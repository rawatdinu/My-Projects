Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class frmJournalVoucher1
    Dim f_blnAddOn As Boolean
    Dim f_blnPrint As Boolean
    Dim f_blnEditOn As Boolean

    Dim f_intRowFound As Integer
    Dim f_strDataCheck As String 'save error messages
    Dim f_blnCheckData As Boolean 'save status

    Dim str_GridDataCheck As String    'To check Numeric data in DgDetail
    Dim bln_GridData As Boolean          'data before save

    Dim StrCode As String
    Dim cash As Integer
    Dim Mode As String
    Dim CashEdit As Integer
    Dim AmountEdit As Integer
    Dim cheque As Integer
    Dim f_ctl As Control
    Dim ModeOfPayment As String
    Dim ledgerCode As String
    Dim intDGSearchKeayPress As Integer

    Dim da As New SqlDataAdapter       'da adapter of gbsearch
    Dim ds As New DataSet               ' ds for gbsearch

    Private Sub frmJournalVoucher1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        JournalVoucher1 = Nothing
    End Sub

    Private Sub frmJournalVoucher1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmJournalVoucher1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DesignGrid()
        Call ControlStatus(False)
        dtpChequeDate.Value = Now
        dtpVoucherDate.Value = Now
        gbCheque.Enabled = False
        ClearControl()
        Display()
        gbSearch.SendToBack()
        gbMain.BringToFront()
    End Sub
    Private Sub DesignGrid()

        With dgDetail

            .RowCount = 1
            .ColumnCount = 5
            .Columns(0).Name = "S#"
            .Columns(0).Width = 35
            .Columns(1).Name = "Description"
            .Columns(1).Width = 189
            .Columns(2).Name = "Amount"
            .Columns(2).Width = 80
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).Name = "Discount"
            .Columns(3).Width = 80
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).Name = "Total Amt"
            .Columns(4).Width = 80
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .RowTemplate.Height = 17
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            If f_blnAddOn = True Or f_blnEditOn = True Then
                dgDetail.EditMode = DataGridViewEditMode.EditOnEnter
            Else
                dgDetail.EditMode = DataGridViewEditMode.EditProgrammatically
            End If

        End With

    End Sub
    Private Sub ControlStatus(ByVal status As Boolean)
        cmdAdd.Enabled = Not status
        cmdEdit.Enabled = Not status
        cmdCancel.Enabled = status
        cmdSave.Enabled = status
        cmdExit.Enabled = Not status
        cmdSearch.Enabled = Not status
        cmdAddRow.Enabled = status
        cmdDelRow.Enabled = status

        txtVoucherNo.ReadOnly = True
        txtBankName.ReadOnly = Not status
        txtNetAmount.ReadOnly = Not status
        txtDiscount.ReadOnly = Not status
        txtReceivedBy.ReadOnly = Not status
        txtRemarks.ReadOnly = Not status
        txtChequeNo.ReadOnly = Not status
        dtpVoucherDate.Enabled = status
        optCash.Enabled = status
        optCheque.Enabled = status


        If cmdSave.Enabled = True Then
            If optCheque.Checked = True Then
                cboAccNo.BringToFront()
                dtpChequeDate.BringToFront()
                txtAccNo.SendToBack()
                txtChequeDate.SendToBack()
            Else
                cboAccNo.SendToBack()
                dtpChequeDate.SendToBack()
                txtAccNo.BringToFront()
                txtChequeDate.BringToFront()
            End If
            dtpVoucherDate.BringToFront()
            txtVoucherDate.SendToBack()
        Else
            cboAccNo.SendToBack()
            dtpChequeDate.SendToBack()
            dtpVoucherDate.SendToBack()
            txtAccNo.BringToFront()
            txtChequeDate.BringToFront()
            txtVoucherDate.BringToFront()
        End If

    End Sub
    Private Sub ClearControl()
        txtBankName.Text = ""
        cboAccNo.Text = ""
        txtChequeNo.Text = ""
        txtReceivedBy.Text = ""
        txtRemarks.Text = ""
        txtDiscount.Text = 0
        txtNetAmount.Text = 0
        txtAmount.Text = 0
        dgDetail.RowCount = 0
        lblAccNo.Text = ""
    End Sub

    Private Sub optCash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCash.Click
        If optCash.Checked = True Then
            ModeOfPayment = "Cash"
            cash = 1
            cheque = 0
            gbCheque.Enabled = False
            txtAccNo.Text = ""
            Mode = "Cash"
            txtBankName.Text = ""
        End If

        If optCheque.Checked = True Then
            cboAccNo.BringToFront()
            dtpChequeDate.BringToFront()
            txtAccNo.SendToBack()
            txtChequeDate.SendToBack()
        Else
            cboAccNo.SendToBack()
            dtpChequeDate.SendToBack()
            txtAccNo.BringToFront()
            txtChequeDate.BringToFront()
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        f_blnAddOn = True
        f_blnEditOn = False
        dtpVoucherDate.Value = Now
        dtpChequeDate.Value = Now
        Call ControlStatus(True)
        Call ClearControl()
        txtVoucherNo.Text = showCode("Journal")
        cash = 1
        Mode = "Cash"
        optCash_Click(sender, e)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        f_blnEditOn = True
        f_blnAddOn = False

        Call ControlStatus(True)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub
    Private Sub Cancel()

        If f_blnAddOn Or f_blnEditOn Then

            If MsgQuestion("CANCEL") = 7 Then

                Exit Sub
            End If

        End If
        If f_blnAddOn = True Then
            Display()
        Else
            Display(txtVoucherNo.Text)
        End If


        Call ControlStatus(False)

        ''''''''''''flag check
        f_blnAddOn = False
        f_blnEditOn = False


        cmdAdd.Focus()

    End Sub

    Private Sub optCheque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCheque.Click
        If optCheque.Checked = True Then
            txtChequeNo.ReadOnly = False
            txtBankName.ReadOnly = False
            ModeOfPayment = "Cheque"
            cash = 0
            cheque = 1
            gbCheque.Enabled = True
            Mode = "Cheque"
        End If
        If optCheque.Checked = True Then
            cboAccNo.BringToFront()
            dtpChequeDate.BringToFront()
            txtAccNo.SendToBack()
            txtChequeDate.SendToBack()
        Else
            cboAccNo.SendToBack()
            dtpChequeDate.SendToBack()
            txtAccNo.BringToFront()
            txtChequeDate.BringToFront()
        End If
    End Sub
    Private Function CheckData() As Boolean
        Dim i As Integer
        f_blnCheckData = False
        f_strDataCheck = ""

        If Trim(txtReceivedBy.Text) = "" Then
            f_strDataCheck = "Received By"
            txtReceivedBy.Focus()
            f_blnCheckData = True
            CheckData = True
            Exit Function
        End If
        With dgDetail
            For i = 0 To .RowCount - 1
                If Trim(.Rows(i).Cells(2).Value) = "" Then
                    f_strDataCheck = "Amount"
                    .CurrentCell = .Item(2, i)
                    f_blnCheckData = True
                    CheckData = True
                    Exit Function
                End If
            Next
        End With
        
        CheckData = f_blnCheckData
    End Function
    Private Function CheckData1() As Boolean
        Dim i As Integer
        bln_GridData = False
        str_GridDataCheck = ""

        With dgDetail

            For i = 0 To .RowCount - 1
                If IsNumeric(.Rows(i).Cells(2).Value) = False Then
                    str_GridDataCheck = "Invalid Amount"
                    .CurrentCell = .Item(2, i)
                    bln_GridData = True
                    CheckData1 = True
                    Exit Function
                End If
                If Len(.Rows(i).Cells(3).Value) > 0 Then
                    If IsNumeric(.Rows(i).Cells(3).Value) = False Then
                        str_GridDataCheck = "Invalid Discount"
                        .CurrentCell = .Item(3, i)
                        bln_GridData = True
                        CheckData1 = True
                        Exit Function
                    End If
                End If
            Next
        End With

        CheckData1 = bln_GridData
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Call Save()
    End Sub
    Private Sub Save()
        Dim StrQuery As String
        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction
        Dim introw As Integer

        Try
            If optCash.Checked = True Then
                cash = 1
                Mode = "Cash"
            ElseIf optCheque.Checked = True Then
                cash = 0
                Mode = "Cheque"
            End If



            If CheckData() = True Then
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Me.ActiveControl.Focus()
                Exit Sub
            Else
                If CheckData1() = True Then
                    MessageBox.Show(str_GridDataCheck)
                    Exit Sub
                End If

                If f_blnAddOn = True Then
                    StrCode = txtVoucherNo.Text
                    If MsgQuestion("SAVE") = 6 Then

                        trn = gl_Con.BeginTransaction()

                        StrQuery = "insert into JournalMaster(VoucherNo,VoucherDate,ReceivedBy,BankCode,AccNo,ChequeNo,ChequeDate,BankName,Remarks,CreatedBy,Cash,Amount,Discount,NetAmount) values('" & Trim(Replace(txtVoucherNo.Text, "'", "''")) & "','" & convertToServerDateFormat(dtpVoucherDate.Value) & "','" & txtReceivedBy.Text & "','" & ledgerCode & "','" & Trim(Replace(lblAccNo.Text, "'", "''")) & "','" & Trim(Replace(txtChequeNo.Text, "'", "''")) & "','" & convertToServerDateFormat(dtpChequeDate.Value) & "','" & Trim(Replace(txtBankName.Text, "'", "''")) & "','" & Trim(Replace(txtRemarks.Text, "'", "''")) & "','" & gl_EmpName & "'," & cash & "," & Val(txtAmount.Text) & "," & Val(txtDiscount.Text) & "," & Val(txtNetAmount.Text) & ")"

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        With dgDetail
                            For i = 0 To .RowCount - 1
                                StrQuery = "insert into JournalDetail(VoucherNo,Description,Amount,Discount,TotalAmt) values('" & Trim(Replace(txtVoucherNo.Text, "'", "''")) & "','" & (.Rows(i).Cells(1).Value.ToString) & "'," & Val(.Rows(i).Cells(2).Value) & "," & Val(.Rows(i).Cells(3).Value) & "," & Val(.Rows(i).Cells(4).Value) & ")"
                                ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                                ComSave.CommandType = CommandType.Text
                                ComSave.Transaction = trn
                                ComSave.ExecuteNonQuery()
                            Next
                        End With


                        If optCash.Checked = True Then
                            StrQuery = "update CompanyMaster1 set CurrentBalance = CurrentBalance- " & Val(txtNetAmount.Text) & " "
                            ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                            ComSave.CommandType = CommandType.Text
                            ComSave.Transaction = trn
                            ComSave.ExecuteNonQuery()
                        Else
                            StrQuery = "update BankMaster set CurrentBalance = CurrentBalance- " & Val(txtNetAmount.Text) & " where AccNo='" & Trim(Replace(lblAccNo.Text, "'", "''")) & "' "
                            ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                            ComSave.CommandType = CommandType.Text
                            ComSave.Transaction = trn
                            ComSave.ExecuteNonQuery()
                        End If

                        If optCash.Checked = True Then
                            StrQuery = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtVoucherNo.Text & "','" & convertToServerDateFormat(dtpVoucherDate.Value) & "','CASH', '" & Mode & "',0," & Val(txtNetAmount.Text) & ",'" & Replace(txtReceivedBy.Text, "'", "''") & "')"
                        Else
                            StrQuery = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtVoucherNo.Text & "','" & convertToServerDateFormat(dtpVoucherDate.Value) & "','" & ledgerCode & "', '" & Mode & "',0," & Val(txtNetAmount.Text) & ",'" & Replace(txtReceivedBy.Text, "'", "''") & "')"
                        End If


                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()



                        StrQuery = "update sequenceMaster set lastValue = lastValue + increment where head='Journal'"
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()
                        trn.Commit() ''''''''End transaction

                        Call ControlStatus(False)


                        Me.ActiveControl.Focus()
                        Call Display(StrCode)
                        f_blnAddOn = False
                        f_blnEditOn = False
                    Else

                        Exit Sub

                    End If
                ElseIf f_blnEditOn = True Then
                    '
                    If MsgQuestion("UPDATE") = 6 Then

                        trn = gl_Con.BeginTransaction()




                        StrQuery = "Update JournalMaster Set  VoucherDate='" & convertToServerDateFormat(dtpVoucherDate.Value) & "',ReceivedBy='" & Trim(Replace(txtReceivedBy.Text, "'", "''")) & "',ModifiedBy='" & gl_EmpName & "',ChequeNo='" & txtChequeNo.Text & "',ChequeDate='" & convertToServerDateFormat(dtpChequeDate.Value) & "',BankCode='" & ledgerCode & "',AccNo='" & Trim(Replace(lblAccNo.Text, "'", "''")) & "',BankName='" & txtBankName.Text & "',Cash='" & cash & "', Remarks='" & Trim(Replace(txtRemarks.Text, "'", "''")) & "',Amount='" & Trim(Replace(txtAmount.Text, "'", "''")) & "',Discount='" & Trim(Replace(txtDiscount.Text, "'", "''")) & "',NetAmount='" & Trim(Replace(txtNetAmount.Text, "'", "''")) & "'  WHERE VoucherNo = '" & txtVoucherNo.Text & "'"
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        StrQuery = "Delete From JournalDetail Where VoucherNo = '" & txtVoucherNo.Text & "'"
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        With dgDetail
                            For i = 0 To .RowCount - 1
                                StrQuery = "insert into JournalDetail(VoucherNo,Description,Amount,Discount,TotalAmt) values('" & Trim(Replace(txtVoucherNo.Text, "'", "''")) & "','" & (.Rows(i).Cells(1).Value.ToString) & "'," & Val(.Rows(i).Cells(2).Value) & "," & Val(.Rows(i).Cells(3).Value) & "," & Val(.Rows(i).Cells(4).Value) & ")"
                                ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                                ComSave.CommandType = CommandType.Text
                                ComSave.Transaction = trn
                                ComSave.ExecuteNonQuery()
                            Next
                        End With


                        If CashEdit = 1 Then
                            StrQuery = "update CompanyMaster1 set CurrentBalance = CurrentBalance+ " & AmountEdit & " "

                        Else
                            StrQuery = "update BankMaster set CurrentBalance = CurrentBalance+ " & AmountEdit & " where AccNo='" & Trim(Replace(lblAccNo.Text, "'", "''")) & "' "

                        End If
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()


                        If optCash.Checked = True Then
                            StrQuery = "update CompanyMaster1 set CurrentBalance = CurrentBalance- " & Val(txtNetAmount.Text) & " "

                        Else
                            StrQuery = "update BankMaster set CurrentBalance = CurrentBalance- " & Val(txtNetAmount.Text) & " where AccNo='" & Trim(Replace(lblAccNo.Text, "'", "''")) & "' "

                        End If
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()


                        StrQuery = "Delete From Ledger where transactionno='" & txtVoucherNo.Text & "'"

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        If optCash.Checked = True Then
                            StrQuery = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtVoucherNo.Text & "','" & convertToServerDateFormat(dtpVoucherDate.Value) & "','CASH', '" & Mode & "',0," & Val(txtNetAmount.Text) & ",'" & Replace(txtReceivedBy.Text, "'", "''") & "')"
                        Else
                            StrQuery = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtVoucherNo.Text & "','" & convertToServerDateFormat(dtpVoucherDate.Value) & "','" & ledgerCode & "', '" & Mode & "',0," & Val(txtNetAmount.Text) & ",'" & Replace(txtReceivedBy.Text, "'", "''") & "')"
                        End If


                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()




                        trn.Commit() ''''''''End transaction


                        Call ControlStatus(False)

                        Me.ActiveControl.Focus()

                        Call Display(StrCode)
                        f_blnAddOn = False
                        f_blnEditOn = False
                    Else

                        Exit Sub
                    End If
                Else
                    Call ControlStatus(False)
                    Call ClearControl()
                    Call Display(StrCode)
                End If
                End If


                cmdSearch.Focus()
        Catch ex As Exception
            trn.Rollback()
            '
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Display(Optional ByVal StrCode As String = "-1")
        Dim StrQuery As String
        Dim Int As Integer
        Dim drDisplay As SqlClient.SqlDataReader
        Dim drItem As SqlClient.SqlDataReader
        Dim comDisplay As SqlClient.SqlCommand
        Dim Opt As Integer
        Try
            If StrCode = "-1" Then
                StrQuery = "SELECT  * FROM JournalMaster  where VoucherID = (Select max(VoucherID) from JournalMaster)"
            Else
                StrQuery = "SELECT  * FROM JournalMaster WHERE voucherNo ='" & StrCode & "'"
            End If
            comDisplay = New SqlClient.SqlCommand(StrQuery, gl_Con)
            drDisplay = comDisplay.ExecuteReader

            If drDisplay.HasRows Then
                drDisplay.Read()
                cash = IIf(IsDBNull(drDisplay.Item("Cash")), "", drDisplay.Item("Cash"))
                CashEdit = IIf(IsDBNull(drDisplay.Item("Cash")), "", drDisplay.Item("Cash"))
                txtVoucherNo.Text = IIf(IsDBNull(drDisplay.Item("VoucherNo")), "", drDisplay.Item("VoucherNo"))
                txtVoucherNo.Tag = IIf(IsDBNull(drDisplay.Item("VoucherID")), "", drDisplay.Item("VoucherID"))
                dtpVoucherDate.Value = IIf(IsDBNull(convertToServerDateFormat(drDisplay.Item("VoucherDate"))), "", convertToServerDateFormat(drDisplay.Item("VoucherDate")))
                txtVoucherDate.Text = IIf(IsDBNull(convertToServerDateFormat(drDisplay.Item("VoucherDate"))), "", convertToServerDateFormat(drDisplay.Item("VoucherDate")))
                cboAccNo.Text = IIf(IsDBNull(drDisplay.Item("AccNo")), "", drDisplay.Item("AccNo"))
                lblAccNo.Text = IIf(IsDBNull(drDisplay.Item("AccNo")), "", drDisplay.Item("AccNo"))
                txtAccNo.Text = IIf(IsDBNull(drDisplay.Item("AccNo")), "", drDisplay.Item("AccNo"))
                ledgerCode = IIf(IsDBNull(drDisplay.Item("BankCode")), "", drDisplay.Item("BankCode"))
                txtReceivedBy.Text = IIf(IsDBNull(drDisplay.Item("ReceivedBy")), "", drDisplay.Item("ReceivedBy"))
                txtRemarks.Text = IIf(IsDBNull(drDisplay.Item("Remarks")), "", drDisplay.Item("Remarks"))
                txtDiscount.Text = IIf(IsDBNull(drDisplay.Item("Discount")), "", drDisplay.Item("Discount"))
                txtAmount.Text = IIf(IsDBNull(drDisplay.Item("Amount")), "", drDisplay.Item("Amount"))
                txtNetAmount.Text = IIf(IsDBNull(drDisplay.Item("NetAmount")), "", drDisplay.Item("NetAmount"))
                AmountEdit = IIf(IsDBNull(drDisplay.Item("NetAmount")), "", drDisplay.Item("NetAmount"))
                If cash = 0 Then
                    optCheque.Checked = True
                    Mode = "Cash"
                    txtChequeNo.Text = IIf(IsDBNull(drDisplay.Item("ChequeNo")), "", drDisplay.Item("ChequeNo"))
                    dtpChequeDate.Value = IIf(IsDBNull(convertToServerDateFormat(drDisplay.Item("ChequeDate"))), "", convertToServerDateFormat(drDisplay.Item("ChequeDate")))
                    txtChequeDate.Text = IIf(IsDBNull(convertToServerDateFormat(drDisplay.Item("ChequeDate"))), "", convertToServerDateFormat(drDisplay.Item("ChequeDate")))

                    txtBankName.Text = IIf(IsDBNull(drDisplay.Item("BankName")), "", drDisplay.Item("BankName"))
                    gbCheque.Enabled = True
                Else
                    Mode = "Cheque"
                    optCash.Checked = True
                    txtAccNo.Text = ""
                    txtChequeDate.Text = ""
                    txtChequeNo.Text = ""
                    txtBankName.Text = ""
                    gbCheque.Enabled = False
                End If

            End If
            drDisplay.Close()

            StrQuery = "SELECT  * FROM JournalDetail  where  VoucherNo ='" & txtVoucherNo.Text & "'"

            comDisplay = New SqlClient.SqlCommand(StrQuery, gl_Con)
            drDisplay = comDisplay.ExecuteReader
            dgDetail.RowCount = 1
            If drDisplay.HasRows Then
                With dgDetail
                    While drDisplay.Read
                        .RowCount = .RowCount + 1
                        .Rows(.RowCount - 2).Cells(0).Value = .RowCount - 1
                        .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("Description")), "", drDisplay.Item("Description"))
                        .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("Amount")), "", drDisplay.Item("Amount"))
                        .Rows(.RowCount - 2).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("Discount")), "", drDisplay.Item("Discount"))
                        .Rows(.RowCount - 2).Cells(4).Value = IIf(IsDBNull(drDisplay.Item("TotalAmt")), "", drDisplay.Item("TotalAmt"))


                    End While
                    dgDetail.RowCount = dgDetail.RowCount - 1
                End With
            Else
                dgDetail.RowCount = 0
            End If

            drDisplay.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Private Sub Designgrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 5
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "VoucherNo"
            .Columns(1).Width = 90
            .Columns(2).Name = "VoucherDate"
            .Columns(2).Width = 100
            .Columns(3).Name = "Mode"
            .Columns(3).Width = 100
            .Columns(4).Name = "ReceivedBy"
            .Columns(4).Width = 150
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
    End Sub
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid1()
        da.Dispose()
        ds.Clear()

        Try

            StrQuery = "SELECT  * FROM JournalMaster"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("VoucherNo")), "", ds.Tables("FillGrid").Rows(i).Item("VoucherNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("VoucherDate"))), "", convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("VoucherDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Cash")), "", ds.Tables("FillGrid").Rows(i).Item("Cash"))
                        If .Rows(i).Cells(3).Value = 1 Then
                            .Rows(i).Cells(3).Value = "Cash"
                        Else
                            .Rows(i).Cells(3).Value = "Cheque"
                        End If

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ReceivedBy")), "", ds.Tables("FillGrid").Rows(i).Item("ReceivedBy"))


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

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try

            dv = New DataView(ds.Tables("FillGrid"), "VoucherNo Like '" & Trim(txtSearch.Text) & "*" & "'", "VoucherNo", DataViewRowState.CurrentRows)
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("VoucherNo")), "", dTable.Rows(i).Item("VoucherNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(dTable.Rows(i).Item("VoucherDate"))), "", convertToServerDateFormat(dTable.Rows(i).Item("VoucherDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("Cash")), "", dTable.Rows(i).Item("Cash"))
                        If .Rows(i).Cells(3).Value = 1 Then
                            .Rows(i).Cells(3).Value = "Cash"
                        Else
                            .Rows(i).Cells(3).Value = "Cheque"
                        End If

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("ReceivedBy")), "", dTable.Rows(i).Item("ReceivedBy"))

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
                    txtVoucherNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                Else
                    txtVoucherNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                End If
                intDGSearchKeayPress = 0
                Display(txtVoucherNo.Text)
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

    Private Sub cboAccNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccNo.Click
        FillBank()
    End Sub
    Private Sub FillBank()
        Dim strQuery As String
        Dim daConfig As SqlClient.SqlDataAdapter
        Dim dsConfig As New DataSet

        Try
            strQuery = "Select AccNo,BankName from BankMaster   Order By AccId"
            daConfig = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            daConfig.Fill(dsConfig, "Config")
            cboAccNo.DataSource = Nothing
            cboAccNo.DataSource = dsConfig.Tables("Config")
            cboAccNo.DisplayMember = "AccNo"


            'cboAccNo.ValueMember = "AccNo"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdAddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRow.Click
        Dim i As Integer
        For i = 0 To dgDetail.RowCount - 1
            If Len(dgDetail.Rows(i).Cells(2).Value) = 0 Then
                MsgBox("Amount Cannot be Empty", MsgBoxStyle.Information)
                dgDetail.CurrentCell = dgDetail.Item(2, i)
                Exit Sub
            End If
        Next
        dgDetail.RowCount = dgDetail.RowCount + 1
        dgDetail.Rows(i).Cells(0).Value = dgDetail.RowCount


    End Sub

    Private Sub dgDetail_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEndEdit


        With dgDetail
            Call Calculation()
            'If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
            '    If e.ColumnIndex = 0 Then
            '        .Rows(.CurrentRow.Index).Cells(4).Value = Val(.Rows(.CurrentRow.Index).Cells(2).Value) - Val(.Rows(.CurrentRow.Index).Cells(3).Value)
            '    Else
            '        .Rows(.CurrentRow.Index).Cells(4).Value = Val(.Rows(.CurrentRow.Index).Cells(2).Value) - Val(.Rows(.CurrentRow.Index).Cells(3).Value) + Val(.Rows(.CurrentRow.Index - 1).Cells(4).Value)
            '    End If
            '    txtAmount.Text = Val(.Rows(.RowCount - 1).Cells(4).Value)
            '    txtNetAmount.Text = Val(.Rows(.RowCount - 1).Cells(4).Value) - Val(txtDiscount.Text)
            'End If
        End With
    End Sub

    Private Sub dgDetail_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEnter
        If f_blnAddOn = True Or f_blnEditOn = True Then
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
                dgDetail.EditMode = DataGridViewEditMode.EditOnEnter
            Else
                dgDetail.EditMode = DataGridViewEditMode.EditProgrammatically
            End If
        End If
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

                'Query for selecting minimum and maximum VoucherID
                strMinMaxKey = "select max(VoucherID) AS MaxId,MIN(VoucherID) As MinId from JournalMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlClient.SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet


                daMinMaxKey.Fill(dsMinMaxKey, "JournalMaster")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("JournalMaster").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select VoucherNo  from JournalMaster where VoucherID=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "JournalMasterNavigation")

                        txtVoucherNo.Text = dsMinMaxKey.Tables("JournalMasterNavigation").Rows(0).Item("VoucherNo")
                        Call Display(txtVoucherNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If txtVoucherNo.Tag = dsMinMaxKey.Tables("JournalMaster").Rows(0).Item("minId") Then
                            nextKey = CDbl(txtVoucherNo.Tag)
                        Else
                            nextKey = CLng(txtVoucherNo.Tag) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("JournalMaster").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select VoucherNo from JournalMaster where VoucherID=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "JournalMasterNavigation")

                            If dsMinMaxKey.Tables("JournalMasterNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("JournalMaster").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtVoucherNo.Text = dsMinMaxKey.Tables("JournalMasterNavigation").Rows(0).Item("VoucherNo")
                        Call Display(txtVoucherNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If txtVoucherNo.Tag = dsMinMaxKey.Tables("JournalMaster").Rows(0).Item("maxId") Then
                            nextKey = CDbl(txtVoucherNo.Tag)
                        Else
                            nextKey = CLng(txtVoucherNo.Tag) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("JournalMaster").Rows(0).Item("maxId")
                            strNextRecord = "select VoucherNo from JournalMaster where VoucherID=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "JournalMasterNavigation")

                            If dsMinMaxKey.Tables("JournalMasterNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("JournalMaster").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtVoucherNo.Text = dsMinMaxKey.Tables("JournalMasterNavigation").Rows(0).Item("VoucherNo")
                        Call Display(txtVoucherNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("JournalMaster").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select VoucherNo from JournalMaster where VoucherID=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "JournalMasterNavigation")

                        txtVoucherNo.Text = dsMinMaxKey.Tables("JournalMasterNavigation").Rows(0).Item("VoucherNo")
                        Call Display(txtVoucherNo.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtDiscount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscount.TextChanged
       
        txtNetAmount.Text = Val(txtAmount.Text) - Val(txtDiscount.Text)
    End Sub
    Private Sub Calculation()
        Dim i As Integer
        With dgDetail
            For i = 0 To .RowCount - 1
                If i = 0 Then
                    .Rows(i).Cells(4).Value = Val(.Rows(i).Cells(2).Value) - Val(.Rows(i).Cells(3).Value)
                Else
                    .Rows(i).Cells(4).Value = Val(.Rows(i).Cells(2).Value) - Val(.Rows(i).Cells(3).Value) + Val(.Rows(i - 1).Cells(4).Value)

                End If
            Next
            txtAmount.Text = Val(.Rows(.RowCount - 1).Cells(4).Value)
            txtNetAmount.Text = Val(txtAmount.Text) - Val(txtDiscount.Text)

        End With
    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        Dim i As Integer
        If dgDetail.RowCount >= 1 Then
            If MsgQuestion("DELETE") = 7 Then
                Exit Sub
            Else
                dgDetail.Rows.Remove(dgDetail.CurrentRow)

                For i = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(i).Cells(0).Value = i + 1
                Next
                Calculation()
            End If
        Else
            MsgBox("No row to delete")
        End If
    End Sub
End Class