<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseInvoice1
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtGRNo = New System.Windows.Forms.TextBox
        Me.txtTotalValue1 = New System.Windows.Forms.TextBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.cmdApprove = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgConfiguration = New System.Windows.Forms.DataGridView
        Me.cmdOverhead = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txttotalvalue = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtConfigCode = New System.Windows.Forms.TextBox
        Me.txtNetValue = New System.Windows.Forms.TextBox
        Me.gbDetail = New System.Windows.Forms.Panel
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.cmdDelItem = New System.Windows.Forms.Button
        Me.cmdAddItem = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtChallanNo = New System.Windows.Forms.TextBox
        Me.chkcash = New System.Windows.Forms.CheckBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPurchaseDate = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdSearchSupplier = New System.Windows.Forms.Button
        Me.txtSupplierName = New System.Windows.Forms.TextBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox
        Me.lblPrimaryKey = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.txtPurchaseNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.gbSearch = New System.Windows.Forms.Panel
        Me.dgSearch = New System.Windows.Forms.DataGridView
        Me.gbSearchInvoice = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblRow = New System.Windows.Forms.Label
        Me.cboSearch = New System.Windows.Forms.ComboBox
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.gbSearchCustomer = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblRowSearch = New System.Windows.Forms.Label
        Me.cboSearchCustomer = New System.Windows.Forms.ComboBox
        Me.txtSearchCustomer = New System.Windows.Forms.TextBox
        Me.gbSelectItem = New System.Windows.Forms.Panel
        Me.dgSelectedItem = New System.Windows.Forms.DataGridView
        Me.dgSelectItem = New System.Windows.Forms.DataGridView
        Me.cmdOk = New System.Windows.Forms.Button
        Me.txtSearchItemName = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.gbConfigSearch = New System.Windows.Forms.Panel
        Me.dgConfigSearch = New System.Windows.Forms.DataGridView
        Me.cmdConfigOk = New System.Windows.Forms.Button
        Me.txtConfigurationRemarks = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboConfig = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.gbMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgConfiguration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearchInvoice.SuspendLayout()
        Me.gbSearchCustomer.SuspendLayout()
        Me.gbSelectItem.SuspendLayout()
        CType(Me.dgSelectedItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSelectItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConfigSearch.SuspendLayout()
        CType(Me.dgConfigSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Green
        Me.TextBox1.Location = New System.Drawing.Point(-2, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(1016, 33)
        Me.TextBox1.TabIndex = 124
        Me.TextBox1.Text = "Purchase Invoice 1"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbMain
        '
        Me.gbMain.BackColor = System.Drawing.Color.Transparent
        Me.gbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbMain.Controls.Add(Me.Label7)
        Me.gbMain.Controls.Add(Me.txtGRNo)
        Me.gbMain.Controls.Add(Me.txtTotalValue1)
        Me.gbMain.Controls.Add(Me.dtpDate)
        Me.gbMain.Controls.Add(Me.cmdApprove)
        Me.gbMain.Controls.Add(Me.Panel2)
        Me.gbMain.Controls.Add(Me.Label13)
        Me.gbMain.Controls.Add(Me.Label12)
        Me.gbMain.Controls.Add(Me.txttotalvalue)
        Me.gbMain.Controls.Add(Me.Label8)
        Me.gbMain.Controls.Add(Me.txtConfigCode)
        Me.gbMain.Controls.Add(Me.txtNetValue)
        Me.gbMain.Controls.Add(Me.gbDetail)
        Me.gbMain.Controls.Add(Me.Label4)
        Me.gbMain.Controls.Add(Me.txtChallanNo)
        Me.gbMain.Controls.Add(Me.chkcash)
        Me.gbMain.Controls.Add(Me.Label15)
        Me.gbMain.Controls.Add(Me.Panel1)
        Me.gbMain.Controls.Add(Me.txtAddress)
        Me.gbMain.Controls.Add(Me.Label2)
        Me.gbMain.Controls.Add(Me.txtPurchaseDate)
        Me.gbMain.Controls.Add(Me.Label1)
        Me.gbMain.Controls.Add(Me.cmdSearchSupplier)
        Me.gbMain.Controls.Add(Me.txtSupplierName)
        Me.gbMain.Controls.Add(Me.cmdSearch)
        Me.gbMain.Controls.Add(Me.txtInvoiceNo)
        Me.gbMain.Controls.Add(Me.lblPrimaryKey)
        Me.gbMain.Controls.Add(Me.txtRemarks)
        Me.gbMain.Controls.Add(Me.txtPurchaseNo)
        Me.gbMain.Controls.Add(Me.Label10)
        Me.gbMain.Controls.Add(Me.Label9)
        Me.gbMain.Controls.Add(Me.Label11)
        Me.gbMain.Location = New System.Drawing.Point(6, 39)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(1003, 581)
        Me.gbMain.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(789, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 16)
        Me.Label7.TabIndex = 130
        Me.Label7.Text = "GR No"
        '
        'txtGRNo
        '
        Me.txtGRNo.BackColor = System.Drawing.Color.White
        Me.txtGRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGRNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGRNo.Location = New System.Drawing.Point(854, 87)
        Me.txtGRNo.Name = "txtGRNo"
        Me.txtGRNo.Size = New System.Drawing.Size(133, 23)
        Me.txtGRNo.TabIndex = 129
        '
        'txtTotalValue1
        '
        Me.txtTotalValue1.BackColor = System.Drawing.Color.White
        Me.txtTotalValue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalValue1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalValue1.Location = New System.Drawing.Point(651, 326)
        Me.txtTotalValue1.Name = "txtTotalValue1"
        Me.txtTotalValue1.Size = New System.Drawing.Size(11, 23)
        Me.txtTotalValue1.TabIndex = 128
        Me.txtTotalValue1.Visible = False
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(392, 15)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(117, 23)
        Me.dtpDate.TabIndex = 1
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
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgConfiguration)
        Me.Panel2.Controls.Add(Me.cmdOverhead)
        Me.Panel2.Location = New System.Drawing.Point(11, 364)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(983, 149)
        Me.Panel2.TabIndex = 84
        '
        'dgConfiguration
        '
        Me.dgConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgConfiguration.Location = New System.Drawing.Point(6, 5)
        Me.dgConfiguration.Name = "dgConfiguration"
        Me.dgConfiguration.Size = New System.Drawing.Size(900, 138)
        Me.dgConfiguration.TabIndex = 51
        '
        'cmdOverhead
        '
        Me.cmdOverhead.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOverhead.Location = New System.Drawing.Point(918, 41)
        Me.cmdOverhead.Name = "cmdOverhead"
        Me.cmdOverhead.Size = New System.Drawing.Size(57, 56)
        Me.cmdOverhead.TabIndex = 8
        Me.cmdOverhead.Text = "&Over Head"
        Me.cmdOverhead.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(395, 333)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(133, 16)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Configuration Code"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(193, 329)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 16)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "TotalValue"
        '
        'txttotalvalue
        '
        Me.txttotalvalue.BackColor = System.Drawing.Color.White
        Me.txttotalvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotalvalue.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalvalue.Location = New System.Drawing.Point(272, 326)
        Me.txttotalvalue.Name = "txttotalvalue"
        Me.txttotalvalue.Size = New System.Drawing.Size(117, 23)
        Me.txttotalvalue.TabIndex = 81
        Me.txttotalvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 329)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 16)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "NetValue"
        '
        'txtConfigCode
        '
        Me.txtConfigCode.BackColor = System.Drawing.Color.White
        Me.txtConfigCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfigCode.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfigCode.Location = New System.Drawing.Point(529, 326)
        Me.txtConfigCode.Name = "txtConfigCode"
        Me.txtConfigCode.Size = New System.Drawing.Size(105, 23)
        Me.txtConfigCode.TabIndex = 79
        '
        'txtNetValue
        '
        Me.txtNetValue.BackColor = System.Drawing.Color.White
        Me.txtNetValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNetValue.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetValue.Location = New System.Drawing.Point(79, 326)
        Me.txtNetValue.Name = "txtNetValue"
        Me.txtNetValue.Size = New System.Drawing.Size(99, 23)
        Me.txtNetValue.TabIndex = 78
        Me.txtNetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbDetail
        '
        Me.gbDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbDetail.Controls.Add(Me.dgDetail)
        Me.gbDetail.Controls.Add(Me.cmdDelItem)
        Me.gbDetail.Controls.Add(Me.cmdAddItem)
        Me.gbDetail.Location = New System.Drawing.Point(6, 119)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(988, 201)
        Me.gbDetail.TabIndex = 77
        '
        'dgDetail
        '
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Location = New System.Drawing.Point(5, 3)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.Size = New System.Drawing.Size(906, 192)
        Me.dgDetail.TabIndex = 509
        '
        'cmdDelItem
        '
        Me.cmdDelItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelItem.Location = New System.Drawing.Point(919, 115)
        Me.cmdDelItem.Name = "cmdDelItem"
        Me.cmdDelItem.Size = New System.Drawing.Size(61, 56)
        Me.cmdDelItem.TabIndex = 7
        Me.cmdDelItem.Text = "&Delete Item"
        Me.cmdDelItem.UseVisualStyleBackColor = True
        '
        'cmdAddItem
        '
        Me.cmdAddItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddItem.Location = New System.Drawing.Point(919, 38)
        Me.cmdAddItem.Name = "cmdAddItem"
        Me.cmdAddItem.Size = New System.Drawing.Size(61, 56)
        Me.cmdAddItem.TabIndex = 6
        Me.cmdAddItem.Text = "&Add Item"
        Me.cmdAddItem.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(575, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 16)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Challan No"
        '
        'txtChallanNo
        '
        Me.txtChallanNo.BackColor = System.Drawing.Color.White
        Me.txtChallanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChallanNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChallanNo.Location = New System.Drawing.Point(659, 88)
        Me.txtChallanNo.Name = "txtChallanNo"
        Me.txtChallanNo.Size = New System.Drawing.Size(114, 23)
        Me.txtChallanNo.TabIndex = 5
        '
        'chkcash
        '
        Me.chkcash.AutoSize = True
        Me.chkcash.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkcash.Location = New System.Drawing.Point(5, 15)
        Me.chkcash.Name = "chkcash"
        Me.chkcash.Size = New System.Drawing.Size(59, 20)
        Me.chkcash.TabIndex = 74
        Me.chkcash.Text = "Cash"
        Me.chkcash.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(515, 18)
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
        Me.cmdPrint.Text = "&Exit"
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
        Me.txtAddress.Location = New System.Drawing.Point(578, 13)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(416, 60)
        Me.txtAddress.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(326, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "P.I.Date"
        '
        'txtPurchaseDate
        '
        Me.txtPurchaseDate.BackColor = System.Drawing.Color.White
        Me.txtPurchaseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurchaseDate.Location = New System.Drawing.Point(392, 15)
        Me.txtPurchaseDate.Name = "txtPurchaseDate"
        Me.txtPurchaseDate.Size = New System.Drawing.Size(117, 23)
        Me.txtPurchaseDate.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Remarks"
        '
        'cmdSearchSupplier
        '
        Me.cmdSearchSupplier.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearchSupplier.Location = New System.Drawing.Point(515, 49)
        Me.cmdSearchSupplier.Name = "cmdSearchSupplier"
        Me.cmdSearchSupplier.Size = New System.Drawing.Size(30, 23)
        Me.cmdSearchSupplier.TabIndex = 2
        Me.cmdSearchSupplier.Text = "........&N"
        Me.cmdSearchSupplier.UseVisualStyleBackColor = True
        '
        'txtSupplierName
        '
        Me.txtSupplierName.BackColor = System.Drawing.Color.White
        Me.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplierName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierName.Location = New System.Drawing.Point(124, 48)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.Size = New System.Drawing.Size(385, 23)
        Me.txtSupplierName.TabIndex = 60
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(277, 13)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(41, 27)
        Me.cmdSearch.TabIndex = 70
        Me.cmdSearch.Text = "?"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.Location = New System.Drawing.Point(410, 87)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(130, 23)
        Me.txtInvoiceNo.TabIndex = 4
        '
        'lblPrimaryKey
        '
        Me.lblPrimaryKey.AutoSize = True
        Me.lblPrimaryKey.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimaryKey.Location = New System.Drawing.Point(269, 69)
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
        Me.txtRemarks.Location = New System.Drawing.Point(124, 84)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(194, 23)
        Me.txtRemarks.TabIndex = 3
        '
        'txtPurchaseNo
        '
        Me.txtPurchaseNo.BackColor = System.Drawing.Color.White
        Me.txtPurchaseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurchaseNo.Location = New System.Drawing.Point(124, 15)
        Me.txtPurchaseNo.Name = "txtPurchaseNo"
        Me.txtPurchaseNo.Size = New System.Drawing.Size(147, 23)
        Me.txtPurchaseNo.TabIndex = 68
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(326, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 16)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Invoice No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(65, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "P.I.No"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 16)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "Supplier Name"
        '
        'gbSearch
        '
        Me.gbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSearch.Controls.Add(Me.dgSearch)
        Me.gbSearch.Controls.Add(Me.gbSearchInvoice)
        Me.gbSearch.Controls.Add(Me.gbSearchCustomer)
        Me.gbSearch.Location = New System.Drawing.Point(6, 39)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(1003, 581)
        Me.gbSearch.TabIndex = 125
        '
        'dgSearch
        '
        Me.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearch.Location = New System.Drawing.Point(7, 50)
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.Size = New System.Drawing.Size(987, 521)
        Me.dgSearch.TabIndex = 19
        '
        'gbSearchInvoice
        '
        Me.gbSearchInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSearchInvoice.Controls.Add(Me.Label14)
        Me.gbSearchInvoice.Controls.Add(Me.lblRow)
        Me.gbSearchInvoice.Controls.Add(Me.cboSearch)
        Me.gbSearchInvoice.Controls.Add(Me.txtSearch)
        Me.gbSearchInvoice.Location = New System.Drawing.Point(8, 7)
        Me.gbSearchInvoice.Name = "gbSearchInvoice"
        Me.gbSearchInvoice.Size = New System.Drawing.Size(609, 36)
        Me.gbSearchInvoice.TabIndex = 16
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
        'cboSearch
        '
        Me.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch.FormattingEnabled = True
        Me.cboSearch.Items.AddRange(New Object() {"PI No", "PI Date", "Supplier Name", "Invoice No", "Challan No", "Total Value"})
        Me.cboSearch.Location = New System.Drawing.Point(60, 5)
        Me.cboSearch.Name = "cboSearch"
        Me.cboSearch.Size = New System.Drawing.Size(155, 21)
        Me.cboSearch.TabIndex = 11
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(351, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(251, 23)
        Me.txtSearch.TabIndex = 12
        '
        'gbSearchCustomer
        '
        Me.gbSearchCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSearchCustomer.Controls.Add(Me.Label3)
        Me.gbSearchCustomer.Controls.Add(Me.lblRowSearch)
        Me.gbSearchCustomer.Controls.Add(Me.cboSearchCustomer)
        Me.gbSearchCustomer.Controls.Add(Me.txtSearchCustomer)
        Me.gbSearchCustomer.Location = New System.Drawing.Point(8, 7)
        Me.gbSearchCustomer.Name = "gbSearchCustomer"
        Me.gbSearchCustomer.Size = New System.Drawing.Size(609, 36)
        Me.gbSearchCustomer.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Select"
        '
        'lblRowSearch
        '
        Me.lblRowSearch.AutoSize = True
        Me.lblRowSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRowSearch.Location = New System.Drawing.Point(221, 8)
        Me.lblRowSearch.Name = "lblRowSearch"
        Me.lblRowSearch.Size = New System.Drawing.Size(54, 16)
        Me.lblRowSearch.TabIndex = 13
        Me.lblRowSearch.Text = "Search"
        '
        'cboSearchCustomer
        '
        Me.cboSearchCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchCustomer.FormattingEnabled = True
        Me.cboSearchCustomer.Items.AddRange(New Object() {"Code", "Supplier Name", "Address", "City", "State", "PIN"})
        Me.cboSearchCustomer.Location = New System.Drawing.Point(60, 5)
        Me.cboSearchCustomer.Name = "cboSearchCustomer"
        Me.cboSearchCustomer.Size = New System.Drawing.Size(155, 21)
        Me.cboSearchCustomer.TabIndex = 11
        '
        'txtSearchCustomer
        '
        Me.txtSearchCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchCustomer.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchCustomer.Location = New System.Drawing.Point(341, 4)
        Me.txtSearchCustomer.Name = "txtSearchCustomer"
        Me.txtSearchCustomer.Size = New System.Drawing.Size(261, 23)
        Me.txtSearchCustomer.TabIndex = 12
        '
        'gbSelectItem
        '
        Me.gbSelectItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSelectItem.Controls.Add(Me.dgSelectedItem)
        Me.gbSelectItem.Controls.Add(Me.dgSelectItem)
        Me.gbSelectItem.Controls.Add(Me.cmdOk)
        Me.gbSelectItem.Controls.Add(Me.txtSearchItemName)
        Me.gbSelectItem.Controls.Add(Me.Label19)
        Me.gbSelectItem.Location = New System.Drawing.Point(6, 39)
        Me.gbSelectItem.Name = "gbSelectItem"
        Me.gbSelectItem.Size = New System.Drawing.Size(1003, 581)
        Me.gbSelectItem.TabIndex = 126
        '
        'dgSelectedItem
        '
        Me.dgSelectedItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelectedItem.Location = New System.Drawing.Point(7, 301)
        Me.dgSelectedItem.Name = "dgSelectedItem"
        Me.dgSelectedItem.Size = New System.Drawing.Size(987, 236)
        Me.dgSelectedItem.TabIndex = 13
        '
        'dgSelectItem
        '
        Me.dgSelectItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelectItem.Location = New System.Drawing.Point(6, 47)
        Me.dgSelectItem.Name = "dgSelectItem"
        Me.dgSelectItem.Size = New System.Drawing.Size(988, 247)
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
        'txtSearchItemName
        '
        Me.txtSearchItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchItemName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchItemName.Location = New System.Drawing.Point(101, 15)
        Me.txtSearchItemName.Name = "txtSearchItemName"
        Me.txtSearchItemName.Size = New System.Drawing.Size(277, 23)
        Me.txtSearchItemName.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(11, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 16)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Item Name"
        '
        'gbConfigSearch
        '
        Me.gbConfigSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbConfigSearch.Controls.Add(Me.dgConfigSearch)
        Me.gbConfigSearch.Controls.Add(Me.cmdConfigOk)
        Me.gbConfigSearch.Controls.Add(Me.txtConfigurationRemarks)
        Me.gbConfigSearch.Controls.Add(Me.Label6)
        Me.gbConfigSearch.Controls.Add(Me.cboConfig)
        Me.gbConfigSearch.Controls.Add(Me.Label5)
        Me.gbConfigSearch.Location = New System.Drawing.Point(325, 209)
        Me.gbConfigSearch.Name = "gbConfigSearch"
        Me.gbConfigSearch.Size = New System.Drawing.Size(456, 407)
        Me.gbConfigSearch.TabIndex = 127
        '
        'dgConfigSearch
        '
        Me.dgConfigSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgConfigSearch.Location = New System.Drawing.Point(9, 80)
        Me.dgConfigSearch.Name = "dgConfigSearch"
        Me.dgConfigSearch.Size = New System.Drawing.Size(437, 291)
        Me.dgConfigSearch.TabIndex = 57
        '
        'cmdConfigOk
        '
        Me.cmdConfigOk.Location = New System.Drawing.Point(210, 379)
        Me.cmdConfigOk.Name = "cmdConfigOk"
        Me.cmdConfigOk.Size = New System.Drawing.Size(46, 23)
        Me.cmdConfigOk.TabIndex = 56
        Me.cmdConfigOk.Text = "OK"
        Me.cmdConfigOk.UseVisualStyleBackColor = True
        '
        'txtConfigurationRemarks
        '
        Me.txtConfigurationRemarks.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfigurationRemarks.Location = New System.Drawing.Point(95, 47)
        Me.txtConfigurationRemarks.Name = "txtConfigurationRemarks"
        Me.txtConfigurationRemarks.Size = New System.Drawing.Size(305, 23)
        Me.txtConfigurationRemarks.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 16)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Remarks"
        '
        'cboConfig
        '
        Me.cboConfig.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConfig.FormattingEnabled = True
        Me.cboConfig.Location = New System.Drawing.Point(95, 7)
        Me.cboConfig.Name = "cboConfig"
        Me.cboConfig.Size = New System.Drawing.Size(188, 24)
        Me.cboConfig.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 16)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "TAX Code"
        '
        'frmPurchaseInvoice1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ClientSize = New System.Drawing.Size(1013, 626)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.gbConfigSearch)
        Me.Controls.Add(Me.gbSelectItem)
        Me.Controls.Add(Me.gbSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPurchaseInvoice1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgConfiguration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetail.ResumeLayout(False)
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.gbSearch.ResumeLayout(False)
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearchInvoice.ResumeLayout(False)
        Me.gbSearchInvoice.PerformLayout()
        Me.gbSearchCustomer.ResumeLayout(False)
        Me.gbSearchCustomer.PerformLayout()
        Me.gbSelectItem.ResumeLayout(False)
        Me.gbSelectItem.PerformLayout()
        CType(Me.dgSelectedItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSelectItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConfigSearch.ResumeLayout(False)
        Me.gbConfigSearch.PerformLayout()
        CType(Me.dgConfigSearch, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gbSearch As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtChallanNo As System.Windows.Forms.TextBox
    Friend WithEvents chkcash As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPurchaseDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSearchSupplier As System.Windows.Forms.Button
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPrimaryKey As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtPurchaseNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents gbDetail As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txttotalvalue As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtConfigCode As System.Windows.Forms.TextBox
    Friend WithEvents txtNetValue As System.Windows.Forms.TextBox
    Friend WithEvents cmdDelItem As System.Windows.Forms.Button
    Friend WithEvents cmdAddItem As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdOverhead As System.Windows.Forms.Button
    Friend WithEvents gbSelectItem As System.Windows.Forms.Panel
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtSearchItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmdApprove As System.Windows.Forms.Button
    Friend WithEvents gbConfigSearch As System.Windows.Forms.Panel
    Friend WithEvents txtConfigurationRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboConfig As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdConfigOk As System.Windows.Forms.Button
    Friend WithEvents txtTotalValue1 As System.Windows.Forms.TextBox
    Friend WithEvents gbSearchCustomer As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRowSearch As System.Windows.Forms.Label
    Friend WithEvents cboSearchCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearchCustomer As System.Windows.Forms.TextBox
    Friend WithEvents gbSearchInvoice As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblRow As System.Windows.Forms.Label
    Friend WithEvents cboSearch As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGRNo As System.Windows.Forms.TextBox
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents dgConfiguration As System.Windows.Forms.DataGridView
    Friend WithEvents dgConfigSearch As System.Windows.Forms.DataGridView
    Friend WithEvents dgSelectItem As System.Windows.Forms.DataGridView
    Friend WithEvents dgSelectedItem As System.Windows.Forms.DataGridView
    Friend WithEvents dgSearch As System.Windows.Forms.DataGridView
End Class