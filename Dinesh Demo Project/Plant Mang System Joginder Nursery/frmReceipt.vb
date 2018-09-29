Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmReceipt
    Dim CrRepDoc As New ReportDocument
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim CustomerCode As String
    Dim SearchCustomer As Integer
    Dim Mode As String
    Dim Approve As Integer

    Private Sub frmReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ENABLECONTROL(True)


        Display()
        dtpDate.Value = Now
        dtpChequeDate.Value = Now

    End Sub
    Private Sub FillCash()
        Dim strQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet

        Try
            strQuery = "Select CurrentBalance from CompanyMaster1"
            da = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            da.Fill(ds, "Bank")
            If ds.Tables("Bank").Rows.Count > 0 Then

                txtCashBalance.Text = ds.Tables("Bank").Rows(0).Item("CurrentBalance")
            End If




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ENABLECONTROL(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdApprove.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status
        cmdSearch.Enabled = status
        cmdSearchCustomer.Enabled = Not status


        txtReceiptNo.ReadOnly = True
        txtRemarks.ReadOnly = status
        txtCustomerName.ReadOnly = True
        txtChequeNo.ReadOnly = status
        txtChequeAmount.ReadOnly = status
        txtBankName.ReadOnly = True
        txtBranch.ReadOnly = True
        txtBankName1.ReadOnly = True
        txtBranch1.ReadOnly = True
        txtChequeDate.ReadOnly = True
        txtAccNo.ReadOnly = True
        txtAccNo1.ReadOnly = True
        txtCashAmount.ReadOnly = status
        txtAmounttransfer.ReadOnly = status
        txtdate.ReadOnly = True
        txtAddress.ReadOnly = True

        txtPartyAccNo.ReadOnly = status
        txtPartyBankBranch.ReadOnly = status
        txtPartyBankName.ReadOnly = status


        optCash.Enabled = Not status
        optCheque.Enabled = Not status
        optBankTransfer.Enabled = Not status



        If cmdSave.Enabled = True Then
            dtpDate.BringToFront()
            txtdate.SendToBack()
            dtpChequeDate.BringToFront()
            txtChequeDate.SendToBack()
            txtAccNo.SendToBack()
            cboAccNo.BringToFront()
            txtAccNo1.SendToBack()
            cboAccNo1.BringToFront()
        Else
            dtpDate.SendToBack()
            txtdate.BringToFront()
            txtAccNo.BringToFront()
            cboAccNo.SendToBack()
            txtAccNo1.BringToFront()
            cboAccNo1.SendToBack()
            dtpChequeDate.SendToBack()
            txtChequeDate.BringToFront()
        End If



    End Sub

    Private Sub ClearControl()
        txtBankCode.Text = ""
        txtRemarks.Text = ""
        txtAccNo.Text = ""
        txtAccNo1.Text = ""
        txtAddress.Text = ""
        txtAmounttransfer.Text = ""
        txtBankName.Text = ""
        txtBankName1.Text = ""
        txtBranch.Text = ""
        txtBranch1.Text = ""
        txtCashAmount.Text = ""
        txtChequeAmount.Text = ""
        txtChequeNo.Text = ""
        txtChequeDate.Text = ""
        txtdate.Text = ""
        txtPartyAccNo.Text = ""
        txtPartyBankBranch.Text = ""
        txtPartyBankName.Text = ""
        txtSearchName.Text = ""
        txtCustomerName.Text = ""
        txtBalance.Text = ""

    End Sub

    Private Sub frmReceipt_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Receipt = Nothing
    End Sub

    Private Sub frmReceipt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub



    Private Sub optBankTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optBankTransfer.Click
        gbBankTransfer.Visible = True
        gbCash.Visible = False
        gbCheque.Visible = False
        Mode = "BankTransfer"
        txtCashAmount.Text = ""
        cboAccNo1.Text = ""
        txtAmounttransfer.Text = ""
        txtPartyAccNo.Text = ""
        txtPartyBankBranch.Text = ""
        txtPartyBankName.Text = ""
        txtBankName1.Text = ""
        txtBranch1.Text = ""
        txtBankBalance1.Text = ""
        cboAccNo.Text = ""
        txtChequeAmount.Text = ""
        txtChequeDate.Text = ""
        txtChequeNo.Text = ""
        txtBankName.Text = ""
        txtBranch.Text = ""
    End Sub

    Private Sub optCash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCash.Click
        gbBankTransfer.Visible = False
        gbCash.Visible = True
        gbCheque.Visible = False
        Mode = "Cash"
        txtCashAmount.Text = ""
        cboAccNo1.Text = ""
        txtAmounttransfer.Text = ""
        txtPartyAccNo.Text = ""
        txtPartyBankBranch.Text = ""
        txtPartyBankName.Text = ""
        txtBankName1.Text = ""
        txtBranch1.Text = ""
        cboAccNo.Text = ""
        txtChequeAmount.Text = ""
        txtChequeDate.Text = ""
        txtChequeNo.Text = ""
        txtBankName.Text = ""
        txtBranch.Text = ""
        FillCash()
    End Sub

    Private Sub optCheque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCheque.Click
        gbBankTransfer.Visible = False
        gbCash.Visible = False
        gbCheque.Visible = True
        Mode = "Cheque"
        txtCashAmount.Text = ""
        cboAccNo1.Text = ""
        txtAmounttransfer.Text = ""
        txtPartyAccNo.Text = ""
        txtPartyBankBranch.Text = ""
        txtPartyBankName.Text = ""
        txtBankName1.Text = ""
        txtBranch1.Text = ""
        cboAccNo.Text = ""
        txtChequeAmount.Text = ""
        txtChequeDate.Text = ""
        txtChequeNo.Text = ""
        txtBankName.Text = ""
        txtBranch.Text = ""
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ENABLECONTROL(False)
        bln_AddOn = True
        txtReceiptNo.Text = showCode("Receipt")
        ClearControl()
        FillBank()
        FillBank1()

        optCheque.Checked = True
        gbBankTransfer.Visible = False
        gbCash.Visible = False
        gbCheque.Visible = True
        Mode = "Cheque"
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        ENABLECONTROL(False)
        bln_EditOn = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub

    Private Sub Cancel()
        If MsgQuestion("CANCEL") = 7 Then


            Exit Sub
        End If
        Call ENABLECONTROL(True)

        bln_AddOn = False
        bln_EditOn = False

        Call Display()


    End Sub


    Private Sub Designgrid1()
        Dim Strquery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim i As Integer


        With fgSearch

            .Editable = VSFlex7L.EditableSettings.flexEDNone
            .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
            .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
            .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
            .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow

            .Rows = 1
            .Cols = 5
            .set_TextMatrix(0, 0, "S.No.")
            .set_ColWidth(0, 500)

            .set_TextMatrix(0, 1, "Code")
            .set_ColWidth(1, 1500)
            .set_TextMatrix(0, 2, "CustomerName")
            .set_ColWidth(2, 3000)
            .set_TextMatrix(0, 3, "Address")
            .set_ColWidth(3, 2500)
            .set_TextMatrix(0, 4, "Balance")
            .set_ColWidth(4, 1200)
        End With

        Strquery = "Select CustomerCode,Customername,Address,Balance from CustomerMaster1 order by Customername"
        da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "FillGrid")


        With fgSearch
            .Rows = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
                    .Rows = .Rows + 1
                    .set_TextMatrix(i + 1, 0, i + 1)
                    .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerCode")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerCode")))
                    .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Customername")), "", ds.Tables("FillGrid").Rows(i).Item("Customername")))
                    .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Address")), "", ds.Tables("FillGrid").Rows(i).Item("Address")))
                    .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Balance")), "", ds.Tables("FillGrid").Rows(i).Item("Balance")))
                Next
            End If


        End With



    End Sub

    Private Sub fgSearch_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles fgSearch.DblClick
        If SearchCustomer = 1 Then
            txtCustomerName.Text = ""
            txtCustomerName.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 2)
            CustomerCode = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
            txtAddress.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 3)
            txtBalance.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 4)
            gbSearch.SendToBack()
            gbMain.BringToFront()
        Else
            Display(fgSearch.get_TextMatrix(fgSearch.RowSel, 1))

            gbSearch.SendToBack()
            gbMain.BringToFront()
        End If

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        gbSearch.Enabled = True
        gbSearch.BringToFront()
        fgSearch.Enabled = True
        Label14.Text = "Search ReceiptNo"
        FillSearchDetail()
        SearchCustomer = 0
        txtSearchName.Text = ""
        txtSearchName.Focus()
    End Sub

    Private Sub FillSearchDetail()
        Dim Strquery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim i As Integer


        With fgSearch

            .Editable = VSFlex7L.EditableSettings.flexEDNone
            .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
            .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
            .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
            .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow

            .Rows = 1
            .Cols = 6
            .Width = 702
            .Height = 437
            .set_TextMatrix(0, 0, "S.No.")
            .set_ColWidth(0, 500)

            .set_TextMatrix(0, 1, "ReceiptNo")
            .set_ColWidth(1, 1000)
            .set_TextMatrix(0, 2, "ReceiptDate")
            .set_ColWidth(2, 1400)
            .set_TextMatrix(0, 3, "CustomerName")
            .set_ColWidth(3, 3500)
            .set_TextMatrix(0, 4, "Mode")
            .set_ColWidth(4, 1500)
            .set_TextMatrix(0, 5, "Amount")
            .set_ColWidth(5, 1200)

        End With

        Strquery = "SELECT ReceiptMaster.ReceiptId, ReceiptMaster.ReceiptNo, ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode, CustomerMaster1.Address, ReceiptMaster.Remarks, ReceiptMaster.Mode, ReceiptMaster.CashAmount, ReceiptMaster.AccNo, BankMaster.BankName, BankMaster.Branch, ReceiptMaster.ChequeNo, ReceiptMaster.ChequeDate, ReceiptMaster.ChequeAmount, ReceiptMaster.AccNo1, BankMaster_1.BankName AS BankName1, BankMaster_1.Branch AS Branch1, ReceiptMaster.PartyAccNo, ReceiptMaster.PartyBankName, ReceiptMaster.PartyBankBranch, ReceiptMaster.AmountTransfer FROM ((ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode) LEFT JOIN BankMaster ON ReceiptMaster.AccNo = BankMaster.AccNo) LEFT JOIN BankMaster AS BankMaster_1 ON ReceiptMaster.AccNo1 = BankMaster_1.AccNo order by ReceiptNo"

        da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "FillGrid")


        With fgSearch
            .Rows = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
                    .Rows = .Rows + 1
                    .set_TextMatrix(i + 1, 0, i + 1)
                    .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ReceiptNo")), "", ds.Tables("FillGrid").Rows(i).Item("ReceiptNo")))
                    .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("ReceiptDate"))), "", convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("ReceiptDate"))))
                    .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerName")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerName")))
                    .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Mode")), "", ds.Tables("FillGrid").Rows(i).Item("Mode")))
                    If .get_TextMatrix(i + 1, 4) = "Cash" Then
                        .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CashAmount")), "", ds.Tables("FillGrid").Rows(i).Item("CashAmount")))
                    ElseIf .get_TextMatrix(i + 1, 4) = "Cheque" Then
                        .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ChequeAmount")), "", ds.Tables("FillGrid").Rows(i).Item("ChequeAmount")))
                    ElseIf .get_TextMatrix(i + 1, 4) = "BankTransfer" Then
                        .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AmountTransfer")), "", ds.Tables("FillGrid").Rows(i).Item("AmountTransfer")))
                    End If
                Next
            End If


        End With



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
    Private Sub FillBank1()
        Dim strQuery As String
        Dim daConfig As SqlClient.SqlDataAdapter
        Dim dsConfig As New DataSet

        Try
            strQuery = "Select AccNo,BankName from BankMaster   Order By AccId"
            daConfig = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            daConfig.Fill(dsConfig, "Config")


            cboAccNo1.DataSource = Nothing
            cboAccNo1.DataSource = dsConfig.Tables("Config")
            cboAccNo1.DisplayMember = "AccNo"

            'cboAccNo.ValueMember = "AccNo"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FillBankName1()
        Dim strQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet

        Try
            strQuery = "Select AccCode,AccNo,BankName,Branch,CurrentBalance from BankMaster   where AccNo='" & cboAccNo1.Text & "'"
            da = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            da.Fill(ds, "Bank")
            If ds.Tables("Bank").Rows.Count > 0 Then
                txtBankName1.Text = ds.Tables("Bank").Rows(0).Item("BankName")
                txtBranch1.Text = ds.Tables("Bank").Rows(0).Item("Branch")
                txtBankBalance1.Text = ds.Tables("Bank").Rows(0).Item("CurrentBalance")
                txtBankCode.Text = ds.Tables("Bank").Rows(0).Item("AccCode")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FillBankName()
        Dim strQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet

        Try
            strQuery = "Select AccCode,AccNo,BankName,Branch,CurrentBalance from BankMaster   where AccNo='" & cboAccNo.Text & "'"
            da = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            da.Fill(ds, "Bank")
            If ds.Tables("Bank").Rows.Count > 0 Then
                txtBankName.Text = ds.Tables("Bank").Rows(0).Item("BankName")
                txtBranch.Text = ds.Tables("Bank").Rows(0).Item("Branch")
                txtBankBalance.Text = ds.Tables("Bank").Rows(0).Item("CurrentBalance")
                txtBankCode.Text = ds.Tables("Bank").Rows(0).Item("AccCode")
            End If




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboAccNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccNo.Click
        FillBank()
    End Sub

    Private Sub cboAccNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccNo.SelectedIndexChanged
        FillBankName()
    End Sub

    Private Sub cboAccNo1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccNo1.Click
        FillBank1()
    End Sub

    Private Sub cboAccNo1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccNo1.SelectedIndexChanged
        FillBankName1()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Save()
    End Sub

    Private Sub Save()
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String


        Dim trn As SqlClient.SqlTransaction

        Dim sender As New System.Object
        Dim e As New System.EventArgs



        Try


            If txtCustomerName.Text = "" Then
                MsgBox("Please Select Customer Name")
                Exit Sub
            End If

            If Mode = "Cash" Then
                If Val(txtCashAmount.Text) = 0 Then
                    MsgBox("Please Enter Cash Amount")
                    Exit Sub
                End If

            End If

            If Mode = "Cheque" Then
                If Val(txtChequeAmount.Text) = 0 Then
                    MsgBox("Please Enter Cheque Amount")
                    Exit Sub
                End If

            End If

            If Mode = "BankTransfer" Then
                If Val(txtAmounttransfer.Text) = 0 Then
                    MsgBox("Please Enter Transfer Amount")
                    Exit Sub
                End If

                If Len(txtPartyAccNo.Text) = 0 Then
                    MsgBox("Please Enter Party Acc No")
                    Exit Sub
                End If

                If Len(txtPartyBankName.Text) = 0 Then
                    MsgBox("Please Enter Party Bank Name")
                    Exit Sub
                End If

                If Len(txtPartyBankBranch.Text) = 0 Then
                    MsgBox("Please Enter Party Bank branch")
                    Exit Sub
                End If
            End If


            If bln_AddOn = True Then


                If MsgQuestion("SAVE") = 6 Then


                    If Mode = "Cash" Then
                        str1 = "Insert into ReceiptMaster(ReceiptNo,ReceiptDate,CustomerCode,PrevBalance, Remarks,Mode,CashAmount) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & CustomerCode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "'," & Val(txtCashAmount.Text) & ")"
                    ElseIf Mode = "Cheque" Then
                        str1 = "Insert into ReceiptMaster(ReceiptNo,ReceiptDate,CustomerCode, PrevBalance,Remarks,Mode,BankCode,AccNo,ChequeNo,ChequeDate,ChequeAmount) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & CustomerCode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "','" & Trim(txtBankCode.Text) & "','" & Replace(cboAccNo.Text, "'", "''") & "','" & Replace(txtChequeNo.Text, "'", "''") & "','" & convertToServerDateFormat(dtpChequeDate.Value) & "'," & Val(txtChequeAmount.Text) & ")"
                    ElseIf Mode = "BankTransfer" Then
                        str1 = "Insert into ReceiptMaster(ReceiptNo,ReceiptDate,CustomerCode,PrevBalance, Remarks,Mode,BankCode1,AccNo1,PartyAccNo,PartyBankName,PartyBankBranch,AmountTransfer) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & CustomerCode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "','" & Trim(txtBankCode.Text) & "','" & Replace(cboAccNo1.Text, "'", "''") & "','" & Replace(txtPartyAccNo.Text, "'", "''") & "','" & Replace(txtPartyBankName.Text, "'", "''") & "','" & Replace(txtPartyBankBranch.Text, "'", "''") & "'," & Val(txtAmounttransfer.Text) & ")"
                    End If


                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='Receipt'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtReceiptNo.Text))
                    bln_AddOn = False
                    bln_EditOn = False
                    Call cmdApprove_Click(sender, e)
                End If
            ElseIf bln_EditOn = True Then
                If MsgQuestion("UPDATE") = 6 Then



                    If Mode = "Cash" Then
                        str1 = "update ReceiptMaster set ReceiptDate='" & convertToServerDateFormat(dtpDate.Value) & "',CustomerCode='" & CustomerCode & "',PrevBalance=" & Val(txtBalance.Text) & ", Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',CashAmount=" & Val(txtCashAmount.Text) & ",AccNo='" & Replace(cboAccNo.Text, "'", "''") & "',ChequeNo='" & Replace(txtChequeNo.Text, "'", "''") & "',ChequeDate='" & convertToServerDateFormat(dtpChequeDate.Value) & "',ChequeAmount=" & Val(txtChequeAmount.Text) & ",AccNo1='" & Replace(cboAccNo1.Text, "'", "''") & "',PartyAccNo='" & Replace(txtPartyAccNo.Text, "'", "''") & "',PartyBankName='" & Replace(txtPartyBankName.Text, "'", "''") & "',PartyBankBranch='" & Replace(txtPartyBankBranch.Text, "'", "''") & "',AmountTransfer=" & Val(txtAmounttransfer.Text) & " where ReceiptNo='" & txtReceiptNo.Text & "'"

                    ElseIf Mode = "Cheque" Then
                        str1 = "update ReceiptMaster set ReceiptDate='" & convertToServerDateFormat(dtpDate.Value) & "',CustomerCode='" & CustomerCode & "',PrevBalance=" & Val(txtBalance.Text) & ", Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',CashAmount=" & Val(txtCashAmount.Text) & ",BankCode='" & Trim(txtBankCode.Text) & "',AccNo='" & Replace(cboAccNo.Text, "'", "''") & "',ChequeNo='" & Replace(txtChequeNo.Text, "'", "''") & "',ChequeDate='" & convertToServerDateFormat(dtpChequeDate.Value) & "',ChequeAmount=" & Val(txtChequeAmount.Text) & ",AccNo1='" & Replace(cboAccNo1.Text, "'", "''") & "',PartyAccNo='" & Replace(txtPartyAccNo.Text, "'", "''") & "',PartyBankName='" & Replace(txtPartyBankName.Text, "'", "''") & "',PartyBankBranch='" & Replace(txtPartyBankBranch.Text, "'", "''") & "',AmountTransfer=" & Val(txtAmounttransfer.Text) & " where ReceiptNo='" & txtReceiptNo.Text & "'"
                    ElseIf Mode = "BankTransfer" Then
                        str1 = "update ReceiptMaster set ReceiptDate='" & convertToServerDateFormat(dtpDate.Value) & "',CustomerCode='" & CustomerCode & "',PrevBalance=" & Val(txtBalance.Text) & ", Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',BankCode1='" & Trim(txtBankCode.Text) & "',CashAmount=" & Val(txtCashAmount.Text) & ",AccNo='" & Replace(cboAccNo.Text, "'", "''") & "',ChequeNo='" & Replace(txtChequeNo.Text, "'", "''") & "',ChequeDate='" & convertToServerDateFormat(dtpChequeDate.Value) & "',ChequeAmount=" & Val(txtChequeAmount.Text) & ",AccNo1='" & Replace(cboAccNo1.Text, "'", "''") & "',PartyAccNo='" & Replace(txtPartyAccNo.Text, "'", "''") & "',PartyBankName='" & Replace(txtPartyBankName.Text, "'", "''") & "',PartyBankBranch='" & Replace(txtPartyBankBranch.Text, "'", "''") & "',AmountTransfer=" & Val(txtAmounttransfer.Text) & " where ReceiptNo='" & txtReceiptNo.Text & "'"
                    End If



                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()







                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtReceiptNo.Text))
                    bln_AddOn = False
                    bln_EditOn = False
                    Call cmdApprove_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Display(Optional ByVal strMRqNo As String = "-1")
        Dim i As Integer
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim daDA1 As SqlClient.SqlDataAdapter
        Dim dsDS1 As New DataSet
        Dim str1 As String

        Try

            If gl_EmpName = "administrator" Then
                cmdApprove.Visible = True
            Else
                cmdApprove.Visible = False
            End If


            If strMRqNo = "-1" Then

                str1 = "SELECT ReceiptMaster.Approve,ReceiptMaster.ReceiptId, ReceiptMaster.ReceiptNo, ReceiptMaster.BankCode, ReceiptMaster.BankCode1, ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode,ReceiptMaster.PrevBalance, CustomerMaster1.Address, ReceiptMaster.Remarks, ReceiptMaster.Mode, ReceiptMaster.CashAmount, ReceiptMaster.AccNo, BankMaster.BankName, BankMaster.Branch, ReceiptMaster.ChequeNo, ReceiptMaster.ChequeDate, ReceiptMaster.ChequeAmount, ReceiptMaster.AccNo1, BankMaster_1.BankName AS BankName1, BankMaster_1.Branch AS Branch1, ReceiptMaster.PartyAccNo, ReceiptMaster.PartyBankName, ReceiptMaster.PartyBankBranch, ReceiptMaster.AmountTransfer FROM ((ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode) LEFT JOIN BankMaster ON ReceiptMaster.AccNo = BankMaster.AccNo) LEFT JOIN BankMaster AS BankMaster_1 ON ReceiptMaster.AccNo1 = BankMaster_1.AccNo WHERE (((ReceiptMaster.ReceiptId)=(SELECT     MAX(ReceiptId)FROM          ReceiptMaster)))  "
            Else
                str1 = "SELECT ReceiptMaster.Approve,ReceiptMaster.ReceiptId, ReceiptMaster.ReceiptNo,ReceiptMaster.BankCode, ReceiptMaster.BankCode1, ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode,ReceiptMaster.PrevBalance,CustomerMaster1.Address, ReceiptMaster.Remarks, ReceiptMaster.Mode, ReceiptMaster.CashAmount, ReceiptMaster.AccNo, BankMaster.BankName, BankMaster.Branch, ReceiptMaster.ChequeNo, ReceiptMaster.ChequeDate, ReceiptMaster.ChequeAmount, ReceiptMaster.AccNo1, BankMaster_1.BankName AS BankName1, BankMaster_1.Branch AS Branch1, ReceiptMaster.PartyAccNo, ReceiptMaster.PartyBankName, ReceiptMaster.PartyBankBranch, ReceiptMaster.AmountTransfer FROM ((ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode) LEFT JOIN BankMaster ON ReceiptMaster.AccNo = BankMaster.AccNo) LEFT JOIN BankMaster AS BankMaster_1 ON ReceiptMaster.AccNo1 = BankMaster_1.AccNo WHERE      (ReceiptMaster.ReceiptNo='" & strMRqNo & "') "
            End If





            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "MR")

            If dsDS1.Tables("MR").Rows.Count > 0 Then
                lblPrimaryKey.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ReceiptId")), "", dsDS1.Tables("MR").Rows(0).Item("ReceiptId"))
                Approve = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Approve")), 0, dsDS1.Tables("MR").Rows(0).Item("Approve"))
                If Approve = 1 Then
                    cmdApprove.Text = "Approved"
                    cmdEdit.Enabled = False
                Else
                    cmdApprove.Text = "Approve"
                    cmdEdit.Enabled = True
                End If
                txtReceiptNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ReceiptNo")), "", dsDS1.Tables("MR").Rows(0).Item("ReceiptNo"))
                dtpDate.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ReceiptDate"))), "01/01/1990", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ReceiptDate")))
                txtdate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ReceiptDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ReceiptDate")))
                CustomerCode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerCode")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerCode"))
                txtCustomerName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerName")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerName"))
                txtBalance.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PrevBalance")), "", dsDS1.Tables("MR").Rows(0).Item("PrevBalance"))
                txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address")), "", dsDS1.Tables("MR").Rows(0).Item("Address"))

                txtRemarks.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Remarks")), "", dsDS1.Tables("MR").Rows(0).Item("Remarks"))
                Mode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Mode")), "", dsDS1.Tables("MR").Rows(0).Item("Mode"))
                If Mode = "Cash" Then
                    txtCashAmount.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CashAmount")), "", dsDS1.Tables("MR").Rows(0).Item("CashAmount"))
                    gbBankTransfer.Visible = False
                    gbCash.Visible = True
                    gbCheque.Visible = False
                    optCash.Checked = True
                ElseIf Mode = "Cheque" Then
                    gbBankTransfer.Visible = False
                    gbCash.Visible = False
                    gbCheque.Visible = True
                    optCheque.Checked = True
                    txtBankCode.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankCode")), "", dsDS1.Tables("MR").Rows(0).Item("BankCode"))
                    cboAccNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo"))
                    txtAccNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo"))

                    dtpChequeDate.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate"))), "01/01/1990", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate")))
                    txtChequeDate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate")))
                    txtBankName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankName")), "", dsDS1.Tables("MR").Rows(0).Item("BankName"))
                    txtBranch.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Branch")), "", dsDS1.Tables("MR").Rows(0).Item("Branch"))

                    txtChequeNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ChequeNo")), "", dsDS1.Tables("MR").Rows(0).Item("ChequeNo"))

                    txtChequeAmount.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ChequeAmount")), "", dsDS1.Tables("MR").Rows(0).Item("ChequeAmount"))

                ElseIf Mode = "BankTransfer" Then
                    gbBankTransfer.Visible = True
                    gbCash.Visible = False
                    gbCheque.Visible = False
                    optBankTransfer.Checked = True

                    txtBankCode.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankCode1")), "", dsDS1.Tables("MR").Rows(0).Item("BankCode1"))
                    cboAccNo1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo1")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo1"))
                    txtAccNo1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo1")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo1"))
                    txtBankName1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankName1")), "", dsDS1.Tables("MR").Rows(0).Item("BankName1"))
                    txtBranch1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Branch1")), "", dsDS1.Tables("MR").Rows(0).Item("Branch1"))
                    txtAmounttransfer.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AmountTransfer")), "", dsDS1.Tables("MR").Rows(0).Item("AmountTransfer"))

                    txtPartyAccNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PartyAccNo")), "", dsDS1.Tables("MR").Rows(0).Item("PartyAccNo"))
                    txtPartyBankBranch.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PartyBankBranch")), "", dsDS1.Tables("MR").Rows(0).Item("PartyBankBranch"))
                    txtPartyBankName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PartyBankName")), "", dsDS1.Tables("MR").Rows(0).Item("PartyBankName"))
                End If


            End If

            daDA1.Dispose()
            dsDS1.Clear()
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
                strMinMaxKey = "select max(ReceiptId) AS MaxId,MIN(ReceiptId) As MinId from ReceiptMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet

                'fill the dataset with min and max Id's 
                'give the name to table "ItemID"

                daMinMaxKey.Fill(dsMinMaxKey, "Receipt")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("Receipt").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select ReceiptNo  from ReceiptMaster where ReceiptId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "ReceiptNavigation")

                        txtReceiptNo.Text = dsMinMaxKey.Tables("ReceiptNavigation").Rows(0).Item("ReceiptNo")
                        Call Display(txtReceiptNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Receipt").Rows(0).Item("minId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Receipt").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select ReceiptNo from ReceiptMaster where ReceiptId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "ReceiptNavigation")

                            If dsMinMaxKey.Tables("ReceiptNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Receipt").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtReceiptNo.Text = dsMinMaxKey.Tables("ReceiptNavigation").Rows(0).Item("ReceiptNo")
                        Call Display(txtReceiptNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Receipt").Rows(0).Item("maxId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Receipt").Rows(0).Item("maxId")
                            strNextRecord = "select ReceiptNo from ReceiptMaster where ReceiptId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "ReceiptNavigation")

                            If dsMinMaxKey.Tables("ReceiptNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Receipt").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtReceiptNo.Text = dsMinMaxKey.Tables("ReceiptNavigation").Rows(0).Item("ReceiptNo")
                        Call Display(txtReceiptNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Receipt").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select ReceiptNo from ReceiptMaster where ReceiptId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "ReceiptNavigation")

                        txtReceiptNo.Text = dsMinMaxKey.Tables("ReceiptNavigation").Rows(0).Item("ReceiptNo")
                        Call Display(txtReceiptNo.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtsearchName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchName.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            If SearchCustomer = 1 Then
                txtCustomerName.Text = ""
                txtCustomerName.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 2)
                CustomerCode = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
                txtAddress.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 3)

                gbSearch.SendToBack()
                gbMain.BringToFront()
            Else
                Display(fgSearch.get_TextMatrix(fgSearch.RowSel, 1))

                gbSearch.SendToBack()
                gbMain.BringToFront()
            End If
        End If

    End Sub




    Private Sub txtsearchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchName.TextChanged


        Dim intLoop As Integer
        Dim intLength As Integer
        Dim f_intRowFound As Integer
        Dim i As Integer
        Dim j As Integer

        If SearchCustomer = 0 Then
            i = 1
            j = 4
        Else
            i = 2
            j = 1
        End If



        intLength = Len(txtSearchName.Text)
        If fgSearch.Rows > 1 Then
            For intLoop = 1 To fgSearch.Rows - 1

                If LCase(txtSearchName.Text) = LCase(Mid(fgSearch.get_TextMatrix(intLoop, i), j, intLength)) Then
                    f_intRowFound = intLoop
                    fgSearch.Row = f_intRowFound
                    fgSearch.TopRow = f_intRowFound
                    Exit Sub
                Else
                    fgSearch.Row = f_intRowFound
                    fgSearch.TopRow = f_intRowFound
                End If



            Next
        End If

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub


    Private Sub cmdSearchCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearchCustomer.Click
        gbSearch.Enabled = True
        gbSearch.BringToFront()
        fgSearch.Enabled = True
        Label14.Text = "Search CustomerName"
        Designgrid1()
        SearchCustomer = 1
        txtSearchName.Text = ""
        txtSearchName.Focus()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim fSalesReportViewer As New frmReportViewer
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        Dim strMRCode As String

        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim StrQuery As String
        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction







        fSalesReportViewer.MdiParent = MainForm
        fSalesReportViewer.Text = "Item Account Statement"
        fSalesReportViewer.Refresh()
        fSalesReportViewer.Show()


        Me.Cursor = Cursors.WaitCursor
        Try



            str1 = "delete from Temp_Report"
            trn = gl_Con.BeginTransaction
            ComSave = New SqlClient.SqlCommand(str1, gl_Con)
            ComSave.CommandType = CommandType.Text
            ComSave.Transaction = trn
            ComSave.ExecuteNonQuery()

            str1 = "Insert into Temp_Report(ReportNo) values('" & txtReceiptNo.Text & "')"
            cmdCom1.Transaction = trn
            cmdCom1.Connection = gl_Con
            cmdCom1.CommandText = str1
            cmdCom1.ExecuteNonQuery()

            trn.Commit()



            CrRepDoc.Load(Application.StartupPath & "\Report\rptReceipt.rpt")


            For Each tbCurrent In CrRepDoc.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = gl_Con.DataSource
                    .UserID = "sa"
                    .Password = gl_strpwd
                    .DatabaseName = gl_Con.Database

                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent
            CrRepDoc.Refresh()
            'strMRCode = "{SaleMaster.SaleInvoiceNo} = '" & Trim(txtSaleInvoiceNo.Text) & "'"
            'fSalesReportViewer.CrystalReportViewer1.SelectionFormula = strMRCode
            fSalesReportViewer.CrystalReportViewer1.ReportSource = CrRepDoc
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim StrQuery As String

        Dim trn As SqlClient.SqlTransaction

        Dim Amount As Decimal
        Dim NetAmount As Decimal
        Dim accno As String


        Try

            If cmdApprove.Text = "Approve" Then
                If MsgQuestion("APPROVE") = 6 Then

                    ''*******************************************PARTY AND BANK BALANCE UPDATE************************* 

                    If Mode = "Cash" Then
                        NetAmount = Val(txtCashAmount.Text)
                    ElseIf Mode = "Cheque" Then
                        NetAmount = Val(txtChequeAmount.Text)
                        accno = cboAccNo.Text
                    ElseIf Mode = "BankTransfer" Then
                        NetAmount = Val(txtAmounttransfer.Text)
                        accno = cboAccNo1.Text
                    End If

                    str1 = "update CustomerMaster1 set Balance=Balance-" & NetAmount & " where CustomerCode='" & CustomerCode & "'"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    If Mode = "Cheque" Or Mode = "BankTransfer" Then
                        str1 = "update BankMaster set CurrentBalance=CurrentBalance+" & NetAmount & " where AccNo='" & accno & "'"
                    ElseIf Mode = "Cash" Then
                        str1 = "update CompanyMaster1 set CurrentBalance=CurrentBalance+" & NetAmount & ""
                    End If
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()
                    ''********************************************LEDGER UPDATE***************************************


                    str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & CustomerCode & "', 'Receipt',0," & NetAmount & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    If Mode = "Cash" Then
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','Company', 'Receipt'," & Val(txtCashAmount.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    ElseIf Mode = "Cheque" Then
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & Trim(txtBankCode.Text) & "','Receipt'," & Val(txtChequeAmount.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    ElseIf Mode = "BankTransfer" Then
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & Trim(txtBankCode.Text) & "', 'Receipt'," & Val(txtAmounttransfer.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    End If


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    str1 = "update ReceiptMaster set Approve=1 where ReceiptNo='" & txtReceiptNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtReceiptNo.Text))
                    If Approve = 1 Then
                        cmdApprove.Text = "Approved"
                        cmdEdit.Enabled = False
                    Else
                        cmdApprove.Text = "Approve"
                        cmdEdit.Enabled = True
                    End If

                    bln_AddOn = False
                    bln_EditOn = False
                End If
            ElseIf cmdApprove.Text = "Approved" Then


                If MsgQuestion("DISAPPROVE") = 6 Then





                    StrQuery = "Delete From Ledger where transactionno='" & txtReceiptNo.Text & "'"

                    trn = gl_Con.BeginTransaction
                    cmdCom1 = New SqlClient.SqlCommand(StrQuery, gl_Con)
                    cmdCom1.CommandType = CommandType.Text
                    cmdCom1.Transaction = trn
                    cmdCom1.ExecuteNonQuery()



                    If Mode = "Cash" Then
                        NetAmount = Val(txtCashAmount.Text)
                    ElseIf Mode = "Cheque" Then
                        NetAmount = Val(txtChequeAmount.Text)
                        accno = cboAccNo.Text
                    ElseIf Mode = "BankTransfer" Then
                        NetAmount = Val(txtAmounttransfer.Text)
                        accno = cboAccNo1.Text
                    End If

                    str1 = "update CustomerMaster1 set Balance=Balance+" & NetAmount & " where CustomerCode='" & CustomerCode & "'"

                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    If Mode = "Cheque" Or Mode = "BankTransfer" Then
                        str1 = "update BankMaster set CurrentBalance=CurrentBalance-" & NetAmount & " where AccNo='" & accno & "'"
                    ElseIf Mode = "Cash" Then
                        str1 = "update CompanyMaster1 set CurrentBalance=CurrentBalance-" & NetAmount & ""
                    End If
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()



                    str1 = "update ReceiptMaster set Approve=0 where ReceiptNo='" & txtReceiptNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtReceiptNo.Text))
                    If Approve = 1 Then
                        cmdApprove.Text = "Approved"
                        cmdEdit.Enabled = False
                    Else
                        cmdApprove.Text = "Approve"
                        cmdEdit.Enabled = True
                    End If
                    bln_AddOn = False
                    bln_EditOn = False
                End If
            End If
        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
End Class