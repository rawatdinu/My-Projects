Imports System.Data.SqlClient
Imports System.IO

Public Class frmPayment
    Dim str As String
    Dim OBType As String
    Dim num1, num2, num3, num4 As Decimal
    Dim i As Integer = 0

    Sub GetSupplierBalance()
        Try
            Try
                num1 = 0
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where PartyID=@d1 group By PartyID"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@d1", txtSupplierID.Text)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If (rdr.Read() = True) Then
                    num1 = rdr.GetValue(0)
                End If
                con.Close()
                lblBalance.Text = num1
                If Val(lblBalance.Text) >= 0 Then
                    str = "CR"
                ElseIf Val(lblBalance.Text < 0) Then
                    str = "DR"
                End If
                lblBalance.Text = Math.Abs(Val(lblBalance.Text))
                lblBalance.Text = (lblBalance.Text & " " & str).ToString()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 T_ID FROM Payment ORDER BY T_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("T_ID")
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
            txtT_ID.Text = GenerateID()
            txtTransactionNo.Text = "T-" & Val(GenerateID())
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
  
    Sub Reset()
        txtAddress.Text = ""
        txtCity.Text = ""
        txtContactNo.Text = ""
        txtRemarks.Text = ""
        txtSupplierID.Text = ""
        txtSupplierName.Text = ""
        txtTransactionAmount.Text = ""
        txtPaymentModeDetails.Text = ""
        cmbPaymentMode.SelectedIndex = 0
        dtpTranactionDate.Value = Today
        lblBalance.Text = "0.00"
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnSelection.Enabled = True
        auto()
    End Sub
 
    Sub GetSupplierInfo()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT SupplierID,Name,Address,City,ContactNo from Supplier where ID=@d1"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtSup_ID.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                txtSupplierID.Text = rdr.GetValue(0)
                txtSupplierName.Text = rdr.GetValue(1)
                txtAddress.Text = rdr.GetValue(2)
                txtCity.Text = rdr.GetValue(3)
                txtContactNo.Text = rdr.GetValue(4)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
  
    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Payment where T_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtT_ID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                SupplierLedgerDelete(txtTransactionNo.Text)
                LedgerDelete(txtTransactionNo.Text, "Payment to " & txtSupplierName.Text & "")
                LogFunc(lblUser.Text, "deleted the payment record having transaction No. '" & txtTransactionNo.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
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


    Private Sub txtTotalPaid_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransactionAmount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTransactionAmount.Text
            Dim selectionStart = Me.txtTransactionAmount.SelectionStart
            Dim selectionLength = Me.txtTransactionAmount.SelectionLength

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


    Private Sub btnSelection_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        Me.Reset()
        frmSupplierRecord.lblSet.Text = "Payment"
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtSupplierID.Text)) = 0 Then
            MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierID.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTransactionAmount.Text)) = 0 Then
            MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTransactionAmount.Focus()
            Exit Sub
        End If
        If Val(txtTransactionAmount.Text) = 0 Then
            MessageBox.Show("Transaction amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTransactionAmount.Focus()
            Exit Sub
        End If
        If Val(txtTransactionAmount.Text) > Val(lblBalance.Text) Then
            MessageBox.Show("Transaction amount can not be more than balance", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransactionAmount.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Payment(T_ID, TransactionID, Date, PaymentMode, SupplierID, Amount,Remarks,PaymentModeDetails) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtT_ID.Text))
            cmd.Parameters.AddWithValue("@d2", txtTransactionNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpTranactionDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", cmbPaymentMode.Text)
            cmd.Parameters.AddWithValue("@d5", Val(txtSup_ID.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtTransactionAmount.Text))
            cmd.Parameters.AddWithValue("@d7", txtRemarks.Text)
            cmd.Parameters.AddWithValue("@d8", txtPaymentModeDetails.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            If cmbPaymentMode.SelectedIndex = 0 Then
                LedgerSave(dtpTranactionDate.Value.Date, "Cash Account", txtTransactionNo.Text, "Payment to " & txtSupplierName.Text.Trim & "", Val(txtTransactionAmount.Text), 0, txtSupplierID.Text)
            End If
            If cmbPaymentMode.SelectedIndex = 1 Or cmbPaymentMode.SelectedIndex = 2 Then
                LedgerSave(dtpTranactionDate.Value.Date, "Bank Account", txtTransactionNo.Text, "Payment to " & txtSupplierName.Text.Trim & "", Val(txtTransactionAmount.Text), 0, txtSupplierID.Text)
            End If
            If cmbPaymentMode.SelectedIndex = 0 Then
                SupplierLedgerSave(dtpTranactionDate.Value.Date, "Cash Account", txtTransactionNo.Text, "Payment", Val(txtTransactionAmount.Text), 0, txtSupplierID.Text)
            End If
            If cmbPaymentMode.SelectedIndex = 1 Or cmbPaymentMode.SelectedIndex = 2 Then
                SupplierLedgerSave(dtpTranactionDate.Value.Date, "Bank Account", txtTransactionNo.Text, "Payment", Val(txtTransactionAmount.Text), 0, txtSupplierID.Text)
            End If
            LogFunc(lblUser.Text, "added the new payment having transaction No. '" & txtTransactionNo.Text & "'")
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click

        If Len(Trim(txtSupplierID.Text)) = 0 Then
            MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierID.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTransactionAmount.Text)) = 0 Then
            MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTransactionAmount.Focus()
            Exit Sub
        End If
        If Val(txtTransactionAmount.Text) = 0 Then
            MessageBox.Show("Transaction amount must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTransactionAmount.Focus()
            Exit Sub
        End If
        If Val(txtTransactionAmount.Text) - Val(txtTempAmt.Text) > Val(lblBalance.Text) Then
            MessageBox.Show("Transaction amount can not be more than balance", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransactionAmount.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Payment set TransactionID=@d2, Date=@d3, PaymentMode=@d4, SupplierID=@d5, Amount=@d6,Remarks=@d7,PaymentModeDetails=@d8 where T_ID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtT_ID.Text))
            cmd.Parameters.AddWithValue("@d2", txtTransactionNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpTranactionDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", cmbPaymentMode.Text)
            cmd.Parameters.AddWithValue("@d5", Val(txtSup_ID.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtTransactionAmount.Text))
            cmd.Parameters.AddWithValue("@d7", txtRemarks.Text)
            cmd.Parameters.AddWithValue("@d8", txtPaymentModeDetails.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            If cmbPaymentMode.SelectedIndex = 0 Then
                LedgerUpdate(dtpTranactionDate.Value.Date, "Cash Account", Val(txtTransactionAmount.Text), 0, txtSupplierID.Text, txtTransactionNo.Text, "Payment to " & txtSupplierName.Text.Trim & "")
            End If
            If cmbPaymentMode.SelectedIndex = 1 Or cmbPaymentMode.SelectedIndex = 2 Then
                LedgerUpdate(dtpTranactionDate.Value.Date, "Bank Account", Val(txtTransactionAmount.Text), 0, txtSupplierID.Text, txtTransactionNo.Text, "Payment to " & txtSupplierName.Text.Trim & "")
            End If
            If cmbPaymentMode.SelectedIndex = 0 Then
                SupplierLedgerUpdate(dtpTranactionDate.Value.Date, "Cash Account", Val(txtTransactionAmount.Text), 0, txtTransactionNo.Text, "Payment")
            End If
            If cmbPaymentMode.SelectedIndex = 1 Or cmbPaymentMode.SelectedIndex = 2 Then
                SupplierLedgerUpdate(dtpTranactionDate.Value.Date, "Bank Account", Val(txtTransactionAmount.Text), 0, txtTransactionNo.Text, "Payment")
            End If
            LogFunc(lblUser.Text, "updated payment record having transaction No. '" & txtTransactionNo.Text & "'")
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            con.Close()
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

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Me.Reset()
        frmPaymentRecord.lblSet.Text = "Payment"
        frmPaymentRecord.Reset()
        frmPaymentRecord.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
