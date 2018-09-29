Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmSaleInvoice1
    Dim CrRepDoc As New ReportDocument
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim CustomerCode As String
    Dim SearchCustomer As Integer
    Dim CashManual As Integer
    Dim CashParty As Integer
    Dim ByQuotation As Integer
    Dim ByChallan As Integer
    Dim Approve As Integer
    Dim LocalityCode As String
    Dim Stock As Decimal
    Dim subStock As Decimal
    Dim CODE As String
    Dim PaymentCode As String
    Dim AddItem As Integer

    Dim search As Integer
    Dim intDGSearchKeayPress As Integer
    Dim da1 As New SqlClient.SqlDataAdapter  'Global Data adapter for Search in dgSearch
    Dim ds1 As New DataSet
    Dim da2 As New SqlClient.SqlDataAdapter   'Global Data adapter for Search  dgSearchItem
    Dim ds2 As New DataSet

    Private Sub frmSaleInvoice1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        SaleInvoice1 = Nothing
    End Sub

    Private Sub frmSaleInvoice1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmSaleInvoice1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbMain.BringToFront()
        DesignGridSelectItem()
        DesignGrid()
        ENABLECONTROL(True)
        Display()
    End Sub
    Private Sub ENABLECONTROL(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status
        cmdSearch.Enabled = status
        cmdSearchCustomer.Enabled = Not status
        cmdPayment.Enabled = Not status
        cmdAddItem.Enabled = Not status
        cmdDelItem.Enabled = Not status
        cmdAddTerms.Enabled = Not status
        CmdDelTerms.Enabled = Not status

        cmdOverhead.Enabled = Not status
        chkcashManual.Enabled = Not status
        chkCashParty.Enabled = Not status
        chkChallan.Enabled = Not status
        chkQuotation.Enabled = Not status

        txtGRNo.ReadOnly = status
        txtPONo.ReadOnly = status
        txtVehicleNo.ReadOnly = status
        txtInvoiceNo.ReadOnly = status
        txtSaleInvoiceNo.ReadOnly = True
        txtRemarks.ReadOnly = status
        txtCustomerName.ReadOnly = True
        txtChallanNo.ReadOnly = True
        txtNetValue.ReadOnly = True
        txttotalvalue.ReadOnly = True
        txtConfigCode.ReadOnly = True
        txtSaleInvoiceDate.ReadOnly = True
        txtAddress.ReadOnly = True
        txtAdvance.ReadOnly = status

        If cmdSave.Enabled = True Then
            dtpDate.BringToFront()
            txtSaleInvoiceDate.SendToBack()
            cmdApprove.Enabled = False
        Else
            dtpDate.SendToBack()
            txtSaleInvoiceDate.BringToFront()
            cmdApprove.Enabled = True
        End If

        If gl_EmpName = "administrator" Then
            cmdApprove.Visible = True
        Else
            cmdApprove.Visible = False
        End If


    End Sub
    Private Sub ClearControl()
        txtInvoiceNo.Text = ""
        txtGRNo.Text = ""
        txtPONo.Text = ""
        txtPaymentTerms.Text = ""
        txtVehicleNo.Text = ""
        txtChallanNo.Text = ""
        txtRemarks.Text = ""
        txtConfigCode.Text = ""
        txtConfigurationRemarks.Text = ""
        txtNetValue.Text = ""
        txttotalvalue.Text = ""
        txtAddress.Text = ""
        cmdApprove.Text = "Approve"
        txtCustomerName.Text = ""
        dgDetail.RowCount = 0
        dgConfiguration.RowCount = 0
        txtAdvance.Text = 0
        txtBalanceValue.Text = 0
        dgConditions.RowCount = 0
        CashManual = 0
        CashParty = 0
        ByChallan = 0
        FillOverHeadDetails("None")
        Cal()
    End Sub
    Private Sub DesignGrid()

        With dgDetail
            .RowCount = 1
            .ColumnCount = 17
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 150
            .Columns(3).Name = "Category"
            .Columns(3).Width = 90
            .Columns(4).Name = "Qty"
            .Columns(4).Width = 60
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 60

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

            .Columns(9).Name = "Rate/Unit"
            .Columns(9).Width = 80
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).Visible = False

            .Columns(10).Name = "Amount"
            .Columns(10).Width = 90
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).Name = "Stock"
            .Columns(11).Width = 80
            .Columns(11).Visible = False
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(12).Name = "S.Stock"
            .Columns(12).Width = 80
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(12).Visible = False

            .Columns(13).Name = "ConvFact"
            .Columns(13).Width = 80
            .Columns(13).Visible = False

            .Columns(14).Name = "ChallanNo"
            .Columns(14).Width = 60
            .Columns(14).Visible = False

            .Columns(15).Name = "RefNo"
            .Columns(15).Width = 60
            .Columns(15).Visible = False

            .Columns(16).Name = "Remarks"
            .Columns(16).Width = 150
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

        With dgConditions

            .RowCount = 1
            .ColumnCount = 3
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Code"
            .Columns(1).Width = 80
            .Columns(2).Name = "Description"
            .Columns(2).Width = 730
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

        With dgConfiguration
            .RowCount = 1
            .ColumnCount = 9
            .Columns(0).Name = "Description"
            .Columns(0).Width = 100
            .Columns(1).Name = "Code"
            .Columns(1).Width = 60
            .Columns(2).Name = "+/-"
            .Columns(2).Width = 60
            .Columns(3).Name = "%age"
            .Columns(3).Width = 60
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).Name = "Amount"
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).Name = "TotalAmount"
            .Columns(5).Width = 100
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).Name = "CalculatedOn"
            .Columns(6).Width = 120
            .Columns(7).Name = "Remarks"
            .Columns(7).Width = 100
            .Columns(8).Name = "S#"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).Width = 60

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

        With dgConfigSearch
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Name = "Description"
            .Columns(0).Width = 60
            .Columns(1).Name = "Code"
            .Columns(1).Width = 60
            .Columns(2).Name = "+/-"
            .Columns(2).Width = 40
            .Columns(3).Name = "%age"
            .Columns(3).Width = 60
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).Name = "Calculation"
            .Columns(4).Width = 100
            .Columns(5).Name = "CalcOnCode"
            .Columns(5).Width = 100
            .Columns(6).Name = "S#"
            .Columns(6).Width = 90
            .Columns(7).Name = "Serial"
            .Columns(7).Width = 60
            .Columns(8).Name = "Lvl"
            .Columns(8).Width = 60
            .Columns(9).Name = "ConfigCode"
            .Columns(9).Width = 90
            .Columns(9).Visible = False
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

    End Sub
    Private Sub DesignGridSelectItem()
        Dim chkBox1 As New DataGridViewCheckBoxColumn()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns.Insert(0, chkBox1)
            .Columns(0).Width = 60
            chkBox1.Name = "Select"
            .Columns(0).Visible = True

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
            .Columns(0).Visible = True

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

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ENABLECONTROL(False)
        cmdApprove.Enabled = False
        bln_AddOn = True
        bln_EditOn = False

        txtSaleInvoiceNo.Text = showCode("Sale")


        ClearControl()
        dtpDate.Value = Now
        chkcashManual.Checked = True
        chkCashParty.Checked = False
        chkChallan.Checked = False
        chkQuotation.Checked = False
        CashManual = 1
        CashParty = 0
        ByChallan = 0
        ByQuotation = 0
        txtCustomerName.Text = "Cash"


        dtpDate.Focus()

        gbSearch.SendToBack()
        gbSelectItem.SendToBack()
        gbConfigSearch.SendToBack()
        cmdSearchCustomer.Enabled = False
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        ENABLECONTROL(False)
        cmdApprove.Enabled = False
        bln_EditOn = True
        bln_AddOn = False
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub
    Private Sub Cancel()
        If MsgQuestion("CANCEL") = 7 Then


            Exit Sub
        End If
        If bln_AddOn = True Then
            Call Display()
        Else
            Call Display(txtSaleInvoiceNo.Text)
        End If
        Call ENABLECONTROL(True)

        bln_AddOn = False
        bln_EditOn = False

        cmdApprove.Enabled = True

    End Sub
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

        With dgDetail
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells(8).Value) = 0 Or Val(.Rows(i).Cells(9).Value) = 0 Then
                    f_strDataCheck = "Rate"
                    .CurrentCell = .Item(8, i)

                    f_blnCheckData = True
                    checkData1 = True
                    Exit Function
                End If
            Next



            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells(4).Value) = 0 Or Val(.Rows(i).Cells(6).Value) = 0 Then
                    f_strDataCheck = "Qty"
                    .CurrentCell = .Item(4, i)
                    f_blnCheckData = True
                    checkData1 = True
                    Exit Function
                End If
            Next


        End With



        checkData1 = f_blnCheckData
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
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
        Dim TC As Integer

        Try

            If txtCustomerName.Text = "" Then
                MsgBox("Please Select Customer Name")
                Exit Sub
            End If

            If dgDetail.RowCount = 0 Then
                MsgBox("Please Select Atleast One Item")
                Exit Sub
            End If

            If dgConfiguration.RowCount = 0 Then
                MsgBox("Please Select Any OverHead")
                Exit Sub
            End If


            checkData1()
            If checkData1() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            End If

            If dgConditions.RowCount = 0 Then
                TC = 0
            Else
                TC = 1
            End If


            If bln_AddOn = True Then


                If MsgQuestion("SAVE") = 6 Then

                    str1 = "Insert into SaleMaster(SaleInvoiceNo,SaleDate,InvoiceNo, ChallanNo, CustomerCode,Remarks,NetValue,TotalValue,Advance,BalanceValue,ConfigurationCode,VehicleNo,GRNo,PONo,PaymentCode,CashManual,CashParty,ByChallan,ByQuotation,CustomerName1,Address1,Approve,TC) values('" & txtSaleInvoiceNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & txtInvoiceNo.Text & "', '" & txtChallanNo.Text & "','" & CustomerCode & "','" & Replace(txtRemarks.Text, "'", "''") & "'," & Val(txtNetValue.Text) & "," & Val(txttotalvalue.Text) & "," & Val(txtAdvance.Text) & "," & Val(txtBalanceValue.Text) & ",'" & Replace(txtConfigCode.Text, "'", "''") & "','" & txtVehicleNo.Text & "','" & txtGRNo.Text & "','" & txtPONo.Text & "','" & PaymentCode & "'," & CashManual & "," & CashParty & "," & ByChallan & "," & ByQuotation & ",'" & txtCustomerName.Text & "','" & txtAddress.Text & "',0," & TC & ")"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    With dgDetail
                        For i = 0 To .RowCount - 1
                            If chkChallan.Checked = True Or chkQuotation.Checked = True Then
                                str1 = "Insert into SaleDetail(SaleInvoiceNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,ChallanNo,Remark) values('" & txtSaleInvoiceNo.Text & "','" & (.Rows(i).Cells(1).Value) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & "," & Val(.Rows(i).Cells(11).Value) & "," & Val(.Rows(i).Cells(12).Value) & ",'" & (.Rows(i).Cells(14).Value) & "','" & (.Rows(i).Cells(16).Value) & "')"
                            Else
                                str1 = "Insert into SaleDetail(SaleInvoiceNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,ChallanNo,Remark) values('" & txtSaleInvoiceNo.Text & "','" & (.Rows(i).Cells(1).Value) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & "," & Val(.Rows(i).Cells(11).Value) & "," & Val(.Rows(i).Cells(12).Value) & ",'','" & (.Rows(i).Cells(16).Value) & "')"
                            End If

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                    End With


                    For i = 0 To dgConditions.RowCount - 1
                        str1 = "Insert into SaleTermsAndConditions(SaleInvoiceNo,SNo,TCCode) values('" & txtSaleInvoiceNo.Text & "','" & (dgConditions.Rows(i).Cells(0).Value) & "','" & (dgConditions.Rows(i).Cells(1).Value) & "')"


                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()
                    Next




                    str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='Sale'"


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()

                    'FillStock()

                    Call Display(Trim(txtSaleInvoiceNo.Text))
                    bln_AddOn = False
                    bln_EditOn = False
                    Call cmdApprove_Click(sender, e)
                End If
            ElseIf bln_EditOn = True Then
                If MsgQuestion("UPDATE") = 6 Then


                    str1 = "update SaleMaster set SaleDate='" & convertToServerDateFormat(dtpDate.Value) & "',InvoiceNo='" & txtInvoiceNo.Text & "', ChallanNo='" & txtChallanNo.Text & "',CustomerCode='" & CustomerCode & "', Remarks='" & Replace(txtRemarks.Text, "'", "''") & "',NetValue=" & Val(txtNetValue.Text) & ",TotalValue=" & Val(txttotalvalue.Text) & ",Advance=" & Val(txtAdvance.Text) & ",BalanceValue=" & Val(txtBalanceValue.Text) & ",ConfigurationCode='" & (txtConfigCode.Text) & "',VehicleNo='" & txtVehicleNo.Text & "',GRNo='" & txtGRNo.Text & "',PONo='" & txtPONo.Text & "',PaymentCode='" & PaymentCode & "',CashManual=" & CashManual & ",CashParty=" & CashParty & ",ByChallan=" & ByChallan & ",ByQuotation=" & ByQuotation & ",CustomerName1='" & txtCustomerName.Text & "',Address1='" & txtAddress.Text & "',Approve=0,TC=" & TC & " where SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "'"

                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    str1 = "Delete From SaleDetail where SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "'"
                    ComSave = New SqlClient.SqlCommand(str1, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()




                    With dgDetail
                        For i = 0 To .RowCount - 1
                            If chkChallan.Checked = True Or chkQuotation.Checked = True Then
                                str1 = "Insert into SaleDetail(SaleInvoiceNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,ChallanNo,Remark) values('" & txtSaleInvoiceNo.Text & "','" & (.Rows(i).Cells(1).Value) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & "," & Val(.Rows(i).Cells(11).Value) & "," & Val(.Rows(i).Cells(12).Value) & ",'" & (.Rows(i).Cells(14).Value) & "','" & (.Rows(i).Cells(16).Value) & "')"
                            Else
                                str1 = "Insert into SaleDetail(SaleInvoiceNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,ChallanNo,Remark) values('" & txtSaleInvoiceNo.Text & "','" & (.Rows(i).Cells(1).Value) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & "," & Val(.Rows(i).Cells(11).Value) & "," & Val(.Rows(i).Cells(12).Value) & ",'','" & (.Rows(i).Cells(16).Value) & "')"
                            End If

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                    End With


                    StrQuery = "Delete from SaleOverHeads where SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "'"

                    ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()

                    StrQuery = "Delete from SaleTermsAndConditions where SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "'"

                    ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()

                    With dgConfiguration
                        For i = 0 To .RowCount - 1
                            StrQuery = "Insert into SaleOverHeads(SaleInvoiceNo, Description, Code, PlusMinus, Percentage, Amount, TotalAmount, CalcOn ,Remarks,SNo ) Values('" & Replace(Trim(txtSaleInvoiceNo.Text), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(0).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(1).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(2).Value), "'", "''") & "'," & Val(.Rows(i).Cells(3).Value) & "," & Val(.Rows(i).Cells(4).Value) & "," & Val(.Rows(i).Cells(5).Value) & ",'" & Replace(Trim(.Rows(i).Cells(6).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(7).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(8).Value), "'", "''") & "')"
                            ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                            ComSave.CommandType = CommandType.Text
                            ComSave.Transaction = trn
                            ComSave.ExecuteNonQuery()
                        Next
                    End With


                    For i = 0 To dgConditions.RowCount - 1
                        str1 = "Insert into SaleTermsAndConditions(SaleInvoiceNo,SNo,TCCode) values('" & txtSaleInvoiceNo.Text & "','" & (dgConditions.Rows(i).Cells(0).Value) & "','" & (dgConditions.Rows(i).Cells(1).Value) & "')"


                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()
                    Next

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtSaleInvoiceNo.Text))
                    bln_AddOn = False
                    bln_EditOn = False
                    Call cmdApprove_Click(sender, e)
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

                str1 = "SELECT     SaleMaster.SaleInvoiceId, SaleMaster.Approve,SaleMaster.ByQuotation,  SaleMaster.SaleInvoiceNo, SaleMaster.SaleDate, SaleMaster.InvoiceNo,SaleMaster.Advance,SaleMaster.BalanceValue, SaleMaster.ChallanNo,  SaleMaster.Remarks, SaleMaster.NetValue, SaleMaster.TotalValue, SaleMaster.ConfigurationCode, SaleMaster.VehicleNo, SaleMaster.GRNo,SaleMaster.PONo, SaleDetail.ItemCode, SaleDetail.Remark, SaleDetail.Qty, SaleDetail.ChallanNo AS ChallanDetail, SaleDetail.SubQty, SaleDetail.Rate, SaleDetail.SubRate, SaleDetail.Amount, ItemMaster.ItemName, ItemMaster.MAke, ItemMaster.Unit, ItemMaster.ConvFAct,  ItemMaster.StoreUnit, ItemMaster.CurrentStock, ItemMaster.CurrentSubStock, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode,CustomerMaster1.CustomerName AS Expr1, CustomerMaster1.Address, SaleMaster.CashManual, SaleMaster.ByChallan, SaleMaster.CashParty,SaleMaster.CustomerName1, SaleMaster.Address1, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName,  StateMaster.StateName, LocalityMaster.PinCode, ChallanMaster.RefNo, SaleMaster.PaymentCode, PaymentTermMaster.Description FROM         SaleMaster INNER JOIN  SaleDetail ON SaleMaster.SaleInvoiceNo = SaleDetail.SaleInvoiceNo INNER JOIN ItemMaster ON SaleDetail.ItemCode = ItemMaster.ItemCode LEFT OUTER JOIN  PaymentTermMaster ON SaleMaster.PaymentCode = PaymentTermMaster.PaymentTermCode LEFT OUTER JOIN ChallanMaster ON SaleDetail.ChallanNo = ChallanMaster.ChallanNo LEFT OUTER JOIN CustomerMaster1 ON SaleMaster.CustomerCode = CustomerMaster1.CustomerCode LEFT OUTER JOIN LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode LEFT OUTER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode LEFT OUTER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode WHERE (SaleMaster.SaleInvoiceNo = (SELECT     MAX(SaleInvoiceNo) FROM          SaleMaster))"
            Else
                str1 = "SELECT     SaleMaster.SaleInvoiceId, SaleMaster.Approve,SaleMaster.ByQuotation, SaleMaster.SaleInvoiceNo, SaleMaster.SaleDate, SaleMaster.InvoiceNo, SaleMaster.Advance,SaleMaster.BalanceValue,SaleMaster.ChallanNo,  SaleMaster.Remarks, SaleMaster.NetValue, SaleMaster.TotalValue, SaleMaster.ConfigurationCode, SaleMaster.VehicleNo, SaleMaster.GRNo,SaleMaster.PONo, SaleDetail.ItemCode, SaleDetail.Remark, SaleDetail.Qty, SaleDetail.ChallanNo AS ChallanDetail, SaleDetail.SubQty, SaleDetail.Rate, SaleDetail.SubRate, SaleDetail.Amount, ItemMaster.ItemName, ItemMaster.MAke, ItemMaster.Unit, ItemMaster.ConvFAct,  ItemMaster.StoreUnit, ItemMaster.CurrentStock, ItemMaster.CurrentSubStock, CustomerMaster1.CustomerName, CustomerMaster1.CustomerCode,CustomerMaster1.CustomerName AS Expr1, CustomerMaster1.Address, SaleMaster.CashManual, SaleMaster.ByChallan, SaleMaster.CashParty,SaleMaster.CustomerName1, SaleMaster.Address1, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName,  StateMaster.StateName, LocalityMaster.PinCode, ChallanMaster.RefNo, SaleMaster.PaymentCode, PaymentTermMaster.Description FROM         SaleMaster INNER JOIN  SaleDetail ON SaleMaster.SaleInvoiceNo = SaleDetail.SaleInvoiceNo INNER JOIN ItemMaster ON SaleDetail.ItemCode = ItemMaster.ItemCode LEFT OUTER JOIN  PaymentTermMaster ON SaleMaster.PaymentCode = PaymentTermMaster.PaymentTermCode LEFT OUTER JOIN ChallanMaster ON SaleDetail.ChallanNo = ChallanMaster.ChallanNo LEFT OUTER JOIN CustomerMaster1 ON SaleMaster.CustomerCode = CustomerMaster1.CustomerCode LEFT OUTER JOIN LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode LEFT OUTER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode LEFT OUTER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode WHERE      (SaleMaster.SaleInvoiceNo=    '" & strMRqNo & "') "
            End If

            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "MR")

            If dsDS1.Tables("MR").Rows.Count > 0 Then
                CashParty = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CashParty")), 0, dsDS1.Tables("MR").Rows(0).Item("CashParty"))
                CashManual = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CashManual")), 0, dsDS1.Tables("MR").Rows(0).Item("CashManual"))
                ByChallan = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ByChallan")), 0, dsDS1.Tables("MR").Rows(0).Item("ByChallan"))
                ByQuotation = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ByQuotation")), 0, dsDS1.Tables("MR").Rows(0).Item("ByQuotation"))
                Approve = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Approve")), 0, dsDS1.Tables("MR").Rows(0).Item("Approve"))
                PaymentCode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PaymentCode")), "", dsDS1.Tables("MR").Rows(0).Item("PaymentCode"))
                If Approve = 1 Then
                    cmdApprove.Text = "Approved"
                    cmdEdit.Enabled = False
                Else
                    cmdApprove.Text = "Approve"
                    cmdEdit.Enabled = True
                End If
                CustomerCode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerCode")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerCode"))
                lblPrimaryKey.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("SaleInvoiceId")), "", dsDS1.Tables("MR").Rows(0).Item("SaleInvoiceId"))
                If CashManual = 1 Then
                    txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address1")), "", dsDS1.Tables("MR").Rows(0).Item("Address1"))
                    txtCustomerName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerName1")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerName1"))
                    chkcashManual.Checked = True
                    chkCashParty.Checked = False
                    chkChallan.Checked = False
                    chkQuotation.Checked = False
                ElseIf CashParty = 1 Then
                    txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address")), "", dsDS1.Tables("MR").Rows(0).Item("Address")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("LocalityName")), "", dsDS1.Tables("MR").Rows(0).Item("LocalityName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CityName")), "", dsDS1.Tables("MR").Rows(0).Item("CItyName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("StateName")), "", dsDS1.Tables("MR").Rows(0).Item("StateName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PINCode")), "", dsDS1.Tables("MR").Rows(0).Item("PINCode"))

                    txtCustomerName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerName")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerName"))
                    chkcashManual.Checked = False
                    chkCashParty.Checked = True
                    chkChallan.Checked = False
                    chkQuotation.Checked = False
                ElseIf ByChallan = 1 Then
                    txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address")), "", dsDS1.Tables("MR").Rows(0).Item("Address")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("LocalityName")), "", dsDS1.Tables("MR").Rows(0).Item("LocalityName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CityName")), "", dsDS1.Tables("MR").Rows(0).Item("CItyName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("StateName")), "", dsDS1.Tables("MR").Rows(0).Item("StateName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PINCode")), "", dsDS1.Tables("MR").Rows(0).Item("PINCode"))

                    txtCustomerName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerName")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerName"))
                    chkcashManual.Checked = False
                    chkCashParty.Checked = False
                    chkChallan.Checked = True
                    chkQuotation.Checked = False
                ElseIf ByQuotation = 1 Then
                    txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address")), "", dsDS1.Tables("MR").Rows(0).Item("Address")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("LocalityName")), "", dsDS1.Tables("MR").Rows(0).Item("LocalityName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CityName")), "", dsDS1.Tables("MR").Rows(0).Item("CItyName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("StateName")), "", dsDS1.Tables("MR").Rows(0).Item("StateName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PINCode")), "", dsDS1.Tables("MR").Rows(0).Item("PINCode"))

                    txtCustomerName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerName")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerName"))
                    chkcashManual.Checked = False
                    chkCashParty.Checked = False
                    chkChallan.Checked = False
                    chkQuotation.Checked = True
                Else
                    txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Address")), "", dsDS1.Tables("MR").Rows(0).Item("Address")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("LocalityName")), "", dsDS1.Tables("MR").Rows(0).Item("LocalityName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CityName")), "", dsDS1.Tables("MR").Rows(0).Item("CItyName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("StateName")), "", dsDS1.Tables("MR").Rows(0).Item("StateName")) & " " & IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PINCode")), "", dsDS1.Tables("MR").Rows(0).Item("PINCode"))

                    txtCustomerName.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("CustomerName")), "", dsDS1.Tables("MR").Rows(0).Item("CustomerName"))
                    chkcashManual.Checked = False
                    chkCashParty.Checked = False
                    chkChallan.Checked = False
                    chkQuotation.Checked = False
                End If
                LocalityCode = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("LocalityCode")), "", dsDS1.Tables("MR").Rows(0).Item("LocalityCode"))

                txtSaleInvoiceNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("SaleInvoiceNo")), "", dsDS1.Tables("MR").Rows(0).Item("SaleInvoiceNo"))
                txtPaymentTerms.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Description")), "", dsDS1.Tables("MR").Rows(0).Item("Description"))
                txtInvoiceNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("InvoiceNo")), "", dsDS1.Tables("MR").Rows(0).Item("InvoiceNo"))
                txtChallanNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ChallanNo")), "", dsDS1.Tables("MR").Rows(0).Item("ChallanNo"))
                dtpDate.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("SaleDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("SaleDate")))
                txtSaleInvoiceDate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("SaleDate"))), "", convertToServerDateFormat(dsDS1.Tables("MR").Rows(0).Item("SaleDate")))
                txtRemarks.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Remarks")), "", dsDS1.Tables("MR").Rows(0).Item("Remarks"))

                txtNetValue.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("NetValue")), 0, dsDS1.Tables("MR").Rows(0).Item("NetValue"))
                txttotalvalue.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Totalvalue")), 0, dsDS1.Tables("MR").Rows(0).Item("Totalvalue"))
                txtAdvance.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("Advance")), 0, dsDS1.Tables("MR").Rows(0).Item("Advance"))
                txtBalanceValue.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("BalanceValue")), 0, dsDS1.Tables("MR").Rows(0).Item("BalanceValue"))
                txtConfigCode.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("ConfigurationCode")), "", dsDS1.Tables("MR").Rows(0).Item("ConfigurationCode"))
                txtVehicleNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("VehicleNo")), "", dsDS1.Tables("MR").Rows(0).Item("VehicleNo"))
                txtGRNo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("GRNo")), "", dsDS1.Tables("MR").Rows(0).Item("GRNo"))
                txtPONo.Text = IIf(IsDBNull(dsDS1.Tables("MR").Rows(0).Item("PONo")), "", dsDS1.Tables("MR").Rows(0).Item("PONo"))

                dgDetail.RowCount = 1
                For i = 0 To dsDS1.Tables("MR").Rows.Count - 1
                    With dgDetail
                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ItemCode")), "", dsDS1.Tables("MR").Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ItemName")), "", dsDS1.Tables("MR").Rows(i).Item("ItemName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Make")), "", dsDS1.Tables("MR").Rows(i).Item("Make"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Qty")), 0, dsDS1.Tables("MR").Rows(i).Item("Qty"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Unit")), "", dsDS1.Tables("MR").Rows(i).Item("Unit"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubQty")), 0, dsDS1.Tables("MR").Rows(i).Item("SubQty"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubQty")), 0, dsDS1.Tables("MR").Rows(i).Item("SubQty"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Rate")), 0, dsDS1.Tables("MR").Rows(i).Item("Rate"))
                        .Rows(i).Cells(9).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("SubRate")), 0, dsDS1.Tables("MR").Rows(i).Item("SubRate"))
                        .Rows(i).Cells(10).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Amount")), 0, dsDS1.Tables("MR").Rows(i).Item("Amount"))
                        .Rows(i).Cells(11).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("CurrentStock")), 0, dsDS1.Tables("MR").Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(12).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("CurrentSubStock")), 0, dsDS1.Tables("MR").Rows(i).Item("CurrentSubStock"))
                        .Rows(i).Cells(13).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ConvFAct")), 0, dsDS1.Tables("MR").Rows(i).Item("ConvFAct"))
                        .Rows(i).Cells(16).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("Remark")), 0, dsDS1.Tables("MR").Rows(i).Item("Remark"))

                        If ByChallan = 1 Or ByQuotation = 1 Then
                            .Rows(i).Cells(14).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("ChallanDetail")), "", dsDS1.Tables("MR").Rows(i).Item("ChallanDetail"))
                            .Rows(i).Cells(15).Value = IIf(IsDBNull(dsDS1.Tables("MR").Rows(i).Item("RefNo")), "", dsDS1.Tables("MR").Rows(i).Item("RefNo"))
                        End If

                    End With
                Next
                dgDetail.RowCount = dgDetail.RowCount - 1

            End If


            daDA1.Dispose()
            dsDS1.Clear()

            str1 = "SELECT SaleOverHeads.SaleInvoiceNo, SaleOverHeads.Description,SaleOverHeads.Code, SaleOverHeads.PlusMinus, SaleOverHeads.Percentage, SaleOverHeads.Amount, SaleOverHeads.TotalAmount, SaleOverHeads.CalcOn,SaleOverHeads.Remarks,SaleOverHeads.SNo FROM SaleOverHeads WHERE (SaleOverHeads.SaleInvoiceNo= '" & txtSaleInvoiceNo.Text & "') "


            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "OverHead")

            If dsDS1.Tables("OverHead").Rows.Count > 0 Then

                dgConfiguration.RowCount = 1
                For i = 0 To dsDS1.Tables("OverHead").Rows.Count - 1
                    With dgConfiguration
                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Description")), "", dsDS1.Tables("OverHead").Rows(i).Item("Description"))
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Code")), "", dsDS1.Tables("OverHead").Rows(i).Item("Code"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("PlusMinus")), "", dsDS1.Tables("OverHead").Rows(i).Item("PlusMinus"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Percentage")), "", dsDS1.Tables("OverHead").Rows(i).Item("Percentage"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Amount")), 0, dsDS1.Tables("OverHead").Rows(i).Item("Amount"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("TotalAmount")), "", dsDS1.Tables("OverHead").Rows(i).Item("TotalAmount"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("CalcOn")), 0, dsDS1.Tables("OverHead").Rows(i).Item("CalcOn"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("Remarks")), "", dsDS1.Tables("OverHead").Rows(i).Item("Remarks"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("SNo")), "", dsDS1.Tables("OverHead").Rows(i).Item("SNo"))
                        txtTotalValue1.Text = IIf(IsDBNull(dsDS1.Tables("OverHead").Rows(i).Item("TotalAmount")), "", dsDS1.Tables("OverHead").Rows(i).Item("TotalAmount"))

                    End With
                Next
                dgConfiguration.RowCount = dgConfiguration.RowCount - 1
            End If

            daDA1.Dispose()
            dsDS1.Clear()


            str1 = "SELECT     SaleMaster.SaleInvoiceNo, SaleTermsAndConditions.SNO, TCMaster.Description, SaleTermsAndConditions.TCCode FROM         SaleTermsAndConditions INNER JOIN SaleMaster ON SaleTermsAndConditions.SaleInvoiceNo = SaleMaster.SaleInvoiceNo INNER JOIN  TCMaster ON SaleTermsAndConditions.TCCode = TCMaster.TCCode WHERE (SaleTermsAndConditions.SaleInvoiceNo= '" & txtSaleInvoiceNo.Text & "') "


            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "TermsAndConditions")
            dgConditions.RowCount = 1
            If dsDS1.Tables("TermsAndConditions").Rows.Count > 0 Then
                For i = 0 To dsDS1.Tables("TermsAndConditions").Rows.Count - 1
                    With dgConditions
                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = IIf(IsDBNull(dsDS1.Tables("TermsAndConditions").Rows(i).Item("SNO")), "", dsDS1.Tables("TermsAndConditions").Rows(i).Item("SNO"))
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("TermsAndConditions").Rows(i).Item("TCCode")), "", dsDS1.Tables("TermsAndConditions").Rows(i).Item("TCCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dsDS1.Tables("TermsAndConditions").Rows(i).Item("Description")), "", dsDS1.Tables("TermsAndConditions").Rows(i).Item("Description"))

                    End With
                Next
                dgConditions.RowCount = dgConditions.RowCount - 1
            Else
                dgConditions.RowCount = 0

            End If

            daDA1.Dispose()
            dsDS1.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim StrQuery As String
        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction
        Dim i As Integer

        Try

            If cmdApprove.Text = "Approve" Then
                If MsgQuestion("APPROVE") = 6 Then
                    trn = gl_Con.BeginTransaction
                    For i = 0 To dgDetail.RowCount - 1

                        str1 = "update ItemMaster set CurrentStock=CurrentStock-" & Val(dgDetail.Rows(i).Cells(4).Value) & ",CurrentSubStock=CurrentSubStock-" & Val(dgDetail.Rows(i).Cells(6).Value) & ",Price=" & Val(dgDetail.Rows(i).Cells(8).Value) & " where ItemCode='" & (dgDetail.Rows(i).Cells(1).Value.ToString) & "'"
                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()

                    Next



                    If chkcashManual.Checked = True Or chkCashParty.Checked = True Then
                        str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration,Cash) values('" & txtSaleInvoiceNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','CASH','SaleInvoice'," & Val(txttotalvalue.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "',1)"
                    Else
                        str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration,Cash) values('" & txtSaleInvoiceNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & CustomerCode & "','SaleInvoice'," & Val(txttotalvalue.Text) & ",0,'" & Replace(txtRemarks.Text, "'", "''") & "',0)"
                    End If


                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    If Val(txtAdvance.Text) > 0 Then
                        str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration,Cash) values('" & txtSaleInvoiceNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & CustomerCode & "','InvoiceAdvance',0," & Val(txtAdvance.Text) & ",'" & Replace(txtRemarks.Text, "'", "''") & "',1)"
                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()


                        str1 = "update CustomerMaster1 set Balance=Balance-" & Val(txtAdvance.Text) & " where CustomerCode='" & CustomerCode & "'"
                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()


                        str1 = "update SaleMaster set ReceivedAmount=" & Val(txtAdvance.Text) & " where SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "'"

                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()

                    End If





                    If chkChallan.Checked = True Then
                        For i = 0 To dgDetail.RowCount - 1

                            str1 = "update ChallanDetail set Invoice=1,SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "' where ChallanNo='" & (dgDetail.Rows(i).Cells(14).Value.ToString) & "' And ItemCode='" & (dgDetail.Rows(i).Cells(1).Value.ToString) & "'"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                    ElseIf chkQuotation.Checked = True Then
                        For i = 0 To dgDetail.RowCount - 1

                            str1 = "update QuotationDetail set Invoice=1,InvoiceNo='" & txtSaleInvoiceNo.Text & "' where QuotationNo='" & (dgDetail.Rows(i).Cells(14).Value.ToString) & "' And ItemCode='" & (dgDetail.Rows(i).Cells(1).Value.ToString) & "'"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next

                    End If

                    With dgConfiguration
                        For i = 0 To .RowCount - 1
                            If i = 0 Then
                                str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration) values('" & txtSaleInvoiceNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','SALE A/C','SaleInvoice',0,'" & Val(txtNetValue.Text) & "','" & Replace(txtRemarks.Text, "'", "''") & "')"
                            Else
                                If dgConfiguration.Rows(i).Cells(2).Value.ToString = "+" Then
                                    str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration) values('" & txtSaleInvoiceNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & dgConfiguration.Rows(i).Cells(0).Value & "','SaleInvoice',0,'" & Val(dgConfiguration.Rows(i).Cells(4).Value) & "','" & Replace(txtRemarks.Text, "'", "''") & "')"

                                Else
                                    str1 = "Insert into LEDGER(TransactionNo,TransactionDate,LedgerCode, TransactionType, Debit,Credit,Narration) values('" & txtSaleInvoiceNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & dgConfiguration.Rows(i).Cells(0).Value & "','SaleInvoice','" & Val(dgConfiguration.Rows(i).Cells(4).Value) & "',0,'" & Replace(txtRemarks.Text, "'", "''") & "')"
                                End If

                            End If

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()

                        Next
                    End With

                    str1 = "update SaleMaster set Approve=1 where SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    If chkcashManual.Checked = True And chkCashParty.Checked = True Then
                        str1 = "update CompanyMaster1 set CurrentBalance=CurrentBalance+" & Val(txttotalvalue.Text) & ""
                    Else
                        str1 = "update CustomerMaster1 set Balance=Balance+" & Val(txttotalvalue.Text) & " where CustomerCode='" & CustomerCode & "'"
                    End If

                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtSaleInvoiceNo.Text))

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
                    For i = 0 To dgDetail.RowCount - 1

                        str1 = "update ItemMaster set CurrentStock=CurrentStock+" & Val(dgDetail.Rows(i).Cells(4).Value) & ",CurrentSubStock=CurrentSubStock+" & Val(dgDetail.Rows(i).Cells(6).Value) & " where ItemCode='" & (dgDetail.Rows(i).Cells(1).Value.ToString) & "'"
                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()


                    Next

                    str1 = "update SaleMaster set Approve=0 where SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    If chkChallan.Checked = True Then
                        For i = 0 To dgDetail.RowCount - 1

                            str1 = "update ChallanDetail set Invoice=0,SaleInvoiceNo='' where ChallanNo='" & (dgDetail.Rows(i).Cells(14).Value) & "' And ItemCode='" & (dgDetail.Rows(i).Cells(1).Value.ToString) & "'"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                    ElseIf chkQuotation.Checked = True Then
                        For i = 0 To dgDetail.RowCount - 1

                            str1 = "update QuotationDetail set Invoice=0,InvoiceNo='' where QuotationNo='" & (dgDetail.Rows(i).Cells(14).Value) & "' And ItemCode='" & (dgDetail.Rows(i).Cells(1).Value.ToString) & "'"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next

                    End If


                    If Val(txtAdvance.Text) > 0 Then



                        str1 = "update CustomerMaster1 set Balance=Balance+" & Val(txtAdvance.Text) & " where CustomerCode='" & CustomerCode & "'"
                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()

                        str1 = "update SaleMaster set ReceivedAmount=ReceivedAmount-" & Val(txtAdvance.Text) & " where SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "'"

                        cmdCom1.Transaction = trn
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()


                    End If




                    StrQuery = "Delete from LEDGER where TransactionNo='" & Replace(Trim(txtSaleInvoiceNo.Text), "'", "''") & "'"
                    ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()

                    If chkcashManual.Checked = True And chkCashParty.Checked = True Then
                        str1 = "update CompanyMaster1 set CurrentBalance=CurrentBalance-" & Val(txttotalvalue.Text) & ""

                    Else
                        str1 = "update CustomerMaster1 set Balance=Balance-" & Val(txttotalvalue.Text) & " where CustomerCode='" & CustomerCode & "'"
                    End If

                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtSaleInvoiceNo.Text))
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

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
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
        fSalesReportViewer.Text = "Sale Invoice"
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

            'str1 = "Insert into Temp_Report(ReportNo) values('" & txtSaleInvoiceNo.Text & "')"
            'cmdCom1.Transaction = trn
            'cmdCom1.Connection = gl_Con
            'cmdCom1.CommandText = str1
            'cmdCom1.ExecuteNonQuery()

            'trn.Commit()


            If chkcashManual.Checked = True Then
                CrRepDoc.Load(Application.StartupPath & "\Report\rptInvoice_Manually1.rpt")
            Else
                CrRepDoc.Load(Application.StartupPath & "\Report\rptInvoice.rpt")
            End If


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
            strMRCode = "{SaleMaster.SaleInvoiceNo} = '" & Trim(txtSaleInvoiceNo.Text) & "'"
            fSalesReportViewer.CrystalReportViewer1.SelectionFormula = strMRCode
            fSalesReportViewer.CrystalReportViewer1.ReportSource = CrRepDoc
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Designgrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 7
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "SI No"
            .Columns(1).Width = 80
            .Columns(2).Name = "SI Date"
            .Columns(2).Width = 90
            .Columns(3).Name = "Curstomer Name"
            .Columns(3).Width = 250
            .Columns(4).Name = "InvoiceNo"
            .Columns(4).Width = 80
            .Columns(5).Name = "ChallanNo"
            .Columns(5).Width = 100
            .Columns(6).Name = "TotalValue"
            .Columns(6).Width = 200
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid1()
        da1.Dispose()
        ds1.Clear()
        search = 0

        Try

            StrQuery = "SELECT SaleMaster.SaleInvoiceNo, SaleMaster.SaleDate, CustomerMaster1.CustomerName, SaleMaster.InvoiceNo, SaleMaster.ChallanNo, SaleMaster.TotalValue FROM SaleMaster INNER JOIN CustomerMaster1 ON SaleMaster.CustomerCode = CustomerMaster1.CustomerCode order by SaleInvoiceNo"
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "SaleMaster")
            dgSearch.RowCount = 1
            If ds1.Tables("SaleMaster").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("SaleMaster").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("SaleMaster").Rows(i).Item("SaleInvoiceNo")), "", ds1.Tables("SaleMaster").Rows(i).Item("SaleInvoiceNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds1.Tables("SaleMaster").Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(ds1.Tables("SaleMaster").Rows(i).Item("SaleDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("SaleMaster").Rows(i).Item("CustomerName")), "", ds1.Tables("SaleMaster").Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds1.Tables("SaleMaster").Rows(i).Item("InvoiceNo")), "", ds1.Tables("SaleMaster").Rows(i).Item("InvoiceNo"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds1.Tables("SaleMaster").Rows(i).Item("ChallanNo")), "", ds1.Tables("SaleMaster").Rows(i).Item("ChallanNo"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds1.Tables("SaleMaster").Rows(i).Item("Totalvalue")), "", ds1.Tables("SaleMaster").Rows(i).Item("Totalvalue"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearch.Text = ""
            txtSearch.Focus()
            cboSearch.Text = ""
            lblRow.Text = "SI No"
            gbSearch.BringToFront()
            gbMain.SendToBack()
            gbSearchInvoice.BringToFront()
            gbSearchCustomer.SendToBack()

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
            .Columns(1).Width = 60
            .Columns(2).Name = "Customer Name"
            .Columns(2).Width = 230
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
    End Sub

    Private Sub cmdSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearchCustomer.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid2()
        da1.Dispose()
        ds1.Clear()
        search = 1

        Try
            StrQuery = "SELECT CustomerMaster1.CustomerCode, CustomerMaster1.CustomerName, CustomerMaster1.Address, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM ((CustomerMaster1 INNER JOIN LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode) INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode ORDER BY CustomerMaster1.CustomerName "
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "CustomerMaster")
            dgSearch.RowCount = 1
            If ds1.Tables("CustomerMaster").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("CustomerMaster").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("CustomerMaster").Rows(i).Item("CustomerCode")), "", ds1.Tables("CustomerMaster").Rows(i).Item("CustomerCode"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds1.Tables("CustomerMaster").Rows(i).Item("CustomerName")), "", ds1.Tables("CustomerMaster").Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("CustomerMaster").Rows(i).Item("Address")), "", ds1.Tables("CustomerMaster").Rows(i).Item("Address"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds1.Tables("CustomerMaster").Rows(i).Item("CityName")), "", ds1.Tables("CustomerMaster").Rows(i).Item("CityName"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds1.Tables("CustomerMaster").Rows(i).Item("StateName")), "", ds1.Tables("CustomerMaster").Rows(i).Item("StateName"))

                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds1.Tables("CustomerMaster").Rows(i).Item("PINCode")), "", ds1.Tables("CustomerMaster").Rows(i).Item("PINCode"))


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
            gbSearchCustomer.BringToFront()
            gbSearchInvoice.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DesignGrid3()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 3
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Code"
            .Columns(1).Width = 60
            .Columns(2).Name = "Description"
            .Columns(2).Width = 300

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
    End Sub

    Private Sub cmdPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPayment.Click
        Dim StrQuery As String
        Dim i As Integer
        DesignGrid3()
        da1.Dispose()
        ds1.Clear()
        search = 2

        Try
            StrQuery = "SELECT    PaymentTermCode, Description FROM PaymentTermMaster ORDER BY PaymentTermCode"
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "Payment")
            dgSearch.RowCount = 1
            If ds1.Tables("Payment").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("Payment").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("Payment").Rows(i).Item("PaymentTermCode")), "", ds1.Tables("Payment").Rows(i).Item("PaymentTermCode"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds1.Tables("Payment").Rows(i).Item("Description")), "", ds1.Tables("Payment").Rows(i).Item("Description"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            lblRowSearch.Text = "Description"
            txtSearchDescription.Text = ""
            txtSearchDescription.Focus()
            gbSearch.BringToFront()
            gbSearchInvoice.SendToBack()
            gbSearchCustomer.SendToBack()
            gbPayment.BringToFront()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub txtSearchCustomer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchCustomer.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub txtSearchDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchDescription.KeyPress
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
                dv = New DataView(ds1.Tables("SaleMaster"), "SaleInvoiceNo Like '" & Trim(txtSearch.Text) & "*" & "'", "SaleInvoiceNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 1 Then
                dv = New DataView(ds1.Tables("SaleMaster"), True, "SaleDate", DataViewRowState.CurrentRows)
                'dv = New DataView(ds.Tables(0), "QuotationDate '" & Trim(txtSearch.Text) & "*" & "'", "QuotationNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 2 Then
                dv = New DataView(ds1.Tables("SaleMaster"), "CustomerName Like '" & Trim(txtSearch.Text) & "*" & "'", "SaleInvoiceNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 3 Then
                dv = New DataView(ds1.Tables("SaleMaster"), "InvoiceNo Like '" & Trim(txtSearch.Text) & "*" & "'", "SaleInvoiceNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 4 Then
                dv = New DataView(ds1.Tables("SaleMaster"), "ChallanNo Like '" & Trim(txtSearch.Text) & "*" & "'", "SaleInvoiceNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 5 Then
                dv = New DataView(ds1.Tables("SaleMaster"), "Totalvalue >= " & Val(txtSearch.Text) & "", "Totalvalue", DataViewRowState.CurrentRows)
            Else
                dv = New DataView(ds1.Tables("SaleMaster"), "SaleInvoiceNo Like '" & Trim(txtSearch.Text) & "*" & "'", "SaleInvoiceNo", DataViewRowState.CurrentRows)
            End If
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("SaleInvoiceNo")), "", dTable.Rows(i).Item("SaleInvoiceNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(dTable.Rows(i).Item("SaleDate"))), "", convertToServerDateFormat(dTable.Rows(i).Item("SaleDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("CustomerName")), "", dTable.Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("InvoiceNo")), "", dTable.Rows(i).Item("InvoiceNo"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("ChallanNo")), "", dTable.Rows(i).Item("ChallanNo"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("Totalvalue")), "", dTable.Rows(i).Item("Totalvalue"))

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

    Private Sub txtSearchCustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchCustomer.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try
            If cboSearchCustomer.SelectedIndex = 0 Then
                dv = New DataView(ds1.Tables("CustomerMaster"), "CustomerCode Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 1 Then
                dv = New DataView(ds1.Tables("CustomerMaster"), "CustomerName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 2 Then
                dv = New DataView(ds1.Tables("CustomerMaster"), "Address Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 3 Then
                dv = New DataView(ds1.Tables("CustomerMaster"), "CityName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 4 Then
                dv = New DataView(ds1.Tables("CustomerMaster"), "StateName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            ElseIf cboSearchCustomer.SelectedIndex = 4 Then
                dv = New DataView(ds1.Tables("CustomerMaster"), "PINCode Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
            Else
                dv = New DataView(ds1.Tables("CustomerMaster"), "CustomerName Like '" & Trim(txtSearchCustomer.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
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

    Private Sub txtSearchDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchDescription.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try
            dv = New DataView(ds1.Tables("Payment"), "Description Like '" & Trim(txtSearchDescription.Text) & "*" & "'", "PaymentTermCode", DataViewRowState.CurrentRows)

            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("PaymentTermCode")), "", dTable.Rows(i).Item("PaymentTermCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("Description")), "", dTable.Rows(i).Item("Description"))

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
    Private Sub FillOverHeadDetails(ByVal strOverHeadCode As String)
        Dim strQuery As String
        Dim daConfigD As SqlClient.SqlDataAdapter
        Dim dsConfigD As New DataSet
        Dim i As Integer
        Try
            dsConfigD.Clear()
            If dgConfiguration.RowCount = 0 Then
                strQuery = "SELECT ConfigurationCode, Description, PlusMinus, CalculatedOn, CalculatedOnSQ, SNo, Sequence, Lvl, Code, Percentage FROM ConfigurationDetails Where Description='None'"
            Else
                strQuery = "SELECT ConfigurationCode, Description, PlusMinus, CalculatedOn, CalculatedOnSQ, SNo, Sequence, Lvl, Code, Percentage FROM ConfigurationDetails Where ConfigurationCode='" & strOverHeadCode & "' Order By SNo"
            End If

            daConfigD = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            daConfigD.Fill(dsConfigD, "ConfigD")
            dgConfigSearch.RowCount = 1
            If dsConfigD.Tables("ConfigD").Rows.Count > 0 Then
                With dgConfigSearch
                    For i = 0 To dsConfigD.Tables("ConfigD").Rows.Count - 1
                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = dsConfigD.Tables("ConfigD").Rows(i).Item("Description")
                        .Rows(i).Cells(1).Value = dsConfigD.Tables("ConfigD").Rows(i).Item("Code")
                        .Rows(i).Cells(2).Value = dsConfigD.Tables("ConfigD").Rows(i).Item("PlusMinus")
                        .Rows(i).Cells(3).Value = dsConfigD.Tables("ConfigD").Rows(i).Item("Percentage")
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("CalculatedOn")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("CalculatedOn"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("CalculatedOnSQ")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("CalculatedOnSQ"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("SNo")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("SNo"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("Sequence")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("Sequence"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("Lvl")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("Lvl"))
                        .Rows(i).Cells(9).Value = IIf(IsDBNull(dsConfigD.Tables("ConfigD").Rows(i).Item("ConfigurationCode")), "", dsConfigD.Tables("ConfigD").Rows(i).Item("ConfigurationCode"))
                    Next
                    dgConfigSearch.RowCount = dgConfigSearch.RowCount - 1
                End With
            Else
                dgConfigSearch.RowCount = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Cal()
        Dim i As Integer

        Try
            Me.Cursor = Cursors.WaitCursor
            txtConfigCode.Text = Trim(dgConfigSearch.Rows(0).Cells(9).Value)
            dgConfiguration.RowCount = 1
            With dgConfiguration
                For i = 0 To dgConfigSearch.RowCount - 1
                    .RowCount = .RowCount + 1
                    .Rows(i).Cells(0).Value = dgConfigSearch.Rows(i).Cells(0).Value
                    .Rows(i).Cells(1).Value = dgConfigSearch.Rows(i).Cells(1).Value
                    .Rows(i).Cells(2).Value = dgConfigSearch.Rows(i).Cells(2).Value
                    .Rows(i).Cells(3).Value = dgConfigSearch.Rows(i).Cells(3).Value
                    .Rows(i).Cells(4).Value = 0.0
                    .Rows(i).Cells(5).Value = 0.0
                    .Rows(i).Cells(6).Value = dgConfigSearch.Rows(i).Cells(4).Value
                    .Rows(i).Cells(8).Value = dgConfigSearch.Rows(i).Cells(6).Value

                Next
                .RowCount = .RowCount - 1
            End With


            For i = 0 To dgConfiguration.RowCount - 1
                Call CalculateTotal(i)
            Next




            gbConfigSearch.SendToBack()
            gbMain.Enabled = True
            gbMain.BringToFront()


            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CalculateTotal(ByVal intRowsel As Integer)
        Dim strQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim Amt As Decimal
        Dim amtchange As Decimal
        Dim TotalValue As Decimal

        Dim i As Integer

        Dim ComSave As SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction



        strQuery = "Select Description, Code, PlusMinus, Percentage, Amount, TotalAmount, CalcOn from SaleOverHeads   where SaleInvoiceNo='" & txtSaleInvoiceNo.Text & "' and Description='" & dgConfiguration.Rows(intRowsel).Cells(6).Value.ToString & "'"
        da = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
        da.Fill(ds, "Config")

        If ds.Tables("Config").Rows.Count > 0 Then
            Amt = IIf(IsDBNull(ds.Tables("Config").Rows(0).Item("TotalAmount")), "", ds.Tables("Config").Rows(0).Item("TotalAmount"))
        End If


        With dgConfiguration

            If .Rows(intRowsel).Cells(6).Value.ToString = "Net Order Value" Then
                .Rows(.CurrentRow.Index).Cells(4).Value = Val(txtNetValue.Text) * (Val(.Rows(.CurrentRow.Index).Cells(3).Value) / 100)
                .Rows(.CurrentRow.Index).Cells(7).Value = Val(txtNetValue.Text)
            Else
                .Rows(.CurrentRow.Index).Cells(4).Value = Amt * (Val(.Rows(.CurrentRow.Index).Cells(3).Value) / 100)
                .Rows(.CurrentRow.Index).Cells(7).Value = Amt

            End If
        End With


        With dgConfiguration
            For i = 0 To .RowCount - 1
                If i = 0 Then
                    If (Trim(.Rows(i).Cells(2).Value.ToString)) = "+" Then
                        .Rows(i).Cells(5).Value = Val(txtNetValue.Text) + Val(.Rows(i).Cells(4).Value)
                    Else
                        .Rows(i).Cells(5).Value = Val(txtNetValue.Text) - Val(.Rows(i).Cells(4).Value)
                    End If

                Else
                    If i > 0 Then
                        If (Trim(.Rows(i).Cells(2).Value.ToString)) = "+" Then
                            .Rows(i).Cells(5).Value = Val(.Rows(i - 1).Cells(5).Value) + Val(.Rows(i).Cells(4).Value)

                        Else
                            .Rows(i).Cells(5).Value = Val(.Rows(i - 1).Cells(5).Value) - Val(.Rows(i).Cells(4).Value)

                        End If
                    End If
                End If

                TotalValue = Val(.Rows(i).Cells(5).Value)
                txttotalvalue.Text = TotalValue
                txtBalanceValue.Text = Val(txttotalvalue.Text) - Val(txtAdvance.Text)
                txtTotalValue1.Text = Val(.Rows(i).Cells(5).Value)

            Next

        End With




        strQuery = "Delete from SaleOverHeads where SaleInvoiceNo='" & Replace(Trim(txtSaleInvoiceNo.Text), "'", "''") & "'"
        ComSave = New SqlClient.SqlCommand(strQuery, gl_Con)
        ComSave.CommandType = CommandType.Text
        ComSave.Transaction = trn
        ComSave.ExecuteNonQuery()

        With dgConfiguration
            For i = 0 To .RowCount - 1
                strQuery = "Insert into SaleOverHeads(SaleInvoiceNo, Description, Code, PlusMinus, Percentage, Amount, TotalAmount, CalcOn ,Remarks,SNo ) Values('" & Replace(Trim(txtSaleInvoiceNo.Text), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(0).Value.ToString), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(1).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(2).Value), "'", "''") & "'," & Val(.Rows(i).Cells(3).Value) & "," & Val(.Rows(i).Cells(4).Value) & "," & Val(.Rows(i).Cells(5).Value) & ",'" & Replace(Trim(.Rows(i).Cells(6).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(7).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(8).Value), "'", "''") & "')"
                ComSave = New SqlClient.SqlCommand(strQuery, gl_Con)
                ComSave.CommandType = CommandType.Text
                ComSave.Transaction = trn
                ComSave.ExecuteNonQuery()
            Next
        End With
    End Sub

    Private Sub cboSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearch.SelectedIndexChanged
        lblRow.Text = cboSearch.Text
        txtSearch.Text = ""
        txtSearch.Focus()
    End Sub

    Private Sub cboSearchCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchCustomer.SelectedIndexChanged
        lblRowSearch.Text = cboSearchCustomer.Text
        txtSearchCustomer.Text = ""
        txtSearchCustomer.Focus()
    End Sub

    Private Sub dgSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.DoubleClick
        With dgSearch
            If search = 0 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                        txtSaleInvoiceNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtSaleInvoiceNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtSaleInvoiceNo.Text)
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                End If
            ElseIf search = 1 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                        CustomerCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtCustomerName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSearch(4, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSearch(5, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSearch(6, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                    Else
                        CustomerCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtCustomerName.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtAddress.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSearch(4, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSearch(5, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSearch(6, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    txtInvoiceNo.Focus()
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                End If
            ElseIf search = 2 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                        PaymentCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtPaymentTerms.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                    Else
                        PaymentCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtPaymentTerms.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    txtVehicleNo.Focus()
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
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

    Private Sub cboSearchItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchItem.SelectedIndexChanged
        lblName.Text = cboSearchItem.Text
        txtSearchItemName.Text = ""
        txtSearchItemName.Focus()

        If chkChallan.Checked = True Then
            txtChallanNo.Text = ""
            dgDetail.RowCount = 0
            FillSearchGridInfoForChallan()
            FillGridChallan()
            gbComboItem.Visible = False
        ElseIf chkQuotation.Checked = True Then
            txtChallanNo.Text = ""
            dgDetail.RowCount = 0
            FillSearchGridInfoForQuotation()
            FillGridQuotation()
            gbComboItem.Visible = False
        Else
            FillSearchGridInfo()
            FillGridItem()
            gbComboItem.Visible = True
        End If
    End Sub

    Private Sub cboConfig_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConfig.SelectedIndexChanged
        Dim strQuery As String
        Dim drConfigD As SqlClient.SqlDataReader
        Dim comConfigD As SqlClient.SqlCommand
        Try


            If bln_AddOn = True Or bln_EditOn = True Then
                If Len(cboConfig.Text) > 0 Then

                    strQuery = "SELECT ConfigurationCode, Remarks FROM ConfigurationMaster Where ConfigurationCode='" & cboConfig.Text & "'"
                    comConfigD = New SqlClient.SqlCommand(strQuery, gl_Con)
                    drConfigD = comConfigD.ExecuteReader()
                    If drConfigD.HasRows Then
                        drConfigD.Read()
                        txtConfigurationRemarks.Text = IIf(IsDBNull(drConfigD.Item("Remarks")), "", drConfigD.Item("Remarks"))
                    End If
                    drConfigD.Close()

                    Call FillOverHeadDetails(Trim(cboConfig.Text()))
                End If
            End If
        Catch ex As Exception
            If drConfigD.IsClosed = False Then
                drConfigD.Close()
            End If
            MsgBox(ex.Message)
        End Try
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

    Private Sub cmdAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddItem.Click

        checkData()
        If checkData() = True Then '''''''''''''Checking data
            MsgDisplay(f_strDataCheck) ''calling function in main module 

            Exit Sub
        End If
        AddItem = 1
        gbSelectItem.BringToFront()
        gbMain.SendToBack()
        gbSelectItem.Visible = True
        If chkChallan.Checked = True Then
            txtChallanNo.Text = ""
            dgDetail.RowCount = 0
            FillSearchGridInfoForChallan()
            FillGridChallan()
            gbComboItem.Visible = False
            gbSearchTermCondiation.Visible = False
        ElseIf chkQuotation.Checked = True Then
            txtChallanNo.Text = ""
            dgDetail.RowCount = 0
            FillSearchGridInfoForQuotation()
            FillGridQuotation()
            gbComboItem.Visible = False
            gbSearchTermCondiation.Visible = False
        Else
            FillSearchGridInfo()
            FillGridItem()
            gbComboItem.Visible = True
            gbSearchTermCondiation.Visible = True
            gbComboItem.BringToFront()
        End If

        If cboSearchItem.Text = "" Then
            lblName.Text = "ItemName"
        Else
            lblName.Text = cboSearchItem.Text
        End If

        txtSearchItemName.Text = ""
        txtSearchItemName.Focus()
    End Sub
    Private Sub FillSearchGridInfoForChallan()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Visible = False

            .Columns(1).Name = "ChallanNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "ChallanDate"
            .Columns(2).Width = 350
            .Columns(3).Name = "RefNo"
            .Columns(3).Width = 150
            .Columns(4).Name = "Remarks"
            .Columns(4).Width = 80

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

        Dim chkBox2 As New DataGridViewCheckBoxColumn()
        With dgSelectedItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Visible = False

            .Columns(1).Name = "ChallanNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "ChallanDate"
            .Columns(2).Width = 350
            .Columns(3).Name = "RefNo"
            .Columns(3).Width = 150
            .Columns(4).Name = "Remarks"
            .Columns(4).Width = 80

            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False

            '.RowTemplate.Height = 17
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
    End Sub
    Private Sub FillGridChallan()

        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim f_daDept As SqlClient.SqlDataAdapter
        Dim f_dsDept As New DataSet
        Dim StrQuery As String

        Me.Cursor = Cursors.WaitCursor


        Try

            StrQuery = "SELECT  DISTINCT ChallanMaster.ChallanNo, ChallanMaster.ChallanDate, ChallanMaster.RefNo, ChallanMaster.Remarks  FROM         ChallanMaster INNER JOIN   ChallanDetail ON ChallanMaster.ChallanNo = ChallanDetail.ChallanNo WHERE(ChallanDetail.Invoice = 0) AND (ChallanMaster.Approve=1) and (ChallanMaster.CustomerCode='" & CustomerCode & "') ORDER BY ChallanMaster.ChallanNo "





            f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            f_dsDept.Clear()
            f_daDept.Fill(f_dsDept, "ItemList")
            dgSelectItem.RowCount = 1
            For i = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
                drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
                With dgSelectItem
                    .RowCount = .RowCount + 1
                    .Rows(0).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ChallanNo")), "", drDisplay.Item("ChallanNo"))


                    .Rows(0).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(drDisplay.Item("ChallanDate"))), "01/01/2000", (convertToServerDateFormat(drDisplay.Item("ChallanDate"))))
                    .Rows(0).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("RefNo")), "", drDisplay.Item("RefNo"))
                    .Rows(0).Cells(4).Value = IIf(IsDBNull(drDisplay.Item("Remarks")), 0, drDisplay.Item("Remarks"))
                End With
            Next
            dgSelectItem.RowCount = dgSelectItem.RowCount - 1

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FillSearchGridInfoForQuotation()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Visible = False

            .Columns(1).Name = "QuotationNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "QuotationDate"
            .Columns(2).Width = 90
            .Columns(3).Name = "Version No"
            .Columns(3).Width = 90
            .Columns(4).Name = "QuotationHeading"
            .Columns(4).Width = 300

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

        Dim chkBox2 As New DataGridViewCheckBoxColumn()
        With dgSelectedItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Visible = False

            .Columns(1).Name = "QuotationNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "QuotationDate"
            .Columns(2).Width = 90
            .Columns(3).Name = "Version No"
            .Columns(3).Width = 90
            .Columns(4).Name = "QuotationHeading"
            .Columns(4).Width = 300

            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False

            '.RowTemplate.Height = 17
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
    End Sub
    Private Sub FillGridQuotation()

        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim f_daDept As SqlClient.SqlDataAdapter
        Dim f_dsDept As New DataSet
        Dim StrQuery As String

        Me.Cursor = Cursors.WaitCursor

        Try


            StrQuery = "SELECT DISTINCT  QuotationMaster.QuotationNo, QuotationMaster.QuotationDate, QuotationMaster.QuotationVersion, QuotationMaster.QuotationHeading,QuotationMaster.CustomerCode FROM QuotationMaster INNER JOIN QuotationDetail ON QuotationMaster.QuotationNo = QuotationDetail.QuotationNo WHERE     (QuotationMaster.Approve = 1) AND (QuotationDetail.Invoice = 0) and (QuotationMaster.CustomerCode='" & CustomerCode & "') ORDER BY QuotationMaster.QuotationNo"





            f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            f_dsDept.Clear()
            f_daDept.Fill(f_dsDept, "ItemList")
            dgSelectItem.RowCount = 1
            For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
                drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
                With dgSelectItem
                    .RowCount = .RowCount + 1
                    .Rows(0).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("QuotationNo")), "", drDisplay.Item("QuotationNo"))


                    .Rows(0).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(drDisplay.Item("QuotationDate"))), "01/01/2000", (convertToServerDateFormat(drDisplay.Item("QuotationDate"))))
                    .Rows(0).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("QuotationVersion")), "", drDisplay.Item("QuotationVersion"))
                    .Rows(0).Cells(4).Value = IIf(IsDBNull(drDisplay.Item("QuotationHeading")), 0, drDisplay.Item("QuotationHeading"))
                End With
            Next
            dgSelectItem.RowCount = dgSelectItem.RowCount - 1


        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
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
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).Name = "Make"
            .Columns(6).Width = 80
            .Columns(7).Name = "SubUnit"
            .Columns(7).Width = 80
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80
            .Columns(9).Name = "Rate"
            .Columns(9).Width = 90
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(4).Visible = False
            .Columns(7).Visible = False

            '.RowTemplate.Height = 17
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
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).Name = "Make"
            .Columns(6).Width = 80
            .Columns(7).Name = "SubUnit"
            .Columns(7).Width = 80
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80
            .Columns(9).Name = "Rate"
            .Columns(9).Width = 90
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(4).Visible = False
            .Columns(7).Visible = False

            '.RowTemplate.Height = 17
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
    End Sub
    Private Sub FillGridItem()
        Dim StrQuery As String
        Dim i As Integer

        da2.Dispose()
        ds2.Clear()
        AddItem = 1


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

            lblName.Text = "Item Name"
            txtSearchItemName.Text = ""
            txtSearchItemName.Focus()
            cboSearchItem.Text = ""

            gbSelectItem.BringToFront()
            gbMain.SendToBack()
            gbComboItem.BringToFront()
            gbSearchTermCondiation.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdDelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelItem.Click
        Dim AmountLess As Decimal
        Dim i As Integer
        If dgDetail.RowCount >= 1 Then
            If MsgQuestion("DELETE") = 7 Then
                Exit Sub
            Else
                AmountLess = dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(10).Value
                dgDetail.Rows.Remove(dgDetail.CurrentRow)

                For i = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(i).Cells(0).Value = i + 1
                Next
            End If
            txtNetValue.Text = Val(txtNetValue.Text) - AmountLess
        Else
            MsgBox("No row to delete")
        End If
        For i = 0 To dgConfiguration.RowCount - 1
            Call CalculateTotal(i)
        Next

        If dgDetail.RowCount = 0 Then
            txtNetValue.Text = 0
            txttotalvalue.Text = 0

        End If
    End Sub

    Private Sub txtSearchItemName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchItemName.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSelectItem.Focus()
        End If
    End Sub

    
    Private Sub txtSearchTermCondiations_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchTermCondiations.KeyPress
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
                dv = New DataView(ds2.Tables("ItemMaster"), "ItemName Like '" & Trim(txtSearchItemName.Text) & "*" & "'", "ItemCode", DataViewRowState.CurrentRows)
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
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("Make")), 0, dTable.Rows(i).Item("Make"))
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
    End Sub
    Private Sub DesignGridTermCondtion()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 3
            .Columns(0).Visible = True

            .Columns(1).Name = "T&C Code"
            .Columns(1).Width = 80
            .Columns(2).Name = "Description"
            .Columns(2).Width = 800

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
            .ColumnCount = 3
            .Columns(0).Visible = True

            .Columns(1).Name = "T&C Code"
            .Columns(1).Width = 80
            .Columns(2).Name = "Description"
            .Columns(2).Width = 800

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


    End Sub

    Private Sub cmdAddTerms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddTerms.Click
        checkData()
        If checkData() = True Then '''''''''''''Checking data
            MsgDisplay(f_strDataCheck) ''calling function in main module 

            Exit Sub
        End If

        Dim StrQuery As String
        Dim i As Integer
        DesignGridTermCondtion()
        da2.Dispose()
        ds2.Clear()
        AddItem = 0

        Try

            StrQuery = "SELECT TCCode, Description  FROM TCMaster ORDER BY Description"
            da2 = New SqlDataAdapter(StrQuery, gl_Con)
            da2.Fill(ds2, "TermAndCondition")
            dgSelectItem.RowCount = 1
            If ds2.Tables("TermAndCondition").Rows.Count > 0 Then
                With dgSelectItem
                    For i = 0 To ds2.Tables("TermAndCondition").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = False

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds2.Tables("TermAndCondition").Rows(i).Item("TCCode")), "", ds2.Tables("TermAndCondition").Rows(i).Item("TCCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds2.Tables("TermAndCondition").Rows(i).Item("Description")), "", ds2.Tables("TermAndCondition").Rows(i).Item("Description"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSelectItem.RowCount = 0
            End If

            txtSearchTermCondiations.Text = ""
            txtSearchTermCondiations.Focus()
            gbSelectItem.BringToFront()
            gbMain.SendToBack()
            gbComboItem.Visible = True
            gbComboItem.SendToBack()
            gbSearchTermCondiation.BringToFront()
            gbSearchTermCondiation.Visible = True

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
                strMinMaxKey = "select max(SaleInvoiceId) AS MaxId,MIN(SaleInvoiceId) As MinId from SaleMaster"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet

                'fill the dataset with min and max Id's 
                'give the name to table "ItemID"

                daMinMaxKey.Fill(dsMinMaxKey, "Sale")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("Sale").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select SaleInvoiceNo  from SaleMaster where SaleInvoiceId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "SaleNavigation")

                        txtSaleInvoiceNo.Text = dsMinMaxKey.Tables("SaleNavigation").Rows(0).Item("SaleInvoiceNo")
                        Call Display(txtSaleInvoiceNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Sale").Rows(0).Item("minId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Sale").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select SaleInvoiceNo from SaleMaster where SaleInvoiceId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "SaleNavigation")

                            If dsMinMaxKey.Tables("SaleNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Sale").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtSaleInvoiceNo.Text = dsMinMaxKey.Tables("SaleNavigation").Rows(0).Item("SaleInvoiceNo")
                        Call Display(txtSaleInvoiceNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Sale").Rows(0).Item("maxId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Sale").Rows(0).Item("maxId")
                            strNextRecord = "select SaleInvoiceNo from SaleMaster where SaleInvoiceId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "SaleNavigation")

                            If dsMinMaxKey.Tables("SaleNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Sale").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtSaleInvoiceNo.Text = dsMinMaxKey.Tables("SaleNavigation").Rows(0).Item("SaleInvoiceNo")
                        Call Display(txtSaleInvoiceNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Sale").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select SaleInvoiceNo from SaleMaster where SaleInvoiceId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "SaleNavigation")

                        txtSaleInvoiceNo.Text = dsMinMaxKey.Tables("SaleNavigation").Rows(0).Item("SaleInvoiceNo")
                        Call Display(txtSaleInvoiceNo.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkcashManual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkcashManual.Click
        If chkcashManual.Checked = True Then
            CashManual = 1
            CashParty = 0
            ByChallan = 0
            ByQuotation = 0
            cmdSearchCustomer.Enabled = False
            txtCustomerName.ReadOnly = False
            txtAddress.ReadOnly = False
            txtCustomerName.Text = "Cash"
            txtAddress.Text = ""
            CustomerCode = ""
            chkCashParty.Checked = False
            chkChallan.Checked = False
            chkQuotation.Checked = False
        Else
            CashParty = 0
            CashManual = 0
            ByChallan = 0
            ByQuotation = 0
            cmdSearchCustomer.Enabled = True
            txtCustomerName.ReadOnly = True
            txtAddress.ReadOnly = True
            txtCustomerName.Text = ""
            txtAddress.Text = ""

        End If


    End Sub

    Private Sub chkCashParty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCashParty.Click
        If chkCashParty.Checked = True Then
            CashManual = 0
            CashParty = 1
            ByChallan = 0
            cmdSearchCustomer.Enabled = True
            txtCustomerName.ReadOnly = True
            txtAddress.ReadOnly = True
            txtCustomerName.Text = ""
            txtAddress.Text = ""
            CustomerCode = ""
            chkcashManual.Checked = False
            chkChallan.Checked = False
            chkQuotation.Checked = False
        Else
            CashManual = 0
            CashParty = 0
            ByChallan = 0
            ByQuotation = 0
            cmdSearchCustomer.Enabled = True
            txtCustomerName.ReadOnly = True
            txtAddress.ReadOnly = True
            txtCustomerName.Text = ""
            txtAddress.Text = ""

        End If
    End Sub

    Private Sub chkChallan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkChallan.Click
        If chkChallan.Checked = True Then
            ClearControl()
            CashManual = 0
            CashParty = 0
            ByChallan = 1
            cmdSearchCustomer.Enabled = True
            txtCustomerName.ReadOnly = True
            txtAddress.ReadOnly = True
            txtCustomerName.Text = ""
            txtAddress.Text = ""
            CustomerCode = ""
            chkCashParty.Checked = False
            chkcashManual.Checked = False
            chkQuotation.Checked = False

        Else
            CashManual = 0
            CashParty = 0
            ByChallan = 0
            ByQuotation = 0
            cmdSearchCustomer.Enabled = True
            txtCustomerName.ReadOnly = True
            txtAddress.ReadOnly = True
            txtCustomerName.Text = ""
            txtAddress.Text = ""

        End If
    End Sub

    Private Sub chkQuotation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkQuotation.Click
        If chkQuotation.Checked = True Then
            ClearControl()
            CashManual = 0
            CashParty = 0
            ByChallan = 0
            ByQuotation = 1
            cmdSearchCustomer.Enabled = True
            txtCustomerName.ReadOnly = True
            txtAddress.ReadOnly = True
            txtCustomerName.Text = ""
            txtAddress.Text = ""
            CustomerCode = ""
            chkCashParty.Checked = False
            chkcashManual.Checked = False
            chkChallan.Checked = False
        Else
            CashManual = 0
            CashParty = 0
            ByChallan = 0
            ByQuotation = 0
            cmdSearchCustomer.Enabled = True
            txtCustomerName.ReadOnly = True
            txtAddress.ReadOnly = True
            txtCustomerName.Text = ""
            txtAddress.Text = ""

        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim amount As Decimal
        gbSelectItem.SendToBack()
        gbMain.Enabled = True
        If AddItem = 1 Then
            If chkChallan.Checked = True Then
                FillChallanDetail()
                For i = 0 To dgDetail.RowCount - 1
                    amount = amount + Val(dgDetail.Rows(i).Cells(10).Value)
                Next
                txtNetValue.Text = amount
                For i = 0 To dgConfiguration.RowCount - 1
                    Call CalculateTotal(i)
                Next
            ElseIf chkQuotation.Checked = True Then
                FillQuotationDetail()
                For i = 0 To dgDetail.RowCount - 1
                    amount = amount + Val(dgDetail.Rows(i).Cells(10).Value)
                Next
                txtNetValue.Text = amount
                For i = 0 To dgConfiguration.RowCount - 1
                    Call CalculateTotal(i)
                Next
            Else
                FillItemGrid()
                dgDetail.CurrentCell = dgDetail.Item(4, dgDetail.RowCount - 1)
            End If
        ElseIf AddItem = 0 Then
            FillTCGrid()
        End If


        gbMain.BringToFront()
    End Sub
    Private Sub FillChallanDetail()

        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim f_daDept As SqlClient.SqlDataAdapter
        Dim f_dsDept As New DataSet
        Dim StrQuery As String

        Me.Cursor = Cursors.WaitCursor

        Try


            For i = 0 To dgSelectedItem.RowCount - 1
                StrQuery = "SELECT     ChallanMaster.ChallanNo, ChallanMaster.ChallanDate, ChallanMaster.RefNo, ChallanMaster.Remarks, ChallanDetail.ItemCode, ChallanDetail.Qty as CurrentStock, ChallanDetail.SubQty as CurrentSubStock, ItemMaster.ItemName, ItemMaster.MAke, ItemMaster.Unit, ItemMaster.StoreUnit, ChallanDetail.Rate As Price, ItemMaster.ConvFAct FROM         ChallanMaster INNER JOIN ChallanDetail ON ChallanMaster.ChallanNo = ChallanDetail.ChallanNo INNER JOIN ItemMaster ON ChallanDetail.ItemCode = ItemMaster.ItemCode where ChallanMaster.ChallanNo='" & Trim(dgSelectedItem.Rows(i).Cells(1).Value) & "'AND (ChallanDetail.Invoice = 0)  ORDER BY ChallanMaster.ChallanNo"
                f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
                f_dsDept.Clear()
                f_daDept.Fill(f_dsDept, "ItemList")
                dgDetail.RowCount = 1
                For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
                    drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
                    With dgDetail
                        .RowCount = .RowCount + 1
                        .Rows(iRow).Cells(0).Value = iRow + 1
                        .Rows(iRow).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode"))
                        .Rows(iRow).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName"))
                        .Rows(iRow).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("MAke")), "", drDisplay.Item("MAke"))
                        .Rows(iRow).Cells(4).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                        .Rows(iRow).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit"))
                        .Rows(iRow).Cells(6).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                        .Rows(iRow).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit"))
                        .Rows(iRow).Cells(13).Value = IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct"))
                        .Rows(iRow).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price"))
                        .Rows(iRow).Cells(9).Value = Val(.Rows(iRow).Cells(8).Value) / Val(.Rows(iRow).Cells(13).Value)
                        .Rows(iRow).Cells(10).Value = Val(.Rows(iRow).Cells(8).Value) * Val(.Rows(iRow).Cells(4).Value)
                        .Rows(iRow).Cells(11).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                        .Rows(iRow).Cells(12).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                        .Rows(iRow).Cells(14).Value = IIf(IsDBNull(drDisplay.Item("ChallanNo")), "", drDisplay.Item("ChallanNo"))
                        .Rows(iRow).Cells(15).Value = IIf(IsDBNull(drDisplay.Item("RefNo")), "", drDisplay.Item("RefNo"))
                    End With
                Next

            Next

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FillQuotationDetail()

        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim f_daDept As SqlClient.SqlDataAdapter
        Dim f_dsDept As New DataSet
        Dim StrQuery As String

        Me.Cursor = Cursors.WaitCursor
        
        Try

            For i = 0 To dgSelectedItem.RowCount - 1
                StrQuery = "SELECT     QuotationMaster.QuotationNo, QuotationMaster.QuotationDate, QuotationMaster.QuotationVersion, QuotationMaster.QuotationHeading, QuotationDetail.ItemCode, QuotationDetail.Qty as CurrentStock, QuotationDetail.SubQty as CurrentSubStock, ItemMaster.ItemName, ItemMaster.MAke, ItemMaster.Unit, ItemMaster.StoreUnit, QuotationDetail.Rate As Price, ItemMaster.ConvFAct FROM         QuotationMaster INNER JOIN QuotationDetail ON QuotationMaster.QuotationNo = QuotationDetail.QuotationNo INNER JOIN ItemMaster ON QuotationDetail.ItemCode = ItemMaster.ItemCode where QuotationMaster.QuotationNo='" & Trim(dgSelectedItem.Rows(i).Cells(1).Value) & "'AND (QuotationDetail.Invoice = 0)  ORDER BY QuotationMaster.QuotationNo"
                f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
                f_dsDept.Clear()
                f_daDept.Fill(f_dsDept, "ItemList")
                For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
                    drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
                    With dgDetail
                        .RowCount = .RowCount + 1
                        .Rows(iRow).Cells(0).Value = iRow + 1
                        .Rows(iRow).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode"))
                        .Rows(iRow).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName"))
                        .Rows(iRow).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("MAke")), "", drDisplay.Item("MAke"))
                        .Rows(iRow).Cells(4).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                        .Rows(iRow).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit"))
                        .Rows(iRow).Cells(6).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                        .Rows(iRow).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit"))
                        .Rows(iRow).Cells(13).Value = IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct"))
                        .Rows(iRow).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price"))
                        .Rows(iRow).Cells(9).Value = Val(.Rows(iRow).Cells(8).Value) / Val(.Rows(iRow).Cells(13).Value)
                        .Rows(iRow).Cells(10).Value = Val(.Rows(iRow).Cells(8).Value) * Val(.Rows(iRow).Cells(4).Value)
                        .Rows(iRow).Cells(11).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                        .Rows(iRow).Cells(12).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                        .Rows(iRow).Cells(14).Value = IIf(IsDBNull(drDisplay.Item("QuotationNo")), "", drDisplay.Item("QuotationNo"))
                        .Rows(iRow).Cells(15).Value = IIf(IsDBNull(drDisplay.Item("QuotationVersion")), "", drDisplay.Item("QuotationVersion"))
                    End With
                Next

            Next

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
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
                    '    If fgDetail.get_TextMatrix(k, 1) = Trim(.get_TextMatrix(i, 1)) Then
                    '        blnAdd = True
                    '        Exit For
                    '    End If
                    'Next
                    If blnAdd = False Then

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

                        If chkChallan.Checked = True Then
                            dgDetail.Rows(dgDetail.RowCount - 1).Cells(4).Value = .Rows(i).Cells(4).Value.ToString
                            dgDetail.Rows(dgDetail.RowCount - 1).Cells(6).Value = Val(dgDetail.Rows(dgDetail.RowCount - 1).Cells(4).Value) * Val(dgDetail.Rows(dgDetail.RowCount - 1).Cells(13).Value)
                            dgDetail.Rows(dgDetail.RowCount - 1).Cells(10).Value = Val(dgDetail.Rows(dgDetail.RowCount - 1).Cells(4).Value) * Val(dgDetail.Rows(dgDetail.RowCount - 1).Cells(8).Value)
                        End If


                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FillTCGrid() 'Fill Search Result in Main Grid
        Dim i As Integer
        Dim J As Integer
        Dim k As Integer
        Dim blnAdd As Boolean
        Try

            With dgSelectedItem
                For i = 0 To .RowCount - 1
                    blnAdd = False
                    For k = 0 To dgConditions.RowCount - 1
                        If Trim(dgConditions.Rows(k).Cells(1).Value.ToString) = Trim(.Rows(i).Cells(1).Value.ToString) Then
                            blnAdd = True
                            Exit For
                        End If
                    Next

                    If blnAdd = False Then
                        dgConditions.RowCount = dgConditions.RowCount + 1
                        dgConditions.Rows(dgConditions.RowCount - 1).Cells(0).Value = dgConditions.RowCount

                        dgConditions.Rows(dgConditions.RowCount - 1).Cells(1).Value = .Rows(i).Cells(1).Value.ToString
                        dgConditions.Rows(dgConditions.RowCount - 1).Cells(2).Value = .Rows(i).Cells(2).Value.ToString

                    End If

                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FillComboConfig()
        Dim strQuery As String
        Dim daConfig As SqlClient.SqlDataAdapter
        Dim dsConfig As New DataSet

        Try
            strQuery = "Select ConfigurationCode from ConfigurationMaster   Order By ConfigurationCode"
            daConfig = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            daConfig.Fill(dsConfig, "Config")
            cboConfig.DataSource = Nothing
            cboConfig.DataSource = dsConfig.Tables("Config")
            cboConfig.DisplayMember = "ConfigurationCode"
            'cboConfig.ValueMember = "Category"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdOverhead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOverhead.Click
        Try

            Call FillComboConfig()
            dgConfigSearch.RowCount = 0
            Call cboConfig_SelectedIndexChanged(sender, New System.EventArgs)
            gbConfigSearch.Visible = True
            gbConfigSearch.BringToFront()
            gbMain.Enabled = False

            cboConfig.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
            txtNetValue.Text = amount
        End With
        For i = 0 To dgConfiguration.RowCount - 1
            Call CalculateTotal(i)
        Next
    End Sub

    Private Sub dgDetail_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEnter
        If bln_AddOn = True Or bln_EditOn = True Then
            With dgDetail
                If e.ColumnIndex = 4 Or e.ColumnIndex = 6 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Or e.ColumnIndex = 16 Then
                    .EditMode = DataGridViewEditMode.EditOnEnter
                Else
                    .EditMode = DataGridViewEditMode.EditProgrammatically
                End If
            End With
            If chkChallan.Checked = True Then
                With dgDetail
                    If e.ColumnIndex = 8 Or e.ColumnIndex = 9 Or e.ColumnIndex = 16 Then
                        .EditMode = DataGridViewEditMode.EditOnEnter
                    Else
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                    End If
                End With
            End If
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
                            If AddItem = 1 Then
                                dgSelectedItem.Rows(i).Cells(3).Value = .Rows(e.RowIndex).Cells(3).Value
                                dgSelectedItem.Rows(i).Cells(4).Value = .Rows(e.RowIndex).Cells(4).Value
                                dgSelectedItem.Rows(i).Cells(5).Value = .Rows(e.RowIndex).Cells(5).Value
                                dgSelectedItem.Rows(i).Cells(6).Value = .Rows(e.RowIndex).Cells(6).Value
                                dgSelectedItem.Rows(i).Cells(7).Value = .Rows(e.RowIndex).Cells(7).Value
                                dgSelectedItem.Rows(i).Cells(8).Value = .Rows(e.RowIndex).Cells(8).Value
                                dgSelectedItem.Rows(i).Cells(9).Value = .Rows(e.RowIndex).Cells(9).Value
                            End If


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

    Private Sub dgSelectItem_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellContentDoubleClick
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
                            If AddItem = 1 Then
                                dgSelectedItem.Rows(i).Cells(3).Value = .Rows(e.RowIndex).Cells(3).Value
                                dgSelectedItem.Rows(i).Cells(4).Value = .Rows(e.RowIndex).Cells(4).Value
                                dgSelectedItem.Rows(i).Cells(5).Value = .Rows(e.RowIndex).Cells(5).Value
                                dgSelectedItem.Rows(i).Cells(6).Value = .Rows(e.RowIndex).Cells(6).Value
                                dgSelectedItem.Rows(i).Cells(7).Value = .Rows(e.RowIndex).Cells(7).Value
                                dgSelectedItem.Rows(i).Cells(8).Value = .Rows(e.RowIndex).Cells(8).Value
                                dgSelectedItem.Rows(i).Cells(9).Value = .Rows(e.RowIndex).Cells(9).Value
                            End If


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

    Private Sub dgSelectItem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellDoubleClick
        'If e.ColumnIndex > 0 Then
        Dim amount As Decimal
        gbSelectItem.SendToBack()
        gbMain.Enabled = True
        If AddItem = 1 Then
            If chkChallan.Checked = True Then
                DirectFillChallanDetail()
                intDGSearchKeayPress = 0
                txtChallanNo.Text = dgSelectItem.Rows(dgSelectItem.CurrentRow.Index).Cells(1).Value
                For i = 0 To dgDetail.RowCount - 1
                    amount = amount + dgDetail.Rows(i).Cells(10).Value
                Next
                txtNetValue.Text = amount
                For i = 0 To dgConfiguration.RowCount - 1
                    Call CalculateTotal(i)
                Next
            ElseIf chkQuotation.Checked = True Then
                DirectFillQuotationDetail()
                intDGSearchKeayPress = 0
                txtChallanNo.Text = dgSelectItem.Rows(dgSelectItem.CurrentRow.Index).Cells(1).Value
                For i = 0 To dgDetail.RowCount - 1
                    amount = amount + dgDetail.Rows(i).Cells(10).Value
                Next
                txtNetValue.Text = amount
                For i = 0 To dgConfiguration.RowCount - 1
                    Call CalculateTotal(i)
                Next
            Else
                DirectFillItemGrid()
                intDGSearchKeayPress = 0
                dgDetail.CurrentCell = dgDetail.Item(4, dgDetail.RowCount - 1)
            End If
        ElseIf AddItem = 0 Then
            DirectFillTCGrid()
            intDGSearchKeayPress = 0
        End If

        gbMain.BringToFront()
        'End If
    End Sub
    Private Sub DirectFillTCGrid()
        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim StrQuery As String


        Try
            With dgSelectItem
                If .RowCount > 1 And intDGSearchKeayPress = 1 Then

                    CODE = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                Else
                    CODE = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                End If
            End With

            StrQuery = "SELECT     TCCode, Description FROM TCMaster  WHERE  TCCode='" & CODE & "'"

            CODE = ""
            da = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            ds.Clear()
            da.Fill(ds, "ItemList")
            dgConditions.RowCount = dgConditions.RowCount + 1
            For iRow = 0 To ds.Tables("ItemList").Rows.Count - 1
                drDisplay = ds.Tables("ItemList").Rows(iRow)
                With dgConditions
                    .RowCount = .RowCount + 1
                    .Rows(.RowCount - 2).Cells(0).Value = .RowCount - 1
                    .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("TCCode")), "", drDisplay.Item("TCCode"))
                    .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("Description")), "", drDisplay.Item("Description"))
                End With
            Next
            dgConditions.RowCount = dgConditions.RowCount - 1

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub DirectFillItemGrid()

        Dim ItemCode As String
        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim StrQuery As String


        Try
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

            ItemCode = ""
            da = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            ds.Clear()
            da.Fill(ds, "ItemList")
            dgDetail.RowCount = dgDetail.RowCount + 1
            For iRow = 0 To ds.Tables("ItemList").Rows.Count - 1
                drDisplay = ds.Tables("ItemList").Rows(iRow)
                With dgDetail
                    .RowCount = .RowCount + 1
                    .Rows(.RowCount - 2).Cells(0).Value = .RowCount - 1
                    .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode"))
                    .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName"))
                    .Rows(.RowCount - 2).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category"))
                    'FillStock()
                    .Rows(.RowCount - 2).Cells(11).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                    .Rows(.RowCount - 2).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit"))
                    .Rows(.RowCount - 2).Cells(12).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                    .Rows(.RowCount - 2).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit"))
                    .Rows(.RowCount - 2).Cells(13).Value = IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct"))
                    .Rows(.RowCount - 2).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price"))

                    .Rows(.RowCount - 2).Cells(9).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) / Val(.Rows(.RowCount - 2).Cells(13).Value)

                End With
            Next
            dgDetail.RowCount = dgDetail.RowCount - 1



        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub DirectFillQuotationDetail()
        Dim ItemCode As String
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
            With dgSelectItem
                If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                    ItemCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                Else
                    ItemCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString

                End If
            End With



            StrQuery = "SELECT     QuotationMaster.QuotationNo, QuotationMaster.QuotationDate, QuotationMaster.QuotationVersion, QuotationMaster.QuotationHeading, QuotationDetail.ItemCode, QuotationDetail.Qty as CurrentStock, QuotationDetail.SubQty as CurrentSubStock, ItemMaster.ItemName, ItemMaster.MAke, ItemMaster.Unit, ItemMaster.StoreUnit, QuotationDetail.Rate As Price, ItemMaster.ConvFAct FROM         QuotationMaster INNER JOIN QuotationDetail ON QuotationMaster.QuotationNo = QuotationDetail.QuotationNo INNER JOIN ItemMaster ON QuotationDetail.ItemCode = ItemMaster.ItemCode where QuotationMaster.QuotationNo='" & ItemCode & "'AND (QuotationDetail.Invoice = 0)  ORDER BY QuotationMaster.QuotationNo"
            f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            f_dsDept.Clear()
            f_daDept.Fill(f_dsDept, "ItemList")
            dgDetail.RowCount = dgDetail.RowCount + 1
            For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
                drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
                With dgDetail
                    .RowCount = .RowCount + 1
                    .Rows(.RowCount - 2).Cells(0).Value = .RowCount - 1
                    .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode"))
                    .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName"))
                    .Rows(.RowCount - 2).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("MAke")), "", drDisplay.Item("MAke"))
                    .Rows(.RowCount - 2).Cells(4).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                    .Rows(.RowCount - 2).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit"))
                    .Rows(.RowCount - 2).Cells(6).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                    .Rows(.RowCount - 2).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit"))
                    .Rows(.RowCount - 2).Cells(13).Value = IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct"))
                    .Rows(.RowCount - 2).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price"))
                    .Rows(.RowCount - 2).Cells(9).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) / Val(.Rows(.RowCount - 2).Cells(13).Value)
                    .Rows(.RowCount - 2).Cells(0).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) * Val(.Rows(.RowCount - 2).Cells(4).Value)
                    .Rows(.RowCount - 2).Cells(11).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                    .Rows(.RowCount - 2).Cells(12).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                    .Rows(.RowCount - 2).Cells(14).Value = IIf(IsDBNull(drDisplay.Item("QuotationNo")), "", drDisplay.Item("QuotationNo"))
                    .Rows(.RowCount - 2).Cells(15).Value = IIf(IsDBNull(drDisplay.Item("QuotationVersion")), "", drDisplay.Item("QuotationVersion"))
                End With
            Next
            dgDetail.RowCount = dgDetail.RowCount - 1


        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub DirectFillChallanDetail()
        Dim ItemCode As String
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
            With dgSelectItem
                If .RowCount > 1 And intDGSearchKeayPress = 1 Then
                    ItemCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                Else
                    ItemCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString

                End If
            End With



            StrQuery = "SELECT     ChallanMaster.ChallanNo, ChallanMaster.ChallanDate, ChallanMaster.RefNo, ChallanMaster.Remarks, ChallanDetail.ItemCode, ChallanDetail.Qty as CurrentStock, ChallanDetail.SubQty as CurrentSubStock, ItemMaster.ItemName, ItemMaster.MAke, ItemMaster.Unit, ItemMaster.StoreUnit, ChallanDetail.Rate As Price, ItemMaster.ConvFAct , ChallanMaster.VehicleNo, ChallanMaster.GRNo, ChallanMaster.PONo FROM         ChallanMaster INNER JOIN ChallanDetail ON ChallanMaster.ChallanNo = ChallanDetail.ChallanNo INNER JOIN ItemMaster ON ChallanDetail.ItemCode = ItemMaster.ItemCode where ChallanMaster.ChallanNo='" & ItemCode & "'AND (ChallanDetail.Invoice = 0)  ORDER BY ChallanMaster.ChallanNo"
            f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            f_dsDept.Clear()
            f_daDept.Fill(f_dsDept, "ItemList")
            dgDetail.RowCount = dgDetail.RowCount + 1
            For iRow = 0 To f_dsDept.Tables("ItemList").Rows.Count - 1
                drDisplay = f_dsDept.Tables("ItemList").Rows(iRow)
                With dgDetail
                    .RowCount = .RowCount + 1
                    .Rows(.RowCount - 2).Cells(0).Value = .RowCount - 1

                    .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode"))
                    .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName"))
                    .Rows(.RowCount - 2).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("MAke")), "", drDisplay.Item("MAke"))
                    .Rows(.RowCount - 2).Cells(4).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                    .Rows(.RowCount - 2).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit"))
                    .Rows(.RowCount - 2).Cells(6).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                    .Rows(.RowCount - 2).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit"))
                    .Rows(.RowCount - 2).Cells(13).Value = IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct"))
                    .Rows(.RowCount - 2).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price"))
                    .Rows(.RowCount - 2).Cells(9).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) / Val(.Rows(.RowCount - 2).Cells(13).Value)
                    .Rows(.RowCount - 2).Cells(10).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) * Val(.Rows(.RowCount - 2).Cells(4).Value)
                    .Rows(.RowCount - 2).Cells(11).Value = IIf(IsDBNull(drDisplay.Item("CurrentStock")), 0, drDisplay.Item("CurrentStock"))
                    .Rows(.RowCount - 2).Cells(12).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                    .Rows(.RowCount - 2).Cells(14).Value = IIf(IsDBNull(drDisplay.Item("ChallanNo")), "", drDisplay.Item("ChallanNo"))
                    .Rows(.RowCount - 2).Cells(15).Value = IIf(IsDBNull(drDisplay.Item("RefNo")), "", drDisplay.Item("RefNo"))
                End With
            Next
            dgDetail.RowCount = dgDetail.RowCount - 1
            txtVehicleNo.Text = IIf(IsDBNull(drDisplay.Item("VehicleNo")), "", drDisplay.Item("VehicleNo"))
            txtGRNo.Text = IIf(IsDBNull(drDisplay.Item("GRNo")), "", drDisplay.Item("GRNo"))
            txtPONo.Text = IIf(IsDBNull(drDisplay.Item("PONo")), "", drDisplay.Item("PONo"))


            StrQuery = "SELECT     QuotationOverHeads.QuotationNo, QuotationOverHeads.Description, QuotationOverHeads.Code, QuotationOverHeads.PlusMinus,   QuotationOverHeads.Percentage, QuotationOverHeads.Amount, QuotationOverHeads.TotalAmount, QuotationOverHeads.CalcOn,  QuotationOverHeads.Remarks, QuotationOverHeads.SNo, ChallanMaster.ChallanNo FROM         QuotationMaster INNER JOIN   ChallanMaster ON QuotationMaster.QuotationNo = ChallanMaster.QuotationNo INNER JOIN    QuotationOverHeads ON QuotationMaster.QuotationNo = QuotationOverHeads.QuotationNo  WHERE     (ChallanMaster.ChallanNo = '" & ItemCode & "')"

            f_daDept = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            f_dsDept.Clear()
            f_daDept.Fill(f_dsDept, "OverHead")
            If f_dsDept.Tables("OverHead").Rows.Count > 0 Then
                dgConfiguration.RowCount = 1
                For iRow = 0 To f_dsDept.Tables("OverHead").Rows.Count - 1
                    drDisplay = f_dsDept.Tables("OverHead").Rows(iRow)

                    With dgConfiguration
                        .RowCount = .RowCount + 1

                        .Rows(iRow).Cells(0).Value = IIf(IsDBNull(drDisplay.Item("Description")), "", drDisplay.Item("Description"))
                        .Rows(iRow).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("Code")), "", drDisplay.Item("Code"))
                        .Rows(iRow).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("PlusMinus")), "", drDisplay.Item("PlusMinus"))
                        .Rows(iRow).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("Percentage")), 0, drDisplay.Item("Percentage"))
                        .Rows(iRow).Cells(4).Value = IIf(IsDBNull(drDisplay.Item("Amount")), 0, drDisplay.Item("Amount"))
                        .Rows(iRow).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("TotalAmount")), 0, drDisplay.Item("TotalAmount"))
                        .Rows(iRow).Cells(6).Value = IIf(IsDBNull(drDisplay.Item("CalcOn")), "", drDisplay.Item("CalcOn"))
                        .Rows(iRow).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("Remarks")), "", drDisplay.Item("Remarks"))
                        .Rows(iRow).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("SNo")), "", drDisplay.Item("SNo"))

                    End With
                Next
                dgConfiguration.RowCount = dgConfiguration.RowCount - 1
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSelectItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellEnter
        If e.ColumnIndex <> 0 Then
            dgSelectItem.EditMode = DataGridViewEditMode.EditProgrammatically

        Else
            dgSelectItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If
    End Sub

    Private Sub cmdConfigOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfigOk.Click
        Cal()
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

    Private Sub txtSearchTermCondiations_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchTermCondiations.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try

            dv = New DataView(ds2.Tables("TermAndCondition"), "Description Like '" & "*" & Trim(txtSearchTermCondiations.Text) & "*" & "'", "TCCode", DataViewRowState.CurrentRows)

            dTable = dv.ToTable
            dgSelectItem.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSelectItem
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = False

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("TCCode")), "", dTable.Rows(i).Item("TCCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("Description")), "", dTable.Rows(i).Item("Description"))


                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSelectItem.RowCount = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSelectItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSelectItem.KeyPress
        Dim e1 As System.Windows.Forms.DataGridViewCellEventArgs
        If (e.KeyChar = Convert.ToChar(13)) Then
            intDGSearchKeayPress = 1
            dgSelectItem_CellDoubleClick(sender, e1)
        End If
    End Sub
End Class