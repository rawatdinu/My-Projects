Imports System.Data.SqlClient

Imports System.IO

Public Class frmServiceBillingRecord

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID order by InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        fillInvoiceNo()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                If lblSet.Text = "Billing" Then
                    frmServiceBilling.Show()
                    Me.Hide()
                    frmServiceBilling.txtID.Text = dr.Cells(0).Value.ToString()
                    frmServiceBilling.txtInvoiceNo.Text = dr.Cells(1).Value.ToString()
                    frmServiceBilling.dtpInvoiceDate.Text = dr.Cells(2).Value.ToString()
                    frmServiceBilling.txtS_ID.Text = dr.Cells(3).Value.ToString()
                    frmServiceBilling.txtServiceCode.Text = dr.Cells(4).Value.ToString()
                    frmServiceBilling.txtCustomerID.Text = dr.Cells(5).Value.ToString()
                    frmServiceBilling.txtCustomerName.Text = dr.Cells(6).Value.ToString()
                    frmServiceBilling.txtRepairCharges.Text = dr.Cells(7).Value.ToString()
                    frmServiceBilling.txtUpfront.Text = dr.Cells(8).Value.ToString()
                    frmServiceBilling.txtServiceTaxPer.Text = dr.Cells(9).Value.ToString()
                    frmServiceBilling.txtServiceTaxAmount.Text = dr.Cells(10).Value.ToString()
                    frmServiceBilling.txtGrandTotal.Text = dr.Cells(11).Value.ToString()
                    frmServiceBilling.txtTotalPayment.Text = dr.Cells(12).Value.ToString()
                    frmServiceBilling.txtPaymentDue.Text = dr.Cells(13).Value.ToString()
                    frmServiceBilling.txtRemarks.Text = dr.Cells(14).Value.ToString()
                    frmServiceBilling.btnSave.Enabled = False
                    frmServiceBilling.btnUpdate.Enabled = True
                    frmServiceBilling.btnPrint.Enabled = True
                    frmServiceBilling.btnDelete.Enabled = True
                    lblSet.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub fillInvoiceNo()
        Try
            con = New SqlConnection(cs)
            con.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(InvoiceNo) FROM InvoiceInfo1", con)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbInvoiceNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbInvoiceNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        cmbInvoiceNo.Text = ""
        txtCustomerName.Text = ""
        fillInvoiceNo()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker1.Text = Today
        Getdata()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceDate between @d1 and @d2 order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbOrderNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceNo='" & cmbInvoiceNo.Text & "' order by InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceDate between @d1 and @d2 and Balance > 0 order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCustomerName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and Name like '%" & txtCustomerName.Text & "%' order by InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbInvoiceNo_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbInvoiceNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub
End Class
