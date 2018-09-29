Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmReceiptSearch
    Dim CrRepDoc As New ReportDocument

    Private Sub FillGridInfo()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 7

            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "ReceiptN0"
            .Columns(1).Width = 90
            .Columns(2).Name = "Date"
            .Columns(2).Width = 90
            .Columns(3).Name = "Customer Name"
            .Columns(3).Width = 200
            .Columns(4).Name = "Mode"
            .Columns(4).Width = 120
            .Columns(5).Name = "Amount"
            .Columns(5).Width = 90
            .Columns(6).Name = "Remarks"
            .Columns(6).Width = 200


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
        '    .Cols = 7

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

        '    .set_TextMatrix(0, 5, "Amount")
        '    .set_ColWidth(5, 1500)


        '    .set_TextMatrix(0, 6, "Remarks")
        '    .set_ColWidth(6, 2500)
        'End With


    End Sub
    Private Sub FillGrid()

        Dim Strquery As String

        Dim da As New SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try

            Strquery = "SELECT ReceiptMaster.ReceiptNo, ReceiptMaster.ReceiptDate, CustomerMaster1.CustomerName, ReceiptMaster.Mode,ReceiptMaster.ReceiptAmount, ReceiptMaster.Remarks FROM ReceiptMaster INNER JOIN CustomerMaster1 ON ReceiptMaster.CustomerCode = CustomerMaster1.CustomerCode WHERE   ReceiptMaster.ReceiptDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and ReceiptMaster.ReceiptDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "' order by ReceiptMaster.ReceiptNo"


            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")
            dgDetail.RowCount = 1
            If ds.Tables("MR").Rows.Count > 0 Then

                For i = 0 To ds.Tables("MR").Rows.Count - 1
                    With dgDetail

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1


                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ReceiptNo")), "", ds.Tables("MR").Rows(i).Item("ReceiptNo"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("ReceiptDate"))), "", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("ReceiptDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("CustomerName")), "", ds.Tables("MR").Rows(i).Item("CustomerName"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Mode")), "", ds.Tables("MR").Rows(i).Item("Mode"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ReceiptAmount")), "", ds.Tables("MR").Rows(i).Item("ReceiptAmount"))

                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Remarks")), "", ds.Tables("MR").Rows(i).Item("Remarks"))
                    End With

                Next
                dgDetail.RowCount = dgDetail.RowCount - 1

            Else
                dgDetail.RowCount = 0
            End If
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
            '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("ReceiptAmount")), 0, ds.Tables("MR").Rows(i).Item("ReceiptAmount")))

            '            .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Remarks")), "", ds.Tables("MR").Rows(i).Item("Remarks")))

            '        End With

            '    Next



            da.Dispose()
            ds.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Private Sub frmReceiptSearch_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ReceiptSearch = Nothing
    End Sub

    Private Sub frmReceiptSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillGridInfo()
        dtpFromDate.Value = Now
        dtpToDate.Value = Now
    End Sub

    Private Sub cmdDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDisplay.Click
        FillGrid()
    End Sub

    Private Sub fgDetail_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'DisplayFormsOnClick("REC", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
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
        fSalesReportViewer.Text = "Receipt Search Report"
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

            'For i = 1 To fgDetail.Rows - 1
            '    Strquery = "Insert into Temp_SaleSearch(FromDate,Todate,CustomerName,TransactionNo,Transactiondate,Amount,TransactionType ) values ('" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (fgDetail.get_TextMatrix(i, 3)) & "','" & (fgDetail.get_TextMatrix(i, 1)) & "','" & (fgDetail.get_TextMatrix(i, 2)) & "','" & Val(fgDetail.get_TextMatrix(i, 5)) & "','" & (fgDetail.get_TextMatrix(i, 4)) & "')"
            '    trn = gl_Con.BeginTransaction
            '    cmdCom1.Transaction = trn
            '    cmdCom1.Connection = gl_Con
            '    cmdCom1.CommandText = Strquery
            '    cmdCom1.ExecuteNonQuery()

            '    trn.Commit()
            'Next
            For i = 0 To dgDetail.RowCount - 1
                Strquery = "Insert into Temp_SaleSearch(FromDate,Todate,CustomerName,TransactionNo,Transactiondate,Amount,TransactionType ) values ('" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (dgDetail.Rows(i).Cells(3).Value.ToString) & "','" & (dgDetail.Rows(i).Cells(1).Value.ToString) & "','" & (dgDetail.Rows(i).Cells(2).Value.ToString) & "','" & Val(dgDetail.Rows(i).Cells(5).Value) & "','" & (dgDetail.Rows(i).Cells(4).Value.ToString) & "')"
                trn = gl_Con.BeginTransaction
                cmdCom1.Transaction = trn
                cmdCom1.Connection = gl_Con
                cmdCom1.CommandText = Strquery
                cmdCom1.ExecuteNonQuery()

                trn.Commit()
            Next

            CrRepDoc.Load(Application.StartupPath & "\Report\rptReceiptSearch.rpt")


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
        DisplayFormsOnClick("REC", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
    End Sub
End Class