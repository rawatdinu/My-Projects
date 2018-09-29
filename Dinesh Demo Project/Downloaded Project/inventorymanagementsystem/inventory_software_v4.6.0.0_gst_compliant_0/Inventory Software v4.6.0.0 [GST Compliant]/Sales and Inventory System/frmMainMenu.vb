Imports System.Data.SqlClient
Imports System.IO

Imports Microsoft.SqlServer.Management.Smo
Imports System.Globalization

Public Class frmMainMenu
    Dim Filename As String
    Dim i1, i2 As Integer

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub
    Sub Backup()
        Try
            Dim dt As DateTime = Today
            Dim destdir As String = "Inventory_DB " & System.DateTime.Now.ToString("dd-MM-yyyy_h-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database Inventory_DB to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackupToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Backup()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        Try
            With OpenFileDialog1
                .Filter = ("DB Backup File|*.bak;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Timer2.Enabled = True
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "USE Master ALTER DATABASE Inventory_DB SET Single_User WITH Rollback Immediate Restore database Inventory_DB FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE Inventory_DB SET Multi_User "
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "Sucessfully performed the restore"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        frmRegistration.lblUser.Text = lblUser.Text
        frmRegistration.Reset()
        frmRegistration.ShowDialog()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogsToolStripMenuItem.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NotepadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NotepadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Notepad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub WordpadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WordpadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("wordpad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSWordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MSWordToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("winword.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TaskManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaskManagerToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("TaskMgr.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SystemInfoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SystemInfoToolStripMenuItem.Click
        frmSystemInfo.ShowDialog()
    End Sub
    Sub LogOut()
        frmPurchaseEntry.Hide()
        frmProduct.Hide()
        Dim st As String = "Successfully logged out"
        LogFunc(lblUser.Text, st)
        Me.Hide()
        frmLogin.Show()
        frmLogin.UserID.Text = ""
        frmLogin.Password.Text = ""
        frmLogin.UserID.Focus()
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Try
            If MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Backup()
                    LogOut()
                Else
                    LogOut()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMainMenu_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub CompanyInfoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompanyInfoToolStripMenuItem.Click
        frmCompany.lblUser.Text = lblUser.Text
        frmCompany.Reset()
        frmCompany.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        frmCustomer.lblUser.Text = lblUser.Text
        frmCustomer.Reset()
        frmCustomer.ShowDialog()
    End Sub

    Private Sub CategoryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CategoryToolStripMenuItem.Click
        frmCategory.lblUser.Text = lblUser.Text
        frmCategory.Reset()
        frmCategory.ShowDialog()
    End Sub

    Private Sub SubCategoryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SubCategoryToolStripMenuItem.Click
        frmSubCategory.lblUser.Text = lblUser.Text
        frmSubCategory.Reset()
        frmSubCategory.ShowDialog()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        frmSupplier.lblUser.Text = lblUser.Text
        frmSupplier.Reset()
        frmSupplier.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CustomerToolStripMenuItem1.Click
        frmCustomerRecord.Reset()
        frmCustomerRecord.ShowDialog()
        frmCustomerRecord.btnAddCustomer.Visible = False
    End Sub

    Private Sub SupplierToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SupplierToolStripMenuItem1.Click
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Public Sub Getdata()
        Try
                    con = New SqlConnection(cs)
                    con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),CostPrice,SellingPrice,Discount,CGST,SGST,CESS,RTRIM(Convert(nvarchar(50),Qty) + ' ' + Convert(Nvarchar(50),SalesUnit)) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and qty > 0  order by ProductName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
            cmd.Dispose()
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select ReorderPoint from Product where ProductCode=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", r.Cells(0).Value.ToString())
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then

                    i1 = rdr.GetValue(0)
                End If
                con.Close()
                cmd.Dispose()
                con = New SqlConnection(cs)
                con.Open()
                Dim ct1 As String = "select sum(Qty) from Product,Temp_Stock where Product.PID=Temp_Stock.ProductID and ProductCode=@d1"
                cmd = New SqlCommand(ct1)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", r.Cells(0).Value.ToString())
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    i2 = rdr.GetValue(0)
                End If
                con.Close()
                If i2 < i1 Then
                    r.DefaultCellStyle.BackColor = Color.Red
                End If
                con.Close()
                cmd.Dispose()
            Next

            DataGridView1.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        txtProductName.Text = ""
        Getdata()
    End Sub
    Private Sub frmMainMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub StockToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles StockToolStripMenuItem1.Click
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(DataGridView1)
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub ContactsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactsToolStripMenuItem.Click
        frmContacts.lblUser.Text = lblUser.Text
        frmContacts.Reset()
        frmContacts.ShowDialog()
    End Sub

    Private Sub IndividualToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs)
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub

    Private Sub ProductToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductToolStripMenuItem.Click
        frmProduct.lblUser.Text = lblUser.Text
        frmProduct.lblUserType.Text = lblUserType.Text
        frmProduct.Reset()
        frmProduct.ShowDialog()
    End Sub

    Private Sub ProductToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ProductToolStripMenuItem2.Click
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub

    Private Sub ServiceToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ServiceToolStripMenuItem1.Click
        frmServicesRecord.Reset()
        frmServicesRecord.ShowDialog()
    End Sub

    Private Sub BillingProductsServiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BillingProductsServiceToolStripMenuItem.Click
        frmServiceBillingRecord.Reset()
        frmServiceBillingRecord.ShowDialog()
    End Sub

    Private Sub ServiceBillingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ServiceBillingToolStripMenuItem.Click
        frmServiceDoneReport.Reset()
        frmServiceDoneReport.ShowDialog()
    End Sub

    Private Sub StockInAndStockOutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StockInAndStockOutToolStripMenuItem.Click
        frmStockInAndOutReport.ShowDialog()
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click
        frmPurchaseReport.Reset()
        frmPurchaseReport.ShowDialog()
    End Sub

    Private Sub VoucherToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VoucherToolStripMenuItem.Click
        frmVoucher.Reset()
        frmVoucher.lblUser.Text = lblUser.Text
        frmVoucher.ShowDialog()
    End Sub

    Private Sub ExpenditureToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpenditureToolStripMenuItem.Click
        frmVoucherReport.Reset()
        frmVoucherReport.ShowDialog()
    End Sub

    Private Sub CreditorsAndDebtorsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CreditorsAndDebtorsToolStripMenuItem.Click
        frmDebtorsReport.ShowDialog()
    End Sub

    Private Sub SQLServerSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmSqlServerSetting.Reset()
        frmSqlServerSetting.lblSet.Text = "Main Form"
        frmSqlServerSetting.ShowDialog()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        frmPayment.lblUser.Text = lblUser.Text
        frmPayment.Reset()
        frmPayment.ShowDialog()
    End Sub

    Private Sub PaymentsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PaymentsToolStripMenuItem.Click
        frmPaymentRecord.Reset()
        frmPaymentRecord.ShowDialog()
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmTrialBalance.Reset()
        frmTrialBalance.ShowDialog()
    End Sub

    Private Sub TaxToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaxToolStripMenuItem.Click
        frmTaxReport.Reset()
        frmTaxReport.ShowDialog()
    End Sub

    Private Sub PurchaseEntryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PurchaseEntryToolStripMenuItem.Click
        frmPurchaseEntry.lblUser.Text = lblUser.Text
        frmPurchaseEntry.lblUserType.Text = lblUserType.Text
        frmPurchaseEntry.Reset()
        frmPurchaseEntry.ShowDialog()
    End Sub

    Private Sub ServiceCreationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ServiceCreationToolStripMenuItem.Click
        frmServices.lblUser.Text = lblUser.Text
        frmServices.lblUserType.Text = lblUserType.Text
        frmServices.Reset()
        frmServices.ShowDialog()
    End Sub

    Private Sub ServiceBillingToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ServiceBillingToolStripMenuItem1.Click
        frmServiceBilling.lblUser.Text = lblUser.Text
        frmServiceBilling.lblUserType.Text = lblUserType.Text
        frmServiceBilling.Reset()
        frmServiceBilling.ShowDialog()
    End Sub
    Private Sub txtProductName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProductName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("SELECT RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),CostPrice,SellingPrice,Discount,CGST,SGST,CESS,RTRIM(Convert(nvarchar(50),Qty) + ' ' + Convert(Nvarchar(50),SalesUnit)) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and qty > 0 and ProductName like '%" & txtProductName.Text & "%' order by ProductName", con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
                    End While
                    con.Close()
                    cmd.Dispose()
                    For Each r As DataGridViewRow In Me.DataGridView1.Rows
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ct As String = "select ReorderPoint from Product where ProductCode=@d1"
                        cmd = New SqlCommand(ct)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", r.Cells(0).Value.ToString())
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then

                            i1 = rdr.GetValue(0)
                        End If
                        con.Close()
                        cmd.Dispose()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ct1 As String = "select sum(Qty) from Product,Temp_Stock where Product.PID=Temp_Stock.ProductID and ProductCode=@d1"
                        cmd = New SqlCommand(ct1)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", r.Cells(0).Value.ToString())
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then
                            i2 = rdr.GetValue(0)
                        End If
                        con.Close()
                        If i2 < i1 Then
                            r.DefaultCellStyle.BackColor = Color.Red
                        End If
                        con.Close()
                        cmd.Dispose()
                    Next

                    DataGridView1.ClearSelection()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub UnitMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnitMasterToolStripMenuItem.Click
        frmUnit.lblUser.Text = lblUser.Text
        frmUnit.Reset()
        frmUnit.ShowDialog()
    End Sub

    Private Sub PurchaseReturnToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TaxSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaxSettingToolStripMenuItem.Click
        frmTaxSetting.Reset()
        frmTaxSetting.ShowDialog()
    End Sub
    Private Sub DayBookToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DayBookToolStripMenuItem.Click
        frmGeneralDayBook.Reset()
        frmGeneralDayBook.ShowDialog()
    End Sub

    Private Sub ServicesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmSendSMS_Services.lblUser.Text = lblUser.Text
        frmSendSMS_Services.Reset()
        frmSendSMS_Services.ShowDialog()
    End Sub

    Private Sub SalesToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs)
        frmSendSMS_Sales.lblUser.Text = lblUser.Text
        frmSendSMS_Sales.Reset()
        frmSendSMS_Sales.ShowDialog()
    End Sub
End Class