Public Class frmActivityList

    Private Sub frmActivityList_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ActivityList = Nothing
    End Sub
    Private Sub Design()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 5
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "TransactionNo"
            .Columns(1).Width = 120
            .Columns(2).Name = "TransactionDate"
            .Columns(2).Width = 120
            .Columns(3).Name = "Type"
            .Columns(3).Width = 80
            .Columns(4).Name = "Narration"
            .Columns(4).Width = 100

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
        '    .Width = 540
        '    .Height = 484
        '    .Editable = VSFlex7L.EditableSettings.flexEDNone
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow

        '    .Rows = 1
        '    .Cols = 5

        '    .set_ColWidth(0, 600)
        '    .set_TextMatrix(0, 0, "SNo.")

        '    .set_ColWidth(1, 1400)
        '    .set_TextMatrix(0, 1, "Transaction No")

        '    .set_ColWidth(2, 1600)
        '    .set_TextMatrix(0, 2, "Transaction Date")

        '    .set_ColWidth(3, 1600)
        '    .set_TextMatrix(0, 3, "Type")

        '    .set_ColWidth(4, 3000)
        '    .set_TextMatrix(0, 4, "Narration")
        'End With

        With dgTime
            .RowCount = 1
            .ColumnCount = 6
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "TrnsNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "TrnsDate"
            .Columns(2).Width = 80
            .Columns(3).Name = "PaymentDays"
            .Columns(3).Width = 100
            .Columns(4).Name = "CurrentDays"
            .Columns(4).Width = 100
            .Columns(5).Name = "AboveDays"
            .Columns(5).Width = 100

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

        'With fgTime
        '    .Width = 442
        '    .Height = 481
        '    .Editable = VSFlex7L.EditableSettings.flexEDNone
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow

        '    .Rows = 1
        '    .Cols = 6

        '    .set_ColWidth(0, 600)
        '    .set_TextMatrix(0, 0, "SNo.")

        '    .set_ColWidth(1, 1100)
        '    .set_TextMatrix(0, 1, "Trn No")

        '    .set_ColWidth(2, 1400)
        '    .set_TextMatrix(0, 2, "Trn Date")

        '    .set_ColWidth(3, 1500)
        '    .set_TextMatrix(0, 3, "PaymentDays")

        '    .set_ColWidth(4, 1200)
        '    .set_TextMatrix(0, 4, "CurrentDays")
        '    .set_ColHidden(4, True)

        '    .set_ColWidth(5, 1500)
        '    .set_TextMatrix(0, 5, "AboveDays")

        'End With


        Dim Str As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet

        Try

       
            Str = "Execute proc_ActivityList"
            da = New SqlClient.SqlDataAdapter(Str, gl_Con)
            da.Fill(ds, "Activity")
            dgDetail.RowCount = 1
            If ds.Tables("Activity").Rows.Count > 0 Then
                With dgDetail
                    For i = 0 To ds.Tables("Activity").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("TrnNo")), "", ds.Tables("Activity").Rows(i).Item("TrnNo"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("Activity").Rows(i).Item("TrnDate"))), "", convertToServerDateFormat(ds.Tables("Activity").Rows(i).Item("TrnDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("Type")), "", ds.Tables("Activity").Rows(i).Item("Type"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("Party")), "", ds.Tables("Activity").Rows(i).Item("Party"))



                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgDetail.RowCount = 0
            End If







            'If ds.Tables("Activity").Rows.Count > 0 Then
            '    fgDetail.Rows = 1
            '    For i = 0 To ds.Tables("Activity").Rows.Count - 1
            '        With fgDetail
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(i + 1, 0, i + 1)
            '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("TrnNo")), "", ds.Tables("Activity").Rows(i).Item("TrnNo")))

            '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("Activity").Rows(i).Item("TrnDate"))), "", convertToServerDateFormat(ds.Tables("Activity").Rows(i).Item("TrnDate"))))
            '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("Type")), "", ds.Tables("Activity").Rows(i).Item("Type")))
            '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("Party")), "", ds.Tables("Activity").Rows(i).Item("Party")))

            '        End With
            '    Next
            '    fgDetail.Row = 1
            '    fgDetail.Col = 1
            '    fgDetail.Focus()

            'End If

            da.Dispose()
            ds.Clear()



            Str = "SELECT     SaleMaster.SaleInvoiceNo, SaleMaster.SaleDate, PaymentTermMaster.Days, DATEDIFF(Day, SaleMaster.SaleDate, GETDATE()) AS DayDiff, DATEDIFF(Day, SaleMaster.SaleDate, GETDATE()) - PaymentTermMaster.Days AS Difference FROM         SaleMaster INNER JOIN PaymentTermMaster ON SaleMaster.PaymentCode = PaymentTermMaster.PaymentTermCode AND DATEDIFF(Day, SaleMaster.SaleDate, GETDATE())> PaymentTermMaster.Days WHERE     (SaleMaster.CashManual = 0) AND (SaleMaster.CashParty = 0)AND (SaleMaster.TotalValue - ISNULL(SaleMaster.ReceivedAmount, 0) > 0) And (SaleMaster.Approve=1)"
            da = New SqlClient.SqlDataAdapter(Str, gl_Con)
            da.Fill(ds, "Activity")
            da.Fill(ds, "Activity")
            dgTime.RowCount = 1
            If ds.Tables("Activity").Rows.Count > 0 Then
                With dgTime
                    For i = 0 To ds.Tables("Activity").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("SaleInvoiceNo")), "", ds.Tables("Activity").Rows(i).Item("SaleInvoiceNo"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("Activity").Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(ds.Tables("Activity").Rows(i).Item("SaleDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("Days")), 0, ds.Tables("Activity").Rows(i).Item("Days"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("DayDiff")), 0, ds.Tables("Activity").Rows(i).Item("DayDiff"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("Difference")), 0, ds.Tables("Activity").Rows(i).Item("Difference"))




                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgDetail.RowCount = 0
            End If






            'If ds.Tables("Activity").Rows.Count > 0 Then
            '    fgTime.Rows = 1
            '    For i = 0 To ds.Tables("Activity").Rows.Count - 1
            '        With fgTime
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(i + 1, 0, i + 1)
            '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("SaleInvoiceNo")), "", ds.Tables("Activity").Rows(i).Item("SaleInvoiceNo")))

            '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(convertToServerDateFormat(ds.Tables("Activity").Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(ds.Tables("Activity").Rows(i).Item("SaleDate"))))


            '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("Days")), 0, ds.Tables("Activity").Rows(i).Item("Days")))
            '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("DayDiff")), 0, ds.Tables("Activity").Rows(i).Item("DayDiff")))

            '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("Activity").Rows(i).Item("Difference")), 0, ds.Tables("Activity").Rows(i).Item("Difference")))


            '        End With
            '    Next
            '    'fgTime.Row = 1
            '    'fgTime.Col = 1
            '    'fgTime.Focus()
            'End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub frmActivityList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Design()
        
    End Sub

    Private Sub fgDetail_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)

        'If fgDetail.get_TextMatrix(fgDetail.RowSel, 3) = "Purchase" Then
        '    DisplayFormsOnClick("PI", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 3) = "Sale" Then
        '    DisplayFormsOnClick("SI", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))

        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 3) = "Tax" Then
        '    DisplayFormsOnClick("TAX", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 3) = "Payment" Then
        '    DisplayFormsOnClick("PAY", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 3) = "Receipt" Then
        '    DisplayFormsOnClick("REC", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'ElseIf fgDetail.get_TextMatrix(fgDetail.RowSel, 3) = "BankVoucher" Then
        '    DisplayFormsOnClick("BV", fgDetail.get_TextMatrix(fgDetail.RowSel, 1))
        'End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Design()
    End Sub

    Private Sub fgTime_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'If dgTime.RowCount >= 1 Then
        '    DisplayFormsOnClick("SI", dgTime(1, Convert.ToInt32(dgTime.CurrentRow.Index)).Value.ToString)
        'End If

    End Sub

    Private Sub dgDetail_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetail.DoubleClick
        If dgDetail.RowCount >= 1 Then
            If dgDetail(3, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "Purchase" Then
                DisplayFormsOnClick("PI", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(3, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "Sale" Then
                DisplayFormsOnClick("SI", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(3, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "Tax" Then
                DisplayFormsOnClick("TAX", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(3, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "Payment" Then
                DisplayFormsOnClick("PAY", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(3, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "Receipt" Then
                DisplayFormsOnClick("REC", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)
            ElseIf dgDetail(3, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString = "BankVoucher" Then
                DisplayFormsOnClick("BV", dgDetail(1, Convert.ToInt32(dgDetail.CurrentRow.Index)).Value.ToString)

            End If
        End If
    End Sub

    Private Sub dgTime_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTime.DoubleClick
        If dgTime.RowCount >= 1 Then
            DisplayFormsOnClick("SI", dgTime(1, Convert.ToInt32(dgTime.CurrentRow.Index)).Value.ToString)
        End If
    End Sub
End Class