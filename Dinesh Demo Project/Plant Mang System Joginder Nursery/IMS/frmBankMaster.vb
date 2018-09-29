
Imports System.Data
Imports System.Data.SqlClient
Public Class frmBankMaster
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim intDGSearchKeayPress As Integer

    Dim da As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds As New DataSet


    Private Sub EnableControl(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status

        txtAccountCode.ReadOnly = True
        txtAccountNo.ReadOnly = status
        txtbankName.ReadOnly = status
        txtBranch.ReadOnly = status
        txtCurrentBal.ReadOnly = True
        txtOpBal.ReadOnly = status

    End Sub
    Private Sub ClearControl()
        txtAccountNo.Text = ""
        txtbankName.Text = ""
        txtBranch.Text = ""
        lblCurrentBalance.Text = 0
        lblOpeningBalance.Text = 0
        txtOpBal.Text = 0
        txtCurrentBal.Text = 0
    End Sub

    Private Sub frmBankMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        BankMaster = Nothing
    End Sub

    Private Sub frmBankMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmBankMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EnableControl(True)
        ClearControl()
        Display()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        EnableControl(False)
        ClearControl()
        bln_AddOn = True
        bln_EditOn = False
        txtAccountCode.Text = showCode("AccId")
        txtAccountNo.Focus()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        EnableControl(False)
        bln_EditOn = True
        bln_AddOn = False
        txtAccountNo.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub
    Private Sub Cancel()

        If bln_AddOn Or bln_EditOn Then

            If MsgQuestion("CANCEL") = 7 Then

                Exit Sub
            End If

        End If
        If bln_AddOn = True Then
            Display()
        Else
            Display(txtAccountCode.Text)
        End If


        Call EnableControl(True)

        ''''''''''''flag check
        bln_AddOn = False
        bln_EditOn = False
        cmdAdd.Focus()

    End Sub
    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Save()
    End Sub

    Private Function checkData() As Boolean

        f_blnCheckData = False
        f_strDataCheck = ""


        If Trim(txtAccountNo.Text) = "" Then
            f_strDataCheck = "AccountNo"
            txtAccountNo.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        ElseIf Trim(txtbankName.Text) = "" Then
            f_strDataCheck = "BankName"
            txtAccountNo.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If

        checkData = f_blnCheckData
    End Function

    Private Sub Save()
        Dim ComSave As SqlClient.SqlCommand
        Dim StrQuery As String
        Dim trn As SqlClient.SqlTransaction

        Try



            If checkData() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            Else
                If bln_AddOn = True Then
                    If MsgQuestion("SAVE") = 6 Then
                        ''''''''inserting data into the table JobCard
                        StrQuery = "insert into BankMaster (AccCode,AccNo,BankName,Branch,OpeningBalance,CurrentBalance)values('" & txtAccountCode.Text & "','" & txtAccountNo.Text & "','" & txtbankName.Text & "','" & txtBranch.Text & "'," & Val(txtOpBal.Text) & ",'" & Val(txtCurrentBal.Text) & "')"

                        trn = gl_Con.BeginTransaction 'Transaction Start

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        StrQuery = "insert into  LedgerMaster  (LedgerCode,OpeningBalance)values('" & txtAccountCode.Text & "'," & Val(txtOpBal.Text) & ")"

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()


                        StrQuery = "Update  sequencemaster set lastvalue=lastvalue+1 where head='AccId'"
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        trn.Commit() ''''''''End transaction

                        Call EnableControl(True)

                        bln_AddOn = False ''setting boolean variable for add completion
                        Call ClearControl()

                    Else

                        Exit Sub
                    End If

                ElseIf bln_EditOn = True Then

                    If MsgQuestion("UPDATE") = 6 Then


                        StrQuery = "Update BankMaster Set AccNo='" & txtAccountNo.Text & "',BankName='" & txtbankName.Text & "', Branch='" & txtBranch.Text & "',OpeningBalance=" & Val(txtOpBal.Text) & ",CurrentBalance=" & Val(txtCurrentBal.Text) & " where AccCode='" & txtAccountCode.Text & "'"

                        trn = gl_Con.BeginTransaction
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        StrQuery = "delete from  LedgerMaster  where LedgerCode='" & txtAccountCode.Text & "'"

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        StrQuery = "insert into  LedgerMaster  (LedgerCode,OpeningBalance)values('" & txtAccountCode.Text & "'," & Val(txtOpBal.Text) & ")"

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()



                        trn.Commit()

                        Call EnableControl(True)

                        bln_EditOn = False
                        Call ClearControl()
                    Else

                        Exit Sub
                    End If
                Else
                    Call EnableControl(True)
                    bln_AddOn = False
                    bln_EditOn = False
                    Call ClearControl()
                End If
            End If


            Call Display(txtAccountCode.Text)

        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Display(Optional ByVal f_display As String = "-1")
        Dim Strquery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try
            If f_display = "-1" Then
                Strquery = "SELECT    * FROM BankMaster WHERE     (Accid =(SELECT     MAX(Accid) FROM          BankMaster)) "
            Else
                Strquery = "SELECT    * FROM BankMaster WHERE    AccCode ='" & txtAccountCode.Text & "'"
            End If

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "BankMaster")
            If ds.Tables("BankMaster").Rows.Count > 0 Then
                lblPrimaryKey.Text = IIf(IsDBNull(ds.Tables("BankMaster").Rows(0).Item("AccId")), "", ds.Tables("BankMaster").Rows(0).Item("AccId"))
                txtAccountCode.Text = IIf(IsDBNull(ds.Tables("BankMaster").Rows(0).Item("AccCode")), "", ds.Tables("BankMaster").Rows(0).Item("AccCode"))
                txtAccountNo.Text = IIf(IsDBNull(ds.Tables("BankMaster").Rows(0).Item("AccNo")), "", ds.Tables("BankMaster").Rows(0).Item("AccNo"))
                txtbankName.Text = IIf(IsDBNull(ds.Tables("BankMaster").Rows(0).Item("BankName")), "", ds.Tables("BankMaster").Rows(0).Item("BankName"))
                txtBranch.Text = IIf(IsDBNull(ds.Tables("BankMaster").Rows(0).Item("Branch")), "", ds.Tables("BankMaster").Rows(0).Item("Branch"))
                txtOpBal.Text = IIf(IsDBNull(ds.Tables("BankMaster").Rows(0).Item("OpeningBalance")), "", ds.Tables("BankMaster").Rows(0).Item("OpeningBalance"))
                txtCurrentBal.Text = IIf(IsDBNull(ds.Tables("BankMaster").Rows(0).Item("CurrentBalance")), "", ds.Tables("BankMaster").Rows(0).Item("CurrentBalance"))
                lblCurrentBalance.Text = IIf(IsDBNull(ds.Tables("BankMaster").Rows(0).Item("CurrentBalance")), "", ds.Tables("BankMaster").Rows(0).Item("CurrentBalance"))
                lblOpeningBalance.Text = IIf(IsDBNull(ds.Tables("BankMaster").Rows(0).Item("OpeningBalance")), "", ds.Tables("BankMaster").Rows(0).Item("OpeningBalance"))


            End If
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

                'Query for selecting minimum and maximum ItemID
                strMinMaxKey = "select max(AccId) AS MaxId,MIN(AccId) As MinId from BankMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet

                'fill the dataset with min and max Id's 
                'give the name to table "ItemID"

                daMinMaxKey.Fill(dsMinMaxKey, "Bank")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("Bank").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select AccCode  from BankMaster where AccId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "BankNavigation")

                        txtAccountCode.Text = dsMinMaxKey.Tables("BankNavigation").Rows(0).Item("AccCode")
                        Call Display(txtAccountCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Bank").Rows(0).Item("minId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Bank").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select AccCode from BankMaster where AccId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "BankNavigation")

                            If dsMinMaxKey.Tables("BankNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Bank").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtAccountCode.Text = dsMinMaxKey.Tables("BankNavigation").Rows(0).Item("AccCode")
                        Call Display(txtAccountCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Bank").Rows(0).Item("maxId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Bank").Rows(0).Item("maxId")
                            strNextRecord = "select AccCode from BankMaster where AccId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "BankNavigation")

                            If dsMinMaxKey.Tables("BankNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Bank").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtAccountCode.Text = dsMinMaxKey.Tables("BankNavigation").Rows(0).Item("AccCode")
                        Call Display(txtAccountCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Bank").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select AccCode from BankMaster where AccId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "BankNavigation")

                        txtAccountCode.Text = dsMinMaxKey.Tables("BankNavigation").Rows(0).Item("AccCode")
                        Call Display(txtAccountCode.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        da.Dispose()
        ds.Clear()
        Designgrid()

        Try
            StrQuery = "Select AccNo,AccCode,BankName,Branch from BankMaster order by BankName"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AccCode")), "", ds.Tables("FillGrid").Rows(i).Item("AccCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AccNo")), "", ds.Tables("FillGrid").Rows(i).Item("AccNo"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("BankName")), "", ds.Tables("FillGrid").Rows(i).Item("BankName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Branch")), "", ds.Tables("FillGrid").Rows(i).Item("Branch"))


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
    Private Sub Designgrid()

        With dgSearch
            .RowCount = 1
            .ColumnCount = 5
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Bank Code"
            .Columns(1).Width = 80
            .columns(1).Visible = False
            .Columns(2).Name = "Acc NO"
            .Columns(2).Width = 160
            .Columns(3).Name = "Bank Name"
            .Columns(3).Width = 150
            .Columns(4).Name = "Branch"
            .Columns(4).Width = 150
            .Columns(4).Visible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        'Dim Strquery As String
        'Dim da As SqlClient.SqlDataAdapter
        'Dim ds As New DataSet
        'Dim i As Integer


        'With fgSearch

        '    .Editable = VSFlex7L.EditableSettings.flexEDNone
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow

        '    .Rows = 1
        '    .Cols = 5
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "BankCode")
        '    .set_ColWidth(1, 1000)
        '    .set_ColHidden(1, True)
        '    .set_TextMatrix(0, 2, "AccNo")
        '    .set_ColWidth(2, 1500)
        '    .set_ColFormat(2, Left)
        '    .set_TextMatrix(0, 3, "BankName")
        '    .set_ColWidth(3, 1500)
        '    .set_TextMatrix(0, 4, "Branch")
        '    .set_ColWidth(4, 1500)
        '    .set_ColHidden(4, True)
        'End With

        'Strquery = "Select AccNo,AccCode,BankName,Branch from BankMaster order by BankName"
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")
        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AccCode")), "", ds.Tables("FillGrid").Rows(i).Item("AccCode")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AccNo")), "", ds.Tables("FillGrid").Rows(i).Item("AccNo")))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("BankName")), "", ds.Tables("FillGrid").Rows(i).Item("BankName")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Branch")), "", ds.Tables("FillGrid").Rows(i).Item("Branch")))
        '        Next
        '    End If


        'End With



    End Sub
    Private Sub txtCurrentBal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCurrentBal.LostFocus
        txtAccountNo.Focus()
    End Sub

    Private Sub txtOpBal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOpBal.TextChanged
        Dim diff As Double
        diff = Val(lblOpeningBalance.Text) - Val(txtOpBal.Text)
        txtCurrentBal.Text = Val(lblCurrentBalance.Text) - diff
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable


        Try
            dv = New DataView(ds.Tables(0), "BankName Like '" & Trim(txtSearch.Text) & "*" & "'", "AccCode", DataViewRowState.CurrentRows)
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("AccCode")), "", dTable.Rows(i).Item("AccCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("AccNo")), "", dTable.Rows(i).Item("AccNo"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("BankName")), "", dTable.Rows(i).Item("BankName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("Branch")), "", dTable.Rows(i).Item("Branch"))


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

    Private Sub dgSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.DoubleClick
        With dgSearch
            If dgSearch.RowCount = 0 Then
                MessageBox.Show("No Record Found")
                gbMain.BringToFront()
                gbSearch.SendToBack()
                Exit Sub
            Else
                If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                    txtAccountCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                Else
                    txtAccountCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                End If
                intDGSearchKeayPress = 0
                Display(txtAccountCode.Text)
                gbMain.BringToFront()
                gbSearch.SendToBack()

            End If
            Panel1.Enabled = True
        End With

    End Sub

    Private Sub dgSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSearch.KeyPress
        Dim e1 As System.EventArgs
        If (e.KeyChar = Convert.ToChar(13)) Then
            intDGSearchKeayPress = 1
            dgSearch_DoubleClick(sender, e1)
        End If
    End Sub
End Class