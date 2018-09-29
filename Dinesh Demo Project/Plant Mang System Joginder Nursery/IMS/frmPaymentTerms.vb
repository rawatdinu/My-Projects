Imports System.Data
Imports System.Data.SqlClient
Public Class frmPaymentTerms
    Dim bln_Add As Boolean
    Dim bln_Edit As Boolean
    Dim f_termID As String
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim intDGSearchKeayPress As Integer

    Dim da As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds As New DataSet


    Private Sub frmPaymentTerms_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        PaymentTermMaster = Nothing
    End Sub
    Private Sub frmPaymentTerms_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmPaymentTerms_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnableControl(True)
        Display()
        cmdAdd.Focus()
    End Sub

    Private Sub ClearControl()

        txtDescription.Text = ""
        txtDays.Text = ""

    End Sub
    Private Sub EnableControl(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status
        cmdSearch.Enabled = status
        txtPaymentTermID.ReadOnly = True
        txtDescription.ReadOnly = status
        txtDays.ReadOnly = status

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        EnableControl(False)
        ClearControl()
        bln_Add = True
        bln_Edit = False
        txtPaymentTermID.Text = showCode("PaymentTerm")
        txtDays.Focus()

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        EnableControl(False)
        bln_Edit = True
        bln_Add = False
        txtDescription.Focus()

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
            Display(txtPaymentTermID.Text)
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


        If Trim(txtDescription.Text) = "" Then
            f_strDataCheck = "Description Name"
            txtDescription.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If


        If Val(txtDays.Text) = 0 Then
            f_strDataCheck = "No Of Days"
            txtDays.Focus()
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

            f_termID = txtPaymentTermID.Text

            If checkData() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            Else
                If bln_Add = True Then
                    If MsgQuestion("SAVE") = 6 Then


                        str1 = "Insert into PaymentTermMaster(PaymentTermCode,Days, Description,CreatedBy) values('" & txtPaymentTermID.Text & "'," & Val(txtDays.Text) & ",'" & Replace(txtDescription.Text, " '", "''") & "','" & gl_EmpName & "')"
                        Trans1 = gl_Con.BeginTransaction
                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()


                        str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='PaymentTerm'"

                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()

                        Trans1.Commit()
                        Call EnableControl(True)
                        cmdCom1.Dispose()

                        bln_Add = False

                        'Call Display(Trim(txtPaymentTermCode.Text))


                    Else

                        Exit Sub
                    End If

                ElseIf bln_Edit = True Then

                    If MsgQuestion("UPDATE") = 6 Then


                        str1 = "update PaymentTermMaster set Days=" & Val(txtDays.Text) & ", Description='" & Replace(txtDescription.Text, " '", "''") & "' ,EditedBy='" & gl_EmpName & "' where PaymentTermCode='" & txtPaymentTermID.Text & "'"

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

            Call Display(txtPaymentTermID.Text)

        Catch ex As Exception
            Trans1.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try


    End Sub

    Public Sub Display(Optional ByVal strDescription As String = "-1")

        Dim cmdCom1 As New SqlCommand
        Dim daDA1 As SqlClient.SqlDataAdapter
        Dim dsDS1 As New DataSet
        Dim str1 As String

        Try

            Call ClearControl()
            If strDescription = "-1" Then

                str1 = "SELECT  Code,PaymentTermCode, Days,  Description from PaymentTermMaster WHERE     (PaymentTermMaster.Code = (SELECT     MAX(Code)  FROM  PaymentTermMaster))"
            Else
                str1 = "SELECT Code,PaymentTermCode, Days,  Description from PaymentTermMaster WHERE   PaymentTermMaster.PaymentTermCode='" & strDescription & "'"

            End If

            daDA1 = New SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "PaymentTermMaster")


            If dsDS1.Tables("PaymentTermMaster").Rows.Count > 0 Then
                txtPaymentTermID.Tag = IIf(IsDBNull(dsDS1.Tables("PaymentTermMaster").Rows(0).Item("Code")), "", dsDS1.Tables("PaymentTermMaster").Rows(0).Item("Code"))
                txtPaymentTermID.Text = IIf(IsDBNull(dsDS1.Tables("PaymentTermMaster").Rows(0).Item("PaymentTermCode")), "", dsDS1.Tables("PaymentTermMaster").Rows(0).Item("PaymentTermCode"))
                txtDescription.Text = IIf(IsDBNull(dsDS1.Tables("PaymentTermMaster").Rows(0).Item("Description")), "", dsDS1.Tables("PaymentTermMaster").Rows(0).Item("Description"))
                txtDays.Text = IIf(IsDBNull(dsDS1.Tables("PaymentTermMaster").Rows(0).Item("Days")), 0, dsDS1.Tables("PaymentTermMaster").Rows(0).Item("Days"))

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

                'Query for selecting minimum and maximum Code
                strMinMaxKey = "select max(Code) AS MaxId,MIN(Code) As MinId from PaymentTermMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet


                daMinMaxKey.Fill(dsMinMaxKey, "PaymentTermMaster")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("PaymentTermMaster").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select PaymentTermCode  from PaymentTermMaster where Code=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PaymentTermMasterNavigation")

                        txtPaymentTermID.Text = dsMinMaxKey.Tables("PaymentTermMasterNavigation").Rows(0).Item("PaymentTermCode")
                        Call Display(txtPaymentTermID.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If txtPaymentTermID.Tag = dsMinMaxKey.Tables("PaymentTermMaster").Rows(0).Item("minId") Then
                            nextKey = CDbl(txtPaymentTermID.Tag)
                        Else
                            nextKey = CLng(txtPaymentTermID.Tag) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("PaymentTermMaster").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select PaymentTermCode from PaymentTermMaster where Code=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PaymentTermMasterNavigation")

                            If dsMinMaxKey.Tables("PaymentTermMasterNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("PaymentTermMaster").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtPaymentTermID.Text = dsMinMaxKey.Tables("PaymentTermMasterNavigation").Rows(0).Item("PaymentTermCode")
                        Call Display(txtPaymentTermID.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If txtPaymentTermID.Tag = dsMinMaxKey.Tables("PaymentTermMaster").Rows(0).Item("maxId") Then
                            nextKey = CDbl(txtPaymentTermID.Tag)
                        Else
                            nextKey = CLng(txtPaymentTermID.Tag) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("PaymentTermMaster").Rows(0).Item("maxId")
                            strNextRecord = "select PaymentTermCode from PaymentTermMaster where Code=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PaymentTermMasterNavigation")

                            If dsMinMaxKey.Tables("PaymentTermMasterNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("PaymentTermMaster").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtPaymentTermID.Text = dsMinMaxKey.Tables("PaymentTermMasterNavigation").Rows(0).Item("PaymentTermCode")
                        Call Display(txtPaymentTermID.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("PaymentTermMaster").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select PaymentTermCode from PaymentTermMaster where Code=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PaymentTermMasterNavigation")

                        txtPaymentTermID.Text = dsMinMaxKey.Tables("PaymentTermMasterNavigation").Rows(0).Item("PaymentTermCode")
                        Call Display(txtPaymentTermID.Text)
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
            .ColumnCount = 3
            .Columns(0).Name = "S.No"
            .Columns(1).Name = "PayTerm Code"
            .Columns(2).Name = "Description"
            .Columns(0).Width = 50
            .Columns(1).Width = 100
            .Columns(2).Width = 160
            .RowTemplate.Height = 17
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

        'With fgSearch
        '    .Width = 289
        '    .Height = 164

        '    .Editable = VSFlex7L.EditableSettings.flexEDNone
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow

        '    .Rows = 1
        '    .Cols = 3
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "PaymentTermCode")
        '    .set_ColWidth(1, 1200)

        '    .set_TextMatrix(0, 2, "Description")
        '    .set_ColWidth(2, 2500)

        'End With

        'Strquery = "SELECT PaymentTermCode,Description from PaymentTermMaster  order by  Description"

        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")
        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("PaymentTermCode")), "", ds.Tables("FillGrid").Rows(i).Item("PaymentTermCode")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Description")), "", ds.Tables("FillGrid").Rows(i).Item("Description")))

        '        Next
        '    End If


        'End With



    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub
    Private Sub txtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            Save()
        End If
    End Sub

    Private Sub txtDays_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDays.KeyPress
        Allowcharacter(e)
    End Sub

    Private Sub cmdCancel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.LostFocus
        txtDescription.Focus()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Me.Close()
    End Sub

    Private Sub txtDays_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDays.LostFocus
        txtDescription.Focus()
    End Sub

    Private Sub txtDescription_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.LostFocus
        txtDays.Focus()
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid()
        da.Dispose()
        ds.Clear()

        Try
            StrQuery = "SELECT PaymentTermCode,Description from PaymentTermMaster  order by  Description"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("PaymentTermCode")), "", ds.Tables("FillGrid").Rows(i).Item("PaymentTermCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Description")), "", ds.Tables("FillGrid").Rows(i).Item("Description"))


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

    Private Sub dgSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.DoubleClick
        With dgSearch
            If dgSearch.RowCount = 0 Then
                MessageBox.Show("No Record Found")
                gbMain.BringToFront()
                gbSearch.SendToBack()
                Exit Sub
            Else
                If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                    txtPaymentTermID.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                Else
                    txtPaymentTermID.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                End If
                intDGSearchKeayPress = 0
                Display(txtPaymentTermID.Text)
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

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable

        Try
            dv = New DataView(ds.Tables(0), "Description Like '" & Trim(txtSearch.Text) & "*" & "'", "PaymentTermCode", DataViewRowState.CurrentRows)
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("PaymentTermCode")), "", dTable.Rows(i).Item("PaymentTermCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("Description")), "", dTable.Rows(i).Item("Description"))


                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class