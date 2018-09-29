Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmAccountGroupReport
    Dim CrRepDoc As New ReportDocument
    Dim intDGSearchKeayPress As Integer

    Dim da_search As New SqlDataAdapter
    Dim ds_search As New DataSet
    Private Sub FillGridInfo()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 12
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "LedgerCode"
            .Columns(1).Width = 100
            .Columns(1).Visible = False
            .Columns(2).Name = "TrnNo"
            .Columns(2).Width = 100
            .Columns(3).Name = "TrnDate"
            .Columns(3).Width = 80
            .Columns(4).Name = "Opening"
            .Columns(4).Width = 100
            .Columns(5).Name = "Opening"
            .Columns(5).Width = 100
            .Columns(5).Visible = False
            .Columns(6).Name = "Debit"
            .Columns(6).Width = 100
            .Columns(7).Name = "Credit"
            .Columns(7).Width = 100
            .Columns(8).Name = "Total"
            .Columns(8).Width = 100
            .Columns(8).Visible = False
            .Columns(9).Name = "Total"
            .Columns(9).Width = 100
            .Columns(10).Name = "DB/CR"
            .Columns(10).Width = 80
            .Columns(11).Name = "Narration"
            .Columns(11).Width = 130


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
        '    .Editable = VSFlex7L.EditableSettings.flexEDNone
        '    '.ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow

        '    .Rows = 1
        '    .Cols = 12

        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "S.No")


        '    .set_TextMatrix(0, 1, "LedgerCode")
        '    .set_ColWidth(1, 1500)
        '    .set_ColHidden(1, True)

        '    .set_TextMatrix(0, 2, "TrnNo")
        '    .set_ColWidth(2, 1500)

        '    .set_TextMatrix(0, 3, "TrnDate")
        '    .set_ColWidth(3, 1500)

        '    .set_TextMatrix(0, 4, "Opening")
        '    .set_ColWidth(4, 1500)
        '    .set_ColHidden(5, True)


        '    .set_TextMatrix(0, 5, "Opening")
        '    .set_ColWidth(5, 1200)

        '    .set_TextMatrix(0, 6, "Debit")
        '    .set_ColWidth(6, 1200)

        '    .set_TextMatrix(0, 7, "Credit")
        '    .set_ColWidth(7, 1200)

        '    .set_TextMatrix(0, 8, "Total")
        '    .set_ColWidth(8, 1200)
        '    .set_ColHidden(8, True)


        '    .set_TextMatrix(0, 9, "Total")
        '    .set_ColWidth(9, 1200)

        '    .set_TextMatrix(0, 10, "DB/CR")
        '    .set_ColWidth(10, 800)

        '    .set_TextMatrix(0, 11, "Narration")
        '    .set_ColWidth(11, 2500)


        'End With


    End Sub
    Private Sub cmdDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisplay.Click
        Dim Strquery As String
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter
        Dim Opening As Decimal
        Dim ds As New DataSet
        Dim i As Integer

        If txtLedgerName.Text = "" Then
            MsgBox("Please Select a Ledger First")
            Exit Sub
        End If
        Try


            Strquery = "SELECT (Sum(LedgerMaster.OpeningBalance)) AS opening FROM LedgerMaster where (LedgerMaster.LedgerCode='" & cboCustomerName.Text & "') "

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            dgDetail.RowCount = 1
            If ds.Tables("MR").Rows.Count > 0 Then
                Opening = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("opening")), 0, ds.Tables("MR").Rows(i).Item("opening"))
            End If
            da.Dispose()
            ds.Clear()


            Strquery = "SELECT (Sum(Ledger.Debit)-Sum(Ledger.Credit)) AS opening FROM Ledger  WHERE     Ledger.TransactionDate < '" & convertToServerDateFormat(dtpFromDate.Value) & "'   and (Ledger.LedgerCode='" & cboCustomerName.Text & "')"
            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            dgDetail.RowCount = 1
            If ds.Tables("MR").Rows.Count > 0 Then

                With dgDetail
                    .RowCount = .RowCount + 1
                    .Rows(0).Cells(0).Value = 1
                    .Rows(0).Cells(1).Value = txtLedgerName.Text
                    .Rows(0).Cells(2).Value = "Opening"
                    .Rows(0).Cells(3).Value = convertToServerDateFormat(dtpFromDate.Value)
                    .Rows(0).Cells(4).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("opening")), 0, ds.Tables("MR").Rows(i).Item("opening"))

                    .Rows(0).Cells(4).Value = .Rows(0).Cells(4).Value + Opening
                    Opening = 0
                    If Val(.Rows(0).Cells(4).Value) < 0 Then
                        .Rows(0).Cells(5).Value = 0 - Val(.Rows(0).Cells(4).Value)
                    Else
                        .Rows(0).Cells(5).Value = Val(.Rows(0).Cells(4).Value)
                    End If

                    '.set_TextMatrix(1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SumOfDebit")), 0, ds.Tables("MR").Rows(i).Item("SumOfDebit")))
                    '.set_TextMatrix(1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SumOfCredit")), 0, ds.Tables("MR").Rows(i).Item("SumOfCredit")))

                    .Rows(0).Cells(11).Value = ""

                End With

            Else
                With dgDetail
                    .RowCount = .RowCount + 1
                    .Rows(0).Cells(0).Value = 1
                    .Rows(0).Cells(1).Value = txtLedgerName.Text
                    .Rows(0).Cells(2).Value = "Opening"
                    .Rows(0).Cells(3).Value = (convertToServerDateFormat(dtpFromDate.Value))
                    .Rows(0).Cells(4).Value = 0
                    .Rows(0).Cells(5).Value = 0
                    .Rows(0).Cells(6).Value = 0
                    .Rows(0).Cells(7).Value = 0
                    .Rows(0).Cells(8).Value = 0
                    .Rows(0).Cells(9).Value = 0
                    .Rows(0).Cells(11).Value = ""


                End With
            End If
            da.Dispose()
            ds.Clear()




            Strquery = "SELECT Sum(Ledger.Debit) AS SumOfDebit, Sum(Ledger.Credit) AS SumOfCredit FROM Ledger WHERE     Ledger.TransactionDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and Ledger.TransactionDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'  and (Ledger.LedgerCode='" & cboCustomerName.Text & "')"
            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")

            If ds.Tables("MR").Rows.Count > 0 Then

                With dgDetail
                    .Rows(0).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SumOfDebit")), 0, ds.Tables("MR").Rows(i).Item("SumOfDebit"))
                    .Rows(0).Cells(7).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SumOfCredit")), 0, ds.Tables("MR").Rows(i).Item("SumOfCredit"))

                    .Rows(0).Cells(8).Value = Val(.Rows(0).Cells(4).Value) + Val(.Rows(0).Cells(6).Value) - Val(.Rows(0).Cells(7).Value)
                    If Val(.Rows(0).Cells(8).Value) < 0 Then

                        .Rows(0).Cells(9).Value = 0 - Val(.Rows(0).Cells(8).Value)
                        .Rows(0).Cells(10).Value = "CR"

                    Else
                        .Rows(0).Cells(9).Value = Val(.Rows(0).Cells(8).Value)
                        .Rows(0).Cells(10).Value = "DB"
                    End If

                End With
            End If
            da.Dispose()
            ds.Clear()




            Strquery = "SELECT Ledger.TransactionNo, Ledger.TransactionDate, Ledger.LedgerCode, Ledger.TransactionType, Ledger.Debit, Ledger.Credit, Ledger.Narration FROM Ledger WHERE     Ledger.TransactionDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and Ledger.TransactionDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'  and (Ledger.LedgerCode='" & cboCustomerName.Text & "') order by Ledger.TransactionDate"



            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "MR")
            Dim ledgercode As String
            If ds.Tables("MR").Rows.Count > 0 Then
                For i = 0 To ds.Tables("MR").Rows.Count - 1
                    ledgercode = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("LedgerCode")), "", ds.Tables("MR").Rows(i).Item("LedgerCode"))
                    If ledgercode <> "" Then
                        With dgDetail
                            .RowCount = .RowCount + 1
                            .Rows(i + 1).Cells(0).Value = i + 1
                            .Rows(i + 1).Cells(1).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("LedgerCode")), "", ds.Tables("MR").Rows(i).Item("LedgerCode"))
                            .Rows(i + 1).Cells(2).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionNo")), "", ds.Tables("MR").Rows(i).Item("TransactionNo"))
                            .Rows(i + 1).Cells(3).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate"))), "01/01/1900", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate")))

                            If i = 0 Then
                                .Rows(i + 1).Cells(4).Value = .Rows(i).Cells(4).Value
                                If Val(.Rows(i + 1).Cells(4).Value) < 0 Then
                                    .Rows(i + 1).Cells(5).Value = 0 - Val(.Rows(i + 1).Cells(4).Value)
                                Else
                                    .Rows(i + 1).Cells(5).Value = Val(.Rows(i).Cells(4).Value)
                                End If

                            Else
                                .Rows(i + 1).Cells(4).Value = .Rows(i).Cells(8).Value
                                If Val(.Rows(i + 1).Cells(4).Value) < 0 Then
                                    .Rows(i + 1).Cells(5).Value = 0 - Val(.Rows(i + 1).Cells(4).Value)
                                Else
                                    .Rows(i + 1).Cells(5).Value = .Rows(i).Cells(8).Value
                                End If
                            End If

                            .Rows(i + 1).Cells(6).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Debit")), 0, ds.Tables("MR").Rows(i).Item("Debit"))
                            .Rows(i + 1).Cells(7).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Credit")), 0, ds.Tables("MR").Rows(i).Item("Credit"))

                            .Rows(i + 1).Cells(8).Value = Val(.Rows(i + 1).Cells(4).Value) + Val(.Rows(i + 1).Cells(6).Value) - Val(.Rows(i + 1).Cells(7).Value)
                            If Val(.Rows(i + 1).Cells(8).Value) < 0 Then

                                .Rows(i + 1).Cells(9).Value = 0 - Val(.Rows(i + 1).Cells(8).Value)
                                .Rows(i + 1).Cells(10).Value = "CR"
                            Else
                                .Rows(i + 1).Cells(9).Value = Val(.Rows(i + 1).Cells(8).Value)
                                .Rows(i + 1).Cells(10).Value = "DB"
                            End If

                            .Rows(i + 1).Cells(11).Value = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Narration")), "", ds.Tables("MR").Rows(i).Item("Narration"))



                        End With
                    End If

                Next
                dgDetail.RowCount = dgDetail.RowCount - 1
            Else
                dgDetail.RowCount = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Strquery = "SELECT (Sum(LedgerMaster.OpeningBalance)) AS opening FROM LedgerMaster where (LedgerMaster.LedgerCode='" & cboCustomerName.Text & "') "

        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "MR")

        ''fgDetail.Rows = 1
        'If ds.Tables("MR").Rows.Count > 0 Then
        '    Opening = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("opening")), 0, ds.Tables("MR").Rows(i).Item("opening"))
        'End If
        'da.Dispose()
        'ds.Clear()


        'Strquery = "SELECT (Sum(Ledger.Debit)-Sum(Ledger.Credit)) AS opening FROM Ledger  WHERE     Ledger.TransactionDate < '" & convertToServerDateFormat(dtpFromDate.Value) & "'   and (Ledger.LedgerCode='" & cboCustomerName.Text & "')"
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "MR")

        'fgDetail.Rows = 1
        'If ds.Tables("MR").Rows.Count > 0 Then

        '    With fgDetail
        '        .Rows = .Rows + 1
        '        .set_TextMatrix(1, 0, 1)
        '        .set_TextMatrix(1, 1, txtLedgerName.Text)
        '        .set_TextMatrix(1, 2, "Opening")
        '        .set_TextMatrix(1, 3, convertToServerDateFormat(dtpFromDate.Value))
        '        .set_TextMatrix(1, 4, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("opening")), 0, ds.Tables("MR").Rows(i).Item("opening")))

        '        .set_TextMatrix(1, 4, Val(.get_TextMatrix(1, 4)) + Opening)
        '        Opening = 0
        '        If Val(.get_TextMatrix(1, 4)) < 0 Then
        '            .set_TextMatrix(1, 5, (0 - Val(.get_TextMatrix(1, 4))))
        '        Else
        '            .set_TextMatrix(1, 5, Val(.get_TextMatrix(1, 4)))
        '        End If

        '        '.set_TextMatrix(1, 5, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SumOfDebit")), 0, ds.Tables("MR").Rows(i).Item("SumOfDebit")))
        '        '.set_TextMatrix(1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SumOfCredit")), 0, ds.Tables("MR").Rows(i).Item("SumOfCredit")))

        '        .set_TextMatrix(1, 11, "")

        '    End With

        'Else
        '    With fgDetail
        '        .Rows = .Rows + 1
        '        .set_TextMatrix(1, 0, 1)
        '        .set_TextMatrix(1, 1, txtLedgerName.Text)
        '        .set_TextMatrix(1, 2, "Opening")
        '        .set_TextMatrix(1, 3, convertToServerDateFormat(dtpFromDate.Value))
        '        .set_TextMatrix(1, 4, 0)
        '        .set_TextMatrix(1, 5, 0)
        '        .set_TextMatrix(1, 6, 0)
        '        .set_TextMatrix(1, 7, 0)
        '        .set_TextMatrix(1, 8, 0)
        '        .set_TextMatrix(1, 9, 0)
        '        .set_TextMatrix(1, 11, "")





        '    End With
        'End If
        'da.Dispose()
        'ds.Clear()




        'Strquery = "SELECT Sum(Ledger.Debit) AS SumOfDebit, Sum(Ledger.Credit) AS SumOfCredit FROM Ledger WHERE     Ledger.TransactionDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and Ledger.TransactionDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'  and (Ledger.LedgerCode='" & cboCustomerName.Text & "')"
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "MR")

        'If ds.Tables("MR").Rows.Count > 0 Then

        '    With fgDetail
        '        .set_TextMatrix(1, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SumOfDebit")), 0, ds.Tables("MR").Rows(i).Item("SumOfDebit")))
        '        .set_TextMatrix(1, 7, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("SumOfCredit")), 0, ds.Tables("MR").Rows(i).Item("SumOfCredit")))

        '        .set_TextMatrix(1, 8, Val(.get_TextMatrix(1, 4)) + Val(.get_TextMatrix(1, 6)) - Val(.get_TextMatrix(1, 7)))
        '        If Val(.get_TextMatrix(1, 8)) < 0 Then

        '            .set_TextMatrix(1, 9, (0 - Val(.get_TextMatrix(1, 8))))
        '            .set_TextMatrix(1, 10, "CR")

        '        Else
        '            .set_TextMatrix(1, 9, Val(.get_TextMatrix(1, 8)))
        '            .set_TextMatrix(1, 10, "DB")

        '        End If

        '    End With
        'End If
        'da.Dispose()
        'ds.Clear()




        'Strquery = "SELECT Ledger.TransactionNo, Ledger.TransactionDate, Ledger.LedgerCode, Ledger.TransactionType, Ledger.Debit, Ledger.Credit, Ledger.Narration FROM Ledger WHERE     Ledger.TransactionDate >= '" & convertToServerDateFormat(dtpFromDate.Value) & "'  and Ledger.TransactionDate <= '" & convertToServerDateFormat(dtpToDate.Value) & "'  and (Ledger.LedgerCode='" & cboCustomerName.Text & "') order by Ledger.TransactionDate"



        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "MR")

        'Dim ledgercode As String
        'If ds.Tables("MR").Rows.Count > 0 Then
        '    For i = 0 To ds.Tables("MR").Rows.Count - 1
        '        ledgercode = IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("LedgerCode")), "", ds.Tables("MR").Rows(i).Item("LedgerCode"))
        '        If ledgercode <> "" Then
        '            With fgDetail
        '                .Rows = .Rows + 1
        '                .set_TextMatrix(i + 2, 0, i + 2)
        '                .set_TextMatrix(i + 2, 1, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("LedgerCode")), "", ds.Tables("MR").Rows(i).Item("LedgerCode")))
        '                .set_TextMatrix(i + 2, 2, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("TransactionNo")), "", ds.Tables("MR").Rows(i).Item("TransactionNo")))
        '                .set_TextMatrix(i + 2, 3, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate"))), "01/01/1900", convertToServerDateFormat(ds.Tables("MR").Rows(i).Item("TransactionDate"))))

        '                If i = 0 Then
        '                    .set_TextMatrix(i + 2, 4, .get_TextMatrix(i + 1, 4))
        '                    If Val(.get_TextMatrix(i + 2, 4)) < 0 Then
        '                        .set_TextMatrix(i + 2, 5, (0 - Val(.get_TextMatrix(i + 2, 4))))
        '                    Else
        '                        .set_TextMatrix(i + 2, 5, .get_TextMatrix(i + 1, 4))
        '                    End If

        '                Else
        '                    .set_TextMatrix(i + 2, 4, .get_TextMatrix(i + 1, 8))
        '                    If Val(.get_TextMatrix(i + 2, 4)) < 0 Then
        '                        .set_TextMatrix(i + 2, 5, (0 - Val(.get_TextMatrix(i + 2, 4))))
        '                    Else
        '                        .set_TextMatrix(i + 2, 5, .get_TextMatrix(i + 1, 8))
        '                    End If
        '                End If

        '                .set_TextMatrix(i + 2, 6, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Debit")), 0, ds.Tables("MR").Rows(i).Item("Debit")))
        '                .set_TextMatrix(i + 2, 7, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Credit")), 0, ds.Tables("MR").Rows(i).Item("Credit")))

        '                .set_TextMatrix(i + 2, 8, Val(.get_TextMatrix(i + 2, 4)) + Val(.get_TextMatrix(i + 2, 6)) - Val(.get_TextMatrix(i + 2, 7)))
        '                If Val(.get_TextMatrix(i + 2, 8)) < 0 Then

        '                    .set_TextMatrix(i + 2, 9, (0 - Val(.get_TextMatrix(i + 2, 8))))
        '                    .set_TextMatrix(i + 2, 10, "CR")
        '                Else
        '                    .set_TextMatrix(i + 2, 9, Val(.get_TextMatrix(i + 2, 8)))
        '                    .set_TextMatrix(i + 2, 10, "DB")
        '                End If







        '                .set_TextMatrix(i + 2, 11, IIf(IsDBNull(ds.Tables("MR").Rows(i).Item("Narration")), "", ds.Tables("MR").Rows(i).Item("Narration")))



        '            End With
        '        End If

        '    Next

        'End If
    End Sub

    Private Sub frmAccountGroupReport_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        AccountGroupLedgerReport = Nothing
    End Sub



    Private Sub frmAccountGroupReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillGridInfo()

        dtpFromDate.Value = Now
        dtpToDate.Value = Now
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        gbSearch.BringToFront()
        FillSearchGridInfo()
        FillGridItem()
        txtSearch.Text = ""
        txtSearch.Focus()

    End Sub
    Private Sub FillSearchGridInfo()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 3
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 50
            .Columns(1).Name = "Ledger Code"
            .Columns(1).Width = 120
            .Columns(2).Name = "Ledger Name"
            .Columns(2).Width = 200
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
        '    .Cols = 3
        '    '.Width = 678
        '    '.Height = 193
        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "S.No")


        '    .set_TextMatrix(0, 1, "LedgerCode")
        '    .set_ColWidth(1, 2000)
        '    .set_TextMatrix(0, 2, "LedgerName")
        '    .set_ColWidth(2, 5000)

        'End With


    End Sub
    Private Sub FillGridItem()
        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim f_daDept As New SqlClient.SqlDataAdapter
        Dim f_dsDept As New DataSet
        Dim StrQuery As String

        Dim str As String

        Me.Cursor = Cursors.WaitCursor
        dgSearch.RowCount = 1

        Try

            StrQuery = "SELECT distinct LedgerCode FROM Ledger order by LedgerCode"


            f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            f_dsDept.Clear()
            f_daDept.Fill(f_dsDept, "ItemList")
            If f_dsDept.Tables("ItemList").Rows.Count > 0 Then
                For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
                    drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
                    With dgSearch
                        .RowCount = .RowCount + 1
                        .Rows(iRow).Cells(0).Value = iRow + 1
                        .Rows(iRow).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("LedgerCode")), "", drDisplay.Item("LedgerCode"))

                        str = "SELECT DISTINCT Ledger.LedgerCode, CustomerMaster1.CustomerName FROM Ledger LEFT JOIN CustomerMaster1 ON Ledger.LedgerCode = CustomerMaster1.CustomerCode where Ledger.LedgerCode='" & Trim(.Rows(iRow).Cells(1).Value.ToString) & "' and Ledger.LedgerCode like 'CUS%'  ORDER BY CustomerMaster1.CustomerName"
                        da_search = New SqlClient.SqlDataAdapter(str, gl_Con)
                        ds_search.Clear()
                        da_search.Fill(ds_search, "Customer")

                        If ds_search.Tables("Customer").Rows.Count > 0 Then
                            .Rows(iRow).Cells(2).Value = IIf(IsDBNull(ds_search.Tables("Customer").Rows(0).Item("CustomerName")), "", ds_search.Tables("Customer").Rows(0).Item("CustomerName"))
                        End If
                        da_search.Dispose()
                        ds_search.Clear()

                        str = "SELECT DISTINCT Ledger.LedgerCode, SupplierMaster1.SupplierName FROM Ledger LEFT JOIN SupplierMaster1 ON Ledger.LedgerCode = SupplierMaster1.SupplierCode where Ledger.LedgerCode='" & Trim(.Rows(iRow).Cells(1).Value.ToString) & "' and Ledger.LedgerCode like 'SUP%'  ORDER BY SupplierMaster1.SupplierName"
                        da_search = New SqlClient.SqlDataAdapter(str, gl_Con)
                        ds_search.Clear()
                        da_search.Fill(ds_search, "Supplier")

                        If ds_search.Tables("Supplier").Rows.Count > 0 Then
                            .Rows(iRow).Cells(2).Value = IIf(IsDBNull(ds_search.Tables("Supplier").Rows(0).Item("SupplierName")), "", ds_search.Tables("Supplier").Rows(0).Item("SupplierName"))
                        End If
                        da_search.Dispose()
                        ds_search.Clear()

                        str = "SELECT DISTINCT Ledger.LedgerCode, BankMaster.BankName FROM Ledger INNER JOIN BankMaster ON Ledger.LedgerCode = BankMaster.AccCode where Ledger.LedgerCode='" & Trim(.Rows(iRow).Cells(1).Value.ToString) & "' and Ledger.LedgerCode like 'BANK%'  ORDER BY BankMaster.BankName"
                        da_search = New SqlClient.SqlDataAdapter(str, gl_Con)
                        ds_search.Clear()
                        da_search.Fill(ds_search, "Bank")

                        If ds_search.Tables("Bank").Rows.Count > 0 Then
                            .Rows(iRow).Cells(2).Value = IIf(IsDBNull(ds_search.Tables("Bank").Rows(0).Item("BankName")), "", ds_search.Tables("Bank").Rows(0).Item("BankName"))
                        End If
                        da_search.Dispose()
                        ds_search.Clear()

                        If .Rows(iRow).Cells(2).Value = "" Then
                            .Rows(iRow).Cells(2).Value = .Rows(iRow).Cells(1).Value.ToString
                        End If


                    End With
                Next
                dgSearch.RowCount = dgSearch.RowCount - 1
            Else
                dgSearch.RowCount = 0
            End If


        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default


        'Dim iRow As Integer
        'Dim drDisplay As DataRow
        'Dim f_daDept As SqlClient.SqlDataAdapter
        'Dim f_dsDept As New DataSet
        'Dim StrQuery As String

        'Dim str As String
        'Dim da As SqlClient.SqlDataAdapter
        'Dim ds As New DataSet

        'Me.Cursor = Cursors.WaitCursor
        'With fgSearch
        '    .Rows = 1
        'End With

        'Try

        '    StrQuery = "SELECT distinct LedgerCode FROM Ledger order by LedgerCode"


        '    f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
        '    f_dsDept.Clear()
        '    f_daDept.Fill(f_dsDept, "ItemList")
        '    For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
        '        drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
        '        With fgSearch
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
        '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("LedgerCode")), "", drDisplay.Item("LedgerCode")))




        '            str = "SELECT DISTINCT Ledger.LedgerCode, CustomerMaster1.CustomerName FROM Ledger LEFT JOIN CustomerMaster1 ON Ledger.LedgerCode = CustomerMaster1.CustomerCode where Ledger.LedgerCode='" & .get_TextMatrix(.Rows - 1, 1) & "' and Ledger.LedgerCode like 'CUS%'  ORDER BY CustomerMaster1.CustomerName"
        '            da = New SqlClient.SqlDataAdapter(str, gl_Con)
        '            ds.Clear()
        '            da.Fill(ds, "Customer")

        '            If ds.Tables("Customer").Rows.Count > 0 Then
        '                .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(ds.Tables("Customer").Rows(0).Item("CustomerName")), "", ds.Tables("Customer").Rows(0).Item("CustomerName")))
        '            End If
        '            da.Dispose()
        '            ds.Clear()

        '            str = "SELECT DISTINCT Ledger.LedgerCode, SupplierMaster1.SupplierName FROM Ledger LEFT JOIN SupplierMaster1 ON Ledger.LedgerCode = SupplierMaster1.SupplierCode where Ledger.LedgerCode='" & .get_TextMatrix(.Rows - 1, 1) & "' and Ledger.LedgerCode like 'SUP%'  ORDER BY SupplierMaster1.SupplierName"
        '            da = New SqlClient.SqlDataAdapter(str, gl_Con)
        '            ds.Clear()
        '            da.Fill(ds, "Supplier")

        '            If ds.Tables("Supplier").Rows.Count > 0 Then
        '                .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(ds.Tables("Supplier").Rows(0).Item("SupplierName")), "", ds.Tables("Supplier").Rows(0).Item("SupplierName")))
        '            End If
        '            da.Dispose()
        '            ds.Clear()

        '            str = "SELECT DISTINCT Ledger.LedgerCode, BankMaster.BankName FROM Ledger INNER JOIN BankMaster ON Ledger.LedgerCode = BankMaster.AccCode where Ledger.LedgerCode='" & .get_TextMatrix(.Rows - 1, 1) & "' and Ledger.LedgerCode like 'BANK%'  ORDER BY BankMaster.BankName"
        '            da = New SqlClient.SqlDataAdapter(str, gl_Con)
        '            ds.Clear()
        '            da.Fill(ds, "Bank")

        '            If ds.Tables("Bank").Rows.Count > 0 Then
        '                .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(ds.Tables("Bank").Rows(0).Item("BankName")), "", ds.Tables("Bank").Rows(0).Item("BankName")))
        '            End If
        '            da.Dispose()
        '            ds.Clear()

        '            If .get_TextMatrix(.Rows - 1, 2) = "" Then
        '                .set_TextMatrix(.Rows - 1, 2, .get_TextMatrix(.Rows - 1, 1))
        '            End If


        '        End With
        '    Next



        'Catch ex As Exception

        '    MsgBox(ex.Message)
        'End Try
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub fgSearch_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'txtLedgerName.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 2)
        'cboCustomerName.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
        'gbSearch.SendToBack()
        'gbMain.BringToFront()
    End Sub

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

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim fSalesReportViewer As New frmReportViewer
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        Dim Strquery As String
        Dim trn As SqlClient.SqlTransaction
        Dim cmdCom1 As SqlClient.SqlCommand


        fSalesReportViewer.MdiParent = MainForm
        fSalesReportViewer.Text = "Ledger Report"
        fSalesReportViewer.Refresh()
        fSalesReportViewer.Show()


        Me.Cursor = Cursors.WaitCursor
        Try




            Strquery = "Delete From Temp_LedgerReport"

            trn = gl_Con.BeginTransaction
            cmdCom1 = New SqlClient.SqlCommand(Strquery, gl_Con)
            cmdCom1.CommandType = CommandType.Text
            cmdCom1.Transaction = trn
            cmdCom1.ExecuteNonQuery()
            trn.Commit()

            With dgDetail
                For i = 0 To dgDetail.RowCount - 1
                    Strquery = "Insert into Temp_LedgerReport(Sno,FromDate,Todate,TrnNo,TrnDate,Opening,Debit,Credit,Total,DbCR, Narration,LedgerName) values (" & Val(.Rows(i).Cells(0).Value) & ",'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (.Rows(i).Cells(2).Value) & "','" & convertToServerDateFormat(.Rows(i).Cells(3).Value) & "','" & Val(.Rows(i).Cells(5).Value) & "','" & Val(.Rows(i).Cells(6).Value) & "','" & Val(.Rows(i).Cells(7).Value) & "','" & Val(.Rows(i).Cells(9).Value) & "','" & (.Rows(i).Cells(10).Value) & "','" & (.Rows(i).Cells(11).Value) & "','" & Trim(txtLedgerName.Text) & "')"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = Strquery
                    cmdCom1.ExecuteNonQuery()
                    trn.Commit()
                Next
            End With


            'For i = 1 To fgDetail.Rows - 1
            '    Strquery = "Insert into Temp_LedgerReport(Sno,FromDate,Todate,TrnNo,TrnDate,Opening,Debit,Credit,Total,DbCR, Narration,LedgerName) values (" & Val(fgDetail.get_TextMatrix(i, 0)) & ",'" & convertToServerDateFormat(dtpFromDate.Value) & "','" & convertToServerDateFormat(dtpToDate.Value) & "','" & (fgDetail.get_TextMatrix(i, 2)) & "','" & convertToServerDateFormat(fgDetail.get_TextMatrix(i, 3)) & "','" & Val(fgDetail.get_TextMatrix(i, 5)) & "','" & Val(fgDetail.get_TextMatrix(i, 6)) & "','" & Val(fgDetail.get_TextMatrix(i, 7)) & "','" & Val(fgDetail.get_TextMatrix(i, 9)) & "','" & (fgDetail.get_TextMatrix(i, 10)) & "','" & (fgDetail.get_TextMatrix(i, 11)) & "','" & Trim(txtLedgerName.Text) & "')"
            '    trn = gl_Con.BeginTransaction
            '    cmdCom1.Transaction = trn
            '    cmdCom1.Connection = gl_Con
            '    cmdCom1.CommandText = Strquery
            '    cmdCom1.ExecuteNonQuery()
            '    trn.Commit()
            'Next

            CrRepDoc.Load(Application.StartupPath & "\Report\rptLedger.rpt")


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
                    cboCustomerName.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    txtLedgerName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                Else
                    cboCustomerName.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    txtLedgerName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
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

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
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