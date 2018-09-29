Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmChallanMaster
    Dim CrRepDoc As New ReportDocument
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim CustomerCode As String
    'Dim SearchCustomer As Integer
    Dim Search As Integer
    Dim Approve As Integer
    Dim LocalityCode As String
    Dim Stock As Decimal
    Dim subStock As Decimal
    Dim CODE As String
    Dim Quotation As Integer


    Dim intDGSearchKeayPress As Integer
    Dim da As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds As New DataSet
    Dim da1 As New SqlDataAdapter   'For search in customer  Search
    Dim ds1 As New DataSet
    Dim da2 As New SqlDataAdapter    'For Searach of Quotation and Item Search
    Dim ds2 As New DataSet


    Private Sub frmChallanMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ChallanMaster = Nothing
    End Sub


    Private Sub ENABLECONTROL(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status
        cmdSearch.Enabled = status
        cmdSearchCustomer.Enabled = Not status
        cmdAddItem.Enabled = Not status
        cmdDelItem.Enabled = Not status

        txtGRNo.ReadOnly = status
        txtPONo.ReadOnly = status
        txtVehicleNo.ReadOnly = status
        txtRefNo.ReadOnly = status
        txtChallanNo.ReadOnly = True
        txtRemarks.ReadOnly = status
        txtCustomerName.ReadOnly = True
        chkQuotation.Enabled = Not status
        txtChallanDate.ReadOnly = True
        txtAddress.ReadOnly = True

        If cmdSave.Enabled = True Then
            dtpDate.BringToFront()
            txtChallanDate.SendToBack()
            cmdApprove.Enabled = False
        Else
            dtpDate.SendToBack()
            txtChallanDate.BringToFront()
            cmdApprove.Enabled = True
        End If

        If gl_EmpName = "administrator" Then
            cmdApprove.Visible = True
        Else
            cmdApprove.Visible = False
        End If


    End Sub
    Private Sub ClearControl()
        txtRefNo.Text = ""
        txtGRNo.Text = ""
        txtPONo.Text = ""
        txtVehicleNo.Text = ""
        txtRemarks.Text = ""
        txtQuotationNo.Text = ""

        txtAddress.Text = ""
        cmdApprove.Text = "Approve"
        txtCustomerName.Text = ""
        dgDetail.RowCount = 0


    End Sub
    Private Sub DesignGrid()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 15
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 50
            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 250
            .Columns(3).Name = "Category"
            .Columns(3).Width = 120
            .Columns(4).Name = "Qty"
            .Columns(4).Width = 70
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 70

            .Columns(6).Name = "S.Qty"
            .Columns(6).Width = 80
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).Visible = False

            .Columns(7).Name = "S.Unit"
            .Columns(7).Width = 80
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).Visible = False

            .Columns(8).Name = "Rate"
            .Columns(8).Width = 90
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).Visible = False
            .Columns(9).Name = "Rate/Unit"
            .Columns(9).Width = 80
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).Visible = False

            .Columns(10).Name = "Amount"
            .Columns(10).Width = 90
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(10).Visible = False
            .Columns(11).Name = "Stock"
            .Columns(11).Width = 80
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).Visible = False
            .Columns(12).Name = "S.Stock"
            .Columns(12).Width = 80
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(12).Visible = False

            .Columns(13).Name = "ConvFact"
            .Columns(13).Width = 80
            .Columns(13).Visible = False


            .Columns(14).Name = "Remarks"
            .Columns(14).Width = 250
            .RowTemplate.Height = 17
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.CellSelect
        End With
        dgDetail.RowCount = 0


        'With fgDetail

        '    .Rows = 1
        '    .Cols = 15

        '    .Width = 913
        '    .Height = 328

        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth


        '    .set_TextMatrix(0, 0, "S.No")
        '    .set_ColWidth(0, 600)

        '    .set_TextMatrix(0, 1, "ItemCode")
        '    .set_ColWidth(1, 1100)

        '    .set_TextMatrix(0, 2, "ItemName")
        '    .set_ColWidth(2, 5000)

        '    .set_TextMatrix(0, 3, "Category")
        '    .set_ColWidth(3, 1200)
        '    '.set_ColHidden(3, True)

        '    .set_TextMatrix(0, 4, "Qty")
        '    .set_ColWidth(4, 1100)
        '    .set_ColFormat(4, "#.##")

        '    .set_TextMatrix(0, 5, "Unit")
        '    .set_ColWidth(5, 1200)

        '    .set_TextMatrix(0, 6, "S.Qty")
        '    .set_ColWidth(6, 800)
        '    .set_ColFormat(6, "#.##")
        '    .set_ColHidden(6, True)
        '    .set_ColHidden(7, True)
        '    .set_ColHidden(9, True)
        '    .set_ColHidden(12, True)
        '    .set_ColHidden(11, True)
        '    .set_ColHidden(13, True)
        '    .set_ColHidden(8, True)
        '    .set_ColHidden(10, True)



        '    .set_TextMatrix(0, 7, "S.Unit")
        '    .set_ColWidth(7, 1000)

        '    .set_TextMatrix(0, 8, "Rate")
        '    .set_ColWidth(8, 1000)
        '    .set_ColFormat(8, "#.##")

        '    .set_TextMatrix(0, 9, "Rate/Unit")
        '    .set_ColWidth(9, 1000)
        '    .set_ColFormat(9, "#.##")

        '    .set_TextMatrix(0, 10, "Amount")
        '    .set_ColWidth(10, 1000)
        '    .set_ColFormat(10, "#.##")

        '    .set_TextMatrix(0, 11, "Stock")
        '    .set_ColWidth(11, 900)


        '    .set_TextMatrix(0, 12, "S.Stock")
        '    .set_ColWidth(12, 900)

        '    .set_TextMatrix(0, 13, "ConvFact")
        '    .set_ColWidth(13, 1000)
        '    .set_TextMatrix(0, 14, "Remark")
        '    .set_ColWidth(14, 2000)

        'End With



    End Sub

    Private Sub frmChallanMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub


    Private Sub frmChallanMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DesignGridItem()
        gbMain.BringToFront()
        DesignGrid()
        ENABLECONTROL(True)
        ClearControl()
        Display()

    End Sub
    Private Sub DesignGridItem()
        Dim chkBox1 As New DataGridViewCheckBoxColumn()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns.Insert(0, chkBox1)
            .Columns(0).Width = 60
            chkBox1.Name = "Select"

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

        End With

        Dim chkBox2 As New DataGridViewCheckBoxColumn()
        With dgSelectedItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns.Insert(0, chkBox2)
            .Columns(0).Width = 60
            chkBox2.Name = "Select"

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
           
        End With
    End Sub
    Private Sub cmdAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddItem.Click

        checkData()
        If checkData() = True Then '''''''''''''Checking data
            MsgDisplay(f_strDataCheck) ''calling function in main module 

            Exit Sub
        End If
        gbSelectItem.BringToFront()
        gbMain.SendToBack()
        gbSelectItem.Enabled = True
        dgSelectedItem.Enabled = True

      If chkQuotation.Checked = True Then
            txtQuotationNo.Text = ""
            dgDetail.RowCount = 0
            FillSearchGridInfoForQuotation()
            FillGridQuotation()
            gbQuotation.Visible = False
        Else

            FillSearchGridInfo()
            FillGridItem()
            gbQuotation.Visible = True
        End If

        txtSearchItemName.Text = ""
        txtSearchItemName.Focus()

        If cboSearchItem.Text = "" Then
            lblName.Text = "ItemName"
        Else
            lblName.Text = cboSearchItem.Text
        End If

    End Sub
    Private Sub FillGridQuotation()
        Dim StrQuery As String
        Dim i As Integer

        da2.Dispose()
        ds2.Clear()


        Try

            StrQuery = "SELECT DISTINCT  QuotationMaster.QuotationNo, QuotationMaster.QuotationDate, QuotationMaster.QuotationVersion, QuotationMaster.QuotationHeading,QuotationMaster.CustomerCode FROM QuotationMaster INNER JOIN QuotationDetail ON QuotationMaster.QuotationNo = QuotationDetail.QuotationNo WHERE     (QuotationMaster.Approve = 1) AND (QuotationDetail.Invoice = 0) and (QuotationMaster.CustomerCode='" & CustomerCode & "') ORDER BY QuotationMaster.QuotationNo"
            da2 = New SqlDataAdapter(StrQuery, gl_Con)
            da2.Fill(ds2, "QuotaionMaster")
            dgSelectItem.RowCount = 1
            If ds2.Tables("QuotaionMaster").Rows.Count > 0 Then
                With dgSelectItem
                    For i = 0 To ds2.Tables("QuotaionMaster").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = False

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds2.Tables("QuotaionMaster").Rows(i).Item("QuotationNo")), "", ds2.Tables("QuotaionMaster").Rows(i).Item("QuotationNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds2.Tables("QuotaionMaster").Rows(i).Item("QuotationDate"))), "01/01/2000", convertToServerDateFormat(ds2.Tables("QuotaionMaster").Rows(i).Item("QuotationDate")))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds2.Tables("QuotaionMaster").Rows(i).Item("QuotationVersion")), "", ds2.Tables("QuotaionMaster").Rows(i).Item("QuotationVersion"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds2.Tables("QuotaionMaster").Rows(i).Item("QuotationHeading")), 0, ds2.Tables("QuotaionMaster").Rows(i).Item("QuotationHeading"))


                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSelectItem.RowCount = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Dim iRow As Integer
        'Dim drDisplay As DataRow
        'Dim f_daDept As SqlClient.SqlDataAdapter
        'Dim f_dsDept As New DataSet
        'Dim StrQuery As String

        'Me.Cursor = Cursors.WaitCursor
        'With fgSelectItem
        '    .Rows = 1
        'End With

        'Try


        '    StrQuery = "SELECT DISTINCT  QuotationMaster.QuotationNo, QuotationMaster.QuotationDate, QuotationMaster.QuotationVersion, QuotationMaster.QuotationHeading,QuotationMaster.CustomerCode FROM QuotationMaster INNER JOIN QuotationDetail ON QuotationMaster.QuotationNo = QuotationDetail.QuotationNo WHERE     (QuotationMaster.Approve = 1) AND (QuotationDetail.Invoice = 0) and (QuotationMaster.CustomerCode='" & CustomerCode & "') ORDER BY QuotationMaster.QuotationNo"





        '    f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
        '    f_dsDept.Clear()
        '    f_daDept.Fill(f_dsDept, "ItemList")
        '    For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
        '        drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
        '        With fgSelectItem
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("QuotationNo")), "", drDisplay.Item("QuotationNo")))


        '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(convertToServerDateFormat(drDisplay.Item("QuotationDate"))), "01/01/2000", (convertToServerDateFormat(drDisplay.Item("QuotationDate")))))
        '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drDisplay.Item("QuotationVersion")), "", drDisplay.Item("QuotationVersion")))
        '            .set_TextMatrix(.Rows - 1, 4, IIf(IsDBNull(drDisplay.Item("QuotationHeading")), 0, drDisplay.Item("QuotationHeading")))
        '        End With
        '    Next



        'Catch ex As Exception

        '    MsgBox(ex.Message)
        'End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub FillSearchGridInfoForQuotation()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Visible = False

            .Columns(1).Name = "QuotationNo"
            .Columns(1).Width = 100
            .Columns(1).Visible = True
            .Columns(2).Name = "QuotationDate"
            .Columns(2).Width = 100
            .Columns(2).Visible = True
            .Columns(3).Name = "VersionNo"
            .Columns(3).Width = 100
            .Columns(3).Visible = True
            .Columns(4).Name = "QuotationHeading"
            .Columns(4).Width = 150
            .Columns(4).Visible = True
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

        With dgSelectedItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Visible = False

            .Columns(1).Name = "QuotationNo"
            .Columns(1).Width = 100
            .Columns(1).Visible = True
            .Columns(2).Name = "QuotationDate"
            .Columns(2).Width = 100
            .Columns(2).Visible = True
            .Columns(3).Name = "VersionNo"
            .Columns(3).Width = 100
            .Columns(3).Visible = True
            .Columns(4).Name = "QuotationHeading"
            .Columns(4).Width = 150
            .Columns(4).Visible = True
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        dgSelectedItem.RowCount = 0
        'With fgSelectItem
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .Rows = 1
        '    .Cols = 10

        '    .set_ColWidth(0, 650)
        '    .set_TextMatrix(0, 0, "Select")
        '    .set_ColDataType(0, VSFlex7L.DataTypeSettings.flexDTBoolean)
        '    .set_ColHidden(0, True)

        '    .set_TextMatrix(0, 1, "QuotationNo")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "QuotationDate")
        '    .set_ColWidth(2, 1500)
        '    .set_TextMatrix(0, 3, "Version No")
        '    .set_ColWidth(3, 1200)
        '    .set_TextMatrix(0, 4, "QuotationHeading")
        '    .set_ColWidth(4, 5000)

        '    .set_ColHidden(5, True)
        '    .set_ColHidden(6, True)
        '    .set_ColHidden(7, True)
        '    .set_ColHidden(8, True)
        '    .set_ColHidden(9, True)

        'End With

        'With fgSelectedItem
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .Rows = 1
        '    .Cols = 10

        '    .set_ColWidth(0, 650)
        '    .set_TextMatrix(0, 0, "Select")
        '    .set_ColDataType(0, VSFlex7L.DataTypeSettings.flexDTBoolean)

        '    .set_TextMatrix(0, 1, "QuotationNo")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "QuotationDate")
        '    .set_ColWidth(2, 1500)
        '    .set_TextMatrix(0, 3, "Version No")
        '    .set_ColWidth(3, 1200)
        '    .set_TextMatrix(0, 4, "QuotationHeading")
        '    .set_ColWidth(4, 5000)

        '    .set_ColHidden(5, True)
        '    .set_ColHidden(6, True)
        '    .set_ColHidden(7, True)
        '    .set_ColHidden(8, True)
        '    .set_ColHidden(9, True)


        'End With
    End Sub
    Private Function checkData() As Boolean

        f_blnCheckData = False
        f_strDataCheck = ""
        If Trim(txtCustomerName.Text) = "" Then
            f_strDataCheck = "Customer Name"
            txtCustomerName.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If

        checkData = f_blnCheckData
    End Function
    Private Function checkData1() As Boolean

        f_blnCheckData = False
        f_strDataCheck = ""
        If Trim(txtCustomerName.Text) = "" Then
            f_strDataCheck = "Customer Name"
            txtCustomerName.Focus()
            f_blnCheckData = True
            checkData1 = True
            Exit Function
        End If

        For i = 0 To dgDetail.RowCount - 1
            If Val(dgDetail.Rows(i).Cells(4).Value) = 0 Then
                f_strDataCheck = "Qty"
                dgDetail.CurrentCell = dgDetail.Item(4, i)
                f_blnCheckData = True
                checkData1 = True
                Exit Function
            End If
        Next

        'With fgDetail



        '    For i = 1 To .Rows - 1
        '        If Val(Trim(.get_TextMatrix(i, 4))) = 0 Then
        '            f_strDataCheck = "Qty"
        '            .Row = i
        '            .Col = 4
        '            f_blnCheckData = True
        '            checkData1 = True
        '            Exit Function
        '        End If
        '    Next


        'End With



        checkData1 = f_blnCheckData
    End Function
    Private Sub FillSearchGridInfo()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Visible = True

            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 350
            .Columns(3).Name = "Category"
            .Columns(3).Width = 150
            .Columns(4).Name = "Stock"
            .Columns(4).Width = 80
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(6).Name = "Make"
            .Columns(6).Width = 80
            .Columns(7).Name = "SubUnit"
            .Columns(7).Width = 80
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80
            .Columns(9).Name = "Rate"
            .Columns(9).Width = 90

            .Columns(1).Visible = True
            .Columns(2).Visible = True
            .Columns(3).Visible = True
            .Columns(5).Visible = True
            .Columns(6).Visible = True
            .Columns(9).Visible = True

            .Columns(4).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

        With dgSelectedItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Visible = True

            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 350
            .Columns(3).Name = "Category"
            .Columns(3).Width = 150
            .Columns(4).Name = "Stock"
            .Columns(4).Width = 80
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(6).Name = "Make"
            .Columns(6).Width = 80
            .Columns(7).Name = "SubUnit"
            .Columns(7).Width = 80
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80
            .Columns(9).Name = "Rate"
            .Columns(9).Width = 90

            .Columns(1).Visible = True
            .Columns(2).Visible = True
            .Columns(3).Visible = True
            .Columns(5).Visible = True
            .Columns(6).Visible = True
            .Columns(9).Visible = True

            .Columns(4).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        dgSelectedItem.RowCount = 0
        'With fgSelectItem
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .Rows = 1
        '    .Cols = 10
        '    '.Width = 678
        '    '.Height = 193
        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "Select")
        '    .set_ColDataType(0, VSFlex7L.DataTypeSettings.flexDTBoolean)

        '    .set_TextMatrix(0, 1, "ItemCode")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "ItemName")
        '    .set_ColWidth(2, 5000)
        '    .set_TextMatrix(0, 3, "Category")
        '    .set_ColWidth(3, 1200)
        '    .set_TextMatrix(0, 4, "Stock")
        '    .set_ColWidth(4, 1300)

        '    .set_TextMatrix(0, 5, "Unit")
        '    .set_ColWidth(5, 1000)

        '    .set_TextMatrix(0, 6, "Make")
        '    .set_ColWidth(6, 1200)


        '    .set_ColHidden(4, True)
        '    .set_ColHidden(7, True)

        '    .set_ColHidden(8, True)
        '    .set_TextMatrix(0, 7, "SubUnit")
        '    .set_ColWidth(7, 1100)

        '    .set_TextMatrix(0, 8, "ConvFact")
        '    .set_ColWidth(8, 1200)

        '    .set_TextMatrix(0, 9, "Rate")
        '    .set_ColWidth(9, 1200)

        'End With

        'With fgSelectedItem
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow
        '    .Rows = 1
        '    .Cols = 10
        '    '.Width = 681
        '    '.Height = 178
        '    .set_ColWidth(0, 550)
        '    .set_TextMatrix(0, 0, "Select")
        '    .set_ColDataType(0, VSFlex7L.DataTypeSettings.flexDTBoolean)

        '    .set_TextMatrix(0, 1, "ItemCode")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "ItemName")
        '    .set_ColWidth(2, 5000)
        '    .set_TextMatrix(0, 3, "Category")
        '    .set_ColWidth(3, 1200)
        '    .set_TextMatrix(0, 4, "Stock")
        '    .set_ColWidth(4, 1300)
        '    .set_ColHidden(4, True)
        '    .set_TextMatrix(0, 5, "Unit")
        '    .set_ColWidth(5, 1000)

        '    .set_TextMatrix(0, 6, "Make")
        '    .set_ColWidth(6, 1200)

        '    .set_TextMatrix(0, 7, "SubUnit")
        '    .set_ColWidth(7, 1100)



        '    .set_ColHidden(7, True)

        '    .set_ColHidden(8, True)

        '    .set_TextMatrix(0, 8, "ConvFact")
        '    .set_ColWidth(8, 1200)

        '    .set_TextMatrix(0, 9, "Rate")
        '    .set_ColWidth(9, 1200)


        'End With
    End Sub
    Private Sub FillGridItem()
        Dim StrQuery As String
        Dim i As Integer

        da2.Dispose()
        ds2.Clear()

        Try

            StrQuery = "SELECT * from ItemMaster  order by itemname"
            da2 = New SqlDataAdapter(StrQuery, gl_Con)
            da2.Fill(ds2, "ItemMaster")
            dgSelectItem.RowCount = 1
            If ds2.Tables("ItemMaster").Rows.Count > 0 Then
                With dgSelectItem
                    For i = 0 To ds2.Tables("ItemMaster").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = False

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("ItemCode")), "", ds2.Tables("ItemMaster").Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("ItemName")), "", ds2.Tables("ItemMaster").Rows(i).Item("ItemName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("Category")), "", ds2.Tables("ItemMaster").Rows(i).Item("Category"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("CurrentStock")), 0, ds2.Tables("ItemMaster").Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("Unit")), "", ds2.Tables("ItemMaster").Rows(i).Item("Unit"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("Make")), 0, ds2.Tables("ItemMaster").Rows(i).Item("Make"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("StoreUnit")), "", ds2.Tables("ItemMaster").Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("ConvFAct")), "", ds2.Tables("ItemMaster").Rows(i).Item("ConvFAct"))
                        .Rows(i).Cells(9).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("Price")), "", ds2.Tables("ItemMaster").Rows(i).Item("Price"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSelectItem.RowCount = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try





        'Dim iRow As Integer
        'Dim drDisplay As DataRow
        'Dim f_daDept As SqlClient.SqlDataAdapter
        'Dim f_dsDept As New DataSet
        'Dim StrQuery As String

        'Me.Cursor = Cursors.WaitCursor
        'With fgSelectItem
        '    .Rows = 1
        'End With

        'Try

        '    StrQuery = "SELECT * from ItemMaster   order by itemname"


        '    f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
        '    f_dsDept.Clear()
        '    f_daDept.Fill(f_dsDept, "ItemList")
        '    For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
        '        drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
        '        With fgSelectItem
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode")))


        '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName")))
        '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category")))
        '            .set_TextMatrix(.Rows - 1, 4, IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock")))
        '            .set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit")))
        '            .set_TextMatrix(.Rows - 1, 6, IIf(IsDBNull(drDisplay.Item("Make")), "", drDisplay.Item("Make")))
        '            .set_TextMatrix(.Rows - 1, 7, IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit")))
        '            .set_TextMatrix(.Rows - 1, 8, IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct")))
        '            .set_TextMatrix(.Rows - 1, 9, IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price")))

        '        End With
        '    Next



        'Catch ex As Exception

        '    MsgBox(ex.Message)
        'End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fgSelectItem_ClickEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim IntCount As Integer
        'Dim intSelectedRow As Integer
        'Dim i As Integer
        'Dim blnAdd As Boolean

        'If fgSelectItem.Col <> 0 Then
        '    fgSelectItem.Editable = VSFlex7L.EditableSettings.flexEDNone
        'Else
        '    fgSelectItem.Editable = VSFlex7L.EditableSettings.flexEDKbdMouse
        'End If

        'Try
        '    intSelectedRow = fgSelectItem.Row
        '    With fgSelectItem
        '        If .Col = 0 Then
        '            If .CellChecked = VSFlex7L.CellCheckedSettings.flexChecked Then
        '                blnAdd = False
        '                For i = 1 To fgSelectedItem.Rows - 1
        '                    If .get_TextMatrix(intSelectedRow, 1) = fgSelectedItem.get_TextMatrix(i, 1) Then
        '                        blnAdd = True
        '                    End If
        '                Next
        '                If blnAdd = False Then
        '                    fgSelectedItem.Rows = fgSelectedItem.Rows + 1
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 0, True)
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 1, .get_TextMatrix(intSelectedRow, 1))
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 2, .get_TextMatrix(intSelectedRow, 2))
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 3, .get_TextMatrix(intSelectedRow, 3))
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 4, .get_TextMatrix(intSelectedRow, 4))
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 5, .get_TextMatrix(intSelectedRow, 5))
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 6, .get_TextMatrix(intSelectedRow, 6))
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 7, .get_TextMatrix(intSelectedRow, 7))
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 8, .get_TextMatrix(intSelectedRow, 8))
        '                    fgSelectedItem.set_TextMatrix(fgSelectedItem.Rows - 1, 9, .get_TextMatrix(intSelectedRow, 9))
        '                End If
        '            Else
        '                For IntCount = 0 To fgSelectedItem.Rows - 1
        '                    If fgSelectedItem.get_TextMatrix(IntCount, 1) = .get_TextMatrix(intSelectedRow, 1) Then
        '                        fgSelectedItem.RemoveItem(IntCount)
        '                        Exit For
        '                    End If
        '                Next
        '            End If
        '        End If
        '    End With
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub fgSelectedItem_ClickEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim IntCount As Integer
        'Dim intSelectedRow As Integer
        'Dim i As Integer
        ''Remove From Selected Search Grid*******
        'If fgSelectedItem.Col <> 0 Then
        '    fgSelectedItem.Editable = VSFlex7L.EditableSettings.flexEDNone
        'Else
        '    fgSelectedItem.Editable = VSFlex7L.EditableSettings.flexEDKbdMouse
        'End If

        'Try
        '    intSelectedRow = fgSelectedItem.Rows - 1
        '    If fgSelectedItem.Col = 0 Then
        '        If fgSelectedItem.CellChecked = VSFlex7L.CellCheckedSettings.flexChecked Then
        '        Else
        '            For IntCount = 1 To fgSelectItem.Rows - 1
        '                If fgSelectItem.get_TextMatrix(IntCount, 1) = fgSelectedItem.get_TextMatrix(fgSelectedItem.RowSel, 1) Then
        '                    fgSelectedItem.RemoveItem(fgSelectedItem.RowSel)
        '                    fgSelectItem.set_TextMatrix(IntCount, 0, False)
        '                    Exit For
        '                End If
        '            Next
        '        End If
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click

        gbMain.Enabled = True
        FillItemGrid()
        gbSelectItem.SendToBack()
        gbSelectItem.SendToBack()
        gbMain.BringToFront()
        If dgDetail.RowCount > 0 Then
            dgDetail.CurrentCell = dgDetail.Item(4, dgDetail.RowCount - 1)
            'fgDetail.Row = fgDetail.Rows - 1
            'fgDetail.Col = 4
            'fgDetail.EditCell()
        End If



    End Sub
    Private Sub FillItemGrid() 'Fill Search Result in Main Grid
        Dim i As Integer
        Dim J As Integer
        Dim k As Integer
        Dim blnAdd As Boolean
        Try

            With dgSelectedItem 
                For i = 0 To .RowCount - 1
                    blnAdd = False
                    'For k = 1 To fgDetail.Rows - 1
                    '    If fgDetail.get_TextMatrix(k, 2) = Trim(.get_TextMatrix(i, 2)) Then
                    '        blnAdd = True
                    '        Exit For
                    '    End If
                    'Next
                    If blnAdd = False Then
                        '.Row = i
                        'If .CellChecked = VSFlex7L.CellCheckedSettings.flexChecked Then

                        dgDetail.RowCount = dgDetail.RowCount + 1
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(0).Value = dgDetail.RowCount
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(1).Value = .Rows(i).Cells(1).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(2).Value = .Rows(i).Cells(2).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(3).Value = .Rows(i).Cells(3).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(11).Value = .Rows(i).Cells(4).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(5).Value = .Rows(i).Cells(5).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(12).Value = .Rows(i).Cells(4).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(7).Value = .Rows(i).Cells(7).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(13).Value = .Rows(i).Cells(8).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(8).Value = .Rows(i).Cells(9).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(9).Value = Val(dgDetail.Rows(dgDetail.RowCount - 1).Cells(8).Value) / Val(dgDetail.Rows(dgDetail.RowCount - 1).Cells(13).Value)

                        'fgDetail.Rows = fgDetail.Rows + 1
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 0, fgDetail.Rows - 1)
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 1, .get_TextMatrix(i, 1))
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 2, .get_TextMatrix(i, 2))
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 3, .get_TextMatrix(i, 3))
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 11, .get_TextMatrix(i, 4))
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 5, .get_TextMatrix(i, 5))

                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 12, .get_TextMatrix(i, 4))
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 7, .get_TextMatrix(i, 7))
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 13, .get_TextMatrix(i, 8))
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 8, .get_TextMatrix(i, 9))
                        'fgDetail.set_TextMatrix(fgDetail.Rows - 1, 9, Val(fgDetail.get_TextMatrix(i, 8)) / Val(fgDetail.get_TextMatrix(i, 13)))




                        'End If
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdDelItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelItem.Click
        Dim i As Integer

        Dim e1 As System.Windows.Forms.DataGridViewCellEventArgs
        If dgDetail.RowCount >= 1 Then
            If MsgQuestion("DELETE") = 7 Then
                Exit Sub
            Else
                dgDetail.Rows.Remove(dgDetail.CurrentRow)

                For i = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(i).Cells(0).Value = i + 1
                    'dgDetail_CellEndEdit(sender, e1)
                Next
            End If
        Else
            MsgBox("No row to delete")
        End If


    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        ENABLECONTROL(False)
        cmdApprove.Enabled = False
        bln_AddOn = True
        bln_EditOn = False

        txtChallanNo.Text = showCode("Challan")
        chkQuotation.Checked = False

        ClearControl()
        Quotation = 0
        dtpDate.Value = Now

        dtpDate.Focus()

        gbSearch.SendToBack()
        gbSelectItem.SendToBack()

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        ENABLECONTROL(False)
        cmdApprove.Enabled = False
        bln_EditOn = True
        bln_AddOn = False
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub

    Private Sub Cancel()
        If MsgQuestion("CANCEL") = 7 Then

            

            Exit Sub
        End If
        Call ENABLECONTROL(True)

        If bln_AddOn = True Then
            Display()
        Else
            Display(txtChallanNo.Text)
        End If
        bln_AddOn = False
        bln_EditOn = False

        cmdApprove.Enabled = True

    End Sub

    Private Sub cmdSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearchCustomer.Click
        'gbSearch.Enabled = True
        'gbSearch.BringToFront()
        'gbSearchInvoice.SendToBack()
        'gbSearchCustomer.BringToFront()
        'fgSearch.Enabled = True

        'If cboSearchCustomer.Text = "" Then
        '    lblRowSearch.Text = "CustomerName"
        'Else
        '    lblRowSearch.Text = cboSearchCustomer.Text
        'End If
        'txtSearchCustomer.Text = ""
        'txtSearchCustomer.Focus()


        Dim StrQuery As String
        Dim i As Integer
        Designgrid2()
        da1.Dispose()
        ds1.Clear()
        Search = 1

        Try
            StrQuery = "SELECT CustomerMaster1.CustomerCode, CustomerMaster1.CustomerName, CustomerMaster1.Address, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM ((CustomerMaster1 INNER JOIN LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode) INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode ORDER BY CustomerMaster1.CustomerName "
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "FillGrid")
            dgSearch.RowCount = 1
            If ds1.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("CustomerCode")), "", ds1.Tables("FillGrid").Rows(i).Item("CustomerCode"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("CustomerName")), "", ds1.Tables("FillGrid").Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("Address")), "", ds1.Tables("FillGrid").Rows(i).Item("Address"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("CityName")), "", ds1.Tables("FillGrid").Rows(i).Item("CityName"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("StateName")), "", ds1.Tables("FillGrid").Rows(i).Item("StateName"))

                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("PINCode")), "", ds1.Tables("FillGrid").Rows(i).Item("PINCode"))


                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearchCustomer.Text = ""
            txtSearchCustomer.Focus()
            cboSearchCustomer.Text = ""
            lblRowSearch.Text = "Customer Name"
            gbSearch.BringToFront()
            gbMain.SendToBack()
            gbSearchInvoice.SendToBack()
            gbSearchCustomer.BringToFront()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Designgrid2()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 7
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Code"
            .Columns(1).Width = 90
            .Columns(2).Name = "Customer Name"
            .Columns(2).Width = 250
            .Columns(3).Name = "Address"
            .Columns(3).Width = 320
            .Columns(4).Name = "City"
            .Columns(4).Width = 100
            .Columns(5).Name = "State"
            .Columns(5).Width = 100
            .Columns(6).Name = "PIN"
            .Columns(6).Width = 90
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

        'Dim Strquery As String
        'Dim da As SqlClient.SqlDataAdapter
        'Dim ds As New DataSet
        'Dim i As Integer


        'With fgSearch

        '    .Editable = VSFlex7L.EditableSettings.flexEDNone
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow

        '    .Rows = 1
        '    .Cols = 7
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "Code")
        '    .set_ColWidth(1, 1100)
        '    .set_TextMatrix(0, 2, "CustomerName")
        '    .set_ColWidth(2, 5000)
        '    .set_TextMatrix(0, 3, "Address")
        '    .set_ColWidth(3, 4000)

        '    .set_TextMatrix(0, 4, "City")
        '    .set_ColWidth(4, 1500)
        '    .set_TextMatrix(0, 5, "State")
        '    .set_ColWidth(5, 1500)
        '    .set_TextMatrix(0, 6, "PIN")
        '    .set_ColWidth(6, 1100)
        'End With

        'Strquery = "SELECT CustomerMaster1.CustomerCode, CustomerMaster1.CustomerName, CustomerMaster1.Address, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM ((CustomerMaster1 INNER JOIN LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode) INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode ORDER BY CustomerMaster1.CustomerName "
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")


        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerCode")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerCode")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerName")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerName")))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Address")), "", ds.Tables("FillGrid").Rows(i).Item("Address")))


        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CityName")), "", ds.Tables("FillGrid").Rows(i).Item("CityName")))
        '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("StateName")), "", ds.Tables("FillGrid").Rows(i).Item("StateName")))
        '            .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("PINCode")), "", ds.Tables("FillGrid").Rows(i).Item("PINCode")))
        '        Next
        '    End If


        'End With



    End Sub
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        'gbSearch.Enabled = True
        'gbSearch.BringToFront()
        'gbSearchInvoice.BringToFront()
        'gbSearchCustomer.SendToBack()
        'fgSearch.Enabled = True
        'Designgrid1()
        'SearchCustomer = 0
        'txtSearch.Text = ""
        'lblRow.Text = "Challan No"
        'txtSearch.Focus()


        Dim StrQuery As String
        Dim i As Integer
        Designgrid1()
        da.Dispose()
        ds.Clear()
        Search = 0

        Try

            StrQuery = "SELECT ChallanMaster.ChallanNo, ChallanMaster.ChallanDate, CustomerMaster1.CustomerName, ChallanMaster.RefNo, ChallanMaster.ChallanNo, ChallanMaster.TotalValue FROM ChallanMaster INNER JOIN CustomerMaster1 ON ChallanMaster.CustomerCode = CustomerMaster1.CustomerCode order by ChallanNo"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ChallanNo")), "", ds.Tables("FillGrid").Rows(i).Item("ChallanNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("ChallanDate"))), "", convertToServerDateFormat(ds.Tables("FillGrid").Rows(i).Item("ChallanDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerName")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("RefNo")), "", ds.Tables("FillGrid").Rows(i).Item("RefNo"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Totalvalue")), "", ds.Tables("FillGrid").Rows(i).Item("Totalvalue"))


                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearch.Text = ""
            txtSearch.Focus()
            cboSearch.Text = ""
            lblRow.Text = "Challan No"
            gbSearch.BringToFront()
            gbMain.SendToBack()
            gbSearchInvoice.BringToFront()
            gbSearchCustomer.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub fgDetail_KeyPressEdit(ByVal sender As Object, ByVal e As AxVSFlex7L._IVSFlexGridEvents_KeyPressEditEvent)

    '    'With fgDetail

    '    '    If .Col = 4 Or .Col = 6 Or .Col = 8 Or .Col = 9 Then
    '    '        If (e.keyAscii >= 48 And e.keyAscii <= 57) Or e.keyAscii = 46 Or e.keyAscii = 8 Then
    '    '        Else
    '    '            e.keyAscii = 0
    '    '        End If
    '    '    ElseIf .Col = 14 Then
    '    '    Else
    '    '        e.keyAscii = 0
    '    '    End If

    '    'End With
    'End Sub


    Private Function CheckRateCol() As Boolean
        Dim i As Integer
        Dim r As Integer
        Dim blnRateEmpty As Boolean
        Dim blnQtyEmpty As Boolean
        Dim s As Integer
        Try

            CheckRateCol = False
            blnRateEmpty = False

            With dgDetail
                For i = 0 To .RowCount - 1
                    If Val(Trim(.Rows(i).Cells(8).Value)) = 0 Or Val(Trim(.Rows(i).Cells(9).Value)) = 0 Then
                        r = i
                        blnRateEmpty = True
                        Exit For
                    End If
                Next



                For i = 0 To .RowCount - 1
                    If Val(Trim(.Rows(i).Cells(4).Value)) = 0 Or Val(Trim(.Rows(i).Cells(6).Value)) = 0 Then
                        s = i
                        blnQtyEmpty = True
                        Exit For
                    End If
                Next


            End With

            'With fgDetail
            '    For i = 1 To .Rows - 1
            '        If Val(Trim(.get_TextMatrix(i, 8))) = 0 Or Val(Trim(.get_TextMatrix(i, 9))) = 0 Then
            '            r = i
            '            blnRateEmpty = True
            '            Exit For
            '        End If
            '    Next



            '    For i = 1 To .Rows - 1
            '        If Val(Trim(.get_TextMatrix(i, 4))) = 0 Or Val(Trim(.get_TextMatrix(i, 6))) = 0 Then
            '            s = i
            '            blnQtyEmpty = True
            '            Exit For
            '        End If
            '    Next


            'End With

            If blnQtyEmpty = True Then
                MsgBox("Qty can't be empty or zero")
                dgDetail.CurrentCell = dgDetail.Item(4, s)
                'fgDetail.Row = s
                'fgDetail.Col = 4
                'fgDetail.EditCell()
                CheckRateCol = True
                Exit Function
            End If


            If blnRateEmpty = True Then
                MsgBox("Rate can't be empty or zero")
                dgDetail.CurrentCell = dgDetail.Item(8, r)
                'fgDetail.Row = r
                'fgDetail.Col = 8
                'fgDetail.EditCell()
                CheckRateCol = True
                Exit Function
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function




    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Save()
    End Sub

    Private Sub Save()
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim StrQuery As String
        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction
        Dim i As Integer
        Dim sender As New System.Object
        Dim e As New System.EventArgs

        Try




            If txtCustomerName.Text = "" Then
                MsgBox("Please Select Customer Name")
                Exit Sub
            End If

            If dgDetail.RowCount = 0 Then
                MsgBox("Please Select Atleast One Item")
                Exit Sub
            End If



            checkData1()
            If checkData1() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            End If


            If bln_AddOn = True Then


                If MsgQuestion("SAVE") = 6 Then


                    str1 = "Insert into ChallanMaster(ChallanNo,ChallanDate,RefNo,VehicleNo,GRNo,PONo,ByQuotation,QuotationNo,  CustomerCode,Remarks,CustomerName1,Address1,Approve) values('" & txtChallanNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & txtRefNo.Text & "','" & txtVehicleNo.Text & "','" & txtGRNo.Text & "','" & txtPONo.Text & "', " & Quotation & " ,'" & txtQuotationNo.Text & "','" & CustomerCode & "','" & Replace(txtRemarks.Text, "'", "''") & "', '" & txtCustomerName.Text & "','" & txtAddress.Text & "',0)"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    With dgDetail
                        For i = 0 To .RowCount - 1
                            str1 = "Insert into ChallanDetail(ChallanNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,Remark,SINo) values('" & txtChallanNo.Text & "','" & (.Rows(i).Cells(1).Value.ToString) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & "," & Val(.Rows(i).Cells(11).Value) & "," & Val(.Rows(i).Cells(12).Value) & ",'" & (.Rows(i).Cells(14).Value) & "'," & Val(.Rows(i).Cells(0).Value) & ")"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()

                        Next
                    End With


                    'For i = 1 To fgDetail.Rows - 1
                    '    str1 = "Insert into ChallanDetail(ChallanNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,Remark,SINo) values('" & txtChallanNo.Text & "','" & (fgDetail.get_TextMatrix(i, 1)) & "'," & Val(fgDetail.get_TextMatrix(i, 4)) & ",'" & Val(fgDetail.get_TextMatrix(i, 6)) & "'," & Val(fgDetail.get_TextMatrix(i, 8)) & "," & Val(fgDetail.get_TextMatrix(i, 9)) & "," & Val(fgDetail.get_TextMatrix(i, 10)) & "," & Val(fgDetail.get_TextMatrix(i, 11)) & "," & Val(fgDetail.get_TextMatrix(i, 12)) & ",'" & (fgDetail.get_TextMatrix(i, 14)) & "'," & Val(fgDetail.get_TextMatrix(i, 0)) & ")"

                    '    cmdCom1.Transaction = trn
                    '    cmdCom1.Connection = gl_Con
                    '    cmdCom1.CommandText = str1
                    '    cmdCom1.ExecuteNonQuery()

                    'Next

                    str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='Challan'"


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()

                    'FillStock()

                    Call Display(Trim(txtChallanNo.Text))
                    bln_AddOn = False
                    bln_EditOn = False
                    'Call cmdApprove_Click(sender, e)
                End If
            ElseIf bln_EditOn = True Then
                If MsgQuestion("UPDATE") = 6 Then


                    str1 = "update ChallanMaster set ChallanDate='" & convertToServerDateFormat(dtpDate.Value) & "',RefNo='" & txtRefNo.Text & "',VehicleNo='" & txtVehicleNo.Text & "',GRNo='" & txtGRNo.Text & "',PONo='" & txtPONo.Text & "',ByQuotation=" & Quotation & ",QuotationNo='" & txtQuotationNo.Text & "', CustomerCode='" & CustomerCode & "', Remarks='" & Replace(txtRemarks.Text, "'", "''") & "', CustomerName1='" & txtCustomerName.Text & "',Address1='" & txtAddress.Text & "',Approve=0 where ChallanNo='" & txtChallanNo.Text & "'"

                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    str1 = "Delete From ChallanDetail where ChallanNo='" & txtChallanNo.Text & "'"
                    ComSave = New SqlClient.SqlCommand(str1, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()

                    With dgDetail
                        For i = 0 To .RowCount - 1
                            str1 = "Insert into ChallanDetail(ChallanNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,Remark,SINo) values('" & txtChallanNo.Text & "','" & (.Rows(i).Cells(1).Value.ToString) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & "," & Val(.Rows(i).Cells(11).Value) & "," & Val(.Rows(i).Cells(12).Value) & ",'" & (.Rows(i).Cells(14).Value) & "'," & Val(.Rows(i).Cells(0).Value) & ")"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()

                        Next
                    End With


                    'For i = 1 To fgDetail.Rows - 1
                    '    str1 = "Insert into ChallanDetail(ChallanNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,Remark,SINo) values('" & txtChallanNo.Text & "','" & (fgDetail.get_TextMatrix(i, 1)) & "'," & Val(fgDetail.get_TextMatrix(i, 4)) & ",'" & Val(fgDetail.get_TextMatrix(i, 6)) & "'," & Val(fgDetail.get_TextMatrix(i, 8)) & "," & Val(fgDetail.get_TextMatrix(i, 9)) & "," & Val(fgDetail.get_TextMatrix(i, 10)) & "," & Val(fgDetail.get_TextMatrix(i, 11)) & "," & Val(fgDetail.get_TextMatrix(i, 12)) & ",'" & (fgDetail.get_TextMatrix(i, 14)) & "'," & val(fgDetail.get_TextMatrix(i, 0)) & ")"

                    '    cmdCom1.Transaction = trn
                    '    cmdCom1.Connection = gl_Con
                    '    cmdCom1.CommandText = str1
                    '    cmdCom1.ExecuteNonQuery()

                    'Next


                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtChallanNo.Text))
                    bln_AddOn = False
                    bln_EditOn = False
                    'Call cmdApprove_Click(sender, e)
                End If

            End If


        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub Display(Optional ByVal strMRqNo As String = "-1")
        Dim i As Integer
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim daDA1 As SqlClient.SqlDataAdapter
        Dim dsDS1 As New DataSet
        Dim str1 As String

        Try

            If gl_EmpName = "administrator" Then
                cmdApprove.Visible = True
            Else
                cmdApprove.Visible = False
            End If
            If strMRqNo = "-1" Then

                str1 = "SELECT  ChallanDetail.SINo,ChallanMaster.ChallanId, ChallanMaster.QuotationNo,ChallanMaster.ByQuotation,ChallanMaster.Approve, ChallanMaster.ChallanNo, ChallanMaster.ChallanDate, ChallanDetail.Invoice, ChallanMaster.RefNo,ChallanMaster.VehicleNo, ChallanMaster.GRNo,ChallanMaster.PONo, ChallanMaster.ChallanNo, ChallanMaster.Remarks, ChallanDetail.ItemCode, ChallanDetail.Qty, ChallanDetail.SubQty, ChallanDetail.Rate, ChallanDetail.SubRate, ChallanDetail.Amount,ChallanDetail.Remark, ItemMaster.ItemName, ItemMaster.Category, ItemMaster.Unit, ItemMaster.ConvFAct, ItemMaster.StoreUnit, ItemMaster.CurrentStock, ItemMaster.CurrentSubStock, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode, CustomerMaster1.CustomerName, CustomerMaster1.Address, ChallanMaster.CustomerName1, ChallanMaster.Address1, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM (((((ChallanMaster INNER JOIN ChallanDetail ON ChallanMaster.ChallanNo = ChallanDetail.ChallanNo) INNER JOIN ItemMaster ON ChallanDetail.ItemCode = ItemMaster.ItemCode) LEFT JOIN CustomerMaster1 ON ChallanMaster.CustomerCode = CustomerMaster1.CustomerCode) LEFT JOIN LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode) LEFT JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) LEFT JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode WHERE (((ChallanMaster.ChallanId)=(SELECT     MAX(ChallanId)FROM          ChallanMaster))) order by ChallanDetail.SINo   "
            Else
                str1 = "SELECT    ChallanDetail.SINo,ChallanMaster.ChallanId,ChallanMaster.QuotationNo,ChallanMaster.ByQuotation, ChallanMaster.Approve, ChallanMaster.ChallanNo, ChallanMaster.ChallanDate, ChallanDetail.Invoice, ChallanMaster.RefNo,ChallanMaster.VehicleNo, ChallanMaster.GRNo,ChallanMaster.PONo,  ChallanMaster.ChallanNo, ChallanMaster.Remarks,ChallanDetail.Remark,  ChallanDetail.ItemCode, ChallanDetail.Qty, ChallanDetail.SubQty, ChallanDetail.Rate, ChallanDetail.SubRate, ChallanDetail.Amount, ItemMaster.ItemName, ItemMaster.Category, ItemMaster.Unit, ItemMaster.ConvFAct, ItemMaster.StoreUnit, ItemMaster.CurrentStock, ItemMaster.CurrentSubStock, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode, CustomerMaster1.CustomerName, CustomerMaster1.Address,   ChallanMaster.CustomerName1, ChallanMaster.Address1, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM (((((ChallanMaster INNER JOIN ChallanDetail ON ChallanMaster.ChallanNo = ChallanDetail.ChallanNo) INNER JOIN ItemMaster ON ChallanDetail.ItemCode = ItemMaster.ItemCode) LEFT JOIN CustomerMaster1 ON ChallanMaster.CustomerCode = CustomerMaster1.CustomerCode) LEFT JOIN LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode) LEFT JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) LEFT JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode WHERE      (ChallanMaster.ChallanNo=    '" & strMRqNo & "') order by ChallanDetail.SINo "
            End If

            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "MR")

            If dsDS1.Tables("MR").Rows.Count > 0 Then

                Approve = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Approve")), 0, dsDS1.Tables("MR").Rows(0).Item("Approve"))
                If Approve = 1 Then
                    cmdApprove.Text = "Approved"
                    cmdEdit.Enabled = False
                Else
                    cmdApprove.Text = "Approve"
                    cmdEdit.Enabled = True
                End If
                txtChallanNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ChallanNo")), "", dsDS1.Tables("MR").Rows(0).Item("ChallanNo"))
                CustomerCode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerCode")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerCode"))
                Quotation = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ByQuotation")), 0, dsDS1.Tables("MR").Rows(0).Item("ByQuotation"))
                If Quotation = 1 Then
                    chkQuotation.Checked = True
                Else
                    chkQuotation.Checked = False
                End If
                lblPrimaryKey.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ChallanId")), "", dsDS1.Tables("MR").Rows(0).Item("ChallanId"))
                txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address")), "", dsDS1.Tables("MR").Rows(0).Item("Address")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("LocalityName")), "", dsDS1.Tables("MR").Rows(0).Item("LocalityName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CityName")), "", dsDS1.Tables("MR").Rows(0).Item("CItyName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("StateName")), "", dsDS1.Tables("MR").Rows(0).Item("StateName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PINCode")), "", dsDS1.Tables("MR").Rows(0).Item("PINCode"))

                txtCustomerName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerName")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerName"))

                LocalityCode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("LocalityCode")), "", dsDS1.Tables("MR").Rows(0).Item("LocalityCode"))


                txtRefNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("RefNo")), "", dsDS1.Tables("MR").Rows(0).Item("RefNo"))

                dtpDate.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChallanDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChallanDate")))
                txtChallanDate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChallanDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("ChallanDate")))
                txtRemarks.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Remarks")), "", dsDS1.Tables("MR").Rows(0).Item("Remarks"))
                txtVehicleNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("VehicleNo")), "", dsDS1.Tables("MR").Rows(0).Item("VehicleNo"))
                txtGRNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("GRNo")), "", dsDS1.Tables("MR").Rows(0).Item("GRNo"))
                txtPONo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PONo")), "", dsDS1.Tables("MR").Rows(0).Item("PONo"))
                txtQuotationNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("QuotationNo")), "", dsDS1.Tables("MR").Rows(0).Item("QuotationNo"))

                cmdApprove.Enabled = True

                dgDetail.RowCount = 1
                For i = 0 To dsDS1.Tables("MR").Rows.Count - 1
                    With dgDetail
                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SINo")), "", dsDS1.Tables("MR").Rows(i).Item("SINo"))
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ItemCode")), "", dsDS1.Tables("MR").Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ItemName")), "", dsDS1.Tables("MR").Rows(i).Item("ItemName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Category")), "", dsDS1.Tables("MR").Rows(i).Item("Category"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Qty")), 0, dsDS1.Tables("MR").Rows(i).Item("Qty"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Unit")), "", dsDS1.Tables("MR").Rows(i).Item("Unit"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubQty")), 0, dsDS1.Tables("MR").Rows(i).Item("SubQty"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("StoreUnit")), "", dsDS1.Tables("MR").Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Rate")), 0, dsDS1.Tables("MR").Rows(i).Item("Rate"))
                        .Rows(i).Cells(9).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubRate")), 0, dsDS1.Tables("MR").Rows(i).Item("SubRate"))
                        .Rows(i).Cells(10).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Amount")), 0, dsDS1.Tables("MR").Rows(i).Item("Amount"))
                        .Rows(i).Cells(11).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("CurrentStock")), 0, dsDS1.Tables("MR").Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(12).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("CurrentSubStock")), 0, dsDS1.Tables("MR").Rows(i).Item("CurrentSubStock"))
                        .Rows(i).Cells(13).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ConvFAct")), 0, dsDS1.Tables("MR").Rows(i).Item("ConvFAct"))
                        .Rows(i).Cells(14).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Remark")), "", dsDS1.Tables("MR").Rows(i).Item("Remark"))



                        '.set_TextMatrix(i + 1, 0, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SINo")), "", dsDS1.Tables("MR").Rows(i).Item("SINo")))
                        '.set_TextMatrix(i + 1, 1, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ItemCode")), "", dsDS1.Tables("MR").Rows(i).Item("ItemCode")))
                        '.set_TextMatrix(i + 1, 2, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ItemName")), "", dsDS1.Tables("MR").Rows(i).Item("ItemName")))
                        '.set_TextMatrix(i + 1, 3, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Category")), "", dsDS1.Tables("MR").Rows(i).Item("Category")))
                        '.set_TextMatrix(i + 1, 4, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Qty")), 0, dsDS1.Tables("MR").Rows(i).Item("Qty")))
                        '.set_TextMatrix(i + 1, 5, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Unit")), "", dsDS1.Tables("MR").Rows(i).Item("Unit")))
                        '.set_TextMatrix(i + 1, 6, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubQty")), 0, dsDS1.Tables("MR").Rows(i).Item("SubQty")))
                        '.set_TextMatrix(i + 1, 7, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("StoreUnit")), "", dsDS1.Tables("MR").Rows(i).Item("StoreUnit")))
                        '.set_TextMatrix(i + 1, 8, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Rate")), 0, dsDS1.Tables("MR").Rows(i).Item("Rate")))
                        '.set_TextMatrix(i + 1, 9, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubRate")), 0, dsDS1.Tables("MR").Rows(i).Item("SubRate")))
                        '.set_TextMatrix(i + 1, 10, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Amount")), 0, dsDS1.Tables("MR").Rows(i).Item("Amount")))

                        ''.set_TextMatrix(i + 1, 11, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("StockOnDate")), 0, dsDS1.Tables("MR").Rows(i).Item("StockOnDate")))
                        ''.set_TextMatrix(i + 1, 12, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubStockOnDate")), 0, dsDS1.Tables("MR").Rows(i).Item("SubStockOnDate")))

                        '.set_TextMatrix(i + 1, 11, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("CurrentStock")), 0, dsDS1.Tables("MR").Rows(i).Item("CurrentStock")))
                        '.set_TextMatrix(i + 1, 12, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("CurrentSubStock")), 0, dsDS1.Tables("MR").Rows(i).Item("CurrentSubStock")))
                        '.set_TextMatrix(i + 1, 13, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ConvFAct")), 0, dsDS1.Tables("MR").Rows(i).Item("ConvFAct")))
                        '.set_TextMatrix(i + 1, 14, IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Remark")), "", dsDS1.Tables("MR").Rows(i).Item("Remark")))
                        Dim invoice As Integer
                        invoice = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("invoice")), 0, dsDS1.Tables("MR").Rows(i).Item("invoice"))
                        If cmdApprove.Enabled = False Then
                            GoTo here
                        End If


                        If invoice = 1 Then
                            cmdApprove.Enabled = False
                        Else
                            cmdApprove.Enabled = True
                        End If

here:               End With
                Next
                dgDetail.RowCount = dgDetail.RowCount - 1

            End If


            daDA1.Dispose()
            dsDS1.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TrapKeyDown(ByVal key As System.Windows.Forms.Keys)
        Try
            Select Case key
                Case Keys.Escape
                    If gbSearch.Visible = True Then
                        gbSearch.SendToBack()
                        gbMain.BringToFront()
                        Panel1.Enabled = True
                    Else
                        If cmdCancel.Enabled = True Then

                            Call Cancel()
                            Exit Sub

                        Else
                            Me.Close()
                        End If
                    End If
            End Select

            '********************Handles Keys*********************

            If cmdCancel.Enabled = True Then
                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearchCustomer_Click(sender, e)
                End Select

            End If
            If cmdCancel.Enabled = False Then
                Dim strMinMaxKey As String
                Dim intCounter As Integer

                'Query for selecting minimum and maximum ItemID
                strMinMaxKey = "select max(ChallanId) AS MaxId,MIN(ChallanId) As MinId from ChallanMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet

                'fill the dataset with min and max Id's 
                'give the name to table "ItemID"

                daMinMaxKey.Fill(dsMinMaxKey, "Challan")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("Challan").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select ChallanNo  from ChallanMaster where ChallanId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "ChallanNavigation")

                        txtChallanNo.Text = dsMinMaxKey.Tables("ChallanNavigation").Rows(0).Item("ChallanNo")
                        Call Display(txtChallanNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Challan").Rows(0).Item("minId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Challan").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select ChallanNo from ChallanMaster where ChallanId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "ChallanNavigation")

                            If dsMinMaxKey.Tables("ChallanNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Challan").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtChallanNo.Text = dsMinMaxKey.Tables("ChallanNavigation").Rows(0).Item("ChallanNo")
                        Call Display(txtChallanNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Challan").Rows(0).Item("maxId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Challan").Rows(0).Item("maxId")
                            strNextRecord = "select ChallanNo from ChallanMaster where ChallanId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "ChallanNavigation")

                            If dsMinMaxKey.Tables("ChallanNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Challan").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtChallanNo.Text = dsMinMaxKey.Tables("ChallanNavigation").Rows(0).Item("ChallanNo")
                        Call Display(txtChallanNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Challan").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select ChallanNo from ChallanMaster where ChallanId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "ChallanNavigation")

                        txtChallanNo.Text = dsMinMaxKey.Tables("ChallanNavigation").Rows(0).Item("ChallanNo")
                        Call Display(txtChallanNo.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Designgrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 6
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "ChallanNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "Date"
            .Columns(2).Width = 100
            .Columns(3).Name = "Curstomer Name"
            .Columns(3).Width = 300
            .Columns(4).Name = "RefNo"
            .Columns(4).Width = 150
            .Columns(5).Name = "TotalValue"
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

        'Dim Strquery As String
        'Dim da As SqlClient.SqlDataAdapter
        'Dim ds As New DataSet
        'Dim i As Integer


        'With fgSearch

        '    .Editable = VSFlex7L.EditableSettings.flexEDNone
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow

        '    .Rows = 1
        '    .Cols = 6
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "ChallanNo")
        '    .set_ColWidth(1, 1500)
        '    .set_TextMatrix(0, 2, "Date")
        '    .set_ColWidth(2, 1500)
        '    .set_TextMatrix(0, 3, "CustomerName")
        '    .set_ColWidth(3, 6500)
        '    .set_TextMatrix(0, 4, "RefNo")
        '    .set_ColWidth(4, 1500)
        '    .set_TextMatrix(0, 5, "TotalValue")
        '    .set_ColWidth(5, 1500)

        'End With

        'Strquery = "SELECT ChallanMaster.ChallanNo, ChallanMaster.ChallanDate, CustomerMaster1.CustomerName, ChallanMaster.RefNo, ChallanMaster.ChallanNo, ChallanMaster.TotalValue FROM ChallanMaster INNER JOIN CustomerMaster1 ON ChallanMaster.CustomerCode = CustomerMaster1.CustomerCode order by ChallanNo"

        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")


        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ChallanNo")), "", ds.Tables("FillGrid").Rows(i).Item("ChallanNo")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ChallanDate")), "", ds.Tables("FillGrid").Rows(i).Item("ChallanDate")))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerName")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerName")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("RefNo")), "", ds.Tables("FillGrid").Rows(i).Item("RefNo")))
        '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Totalvalue")), "", ds.Tables("FillGrid").Rows(i).Item("Totalvalue")))
        '        Next
        '    End If


        'End With



    End Sub

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim fSalesReportViewer As New frmReportViewer
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        Dim strMRCode As String

        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim StrQuery As String
        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction







        fSalesReportViewer.MdiParent = MainForm
        fSalesReportViewer.Text = "Challan"
        fSalesReportViewer.Refresh()
        fSalesReportViewer.Show()


        Me.Cursor = Cursors.WaitCursor
        Try



            'str1 = "delete from Temp_Report"
            'trn = gl_Con.BeginTransaction
            'ComSave = New SqlClient.SqlCommand(str1, gl_Con)
            'ComSave.CommandType = CommandType.Text
            'ComSave.Transaction = trn
            'ComSave.ExecuteNonQuery()

            'str1 = "Insert into Temp_Report(ReportNo) values('" & txtChallanNo.Text & "')"
            'cmdCom1.Transaction = trn
            'cmdCom1.Connection = gl_Con
            'cmdCom1.CommandText = str1
            'cmdCom1.ExecuteNonQuery()

            'trn.Commit()


             
            CrRepDoc.Load(Application.StartupPath & "\Report\rptChallan.rpt")



            For Each tbCurrent In CrRepDoc.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo

                    .ServerName = gl_Con.DataSource
                    .UserID = "sa"
                    .Password = ""
                    .DatabaseName = gl_Con.Database
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent
            CrRepDoc.Refresh()
            strMRCode = "{ChallanMaster.ChallanNo} = '" & Trim(txtChallanNo.Text) & "'"
            fSalesReportViewer.CrystalReportViewer1.SelectionFormula = strMRCode
            fSalesReportViewer.CrystalReportViewer1.ReportSource = CrRepDoc
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtSearchItemName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchItemName.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSelectItem.Focus()
        End If
    End Sub


    Private Sub txtSearchItemName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchItemName.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try
            If cboSearchItem.SelectedIndex = 0 Then
                dv = New DataView(ds2.Tables("ItemMaster"), "ItemCode Like '" & Trim(txtSearchItemName.Text) & "*" & "'", "ItemCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchItem.SelectedIndex = 1 Then
                dv = New DataView(ds2.Tables("ItemMaster"), "Category Like '" & Trim(txtSearchItemName.Text) & "*" & "'", "ItemCode", DataViewRowState.CurrentRows)

            ElseIf cboSearchItem.SelectedIndex = 2 Then
                dv = New DataView(ds2.Tables("ItemMaster"), "Make Like '" & Trim(txtSearchItemName.Text) & "*" & "'", "ItemCode", DataViewRowState.CurrentRows)
            Else
                dv = New DataView(ds2.Tables("ItemMaster"), "ItemName Like '" & Trim(txtSearchItemName.Text) & "*" & "'", "ItemCode", DataViewRowState.CurrentRows)
            End If

            dTable = dv.ToTable
            dgSelectItem.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSelectItem
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = False

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemCode")), "", dTable.Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemName")), "", dTable.Rows(i).Item("ItemName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("Category")), "", dTable.Rows(i).Item("Category"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("CurrentStock")), 0, dTable.Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("Unit")), "", dTable.Rows(i).Item("Unit"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("Make")), "", dTable.Rows(i).Item("Make"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dTable.Rows(i).Item("StoreUnit")), "", dTable.Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dTable.Rows(i).Item("ConvFAct")), "", dTable.Rows(i).Item("ConvFAct"))
                        .Rows(i).Cells(9).Value = IIf(IsDBNull(dTable.Rows(i).Item("Price")), "", dTable.Rows(i).Item("Price"))


                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSelectItem.RowCount = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




       
        'fgSelectItem.Rows = 1
        'Strquery = "SELECT * from ItemMaster  WHERE     (" & Text & "  LIKE '%" & txtSearchItemName.Text & "%') order by ItemName"

        'f_daDept = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'f_dsDept.Clear()
        'f_daDept.Fill(f_dsDept, "ItemList")
        'For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
        '    drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
        '    With fgSelectItem
        '        .Rows = .Rows + 1
        '        .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode")))

        '        .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName")))
        '        .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category")))
        '        .set_TextMatrix(.Rows - 1, 4, IIf(IsDBNull(drDisplay.Item("Make")), "", drDisplay.Item("Make")))
        '        .set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit")))
        '        .set_TextMatrix(.Rows - 1, 6, IIf(IsDBNull(drDisplay.Item("Make")), "", drDisplay.Item("Make")))
        '        .set_TextMatrix(.Rows - 1, 7, IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit")))
        '        .set_TextMatrix(.Rows - 1, 8, IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct")))
        '        .set_TextMatrix(.Rows - 1, 9, IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price")))

        '    End With
        'Next



    End Sub

    Private Sub txtsearchName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If

    End Sub

    Private Sub txtSearchChallan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub



    Private Sub txtSearchInvoice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub cmdApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
     
        Dim trn As SqlClient.SqlTransaction
        Dim i As Integer

        Try

            If cmdApprove.Text = "Approve" Then
                If MsgQuestion("APPROVE") = 6 Then
                    trn = gl_Con.BeginTransaction
                    'For i = 1 To fgDetail.Rows - 1

                    '    str1 = "update ItemMaster set CurrentStock=CurrentStock-" & Val(fgDetail.get_TextMatrix(i, 4)) & ",CurrentSubStock=CurrentSubStock-" & Val(fgDetail.get_TextMatrix(i, 6)) & ",Price=" & Val(fgDetail.get_TextMatrix(i, 8)) & " where ItemCode='" & (fgDetail.get_TextMatrix(i, 1)) & "'"
                    '    cmdCom1.Transaction = trn
                    '    cmdCom1.Connection = gl_Con
                    '    cmdCom1.CommandText = str1
                    '    cmdCom1.ExecuteNonQuery()

                    'Next

                    If chkQuotation.Checked = True Then

                        For i = 0 To dgDetail.RowCount - 1

                            str1 = "update QuotationDetail set Invoice=1,InvoiceNo='" & txtChallanNo.Text & "' where QuotationNo='" & Trim(txtQuotationNo.Text) & "' And ItemCode='" & (dgDetail.Rows(i).Cells(1).Value) & "'"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                        'For i = 1 To fgDetail.Rows - 1

                        '    str1 = "update QuotationDetail set Invoice=1,InvoiceNo='" & txtChallanNo.Text & "' where QuotationNo='" & Trim(txtQuotationNo.Text) & "' And ItemCode='" & (fgDetail.get_TextMatrix(i, 1)) & "'"

                        '    cmdCom1.Transaction = trn
                        '    cmdCom1.Connection = gl_Con
                        '    cmdCom1.CommandText = str1
                        '    cmdCom1.ExecuteNonQuery()
                        'Next

                    End If

                    str1 = "update ChallanMaster set Approve=1 where ChallanNo='" & txtChallanNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()



                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtChallanNo.Text))

                    If Approve = 1 Then
                        cmdApprove.Text = "Approved"
                        cmdEdit.Enabled = False
                    Else
                        cmdApprove.Text = "Approve"
                        cmdEdit.Enabled = True
                    End If
                End If
            ElseIf cmdApprove.Text = "Approved" Then


                If MsgQuestion("DISAPPROVE") = 6 Then

                    trn = gl_Con.BeginTransaction
                    'For i = 1 To fgDetail.Rows - 1

                    '    str1 = "update ItemMaster set CurrentStock=CurrentStock+" & Val(fgDetail.get_TextMatrix(i, 4)) & ",CurrentSubStock=CurrentSubStock+" & Val(fgDetail.get_TextMatrix(i, 6)) & " where ItemCode='" & (fgDetail.get_TextMatrix(i, 1)) & "'"
                    '    cmdCom1.Transaction = trn
                    '    cmdCom1.Connection = gl_Con
                    '    cmdCom1.CommandText = str1
                    '    cmdCom1.ExecuteNonQuery()


                    'Next
                    If chkQuotation.Checked = True Then
                        For i = 0 To dgDetail.RowCount - 1

                            str1 = "update QuotationDetail set Invoice=0,InvoiceNo='' where QuotationNo='" & Trim(txtQuotationNo.Text) & "'  And ItemCode='" & (dgDetail.Rows(i).Cells(1).Value) & "'"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next

                        'For i = 1 To fgDetail.Rows - 1

                        '    str1 = "update QuotationDetail set Invoice=0,InvoiceNo='' where QuotationNo='" & Trim(txtQuotationNo.Text) & "'  And ItemCode='" & (fgDetail.get_TextMatrix(i, 1)) & "'"

                        '    cmdCom1.Transaction = trn
                        '    cmdCom1.Connection = gl_Con
                        '    cmdCom1.CommandText = str1
                        '    cmdCom1.ExecuteNonQuery()
                        'Next

                    End If


                    str1 = "update ChallanMaster set Approve=0 where ChallanNo='" & txtChallanNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtChallanNo.Text))
                    If Approve = 1 Then
                        cmdApprove.Text = "Approved"
                        cmdEdit.Enabled = False
                    Else
                        cmdApprove.Text = "Approve"
                        cmdEdit.Enabled = True
                    End If
            End If
            End If
        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub fgSelectItem_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)

        'If fgSelectItem.Col > 0 Then
        '    gbSelectItem.Visible = False
        '    gbMain.Enabled = True
        '    gbSelectItem.Visible = False
        '    gbSelectItem.SendToBack()

        '    If chkQuotation.Checked = True Then
        '        DirectFillQuotationDetail()
        '        txtQuotationNo.Text = fgSelectItem.get_TextMatrix(fgSelectItem.RowSel, 1)

        '    Else
        '        DirectFillItemGrid()
        '        fgDetail.Row = fgDetail.Rows - 1
        '        fgDetail.Col = 4
        '        fgDetail.EditCell()
        '    End If

        'End If
    End Sub
    Private Sub DirectFillQuotationDetail()

        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim f_daDept As SqlClient.SqlDataAdapter
        Dim f_dsDept As New DataSet
        Dim StrQuery As String

        Me.Cursor = Cursors.WaitCursor
        'With fgSelectItem
        '    .Rows = 1
        'End With

        Try
            StrQuery = "SELECT     QuotationDetail.SNo, QuotationMaster.QuotationNo, QuotationMaster.QuotationDate, QuotationMaster.QuotationVersion, QuotationMaster.QuotationHeading, QuotationDetail.ItemCode, QuotationDetail.Qty as CurrentStock, QuotationDetail.SubQty as CurrentSubStock, ItemMaster.ItemName, ItemMaster.Category, ItemMaster.Unit, ItemMaster.StoreUnit, QuotationDetail.Rate As Price, ItemMaster.ConvFAct FROM         QuotationMaster INNER JOIN QuotationDetail ON QuotationMaster.QuotationNo = QuotationDetail.QuotationNo INNER JOIN ItemMaster ON QuotationDetail.ItemCode = ItemMaster.ItemCode where QuotationMaster.QuotationNo='" & dgSelectItem.Rows(dgSelectItem.CurrentRow.Index).Cells(1).Value & "'AND (QuotationDetail.Invoice = 0)  ORDER BY  QuotationDetail.SNo"
            f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            f_dsDept.Clear()
            f_daDept.Fill(f_dsDept, "ItemList")
            dgDetail.RowCount = dgDetail.RowCount + 1
            For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
                drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
                With dgDetail
                    .RowCount = .RowCount + 1
                    .Rows(.RowCount - 2).Cells(0).Value = IIf(IsDBNull(drDisplay.Item("SNo")), "", drDisplay.Item("SNo"))
                    .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode"))
                    .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName"))
                    .Rows(.RowCount - 2).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category"))
                    .Rows(.RowCount - 2).Cells(4).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                    .Rows(.RowCount - 2).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit"))
                    .Rows(.RowCount - 2).Cells(6).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                    .Rows(.RowCount - 2).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit"))
                    .Rows(.RowCount - 2).Cells(13).Value = IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct"))
                    .Rows(.RowCount - 2).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price"))
                    .Rows(.RowCount - 2).Cells(9).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) / .Rows(.RowCount - 2).Cells(13).Value
                    .Rows(.RowCount - 2).Cells(10).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) * Val(.Rows(.RowCount - 2).Cells(4).Value)
                    .Rows(.RowCount - 2).Cells(11).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                    .Rows(.RowCount - 2).Cells(12).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))


                    '.set_TextMatrix(.Rows - 1, 0, IIf(IsDBNull(drDisplay.Item("SNo")), "", drDisplay.Item("SNo")))
                    '.set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode")))
                    '.set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName")))
                    '.set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category")))
                    '.set_TextMatrix(.Rows - 1, 4, IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock")))
                    '.set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit")))
                    '.set_TextMatrix(.Rows - 1, 6, IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock")))
                    '.set_TextMatrix(.Rows - 1, 7, IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit")))
                    '.set_TextMatrix(.Rows - 1, 13, IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct")))
                    '.set_TextMatrix(.Rows - 1, 8, IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price")))
                    '.set_TextMatrix(.Rows - 1, 9, Val(.get_TextMatrix(.Rows - 1, 8)) / Val(.get_TextMatrix(.Rows - 1, 13)))
                    '.set_TextMatrix(.Rows - 1, 10, Val(.get_TextMatrix(.Rows - 1, 8)) * Val(.get_TextMatrix(.Rows - 1, 4)))
                    '.set_TextMatrix(.Rows - 1, 11, IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock")))
                    '.set_TextMatrix(.Rows - 1, 12, IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock")))

                End With
            Next
            dgDetail.RowCount = dgDetail.RowCount - 1

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub fgSelectItem_KeyPressEvent(ByVal sender As Object, ByVal e As AxVSFlex7L._IVSFlexGridEvents_KeyPressEvent)
    '    'gbSelectItem.Visible = False
    '    'gbMain.Enabled = True
    '    'DirectFillItemGrid()
    '    'gbSelectItem.Visible = False
    '    'gbSelectItem.SendToBack()
    '    'fgDetail.Row = fgDetail.Rows - 1
    '    'fgDetail.Col = 4
    '    'fgDetail.EditCell()
    'End Sub
    Private Sub DirectFillItemGrid()
        Dim ItemCode As String
        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim StrQuery As String
        Dim blnAdd As Boolean


        Try
            'ItemCode = fgSelectItem.get_TextMatrix(fgSelectItem.RowSel, 1)
            'CODE = fgSelectItem.get_TextMatrix(fgSelectItem.RowSel, 1)
            With dgSelectItem
                If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                    ItemCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    CODE = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                Else

                    ItemCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    CODE = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString

                End If
            End With

            StrQuery = "SELECT * from ItemMaster WHERE  itemcode='" & ItemCode & "' order by itemname"
            da = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            ds.Clear()
            da.Fill(ds, "ItemList")


            blnAdd = False
            For i = 0 To dgDetail.RowCount - 1
                If Trim(dgDetail.Rows(i).Cells(1).Value) = ItemCode Then
                    blnAdd = True
                End If
            Next
            'For i = 1 To fgDetail.Rows - 1
            '    If Trim(fgDetail.get_TextMatrix(i, 1)) = ItemCode Then
            '        blnAdd = True
            '    End If
            'Next
            ItemCode = ""

            If blnAdd = False Then
                dgDetail.RowCount = dgDetail.RowCount + 1
                For iRow = 0 To ds.Tables("ItemList").Rows.Count - 1
                    drDisplay = ds.Tables("ItemList").Rows(iRow)
                    With dgDetail
                        .RowCount = .RowCount + 1
                        .Rows(.RowCount - 2).Cells(0).Value = .RowCount - 1
                        .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode"))
                        .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName"))
                        .Rows(.RowCount - 2).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category"))

                        .Rows(.RowCount - 2).Cells(11).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), "", drDisplay.Item("CurrentStock"))
                        .Rows(.RowCount - 2).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit"))
                        .Rows(.RowCount - 2).Cells(12).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                        .Rows(.RowCount - 2).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit"))
                        .Rows(.RowCount - 2).Cells(13).Value = IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct"))
                        .Rows(.RowCount - 2).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price"))
                        .Rows(.RowCount - 2).Cells(9).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) / Val(.Rows(.RowCount - 2).Cells(13).Value)













                        ''.Rows = .Rows + 1
                        ''.set_TextMatrix(.Rows - 1, 0, .Rows - 1)
                        ''.set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode")))
                        ''.set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName")))
                        ''.set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category")))
                        ' ''FillStock()
                        ''.set_TextMatrix(.Rows - 1, 11, IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock")))
                        '.set_TextMatrix(.Rows - 1, 5, IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit")))
                        '.set_TextMatrix(.Rows - 1, 12, IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock")))
                        '.set_TextMatrix(.Rows - 1, 7, IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit")))
                        '.set_TextMatrix(.Rows - 1, 13, IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct")))
                        '.set_TextMatrix(.Rows - 1, 8, IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price")))

                        '.set_TextMatrix(.Rows - 1, 9, Val(.get_TextMatrix(.Rows - 1, 8)) / Val(.get_TextMatrix(.Rows - 1, 13)))

                    End With
                Next
                dgDetail.RowCount = dgDetail.RowCount - 1
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearch.SelectedIndexChanged
        lblRow.Text = cboSearch.Text
        txtSearch.Text = ""
        txtSearch.Focus()
    End Sub
    Private Sub cboSearch_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearch.TabIndexChanged
        txtSearch.Text = ""
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
            If cboSearch.SelectedIndex = 0 Then
                dv = New DataView(ds.Tables(0), "ChallanNo Like '" & Trim(txtSearch.Text) & "*" & "'", "ChallanNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 1 Then
                dv = New DataView(ds.Tables(0), True, "ChallanDate", DataViewRowState.CurrentRows)
                'dv = New DataView(ds.Tables(0), "ChallanDate '" & Trim(txtSearch.Text) & "*" & "'", "ChallanNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 2 Then
                dv = New DataView(ds.Tables(0), "CustomerName Like '" & Trim(txtSearch.Text) & "*" & "'", "ChallanNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 3 Then
                dv = New DataView(ds.Tables(0), "RefNo Like '" & Trim(txtSearch.Text) & "*" & "'", "ChallanNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 4 Then
                dv = New DataView(ds.Tables(0), "Totalvalue Like '" & Trim(txtSearch.Text) & "*" & "'", "ChallanNo", DataViewRowState.CurrentRows)
            Else
                dv = New DataView(ds.Tables(0), "CustomerName Like '" & Trim(txtSearch.Text) & "*" & "'", "ChallanNo", DataViewRowState.CurrentRows)
            End If
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("ChallanNo")), "", dTable.Rows(i).Item("ChallanNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(dTable.Rows(i).Item("ChallanDate"))), "", convertToServerDateFormat(dTable.Rows(i).Item("ChallanDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("CustomerName")), "", dTable.Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("RefNo")), "", dTable.Rows(i).Item("RefNo"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("Totalvalue")), "", dTable.Rows(i).Item("Totalvalue"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub cboSearchCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchCustomer.SelectedIndexChanged
        lblRowSearch.Text = cboSearchCustomer.Text
        txtSearchCustomer.Text = ""
        txtSearchCustomer.Focus()
    End Sub
    Private Sub cboSearchCustomer_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchCustomer.TabIndexChanged
        txtSearchCustomer.Text = ""
    End Sub
    Private Sub txtSearchCustomer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchCustomer.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub txtSearchCustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchCustomer.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try
            If cboSearchCustomer.SelectedIndex = 0 Then
                dv = New DataView(ds1.Tables(0), "CustomerCode Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 1 Then
                dv = New DataView(ds1.Tables(0), "CustomerName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 2 Then
                dv = New DataView(ds1.Tables(0), "Address Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 3 Then
                dv = New DataView(ds1.Tables(0), "CityName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 4 Then
                dv = New DataView(ds1.Tables(0), "StateName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 5 Then
                dv = New DataView(ds1.Tables(0), "PINCode Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            Else
                dv = New DataView(ds1.Tables(0), "CustomerName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            End If
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("CustomerCode")), "", dTable.Rows(i).Item("CustomerCode"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("CustomerName")), "", dTable.Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("Address")), "", dTable.Rows(i).Item("Address"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("CityName")), "", dTable.Rows(i).Item("CityName"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("StateName")), "", dTable.Rows(i).Item("StateName"))

                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("PINCode")), "", dTable.Rows(i).Item("PINCode"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub txtRemarks_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRemarks.LostFocus
        txtVehicleNo.Focus()
    End Sub
    Private Sub txtPONo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPONo.LostFocus
        dtpDate.Focus()
    End Sub
    Private Sub chkQuotation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkQuotation.Click
        If chkQuotation.Checked = True Then
            Quotation = 1
            ClearControl()

            cmdSearchCustomer.Enabled = True
            txtCustomerName.ReadOnly = True
            txtAddress.ReadOnly = True
            txtCustomerName.Text = ""
            txtAddress.Text = ""
            CustomerCode = ""

        Else
            Quotation = 0
        End If
    End Sub

    Private Sub cboSearchItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchItem.SelectedIndexChanged
        lblName.Text = cboSearchItem.Text
        txtSearchItemName.Text = ""
        txtSearchItemName.Focus()

        If chkQuotation.Checked = True Then
            txtQuotationNo.Text = ""
            dgDetail.RowCount = 0
            'fgDetail.Rows = 1
            FillSearchGridInfoForQuotation()
            FillGridQuotation()
            gbQuotation.Visible = False
        Else

            FillSearchGridInfo()
            FillGridItem()
            gbQuotation.Visible = True
        End If
    End Sub

   
    Private Sub dgSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.DoubleClick
        With dgSearch
            If Search = 0 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                        txtChallanNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtChallanNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtChallanNo.Text)
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                End If
            ElseIf Search = 1 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                        CustomerCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtCustomerName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSearch(4, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSearch(5, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & "  " & dgSearch(6, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                    Else
                        CustomerCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtCustomerName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSearch(4, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSearch(5, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & "  " & dgSearch(6, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    txtRefNo.Focus()
                End If
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

    Private Sub dgSelectItem_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellContentClick
        Dim IntCount As Integer
        Dim intSelectedRow As Integer
        Dim i As Integer
        Dim blnAdd As Boolean
        Dim ch1 As DataGridViewCheckBoxCell
        ch1 = New DataGridViewCheckBoxCell()
        ch1 = dgSelectItem.Rows(dgSelectItem.CurrentRow.Index).Cells(0)

        If e.ColumnIndex <> 0 Then
            dgSelectItem.EditMode = DataGridViewEditMode.EditProgrammatically
            Exit Sub
        Else
            dgSelectItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If


        Try
            'intSelectedRow = fgSelectItem.Row
            With dgSelectItem
                If e.ColumnIndex = 0 Then
                    If ch1.EditingCellFormattedValue = "True" Then

                        blnAdd = False
                        'For i = 1 To fgSelectedItem.Rows - 1
                        '    If .get_TextMatrix(intSelectedRow, 1) = fgSelectedItem.get_TextMatrix(i, 1) Then
                        '        blnAdd = True
                        '    End If
                        'Next
                        If blnAdd = False Then

                            dgSelectedItem.RowCount = dgSelectedItem.RowCount + 1
                            i = dgSelectedItem.RowCount - 1

                            dgSelectedItem.Rows(i).Cells(0).Value = True
                            dgSelectedItem.Rows(i).Cells(1).Value = .Rows(e.RowIndex).Cells(1).Value
                            dgSelectedItem.Rows(i).Cells(2).Value = .Rows(e.RowIndex).Cells(2).Value

                            dgSelectedItem.Rows(i).Cells(3).Value = .Rows(e.RowIndex).Cells(3).Value
                            dgSelectedItem.Rows(i).Cells(4).Value = .Rows(e.RowIndex).Cells(4).Value
                            dgSelectedItem.Rows(i).Cells(5).Value = .Rows(e.RowIndex).Cells(5).Value
                            dgSelectedItem.Rows(i).Cells(6).Value = .Rows(e.RowIndex).Cells(6).Value
                            dgSelectedItem.Rows(i).Cells(7).Value = .Rows(e.RowIndex).Cells(7).Value
                            dgSelectedItem.Rows(i).Cells(8).Value = .Rows(e.RowIndex).Cells(8).Value
                            dgSelectedItem.Rows(i).Cells(9).Value = .Rows(e.RowIndex).Cells(9).Value



                        End If
                    Else
                        For IntCount = 0 To dgSelectedItem.RowCount - 1
                            If dgSelectedItem.Rows(IntCount).Cells(1).Value = .Rows(.CurrentRow.Index).Cells(1).Value.ToString Then
                                dgSelectedItem.Rows.Remove(dgSelectedItem.Rows(IntCount))

                                Exit For
                            End If
                        Next
                    End If

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSelectItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellEnter
        If e.ColumnIndex <> 0 Then
            dgSelectItem.EditMode = DataGridViewEditMode.EditProgrammatically

        Else
            dgSelectItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If
    End Sub

    Private Sub dgSelectItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSelectItem.DoubleClick
        With dgSelectItem
            If chkQuotation.Checked = True Then
                If dgSelectItem.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSelectItem.SendToBack()
                    Exit Sub
                Else
                    DirectFillQuotationDetail()
                    txtQuotationNo.Text = .Rows(.CurrentRow.Index).Cells(1).Value
                    intDGSearchKeayPress = 0
                    gbMain.BringToFront()
                    gbSelectItem.SendToBack()
                End If
                'ElseIf AddItem = 2 Then
                '    If dgSelectItem.RowCount = 0 Then
                '        MessageBox.Show("No Record Found")
                '        gbMain.BringToFront()
                '        gbSelectItem.SendToBack()
                '        Exit Sub
                '    Else
                '        If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                '            CustomerCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                '            txtCustomerName.Text = dgSelectItem(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                '            txtAddress.Text = dgSelectItem(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSelectItem(4, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSelectItem(5, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSelectItem(6, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                '        Else
                '            CustomerCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                '            txtCustomerName.Text = dgSelectItem(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                '            txtAddress.Text = dgSelectItem(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSelectItem(4, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSelectItem(5, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSelectItem(6, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                '        End If
                '        intDGSearchKeayPress = 0
                '        cboQuotationVersion.Focus()
                '        gbMain.BringToFront()
                '        gbSelectItem.SendToBack()
                '    End If
            Else
                If dgSelectItem.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSelectItem.SendToBack()
                    Exit Sub
                Else
                    DirectFillItemGrid()
                    intDGSearchKeayPress = 0
                    gbMain.BringToFront()
                    gbSelectItem.SendToBack()
                End If
            End If

        End With
    End Sub

    Private Sub dgDetail_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEndEdit
        Dim amount As Decimal



        With dgDetail
            If e.ColumnIndex = 4 Then
                .Rows(.CurrentRow.Index).Cells(6).Value = Val(.Rows(.CurrentRow.Index).Cells(4).Value) * Val(.Rows(.CurrentRow.Index).Cells(13).Value)

            ElseIf e.ColumnIndex = 6 Then
                .Rows(.CurrentRow.Index).Cells(4).Value = Val(.Rows(.CurrentRow.Index).Cells(6).Value) / Val(.Rows(.CurrentRow.Index).Cells(13).Value)

            End If


            If e.ColumnIndex = 8 Then
                .Rows(.CurrentRow.Index).Cells(9).Value = Val(.Rows(.CurrentRow.Index).Cells(8).Value) / Val(.Rows(.CurrentRow.Index).Cells(13).Value)

            ElseIf e.ColumnIndex = 9 Then
                .Rows(.CurrentRow.Index).Cells(8).Value = Val(.Rows(.CurrentRow.Index).Cells(9).Value) * Val(.Rows(.CurrentRow.Index).Cells(13).Value)

            End If
            .Rows(.CurrentRow.Index).Cells(10).Value = Val(.Rows(.CurrentRow.Index).Cells(4).Value) * Val(.Rows(.CurrentRow.Index).Cells(8).Value)



            For i = 0 To .RowCount - 1
                amount = amount + Val(.Rows(i).Cells(10).Value)
            Next

        End With
    End Sub

    Private Sub dgDetail_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEnter
        If bln_AddOn = True Or bln_EditOn = True Then
            With dgDetail

                If e.ColumnIndex = 4 Or e.ColumnIndex = 6 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Or e.ColumnIndex = 14 Then
                    dgDetail.EditMode = DataGridViewEditMode.EditOnEnter
                Else
                    dgDetail.EditMode = DataGridViewEditMode.EditProgrammatically
                End If
            End With
        End If
    End Sub

    Private Sub dgSelectedItem_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectedItem.CellContentClick
        Dim IntCount As Integer
        Dim intSelectedRow As Integer
        Dim i As Integer
        Dim Code As String
        Dim ch1 As DataGridViewCheckBoxCell
        ch1 = New DataGridViewCheckBoxCell()
        ch1 = dgSelectedItem.Rows(dgSelectedItem.CurrentRow.Index).Cells(0)

        If e.ColumnIndex <> 0 Then
            dgSelectedItem.EditMode = DataGridViewEditMode.EditProgrammatically
            Exit Sub
        Else
            dgSelectedItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If


        Try

            With dgSelectedItem
                If e.ColumnIndex = 0 Then
                    If ch1.EditingCellFormattedValue = "False" Then

                        If dgSelectedItem.RowCount > 0 Then
                            Code = dgSelectedItem.Rows(.CurrentRow.Index).Cells(1).Value
                            dgSelectedItem.Rows.Remove(dgSelectedItem.CurrentRow)

                        Else
                            Exit Sub

                        End If
                    Else
                        Exit Sub
                    End If
                    For IntCount = 0 To dgSelectItem.RowCount - 1
                        If dgSelectItem.Rows(IntCount).Cells(1).Value = Code Then
                            dgSelectItem.Rows(IntCount).Cells(0).Value = False
                            Exit For
                        End If
                    Next
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSelectedItem_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectedItem.CellContentDoubleClick
        Dim IntCount As Integer
        Dim intSelectedRow As Integer
        Dim i As Integer
        Dim Code As String
        Dim ch1 As DataGridViewCheckBoxCell
        ch1 = New DataGridViewCheckBoxCell()
        ch1 = dgSelectedItem.Rows(dgSelectedItem.CurrentRow.Index).Cells(0)

        If e.ColumnIndex <> 0 Then
            dgSelectedItem.EditMode = DataGridViewEditMode.EditProgrammatically
            Exit Sub
        Else
            dgSelectedItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If


        Try

            With dgSelectedItem
                If e.ColumnIndex = 0 Then
                    If ch1.EditingCellFormattedValue = "False" Then

                        If dgSelectedItem.RowCount > 0 Then
                            Code = dgSelectedItem.Rows(.CurrentRow.Index).Cells(1).Value
                            dgSelectedItem.Rows.Remove(dgSelectedItem.CurrentRow)

                        Else
                            Exit Sub

                        End If
                    Else
                        Exit Sub
                    End If
                    For IntCount = 0 To dgSelectItem.RowCount - 1
                        If dgSelectItem.Rows(IntCount).Cells(1).Value = Code Then
                            dgSelectItem.Rows(IntCount).Cells(0).Value = False
                            Exit For
                        End If
                    Next
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSelectedItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectedItem.CellEnter
        If e.ColumnIndex <> 0 Then
            dgSelectedItem.EditMode = DataGridViewEditMode.EditProgrammatically

        Else
            dgSelectedItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If
    End Sub

    Private Sub dgSelectItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSelectItem.KeyPress
        Dim e1 As System.EventArgs
        If (e.KeyChar = Convert.ToChar(13)) Then
            intDGSearchKeayPress = 1
            dgSelectItem_DoubleClick(sender, e1)

        End If
    End Sub
End Class
