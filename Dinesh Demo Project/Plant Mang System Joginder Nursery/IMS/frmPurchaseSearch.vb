Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmPurchaseSearch
    Dim CrRepDoc As New ReportDocument
    Private Sub FillGridInfo()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Supplier Name"
            .Columns(1).Width = 150
            .Columns(2).Name = "TrnNo"
            .Columns(2).Width = 100
            .Columns(3).Name = "TransDate"
            .Columns(3).Width = 80
            .Columns(4).Name = "TotalValue"
            .Columns(4).Width = 80
            .Columns(5).Name = "TaxCode"
            .Columns(5).Width = 80
            .Columns(5).Visible = False
            .Columns(6).Name = "NetValue"
            .Columns(6).Width = 80
            .Columns(7).Name = "Invoice"
            .Columns(7).Width = 80
            .Columns(8).Name = "ChallanNo"
            .Columns(8).Width = 80
            .Columns(9).Name = "Remarks"
            .Columns(9).Width = 130

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
        '    .Cols = 10

        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "S.No")


        '    .set_TextMatrix(0, 1, "SupplierName")
        '    .set_ColWidth(1, 5000)

        '    .set_TextMatrix(0, 2, "TrnNo")
        '    .set_ColWidth(2, 1500)

        '    .set_TextMatrix(0, 3, "TrnDate")
        '    .set_ColWidth(3, 1500)

        '    .set_TextMatrix(0, 4, "TotalValue")
        '    .set_ColWidth(4, 1500)

        '    .set_TextMatrix(0, 5, "TaxCode")
        '    .set_ColWidth(5, 2000)
        '    .set_ColHidden(5, True)



        '    .set_TextMatrix(0, 6, "NetValue")
        '    .set_ColWidth(6, 1500)

        '    .set_TextMatrix(0, 7, "InvoiceNo")
        '    .set_ColWidth(7, 1500)

        '    .set_TextMatrix(0, 8, "ChallanNo")
        '    .set_ColWidth(8, 1500)


        '    .set_TextMatrix(0, 9, "Remarks")
        '    .set_ColWidth(9, 2000)
        'End With


    End Sub

    Private Sub frmPurchaseSearch_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        PurchaseSearch = Nothing
    End Sub

    Private Sub frmPurchaseSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillGridInfo()
        FillSupplier()
        dtpFromDate.Value = Now
        dtpToDate.Value = Now
    End Sub

    Private Sub FillSupplier()
        Dim strQuery As String
        Dim daConfig As SqlClient.SqlDataAdapter
        Dim dsConfig As New DataSet
        Dim i As Integer

        Try
            strQuery = "Select SupplierCode,SupplierName from SupplierMaster1 order by SupplierName"
            daConfig = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            daConfig.Fill(dsConfig, "Supplier")
            cboSupplierName.Items.Clear()

            If dsConfig.Tables("Supplier").Rows.Count > 0 Then
                For i = 0 To dsConfig.Tables("Supplier").Rows.Count - 1
                    If i = -1 Then

                        cboSupplierName.Text = "All Supplier"
                        cboSupplierName.Items.Add("ALL")
                    Else
                        'cboSupplierName.DataSource = Nothing
                        'cboSupplierName.DataSource = dsConfig.Tables("Supplier")
                        'cboSupplierName.ValueMember = "SupplierCode"
                        'cboSupplierName.DisplayMember = "SupplierName"
                        cboSupplierName.Items.Add(dsConfig.Tables("Supplier").Rows(i).Item("SupplierName"))
                    End If
                Next

            End If
            cboSupplierName.Text = "ALL"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisplay.Click
        Dim Strquery As String
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim i As Integer
        If cboSupplierName.Text = "" Then
            MsgBox("Please Select a supplier name")
            Exit Sub
        End If

        If cboSupplierName.Text = "ALL" Then
            Strquery = "SELECT PurchaseMaster.PurchaseNo, PurchaseMaster.PurchaseDate, PurchaseMaster.InvoiceNo, PurchaseMaster.ChallanNo, SupplierMaster1.SupplierName, PurchaseMaster.NetValue, PurchaseMaster.Totalvalue,PurchaseMaster.ConfigurationCode, PurchaseMaster.Remarks, PurchaseMaster.Cash, PurchaseMaster.SupplierName1 FROM PurchaseMaster LEFT JOIN SupplierMaster1 ON PurchaseMaster.SupplierCode = SupplierMaster1.SupplierCode  WHERE     PurchaseMaster.PurchaseDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and PurchaseMaster.PurchaseDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "' "
        Else
            Strquery = "SELECT PurchaseMaster.PurchaseNo, PurchaseMaster.PurchaseDate, PurchaseMaster.InvoiceNo, PurchaseMaster.ChallanNo, SupplierMaster1.SupplierName, PurchaseMaster.NetValue, PurchaseMaster.Totalvalue,PurchaseMaster.ConfigurationCode, PurchaseMaster.Remarks, PurchaseMaster.Cash, PurchaseMaster.SupplierName1 FROM PurchaseMaster LEFT JOIN SupplierMaster1 ON PurchaseMaster.SupplierCode = SupplierMaster1.SupplierCode  WHERE     PurchaseMaster.PurchaseDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and PurchaseMaster.PurchaseDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'  and (SupplierMaster1.SupplierName='" & cboSupplierName.Text & "')"

        End If
        da = New SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "MR")
        dgDetail.RowCount = 1
        If ds.Tables("MR").Rows.Count > 0 Then
            With dgDetail
                For i = 0 To ds.Tables("MR").Rows.Count - 1

                    .RowCount = .RowCount + 1
                    .Rows(i).Cells(0).Value = i + 1
                    If ds.Tables("MR").Rows(i).Item("Cash") = 1 Then

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName1")), "", ds.Tables("MR").Rows(i).Item("SupplierName1"))
                    Else
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName")), "", ds.Tables("MR").Rows(i).Item("SupplierName"))
                    End If
                    .Rows(i).Cells(2).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PurchaseNo")), "", ds.Tables("MR").Rows(i).Item("PurchaseNo"))

                    .Rows(i).Cells(3).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PurchaseDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("PurchaseDate")))
                    .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("NetValue")), 0, ds.Tables("MR").Rows(i).Item("NetValue"))
                    .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ConfigurationCode")), 0, ds.Tables("MR").Rows(i).Item("ConfigurationCode"))
                    .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Totalvalue")), "", ds.Tables("MR").Rows(i).Item("Totalvalue"))
                    .Rows(i).Cells(7).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo"))
                    .Rows(i).Cells(8).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), 8, ds.Tables("MR").Rows(i).Item("ChallanNo"))
                    .Rows(i).Cells(9).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Remarks")), 9, ds.Tables("MR").Rows(i).Item("Remarks"))
                
                Next
                .RowCount = .RowCount - 1
            End With
        Else
            dgDetail.RowCount = 0
        End If

        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "MR")

        'fgDetail.Rows = 1
        'If ds.Tables("MR").Rows.Count > 0 Then
        '    For i = 0 To ds.Tables("MR").Rows.Count - 1
        '        With fgDetail
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            If ds.Tables("MR").Rows(i).Item("Cash") = 1 Then

        '                .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName1")), "", ds.Tables("MR").Rows(i).Item("SupplierName1")))
        '            Else

        '                .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SupplierName")), "", ds.Tables("MR").Rows(i).Item("SupplierName")))
        '            End If



        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PurchaseNo")), "", ds.Tables("MR").Rows(i).Item("PurchaseNo")))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("PurchaseDate")), "", ds.Tables("MR").Rows(i).Item("PurchaseDate")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("NetValue")), 0, ds.Tables("MR").Rows(i).Item("NetValue")))
        '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ConfigurationCode")), 0, ds.Tables("MR").Rows(i).Item("ConfigurationCode")))
        '            .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Totalvalue")), "", ds.Tables("MR").Rows(i).Item("Totalvalue")))

        '            .set_TextMatrix(i + 1, 7, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("InvoiceNo")), "", ds.Tables("MR").Rows(i).Item("InvoiceNo")))
        '            .set_TextMatrix(i + 1, 8, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ChallanNo")), 0, ds.Tables("MR").Rows(i).Item("ChallanNo")))
        '            .set_TextMatrix(i + 1, 9, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Remarks")), 0, ds.Tables("MR").Rows(i).Item("Remarks")))

        '        End With
        '    Next

        'End If

    End Sub

    Private Sub fgDetail_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)

        'DisplayFormsOnClick("PI", fgDetail.get_TextMatrix(fgDetail.RowSel, 2))

    End Sub

    Private Sub cboSupplierName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSupplierName.Click
        FillSupplier()
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
        fSalesReportViewer.Text = "Purchase Search Report"
        fSalesReportViewer.Refresh()
        fSalesReportViewer.Show()


        Me.Cursor = Cursors.WaitCursor
        Try


            Strquery = "Delete From Temp_SaleSearch"

            trn = gl_Con.BeginTransaction
            cmdCom1 = New SqlClient.SqlCommand(Strquery, gl_Con)
            cmdCom1.CommandType = CommandType.Text
            cmdCom1.Transaction = trn
            cmdCom1.ExecuteNonQuery()
            trn.Commit()

            With dgDetail
                For i = 0 To .RowCount - 1
                    Strquery = "Insert into Temp_SaleSearch(FromDate,Todate,CustomerName,TransactionNo,Transactiondate,Amount,NetAmount ) values ('" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (.Rows(i).Cells(1).Value) & "','" & (.Rows(i).Cells(2).Value) & "','" & (.Rows(i).Cells(3).Value) & "','" & Val(.Rows(i).Cells(4).Value) & "','" & Val(.Rows(i).Cells(6).Value) & "')"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = Strquery
                    cmdCom1.ExecuteNonQuery()

                    trn.Commit()

                Next
            End With

            'For i = 1 To fgDetail.Rows - 1
            '    Strquery = "Insert into Temp_SaleSearch(FromDate,Todate,CustomerName,TransactionNo,Transactiondate,Amount,NetAmount ) values ('" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (fgDetail.get_TextMatrix(i, 1)) & "','" & (fgDetail.get_TextMatrix(i, 2)) & "','" & (fgDetail.get_TextMatrix(i, 3)) & "','" & Val(fgDetail.get_TextMatrix(i, 4)) & "','" & Val(fgDetail.get_TextMatrix(i, 6)) & "')"
            '    trn = gl_Con.BeginTransaction
            '    cmdCom1.Transaction = trn
            '    cmdCom1.Connection = gl_Con
            '    cmdCom1.CommandText = Strquery
            '    cmdCom1.ExecuteNonQuery()

            '    trn.Commit()
            'Next

            CrRepDoc.Load(Application.StartupPath & "\Report\rptPurchaseSearch.rpt")


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

    Private Sub dgDetail_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetail.DoubleClick
        If dgDetail.RowCount >= 1 Then
            DisplayFormsOnClick("PI", dgDetail(2, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
        End If
    End Sub
End Class