Imports System.Data.SqlClient

Imports System.IO

Public Class frmPaymentRecord
    Dim num1, num2, num3 As Decimal
    Dim str As String
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(Payment.Remarks) from Supplier,Payment where Supplier.ID=Payment.SupplierID and Amount > 0 order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Payment" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmPayment.Show()
                    Me.Hide()
                    frmPayment.txtT_ID.Text = dr.Cells(0).Value.ToString()
                    frmPayment.txtTransactionNo.Text = dr.Cells(1).Value.ToString()
                    frmPayment.dtpTranactionDate.Text = dr.Cells(2).Value.ToString()
                    frmPayment.cmbPaymentMode.Text = dr.Cells(3).Value.ToString()
                    frmPayment.txtSup_ID.Text = dr.Cells(4).Value.ToString()
                    frmPayment.txtSupplierID.Text = dr.Cells(5).Value.ToString()
                    frmPayment.txtSupplierName.Text = dr.Cells(6).Value.ToString()
                    frmPayment.txtTransactionAmount.Text = dr.Cells(7).Value.ToString()
                    frmPayment.txtTempAmt.Text = dr.Cells(7).Value.ToString()
                    frmPayment.txtPaymentModeDetails.Text = dr.Cells(8).Value.ToString()
                    frmPayment.txtRemarks.Text = dr.Cells(9).Value.ToString()
                    frmPayment.btnSave.Enabled = False
                    frmPayment.btnUpdate.Enabled = True
                    frmPayment.btnDelete.Enabled = True
                    frmPayment.GetSupplierInfo()
                    frmPayment.btnSelection.Enabled = False
                    frmPayment.GetSupplierBalance()
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
    Sub Reset()
        txtSupplierName.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        Getdata()
    End Sub


    Private Sub txtSupplierName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSupplierName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(Payment.Remarks) from Supplier,Payment where Supplier.ID=Payment.SupplierID and Amount > 0  and [Name] like '%" & txtSupplierName.Text & "%' order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(Payment.Remarks) from Supplier,Payment where Supplier.ID=Payment.SupplierID and Amount > 0  and [Date] between @d1 and @d2 order by [Date]", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnReset_Click_1(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
