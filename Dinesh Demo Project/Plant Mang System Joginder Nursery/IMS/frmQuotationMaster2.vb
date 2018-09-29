Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmQuotationMaster2
    Dim CrRepDoc As New ReportDocument
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim CustomerCode As String
    Dim SearchCustomer As Integer
    Dim CashManual As Integer
    Dim CashParty As Integer
    Dim Approve As Integer
    Dim LocalityCode As String
    Dim Stock As Decimal
    Dim subStock As Decimal
    Dim CODE As String
    Dim AddItem As Integer
    Dim PaymentCode As String
    Dim invoice As Integer
    Dim ConvFact As Double
    Dim search As Integer
    Dim intDGSearchKeayPress As Integer

    Dim da1 As New SqlClient.SqlDataAdapter  'Global Data adapter for Search in dgSearch
    Dim ds1 As New DataSet
    Dim da2 As New SqlClient.SqlDataAdapter   'Global Data adapter for Search  dgSearchItem
    Dim ds2 As New DataSet


    Private Sub frmQuotationMaster2_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        QuotationMaster2 = Nothing
    End Sub

    Private Sub frmQuotationMaster2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub
    Private Sub DesignGridItem()
        Dim chkBox1 As New DataGridViewCheckBoxColumn()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns.Insert(0, chkBox1)
            .Columns(0).Width = 60
            chkBox1.Name = "Select"

            
            '.Columns.Insert(0, New DataGridViewCheckBoxColumn())
            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 350
            .Columns(3).Name = "Category"
            .Columns(3).Width = 150
            .Columns(4).Name = "Make"
            .Columns(4).Width = 80
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(6).Name = "SubStock"
            .Columns(6).Width = 80
            .Columns(7).Name = "SubUnit"
            .Columns(7).Width = 80
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80
            .Columns(9).Name = "Rate"
            .Columns(9).Width = 90

            .Columns(6).Visible = False
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



        End With

        Dim chkBox2 As New DataGridViewCheckBoxColumn()
        With dgSelectedItem
            .RowCount = 1
            .ColumnCount = 10
            .Columns.Insert(0, chkBox2)
            .Columns(0).Width = 60
            chkBox2.Name = "Select"
            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 350
            .Columns(3).Name = "Category"
            .Columns(3).Width = 150
            .Columns(4).Name = "Make"
            .Columns(4).Width = 80
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(6).Name = "SubStock"
            .Columns(6).Width = 80
            .Columns(7).Name = "SubUnit"
            .Columns(7).Width = 80
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80
            .Columns(9).Name = "Rate"
            .Columns(9).Width = 90

            .Columns(6).Visible = False
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
        End With
    End Sub
    Private Sub frmQuotationMaster2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DesignGridItem()
        ENABLECONTROL(True)
        DesignGrid()
        Display()
        cmdAdd.Focus()
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
        cmdAddNewRow.Enabled = Not status
        cmdDelItem.Enabled = Not status
        cmdAddTerms.Enabled = Not status
        CmdDelTerms.Enabled = Not status
        cmdPayment.Enabled = Not status
        cmdOverhead.Enabled = Not status
        cmdPayment.Enabled = Not status
        txtQuotationVersion.ReadOnly = status
        txtQuotationNo.ReadOnly = True
        txtQuotationFor.ReadOnly = status
        txtCustomerName.ReadOnly = True
        txtQuotationType.ReadOnly = status
        txtNetValue.ReadOnly = True
        txttotalvalue.ReadOnly = True
        txtSaleInvoiceDate.ReadOnly = True
        txtAddress.ReadOnly = True
        txtDescription.ReadOnly = status

        If cmdSave.Enabled = True Then
            dtpDate.BringToFront()
            cboQuotationVersion.BringToFront()
            cboCurrency.BringToFront()
            cboQuotationType.BringToFront()
            dtpValidUpto.BringToFront()
            cboQuotationFor.BringToFront()
            cmdApprove.Enabled = False
        Else
            dtpDate.SendToBack()
            cboQuotationVersion.SendToBack()
            cboQuotationType.SendToBack()
            cboCurrency.SendToBack()
            dtpValidUpto.SendToBack()
            cboQuotationFor.SendToBack()
            cmdApprove.Enabled = True
        End If

        If gl_EmpName = "administrator" Then
            cmdApprove.Visible = True
        Else
            cmdApprove.Visible = False
        End If
    End Sub
    Private Sub DesignGrid()

        With dgDetail
            .RowCount = 1
            .ColumnCount = 15
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
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(12).Name = "S.Stock"
            .Columns(12).Width = 80
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(12).Visible = False

            .Columns(13).Name = "ConvFact"
            .Columns(13).Width = 80
            .Columns(13).Visible = False


            .Columns(14).Name = "Remarks"
            .Columns(14).Width = 150
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
    Private Sub ClearControl()
        txtAddress.Text = ""
        'txtPaymentTerms.Text = ""
        txtCustomerName.Text = ""
        txtQuotationVersion.Text = ""
        cboQuotationVersion.Text = ""
        txtQuotationType.Text = ""
        cboQuotationType.Text = ""
        txtValidUpto.Text = ""
        txtQuotationFor.Text = ""
        cboQuotationFor.Text = ""
        txtQuotationHeading.Text = ""
        txtPaymentTerms.Text = ""
        txtDescription.Text = ""
        txtConfigurationRemarks.Text = ""
        txtNetValue.Text = ""
        txttotalvalue.Text = ""
        txtTotalValue1.Text = ""
        cmdApprove.Text = "Approve"
        dgDetail.RowCount = 0
        dgConditions.RowCount = 0
        dgConfiguration.RowCount = 0
        dgConfigSearch.RowCount = 0

        CashManual = 0
        CashParty = 0
        FillOverHeadDetails("None")
        Cal()

    End Sub



    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ENABLECONTROL(False)
        ClearControl()
        cmdApprove.Enabled = False
        bln_AddOn = True
        bln_EditOn = False
        txtQuotationNo.Text = showCode("Quotation")
        FillCurrency()
        dtpDate.Value = Now
        dtpValidUpto.Value = Now.Date.AddDays(30)
        dtpDate.Focus()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        ENABLECONTROL(False)
        cmdApprove.Enabled = False
        bln_EditOn = True
        bln_AddOn = False
    End Sub
    Private Sub FillCurrency()
        Dim strQuery As String
        Dim daConfig As SqlClient.SqlDataAdapter
        Dim dsConfig As New DataSet

        Try
            strQuery = "Select CurrencyName,ConvFact from CurrencyMaster   Order By CurrencyName"
            daConfig = New SqlClient.SqlDataAdapter(strQuery, gl_Con)
            daConfig.Fill(dsConfig, "Config")
            cboConfig.DataSource = Nothing
            cboCurrency.DataSource = dsConfig.Tables("Config")
            cboCurrency.DisplayMember = "CurrencyName"
            cboCurrency.ValueMember = "ConvFact"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        If Trim(cboQuotationVersion.Text) = "" Then
            f_strDataCheck = "Quotation Version"
            cboQuotationVersion.Focus()
            f_blnCheckData = True
            checkData1 = True
            Exit Function
        End If
        'If Trim(cboQuotationType.Text) = "" Then
        '    f_strDataCheck = "Quotation Type"
        '    cboQuotationType.Focus()
        '    f_blnCheckData = True
        '    checkData1 = True
        '    Exit Function
        'End If
        'If Trim(cboQuotationFor.Text) = "" Then
        '    f_strDataCheck = "Quotation For"
        '    cboQuotationFor.Focus()
        '    f_blnCheckData = True
        '    checkData1 = True
        '    Exit Function
        'End If
        If Trim(txtQuotationHeading.Text) = "" Then
            f_strDataCheck = "Quotation Heading"
            txtQuotationHeading.Focus()
            f_blnCheckData = True
            checkData1 = True
            Exit Function
        End If

        For i = 0 To dgDetail.RowCount - 1
            If Val(dgDetail.Rows(i).Cells(4).Value) = 0 Then
                f_strDataCheck = "Qty"
                dgDetail.CurrentCell = dgDetail.Item(4, i)
                'dgDetail.Focus()
                f_blnCheckData = True
                checkData1 = True
                Exit Function
            End If
        Next

        For i = 0 To dgDetail.RowCount - 1
            If Val(dgDetail.Rows(i).Cells(8).Value) = 0 Then
                f_strDataCheck = "Rate"
                dgDetail.CurrentCell = dgDetail.Item(8, i)
                'dgDetail.Focus()
                f_blnCheckData = True
                checkData1 = True
                Exit Function
            End If
        Next

        checkData1 = f_blnCheckData
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        save()
    End Sub
    Private Sub save()
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String

        Dim ComSave As New SqlClient.SqlCommand
        Dim trn As SqlClient.SqlTransaction
        Dim i As Integer
        Dim sender As New System.Object
        Dim e As New System.EventArgs
        Dim cmdCom2 As New SqlClient.SqlCommand


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

            If bln_AddOn = True Then


                If MsgQuestion("SAVE") = 6 Then

                    str1 = "Insert into QuotationMaster (QuotationNo,QuotationDate,CustomerCode, QuotationVersion, QuotationType,ValidUpto,QuotationFor,QuotationHeading,PaymentCode,Description,NetValue,TotalValue,Currency,ConvFact,Approve,CreatedBy) values('" & txtQuotationNo.Text & "','" & convertToServerDateFormat(dtpDate.Value) & "','" & CustomerCode & "', '" & cboQuotationVersion.Text & "','" & cboQuotationType.Text & "','" & convertToServerDateFormat(dtpValidUpto.Value) & "','" & cboQuotationFor.Text & "','" & txtQuotationHeading.Text & "','" & PaymentCode & "','" & txtDescription.Text & "','" & Val(txtNetValue.Text) & "','" & Val(txttotalvalue.Text) & "','" & cboCurrency.Text & "','" & cboCurrency.SelectedValue & "','0','" & gl_EmpName & "')"
                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    With dgDetail
                        For i = 0 To .RowCount - 1
                            str1 = "Insert into QuotationDetail(QuotationNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,Remark,Invoice,InvoiceNo,SNO) values('" & txtQuotationNo.Text & "','" & (.Rows(i).Cells(1).Value.ToString) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & "," & Val(.Rows(i).Cells(11).Value) & "," & Val(.Rows(i).Cells(12).Value) & ",'" & (.Rows(i).Cells(14).Value.ToString) & "',0,''," & Val(.Rows(i).Cells(0).Value) & ")"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()

                        Next
                    End With


                    dgConditions.RowCount = 1
                    With dgConditions
                        For i = 0 To .RowCount - 1
                            str1 = "Insert into QuotationTermsAndConditions(QuotationNo,SNo,TCCode) values('" & txtQuotationNo.Text & "','" & (.Rows(i).Cells(0).Value) & "','" & (.Rows(i).Cells(1).Value.ToString) & "')"


                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                    End With
                    dgConditions.RowCount = dgConditions.RowCount - 1

                    str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='Quotation'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()


                    Call Display(Trim(txtQuotationNo.Text))

                    bln_AddOn = False
                    bln_EditOn = False

                End If
            ElseIf bln_EditOn = True Then

                If MsgQuestion("UPDATE") = 6 Then

                    str1 = "update QuotationMaster set QuotationDate='" & convertToServerDateFormat(dtpDate.Value) & "',CustomerCode='" & CustomerCode & "', QuotationVersion='" & cboQuotationVersion.Text & "',QuotationType='" & cboQuotationType.Text & "', ValidUpto='" & convertToServerDateFormat(dtpValidUpto.Value) & "',QuotationFor='" & cboQuotationFor.Text & "',QuotationHeading ='" & txtQuotationHeading.Text & "',PaymentCode='" & PaymentCode & "',Description='" & txtDescription.Text & "',NetValue='" & Val(txtNetValue.Text) & "',TotalValue='" & Val(txttotalvalue.Text) & "' ,Currency='" & cboCurrency.Text & "',ConvFact='" & ConvFact & "', ModifyBy='" & gl_EmpName & "' where QuotationNo='" & txtQuotationNo.Text & "'"

                    trn = gl_Con.BeginTransaction
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    str1 = "Delete From QuotationDetail where QuotationNo='" & txtQuotationNo.Text & "'"
                    ComSave = New SqlClient.SqlCommand(str1, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()


                    With dgDetail
                        For i = 0 To .RowCount - 1
                            str1 = "Insert into QuotationDetail(QuotationNo,ItemCode,Qty, SubQty, Rate,SubRate,Amount,StockOnDate,SubStockOnDate,Remark,Invoice,InvoiceNo,SNO) values('" & txtQuotationNo.Text & "','" & (.Rows(i).Cells(1).Value.ToString) & "'," & Val(.Rows(i).Cells(4).Value) & ",'" & Val(.Rows(i).Cells(6).Value) & "'," & Val(.Rows(i).Cells(8).Value) & "," & Val(.Rows(i).Cells(9).Value) & "," & Val(.Rows(i).Cells(10).Value) & "," & Val(.Rows(i).Cells(11).Value) & "," & Val(.Rows(i).Cells(12).Value) & ",'" & (.Rows(i).Cells(14).Value.ToString) & "',0,''," & Val(.Rows(i).Cells(0).Value) & ")"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()

                        Next
                    End With


                    str1 = "Delete from QuotationTermsAndConditions where QuotationNo='" & txtQuotationNo.Text & "'"

                    ComSave = New SqlClient.SqlCommand(str1, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.Transaction = trn
                    ComSave.ExecuteNonQuery()


                    dgConditions.RowCount = 1
                    With dgConditions
                        For i = 0 To .RowCount - 1
                            str1 = "Insert into QuotationTermsAndConditions(QuotationNo,SNo,TCCode) values('" & txtQuotationNo.Text & "','" & (.Rows(i).Cells(0).Value) & "','" & (.Rows(i).Cells(1).Value.ToString) & "')"

                            cmdCom1.Transaction = trn
                            cmdCom1.Connection = gl_Con
                            cmdCom1.CommandText = str1
                            cmdCom1.ExecuteNonQuery()
                        Next
                    End With
                    dgConditions.RowCount = dgConditions.RowCount - 1


                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()
                    Call Display(Trim(txtQuotationNo.Text))


                    bln_AddOn = False
                    bln_EditOn = False
                End If

            End If



        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Designgrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 7
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "QuotationNo"
            .Columns(1).Width = 80
            .Columns(2).Name = "QuotationDate"
            .Columns(2).Width = 90
            .Columns(3).Name = "Curstomer Name"
            .Columns(3).Width = 250
            .Columns(4).Name = "Version"
            .Columns(4).Width = 80
            .Columns(5).Name = "Type"
            .Columns(5).Width = 100
            .Columns(6).Name = "For"
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

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid1()
        da1.Dispose()
        ds1.Clear()
        search = 0

        Try

            StrQuery = "SELECT     QuotationMaster.QuotationNo, QuotationMaster.QuotationDate, CustomerMaster1.CustomerName, QuotationMaster.QuotationVersion,    QuotationMaster.QuotationType, QuotationMaster.QuotationFor, QuotationMaster.ValidUpto  FROM         QuotationMaster INNER JOIN   CustomerMaster1 ON QuotationMaster.CustomerCode = CustomerMaster1.CustomerCode order by QuotationMaster.QuotationNo"
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "QuotationMaster")
            dgSearch.RowCount = 1
            If ds1.Tables("QuotationMaster").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("QuotationMaster").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("QuotationMaster").Rows(i).Item("QuotationNo")), "", ds1.Tables("QuotationMaster").Rows(i).Item("QuotationNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(ds1.Tables("QuotationMaster").Rows(i).Item("QuotationDate"))), "", convertToServerDateFormat(ds1.Tables("QuotationMaster").Rows(i).Item("QuotationDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("QuotationMaster").Rows(i).Item("CustomerName")), "", ds1.Tables("QuotationMaster").Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds1.Tables("QuotationMaster").Rows(i).Item("QuotationVersion")), "", ds1.Tables("QuotationMaster").Rows(i).Item("QuotationVersion"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds1.Tables("QuotationMaster").Rows(i).Item("QuotationType")), "", ds1.Tables("QuotationMaster").Rows(i).Item("QuotationType"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds1.Tables("QuotationMaster").Rows(i).Item("QuotationFor")), "", ds1.Tables("QuotationMaster").Rows(i).Item("QuotationFor"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearch.Text = ""
            txtSearch.Focus()
            cboSearch.Text = ""
            lblRow.Text = "Quotation No"
            gbSearch.BringToFront()
            gbMain.SendToBack()
            gbSearchInvoice.BringToFront()
            gbSearchCustomer.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




    End Sub

    Private Sub cboSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearch.SelectedIndexChanged
        lblRow.Text = cboSearch.Text
        txtSearch.Text = ""
        txtSearch.Focus()
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
                dv = New DataView(ds1.Tables("QuotationMaster"), "QuotationNo Like '" & Trim(txtSearch.Text) & "*" & "'", "QuotationNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 1 Then
                dv = New DataView(ds1.Tables("QuotationMaster"), True, "QuotationDate", DataViewRowState.CurrentRows)
                'dv = New DataView(ds.Tables(0), "QuotationDate '" & Trim(txtSearch.Text) & "*" & "'", "QuotationNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 2 Then
                dv = New DataView(ds1.Tables("QuotationMaster"), "CustomerName Like '" & Trim(txtSearch.Text) & "*" & "'", "QuotationNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 3 Then
                dv = New DataView(ds1.Tables("QuotationMaster"), "QuotationVersion Like '" & Trim(txtSearch.Text) & "*" & "'", "QuotationNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 4 Then
                dv = New DataView(ds1.Tables("QuotationMaster"), "QuotationType Like '" & Trim(txtSearch.Text) & "*" & "'", "QuotationNo", DataViewRowState.CurrentRows)
            ElseIf cboSearch.SelectedIndex = 5 Then
                dv = New DataView(ds1.Tables("QuotationMaster"), "QuotationFor Like '" & Trim(txtSearch.Text) & "*" & "'", "QuotationNo", DataViewRowState.CurrentRows)
            Else
                dv = New DataView(ds1.Tables("QuotationMaster"), "QuotationNo Like '" & Trim(txtSearch.Text) & "*" & "'", "QuotationNo", DataViewRowState.CurrentRows)
            End If
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("QuotationNo")), "", dTable.Rows(i).Item("QuotationNo"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(convertToServerDateFormat(dTable.Rows(i).Item("QuotationDate"))), "", convertToServerDateFormat(dTable.Rows(i).Item("QuotationDate")))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("CustomerName")), "", dTable.Rows(i).Item("CustomerName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("QuotationVersion")), "", dTable.Rows(i).Item("QuotationVersion"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("QuotationType")), "", dTable.Rows(i).Item("QuotationType"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("QuotationFor")), "", dTable.Rows(i).Item("QuotationFor"))

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

    Private Sub cboSearchCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchCustomer.SelectedIndexChanged
        lblRowSearch.Text = cboSearchCustomer.Text
        txtSearchCustomer.Text = ""
        txtSearchCustomer.Focus()
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

    Private Sub txtSearchDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchDescription.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
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

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
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
            Display(txtQuotationNo.Text)
        End If

        bln_AddOn = False
        bln_EditOn = False
        cmdApprove.Enabled = True

    End Sub
    Public Sub Display(Optional ByVal QuotationNo As String = "-1")
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
            If QuotationNo = "-1" Then

                str1 = "SELECT QuotationMaster.Currency,QuotationMaster.ConvFact,    QuotationMaster.ID, QuotationMaster.Approve, QuotationMaster.TotalValue, QuotationMaster.QuotationNo, QuotationMaster.QuotationDate,  QuotationMaster.CustomerCode, CustomerMaster1.CustomerName, QuotationMaster.QuotationVersion, QuotationMaster.PaymentCode,   QuotationMaster.QuotationType, QuotationMaster.ValidUpto, QuotationMaster.QuotationFor, QuotationMaster.QuotationHeading,  QuotationMaster.NetValue, QuotationDetail.ItemCode, QuotationDetail.Qty, QuotationDetail.SNo, QuotationDetail.SubQty, QuotationDetail.Rate,   QuotationDetail.SubRate, QuotationDetail.Amount, QuotationDetail.Remark, QuotationDetail.StockOnDate, QuotationDetail.SubStockOnDate,   CustomerMaster1.Address, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode,   ItemMaster.ItemName, ItemMaster.Code, ItemMaster.MAke, ItemMaster.Category, ItemMaster.Unit, ItemMaster.ConvFAct, ItemMaster.StoreUnit,  QuotationDetail.Invoice,  ItemMaster.OpeningStock, ItemMaster.CurrentStock, ItemMaster.OpeningSubStock, ItemMaster.CurrentSubStock, ItemMaster.Price,  ItemMaster.PurchasePrice, ItemMaster.Remarks, QuotationMaster.Description, PaymentTermMaster.Days,  PaymentTermMaster.Description AS PaymentTerms FROM         QuotationMaster INNER JOIN  QuotationDetail ON QuotationMaster.QuotationNo = QuotationDetail.QuotationNo INNER JOIN CustomerMaster1 ON QuotationMaster.CustomerCode = CustomerMaster1.CustomerCode INNER JOIN  LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode INNER JOIN  StateMaster ON CityMaster.StateCode = StateMaster.StateCode INNER JOIN  ItemMaster ON QuotationDetail.ItemCode = ItemMaster.ItemCode LEFT OUTER JOIN  PaymentTermMaster ON QuotationMaster.PaymentCode = PaymentTermMaster.PaymentTermCode WHERE     (QuotationMaster.ID = (SELECT     MAX(ID) FROM     QuotationMaster)) ORDER BY QuotationDetail.SNo"
            Else
                str1 = "SELECT   QuotationMaster.Currency,QuotationMaster.ConvFact,   QuotationMaster.ID, QuotationMaster.Approve, QuotationMaster.TotalValue, QuotationMaster.QuotationNo, QuotationMaster.QuotationDate,  QuotationMaster.CustomerCode, CustomerMaster1.CustomerName, QuotationMaster.QuotationVersion, QuotationMaster.PaymentCode,   QuotationMaster.QuotationType, QuotationMaster.ValidUpto, QuotationMaster.QuotationFor, QuotationMaster.QuotationHeading, QuotationDetail.Invoice , QuotationMaster.NetValue, QuotationDetail.ItemCode, QuotationDetail.Qty, QuotationDetail.SNo, QuotationDetail.SubQty, QuotationDetail.Rate,   QuotationDetail.SubRate, QuotationDetail.Amount, QuotationDetail.Remark, QuotationDetail.StockOnDate, QuotationDetail.SubStockOnDate,   CustomerMaster1.Address, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode,   ItemMaster.ItemName, ItemMaster.Code, ItemMaster.MAke, ItemMaster.Category, ItemMaster.Unit, ItemMaster.ConvFAct, ItemMaster.StoreUnit,   ItemMaster.OpeningStock, ItemMaster.CurrentStock, ItemMaster.OpeningSubStock, ItemMaster.CurrentSubStock, ItemMaster.Price,  ItemMaster.PurchasePrice, ItemMaster.Remarks, QuotationMaster.Description, PaymentTermMaster.Days,  PaymentTermMaster.Description AS PaymentTerms FROM         QuotationMaster INNER JOIN  QuotationDetail ON QuotationMaster.QuotationNo = QuotationDetail.QuotationNo INNER JOIN CustomerMaster1 ON QuotationMaster.CustomerCode = CustomerMaster1.CustomerCode INNER JOIN  LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode INNER JOIN  StateMaster ON CityMaster.StateCode = StateMaster.StateCode INNER JOIN  ItemMaster ON QuotationDetail.ItemCode = ItemMaster.ItemCode LEFT OUTER JOIN  PaymentTermMaster ON QuotationMaster.PaymentCode = PaymentTermMaster.PaymentTermCode WHERE    (QuotationMaster.QuotationNo=    '" & QuotationNo & "') ORDER BY QuotationDetail.SNo"
            End If





            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "Quotation")

            If dsDS1.Tables("Quotation").Rows.Count > 0 Then

                Approve = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("Approve")), 0, dsDS1.Tables("Quotation").Rows(0).Item("Approve"))
                If Approve = 1 Then
                    cmdApprove.Text = "Approved"
                    cmdEdit.Enabled = False
                Else
                    cmdApprove.Text = "Approve"
                    cmdEdit.Enabled = True
                End If

                txtQuotationNo.Tag = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("ID")), "", dsDS1.Tables("Quotation").Rows(0).Item("ID"))
                txtQuotationNo.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("QuotationNo")), "", dsDS1.Tables("Quotation").Rows(0).Item("QuotationNo"))
                txtDate.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("Quotation").Rows(0).Item("QuotationDate"))), "", convertToServerDateFormat(dsDS1.Tables("Quotation").Rows(0).Item("QuotationDate")))


                txtAddress.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("Address")), "", dsDS1.Tables("Quotation").Rows(0).Item("Address")) & " , " & IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("LocalityName")), "", dsDS1.Tables("Quotation").Rows(0).Item("LocalityName")) & ", " & IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("CityName")), "", dsDS1.Tables("Quotation").Rows(0).Item("CItyName")) & " ," & IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("PINCode")), "", dsDS1.Tables("Quotation").Rows(0).Item("PINCode")) & "," & IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("StateName")), "", dsDS1.Tables("Quotation").Rows(0).Item("StateName"))

                txtCustomerName.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("CustomerName")), "", dsDS1.Tables("Quotation").Rows(0).Item("CustomerName"))
                txtQuotationVersion.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("QuotationVersion")), "", dsDS1.Tables("Quotation").Rows(0).Item("QuotationVersion"))
                cboQuotationVersion.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("QuotationVersion")), "", dsDS1.Tables("Quotation").Rows(0).Item("QuotationVersion"))

                txtQuotationHeading.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("QuotationHeading")), "", dsDS1.Tables("Quotation").Rows(0).Item("QuotationHeading"))
                CustomerCode = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("CustomerCode")), "", dsDS1.Tables("Quotation").Rows(0).Item("CustomerCode"))
                txtQuotationType.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("QuotationType")), "", dsDS1.Tables("Quotation").Rows(0).Item("QuotationType"))
                cboQuotationType.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("QuotationType")), "", dsDS1.Tables("Quotation").Rows(0).Item("QuotationType"))
                txtValidUpto.Text = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("Quotation").Rows(0).Item("ValidUpto"))), "", convertToServerDateFormat(dsDS1.Tables("Quotation").Rows(0).Item("ValidUpto")))
                dtpValidUpto.Value = IIf(IsDBNull(convertToServerDateFormat(dsDS1.Tables("Quotation").Rows(0).Item("ValidUpto"))), "", convertToServerDateFormat(dsDS1.Tables("Quotation").Rows(0).Item("ValidUpto")))
                txtQuotationFor.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("QuotationFor")), "", dsDS1.Tables("Quotation").Rows(0).Item("QuotationFor"))
                cboQuotationFor.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("QuotationFor")), "", dsDS1.Tables("Quotation").Rows(0).Item("QuotationFor"))

                txtCurrency.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("Currency")), "", dsDS1.Tables("Quotation").Rows(0).Item("Currency"))

                cboCurrency.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("Currency")), "", dsDS1.Tables("Quotation").Rows(0).Item("Currency"))
                ConvFact = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("ConvFact")), "", dsDS1.Tables("Quotation").Rows(0).Item("ConvFact"))

                txtQuotationHeading.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("QuotationHeading")), "", dsDS1.Tables("Quotation").Rows(0).Item("QuotationHeading"))
                PaymentCode = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("PaymentCode")), "", dsDS1.Tables("Quotation").Rows(0).Item("PaymentCode"))

                txtPaymentTerms.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("PaymentTerms")), "", dsDS1.Tables("Quotation").Rows(0).Item("PaymentTerms"))

                txtDescription.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("Description")), "", dsDS1.Tables("Quotation").Rows(0).Item("Description"))
                txtNetValue.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("NetValue")), "", dsDS1.Tables("Quotation").Rows(0).Item("NetValue"))

                txttotalvalue.Text = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(0).Item("TotalValue")), "", dsDS1.Tables("Quotation").Rows(0).Item("TotalValue"))
                cmdApprove.Enabled = True

                dgDetail.RowCount = 1
                With dgDetail
                    For i = 0 To dsDS1.Tables("Quotation").Rows.Count - 1
                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("SNo")), "", dsDS1.Tables("Quotation").Rows(i).Item("SNo"))
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("ItemCode")), "", dsDS1.Tables("Quotation").Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("ItemName")), "", dsDS1.Tables("Quotation").Rows(i).Item("ItemName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("Category")), "", dsDS1.Tables("Quotation").Rows(i).Item("Category"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("Qty")), "", dsDS1.Tables("Quotation").Rows(i).Item("Qty"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("Unit")), "", dsDS1.Tables("Quotation").Rows(i).Item("Unit"))

                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("SubQty")), "", dsDS1.Tables("Quotation").Rows(i).Item("SubQty"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("StoreUnit")), "", dsDS1.Tables("Quotation").Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("Rate")), "", dsDS1.Tables("Quotation").Rows(i).Item("Rate"))

                        .Rows(i).Cells(9).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("SubRate")), "", dsDS1.Tables("Quotation").Rows(i).Item("SubRate"))
                        .Rows(i).Cells(10).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("Amount")), "", dsDS1.Tables("Quotation").Rows(i).Item("Amount"))

                        .Rows(i).Cells(11).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("CurrentStock")), "", dsDS1.Tables("Quotation").Rows(i).Item("CurrentStock"))

                        .Rows(i).Cells(12).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("CurrentSubStock")), "", dsDS1.Tables("Quotation").Rows(i).Item("CurrentSubStock"))

                        .Rows(i).Cells(13).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("ConvFAct")), "", dsDS1.Tables("Quotation").Rows(i).Item("ConvFAct"))
                        .Rows(i).Cells(14).Value = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("Remark")), "", dsDS1.Tables("Quotation").Rows(i).Item("Remark"))

                        invoice = IIf(IsDBNull(dsDS1.Tables("Quotation").Rows(i).Item("invoice")), 0, dsDS1.Tables("Quotation").Rows(i).Item("invoice"))
                        If cmdApprove.Enabled = False Then
                            GoTo here
                        End If


                        If invoice = 1 Then
                            cmdApprove.Enabled = False
                        Else
                            cmdApprove.Enabled = True
                        End If

here:               Next
                End With
                dgDetail.RowCount = dgDetail.RowCount - 1
            End If


            txtCustomerName.Focus()

            daDA1.Dispose()
            dsDS1.Clear()

            str1 = "SELECT     TCMaster.Description, QuotationMaster.QuotationNo, QuotationTermsAndConditions.SNo, QuotationTermsAndConditions.TCCode FROM QuotationTermsAndConditions INNER JOIN QuotationMaster ON QuotationTermsAndConditions.QuotationNo = QuotationMaster.QuotationNo INNER JOIN TCMaster ON QuotationTermsAndConditions.TCCode = TCMaster.TCCode WHERE (QuotationTermsAndConditions.QuotationNo= '" & txtQuotationNo.Text & "') ORDER BY QuotationTermsAndConditions.SNo "


            daDA1 = New SqlClient.SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "TermsAndConditions")

            If dsDS1.Tables("TermsAndConditions").Rows.Count > 0 Then

                dgConditions.RowCount = 1
                For i = 0 To dsDS1.Tables("TermsAndConditions").Rows.Count - 1
                    With dgConditions
                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = IIf(IsDBNull(dsDS1.Tables("TermsAndConditions").Rows(i).Item("SNO")), "", dsDS1.Tables("TermsAndConditions").Rows(i).Item("SNO"))
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("TermsAndConditions").Rows(i).Item("TCCode")), "", dsDS1.Tables("TermsAndConditions").Rows(i).Item("TCCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dsDS1.Tables("TermsAndConditions").Rows(i).Item("Description")), "", dsDS1.Tables("TermsAndConditions").Rows(i).Item("Description"))

                    End With
                Next
                dgConditions.RowCount = dgConditions.RowCount - 1

            End If

            daDA1.Dispose()
            dsDS1.Clear()


            str1 = "SELECT QuotationOverHeads.QuotationNo, QuotationOverHeads.Description,QuotationOverHeads.Code, QuotationOverHeads.PlusMinus, QuotationOverHeads.Percentage, QuotationOverHeads.Amount, QuotationOverHeads.TotalAmount, QuotationOverHeads.CalcOn,QuotationOverHeads.Remarks,QuotationOverHeads.SNo FROM QuotationOverHeads WHERE (QuotationOverHeads.QuotationNo= '" & txtQuotationNo.Text & "') "


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
                        gbMain.Enabled = True
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
                strMinMaxKey = "select max(ID) AS MaxId,MIN(ID) As MinId from QuotationMaster"
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

                        strNextRecord = "select QuotationNo  from QuotationMaster where ID=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "SaleNavigation")

                        txtQuotationNo.Text = dsMinMaxKey.Tables("SaleNavigation").Rows(0).Item("QuotationNo")
                        Call Display(txtQuotationNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If txtQuotationNo.Tag = dsMinMaxKey.Tables("Sale").Rows(0).Item("minId") Then
                            nextKey = CDbl(txtQuotationNo.Tag)
                        Else
                            nextKey = CLng(txtQuotationNo.Tag) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Sale").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select QuotationNo from QuotationMaster where ID=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "SaleNavigation")

                            If dsMinMaxKey.Tables("SaleNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Sale").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtQuotationNo.Text = dsMinMaxKey.Tables("SaleNavigation").Rows(0).Item("QuotationNo")
                        Call Display(txtQuotationNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If txtQuotationNo.Tag = dsMinMaxKey.Tables("Sale").Rows(0).Item("maxId") Then
                            nextKey = CDbl(txtQuotationNo.Tag)
                        Else
                            nextKey = CLng(txtQuotationNo.Tag) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Sale").Rows(0).Item("maxId")
                            strNextRecord = "select QuotationNo from QuotationMaster where ID=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "SaleNavigation")

                            If dsMinMaxKey.Tables("SaleNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Sale").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtQuotationNo.Text = dsMinMaxKey.Tables("SaleNavigation").Rows(0).Item("QuotationNo")
                        Call Display(txtQuotationNo.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Sale").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select QuotationNo from QuotationMaster where ID=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "SaleNavigation")

                        txtQuotationNo.Text = dsMinMaxKey.Tables("SaleNavigation").Rows(0).Item("QuotationNo")
                        Call Display(txtQuotationNo.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
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

    Private Sub cmdOverhead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOverhead.Click
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

    Private Sub cboConfig_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConfig.SelectedIndexChanged
        Dim strQuery As String
        Dim drConfigD As SqlClient.SqlDataReader
        Dim comConfigD As New SqlClient.SqlCommand
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

    Private Sub cmdConfigOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConfigOk.Click
        Cal()
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
                        txtQuotationNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtQuotationNo.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtQuotationNo.Text)
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
                    cboQuotationVersion.Focus()
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
    Private Sub DesignGridItem1()

        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 10



            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 350
            .Columns(3).Name = "Category"
            .Columns(3).Width = 150
            .Columns(4).Name = "Make"
            .Columns(4).Width = 80
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(6).Name = "SubStock"
            .Columns(6).Width = 80
            .Columns(7).Name = "SubUnit"
            .Columns(7).Width = 80
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80
            .Columns(9).Name = "Rate"
            .Columns(9).Width = 90

            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False

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

            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 80
            .Columns(2).Name = "ItemName"
            .Columns(2).Width = 350
            .Columns(3).Name = "Category"
            .Columns(3).Width = 150
            .Columns(4).Name = "Make"
            .Columns(4).Width = 80
            .Columns(5).Name = "Unit"
            .Columns(5).Width = 80
            .Columns(6).Name = "SubStock"
            .Columns(6).Width = 80
            .Columns(7).Name = "SubUnit"
            .Columns(7).Width = 80
            .Columns(8).Name = "ConvFact"
            .Columns(8).Width = 80
            .Columns(9).Name = "Rate"
            .Columns(9).Width = 90

            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False

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


    Private Sub cmdAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddItem.Click
        checkData()
        If checkData() = True Then '''''''''''''Checking data
            MsgDisplay(f_strDataCheck) ''calling function in main module 

            Exit Sub
        End If

        Dim StrQuery As String
        Dim i As Integer
        
        DesignGridItem1()
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
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("Make")), "", ds2.Tables("ItemMaster").Rows(i).Item("Make"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("Unit")), "", ds2.Tables("ItemMaster").Rows(i).Item("Unit"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("CurrentSubStock")), 0, ds2.Tables("ItemMaster").Rows(i).Item("CurrentSubStock"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("StoreUnit")), "", ds2.Tables("ItemMaster").Rows(i).Item("StoreUnit"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("ConvFAct")), "", ds2.Tables("ItemMaster").Rows(i).Item("ConvFAct"))
                        .Rows(i).Cells(9).Value = IIf(IsDBNull(ds2.Tables("ItemMaster").Rows(i).Item("Price")), "", ds2.Tables("ItemMaster").Rows(i).Item("Price"))




                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSelectItem.RowCount = 0
            End If


            lblSearchItem.Text = "Item Name"
            txtSearchItemName.Text = ""
            txtSearchItemName.Focus()
            cboSearchItem.Text = ""

            gbSelectItem.BringToFront()
            gbMain.SendToBack()
            gbSearchItem.BringToFront()
            gbSearchTermCondition.SendToBack()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboSearchItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchItem.SelectedIndexChanged
        lblSearchItem.Text = cboSearchItem.Text
        txtSearchItemName.Text = ""
        txtSearchItemName.Focus()
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
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("Make")), "", dTable.Rows(i).Item("Make"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("Unit")), "", dTable.Rows(i).Item("Unit"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("CurrentSubStock")), 0, dTable.Rows(i).Item("CurrentSubStock"))
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
        If e.ColumnIndex > 0 Then
            With dgSelectItem
                If AddItem = 1 Then
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

                ElseIf AddItem = 0 Then
                    If dgSelectItem.RowCount = 0 Then
                        MessageBox.Show("No Record Found")
                        gbMain.BringToFront()
                        gbSelectItem.SendToBack()
                        Exit Sub
                    Else
                        DirectFillTCGrid()
                        intDGSearchKeayPress = 0
                        gbMain.BringToFront()
                        gbSelectItem.SendToBack()
                    End If
                End If

            End With
        End If
    End Sub

    Private Sub dgSelectItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelectItem.CellEnter
        If e.ColumnIndex <> 0 Then
            dgSelectItem.EditMode = DataGridViewEditMode.EditProgrammatically

        Else
            dgSelectItem.EditMode = DataGridViewEditMode.EditOnEnter

        End If
       
    End Sub
    Private Sub dgSelectItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSelectItem.DoubleClick
        'With dgSelectItem
        '    If AddItem = 1 Then
        '        If dgSelectItem.RowCount = 0 Then
        '            MessageBox.Show("No Record Found")
        '            gbMain.BringToFront()
        '            gbSelectItem.SendToBack()
        '            Exit Sub
        '        Else
        '            DirectFillItemGrid()
        '            intDGSearchKeayPress = 0
        '            gbMain.BringToFront()
        '            gbSelectItem.SendToBack()
        '        End If
        '        'ElseIf AddItem = 2 Then
        '        '    If dgSelectItem.RowCount = 0 Then
        '        '        MessageBox.Show("No Record Found")
        '        '        gbMain.BringToFront()
        '        '        gbSelectItem.SendToBack()
        '        '        Exit Sub
        '        '    Else
        '        '        If .RowCount > 1 And intDGSearchKeayPress = 1 Then
        '        '            CustomerCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
        '        '            txtCustomerName.Text = dgSelectItem(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

        '        '            txtAddress.Text = dgSelectItem(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSelectItem(4, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSelectItem(5, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString & " " & dgSelectItem(6, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

        '        '        Else
        '        '            CustomerCode = dgSelectItem(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
        '        '            txtCustomerName.Text = dgSelectItem(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
        '        '            txtAddress.Text = dgSelectItem(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSelectItem(4, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSelectItem(5, Convert.ToInt32(.CurrentRow.Index)).Value.ToString & " " & dgSelectItem(6, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
        '        '        End If
        '        '        intDGSearchKeayPress = 0
        '        '        cboQuotationVersion.Focus()
        '        '        gbMain.BringToFront()
        '        '        gbSelectItem.SendToBack()
        '        '    End If
        '    ElseIf AddItem = 0 Then
        '        If dgSelectItem.RowCount = 0 Then
        '            MessageBox.Show("No Record Found")
        '            gbMain.BringToFront()
        '            gbSelectItem.SendToBack()
        '            Exit Sub
        '        Else
        '            DirectFillTCGrid()
        '            intDGSearchKeayPress = 0
        '            gbMain.BringToFront()
        '            gbSelectItem.SendToBack()
        '        End If
        '    End If

        'End With
    End Sub
    Private Sub DirectFillItemGrid()
        Dim i As Integer

        Dim ItemCode As String
        Dim iRow As Integer
        Dim drDisplay As DataRow
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim StrQuery As String
        Dim blnAdd As Boolean


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


            'ItemCode = fgSelectItem.get_TextMatrix(fgSelectItem.RowSel, 1)
            'CODE = fgSelectItem.get_TextMatrix(fgSelectItem.RowSel, 1)

            StrQuery = "SELECT * from ItemMaster WHERE  itemcode='" & ItemCode & "' order by itemname"
            da = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            ds.Clear()
            da.Fill(ds, "ItemList")


            blnAdd = False

            ItemCode = ""


            If blnAdd = False Then
                dgDetail.RowCount = dgDetail.RowCount + 1
                For iRow = 0 To ds.Tables("ItemList").Rows.Count - 1
                    drDisplay = ds.Tables("ItemList").Rows(iRow)
                    If AddItem = 1 Then
                        With dgDetail
                            .RowCount = .RowCount + 1
                            .Rows(.RowCount - 2).Cells(0).Value = .RowCount - 1
                            .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode"))
                            .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName"))
                            .Rows(.RowCount - 2).Cells(3).Value = IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category"))

                            .Rows(.RowCount - 2).Cells(11).Value = IIf(IsDBNull(drDisplay.Item("Make")), "", drDisplay.Item("Make"))
                            .Rows(.RowCount - 2).Cells(5).Value = IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit"))
                            .Rows(.RowCount - 2).Cells(12).Value = IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock"))
                            .Rows(.RowCount - 2).Cells(7).Value = IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit"))
                            .Rows(.RowCount - 2).Cells(13).Value = IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct"))
                            .Rows(.RowCount - 2).Cells(8).Value = IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price"))
                            .Rows(.RowCount - 2).Cells(9).Value = Val(.Rows(.RowCount - 2).Cells(8).Value) / Val(.Rows(.RowCount - 2).Cells(13).Value)


                            'ElseIf AddItem = 2 Then
                            '    With fgDetail

                            '        .set_TextMatrix(.RowSel, 1, IIf(IsDBNull(drDisplay.Item("ItemCode")), "", drDisplay.Item("ItemCode")))
                            '        .set_TextMatrix(.RowSel, 2, IIf(IsDBNull(drDisplay.Item("ItemName")), "", drDisplay.Item("ItemName")))
                            '        .set_TextMatrix(.RowSel, 3, IIf(IsDBNull(drDisplay.Item("Category")), "", drDisplay.Item("Category")))

                            '        .set_TextMatrix(.RowSel, 11, IIf(IsDBNull(drDisplay.Item("Make")), "", drDisplay.Item("Make")))
                            '        .set_TextMatrix(.RowSel, 5, IIf(IsDBNull(drDisplay.Item("Unit")), "", drDisplay.Item("Unit")))
                            '        .set_TextMatrix(.RowSel, 12, IIf(IsDBNull(drDisplay.Item("CurrentSubStock")), 0, drDisplay.Item("CurrentSubStock")))
                            '        .set_TextMatrix(.RowSel, 7, IIf(IsDBNull(drDisplay.Item("StoreUnit")), "", drDisplay.Item("StoreUnit")))
                            '        .set_TextMatrix(.RowSel, 13, IIf(IsDBNull(drDisplay.Item("ConvFAct")), "", drDisplay.Item("ConvFAct")))
                            '        .set_TextMatrix(.RowSel, 8, IIf(IsDBNull(drDisplay.Item("Price")), "", drDisplay.Item("Price")))

                            '        .set_TextMatrix(.RowSel, 9, Val(.get_TextMatrix(.RowSel, 8)) / Val(.get_TextMatrix(.RowSel, 13)))

                        End With
                    End If
                Next
                dgDetail.RowCount = dgDetail.RowCount - 1
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
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
    Private Sub DesignGridTermCondtion()
        With dgSelectItem
            .RowCount = 1
            .ColumnCount = 3
           
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
            da2.Fill(ds2, "ItemList")
            dgSelectItem.RowCount = 1
            If ds2.Tables("ItemList").Rows.Count > 0 Then
                With dgSelectItem
                    For i = 0 To ds2.Tables("ItemList").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = False

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds2.Tables("ItemList").Rows(i).Item("TCCode")), "", ds2.Tables("ItemList").Rows(i).Item("TCCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds2.Tables("ItemList").Rows(i).Item("Description")), "", ds2.Tables("ItemList").Rows(i).Item("Description"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSelectItem.RowCount = 0
            End If

            txtSearchTC.Text = ""
            txtSearchTC.Focus()
            gbSelectItem.BringToFront()
            gbMain.SendToBack()
            gbSearchItem.SendToBack()
            gbSearchTermCondition.BringToFront()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtSearchTC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchTC.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSelectItem.Focus()
        End If
    End Sub

    Private Sub txtSearchTC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchTC.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        Try

            dv = New DataView(ds2.Tables("ItemList"), "Description Like '" & "*" & Trim(txtSearchTC.Text) & "*" & "'", "TCCode", DataViewRowState.CurrentRows)

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

    Private Sub CmdDelTerms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDelTerms.Click
        Dim i As Integer
        If dgConditions.RowCount >= 1 Then
            If MsgQuestion("DELETE") = 7 Then
                Exit Sub
            Else
                dgConditions.Rows.Remove(dgConditions.CurrentRow)

                For i = 0 To dgConditions.RowCount - 1
                    dgConditions.Rows(i).Cells(0).Value = i + 1
                Next
            End If
        Else
            MsgBox("No row to delete")
        End If
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



        strQuery = "Select Description, Code, PlusMinus, Percentage, Amount, TotalAmount, CalcOn from QuotationOverHeads   where QuotationNo='" & txtQuotationNo.Text & "' and Description='" & dgConfiguration.Rows(intRowsel).Cells(6).Value.ToString & "'"
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


            'If .get_TextMatrix(intRowsel, 6) = "Net Order Value" Then
            '    .set_TextMatrix(intRowsel, 4, Val(txtNetValue.Text) * (.get_TextMatrix(intRowsel, 3) / 100))
            '    .set_TextMatrix(intRowsel, 7, Val(txtNetValue.Text))
            'Else
            '    .set_TextMatrix(intRowsel, 4, Amt * (.get_TextMatrix(intRowsel, 3) / 100))
            '    .set_TextMatrix(intRowsel, 7, Amt)

            'End If
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
                txtTotalValue1.Text = Val(.Rows(i).Cells(5).Value)
            Next


        End With


        'With fgConfiguration
        '    For i = 1 To .Rows - 1
        '        If i = 1 Then
        '            If (.get_TextMatrix(i, 2)) = "+" Then
        '                .set_TextMatrix(i, 5, Val(txtNetValue.Text) + Val(.get_TextMatrix(i, 4)))
        '            Else
        '                .set_TextMatrix(i, 5, Val(txtNetValue.Text) - Val(.get_TextMatrix(i, 4)))
        '            End If
        '        Else
        '            If (.get_TextMatrix(i, 2)) = "+" Then
        '                .set_TextMatrix(i, 5, Val(.get_TextMatrix(i - 1, 5)) + Val(.get_TextMatrix(i, 4)))
        '            Else
        '                .set_TextMatrix(i, 5, Val(.get_TextMatrix(i - 1, 5)) - Val(.get_TextMatrix(i, 4)))
        '            End If


        '        End If

        '        TotalValue = fgConfiguration.get_TextMatrix(i, 5)
        '        txttotalvalue.Text = TotalValue
        '        txtTotalValue1.Text = fgConfiguration.get_TextMatrix(i, 5)

        '    Next

        'End With




        strQuery = "Delete from QuotationOverHeads where QuotationNo='" & Replace(Trim(txtQuotationNo.Text), "'", "''") & "'"
        ComSave = New SqlClient.SqlCommand(strQuery, gl_Con)
        ComSave.CommandType = CommandType.Text
        ComSave.Transaction = trn
        ComSave.ExecuteNonQuery()





        With dgConfiguration
            For i = 0 To .RowCount - 1
                strQuery = "Insert into QuotationOverHeads(QuotationNo, Description, Code, PlusMinus, Percentage, Amount, TotalAmount, CalcOn ,Remarks,SNo ) Values('" & Replace(Trim(txtQuotationNo.Text), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(0).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(1).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(2).Value), "'", "''") & "'," & Val(.Rows(i).Cells(3).Value) & "," & Val(.Rows(i).Cells(4).Value) & "," & Val(.Rows(i).Cells(5).Value) & ",'" & Replace(Trim(.Rows(i).Cells(6).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(7).Value), "'", "''") & "','" & Replace(Trim(.Rows(i).Cells(8).Value), "'", "''") & "')"
                ComSave = New SqlClient.SqlCommand(strQuery, gl_Con)
                ComSave.CommandType = CommandType.Text
                ComSave.Transaction = trn
                ComSave.ExecuteNonQuery()
            Next
        End With
    End Sub

    Private Sub dgDetail_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEnter
        If bln_AddOn = True Or bln_EditOn = True Then
            If e.ColumnIndex = 1 Or e.ColumnIndex = 4 Or e.ColumnIndex = 6 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Or e.ColumnIndex = 14 Then
                dgDetail.EditMode = DataGridViewEditMode.EditOnEnter
            Else
                dgDetail.EditMode = DataGridViewEditMode.EditProgrammatically
            End If
        End If

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If AddItem = 1 Then
            FillItemGrid()
         
        ElseIf AddItem = 0 Then
            FillTCGrid()
        End If

        gbMain.BringToFront()
        gbSelectItem.SendToBack()
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
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(12).Value = .Rows(i).Cells(6).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(7).Value = .Rows(i).Cells(7).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(13).Value = .Rows(i).Cells(8).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(8).Value = .Rows(i).Cells(9).Value.ToString
                        dgDetail.Rows(dgDetail.RowCount - 1).Cells(9).Value = Val(dgDetail.Rows(dgDetail.RowCount - 1).Cells(8).Value) / Val(dgDetail.Rows(dgDetail.RowCount - 1).Cells(13).Value)



                   




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

    Private Sub cmdApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String

        Dim trn As SqlClient.SqlTransaction


        Try

            If cmdApprove.Text = "Approve" Then
                If MsgQuestion("APPROVE") = 6 Then
                    trn = gl_Con.BeginTransaction

                    str1 = "update QuotationMaster set Approve=1 where QuotationNo='" & txtQuotationNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()


                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtQuotationNo.Text))

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


                    str1 = "update QuotationMaster set Approve=0 where QuotationNo='" & txtQuotationNo.Text & "'"
                    cmdCom1.Transaction = trn
                    cmdCom1.Connection = gl_Con
                    cmdCom1.CommandText = str1
                    cmdCom1.ExecuteNonQuery()

                    Call ENABLECONTROL(True)
                    cmdCom1.Dispose()

                    trn.Commit()



                    Call Display(Trim(txtQuotationNo.Text))
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
End Class