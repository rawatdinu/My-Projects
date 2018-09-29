Imports System.Data.SqlClient

Imports System.IO

Public Class frmSupplierRecord
    Dim num1, num2, num3 As Decimal
    Dim str As String
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),OpeningBalance,RTRIM(OpeningBalanceType),RTRIM(Remarks) from Supplier order by name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19))
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
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                If lblSet.Text = "Supplier Entry" Then
                    frmSupplier.Show()
                    Me.Hide()
                    frmSupplier.txtID.Text = dr.Cells(0).Value.ToString()
                    frmSupplier.txtSupplierID.Text = dr.Cells(1).Value.ToString()
                    frmSupplier.txtSupplierName.Text = dr.Cells(2).Value.ToString()
                    frmSupplier.txtSupName.Text = dr.Cells(2).Value.ToString()
                    frmSupplier.txtAddress.Text = dr.Cells(3).Value.ToString()
                    frmSupplier.txtCity.Text = dr.Cells(4).Value.ToString()
                    frmSupplier.cmbState.Text = dr.Cells(5).Value.ToString()
                    frmSupplier.txtZipCode.Text = dr.Cells(6).Value.ToString()
                    frmSupplier.txtContactNo.Text = dr.Cells(7).Value.ToString()
                    frmSupplier.txtEmailID.Text = dr.Cells(8).Value.ToString()
                    frmSupplier.txtGSTIN.Text = dr.Cells(9).Value.ToString()
                    frmSupplier.txtCIN.Text = dr.Cells(10).Value.ToString()
                    frmSupplier.txtPAN.Text = dr.Cells(11).Value.ToString()
                    frmSupplier.txtAccountName.Text = dr.Cells(12).Value.ToString()
                    frmSupplier.txtAccountNo.Text = dr.Cells(13).Value.ToString()
                    frmSupplier.txtBank.Text = dr.Cells(14).Value.ToString()
                    frmSupplier.txtBranch.Text = dr.Cells(15).Value.ToString()
                    frmSupplier.txtIFSCcode.Text = dr.Cells(16).Value.ToString()
                    frmSupplier.txtOpeningBalance.Text = dr.Cells(17).Value.ToString()
                    frmSupplier.cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDown
                    frmSupplier.cmbOpeningBalanceType.Text = dr.Cells(18).Value.ToString()
                    frmSupplier.txtRemarks.Text = dr.Cells(19).Value.ToString()
                    frmSupplier.btnUpdate.Enabled = True
                    frmSupplier.btnDelete.Enabled = True
                    frmSupplier.btnSave.Enabled = False
                    frmSupplier.cmbOpeningBalanceType.Enabled = False
                    frmSupplier.txtOpeningBalance.ReadOnly = True
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Payment" Then
                    frmPayment.Show()
                    Me.Hide()
                    frmPayment.txtSup_ID.Text = dr.Cells(0).Value.ToString()
                    frmPayment.txtSupplierID.Text = dr.Cells(1).Value.ToString()
                    frmPayment.txtSupplierName.Text = dr.Cells(2).Value.ToString()
                    frmPayment.txtAddress.Text = dr.Cells(3).Value.ToString()
                    frmPayment.txtCity.Text = dr.Cells(5).Value.ToString()
                    frmPayment.txtContactNo.Text = dr.Cells(7).Value.ToString()
                    frmPayment.GetSupplierBalance()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Purchase" Then
                    frmPurchaseEntry.Show()
                    Me.Hide()
                    frmPurchaseEntry.txtSup_ID.Text = dr.Cells(0).Value.ToString()
                    frmPurchaseEntry.txtSupplierID.Text = dr.Cells(1).Value.ToString()
                    frmPurchaseEntry.txtSupplierName.Text = dr.Cells(2).Value.ToString()
                    frmPurchaseEntry.txtAddress.Text = dr.Cells(3).Value.ToString()
                    frmPurchaseEntry.txtState.Text = dr.Cells(5).Value.ToString()
                    frmPurchaseEntry.txtContactNo.Text = dr.Cells(7).Value.ToString()
                    frmPurchaseEntry.GetSupplierBalance()
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

    Private Sub txtSupplierName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSupplierName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),OpeningBalance,RTRIM(OpeningBalanceType),RTRIM(Remarks) from Supplier where name like '%" & txtSupplierName.Text & "%' order by name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCity_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCity.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),OpeningBalance,RTRIM(OpeningBalanceType),RTRIM(Remarks) from Supplier where City like '%" & txtCity.Text & "%' order by city", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        txtSupplierName.Text = ""
        txtContactNo.Text = ""
        txtCity.Text = ""
        Getdata()
    End Sub


    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),OpeningBalance,RTRIM(OpeningBalanceType),RTRIM(Remarks) from Supplier where ContactNo like '%" & txtContactNo.Text & "%' order by city", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnClose_Click_2(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub
End Class
