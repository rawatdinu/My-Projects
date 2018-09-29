Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmSupplierAccount
    Dim CrRepDoc As New ReportDocument
    Dim Cash As Integer
    Dim intDGSearchKeayPress As Integer
    Dim da_search As New SqlDataAdapter
    Dim ds_search As New DataSet


    Private Sub cmdFindItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindItem.Click
        'gbSearch.BringToFront()
        'FillSearchGridInfo()
        'FillGridItem()
        'Button2.Enabled = True
        'fgDetail.Rows = 1
        'txtSearch.Text = ""
        'txtSearch.Focus()

        Dim StrQuery As String
        da_search.Dispose()
        ds_search.Clear()
        Dim i As Integer
        Button2.Enabled = True
        FillSearchGridInfo()

        Try

            StrQuery = "SELECT * from SupplierMaster1 order by SupplierName"
            da_search = New SqlDataAdapter(StrQuery, gl_Con)
            da_search.Fill(ds_search, "FillGrid")
            dgSearch.RowCount = 1
            If ds_search.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds_search.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds_search.Tables("FillGrid").Rows(i).Item("SupplierCode")), "", ds_search.Tables("FillGrid").Rows(i).Item("SupplierCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds_search.Tables("FillGrid").Rows(i).Item("SupplierName")), "", ds_search.Tables("FillGrid").Rows(i).Item("SupplierName"))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds_search.Tables("FillGrid").Rows(i).Item("Address")), "", ds_search.Tables("FillGrid").Rows(i).Item("Address"))

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
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FillGridInfo()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 13
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "TrnNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "TrnDate"
            .Columns(2).Width = 80
            .Columns(3).Name = "TrnType"
            .Columns(3).Width = 80
            .Columns(4).Name = "Op Bal"
            .Columns(4).Width = 80
            .Columns(5).Name = "PaidAmount"
            .Columns(5).Width = 80
            .Columns(6).Name = "PurchaseAmount"
            .Columns(6).Width = 80
            .Columns(7).Name = "Total"
            .Columns(7).Width = 80
            .Columns(7).Visible = False
            .Columns(8).Name = "Total"
            .Columns(8).Width = 80
            .Columns(9).Name = "DB/CR"
            .Columns(9).Width = 80
            .Columns(10).Name = "InvoiceNo"
            .Columns(10).Width = 80
            .Columns(11).Name = "ChallanNo"
            .Columns(11).Width = 80
            .Columns(12).Name = "Remarks"
            .Columns(12).Width = 120


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
        '    .Cols = 13

        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "S.No")


        '    .set_TextMatrix(0, 1, "TrnNo")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "TrnDate")
        '    .set_ColWidth(2, 1500)
        '    .set_TextMatrix(0, 3, "TrnType")
        '    .set_ColWidth(3, 1500)
        '    .set_TextMatrix(0, 4, "Op Bal")
        '    .set_ColWidth(4, 1300)

        '    .set_TextMatrix(0, 5, "PaidAmount")
        '    .set_ColWidth(5, 1600)

        '    .set_TextMatrix(0, 6, "PurchaseAmount")
        '    .set_ColWidth(6, 1600)

        '    .set_TextMatrix(0, 7, "Total")
        '    .set_ColWidth(7, 1600)
        '    .set_ColHidden(7, True)

        '    .set_TextMatrix(0, 8, "Total")
        '    .set_ColWidth(8, 1300)

        '    .set_TextMatrix(0, 9, "DB/CR")
        '    .set_ColWidth(9, 1000)

        '    .set_TextMatrix(0, 10, "InvoiceNo")
        '    .set_ColWidth(10, 1000)

        '    .set_TextMatrix(0, 11, "ChallanNo")
        '    .set_ColWidth(11, 1200)

        '    .set_TextMatrix(0, 12, "Remarks")
        '    .set_ColWidth(12, 1200)

        'End With


    End Sub
    Private Sub FillSearchGridInfo()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 6
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 50
            .Columns(1).Name = "SupplierCode"
            .Columns(1).Width = 100
            .Columns(2).Name = "Supplier Name"
            .Columns(2).Width = 200
            .Columns(3).Name = "Address"
            .Columns(3).Width = 200
            .Columns(4).Name = "City"
            .Columns(4).Width = 130
            .Columns(5).Name = "State"
            .Columns(5).Width = 130

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
        '    .Cols = 6
        '    '.Width = 678
        '    '.Height = 193
        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "S.No")


        '    .set_TextMatrix(0, 1, "SupplierCode")
        '    .set_ColWidth(1, 2000)
        '    .set_TextMatrix(0, 2, "SupplierName")
        '    .set_ColWidth(2, 3000)
        '    .set_TextMatrix(0, 3, "Address")
        '    .set_ColWidth(3, 3000)
        '    .set_TextMatrix(0, 4, "City")
        '    .set_ColWidth(4, 1500)

        '    .set_TextMatrix(0, 5, "State")
        '    .set_ColWidth(5, 1500)
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

        '    StrQuery = "SELECT * from SupplierMaster1 order by SupplierName"


        '    f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
        '    f_dsDept.Clear()
        '    f_daDept.Fill(f_dsDept, "ItemList")
        '    For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
        '        drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
        '        With fgSearch
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
        '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("SupplierCode")), "", drDisplay.Item("SupplierCode")))
        '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(drDisplay.Item("SupplierName")), "", drDisplay.Item("SupplierName")))
        '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drDisplay.Item("Address")), "", drDisplay.Item("Address")))
        '            '.set_TextMatrix(.Rows - 1, 4, IIf(IsDBNull(drDisplay.Item("City")), 0, drDisplay.Item("City")))
        '            '.set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(drDisplay.Item("State")), "", drDisplay.Item("State")))

        '        End With
        '    Next



        'Catch ex As Exception

        '    MsgBox(ex.Message)
        'End Try
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub fgSearch_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'txtSuppCode.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
        'txtSuppName.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 2)
        'gbSearch.SendToBack()
        'gbMain.BringToFront()
    End Sub

    Private Sub frmSupplierAccount_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        SupplierAcc = Nothing
    End Sub




    Private Sub frmItemAccountStatement_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtSuppCode.ReadOnly = True
        txtSuppName.ReadOnly = True
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

        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim OpDebit As Decimal
        Dim OpCredit As Decimal
        Dim Debit As Decimal
        Dim Credit As Decimal
        Dim i As Integer

        Dim TrnNo As String
        Dim TrnDate As Date

        Dim Narration As String
        Dim TransactionType As String

        cmdPrint.Enabled = True


        Strquery = "Delete From Temp_PartyAccoumt"

        trn = gl_Con.BeginTransaction
        cmdCom1 = New SqlClient.SqlCommand(Strquery, gl_Con)
        cmdCom1.CommandType = CommandType.Text
        cmdCom1.Transaction = trn
        cmdCom1.ExecuteNonQuery()
        trn.Commit()



        '''*********************************************OpeningBalance**************************************************

        Strquery = "SELECT OpeningBalance As  Debit FROM SupplierMaster1 where Suppliercode='" & txtSuppCode.Text & "'  "

        da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "MR")

        If ds.Tables("MR").Rows.Count > 0 Then
            OpCredit = IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Debit")), 0, ds.Tables("MR").Rows(0).Item("Debit"))
        Else
            OpDebit = 0
            OpCredit = 0
        End If

        If OpCredit < 0 Then
            OpDebit = 0 - OpCredit
            OpDebit = 0
        End If

        da.Dispose()
        ds.Clear()





        Strquery = "SELECT Sum(Ledger.Debit) As Debit,Sum( Ledger.Credit) As Credit FROM Ledger where LedgerCode='" & txtSuppCode.Text & "' and Ledger.TransactionDate < '" & convertToServerDateFormat(dtpFromDate.Value) & "' "

        da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "MR")

        If ds.Tables("MR").Rows.Count > 0 Then
            OpDebit = OpDebit + IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Debit")), 0, ds.Tables("MR").Rows(0).Item("Debit"))
            OpCredit = OpCredit + IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("Credit")), 0, ds.Tables("MR").Rows(0).Item("Credit"))
        Else
            OpDebit = 0
            OpCredit = 0
        End If

        da.Dispose()
        ds.Clear()




        Strquery = "Insert into Temp_PartyAccoumt(Sno,FromDate,Todate,TransactionNo,TransactionDate,LedgerCode,TransactionType,Debit, Credit,Narration) values(1,'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','Opening','" & convertToServerDateFormat(dtpFromDate.Value) & "','" & txtSuppCode.Text & "','OPENING'," & OpDebit & "," & OpCredit & ",'' )"

        trn = gl_Con.BeginTransaction
        cmdCom1.Transaction = trn
        cmdCom1.Connection = gl_Con
        cmdCom1.CommandText = Strquery
        cmdCom1.ExecuteNonQuery()
        trn.Commit()




        '''************************************************************************************************************


        Strquery = "SELECT Ledger.TransactionNo, Ledger.TransactionDate, Ledger.LedgerCode, Ledger.TransactionType, Ledger.Debit, Ledger.Credit, Ledger.Narration FROM Ledger   WHERE  Ledger.LedgerCode='" & txtSuppCode.Text & "'And Ledger.TransactionDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and Ledger.TransactionDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "' "


        da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "MR")

        If ds.Tables("MR").Rows.Count > 0 Then

            For i = 0 To ds.Tables("MR").Rows.Count - 1


                TrnNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionNo")), "", ds.Tables("MR").Rows(i).Item("TransactionNo"))
                TrnDate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionDate")), "01/01/1990", ds.Tables("MR").Rows(i).Item("TransactionDate"))
                Debit = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Debit")), 0, ds.Tables("MR").Rows(i).Item("Debit"))
                Credit = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Credit")), 0, ds.Tables("MR").Rows(i).Item("Credit"))
                Narration = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Narration")), "", ds.Tables("MR").Rows(i).Item("Narration"))
                TransactionType = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionType")), "", ds.Tables("MR").Rows(i).Item("TransactionType"))


                Strquery = "Insert into Temp_PartyAccoumt(Sno,FromDate,Todate,TransactionNo,TransactionDate,LedgerCode,TransactionType,Debit, Credit,Narration) values(2,'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & TrnNo & "','" & convertToServerDateFormat(TrnDate) & "','" & txtSuppCode.Text & "','" & TransactionType & "'," & Debit & "," & Credit & ",'" & Narration & "' )"

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






        'Strquery = "SELECT SaleMaster.Cash, SaleMaster.CustomerName1, SaleMaster.SaleInvoiceNo, SaleMaster.SaleDate, SaleDetail.ItemCode, SaleDetail.Qty, SaleDetail.SubQty, SaleDetail.Rate, SaleDetail.SubRate, SaleMaster.InvoiceNo, SaleMaster.ChallanNo, CustomerMaster1.CustomerName FROM SaleDetail INNER JOIN (SaleMaster LEFT JOIN CustomerMaster1 ON SaleMaster.CustomerCode = CustomerMaster1.CustomerCode) ON SaleDetail.SaleInvoiceNo = SaleMaster.SaleInvoiceNo WHERE SaleDetail.ItemCode='" & txtSuppCode.Text & "' and SaleMaster.SaleDate >= #" & convertToServerDateFormatconvertToServerDateFormat(dtpFromDate.Value) & "#  and SaleMaster.SaleDate <= #" &convertToServerDateFormat(dtpToDate.Value) & "# "
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "MR")

        'If ds.Tables("MR").Rows.Count > 0 Then

        '    For i = 0 To ds.Tables("MR").Rows.Count - 1
        '        Cash = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Cash")), 0, ds.Tables("MR").Rows(i).Item("Cash"))

        '        TrnNo = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SaleInvoiceNo")), "", ds.Tables("MR").Rows(i).Item("SaleInvoiceNo"))
        '        TrnDate = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SaleDate")), "01/01/1990", ds.Tables("MR").Rows(i).Item("SaleDate"))
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
        '        Opqty = Opqty - qty
        '        Opsubqty = Opsubqty - subqty

        '        Strquery = "Insert into Temp_PartyAccoumt(Sno,FromDate,Todate,TransactionNo,TransactionDate,ItemCode,Issued, Issued1, Rate,SubRate,InvoiceNo,ChallanNo,PartyName,Balance,Balance1) values(2,'" & dtpFromDate.Value & "','" & dtpToDate.Value & "','" & TrnNo & "','" & TrnDate & "','" & txtSuppCode.Text & "'," & qty & "," & subqty & "," & rate & "," & SubRate & ",'" & InvoiceNo & "','" & ChallanNo & "','" & PartyName & "'," & Opqty & "," & Opsubqty & " )"

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



        Strquery = "SELECT Temp_PartyAccoumt.Sno, Temp_PartyAccoumt.TransactionNo, Temp_PartyAccoumt.TransactionDate, Temp_PartyAccoumt.LedgerCode, Temp_PartyAccoumt.Debit, Temp_PartyAccoumt.TransactionType, Temp_PartyAccoumt.Credit, Temp_PartyAccoumt.Narration, PurchaseMaster.InvoiceNo, PurchaseMaster.ChallanNo, PurchaseMaster.Remarks FROM Temp_PartyAccoumt LEFT JOIN PurchaseMaster ON Temp_PartyAccoumt.TransactionNo = PurchaseMaster.PurchaseNo ORDER BY Temp_PartyAccoumt.Sno, Temp_PartyAccoumt.TransactionDate"

        da = New SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "MR")
        dgDetail.RowCount = 1
        If ds.Tables("MR").Rows.Count > 0 Then
            With dgDetail
                For i = 0 To ds.Tables("MR").Rows.Count - 1

                    .RowCount = .RowCount + 1
                    .Rows(i).Cells(0).Value = i + 1

                    .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionNo")), "", ds.Tables("MR").Rows(i).Item("TransactionNo"))
                    .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate")))
                    .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionType")), "", ds.Tables("MR").Rows(i).Item("TransactionType"))
                    .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Debit")), "", ds.Tables("MR").Rows(i).Item("Debit"))
                    .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Credit")), "", ds.Tables("MR").Rows(i).Item("Credit"))


                    If Trim(.Rows(i).Cells(1).Value.ToString) = "Opening" Then
                        txtOpening.Text = Val(.Rows(i).Cells(6).Value) - Val(.Rows(i).Cells(5).Value)
                    End If

                    If i = 0 Then
                        .Rows(i).Cells(4).Value = 0.0
                        .Rows(i).Cells(7).Value = Val(.Rows(i).Cells(4).Value) + Val(.Rows(i).Cells(5).Value) - Val(.Rows(i).Cells(6).Value)
                    Else
                        .Rows(i).Cells(4).Value = Val(.Rows(i).Cells(7).Value)
                        .Rows(i).Cells(7).Value = Val(.Rows(i).Cells(4).Value) + Val(.Rows(i).Cells(5).Value) - Val(.Rows(i).Cells(6).Value)
                    End If

                    If Val(.Rows(i).Cells(7).Value) < 0 Then
                        .Rows(i).Cells(8).Value = 0 - Val(.Rows(i).Cells(7).Value)
                        .Rows(i).Cells(9).Value = "CR"
                    Else
                        .Rows(i).Cells(8).Value = Val(.Rows(i).Cells(7).Value)
                        .Rows(i).Cells(9).Value = "DB"

                    End If



                    .Rows(i).Cells(10).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo"))
                    .Rows(i).Cells(11).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), "", ds.Tables("MR").Rows(i).Item("ChallanNo"))
                    .Rows(i).Cells(12).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Narration")), "", ds.Tables("MR").Rows(i).Item("Narration"))

                Next
                .RowCount = .RowCount - 1
            End With
        Else
            dgSearch.RowCount = 0
        End If



        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "MR")

        'fgDetail.Rows = 1
        'For i = 0 To ds.Tables("MR").Rows.Count - 1
        '    With fgDetail
        '        .Rows = .Rows + 1
        '        .set_TextMatrix(i + 1, 0, i + 1)
        '        .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionNo")), "", ds.Tables("MR").Rows(i).Item("TransactionNo")))
        '        .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate"))))
        '        .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionType")), "", ds.Tables("MR").Rows(i).Item("TransactionType")))


        '        .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Debit")), "", ds.Tables("MR").Rows(i).Item("Debit")))
        '        .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Credit")), 0, ds.Tables("MR").Rows(i).Item("Credit")))

        '        If Trim(.get_TextMatrix(i + 1, 1)) = "Opening" Then
        '            txtOpening.Text = Val(.get_TextMatrix(i + 1, 6)) - Val(.get_TextMatrix(i + 1, 5))
        '        End If


        '        'If .get_TextMatrix(i + 1, 5) <> 0 Then
        '        '    .set_TextMatrix(i + 1, 8, "DB")
        '        'Else
        '        '    .set_TextMatrix(i + 1, 8, "CR")


        '        'End If


        '        If i = 0 Then
        '            .set_TextMatrix(i + 1, 4, 0.0)
        '            .set_TextMatrix(i + 1, 7, Val(.get_TextMatrix(i + 1, 4)) + Val(.get_TextMatrix(i + 1, 5)) - Val(.get_TextMatrix(i + 1, 6)))
        '        Else
        '            .set_TextMatrix(i + 1, 4, Val(.get_TextMatrix(i, 7)))
        '            .set_TextMatrix(i + 1, 7, Val(.get_TextMatrix(i + 1, 4)) + Val(.get_TextMatrix(i + 1, 5)) - Val(.get_TextMatrix(i + 1, 6)))
        '        End If

        '        If .get_TextMatrix(i + 1, 7) < 0 Then
        '            .set_TextMatrix(i + 1, 8, 0 - Val(.get_TextMatrix(i + 1, 7)))
        '            .set_TextMatrix(i + 1, 9, "CR")
        '        Else
        '            .set_TextMatrix(i + 1, 8, Val(.get_TextMatrix(i + 1, 7)))
        '            .set_TextMatrix(i + 1, 9, "DB")


        '        End If



        '        .set_TextMatrix(i + 1, 10, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo")))
        '        .set_TextMatrix(i + 1, 11, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), "", ds.Tables("MR").Rows(i).Item("ChallanNo")))
        '        .set_TextMatrix(i + 1, 12, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Narration")), 0, ds.Tables("MR").Rows(i).Item("Narration")))
        '        '.set_TextMatrix(i + 1, 12, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), 0, ds.Tables("MR").Rows(i).Item("ChallanNo")))

        '        '.set_TextMatrix(i + 1, 13, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PartyName")), 0, ds.Tables("MR").Rows(i).Item("PartyName")))

        '    End With
        'Next

        da.Dispose()
        ds.Clear()


        Strquery = "SELECT Sum(Temp_PartyAccoumt.Debit) AS SumOfDebit, Sum(Temp_PartyAccoumt.Credit) AS SumOfCredit        FROM Temp_PartyAccoumt WHERE (((Temp_PartyAccoumt.TransactionType)<>'Opening'))"

        da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "MR")

        If ds.Tables("MR").Rows.Count > 0 Then
            txtDebit.Text = IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("SumOfDebit")), 0, ds.Tables("MR").Rows(0).Item("SumOfDebit"))
            txtCredit.Text = IIf(IsDBNull(ds.Tables("MR").Rows(0).Item("SumOfCredit")), 0, ds.Tables("MR").Rows(0).Item("SumOfCredit"))
        End If

        txtBalance.Text = Val(txtOpening.Text) - Val(txtDebit.Text) + Val(txtCredit.Text)


        da.Dispose()
        ds.Clear()





    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim fSalesReportViewer As New frmReportViewer
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        Dim strMRCode As String
        Dim Strquery As String
        Dim trn As SqlClient.SqlTransaction
        Dim cmdCom1 As SqlClient.SqlCommand


        fSalesReportViewer.MdiParent = MainForm
        fSalesReportViewer.Text = "Supplier Account Statement"
        fSalesReportViewer.Refresh()
        fSalesReportViewer.Show()


        Me.Cursor = Cursors.WaitCursor
        Try


            Strquery = "delete from Temp_PartyAccoumt"

            trn = gl_Con.BeginTransaction
            cmdCom1 = New SqlClient.SqlCommand(Strquery, gl_Con)
            cmdCom1.CommandType = CommandType.Text
            cmdCom1.Transaction = trn
            cmdCom1.ExecuteNonQuery()
            trn.Commit()


            With dgDetail
                For i = 0 To .RowCount - 1
                    Strquery = "Insert into Temp_PartyAccoumt(Sno,FromDate,Todate,TransactionNo,TransactionDate,LedgerCode,Debit,TransactionType,Credit,Balance,DBCR, Narration,InvoiceNo,ChallanNo ) values (" & Val(.Rows(i).Cells(0).Value) & ",'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (.Rows(i).Cells(1).Value) & "','" & (.Rows(i).Cells(2).Value) & "','" & txtSuppCode.Text & "','" & Val(.Rows(i).Cells(5).Value) & "','" & (.Rows(i).Cells(3).Value) & "','" & Val(.Rows(i).Cells(6).Value) & "','" & Val(.Rows(i).Cells(8).Value) & "','" & (.Rows(i).Cells(9).Value) & "','" & (.Rows(i).Cells(12).Value) & "','" & (.Rows(i).Cells(10).Value) & "','" & (.Rows(i).Cells(11).Value) & "')"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = Strquery
                    cmdCom1.ExecuteNonQuery()

                    trn.Commit()
                Next
            End With

            'For i = 1 To fgDetail.Rows - 1
            '    Strquery = "Insert into Temp_PartyAccoumt(Sno,FromDate,Todate,TransactionNo,TransactionDate,LedgerCode,Debit,TransactionType,Credit,Balance,DBCR, Narration,InvoiceNo,ChallanNo ) values (" & Val(fgDetail.get_TextMatrix(i, 0)) & ",'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (fgDetail.get_TextMatrix(i, 1)) & "','" & (fgDetail.get_TextMatrix(i, 2)) & "','" & txtSuppCode.Text & "','" & Val(fgDetail.get_TextMatrix(i, 5)) & "','" & (fgDetail.get_TextMatrix(i, 3)) & "','" & Val(fgDetail.get_TextMatrix(i, 6)) & "','" & Val(fgDetail.get_TextMatrix(i, 8)) & "','" & (fgDetail.get_TextMatrix(i, 9)) & "','" & (fgDetail.get_TextMatrix(i, 12)) & "','" & (fgDetail.get_TextMatrix(i, 10)) & "','" & (fgDetail.get_TextMatrix(i, 11)) & "')"

            '    trn = gl_Con.BeginTransaction
            '    cmdCom1.Transaction = trn
            '    cmdCom1.Connection = gl_Con
            '    cmdCom1.CommandText = Strquery
            '    cmdCom1.ExecuteNonQuery()

            '    trn.Commit()
            'Next




            CrRepDoc.Load(Application.StartupPath & "\Report\rptSupplierAccountStatement.rpt")


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
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable

        Try

            dv = New DataView(ds_search.Tables(0), "SupplierName Like '" & Trim(txtSearch.Text) & "*" & "'", "SupplierCode", DataViewRowState.CurrentRows)
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("SupplierCode")), "", dTable.Rows(i).Item("SupplierCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("SupplierName")), "", dTable.Rows(i).Item("SupplierName"))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("Address")), "", dTable.Rows(i).Item("Address"))

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
        'Strquery = "Select SupplierCode,Suppliername,Address from SupplierMaster1 WHERE     (Suppliername  LIKE '%" & txtSearch.Text & "%') order by Suppliername"

        'f_daDept = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'f_dsDept.Clear()
        'f_daDept.Fill(f_dsDept, "ItemList")
        'For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
        '    drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
        '    With fgSearch
        '        .Rows = .Rows + 1
        '        .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
        '        .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("SupplierCode")), "", drDisplay.Item("SupplierCode")))
        '        .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(drDisplay.Item("SupplierName")), "", drDisplay.Item("SupplierName")))
        '        .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drDisplay.Item("Address")), "", drDisplay.Item("Address")))

        '    End With
        'Next

    End Sub



    'Private Sub fgSearch_KeyPressEvent(ByVal sender As Object, ByVal e As AxVSFlex7L._IVSFlexGridEvents_KeyPressEvent)
    '    Dim e1 As System.EventArgs
    '    fgSearch_DblClick(sender, e1)
    'End Sub

    Private Sub fgDetail_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'If fgDetail.get_TextMatrix(fgDetail.RowSel, 3) = "PurchaseInvoice" Then
        '    DisplayFormsOnClick("PI", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 3) = "Payment" Then
        '    DisplayFormsOnClick("PAY", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'End If
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
                    txtSuppCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    txtSuppName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                  
                Else
                    txtSuppCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    txtSuppName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
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
            If dgDetail(3, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "PurchaseInvoice" Then
                DisplayFormsOnClick("PI", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(3, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "Payment" Then
                DisplayFormsOnClick("PAY", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)

            End If
        End If

    End Sub
End Class

