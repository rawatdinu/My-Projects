Module MainModule
    Public gl_Con As SqlClient.SqlConnection
    Public gl_dsLogin As New Data.DataSet
    Public gl_dtServerDate As DateTime
    Public gl_strFinancialYear As String
    Public gl_strCurrFinancialYear As String
    Public gl_strFinancialYearShort As String
    Public gl_FromDate As Date
    Public gl_ToDate As Date
    Public gl_strMachine As String 'Current machine Name 
    Public gl_strUserName As String 'Employee Login ID
    Public gl_MinDate As Date
    Public gl_MaxDate As Date
    Public gl_daGrp As SqlClient.SqlDataAdapter
    Public gl_dsGrp As New DataSet
    Public gl_intMaxval As Long
    Public MainForm As New frmMainmenu
    Public Login As New LoginForm1
    Public ItemMaster As frmItemMaster
    Public AllowChar = "0123456789"
    Public f_blnValidity As Boolean = True
    Public gl_Sino As Integer
    Public DescriptionMaster As frmDescriptionMaster
    Public gl_EmpName As String
    Public CompanyMaster As frmCompanyMaster
    Public SupplierMaster As frmSupplierMaster
    Public CustomerMaster As frmCustomerMaster
    'Public PurchaseInvoice As frmPurchaseInvoice
    Public gl_DateTime As DateTime
    'Public ConfigurationMaster As frmPOConfigurationMaster
    'Public SaleInvoice As frmSaleInvoice
    Public ItemAccountStatement As frmItemAccountStatement
    'Public SaleReturn As frmSaleReturn
    Public payment As frmPayment
    Public CustomerAcc As frmCustomerAccount
    Public SupplierAcc As frmSupplierAccount
    Public Receipt As frmReceipt
    Public BankMaster As frmBankMaster
    Public BankVoucher As frmBankVoucher
    Public PurchaseSearch As frmPurchaseSearch
    Public SaleSearch As frmSaleSearch
    'Public SaleReturnSearch As frmSaleReturnSearch
    Public StateMaster As frmStateMaster
    Public CityMaster As frmCityMaster
    Public LocalityMaster As frmLocalityMaster
    Public gl_strpwd As String
    Public PaymentSearch As frmPaymentSearch
    Public ReceiptSearch As frmReceiptSearch
    Public AccountGroupLedgerReport As frmAccountGroupReport
    'Public JournalVoucher As frmJournalVoucher
    'Public TaxInvoice As frmTaxInvoice
    Public DayBook As frmDayBook
    Public BackupDatabase As frmBackup
    Dim file As New System.IO.StreamReader(Application.StartupPath & "\Connection.txt")
    Dim txtConnectionString As String = file.ReadToEnd()
    Public txtConnectionReport As String
    Public PaymentTermMaster As frmPaymentTerms
    'Public QuotationMaster As frmQuotationMaster
    Public TCMaster As frmTermsAndConditions
    Public ChallanMaster As frmChallanMaster
    Public ActivityList As frmActivityList
    Public CurrencyMaster As frmCurrencyMaster
    Public OverHeadMaster As frmOverHeadMaster
    Public QuotationMaster2 As frmQuotationMaster2
    Public JournalVoucher1 As frmJournalVoucher1
    Public PurchaseInvoice1 As frmPurchaseInvoice1
    Public SaleInvoice1 As frmSaleInvoice1

    Public Sub connect()

        On Error GoTo ErrHnd
        Dim tempstr As String


        'tempstr = "Data Source=ADMIN-2747177B8;Initial Catalog=JoginderNursery;User ID=sa;Password=aaaaaa"

        'file.Close()
        'file = New System.IO.StreamReader(Application.StartupPath & "\Connection.txt")
        'txtConnectionReport = file.ReadLine()

        'file.Close()
        'Dim intPos As Integer
        'Dim intPos1 As Integer
        'Dim strDecode As String = ""
        'Dim strPwd As String
        'If InStr(txtConnectionString, "pwd") > 0 Then
        '    intPos1 = InStr(txtConnectionString, "pwd")
        '    strPwd = Mid(txtConnectionString, intPos1 + 4, Len(txtConnectionString))
        '    For intPos = 1 To Len(strPwd)
        '        strDecode = strDecode & CodeDecode(Mid(strPwd, intPos, 1))
        '    Next
        '    gl_strpwd = strDecode
        '    txtConnectionReport = txtConnectionReport '& LCase(strDecode) & ";"
        '    strDecode = Mid(txtConnectionString, 1, intPos1 + 3) & LCase(strDecode) '& ";"
        'Else
        '    gl_strpwd = ""
        '    strDecode = txtConnectionString
        'End If
        Dim dbpath As String = Application.StartupPath
        gl_strpwd = "12345"

        txtConnectionReport = "Data Source=DINESH-PC;AttachDbFilename=" + dbpath + "\JoginderNursery_Data.MDF;User ID=sa;Password=12345"
        gl_Con = New SqlClient.SqlConnection(txtConnectionReport)
        gl_Con.Open()
        Login = Nothing
        'Login.Cursor = Cursors.WaitCursor
        'Login.ShowDialog()
        'Login.Cursor = Cursors.Default
        Exit Sub
ErrHnd:
        MsgBox(Err.Description)
    End Sub

    Private Function CodeDecode(ByVal strCode As String) As String
        Select Case UCase(strCode)
            Case "A"
                CodeDecode = "J"
            Case "B"
                CodeDecode = "D"
            Case "C"
                CodeDecode = "F"
            Case "D"
                CodeDecode = "L"
            Case "E"
                CodeDecode = "K"
            Case "F"
                CodeDecode = "P"
            Case "G"
                CodeDecode = "O"
            Case "H"
                CodeDecode = "S"
            Case "I"
                CodeDecode = "Z"
            Case "J"
                CodeDecode = "X"
            Case "K"
                CodeDecode = "C"
            Case "L"
                CodeDecode = "W"
            Case "M"
                CodeDecode = "B"
            Case "N"
                CodeDecode = "Q"
            Case "O"
                CodeDecode = "Y"
            Case "P"
                CodeDecode = "E"
            Case "Q"
                CodeDecode = "R"
            Case "R"
                CodeDecode = "T"
            Case "S"
                CodeDecode = "U"
            Case "T"
                CodeDecode = "I"
            Case "U"
                CodeDecode = "H"
            Case "V"
                CodeDecode = "N"
            Case "W"
                CodeDecode = "G"
            Case "X"
                CodeDecode = "M"
            Case "Y"
                CodeDecode = "V"
            Case "Z"
                CodeDecode = "A"
        End Select
    End Function

    Public Sub Allowcharacter(ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If (e.KeyChar = Convert.ToChar(46)) Then
            e.Handled = False
            Exit Sub
        ElseIf (e.KeyChar = Convert.ToChar(8)) Then
            e.Handled = False
            Exit Sub
        ElseIf AllowChar.indexof(e.KeyChar) = -1 Then
            e.Handled = True
            Exit Sub
        End If


    End Sub
    Public Function checkValidity() As Boolean
        Dim strSql As String
        Dim intCPOCount As Integer
        Dim intPOCount As Integer
        Dim intVoucherCount As Integer

        'when no of records exceeds 1000 in CPO, Validity expires
        strSql = "select count(*)  as count1 from SaleMaster"
        Dim daValidity As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(strSql, gl_Con)
        Dim dsValidity As DataSet = New DataSet
        daValidity.Fill(dsValidity, "ServiceMaster")

        If dsValidity.Tables("ServiceMaster").Rows.Count > 0 Then
            intCPOCount = dsValidity.Tables("ServiceMaster").Rows(0).Item("Count1")
        End If

        'when no of records exceeds 1000 in Purchase Order, Validity expires
        strSql = "select count(*)  as Count1 from PurchaseMaster"
        daValidity = New SqlClient.SqlDataAdapter(strSql, gl_Con)
        daValidity.Fill(dsValidity, "OutPatientMaster")
        If dsValidity.Tables("OutPatientMaster").Rows.Count > 0 Then
            intPOCount = dsValidity.Tables("OutPatientMaster").Rows(0).Item("Count1")
        End If

        'when no of records exceeds 10,000 in BankVoucher, Validity expires
        strSql = "select count(*)  as Count1 from PaymentMaster"
        daValidity = New SqlClient.SqlDataAdapter(strSql, gl_Con)
        daValidity.Fill(dsValidity, "INPatientMaster")
        If dsValidity.Tables("INPatientMaster").Rows.Count > 0 Then
            intVoucherCount = dsValidity.Tables("INPatientMaster").Rows(0).Item("Count1")
        End If


        If intCPOCount > 100000000000 Or intPOCount > 1000000000000 Or intVoucherCount > 10000000000000 Then

            checkValidity = False
        Else
            checkValidity = True
        End If

        dsValidity.Clear()
        If Not daValidity Is Nothing Then
            daValidity.Dispose()
        End If
    End Function

    Public Function MsgQuestion(ByVal strAction As String) As Integer
        Select Case UCase(strAction)
            Case "SAVE"
                MsgQuestion = MsgBox("Are you sure You want to save the record ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "SAVEAS"
                MsgQuestion = MsgBox("Are you sure You want to Create New Version for this Quotation ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "UPDATE"
                MsgQuestion = MsgBox("Are you sure You want to update the record ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "CANCEL"
                MsgQuestion = MsgBox("Are you sure You want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "CLOSE"
                MsgQuestion = MsgBox("Are you sure You want to close the Screen ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "DELETE"
                MsgQuestion = MsgBox("Are you sure You want to delete Record ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "QUOTATION"
                MsgQuestion = MsgBox("Are you sure You want to save the Record for New Customer ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "MOVE"
                MsgQuestion = MsgBox("Are you sure You want to move this Record ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "PRINT"
                MsgQuestion = MsgBox("Are you sure You want to Print ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Medicare")
            Case "DISAPPROVE"
                MsgQuestion = MsgBox("You want to DisApprove ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "EXCEL"
                MsgQuestion = MsgBox("Are you sure You want to Transfer Data in Excel ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "VAT"
                MsgQuestion = MsgBox("Are you sure You want to Take This vat Amount Data in Excel ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "LOGOFF"
                MsgQuestion = MsgBox("Are you sure You want to Log Out ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "APPROVE"
                MsgQuestion = MsgBox("Are you sure You want to Approve ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "CURRENCY"
                MsgQuestion = MsgBox("Press Yes to Create Invoice in GOC or Press No to Create Invoice in BankRate ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "CANCEL PO"
                MsgQuestion = MsgBox("Are you sure You want to Cancel This PO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
            Case "CANCELINV"
                MsgQuestion = MsgBox("Are you sure You want to Cancel This Invoice ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "IMS")
        End Select
    End Function
    Public Sub DisplayForm(ByVal strSelectedform As String)

        Select Case strSelectedform

            Case "SaleInvoice1"
                If PurchaseInvoice1 Is Nothing Then
                    SaleInvoice1 = New frmSaleInvoice1
                    SaleInvoice1.MdiParent = MainForm
                    SaleInvoice1.Show()
                    SaleInvoice1.BringToFront()

                Else
                    SaleInvoice1.Activate()
                End If

            Case "PurchaseInvoice1"
                If PurchaseInvoice1 Is Nothing Then
                    PurchaseInvoice1 = New frmPurchaseInvoice1
                    PurchaseInvoice1.MdiParent = MainForm
                    PurchaseInvoice1.Show()
                    PurchaseInvoice1.BringToFront()

                Else
                    PurchaseInvoice1.Activate()
                End If

            Case "JournalVoucher1"
                If JournalVoucher1 Is Nothing Then
                    JournalVoucher1 = New frmJournalVoucher1
                    JournalVoucher1.MdiParent = MainForm
                    JournalVoucher1.Show()
                    JournalVoucher1.BringToFront()

                Else
                    JournalVoucher1.Activate()
                End If

            Case "QuotationMaster2"
                If QuotationMaster2 Is Nothing Then
                    QuotationMaster2 = New frmQuotationMaster2
                    QuotationMaster2.MdiParent = MainForm
                    QuotationMaster2.Show()
                    QuotationMaster2.BringToFront()

                Else
                    QuotationMaster2.Activate()
                End If


            Case "OverHeadMaster"
                If OverHeadMaster Is Nothing Then
                    OverHeadMaster = New frmOverHeadMaster
                    OverHeadMaster.MdiParent = MainForm
                    OverHeadMaster.Show()
                    OverHeadMaster.BringToFront()

                Else
                    OverHeadMaster.Activate()
                End If

            Case "CurrencyMaster"
                If CurrencyMaster Is Nothing Then
                    CurrencyMaster = New frmCurrencyMaster
                    CurrencyMaster.MdiParent = MainForm
                    CurrencyMaster.Show()
                    CurrencyMaster.BringToFront()

                Else
                    CurrencyMaster.Activate()
                End If
            Case "ActivityList"
                If ActivityList Is Nothing Then
                    ActivityList = New frmActivityList
                    ActivityList.MdiParent = MainForm
                    ActivityList.Show()
                    ActivityList.BringToFront()

                Else
                    ActivityList.Activate()
                End If
            Case "ChallanMaster"
                If ChallanMaster Is Nothing Then
                    ChallanMaster = New frmChallanMaster
                    ChallanMaster.MdiParent = MainForm
                    ChallanMaster.Show()
                    ChallanMaster.BringToFront()

                Else
                    ChallanMaster.Activate()
                End If
            Case "TCMaster"
                If TCMaster Is Nothing Then
                    TCMaster = New frmTermsAndConditions
                    TCMaster.MdiParent = MainForm
                    TCMaster.Show()
                    TCMaster.BringToFront()

                Else
                    TCMaster.Activate()
                End If
                'Case "QuotationMaster"
                '    If QuotationMaster Is Nothing Then
                '        QuotationMaster = New frmQuotationMaster
                '        QuotationMaster.MdiParent = MainForm
                '        QuotationMaster.Show()
                '        QuotationMaster.BringToFront()

                '    Else
                '        QuotationMaster.Activate()
                '    End If

            Case "DescriptionMaster"
                If DescriptionMaster Is Nothing Then
                    DescriptionMaster = New frmDescriptionMaster
                    DescriptionMaster.MdiParent = MainForm
                    DescriptionMaster.Show()
                    DescriptionMaster.BringToFront()

                Else
                    DescriptionMaster.Activate()
                End If

            Case "DayBook"
                If DayBook Is Nothing Then
                    DayBook = New frmDayBook
                    DayBook.MdiParent = MainForm
                    DayBook.Show()
                    DayBook.BringToFront()

                Else
                    DayBook.Activate()
                End If

                'Case "TaxInvoice"
                '    If TaxInvoice Is Nothing Then
                '        TaxInvoice = New frmTaxInvoice
                '        TaxInvoice.MdiParent = MainForm
                '        TaxInvoice.Show()
                '        TaxInvoice.BringToFront()

                '    Else
                '        TaxInvoice.Activate()
                '    End If
            Case "PaymentTermMaster"
                If PaymentTermMaster Is Nothing Then
                    PaymentTermMaster = New frmPaymentTerms
                    PaymentTermMaster.MdiParent = MainForm
                    PaymentTermMaster.Show()
                    PaymentTermMaster.BringToFront()

                Else
                    PaymentTermMaster.Activate()
                End If

            Case "CompanyMaster"
                If CompanyMaster Is Nothing Then
                    CompanyMaster = New frmCompanyMaster
                    CompanyMaster.MdiParent = MainForm
                    CompanyMaster.Show()
                    CompanyMaster.BringToFront()

                Else
                    CompanyMaster.Activate()
                End If


                'Case "JournalVoucher"
                '    If JournalVoucher Is Nothing Then
                '        JournalVoucher = New frmJournalVoucher
                '        JournalVoucher.MdiParent = MainForm
                '        JournalVoucher.Show()
                '        JournalVoucher.BringToFront()

                '    Else
                '        JournalVoucher.Activate()
                '    End If
                'Case "ConfigurationMaster"
                '    If ConfigurationMaster Is Nothing Then
                '        ConfigurationMaster = New frmPOConfigurationMaster
                '        ConfigurationMaster.MdiParent = MainForm
                '        ConfigurationMaster.Show()
                '        ConfigurationMaster.BringToFront()

                '    Else
                '        ConfigurationMaster.Activate()
                '    End If

                'Case "SaleInvoice"
                '    If SaleInvoice Is Nothing Then
                '        SaleInvoice = New frmSaleInvoice
                '        SaleInvoice.MdiParent = MainForm
                '        SaleInvoice.Show()
                '        SaleInvoice.BringToFront()

                '    Else
                '        SaleInvoice.Activate()
                '    End If



            Case "SupplierMaster"
                If SupplierMaster Is Nothing Then
                    SupplierMaster = New frmSupplierMaster
                    SupplierMaster.MdiParent = MainForm
                    SupplierMaster.Show()
                    SupplierMaster.BringToFront()

                Else
                    SupplierMaster.Activate()
                End If

            Case "CustomerMaster"
                If CustomerMaster Is Nothing Then
                    CustomerMaster = New frmCustomerMaster
                    CustomerMaster.MdiParent = MainForm
                    CustomerMaster.Show()
                    CustomerMaster.BringToFront()

                Else
                    CustomerMaster.Activate()
                End If

            Case "ItemMaster"
                If ItemMaster Is Nothing Then
                    ItemMaster = New frmItemMaster
                    ItemMaster.MdiParent = MainForm
                    ItemMaster.Show()
                    ItemMaster.BringToFront()

                Else
                    ItemMaster.Activate()
                End If

                'Case "PurchaseInvoice"
                '    If PurchaseInvoice Is Nothing Then
                '        PurchaseInvoice = New frmPurchaseInvoice
                '        PurchaseInvoice.MdiParent = MainForm
                '        PurchaseInvoice.Show()
                '        PurchaseInvoice.BringToFront()

                '    Else
                '        PurchaseInvoice.Activate()
                '    End If

            Case "AccountGroupLedgerReport"
                If AccountGroupLedgerReport Is Nothing Then
                    AccountGroupLedgerReport = New frmAccountGroupReport
                    AccountGroupLedgerReport.MdiParent = MainForm
                    AccountGroupLedgerReport.Show()
                    AccountGroupLedgerReport.BringToFront()

                Else
                    AccountGroupLedgerReport.Activate()
                End If

            Case "StateMaster"
                If StateMaster Is Nothing Then
                    StateMaster = New frmStateMaster
                    StateMaster.MdiParent = MainForm
                    StateMaster.Show()
                    StateMaster.BringToFront()

                Else
                    StateMaster.Activate()
                End If
            Case "CityMaster"
                If CityMaster Is Nothing Then
                    CityMaster = New frmCityMaster
                    CityMaster.MdiParent = MainForm
                    CityMaster.Show()
                    CityMaster.BringToFront()

                Else
                    CityMaster.Activate()
                End If


            Case "LocalityMaster"
                If LocalityMaster Is Nothing Then
                    LocalityMaster = New frmLocalityMaster
                    LocalityMaster.MdiParent = MainForm
                    LocalityMaster.Show()
                    LocalityMaster.BringToFront()

                Else
                    LocalityMaster.Activate()
                End If


            Case "ItemAccountStatement"
                If ItemAccountStatement Is Nothing Then
                    ItemAccountStatement = New frmItemAccountStatement
                    ItemAccountStatement.MdiParent = MainForm
                    ItemAccountStatement.Show()
                    ItemAccountStatement.BringToFront()

                Else
                    ItemAccountStatement.Activate()
                End If

                'Case "SaleReturn"
                '    If SaleReturn Is Nothing Then
                '        SaleReturn = New frmSaleReturn
                '        SaleReturn.MdiParent = MainForm
                '        SaleReturn.Show()
                '        SaleReturn.BringToFront()

                '    Else
                '        SaleReturn.Activate()
                '    End If


            Case "Payment"
                If payment Is Nothing Then
                    payment = New frmPayment
                    payment.MdiParent = MainForm
                    payment.Show()
                    payment.BringToFront()

                Else
                    payment.Activate()
                End If

            Case "Receipt"
                If Receipt Is Nothing Then
                    Receipt = New frmReceipt
                    Receipt.MdiParent = MainForm
                    Receipt.Show()
                    Receipt.BringToFront()

                Else
                    Receipt.Activate()
                End If

            Case "CustomerAcc"
                If CustomerAcc Is Nothing Then
                    CustomerAcc = New frmCustomerAccount
                    CustomerAcc.MdiParent = MainForm
                    CustomerAcc.Show()
                    CustomerAcc.BringToFront()

                Else
                    CustomerAcc.Activate()
                End If

            Case "SupplierAcc"
                If SupplierAcc Is Nothing Then
                    SupplierAcc = New frmSupplierAccount
                    SupplierAcc.MdiParent = MainForm
                    SupplierAcc.Show()
                    SupplierAcc.BringToFront()

                Else
                    SupplierAcc.Activate()
                End If
            Case "PaymentSearch"
                If PaymentSearch Is Nothing Then
                    PaymentSearch = New frmPaymentSearch
                    PaymentSearch.MdiParent = MainForm
                    PaymentSearch.Show()
                    PaymentSearch.BringToFront()

                Else
                    PaymentSearch.Activate()
                End If

            Case "BankMaster"
                If BankMaster Is Nothing Then
                    BankMaster = New frmBankMaster
                    BankMaster.MdiParent = MainForm
                    BankMaster.Show()
                    BankMaster.BringToFront()

                Else
                    BankMaster.Activate()
                End If

            Case "BankVoucher"
                If BankVoucher Is Nothing Then
                    BankVoucher = New frmBankVoucher
                    BankVoucher.MdiParent = MainForm
                    BankVoucher.Show()
                    BankVoucher.BringToFront()

                Else
                    BankVoucher.Activate()
                End If


                'Case "PurchaseReturn"
                '    If PurchaseReturn Is Nothing Then
                '        PurchaseReturn = New frmPurchaseReturn
                '        PurchaseReturn.MdiParent = MainForm
                '        PurchaseReturn.Show()
                '        PurchaseReturn.BringToFront()

                '    Else
                '        PurchaseReturn.Activate()
                '    End If

            Case "PurchaseSearch"
                If PurchaseSearch Is Nothing Then
                    PurchaseSearch = New frmPurchaseSearch
                    PurchaseSearch.MdiParent = MainForm
                    PurchaseSearch.Show()
                    PurchaseSearch.BringToFront()

                Else
                    PurchaseSearch.Activate()
                End If


                'Case "PurchaseReturn Search"
                '    If PurchaseReturnSearch Is Nothing Then
                '        PurchaseReturnSearch = New frmPurchaseReturnSearch
                '        PurchaseReturnSearch.MdiParent = MainForm
                '        PurchaseReturnSearch.Show()
                '        PurchaseReturnSearch.BringToFront()

                '    Else
                '        PurchaseReturnSearch.Activate()
                '    End If


            Case "Sale Search"
                If SaleSearch Is Nothing Then
                    SaleSearch = New frmSaleSearch
                    SaleSearch.MdiParent = MainForm
                    SaleSearch.Show()
                    SaleSearch.BringToFront()

                Else
                    PurchaseSearch.Activate()
                End If

            Case "ReceiptSearch"
                If ReceiptSearch Is Nothing Then
                    ReceiptSearch = New frmReceiptSearch
                    ReceiptSearch.MdiParent = MainForm
                    ReceiptSearch.Show()
                    ReceiptSearch.BringToFront()

                Else
                    ReceiptSearch.Activate()
                End If


                'Case "SaleReturn Search"
                '    If SaleReturnSearch Is Nothing Then
                '        SaleReturnSearch = New frmSaleReturnSearch
                '        SaleReturnSearch.MdiParent = MainForm
                '        SaleReturnSearch.Show()
                '        SaleReturnSearch.BringToFront()

                '    Else
                '        SaleReturnSearch.Activate()
                '    End If

            Case "Backup"
                If BackupDatabase Is Nothing Then
                    BackupDatabase = New frmBackup
                    BackupDatabase.MdiParent = MainForm
                    BackupDatabase.Show()
                    BackupDatabase.BringToFront()

                Else
                    BackupDatabase.Activate()
                End If

            Case "BackupDB"
                If BackupDatabase Is Nothing Then
                    BackupDatabase = New frmBackup

                    BackupDatabase.Show()

                End If

        End Select



    End Sub
    Public Sub DisplayFormsOnClick(ByVal strPrefix As String, Optional ByVal strCode As String = "-1", Optional ByVal blnEnable As Boolean = False)

        Select Case UCase(strPrefix)
            'Case "PI"
            '    PurchaseInvoice = New frmPurchaseInvoice
            '    PurchaseInvoice.MdiParent = MainForm
            '    PurchaseInvoice.Show()
            '    PurchaseInvoice.Display(strCode)
            Case "PAY"
                payment = New frmPayment
                payment.MdiParent = MainForm
                payment.Show()
                payment.Display(strCode)


                'Case "PR"
                '    PurchaseReturn = New frmPurchaseReturn
                '    PurchaseReturn.MdiParent = MainForm
                '    PurchaseReturn.Show()
                '    PurchaseReturn.Display(strCode)

                'Case "SI"
                '    SaleInvoice = New frmSaleInvoice
                '    SaleInvoice.MdiParent = MainForm
                '    SaleInvoice.Show()
                '    SaleInvoice.Display(strCode)

                'Case "SR"
                '    SaleReturn = New frmSaleReturn
                '    SaleReturn.MdiParent = MainForm
                '    SaleReturn.Show()
                '    SaleReturn.Display(strCode)

            Case "REC"
                Receipt = New frmReceipt
                Receipt.MdiParent = MainForm
                Receipt.Show()
                Receipt.Display(strCode)
        End Select
    End Sub
    Public Function showCode(ByVal Head As String) As String
        On Error GoTo errorhandler

        Dim comShowCode As SqlClient.SqlCommand
        Dim drShowCode As SqlClient.SqlDataReader
        Dim lngLastValue As Long
        Dim strLastValue As String
        Dim strPrefix As String
        Dim strShowCode As String
        Dim chrPrefix As Char
        Dim strQuerry As String

        strQuerry = "Select prefix,lastValue,increment,stop from sequenceMaster where head='" & Head & "'"
        comShowCode = New SqlClient.SqlCommand(strQuerry, gl_Con)
        drShowCode = comShowCode.ExecuteReader()

        While drShowCode.Read
            lngLastValue = drShowCode.Item("lastValue") + drShowCode.Item("increment")
            If lngLastValue > drShowCode.Item("stop") Then
                strShowCode = "-1"
            Else
                strLastValue = lngLastValue
                If Len(CStr(lngLastValue)) <> Len(CStr(drShowCode.Item("stop"))) Then
                    chrPrefix = "0"
                    strLastValue = strLastValue.PadLeft(Len(CStr(drShowCode.Item("stop"))), chrPrefix)
                End If
                strShowCode = drShowCode.Item("prefix") & strLastValue
            End If
        End While



        drShowCode.Close()
        showCode = strShowCode
        Exit Function
errorhandler:
        MsgBox(Err.Number & vbCrLf & Err.Description)
    End Function
    Public Sub AppClose()
        'On Error GoTo ErrHnd
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim Trans1 As SqlClient.SqlTransaction


        Try


            str1 = "update LoginDetails set Logout1 = '" & Date.Now & "' where SlNo=" & gl_Sino + 1 & ""
            Trans1 = gl_Con.BeginTransaction
            cmdCom1.Transaction = Trans1
            cmdCom1.Connection = gl_Con
            cmdCom1.CommandText = str1
            cmdCom1.ExecuteNonQuery()

            Trans1.Commit()

            ' Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'ErrHnd:
    End Sub
    '    Public Function showCodeCom(ByVal Head As String) As String
    '        On Error GoTo errorhandler

    '        Dim comShowCode As SqlClient.SqlCommand
    '        Dim drShowCode As SqlClient.SqlDataReader
    '        Dim lngLastValue As Long
    '        Dim strLastValue As String
    '        Dim strPrefix As String
    '        Dim strShowCode As String
    '        Dim chrPrefix As Char
    '        Dim strQuerry As String

    '        strQuerry = "Select prefix,lastValue,increment,stop from companyMaster where companyname='" & Head & "'"
    '        comShowCode = New SqlClient.SqlCommand(strQuerry, gl_Con)
    '        drShowCode = comShowCode.ExecuteReader()

    '        While drShowCode.Read
    '            lngLastValue = drShowCode.Item("lastValue") + drShowCode.Item("increment")
    '            If lngLastValue > drShowCode.Item("stop") Then
    '                strShowCode = "-1"
    '            Else
    '                strLastValue = lngLastValue
    '                If Len(CStr(lngLastValue)) <> Len(CStr(drShowCode.Item("stop"))) Then
    '                    chrPrefix = "0"
    '                    strLastValue = strLastValue.PadLeft(Len(CStr(drShowCode.Item("stop"))), chrPrefix)
    '                End If
    '                strShowCode = drShowCode.Item("prefix") & strLastValue
    '            End If
    '        End While



    '        drShowCode.Close()
    '        showCodeCom = strShowCode
    '        Exit Function
    'errorhandler:
    '        MsgBox(Err.Number & vbCrLf & Err.Description)
    '    End Function
    Public Function convertToFormDateFormat(ByVal DateValue As String) As String
        Dim strDay As String
        Dim strMonth As String
        Dim strYear As String

        Dim dtTemp As DateTime
        Dim strTemp As String
        Dim strTemp2 As String
        Dim strTemp3 As String
        Dim strPart1 As String
        Dim strPart2 As String
        Dim strPart3 As String
        Dim intFirstOccOfSlash As Integer
        Dim intLastOccOfSlash As Integer
        Dim intLengthOfDate As Integer
        Dim iRow As Integer
        Dim chTemp As Char
        Try

            'getting the system date format
            'the temporary data
            dtTemp = "10 Nov 2004"
            strTemp = dtTemp

            'the real data
            DateValue = Trim(DateValue)

            'getting the required information
            intLengthOfDate = Len(strTemp)

            'getting the real data according to temp data and removing the time part
            DateValue = CStr(CDate(DateValue).Date)

            'setting the seperator to be / instead of any other
            strTemp3 = ""
            For iRow = 0 To intLengthOfDate - 1
                chTemp = strTemp.Chars(iRow)
                If (IsNumeric(chTemp) = False) And (InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ", UCase(chTemp), CompareMethod.Text) <= 0) Then
                    chTemp = "/"
                End If
                strTemp3 = strTemp3 & chTemp
            Next
            strTemp = strTemp3

            'setting the seperator to be / instead of any other
            strTemp3 = ""
            For iRow = 0 To Len(DateValue) - 1
                chTemp = DateValue.Chars(iRow)
                If (IsNumeric(chTemp) = False) And (InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ", UCase(chTemp), CompareMethod.Text) <= 0) Then
                    chTemp = "/"
                End If
                strTemp3 = strTemp3 & chTemp
            Next
            DateValue = strTemp3

            'Searching the slash in the date variable
            intFirstOccOfSlash = InStr(strTemp, "/", CompareMethod.Text)
            intLastOccOfSlash = InStrRev(strTemp, "/")

            'getting the date part of temporary
            strPart1 = Mid(strTemp, 1, intFirstOccOfSlash - 1)
            strPart2 = Mid(strTemp, intFirstOccOfSlash + 1, intLastOccOfSlash - intFirstOccOfSlash - 1)
            strPart3 = Mid(strTemp, intLastOccOfSlash + 1, intLengthOfDate - intLastOccOfSlash)

            'getting the date part of real data
            strMonth = Mid(DateValue, 1, InStr(DateValue, "/", CompareMethod.Text) - 1)
            strDay = Mid(DateValue, InStr(DateValue, "/", CompareMethod.Text) + 1, InStrRev(DateValue, "/") - InStr(DateValue, "/", CompareMethod.Text) - 1)
            strYear = Mid(DateValue, InStrRev(DateValue, "/") + 1, Len(DateValue) - InStrRev(DateValue, "/"))

            'now sorting the data to get the proper format
            'i.e. trying to get the proper day, month and year
            Select Case UCase(strPart1)
                Case "10" 'case of DD
                    Select Case UCase(strPart2)
                        Case "NOV", "NOVEMBER" 'Case of MMM
                            'here the format is dd/Month/yyyy
                            'so strPart1 is DD, strpart2 is month, strpart3 is year
                            'swaping Day and month variables
                            strTemp2 = strDay
                            strDay = strMonth
                            strMonth = strTemp2
                        Case "11"
                            'here the format is dd/MM/yyyy
                            'so strPart1 is DD, strpart2 is month, strpart3 is year
                            'swaping Day and month variables
                            strTemp2 = strDay
                            strDay = strMonth
                            strMonth = MonthName(strTemp2, True)
                        Case "2004", "04" 'Case of yyyy
                            'here the format is dd/yyyy/Month
                            'so strPart1 is DD, strpart2 is year, strpart3 is month
                            'swaping Day month and year variable
                            strTemp2 = strDay
                            strDay = strMonth
                            strMonth = strYear
                            strYear = strTemp2
                    End Select
                Case "NOV", "NOVEMBER" 'Case of MMM
                    Select Case UCase(strPart2)
                        Case "2004", "04" 'Case of yyyy
                            'here the format is month/year/day
                            'so strPart1 is month, strpart2 is year, strpart3 is date
                            'swaping Day and year variables
                            strTemp2 = strDay
                            strDay = strYear
                            strYear = strTemp2
                        Case "10"
                            'here the format is month/day/year
                            'so strPart1 is month, strpart2 is day, strpart3 is year
                            'no swaping required
                    End Select
                Case "11" 'Case of MMM
                    Select Case UCase(strPart2)
                        Case "2004", "04" 'Case of yyyy
                            'here the format is month/year/day
                            'so strPart1 is month, strpart2 is year, strpart3 is date
                            'swaping Day and year variables
                            strTemp2 = strDay
                            strDay = strYear
                            strYear = strTemp2
                            strMonth = MonthName(strMonth, True)
                        Case "10"
                            'here the format is month/day/year
                            'so strPart1 is month, strpart2 is day, strpart3 is year
                            'no swaping required
                            strMonth = MonthName(strMonth, True)
                    End Select
                Case "2004", "04" 'Case of yyyy
                    Select Case UCase(strPart2)
                        Case "NOV", "NOVEMBER"
                            'here the format is year/month/day
                            'so strPart1 is year, strpart2 is month, strpart3 is date
                            'swaping Day, month and year variables
                            strTemp2 = strYear
                            strYear = strMonth
                            strMonth = strDay
                            strDay = strTemp2
                        Case "11"  'Case of MM
                            'here the format is year/month/day
                            'so strPart1 is year, strpart2 is month, strpart3 is date
                            'swaping Day, month and year variables
                            strTemp2 = strYear
                            strYear = strMonth
                            strMonth = MonthName(strDay, True)
                            strDay = strTemp2
                        Case "10" 'Case of yyyy
                            'here the format is month/day/month
                            'so strPart1 is month, strpart2 is day, strpart3 is year
                            'swaping month and year variables
                            strTemp2 = strMonth
                            strMonth = strYear
                            strYear = strTemp2
                    End Select
            End Select
            'considering the date format is MM/dd/yyyy
            If IsNumeric(strMonth) = True Then
                strMonth = MonthName(strMonth, True)
            End If

            'the form date format is dd/MM/yyyy
            convertToFormDateFormat = strDay & " " & UCase(strMonth) & " " & strYear
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub valid()
        Dim str As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim i As Integer

        str = "SELECT count(*) as Number123 from SaleMaster"
        da = New SqlClient.SqlDataAdapter(str, gl_Con)
        da.Fill(ds, "Valid")
        If ds.Tables("Valid").Rows.Count > 0 Then
            i = IIf(IsDBNull(ds.Tables("Valid").Rows(0).Item("Number123")), "", ds.Tables("CustomerMaster1").Rows(0).Item("Number123"))
        End If
        If i > 1 Then
            f_blnValidity = False
        End If




    End Sub
    Public Function showCode1(ByVal Head As String) As String
        On Error GoTo errorhandler

        Dim comShowCode As SqlClient.SqlCommand
        Dim drShowCode As SqlClient.SqlDataReader
        Dim lngLastValue As Long
        Dim strLastValue As String
        Dim strPrefix As String
        Dim strShowCode As String
        Dim chrPrefix As Char
        Dim strQuerry As String
        Dim strFinancialYear As String = Nothing

        'strQuerry = "Select prefix,lastValue,increment,stop,FinancialYear from sequenceMaster1 where head='" & Head & "'"
        If gl_strFinancialYear = gl_strCurrFinancialYear Then
            strQuerry = "Select prefix,lastValue,increment,stop from sequenceMaster1 where head='" & Head & "'"
        Else
            strQuerry = "Select prefix,lastValue,increment,stop from sequenceMaster where head='" & Head & "'"
        End If

        strFinancialYear = gl_strFinancialYear
        comShowCode = New SqlClient.SqlCommand(strQuerry, gl_Con)
        drShowCode = comShowCode.ExecuteReader()

        While drShowCode.Read
            lngLastValue = drShowCode.Item("lastValue") + drShowCode.Item("increment")
            If lngLastValue > drShowCode.Item("stop") Then
                strShowCode = "-1"
            Else
                strLastValue = lngLastValue
                If Len(CStr(lngLastValue)) <> Len(CStr(drShowCode.Item("stop"))) Then
                    chrPrefix = "0"
                    strLastValue = strLastValue.PadLeft(Len(CStr(drShowCode.Item("stop"))), chrPrefix)
                End If
                strShowCode = drShowCode.Item("prefix") & strLastValue
            End If
        End While

        strShowCode = strShowCode & "/" & gl_strFinancialYear
        drShowCode.Close()
        showCode1 = strShowCode
        Exit Function
errorhandler:
        MsgBox(Err.Number & vbCrLf & Err.Description)
    End Function
    Public Sub MinMaxDateOfMonth()
        Dim IntYear As Integer
        Dim IntMonth As Integer
        Dim IntMin As Integer = 1
        Dim IntMax As Integer
        Dim strMonthName As String
        IntYear = Year(gl_dtServerDate)
        IntMonth = Month(gl_dtServerDate)
        strMonthName = MonthName(IntMonth)
        Select Case IntMonth
            Case 1, 3, 5, 7, 8, 10, 12
                IntMax = 31
            Case 2
                If IntYear Mod 400 = 0 Then
                    IntMax = 29
                Else
                    If IntYear Mod 4 = 0 Then
                        IntMax = 29
                    Else
                        IntMax = 28
                    End If
                End If
            Case 4, 6, 9, 11
                IntMax = 30
        End Select
        gl_MinDate = IntMin & " " & strMonthName & " " & IntYear
        gl_MaxDate = IntMax & " " & strMonthName & " " & IntYear
    End Sub
    Public Function convertToServerDateFormat(ByVal DateValue As Date) As String
        Dim strDay As String
        Dim strMonth As String
        Dim strYear As String
        Try
            strDay = DateValue.Day
            strMonth = MonthName(DateValue.Month, True)
            strYear = DateValue.Year

            convertToServerDateFormat = strDay & " " & strMonth & " " & strYear
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub MsgDisplay(ByVal strMsg As String, Optional ByVal PrintMyMessage As Boolean = False)
        Select Case UCase(strMsg)
            Case "DUPLICATE"
                MsgBox("Duplicate Entry", MsgBoxStyle.Information, "IMS")
            Case "MLINK"
                MsgBox("Link information missing.", MsgBoxStyle.Information, "IMS")
            Case Else
                If PrintMyMessage = False Then
                    MsgBox(strMsg & " cannot be empty", MsgBoxStyle.Information, "IMS")
                Else
                    MsgBox(strMsg, MsgBoxStyle.Information, "IMS")
                End If
        End Select
    End Sub
End Module
