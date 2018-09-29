Imports System.Data.SqlClient

Imports System.IO

Public Class frmProductRecord

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit) from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID order by ProductName", con)
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


    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then

                If lblSet.Text = "Product Entry" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmProduct.Show()
                    Me.Hide()
                    frmProduct.txtID.Text = dr.Cells(0).Value.ToString()
                    frmProduct.txtProductCode.Text = dr.Cells(1).Value.ToString()
                    frmProduct.txtProductName.Text = dr.Cells(2).Value.ToString()
                    frmProduct.txtSubCategoryID.Text = dr.Cells(3).Value.ToString()
                    frmProduct.cmbCategory.Text = dr.Cells(4).Value.ToString()
                    frmProduct.cmbSubCategory.Text = dr.Cells(5).Value.ToString()
                    frmProduct.txtHSNCode.Text = dr.Cells(6).Value.ToString()
                    frmProduct.txtPartNo.Text = dr.Cells(7).Value.ToString()
                    frmProduct.txtFeatures.Text = dr.Cells(8).Value.ToString()
                    frmProduct.txtCostPrice.Text = dr.Cells(9).Value.ToString()
                    frmProduct.txtSellingPrice.Text = dr.Cells(10).Value.ToString()
                    frmProduct.txtDiscount.Text = dr.Cells(11).Value.ToString()
                    frmProduct.txtCGST.Text = dr.Cells(12).Value.ToString()
                    frmProduct.txtSGST.Text = dr.Cells(13).Value.ToString()
                    frmProduct.txtCESS.Text = dr.Cells(14).Value.ToString()
                    frmProduct.txtReorderPoint.Text = dr.Cells(15).Value.ToString()
                    frmProduct.txtBarcode.Text = dr.Cells(16).Value.ToString()
                    frmProduct.txtBCode.Text = dr.Cells(16).Value.ToString()
                    frmProduct.txtOpeningStock.Text = dr.Cells(17).Value.ToString()
                    frmProduct.txtOStock.Text = dr.Cells(17).Value.ToString()
                    frmProduct.cmbPurchaseUnit.Text = dr.Cells(18).Value.ToString()
                    frmProduct.cmbSalesUnit.Text = dr.Cells(19).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("SELECT Photo from Product,Product_Join where Product.PID=Product_Join.ProductID and Product.PID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmProduct.dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        Dim img4 As Image
                        Dim data As Byte() = DirectCast(rdr(0), Byte())
                        Dim ms As New MemoryStream(data)
                        img4 = Image.FromStream(ms)
                        frmProduct.dgw.Rows.Add(img4)
                    End While
                    con.Close()
                    frmProduct.btnUpdate.Enabled = True
                    frmProduct.btnDelete.Enabled = True
                    frmProduct.btnSave.Enabled = False
                    lblSet.Text = ""
                End If
            End If
            If lblSet.Text = "Stock" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                frmPurchaseEntry.Show()
                Me.Hide()
                frmPurchaseEntry.txtProductID.Text = dr.Cells(0).Value.ToString()
                frmPurchaseEntry.txtHSNCode.Text = dr.Cells(6).Value.ToString()
                frmPurchaseEntry.txtProductName.Text = dr.Cells(2).Value.ToString()
                frmPurchaseEntry.txtPricePerQty.Text = dr.Cells(9).Value.ToString()
                frmPurchaseEntry.txtBarcode.Text = dr.Cells(16).Value.ToString()
                frmPurchaseEntry.lblUnit.Text = dr.Cells(18).Value.ToString()
                frmPurchaseEntry.txtQty.Focus()
                lblSet.Text = ""
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
        txtProductName.Text = ""
        txtCategory.Text = ""
        txtSubCategory.Text = ""
        txtBarcode.Text = ""
        Getdata()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub txtProductName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProductName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit) from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and ProductName like '%" & txtProductName.Text & "%' order by ProductName", con)
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

    Private Sub txtCategory_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCategory.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit) from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and CategoryName like '%" & txtCategory.Text & "%' order by ProductName", con)
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

    Private Sub txtSubCategory_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubCategory.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit) from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and SubCategoryName like '%" & txtSubCategory.Text & "%' order by ProductName", con)
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

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub txtBarcode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBarcode.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(HSNCode),RTRIM(PartNo), RTRIM(Description), CostPrice,SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,RTRIM(Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit) from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Barcode like '%" & txtBarcode.Text & "%' order by ProductName", con)
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
End Class
