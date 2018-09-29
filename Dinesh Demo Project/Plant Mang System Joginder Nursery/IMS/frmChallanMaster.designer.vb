<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChallanMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.gbMain = New System.Windows.Forms.Panel
        Me.chkQuotation = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtQuotationNo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtGRNo = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtVehicleNo = New System.Windows.Forms.TextBox
        Me.txtPONo = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTotalValue1 = New System.Windows.Forms.TextBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.cmdApprove = New System.Windows.Forms.Button
        Me.gbDetail = New System.Windows.Forms.Panel
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.cmdDelItem = New System.Windows.Forms.Button
        Me.cmdAddItem = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdSearchCustomer = New System.Windows.Forms.Button
        Me.txtCustomerName = New System.Windows.Forms.TextBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.txtRefNo = New System.Windows.Forms.TextBox
        Me.lblPrimaryKey = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.txtChallanNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtChallanDate = New System.Windows.Forms.TextBox
        Me.gbSelectItem = New System.Windows.Forms.Panel
        Me.dgSelectedItem = New System.Windows.Forms.DataGridView
        Me.dgSelectItem = New System.Windows.Forms.DataGridView
        Me.cmdOk = New System.Windows.Forms.Button
        Me.gbQuotation = New System.Windows.Forms.Panel
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboSearchItem = New System.Windows.Forms.ComboBox
        Me.txtSearchItemName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboSearch = New System.Windows.Forms.ComboBox
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lblRow = New System.Windows.Forms.Label
        Me.gbSearch = New System.Windows.Forms.Panel
        Me.dgSearch = New System.Windows.Forms.DataGridView
        Me.gbSearchCustomer = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblRowSearch = New System.Windows.Forms.Label
        Me.cboSearchCustomer = New System.Windows.Forms.ComboBox
        Me.txtSearchCustomer = New System.Windows.Forms.TextBox
        Me.gbSearchInvoice = New System.Windows.Forms.Panel
        Me.gbMain.SuspendLayout()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gbSelectItem.SuspendLayout()
        CType(Me.dgSelectedItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSelectItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbQuotation.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearchCustomer.SuspendLayout()
        Me.gbSearchInvoice.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Green
        Me.TextBox1.Location = New System.Drawing.Point(-2, -5)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(1024, 38)
        Me.TextBox1.TabIndex = 800
        Me.TextBox1.Text = "Challan Master"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbMain
        '
        Me.gbMain.BackColor = System.Drawing.Color.Transparent
        Me.gbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbMain.Controls.Add(Me.chkQuotation)
        Me.gbMain.Controls.Add(Me.Label4)
        Me.gbMain.Controls.Add(Me.txtQuotationNo)
        Me.gbMain.Controls.Add(Me.Label7)
        Me.gbMain.Controls.Add(Me.txtGRNo)
        Me.gbMain.Controls.Add(Me.Label16)
        Me.gbMain.Controls.Add(Me.txtVehicleNo)
        Me.gbMain.Controls.Add(Me.txtPONo)
        Me.gbMain.Controls.Add(Me.Label17)
        Me.gbMain.Controls.Add(Me.txtTotalValue1)
        Me.gbMain.Controls.Add(Me.dtpDate)
        Me.gbMain.Controls.Add(Me.cmdApprove)
        Me.gbMain.Controls.Add(Me.gbDetail)
        Me.gbMain.Controls.Add(Me.Label15)
        Me.gbMain.Controls.Add(Me.Panel1)
        Me.gbMain.Controls.Add(Me.txtAddress)
        Me.gbMain.Controls.Add(Me.Label2)
        Me.gbMain.Controls.Add(Me.Label1)
        Me.gbMain.Controls.Add(Me.cmdSearchCustomer)
        Me.gbMain.Controls.Add(Me.txtCustomerName)
        Me.gbMain.Controls.Add(Me.cmdSearch)
        Me.gbMain.Controls.Add(Me.txtRefNo)
        Me.gbMain.Controls.Add(Me.lblPrimaryKey)
        Me.gbMain.Controls.Add(Me.txtRemarks)
        Me.gbMain.Controls.Add(Me.txtChallanNo)
        Me.gbMain.Controls.Add(Me.Label10)
        Me.gbMain.Controls.Add(Me.Label9)
        Me.gbMain.Controls.Add(Me.Label11)
        Me.gbMain.Controls.Add(Me.txtChallanDate)
        Me.gbMain.Location = New System.Drawing.Point(6, 39)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(1003, 581)
        Me.gbMain.TabIndex = 1
        '
        'chkQuotation
        '
        Me.chkQuotation.AutoSize = True
        Me.chkQuotation.Location = New System.Drawing.Point(11, 3)
        Me.chkQuotation.Name = "chkQuotation"
        Me.chkQuotation.Size = New System.Drawing.Size(87, 17)
        Me.chkQuotation.TabIndex = 522
        Me.chkQuotation.Text = "By Quotation"
        Me.chkQuotation.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(741, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 16)
        Me.Label4.TabIndex = 520
        Me.Label4.Text = "Quotation No"
        '
        'txtQuotationNo
        '
        Me.txtQuotationNo.BackColor = System.Drawing.Color.White
        Me.txtQuotationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuotationNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuotationNo.Location = New System.Drawing.Point(842, 132)
        Me.txtQuotationNo.Name = "txtQuotationNo"
        Me.txtQuotationNo.ReadOnly = True
        Me.txtQuotationNo.Size = New System.Drawing.Size(158, 23)
        Me.txtQuotationNo.TabIndex = 521
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(332, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 16)
        Me.Label7.TabIndex = 516
        Me.Label7.Text = "G.R.No"
        '
        'txtGRNo
        '
        Me.txtGRNo.BackColor = System.Drawing.Color.White
        Me.txtGRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGRNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGRNo.Location = New System.Drawing.Point(400, 132)
        Me.txtGRNo.Name = "txtGRNo"
        Me.txtGRNo.Size = New System.Drawing.Size(116, 23)
        Me.txtGRNo.TabIndex = 518
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(534, 134)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 16)
        Me.Label16.TabIndex = 514
        Me.Label16.Text = "PO No"
        '
        'txtVehicleNo
        '
        Me.txtVehicleNo.BackColor = System.Drawing.Color.White
        Me.txtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleNo.Location = New System.Drawing.Point(131, 134)
        Me.txtVehicleNo.Name = "txtVehicleNo"
        Me.txtVehicleNo.Size = New System.Drawing.Size(195, 23)
        Me.txtVehicleNo.TabIndex = 517
        '
        'txtPONo
        '
        Me.txtPONo.BackColor = System.Drawing.Color.White
        Me.txtPONo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPONo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONo.Location = New System.Drawing.Point(585, 132)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(150, 23)
        Me.txtPONo.TabIndex = 519
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(11, 136)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 16)
        Me.Label17.TabIndex = 515
        Me.Label17.Text = "Vehicle No"
        '
        'txtTotalValue1
        '
        Me.txtTotalValue1.BackColor = System.Drawing.Color.White
        Me.txtTotalValue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalValue1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalValue1.Location = New System.Drawing.Point(587, 549)
        Me.txtTotalValue1.Name = "txtTotalValue1"
        Me.txtTotalValue1.Size = New System.Drawing.Size(15, 23)
        Me.txtTotalValue1.TabIndex = 87
        Me.txtTotalValue1.Visible = False
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(399, 24)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(117, 23)
        Me.dtpDate.TabIndex = 501
        '
        'cmdApprove
        '
        Me.cmdApprove.Location = New System.Drawing.Point(637, 532)
        Me.cmdApprove.Name = "cmdApprove"
        Me.cmdApprove.Size = New System.Drawing.Size(80, 26)
        Me.cmdApprove.TabIndex = 85
        Me.cmdApprove.Text = "Approve"
        Me.cmdApprove.UseVisualStyleBackColor = True
        '
        'gbDetail
        '
        Me.gbDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbDetail.Controls.Add(Me.dgDetail)
        Me.gbDetail.Controls.Add(Me.cmdDelItem)
        Me.gbDetail.Controls.Add(Me.cmdAddItem)
        Me.gbDetail.Location = New System.Drawing.Point(9, 178)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(988, 336)
        Me.gbDetail.TabIndex = 77
        '
        'dgDetail
        '
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Location = New System.Drawing.Point(7, 5)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.Size = New System.Drawing.Size(904, 323)
        Me.dgDetail.TabIndex = 507
        '
        'cmdDelItem
        '
        Me.cmdDelItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelItem.Location = New System.Drawing.Point(919, 204)
        Me.cmdDelItem.Name = "cmdDelItem"
        Me.cmdDelItem.Size = New System.Drawing.Size(61, 56)
        Me.cmdDelItem.TabIndex = 46
        Me.cmdDelItem.Text = "&Delete Item"
        Me.cmdDelItem.UseVisualStyleBackColor = True
        '
        'cmdAddItem
        '
        Me.cmdAddItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddItem.Location = New System.Drawing.Point(919, 127)
        Me.cmdAddItem.Name = "cmdAddItem"
        Me.cmdAddItem.Size = New System.Drawing.Size(61, 56)
        Me.cmdAddItem.TabIndex = 506
        Me.cmdAddItem.Text = "&Add Item"
        Me.cmdAddItem.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(522, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 16)
        Me.Label15.TabIndex = 73
        Me.Label15.Text = "Address"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdPrint)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.cmdEdit)
        Me.Panel1.Controls.Add(Me.cmdAdd)
        Me.Panel1.Location = New System.Drawing.Point(723, 520)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(271, 49)
        Me.Panel1.TabIndex = 33
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(220, 13)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(46, 23)
        Me.cmdPrint.TabIndex = 4
        Me.cmdPrint.Text = "&Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(159, 13)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(55, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(107, 13)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(46, 23)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(55, 13)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(46, 23)
        Me.cmdEdit.TabIndex = 1
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(3, 13)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(46, 23)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.White
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(585, 22)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(416, 60)
        Me.txtAddress.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(332, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(332, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Remarks"
        '
        'cmdSearchCustomer
        '
        Me.cmdSearchCustomer.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearchCustomer.Location = New System.Drawing.Point(522, 58)
        Me.cmdSearchCustomer.Name = "cmdSearchCustomer"
        Me.cmdSearchCustomer.Size = New System.Drawing.Size(26, 23)
        Me.cmdSearchCustomer.TabIndex = 502
        Me.cmdSearchCustomer.Text = "........&Name"
        Me.cmdSearchCustomer.UseVisualStyleBackColor = True
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.White
        Me.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(131, 57)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(385, 23)
        Me.txtCustomerName.TabIndex = 60
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(284, 22)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(41, 27)
        Me.cmdSearch.TabIndex = 70
        Me.cmdSearch.Text = "?"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtRefNo
        '
        Me.txtRefNo.BackColor = System.Drawing.Color.White
        Me.txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRefNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNo.Location = New System.Drawing.Point(131, 95)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(195, 23)
        Me.txtRefNo.TabIndex = 503
        '
        'lblPrimaryKey
        '
        Me.lblPrimaryKey.AutoSize = True
        Me.lblPrimaryKey.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimaryKey.Location = New System.Drawing.Point(276, 78)
        Me.lblPrimaryKey.Name = "lblPrimaryKey"
        Me.lblPrimaryKey.Size = New System.Drawing.Size(94, 16)
        Me.lblPrimaryKey.TabIndex = 69
        Me.lblPrimaryKey.Text = "lblPrimaryKey"
        Me.lblPrimaryKey.Visible = False
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(400, 95)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(601, 23)
        Me.txtRemarks.TabIndex = 505
        '
        'txtChallanNo
        '
        Me.txtChallanNo.BackColor = System.Drawing.Color.White
        Me.txtChallanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChallanNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChallanNo.Location = New System.Drawing.Point(131, 24)
        Me.txtChallanNo.Name = "txtChallanNo"
        Me.txtChallanNo.Size = New System.Drawing.Size(147, 23)
        Me.txtChallanNo.TabIndex = 68
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 16)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Ref No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Challan No"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 16)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "CustomerName"
        '
        'txtChallanDate
        '
        Me.txtChallanDate.BackColor = System.Drawing.Color.White
        Me.txtChallanDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChallanDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChallanDate.Location = New System.Drawing.Point(399, 24)
        Me.txtChallanDate.Name = "txtChallanDate"
        Me.txtChallanDate.Size = New System.Drawing.Size(117, 23)
        Me.txtChallanDate.TabIndex = 72
        '
        'gbSelectItem
        '
        Me.gbSelectItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSelectItem.Controls.Add(Me.dgSelectedItem)
        Me.gbSelectItem.Controls.Add(Me.dgSelectItem)
        Me.gbSelectItem.Controls.Add(Me.cmdOk)
        Me.gbSelectItem.Controls.Add(Me.gbQuotation)
        Me.gbSelectItem.Location = New System.Drawing.Point(6, 39)
        Me.gbSelectItem.Name = "gbSelectItem"
        Me.gbSelectItem.Size = New System.Drawing.Size(1003, 581)
        Me.gbSelectItem.TabIndex = 126
        '
        'dgSelectedItem
        '
        Me.dgSelectedItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelectedItem.Location = New System.Drawing.Point(7, 295)
        Me.dgSelectedItem.Name = "dgSelectedItem"
        Me.dgSelectedItem.Size = New System.Drawing.Size(986, 243)
        Me.dgSelectedItem.TabIndex = 13
        '
        'dgSelectItem
        '
        Me.dgSelectItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelectItem.Location = New System.Drawing.Point(7, 50)
        Me.dgSelectItem.Name = "dgSelectItem"
        Me.dgSelectItem.Size = New System.Drawing.Size(986, 236)
        Me.dgSelectItem.TabIndex = 12
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(339, 544)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(119, 31)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'gbQuotation
        '
        Me.gbQuotation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbQuotation.Controls.Add(Me.Label19)
        Me.gbQuotation.Controls.Add(Me.cboSearchItem)
        Me.gbQuotation.Controls.Add(Me.txtSearchItemName)
        Me.gbQuotation.Controls.Add(Me.lblName)
        Me.gbQuotation.Location = New System.Drawing.Point(9, 4)
        Me.gbQuotation.Name = "gbQuotation"
        Me.gbQuotation.Size = New System.Drawing.Size(702, 37)
        Me.gbQuotation.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 7)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Select"
        '
        'cboSearchItem
        '
        Me.cboSearchItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSearchItem.FormattingEnabled = True
        Me.cboSearchItem.Items.AddRange(New Object() {"ItemName", "Category", "Make"})
        Me.cboSearchItem.Location = New System.Drawing.Point(59, 6)
        Me.cboSearchItem.Name = "cboSearchItem"
        Me.cboSearchItem.Size = New System.Drawing.Size(159, 22)
        Me.cboSearchItem.TabIndex = 10
        '
        'txtSearchItemName
        '
        Me.txtSearchItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchItemName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchItemName.Location = New System.Drawing.Point(353, 5)
        Me.txtSearchItemName.Name = "txtSearchItemName"
        Me.txtSearchItemName.Size = New System.Drawing.Size(331, 22)
        Me.txtSearchItemName.TabIndex = 7
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(234, 7)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(72, 14)
        Me.lblName.TabIndex = 9
        Me.lblName.Text = "ItemName"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(4, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 16)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Select"
        '
        'cboSearch
        '
        Me.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch.FormattingEnabled = True
        Me.cboSearch.Items.AddRange(New Object() {"Challan No", "Date", "Customer Name", "Ref No", "Total Value"})
        Me.cboSearch.Location = New System.Drawing.Point(60, 5)
        Me.cboSearch.Name = "cboSearch"
        Me.cboSearch.Size = New System.Drawing.Size(155, 21)
        Me.cboSearch.TabIndex = 11
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(361, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(344, 23)
        Me.txtSearch.TabIndex = 12
        '
        'lblRow
        '
        Me.lblRow.AutoSize = True
        Me.lblRow.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRow.Location = New System.Drawing.Point(221, 8)
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(54, 16)
        Me.lblRow.TabIndex = 13
        Me.lblRow.Text = "Search"
        '
        'gbSearch
        '
        Me.gbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSearch.Controls.Add(Me.dgSearch)
        Me.gbSearch.Controls.Add(Me.gbSearchCustomer)
        Me.gbSearch.Controls.Add(Me.gbSearchInvoice)
        Me.gbSearch.Location = New System.Drawing.Point(6, 39)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(1003, 581)
        Me.gbSearch.TabIndex = 125
        '
        'dgSearch
        '
        Me.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearch.Location = New System.Drawing.Point(5, 51)
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.Size = New System.Drawing.Size(989, 518)
        Me.dgSearch.TabIndex = 16
        '
        'gbSearchCustomer
        '
        Me.gbSearchCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSearchCustomer.Controls.Add(Me.Label3)
        Me.gbSearchCustomer.Controls.Add(Me.lblRowSearch)
        Me.gbSearchCustomer.Controls.Add(Me.cboSearchCustomer)
        Me.gbSearchCustomer.Controls.Add(Me.txtSearchCustomer)
        Me.gbSearchCustomer.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSearchCustomer.Location = New System.Drawing.Point(7, 7)
        Me.gbSearchCustomer.Name = "gbSearchCustomer"
        Me.gbSearchCustomer.Size = New System.Drawing.Size(710, 36)
        Me.gbSearchCustomer.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Select"
        '
        'lblRowSearch
        '
        Me.lblRowSearch.AutoSize = True
        Me.lblRowSearch.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRowSearch.Location = New System.Drawing.Point(221, 8)
        Me.lblRowSearch.Name = "lblRowSearch"
        Me.lblRowSearch.Size = New System.Drawing.Size(50, 14)
        Me.lblRowSearch.TabIndex = 13
        Me.lblRowSearch.Text = "Search"
        '
        'cboSearchCustomer
        '
        Me.cboSearchCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchCustomer.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSearchCustomer.FormattingEnabled = True
        Me.cboSearchCustomer.Items.AddRange(New Object() {"CustomerCode", "CustomerName", "Address", "CityName", "StateName", "PIN"})
        Me.cboSearchCustomer.Location = New System.Drawing.Point(60, 5)
        Me.cboSearchCustomer.Name = "cboSearchCustomer"
        Me.cboSearchCustomer.Size = New System.Drawing.Size(155, 22)
        Me.cboSearchCustomer.TabIndex = 11
        '
        'txtSearchCustomer
        '
        Me.txtSearchCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchCustomer.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchCustomer.Location = New System.Drawing.Point(360, 4)
        Me.txtSearchCustomer.Name = "txtSearchCustomer"
        Me.txtSearchCustomer.Size = New System.Drawing.Size(344, 22)
        Me.txtSearchCustomer.TabIndex = 12
        '
        'gbSearchInvoice
        '
        Me.gbSearchInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSearchInvoice.Controls.Add(Me.Label14)
        Me.gbSearchInvoice.Controls.Add(Me.lblRow)
        Me.gbSearchInvoice.Controls.Add(Me.cboSearch)
        Me.gbSearchInvoice.Controls.Add(Me.txtSearch)
        Me.gbSearchInvoice.Location = New System.Drawing.Point(7, 7)
        Me.gbSearchInvoice.Name = "gbSearchInvoice"
        Me.gbSearchInvoice.Size = New System.Drawing.Size(710, 36)
        Me.gbSearchInvoice.TabIndex = 14
        '
        'frmChallanMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ClientSize = New System.Drawing.Size(1013, 626)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.gbSelectItem)
        Me.Controls.Add(Me.gbSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChallanMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.gbDetail.ResumeLayout(False)
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.gbSelectItem.ResumeLayout(False)
        CType(Me.dgSelectedItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSelectItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbQuotation.ResumeLayout(False)
        Me.gbQuotation.PerformLayout()
        Me.gbSearch.ResumeLayout(False)
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearchCustomer.ResumeLayout(False)
        Me.gbSearchCustomer.PerformLayout()
        Me.gbSearchInvoice.ResumeLayout(False)
        Me.gbSearchInvoice.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents gbMain As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtChallanDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSearchCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPrimaryKey As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtChallanNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents gbDetail As System.Windows.Forms.Panel
    Friend WithEvents cmdDelItem As System.Windows.Forms.Button
    Friend WithEvents cmdAddItem As System.Windows.Forms.Button
    Friend WithEvents gbSelectItem As System.Windows.Forms.Panel
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtSearchItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmdApprove As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTotalValue1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboSearch As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblRow As System.Windows.Forms.Label
    Friend WithEvents gbSearch As System.Windows.Forms.Panel
    Friend WithEvents gbSearchInvoice As System.Windows.Forms.Panel
    Friend WithEvents gbSearchCustomer As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRowSearch As System.Windows.Forms.Label
    Friend WithEvents cboSearchCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearchCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGRNo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQuotationNo As System.Windows.Forms.TextBox
    Friend WithEvents chkQuotation As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchItem As System.Windows.Forms.ComboBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents gbQuotation As System.Windows.Forms.Panel
    Friend WithEvents dgSearch As System.Windows.Forms.DataGridView
    Friend WithEvents dgSelectItem As System.Windows.Forms.DataGridView
    Friend WithEvents dgSelectedItem As System.Windows.Forms.DataGridView
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
End Class
