<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.help = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.CompanyMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupplierMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TaxMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BankMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StateMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CityMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LocalityMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DescriptionMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PaymentTermMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TermsAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CurrencyMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OverHeadMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseInvoice1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.QuotationMaster2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.SaleInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaleInvoice1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaleReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TaxInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DepositToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.JournalVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.JournalVoucher1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemAccountStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupplierAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseReturnSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaleSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaleReturnSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PaymentSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReceiptSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AccountGroupLedgerReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DayBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AccessoriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CalculatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpeningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.help})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(993, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(216, 17)
        Me.ToolStripStatusLabel1.Text = "Developed By MAQ Software Solution"
        '
        'help
        '
        Me.help.Name = "help"
        Me.help.Size = New System.Drawing.Size(317, 17)
        Me.help.Text = "For Any Queries and Technical Help Please Call  +919313173967"
        Me.help.Visible = False
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.PurchaseToolStripMenuItem, Me.SaleToolStripMenuItem, Me.AccountToolStripMenuItem, Me.ReportToolStripMenuItem, Me.AccessoriesToolStripMenuItem, Me.BackupToolStripMenuItem, Me.HelpToolStripMenuItem, Me.OpeningToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(993, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompanyMasterToolStripMenuItem, Me.SupplierMasterToolStripMenuItem, Me.CustomerMasterToolStripMenuItem, Me.ItemMasterToolStripMenuItem, Me.TaxMasterToolStripMenuItem, Me.BankMasterToolStripMenuItem, Me.StateMasterToolStripMenuItem, Me.CityMasterToolStripMenuItem, Me.LocalityMasterToolStripMenuItem, Me.DescriptionMasterToolStripMenuItem, Me.PaymentTermMasterToolStripMenuItem, Me.TermsAToolStripMenuItem, Me.CurrencyMasterToolStripMenuItem, Me.OverHeadMasterToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(52, 20)
        Me.FileMenu.Text = "&Master"
        '
        'CompanyMasterToolStripMenuItem
        '
        Me.CompanyMasterToolStripMenuItem.Name = "CompanyMasterToolStripMenuItem"
        Me.CompanyMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.CompanyMasterToolStripMenuItem.Text = "CompanyMaster"
        '
        'SupplierMasterToolStripMenuItem
        '
        Me.SupplierMasterToolStripMenuItem.Name = "SupplierMasterToolStripMenuItem"
        Me.SupplierMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.SupplierMasterToolStripMenuItem.Text = "SupplierMaster"
        '
        'CustomerMasterToolStripMenuItem
        '
        Me.CustomerMasterToolStripMenuItem.Name = "CustomerMasterToolStripMenuItem"
        Me.CustomerMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.CustomerMasterToolStripMenuItem.Text = "CustomerMaster"
        '
        'ItemMasterToolStripMenuItem
        '
        Me.ItemMasterToolStripMenuItem.Name = "ItemMasterToolStripMenuItem"
        Me.ItemMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ItemMasterToolStripMenuItem.Text = "ItemMaster"
        '
        'TaxMasterToolStripMenuItem
        '
        Me.TaxMasterToolStripMenuItem.Name = "TaxMasterToolStripMenuItem"
        Me.TaxMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.TaxMasterToolStripMenuItem.Text = "OverHeadMaster"
        '
        'BankMasterToolStripMenuItem
        '
        Me.BankMasterToolStripMenuItem.Name = "BankMasterToolStripMenuItem"
        Me.BankMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.BankMasterToolStripMenuItem.Text = "BankMaster"
        '
        'StateMasterToolStripMenuItem
        '
        Me.StateMasterToolStripMenuItem.Name = "StateMasterToolStripMenuItem"
        Me.StateMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.StateMasterToolStripMenuItem.Text = "StateMaster"
        '
        'CityMasterToolStripMenuItem
        '
        Me.CityMasterToolStripMenuItem.Name = "CityMasterToolStripMenuItem"
        Me.CityMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.CityMasterToolStripMenuItem.Text = "CityMaster"
        '
        'LocalityMasterToolStripMenuItem
        '
        Me.LocalityMasterToolStripMenuItem.Name = "LocalityMasterToolStripMenuItem"
        Me.LocalityMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.LocalityMasterToolStripMenuItem.Text = "LocalityMaster"
        '
        'DescriptionMasterToolStripMenuItem
        '
        Me.DescriptionMasterToolStripMenuItem.Name = "DescriptionMasterToolStripMenuItem"
        Me.DescriptionMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.DescriptionMasterToolStripMenuItem.Text = "DescriptionMaster"
        '
        'PaymentTermMasterToolStripMenuItem
        '
        Me.PaymentTermMasterToolStripMenuItem.Name = "PaymentTermMasterToolStripMenuItem"
        Me.PaymentTermMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.PaymentTermMasterToolStripMenuItem.Text = "PaymentTermMaster"
        '
        'TermsAToolStripMenuItem
        '
        Me.TermsAToolStripMenuItem.Name = "TermsAToolStripMenuItem"
        Me.TermsAToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.TermsAToolStripMenuItem.Text = "TermsAndConditionMaster"
        '
        'CurrencyMasterToolStripMenuItem
        '
        Me.CurrencyMasterToolStripMenuItem.Name = "CurrencyMasterToolStripMenuItem"
        Me.CurrencyMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.CurrencyMasterToolStripMenuItem.Text = "CurrencyMaster"
        '
        'OverHeadMasterToolStripMenuItem
        '
        Me.OverHeadMasterToolStripMenuItem.Name = "OverHeadMasterToolStripMenuItem"
        Me.OverHeadMasterToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.OverHeadMasterToolStripMenuItem.Text = "NewOverHeadMaster"
        '
        'PurchaseToolStripMenuItem
        '
        Me.PurchaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseInvoiceToolStripMenuItem, Me.PurchaseReturnToolStripMenuItem, Me.PurchaseInvoice1ToolStripMenuItem})
        Me.PurchaseToolStripMenuItem.Name = "PurchaseToolStripMenuItem"
        Me.PurchaseToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.PurchaseToolStripMenuItem.Text = "&Purchase"
        '
        'PurchaseInvoiceToolStripMenuItem
        '
        Me.PurchaseInvoiceToolStripMenuItem.Name = "PurchaseInvoiceToolStripMenuItem"
        Me.PurchaseInvoiceToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.PurchaseInvoiceToolStripMenuItem.Text = "&Purchase Invoice"
        Me.PurchaseInvoiceToolStripMenuItem.Visible = False
        '
        'PurchaseReturnToolStripMenuItem
        '
        Me.PurchaseReturnToolStripMenuItem.Name = "PurchaseReturnToolStripMenuItem"
        Me.PurchaseReturnToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.PurchaseReturnToolStripMenuItem.Text = "PurchaseReturn"
        Me.PurchaseReturnToolStripMenuItem.Visible = False
        '
        'PurchaseInvoice1ToolStripMenuItem
        '
        Me.PurchaseInvoice1ToolStripMenuItem.Name = "PurchaseInvoice1ToolStripMenuItem"
        Me.PurchaseInvoice1ToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.PurchaseInvoice1ToolStripMenuItem.Text = "Purchase Invoice 1"
        '
        'SaleToolStripMenuItem
        '
        Me.SaleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.QuotationMaster2ToolStripMenuItem, Me.ToolStripMenuItem2, Me.SaleInvoiceToolStripMenuItem, Me.SaleInvoice1ToolStripMenuItem, Me.SaleReturnToolStripMenuItem, Me.TaxInvoiceToolStripMenuItem})
        Me.SaleToolStripMenuItem.Name = "SaleToolStripMenuItem"
        Me.SaleToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.SaleToolStripMenuItem.Text = "&Sale"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem1.Text = "QuotationMaster"
        Me.ToolStripMenuItem1.Visible = False
        '
        'QuotationMaster2ToolStripMenuItem
        '
        Me.QuotationMaster2ToolStripMenuItem.Name = "QuotationMaster2ToolStripMenuItem"
        Me.QuotationMaster2ToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.QuotationMaster2ToolStripMenuItem.Text = "Quotation Master 2"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem2.Text = "ChallanMaster"
        '
        'SaleInvoiceToolStripMenuItem
        '
        Me.SaleInvoiceToolStripMenuItem.Name = "SaleInvoiceToolStripMenuItem"
        Me.SaleInvoiceToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.SaleInvoiceToolStripMenuItem.Text = "&SaleInvoice"
        Me.SaleInvoiceToolStripMenuItem.Visible = False
        '
        'SaleInvoice1ToolStripMenuItem
        '
        Me.SaleInvoice1ToolStripMenuItem.Name = "SaleInvoice1ToolStripMenuItem"
        Me.SaleInvoice1ToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.SaleInvoice1ToolStripMenuItem.Text = "Sale Invoice 1"
        '
        'SaleReturnToolStripMenuItem
        '
        Me.SaleReturnToolStripMenuItem.Name = "SaleReturnToolStripMenuItem"
        Me.SaleReturnToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.SaleReturnToolStripMenuItem.Text = "Sale Return"
        Me.SaleReturnToolStripMenuItem.Visible = False
        '
        'TaxInvoiceToolStripMenuItem
        '
        Me.TaxInvoiceToolStripMenuItem.Name = "TaxInvoiceToolStripMenuItem"
        Me.TaxInvoiceToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.TaxInvoiceToolStripMenuItem.Text = "TaxInvoice"
        Me.TaxInvoiceToolStripMenuItem.Visible = False
        '
        'AccountToolStripMenuItem
        '
        Me.AccountToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PaymentToolStripMenuItem, Me.ReceiptToolStripMenuItem, Me.DepositToolStripMenuItem, Me.JournalVoucherToolStripMenuItem, Me.JournalVoucher1ToolStripMenuItem})
        Me.AccountToolStripMenuItem.Name = "AccountToolStripMenuItem"
        Me.AccountToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.AccountToolStripMenuItem.Text = "Account"
        '
        'PaymentToolStripMenuItem
        '
        Me.PaymentToolStripMenuItem.Name = "PaymentToolStripMenuItem"
        Me.PaymentToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.PaymentToolStripMenuItem.Text = "Payment"
        '
        'ReceiptToolStripMenuItem
        '
        Me.ReceiptToolStripMenuItem.Name = "ReceiptToolStripMenuItem"
        Me.ReceiptToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ReceiptToolStripMenuItem.Text = "Receipt"
        '
        'DepositToolStripMenuItem
        '
        Me.DepositToolStripMenuItem.Name = "DepositToolStripMenuItem"
        Me.DepositToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DepositToolStripMenuItem.Text = "BankVoucher"
        '
        'JournalVoucherToolStripMenuItem
        '
        Me.JournalVoucherToolStripMenuItem.Name = "JournalVoucherToolStripMenuItem"
        Me.JournalVoucherToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.JournalVoucherToolStripMenuItem.Text = "JournalVoucher"
        Me.JournalVoucherToolStripMenuItem.Visible = False
        '
        'JournalVoucher1ToolStripMenuItem
        '
        Me.JournalVoucher1ToolStripMenuItem.Name = "JournalVoucher1ToolStripMenuItem"
        Me.JournalVoucher1ToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.JournalVoucher1ToolStripMenuItem.Text = "JournalVoucher 1"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemAccountStatementToolStripMenuItem, Me.CustomerAccountToolStripMenuItem, Me.SupplierAccountToolStripMenuItem, Me.PurchaseSearchToolStripMenuItem, Me.PurchaseReturnSearchToolStripMenuItem, Me.SaleSearchToolStripMenuItem, Me.SaleReturnSearchToolStripMenuItem, Me.PaymentSearchToolStripMenuItem, Me.ReceiptSearchToolStripMenuItem, Me.AccountGroupLedgerReportToolStripMenuItem, Me.DayBookToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'ItemAccountStatementToolStripMenuItem
        '
        Me.ItemAccountStatementToolStripMenuItem.Name = "ItemAccountStatementToolStripMenuItem"
        Me.ItemAccountStatementToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ItemAccountStatementToolStripMenuItem.Text = "ItemAccountStatement"
        '
        'CustomerAccountToolStripMenuItem
        '
        Me.CustomerAccountToolStripMenuItem.Name = "CustomerAccountToolStripMenuItem"
        Me.CustomerAccountToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.CustomerAccountToolStripMenuItem.Text = "Customer Account"
        '
        'SupplierAccountToolStripMenuItem
        '
        Me.SupplierAccountToolStripMenuItem.Name = "SupplierAccountToolStripMenuItem"
        Me.SupplierAccountToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.SupplierAccountToolStripMenuItem.Text = "Supplier Account"
        '
        'PurchaseSearchToolStripMenuItem
        '
        Me.PurchaseSearchToolStripMenuItem.Name = "PurchaseSearchToolStripMenuItem"
        Me.PurchaseSearchToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.PurchaseSearchToolStripMenuItem.Text = "Purchase Search"
        '
        'PurchaseReturnSearchToolStripMenuItem
        '
        Me.PurchaseReturnSearchToolStripMenuItem.Name = "PurchaseReturnSearchToolStripMenuItem"
        Me.PurchaseReturnSearchToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.PurchaseReturnSearchToolStripMenuItem.Text = "PurchaseReturn Search"
        Me.PurchaseReturnSearchToolStripMenuItem.Visible = False
        '
        'SaleSearchToolStripMenuItem
        '
        Me.SaleSearchToolStripMenuItem.Name = "SaleSearchToolStripMenuItem"
        Me.SaleSearchToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.SaleSearchToolStripMenuItem.Text = "Sale Search"
        '
        'SaleReturnSearchToolStripMenuItem
        '
        Me.SaleReturnSearchToolStripMenuItem.Name = "SaleReturnSearchToolStripMenuItem"
        Me.SaleReturnSearchToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.SaleReturnSearchToolStripMenuItem.Text = "SaleReturn Search"
        Me.SaleReturnSearchToolStripMenuItem.Visible = False
        '
        'PaymentSearchToolStripMenuItem
        '
        Me.PaymentSearchToolStripMenuItem.Name = "PaymentSearchToolStripMenuItem"
        Me.PaymentSearchToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.PaymentSearchToolStripMenuItem.Text = "Payment Search"
        '
        'ReceiptSearchToolStripMenuItem
        '
        Me.ReceiptSearchToolStripMenuItem.Name = "ReceiptSearchToolStripMenuItem"
        Me.ReceiptSearchToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ReceiptSearchToolStripMenuItem.Text = "Receipt Search"
        '
        'AccountGroupLedgerReportToolStripMenuItem
        '
        Me.AccountGroupLedgerReportToolStripMenuItem.Name = "AccountGroupLedgerReportToolStripMenuItem"
        Me.AccountGroupLedgerReportToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.AccountGroupLedgerReportToolStripMenuItem.Text = "AccountGroup/LedgerReport"
        '
        'DayBookToolStripMenuItem
        '
        Me.DayBookToolStripMenuItem.Name = "DayBookToolStripMenuItem"
        Me.DayBookToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.DayBookToolStripMenuItem.Text = "DayBook"
        '
        'AccessoriesToolStripMenuItem
        '
        Me.AccessoriesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalculatorToolStripMenuItem, Me.NotepadToolStripMenuItem})
        Me.AccessoriesToolStripMenuItem.Name = "AccessoriesToolStripMenuItem"
        Me.AccessoriesToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.AccessoriesToolStripMenuItem.Text = "Accessories"
        '
        'CalculatorToolStripMenuItem
        '
        Me.CalculatorToolStripMenuItem.Name = "CalculatorToolStripMenuItem"
        Me.CalculatorToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CalculatorToolStripMenuItem.Text = "Calculator"
        '
        'NotepadToolStripMenuItem
        '
        Me.NotepadToolStripMenuItem.Name = "NotepadToolStripMenuItem"
        Me.NotepadToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NotepadToolStripMenuItem.Text = "Notepad"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'OpeningToolStripMenuItem
        '
        Me.OpeningToolStripMenuItem.Name = "OpeningToolStripMenuItem"
        Me.OpeningToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.OpeningToolStripMenuItem.Text = "Opening"
        Me.OpeningToolStripMenuItem.Visible = False
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(993, 453)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMainMenu"
        Me.Text = "JOGINDER NURSERY"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompanyMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TaxMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaleInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemAccountStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaleReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DepositToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BankMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseReturnSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaleSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaleReturnSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReceiptSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StateMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CityMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LocalityMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountGroupLedgerReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JournalVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TaxInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DayBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccessoriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalculatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotepadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents help As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DescriptionMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpeningToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentTermMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TermsAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CurrencyMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverHeadMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuotationMaster2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JournalVoucher1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseInvoice1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaleInvoice1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
