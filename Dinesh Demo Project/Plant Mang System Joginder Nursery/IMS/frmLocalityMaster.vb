
Imports System.Data
Imports System.Data.SqlClient

Public Class frmLocalityMaster
    Dim bln_Add As Boolean
    Dim bln_Edit As Boolean
    Dim CityCode As String
    Dim f_LocalityCode As String
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim Search As Integer
    Dim intDGSearchKeayPress As Integer

    Dim da As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds As New DataSet
    Dim da1 As New SqlDataAdapter   'Fro search in State Search
    Dim ds1 As New DataSet

    Private Sub frmLocalityMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        LocalityMaster = Nothing
    End Sub
    Private Sub frmLocalityMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmLocalityMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnableControl(True)
        ClearControl()
        Display()
        cmdAdd.Focus()
    End Sub

    Private Sub ClearControl()
        txtLocalityName.Text = ""
        txtPIN.Text = ""
        txtCityName.Text = ""
        txtStateName.Text = ""

    End Sub
    Private Sub EnableControl(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status
        CmdSearch.Enabled = status
        txtLocalityCode.ReadOnly = True
        txtLocalityName.ReadOnly = status
        txtPIN.ReadOnly = status
        cmdSearchCity.Enabled = Not status

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        EnableControl(False)
        ClearControl()
        bln_Add = True
        bln_Edit = False
        txtLocalityCode.Text = showCode("Locality")
        txtLocalityName.Focus()

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        EnableControl(False)
        bln_Edit = True
        bln_Add = False
        txtLocalityName.Focus()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub
    Private Sub Cancel()

        If bln_Add Or bln_Edit Then

            If MsgQuestion("CANCEL") = 7 Then

                Exit Sub
            End If

        End If
        If bln_Add = True Then
            Display()
        Else
            Display(txtLocalityCode.Text)
        End If


        Call EnableControl(True)

        ''''''''''''flag check
        bln_Add = False
        bln_Edit = False

        cmdAdd.Focus()

    End Sub



    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Save()
    End Sub
    Private Function checkData() As Boolean

        f_blnCheckData = False
        f_strDataCheck = ""


        If Trim(txtLocalityName.Text) = "" Then
            f_strDataCheck = "Locality Name"
            txtLocalityName.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If

        If Trim(txtPIN.Text) = "" Then
            f_strDataCheck = "PIN Code"
            txtPIN.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If

        checkData = f_blnCheckData
    End Function

    Private Sub Save()
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim Trans1 As SqlClient.SqlTransaction


        Try

            f_LocalityCode = txtLocalityCode.Text

            If checkData() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            Else
                If bln_Add = True Then
                    If MsgQuestion("SAVE") = 6 Then


                        str1 = "Insert into LocalityMaster(LocalityCode, LocalityName,CityCode,PINCode,CreatedBy) values('" & txtLocalityCode.Text & "','" & Replace(txtLocalityName.Text, " '", "''") & "','" & CityCode & "','" & Replace(txtPIN.Text, " '", "''") & "','" & gl_EmpName & "')"
                        Trans1 = gl_Con.BeginTransaction
                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()


                        str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='Locality'"

                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()

                        Trans1.Commit()
                        Call EnableControl(True)
                        cmdCom1.Dispose()
                        bln_Add = False

                    Else

                        Exit Sub
                    End If

                ElseIf bln_Edit = True Then

                    If MsgQuestion("UPDATE") = 6 Then


                        str1 = "update LocalityMaster set  LocalityName='" & Replace(txtLocalityName.Text, " '", "''") & "' ,EditedBy='" & gl_EmpName & "',PINCode='" & Replace(txtPIN.Text, " '", "''") & "',CityCode='" & CityCode & "' where LocalityCode='" & txtLocalityCode.Text & "'"

                        Trans1 = gl_Con.BeginTransaction
                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()
                        Trans1.Commit()

                        Call EnableControl(True)
                        bln_Edit = False
                    Else

                        Exit Sub
                    End If
                Else
                    Call EnableControl(True)
                    bln_Add = False
                    bln_Edit = False
                    Call ClearControl()
                End If
            End If


            Call Display(txtLocalityCode.Text)

        Catch ex As Exception
            Trans1.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try


    End Sub

    Public Sub Display(Optional ByVal strLocality As String = "-1")

        Dim cmdCom1 As New SqlCommand
        Dim daDA1 As SqlClient.SqlDataAdapter
        Dim dsDS1 As New DataSet
        Dim str1 As String

        Try

            Call ClearControl()
            If strLocality = "-1" Then



                str1 = "SELECT LocalityMaster.LocalityId, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, LocalityMaster.CityCode, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM (CityMaster INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode) INNER JOIN LocalityMaster ON CityMaster.CityCode = LocalityMaster.CityCode WHERE (LocalityMaster.LocalityId = (SELECT     MAX(LocalityId)  FROM  LocalityMaster))"
            Else
                str1 = "SELECT LocalityMaster.LocalityId, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, LocalityMaster.CityCode, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM (CityMaster INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode) INNER JOIN LocalityMaster ON CityMaster.CityCode = LocalityMaster.CityCode  WHERE   LocalityMaster.LocalityCode='" & strLocality & "'"

            End If

            daDA1 = New SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "LocalityMaster")


            If dsDS1.Tables("LocalityMaster").Rows.Count > 0 Then
                txtLocalityCode.Tag = IIf(IsDBNull(dsDS1.Tables("LocalityMaster").Rows(0).Item("LocalityId")), "", dsDS1.Tables("LocalityMaster").Rows(0).Item("LocalityId"))
                txtLocalityCode.Text = IIf(IsDBNull(dsDS1.Tables("LocalityMaster").Rows(0).Item("LocalityCode")), "", dsDS1.Tables("LocalityMaster").Rows(0).Item("LocalityCode"))
                txtLocalityName.Text = IIf(IsDBNull(dsDS1.Tables("LocalityMaster").Rows(0).Item("LocalityName")), "", dsDS1.Tables("LocalityMaster").Rows(0).Item("LocalityName"))
                txtCityName.Text = IIf(IsDBNull(dsDS1.Tables("LocalityMaster").Rows(0).Item("CityName")), "", dsDS1.Tables("LocalityMaster").Rows(0).Item("CityName"))
                txtStateName.Text = IIf(IsDBNull(dsDS1.Tables("LocalityMaster").Rows(0).Item("StateName")), "", dsDS1.Tables("LocalityMaster").Rows(0).Item("StateName"))
                txtPIN.Text = IIf(IsDBNull(dsDS1.Tables("LocalityMaster").Rows(0).Item("PINCode")), "", dsDS1.Tables("LocalityMaster").Rows(0).Item("PINCode"))
                CityCode = IIf(IsDBNull(dsDS1.Tables("LocalityMaster").Rows(0).Item("CityCode")), "", dsDS1.Tables("LocalityMaster").Rows(0).Item("CityCode"))

            End If
            cmdAdd.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TrapKeyDown(ByVal key As System.Windows.Forms.Keys)
        Try
            Select Case key
                Case Keys.Escape
                    If gbSearch.Visible = True Then
                        gbSearch.SendToBack()
                        gbMain.BringToFront()
                        Panel1.Enabled = True
                    Else
                        If cmdCancel.Enabled = True Then

                            Call Cancel()
                            Exit Sub

                        Else
                            Me.Close()
                        End If
                    End If
            End Select

            '********************Handles Keys*********************
            If cmdCancel.Enabled = False Then
                Dim strMinMaxKey As String
                Dim intCounter As Integer

                'Query for selecting minimum and maximum LocalityId
                strMinMaxKey = "select max(LocalityId) AS MaxId,MIN(LocalityId) As MinId from LocalityMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet


                daMinMaxKey.Fill(dsMinMaxKey, "LocalityMaster")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("LocalityMaster").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select LocalityCode  from LocalityMaster where LocalityId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "LocalityMasterNavigation")

                        txtLocalityCode.Text = dsMinMaxKey.Tables("LocalityMasterNavigation").Rows(0).Item("LocalityCode")
                        Call Display(txtLocalityCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If txtLocalityCode.Tag = dsMinMaxKey.Tables("LocalityMaster").Rows(0).Item("minId") Then
                            nextKey = CDbl(txtLocalityCode.Tag)
                        Else
                            nextKey = CLng(txtLocalityCode.Tag) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("LocalityMaster").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select LocalityCode from LocalityMaster where LocalityId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "LocalityMasterNavigation")

                            If dsMinMaxKey.Tables("LocalityMasterNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("LocalityMaster").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtLocalityCode.Text = dsMinMaxKey.Tables("LocalityMasterNavigation").Rows(0).Item("LocalityCode")
                        Call Display(txtLocalityCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If txtLocalityCode.Tag = dsMinMaxKey.Tables("LocalityMaster").Rows(0).Item("maxId") Then
                            nextKey = CDbl(txtLocalityCode.Tag)
                        Else
                            nextKey = CLng(txtLocalityCode.Tag) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("LocalityMaster").Rows(0).Item("maxId")
                            strNextRecord = "select LocalityCode from LocalityMaster where LocalityId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "LocalityMasterNavigation")

                            If dsMinMaxKey.Tables("LocalityMasterNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("LocalityMaster").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtLocalityCode.Text = dsMinMaxKey.Tables("LocalityMasterNavigation").Rows(0).Item("LocalityCode")
                        Call Display(txtLocalityCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("LocalityMaster").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select LocalityCode from LocalityMaster where LocalityId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "LocalityMasterNavigation")

                        txtLocalityCode.Text = dsMinMaxKey.Tables("LocalityMasterNavigation").Rows(0).Item("LocalityCode")
                        Call Display(txtLocalityCode.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Designgrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 6
            .Columns(0).Name = "S.No"
            .Columns(1).Name = "Locality Code"
            .Columns(2).Name = "Locality Name"
            .Columns(3).Name = "City Name"
            .Columns(4).Name = "State Name"
            .Columns(5).Name = "PIN"
            .Columns(0).Width = 40
            .Columns(1).Width = 60
            .Columns(2).Width = 100
            .Columns(3).Width = 100
            .Columns(4).Width = 100
            .Columns(5).Width = 50
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid1()
        da.Dispose()
        ds.Clear()
        Search = 0
        Try
            lblSearch.Text = "Search Locality Name"
            StrQuery = "SELECT  LocalityMaster.LocalityCode, LocalityMaster.LocalityName, LocalityMaster.CityCode, LocalityMaster.PinCode, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM (CityMaster INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode) INNER JOIN LocalityMaster ON CityMaster.CityCode = LocalityMaster.CityCode ORDER BY LocalityMaster.LocalityCode"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("LocalityCode")), "", ds.Tables("FillGrid").Rows(i).Item("LocalityCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("LocalityName")), "", ds.Tables("FillGrid").Rows(i).Item("LocalityName"))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CityName")), "", ds.Tables("FillGrid").Rows(i).Item("CityName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("StateName")), "", ds.Tables("FillGrid").Rows(i).Item("StateName"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("PinCode")), "", ds.Tables("FillGrid").Rows(i).Item("PinCode"))
                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearch.Text = ""
            txtSearch.Focus()
            gbSearch.BringToFront()
            gbMain.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub
    Private Sub txtLocalityNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalityName.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            Save()
        End If
    End Sub
    Private Sub Designgrid2()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 4
            .Columns(0).Name = "S.No"
            .Columns(1).Name = "City Code"
            .Columns(2).Name = "City Name"
            .Columns(3).Name = "State Name"
            .Columns(0).Width = 40
            .Columns(1).Width = 80
            .Columns(2).Width = 150
            .Columns(3).Width = 150
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Private Sub cmdSearchCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearchCity.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid2()
        da1.Dispose()
        ds1.Clear()
        Search = 1

        Try

            lblSearch.Text = "Search City Name"
            StrQuery = "SELECT     CityMaster.CityCode, CityMaster.CityName, StateMaster.StateName FROM  StateMaster INNER JOIN CityMaster ON StateMaster.StateCode = CityMaster.StateCode ORDER BY CityMaster.CityCode"
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds1, "FillGrid")
            dgSearch.RowCount = 1
            If ds1.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("CityCode")), "", ds1.Tables("FillGrid").Rows(i).Item("CityCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("CityName")), "", ds1.Tables("FillGrid").Rows(i).Item("CityName"))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("StateName")), "", ds1.Tables("FillGrid").Rows(i).Item("StateName"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearch.Text = ""
            txtSearch.Focus()
            gbSearch.BringToFront()
            gbMain.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub txtPIN_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPIN.LostFocus
        txtLocalityName.Focus()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Me.Close()
    End Sub

    Private Sub dgSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.DoubleClick
        Dim i As Integer = dgSearch.RowCount
        Dim RowSelect As Integer
        RowSelect = dgSearch.CurrentRow.Index + 1
        With dgSearch
            If Search = 0 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And RowSelect < i And intDGSearchKeayPress = 1 Then
                        txtLocalityCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtLocalityCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtLocalityCode.Text)
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                End If
            ElseIf Search = 1 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And RowSelect < i And intDGSearchKeayPress = 1 Then
                        CityCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtCityName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtStateName.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        CityCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtCityName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtStateName.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString

                    End If
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                End If
            End If
        End With
    End Sub

    Private Sub dgSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSearch.KeyPress
        Dim e1 As System.EventArgs
        If (e.KeyChar = Convert.ToChar(13)) Then
            intDGSearchKeayPress = 1
            dgSearch_DoubleClick(sender, e1)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable

        Try
            If Search = 0 Then
                dv = New DataView(ds.Tables(0), "LocalityName Like '" & Trim(txtSearch.Text) & "*" & "'", "LocalityCode", DataViewRowState.CurrentRows)
                dTable = dv.ToTable
                dgSearch.RowCount = 1
                If dTable.Rows.Count > 0 Then
                    With dgSearch
                        For i = 0 To dTable.Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = i + 1

                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("LocalityCode")), "", dTable.Rows(i).Item("LocalityCode"))
                            .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("LocalityName")), "", dTable.Rows(i).Item("LocalityName"))

                            .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("CityName")), "", dTable.Rows(i).Item("CityName"))
                            .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("StateName")), "", dTable.Rows(i).Item("StateName"))
                            .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("PinCode")), "", dTable.Rows(i).Item("PinCode"))
                        Next
                        .RowCount = .RowCount - 1
                    End With
                Else
                    dgSearch.RowCount = 0
                End If
            ElseIf Search = 1 Then
                dv = New DataView(ds1.Tables(0), "CityName Like '" & Trim(txtSearch.Text) & "*" & "'", "CityCode", DataViewRowState.CurrentRows)
                dTable = dv.ToTable
                dgSearch.RowCount = 1
                If dTable.Rows.Count > 0 Then
                    With dgSearch
                        For i = 0 To dTable.Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = i + 1

                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("CityCode")), "", dTable.Rows(i).Item("CityCode"))
                            .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("CityName")), "", dTable.Rows(i).Item("CityName"))

                            .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("StateName")), "", dTable.Rows(i).Item("StateName"))

                        Next
                        .RowCount = .RowCount - 1
                    End With
                Else
                    dgSearch.RowCount = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class