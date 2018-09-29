<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceipt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReceipt))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.gbMain = New System.Windows.Forms.Panel
        Me.gbBankTransfer = New System.Windows.Forms.Panel
        Me.txtBankBalance1 = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtAccNo1 = New System.Windows.Forms.TextBox
        Me.txtAmounttransfer = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtPartyBankName = New System.Windows.Forms.TextBox
        Me.txtBranch1 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtBankName1 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboAccNo1 = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtPartyBankBranch = New System.Windows.Forms.TextBox
        Me.txtPartyAccNo = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.cmdApprove = New System.Windows.Forms.Button
        Me.gbCheque = New System.Windows.Forms.Panel
        Me.txtBankBalance = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtChequeDate = New System.Windows.Forms.TextBox
        Me.txtAccNo = New System.Windows.Forms.TextBox
        Me.txtBranch = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtBankName = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboAccNo = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpChequeDate = New System.Windows.Forms.DateTimePicker
        Me.txtChequeAmount = New System.Windows.Forms.TextBox
        Me.txtChequeNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.gbCash = New System.Windows.Forms.Panel
        Me.txtCashBalance = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtCashAmount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblPrimaryKey = New System.Windows.Forms.Label
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.gbMode = New System.Windows.Forms.Panel
        Me.optBankTransfer = New System.Windows.Forms.RadioButton
        Me.optCash = New System.Windows.Forms.RadioButton
        Me.optCheque = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBalance = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtdate = New System.Windows.Forms.TextBox
        Me.cmdSearchCustomer = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.txtReceiptNo = New System.Windows.Forms.TextBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.txtCustomerName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.gbSearch = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtSearchName = New System.Windows.Forms.TextBox
        Me.fgSearch = New AxVSFlex7L.AxVSFlexGrid
        Me.txtBankCode = New System.Windows.Forms.TextBox
        Me.gbMain.SuspendLayout()
        Me.gbBankTransfer.SuspendLayout()
        Me.gbCheque.SuspendLayout()
        Me.gbCash.SuspendLayout()
        Me.gbMode.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        CType(Me.fgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TextBox1.Size = New System.Drawing.Size(728, 38)
        Me.TextBox1.TabIndex = 124
        Me.TextBox1.Text = "Receipt"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbMain
        '
        Me.gbMain.BackColor = System.Drawing.Color.Transparent
        Me.gbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbMain.Controls.Add(Me.gbCheque)
        Me.gbMain.Controls.Add(Me.gbBankTransfer)
        Me.gbMain.Controls.Add(Me.cmdApprove)
        Me.gbMain.Controls.Add(Me.gbCash)
        Me.gbMain.Controls.Add(Me.Label9)
        Me.gbMain.Controls.Add(Me.Label11)
        Me.gbMain.Controls.Add(Me.lblPrimaryKey)
        Me.gbMain.Controls.Add(Me.dtpDate)
        Me.gbMain.Controls.Add(Me.Label4)
        Me.gbMain.Controls.Add(Me.gbMode)
        Me.gbMain.Controls.Add(Me.Label2)
        Me.gbMain.Controls.Add(Me.txtBalance)
        Me.gbMain.Controls.Add(Me.Label27)
        Me.gbMain.Controls.Add(Me.Label15)
        Me.gbMain.Controls.Add(Me.txtAddress)
        Me.gbMain.Controls.Add(Me.txtdate)
        Me.gbMain.Controls.Add(Me.cmdSearchCustomer)
        Me.gbMain.Controls.Add(Me.cmdSearch)
        Me.gbMain.Controls.Add(Me.txtReceiptNo)
        Me.gbMain.Controls.Add(Me.txtRemarks)
        Me.gbMain.Controls.Add(Me.txtCustomerName)
        Me.gbMain.Controls.Add(Me.Label1)
        Me.gbMain.Controls.Add(Me.Panel1)
        Me.gbMain.Location = New System.Drawing.Point(6, 39)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(710, 486)
        Me.gbMain.TabIndex = 1
        '
        'gbBankTransfer
        '
        Me.gbBankTransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbBankTransfer.Controls.Add(Me.txtBankBalance1)
        Me.gbBankTransfer.Controls.Add(Me.Label29)
        Me.gbBankTransfer.Controls.Add(Me.txtAccNo1)
        Me.gbBankTransfer.Controls.Add(Me.txtAmounttransfer)
        Me.gbBankTransfer.Controls.Add(Me.Label26)
        Me.gbBankTransfer.Controls.Add(Me.txtPartyBankName)
        Me.gbBankTransfer.Controls.Add(Me.txtBranch1)
        Me.gbBankTransfer.Controls.Add(Me.Label20)
        Me.gbBankTransfer.Controls.Add(Me.txtBankName1)
        Me.gbBankTransfer.Controls.Add(Me.Label21)
        Me.gbBankTransfer.Controls.Add(Me.cboAccNo1)
        Me.gbBankTransfer.Controls.Add(Me.Label22)
        Me.gbBankTransfer.Controls.Add(Me.txtPartyBankBranch)
        Me.gbBankTransfer.Controls.Add(Me.txtPartyAccNo)
        Me.gbBankTransfer.Controls.Add(Me.Label23)
        Me.gbBankTransfer.Controls.Add(Me.Label24)
        Me.gbBankTransfer.Controls.Add(Me.Label25)
        Me.gbBankTransfer.Location = New System.Drawing.Point(2, 233)
        Me.gbBankTransfer.Name = "gbBankTransfer"
        Me.gbBankTransfer.Size = New System.Drawing.Size(696, 192)
        Me.gbBankTransfer.TabIndex = 73
        '
        'txtBankBalance1
        '
        Me.txtBankBalance1.BackColor = System.Drawing.Color.White
        Me.txtBankBalance1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankBalance1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankBalance1.Location = New System.Drawing.Point(102, 158)
        Me.txtBankBalance1.Name = "txtBankBalance1"
        Me.txtBankBalance1.ReadOnly = True
        Me.txtBankBalance1.Size = New System.Drawing.Size(113, 23)
        Me.txtBankBalance1.TabIndex = 69
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(8, 162)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(90, 16)
        Me.Label29.TabIndex = 68
        Me.Label29.Text = "BankBalance"
        '
        'txtAccNo1
        '
        Me.txtAccNo1.BackColor = System.Drawing.Color.White
        Me.txtAccNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccNo1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccNo1.Location = New System.Drawing.Point(102, 11)
        Me.txtAccNo1.Name = "txtAccNo1"
        Me.txtAccNo1.Size = New System.Drawing.Size(194, 23)
        Me.txtAccNo1.TabIndex = 67
        '
        'txtAmounttransfer
        '
        Me.txtAmounttransfer.BackColor = System.Drawing.Color.White
        Me.txtAmounttransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmounttransfer.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmounttransfer.Location = New System.Drawing.Point(387, 155)
        Me.txtAmounttransfer.Name = "txtAmounttransfer"
        Me.txtAmounttransfer.Size = New System.Drawing.Size(194, 23)
        Me.txtAmounttransfer.TabIndex = 59
        Me.txtAmounttransfer.Text = "0.00"
        Me.txtAmounttransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(241, 158)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(118, 16)
        Me.Label26.TabIndex = 66
        Me.Label26.Text = "Amount Transfer"
        '
        'txtPartyBankName
        '
        Me.txtPartyBankName.BackColor = System.Drawing.Color.White
        Me.txtPartyBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartyBankName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartyBankName.Location = New System.Drawing.Point(472, 61)
        Me.txtPartyBankName.Name = "txtPartyBankName"
        Me.txtPartyBankName.Size = New System.Drawing.Size(203, 23)
        Me.txtPartyBankName.TabIndex = 55
        '
        'txtBranch1
        '
        Me.txtBranch1.BackColor = System.Drawing.Color.White
        Me.txtBranch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranch1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch1.Location = New System.Drawing.Point(102, 117)
        Me.txtBranch1.Name = "txtBranch1"
        Me.txtBranch1.Size = New System.Drawing.Size(194, 23)
        Me.txtBranch1.TabIndex = 65
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 122)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 16)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "Branch"
        '
        'txtBankName1
        '
        Me.txtBankName1.BackColor = System.Drawing.Color.White
        Me.txtBankName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankName1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankName1.Location = New System.Drawing.Point(102, 64)
        Me.txtBankName1.Name = "txtBankName1"
        Me.txtBankName1.Size = New System.Drawing.Size(194, 23)
        Me.txtBankName1.TabIndex = 63
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 71)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(75, 16)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "BankName"
        '
        'cboAccNo1
        '
        Me.cboAccNo1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAccNo1.FormattingEnabled = True
        Me.cboAccNo1.Location = New System.Drawing.Point(102, 10)
        Me.cboAccNo1.Name = "cboAccNo1"
        Me.cboAccNo1.Size = New System.Drawing.Size(194, 24)
        Me.cboAccNo1.TabIndex = 60
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(8, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(85, 16)
        Me.Label22.TabIndex = 61
        Me.Label22.Text = "Account No"
        '
        'txtPartyBankBranch
        '
        Me.txtPartyBankBranch.BackColor = System.Drawing.Color.White
        Me.txtPartyBankBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartyBankBranch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartyBankBranch.Location = New System.Drawing.Point(472, 111)
        Me.txtPartyBankBranch.Name = "txtPartyBankBranch"
        Me.txtPartyBankBranch.Size = New System.Drawing.Size(203, 23)
        Me.txtPartyBankBranch.TabIndex = 57
        '
        'txtPartyAccNo
        '
        Me.txtPartyAccNo.BackColor = System.Drawing.Color.White
        Me.txtPartyAccNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartyAccNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartyAccNo.Location = New System.Drawing.Point(472, 12)
        Me.txtPartyAccNo.Name = "txtPartyAccNo"
        Me.txtPartyAccNo.Size = New System.Drawing.Size(203, 23)
        Me.txtPartyAccNo.TabIndex = 53
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(330, 118)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(129, 16)
        Me.Label23.TabIndex = 58
        Me.Label23.Text = "Party Bank Branch"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(330, 66)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(120, 16)
        Me.Label24.TabIndex = 56
        Me.Label24.Text = "Party Bank Name"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(330, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(125, 16)
        Me.Label25.TabIndex = 54
        Me.Label25.Text = "Party Account No"
        '
        'cmdApprove
        '
        Me.cmdApprove.Location = New System.Drawing.Point(336, 442)
        Me.cmdApprove.Name = "cmdApprove"
        Me.cmdApprove.Size = New System.Drawing.Size(80, 26)
        Me.cmdApprove.TabIndex = 127
        Me.cmdApprove.Text = "Approve"
        Me.cmdApprove.UseVisualStyleBackColor = True
        '
        'gbCheque
        '
        Me.gbCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbCheque.Controls.Add(Me.txtBankCode)
        Me.gbCheque.Controls.Add(Me.txtBankBalance)
        Me.gbCheque.Controls.Add(Me.Label28)
        Me.gbCheque.Controls.Add(Me.txtChequeDate)
        Me.gbCheque.Controls.Add(Me.txtAccNo)
        Me.gbCheque.Controls.Add(Me.txtBranch)
        Me.gbCheque.Controls.Add(Me.Label19)
        Me.gbCheque.Controls.Add(Me.txtBankName)
        Me.gbCheque.Controls.Add(Me.Label13)
        Me.gbCheque.Controls.Add(Me.cboAccNo)
        Me.gbCheque.Controls.Add(Me.Label12)
        Me.gbCheque.Controls.Add(Me.dtpChequeDate)
        Me.gbCheque.Controls.Add(Me.txtChequeAmount)
        Me.gbCheque.Controls.Add(Me.txtChequeNo)
        Me.gbCheque.Controls.Add(Me.Label10)
        Me.gbCheque.Controls.Add(Me.Label8)
        Me.gbCheque.Controls.Add(Me.Label6)
        Me.gbCheque.Location = New System.Drawing.Point(2, 233)
        Me.gbCheque.Name = "gbCheque"
        Me.gbCheque.Size = New System.Drawing.Size(696, 192)
        Me.gbCheque.TabIndex = 72
        '
        'txtBankBalance
        '
        Me.txtBankBalance.BackColor = System.Drawing.Color.White
        Me.txtBankBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankBalance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankBalance.Location = New System.Drawing.Point(480, 112)
        Me.txtBankBalance.Name = "txtBankBalance"
        Me.txtBankBalance.ReadOnly = True
        Me.txtBankBalance.Size = New System.Drawing.Size(197, 23)
        Me.txtBankBalance.TabIndex = 65
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(383, 112)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(90, 16)
        Me.Label28.TabIndex = 64
        Me.Label28.Text = "BankBalance"
        '
        'txtChequeDate
        '
        Me.txtChequeDate.BackColor = System.Drawing.Color.White
        Me.txtChequeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChequeDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequeDate.Location = New System.Drawing.Point(158, 105)
        Me.txtChequeDate.Name = "txtChequeDate"
        Me.txtChequeDate.Size = New System.Drawing.Size(175, 23)
        Me.txtChequeDate.TabIndex = 56
        '
        'txtAccNo
        '
        Me.txtAccNo.BackColor = System.Drawing.Color.White
        Me.txtAccNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccNo.Location = New System.Drawing.Point(158, 11)
        Me.txtAccNo.Name = "txtAccNo"
        Me.txtAccNo.Size = New System.Drawing.Size(175, 23)
        Me.txtAccNo.TabIndex = 63
        '
        'txtBranch
        '
        Me.txtBranch.BackColor = System.Drawing.Color.White
        Me.txtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.Location = New System.Drawing.Point(480, 60)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(197, 23)
        Me.txtBranch.TabIndex = 62
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(383, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 16)
        Me.Label19.TabIndex = 61
        Me.Label19.Text = "Branch"
        '
        'txtBankName
        '
        Me.txtBankName.BackColor = System.Drawing.Color.White
        Me.txtBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankName.Location = New System.Drawing.Point(480, 11)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(197, 23)
        Me.txtBankName.TabIndex = 60
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(383, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 16)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "BankName"
        '
        'cboAccNo
        '
        Me.cboAccNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAccNo.FormattingEnabled = True
        Me.cboAccNo.Location = New System.Drawing.Point(158, 10)
        Me.cboAccNo.Name = "cboAccNo"
        Me.cboAccNo.Size = New System.Drawing.Size(175, 24)
        Me.cboAccNo.TabIndex = 50
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 16)
        Me.Label12.TabIndex = 58
        Me.Label12.Text = "Account No"
        '
        'dtpChequeDate
        '
        Me.dtpChequeDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpChequeDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChequeDate.Location = New System.Drawing.Point(158, 104)
        Me.dtpChequeDate.Name = "dtpChequeDate"
        Me.dtpChequeDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpChequeDate.TabIndex = 55
        '
        'txtChequeAmount
        '
        Me.txtChequeAmount.BackColor = System.Drawing.Color.White
        Me.txtChequeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChequeAmount.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequeAmount.Location = New System.Drawing.Point(158, 151)
        Me.txtChequeAmount.Name = "txtChequeAmount"
        Me.txtChequeAmount.Size = New System.Drawing.Size(175, 23)
        Me.txtChequeAmount.TabIndex = 57
        Me.txtChequeAmount.Text = "0.00"
        Me.txtChequeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtChequeNo
        '
        Me.txtChequeNo.BackColor = System.Drawing.Color.White
        Me.txtChequeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChequeNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequeNo.Location = New System.Drawing.Point(158, 55)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(175, 23)
        Me.txtChequeNo.TabIndex = 54
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 158)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 16)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Cheque Amount"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 16)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Cheque Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 16)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Cheque No"
        '
        'gbCash
        '
        Me.gbCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbCash.Controls.Add(Me.txtCashBalance)
        Me.gbCash.Controls.Add(Me.Label30)
        Me.gbCash.Controls.Add(Me.txtCashAmount)
        Me.gbCash.Controls.Add(Me.Label5)
        Me.gbCash.Location = New System.Drawing.Point(2, 233)
        Me.gbCash.Name = "gbCash"
        Me.gbCash.Size = New System.Drawing.Size(697, 192)
        Me.gbCash.TabIndex = 82
        '
        'txtCashBalance
        '
        Me.txtCashBalance.BackColor = System.Drawing.Color.White
        Me.txtCashBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCashBalance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashBalance.Location = New System.Drawing.Point(294, 49)
        Me.txtCashBalance.Name = "txtCashBalance"
        Me.txtCashBalance.ReadOnly = True
        Me.txtCashBalance.Size = New System.Drawing.Size(164, 23)
        Me.txtCashBalance.TabIndex = 71
        Me.txtCashBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(193, 52)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(59, 16)
        Me.Label30.TabIndex = 70
        Me.Label30.Text = "Balance"
        '
        'txtCashAmount
        '
        Me.txtCashAmount.BackColor = System.Drawing.Color.White
        Me.txtCashAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCashAmount.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashAmount.Location = New System.Drawing.Point(294, 92)
        Me.txtCashAmount.Name = "txtCashAmount"
        Me.txtCashAmount.Size = New System.Drawing.Size(164, 23)
        Me.txtCashAmount.TabIndex = 69
        Me.txtCashAmount.Text = "0.00"
        Me.txtCashAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(193, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Amount"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 16)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "Receipt No"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 16)
        Me.Label11.TabIndex = 89
        Me.Label11.Text = "CustomerName"
        '
        'lblPrimaryKey
        '
        Me.lblPrimaryKey.AutoSize = True
        Me.lblPrimaryKey.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimaryKey.Location = New System.Drawing.Point(512, 115)
        Me.lblPrimaryKey.Name = "lblPrimaryKey"
        Me.lblPrimaryKey.Size = New System.Drawing.Size(60, 16)
        Me.lblPrimaryKey.TabIndex = 88
        Me.lblPrimaryKey.Text = "Address"
        Me.lblPrimaryKey.Visible = False
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(378, 13)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(117, 23)
        Me.dtpDate.TabIndex = 87
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 16)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Payment Mode:-->"
        '
        'gbMode
        '
        Me.gbMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbMode.Controls.Add(Me.optBankTransfer)
        Me.gbMode.Controls.Add(Me.optCash)
        Me.gbMode.Controls.Add(Me.optCheque)
        Me.gbMode.Location = New System.Drawing.Point(3, 173)
        Me.gbMode.Name = "gbMode"
        Me.gbMode.Size = New System.Drawing.Size(360, 52)
        Me.gbMode.TabIndex = 80
        '
        'optBankTransfer
        '
        Me.optBankTransfer.AutoSize = True
        Me.optBankTransfer.Location = New System.Drawing.Point(259, 21)
        Me.optBankTransfer.Name = "optBankTransfer"
        Me.optBankTransfer.Size = New System.Drawing.Size(89, 17)
        Me.optBankTransfer.TabIndex = 63
        Me.optBankTransfer.TabStop = True
        Me.optBankTransfer.Text = "BankTransfer"
        Me.optBankTransfer.UseVisualStyleBackColor = True
        '
        'optCash
        '
        Me.optCash.AutoSize = True
        Me.optCash.Location = New System.Drawing.Point(137, 21)
        Me.optCash.Name = "optCash"
        Me.optCash.Size = New System.Drawing.Size(49, 17)
        Me.optCash.TabIndex = 61
        Me.optCash.TabStop = True
        Me.optCash.Text = "Cash"
        Me.optCash.UseVisualStyleBackColor = True
        '
        'optCheque
        '
        Me.optCheque.AutoSize = True
        Me.optCheque.Location = New System.Drawing.Point(5, 21)
        Me.optCheque.Name = "optCheque"
        Me.optCheque.Size = New System.Drawing.Size(62, 17)
        Me.optCheque.TabIndex = 62
        Me.optCheque.TabStop = True
        Me.optCheque.Text = "Cheque"
        Me.optCheque.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(333, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Date"
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.Color.White
        Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.Location = New System.Drawing.Point(111, 82)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(107, 23)
        Me.txtBalance.TabIndex = 78
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(5, 85)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(59, 16)
        Me.Label27.TabIndex = 77
        Me.Label27.Text = "Balance"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(501, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 16)
        Me.Label15.TabIndex = 76
        Me.Label15.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.White
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(559, 5)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(146, 71)
        Me.txtAddress.TabIndex = 68
        '
        'txtdate
        '
        Me.txtdate.BackColor = System.Drawing.Color.White
        Me.txtdate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdate.Location = New System.Drawing.Point(378, 13)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.Size = New System.Drawing.Size(117, 23)
        Me.txtdate.TabIndex = 75
        '
        'cmdSearchCustomer
        '
        Me.cmdSearchCustomer.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearchCustomer.Location = New System.Drawing.Point(467, 49)
        Me.cmdSearchCustomer.Name = "cmdSearchCustomer"
        Me.cmdSearchCustomer.Size = New System.Drawing.Size(28, 25)
        Me.cmdSearchCustomer.TabIndex = 74
        Me.cmdSearchCustomer.Text = "?"
        Me.cmdSearchCustomer.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(276, 13)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(41, 27)
        Me.cmdSearch.TabIndex = 73
        Me.cmdSearch.Text = "?"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtReceiptNo
        '
        Me.txtReceiptNo.BackColor = System.Drawing.Color.White
        Me.txtReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceiptNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiptNo.Location = New System.Drawing.Point(111, 16)
        Me.txtReceiptNo.Name = "txtReceiptNo"
        Me.txtReceiptNo.Size = New System.Drawing.Size(159, 23)
        Me.txtReceiptNo.TabIndex = 72
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(111, 115)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(350, 23)
        Me.txtRemarks.TabIndex = 69
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.White
        Me.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(111, 49)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(350, 23)
        Me.txtCustomerName.TabIndex = 66
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Remarks"
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
        Me.Panel1.Location = New System.Drawing.Point(427, 431)
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
        'gbSearch
        '
        Me.gbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSearch.Controls.Add(Me.Label14)
        Me.gbSearch.Controls.Add(Me.txtSearchName)
        Me.gbSearch.Controls.Add(Me.fgSearch)
        Me.gbSearch.Location = New System.Drawing.Point(6, 39)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(710, 486)
        Me.gbSearch.TabIndex = 125
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(138, 16)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Search Supplier Name"
        '
        'txtSearchName
        '
        Me.txtSearchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchName.Location = New System.Drawing.Point(149, 9)
        Me.txtSearchName.Name = "txtSearchName"
        Me.txtSearchName.Size = New System.Drawing.Size(159, 20)
        Me.txtSearchName.TabIndex = 1
        '
        'fgSearch
        '
        Me.fgSearch.Location = New System.Drawing.Point(3, 42)
        Me.fgSearch.Name = "fgSearch"
        Me.fgSearch.OcxState = CType(resources.GetObject("fgSearch.OcxState"), System.Windows.Forms.AxHost.State)
        Me.fgSearch.Size = New System.Drawing.Size(702, 461)
        Me.fgSearch.TabIndex = 0
        '
        'txtBankCode
        '
        Me.txtBankCode.BackColor = System.Drawing.Color.White
        Me.txtBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankCode.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankCode.Location = New System.Drawing.Point(480, 158)
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.ReadOnly = True
        Me.txtBankCode.Size = New System.Drawing.Size(197, 23)
        Me.txtBankCode.TabIndex = 67
        Me.txtBankCode.Visible = False
        '
        'frmReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ClientSize = New System.Drawing.Size(721, 531)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.gbSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.gbBankTransfer.ResumeLayout(False)
        Me.gbBankTransfer.PerformLayout()
        Me.gbCheque.ResumeLayout(False)
        Me.gbCheque.PerformLayout()
        Me.gbCash.ResumeLayout(False)
        Me.gbCash.PerformLayout()
        Me.gbMode.ResumeLayout(False)
        Me.gbMode.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        CType(Me.fgSearch, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtSearchName As System.Windows.Forms.TextBox
    Friend WithEvents fgSearch As AxVSFlex7L.AxVSFlexGrid
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents gbMode As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtdate As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearchCustomer As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtReceiptNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbCash As System.Windows.Forms.Panel
    Friend WithEvents gbCheque As System.Windows.Forms.Panel
    Friend WithEvents gbBankTransfer As System.Windows.Forms.Panel
    Friend WithEvents txtBankBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtChequeDate As System.Windows.Forms.TextBox
    Friend WithEvents txtAccNo As System.Windows.Forms.TextBox
    Friend WithEvents txtBranch As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboAccNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpChequeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtChequeAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCashBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtCashAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents optBankTransfer As System.Windows.Forms.RadioButton
    Friend WithEvents optCash As System.Windows.Forms.RadioButton
    Friend WithEvents optCheque As System.Windows.Forms.RadioButton
    Friend WithEvents txtBankBalance1 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtAccNo1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAmounttransfer As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPartyBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtBranch1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtBankName1 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboAccNo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtPartyBankBranch As System.Windows.Forms.TextBox
    Friend WithEvents txtPartyAccNo As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPrimaryKey As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdApprove As System.Windows.Forms.Button
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
End Class
