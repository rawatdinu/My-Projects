
Imports System.Data
Imports System.Data.SqlClient
Public Class frmStateMaster
    Dim bln_Add As Boolean
    Dim bln_Edit As Boolean
    Dim Statecode As String
    Dim f_StateCode As String
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim intDGSearchKeayPress As Integer
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
   



    Private Sub frmStateMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        StateMaster = Nothing
    End Sub
    Private Sub frmStateMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmStateMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnableControl(True)
        ClearControl()
        Display()
        cmdAdd.Focus()
    End Sub

    Private Sub ClearControl()
        txtStateName.Text = ""

    End Sub
    Private Sub EnableControl(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status
        cmdSearch.Enabled = status
        txtStateCode.ReadOnly = True
        txtStateName.ReadOnly = status

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        EnableControl(False)
        ClearControl()
        bln_Add = True
        bln_Edit = False
        txtStateCode.Text = showCode("State")
        txtStateName.Focus()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        EnableControl(False)
        bln_Edit = True
        bln_Add = False
        txtStateName.Focus()
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
            Display(txtStateCode.Text)
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


        If Trim(txtStateName.Text) = "" Then
            f_strDataCheck = "State Name"
            txtStateName.Focus()
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

            f_StateCode = txtStateCode.Text

            If checkData() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            Else
                If bln_Add = True Then
                    If MsgQuestion("SAVE") = 6 Then


                        str1 = "Insert into StateMaster(StateCode, StateName,CreatedBy) values('" & txtStateCode.Text & "','" & Replace(txtStateName.Text, " '", "''") & "','" & gl_EmpName & "')"
                        Trans1 = gl_Con.BeginTransaction
                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()


                        str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='State'"

                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()

                        Trans1.Commit()
                        Call EnableControl(True)
                        bln_Add = False
                        cmdCom1.Dispose()

                    Else

                        Exit Sub
                    End If

                ElseIf bln_Edit = True Then

                    If MsgQuestion("UPDATE") = 6 Then


                        str1 = "update StateMaster set  StateName='" & Replace(txtStateName.Text, " '", "''") & "' ,EditedBy='" & gl_EmpName & "' where StateCode='" & txtStateCode.Text & "'"

                        Trans1 = gl_Con.BeginTransaction
                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()
                        Trans1.Commit()
                        cmdCom1.Dispose()
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


            Call Display(txtStateCode.Text)

        Catch ex As Exception
            Trans1.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try


    End Sub

    Public Sub Display(Optional ByVal strState As String = "-1")

        Dim cmdCom1 As New SqlCommand
        Dim daDA1 As SqlClient.SqlDataAdapter
        Dim dsDS1 As New DataSet
        Dim str1 As String

        Try

            Call ClearControl()
            If strState = "-1" Then

                str1 = "SELECT  Stateid,Statecode,   StateName from Statemaster WHERE     (StateMaster.StateId = (SELECT     MAX(StateId)  FROM  StateMaster))"
            Else
                str1 = "SELECT Stateid,Statecode,   StateName from Statemaster WHERE   StateMaster.StateCode='" & strState & "'"

            End If

            daDA1 = New SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "StateMaster")


            If dsDS1.Tables("StateMaster").Rows.Count > 0 Then
                txtStateCode.Tag = IIf(IsDBNull(dsDS1.Tables("StateMaster").Rows(0).Item("StateId")), "", dsDS1.Tables("StateMaster").Rows(0).Item("StateId"))
                txtStateCode.Text = IIf(IsDBNull(dsDS1.Tables("StateMaster").Rows(0).Item("StateCode")), "", dsDS1.Tables("StateMaster").Rows(0).Item("StateCode"))
                txtStateName.Text = IIf(IsDBNull(dsDS1.Tables("StateMaster").Rows(0).Item("StateName")), "", dsDS1.Tables("StateMaster").Rows(0).Item("StateName"))

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

                'Query for selecting minimum and maximum StateId
                strMinMaxKey = "select max(StateId) AS MaxId,MIN(StateId) As MinId from StateMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet


                daMinMaxKey.Fill(dsMinMaxKey, "StateMaster")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("StateMaster").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select StateCode  from StateMaster where StateId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "StateMasterNavigation")

                        txtStateCode.Text = dsMinMaxKey.Tables("StateMasterNavigation").Rows(0).Item("StateCode")
                        Call Display(txtStateCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If txtStateCode.Tag = dsMinMaxKey.Tables("StateMaster").Rows(0).Item("minId") Then
                            nextKey = CDbl(txtStateCode.Tag)
                        Else
                            nextKey = CLng(txtStateCode.Tag) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("StateMaster").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select StateCode from StateMaster where StateId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "StateMasterNavigation")

                            If dsMinMaxKey.Tables("StateMasterNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("StateMaster").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtStateCode.Text = dsMinMaxKey.Tables("StateMasterNavigation").Rows(0).Item("StateCode")
                        Call Display(txtStateCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If txtStateCode.Tag = dsMinMaxKey.Tables("StateMaster").Rows(0).Item("maxId") Then
                            nextKey = CDbl(txtStateCode.Tag)
                        Else
                            nextKey = CLng(txtStateCode.Tag) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("StateMaster").Rows(0).Item("maxId")
                            strNextRecord = "select StateCode from StateMaster where StateId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "StateMasterNavigation")

                            If dsMinMaxKey.Tables("StateMasterNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("StateMaster").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtStateCode.Text = dsMinMaxKey.Tables("StateMasterNavigation").Rows(0).Item("StateCode")
                        Call Display(txtStateCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("StateMaster").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select StateCode from StateMaster where StateId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "StateMasterNavigation")

                        txtStateCode.Text = dsMinMaxKey.Tables("StateMasterNavigation").Rows(0).Item("StateCode")
                        Call Display(txtStateCode.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Designgrid()
       

        With dgSearch
            .RowCount = 1
            .ColumnCount = 5
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 50
            .Columns(1).Name = "StateCode"
            .Columns(1).Width = 90
            .Columns(2).Name = "State Name"
            .Columns(2).Width = 160

            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

    End Sub


    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub
    Private Sub txtStateName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStateName.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            Save()
        End If
    End Sub
    Private Sub cmdCancel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.LostFocus
        txtStateName.Focus()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try

            dv = New DataView(ds.Tables(0), "StateName Like '" & Trim(txtSearch.Text) & "*" & "'", "Statecode", DataViewRowState.CurrentRows)

            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then

                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("Statecode")), "", dTable.Rows(i).Item("Statecode"))
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("Statecode")), "", dTable.Rows(i).Item("Statecode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("StateName")), "", dTable.Rows(i).Item("StateName"))


                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        't = DataSet1.Tables("Orders")
        '' Presuming the DataTable has a column named Date.
        'Dim strExpr As String
        'strExpr = "Date > '1/1/00'"
        'Dim foundRows() As DataRow
        '' Use the Select method to find all rows matching the filter.
        'foundRows = t.Select(strExpr)
        'Dim i As Integer
        '' Print column 0 of each returned row.
        'For i = 0 To foundRows.GetUpperBound(0)
        '    Console.WriteLine(foundRows(i)(0))
        'Next i
        'End Sub




        'Dim dv As DataView
        'dv = New DataView(ds.Tables("FillGrid"))
        'dv.RowFilter = "StateName = '" & txtSearch.Text & "'", 
        ''i = DataViewRowState.CurrentRows()

        'Dim intLoop As Integer
        'Dim intLength As Integer
        'intLength = Len(txtSearch.Text)
        'If dgSearch.RowCount > 1 Then
        '    For intLoop = 0 To dgSearch.RowCount - 1
        '        'If LCase(txtSearch.Text) = LCase(Mid(dgSearch.get_TextMatrix(intLoop, 0), 1, intLength)) Then
        '        If LCase(txtSearch.Text) = LCase(Mid(dgSearch.Rows(intLoop).Cells(2).Value.ToString, 1, intLength)) Then
        '            f_intRowFound = intLoop
        '            dgSearch.RowCount = f_intRowFound
        '            dgSearch.Rows(f_intRowFound).Selected = True
        '            Exit Sub
        '        Else
        '            dgSearch.RowCount = f_intRowFound
        '            dgSearch.Rows(f_intRowFound).Selected = True
        '        End If
        '    Next
        'End If

        ''Associate the dataview to _oDs (Dataset table)
        ''dv.Table = ds.Tables("FillGrid")

        ''Dim drv As New  'Data Row View object to query DataView object

        ''Filter based on a combo box value selected
        ''dv.RowFilter = "[StateName] = " & txtSearch.Text

        'Dim drv As DataView = New DataView(ds.Tables("FillGrid"), "StateName  Like '" + txtSearch.Text + "%'", "", DataViewRowState.CurrentRows)

        ''Retrieve my values returned in the result
        ''For Each drv In dv
        ''    _dteDateModified = drv("dteDateModified")
        ''Next

    End Sub

    Private Sub dgSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.DoubleClick
        Dim i As Integer = dgSearch.RowCount
        Dim RowSelect As Integer
        With dgSearch
            If dgSearch.RowCount = 0 Then
                MessageBox.Show("No Record Found")
                gbMain.BringToFront()
                gbSearch.SendToBack()
                Exit Sub
            Else
                If .RowCount > 1 And intDGSearchKeayPress = 1 Then

                    txtStateCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                ElseIf .RowCount = i And intDGSearchKeayPress = 1 Then
                    txtStateCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                Else
                    txtStateCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                End If


                intDGSearchKeayPress = 0
                Display(txtStateCode.Text)
                gbMain.BringToFront()
                gbSearch.SendToBack()

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

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid()
        da.Dispose()
        ds.Clear()
        Try
            StrQuery = "SELECT Statecode,   StateName from Statemaster ORDER BY Statecode"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")

            'dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Statecode")), "", ds.Tables("FillGrid").Rows(i).Item("Statecode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("StateName")), "", ds.Tables("FillGrid").Rows(i).Item("StateName"))


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
End Class