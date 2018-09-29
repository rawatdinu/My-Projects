Imports System.Data.SqlClient
Imports System.IO

Public Class frmSupplier
    Sub Reset()
        txtSupplierName.Text = ""
        txtAddress.Text = ""
        txtRemarks.Text = ""
        txtSupplierName.Text = ""
        txtSupplierID.Text = ""
        txtContactNo.Text = ""
        txtEmailID.Text = ""
        cmbState.SelectedIndex = -1
        txtZipCode.Text = ""
        txtCity.Text = ""
        txtSupplierName.Focus()
        txtGSTIN.Text = ""
        txtPAN.Text = ""
        txtCIN.Text = ""
        txtSTNo.Text = ""
        txtAccountName.Text = ""
        txtAccountNo.Text = ""
        txtBank.Text = ""
        txtBranch.Text = ""
        txtIFSCcode.Text = ""
        cmbOpeningBalanceType.SelectedIndex = 0
        txtOpeningBalance.Text = "0.00"
        cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOpeningBalanceType.Enabled = True
        txtOpeningBalance.ReadOnly = False
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        auto()
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ID FROM Supplier ORDER BY ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ID")
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
            txtSupplierID.Text = "S-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl2 As String = "SELECT Supplier.ID FROM Supplier INNER JOIN PurchaseOrder ON Supplier.ID = PurchaseOrder.SupplierID where Supplier.ID=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Purchase order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "SELECT Supplier.ID FROM Supplier INNER JOIN Stock ON Supplier.ID = Stock.SupplierID where Supplier.ID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Purchase Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl1 As String = "SELECT Supplier.ID FROM Supplier INNER JOIN Payment ON Supplier.ID = Payment.SupplierID where Supplier.ID=@d1"
            cmd = New SqlCommand(cl1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Payment Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Supplier where ID =" & txtID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                LedgerDelete(txtSupplierID.Text, "Opening Balance")
                SupplierLedgerDelete(txtSupplierID.Text)
                LogFunc(lblUser.Text, "deleted the supplier record having supplier id '" & txtSupplierID.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbState_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbState.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub


    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtSupplierName.Text)) = 0 Then
            MessageBox.Show("Please enter supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show("Please Enter Address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCity.Text)) = 0 Then
            MessageBox.Show("Please Enter City", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCity.Focus()
            Exit Sub
        End If
        If cmbState.Text = "" Then
            MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbState.Focus()
            Return
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Exit Sub
        End If
        If Len(Trim(txtOpeningBalance.Text)) = 0 Then
            MessageBox.Show("Please Enter Opening Balance", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOpeningBalance.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select RTRIM(ContactNo) from Supplier where ContactNo=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtContactNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Supplier(ID, SupplierID, [Name], Address, City, ContactNo, EmailID,Remarks,State,ZipCode,GSTIN,CIN,PAN,AccountName,AccountNumber,Bank,Branch,IFSCCode,OpeningBalance,OpeningBalanceType) VALUES (@d1,@d2,@d3,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtSupplierID.Text)
            cmd.Parameters.AddWithValue("@d3", txtSupplierName.Text)
            cmd.Parameters.AddWithValue("@d5", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d6", txtCity.Text)
            cmd.Parameters.AddWithValue("@d7", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d8", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d9", txtRemarks.Text)
            cmd.Parameters.AddWithValue("@d10", cmbState.Text)
            cmd.Parameters.AddWithValue("@d11", txtZipCode.Text)
            cmd.Parameters.AddWithValue("@d12", txtGSTIN.Text)
            cmd.Parameters.AddWithValue("@d14", txtCIN.Text)
            cmd.Parameters.AddWithValue("@d15", txtPAN.Text)
            cmd.Parameters.AddWithValue("@d16", txtAccountName.Text)
            cmd.Parameters.AddWithValue("@d17", txtAccountNo.Text)
            cmd.Parameters.AddWithValue("@d18", txtBank.Text)
            cmd.Parameters.AddWithValue("@d19", txtBranch.Text)
            cmd.Parameters.AddWithValue("@d20", txtIFSCcode.Text)
            cmd.Parameters.AddWithValue("@d21", Val(txtOpeningBalance.Text))
            cmd.Parameters.AddWithValue("@d22", cmbOpeningBalanceType.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            If cmbOpeningBalanceType.SelectedIndex = 0 And Val(txtOpeningBalance.Text) > 0 Then
                LedgerSave(Today, txtSupplierName.Text, txtSupplierID.Text, "Opening Balance", 0, Val(txtOpeningBalance.Text), txtSupplierID.Text)
                SupplierLedgerSave(Today, txtSupplierName.Text, txtSupplierID.Text, "Opening Balance", 0, Val(txtOpeningBalance.Text), txtSupplierID.Text)
            End If
            If cmbOpeningBalanceType.SelectedIndex = 1 And Val(txtOpeningBalance.Text) > 0 Then
                LedgerSave(Today, txtSupplierName.Text, txtSupplierID.Text, "Opening Balance", Val(txtOpeningBalance.Text), 0, txtSupplierID.Text)
                SupplierLedgerSave(Today, txtSupplierName.Text, txtSupplierID.Text, "Opening Balance", Val(txtOpeningBalance.Text), 0, txtSupplierID.Text)
            End If
            LogFunc(lblUser.Text, "added the new supplier having supplier id '" & txtSupplierID.Text & "'")
            MessageBox.Show("Successfully saved", "Supplier Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
           
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click

        If Len(Trim(txtSupplierName.Text)) = 0 Then
            MessageBox.Show("Please enter supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show("Please Enter Address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCity.Text)) = 0 Then
            MessageBox.Show("Please Enter City", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCity.Focus()
            Exit Sub
        End If
        If cmbState.Text = "" Then
            MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbState.Focus()
            Return
        End If
        If cmbState.Text = "" Then
            MessageBox.Show("Please enter state", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbState.Focus()
            Return
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Exit Sub
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "update LedgerBook set [Name]=@d3 where PartyID=@d1 and Name=@d2"
            cmd = New SqlCommand(cb1)
            cmd.Parameters.AddWithValue("@d1", txtSupplierID.Text)
            cmd.Parameters.AddWithValue("@d2", txtSupName.Text)
            cmd.Parameters.AddWithValue("@d3", txtSupplierName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "update SupplierLedgerBook set [Name]=@d3 where PartyID=@d1 and Name=@d2"
            cmd = New SqlCommand(cb3)
            cmd.Parameters.AddWithValue("@d1", txtSupplierID.Text)
            cmd.Parameters.AddWithValue("@d2", txtSupName.Text)
            cmd.Parameters.AddWithValue("@d3", txtSupplierName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update supplier set SupplierID=@d2,[Name]=@d3, Address=@d5,City=@d6, ContactNo=@d7, EmailID=@d8,Remarks=@d9,State=@d10,ZipCode=@d11,GSTIN=@d12,CIN=@d14,PAN=@d15,AccountName=@d16,AccountNumber=@d17,Bank=@d18,Branch=@d19,IFSCCode=@d20 where ID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d2", txtSupplierID.Text)
            cmd.Parameters.AddWithValue("@d3", txtSupplierName.Text)
            cmd.Parameters.AddWithValue("@d5", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d6", txtCity.Text)
            cmd.Parameters.AddWithValue("@d7", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d8", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d9", txtRemarks.Text)
            cmd.Parameters.AddWithValue("@d10", cmbState.Text)
            cmd.Parameters.AddWithValue("@d11", txtZipCode.Text)
            cmd.Parameters.AddWithValue("@d12", txtGSTIN.Text)
            cmd.Parameters.AddWithValue("@d14", txtCIN.Text)
            cmd.Parameters.AddWithValue("@d15", txtPAN.Text)
            cmd.Parameters.AddWithValue("@d16", txtAccountName.Text)
            cmd.Parameters.AddWithValue("@d17", txtAccountNo.Text)
            cmd.Parameters.AddWithValue("@d18", txtBank.Text)
            cmd.Parameters.AddWithValue("@d19", txtBranch.Text)
            cmd.Parameters.AddWithValue("@d20", txtIFSCcode.Text)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            LogFunc(lblUser.Text, "updated the supplier having supplier id '" & txtSupplierID.Text & "'")
            MessageBox.Show("Successfully updated", "Supplier Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Dim frm As New frmSupplierRecord
        frm.lblSet.Text = "Supplier Entry"
        frm.Getdata()
        frm.ShowDialog()
    End Sub

    Private Sub btnClose_Click_1(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtOpeningBalance_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpeningBalance.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtOpeningBalance.Text
            Dim selectionStart = Me.txtOpeningBalance.SelectionStart
            Dim selectionLength = Me.txtOpeningBalance.SelectionLength

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
End Class
