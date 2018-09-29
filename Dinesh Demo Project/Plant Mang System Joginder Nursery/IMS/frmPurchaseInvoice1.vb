Imports System.Data
Imports System.Data.SqlClient
Public Class frmPurchaseInvoice1
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim suppliercode As String
    Dim SearchSupplier As Integer
    Dim Approve As Integer
    Dim Cash As Integer

    Dim intDGSearchKeayPress As Integer
    Dim search As Integer
    Dim da1 As New SqlClient.SqlDataAdapter  'Global Data adapter for Search in dgSearch
    Dim ds1 As New DataSet
    Dim da2 As New SqlClient.SqlDataAdapter   'Global Data adapter for Search  dgSearchItem
    Dim ds2 As New DataSet

    Private Sub frmPurchaseInvoice1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        PurchaseInvoice1 = Nothing
    End Sub

    Private Sub frmPurchaseInvoice1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmPurchaseInvoice1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DesignGridSelectItem()
        DesignGrid()
        ClearControl()
        ENABLECONTROL(True)
        Display()

    End Sub
    Private Sub DesignGrid()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 14
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 150
            .Columns(3).Name = "Category"
            .Columns(3).Width = 90
            .Columns(4).Name = "Qty"
            .Columns(4).Width = 60
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 60

            .Columns(6).Name = "S.Qty"
            .Columns(6).Width = 80
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).Visible = False

            .Columns(7).Name = "S.Unit"
            .Columns(7).Width = 80
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).Visible = False

            .Columns(8).Name = "Rate"
            .Columns(8).Width = 90
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(9).Name = "Rate/Unit"
            .Columns(9).Width = 80
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).Visible = False

            .Columns(10).Name = "Amount"
            .Columns(10).Width = 90
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).Name = "Stock"
            .Columns(11).Width = 80
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(12).Name = "S.Stock"
            .Columns(12).Width = 80
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(12).Visible = False

            .Columns(13).Name = "ConvFact"
            .Columns(13).Width = 80
            .Columns(13).Visible = False

            .RowTemplate.Height = 17
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.CellSelect
        End With



        
        With dgConfiguration
            .RowCount = 1
            .ColumnCount = 9
            .Columns(0).Name = "Description"
            .Columns(0).Width = 100
            .Columns(1).Name = "Code"
            .Columns(1).Width = 60
            .Columns(2).Name = "+/-"
            .Columns(2).Width = 60
            .Columns(3).Name = "%age"
            .Columns(3).Width = 60
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).Name = "Amount"
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).Name = "TotalAmount"
            .Columns(5).Width = 100
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).Name = "CalculatedOn"
            .Columns(6).Width = 120
            .Columns(7).Name = "Remarks"
            .Columns(7).Width = 100
            .Columns(8).Name = "S#"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).Width = 60

            .RowTemplate.Height = 17
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.CellSelect
        End With

        With dgConfigSearch
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Name = "Description"
            .Columns(0).Width = 60
            .Columns(1).Name = "Code"
            .Columns(1).Width = 60
            .Columns(2).Name = "+/-"
            .Columns(2).Width = 40
            .Columns(3).Name = "%age"
            .Columns(3).Width = 60
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).Name = "Calculation"
            .Columns(4).Width = 100
            .Columns(5).Name = "CalcOnCode"
            .Columns(5).Width = 100
            .Columns(6).Name = "S#"
            .Columns(6).Width = 90
            .Columns(7).Name = "Serial"
            .Columns(7).Width = 60
            .Columns(8).Name = "Lvl"
            .Columns(8).Width = 60
            .Columns(9).Name = "ConfigCode"
            .Columns(9).Width = 90
            .Columns(9).Visible = False

            .RowTemplate.Height = 17
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.CellSelect
        End With

    End Sub
    Private Sub DesignGridSelectItem()
        Dim chkBox1 As New DataGridViewCheckBoxColumn()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 9
            .Columns.Insert(0, chkBox1)
            .Columns(0).Width = 60
            chkBox1.Name = "Select"

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

        End With

        Dim chkBox2 As New DataGridViewCheckBoxColumn()
        With dgSelectedItem
            .RowCount = 1
            .ColumnCount = 9
            .Columns.Insert(0, chkBox2)
            .Columns(0).Width = 60
            chkBox2.Name = "Select"

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
    Private Sub ENABLECONTROL(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status
        cmdSearch.Enabled = status
        cmdSearchSupplier.Enabled = Not status
        cmdAddItem.Enabled = Not status
        cmdDelItem.Enabled = Not status
        cmdOverhead.Enabled = Not status
        chkcash.Enabled = Not status

        txtInvoiceNo.ReadOnly = status
        txtPurchaseNo.ReadOnly = True
        txtRemarks.ReadOnly = status
        txtSupplierNAme.ReadOnly = True
        txtChallanNo.ReadOnly = status
        txtGRNo.ReadOnly = status
        txtNetValue.ReadOnly = True
        txttotalvalue.ReadOnly = True
        txtConfigCode.ReadOnly = True
        txtPurchaseDate.ReadOnly = True
        txtAddress.ReadOnly = True

        If cmdSave.Enabled = True Then
            dtpDate.BringToFront()
            txtPurchaseDate.SendToBack()
            cmdApprove.Enabled = False
        Else
            dtpDate.SendToBack()
            txtPurchaseDate.BringToFront()
            cmdApprove.Enabled = True
        End If

        If gl_EmpName = "administrator" Then
            cmdApprove.Visible = True
        Else
            cmdApprove.Visible = False
        End If

    End Sub
    Private Sub ClearControl()
        txtInvoiceNo.Text = ""
        txtChallanNo.Text = ""
        txtRemarks.Text = ""
        txtConfigCode.Text = ""
        txtConfigurationRemarks.Text = ""
        txtNetValue.Text = ""
        txtAddress.Text = ""
        txttotalvalue.Text = ""
        txtSupplierNAme.Text = ""
        dgDetail.RowCount = 0
        dgConfiguration.RowCount = 0
        txtGRNo.Text = ""
        txtAddress.Text = ""
        cmdApprove.Text = "Approve"

    End Sub
    Private Sub Designgrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 7
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "PI.No"
            .Columns(1).Width = 80
            .Columns(2).Name = "PI.Date"
            .Columns(2).Width = 90
            .Columns(3).Name = "Supplier Name"
            .Columns(3).Width = 250
            .Columns(4).Name = "InvoiceNo"
            .Columns(4).Width = 80
            .Columns(5).Name = "ChallanNo"
            .Columns(5).Width = 100
            .Columns(6).Name = "TotalValue"
            .Columns(6).Width = 200
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
        da1.Dispose()
        ds1.Clear()
        search = 0

        Try

            StrQuery = "SELECT PurchaseMaster.PurchaseNo, PurchaseMaster.PurchaseDate, SupplierMaster1.SupplierName, PurchaseMaster.InvoiceNo, PurchaseMaster.ChallanNo, PurchaseMaster.Totalvalue  FROM PurchaseMaster INNER JOIN SupplierMaster1 ON PurchaseMaster.SupplierCode = SupplierMaster1.SupplierCode order by PurchaseNo"
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "PurchaseMaster")
            dgSearch.RowCount = 1
            If ds1.Tables("PurchaseMaster").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("PurchaseMaster").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("PurchaseMaster").Rows(i).Item("PurchaseNo")), "", ds1.Tables("PurchaseMaster").Rows(i).Item("PurchaseNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds1.Tables("PurchaseMaster").Rows(i).Item("PurchaseDate"))), "", convertToServerDateFormat(ds1.Tables("PurchaseMaster").Rows(i).Item("PurchaseDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("PurchaseMaster").Rows(i).Item("SupplierName")), "", ds1.Tables("PurchaseMaster").Rows(i).Item("SupplierName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds1.Tables("PurchaseMaster").Rows(i).Item("InvoiceNo")), "", ds1.Tables("PurchaseMaster").Rows(i).Item("InvoiceNo"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds1.Tables("PurchaseMaster").Rows(i).Item("ChallanNo")), "", ds1.Tables("PurchaseMaster").Rows(i).Item("ChallanNo"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds1.Tables("PurchaseMaster").Rows(i).Item("Totalvalue")), "", ds1.Tables("PurchaseMaster").Rows(i).Item("Totalvalue"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearch.Text = ""
            txtSearch.Focus()
            cboSearch.Text = ""
            lblRow.Text = "SI No"
            gbSearch.BringToFront()
            gbMain.SendToBack()
            gbSearchInvoice.BringToFront()
            gbSearchCustomer.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Private Sub Designgrid2()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 7
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Code"
            .Columns(1).Width = 90
            .Columns(2).Name = "Supplier Name"
            .Columns(2).Width = 250
            .Columns(3).Name = "Address"
            .Columns(3).Width = 320
            .Columns(4).Name = "City"
            .Columns(4).Width = 100
            .Columns(5).Name = "State"
            .Columns(5).Width = 100
            .Columns(6).Name = "PIN"
            .Columns(6).Width = 90
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

    Private Sub cmdSearchSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearchSupplier.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid2()
        da1.Dispose()
        ds1.Clear()
        search = 1

        Try

            StrQuery = "SELECT SupplierMaster1.SupplierCode, SupplierMaster1.SupplierName, SupplierMaster1.Address, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM ((SupplierMaster1 INNER JOIN LocalityMaster ON SupplierMaster1.LocalityCode = LocalityMaster.LocalityCode) INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode ORDER BY SupplierMaster1.SupplierName"
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "SupplierMaster")
            dgSearch.RowCount = 1
            If ds1.Tables("SupplierMaster").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("SupplierMaster").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("SupplierMaster").Rows(i).Item("SupplierCode")), "", ds1.Tables("SupplierMaster").Rows(i).Item("SupplierCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds1.Tables("SupplierMaster").Rows(i).Item("Suppliername")), "", ds1.Tables("SupplierMaster").Rows(i).Item("Suppliername"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("SupplierMaster").Rows(i).Item("Address")), "", ds1.Tables("SupplierMaster").Rows(i).Item("Address"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds1.Tables("SupplierMaster").Rows(i).Item("CityName")), "", ds1.Tables("SupplierMaster").Rows(i).Item("CityName"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds1.Tables("SupplierMaster").Rows(i).Item("StateName")), "", ds1.Tables("SupplierMaster").Rows(i).Item("StateName"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds1.Tables("SupplierMaster").Rows(i).Item("PINCode")), "", ds1.Tables("SupplierMaster").Rows(i).Item("PINCode"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearchCustomer.Text = ""
            txtSearchCustomer.Focus()
            cboSearchCustomer.Text = ""
            lblRowSearch.Text = "Supplier Name"
            gbSearch.BringToFront()
            gbMain.SendToBack()
            gbSearchInvoice.SendToBack()
            gbSearchCustomer.BringToFront()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearch.SelectedIndexChanged
        lblRow.Text = cboSearch.Text
        txtSearch.Text = ""
        txtSearch.Focus()
    End Sub

    Private Sub cboSearchCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchCustomer.SelectedIndexChanged
        lblRowSearch.Text = cboSearchCustomer.Text
        txtSearchCustomer.Text = ""
        txtSearchCustomer.Focus()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub txtSearchCustomer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchCustomer.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try
            If cboSearch.SelectedIndex = 0 Then
                dv = New DataView(ds1.Tables("PurchaseMaster"), "PurchaseNo Like '" & Trim(txtSearch.Text) & "*" & "'", "PurchaseNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 1 Then
                dv = New DataView(ds1.Tables("PurchaseMaster"), True, "PurchaseDate", DataViewRowState.CurrentRows)

            ElseIf cboSearch.SelectedIndex = 2 Then
                dv = New DataView(ds1.Tables("PurchaseMaster"), "SupplierName Like '" & Trim(txtSearch.Text) & "*" & "'", "PurchaseNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 3 Then
                dv = New DataView(ds1.Tables("PurchaseMaster"), "InvoiceNo Like '" & Trim(txtSearch.Text) & "*" & "'", "PurchaseNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 4 Then
                dv = New DataView(ds1.Tables("PurchaseMaster"), "ChallanNo Like '" & Trim(txtSearch.Text) & "*" & "'", "PurchaseNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 5 Then
                dv = New DataView(ds1.Tables("PurchaseMaster"), "Totalvalue >= '" & Val(txtSearch.Text) & "'", "PurchaseNo", DataViewRowState.CurrentRows)
            Else
                dv = New DataView(ds1.Tables("PurchaseMaster"), "PurchaseNo Like '" & Trim(txtSearch.Text) & "*" & "'", "PurchaseNo", DataViewRowState.CurrentRows)
            End If
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("PurchaseNo")), "", dTable.Rows(i).Item("PurchaseNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(dTable.Rows(i).Item("PurchaseDate"))), "", convertToServerDateFormat(dTable.Rows(i).Item("PurchaseDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("SupplierName")), "", dTable.Rows(i).Item("SupplierName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("InvoiceNo")), "", dTable.Rows(i).Item("InvoiceNo"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("ChallanNo")), "", dTable.Rows(i).Item("ChallanNo"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("Totalvalue")), "", dTable.Rows(i).Item("Totalvalue"))

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

    Private Sub txtSearchCustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchCustomer.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try
            If cboSearchCustomer.SelectedIndex = 0 Then
                dv = New DataView(ds1.Tables("SupplierMaster"), "SupplierCode Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "SupplierCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 1 Then
                dv = New DataView(ds1.Tables("SupplierMaster"), "SupplierName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "SupplierCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 2 Then
                dv = New DataView(ds1.Tables("SupplierMaster"), "Address Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "SupplierCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 3 Then
                dv = New DataView(ds1.Tables("SupplierMaster"), "CityName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "SupplierCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 4 Then
                dv = New DataView(ds1.Tables("SupplierMaster"), "StateName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "SupplierCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 5 Then
                dv = New DataView(ds1.Tables("SupplierMaster"), "PINCode Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "SupplierCode", DataViewRowState.CurrentRows)
            Else
                dv = New DataView(ds1.Tables("SupplierMaster"), "Suppliername Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "SupplierCode", DataViewRowState.CurrentRows)
            End If
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
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("CityName")), "", dTable.Rows(i).Item("CityName"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("StateName")), "", dTable.Rows(i).Item("StateName"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("PINCode")), "", dTable.Rows(i).Item("PINCode"))
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
            If search = 0 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                        txtPurchaseNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtPurchaseNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtPurchaseNo.Text)
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                End If
            ElseIf search = 1 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                        suppliercode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtSupplierName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSearch(4, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSearch(5, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & "  " & dgSearch(6, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString


                    Else
                        suppliercode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtSupplierName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSearch(4, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSearch(5, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & "  " & dgSearch(6, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If

                    intDGSearchKeayPress = 0
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    txtRemarks.Focus()
                End If
            End If
        End With
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ENABLECONTROL(False)
        bln_AddOn = True
        bln_EditOn = False
        txtPurchaseNo.Text = showCode("Purchase")
        ClearControl()
        dtpDate.Value = Now
        chkcash.Checked = False
        FillOverHeadDetails("None")
        'Cal()
        dtpDate.Focus()
    End Sub
    Private Sub FillOverHeadDetails(ByVal strOverHeadCode As String)
        Dim strQuery As String
        Dim daConfigD As SqlClient.SqlDataAdapter
        Dim dsConfigD As New DataSet
        Dim i As Integer
        Try
            dsConfigD.Clear()
            If dgConfiguration.RowCount = 0 Then
                strQuery = "SELECT ConfigurationCode, Description, PlusMinus, CalculatedOn, CalculatedOnSQ, SNo, Sequence, Lvl, Code, Percentage FROM ConfigurationDetails Where Description='None'"
            Else
                strQuery = "SELECT ConfigurationCode, Description, PlusMinus, CalculatedOn, CalculatedOnSQ, SNo, Sequence, Lvl, Code, Percentage FROM ConfigurationDetails Where ConfigurationCode='" & strOverHeadCode & "' Order By SNo"
            End If

            daConfigD = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            daConfigD.Fill(dsConfigD, "ConfigD")
            dgConfigSearch.RowCount = 1
            If dsConfigD.Tables("ConfigD").Rows.Count > 0 Then
                With dgConfigSearch
                    For i = 0 To dsConfigD.Tables("ConfigD").Rows.Count - 1
                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = dsConfigD.Tables("ConfigD").Rows(i).Item("Description")
                        .Rows(i).Cells(1).Value = dsConfigD.Tables("ConfigD").Rows(i).Item("Code")
                        .Rows(i).Cells(2).Value = dsConfigD.Tables("ConfigD").Rows(i).Item("PlusMinus")
                        .Rows(i).Cells(3).Value = dsConfigD.Tables("ConfigD").Rows(i).Item("Percentage")
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("CalculatedOn")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("CalculatedOn"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("CalculatedOnSQ")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("CalculatedOnSQ"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("SNo")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("SNo"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("Sequence")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("Sequence"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("Lvl")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("Lvl"))
                        .Rows(i).Cells(9).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("ConfigurationCode")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("ConfigurationCode"))
                    Next
                    dgConfigSearch.RowCount = dgConfigSearch.RowCount - 1
                End With
            Else
                dgConfigSearch.RowCount = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        ENABLECONTROL(False)
        bln_EditOn = True
        bln_AddOn = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
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
        Dim sender As New System.Object
        Dim e As New System.EventArgs

        Try



            If txtSupplierNAme.Text = "" Then
                MsgBox("Please Select Supplier Name")
                Exit Sub
            End If

            If dgDetail.RowCount = 0 Then
                MsgBox("Please Select Atleast One Item")
                Exit Sub
            End If

            If dgConfiguration.RowCount = 0 Then
                MsgBox("Please Select Any Tax Code")
                Exit Sub
            End If
            If Trim(txtInvoiceNo.Text) = "" And Trim(txtChallanNo.Text) = "" Then
                MsgBox("Please Enter Invoice No or Challan No")
                txtInvoiceNo.Focus()
                Exit Sub
            End If


            If bln_AddOn = True Then


                If MsgQuestion("SAVE") = 6 Then


                    str1 = "Insert into PurchaseMaster(PurchaseNo,PurchaseDate,InvoiceNo, ChallanNo, SupplierCode,Remarks,NetValue,TotalValue,ConfigurationCode,Cash,SupplierName1,Address1,GRNo) values('" & txtPurchaseNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & txtInvoiceNo.Text & "', '" & txtChallanNo.Text & "','" & suppliercode & "','" & Replace(txtRemarks.Text, "'", "''") & "'," & Val(txtNetValue.Text) & "," & Val(txttotalvalue.Text) & ",'" & Replace(txtConfigCode.Text, "'", "''") & "'," & Cash & ",'" & txtSupplierName.Text & "','" & txtAddress.Text & "','" & txtGRNo.Text & "')"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    With dgDetail
                        For i = 0 To .RowCount - 1
                            str1 = "Insert into PurchaseDetail(PurchaseNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount) values('" & txtPurchaseNo.Text & "','" & (.Rows(i).Cells(1).Value) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & ")"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()

                        Next
                    End With


                    str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='Purchase'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtPurchaseNo.Text))
                    bln_AddOn = False
                    bln_EditOn = False
                    Call cmdApprove_Click(sender, e)
                End If
            ElseIf bln_EditOn = True Then
                If MsgQuestion("UPDATE") = 6 Then




                    str1 = "update PurchaseMaster set PurchaseDate='" & convertToServerDateFormat(dtpDate.Value) & "',InvoiceNo='" & txtInvoiceNo.Text & "', ChallanNo='" & txtChallanNo.Text & "',SupplierCode='" & suppliercode & "', Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',NetValue=" & Val(txtNetValue.Text) & ",TotalValue=" & Val(txttotalvalue.Text) & ",ConfigurationCode='" & (txtConfigCode.Text) & "',Cash=" & Cash & ",SupplierName1='" & txtSupplierName.Text & "',Address1='" & txtAddress.Text & "',GRNo='" & txtGRNo.Text & "' where PurchaseNo='" & txtPurchaseNo.Text & "'"

                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()




                    str1 = "Delete From PurchaseDetail where PurchaseNo='" & txtPurchaseNo.Text & "'"
                    ComSave = New SqlClient.SqlCommand(str1, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()


                    With dgDetail
                        For i = 0 To .RowCount - 1
                            str1 = "Insert into PurchaseDetail(PurchaseNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount) values('" & txtPurchaseNo.Text & "','" & (.Rows(i).Cells(1).Value) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & ")"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()

                        Next
                    End With


                    StrQuery = "Delete from PurchaseOrderOverHeads where PurchaseNo='" & Replace(Trim(txtPurchaseNo.Text), "'", "''") & "'"
                    ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()

                    With dgConfiguration
                        For i = 0 To .RowCount - 1
                            StrQuery = "Insert into PurchaseOrderOverHeads(PurchaseNo, Description, Code, PlusMinus, Percentage, Amount, TotalAmount, CalcOn ,Remarks,SNo ) Values('" & Replace(Trim(txtPurchaseNo.Text), "'", "''") & "','" & (Trim(.Rows(i).Cells(0).Value.ToString)) & "','" & Replace(Trim(.Rows(i).Cells(1).Value.ToString), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(2).Value.ToString), "'", "''") & "'," & Val(.Rows(i).Cells(3).Value) & "," & Val(.Rows(i).Cells(4).Value) & "," & Val(.Rows(i).Cells(5).Value) & ",'" & Replace(Trim(.Rows(i).Cells(6).Value.ToString), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(7).Value.ToString), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(8).Value.ToString), "'", "''") & "')"
                            ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                            ComSave.CommandType = CommandType.Text
                            ComSave.Transaction = trn
                            ComSave.ExecuteNonQuery()
                        Next
                    End With



                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtPurchaseNo.Text))
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
        If gl_EmpName = "administrator" Then
            cmdApprove.Visible = True
        Else
            cmdApprove.Visible = False
        End If

        Try
            ClearControl()
            If strMRqNo = "-1" Then

                str1 = " SELECT PurchaseMaster.Approve, PurchaseMaster.GRNo,PurchaseMaster.Cash, PurchaseMaster.PurchaseId, PurchaseMaster.PurchaseNo, PurchaseMaster.PurchaseDate, PurchaseMaster.InvoiceNo, PurchaseMaster.ChallanNo, SupplierMaster1.SupplierCode, SupplierMaster1.SupplierName, SupplierMaster1.Address, PurchaseMaster.Remarks, PurchaseMaster.NetValue, PurchaseMaster.Totalvalue, PurchaseMaster.ConfigurationCode, PurchaseDetail.ItemCode, PurchaseDetail.Qty, PurchaseDetail.SubQty, PurchaseDetail.Rate, PurchaseDetail.SubRate, PurchaseDetail.Amount, ItemMaster.ItemName, ItemMaster.Category, ItemMaster.Unit, ItemMaster.ConvFAct, ItemMaster.StoreUnit, ItemMaster.CurrentStock, ItemMaster.CurrentSubStock, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode, PurchaseMaster.SupplierName1, PurchaseMaster.Address1 FROM (((((PurchaseMaster INNER JOIN PurchaseDetail ON PurchaseMaster.PurchaseNo = PurchaseDetail.PurchaseNo) LEFT JOIN SupplierMaster1 ON PurchaseMaster.SupplierCode = SupplierMaster1.SupplierCode) INNER JOIN ItemMaster ON PurchaseDetail.ItemCode = ItemMaster.ItemCode) LEFT JOIN LocalityMaster ON SupplierMaster1.LocalityCode = LocalityMaster.LocalityCode) LEFT JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) LEFT JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode WHERE (((PurchaseMaster.PurchaseNo)=(SELECT     MAX(PurchaseNo)FROM          PurchaseMaster)))"
            Else
                str1 = "SELECT PurchaseMaster.Approve, PurchaseMaster.GRNo,PurchaseMaster.Cash, PurchaseMaster.PurchaseId, PurchaseMaster.PurchaseNo, PurchaseMaster.PurchaseDate, PurchaseMaster.InvoiceNo, PurchaseMaster.ChallanNo, SupplierMaster1.SupplierCode, SupplierMaster1.SupplierName, SupplierMaster1.Address, PurchaseMaster.Remarks, PurchaseMaster.NetValue, PurchaseMaster.Totalvalue, PurchaseMaster.ConfigurationCode, PurchaseDetail.ItemCode, PurchaseDetail.Qty, PurchaseDetail.SubQty, PurchaseDetail.Rate, PurchaseDetail.SubRate, PurchaseDetail.Amount, ItemMaster.ItemName, ItemMaster.Category, ItemMaster.Unit, ItemMaster.ConvFAct, ItemMaster.StoreUnit, ItemMaster.CurrentStock, ItemMaster.CurrentSubStock, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode, PurchaseMaster.SupplierName1, PurchaseMaster.Address1 FROM (((((PurchaseMaster INNER JOIN PurchaseDetail ON PurchaseMaster.PurchaseNo = PurchaseDetail.PurchaseNo) LEFT JOIN SupplierMaster1 ON PurchaseMaster.SupplierCode = SupplierMaster1.SupplierCode) INNER JOIN ItemMaster ON PurchaseDetail.ItemCode = ItemMaster.ItemCode) LEFT JOIN LocalityMaster ON SupplierMaster1.LocalityCode = LocalityMaster.LocalityCode) LEFT JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) LEFT JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode  WHERE      (PurchaseMaster.PurchaseNo=    '" & strMRqNo & "') "
            End If





            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "MR")

            If dsDS1.Tables("MR").Rows.Count > 0 Then
                Approve = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Approve")), 0, dsDS1.Tables("MR").Rows(0).Item("Approve"))
                If Approve = 1 Then
                    cmdApprove.Text = "Approved"
                    cmdEdit.Enabled = False
                Else
                    cmdApprove.Text = "Approve"
                    cmdEdit.Enabled = True
                End If
                suppliercode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("SupplierCode")), "", dsDS1.Tables("MR").Rows(0).Item("SupplierCode"))
                Cash = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Cash")), 0, dsDS1.Tables("MR").Rows(0).Item("Cash"))
                lblPrimaryKey.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PurchaseId")), "", dsDS1.Tables("MR").Rows(0).Item("PurchaseId"))
                If Cash = 1 Then
                    chkcash.Checked = True
                    txtSupplierName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("SupplierName1")), "", dsDS1.Tables("MR").Rows(0).Item("SupplierName1"))
                    txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address1")), "", dsDS1.Tables("MR").Rows(0).Item("Address1"))
                Else
                    chkcash.Checked = False
                    txtSupplierName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("SupplierName")), "", dsDS1.Tables("MR").Rows(0).Item("SupplierName"))
                    txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address")), "", dsDS1.Tables("MR").Rows(0).Item("Address")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("LocalityName")), "", dsDS1.Tables("MR").Rows(0).Item("LocalityName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CityName")), "", dsDS1.Tables("MR").Rows(0).Item("CItyName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("StateName")), "", dsDS1.Tables("MR").Rows(0).Item("StateName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PINCode")), "", dsDS1.Tables("MR").Rows(0).Item("PINCode"))
                End If

                txtPurchaseNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PurchaseNo")), "", dsDS1.Tables("MR").Rows(0).Item("PurchaseNo"))
                txtInvoiceNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("InvoiceNo")), "", dsDS1.Tables("MR").Rows(0).Item("InvoiceNo"))
                txtGRNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("GRNo")), "", dsDS1.Tables("MR").Rows(0).Item("GRNo"))
                txtChallanNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ChallanNo")), "", dsDS1.Tables("MR").Rows(0).Item("ChallanNo"))
                dtpDate.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("PurchaseDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("PurchaseDate")))
                txtPurchaseDate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("PurchaseDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("PurchaseDate")))
                txtRemarks.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Remarks")), "", dsDS1.Tables("MR").Rows(0).Item("Remarks"))

                txtNetValue.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("NetValue")), "", dsDS1.Tables("MR").Rows(0).Item("NetValue"))
                txttotalvalue.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Totalvalue")), "", dsDS1.Tables("MR").Rows(0).Item("Totalvalue"))

                txtConfigCode.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ConfigurationCode")), "", dsDS1.Tables("MR").Rows(0).Item("ConfigurationCode"))


                dgDetail.RowCount = 1
                With dgDetail
                    For i = 0 To dsDS1.Tables("MR").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ItemCode")), "", dsDS1.Tables("MR").Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ItemName")), "", dsDS1.Tables("MR").Rows(i).Item("ItemName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Category")), "", dsDS1.Tables("MR").Rows(i).Item("Category"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Qty")), 0, dsDS1.Tables("MR").Rows(i).Item("Qty"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Unit")), "", dsDS1.Tables("MR").Rows(i).Item("Unit"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubQty")), 0, dsDS1.Tables("MR").Rows(i).Item("SubQty"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("StoreUnit")), "", dsDS1.Tables("MR").Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Rate")), 0, dsDS1.Tables("MR").Rows(i).Item("Rate"))

                        .Rows(i).Cells(9).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubRate")), 0, dsDS1.Tables("MR").Rows(i).Item("SubRate"))
                        .Rows(i).Cells(10).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Amount")), 0, dsDS1.Tables("MR").Rows(i).Item("Amount"))
                        .Rows(i).Cells(11).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("CurrentStock")), 0, dsDS1.Tables("MR").Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(12).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("CurrentSubStock")), 0, dsDS1.Tables("MR").Rows(i).Item("CurrentSubStock"))
                        .Rows(i).Cells(13).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ConvFAct")), 0, dsDS1.Tables("MR").Rows(i).Item("ConvFAct"))



                    Next
                    dgDetail.RowCount = dgDetail.RowCount - 1
                End With


            End If


            daDA1.Dispose()
            dsDS1.Clear()

            str1 = "SELECT PurchaseOrderOverHeads.PurchaseNo, PurchaseOrderOverHeads.Description,PurchaseOrderOverHeads.Code, PurchaseOrderOverHeads.PlusMinus, PurchaseOrderOverHeads.Percentage, PurchaseOrderOverHeads.Amount, PurchaseOrderOverHeads.TotalAmount, PurchaseOrderOverHeads.CalcOn,PurchaseOrderOverHeads.Remarks,purchaseOrderOverHeads.SNo FROM PurchaseOrderOverHeads WHERE (PurchaseOrderOverHeads.PurchaseNo= '" & txtPurchaseNo.Text & "') "


            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "OverHead")
            dgConfiguration.RowCount = 1
            If dsDS1.Tables("OverHead").Rows.Count > 0 Then
                With dgConfiguration
                    For i = 0 To dsDS1.Tables("OverHead").Rows.Count - 1
                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Description")), "", dsDS1.Tables("OverHead").Rows(i).Item("Description"))
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Code")), "", dsDS1.Tables("OverHead").Rows(i).Item("Code"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("PlusMinus")), "", dsDS1.Tables("OverHead").Rows(i).Item("PlusMinus"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Percentage")), "", dsDS1.Tables("OverHead").Rows(i).Item("Percentage"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Amount")), 0, dsDS1.Tables("OverHead").Rows(i).Item("Amount"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("TotalAmount")), "", dsDS1.Tables("OverHead").Rows(i).Item("TotalAmount"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("CalcOn")), 0, dsDS1.Tables("OverHead").Rows(i).Item("CalcOn"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Remarks")), "", dsDS1.Tables("OverHead").Rows(i).Item("Remarks"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("SNo")), "", dsDS1.Tables("OverHead").Rows(i).Item("SNo"))
                        txtTotalValue1.Text = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("TotalAmount")), "", dsDS1.Tables("OverHead").Rows(i).Item("TotalAmount"))

                    Next
                    .RowCount = .RowCount - 1
                End With

            Else
                dgConfiguration.RowCount = 0
            End If

            daDA1.Dispose()
            dsDS1.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim StrQuery As String
        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction
        Dim i As Integer

        Try

            If cmdApprove.Text = "Approve" Then
                If MsgQuestion("APPROVE") = 6 Then
                    trn = gl_Con.BeginTransaction
                    With dgDetail
                        For i = 0 To .RowCount - 1
                            str1 = "update ItemMaster set CurrentStock=CurrentStock+" & Val(.Rows(i).Cells(4).Value) & ",CurrentSubStock=CurrentSubStock+" & Val(.Rows(i).Cells(6).Value) & ",PurchasePrice=" & Val(.Rows(i).Cells(8).Value) & " where ItemCode='" & (.Rows(i).Cells(1).Value) & "'"
                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                    End With

                    If chkcash.Checked = True Then
                        str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration) values('" & txtPurchaseNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','CASH','PurchaseInvoice',0," & Val(txttotalvalue.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"
                    Else
                        str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration) values('" & txtPurchaseNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & suppliercode & "','PurchaseInvoice',0," & Val(txttotalvalue.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    End If


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    With dgConfiguration
                        For i = 0 To .RowCount - 1
                            If i = 0 Then
                                str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration) values('" & txtPurchaseNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','Purchase A/C','PurchaseInvoice','" & Val(txtNetValue.Text) & "',0,'" & Replace(txtRemarks.Text, "'", "''") & "')"
                            Else
                                If .Rows(i).Cells(2).Value.ToString = "+" Then
                                    str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration) values('" & txtPurchaseNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & .Rows(i).Cells(0).Value & "','PurchaseInvoice','" & Val(.Rows(i).Cells(4).Value) & "',0,'" & Replace(txtRemarks.Text, "'", "''") & "')"
                                Else
                                    str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration) values('" & txtPurchaseNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & .Rows(i).Cells(0).Value & "','PurchaseInvoice',0,'" & Val(.Rows(i).Cells(4).Value) & "','" & Replace(txtRemarks.Text, "'", "''") & "')"
                                End If

                            End If

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()

                        Next
                    End With

                   
                    'str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration) values('" & txtPurchaseNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','PURCHASE A/C','Purchase'," & Val(txttotalvalue.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "')"

                    'cmdCom1.Transaction = trn
                    'cmdCom1.Connection = gl_Con
                    'cmdCom1.CommandText = str1
                    'cmdCom1.ExecuteNonQuery()


                    str1 = "update PurchaseMaster set Approve=1 where PurchaseNo='" & txtPurchaseNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    If chkcash.Checked = False Then
                        str1 = "update supplierMaster1 set Balance=Balance+" & Val(txttotalvalue.Text) & " where suppliercode='" & suppliercode & "'"
                    Else
                        str1 = "update CompanyMaster1 set CurrentBalance=CurrentBalance-" & Val(txttotalvalue.Text) & ""
                    End If

                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtPurchaseNo.Text))

                    If Approve = 1 Then
                        cmdApprove.Text = "Approved"
                        cmdEdit.Enabled = False
                    Else
                        cmdApprove.Text = "Approve"
                        cmdEdit.Enabled = True
                    End If
                End If
            ElseIf cmdApprove.Text = "Approved" Then


                If MsgQuestion("DISAPPROVE") = 6 Then

                    trn = gl_Con.BeginTransaction
                    With dgDetail
                        For i = 0 To .RowCount - 1

                            str1 = "update ItemMaster set CurrentStock=CurrentStock-" & Val(.Rows(i).Cells(4).Value) & ",CurrentSubStock=CurrentSubStock-" & Val(.Rows(i).Cells(6).Value) & " where ItemCode='" & (.Rows(i).Cells(1).Value) & "'"
                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()


                        Next
                    End With


                    str1 = "update PurchaseMaster set Approve=0 where PurchaseNo='" & txtPurchaseNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    StrQuery = "Delete from LEDGER where TransactionNo='" & Replace(Trim(txtPurchaseNo.Text), "'", "''") & "'"
                    ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()

                    If chkcash.Checked = False Then
                        str1 = "update supplierMaster1 set Balance=Balance-" & Val(txttotalvalue.Text) & " where suppliercode='" & suppliercode & "'"
                    Else
                        str1 = "update CompanyMaster1 set CurrentBalance=CurrentBalance+" & Val(txttotalvalue.Text) & ""
                    End If

                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtPurchaseNo.Text))
                    If Approve = 1 Then
                        cmdApprove.Text = "Approved"
                        cmdEdit.Enabled = False
                    Else
                        cmdApprove.Text = "Approve"
                        cmdEdit.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkcash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkcash.Click
        If chkcash.Checked = True Then
            Cash = 1
            cmdSearchSupplier.Enabled = False
            txtSupplierName.ReadOnly = False
            txtAddress.ReadOnly = False
            txtSupplierName.Text = ""
            txtAddress.Text = ""
            suppliercode = ""

        Else
            Cash = 0
            cmdSearchSupplier.Enabled = True
            txtSupplierName.ReadOnly = True
            txtAddress.ReadOnly = True
            txtSupplierName.Text = ""
            txtAddress.Text = ""
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

                'Query for selecting minimum and maximum ItemID
                strMinMaxKey = "select max(PurchaseId) AS MaxId,MIN(PurchaseId) As MinId from PurchaseMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet

                'fill the dataset with min and max Id's 
                'give the name to table "ItemID"

                daMinMaxKey.Fill(dsMinMaxKey, "Purchase")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select PurchaseNo  from PurchaseMaster where PurchaseId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                        txtPurchaseNo.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("PurchaseNo")
                        Call Display(txtPurchaseNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select PurchaseNo from PurchaseMaster where PurchaseId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                            If dsMinMaxKey.Tables("PurchaseNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtPurchaseNo.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("PurchaseNo")
                        Call Display(txtPurchaseNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId")
                            strNextRecord = "select PurchaseNo from PurchaseMaster where PurchaseId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                            If dsMinMaxKey.Tables("PurchaseNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtPurchaseNo.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("PurchaseNo")
                        Call Display(txtPurchaseNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select PurchaseNo from PurchaseMaster where PurchaseId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                        txtPurchaseNo.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("PurchaseNo")
                        Call Display(txtPurchaseNo.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub
    Private Sub Cancel()
        If MsgQuestion("CANCEL") = 7 Then


            Exit Sub
        End If
        If bln_AddOn = True Then
            Display()
        Else
            Display(txtPurchaseNo.Text)
        End If


        Call ENABLECONTROL(True)

        bln_AddOn = False
        bln_EditOn = False

    End Sub
    Private Sub DesignGrid3()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 9

            .Columns(0).Visible = True
            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 350
            .Columns(3).Name = "Category"
            .Columns(3).Width = 200
            .Columns(4).Name = "CurrentStock"
            .Columns(4).Width = 80
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(6).Name = "SubStock"
            .Columns(6).Width = 80
            .Columns(7).Name = "StoreUnit"
            .Columns(7).Width = 80
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80
  
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

        End With


        With dgSelectedItem
            .RowCount = 1
            .ColumnCount = 9


            .Columns(0).Visible = True
            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 350
            .Columns(3).Name = "Category"
            .Columns(3).Width = 200
            .Columns(4).Name = "CurrentStock"
            .Columns(4).Width = 80
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(6).Name = "SubStock"
            .Columns(6).Width = 80
            .Columns(7).Name = "StoreUnit"
            .Columns(7).Width = 80
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80

            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

        End With
        dgSelectedItem.RowCount = 0


       
    End Sub
    Private Function checkData() As Boolean

        f_blnCheckData = False
        f_strDataCheck = ""
        If Trim(txtSupplierName.Text) = "" Then
            f_strDataCheck = "Supplier Name"
            txtSupplierName.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If
        checkData = f_blnCheckData
    End Function

    Private Sub cmdAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddItem.Click
        checkData()
        If checkData() = True Then '''''''''''''Checking data
            MsgDisplay(f_strDataCheck) ''calling function in main module 

            Exit Sub
        End If

        Dim StrQuery As String
        Dim i As Integer

        DesignGrid3()
        da2.Dispose()
        ds2.Clear()
        Try

            StrQuery = "SELECT * from ItemMaster order by ItemCode"
            da2 = New SqlDataAdapter(StrQuery, gl_Con)
            da2.Fill(ds2, "ItemMaster")
            dgSelectItem.RowCount = 1
            If ds2.Tables("ItemMaster").Rows.Count > 0 Then
                With dgSelectItem
                    For i = 0 To ds2.Tables("ItemMaster").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = False

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("ItemCode")), "", ds2.Tables("ItemMaster").Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("ItemName")), "", ds2.Tables("ItemMaster").Rows(i).Item("ItemName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("Category")), "", ds2.Tables("ItemMaster").Rows(i).Item("Category"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("CurrentStock")), "", ds2.Tables("ItemMaster").Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("Unit")), "", ds2.Tables("ItemMaster").Rows(i).Item("Unit"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("CurrentSubStock")), 0, ds2.Tables("ItemMaster").Rows(i).Item("CurrentSubStock"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("StoreUnit")), "", ds2.Tables("ItemMaster").Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("ConvFAct")), "", ds2.Tables("ItemMaster").Rows(i).Item("ConvFAct"))



                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSelectItem.RowCount = 0
            End If
            txtSearchItemName.Text = ""
            txtSearchItemName.Focus()
            gbSelectItem.BringToFront()
            gbMain.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtSearchItemName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchItemName.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSelectItem.Focus()
        End If
    End Sub

    Private Sub txtSearchItemName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchItemName.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try
           
            dv = New DataView(ds2.Tables("ItemMaster"), "ItemName Like '" & Trim(txtSearchItemName.Text) & "*" & "'", "ItemCode", DataViewRowState.CurrentRows)

            dTable = dv.ToTable
            dgSelectItem.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSelectItem
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemCode")), "", dTable.Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemName")), "", dTable.Rows(i).Item("ItemName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("Category")), "", dTable.Rows(i).Item("Category"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("CurrentStock")), "", dTable.Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("Unit")), "", dTable.Rows(i).Item("Unit"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("CurrentSubStock")), 0, dTable.Rows(i).Item("CurrentSubStock"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dTable.Rows(i).Item("StoreUnit")), "", dTable.Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dTable.Rows(i).Item("ConvFAct")), "", dTable.Rows(i).Item("ConvFAct"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSelectItem.RowCount = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSelectItem_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellContentClick
        Dim IntCount As Integer
        Dim intSelectedRow As Integer
        Dim i As Integer
        Dim blnAdd As Boolean
        Dim ch1 As DataGridViewCheckBoxCell
        ch1 = New DataGridViewCheckBoxCell()
        ch1 = dgSelectItem.Rows(dgSelectItem.CurrentRow.Index).Cells(0)

        If e.ColumnIndex <> 0 Then
            dgSelectItem.EditMode = DataGridViewEditMode.EditProgrammatically
            Exit Sub
        Else
            dgSelectItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If


        Try
            'intSelectedRow = fgSelectItem.Row
            With dgSelectItem
                If e.ColumnIndex = 0 Then
                    If ch1.EditingCellFormattedValue = "True" Then

                        blnAdd = False
                        'For i = 1 To fgSelectedItem.Rows - 1
                        '    If .get_TextMatrix(intSelectedRow, 1) = fgSelectedItem.get_TextMatrix(i, 1) Then
                        '        blnAdd = True
                        '    End If
                        'Next
                        If blnAdd = False Then

                            dgSelectedItem.RowCount = dgSelectedItem.RowCount + 1
                            i = dgSelectedItem.RowCount - 1

                            dgSelectedItem.Rows(i).Cells(0).Value = True
                            dgSelectedItem.Rows(i).Cells(1).Value = .Rows(e.RowIndex).Cells(1).Value
                            dgSelectedItem.Rows(i).Cells(2).Value = .Rows(e.RowIndex).Cells(2).Value

                            dgSelectedItem.Rows(i).Cells(3).Value = .Rows(e.RowIndex).Cells(3).Value
                            dgSelectedItem.Rows(i).Cells(4).Value = .Rows(e.RowIndex).Cells(4).Value
                            dgSelectedItem.Rows(i).Cells(5).Value = .Rows(e.RowIndex).Cells(5).Value
                            dgSelectedItem.Rows(i).Cells(6).Value = .Rows(e.RowIndex).Cells(6).Value
                            dgSelectedItem.Rows(i).Cells(7).Value = .Rows(e.RowIndex).Cells(7).Value
                            dgSelectedItem.Rows(i).Cells(8).Value = .Rows(e.RowIndex).Cells(8).Value

                        End If
                    Else
                        For IntCount = 0 To dgSelectedItem.RowCount - 1
                            If dgSelectedItem.Rows(IntCount).Cells(1).Value = .Rows(.CurrentRow.Index).Cells(1).Value.ToString Then
                                dgSelectedItem.Rows.Remove(dgSelectedItem.Rows(IntCount))

                                Exit For
                            End If
                        Next
                    End If

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSelectItem_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellContentDoubleClick
        Dim IntCount As Integer
        Dim intSelectedRow As Integer
        Dim i As Integer
        Dim blnAdd As Boolean
        Dim ch1 As DataGridViewCheckBoxCell
        ch1 = New DataGridViewCheckBoxCell()
        ch1 = dgSelectItem.Rows(dgSelectItem.CurrentRow.Index).Cells(0)

        If e.ColumnIndex <> 0 Then
            dgSelectItem.EditMode = DataGridViewEditMode.EditProgrammatically
            Exit Sub
        Else
            dgSelectItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If


        Try
            'intSelectedRow = fgSelectItem.Row
            With dgSelectItem
                If e.ColumnIndex = 0 Then
                    If ch1.EditingCellFormattedValue = "True" Then

                        blnAdd = False
                        'For i = 1 To fgSelectedItem.Rows - 1
                        '    If .get_TextMatrix(intSelectedRow, 1) = fgSelectedItem.get_TextMatrix(i, 1) Then
                        '        blnAdd = True
                        '    End If
                        'Next
                        If blnAdd = False Then

                            dgSelectedItem.RowCount = dgSelectedItem.RowCount + 1
                            i = dgSelectedItem.RowCount - 1

                            dgSelectedItem.Rows(i).Cells(0).Value = True
                            dgSelectedItem.Rows(i).Cells(1).Value = .Rows(e.RowIndex).Cells(1).Value
                            dgSelectedItem.Rows(i).Cells(2).Value = .Rows(e.RowIndex).Cells(2).Value

                            dgSelectedItem.Rows(i).Cells(3).Value = .Rows(e.RowIndex).Cells(3).Value
                            dgSelectedItem.Rows(i).Cells(4).Value = .Rows(e.RowIndex).Cells(4).Value
                            dgSelectedItem.Rows(i).Cells(5).Value = .Rows(e.RowIndex).Cells(5).Value
                            dgSelectedItem.Rows(i).Cells(6).Value = .Rows(e.RowIndex).Cells(6).Value
                            dgSelectedItem.Rows(i).Cells(7).Value = .Rows(e.RowIndex).Cells(7).Value
                            dgSelectedItem.Rows(i).Cells(8).Value = .Rows(e.RowIndex).Cells(8).Value

                        End If
                    Else
                        For IntCount = 0 To dgSelectedItem.RowCount - 1
                            If dgSelectedItem.Rows(IntCount).Cells(1).Value = .Rows(.CurrentRow.Index).Cells(1).Value.ToString Then
                                dgSelectedItem.Rows.Remove(dgSelectedItem.Rows(IntCount))

                                Exit For
                            End If
                        Next
                    End If

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSelectItem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellDoubleClick
        If e.ColumnIndex > 0 Then
            If dgSelectItem.RowCount = 0 Then
                MessageBox.Show("No Record Found")
                gbMain.BringToFront()
                gbSelectItem.SendToBack()
                Exit Sub
            Else
                DirectFillItemGrid()
                intDGSearchKeayPress = 0
                gbMain.BringToFront()
                gbSelectItem.SendToBack()
            End If
        End If

    End Sub
    Private Sub DirectFillItemGrid()
        Dim i As Integer

        Dim ItemCode As String
        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim StrQuery As String


        Try
            With dgSelectItem
                If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                    ItemCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                Else
                    ItemCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                End If
            End With


            StrQuery = "SELECT * from ItemMaster WHERE  itemcode='" & ItemCode & "' order by itemname"

            ItemCode = ""
            da = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            ds.Clear()
            da.Fill(ds, "ItemList")
            dgDetail.RowCount = dgDetail.RowCount + 1
            For iRow = 0 To ds.Tables("ItemList").Rows.Count - 1
                drDisplay = ds.Tables("ItemList").Rows(iRow)
                With dgDetail
                    Dim K As Integer
                    Dim J As Integer
                    .RowCount = .RowCount + 1
                    .Rows(.RowCount - 2).Cells(0).Value = .RowCount - 1
                    .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode"))
                    .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName"))
                    .Rows(.RowCount - 2).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category"))

                    .Rows(.RowCount - 2).Cells(11).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                    .Rows(.RowCount - 2).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit"))
                    .Rows(.RowCount - 2).Cells(12).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                    .Rows(.RowCount - 2).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit"))
                    .Rows(.RowCount - 2).Cells(13).Value = IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct"))
                    .Rows(.RowCount - 2).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("PurchasePrice")), "", drDisplay.Item("PurchasePrice"))
                    .Rows(.RowCount - 2).Cells(9).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) / Val(.Rows(.RowCount - 2).Cells(13).Value)

                    K = Val(.Rows(.RowCount - 2).Cells(8).Value)
                    K = Val(.Rows(.RowCount - 2).Cells(13).Value)
                    J = Val(.Rows(.RowCount - 2).Cells(8).Value) / Val(.Rows(.RowCount - 2).Cells(13).Value)

                End With

            Next
            dgDetail.RowCount = dgDetail.RowCount - 1


        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSelectItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellEnter
        If e.ColumnIndex <> 0 Then
            dgSelectItem.EditMode = DataGridViewEditMode.EditProgrammatically

        Else
            dgSelectItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If
    End Sub

    Private Sub dgSelectedItem_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectedItem.CellContentClick
        Dim IntCount As Integer
        Dim intSelectedRow As Integer
        Dim i As Integer
        Dim Code As String
        Dim ch1 As DataGridViewCheckBoxCell
        ch1 = New DataGridViewCheckBoxCell()
        ch1 = dgSelectedItem.Rows(dgSelectedItem.CurrentRow.Index).Cells(0)

        If e.ColumnIndex <> 0 Then
            dgSelectedItem.EditMode = DataGridViewEditMode.EditProgrammatically
            Exit Sub
        Else
            dgSelectedItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If


        Try

            With dgSelectedItem
                If e.ColumnIndex = 0 Then
                    If ch1.EditingCellFormattedValue = "False" Then

                        If dgSelectedItem.RowCount > 0 Then
                            Code = dgSelectedItem.Rows(.CurrentRow.Index).Cells(1).Value
                            dgSelectedItem.Rows.Remove(dgSelectedItem.CurrentRow)

                        Else
                            Exit Sub

                        End If
                    Else
                        Exit Sub
                    End If
                    For IntCount = 0 To dgSelectItem.RowCount - 1
                        If dgSelectItem.Rows(IntCount).Cells(1).Value = Code Then
                            dgSelectItem.Rows(IntCount).Cells(0).Value = False
                            Exit For
                        End If
                    Next
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSelectedItem_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectedItem.CellContentDoubleClick
        Dim IntCount As Integer
        Dim intSelectedRow As Integer
        Dim i As Integer
        Dim Code As String
        Dim ch1 As DataGridViewCheckBoxCell
        ch1 = New DataGridViewCheckBoxCell()
        ch1 = dgSelectedItem.Rows(dgSelectedItem.CurrentRow.Index).Cells(0)

        If e.ColumnIndex <> 0 Then
            dgSelectedItem.EditMode = DataGridViewEditMode.EditProgrammatically
            Exit Sub
        Else
            dgSelectedItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If


        Try

            With dgSelectedItem
                If e.ColumnIndex = 0 Then
                    If ch1.EditingCellFormattedValue = "False" Then

                        If dgSelectedItem.RowCount > 0 Then
                            Code = dgSelectedItem.Rows(.CurrentRow.Index).Cells(1).Value
                            dgSelectedItem.Rows.Remove(dgSelectedItem.CurrentRow)

                        Else
                            Exit Sub

                        End If
                    Else
                        Exit Sub
                    End If
                    For IntCount = 0 To dgSelectItem.RowCount - 1
                        If dgSelectItem.Rows(IntCount).Cells(1).Value = Code Then
                            dgSelectItem.Rows(IntCount).Cells(0).Value = False
                            Exit For
                        End If
                    Next
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSelectedItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectedItem.CellEnter
        If e.ColumnIndex <> 0 Then
            dgSelectedItem.EditMode = DataGridViewEditMode.EditProgrammatically

        Else
            dgSelectedItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If
    End Sub

    Private Sub cmdDelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelItem.Click
        Dim AmountLess As Decimal
        Dim i As Integer
        If dgDetail.RowCount >= 1 Then
            If MsgQuestion("DELETE") = 7 Then
                Exit Sub
            Else
                AmountLess = dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(10).Value
                dgDetail.Rows.Remove(dgDetail.CurrentRow)

                For i = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(i).Cells(0).Value = i + 1
                Next
            End If
            txtNetValue.Text = Val(txtNetValue.Text) - AmountLess
        Else
            MsgBox("No row to delete")
        End If
        For i = 0 To dgConfiguration.RowCount - 1
            Call CalculateTotal(i)
        Next

        If dgDetail.RowCount = 0 Then
            txtNetValue.Text = 0
            txttotalvalue.Text = 0

        End If
    End Sub

    Private Sub dgSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSearch.KeyPress
        Dim e1 As System.EventArgs
        If (e.KeyChar = Convert.ToChar(13)) Then
            intDGSearchKeayPress = 1
            dgSearch_DoubleClick(sender, e1)
        End If
    End Sub
    Private Function CheckRateCol() As Boolean
        Dim i As Integer
        Dim r As Integer
        Dim blnRateEmpty As Boolean
        Dim blnQtyEmpty As Boolean
        Dim s As Integer
        Try

            CheckRateCol = False
            blnRateEmpty = False
            With dgDetail
                For i = 0 To .RowCount - 1
                    If Val(.Rows(i).Cells(8).Value) = 0 Or Val(.Rows(i).Cells(9).Value) = 0 Then
                        r = i
                        blnRateEmpty = True
                        Exit For
                    End If
                Next



                For i = 1 To .RowCount - 1
                    If Val(.Rows(i).Cells(4).Value) = 0 Or Val(.Rows(i).Cells(6).Value) = 0 Then
                        s = i
                        blnQtyEmpty = True
                        Exit For
                    End If
                Next


            End With

            If blnQtyEmpty = True Then
                MsgBox("Qty can't be empty or zero")
                dgDetail.CurrentCell = dgDetail.Item(4, s)
                CheckRateCol = True
                Exit Function
            End If


            If blnRateEmpty = True Then
                MsgBox("Rate can't be empty or zero")
                dgDetail.CurrentCell = dgDetail.Item(8, r)
                CheckRateCol = True
                Exit Function
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub FillComboConfig()
        Dim strQuery As String
        Dim daConfig As SqlClient.SqlDataAdapter
        Dim dsConfig As New DataSet

        Try
            strQuery = "Select ConfigurationCode from ConfigurationMaster   Order By ConfigurationCode"
            daConfig = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            daConfig.Fill(dsConfig, "Config")
            cboConfig.DataSource = Nothing
            cboConfig.DataSource = dsConfig.Tables("Config")
            cboConfig.DisplayMember = "ConfigurationCode"
            'cboConfig.ValueMember = "Category"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdOverhead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOverhead.Click
        Try
            If dgDetail.RowCount = 0 Then
                MsgBox("First Select Item Details", MsgBoxStyle.Information)
                cmdAddItem.Focus()
                Exit Sub
            End If
            If CheckRateCol() = True Then
                Exit Sub
            End If

            Call FillComboConfig()

            dgConfigSearch.RowCount = 0



            Call cboConfig_SelectedIndexChanged(sender, New System.EventArgs)
            gbConfigSearch.Visible = True
            gbConfigSearch.BringToFront()
            gbMain.Enabled = False


            cboConfig.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub cboConfig_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConfig.SelectedIndexChanged
        Dim strQuery As String
        Dim drConfigD As SqlClient.SqlDataReader
        Dim comConfigD As New SqlClient.SqlCommand
        Try


            If bln_AddOn = True Or bln_EditOn = True Then
                If Len(cboConfig.Text) > 0 Then

                    strQuery = "SELECT ConfigurationCode, Remarks FROM ConfigurationMaster Where ConfigurationCode='" & cboConfig.Text & "'"
                    comConfigD = New SqlClient.SqlCommand(strQuery, gl_Con)
                    drConfigD = comConfigD.ExecuteReader()
                    If drConfigD.HasRows Then
                        drConfigD.Read()
                        txtConfigurationRemarks.Text = IIf(IsDBNull(drConfigD.Item("Remarks")), "", drConfigD.Item("Remarks"))
                    End If
                    drConfigD.Close()

                    Call FillOverHeadDetails(Trim(cboConfig.Text()))
                End If
            End If
        Catch ex As Exception
            If drConfigD.IsClosed = False Then
                drConfigD.Close()
            End If
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click

        FillItemGrid()
        gbMain.BringToFront()
        gbSelectItem.SendToBack()
    End Sub
    Private Sub FillItemGrid() 'Fill Search Result in Main Grid
        Dim i As Integer
        Dim J As Integer
        Dim k As Integer
        Dim blnAdd As Boolean
        Try

            With dgSelectedItem
                For i = 0 To .RowCount - 1
                    blnAdd = False
                    'For k = 1 To fgDetail.Rows - 1
                    '    If fgDetail.get_TextMatrix(k, 1) = Trim(.get_TextMatrix(i, 1)) Then
                    '        blnAdd = True
                    '        Exit For
                    '    End If
                    'Next
                    If blnAdd = False Then

                        dgDetail.RowCount = dgDetail.RowCount + 1
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(0).Value = dgDetail.RowCount

                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(1).Value = .Rows(i).Cells(1).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(2).Value = .Rows(i).Cells(2).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(3).Value = .Rows(i).Cells(3).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(11).Value = .Rows(i).Cells(4).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(5).Value = .Rows(i).Cells(5).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(12).Value = .Rows(i).Cells(6).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(7).Value = .Rows(i).Cells(7).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(13).Value = .Rows(i).Cells(8).Value.ToString


                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgDetail_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEndEdit
        Dim amount As Decimal

        With dgDetail

            If e.ColumnIndex = 4 Then
                .Rows(.CurrentRow.Index).Cells(6).Value = Val(.Rows(.CurrentRow.Index).Cells(4).Value) * Val(.Rows(.CurrentRow.Index).Cells(13).Value)

            ElseIf e.ColumnIndex = 6 Then
                .Rows(.CurrentRow.Index).Cells(4).Value = Val(.Rows(.CurrentRow.Index).Cells(6).Value) / Val(.Rows(.CurrentRow.Index).Cells(13).Value)
            End If


            If e.ColumnIndex = 8 Then
                .Rows(.CurrentRow.Index).Cells(9).Value = Val(.Rows(.CurrentRow.Index).Cells(8).Value) / Val(.Rows(.CurrentRow.Index).Cells(13).Value)
            ElseIf e.ColumnIndex = 9 Then
                .Rows(.CurrentRow.Index).Cells(8).Value = Val(.Rows(.CurrentRow.Index).Cells(9).Value) * Val(.Rows(.CurrentRow.Index).Cells(13).Value)

            End If
            .Rows(.CurrentRow.Index).Cells(10).Value = Val(.Rows(.CurrentRow.Index).Cells(4).Value) * Val(.Rows(.CurrentRow.Index).Cells(8).Value)

            For i = 0 To .RowCount - 1
                amount = amount + Val(.Rows(i).Cells(10).Value)
            Next
            txtNetValue.Text = amount
        End With
        For i = 0 To dgConfiguration.RowCount - 1
            Call CalculateTotal(i)
        Next

    End Sub
    Private Sub CalculateTotal(ByVal intRowsel As Integer)
        Dim strQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim Amt As Decimal
        Dim amtchange As Decimal
        Dim TotalValue As Integer



        Dim i As Integer

        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction



        strQuery = "Select Description, Code, PlusMinus, Percentage, Amount, TotalAmount, CalcOn from PurchaseOrderOverHeads   where PurchaseNo='" & txtPurchaseNo.Text & "' and Description='" & dgConfiguration.Rows(intRowsel).Cells(6).Value & "'"
        da = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
        da.Fill(ds, "Config")

        If ds.Tables("Config").Rows.Count > 0 Then
            Amt = IIf(IsDBNull(ds.Tables("Config").Rows(0).Item("TotalAmount")), "", ds.Tables("Config").Rows(0).Item("TotalAmount"))
        End If


        With dgConfiguration

            If .Rows(intRowsel).Cells(6).Value.ToString = "Net Order Value" Then

                .Rows(intRowsel).Cells(4).Value = Val(txtNetValue.Text) * (Val(.Rows(intRowsel).Cells(3).Value) / 100)
                .Rows(intRowsel).Cells(7).Value = Val(txtNetValue.Text)
            Else

                .Rows(intRowsel).Cells(4).Value = Amt * (Val(.Rows(intRowsel).Cells(3).Value) / 100)
                .Rows(intRowsel).Cells(7).Value = Amt
            End If
        End With

        With dgConfiguration
            For i = 0 To .RowCount - 1
                If i = 0 Then
                    If (Trim(.Rows(i).Cells(2).Value.ToString)) = "+" Then
                        .Rows(i).Cells(5).Value = Val(txtNetValue.Text) + Val(.Rows(i).Cells(4).Value)
                    Else
                        .Rows(i).Cells(5).Value = Val(txtNetValue.Text) - Val(.Rows(i).Cells(4).Value)
                    End If

                Else
                    If i > 0 Then
                        If (Trim(.Rows(i).Cells(2).Value.ToString)) = "+" Then
                            .Rows(i).Cells(5).Value = Val(.Rows(i - 1).Cells(5).Value) + Val(.Rows(i).Cells(4).Value)

                        Else
                            .Rows(i).Cells(5).Value = Val(.Rows(i - 1).Cells(5).Value) - Val(.Rows(i).Cells(4).Value)

                        End If
                    End If
                End If

                TotalValue = Val(.Rows(i).Cells(5).Value)
                txttotalvalue.Text = TotalValue
                txtTotalValue1.Text = Val(.Rows(i).Cells(5).Value)
            Next


        End With



        strQuery = "Delete from PurchaseOrderOverHeads where PurchaseNo='" & Replace(Trim(txtPurchaseNo.Text), "'", "''") & "'"
        ComSave = New SqlClient.SqlCommand(strQuery, gl_Con)
        ComSave.CommandType = CommandType.Text
        ComSave.Transaction = trn
        ComSave.ExecuteNonQuery()

        With dgConfiguration
            For i = 0 To .RowCount - 1
                strQuery = "Insert into PurchaseOrderOverHeads(PurchaseNo, Description, Code, PlusMinus, Percentage, Amount, TotalAmount, CalcOn ,Remarks,SNo ) Values('" & Replace(Trim(txtPurchaseNo.Text), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(0).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(1).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(2).Value), "'", "''") & "'," & Val(.Rows(i).Cells(3).Value) & "," & Val(.Rows(i).Cells(4).Value) & "," & Val(.Rows(i).Cells(5).Value) & ",'" & Replace(Trim(.Rows(i).Cells(6).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(7).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(8).Value), "'", "''") & "')"
                ComSave = New SqlClient.SqlCommand(strQuery, gl_Con)
                ComSave.CommandType = CommandType.Text
                ComSave.Transaction = trn
                ComSave.ExecuteNonQuery()
            Next
        End With

    End Sub

    Private Sub dgDetail_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEnter
        If bln_AddOn = True Or bln_EditOn = True Then
            With dgDetail

                If e.ColumnIndex = 4 Or e.ColumnIndex = 6 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
                    dgDetail.EditMode = DataGridViewEditMode.EditOnEnter
                Else
                    dgDetail.EditMode = DataGridViewEditMode.EditProgrammatically
                End If
            End With
        End If
    End Sub

    Private Sub cmdConfigOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfigOk.Click
        Cal()
    End Sub
    Private Sub Cal()
        Dim i As Integer

        Try
            Me.Cursor = Cursors.WaitCursor
            txtConfigCode.Text = Trim(dgConfigSearch.Rows(1).Cells(9).Value)
            dgConfiguration.RowCount = 1
            With dgConfiguration
                For i = 0 To dgConfigSearch.RowCount - 1
                    .RowCount = .RowCount + 1
                    .Rows(i).Cells(0).Value = dgConfigSearch.Rows(i).Cells(0).Value
                    .Rows(i).Cells(1).Value = dgConfigSearch.Rows(i).Cells(1).Value
                    .Rows(i).Cells(2).Value = dgConfigSearch.Rows(i).Cells(2).Value
                    .Rows(i).Cells(3).Value = dgConfigSearch.Rows(i).Cells(3).Value
                    .Rows(i).Cells(4).Value = 0.0
                    .Rows(i).Cells(5).Value = 0.0
                    .Rows(i).Cells(6).Value = dgConfigSearch.Rows(i).Cells(4).Value
                    .Rows(i).Cells(8).Value = dgConfigSearch.Rows(i).Cells(6).Value
                Next
                .RowCount = .RowCount - 1

                For i = 0 To dgConfiguration.RowCount - 1
                    Call CalculateTotal(i)
                Next

            End With

            gbConfigSearch.SendToBack()
            gbMain.Enabled = True
            gbMain.BringToFront()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Me.Close()
    End Sub
End Class