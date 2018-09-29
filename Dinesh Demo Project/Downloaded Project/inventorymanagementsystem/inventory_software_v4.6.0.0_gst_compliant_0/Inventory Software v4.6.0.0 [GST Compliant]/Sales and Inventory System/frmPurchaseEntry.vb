Imports System.Data.SqlClient
Imports System.IO

Public Class frmPurchaseEntry
    Dim str As String
    Dim OBType As String
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11 As Decimal
    Sub GetPurchaseTaxType()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(PurchaseTax) from Setting"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                cmbTaxType.Text = rdr.GetValue(0)
            Else
                cmbTaxType.SelectedIndex = 1
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
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
            cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM Stock ORDER BY ST_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ST_ID")
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
            txtST_ID.Text = GenerateID()
            txtInvoiceNo.Text = "ST-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtSupplierID.Text)) = 0 Then
            MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierID.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Sorry no product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
      
        If Len(Trim(txtFreightCharges.Text)) = 0 Then
            MessageBox.Show("Please enter freight charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFreightCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtOtherCharges.Text)) = 0 Then
            MessageBox.Show("Please enter other charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOtherCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRoundOff.Text)) = 0 Then
            MessageBox.Show("Please enter round off", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoundOff.Focus()
            Exit Sub
        End If
        If cmbPurchaseType.SelectedIndex = 0 Then
            If Len(Trim(txtTotalPaid.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtTotalPaid.Text) = 0 Then
                MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPaid.Focus()
                Exit Sub
            End If
        End If
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select InvoiceNo from Stock where InvoiceNo=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Invoice No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtInvoiceNo.Text = ""
                txtInvoiceNo.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Stock(ST_ID, InvoiceNo, Date,PurchaseType, SupplierID, SubTotal, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks,ReferenceNo1,ReferenceNo2,TaxType,SupplierInvoiceNo,SupplierInvoiceDate,CGST,SGST,IGST,CESS) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", cmbPurchaseType.Text)
            cmd.Parameters.AddWithValue("@d5", Val(txtSup_ID.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtPreviousDue.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtFreightCharges.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtOtherCharges.Text))
            cmd.Parameters.AddWithValue("@d12", Val(txtTotal.Text))
            cmd.Parameters.AddWithValue("@d13", Val(txtRoundOff.Text))
            cmd.Parameters.AddWithValue("@d14", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d15", Val(txtTotalPaid.Text))
            cmd.Parameters.AddWithValue("@d16", Val(txtBalance.Text))
            cmd.Parameters.AddWithValue("@d17", txtRemarks.Text)
            cmd.Parameters.AddWithValue("@d18", txtReferenceNo1.Text)
            cmd.Parameters.AddWithValue("@d19", txtReferenceNo2.Text)
            cmd.Parameters.AddWithValue("@d20", cmbTaxType.Text)
            cmd.Parameters.AddWithValue("@d21", txtSupplierInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d22", dtpSupplierInvoiceDate.Value.Date)
            cmd.Parameters.AddWithValue("@d23", Val(txtCGST.Text))
            cmd.Parameters.AddWithValue("@d24", Val(txtSGST.Text))
            cmd.Parameters.AddWithValue("@d25", Val(txtIGST.Text))
            cmd.Parameters.AddWithValue("@d26", Val(txtCESS.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Stock_Product(StockID, ProductID,Barcode, Qty,MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount) VALUES (" & txtST_ID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(12).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(13).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(14).Value))
                    cmd.Parameters.AddWithValue("@d14", Val(row.Cells(15).Value))
                    cmd.Parameters.AddWithValue("@d15", Val(row.Cells(16).Value))
                    cmd.Parameters.AddWithValue("@d16", Val(row.Cells(17).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctx As String = "select ProductID from Temp_Stock where ProductID=@d1 and Barcode=@d2"
                    cmd = New SqlCommand(ctx)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then

                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty = Qty + " & row.Cells(4).Value & " where ProductID=@d1 and Barcode=@d2"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()

                    Else
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "insert into Temp_Stock(ProductID,Qty,Barcode) VALUES (@d1,@d2,@d3)"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                End If
            Next
            If cmbPurchaseType.SelectedIndex = 1 Then
                SupplierLedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text)
            End If
            If cmbPurchaseType.SelectedIndex = 0 Then
                SupplierLedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text)
                SupplierLedgerSave(dtpDate.Value.Date, "Cash Account", txtInvoiceNo.Text, "Payment", Val(txtTotalPaid.Text), 0, txtSupplierID.Text)
            End If
            If cmbPurchaseType.SelectedIndex = 1 Then
                LedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text)
            End If
            If cmbPurchaseType.SelectedIndex = 0 Then
                LedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text)
                LedgerSave(dtpDate.Value.Date, "Cash Account", txtInvoiceNo.Text, "Payment to " & txtSupplierName.Text & "", Val(txtTotalPaid.Text), 0, txtSupplierID.Text)
            End If
            RefreshRecords()
            LogFunc(lblUser.Text, "added the new Purchase having Invoice No. '" & txtInvoiceNo.Text & "'")
            MessageBox.Show("Successfully saved", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
        frmSupplierRecord.lblSet.Text = "Stock Entry"
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmProductRecord.lblSet.Text = "Stock"
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub
    Sub Reset()
        txtAddress.Text = ""
        txtBalance.Text = ""
        txtState.Text = ""
        txtContactNo.Text = ""
        txtSubTotal.Text = ""
        txtTotal.Text = ""
        txtSupplierID.Text = ""
        txtSupplierName.Text = ""
        txtSup_ID.Text = ""
        txtCGST.Text = "0.00"
        txtSGST.Text = "0.00"
        txtIGST.Text = "0.00"
        txtCESS.Text = "0.00"
        txtMRP.Text = ""
        txtFreightCharges.Text = "0.00"
        txtGrandTotal.Text = ""
        txtInvoiceNo.Text = ""
        txtOtherCharges.Text = "0.00"
        txtPreviousDue.Text = "0.00"
        txtRemarks.Text = ""
        txtRoundOff.Text = "0.00"
        txtTotalPaid.Text = "0.00"
        cmbPurchaseType.SelectedIndex = 1
        cmbTaxType.SelectedIndex = 1
        dtpDate.Text = Today
        btnSave.Enabled = True
        btnDelete.Enabled = False
        DataGridView1.Enabled = True
        btnAdd.Enabled = True
        pnlCalc.Enabled = True
        lblBalance.Text = "0.00"
        txtTotalPaid.ReadOnly = True
        txtTotalPaid.Enabled = False
        DataGridView1.Rows.Clear()
        btnSelection.Enabled = True
        lblUnit.Text = "Unit"
        GetPurchaseTaxType()
        cmbTaxType.Enabled = True
        lblSet.Text = ""
        Clear()
        auto()
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
        Reset()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtProductName.Text = "" Then
                MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductName.Focus()
                Exit Sub
            End If
            If txtBarcode.Text = "" Then
                MessageBox.Show("Please enter barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtQty.Text = 0 Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtMRP.Text = "" Then
                MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMRP.Focus()
                Exit Sub
            End If
            If txtPricePerQty.Text = "" Then
                MessageBox.Show("Please enter price per qty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPricePerQty.Focus()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(0).Value = Val(txtProductID.Text) And r.Cells(3).Value = txtBarcode.Text Then
                    MessageBox.Show("Same Product already added to grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Clear()
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(txtProductID.Text, txtHSNCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtQty.Text), Val(txtMRP.Text), Val(txtPricePerQty.Text), Val(txtDiscPer.Text), Val(txtDisc.Text), Val(txtCGSTPer.Text), Val(txtCGSTAmt.Text), Val(txtSGSTPer.Text), Val(txtSGSTAmt.Text), Val(txtIGSTPer.Text), Val(txtIGSTAmt.Text), Val(txtCESSPer.Text), Val(txtCESSAmt.Text), Val(txtTotalAmount.Text))
            Dim j As Double = 0
            j = SubTotal()
            j = Math.Round(j, 2)
            txtSubTotal.Text = j
            Compute()
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function SubTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + ((Val(r.Cells(4).Value) * Val(r.Cells(6).Value)) - Val(r.Cells(8).Value))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Clear()
        txtHSNCode.Text = ""
        txtProductName.Text = ""
        txtQty.Text = 1
        txtPricePerQty.Text = ""
        txtDiscPer.Text = "0.00"
        txtDisc.Text = "0.00"
        txtCESS.Text = "0.00"
        txtCESSAmt.Text = "0.00"
        txtCGSTPer.Text = "0.00"
        txtCGSTAmt.Text = "0.00"
        txtSGSTPer.Text = "0.00"
        txtSGSTAmt.Text = "0.00"
        txtIGSTPer.Text = "0.00"
        txtIGSTAmt.Text = "0.00"
        txtTotalAmount.Text = ""
        txtBarcode.Text = ""
        lblUnit.Text = "Unit"
        txtProductID.Text = ""
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = SubTotal()
            k = Math.Round(k, 2)
            txtSubTotal.Text = k
            Compute()
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Compute()
        If cmbTaxType.Text = "Exclusive" Then
            GridCalc()
            num1 = Val(txtSubTotal.Text) + Val(txtFreightCharges.Text) + Val(txtOtherCharges.Text) + Val(txtPreviousDue.Text) + Val(txtCGST.Text) + Val(txtSGST.Text) + Val(txtIGST.Text) + Val(txtCESS.Text)
            num1 = Math.Round(num1, 2)
            txtTotal.Text = num1
            num2 = Math.Round(num1, 0)
            num3 = num2 - num1
            num3 = Math.Round(num3, 2)
            txtRoundOff.Text = num3
            num4 = Val(txtTotal.Text) + Val(txtRoundOff.Text)
            num4 = Math.Round(num4, 2)
            txtGrandTotal.Text = num4
            num5 = Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)
            num5 = Math.Round(num5, 2)
            txtBalance.Text = num5

        End If
        If cmbTaxType.Text = "Inclusive" Then
            GridCalc()
            num1 = Val(txtSubTotal.Text) + Val(txtFreightCharges.Text) + Val(txtOtherCharges.Text) + Val(txtPreviousDue.Text)
            num1 = Math.Round(num1, 2)
            txtTotal.Text = num1
            num2 = Math.Round(num1, 0)
            num3 = num2 - num1
            num3 = Math.Round(num3, 2)
            txtRoundOff.Text = num3
            num4 = Val(txtTotal.Text) + Val(txtRoundOff.Text)
            num4 = Math.Round(num4, 2)
            txtGrandTotal.Text = num4
            num5 = Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)
            num5 = Math.Round(num5, 2)
            txtBalance.Text = num5

        End If
    End Sub
    Sub GridCalc()
            Dim sum1 As Double = 0
            Dim sum2 As Double = 0
            Dim sum3 As Double = 0
            Dim sum4 As Double = 0
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
            sum1 = sum1 + r.Cells(10).Value
            sum2 = sum2 + r.Cells(12).Value
            sum3 = sum3 + r.Cells(14).Value
            sum4 = sum4 + r.Cells(16).Value
            Next
            sum1 = Math.Round(sum1, 2)
            sum2 = Math.Round(sum2, 2)
            sum3 = Math.Round(sum3, 2)
            sum4 = Math.Round(sum4, 2)
            txtCGST.Text = sum1
            txtSGST.Text = sum2
            txtIGST.Text = sum3
            txtCESS.Text = sum4
    End Sub
    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            If lblSet.Text = "Not allowed" Then
                btnRemove.Enabled = False
            Else
                btnRemove.Enabled = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub frmStock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtPricePerQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPricePerQty.TextChanged
        Calc()
    End Sub

    Sub Calc()
        If cmbTaxType.Text = "Exclusive" Then
            num1 = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
            num1 = Math.Round(num1, 2)
            num7 = Val((num1 * Val(txtDiscPer.Text)) / 100)
            num7 = Math.Round(num7, 2)
            txtDisc.Text = num7
            num8 = num1 - Val(txtDisc.Text)
            num2 = Val((num8 * Val(txtCGSTPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtCGSTAmt.Text = num2

            num3 = Val((num8 * Val(txtSGSTPer.Text)) / 100)
            num3 = Math.Round(num3, 2)
            txtSGSTAmt.Text = num3

            num4 = Val((num8 * Val(txtIGSTPer.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtIGSTAmt.Text = num4

            num5 = Val((num8 * Val(txtCESSPer.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtCESSAmt.Text = num5

            num6 = num8 + num2 + num3 + num4 + num5
            num6 = Math.Round(num6, 2)
            txtTotalAmount.Text = num6
        End If
        If cmbTaxType.Text = "Inclusive" Then
            num1 = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
            num1 = Math.Round(num1, 2)
            num7 = Val((num1 * Val(txtDiscPer.Text)) / 100)
            num7 = Math.Round(num7, 2)
            txtDisc.Text = num7
            num8 = num1 - Val(txtDisc.Text)
            num2 = Val((num8 * Val(txtCGSTPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtCGSTAmt.Text = num2

            num3 = Val((num8 * Val(txtSGSTPer.Text)) / 100)
            num3 = Math.Round(num3, 2)
            txtSGSTAmt.Text = num3

            num4 = Val((num8 * Val(txtIGSTPer.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtIGSTAmt.Text = num4

            num5 = Val((num8 * Val(txtCESSPer.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtCESSAmt.Text = num5

            num6 = num8 - num7
            num6 = Math.Round(num6, 2)
            txtTotalAmount.Text = num6

        End If
    
    End Sub
    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Calc()
    End Sub

    Private Sub txtQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtQty.Text
            Dim selectionStart = Me.txtQty.SelectionStart
            Dim selectionLength = Me.txtQty.SelectionLength

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

    Private Sub txtPricePerQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPricePerQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtPricePerQty.Text
            Dim selectionStart = Me.txtPricePerQty.SelectionStart
            Dim selectionLength = Me.txtPricePerQty.SelectionLength

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

    Private Sub txtTotalPayment_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub

    Private Sub txtTotalPayment_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Exit Sub
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Me.Reset()
        frmPurchaseRecord.lblSet.Text = "Purchase"
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub

    Sub GetSupplierBalance()
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
            txtPreviousDue.Text = num1
            lblBalance.Text = Math.Abs(Val(lblBalance.Text))
            lblBalance.Text = (lblBalance.Text & " " & str).ToString()
            Compute()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetSupplierInfo()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT SupplierID,Name,Address,City,ContactNo from Supplier Where ID=@d1"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtSup_ID.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                txtSupplierID.Text = rdr.GetValue(0)
                txtSupplierName.Text = rdr.GetValue(1)
                txtAddress.Text = rdr.GetValue(2)
                txtState.Text = rdr.GetValue(3)
                txtContactNo.Text = rdr.GetValue(4)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetSupplierBalance1()
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
                Compute()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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
            Dim cl As String = "select ST_ID from Stock,PurchaseReturn where PurchaseReturn.PurchaseID=Stock.ST_ID and ST_ID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Purchase Return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Stock where ST_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty = Qty - " & row.Cells(4).Value & " where ProductID=@d1 and Barcode=@d2"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                LedgerDelete(txtInvoiceNo.Text, "Payment to " & txtSupplierName.Text & "")
                LedgerDelete(txtInvoiceNo.Text, "Purchase")
                SupplierLedgerDelete(txtInvoiceNo.Text)
                LogFunc(lblUser.Text, "deleted the purchase record having Invoice No. '" & txtInvoiceNo.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmSupplierRecord.lblSet.Text = "Purchase"
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Sub txtDiscPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscPer.TextChanged
        Calc()
    End Sub

    Private Sub txtSubTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubTotal.TextChanged
        Compute()
    End Sub

    Private Sub txtFreightCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFreightCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtOtherCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOtherCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtPreviousDue_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPreviousDue.TextChanged
        Compute()
    End Sub

    Private Sub txtRoundOff_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRoundOff.TextChanged
        Compute()
    End Sub

    Private Sub txtTotalPaid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalPaid.TextChanged
        Compute()
    End Sub

    Private Sub cmbPurchaseType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPurchaseType.SelectedIndexChanged
        If cmbPurchaseType.SelectedIndex = 1 Then
            txtTotalPaid.Text = "0.00"
            txtTotalPaid.ReadOnly = True
            txtTotalPaid.Enabled = False
        Else
            txtTotalPaid.Text = "0.00"
            txtTotalPaid.ReadOnly = False
            txtTotalPaid.Enabled = True
        End If
    End Sub

    Private Sub txtVATPer_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub

    Private Sub txtCGSTPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCGSTPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCGSTPer.Text
            Dim selectionStart = Me.txtCGSTPer.SelectionStart
            Dim selectionLength = Me.txtCGSTPer.SelectionLength

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

    Private Sub txtSGSTPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSGSTPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtSGSTPer.Text
            Dim selectionStart = Me.txtSGSTPer.SelectionStart
            Dim selectionLength = Me.txtSGSTPer.SelectionLength

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

    Private Sub txtIGSTPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIGSTPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtIGSTPer.Text
            Dim selectionStart = Me.txtIGSTPer.SelectionStart
            Dim selectionLength = Me.txtIGSTPer.SelectionLength

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

    Private Sub txtCESSPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCESSPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCESSPer.Text
            Dim selectionStart = Me.txtCESSPer.SelectionStart
            Dim selectionLength = Me.txtCESSPer.SelectionLength

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

    Private Sub cmbTaxType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTaxType.SelectedIndexChanged
        Calc()
        Compute()
        cmbTaxType.Enabled = False
    End Sub

    Private Sub txtCGSTPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCGSTPer.TextChanged
        Calc()
    End Sub

    Private Sub txtSGSTPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSGSTPer.TextChanged
        Calc()
    End Sub

    Private Sub txtIGSTPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIGSTPer.TextChanged
        Calc()
    End Sub

    Private Sub txtCESSPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCESSPer.TextChanged
        Calc()
    End Sub

    Private Sub txtDiscPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscPer.Text
            Dim selectionStart = Me.txtDiscPer.SelectionStart
            Dim selectionLength = Me.txtDiscPer.SelectionLength

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

    Private Sub txtCGST_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCGST.TextChanged
        Compute()
    End Sub

    Private Sub txtMRP_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMRP.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtMRP.Text
            Dim selectionStart = Me.txtMRP.SelectionStart
            Dim selectionLength = Me.txtMRP.SelectionLength

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
