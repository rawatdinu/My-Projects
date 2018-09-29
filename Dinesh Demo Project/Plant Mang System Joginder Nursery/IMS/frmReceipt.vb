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
    Dim Search As Integer
    Dim intDGSearchKeayPress As Integer

    Dim da As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds As New DataSet
    Dim da1 As New SqlDataAdapter   'Fro search in State Search
    Dim ds1 As New DataSet

    Private Sub frmReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Design()
        ClearControl()
        ENABLECONTROL(True)
        Display()
    End Sub
    Private Sub Design()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 9
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "SaleInvoiceNo"
            .Columns(1).Width = 90
            .Columns(2).Name = "Date"
            .Columns(2).Width = 80
            .Columns(3).Name = "InvoiceNo"
            .Columns(3).Width = 90
            .Columns(4).Name = "Challan/Quotation"
            .Columns(4).Width = 120
            .Columns(5).Name = "InvAmt"
            .Columns(5).Width = 90
            .Columns(6).Name = "PaidAmt"
            .Columns(6).Width = 90
            .Columns(7).Name = "BalanceAmt"
            .Columns(7).Width = 100
            .Columns(8).Name = "Amount"
            .Columns(8).Width = 90

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
        'With fgDetail
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth

        '    .Rows = 1
        '    .Cols = 9

        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "SaleInvoiceNo")
        '    .set_ColWidth(1, 1300)

        '    .set_TextMatrix(0, 2, "Date")
        '    .set_ColWidth(2, 1200)

        '    .set_TextMatrix(0, 3, "InvoiceNo")
        '    .set_ColWidth(3, 1200)

        '    .set_TextMatrix(0, 4, "Challan/Quotation")
        '    .set_ColWidth(4, 1200)

        '    .set_TextMatrix(0, 5, "InvAmt")
        '    .set_ColWidth(5, 1200)

        '    .set_TextMatrix(0, 6, "PaidAmt")
        '    .set_ColWidth(6, 1200)


        '    .set_TextMatrix(0, 7, "BalanceAmt")
        '    .set_ColWidth(7, 1200)


        '    .set_TextMatrix(0, 8, "Amount")
        '    .set_ColWidth(8, 1200)


        'End With
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

        txtBankName.ReadOnly = True
        txtBranch.ReadOnly = True
      
        txtChequeDate.ReadOnly = True
        txtAccNo.ReadOnly = True
        
        txtdate.ReadOnly = True
        txtAddress.ReadOnly = True

      


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
            
        Else
            dtpDate.SendToBack()
            txtdate.BringToFront()
            txtAccNo.BringToFront()
            cboAccNo.SendToBack()
           
            dtpChequeDate.SendToBack()
            txtChequeDate.BringToFront()
        End If



    End Sub

    Private Sub ClearControl()
        txtBankCode.Text = ""
        txtRemarks.Text = ""
        txtAccNo.Text = ""

        txtAddress.Text = ""
        txtReceiptAmount.Text = ""
        txtBankName.Text = ""

        txtBranch.Text = ""

        txtReceiptAmount.Text = ""

        txtChequeNo.Text = ""
        txtChequeDate.Text = ""
        txtdate.Text = ""
        
        txtSearch.Text = ""
        txtCustomerName.Text = ""
        txtBalance.Text = ""
        dgDetail.RowCount = 0

    End Sub

    Private Sub frmReceipt_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Receipt = Nothing
    End Sub

    Private Sub frmReceipt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub



    Private Sub optBankTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optBankTransfer.Click

        Mode = "BankTransfer"
        cboAccNo.Text = ""
        cboAccNo.BringToFront()
        txtChequeDate.Text = ""
        txtChequeNo.Text = ""
        txtBankName.Text = ""
        txtBranch.Text = ""
        dtpChequeDate.SendToBack()
    End Sub

    Private Sub optCash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCash.Click

        Mode = "Cash"
        cboAccNo.Text = ""
        cboAccNo.SendToBack()
        txtChequeDate.Text = ""
        txtChequeNo.Text = ""
        txtBankName.Text = ""
        txtBranch.Text = ""
        dtpChequeDate.SendToBack()

    End Sub

    Private Sub optCheque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCheque.Click

        Mode = "Cheque"
        cboAccNo.Text = ""
        cboAccNo.BringToFront()
        txtChequeDate.Text = ""
        txtChequeNo.Text = ""
        txtBankName.Text = ""
        txtBranch.Text = ""
        dtpChequeDate.BringToFront()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ENABLECONTROL(False)
        bln_AddOn = True
        bln_EditOn = False
        txtReceiptNo.Text = showCode("Receipt")
        ClearControl()
        FillBank()
        optCheque.Checked = True
        Mode = "Cheque"
        cboAccNo.Text = ""
        txtChequeDate.Text = ""
        txtChequeNo.Text = ""
        txtBankName.Text = ""
        txtBranch.Text = ""
        cboAccNo.BringToFront()
        dtpChequeDate.BringToFront()
        dtpDate.Value = Now
        dtpChequeDate.Value = Now
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        ENABLECONTROL(False)
        bln_EditOn = True
        bln_AddOn = False

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub

    Private Sub Cancel()
        If MsgQuestion("CANCEL") = 7 Then


            Exit Sub
        End If
        If bln_AddOn = True Then
            Display()
        Else
            Display(txtReceiptNo.Text)
        End If
        Call ENABLECONTROL(True)

        bln_AddOn = False
        bln_EditOn = False

    End Sub


    Private Sub Designgrid2()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 5
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Code"
            .Columns(1).Width = 80
            .Columns(2).Name = "Customer Name"
            .Columns(2).Width = 200
            .Columns(3).Name = "Address"
            .Columns(3).Width = 200
            .Columns(4).Name = "Balance"
            .Columns(4).Width = 100
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

        '    .set_TextMatrix(0, 1, "Code")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "CustomerName")
        '    .set_ColWidth(2, 3000)
        '    .set_TextMatrix(0, 3, "Address")
        '    .set_ColWidth(3, 2500)
        '    .set_TextMatrix(0, 4, "Balance")
        '    .set_ColWidth(4, 1200)
        'End With

        'Strquery = "Select CustomerCode,Customername,Address,Balance from CustomerMaster1 order by Customername"
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")


        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerCode")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerCode")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Customername")), "", ds.Tables("FillGrid").Rows(i).Item("Customername")))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Address")), "", ds.Tables("FillGrid").Rows(i).Item("Address")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Balance")), "", ds.Tables("FillGrid").Rows(i).Item("Balance")))
        '        Next
        '    End If


        'End With



    End Sub
    Private Sub Balance()
        Dim Str As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try

            Str = "SELECT     SaleInvoiceNo, SaleDate, InvoiceNo, ChallanNo, TotalValue, ISNULL(ReceivedAmount, 0) AS PaidAmount, TotalValue - ISNULL(ReceivedAmount, 0) AS Balance FROM SaleMaster WHERE (SaleMaster.CustomerCode='" & CustomerCode & "')  and  (CashManual = 0) AND (CashParty = 0) And  (TotalValue - ISNULL(ReceivedAmount, 0) > 0) GROUP BY SaleInvoiceNo, SaleDate, InvoiceNo, ChallanNo, TotalValue, ReceivedAmount"

            da = New SqlClient.SqlDataAdapter(Str, gl_Con)
            da.Fill(ds, "Balance")

            dgDetail.RowCount = 1
            If ds.Tables("Balance").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To ds.Tables("Balance").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("SaleInvoiceNo")), "", ds.Tables("Balance").Rows(i).Item("SaleInvoiceNo"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("Balance").Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(ds.Tables("Balance").Rows(i).Item("SaleDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("InvoiceNo")), "", ds.Tables("Balance").Rows(i).Item("InvoiceNo"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("ChallanNo")), "", ds.Tables("Balance").Rows(i).Item("ChallanNo"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("TotalValue")), "", ds.Tables("Balance").Rows(i).Item("TotalValue"))

                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("PaidAmount")), "", ds.Tables("Balance").Rows(i).Item("PaidAmount"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("Balance")), "", ds.Tables("Balance").Rows(i).Item("Balance"))


                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgDetail.RowCount = 0
            End If


            'With fgDetail
            '    .Rows = 1
            '    If ds.Tables("Balance").Rows.Count > 0 Then
            '        For i = 0 To ds.Tables("Balance").Rows.Count - 1
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(i + 1, 0, i + 1)
            '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("SaleInvoiceNo")), "", ds.Tables("Balance").Rows(i).Item("SaleInvoiceNo")))
            '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("Balance").Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(ds.Tables("Balance").Rows(i).Item("SaleDate"))))
            '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("InvoiceNo")), "", ds.Tables("Balance").Rows(i).Item("InvoiceNo")))
            '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("ChallanNo")), "", ds.Tables("Balance").Rows(i).Item("ChallanNo")))
            '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("TotalValue")), 0, ds.Tables("Balance").Rows(i).Item("TotalValue")))
            '            .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("PaidAmount")), 0, ds.Tables("Balance").Rows(i).Item("PaidAmount")))

            '            .set_TextMatrix(i + 1, 7, IIf(IsDBNull(ds.Tables("Balance").Rows(i).Item("Balance")), 0, ds.Tables("Balance").Rows(i).Item("Balance")))

            '        Next
            '    End If

            'End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Private Sub fgSearch_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'If SearchCustomer = 1 Then
        '    txtCustomerName.Text = ""
        '    txtCustomerName.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 2)
        '    CustomerCode = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
        '    txtAddress.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 3)
        '    txtBalance.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 4)
        '    Balance()
        '    gbSearch.SendToBack()
        '    gbMain.BringToFront()
        'Else
        '    Display(fgSearch.get_TextMatrix(fgSearch.RowSel, 1))

        '    gbSearch.SendToBack()
        '    gbMain.BringToFront()
        'End If

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        'gbSearch.Enabled = True
        'gbSearch.BringToFront()
        'fgSearch.Enabled = True
        'lblSearch.Text = "Search ReceiptNo"
        'FillSearchDetail()
        'SearchCustomer = 0
        'txtSearch.Text = ""
        'txtSearch.Focus()

        Dim StrQuery As String
        Dim i As Integer
        Designgrid1()
        da.Dispose()
        ds.Clear()
        Search = 0

        Try

            lblSearch.Text = "Search ReceiptNo"
            StrQuery = "SELECT ReceiptMaster.ReceiptId, ReceiptMaster.ReceiptNo, ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode, CustomerMaster1.Address, ReceiptMaster.Remarks, ReceiptMaster.Mode,  ReceiptMaster.AccNo, BankMaster.BankName, BankMaster.Branch, ReceiptMaster.ChequeNo, ReceiptMaster.ChequeDate, ReceiptMaster.receiptamount FROM ((ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode) LEFT JOIN BankMaster ON ReceiptMaster.AccNo = BankMaster.AccNo)  order by ReceiptNo"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ReceiptNo")), "", ds.Tables("FillGrid").Rows(i).Item("ReceiptNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("ReceiptDate"))), "", convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("ReceiptDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerName")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Mode")), "", ds.Tables("FillGrid").Rows(i).Item("Mode"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("receiptamount")), "", ds.Tables("FillGrid").Rows(i).Item("receiptamount"))

                       
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

    Private Sub Designgrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 6
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "ReceiptNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "ReceiptDate"
            .Columns(2).Width = 90
            .Columns(3).Name = "Customer Name"
            .Columns(3).Width = 200
            .Columns(4).Name = "Mode"
            .Columns(4).Width = 80
            .Columns(5).Name = "Balance"
            .Columns(5).Width = 100
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
        '    .Cols = 6
        '    .Width = 702
        '    .Height = 501
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "ReceiptNo")
        '    .set_ColWidth(1, 1200)
        '    .set_TextMatrix(0, 2, "ReceiptDate")
        '    .set_ColWidth(2, 1400)
        '    .set_TextMatrix(0, 3, "CustomerName")
        '    .set_ColWidth(3, 3500)
        '    .set_TextMatrix(0, 4, "Mode")
        '    .set_ColWidth(4, 1500)
        '    .set_TextMatrix(0, 5, "Amount")
        '    .set_ColWidth(5, 1200)

        'End With

        'Strquery = "SELECT ReceiptMaster.ReceiptId, ReceiptMaster.ReceiptNo, ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode, CustomerMaster1.Address, ReceiptMaster.Remarks, ReceiptMaster.Mode,  ReceiptMaster.AccNo, BankMaster.BankName, BankMaster.Branch, ReceiptMaster.ChequeNo, ReceiptMaster.ChequeDate, ReceiptMaster.receiptamount FROM ((ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode) LEFT JOIN BankMaster ON ReceiptMaster.AccNo = BankMaster.AccNo)  order by ReceiptNo"

        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")


        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ReceiptNo")), "", ds.Tables("FillGrid").Rows(i).Item("ReceiptNo")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("ReceiptDate"))), "", convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("ReceiptDate"))))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerName")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerName")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Mode")), "", ds.Tables("FillGrid").Rows(i).Item("Mode")))

        '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("receiptamount")), "", ds.Tables("FillGrid").Rows(i).Item("receiptamount")))

        '        Next
        '    End If


        'End With



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




    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Save()
    End Sub

    Private Sub Save()
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String


        Dim trn As SqlClient.SqlTransaction

        Dim sender As New System.Object
        Dim e As New System.EventArgs
        If optBankTransfer.Checked = True Or optCheque.Checked = True Then
            If cboAccNo.Text = "" Then
                MsgBox("Please Select Account No!")
                Exit Sub
            End If
        End If


        Try


            If txtCustomerName.Text = "" Then
                MsgBox("Please Select Customer Name")
                Exit Sub
            End If


            If Val(txtReceiptAmount.Text) = 0 Then
                MsgBox("Please Enter Receipt Amount")
                Exit Sub
            End If






            If bln_AddOn = True Then


                If MsgQuestion("SAVE") = 6 Then

                    str1 = "Insert into ReceiptMaster(ReceiptNo,ReceiptDate,CustomerCode,PrevBalance, Remarks,Mode,ReceiptAmount,BankCode,AccNo,ChequeNo,ChequeDate) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & CustomerCode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "'," & Val(txtReceiptAmount.Text) & ",'" & Trim(txtBankCode.Text) & "','" & Replace(cboAccNo.Text, "'", "''") & "','" & Replace(txtChequeNo.Text, "'", "''") & "','" & convertToServerDateFormat(dtpChequeDate.Value) & "')"

                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    With dgDetail
                        For i = 0 To .RowCount - 1
                            If Val(.Rows(i).Cells(8).Value.ToString) > 0 Then
                                str1 = "Insert into InvoiceWiseReceipt(SaleInvoiceNo,ReceiptNo,PaidAmount,BalanceAmount,ReceiptAmount,Approve) values('" & (.Rows(i).Cells(1).Value.ToString) & "','" & txtReceiptNo.Text & "'," & Val(.Rows(i).Cells(6).Value.ToString) & "," & Val(.Rows(i).Cells(7).Value.ToString) & "," & Val(.Rows(i).Cells(8).Value.ToString) & ",0)"

                                cmdCom1.Transaction = trn
                                cmdCom1.Connection = gl_Con
                                cmdCom1.CommandText = str1
                                cmdCom1.ExecuteNonQuery()
                            End If
                        Next

                    End With

                    'With fgDetail

                    '    For i = 1 To .Rows - 1
                    '        If Val(.get_TextMatrix(i, 8)) > 0 Then
                    '            str1 = "Insert into InvoiceWiseReceipt(SaleInvoiceNo,ReceiptNo,PaidAmount,BalanceAmount,ReceiptAmount,Approve) values('" & .get_TextMatrix(i, 1) & "','" & txtReceiptNo.Text & "'," & Val(.get_TextMatrix(i, 6)) & "," & Val(.get_TextMatrix(i, 7)) & "," & Val(.get_TextMatrix(i, 8)) & ",0)"

                    '            cmdCom1.Transaction = trn
                    '            cmdCom1.Connection = gl_Con
                    '            cmdCom1.CommandText = str1
                    '            cmdCom1.ExecuteNonQuery()
                    '        End If

                    '    Next
                    'End With


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

                    str1 = "update ReceiptMaster set ReceiptDate='" & convertToServerDateFormat(dtpDate.Value) & "',CustomerCode='" & CustomerCode & "',PrevBalance=" & Val(txtBalance.Text) & ", Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',ReceiptAmount=" & Val(txtReceiptAmount.Text) & ",BankCode='" & Trim(txtBankCode.Text) & "',AccNo='" & Replace(cboAccNo.Text, "'", "''") & "',ChequeNo='" & Replace(txtChequeNo.Text, "'", "''") & "',ChequeDate='" & convertToServerDateFormat(dtpChequeDate.Value) & "'  where ReceiptNo='" & txtReceiptNo.Text & "'"


                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()



                    str1 = "Delete From InvoiceWiseReceipt where ReceiptNo='" & txtReceiptNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    With dgDetail
                        For i = 0 To .RowCount - 1
                            If Val(.Rows(i).Cells(8).Value.ToString) > 0 Then
                                str1 = "Insert into InvoiceWiseReceipt(SaleInvoiceNo,ReceiptNo,PaidAmount,BalanceAmount,ReceiptAmount,Approve) values('" & (.Rows(i).Cells(1).Value.ToString) & "','" & txtReceiptNo.Text & "'," & Val(.Rows(i).Cells(6).Value.ToString) & "," & Val(.Rows(i).Cells(7).Value.ToString) & "," & Val(.Rows(i).Cells(8).Value.ToString) & ",0)"

                                cmdCom1.Transaction = trn
                                cmdCom1.Connection = gl_Con
                                cmdCom1.CommandText = str1
                                cmdCom1.ExecuteNonQuery()
                            End If
                        Next

                    End With

                    'With fgDetail

                    '    For i = 1 To .Rows - 1
                    '        If Val(.get_TextMatrix(i, 8)) > 0 Then
                    '            str1 = "Insert into InvoiceWiseReceipt(SaleInvoiceNo,ReceiptNo,PaidAmount,BalanceAmount,ReceiptAmount,Approve) values('" & .get_TextMatrix(i, 1) & "','" & txtReceiptNo.Text & "'," & Val(.get_TextMatrix(i, 6)) & "," & Val(.get_TextMatrix(i, 7)) & "," & Val(.get_TextMatrix(i, 8)) & ",0)"

                    '            cmdCom1.Transaction = trn
                    '            cmdCom1.Connection = gl_Con
                    '            cmdCom1.CommandText = str1
                    '            cmdCom1.ExecuteNonQuery()
                    '        End If

                    '    Next
                    'End With

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

                str1 = "SELECT ReceiptMaster.Approve,ReceiptMaster.ReceiptId, ReceiptMaster.ReceiptNo, ReceiptMaster.BankCode,  ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode,ReceiptMaster.PrevBalance, CustomerMaster1.Address, ReceiptMaster.Remarks, ReceiptMaster.Mode, ReceiptMaster.ReceiptAmount, ReceiptMaster.AccNo, BankMaster.BankName, BankMaster.Branch, ReceiptMaster.ChequeNo, ReceiptMaster.ChequeDate  FROM  ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode LEFT JOIN BankMaster ON ReceiptMaster.AccNo = BankMaster.AccNo   WHERE (((ReceiptMaster.ReceiptId)=(SELECT     MAX(ReceiptId)FROM          ReceiptMaster)))  "
            Else
                str1 = "SELECT ReceiptMaster.Approve,ReceiptMaster.ReceiptId, ReceiptMaster.ReceiptNo, ReceiptMaster.BankCode,  ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode,ReceiptMaster.PrevBalance, CustomerMaster1.Address, ReceiptMaster.Remarks, ReceiptMaster.Mode, ReceiptMaster.ReceiptAmount, ReceiptMaster.AccNo, BankMaster.BankName, BankMaster.Branch, ReceiptMaster.ChequeNo, ReceiptMaster.ChequeDate  FROM  ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode LEFT JOIN BankMaster ON ReceiptMaster.AccNo = BankMaster.AccNo  WHERE      (ReceiptMaster.ReceiptNo='" & strMRqNo & "') "
            End If

            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "MR")

            If dsDS1.Tables("MR").Rows.Count > 0 Then
                Label3.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ReceiptId")), "", dsDS1.Tables("MR").Rows(0).Item("ReceiptId"))
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
                    optCash.Checked = True
                ElseIf Mode = "Cheque" Then
                    optCheque.Checked = True
                ElseIf Mode = "BankTransfer" Then
                    optBankTransfer.Checked = True
                End If
                txtReceiptAmount.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ReceiptAmount")), 0, dsDS1.Tables("MR").Rows(0).Item("ReceiptAmount"))
                txtBankCode.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankCode")), "", dsDS1.Tables("MR").Rows(0).Item("BankCode"))
                cboAccNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo"))
                txtAccNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo"))

                dtpChequeDate.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate"))), "01/01/1990", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate")))
                txtChequeDate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate")))
                txtBankName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankName")), "", dsDS1.Tables("MR").Rows(0).Item("BankName"))
                txtBranch.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Branch")), "", dsDS1.Tables("MR").Rows(0).Item("Branch"))
                txtChequeNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ChequeNo")), "", dsDS1.Tables("MR").Rows(0).Item("ChequeNo"))
            End If

            daDA1.Dispose()
            dsDS1.Clear()

            str1 = "SELECT     InvoiceWiseReceipt.SaleInvoiceNo, InvoiceWiseReceipt.ReceiptNo, SaleMaster.SaleDate, SaleMaster.InvoiceNo, SaleMaster.ChallanNo,  SaleMaster.TotalValue, InvoiceWiseReceipt.ReceiptAmount, InvoiceWiseReceipt.PaidAmount, InvoiceWiseReceipt.BalanceAmount  FROM         InvoiceWiseReceipt INNER JOIN  SaleMaster ON InvoiceWiseReceipt.SaleInvoiceNo = SaleMaster.SaleInvoiceNo INNER JOIN ReceiptMaster ON InvoiceWiseReceipt.ReceiptNo = ReceiptMaster.ReceiptNo WHERE (ReceiptMaster.ReceiptNo='" & txtReceiptNo.Text & "') "

            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "Balance")
            dgDetail.RowCount = 1
            If dsDS1.Tables("Balance").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To dsDS1.Tables("Balance").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("SaleInvoiceNo")), "", dsDS1.Tables("Balance").Rows(i).Item("SaleInvoiceNo"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("Balance").Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(dsDS1.Tables("Balance").Rows(i).Item("SaleDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("InvoiceNo")), "", dsDS1.Tables("Balance").Rows(i).Item("InvoiceNo"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("ChallanNo")), "", dsDS1.Tables("Balance").Rows(i).Item("ChallanNo"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("TotalValue")), "", dsDS1.Tables("Balance").Rows(i).Item("TotalValue"))

                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("PaidAmount")), "", dsDS1.Tables("Balance").Rows(i).Item("PaidAmount"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("BalanceAmount")), "", dsDS1.Tables("Balance").Rows(i).Item("BalanceAmount"))

                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("ReceiptAmount")), "", dsDS1.Tables("Balance").Rows(i).Item("ReceiptAmount"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgDetail.RowCount = 0
            End If


            'fgDetail.Rows = 1
            'With fgDetail
            '    If dsDS1.Tables("Balance").Rows.Count > 0 Then
            '        For i = 0 To dsDS1.Tables("Balance").Rows.Count - 1
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(i + 1, 0, i + 1)
            '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("SaleInvoiceNo")), "", dsDS1.Tables("Balance").Rows(i).Item("SaleInvoiceNo")))
            '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("Balance").Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(dsDS1.Tables("Balance").Rows(i).Item("SaleDate"))))
            '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("InvoiceNo")), "", dsDS1.Tables("Balance").Rows(i).Item("InvoiceNo")))
            '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("ChallanNo")), "", dsDS1.Tables("Balance").Rows(i).Item("ChallanNo")))
            '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("TotalValue")), 0, dsDS1.Tables("Balance").Rows(i).Item("TotalValue")))
            '            .set_TextMatrix(i + 1, 6, IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("PaidAmount")), 0, dsDS1.Tables("Balance").Rows(i).Item("PaidAmount")))

            '            .set_TextMatrix(i + 1, 7, IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("BalanceAmount")), 0, dsDS1.Tables("Balance").Rows(i).Item("BalanceAmount")))
            '            .set_TextMatrix(i + 1, 8, IIf(IsDBNull(dsDS1.Tables("Balance").Rows(i).Item("ReceiptAmount")), 0, dsDS1.Tables("Balance").Rows(i).Item("ReceiptAmount")))


            '        Next
            '    End If
            'End With

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
                        If Label3.Text = dsMinMaxKey.Tables("Receipt").Rows(0).Item("minId") Then
                            nextKey = CDbl(Label3.Text)
                        Else
                            nextKey = CLng(Label3.Text) - 1
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
                        If Label3.Text = dsMinMaxKey.Tables("Receipt").Rows(0).Item("maxId") Then
                            nextKey = CDbl(Label3.Text)
                        Else
                            nextKey = CLng(Label3.Text) + 1
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

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub


    Private Sub cmdSearchCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearchCustomer.Click
        'gbSearch.Enabled = True
        'gbSearch.BringToFront()
        'fgSearch.Enabled = True
        'lblSearch.Text = "Search CustomerName"
        'Designgrid1()
        'SearchCustomer = 1
        'txtSearchName.Text = ""
        'txtSearchName.Focus()

        Dim StrQuery As String
        Dim i As Integer
        Designgrid2()
        da1.Dispose()
        ds1.Clear()
        Search = 1

        Try

            lblSearch.Text = "Search CustomerName"
            StrQuery = "Select CustomerCode,Customername,Address,Balance from CustomerMaster1 order by Customername"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds1, "FillGrid")
            dgSearch.RowCount = 1
            If ds1.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("CustomerCode")), "", ds1.Tables("FillGrid").Rows(i).Item("CustomerCode"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("Customername")), "", ds1.Tables("FillGrid").Rows(i).Item("Customername"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("Address")), "", ds1.Tables("FillGrid").Rows(i).Item("Address"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("Balance")), "", ds1.Tables("FillGrid").Rows(i).Item("Balance"))

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
            strMRCode = "{ReceiptMaster.ReceiptNo} = '" & Trim(txtReceiptNo.Text) & "'"
            fSalesReportViewer.CrystalReportViewer1.SelectionFormula = strMRCode
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


                    NetAmount = Val(txtReceiptAmount.Text)
                 

                    str1 = "update CustomerMaster1 set Balance=Balance-" & NetAmount & " where CustomerCode='" & CustomerCode & "'"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    With dgDetail
                        For i = 0 To .RowCount - 1
                            str1 = "update SaleMaster set ReceivedAmount=isnull(ReceivedAmount,0)+" & Val(.Rows(i).Cells(8).Value) & " where SaleInvoiceNo='" & (.Rows(i).Cells(1).Value.ToString) & "'"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                    End With


                    'With fgDetail
                    '    For i = 1 To .Rows - 1
                    '        str1 = "update SaleMaster set ReceivedAmount=isnull(ReceivedAmount,0)+" & Val(.get_TextMatrix(i, 8)) & " where SaleInvoiceNo='" & .get_TextMatrix(i, 1) & "'"

                    '        cmdCom1.Transaction = trn
                    '        cmdCom1.Connection = gl_Con
                    '        cmdCom1.CommandText = str1
                    '        cmdCom1.ExecuteNonQuery()
                    '    Next
                    'End With


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
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','Company', 'Receipt'," & Val(txtReceiptAmount.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    ElseIf Mode = "Cheque" Then
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & Trim(txtBankCode.Text) & "','Receipt'," & Val(txtReceiptAmount.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    ElseIf Mode = "BankTransfer" Then
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtReceiptNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & Trim(txtBankCode.Text) & "', 'Receipt'," & Val(txtReceiptAmount.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"

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




                    NetAmount = Val(txtReceiptAmount.Text)
                 

                    str1 = "update CustomerMaster1 set Balance=Balance+" & NetAmount & " where CustomerCode='" & CustomerCode & "'"

                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    With dgDetail
                        For i = 0 To .RowCount - 1
                            str1 = "update SaleMaster set ReceivedAmount=isnull(ReceivedAmount,0)-" & Val(.Rows(i).Cells(8).Value) & " where SaleInvoiceNo='" & (.Rows(i).Cells(1).Value.ToString) & "'"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                    End With

                    'With fgDetail
                    '    For i = 1 To .Rows - 1
                    '        str1 = "update SaleMaster set ReceivedAmount=isnull(ReceivedAmount,0)-" & Val(.get_TextMatrix(i, 8)) & " where SaleInvoiceNo='" & .get_TextMatrix(i, 1) & "'"

                    '        cmdCom1.Transaction = trn
                    '        cmdCom1.Connection = gl_Con
                    '        cmdCom1.CommandText = str1
                    '        cmdCom1.ExecuteNonQuery()
                    '    Next
                    'End With


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

    Private Sub txtChequeAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If bln_AddOn Or bln_EditOn Then
        '    txtReceiptAmount.Text = Val(txtChequeAmount.Text)
        '    With fgDetail
        '        For i = 1 To .Rows - 1
        '            If Val(.get_TextMatrix(i, 7)) > Val(txtReceiptAmount.Text) Then
        '                .set_TextMatrix(i, 8, Val(txtReceiptAmount.Text))
        '                txtReceiptAmount.Text = Val(txtReceiptAmount.Text) - Val(.get_TextMatrix(i, 8))
        '            Else
        '                .set_TextMatrix(i, 8, Val(.get_TextMatrix(i, 7)))
        '                txtReceiptAmount.Text = Val(txtReceiptAmount.Text) - Val(.get_TextMatrix(i, 8))
        '            End If
        '        Next
        '    End With
        'End If

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    'Private Sub fgDetail_AfterEdit1(ByVal sender As Object, ByVal e As AxVSFlex7L._IVSFlexGridEvents_AfterEditEvent)
    '    'With fgDetail
    '    '    txtReceiptAmount.Text = 0
    '    '    For i = 1 To .Rows - 1

    '    '        If Val(.get_TextMatrix(i, 8)) > Val(.get_TextMatrix(i, 7)) Then
    '    '            MsgBox("Amount exceeds the balance amount!")
    '    '            .set_TextMatrix(i, 8, Val(.get_TextMatrix(i, 7)))

    '    '        End If
    '    '        txtReceiptAmount.Text = Val(txtReceiptAmount.Text) + Val(.get_TextMatrix(i, 8))
    '    '    Next
    '    'End With
    'End Sub

    Private Sub fgDetail_EnterCell1(ByVal sender As Object, ByVal e As System.EventArgs)
        'If bln_AddOn = True Or bln_EditOn = True Then
        '    With fgDetail

        '        If .Col = 8 Then
        '            fgDetail.Editable = VSFlex7L.EditableSettings.flexEDKbdMouse
        '        Else
        '            fgDetail.Editable = VSFlex7L.EditableSettings.flexEDNone
        '        End If
        '    End With
        'End If
    End Sub

    'Private Sub fgDetail_KeyPressEdit1(ByVal sender As Object, ByVal e As AxVSFlex7L._IVSFlexGridEvents_KeyPressEditEvent)
    '    'Dim asci As Integer
    '    'Dim k As String
    '    'Dim i As Integer
    '    'With fgDetail




    '    '    If .Col = 8 Then
    '    '        If (e.keyAscii >= 48 And e.keyAscii <= 57) Or e.keyAscii = 46 Or e.keyAscii = 8 Then
    '    '        Else
    '    '            e.keyAscii = 0
    '    '        End If
    '    '    Else
    '    '        e.keyAscii = 0
    '    '    End If

    '    'End With
    'End Sub

    Private Sub dgDetail_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEnter
        If bln_AddOn = True Or bln_EditOn = True Then
            With dgDetail

                If e.ColumnIndex = 8 Then
                    .EditMode = DataGridViewEditMode.EditOnEnter

                Else
                    .EditMode = DataGridViewEditMode.EditProgrammatically
                End If
            End With
        End If
    End Sub

    Private Sub dgDetail_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellLeave
        With dgDetail
            txtReceiptAmount.Text = 0
            For i = 0 To .RowCount - 1

                If Val(.Rows(i).Cells(8).Value) > Val(.Rows(i).Cells(7).Value) Then
                    MsgBox("Amount exceeds the balance amount!")
                    '.set_TextMatrix(i, 8, Val(.get_TextMatrix(i, 7)))
                    .Rows(i).Cells(8).Value = Val(.Rows(i).Cells(7).Value)

                End If
                txtReceiptAmount.Text = Val(txtReceiptAmount.Text) + Val(.Rows(i).Cells(8).Value)
            Next
        End With
    End Sub

    Private Sub dgSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.DoubleClick
        With dgSearch
            If Search = 0 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                        txtReceiptNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtReceiptNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtReceiptNo.Text)
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
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                        txtCustomerName.Text = ""
                        txtCustomerName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        CustomerCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtBalance.Text = dgSearch(4, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString


                    Else
                        txtCustomerName.Text = ""
                        txtCustomerName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        CustomerCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtBalance.Text = dgSearch(4, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Balance()
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
            If Search = 0 Then
                dv = New DataView(ds.Tables(0), "ReceiptNo Like '" & Trim(txtSearch.Text) & "*" & "'", "ReceiptNo", DataViewRowState.CurrentRows)
                dTable = dv.ToTable
                dgSearch.RowCount = 1
                If dTable.Rows.Count > 0 Then
                    With dgSearch
                        For i = 0 To dTable.Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = i + 1

                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("ReceiptNo")), "", dTable.Rows(i).Item("ReceiptNo"))
                            .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(dTable.Rows(i).Item("ReceiptDate"))), "", convertToServerDateFormat(dTable.Rows(i).Item("ReceiptDate")))

                            .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("CustomerName")), "", dTable.Rows(i).Item("CustomerName"))
                            .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("Mode")), "", dTable.Rows(i).Item("Mode"))
                            .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("receiptamount")), "", dTable.Rows(i).Item("receiptamount"))


                        Next
                        .RowCount = .RowCount - 1
                    End With
                Else
                    dgSearch.RowCount = 0
                End If
            ElseIf Search = 1 Then
                dv = New DataView(ds1.Tables(0), "Customername Like '" & Trim(txtSearch.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
                dTable = dv.ToTable
                dgSearch.RowCount = 1
                If dTable.Rows.Count > 0 Then
                    With dgSearch
                        For i = 0 To dTable.Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = i + 1
                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("CustomerCode")), "", dTable.Rows(i).Item("CustomerCode"))

                            .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("Customername")), "", dTable.Rows(i).Item("Customername"))
                            .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("Address")), "", dTable.Rows(i).Item("Address"))

                            .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("Balance")), "", dTable.Rows(i).Item("Balance"))

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