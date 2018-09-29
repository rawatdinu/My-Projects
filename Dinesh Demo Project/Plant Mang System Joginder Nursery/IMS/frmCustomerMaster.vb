
Imports System.Data
Imports System.Data.SqlClient
Public Class frmCustomerMaster
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim f_CustomerCode As String
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim search As Integer
    Dim LocalityCode As String
    Dim intDGSearchKeayPress As Integer

    Dim da As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds As New DataSet
    Dim da1 As New SqlDataAdapter   'Fro search in State Search
    Dim ds1 As New DataSet


    Private Sub frmCustomerMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        CustomerMaster = Nothing
    End Sub

    Private Sub frmCustomerMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmCustomerMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EnableControl(True)
        Display()
    End Sub
    Private Sub EnableControl(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status
        cmdSearch.Enabled = status
        cmdsearchCity.Enabled = Not status



        txtCustomerName.ReadOnly = status
        txtAddress.ReadOnly = status
        txtaddress1.ReadOnly = status

        txtEmail.ReadOnly = status
        txtwebsite.ReadOnly = status
        txtFax.ReadOnly = status
        txtPhone.ReadOnly = status
        txtTinNo.ReadOnly = status
        txtPANNo.ReadOnly = status
        txtCustomerCode.ReadOnly = True
        If bln_AddOn = True Then
            txtOpeningBalance.ReadOnly = False
        Else
            txtOpeningBalance.ReadOnly = True
        End If

        'txtCustomerCode.BackColor = Color.White
        'txtCustomerName.BackColor = Color.White
        'txtAddress.BackColor = Color.White
        'txtCity.BackColor = Color.White
        'txtState.BackColor = Color.White
        'txtCountry.BackColor = Color.White
        'txtPin.BackColor = Color.White
        'txtEmail.BackColor = Color.White
        'txtwebsite.BackColor = Color.White
        'txtFax.BackColor = Color.White
        'txtPhone.BackColor = Color.White
        'txtTinNo.BackColor = Color.White
        'txtPANNo.BackColor = Color.White


    End Sub



    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        bln_AddOn = True
        bln_EditOn = False
        EnableControl(False)
        ClearControl()
        txtCustomerCode.Text = showCode("Customer")
        txtCustomerName.Focus()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        bln_EditOn = True
        bln_AddOn = False
        EnableControl(False)
        txtCustomerName.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub
    Private Sub Cancel()

        If bln_AddOn Or bln_EditOn Then

            If MsgQuestion("CANCEL") = 7 Then

                Exit Sub
            End If

        End If
        If bln_AddOn = True Then
            Display()
        Else
            Display(txtCustomerCode.Text)
        End If


        Call EnableControl(True)

        ''''''''''''flag check
        bln_AddOn = False
        bln_EditOn = False


        cmdAdd.Focus()

    End Sub
    Private Sub ClearControl()
        txtCustomerName.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtState.Text = ""
        txtLocality.Text = ""
        txtPin.Text = ""
        txtEmail.Text = ""
        txtwebsite.Text = ""
        txtFax.Text = ""
        txtPhone.Text = ""
        txtTinNo.Text = ""
        txtPANNo.Text = ""
        txtOpeningBalance.Text = 0
        LocalityCode = ""
        txtaddress1.Text = ""
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Save()
    End Sub

    Private Function checkData() As Boolean

        f_blnCheckData = False
        f_strDataCheck = ""


        If Trim(txtCustomerName.Text) = "" Then
            f_strDataCheck = "CustomerName"
            txtCustomerName.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If

        If Trim(txtAddress.Text) = "" Then
            f_strDataCheck = "Address2"
            txtAddress.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If

        If Trim(txtaddress1.Text) = "" Then
            f_strDataCheck = "Address1"
            txtaddress1.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If

        If Trim(txtLocality.Text) = "" Then
            f_strDataCheck = "Locality"
            cmdsearchCity.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If


        checkData = f_blnCheckData
    End Function

    Private Sub Save()
        Dim ComSave As SqlClient.SqlCommand
        Dim StrQuery As String
        Dim trn As SqlClient.SqlTransaction

        Try

            f_CustomerCode = txtCustomerCode.Text

            If checkData() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            Else
                If bln_AddOn = True Then
                    If MsgQuestion("SAVE") = 6 Then
                        ''''''''inserting data into the table JobCard
                        StrQuery = "insert into CustomerMaster1 (CustomerCode,CustomerName,Address1,Address,LocalityCode,Phone,Fax, EmailId,Website,TINNo,PANNo,OpeningBalance,Balance)values('" & txtCustomerCode.Text & "','" & txtCustomerName.Text & "','" & txtaddress1.Text & "','" & txtAddress.Text & "','" & LocalityCode & "','" & txtPhone.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "','" & txtwebsite.Text & "','" & txtTinNo.Text & "','" & txtPANNo.Text & "'," & Val(txtOpeningBalance.Text) & "," & Val(txtOpeningBalance.Text) & ")"

                        trn = gl_Con.BeginTransaction 'Transaction Start

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        StrQuery = "insert into  LedgerMaster  (LedgerCode,OpeningBalance)values('" & txtCustomerCode.Text & "'," & Val(txtOpeningBalance.Text) & ")"

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        StrQuery = "Update  sequencemaster set lastvalue=lastvalue+1 where head='Customer'"
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        trn.Commit() ''''''''End transaction

                        Call EnableControl(True)

                        bln_AddOn = False ''setting boolean variable for add completion
                        Call ClearControl()

                    Else

                        Exit Sub
                    End If

                ElseIf bln_EditOn = True Then

                    If MsgQuestion("UPDATE") = 6 Then

                        StrQuery = "Update CustomerMaster1 Set CustomerName='" & txtCustomerName.Text & "',Address='" & txtAddress.Text & "',Address1='" & txtaddress1.Text & "', LocalityCode='" & LocalityCode & "',Phone='" & txtPhone.Text & "',Fax='" & txtFax.Text & "',EmailId='" & txtEmail.Text & "',Website='" & txtwebsite.Text & "',PANNo='" & txtPANNo.Text & "',TINNo='" & txtTinNo.Text & "',OpeningBalance=" & Val(txtOpeningBalance.Text) & " where CustomerCode='" & txtCustomerCode.Text & "'"
                        trn = gl_Con.BeginTransaction
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()



                        StrQuery = "delete from  LedgerMaster  where LedgerCode='" & txtCustomerCode.Text & "'"

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        StrQuery = "insert into  LedgerMaster  (LedgerCode,OpeningBalance)values('" & txtCustomerCode.Text & "'," & Val(txtOpeningBalance.Text) & ")"

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()







                        trn.Commit()

                        Call EnableControl(True)

                        bln_EditOn = False
                        Call ClearControl()
                    Else

                        Exit Sub
                    End If
                Else
                    Call EnableControl(True)

                    bln_EditOn = False
                    Call ClearControl()
                End If
            End If


            Call Display(txtCustomerCode.Text)

        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Display(Optional ByVal f_display As String = "-1")
        Dim Strquery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try
            If f_display = "-1" Then
                Strquery = "SELECT CustomerMaster1.Customerid,CustomerMaster1.OpeningBalance, CustomerMaster1.Customercode, CustomerMaster1.CustomerName, CustomerMaster1.Address,CustomerMaster1.Address1, CustomerMaster1.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode, CustomerMaster1.Phone, CustomerMaster1.Fax, CustomerMaster1.EmailId, CustomerMaster1.Website, CustomerMaster1.TINNo, CustomerMaster1.PAnNo, CustomerMaster1.Balance FROM ((CustomerMaster1 INNER JOIN LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode) INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode WHERE     (Customerid =(SELECT     MAX(Customerid) FROM          CustomerMaster1)) "
            Else
                Strquery = "SELECT CustomerMaster1.Customerid,CustomerMaster1.OpeningBalance, CustomerMaster1.Customercode, CustomerMaster1.CustomerName, CustomerMaster1.Address,CustomerMaster1.Address1, CustomerMaster1.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode, CustomerMaster1.Phone, CustomerMaster1.Fax, CustomerMaster1.EmailId, CustomerMaster1.Website, CustomerMaster1.TINNo, CustomerMaster1.PAnNo, CustomerMaster1.Balance FROM ((CustomerMaster1 INNER JOIN LocalityMaster ON CustomerMaster1.LocalityCode = LocalityMaster.LocalityCode) INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode  WHERE     Customercode ='" & txtCustomerCode.Text & "'"
            End If

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "CustomerMaster1")
            If ds.Tables("CustomerMaster1").Rows.Count > 0 Then
                lblPrimaryKey.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("CustomerId")), "", ds.Tables("CustomerMaster1").Rows(0).Item("CustomerId"))
                LocalityCode = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("LocalityCode")), "", ds.Tables("CustomerMaster1").Rows(0).Item("LocalityCode"))
                txtCustomerCode.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("Customercode")), "", ds.Tables("CustomerMaster1").Rows(0).Item("Customercode"))
                txtCustomerName.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("CustomerName")), "", ds.Tables("CustomerMaster1").Rows(0).Item("CustomerName"))
                txtAddress.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("Address")), "", ds.Tables("CustomerMaster1").Rows(0).Item("Address"))
                txtaddress1.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("Address1")), "", ds.Tables("CustomerMaster1").Rows(0).Item("Address1"))
                txtPANNo.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("PANNo")), "", ds.Tables("CustomerMaster1").Rows(0).Item("PANNo"))
                txtCity.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("CityName")), "", ds.Tables("CustomerMaster1").Rows(0).Item("CityName"))
                txtPin.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("PinCode")), "", ds.Tables("CustomerMaster1").Rows(0).Item("PinCode"))
                txtPhone.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("Phone")), "", ds.Tables("CustomerMaster1").Rows(0).Item("Phone"))
                txtFax.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("Fax")), "", ds.Tables("CustomerMaster1").Rows(0).Item("Fax"))
                txtTinNo.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("TINNo")), "", ds.Tables("CustomerMaster1").Rows(0).Item("TINNo"))
                txtState.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("StateName")), "", ds.Tables("CustomerMaster1").Rows(0).Item("StateName"))
                txtLocality.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("LocalityName")), "", ds.Tables("CustomerMaster1").Rows(0).Item("LocalityName"))
                txtEmail.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("EmailId")), "", ds.Tables("CustomerMaster1").Rows(0).Item("EmailId"))
                txtwebsite.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("Website")), "", ds.Tables("CustomerMaster1").Rows(0).Item("Website"))
                txtOpeningBalance.Text = IIf(IsDBNull(ds.Tables("CustomerMaster1").Rows(0).Item("OpeningBalance")), 0, ds.Tables("CustomerMaster1").Rows(0).Item("OpeningBalance"))
            End If
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
            If cmdCancel.Enabled = False Then
                Dim strMinMaxKey As String
                Dim intCounter As Integer

                'Query for selecting minimum and maximum ItemID
                strMinMaxKey = "select max(CustomerId) AS MaxId,MIN(CustomerId) As MinId from CustomerMaster1"
                Dim daMinMaxKey As SqlDataAdapter = New SqlDataAdapter(strMinMaxKey, gl_Con)
                Dim dsMinMaxKey As DataSet = New DataSet

                'fill the dataset with min and max Id's 
                'give the name to table "ItemID"

                daMinMaxKey.Fill(dsMinMaxKey, "Purchase")

                Dim strNextRecord As String
                Dim nextKey As Long

                Select Case key

                    Case Keys.F2 'Find
                        Dim sender As New System.Object
                        Dim e As New System.EventArgs
                        Call cmdSearch_Click(sender, e)

                    Case Keys.F3 'First Record

                        nextKey = dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") 'go to First Record

                        strNextRecord = "select CustomerCode  from CustomerMaster1 where CustomerId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                        txtCustomerCode.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("CustomerCode")
                        Call Display(txtCustomerCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select CustomerCode from CustomerMaster1 where CustomerId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                            If dsMinMaxKey.Tables("PurchaseNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtCustomerCode.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("CustomerCode")
                        Call Display(txtCustomerCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId")
                            strNextRecord = "select CustomerCode from CustomerMaster1 where CustomerId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                            If dsMinMaxKey.Tables("PurchaseNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtCustomerCode.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("CustomerCode")
                        Call Display(txtCustomerCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select CustomerCode from CustomerMaster1 where CustomerId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                        txtCustomerCode.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("CustomerCode")
                        Call Display(txtCustomerCode.Text)
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
            .ColumnCount = 5
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Code"
            .Columns(1).Width = 80
            .Columns(2).Name = "Curstomer Name"
            .Columns(2).Width = 150
            .Columns(3).Name = "Address 1"
            .Columns(3).Width = 180
            .Columns(4).Name = "Address 2"
            .Columns(4).Width = 180
            .RowHeadersVisible = False
            .RowTemplate.Height = 17
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
        da.Dispose()
        ds.Clear()
        search = 0

        Try
            lblSearch.Text = "Search Customer Name"
            StrQuery = "Select CustomerCode,Customername,Address,Customername,Address1 from Customermaster1 order by Customername"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerCode")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Customername")), "", ds.Tables("FillGrid").Rows(i).Item("Customername"))

                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Address1")), "", ds.Tables("FillGrid").Rows(i).Item("Address1"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Address")), "", ds.Tables("FillGrid").Rows(i).Item("Address"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            gbSearch.BringToFront()
            gbMain.SendToBack()
            txtSearch.Text = ""
            txtSearch.Focus()
           

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Designgrid()
        'Dim Strquery As String
        'Dim da As SqlClient.SqlDataAdapter
        'Dim ds As New DataSet
        'Dim i As Integer

        'search = 0
        'With fgSearch

        '    .Editable = VSFlex7L.EditableSettings.flexEDNone
        '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
        '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth
        '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
        '    .SelectionMode = VSFlex7L.SelModeSettings.flexSelectionByRow

        '    .Rows = 1
        '    .Cols = 5
        '    .Width = 638
        '    .Height = 383
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "Code")
        '    .set_ColWidth(1, 1200)
        '    .set_TextMatrix(0, 2, "CustomerName")
        '    .set_ColWidth(2, 3500)
        '    .set_TextMatrix(0, 3, "Address1")
        '    .set_ColWidth(3, 1500)
        '    .set_TextMatrix(0, 4, "Address2")
        '    .set_ColWidth(4, 3500)
        'End With

        'Strquery = "Select CustomerCode,Customername,Address,Customername,Address1 from Customermaster1 order by Customername"
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")
        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CustomerCode")), "", ds.Tables("FillGrid").Rows(i).Item("CustomerCode")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Customername")), "", ds.Tables("FillGrid").Rows(i).Item("Customername")))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Address1")), "", ds.Tables("FillGrid").Rows(i).Item("Address1")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Address")), "", ds.Tables("FillGrid").Rows(i).Item("Address")))
        '        Next
        '    End If


        'End With

        'End Sub
        'Private Sub fgsearch_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        '    If search = 1 Then
        '        LocalityCode = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
        '        txtLocality.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 2)
        '        txtCity.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 3)
        '        txtState.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 4)
        '        txtPin.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 5)
        '        gbSearch.SendToBack()
        '        Panel1.Enabled = True
        '        txtEmail.Focus()
        '    Else
        '        txtCustomerCode.Text = ""
        '        txtCustomerCode.Text = fgSearch.get_TextMatrix(fgSearch.RowSel, 1)
        '        Display("txtCustomerCode.Text")
        '        gbSearch.SendToBack()
        '        Panel1.Enabled = True
        '    End If


    End Sub

    Private Sub Designgrid2()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 6
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "Code"
            .Columns(1).Width = 80
            .Columns(2).Name = "Locality"
            .Columns(2).Width = 140
            .Columns(3).Name = "City"
            .Columns(3).Width = 140
            .Columns(4).Name = "State"
            .Columns(4).Width = 140
            .Columns(5).Name = "PIN"
            .Columns(5).Width = 90
            .RowHeadersVisible = False
            .RowTemplate.Height = 17
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With


    End Sub

    Private Sub cmdsearchCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsearchCity.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid2()
        da1.Dispose()
        ds1.Clear()
        search = 1

        Try
            lblSearch.Text = "Search Locality Name"
            StrQuery = "SELECT LocalityMaster.LocalityId, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM (LocalityMaster INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode order by LocalityMaster.LocalityName"
            da1 = New SqlDataAdapter(StrQuery, gl_Con)
            da1.Fill(ds1, "FillGrid")
            dgSearch.RowCount = 1
            If ds1.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds1.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("LocalityCode")), "", ds1.Tables("FillGrid").Rows(i).Item("LocalityCode"))

                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("LocalityName")), "", ds1.Tables("FillGrid").Rows(i).Item("LocalityName"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("CityName")), "", ds1.Tables("FillGrid").Rows(i).Item("CityName"))

                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("StateName")), "", ds1.Tables("FillGrid").Rows(i).Item("StateName"))
                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds1.Tables("FillGrid").Rows(i).Item("PinCode")), "", ds1.Tables("FillGrid").Rows(i).Item("PinCode"))



                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            gbSearch.BringToFront()
            gbMain.SendToBack()
            txtSearch.Text = ""
            txtSearch.Focus()
            

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FillCity()
        'Dim Strquery As String
        'Dim da As SqlClient.SqlDataAdapter
        'Dim ds As New DataSet
        'Dim i As Integer

        'search = 1
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

        '    .set_TextMatrix(0, 1, "Code")
        '    .set_ColWidth(1, 1000)
        '    .set_TextMatrix(0, 2, "Locality")
        '    .set_ColWidth(2, 3000)
        '    .set_TextMatrix(0, 3, "City")
        '    .set_ColWidth(3, 2000)
        '    .set_TextMatrix(0, 4, "State")
        '    .set_ColWidth(4, 1500)
        '    .set_TextMatrix(0, 5, "PIN")
        '    .set_ColWidth(5, 1000)
        'End With

        'Strquery = "SELECT LocalityMaster.LocalityId, LocalityMaster.LocalityCode, LocalityMaster.LocalityName, CityMaster.CityName, StateMaster.StateName, LocalityMaster.PinCode FROM (LocalityMaster INNER JOIN CityMaster ON LocalityMaster.CityCode = CityMaster.CityCode) INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode order by LocalityMaster.LocalityName"
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")


        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("LocalityCode")), "", ds.Tables("FillGrid").Rows(i).Item("LocalityCode")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("LocalityName")), "", ds.Tables("FillGrid").Rows(i).Item("LocalityName")))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CityName")), "", ds.Tables("FillGrid").Rows(i).Item("CityName")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("StateName")), "", ds.Tables("FillGrid").Rows(i).Item("StateName")))
        '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("PinCode")), "", ds.Tables("FillGrid").Rows(i).Item("PinCode")))
        '        Next
        '    End If


        'End With
    End Sub



    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Me.Close()
    End Sub

    Private Sub txtOpeningBalance_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOpeningBalance.LostFocus
        txtCustomerName.Focus()

    End Sub

    Private Sub txtCustomerName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerName.LostFocus
        txtaddress1.Focus()
    End Sub

    Private Sub txtaddress1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtaddress1.LostFocus
        txtAddress.Focus()
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
                        txtCustomerCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtCustomerCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtCustomerCode.Text)
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
                        LocalityCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtLocality.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtCity.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        txtState.Text = dgSearch(4, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString()
                        txtPin.Text = dgSearch(5, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString

                    Else
                        LocalityCode = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtLocality.Text = dgSearch(2, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtCity.Text = dgSearch(3, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        txtState.Text = dgSearch(4, Convert.ToInt32(.CurrentRow.Index)).Value.ToString()
                        txtPin.Text = dgSearch(5, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    gbMain.BringToFront()
                    gbSearch.SendToBack()
                    Panel1.Enabled = True
                    txtEmail.Focus()

                End If
            End If
        End With
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub dgSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSearch.KeyPress
        Dim e1 As System.EventArgs
        If (e.KeyChar = Convert.ToChar(13)) Then
            intDGSearchKeayPress = 1
            dgSearch_DoubleClick(sender, e1)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable

        Try
            If search = 0 Then
                dv = New DataView(ds.Tables(0), "Customername Like '" & Trim(txtSearch.Text) & "*" & "'", "CustomerCode", DataViewRowState.CurrentRows)
                dTable = dv.ToTable
                dgSearch.RowCount = 1
                If dTable.Rows.Count > 0 Then
                    With dgSearch
                        For i = 0 To dTable.Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = i + 1

                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("CustomerCode")), "", dTable.Rows(i).Item("CustomerCode"))
                            .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("Customername")), "", dTable.Rows(i).Item("Customername"))

                            .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("Address1")), "", dTable.Rows(i).Item("Address1"))
                            .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("Address")), "", dTable.Rows(i).Item("Address"))
                        Next
                        .RowCount = .RowCount - 1
                    End With
                Else
                    dgSearch.RowCount = 0
                End If
            ElseIf search = 1 Then
                dv = New DataView(ds1.Tables(0), "LocalityName Like '" & Trim(txtSearch.Text) & "*" & "'", "LocalityCode", DataViewRowState.CurrentRows)
                dTable = dv.ToTable
                dgSearch.RowCount = 1
                If dTable.Rows.Count > 0 Then
                    With dgSearch
                        For i = 0 To dTable.Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = i + 1
                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("LocalityCode")), "", dTable.Rows(i).Item("LocalityCode"))

                            .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("LocalityName")), "", dTable.Rows(i).Item("LocalityName"))
                            .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("CityName")), "", dTable.Rows(i).Item("CityName"))

                            .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("StateName")), "", dTable.Rows(i).Item("StateName"))
                            .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("PinCode")), "", dTable.Rows(i).Item("PinCode"))

                        Next
                        .RowCount = .RowCount - 1
                    End With
                Else
                    dgSearch.RowCount = 0
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class