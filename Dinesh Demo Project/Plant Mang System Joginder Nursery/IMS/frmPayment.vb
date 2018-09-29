Imports System.Data
Imports System.Data.SqlClient
Public Class frmPayment
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim suppliercode As String
    Dim Search As Integer
    Dim Mode As String
    Dim Approve As Integer
    Dim intDGSearchKeayPress As Integer

    Dim da As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds As New DataSet
    Dim da1 As New SqlDataAdapter   'Fro search in State Search
    Dim ds1 As New DataSet



    Private Sub frmPayment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        payment = Nothing
    End Sub

    Private Sub ENABLECONTROL(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdApprove.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdExit.Enabled = status
        cmdSearch.Enabled = status
        cmdSearchSupplier.Enabled = Not status


        txtPaymentNo.ReadOnly = True
        txtRemarks.ReadOnly = status
        txtSupplierNAme.ReadOnly = True
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

        txtRemarks.Text = ""
        txtAccNo.Text = ""
        txtBankCode.Text = ""
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
        txtSearch.Text = ""
        txtSupplierNAme.Text = ""
        txtBalance.Text = ""
        txtBankBalance.Text = ""
        txtBankBalance1.Text = ""
    End Sub

    Private Sub frmPayment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmPayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ENABLECONTROL(True)


        Display()
        dtpDate.Value = Now
        dtpChequeDate.Value = Now

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
        cboAccNo.Text = ""
        txtChequeAmount.Text = ""
        txtChequeDate.Text = ""
        txtChequeNo.Text = ""
        txtBankName.Text = ""
        txtBranch.Text = ""
        txtBankBalance.Text = ""
        txtBankBalance1.Text = ""
        txtCashBalance.Text = ""
        FillPartyBankDetail()
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
        txtBankBalance.Text = ""
        txtBankBalance1.Text = ""
        txtCashBalance.Text = ""
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
        txtBankBalance.Text = ""
        txtBankBalance1.Text = ""
        txtCashBalance.Text = ""
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ENABLECONTROL(False)
        bln_AddOn = True
        bln_EditOn = False
        txtPaymentNo.Text = showCode("Payment")
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
            Display(txtPaymentNo.Text)
        End If
        Call ENABLECONTROL(True)

        bln_AddOn = False
        bln_EditOn = False




    End Sub

    Private Sub cmdSearchSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearchSupplier.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid2()
        da1.Dispose()
        ds1.Clear()
        Search = 1

        Try

            lblSearch.Text = "Search Supplier Name"
            StrQuery = "Select SupplierCode,Suppliername,Address,Balance from SupplierMaster1 order by Suppliername"
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "FillGrid")
            dgSearch.RowCount = 1
            If ds1.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("SupplierCode")), "", ds1.Tables("FillGrid").Rows(i).Item("SupplierCode"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("Suppliername")), "", ds1.Tables("FillGrid").Rows(i).Item("Suppliername"))
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




        'gbSearch.Enabled = True
        'gbSearch.BringToFront()
        'fgSearch.Enabled = True
        'lblSearch.Text = "Search Supplier Name"
        'Designgrid1()
        'Search = 1
        'txtSearch.Text = ""
        'txtSearch.Focus()
    End Sub
    Private Sub Designgrid2()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 5
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Code"
            .Columns(1).Width = 80
            .Columns(2).Name = "Supplier Name"
            .Columns(2).Width = 200
            .Columns(3).Name = "Address"
            .Columns(3).Width = 250
            .Columns(4).Name = "Balance"
            .Columns(4).Width = 120
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
        '    .set_TextMatrix(0, 2, "SupplierName")
        '    .set_ColWidth(2, 5500)
        '    .set_TextMatrix(0, 3, "Address")
        '    .set_ColWidth(3, 5000)
        '    .set_TextMatrix(0, 4, "Balance")
        '    .set_ColWidth(4, 1500)
        'End With

        'Strquery = "Select SupplierCode,Suppliername,Address,Balance from SupplierMaster1 order by Suppliername"
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")


        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("SupplierCode")), "", ds.Tables("FillGrid").Rows(i).Item("SupplierCode")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Suppliername")), "", ds.Tables("FillGrid").Rows(i).Item("Suppliername")))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Address")), "", ds.Tables("FillGrid").Rows(i).Item("Address")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Balance")), "", ds.Tables("FillGrid").Rows(i).Item("Balance")))
        '        Next
        '    End If


        'End With



    End Sub
    Private Sub FillPartyBankDetail()
        Dim Strquery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim i As Integer



        Strquery = "SELECT     SupplierCode, SupplierName, Address, Balance, AccNo, Branch, BankName, AccHolderName, CBSCode   FROM SupplierMaster1 where suppliercode='" & suppliercode & "' "

        da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "FillGrid")



        If ds.Tables("FillGrid").Rows.Count > 0 Then
            For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
                txtPartyAccNo.Text = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AccNo")), "", ds.Tables("FillGrid").Rows(i).Item("AccNo"))
                txtPartyBankBranch.Text = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Branch")), "", ds.Tables("FillGrid").Rows(i).Item("Branch"))
                txtPartyBankName.Text = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("BankName")), "", ds.Tables("FillGrid").Rows(i).Item("BankName"))
            Next
        End If





    End Sub
    Private Sub fgSearch_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Search = 1 Then
        '    txtSupplierNAme.Text = ""
        '    txtSupplierNAme.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 2)
        '    suppliercode = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
        '    txtAddress.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 3)
        '    txtBalance.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 4)
        '    FillPartyBankDetail()
        '    gbSearch.SendToBack()
        '    gbMain.BringToFront()
        'Else
        '    Display(fgSearch.get_TextMatrix(fgSearch.RowSel, 1))

        '    gbSearch.SendToBack()
        '    gbMain.BringToFront()
        'End If

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid1()
        da.Dispose()
        ds.Clear()
        Search = 0

        Try

            lblSearch.Text = "Search PaymentNo"
            StrQuery = "SELECT PaymentMaster.PaymentId, PaymentMaster.PaymentNo, PaymentMaster.PaymentDate, SupplierMaster1.SupplierName, SupplierMaster1.SupplierCode, SupplierMaster1.Address, PaymentMaster.Remarks, PaymentMaster.Mode, PaymentMaster.CashAmount, PaymentMaster.AccNo, BankMaster.BankName, BankMaster.Branch, PaymentMaster.ChequeNo, PaymentMaster.ChequeDate, PaymentMaster.ChequeAmount, PaymentMaster.AccNo1, BankMaster_1.BankName AS BankName1, BankMaster_1.Branch AS Branch1, PaymentMaster.PartyAccNo, PaymentMaster.PartyBankName, PaymentMaster.PartyBankBranch, PaymentMaster.AmountTransfer FROM ((PaymentMaster INNER JOIN SupplierMaster1 ON PaymentMaster.SupplierCode = SupplierMaster1.SupplierCode) LEFT JOIN BankMaster ON PaymentMaster.AccNo = BankMaster.AccNo) LEFT JOIN BankMaster AS BankMaster_1 ON PaymentMaster.AccNo1 = BankMaster_1.AccNo order by PaymentNo"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("PaymentNo")), "", ds.Tables("FillGrid").Rows(i).Item("PaymentNo"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("PaymentDate"))), "", convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("PaymentDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("SupplierName")), "", ds.Tables("FillGrid").Rows(i).Item("SupplierName"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Mode")), "", ds.Tables("FillGrid").Rows(i).Item("Mode"))
                        If .Rows(i).Cells(4).Value = "Cash" Then
                            .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CashAmount")), "", ds.Tables("FillGrid").Rows(i).Item("CashAmount"))
                        ElseIf .Rows(i).Cells(4).Value = "Cheque" Then
                            .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ChequeAmount")), "", ds.Tables("FillGrid").Rows(i).Item("ChequeAmount"))
                        ElseIf .Rows(i).Cells(4).Value = "BankTransfer" Then
                            .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AmountTransfer")), "", ds.Tables("FillGrid").Rows(i).Item("AmountTransfer"))
                        End If

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
        'gbSearch.Enabled = True
        'gbSearch.BringToFront()
        'fgSearch.Enabled = True
        'lblSearch.Text = "Search PaymentNo"
        'FillSearchDetail()
        'Search = 0
        'txtSearch.Text = ""
        'txtSearch.Focus()
    End Sub

    Private Sub Designgrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 6
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Payment No"
            .Columns(1).Width = 100
            .Columns(2).Name = "PaymentDate"
            .Columns(2).Width = 100
            .Columns(3).Name = "Supplier Name"
            .Columns(3).Width = 210
            .Columns(4).Name = "Mode"
            .Columns(4).Width = 130
            .Columns(5).Name = "Amount"
            .Columns(5).Width = 110
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
        '    .Height = 437
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "PaymentNo")
        '    .set_ColWidth(1, 1000)
        '    .set_TextMatrix(0, 2, "PaymentDate")
        '    .set_ColWidth(2, 1400)
        '    .set_TextMatrix(0, 3, "SupplierName")
        '    .set_ColWidth(3, 3500)
        '    .set_TextMatrix(0, 4, "Mode")
        '    .set_ColWidth(4, 1500)
        '    .set_TextMatrix(0, 5, "Amount")
        '    .set_ColWidth(5, 1500)

        'End With

        'Strquery = "SELECT PaymentMaster.PaymentId, PaymentMaster.PaymentNo, PaymentMaster.PaymentDate, SupplierMaster1.SupplierName, SupplierMaster1.SupplierCode, SupplierMaster1.Address, PaymentMaster.Remarks, PaymentMaster.Mode, PaymentMaster.CashAmount, PaymentMaster.AccNo, BankMaster.BankName, BankMaster.Branch, PaymentMaster.ChequeNo, PaymentMaster.ChequeDate, PaymentMaster.ChequeAmount, PaymentMaster.AccNo1, BankMaster_1.BankName AS BankName1, BankMaster_1.Branch AS Branch1, PaymentMaster.PartyAccNo, PaymentMaster.PartyBankName, PaymentMaster.PartyBankBranch, PaymentMaster.AmountTransfer FROM ((PaymentMaster INNER JOIN SupplierMaster1 ON PaymentMaster.SupplierCode = SupplierMaster1.SupplierCode) LEFT JOIN BankMaster ON PaymentMaster.AccNo = BankMaster.AccNo) LEFT JOIN BankMaster AS BankMaster_1 ON PaymentMaster.AccNo1 = BankMaster_1.AccNo order by PaymentNo"

        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")


        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("PaymentNo")), "", ds.Tables("FillGrid").Rows(i).Item("PaymentNo")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("PaymentDate"))), "", convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("PaymentDate"))))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("SupplierName")), "", ds.Tables("FillGrid").Rows(i).Item("SupplierName")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Mode")), "", ds.Tables("FillGrid").Rows(i).Item("Mode")))
        '            If .get_TextMatrix(i + 1, 4) = "Cash" Then
        '                .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CashAmount")), "", ds.Tables("FillGrid").Rows(i).Item("CashAmount")))
        '            ElseIf .get_TextMatrix(i + 1, 4) = "Cheque" Then
        '                .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ChequeAmount")), "", ds.Tables("FillGrid").Rows(i).Item("ChequeAmount")))
        '            ElseIf .get_TextMatrix(i + 1, 4) = "BankTransfer" Then
        '                .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AmountTransfer")), "", ds.Tables("FillGrid").Rows(i).Item("AmountTransfer")))
        '            End If
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
        Dim StrQuery As String
        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction
        Dim daEdit As SqlClient.SqlDataAdapter
        Dim dsEdit As New DataSet
        Dim i As Integer
        Dim j As Integer
        Dim r As Integer
        Dim Amount As Decimal
        Dim NetAmount As Decimal
        Dim accno As String
        Dim sender As New System.Object
        Dim e As New System.EventArgs


        Try






            If txtSupplierNAme.Text = "" Then
                MsgBox("Please Select Supplier Name")
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
                        str1 = "Insert into PaymentMaster(PaymentNo,PaymentDate,SupplierCode,PrevBalance, Remarks,Mode,CashAmount,CashBalance) values('" & txtPaymentNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & suppliercode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "'," & Val(txtCashAmount.Text) & "," & Val(txtCashBalance.Text) & ")"
                    ElseIf Mode = "Cheque" Then
                        str1 = "Insert into PaymentMaster(PaymentNo,PaymentDate,SupplierCode,PrevBalance, Remarks,Mode,BankCode,AccNo,ChequeNo,ChequeDate,ChequeAmount,BankBalance) values('" & txtPaymentNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & suppliercode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "','" & Trim(txtBankCode.Text) & "','" & Replace(cboAccNo.Text, "'", "''") & "','" & Replace(txtChequeNo.Text, "'", "''") & "','" & convertToServerDateFormat(dtpChequeDate.Value) & "'," & Val(txtChequeAmount.Text) & "," & Val(txtBankBalance.Text) & ")"
                    ElseIf Mode = "BankTransfer" Then
                        str1 = "Insert into PaymentMaster(PaymentNo,PaymentDate,SupplierCode,PrevBalance, Remarks,Mode,BankCode1,AccNo1,PartyAccNo,PartyBankName,PartyBankBranch,AmountTransfer,BankBalance) values('" & txtPaymentNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & suppliercode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "','" & Trim(txtBankCode.Text) & "','" & Replace(cboAccNo1.Text, "'", "''") & "','" & Replace(txtPartyAccNo.Text, "'", "''") & "','" & Replace(txtPartyBankName.Text, "'", "''") & "','" & Replace(txtPartyBankBranch.Text, "'", "''") & "'," & Val(txtAmounttransfer.Text) & "," & Val(txtBankBalance1.Text) & ")"
                    End If


                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    ''**********************************************************************************************
                    str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='Payment'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtPaymentNo.Text))
                    bln_AddOn = False
                    bln_EditOn = False
                    Call cmdApprove_Click(sender, e)
                End If
            ElseIf bln_EditOn = True Then
                If MsgQuestion("UPDATE") = 6 Then




                    If Mode = "Cash" Then
                        str1 = "update PaymentMaster set PaymentDate='" & convertToServerDateFormat(dtpDate.Value) & "',SupplierCode='" & suppliercode & "',PrevBalance=" & Val(txtBalance.Text) & ", Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',CashAmount=" & Val(txtCashAmount.Text) & ",AccNo='" & Replace(cboAccNo.Text, "'", "''") & "',ChequeNo='" & Replace(txtChequeNo.Text, "'", "''") & "',ChequeDate='" & convertToServerDateFormat(dtpChequeDate.Value) & "',ChequeAmount=" & Val(txtChequeAmount.Text) & ",AccNo1='" & Replace(cboAccNo1.Text, "'", "''") & "',PartyAccNo='" & Replace(txtPartyAccNo.Text, "'", "''") & "',PartyBankName='" & Replace(txtPartyBankName.Text, "'", "''") & "',PartyBankBranch='" & Replace(txtPartyBankBranch.Text, "'", "''") & "',AmountTransfer=" & Val(txtAmounttransfer.Text) & " where PaymentNo='" & txtPaymentNo.Text & "'"

                    ElseIf Mode = "Cheque" Then
                        str1 = "update PaymentMaster set PaymentDate='" & convertToServerDateFormat(dtpDate.Value) & "',SupplierCode='" & suppliercode & "', PrevBalance=" & Val(txtBalance.Text) & ",Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',CashAmount=" & Val(txtCashAmount.Text) & ",BankCode='" & Trim(txtBankCode.Text) & "',AccNo='" & Replace(cboAccNo.Text, "'", "''") & "',ChequeNo='" & Replace(txtChequeNo.Text, "'", "''") & "',ChequeDate='" & convertToServerDateFormat(dtpChequeDate.Value) & "',ChequeAmount=" & Val(txtChequeAmount.Text) & ",AccNo1='" & Replace(cboAccNo1.Text, "'", "''") & "',PartyAccNo='" & Replace(txtPartyAccNo.Text, "'", "''") & "',PartyBankName='" & Replace(txtPartyBankName.Text, "'", "''") & "',PartyBankBranch='" & Replace(txtPartyBankBranch.Text, "'", "''") & "',AmountTransfer=" & Val(txtAmounttransfer.Text) & " where PaymentNo='" & txtPaymentNo.Text & "'"
                    ElseIf Mode = "BankTransfer" Then
                        str1 = "update PaymentMaster set PaymentDate='" & convertToServerDateFormat(dtpDate.Value) & "',SupplierCode='" & suppliercode & "',Balance=" & Val(txtBalance.Text) & ", Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',CashAmount=" & Val(txtCashAmount.Text) & ",BankCode1='" & Trim(txtBankCode.Text) & "',AccNo='" & Replace(cboAccNo.Text, "'", "''") & "',ChequeNo='" & Replace(txtChequeNo.Text, "'", "''") & "',ChequeDate='" & convertToServerDateFormat(dtpChequeDate.Value) & "',ChequeAmount=" & Val(txtChequeAmount.Text) & ",AccNo1='" & Replace(cboAccNo1.Text, "'", "''") & "',PartyAccNo='" & Replace(txtPartyAccNo.Text, "'", "''") & "',PartyBankName='" & Replace(txtPartyBankName.Text, "'", "''") & "',PartyBankBranch='" & Replace(txtPartyBankBranch.Text, "'", "''") & "',AmountTransfer=" & Val(txtAmounttransfer.Text) & " where PaymentNo='" & txtPaymentNo.Text & "'"
                    End If



                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtPaymentNo.Text))
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

                str1 = "SELECT PaymentMaster.CashBalance,PaymentMaster.BankCode,PaymentMaster.BankCode1,PaymentMaster.Approve,PaymentMaster.BankBalance,PaymentMaster.PaymentId, PaymentMaster.PaymentNo, PaymentMaster.PaymentDate, SupplierMaster1.SupplierName, SupplierMaster1.SupplierCode,PaymentMaster.PrevBalance, SupplierMaster1.Address, PaymentMaster.Remarks, PaymentMaster.Mode, PaymentMaster.CashAmount, PaymentMaster.AccNo, BankMaster.BankName, BankMaster.Branch, PaymentMaster.ChequeNo, PaymentMaster.ChequeDate, PaymentMaster.ChequeAmount, PaymentMaster.AccNo1, BankMaster_1.BankName AS BankName1, BankMaster_1.Branch AS Branch1, PaymentMaster.PartyAccNo, PaymentMaster.PartyBankName, PaymentMaster.PartyBankBranch, PaymentMaster.AmountTransfer FROM ((PaymentMaster INNER JOIN SupplierMaster1 ON PaymentMaster.SupplierCode = SupplierMaster1.SupplierCode) LEFT JOIN BankMaster ON PaymentMaster.AccNo = BankMaster.AccNo) LEFT JOIN BankMaster AS BankMaster_1 ON PaymentMaster.AccNo1 = BankMaster_1.AccNo WHERE (((PaymentMaster.PaymentId)=(SELECT     MAX(PaymentId)FROM          PaymentMaster)))  "
            Else
                str1 = "SELECT PaymentMaster.CashBalance,PaymentMaster.BankCode,PaymentMaster.BankCode1,PaymentMaster.Approve,PaymentMaster.BankBalance,PaymentMaster.PaymentId, PaymentMaster.PaymentNo, PaymentMaster.PaymentDate, SupplierMaster1.SupplierName, SupplierMaster1.SupplierCode,PaymentMaster.PrevBalance, SupplierMaster1.Address, PaymentMaster.Remarks, PaymentMaster.Mode, PaymentMaster.CashAmount, PaymentMaster.AccNo, BankMaster.BankName, BankMaster.Branch, PaymentMaster.ChequeNo, PaymentMaster.ChequeDate, PaymentMaster.ChequeAmount, PaymentMaster.AccNo1, BankMaster_1.BankName AS BankName1, BankMaster_1.Branch AS Branch1, PaymentMaster.PartyAccNo, PaymentMaster.PartyBankName, PaymentMaster.PartyBankBranch, PaymentMaster.AmountTransfer FROM ((PaymentMaster INNER JOIN SupplierMaster1 ON PaymentMaster.SupplierCode = SupplierMaster1.SupplierCode) LEFT JOIN BankMaster ON PaymentMaster.AccNo = BankMaster.AccNo) LEFT JOIN BankMaster AS BankMaster_1 ON PaymentMaster.AccNo1 = BankMaster_1.AccNo WHERE      (PaymentMaster.PaymentNo='" & strMRqNo & "') "
            End If





            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "MR")

            If dsDS1.Tables("MR").Rows.Count > 0 Then
                lblPrimaryKey.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PaymentId")), "", dsDS1.Tables("MR").Rows(0).Item("PaymentId"))
                Approve = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Approve")), 0, dsDS1.Tables("MR").Rows(0).Item("Approve"))
                If Approve = 1 Then
                    cmdApprove.Text = "Approved"
                    cmdEdit.Enabled = False
                Else
                    cmdApprove.Text = "Approve"
                    cmdEdit.Enabled = True
                End If
                txtPaymentNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PaymentNo")), "", dsDS1.Tables("MR").Rows(0).Item("PaymentNo"))
                dtpDate.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("PaymentDate"))), "01/01/1990", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("PaymentDate")))
                txtdate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("PaymentDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("PaymentDate")))
                suppliercode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("SupplierCode")), "", dsDS1.Tables("MR").Rows(0).Item("SupplierCode"))
                txtSupplierNAme.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("SupplierName")), "", dsDS1.Tables("MR").Rows(0).Item("SupplierName"))
                txtBalance.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PrevBalance")), "", dsDS1.Tables("MR").Rows(0).Item("PrevBalance"))
                txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address")), "", dsDS1.Tables("MR").Rows(0).Item("Address"))

                txtRemarks.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Remarks")), "", dsDS1.Tables("MR").Rows(0).Item("Remarks"))
                Mode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Mode")), "", dsDS1.Tables("MR").Rows(0).Item("Mode"))
                If Mode = "Cash" Then
                    txtCashAmount.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CashAmount")), "", dsDS1.Tables("MR").Rows(0).Item("CashAmount"))
                    txtCashBalance.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CashBalance")), "", dsDS1.Tables("MR").Rows(0).Item("CashBalance"))
                    gbBankTransfer.Visible = False
                    gbCash.Visible = True
                    gbCheque.Visible = False
                    optCash.Checked = True
                ElseIf Mode = "Cheque" Then
                    gbBankTransfer.Visible = False
                    gbCash.Visible = False
                    gbCheque.Visible = True
                    optCheque.Checked = True
                    cboAccNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo"))
                    txtAccNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo"))
                    txtBankCode.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankCode")), "", dsDS1.Tables("MR").Rows(0).Item("BankCode"))
                    dtpChequeDate.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate"))), "01/01/1990", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate")))
                    txtChequeDate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChequeDate")))
                    txtBankName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankName")), "", dsDS1.Tables("MR").Rows(0).Item("BankName"))
                    txtBranch.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Branch")), "", dsDS1.Tables("MR").Rows(0).Item("Branch"))

                    txtChequeNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ChequeNo")), "", dsDS1.Tables("MR").Rows(0).Item("ChequeNo"))

                    txtChequeAmount.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ChequeAmount")), "", dsDS1.Tables("MR").Rows(0).Item("ChequeAmount"))
                    txtBankBalance.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankBalance")), "", dsDS1.Tables("MR").Rows(0).Item("BankBalance"))

                ElseIf Mode = "BankTransfer" Then
                    gbBankTransfer.Visible = True
                    gbCash.Visible = False
                    gbCheque.Visible = False
                    optBankTransfer.Checked = True
                    cboAccNo1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo1")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo1"))
                    txtAccNo1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo1")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo1"))
                    txtBankCode.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankCode1")), "", dsDS1.Tables("MR").Rows(0).Item("BankCode1"))
                    txtBankName1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankName1")), "", dsDS1.Tables("MR").Rows(0).Item("BankName1"))
                    txtBranch1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Branch1")), "", dsDS1.Tables("MR").Rows(0).Item("Branch1"))
                    txtAmounttransfer.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AmountTransfer")), "", dsDS1.Tables("MR").Rows(0).Item("AmountTransfer"))

                    txtPartyAccNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PartyAccNo")), "", dsDS1.Tables("MR").Rows(0).Item("PartyAccNo"))
                    txtPartyBankBranch.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PartyBankBranch")), "", dsDS1.Tables("MR").Rows(0).Item("PartyBankBranch"))
                    txtPartyBankName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PartyBankName")), "", dsDS1.Tables("MR").Rows(0).Item("PartyBankName"))
                    txtBankBalance1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankBalance")), "", dsDS1.Tables("MR").Rows(0).Item("BankBalance"))
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
                strMinMaxKey = "select max(PaymentId) AS MaxId,MIN(PaymentId) As MinId from PaymentMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet

                'fill the dataset with min and max Id's 
                'give the name to table "ItemID"

                daMinMaxKey.Fill(dsMinMaxKey, "Payment")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("Payment").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select PaymentNo  from PaymentMaster where PaymentId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PaymentNavigation")

                        txtPaymentNo.Text = dsMinMaxKey.Tables("PaymentNavigation").Rows(0).Item("PaymentNo")
                        Call Display(txtPaymentNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Payment").Rows(0).Item("minId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Payment").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select PaymentNo from PaymentMaster where PaymentId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PaymentNavigation")

                            If dsMinMaxKey.Tables("PaymentNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Payment").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtPaymentNo.Text = dsMinMaxKey.Tables("PaymentNavigation").Rows(0).Item("PaymentNo")
                        Call Display(txtPaymentNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Payment").Rows(0).Item("maxId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Payment").Rows(0).Item("maxId")
                            strNextRecord = "select PaymentNo from PaymentMaster where PaymentId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PaymentNavigation")

                            If dsMinMaxKey.Tables("PaymentNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Payment").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtPaymentNo.Text = dsMinMaxKey.Tables("PaymentNavigation").Rows(0).Item("PaymentNo")
                        Call Display(txtPaymentNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Payment").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select PaymentNo from PaymentMaster where PaymentId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PaymentNavigation")

                        txtPaymentNo.Text = dsMinMaxKey.Tables("PaymentNavigation").Rows(0).Item("PaymentNo")
                        Call Display(txtPaymentNo.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub fgSearch_KeyPressEvent(ByVal sender As Object, ByVal e As AxVSFlex7L._IVSFlexGridEvents_KeyPressEvent)
    '    Dim e1 As System.EventArgs
    '    fgSearch_DblClick(sender, e1)
    'End Sub


    'Private Sub txtsearchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged


    '    Dim intLoop As Integer
    '    Dim intLength As Integer
    '    Dim f_intRowFound As Integer
    '    Dim i As Integer
    '    Dim j As Integer

    '    If Search = 0 Then
    '        i = 1
    '        j = 4
    '    Else
    '        i = 2
    '        j = 1
    '    End If



    '    intLength = Len(txtSearch.Text)
    '    If fgSearch.Rows > 1 Then
    '        For intLoop = 1 To fgSearch.Rows - 1

    '            If LCase(txtSearchName.Text) = LCase(Mid(fgSearch.get_TextMatrix(intLoop, i), j, intLength)) Then
    '                f_intRowFound = intLoop
    '                fgSearch.Row = f_intRowFound
    '                fgSearch.TopRow = f_intRowFound
    '                Exit Sub
    '            Else
    '                fgSearch.Row = f_intRowFound
    '                fgSearch.TopRow = f_intRowFound
    '            End If



    '        Next
    '    End If

    'End Sub


    Private Sub cmdApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim StrQuery As String
        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction
        Dim daEdit As SqlClient.SqlDataAdapter
        Dim dsEdit As New DataSet
        Dim i As Integer
        Dim j As Integer
        Dim r As Integer
        Dim Amount As Decimal
        Dim NetAmount As Decimal
        Dim accno As String


        Try


            StrQuery = "SELECT  PaymentMaster.SupplierCode, PaymentMaster.Mode, PaymentMaster.CashAmount, PaymentMaster.AccNo, PaymentMaster.AccNo1, PaymentMaster.ChequeAmount, PaymentMaster.AmountTransfer FROM PaymentMaster WHERE     (PaymentMaster.PaymentNo = '" & txtPaymentNo.Text & "')"

            daEdit = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            daEdit.Fill(dsEdit, "SaleEdit")


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

                    str1 = "update supplierMaster1 set Balance=Balance-" & NetAmount & " where suppliercode='" & suppliercode & "'"
                    trn = gl_Con.BeginTransaction
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
                    ''********************************************LEDGER UPDATE***************************************


                    str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtPaymentNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & suppliercode & "', '" & Mode & "'," & NetAmount & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    If Mode = "Cash" Then
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtPaymentNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','Company', '" & Mode & "',0," & Val(txtCashAmount.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    ElseIf Mode = "Cheque" Then
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtPaymentNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & Trim(txtBankCode.Text) & "', '" & Mode & "',0," & Val(txtChequeAmount.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    ElseIf Mode = "BankTransfer" Then
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtPaymentNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & Trim(txtBankCode.Text) & "', '" & Mode & "',0," & Val(txtAmounttransfer.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    End If


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()



                    str1 = "update PaymentMaster set Approve=1 where PaymentNo='" & txtPaymentNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()



                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtPaymentNo.Text))
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

                    StrQuery = "Delete From Ledger where transactionno='" & txtPaymentNo.Text & "'"

                    trn = gl_Con.BeginTransaction
                    cmdCom1 = New SqlClient.SqlCommand(StrQuery, gl_Con)
                    cmdCom1.CommandType = CommandType.Text
                    cmdCom1.Transaction = trn
                    cmdCom1.ExecuteNonQuery()




                    If dsEdit.Tables("SaleEdit").Rows.Count > 0 Then

                        If dsEdit.Tables("SaleEdit").Rows(0).Item("Mode") = "Cash" Then
                            Amount = dsEdit.Tables("SaleEdit").Rows(0).Item("CashAmount")
                        ElseIf dsEdit.Tables("SaleEdit").Rows(0).Item("Mode") = "Cheque" Then
                            Amount = dsEdit.Tables("SaleEdit").Rows(0).Item("ChequeAmount")
                        ElseIf dsEdit.Tables("SaleEdit").Rows(0).Item("Mode") = "BankTransfer" Then
                            Amount = dsEdit.Tables("SaleEdit").Rows(0).Item("AmountTransfer")
                        End If

                        str1 = "update supplierMaster1 set Balance=Balance+" & Amount & " where supplierCode='" & dsEdit.Tables("SaleEdit").Rows(0).Item("supplierCode") & "'"
                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()
                    End If


                    If dsEdit.Tables("SaleEdit").Rows.Count > 0 Then

                        If dsEdit.Tables("SaleEdit").Rows(0).Item("Mode") = "Cheque" Then
                            accno = dsEdit.Tables("SaleEdit").Rows(0).Item("AccNo")
                            str1 = "update BankMaster set CurrentBalance=CurrentBalance+" & Amount & " where AccNo='" & accno & "'"
                        ElseIf dsEdit.Tables("SaleEdit").Rows(0).Item("Mode") = "BankTransfer" Then
                            accno = dsEdit.Tables("SaleEdit").Rows(0).Item("AccNo1")
                            str1 = "update BankMaster set CurrentBalance=CurrentBalance+" & Amount & " where AccNo='" & accno & "'"
                        ElseIf Mode = "Cash" Then
                            str1 = "update CompanyMaster1 set CurrentBalance=CurrentBalance+" & Amount & ""
                        End If
                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()

                        str1 = "update PaymentMaster set Approve=0 where PaymentNo='" & txtPaymentNo.Text & "'"
                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()



                    End If

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()

                    Call Display(Trim(txtPaymentNo.Text))
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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
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
                        txtPaymentNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtPaymentNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtPaymentNo.Text)
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
                        txtSupplierNAme.Text = ""
                        txtSupplierNAme.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        suppliercode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtBalance.Text = dgSearch(4, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                    Else
                        txtSupplierNAme.Text = ""
                        txtSupplierNAme.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        suppliercode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtBalance.Text = dgSearch(4, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    FillPartyBankDetail()
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                End If
            End If
        End With
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
                dv = New DataView(ds.Tables(0), "PaymentNo Like '" & Trim(txtSearch.Text) & "*" & "'", "PaymentNo", DataViewRowState.CurrentRows)
                dTable = dv.ToTable
                dgSearch.RowCount = 1
                If dTable.Rows.Count > 0 Then
                    With dgSearch
                        For i = 0 To dTable.Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = i + 1

                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("PaymentNo")), "", dTable.Rows(i).Item("PaymentNo"))

                            .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(dTable.Rows(i).Item("PaymentDate"))), "", convertToServerDateFormat(dTable.Rows(i).Item("PaymentDate")))

                            .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("SupplierName")), "", dTable.Rows(i).Item("SupplierName"))

                            .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("Mode")), "", dTable.Rows(i).Item("Mode"))
                            If .Rows(i).Cells(4).Value = "Cash" Then
                                .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("CashAmount")), "", dTable.Rows(i).Item("CashAmount"))
                            ElseIf .Rows(i).Cells(4).Value = "Cheque" Then
                                .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("ChequeAmount")), "", dTable.Rows(i).Item("ChequeAmount"))
                            ElseIf .Rows(i).Cells(4).Value = "BankTransfer" Then
                                .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("AmountTransfer")), "", dTable.Rows(i).Item("AmountTransfer"))
                            End If

                        Next
                        .RowCount = .RowCount - 1
                    End With
                Else
                    dgSearch.RowCount = 0
                End If
            ElseIf Search = 1 Then
                dv = New DataView(ds1.Tables(0), "Suppliername Like '" & Trim(txtSearch.Text) & "*" & "'", "SupplierCode", DataViewRowState.CurrentRows)
                dTable = dv.ToTable
                dgSearch.RowCount = 1
                If dTable.Rows.Count > 0 Then
                    With dgSearch
                        For i = 0 To dTable.Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = i + 1
                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("SupplierCode")), "", dTable.Rows(i).Item("SupplierCode"))

                            .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("Suppliername")), "", dTable.Rows(i).Item("Suppliername"))
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

    Private Sub dgSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSearch.KeyPress
        Dim e1 As System.EventArgs
        If (e.KeyChar = Convert.ToChar(13)) Then
            intDGSearchKeayPress = 1
            dgSearch_DoubleClick(sender, e1)
        End If
    End Sub
End Class