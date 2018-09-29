Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmDayBook
    Dim CrRepDoc As New ReportDocument


    Private Sub frmDayBook_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DayBook = Nothing
    End Sub
    Private Sub FillGridInfo()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 8
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "ReceiptNo"
            .Columns(1).Width = 90
            .Columns(2).Name = "Date"
            .Columns(2).Width = 80
            .Columns(3).Name = "Customer Name"
            .Columns(3).Width = 200
            .Columns(4).Name = "Mode"
            .Columns(4).Width = 100
            .Columns(5).Name = "Credit"
            .Columns(5).Width = 100
            .Columns(6).Name = "Debit"
            .Columns(6).Width = 100
            .Columns(7).Name = "Total"
            .Columns(7).Width = 90
   
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
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .Rows = 1
        '    .Cols = 8

        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "S.No")


        '    .set_TextMatrix(0, 1, "Receipt No")
        '    .set_ColWidth(1, 1200)

        '    .set_TextMatrix(0, 2, "Date")
        '    .set_ColWidth(2, 1400)

        '    .set_TextMatrix(0, 3, "Customer Name")
        '    .set_ColWidth(3, 3500)

        '    .set_TextMatrix(0, 4, "Mode")
        '    .set_ColWidth(4, 1500)

        '    .set_TextMatrix(0, 5, "Credit")
        '    .set_ColWidth(5, 1200)


        '    .set_TextMatrix(0, 6, "Debit")
        '    .set_ColWidth(6, 1200)


        '    .set_TextMatrix(0, 7, "Total")
        '    .set_ColWidth(7, 1200)


        'End With


    End Sub
    Private Sub FillGrid()

        Dim Strquery As String

        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try

            Strquery = "SELECT ReceiptMaster.ReceiptNo, ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, ReceiptMaster.Mode, ReceiptMaster.CashAmount, ReceiptMaster.Remarks FROM ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode WHERE ReceiptMaster.Approve=1 and ReceiptMaster.ReceiptDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and ReceiptMaster.ReceiptDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'   AND ((ReceiptMaster.Mode)='Cash')  order by ReceiptMaster.ReceiptNo"

            da = New SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")
            dgDetail.RowCount = 1
            If ds.Tables("MR").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To ds.Tables("MR").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ReceiptNo")), "", ds.Tables("MR").Rows(i).Item("ReceiptNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("ReceiptDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("ReceiptDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName")), "", ds.Tables("MR").Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(4).Value = "Cash"
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashAmount")), 0, ds.Tables("MR").Rows(i).Item("CashAmount"))
                        .Rows(i).Cells(6).Value = 0

                    Next
                    .RowCount = .RowCount - 1
                End With

            End If





            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")
            'fgDetail.Rows = 1

            'If ds.Tables("MR").Rows.Count > 0 Then

            '    For i = 0 To ds.Tables("MR").Rows.Count - 1
            '        With fgDetail
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
            '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ReceiptNo")), "", ds.Tables("MR").Rows(i).Item("ReceiptNo")))
            '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("ReceiptDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("ReceiptDate"))))
            '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName")), "", ds.Tables("MR").Rows(i).Item("CustomerName")))


            '            .set_TextMatrix(.Rows - 1, 4, "Cash")

            '            .set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashAmount")), 0, ds.Tables("MR").Rows(i).Item("CashAmount")))

            '            .set_TextMatrix(.Rows - 1, 6, 0)

            '        End With


            '    Next

            'End If

            da.Dispose()
            ds.Clear()


            'Strquery = "SELECT ReceiptMaster.ReceiptNo, ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, ReceiptMaster.Mode, ReceiptMaster.CashAmount, ReceiptMaster.ChequeAmount, ReceiptMaster.AmountTransfer, ReceiptMaster.Remarks FROM ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode WHERE ReceiptMaster.Approve=1 and  ReceiptMaster.ReceiptDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and ReceiptMaster.ReceiptDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "' order by ReceiptMaster.ReceiptNo"


            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")
            'fgDetail.Rows = 1
            'If ds.Tables("MR").Rows.Count > 0 Then

            '    For i = 0 To ds.Tables("MR").Rows.Count - 1
            '        With fgDetail
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(i + 1, 0, i + 1)
            '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ReceiptNo")), "", ds.Tables("MR").Rows(i).Item("ReceiptNo")))
            '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("ReceiptDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("ReceiptDate"))))
            '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName")), "", ds.Tables("MR").Rows(i).Item("CustomerName")))


            '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Mode")), "", ds.Tables("MR").Rows(i).Item("Mode")))
            '            If .get_TextMatrix(i + 1, 4) = "Cash" Then
            '                .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashAmount")), 0, ds.Tables("MR").Rows(i).Item("CashAmount")))
            '            ElseIf .get_TextMatrix(i + 1, 4) = "Cheque" Then
            '                .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChequeAmount")), 0, ds.Tables("MR").Rows(i).Item("ChequeAmount")))
            '            ElseIf .get_TextMatrix(i + 1, 4) = "BankTransfer" Then
            '                .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("AmountTransfer")), 0, ds.Tables("MR").Rows(i).Item("AmountTransfer")))
            '            End If
            '            .set_TextMatrix(i + 1, 6, 0)

            '        End With


            '    Next

            'End If

            'da.Dispose()
            'ds.Clear()

            Strquery = "SELECT SaleMaster.SaleInvoiceNo, SaleMaster.SaleDate, SaleMaster.CustomerName1, SaleMaster.CashManual, SaleMaster.CashParty, SaleMaster.TotalValue, SaleMaster.Remarks FROM SaleMaster WHERE SaleMaster.Approve=1 and  SaleMaster.SaleDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and SaleMaster.SaleDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'  and (((SaleMaster.CashManual)=1) or ((SaleMaster.CashParty)=1)) order by SaleMaster.SaleInvoiceNo"

            da = New SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")
            If dgDetail.RowCount < 2 Then
                dgDetail.RowCount = 1
            End If

            If ds.Tables("MR").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To ds.Tables("MR").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SaleInvoiceNo")), "", ds.Tables("MR").Rows(i).Item("SaleInvoiceNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("SaleDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName1")), "", ds.Tables("MR").Rows(i).Item("CustomerName1"))
                        .Rows(i).Cells(4).Value = "Cash"
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TotalValue")), 0, ds.Tables("MR").Rows(i).Item("TotalValue"))
                        .Rows(i).Cells(6).Value = 0

                    Next
                    .RowCount = .RowCount - 1
                End With
            End If




            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")
            'If fgDetail.Rows < 2 Then
            '    fgDetail.Rows = 1
            'End If

            'If ds.Tables("MR").Rows.Count > 0 Then

            '    For i = 0 To ds.Tables("MR").Rows.Count - 1
            '        With fgDetail
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
            '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SaleInvoiceNo")), "", ds.Tables("MR").Rows(i).Item("SaleInvoiceNo")))
            '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("SaleDate"))))
            '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName1")), "", ds.Tables("MR").Rows(i).Item("CustomerName1")))


            '            .set_TextMatrix(.Rows - 1, 4, "Cash")

            '            .set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TotalValue")), 0, ds.Tables("MR").Rows(i).Item("TotalValue")))

            '            .set_TextMatrix(.Rows - 1, 6, 0)

            '        End With


            '    Next

            'End If

            da.Dispose()
            ds.Clear()

            Strquery = "SELECT BankVoucher.BankVoucherNo, BankVoucher.BankVoucherDate, BankMaster.BankName, BankVoucher.Mode, BankVoucher.CashDepositAmount, BankVoucher.CashWithdrawlAmount, BankVoucher.AmountTransfer, BankVoucher.Remarks FROM BankVoucher INNER JOIN BankMaster ON BankVoucher.BankCode = BankMaster.AccCode WHERE BankVoucher.Approve=1 and BankVoucher.BankVoucherDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and BankVoucher.BankVoucherDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'   AND ((BankVoucher.Mode)='CashDeposit' or (BankVoucher.Mode)='CashWithdrawl')  order by BankVoucher.BankVoucherNo"

            da = New SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")
            If dgDetail.RowCount < 2 Then
                dgDetail.RowCount = 1
            End If

            If ds.Tables("MR").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To ds.Tables("MR").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("BankVoucherNo")), "", ds.Tables("MR").Rows(i).Item("BankVoucherNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("BankVoucherDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("BankVoucherDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("BankName")), "", ds.Tables("MR").Rows(i).Item("BankName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Mode")), "", ds.Tables("MR").Rows(i).Item("Mode"))
                        If Trim(.Rows(i).Cells(4).Value) = "CashDeposit" Then
                            .Rows(i).Cells(5).Value = 0
                            .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashDepositAmount")), 0, ds.Tables("MR").Rows(i).Item("CashDepositAmount"))
                         
                        ElseIf Trim(.Rows(i).Cells(4).Value) = "CashWithdrawl" Then

                            .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashWithdrawlAmount")), 0, ds.Tables("MR").Rows(i).Item("CashWithdrawlAmount"))
                            .Rows(i).Cells(6).Value = 0
                        End If


                    Next
                    .RowCount = .RowCount - 1
                End With
           
            End If



            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")
            'If fgDetail.Rows < 2 Then
            '    fgDetail.Rows = 1
            'End If

            'If ds.Tables("MR").Rows.Count > 0 Then

            '    For i = 0 To ds.Tables("MR").Rows.Count - 1
            '        With fgDetail
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
            '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("BankVoucherNo")), "", ds.Tables("MR").Rows(i).Item("BankVoucherNo")))
            '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("BankVoucherDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("BankVoucherDate"))))
            '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("BankName")), "", ds.Tables("MR").Rows(i).Item("BankName")))
            '            .set_TextMatrix(.Rows - 1, 4, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Mode")), "", ds.Tables("MR").Rows(i).Item("Mode")))
            '            If .get_TextMatrix(.Rows - 1, 4) = "CashDeposit" Then
            '                .set_TextMatrix(.Rows - 1, 5, 0)
            '                .set_TextMatrix(.Rows - 1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashDepositAmount")), 0, ds.Tables("MR").Rows(i).Item("CashDepositAmount")))


            '            ElseIf .get_TextMatrix(.Rows - 1, 4) = "CashWithdrawl" Then
            '                .set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashWithdrawlAmount")), 0, ds.Tables("MR").Rows(i).Item("CashWithdrawlAmount")))

            '                .set_TextMatrix(.Rows - 1, 6, 0)
            '            End If


            '        End With


            '    Next

            'End If

            da.Dispose()
            ds.Clear()




            Strquery = "SELECT PurchaseMaster.PurchaseNo, PurchaseMaster.PurchaseDate, PurchaseMaster.SupplierName1, PurchaseMaster.Cash,   PurchaseMaster.TotalValue, PurchaseMaster.Remarks FROM PurchaseMaster WHERE PurchaseMaster.Approve=1 and  PurchaseMaster.PurchaseDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and PurchaseMaster.PurchaseDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'  and ((PurchaseMaster.Cash)=1) order by PurchaseMaster.PurchaseNo"

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")
            If dgDetail.RowCount < 2 Then
                dgDetail.RowCount = 1
            End If

            If ds.Tables("MR").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To ds.Tables("MR").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PurchaseNo")), "", ds.Tables("MR").Rows(i).Item("PurchaseNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PurchaseDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PurchaseDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName1")), "", ds.Tables("MR").Rows(i).Item("SupplierName1"))
                        .Rows(i).Cells(4).Value = "Cash"
                        .Rows(i).Cells(5).Value = 0
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TotalValue")), 0, ds.Tables("MR").Rows(i).Item("TotalValue"))

                    Next
                    .RowCount = .RowCount - 1
                End With

            End If





            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")
            'If fgDetail.Rows < 2 Then
            '    fgDetail.Rows = 1
            'End If

            'If ds.Tables("MR").Rows.Count > 0 Then

            '    For i = 0 To ds.Tables("MR").Rows.Count - 1
            '        With fgDetail
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
            '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PurchaseNo")), "", ds.Tables("MR").Rows(i).Item("PurchaseNo")))
            '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PurchaseDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PurchaseDate"))))
            '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName1")), "", ds.Tables("MR").Rows(i).Item("SupplierName1")))


            '            .set_TextMatrix(.Rows - 1, 4, "Cash")

            '            .set_TextMatrix(.Rows - 1, 5, 0)
            '            .set_TextMatrix(.Rows - 1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TotalValue")), 0, ds.Tables("MR").Rows(i).Item("TotalValue")))


            '        End With


            '    Next

            'End If



            da.Dispose()
            ds.Clear()

            Strquery = "SELECT PaymentMaster.PaymentNo, PaymentMaster.PaymentDate, SupplierMaster1.SupplierName, PaymentMaster.Mode, PaymentMaster.CashAmount, PaymentMaster.Remarks FROM PaymentMaster INNER JOIN SupplierMaster1 ON PaymentMaster.SupplierCode = SupplierMaster1.SupplierCode WHERE PaymentMaster.Approve=1 and PaymentMaster.PaymentDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and PaymentMaster.PaymentDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'  and ((PaymentMaster.Mode)='Cash') order by PaymentMaster.PaymentNo"

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")
            If dgDetail.RowCount < 2 Then
                dgDetail.RowCount = 1
            End If

            If ds.Tables("MR").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To ds.Tables("MR").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PaymentNo")), "", ds.Tables("MR").Rows(i).Item("PaymentNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PaymentDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PaymentDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName")), "", ds.Tables("MR").Rows(i).Item("SupplierName"))
                        .Rows(i).Cells(4).Value = "Cash"
                        .Rows(i).Cells(5).Value = 0
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashAmount")), 0, ds.Tables("MR").Rows(i).Item("CashAmount"))

                    Next
                    .RowCount = .RowCount - 1
                End With

            End If






            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")
            'If fgDetail.Rows < 2 Then
            '    fgDetail.Rows = 1
            'End If

            'If ds.Tables("MR").Rows.Count > 0 Then

            '    For i = 0 To ds.Tables("MR").Rows.Count - 1
            '        With fgDetail
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
            '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PaymentNo")), "", ds.Tables("MR").Rows(i).Item("PaymentNo")))
            '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PaymentDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PaymentDate"))))
            '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName")), "", ds.Tables("MR").Rows(i).Item("SupplierName")))


            '            .set_TextMatrix(.Rows - 1, 4, "Cash")

            '            .set_TextMatrix(.Rows - 1, 5, 0)
            '            .set_TextMatrix(.Rows - 1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CashAmount")), 0, ds.Tables("MR").Rows(i).Item("CashAmount")))


            '        End With


            '    Next

            'End If

            da.Dispose()
            ds.Clear()



            Strquery = "SELECT JournalMaster.VoucherNo, JournalMaster.VoucherDate, JournalMaster.ReceivedBy, JournalMaster.Cash, JournalMaster.NetAmount FROM JournalMaster WHERE (((JournalMaster.Cash)=1)) and   JournalMaster.VoucherDate>= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and JournalMaster.VoucherDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'    order by JournalMaster.VoucherNo"

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")
            If dgDetail.RowCount < 2 Then
                dgDetail.RowCount = 1
            End If

            If ds.Tables("MR").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To ds.Tables("MR").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("VoucherNo")), "", ds.Tables("MR").Rows(i).Item("VoucherNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("VoucherDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("VoucherDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ReceivedBy")), "", ds.Tables("MR").Rows(i).Item("ReceivedBy"))
                        .Rows(i).Cells(4).Value = "Cash"
                        .Rows(i).Cells(5).Value = 0
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("NetAmount")), 0, ds.Tables("MR").Rows(i).Item("NetAmount"))

                    Next
                    .RowCount = .RowCount - 1
                End With

            End If





            'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            'da.Fill(ds, "MR")
            'If fgDetail.Rows < 2 Then
            '    fgDetail.Rows = 1
            'End If

            'If ds.Tables("MR").Rows.Count > 0 Then

            '    For i = 0 To ds.Tables("MR").Rows.Count - 1
            '        With fgDetail
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
            '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("VoucherNo")), "", ds.Tables("MR").Rows(i).Item("VoucherNo")))
            '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("VoucherDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("VoucherDate"))))
            '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ReceivedBy")), "", ds.Tables("MR").Rows(i).Item("ReceivedBy")))


            '            .set_TextMatrix(.Rows - 1, 4, "Cash")
            '            .set_TextMatrix(.Rows - 1, 5, 0)
            '            .set_TextMatrix(.Rows - 1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("NetAmount")), 0, ds.Tables("MR").Rows(i).Item("NetAmount")))



            '        End With


            '    Next

            'End If

            da.Dispose()
            ds.Clear()

            With dgDetail
                For i = 0 To .RowCount - 1
                    If i = 0 Then
                        If Val(.Rows(i).Cells(5).Value) > 0 Then
                            .Rows(i).Cells(7).Value = Val(.Rows(i).Cells(7).Value) + Val(.Rows(i).Cells(5).Value)
                        ElseIf Val(.Rows(i).Cells(6).Value) > 0 Then
                            .Rows(i).Cells(7).Value = Val(.Rows(i).Cells(7).Value) - Val(.Rows(i).Cells(6).Value)
                        End If
                    ElseIf i > 0 Then
                        If Val(.Rows(i).Cells(5).Value) > 0 Then
                            .Rows(i).Cells(7).Value = Val(.Rows(i - 1).Cells(7).Value) - Val(.Rows(i).Cells(5).Value)

                        ElseIf Val(.Rows(i).Cells(6).Value) > 0 Then
                            .Rows(i).Cells(7).Value = Val(.Rows(i - 1).Cells(7).Value) - Val(.Rows(i).Cells(6).Value)
                        End If
                    End If

                Next
            End With




            'With fgDetail
            '    For i = 1 To .Rows - 1
            '        If i = 1 Then
            '            If Val(.get_TextMatrix(i, 5)) > 0 Then
            '                .set_TextMatrix(i, 7, Val(.get_TextMatrix(i, 7)) + Val(.get_TextMatrix(i, 5)))
            '            ElseIf Val(.get_TextMatrix(i, 6)) > 0 Then
            '                .set_TextMatrix(i, 7, Val(.get_TextMatrix(i, 7)) - Val(.get_TextMatrix(i, 6)))
            '            End If
            '        ElseIf i > 1 Then
            '            If Val(.get_TextMatrix(i, 5)) > 0 Then
            '                .set_TextMatrix(i, 7, Val(.get_TextMatrix(i - 1, 7)) + Val(.get_TextMatrix(i, 5)))
            '            ElseIf Val(.get_TextMatrix(i, 6)) > 0 Then
            '                .set_TextMatrix(i, 7, Val(.get_TextMatrix(i - 1, 7)) - Val(.get_TextMatrix(i, 6)))
            '            End If
            '        End If

            '    Next
            'End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub frmDayBook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillGridInfo()
        dtpFromDate.Value = Now
        dtpToDate.Value = Now
    End Sub

    Private Sub cmdDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDisplay.Click
        FillGrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim fSalesReportViewer As New frmReportViewer
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        Dim strMRCode As String
        Dim Strquery As String
        Dim trn As SqlClient.SqlTransaction
        Dim cmdCom1 As SqlClient.SqlCommand


        fSalesReportViewer.MdiParent = MainForm
        fSalesReportViewer.Text = "Day Book Report"
        fSalesReportViewer.Refresh()
        fSalesReportViewer.Show()


        Me.Cursor = Cursors.WaitCursor
        Try


            Strquery = "Delete From temp_DayBook"

            trn = gl_Con.BeginTransaction
            cmdCom1 = New SqlClient.SqlCommand(Strquery, gl_Con)
            cmdCom1.CommandType = CommandType.Text
            cmdCom1.Transaction = trn
            cmdCom1.ExecuteNonQuery()
            trn.Commit()

            With dgDetail
                For i = 0 To .RowCount - 1
                    Strquery = "Insert into temp_DayBook(FromDate,Todate,ReceiptNo,Receiptdate,CustomerName,Mode,credit,debit,total ) values ('" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (.Rows(i).Cells(1).Value) & "','" & (.Rows(i).Cells(2).Value) & "','" & (.Rows(i).Cells(3).Value) & "','" & (.Rows(i).Cells(4).Value) & "','" & Val(.Rows(i).Cells(5).Value) & "','" & Val(.Rows(i).Cells(6).Value) & "','" & Val(.Rows(i).Cells(7).Value) & "')"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = Strquery
                    cmdCom1.ExecuteNonQuery()

                    trn.Commit()
                Next
            End With

            'For i = 1 To fgDetail.Rows - 1
            '    Strquery = "Insert into temp_DayBook(FromDate,Todate,ReceiptNo,Receiptdate,CustomerName,Mode,credit,debit,total ) values ('" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (fgDetail.get_TextMatrix(i, 1)) & "','" & (fgDetail.get_TextMatrix(i, 2)) & "','" & (fgDetail.get_TextMatrix(i, 3)) & "','" & (fgDetail.get_TextMatrix(i, 4)) & "','" & Val(fgDetail.get_TextMatrix(i, 5)) & "','" & Val(fgDetail.get_TextMatrix(i, 6)) & "','" & Val(fgDetail.get_TextMatrix(i, 7)) & "')"
            '    trn = gl_Con.BeginTransaction
            '    cmdCom1.Transaction = trn
            '    cmdCom1.Connection = gl_Con
            '    cmdCom1.CommandText = Strquery
            '    cmdCom1.ExecuteNonQuery()

            '    trn.Commit()


            'Next

            CrRepDoc.Load(Application.StartupPath & "\Report\rptDayBook.rpt")


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

    Private Sub fgDetail_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        With dgDetail
            If .RowCount >= 1 Then
                If dgDetail(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString = "PurchaseInvoice" Then
                    DisplayFormsOnClick("PI", dgDetail(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString)
                ElseIf dgDetail(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString = "SaleInvoice" Then
                    DisplayFormsOnClick("SI", dgDetail(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString)
                ElseIf dgDetail(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString = "PurchaseReturn" Then
                    DisplayFormsOnClick("PR", dgDetail(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString)
                ElseIf dgDetail(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString = "SaleReturn" Then
                    DisplayFormsOnClick("SR", dgDetail(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString)
                ElseIf dgDetail(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString = "TaxInvoice" Then
                    DisplayFormsOnClick("TAX", dgDetail(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString)
                End If
            End If
        End With

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