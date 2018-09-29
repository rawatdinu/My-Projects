
Imports System.IO
Imports System.Windows.Forms

Public Class frmMainMenu

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    

    

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub CompanyMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyMasterToolStripMenuItem.Click
        DisplayForm("CompanyMaster")
    End Sub

    Private Sub SupplierMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierMasterToolStripMenuItem.Click
        DisplayForm("SupplierMaster")
    End Sub

    Private Sub CustomerMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerMasterToolStripMenuItem.Click
        DisplayForm("CustomerMaster")
    End Sub

    Private Sub ItemMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemMasterToolStripMenuItem.Click
        DisplayForm("ItemMaster")
    End Sub

    Private Sub PurchaseInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceToolStripMenuItem.Click
        DisplayForm("PurchaseInvoice")
    End Sub

    Private Sub TaxMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxMasterToolStripMenuItem.Click
        DisplayForm("ConfigurationMaster")
    End Sub

    Private Sub SaleInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleInvoiceToolStripMenuItem.Click

        DisplayForm("SaleInvoice")
    End Sub

    Private Sub ItemAccountStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemAccountStatementToolStripMenuItem.Click
        DisplayForm("ItemAccountStatement")
    End Sub

    Private Sub SaleReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleReturnToolStripMenuItem.Click
        DisplayForm("SaleReturn")
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        DisplayForm("Payment")
    End Sub

    Private Sub CustomerAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerAccountToolStripMenuItem.Click
        DisplayForm("CustomerAcc")
    End Sub

    Private Sub SupplierAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierAccountToolStripMenuItem.Click
        DisplayForm("SupplierAcc")
    End Sub

    Private Sub ReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptToolStripMenuItem.Click
        DisplayForm("Receipt")
    End Sub

    Private Sub BankMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankMasterToolStripMenuItem.Click
        DisplayForm("BankMaster")
    End Sub

    Private Sub DepositToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepositToolStripMenuItem.Click
        DisplayForm("BankVoucher")
    End Sub

    Private Sub PurchaseReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnToolStripMenuItem.Click
        DisplayForm("PurchaseReturn")
    End Sub

    Private Sub PurchaseSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseSearchToolStripMenuItem.Click
        DisplayForm("PurchaseSearch")
    End Sub

    Private Sub PurchaseReturnSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnSearchToolStripMenuItem.Click
        DisplayForm("PurchaseReturn Search")
    End Sub

    Private Sub SaleSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleSearchToolStripMenuItem.Click
        DisplayForm("Sale Search")
    End Sub

    Private Sub SaleReturnSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleReturnSearchToolStripMenuItem.Click
        DisplayForm("SaleReturn Search")
    End Sub

    Private Sub StateMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateMasterToolStripMenuItem.Click
        DisplayForm("StateMaster")
    End Sub

    Private Sub CityMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CityMasterToolStripMenuItem.Click
        DisplayForm("CityMaster")
    End Sub

    Private Sub LocalityMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalityMasterToolStripMenuItem.Click
        DisplayForm("LocalityMaster")
    End Sub

    Private Sub PaymentSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentSearchToolStripMenuItem.Click
        DisplayForm("PaymentSearch")
    End Sub

    Private Sub ReceiptSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptSearchToolStripMenuItem.Click
        DisplayForm("ReceiptSearch")
    End Sub

    Private Sub AccountGroupLedgerReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountGroupLedgerReportToolStripMenuItem.Click
        DisplayForm("AccountGroupLedgerReport")
    End Sub

    Private Sub JournalVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalVoucherToolStripMenuItem.Click
        DisplayForm("JournalVoucher")
    End Sub

    Private Sub TaxInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxInvoiceToolStripMenuItem.Click
        DisplayForm("TaxInvoice")
    End Sub

    Private Sub DayBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayBookToolStripMenuItem.Click
        DisplayForm("DayBook")
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Shell("C:\Windows\System32\Calc.exe", vbNormalFocus)
    End Sub

    Private Sub NotepadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotepadToolStripMenuItem.Click
        Shell("C:\Windows\System32\notepad.exe", vbNormalFocus)
    End Sub

    
    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        If help.Visible = False Then
            help.Visible = True
        Else
            help.Visible = False
        End If

    End Sub

  
    Private Sub frmMainMenu_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        AppClose()
    End Sub

  
    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        DisplayForm("Backup")
    End Sub

    Private Sub DescriptionMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescriptionMasterToolStripMenuItem.Click
        DisplayForm("DescriptionMaster")
    End Sub

    Private Sub OpeningToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpeningToolStripMenuItem.Click
        Dim str As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim ItemCode As String
        Dim OpeningStock As Integer
        Dim ItemName As String
        Dim diff As Integer
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim Trans1 As SqlClient.SqlTransaction



        str = "SELECT ItemOpening.ItemCode, ItemOpening.ItemName, ItemOpening.[OpeningStock] FROM ItemOpening  WHERE (((ItemOpening.ItemCode)>'itm00511')) order by ItemCode"

        da = New SqlClient.SqlDataAdapter(str, gl_Con)
        da.Fill(ds, "Opening")

        If ds.Tables("Opening").Rows.Count > 0 Then
            For i = 0 To ds.Tables("Opening").Rows.Count - 1
                ItemCode = IIf(IsDBNull(ds.Tables("Opening").Rows(i).Item("ItemCode")), "", ds.Tables("Opening").Rows(i).Item("ItemCode"))
                ItemName = IIf(IsDBNull(ds.Tables("Opening").Rows(i).Item("ItemName")), "", ds.Tables("Opening").Rows(i).Item("ItemName"))
                OpeningStock = IIf(IsDBNull(ds.Tables("Opening").Rows(i).Item("OpeningStock")), 0, ds.Tables("Opening").Rows(i).Item("OpeningStock"))
              
                'str1 = "update ItemMaster set CurrentStock=" & OpeningStock & ",CurrentSubStock=" & OpeningStock & " where ItemCode='" & ItemCode & "'"

                str1 = "Insert into ItemMaster(ItemCode, ItemName,OpeningStock,CurrentStock,OpeningSubStock,CurrentSubStock) values('" & ItemCode & "','" & ItemName & "'," & OpeningStock & "," & OpeningStock & "," & OpeningStock & "," & OpeningStock & ")"

                Trans1 = gl_Con.BeginTransaction
                cmdCom1.Transaction = Trans1
                cmdCom1.Connection = gl_Con
                cmdCom1.CommandText = str1
                cmdCom1.ExecuteNonQuery()
                Trans1.Commit()

                ItemCode = ""
                OpeningStock = 0

            Next
        End If

    End Sub

    Private Sub PaymentTermMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentTermMasterToolStripMenuItem.Click
        DisplayForm("PaymentTermMaster")
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        DisplayForm("QuotationMaster")
    End Sub

    Private Sub TermsAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TermsAToolStripMenuItem.Click
        DisplayForm("TCMaster")
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        DisplayForm("ChallanMaster")
    End Sub

    Private Sub CurrencyMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrencyMasterToolStripMenuItem.Click
        DisplayForm("CurrencyMaster")
    End Sub

    Private Sub OverHeadMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverHeadMasterToolStripMenuItem.Click
        DisplayForm("OverHeadMaster")
    End Sub

    Private Sub QuotationMaster2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationMaster2ToolStripMenuItem.Click
        DisplayForm("QuotationMaster2")
    End Sub

    Private Sub JournalVoucher1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalVoucher1ToolStripMenuItem.Click
        DisplayForm("JournalVoucher1")
    End Sub

    Private Sub PurchaseInvoice1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoice1ToolStripMenuItem.Click
        DisplayForm("PurchaseInvoice1")
    End Sub

    Private Sub SaleInvoice1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleInvoice1ToolStripMenuItem.Click
        DisplayForm("SaleInvoice1")
    End Sub
End Class
