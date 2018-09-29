Imports System.Data.SqlClient
Imports System.IO

Public Class frmServiceBilling
    Dim st2 As String

    Sub Reset()
        txtCID.Text = ""
        txtRemarks.Text = ""
        txtCustomerName.Text = ""
        txtCustomerID.Text = ""
        txtInvoiceNo.Text = ""
        txtGrandTotal.Text = ""
        txtTotalPayment.Text = ""
        txtPaymentDue.Text = ""
        txtServiceCode.Text = ""
        txtRepairCharges.Text = ""
        txtUpfront.Text = ""
        txtServiceTaxPer.Text = "0.00"
        txtServiceTaxAmount.Text = "0.00"
        dtpInvoiceDate.Text = Today
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnSave.Enabled = True
        btnPrint.Enabled = False
        txtContactNo.Text = ""
        auto()
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 Inv_ID FROM InvoiceInfo1 ORDER BY Inv_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("Inv_ID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function
    Sub auto()
        Try
            txtID.Text = GenerateID()
            txtInvoiceNo.Text = "SB-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        frmServicesRecord1.Reset()
        frmServicesRecord1.lblSet.Text = "Billing"
        frmServicesRecord1.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Sub Print()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptServiceBillingInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT InvoiceInfo1.Inv_ID, InvoiceInfo1.InvoiceNo, InvoiceInfo1.InvoiceDate, InvoiceInfo1.ServiceID, InvoiceInfo1.RepairCharges, InvoiceInfo1.Upfront, InvoiceInfo1.ServiceTaxPer, InvoiceInfo1.ServiceTax,InvoiceInfo1.GrandTotal, InvoiceInfo1.TotalPaid, InvoiceInfo1.Balance, InvoiceInfo1.Remarks, Service.S_ID, Service.ServiceCode, Service.CustomerID, Service.ServiceType, Service.ServiceCreationDate,Service.ItemDescription, Service.ProblemDescription, Service.ChargesQuote, Service.AdvanceDeposit, Service.EstimatedRepairDate, Service.Remarks AS Expr1, Service.Status, Customer.ID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr3, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo1 INNER JOIN Service ON InvoiceInfo1.ServiceID = Service.S_ID INNER JOIN Customer ON Service.CustomerID = Customer.ID where InvoiceInfo1.Invoiceno=@d1"
            MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
            MyCommand1.CommandText = "SELECT * from Company"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "InvoiceInfo1")
            myDA.Fill(myDS, "Service")
            myDA.Fill(myDS, "Customer")
            myDA1.Fill(myDS, "Company")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", txtCustomerID.Text)
            rpt.SetParameterValue("p2", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
 
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from InvoiceInfo1 where Inv_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                LedgerDelete(txtInvoiceNo.Text, "Services")
                LedgerDelete(txtInvoiceNo.Text, "Payment")
                Dim st As String = "deleted the service bill having invoice no. '" & txtInvoiceNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                Reset()
                RefreshRecords()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub Compute1()
        Dim num1, num2, num3 As Double
        num1 = CDbl((Val(txtRepairCharges.Text) * Val(txtServiceTaxPer.Text)) / 100)
        num1 = Math.Round(num1, 2)
        txtServiceTaxAmount.Text = num1
        num2 = CDbl(Val(txtRepairCharges.Text) + Val(txtServiceTaxAmount.Text) - Val(txtUpfront.Text))
        num2 = Math.Round(num2, 2)
        txtGrandTotal.Text = num2
        num3 = Val(txtGrandTotal.Text) - Val(txtTotalPayment.Text)
        num3 = Math.Round(num3, 2)
        txtPaymentDue.Text = num3
    End Sub
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtCustomerName.Text)) = 0 Then
            MessageBox.Show("Please retrieve service details", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(txtRepairCharges.Text)) = 0 Then
            MessageBox.Show("Please enter service charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRepairCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtServiceTaxPer.Text)) = 0 Then
            MessageBox.Show("Please enter service tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtServiceTaxPer.Focus()
            Exit Sub
        End If
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn As String = "select * from Company"
            cmd = New SqlCommand(ctn)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If Not rdr.Read() Then
                MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into InvoiceInfo1( Inv_ID, InvoiceNo, InvoiceDate, ServiceID, RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, Remarks) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d8,@d9,@d10,@d11,@d12,@d13)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpInvoiceDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", Val(txtS_ID.Text))
            cmd.Parameters.AddWithValue("@d5", Val(txtRepairCharges.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtUpfront.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtServiceTaxPer.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtServiceTaxAmount.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtTotalPayment.Text))
            cmd.Parameters.AddWithValue("@d12", Val(txtPaymentDue.Text))
            cmd.Parameters.AddWithValue("@d13", txtRemarks.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            LedgerSave(dtpInvoiceDate.Value.Date, txtCustomerName.Text, txtInvoiceNo.Text, "Services", Val(txtGrandTotal.Text), 0, txtCustomerID.Text)
            LedgerSave(dtpInvoiceDate.Value.Date, "Cash Account", txtInvoiceNo.Text, "Payment", 0, Val(txtTotalPayment.Text), txtCustomerID.Text)
            Dim st As String = "added the new service bill having Invoice no. '" & txtInvoiceNo.Text & "'"
            LogFunc(lblUser.Text, st)
            If CheckForInternetConnection() = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    st2 = rdr.GetValue(0)
                    Dim st3 As String = "Hello, " & txtCustomerName.Text & " you have successfully received your item having invoice no. " & txtInvoiceNo.Text & ""
                    SMSFunc(txtContactNo.Text, st3, st2)
                    SMS(st3)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                End If
            End If
            con.Close()
            btnSave.Enabled = False
            RefreshRecords()
            MessageBox.Show("Successfully done", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Print()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtCustomerName.Text)) = 0 Then
            MessageBox.Show("Please retrieve service details", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(txtRepairCharges.Text)) = 0 Then
            MessageBox.Show("Please enter service charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRepairCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtServiceTaxPer.Text)) = 0 Then
            MessageBox.Show("Please enter service tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtServiceTaxPer.Focus()
            Exit Sub
        End If
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update InvoiceInfo1 set InvoiceNo=@d2, InvoiceDate=@d3, ServiceID=@d4, RepairCharges=@d5, Upfront=@d6, ServiceTaxPer=@d8, ServiceTax=@d9, GrandTotal=@d10, TotalPaid=@d11, Balance=@d12, Remarks=@d13 where Inv_ID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpInvoiceDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", Val(txtS_ID.Text))
            cmd.Parameters.AddWithValue("@d5", Val(txtRepairCharges.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtUpfront.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtServiceTaxPer.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtServiceTaxAmount.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtTotalPayment.Text))
            cmd.Parameters.AddWithValue("@d12", Val(txtPaymentDue.Text))
            cmd.Parameters.AddWithValue("@d13", txtRemarks.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            LedgerDelete(txtInvoiceNo.Text, "Services")
            LedgerDelete(txtInvoiceNo.Text, "Payment")
            LedgerSave(dtpInvoiceDate.Value.Date, txtCustomerName.Text, txtInvoiceNo.Text, "Services", Val(txtGrandTotal.Text), 0, txtCustomerID.Text)
            LedgerSave(System.DateTime.Now, "Cash Account", txtInvoiceNo.Text, "Payment", 0, Val(txtTotalPayment.Text), txtCustomerID.Text)
            Dim st As String = "updated the service bill having invoice no. '" & txtInvoiceNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnUpdate.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmServiceBillingRecord.lblSet.Text = "Billing"
        frmServiceBillingRecord.Reset()
        frmServiceBillingRecord.ShowDialog()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
        Reset()
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Print()
    End Sub

    Private Sub txtRepairCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRepairCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtRepairCharges.Text
            Dim selectionStart = Me.txtRepairCharges.SelectionStart
            Dim selectionLength = Me.txtRepairCharges.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtServiceTaxPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtServiceTaxPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtServiceTaxPer.Text
            Dim selectionStart = Me.txtServiceTaxPer.SelectionStart
            Dim selectionLength = Me.txtServiceTaxPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtRepairCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRepairCharges.TextChanged
        Compute1()
    End Sub

    Private Sub txtServiceTaxPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtServiceTaxPer.TextChanged
        Compute1()
    End Sub

    Private Sub txtUpfront_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUpfront.TextChanged
        Compute1()
    End Sub

    Private Sub txtTotalPayment_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalPayment.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTotalPayment.Text
            Dim selectionStart = Me.txtTotalPayment.SelectionStart
            Dim selectionLength = Me.txtTotalPayment.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalPayment_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalPayment.TextChanged
        Compute1()
    End Sub
End Class
