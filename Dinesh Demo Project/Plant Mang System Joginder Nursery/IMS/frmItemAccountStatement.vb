Imports System.Data
Imports System.Data.SqlClient

Imports CrystalDecisions.CrystalReports.Engine
Public Class frmItemAccountStatement
    Dim CrRepDoc As New ReportDocument
    Dim Cash As Integer
    Dim intDGSearchKeayPress As Integer

    Dim da_Search As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds_Search As New DataSet

    Private Sub cmdFindItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindItem.Click
        'gbSearch.BringToFront()
        'FillSearchGridInfo()
        'FillGridItem()
        'Button2.Enabled = True
        'fgDetail.Rows = 1
        'txtSearch.Focus()

        Dim StrQuery As String
        Dim i As Integer
        da_Search.Dispose()
        ds_Search.Clear()
        Button2.Enabled = True
        FillSearchGridInfo()
       


        Try


            StrQuery = "SELECT * from ItemMaster"
            da_Search = New SqlDataAdapter(StrQuery, gl_Con)
            da_Search.Fill(ds_Search, "FillGrid")
            dgSearch.RowCount = 1
            If ds_Search.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds_Search.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds_Search.Tables("FillGrid").Rows(i).Item("ItemCode")), "", ds_Search.Tables("FillGrid").Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds_Search.Tables("FillGrid").Rows(i).Item("ItemName")), "", ds_Search.Tables("FillGrid").Rows(i).Item("ItemName"))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds_Search.Tables("FillGrid").Rows(i).Item("Make")), "", ds_Search.Tables("FillGrid").Rows(i).Item("Make"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds_Search.Tables("FillGrid").Rows(i).Item("CurrentStock")), "", ds_Search.Tables("FillGrid").Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds_Search.Tables("FillGrid").Rows(i).Item("Unit")), "", ds_Search.Tables("FillGrid").Rows(i).Item("Unit"))

                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds_Search.Tables("FillGrid").Rows(i).Item("CurrentSubStock")), "", ds_Search.Tables("FillGrid").Rows(i).Item("CurrentSubStock"))

                        .Rows(i).Cells(7).Value = IIf(IsDBNull(ds_Search.Tables("FillGrid").Rows(i).Item("StoreUnit")), "", ds_Search.Tables("FillGrid").Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(ds_Search.Tables("FillGrid").Rows(i).Item("ConvFAct")), "", ds_Search.Tables("FillGrid").Rows(i).Item("ConvFAct"))




                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearch.Text = ""
            txtSearch.Focus()
            gbSearch.BringToFront()
            gbMain.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FillGridInfo()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 15
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "TransNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "TransType"
            .Columns(2).Width = 100
            .Columns(3).Name = "TransDate"
            .Columns(3).Width = 80
            .Columns(4).Name = "QtyIss"
            .Columns(4).Width = 80
            .Columns(5).Name = "SubQtyIss"
            .Columns(5).Width = 80
            .Columns(5).Visible = False
            .Columns(6).Name = "QtyRecv"
            .Columns(6).Width = 80
            .Columns(7).Name = "SubQtyRecv"
            .Columns(7).Width = 80
            .Columns(7).Visible = False
            .Columns(8).Name = "Qty"
            .Columns(8).Width = 80
            .Columns(9).Name = "SubQty"
            .Columns(9).Width = 80
            .Columns(9).Visible = False
            .Columns(10).Name = "Rate"
            .Columns(10).Width = 80
            .Columns(11).Name = "SubRate"
            .Columns(11).Width = 80
            .Columns(11).Visible = False
            .Columns(12).Name = "InvoiceNo"
            .Columns(12).Width = 80
            .Columns(13).Name = "ChallanNo"
            .Columns(13).Width = 80
            .Columns(14).Name = "PartyName"
            .Columns(14).Width = 180

            .RowTemplate.Height = 17
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

        'With fgDetail
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    ' .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .Rows = 1
        '    .Cols = 15

        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "S.No")


        '    .set_TextMatrix(0, 1, "TransNo")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "TransType")
        '    .set_ColWidth(2, 1200)
        '    .set_TextMatrix(0, 3, "TransDate")
        '    .set_ColWidth(3, 1500)
        '    .set_TextMatrix(0, 4, "QtyIss")
        '    .set_ColWidth(4, 1200)
        '    .set_TextMatrix(0, 5, "SubQtyIss")
        '    .set_ColWidth(5, 1300)
        '    .set_ColHidden(5, True)

        '    .set_TextMatrix(0, 6, "QtyRecv")
        '    .set_ColWidth(6, 1200)

        '    .set_TextMatrix(0, 7, "SubQtyRecv")
        '    .set_ColWidth(7, 1600)
        '    .set_ColHidden(7, True)
        '    .set_TextMatrix(0, 8, "Qty")
        '    .set_ColWidth(8, 1000)

        '    .set_TextMatrix(0, 9, "SubQty")
        '    .set_ColWidth(9, 1200)
        '    .set_ColHidden(9, True)
        '    .set_TextMatrix(0, 10, "Rate")
        '    .set_ColWidth(10, 1000)

        '    .set_TextMatrix(0, 11, "SubRate")
        '    .set_ColWidth(11, 1200)
        '    .set_ColHidden(11, True)

        '    .set_TextMatrix(0, 12, "InvoiceNo")
        '    .set_ColWidth(12, 1200)

        '    .set_TextMatrix(0, 13, "ChallanNo")
        '    .set_ColWidth(13, 1200)


        '    .set_TextMatrix(0, 14, "PartyName")
        '    .set_ColWidth(14, 5000)

        'End With


    End Sub
    Private Sub FillSearchGridInfo()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 9
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 50
            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 300
            .Columns(3).Name = "Make"
            .Columns(3).Width = 100
            .Columns(4).Name = "CurrentStock"
            .Columns(4).Width = 90
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 50
            .Columns(6).Name = "SubStock"
            .Columns(6).Width = 80
            .Columns(7).Name = "StoreUnit"
            .Columns(7).Width = 80
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 100

            .RowTemplate.Height = 17
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

        'With fgSearch
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .Rows = 1
        '    .Cols = 9
        '    '.Width = 678
        '    '.Height = 193
        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "S.No")


        '    .set_TextMatrix(0, 1, "ItemCode")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "ItemName")
        '    .set_ColWidth(2, 5000)
        '    .set_TextMatrix(0, 3, "Make")
        '    .set_ColWidth(3, 1200)
        '    .set_TextMatrix(0, 4, "CurrentStock")
        '    .set_ColWidth(4, 1300)

        '    .set_TextMatrix(0, 5, "Unit")
        '    .set_ColWidth(5, 1000)

        '    .set_TextMatrix(0, 6, "SubStock")
        '    .set_ColWidth(6, 1100)

        '    .set_TextMatrix(0, 7, "StoreUnit")
        '    .set_ColWidth(7, 1000)

        '    .set_TextMatrix(0, 8, "ConvFact")
        '    .set_ColWidth(8, 1200)

        'End With


    End Sub
    Private Sub FillGridItem()

        'Dim iRow As Integer
        'Dim drDisplay As DataRow
        'Dim f_daDept As SqlClient.SqlDataAdapter
        'Dim f_dsDept As New DataSet
        'Dim StrQuery As String

        'Me.Cursor = Cursors.WaitCursor
        'With fgSearch
        '    .Rows = 1
        'End With

        'Try

        '    StrQuery = "SELECT * from ItemMaster"


        '    f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
        '    f_dsDept.Clear()
        '    f_daDept.Fill(f_dsDept, "ItemList")
        '    For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
        '        drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
        '        With fgSearch
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
        '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode")))
        '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName")))
        '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drDisplay.Item("MAke")), "", drDisplay.Item("MAke")))
        '            .set_TextMatrix(.Rows - 1, 4, IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock")))
        '            .set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit")))
        '            .set_TextMatrix(.Rows - 1, 6, IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock")))
        '            .set_TextMatrix(.Rows - 1, 7, IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit")))
        '            .set_TextMatrix(.Rows - 1, 8, IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct")))
        '        End With
        '    Next



        'Catch ex As Exception

        '    MsgBox(ex.Message)
        'End Try
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub fgSearch_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'txtItemCode.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
        'txtItemName.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 2)
        'gbSearch.SendToBack()
        'gbMain.BringToFront()
    End Sub

    Private Sub frmItemAccountStatement_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ItemAccountStatement = Nothing
    End Sub


    Private Sub frmItemAccountStatement_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtItemCode.ReadOnly = True
        txtItemName.ReadOnly = True
        Button2.Enabled = False
        cmdPrint.Enabled = False
        FillGridInfo()
        dtpFromDate.Value = Now
        dtpToDate.Value = Now
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Strquery As String
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction
        Dim OpeningStock As Decimal
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim Opqty As Decimal
        Dim Opsubqty As Decimal
        Dim qty As Decimal
        Dim subqty As Decimal
        Dim i As Integer
        Dim PartyName As String
        Dim TrnNo As String
        Dim TrnDate As Date
        Dim rate As Decimal
        Dim SubRate As Decimal
        Dim InvoiceNo As String
        Dim ChallanNo As String
        Dim TransType As String

        cmdPrint.Enabled = True
        Try

            Strquery = "truncate table Temp_ItemAccountStatement"

            trn = gl_Con.BeginTransaction
            cmdCom1 = New SqlClient.SqlCommand(Strquery, gl_Con)
            cmdCom1.CommandType = CommandType.Text
            cmdCom1.Transaction = trn
            cmdCom1.ExecuteNonQuery()
            trn.Commit()



            '''*********************************************OpeningStock**************************************************
            Strquery = "SELECT ItemMaster.OpeningStock, ItemMaster.OpeningSubStock FROM ItemMaster where ItemCode = '" & txtItemCode.Text & "'"

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            If ds.Tables("MR").Rows.Count > 0 Then
                Opqty = IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("OpeningStock")), 0, ds.Tables("MR").Rows(0).Item("OpeningStock"))
                Opsubqty = IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("OpeningSubStock")), 0, ds.Tables("MR").Rows(0).Item("OpeningSubStock"))
            Else
                Opqty = 0
                Opsubqty = 0
            End If

            da.Dispose()
            ds.Clear()



            '''*********************************************Receive**************************************************
            Strquery = "SELECT Sum(PurchaseDetail.Qty) As Qty, Sum(PurchaseDetail.SubQty) As SubQty FROM PurchaseMaster INNER JOIN PurchaseDetail ON PurchaseMaster.PurchaseNo = PurchaseDetail.PurchaseNo WHERE PurchaseDetail.ItemCode='" & txtItemCode.Text & "' and PurchaseMaster.PurchaseDate < '" & convertToServerDateFormat(dtpFromDate.Value) & "' AND PurchaseMaster.APPROVE=1 "
            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            If ds.Tables("MR").Rows.Count > 0 Then
                Opqty = Opqty + IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Qty")), 0, ds.Tables("MR").Rows(0).Item("Qty"))
                Opsubqty = Opsubqty + IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("SubQty")), 0, ds.Tables("MR").Rows(0).Item("SubQty"))

            End If

            da.Dispose()
            ds.Clear()


            'Strquery = "SELECT Sum(SaleReturnDetail.Qty) AS Qty, Sum(SaleReturnDetail.SubQty) AS SubQty FROM SaleReturnDetail INNER JOIN SaleReturnMaster ON SaleReturnDetail.SaleReturnNo = SaleReturnMaster.SaleReturnNo    WHERE SaleReturnDetail.ItemCode='" & txtItemCode.Text & "' and SaleReturnMaster.SaleReturnDate <  '" & convertToServerDateFormat(dtpFromDate.Value) & "' AND SaleReturnMaster.APPROVE=1"

            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")

            'If ds.Tables("MR").Rows.Count > 0 Then
            '    Opqty = Opqty + IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Qty")), 0, ds.Tables("MR").Rows(0).Item("Qty"))
            '    Opsubqty = Opsubqty + IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("SubQty")), 0, ds.Tables("MR").Rows(0).Item("SubQty"))

            'End If

            'da.Dispose()
            'ds.Clear()


            '''*********************************************Issue**************************************************

            Strquery = "SELECT Sum(SaleDetail.Qty) AS Qty, Sum(SaleDetail.SubQty) AS SubQty FROM SaleDetail INNER JOIN SaleMaster ON SaleDetail.SaleInvoiceNo = SaleMaster.SaleInvoiceNo    WHERE SaleDetail.ItemCode='" & txtItemCode.Text & "' and SaleMaster.SaleDate <  '" & convertToServerDateFormat(dtpFromDate.Value) & "' AND SALEMASTER.APPROVE=1"

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            If ds.Tables("MR").Rows.Count > 0 Then
                Opqty = Opqty - IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Qty")), 0, ds.Tables("MR").Rows(0).Item("Qty"))
                Opsubqty = Opsubqty - IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("SubQty")), 0, ds.Tables("MR").Rows(0).Item("SubQty"))

            End If

            da.Dispose()
            ds.Clear()

            Strquery = "SELECT Sum(TaxDetail.Qty) AS Qty, Sum(TaxDetail.SubQty) AS SubQty FROM TaxDetail INNER JOIN TaxMaster ON TaxDetail.TaxInvoiceNo = TaxMaster.TaxInvoiceNo    WHERE TaxDetail.ItemCode='" & txtItemCode.Text & "' and TaxMaster.TaxDate <  '" & convertToServerDateFormat(dtpFromDate.Value) & "' AND TaxMASTER.APPROVE=1"

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            If ds.Tables("MR").Rows.Count > 0 Then
                Opqty = Opqty - IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Qty")), 0, ds.Tables("MR").Rows(0).Item("Qty"))
                Opsubqty = Opsubqty - IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("SubQty")), 0, ds.Tables("MR").Rows(0).Item("SubQty"))

            End If

            da.Dispose()
            ds.Clear()

            'Strquery = "SELECT Sum(PurchaseReturnDetail.Qty) AS Qty, Sum(PurchaseReturnDetail.SubQty) AS SubQty FROM PurchaseReturnDetail INNER JOIN PurchaseReturnMaster ON PurchaseReturnDetail.PurchaseReturnNo = PurchaseReturnMaster.PurchaseReturnNo    WHERE PurchaseReturnDetail.ItemCode='" & txtItemCode.Text & "' and PurchaseReturnMaster.PurchaseReturnDate <  '" & convertToServerDateFormat(dtpFromDate.Value) & "'"

            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")

            'If ds.Tables("MR").Rows.Count > 0 Then
            '    Opqty = Opqty - IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Qty")), 0, ds.Tables("MR").Rows(0).Item("Qty"))
            '    Opsubqty = Opsubqty - IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("SubQty")), 0, ds.Tables("MR").Rows(0).Item("SubQty"))

            'End If

            'da.Dispose()
            'ds.Clear()



            Strquery = "Insert into Temp_ItemAccountStatement(Sno,FromDate,Todate,TransactionNo,TransactionDate,ItemCode,Received, Received1,Balance,Balance1) values(1,'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','Opening','" & convertToServerDateFormat(dtpFromDate.Value) & "','" & txtItemCode.Text & "'," & Opqty & "," & Opsubqty & "," & Opqty & "," & Opsubqty & " )"

            trn = gl_Con.BeginTransaction
            cmdCom1.Transaction = trn
            cmdCom1.Connection = gl_Con
            cmdCom1.CommandText = Strquery
            cmdCom1.ExecuteNonQuery()
            trn.Commit()




            '''************************************************************************************************************


            Strquery = "SELECT 'PurchaseInvoice' As TransType, PurchaseMaster.PurchaseNo, PurchaseMaster.PurchaseDate, PurchaseDetail.ItemCode, PurchaseDetail.Qty, PurchaseDetail.SubQty, PurchaseDetail.Rate, PurchaseDetail.SubRate, PurchaseMaster.InvoiceNo, PurchaseMaster.ChallanNo, SupplierMaster1.SupplierName FROM (PurchaseMaster INNER JOIN PurchaseDetail ON PurchaseMaster.PurchaseNo = PurchaseDetail.PurchaseNo) INNER JOIN SupplierMaster1 ON PurchaseMaster.SupplierCode = SupplierMaster1.SupplierCode WHERE PurchaseDetail.ItemCode='" & txtItemCode.Text & "' and PurchaseMaster.PurchaseDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and PurchaseMaster.PurchaseDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "' AND PurchaseMaster.APPROVE=1 "


            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            If ds.Tables("MR").Rows.Count > 0 Then

                For i = 0 To ds.Tables("MR").Rows.Count - 1


                    TrnNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PurchaseNo")), "", ds.Tables("MR").Rows(i).Item("PurchaseNo"))
                    TransType = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransType")), "", ds.Tables("MR").Rows(i).Item("TransType"))
                    TrnDate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PurchaseDate")), "01/01/1990", ds.Tables("MR").Rows(i).Item("PurchaseDate"))
                    qty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Qty")), 0, ds.Tables("MR").Rows(i).Item("Qty"))
                    subqty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubQty")), 0, ds.Tables("MR").Rows(i).Item("SubQty"))
                    rate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Rate")), 0, ds.Tables("MR").Rows(i).Item("Rate"))
                    SubRate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubRate")), 0, ds.Tables("MR").Rows(i).Item("SubRate"))
                    InvoiceNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo"))
                    ChallanNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), "", ds.Tables("MR").Rows(i).Item("ChallanNo"))
                    PartyName = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName")), "", ds.Tables("MR").Rows(i).Item("SupplierName"))
                    Opqty = Opqty + qty
                    Opsubqty = Opsubqty + subqty

                    Strquery = "Insert into Temp_ItemAccountStatement(Sno,FromDate,Todate,TransactionNo,TransactionDate,ItemCode,Received, Received1, Rate,SubRate,InvoiceNo,ChallanNo,PartyName,Balance,Balance1,TransType) values(2,'" & dtpFromDate.Value & "','" & dtpToDate.Value & "','" & TrnNo & "','" & TrnDate & "','" & txtItemCode.Text & "'," & qty & "," & subqty & "," & rate & "," & SubRate & ",'" & InvoiceNo & "','" & ChallanNo & "','" & PartyName & "'," & Opqty & "," & Opsubqty & " ,'" & TransType & "')"

                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = Strquery
                    cmdCom1.ExecuteNonQuery()
                    trn.Commit()



                Next

            End If

            da.Dispose()
            ds.Clear()



            'Strquery = "SELECT 'PurcghaseReturn' As TransType, PurchaseReturnMaster.Cash, PurchaseReturnMaster.SupplierName1, PurchaseReturnMaster.PurchaseReturnNo, PurchaseReturnMaster.PurchaseReturnDate, PurchaseReturnDetail.ItemCode, PurchaseReturnDetail.Qty, PurchaseReturnDetail.SubQty, PurchaseReturnDetail.Rate, PurchaseReturnDetail.SubRate, PurchaseReturnMaster.InvoiceNo, PurchaseReturnMaster.ChallanNo, SupplierMaster1.SupplierName FROM PurchaseReturnDetail INNER JOIN (PurchaseReturnMaster LEFT JOIN SupplierMaster1 ON PurchaseReturnMaster.SupplierCode = SupplierMaster1.SupplierCode) ON PurchaseReturnDetail.PurchaseReturnNo = PurchaseReturnMaster.PurchaseReturnNo WHERE PurchaseReturnDetail.ItemCode='" & txtItemCode.Text & "' and PurchaseReturnMaster.PurchaseReturnDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and PurchaseReturnMaster.PurchaseReturnDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "' "
            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")

            'If ds.Tables("MR").Rows.Count > 0 Then

            '    For i = 0 To ds.Tables("MR").Rows.Count - 1
            '        Cash = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Cash")), 0, ds.Tables("MR").Rows(i).Item("Cash"))

            '        TrnNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PurchaseReturnNo")), "", ds.Tables("MR").Rows(i).Item("PurchaseReturnNo"))
            '        TransType = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransType")), "", ds.Tables("MR").Rows(i).Item("TransType"))
            '        TrnDate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PurchaseReturnDate")), "01/01/1990", ds.Tables("MR").Rows(i).Item("PurchaseReturnDate"))
            '        qty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Qty")), 0, ds.Tables("MR").Rows(i).Item("Qty"))
            '        subqty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubQty")), 0, ds.Tables("MR").Rows(i).Item("SubQty"))
            '        rate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Rate")), 0, ds.Tables("MR").Rows(i).Item("Rate"))
            '        SubRate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubRate")), 0, ds.Tables("MR").Rows(i).Item("SubRate"))
            '        InvoiceNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo"))
            '        ChallanNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), "", ds.Tables("MR").Rows(i).Item("ChallanNo"))
            '        If Cash = 1 Then
            '            PartyName = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName1")), "", ds.Tables("MR").Rows(i).Item("SupplierName1"))
            '        Else

            '            PartyName = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName")), "", ds.Tables("MR").Rows(i).Item("SupplierName"))
            '        End If
            '        Opqty = Opqty - qty
            '        Opsubqty = Opsubqty - subqty

            '        Strquery = "Insert into Temp_ItemAccountStatement(Sno,FromDate,Todate,TransactionNo,TransactionDate,ItemCode,Issued, Issued1, Rate,SubRate,InvoiceNo,ChallanNo,PartyName,Balance,Balance1,TransType) values(2,'" & dtpFromDate.Value & "','" & dtpToDate.Value & "','" & TrnNo & "','" & TrnDate & "','" & txtItemCode.Text & "'," & qty & "," & subqty & "," & rate & "," & SubRate & ",'" & InvoiceNo & "','" & ChallanNo & "','" & PartyName & "'," & Opqty & "," & Opsubqty & ",'" & TransType & "' )"

            '        trn = gl_Con.BeginTransaction
            '        cmdCom1.Transaction = trn
            '        cmdCom1.Connection = gl_Con
            '        cmdCom1.CommandText = Strquery
            '        cmdCom1.ExecuteNonQuery()
            '        trn.Commit()



            '    Next

            'End If

            'da.Dispose()
            'ds.Clear()






            Strquery = "SELECT 'SaleInvoice' As TransType,SaleMaster.CashManual,SaleMaster.CashParty, SaleMaster.CustomerName1, SaleMaster.SaleInvoiceNo, SaleMaster.SaleDate, SaleDetail.ItemCode, SaleDetail.Qty, SaleDetail.SubQty, SaleDetail.Rate, SaleDetail.SubRate, SaleMaster.InvoiceNo, SaleMaster.ChallanNo, CustomerMaster1.CustomerName FROM SaleDetail INNER JOIN (SaleMaster LEFT JOIN CustomerMaster1 ON SaleMaster.CustomerCode = CustomerMaster1.CustomerCode) ON SaleDetail.SaleInvoiceNo = SaleMaster.SaleInvoiceNo WHERE SaleDetail.ItemCode='" & txtItemCode.Text & "' and SaleMaster.SaleDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and SaleMaster.SaleDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "' AND SALEMASTER.APPROVE=1"
            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            If ds.Tables("MR").Rows.Count > 0 Then

                For i = 0 To ds.Tables("MR").Rows.Count - 1
                    Cash = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashManual")), 0, ds.Tables("MR").Rows(i).Item("CashManual"))

                    TrnNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SaleInvoiceNo")), "", ds.Tables("MR").Rows(i).Item("SaleInvoiceNo"))
                    TransType = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransType")), "", ds.Tables("MR").Rows(i).Item("TransType"))
                    TrnDate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SaleDate")), "01/01/1990", ds.Tables("MR").Rows(i).Item("SaleDate"))
                    qty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Qty")), 0, ds.Tables("MR").Rows(i).Item("Qty"))
                    subqty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubQty")), 0, ds.Tables("MR").Rows(i).Item("SubQty"))
                    rate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Rate")), 0, ds.Tables("MR").Rows(i).Item("Rate"))
                    SubRate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubRate")), 0, ds.Tables("MR").Rows(i).Item("SubRate"))
                    InvoiceNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo"))
                    ChallanNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), "", ds.Tables("MR").Rows(i).Item("ChallanNo"))
                    If Cash = 1 Then
                        PartyName = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName1")), "", ds.Tables("MR").Rows(i).Item("CustomerName1"))
                    Else

                        PartyName = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName")), "", ds.Tables("MR").Rows(i).Item("CustomerName"))
                    End If
                    Opqty = Opqty - qty
                    Opsubqty = Opsubqty - subqty

                    Strquery = "Insert into Temp_ItemAccountStatement(Sno,FromDate,Todate,TransactionNo,TransactionDate,ItemCode,Issued, Issued1, Rate,SubRate,InvoiceNo,ChallanNo,PartyName,Balance,Balance1,TransType) values(2,'" & dtpFromDate.Value & "','" & dtpToDate.Value & "','" & TrnNo & "','" & TrnDate & "','" & txtItemCode.Text & "'," & qty & "," & subqty & "," & rate & "," & SubRate & ",'" & InvoiceNo & "','" & ChallanNo & "','" & PartyName & "'," & Opqty & "," & Opsubqty & ",'" & TransType & "' )"

                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = Strquery
                    cmdCom1.ExecuteNonQuery()
                    trn.Commit()



                Next

            End If

            da.Dispose()
            ds.Clear()

            Strquery = "SELECT 'TaxInvoice' As TransType,TaxMaster.CashManual,TaxMaster.CashParty, TaxMaster.CustomerName1, TaxMaster.TaxInvoiceNo, TaxMaster.TaxDate, TaxDetail.ItemCode, TaxDetail.Qty, TaxDetail.SubQty, TaxDetail.Rate, TaxDetail.SubRate, TaxMaster.InvoiceNo, TaxMaster.ChallanNo, CustomerMaster1.CustomerName FROM TaxDetail INNER JOIN (TaxMaster LEFT JOIN CustomerMaster1 ON TaxMaster.CustomerCode = CustomerMaster1.CustomerCode) ON TaxDetail.TaxInvoiceNo = TaxMaster.TaxInvoiceNo WHERE TaxDetail.ItemCode='" & txtItemCode.Text & "' and TaxMaster.TaxDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and TaxMaster.TaxDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "' AND TaxMASTER.APPROVE=1"
            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            If ds.Tables("MR").Rows.Count > 0 Then

                For i = 0 To ds.Tables("MR").Rows.Count - 1
                    Cash = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashManual")), 0, ds.Tables("MR").Rows(i).Item("CashManual"))

                    TrnNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TaxInvoiceNo")), "", ds.Tables("MR").Rows(i).Item("TaxInvoiceNo"))
                    TransType = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransType")), "", ds.Tables("MR").Rows(i).Item("TransType"))
                    TrnDate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TaxDate")), "01/01/1990", ds.Tables("MR").Rows(i).Item("TaxDate"))
                    qty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Qty")), 0, ds.Tables("MR").Rows(i).Item("Qty"))
                    subqty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubQty")), 0, ds.Tables("MR").Rows(i).Item("SubQty"))
                    rate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Rate")), 0, ds.Tables("MR").Rows(i).Item("Rate"))
                    SubRate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubRate")), 0, ds.Tables("MR").Rows(i).Item("SubRate"))
                    InvoiceNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo"))
                    ChallanNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), "", ds.Tables("MR").Rows(i).Item("ChallanNo"))
                    If Cash = 1 Then
                        PartyName = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName1")), "", ds.Tables("MR").Rows(i).Item("CustomerName1"))
                    Else

                        PartyName = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName")), "", ds.Tables("MR").Rows(i).Item("CustomerName"))
                    End If
                    Opqty = Opqty - qty
                    Opsubqty = Opsubqty - subqty

                    Strquery = "Insert into Temp_ItemAccountStatement(Sno,FromDate,Todate,TransactionNo,TransactionDate,ItemCode,Issued, Issued1, Rate,SubRate,InvoiceNo,ChallanNo,PartyName,Balance,Balance1,TransType) values(2,'" & dtpFromDate.Value & "','" & dtpToDate.Value & "','" & TrnNo & "','" & TrnDate & "','" & txtItemCode.Text & "'," & qty & "," & subqty & "," & rate & "," & SubRate & ",'" & InvoiceNo & "','" & ChallanNo & "','" & PartyName & "'," & Opqty & "," & Opsubqty & " ,'" & TransType & "')"

                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = Strquery
                    cmdCom1.ExecuteNonQuery()
                    trn.Commit()



                Next

            End If

            da.Dispose()
            ds.Clear()



            'Strquery = "SELECT 'SaleReturn' As TransType,SaleReturnMaster.Cash, SaleReturnMaster.CustomerName1, SaleReturnMaster.SaleReturnNo, SaleReturnMaster.SaleReturnDate, SaleReturnDetail.ItemCode, SaleReturnDetail.Qty, SaleReturnDetail.SubQty, SaleReturnDetail.Rate, SaleReturnDetail.SubRate, SaleReturnMaster.InvoiceNo, SaleReturnMaster.ChallanNo, CustomerMaster1.CustomerName FROM (SaleReturnMaster INNER JOIN SaleReturnDetail ON SaleReturnMaster.SaleReturnNo = SaleReturnDetail.SaleReturnNo) LEFT JOIN CustomerMaster1 ON SaleReturnMaster.CustomerCode = CustomerMaster1.CustomerCode WHERE SaleReturnDetail.ItemCode='" & txtItemCode.Text & "' and SaleReturnMaster.SalereturnDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and SaleReturnMaster.SalereturnDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "' "


            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")

            'If ds.Tables("MR").Rows.Count > 0 Then

            '    For i = 0 To ds.Tables("MR").Rows.Count - 1

            '        Cash = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Cash")), 0, ds.Tables("MR").Rows(i).Item("Cash"))
            '        TrnNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SalereturnNo")), "", ds.Tables("MR").Rows(i).Item("SalereturnNo"))
            '        TransType = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransType")), "", ds.Tables("MR").Rows(i).Item("TransType"))
            '        TrnDate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SalereturnDate")), "01/01/1990", ds.Tables("MR").Rows(i).Item("SalereturnDate"))
            '        qty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Qty")), 0, ds.Tables("MR").Rows(i).Item("Qty"))
            '        subqty = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubQty")), 0, ds.Tables("MR").Rows(i).Item("SubQty"))
            '        rate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Rate")), 0, ds.Tables("MR").Rows(i).Item("Rate"))
            '        SubRate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubRate")), 0, ds.Tables("MR").Rows(i).Item("SubRate"))
            '        InvoiceNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo"))
            '        ChallanNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), "", ds.Tables("MR").Rows(i).Item("ChallanNo"))
            '        If Cash = 1 Then
            '            PartyName = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName1")), "", ds.Tables("MR").Rows(i).Item("CustomerName1"))
            '        Else

            '            PartyName = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName")), "", ds.Tables("MR").Rows(i).Item("CustomerName"))
            '        End If

            '        Opqty = Opqty + qty
            '        Opsubqty = Opsubqty + subqty

            '        Strquery = "Insert into Temp_ItemAccountStatement(Sno,FromDate,Todate,TransactionNo,TransactionDate,ItemCode,Received, Received1, Rate,SubRate,InvoiceNo,ChallanNo,PartyName,Balance,Balance1,TransType) values(2,'" & dtpFromDate.Value & "','" & dtpToDate.Value & "','" & TrnNo & "','" & TrnDate & "','" & txtItemCode.Text & "'," & qty & "," & subqty & "," & rate & "," & SubRate & ",'" & InvoiceNo & "','" & ChallanNo & "','" & PartyName & "'," & Opqty & "," & Opsubqty & " ,'" & TransType & "')"

            '        trn = gl_Con.BeginTransaction
            '        cmdCom1.Transaction = trn
            '        cmdCom1.Connection = gl_Con
            '        cmdCom1.CommandText = Strquery
            '        cmdCom1.ExecuteNonQuery()
            '        trn.Commit()



            '    Next

            'End If

            'da.Dispose()
            'ds.Clear()





            Dim a As Integer
            Dim b As Integer



            Strquery = "SELECT  Temp_ItemAccountStatement.SNo,Temp_ItemAccountStatement.TransactionNo,Temp_ItemAccountStatement.TransType, Temp_ItemAccountStatement.TransactionDate, Temp_ItemAccountStatement.ItemCode, Temp_ItemAccountStatement.Received, Temp_ItemAccountStatement.Received1, Temp_ItemAccountStatement.Issued, Temp_ItemAccountStatement.Issued1, Temp_ItemAccountStatement.Rate, Temp_ItemAccountStatement.SubRate, Temp_ItemAccountStatement.InvoiceNo, Temp_ItemAccountStatement.ChallanNo, Temp_ItemAccountStatement.PartyName,Temp_ItemAccountStatement.Balance,Temp_ItemAccountStatement.Balance1 FROM Temp_ItemAccountStatement order by Temp_ItemAccountStatement.SNo,Temp_ItemAccountStatement.TransactionNo,Temp_ItemAccountStatement.TransactionDate"

            da = New SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")
            dgDetail.RowCount = 1
            If ds.Tables("MR").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To ds.Tables("MR").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionNo")), "", ds.Tables("MR").Rows(i).Item("TransactionNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransType")), "", ds.Tables("MR").Rows(i).Item("TransType"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate")))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Issued")), "", ds.Tables("MR").Rows(i).Item("Issued"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Issued1")), "", ds.Tables("MR").Rows(i).Item("Issued1"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Received")), "", ds.Tables("MR").Rows(i).Item("Received"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Received1")), "", ds.Tables("MR").Rows(i).Item("Received1"))

                        .Rows(i).Cells(8).Value = Val(.Rows(i).Cells(8).Value) + Val(.Rows(i).Cells(6).Value) - Val(.Rows(i).Cells(4).Value)
                        a = Val(.Rows(i).Cells(8).Value)

                        .Rows(i).Cells(9).Value = Val(.Rows(i).Cells(9).Value) + Val(.Rows(i).Cells(7).Value) - Val(.Rows(i).Cells(5).Value)
                        b = Val(.Rows(i).Cells(8).Value)

                        .Rows(i).Cells(10).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Rate")), "", ds.Tables("MR").Rows(i).Item("Rate"))
                        .Rows(i).Cells(11).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubRate")), "", ds.Tables("MR").Rows(i).Item("SubRate"))
                        .Rows(i).Cells(12).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo"))
                        .Rows(i).Cells(13).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), "", ds.Tables("MR").Rows(i).Item("ChallanNo"))
                        .Rows(i).Cells(14).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PartyName")), "", ds.Tables("MR").Rows(i).Item("PartyName"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgDetail.RowCount = 0
            End If



            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")

            'fgDetail.Rows = 1
            'For i = 0 To ds.Tables("MR").Rows.Count - 1
            '    With fgDetail
            '        .Rows = .Rows + 1
            '        .set_TextMatrix(i + 1, 0, i + 1)
            '        .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionNo")), "", ds.Tables("MR").Rows(i).Item("TransactionNo")))
            '        .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransType")), "", ds.Tables("MR").Rows(i).Item("TransType")))
            '        .set_TextMatrix(i + 1, 3, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate"))))
            '        .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Issued")), "", ds.Tables("MR").Rows(i).Item("Issued")))
            '        .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Issued1")), 0, ds.Tables("MR").Rows(i).Item("Issued1")))
            '        .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Received")), "", ds.Tables("MR").Rows(i).Item("Received")))
            '        .set_TextMatrix(i + 1, 7, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Received1")), 0, ds.Tables("MR").Rows(i).Item("Received1")))
            '        '.set_TextMatrix(i + 1, 7, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Balance")), 0, ds.Tables("MR").Rows(i).Item("Balance")))
            '        '.set_TextMatrix(i + 1, 8, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Balance1")), 0, ds.Tables("MR").Rows(i).Item("Balance1")))


            '        .set_TextMatrix(i + 1, 8, Val(.get_TextMatrix(i, 8)) + Val(.get_TextMatrix(i + 1, 6)) - Val(.get_TextMatrix(i + 1, 4)))
            '        a = .get_TextMatrix(i + 1, 8)
            '        .set_TextMatrix(i + 1, 9, Val(.get_TextMatrix(i, 9)) + Val(.get_TextMatrix(i + 1, 7)) - Val(.get_TextMatrix(i + 1, 5)))

            '        b = .get_TextMatrix(i + 1, 8)



            '        .set_TextMatrix(i + 1, 10, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Rate")), "", ds.Tables("MR").Rows(i).Item("Rate")))
            '        .set_TextMatrix(i + 1, 11, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SubRate")), 0, ds.Tables("MR").Rows(i).Item("SubRate")))
            '        .set_TextMatrix(i + 1, 12, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo")))
            '        .set_TextMatrix(i + 1, 13, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), "", ds.Tables("MR").Rows(i).Item("ChallanNo")))

            '        .set_TextMatrix(i + 1, 14, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PartyName")), "", ds.Tables("MR").Rows(i).Item("PartyName")))

            '    End With
            'Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub Stock()
        Dim Strquery As String
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction
        Dim OpeningStock As Decimal
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet

        Dim da1 As SqlClient.SqlDataAdapter
        Dim ds1 As New DataSet

        Dim Opqty As Decimal
        Dim Opsubqty As Decimal
        Dim IssueQty As Decimal
        Dim RecvQty As Decimal
        Dim i As Integer


        cmdPrint.Enabled = True


        Strquery = "Delete From Temp_ItemAccountStatement"

        trn = gl_Con.BeginTransaction
        cmdCom1 = New SqlClient.SqlCommand(Strquery, gl_Con)
        cmdCom1.CommandType = CommandType.Text
        cmdCom1.Transaction = trn
        cmdCom1.ExecuteNonQuery()
        trn.Commit()
        Strquery = "SELECT ItemCode FROM ItemMaster order by itemcode"

        da1 = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        da1.Fill(ds1, "MR1")

        If ds1.Tables("MR1").Rows.Count > 0 Then
            For i = 0 To ds1.Tables("MR1").Rows.Count - 1


                txtItemCode.Text = IIf(IsDBNull(ds1.Tables("MR1").Rows(i).Item("ItemCode")), 0, ds1.Tables("MR1").Rows(i).Item("ItemCode"))
                Opqty = 0
                Opsubqty = 0
                IssueQty = 0
                RecvQty = 0


                '''*********************************************OpeningStock**************************************************
                Strquery = "SELECT ItemMaster.OpeningStock, ItemMaster.OpeningSubStock FROM ItemMaster where ItemCode = '" & txtItemCode.Text & "'"

                da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
                da.Fill(ds, "MR")

                If ds.Tables("MR").Rows.Count > 0 Then
                    Opqty = IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("OpeningStock")), 0, ds.Tables("MR").Rows(0).Item("OpeningStock"))

                Else
                    Opqty = 0

                End If

                da.Dispose()
                ds.Clear()



                '''*********************************************Receive**************************************************
                Strquery = "SELECT Sum(PurchaseDetail.Qty) As Qty, Sum(PurchaseDetail.SubQty) As SubQty FROM PurchaseMaster INNER JOIN PurchaseDetail ON PurchaseMaster.PurchaseNo = PurchaseDetail.PurchaseNo WHERE PurchaseDetail.ItemCode='" & txtItemCode.Text & "' and PurchaseMaster.PurchaseDate < '" & convertToServerDateFormat(dtpFromDate.Value) & "' AND PurchaseMaster.APPROVE=1 "
                da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
                da.Fill(ds, "MR")

                If ds.Tables("MR").Rows.Count > 0 Then
                    Opqty = Opqty + IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Qty")), 0, ds.Tables("MR").Rows(0).Item("Qty"))

                End If

                da.Dispose()
                ds.Clear()


                '''*********************************************Issue**************************************************

                Strquery = "SELECT Sum(SaleDetail.Qty) AS Qty, Sum(SaleDetail.SubQty) AS SubQty FROM SaleDetail INNER JOIN SaleMaster ON SaleDetail.SaleInvoiceNo = SaleMaster.SaleInvoiceNo    WHERE SaleDetail.ItemCode='" & txtItemCode.Text & "' and SaleMaster.SaleDate <  '" & convertToServerDateFormat(dtpFromDate.Value) & "' AND SALEMASTER.APPROVE=1"

                da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
                da.Fill(ds, "MR")

                If ds.Tables("MR").Rows.Count > 0 Then
                    Opqty = Opqty - IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Qty")), 0, ds.Tables("MR").Rows(0).Item("Qty"))

                End If

                da.Dispose()
                ds.Clear()


                '''*********************************************Receive**************************************************
                Strquery = "SELECT Sum(PurchaseDetail.Qty) As Qty  FROM PurchaseMaster INNER JOIN PurchaseDetail ON PurchaseMaster.PurchaseNo = PurchaseDetail.PurchaseNo WHERE PurchaseDetail.ItemCode='" & txtItemCode.Text & "' and PurchaseMaster.PurchaseDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and PurchaseMaster.PurchaseDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'AND PurchaseMaster.APPROVE=1 "
                da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
                da.Fill(ds, "MR")

                If ds.Tables("MR").Rows.Count > 0 Then

                    RecvQty = IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Qty")), 0, ds.Tables("MR").Rows(0).Item("Qty"))

                End If

                da.Dispose()
                ds.Clear()


                '''*********************************************Issue**************************************************

                Strquery = "SELECT Sum(SaleDetail.Qty) AS Qty  FROM SaleDetail INNER JOIN SaleMaster ON SaleDetail.SaleInvoiceNo = SaleMaster.SaleInvoiceNo    WHERE SaleDetail.ItemCode='" & txtItemCode.Text & "' and SaleMaster.SaleDate >=  '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and SaleMaster.SaleDate <=  '" & convertToServerDateFormat(dtpToDate.Value) & "' AND SALEMASTER.APPROVE=1"

                da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
                da.Fill(ds, "MR")

                If ds.Tables("MR").Rows.Count > 0 Then
                    IssueQty = IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Qty")), 0, ds.Tables("MR").Rows(0).Item("Qty"))

                End If

                da.Dispose()
                ds.Clear()




                Strquery = "Insert into Temp_ItemAccountStatement(Sno,FromDate,Todate,TransactionNo,TransactionDate,ItemCode,Received, Received1,Balance,Balance1) values(1,'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','Opening','" & convertToServerDateFormat(dtpFromDate.Value) & "','" & txtItemCode.Text & "'," & Opqty & "," & (Opqty + RecvQty - IssueQty) & "," & IssueQty & "," & RecvQty & " )"

                trn = gl_Con.BeginTransaction
                cmdCom1.Transaction = trn
                cmdCom1.Connection = gl_Con
                cmdCom1.CommandText = Strquery
                cmdCom1.ExecuteNonQuery()
                trn.Commit()

            Next
        End If

        da1.Dispose()
        ds1.Clear()

        txtItemCode.Text = ""


    End Sub
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim fSalesReportViewer As New frmReportViewer
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        Dim Strquery As String
        Dim trn As SqlClient.SqlTransaction
        Dim cmdCom1 As SqlClient.SqlCommand


        fSalesReportViewer.MdiParent = MainForm
        fSalesReportViewer.Text = "Item Account Statement"
        fSalesReportViewer.Refresh()
        fSalesReportViewer.Show()


        Me.Cursor = Cursors.WaitCursor
        Try




            Strquery = "Delete From Temp_ItemAccountStatement"

            trn = gl_Con.BeginTransaction
            cmdCom1 = New SqlClient.SqlCommand(Strquery, gl_Con)
            cmdCom1.CommandType = CommandType.Text
            cmdCom1.Transaction = trn
            cmdCom1.ExecuteNonQuery()
            trn.Commit()

            With dgDetail
                For i = 0 To .RowCount - 1
                    Strquery = "Insert into Temp_ItemAccountStatement(Sno,FromDate,Todate,TransactionNo,TransactionType,TransactionDate,ItemCode,Issued,Issued1,Received, Received1,Balance,Balance1, Rate,SubRate,InvoiceNo,ChallanNo,PartyName ) values (" & Val(.Rows(i).Cells(0).Value) & ",'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (.Rows(i).Cells(1).Value) & "','" & (.Rows(i).Cells(2).Value) & "','" & (.Rows(i).Cells(3).Value) & "','" & txtItemCode.Text & "','" & Val(.Rows(i).Cells(4).Value) & "','" & Val(.Rows(i).Cells(5).Value) & "','" & Val(.Rows(i).Cells(6).Value) & "','" & Val(.Rows(i).Cells(7).Value) & "','" & Val(.Rows(i).Cells(8).Value) & "','" & Val(.Rows(i).Cells(9).Value) & "','" & Val(.Rows(i).Cells(10).Value) & "','" & Val(.Rows(i).Cells(11).Value) & "','" & (.Rows(i).Cells(12).Value) & "','" & (.Rows(i).Cells(13).Value) & "','" & (.Rows(i).Cells(14).Value) & "')"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = Strquery
                    cmdCom1.ExecuteNonQuery()

                    trn.Commit()

                Next
            End With

            'For i = 1 To fgDetail.Rows - 1
            '    Strquery = "Insert into Temp_ItemAccountStatement(Sno,FromDate,Todate,TransactionNo,TransactionType,TransactionDate,ItemCode,Issued,Issued1,Received, Received1,Balance,Balance1, Rate,SubRate,InvoiceNo,ChallanNo,PartyName ) values (" & Val(fgDetail.get_TextMatrix(i, 0)) & ",'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (fgDetail.get_TextMatrix(i, 1)) & "','" & (fgDetail.get_TextMatrix(i, 2)) & "','" & (fgDetail.get_TextMatrix(i, 3)) & "','" & txtItemCode.Text & "','" & Val(fgDetail.get_TextMatrix(i, 4)) & "','" & Val(fgDetail.get_TextMatrix(i, 5)) & "','" & Val(fgDetail.get_TextMatrix(i, 6)) & "','" & Val(fgDetail.get_TextMatrix(i, 7)) & "','" & Val(fgDetail.get_TextMatrix(i, 8)) & "','" & Val(fgDetail.get_TextMatrix(i, 9)) & "','" & Val(fgDetail.get_TextMatrix(i, 10)) & "','" & Val(fgDetail.get_TextMatrix(i, 11)) & "','" & (fgDetail.get_TextMatrix(i, 12)) & "','" & (fgDetail.get_TextMatrix(i, 13)) & "','" & (fgDetail.get_TextMatrix(i, 14)) & "')"
            '    trn = gl_Con.BeginTransaction
            '    cmdCom1.Transaction = trn
            '    cmdCom1.Connection = gl_Con
            '    cmdCom1.CommandText = Strquery
            '    cmdCom1.ExecuteNonQuery()

            '    trn.Commit()
            'Next

            CrRepDoc.Load(Application.StartupPath & "\Report\rptItemAccountStatement.rpt")
            For Each tbCurrent In CrRepDoc.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = gl_Con.DataSource
                    .UserID = "sa"
                    .Password = gl_strpwd
                    .DatabaseName = gl_Con.Database
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent

            'For Each tbCurrent In CrRepDoc.Database.Tables
            '    tliCurrent = tbCurrent.LogOnInfo
            '    With tliCurrent.ConnectionInfo
            '        With tliCurrent.ConnectionInfo
            '            .ServerName = gl_Con.DataSource
            '            .UserID = Trim(Split(txtConnectionReport, ",")(1))
            '            .Password = gl_strpwd
            '            .DatabaseName = gl_Con.Database
            '        End With
            '    End With
            '    tbCurrent.ApplyLogOnInfo(tliCurrent)
            'Next tbCurrent
            CrRepDoc.Refresh()
            'strMRCode = "{PurchaseMaster.PONo} = '" & Trim(txtPONo.Text) & "'"
            'fSalesReportViewer.CrystalReportViewer1.SelectionFormula = strMRCode
            fSalesReportViewer.CrystalReportViewer1.ReportSource = CrRepDoc
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    'Private Sub fgSearch_KeyPressEvent(ByVal sender As Object, ByVal e As AxVSFlex7L._IVSFlexGridEvents_KeyPressEvent)
    '    'Dim e1 As System.EventArgs
    '    'fgSearch_DblClick(sender, e1)

    'End Sub

    Private Sub fgDetail_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)

        'If fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "PurchaseInvoice" Then
        '    DisplayFormsOnClick("PI", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "SaleInvoice" Then
        '    DisplayFormsOnClick("SI", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "PurchaseReturn" Then
        '    DisplayFormsOnClick("PR", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "SaleReturn" Then
        '    DisplayFormsOnClick("SR", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "TaxInvoice" Then
        '    DisplayFormsOnClick("TAX", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'End If

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable

        Try

            dv = New DataView(ds_Search.Tables(0), "ItemName Like '" & Trim(txtSearch.Text) & "*" & "'", "ItemCode", DataViewRowState.CurrentRows)
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemCode")), "", dTable.Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemName")), "", dTable.Rows(i).Item("ItemName"))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("Make")), "", dTable.Rows(i).Item("Make"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("CurrentStock")), "", dTable.Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("Unit")), "", dTable.Rows(i).Item("Unit"))

                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("CurrentSubStock")), "", dTable.Rows(i).Item("CurrentSubStock"))

                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dTable.Rows(i).Item("StoreUnit")), "", dTable.Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dTable.Rows(i).Item("ConvFAct")), "", dTable.Rows(i).Item("ConvFAct"))




                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        'Dim Strquery As String
        'Dim f_daDept As SqlClient.SqlDataAdapter
        'Dim f_dsDept As New DataSet
        'Dim drDisplay As DataRow

        'fgSearch.Rows = 1
        'Strquery = "SELECT * from ItemMaster  WHERE     (ItemName  LIKE '%" & txtSearch.Text & "%') order by ItemName"

        'f_daDept = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'f_dsDept.Clear()
        'f_daDept.Fill(f_dsDept, "ItemList")
        'For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
        '    drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
        '    With fgSearch
        '        .Rows = .Rows + 1
        '        .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
        '        .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode")))
        '        .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName")))
        '        .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drDisplay.Item("MAke")), "", drDisplay.Item("MAke")))
        '        .set_TextMatrix(.Rows - 1, 4, IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock")))
        '        .set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit")))
        '        .set_TextMatrix(.Rows - 1, 6, IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock")))
        '        .set_TextMatrix(.Rows - 1, 7, IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit")))
        '        .set_TextMatrix(.Rows - 1, 8, IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct")))
        '    End With
        'Next


    End Sub

    Private Sub cmdStockReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStockReport.Click
        Stock()
        Dim fSalesReportViewer As New frmReportViewer
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        Dim strMRCode As String
        Dim Strquery As String
        Dim trn As SqlClient.SqlTransaction
        Dim cmdCom1 As SqlClient.SqlCommand


        fSalesReportViewer.MdiParent = MainForm
        fSalesReportViewer.Text = "Stock Report"
        fSalesReportViewer.Refresh()
        fSalesReportViewer.Show()


        Me.Cursor = Cursors.WaitCursor
        Try



            CrRepDoc.Load(Application.StartupPath & "\Report\rptStockReportOnDate.rpt")


            For Each tbCurrent In CrRepDoc.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo

                    .ServerName = gl_Con.DataSource
                    .UserID = "sa"
                    .Password = gl_strpwd
                    .DatabaseName = gl_Con.Database

                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent
            CrRepDoc.Refresh()
            'strMRCode = "{PurchaseMaster.PONo} = '" & Trim(txtPONo.Text) & "'"
            'fSalesReportViewer.CrystalReportViewer1.SelectionFormula = strMRCode
            fSalesReportViewer.CrystalReportViewer1.ReportSource = CrRepDoc
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.DoubleClick
        With dgSearch

            If dgSearch.RowCount = 0 Then
                MessageBox.Show("No Record Found")
                gbMain.BringToFront()
                gbSearch.SendToBack()
                Exit Sub
            Else
                If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                    txtItemCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    txtItemName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                Else
                    txtItemCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    txtItemName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                End If
                intDGSearchKeayPress = 0
                gbMain.BringToFront()
                gbSearch.SendToBack()
            End If
        End With
    End Sub

    Private Sub dgSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSearch.KeyPress
        Dim e1 As System.EventArgs
        If (e.KeyChar = Convert.ToChar(13)) Then
            intDGSearchKeayPress = 1
            dgSearch_DoubleClick(sender, e1)
        End If
    End Sub

    Private Sub dgDetail_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetail.DoubleClick
        If dgDetail.RowCount >= 1 Then

            If dgDetail(2, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "PurchaseInvoice" Then
                DisplayFormsOnClick("PI", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(2, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "SaleInvoice" Then
                DisplayFormsOnClick("SI", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(2, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "PurchaseReturn" Then
                DisplayFormsOnClick("PR", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(2, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "SaleReturn" Then
                DisplayFormsOnClick("SR", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(2, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "TaxInvoice" Then
                DisplayFormsOnClick("TAX", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)

            End If
        End If

        'If fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "PurchaseInvoice" Then
        '    DisplayFormsOnClick("PI", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "SaleInvoice" Then
        '    DisplayFormsOnClick("SI", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "PurchaseReturn" Then
        '    DisplayFormsOnClick("PR", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "SaleReturn" Then
        '    DisplayFormsOnClick("SR", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 2) = "TaxInvoice" Then
        '    DisplayFormsOnClick("TAX", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'End If

    End Sub
End Class