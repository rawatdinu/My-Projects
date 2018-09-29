Imports System.Data.SqlClient

Imports System.IO

Public Class frmPurchaseReport
  
    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptPurchase 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS, myDS1 As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "SELECT Stock.ST_ID, Stock.InvoiceNo, Stock.PurchaseType, Stock.ReferenceNo1, Stock.ReferenceNo2, Stock.Date, Stock.SupplierID, Stock.SupplierInvoiceNo, Stock.SupplierInvoiceDate, Stock.TaxType, Stock.SGST,Stock.CGST, Stock.IGST, Stock.CESS, Stock.SubTotal, Stock.PreviousDue, Stock.FreightCharges, Stock.OtherCharges, Stock.Total, Stock.RoundOff, Stock.GrandTotal, Stock.TotalPayment, Stock.PaymentDue,Stock.Remarks, Stock_Product.SP_ID, Stock_Product.StockID, Stock_Product.ProductID, Stock_Product.Barcode, Stock_Product.Qty, Stock_Product.Price, Stock_Product.CGSTPer, Stock_Product.CGSTAmt,Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt, Stock_Product.DiscountPer, Stock_Product.DiscountAmt,Stock_Product.TotalAmount, Supplier.ID, Supplier.SupplierID AS Expr1, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID,Supplier.Remarks AS Expr2, Supplier.AccountName, Supplier.AccountNumber, Supplier.Bank, Supplier.Branch, Supplier.IFSCCode, Supplier.GSTIN, Supplier.PAN, Supplier.CIN, Supplier.OpeningBalanceType,Supplier.OpeningBalance, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, Product.PartNo, Product.Description, Product.CostPrice, Product.SellingPrice,Product.Discount, Product.CGST AS Expr3, Product.SGST AS Expr4, Product.CESS AS Expr5, Product.Barcode AS Expr6, Product.ReorderPoint, Product.OpeningStock, Product.PurchaseUnit,Product.SalesUnit FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock.Date between @d1 and @d2 order by Stock.Date"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "Stock")
            myDA.Fill(myDS, "Stock_Product")
            myDA.Fill(myDS, "Product")
            myDA.Fill(myDS, "Supplier")
            con = New SqlConnection(cs)
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(Date)) AS Year, SUM(GrandTotal) AS GrandTotal FROM Stock where date between @d3 and @d4 GROUP BY YEAR(Date) ORDER BY Year", con)
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            myDS1.Tables.Add(dtable)
            myDS1.WriteXmlSchema("TotalPurchase.xml")
            rpt.Subreports(0).SetDataSource(myDS1)
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p6", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
