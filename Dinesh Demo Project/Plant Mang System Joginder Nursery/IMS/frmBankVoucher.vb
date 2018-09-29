Imports System.Data
Imports System.Data.SqlClient
Public Class frmBankVoucher
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim BankCode As String
    Dim Search As Integer
    Dim Mode As String
    Dim Approve As Integer
    Dim intDGSearchKeayPress As Integer

    Dim da As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds As New DataSet
    Dim da1 As New SqlDataAdapter   'Fro search in State Search
    Dim ds1 As New DataSet



    Private Sub ENABLECONTROL(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdApprove.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdExit.Enabled = status
        cmdSearch.Enabled = status
        cmdSearchSupplier.Enabled = Not status


        txtBankVoucherNo.ReadOnly = True
        txtRemarks.ReadOnly = status
        txtBankName.ReadOnly = True
        cboDR.Enabled = Not status
        txtBankName1.ReadOnly = True
        txtBranch1.ReadOnly = True

        txtAccNo1.ReadOnly = True
        txtCashAmount.ReadOnly = status
        txtAmounttransfer.ReadOnly = status
        txtdate.ReadOnly = True
        txtBranch.ReadOnly = True




        optCashWithdrawl.Enabled = Not status
        optCashDeposit.Enabled = Not status
        optBankTransfer.Enabled = Not status



        If cmdSave.Enabled = True Then
            dtpDate.BringToFront()
            txtdate.SendToBack()

            txtAccNo1.SendToBack()
            cboAccNo1.BringToFront()
        Else
            dtpDate.SendToBack()
            txtdate.BringToFront()

            txtAccNo1.BringToFront()
            cboAccNo1.SendToBack()

        End If



    End Sub

    Private Sub ClearControl()

        txtRemarks.Text = ""
        txtBankCode1.Text = ""
        txtAccNo1.Text = ""
        txtBranch.Text = ""
        txtAmounttransfer.Text = ""

        txtBankName1.Text = ""

        txtBranch1.Text = ""
        txtCashAmount.Text = ""


        txtdate.Text = ""

        txtSearch.Text = ""
        txtBankName.Text = ""
        txtBalance.Text = ""
        cboDR.Text = ""
        txtBankBalance1.Text = ""
    End Sub

    Private Sub frmBankVoucher_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        BankVoucher = Nothing
    End Sub

    Private Sub frmBankVoucher_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmBankVoucher_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ENABLECONTROL(True)


        Display()
        dtpDate.Value = Now


    End Sub

    Private Sub optBankTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optBankTransfer.Click
        gbBankTransfer.Visible = True
        gbCash.Visible = False

        Mode = "BankTransfer"
        txtCashAmount.Text = ""
        cboAccNo1.Text = ""
        txtAmounttransfer.Text = ""

        txtBankName1.Text = ""
        txtBranch1.Text = ""

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ENABLECONTROL(False)
        bln_AddOn = True
        txtBankVoucherNo.Text = showCode("BankVoucher")
        ClearControl()
        'FillBank()
        FillBank1()

        optCashDeposit.Checked = True
        gbBankTransfer.Visible = False
        gbCash.Visible = True

        gbCash.BringToFront()
        Mode = "CashDeposit"
    End Sub
    Private Sub FillBank1()
        Dim strQuery As String
        Dim daConfig As SqlClient.SqlDataAdapter
        Dim dsConfig As New DataSet

        Try

            If txtBankName.Text = "" Then
                MsgBox("Please Select Bank Name First")
                Exit Sub
            Else
                strQuery = "Select AccNo from BankMaster  where AccCode<>'" & BankCode & "' Order By AccCode"

                daConfig = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
                daConfig.Fill(dsConfig, "Config")
                cboAccNo1.DataSource = Nothing
                cboAccNo1.DataSource = dsConfig.Tables("Config")
                cboAccNo1.DisplayMember = "AccNo"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdSearchSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearchSupplier.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid2()
        da1.Dispose()
        ds1.Clear()
        Search = 1

        Try

            lblSearch.Text = "Search Bank Name"
            StrQuery = "Select AccCode,AccNo,BankName,Branch,CurrentBalance from BankMaster order by BankName"
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "FillGrid")
            dgSearch.RowCount = 1
            If ds1.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("AccCode")), "", ds1.Tables("FillGrid").Rows(i).Item("AccCode"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("AccNo")), "", ds1.Tables("FillGrid").Rows(i).Item("AccNo"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("BankName")), "", ds1.Tables("FillGrid").Rows(i).Item("BankName"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("Branch")), "", ds1.Tables("FillGrid").Rows(i).Item("Branch"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("CurrentBalance")), "", ds1.Tables("FillGrid").Rows(i).Item("CurrentBalance"))

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
        'Label14.Text = "Search BankName"
        'Designgrid1()
        'Search = 1
        'txtSearchName.Text = ""
        'txtSearchName.Focus()
    End Sub
    Private Sub Designgrid2()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 6
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Bank Code"
            .Columns(1).Width = 100
            .Columns(2).Name = "Accountn No"
            .Columns(2).Width = 120
            .Columns(3).Name = "Bank Name"
            .Columns(3).Width = 150
            .Columns(4).Name = "Branch"
            .Columns(4).Width = 150
            .Columns(5).Name = "Balance"
            .Columns(5).Width = 120
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
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "BankCode")
        '    .set_ColWidth(1, 1200)
        '    .set_TextMatrix(0, 2, "AccountNo")
        '    .set_ColWidth(2, 2500)
        '    .set_TextMatrix(0, 3, "BankName")
        '    .set_ColWidth(3, 2500)
        '    .set_TextMatrix(0, 4, "Branch")
        '    .set_ColWidth(4, 1500)
        '    .set_TextMatrix(0, 5, "Balance")
        '    .set_ColWidth(5, 1500)
        'End With

        'Strquery = "Select AccCode,AccNo,BankName,Branch,CurrentBalance from BankMaster order by BankName"
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
        '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CurrentBalance")), "", ds.Tables("FillGrid").Rows(i).Item("CurrentBalance")))
        '        Next
        '    End If


        'End With

    End Sub


    Private Sub fgSearch_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)

        'If Search = 1 Then
        '    txtBankName.Text = ""
        '    txtBankName.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 3)
        '    BankCode = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
        '    txtBranch.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 4)
        '    txtBalance.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 5)

        '    gbSearch.SendToBack()
        '    gbMain.BringToFront()
        'Else

        '    Display(fgSearch.get_TextMatrix(fgSearch.RowSel, 1))
        '    gbSearch.SendToBack()
        '    gbMain.BringToFront()

        'End If
    End Sub

    Private Sub cboAccNo1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccNo1.Click
        FillBank1()
    End Sub

    Private Sub cboAccNo1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccNo1.SelectedIndexChanged
        FillBankName1()
    End Sub
    Private Sub FillBankName1()
        Dim strQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet

        Try

            If txtBankName.Text = "" Then
                MsgBox("Please Select Bank Name First")
                Exit Sub
            Else
                strQuery = "Select AccCode,AccNo,BankName,Branch,CurrentBalance from BankMaster   where AccNo='" & cboAccNo1.Text & "'"
                da = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
                da.Fill(ds, "Bank")
                If ds.Tables("Bank").Rows.Count > 0 Then
                    txtBankName1.Text = ds.Tables("Bank").Rows(0).Item("BankName")
                    txtBranch1.Text = ds.Tables("Bank").Rows(0).Item("Branch")
                    txtBankBalance1.Text = ds.Tables("Bank").Rows(0).Item("CurrentBalance")
                    txtBankCode1.Text = ds.Tables("Bank").Rows(0).Item("AccCode")
                End If
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    'Private Sub FillCash()
    '    Dim strQuery As String
    '    Dim da As SqlClient.SqlDataAdapter
    '    Dim ds As New DataSet

    '    Try
    '        strQuery = "Select CurrentBalance from CompanyMaster1"
    '        da = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
    '        da.Fill(ds, "Bank")
    '        If ds.Tables("Bank").Rows.Count > 0 Then

    '            txtCashBalance.Text = ds.Tables("Bank").Rows(0).Item("CurrentBalance")
    '        End If




    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub optCashDeposit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCashDeposit.Click
        gbBankTransfer.Visible = False
        gbCash.Visible = True
        gbCash.Text = "CashDeposit"

        Mode = "CashDeposit"
        txtCashAmount.Text = ""
        cboAccNo1.Text = ""
        txtAmounttransfer.Text = ""

        txtBankName1.Text = ""
        txtBranch1.Text = ""

        txtBankBalance1.Text = ""
        ' FillCash()
    End Sub

    Private Sub optCashWithdrawl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCashWithdrawl.Click
        gbBankTransfer.Visible = False
        gbCash.Visible = True
        gbCash.Text = "CashWithdrawl"
        Mode = "CashWithdrawl"
        txtCashAmount.Text = ""
        cboAccNo1.Text = ""
        txtAmounttransfer.Text = ""

        txtBankName1.Text = ""
        txtBranch1.Text = ""

        txtBankBalance1.Text = ""
        ' FillCash()
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

        'Call Display()


    End Sub
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        DesignGrid1()
        da.Dispose()
        ds.Clear()
        Search = 0

        Try

            lblSearch.Text = "Search Voucher No"
            StrQuery = "SELECT BankVoucher.BankVoucherId, BankVoucher.BankVoucherNo, BankVoucher.BankVoucherDate, BankMaster.AccNo,  BankMaster.BankName,BankVoucher.CashDepositAmount, BankVoucher.Mode, BankVoucher.CashWithdrawlAmount, BankVoucher.AmountTransfer FROM BankVoucher INNER JOIN BankMaster ON BankVoucher.BankCode = BankMaster.AccCode ORDER BY BankVoucher.BankVoucherNo"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("BankVoucherNo")), "", ds.Tables("FillGrid").Rows(i).Item("BankVoucherNo"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("BankVoucherDate")), "", ds.Tables("FillGrid").Rows(i).Item("BankVoucherDate"))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AccNo")), "", ds.Tables("FillGrid").Rows(i).Item("AccNo"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("BankName")), "", ds.Tables("FillGrid").Rows(i).Item("BankName"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Mode")), "", ds.Tables("FillGrid").Rows(i).Item("Mode"))
                        If .Rows(i).Cells(5).Value = "CashDeposit" Then

                            .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CashDepositAmount")), "", ds.Tables("FillGrid").Rows(i).Item("CashDepositAmount"))
                        ElseIf .Rows(i).Cells(5).Value = "CashWithdrawl" Then

                            .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CashWithdrawlAmount")), "", ds.Tables("FillGrid").Rows(i).Item("CashWithdrawlAmount"))
                        ElseIf .Rows(i).Cells(5).Value = "BankTransfer" Then
                            .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AmountTransfer")), "", ds.Tables("FillGrid").Rows(i).Item("AmountTransfer"))
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
        'lblSearch.Text = "Search BankVoucherNo"
        'FillSearchDetail()
        'Search = 0
        'txtSearch.Text = ""
        'txtSearch.Focus()
    End Sub
    Private Sub DesignGrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 7
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Voucher No"
            .Columns(1).Width = 100
            .Columns(2).Name = "VoucherDate"
            .Columns(2).Width = 100
            .Columns(3).Name = "AccountNo"
            .Columns(3).Width = 100
            .Columns(4).Name = "Bank Name"
            .Columns(4).Width = 150
            .Columns(5).Name = "Mode"
            .Columns(5).Width = 100
            .Columns(6).Name = "Amount"
            .Columns(6).Width = 100
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
        '    .Cols = 7
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "BankVoucherNo")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "BankVoucherDate")
        '    .set_ColWidth(2, 1500)
        '    .set_TextMatrix(0, 3, "AccountNo")
        '    .set_ColWidth(3, 1500)
        '    .set_TextMatrix(0, 4, "Bank Name")
        '    .set_ColWidth(4, 1500)
        '    .set_TextMatrix(0, 5, "Mode")
        '    .set_ColWidth(5, 1500)
        '    .set_TextMatrix(0, 6, "Amount")
        '    .set_ColWidth(6, 1500)

        'End With

        'Strquery = "SELECT BankVoucher.BankVoucherId, BankVoucher.BankVoucherNo, BankVoucher.BankVoucherDate, BankMaster.AccNo,  BankMaster.BankName,BankVoucher.CashDepositAmount, BankVoucher.Mode, BankVoucher.CashWithdrawlAmount, BankVoucher.AmountTransfer FROM BankVoucher INNER JOIN BankMaster ON BankVoucher.BankCode = BankMaster.AccCode ORDER BY BankVoucher.BankVoucherNo"



        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'ds = New DataSet
        'da.Fill(ds, "FillGrid")


        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("BankVoucherNo")), "", ds.Tables("FillGrid").Rows(i).Item("BankVoucherNo")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("BankVoucherDate"))), "", convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("BankVoucherDate"))))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AccNo")), "", ds.Tables("FillGrid").Rows(i).Item("AccNo")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("BankName")), "", ds.Tables("FillGrid").Rows(i).Item("BankName")))
        '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Mode")), "", ds.Tables("FillGrid").Rows(i).Item("Mode")))
        '            If .get_TextMatrix(i + 1, 5) = "CashDeposit" Then
        '                .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CashDepositAmount")), 0, ds.Tables("FillGrid").Rows(i).Item("CashDepositAmount")))
        '            ElseIf .get_TextMatrix(i + 1, 5) = "CashWithdrawl" Then
        '                .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CashWithdrawlAmount")), 0, ds.Tables("FillGrid").Rows(i).Item("CashWithdrawlAmount")))
        '            ElseIf .get_TextMatrix(i + 1, 5) = "BankTransfer" Then
        '                .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("AmountTransfer")), 0, ds.Tables("FillGrid").Rows(i).Item("AmountTransfer")))
        '            End If
        '        Next
        '    End If


        'End With



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
            If txtBankName.Text = "" Then
                MsgBox("Please Select Bank Name")
                Exit Sub
            End If

            If Mode = "CashDeposit" Or Mode = "CashWithdrawl" Then
                If Val(txtCashAmount.Text) = 0 Then
                    MsgBox("Please Enter Cash Amount")
                    Exit Sub
                End If

            End If



            If Mode = "BankTransfer" Then
                If (cboAccNo1.Text) = "" Then
                    MsgBox("Please Enter Bank Acc No")
                    cboAccNo1.Focus()
                    Exit Sub
                End If
                If (cboDR.Text) = "" Then
                    MsgBox("Please Enter DB/CR")
                    cboDR.Focus()
                    Exit Sub
                End If

                If Val(txtAmounttransfer.Text) = 0 Then
                    MsgBox("Please Enter Transfer Amount")
                    txtAmounttransfer.Focus()
                    Exit Sub
                End If


            End If


            If bln_AddOn = True Then


                If MsgQuestion("SAVE") = 6 Then


                    If Mode = "CashDeposit" Then
                        str1 = "Insert into BankVoucher(BankVoucherNo,BankVoucherDate,BankCode,PrevBalance, Remarks,Mode,CashDepositAmount) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & BankCode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "'," & Val(txtCashAmount.Text) & ")"
                    ElseIf Mode = "CashWithdrawl" Then
                        str1 = "Insert into BankVoucher(BankVoucherNo,BankVoucherDate,BankCode,PrevBalance, Remarks,Mode,CashWithdrawlAmount) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & BankCode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "'," & Val(txtCashAmount.Text) & ")"
                    ElseIf Mode = "BankTransfer" Then
                        str1 = "Insert into BankVoucher(BankVoucherNo,BankVoucherDate,BankCode,PrevBalance, Remarks,Mode,BankCode1, AmountTransfer,BankBalance,DBCR) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & BankCode & "'," & Val(txtBalance.Text) & ", '" & Replace(txtRemarks.Text, "'", "''") & "','" & Mode & "','" & Replace(txtBankCode1.Text, "'", "''") & "',  " & Val(txtAmounttransfer.Text) & "," & Val(txtBankBalance1.Text) & ",'" & cboDR.Text & "')"
                    End If


                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()
                    ''**********************************************************************************************
                    str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='BankVoucher'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtBankVoucherNo.Text))
                    bln_AddOn = False
                    bln_EditOn = False
                    Call cmdApprove_Click(sender, e)
                End If
            ElseIf bln_EditOn = True Then
                If MsgQuestion("UPDATE") = 6 Then

                    If Mode = "CashDeposit" Then
                        str1 = "update BankVoucher set BankVoucherDate='" & convertToServerDateFormat(dtpDate.Value) & "',BankCode='" & BankCode & "',PrevBalance=" & Val(txtBalance.Text) & ", Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',CashDepositAmount=" & Val(txtCashAmount.Text) & " where BankVoucherNo='" & txtBankVoucherNo.Text & "'"
                    ElseIf Mode = "CashWithdrawl" Then
                        str1 = "update BankVoucher set BankVoucherDate='" & convertToServerDateFormat(dtpDate.Value) & "',BankCode='" & BankCode & "', PrevBalance=" & Val(txtBalance.Text) & ",Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',CashWithdrawlAmount=" & Val(txtCashAmount.Text) & "  where BankVoucherNo='" & txtBankVoucherNo.Text & "'"
                    ElseIf Mode = "BankTransfer" Then
                        str1 = "update BankVoucher set BankVoucherDate='" & convertToServerDateFormat(dtpDate.Value) & "',BankCode='" & BankCode & "',PrevBalance=" & Val(txtBalance.Text) & ", Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',Mode='" & Mode & "',AmountTransfer=" & Val(txtAmounttransfer.Text) & ",BankCode1='" & txtBankCode1.Text & "',BankBalance='" & Val(txtBankBalance1.Text) & "',DBCR='" & cboDR.Text & "'  where BankVoucherNo='" & txtBankVoucherNo.Text & "'"
                    End If

                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtBankVoucherNo.Text))
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

                str1 = "SELECT BankVoucher.Approve,BankVoucher.DBCR,BankVoucher.BankVoucherId, BankVoucher.BankVoucherNo, BankVoucher.BankVoucherDate, BankVoucher.BankCode, BankMaster.AccNo, BankMaster.BankName, BankMaster.Branch, BankVoucher.PrevBalance, BankVoucher.Remarks, BankVoucher.Mode, BankVoucher.CashWithdrawlAmount, BankVoucher.CashDepositAmount, BankVoucher.BankCode1, BankMaster_1.AccNo As AccNo1, BankMaster_1.BankName As BankName1, BankMaster_1.Branch As Branch1, BankVoucher.AmountTransfer, BankVoucher.BankBalance, BankVoucher.Approve FROM (BankVoucher LEFT JOIN BankMaster ON BankVoucher.BankCode = BankMaster.AccCode) LEFT JOIN BankMaster AS BankMaster_1 ON BankVoucher.BankCode1 = BankMaster_1.AccCode WHERE (((BankVoucher.BankVoucherId)=(SELECT     MAX(BankVoucherId)FROM          BankVoucher)))  "
            Else
                str1 = "SELECT BankVoucher.Approve,BankVoucher.DBCR,BankVoucher.BankVoucherId, BankVoucher.BankVoucherNo, BankVoucher.BankVoucherDate, BankVoucher.BankCode, BankMaster.AccNo, BankMaster.BankName, BankMaster.Branch, BankVoucher.PrevBalance, BankVoucher.Remarks, BankVoucher.Mode, BankVoucher.CashWithdrawlAmount, BankVoucher.CashDepositAmount, BankVoucher.BankCode1, BankMaster_1.AccNo As AccNo1, BankMaster_1.BankName As BankName1, BankMaster_1.Branch As Branch1, BankVoucher.AmountTransfer, BankVoucher.BankBalance, BankVoucher.Approve FROM (BankVoucher LEFT JOIN BankMaster ON BankVoucher.BankCode = BankMaster.AccCode) LEFT JOIN BankMaster AS BankMaster_1 ON BankVoucher.BankCode1 = BankMaster_1.AccCode WHERE      (BankVoucher.BankVoucherNo='" & strMRqNo & "') "
            End If





            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "MR")

            If dsDS1.Tables("MR").Rows.Count > 0 Then
                lblPrimaryKey.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankVoucherId")), "", dsDS1.Tables("MR").Rows(0).Item("BankVoucherId"))
                Approve = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Approve")), 0, dsDS1.Tables("MR").Rows(0).Item("Approve"))
                If Approve = 1 Then
                    cmdApprove.Text = "Approved"
                    cmdEdit.Enabled = False
                Else
                    cmdApprove.Text = "Approve"
                    cmdEdit.Enabled = True
                End If
                txtBankVoucherNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankVoucherNo")), "", dsDS1.Tables("MR").Rows(0).Item("BankVoucherNo"))
                dtpDate.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("BankVoucherDate"))), "01/01/1990", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("BankVoucherDate")))
                txtdate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("BankVoucherDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("BankVoucherDate")))
                BankCode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankCode")), "", dsDS1.Tables("MR").Rows(0).Item("BankCode"))
                txtBankName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankName")), "", dsDS1.Tables("MR").Rows(0).Item("BankName"))

                txtBalance.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PrevBalance")), "", dsDS1.Tables("MR").Rows(0).Item("PrevBalance"))
                txtBranch.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Branch")), "", dsDS1.Tables("MR").Rows(0).Item("Branch"))

                txtRemarks.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Remarks")), "", dsDS1.Tables("MR").Rows(0).Item("Remarks"))
                Mode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Mode")), "", dsDS1.Tables("MR").Rows(0).Item("Mode"))
                If Mode = "CashDeposit" Then
                    txtCashAmount.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CashDepositAmount")), "", dsDS1.Tables("MR").Rows(0).Item("CashDepositAmount"))
                    gbBankTransfer.Visible = False
                    gbCash.Visible = True

                    optCashDeposit.Checked = True
                ElseIf Mode = "CashWithdrawl" Then
                    txtCashAmount.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CashWithdrawlAmount")), "", dsDS1.Tables("MR").Rows(0).Item("CashWithdrawlAmount"))
                    gbBankTransfer.Visible = False
                    gbCash.Visible = True

                    optCashWithdrawl.Checked = True

                ElseIf Mode = "BankTransfer" Then
                    gbBankTransfer.Visible = True
                    gbCash.Visible = False

                    optBankTransfer.Checked = True
                    txtBankCode1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankCode1")), "", dsDS1.Tables("MR").Rows(0).Item("BankCode1"))
                    cboAccNo1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo1")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo1"))
                    txtAccNo1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AccNo1")), "", dsDS1.Tables("MR").Rows(0).Item("AccNo1"))
                    txtBankName1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankName1")), "", dsDS1.Tables("MR").Rows(0).Item("BankName1"))
                    txtBranch1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Branch1")), "", dsDS1.Tables("MR").Rows(0).Item("Branch1"))
                    txtAmounttransfer.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("AmountTransfer")), 0, dsDS1.Tables("MR").Rows(0).Item("AmountTransfer"))
                    txtBankBalance1.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BankBalance")), 0, dsDS1.Tables("MR").Rows(0).Item("BankBalance"))

                    cboDR.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("DBCR")), "", dsDS1.Tables("MR").Rows(0).Item("DBCR"))
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
                strMinMaxKey = "select max(BankVoucherId) AS MaxId,MIN(BankVoucherId) As MinId from BankVoucher"
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

                        strNextRecord = "select BankVoucherNo  from BankVoucher where BankVoucherId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PaymentNavigation")

                        txtBankVoucherNo.Text = dsMinMaxKey.Tables("PaymentNavigation").Rows(0).Item("BankVoucherNo")
                        Call Display(txtBankVoucherNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Payment").Rows(0).Item("minId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Payment").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select BankVoucherNo from BankVoucher where BankVoucherId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PaymentNavigation")

                            If dsMinMaxKey.Tables("PaymentNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Payment").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtBankVoucherNo.Text = dsMinMaxKey.Tables("PaymentNavigation").Rows(0).Item("BankVoucherNo")
                        Call Display(txtBankVoucherNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Payment").Rows(0).Item("maxId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Payment").Rows(0).Item("maxId")
                            strNextRecord = "select BankVoucherNo from BankVoucher where BankVoucherId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PaymentNavigation")

                            If dsMinMaxKey.Tables("PaymentNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Payment").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtBankVoucherNo.Text = dsMinMaxKey.Tables("PaymentNavigation").Rows(0).Item("BankVoucherNo")
                        Call Display(txtBankVoucherNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Payment").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select BankVoucherNo from BankVoucher where BankVoucherId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PaymentNavigation")

                        txtBankVoucherNo.Text = dsMinMaxKey.Tables("PaymentNavigation").Rows(0).Item("BankVoucherNo")
                        Call Display(txtBankVoucherNo.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboDR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDR.SelectedIndexChanged
        If cboDR.Text = "DR" Then
            Label6.Text = "An amount of Rs." & Val(txtAmounttransfer.Text) & "   is Deposited in  " & txtBankName1.Text & "  "
        ElseIf cboDR.Text = "CR" Then
            Label6.Text = "An amount of Rs." & Val(txtAmounttransfer.Text) & "    is Withdrawl from  " & txtBankName1.Text & "  "
        End If
    End Sub

    Private Sub cmdApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim str2 As String
        Dim trn As SqlClient.SqlTransaction
        Dim NetAmount As Decimal
        Dim accno As String


        Try
            If txtBankName.Text = "" Then
                MsgBox("Please Select Bank Name")
                Exit Sub
            End If

            If Mode = "CashDeposit" Or Mode = "CashWithdrawl" Then
                If Val(txtCashAmount.Text) = 0 Then
                    MsgBox("Please Enter Cash Amount")
                    Exit Sub
                End If

            End If



            If Mode = "BankTransfer" Then
                If Val(txtAmounttransfer.Text) = 0 Then
                    MsgBox("Please Enter Transfer Amount")
                    Exit Sub
                End If


            End If


            If cmdApprove.Text = "Approve" Then
                If MsgQuestion("APPROVE") = 6 Then


                    ''*******************************************PARTY AND BANK BALANCE UPDATE************************* 
                    NetAmount = 0
                    If Mode = "CashDeposit" Or Mode = "CashWithdrawl" Then
                        NetAmount = Val(txtCashAmount.Text)

                    ElseIf Mode = "BankTransfer" Then
                        NetAmount = Val(txtAmounttransfer.Text)
                        accno = cboAccNo1.Text
                    End If



                    If Mode = "CashDeposit" Then
                        str1 = "update BankMaster set CurrentBalance=CurrentBalance+" & NetAmount & " where AccCode='" & BankCode & "'"
                        str2 = "update CompanyMaster1 set CurrentBalance=CurrentBalance-" & NetAmount & " "
                    ElseIf Mode = "CashWithdrawl" Then
                        str1 = "update BankMaster set CurrentBalance=CurrentBalance-" & NetAmount & " where AccCode='" & BankCode & "'"
                        str2 = "update CompanyMaster1 set CurrentBalance=CurrentBalance+" & NetAmount & " "
                    ElseIf Mode = "BankTransfer" Then
                        If cboDR.Text = "CR" Then
                            str1 = "update BankMaster set CurrentBalance=CurrentBalance+" & NetAmount & " where AccCode='" & BankCode & "'"
                            str2 = "update BankMaster set CurrentBalance=CurrentBalance-" & NetAmount & " where AccCode='" & txtBankCode1.Text & "'"
                        ElseIf cboDR.Text = "DB" Then
                            str1 = "update BankMaster set CurrentBalance=CurrentBalance-" & NetAmount & " where AccCode='" & BankCode & "'"
                            str2 = "update BankMaster set CurrentBalance=CurrentBalance+" & NetAmount & " where AccCode='" & txtBankCode1.Text & "'"
                        End If

                    End If
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str2
                    cmdCom1.ExecuteNonQuery()
                    ''********************************************LEDGER UPDATE***************************************

                    If Mode = "CashDeposit" Then

                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','Company', '" & Mode & "',0," & Val(txtCashAmount.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"
                        str2 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & BankCode & "', '" & Mode & "'," & Val(txtCashAmount.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"
                    ElseIf Mode = "CashWithdrawl" Then
                        str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','Company', '" & Mode & "'," & Val(txtCashAmount.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"
                        str2 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & BankCode & "', '" & Mode & "',0," & Val(txtCashAmount.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"
                    ElseIf Mode = "BankTransfer" Then
                        If cboDR.Text = "DB" Then
                            str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & BankCode & "', '" & Mode & "',0," & Val(txtAmounttransfer.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"
                            str2 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & Replace(txtBankCode1.Text, "'", "''") & "', '" & Mode & "'," & Val(txtAmounttransfer.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"
                        ElseIf cboDR.Text = "CR" Then
                            str1 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & BankCode & "', '" & Mode & "'," & Val(txtAmounttransfer.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"
                            str2 = "Insert into Ledger(TransactionNo,TransactionDate,LedgerCode, TransactionType,Debit,Credit,Narration) values('" & txtBankVoucherNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & Replace(txtBankCode1.Text, "'", "''") & "', '" & Mode & "',0," & Val(txtAmounttransfer.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"
                        End If


                    End If


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str2
                    cmdCom1.ExecuteNonQuery()

                    str1 = "update BankVoucher set Approve=1 where BankVoucherNo='" & txtBankVoucherNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtBankVoucherNo.Text))
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


                    str1 = "Delete From Ledger where transactionno='" & txtBankVoucherNo.Text & "'"

                    trn = gl_Con.BeginTransaction
                    cmdCom1 = New SqlClient.SqlCommand(str1, gl_Con)
                    cmdCom1.CommandType = CommandType.Text
                    cmdCom1.Transaction = trn
                    cmdCom1.ExecuteNonQuery()




                    NetAmount = 0
                    If Mode = "CashDeposit" Or Mode = "CashWithdrawl" Then
                        NetAmount = Val(txtCashAmount.Text)

                    ElseIf Mode = "BankTransfer" Then
                        NetAmount = Val(txtAmounttransfer.Text)
                        accno = cboAccNo1.Text
                    End If



                    If Mode = "CashDeposit" Then
                        str1 = "update BankMaster set CurrentBalance=CurrentBalance-" & NetAmount & " where AccCode='" & BankCode & "'"
                        str2 = "update CompanyMaster1 set CurrentBalance=CurrentBalance+" & NetAmount & " "
                    ElseIf Mode = "CashWithdrawl" Then
                        str1 = "update BankMaster set CurrentBalance=CurrentBalance+" & NetAmount & " where AccCode='" & BankCode & "'"
                        str2 = "update CompanyMaster1 set CurrentBalance=CurrentBalance-" & NetAmount & " "
                    ElseIf Mode = "BankTransfer" Then
                        If cboDR.Text = "DB" Then
                            str1 = "update BankMaster set CurrentBalance=CurrentBalance+" & NetAmount & " where AccCode='" & BankCode & "'"
                            str2 = "update BankMaster set CurrentBalance=CurrentBalance-" & NetAmount & " where AccCode='" & txtBankCode1.Text & "'"
                        ElseIf cboDR.Text = "CR" Then
                            str1 = "update BankMaster set CurrentBalance=CurrentBalance-" & NetAmount & " where AccCode='" & BankCode & "'"
                            str2 = "update BankMaster set CurrentBalance=CurrentBalance+" & NetAmount & " where AccCode='" & txtBankCode1.Text & "'"
                        End If
                    End If
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str2
                    cmdCom1.ExecuteNonQuery()
                    ''********************************************LEDGER UPDATE***************************************

                    str1 = "update BankVoucher set Approve=0 where BankVoucherNo='" & txtBankVoucherNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtBankVoucherNo.Text))
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
        Catch Exp As Exception
            trn.Rollback()
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
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
                        txtBankVoucherNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtBankVoucherNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtBankVoucherNo.Text)
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

                        txtBankName.Text = ""
                        txtBankName.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        BankCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtBranch.Text = dgSearch(4, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtBalance.Text = dgSearch(5, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                    Else
                        txtBankName.Text = ""
                        txtBankName.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        BankCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtBranch.Text = dgSearch(4, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtBalance.Text = dgSearch(5, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
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
                dv = New DataView(ds.Tables(0), "BankVoucherNo Like '" & Trim(txtSearch.Text) & "*" & "'", "BankVoucherNo", DataViewRowState.CurrentRows)
                dTable = dv.ToTable
                dgSearch.RowCount = 1
                If dTable.Rows.Count > 0 Then
                    With dgSearch
                        For i = 0 To dTable.Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = i + 1

                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("BankVoucherNo")), "", dTable.Rows(i).Item("BankVoucherNo"))

                            .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("BankVoucherDate")), "", dTable.Rows(i).Item("BankVoucherDate"))

                            .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("AccNo")), "", dTable.Rows(i).Item("AccNo"))
                            .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("BankName")), "", dTable.Rows(i).Item("BankName"))

                            .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("Mode")), "", dTable.Rows(i).Item("Mode"))
                            If .Rows(i).Cells(5).Value = "CashDeposit" Then

                                .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("CashDepositAmount")), "", dTable.Rows(i).Item("CashDepositAmount"))
                            ElseIf .Rows(i).Cells(5).Value = "CashWithdrawl" Then

                                .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("CashWithdrawlAmount")), "", dTable.Rows(i).Item("CashWithdrawlAmount"))
                            ElseIf .Rows(i).Cells(5).Value = "BankTransfer" Then
                                .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("AmountTransfer")), "", dTable.Rows(i).Item("AmountTransfer"))
                            End If

                        Next
                        .RowCount = .RowCount - 1
                    End With
                Else
                    dgSearch.RowCount = 0
                End If
            ElseIf Search = 1 Then
                dv = New DataView(ds1.Tables(0), "BankName Like '" & Trim(txtSearch.Text) & "*" & "'", "AccCode", DataViewRowState.CurrentRows)
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

                            .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("CurrentBalance")), "", dTable.Rows(i).Item("CurrentBalance"))

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