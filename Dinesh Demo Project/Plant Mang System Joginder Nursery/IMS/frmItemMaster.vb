
Imports System.Data
Imports System.Data.SqlClient
Public Class frmItemMaster
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim f_ItemCode As String
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Dim OpeningStock As Double
    Dim OpeningSubStock As Double
    Dim CurrentStock As Double
    Dim CurrentSubStock As Double
    Dim diffopeningstock As Double
    Dim DiffOpeningSubStock As Double
    Dim intDGSearchKeayPress As Integer

    Dim da As New SqlDataAdapter  'For search in cmdSearach 
    Dim ds As New DataSet



    Private Sub frmItemMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ItemMaster = Nothing
    End Sub

    Private Sub EnableControl(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdPrint.Enabled = status
        cmdSearch.Enabled = status

        txtItemCode.ReadOnly = True
        txtItemName.ReadOnly = status
        txtConversion.ReadOnly = status

        txtOpeningStock.ReadOnly = status

        txtRemarks.ReadOnly = status
        txtSalePrice.ReadOnly = status
        txtPurchasePrice.ReadOnly = status
        txtCode.ReadOnly = status

        txtUnit.ReadOnly = True
        txtStoreUnit.ReadOnly = True
        txtMake.ReadOnly = True
        txtCategory.ReadOnly = True


        'txtItemCode.BackColor = Color.White
        'txtItemName.BackColor = Color.White
        'txtConversion.BackColor = Color.White
        'txtCurrentStock.BackColor = Color.White
        'txtOpeningStock.BackColor = Color.White

        'txtRemarks.BackColor = Color.White
        'txtPrice.BackColor = Color.White
        'txtCode.BackColor = Color.White
        'txtOpeningSubStock.BackColor = Color.White
        'txtCurrentSubStock.BackColor = Color.White
        'txtUnit.BackColor = Color.White
        'txtStoreUnit.BackColor = Color.White
        'txtMake.BackColor = Color.White
        'txtCategory.BackColor = Color.White

        If cmdSave.Enabled = True Then
            txtUnit.SendToBack()
            txtStoreUnit.SendToBack()
            txtMake.SendToBack()
            txtCategory.SendToBack()

            cboCategory.BringToFront()
            cboMake.BringToFront()
            cboStoreUnit.BringToFront()
            cboUnit.BringToFront()
        Else
            txtUnit.BringToFront()
            txtStoreUnit.BringToFront()
            txtMake.BringToFront()
            txtCategory.BringToFront()


            cboCategory.SendToBack()
            cboMake.SendToBack()
            cboStoreUnit.SendToBack()
            cboUnit.SendToBack()

        End If


    End Sub

    Private Sub ClearControl()

        txtItemName.Text = ""
        txtConversion.Text = 1
        txtCurrentStock.Text = 0
        txtOpeningStock.Text = 0

        txtSalePrice.Text = ""
        txtPurchasePrice.Text = ""
        txtRemarks.Text = ""
        cboCategory.Text = ""
        cboUnit.Text = ""
        cboStoreUnit.Text = ""
        cboMake.Text = ""
        txtCode.Text = ""
        txtOpeningSubStock.Text = 0
        txtCurrentSubStock.Text = 0

    End Sub

    Private Sub frmItemMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        TrapKeyDown(e.KeyCode)
    End Sub

    Private Sub frmItemMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EnableControl(True)
        Display()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        bln_AddOn = True
        bln_EditOn = False
        EnableControl(False)
        ClearControl()
        txtItemCode.Text = showCode("ItemCode")
        txtItemName.Focus()
    End Sub
    Private Sub FillCategory()
        Dim StrQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try


            StrQuery = "Select Distinct Category from ItemMaster order by Category"
            da = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "Category")

            If ds.Tables("Category").Rows.Count > 0 Then

                cboCategory.DataSource = ds.Tables("Category")
                cboCategory.DisplayMember = "Category"

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FillMake()
        Dim StrQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try


            StrQuery = "Select Distinct Make from ItemMaster order by Make"
            da = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "Make")
            If ds.Tables("Make").Rows.Count > 0 Then
                cboMake.DataSource = ds.Tables("Make")
                cboMake.DisplayMember = "Make"
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FillUnit()
        Dim StrQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try


            StrQuery = "Select distinct Unit  from ItemMaster order by Unit"
            da = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "Unit")
            If ds.Tables("Unit").Rows.Count > 0 Then
                cboUnit.DataSource = ds.Tables("Unit")
                cboUnit.DisplayMember = "Unit"

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FillStoreUnit()
        Dim StrQuery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try


            StrQuery = "Select distinct StoreUnit  from ItemMaster order by StoreUnit"
            da = New SqlClient.SqlDataAdapter(StrQuery, gl_Con)

            da.Fill(ds, "StoreUnit")
            If ds.Tables("StoreUnit").Rows.Count > 0 Then
                cboStoreUnit.DataSource = ds.Tables("StoreUnit")
                cboStoreUnit.DisplayMember = "StoreUnit"
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        bln_EditOn = True
        bln_AddOn = False
        EnableControl(False)
        txtItemName.Focus()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Save()
    End Sub
    Private Sub Save()
        Dim ComSave As SqlClient.SqlCommand
        Dim StrQuery As String
        Dim trn As SqlClient.SqlTransaction

        Try

            f_ItemCode = txtItemCode.Text

            If checkData() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            Else
                If bln_AddOn = True Then
                    If MsgQuestion("SAVE") = 6 Then
                        ''''''''inserting data into the table JobCard
                        StrQuery = "insert into ItemMaster (ItemCode,ItemName,Code,Make,Category,Unit,ConvFAct,StoreUnit,OpeningStock,CurrentStock,OpeningSubStock,CurrentSubStock, Price,PurchasePrice,Remarks)values('" & txtItemCode.Text & "','" & txtItemName.Text & "','" & txtCode.Text & "','" & cboMake.Text & "','" & cboCategory.Text & "','" & cboUnit.Text & "','" & txtConversion.Text & "','" & cboStoreUnit.Text & "','" & txtOpeningStock.Text & "','" & txtCurrentStock.Text & "','" & txtOpeningSubStock.Text & "','" & txtCurrentSubStock.Text & "', '" & Val(txtSalePrice.Text) & "'," & Val(txtPurchasePrice.Text) & ",'" & txtRemarks.Text & "')"

                        trn = gl_Con.BeginTransaction 'Transaction Start

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()


                        StrQuery = "Update  sequencemaster set lastvalue=lastvalue+1 where head='ItemCode'"
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        trn.Commit() ''''''''End transaction

                        Call EnableControl(True)

                        bln_AddOn = False
                        bln_EditOn = False ''setting boolean variable for add completion
                        Call ClearControl()

                    Else

                        Exit Sub
                    End If

                ElseIf bln_EditOn = True Then

                    If MsgQuestion("UPDATE") = 6 Then

                        StrQuery = "Update itemmaster Set ItemName='" & txtItemName.Text & "',Make='" & cboMake.Text & "',Category='" & cboCategory.Text & "', Unit='" & cboUnit.Text & "',ConvFact='" & txtConversion.Text & "',StoreUnit='" & cboStoreUnit.Text & "',OpeningStock='" & txtOpeningStock.Text & "',CurrentStock='" & txtCurrentStock.Text & "' ,Price='" & txtSalePrice.Text & "',PurchasePrice=" & Val(txtPurchasePrice.Text) & ", Remarks='" & txtRemarks.Text & "',Code='" & txtCode.Text & "',OpeningSubStock='" & txtOpeningSubStock.Text & "',CurrentSubStock='" & txtCurrentSubStock.Text & "' where ItemCode='" & txtItemCode.Text & "'"
                        trn = gl_Con.BeginTransaction
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()
                        trn.Commit()

                        Call EnableControl(True)

                        bln_AddOn = False
                        bln_EditOn = False
                        Call ClearControl()
                    Else

                        Exit Sub
                    End If
                Else
                    Call EnableControl(True)
                    bln_AddOn = False
                    bln_EditOn = False
                    Call ClearControl()
                End If
            End If


            Call Display(txtItemCode.Text)

        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Function checkData() As Boolean

        f_blnCheckData = False
        f_strDataCheck = ""


        If Trim(txtItemName.Text) = "" Then
            f_strDataCheck = "ItemName"
            txtItemName.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If

        checkData = f_blnCheckData
    End Function

    Private Sub Display(Optional ByVal f_display As String = "-1")
        Dim Strquery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try
            If f_display = "-1" Then
                Strquery = "SELECT   ItemId,  ItemCode,ItemName,Code,OpeningSubStock,CurrentSubStock,Make,category,Unit,ConvFact,StoreUnit,OpeningStock,CurrentStock, Price,PurchasePrice,Remarks FROM ItemMAster WHERE     (ItemId =(SELECT     MAX(ItemId) FROM          ItemMaster)) "
            Else
                Strquery = "SELECT   ItemId,  ItemCode,ItemName,Code,OpeningSubStock,CurrentSubStock,Make,category,Unit,ConvFact,StoreUnit,OpeningStock,CurrentStock, Price,PurchasePrice, Remarks FROM ItemMAster WHERE     ItemCode ='" & txtItemCode.Text & "'"
            End If

            da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
            da.Fill(ds, "ItemMaster")
            If ds.Tables("ItemMaster").Rows.Count > 0 Then
                lblPrimaryKey.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("ItemId")), "", ds.Tables("ItemMaster").Rows(0).Item("ItemId"))
                txtItemCode.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("ItemCode")), "", ds.Tables("ItemMaster").Rows(0).Item("ItemCode"))
                txtItemName.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("ItemName")), "", ds.Tables("ItemMaster").Rows(0).Item("ItemName"))
                cboMake.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("MAke")), "", ds.Tables("ItemMaster").Rows(0).Item("Make"))
                txtMake.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("MAke")), "", ds.Tables("ItemMaster").Rows(0).Item("Make"))
                txtCode.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("Code")), "", ds.Tables("ItemMaster").Rows(0).Item("Code"))
                txtOpeningSubStock.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("OpeningSubStock")), 0, ds.Tables("ItemMaster").Rows(0).Item("OpeningSubStock"))
                txtCurrentSubStock.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("CurrentSubStock")), 0, ds.Tables("ItemMaster").Rows(0).Item("CurrentSubStock"))
                cboCategory.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("category")), "", ds.Tables("ItemMaster").Rows(0).Item("category"))
                txtCategory.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("category")), "", ds.Tables("ItemMaster").Rows(0).Item("category"))
                cboUnit.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("Unit")), "", ds.Tables("ItemMaster").Rows(0).Item("Unit"))
                txtUnit.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("Unit")), "", ds.Tables("ItemMaster").Rows(0).Item("Unit"))
                txtConversion.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("ConvFact")), 0, ds.Tables("ItemMaster").Rows(0).Item("ConvFact"))
                cboStoreUnit.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("StoreUnit")), "", ds.Tables("ItemMaster").Rows(0).Item("StoreUnit"))
                txtStoreUnit.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("StoreUnit")), "", ds.Tables("ItemMaster").Rows(0).Item("StoreUnit"))
                txtOpeningStock.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("OpeningStock")), 0, ds.Tables("ItemMaster").Rows(0).Item("OpeningStock"))
                txtCurrentStock.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("CurrentStock")), 0, ds.Tables("ItemMaster").Rows(0).Item("CurrentStock"))

                txtSalePrice.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("Price")), 0.0, ds.Tables("ItemMaster").Rows(0).Item("Price"))
                txtPurchasePrice.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("PurchasePrice")), 0.0, ds.Tables("ItemMaster").Rows(0).Item("PurchasePrice"))
                txtRemarks.Text = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("Remarks")), "", ds.Tables("ItemMaster").Rows(0).Item("Remarks"))
                OpeningStock = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("OpeningStock")), 0, ds.Tables("ItemMaster").Rows(0).Item("OpeningStock"))
                OpeningSubStock = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("OpeningSubStock")), 0, ds.Tables("ItemMaster").Rows(0).Item("OpeningSubStock"))
                CurrentStock = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("CurrentStock")), 0, ds.Tables("ItemMaster").Rows(0).Item("CurrentStock"))
                CurrentSubStock = IIf(IsDBNull(ds.Tables("ItemMaster").Rows(0).Item("CurrentSubStock")), 0, ds.Tables("ItemMaster").Rows(0).Item("CurrentSubStock"))

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtOpeningStock_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOpeningStock.TextChanged
        If bln_AddOn = True Then
            txtOpeningSubStock.Text = Val(txtOpeningStock.Text) * Val(txtConversion.Text)
            txtCurrentStock.Text = Val(txtOpeningStock.Text)
        Else
            txtOpeningSubStock.Text = Val(txtOpeningStock.Text) * Val(txtConversion.Text)
            txtCurrentStock.Text = 0
            diffopeningstock = Val(txtOpeningStock.Text) - OpeningStock
            txtCurrentStock.Text = CurrentStock + diffopeningstock
        End If

        'If bln_AddOn = True Or bln_EditOn = True Then
        '    txtOpeningSubStock.Text = Val(txtOpeningStock.Text) * Val(txtConversion.Text)
        'End If
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
            Display(txtItemCode.Text)
        End If

        Call EnableControl(True)

        ''''''''''''flag check
        bln_AddOn = False
        bln_EditOn = False

        cmdAdd.Focus()

    End Sub

    Private Sub txtOpeningSubStock_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOpeningSubStock.TextChanged
        If bln_AddOn = True Then
            txtCurrentSubStock.Text = Val(txtOpeningSubStock.Text)
        Else
            txtCurrentSubStock.Text = 0
            DiffOpeningSubStock = Val(txtOpeningSubStock.Text) - OpeningSubStock
            txtCurrentSubStock.Text = CurrentSubStock + DiffOpeningSubStock
        End If
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim StrQuery As String
        Dim i As Integer
        Designgrid()
        da.Dispose()
        ds.Clear()

        Try
            StrQuery = "Select * from ItemMaster order by Itemname"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ItemCode")), "", ds.Tables("FillGrid").Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Code")), "", ds.Tables("FillGrid").Rows(i).Item("Code"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ItemName")), "", ds.Tables("FillGrid").Rows(i).Item("ItemName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Make")), "", ds.Tables("FillGrid").Rows(i).Item("Make"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CurrentStock")), "", ds.Tables("FillGrid").Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Unit")), "", ds.Tables("FillGrid").Rows(i).Item("Unit"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Category")), "", ds.Tables("FillGrid").Rows(i).Item("Category"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Price")), "", ds.Tables("FillGrid").Rows(i).Item("Price"))



                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearch.Text = ""
            txtSearchMake.Text = ""
            txtSearch.Focus()
            gbSearch.BringToFront()
            gbMain.SendToBack()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'gbSearch.BringToFront()
    'txtSearchMake.Text = ""
    'txtSearch.Text = ""


    'gbSearch.Enabled = True
    'gbSearch.BringToFront()
    'fgSearch.Enabled = True
    'Designgrid()
    'txtSearchMake.Text = ""
    'txtSearch.Text = ""

    'txtSearch.Focus()


    Private Sub Designgrid()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 9
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "ItemCode"
            .Columns(1).Width = 70
            .Columns(2).Name = "Code"
            .Columns(2).Width = 70
            .Columns(3).Name = "Item Name"
            .Columns(3).Width = 150
            .Columns(4).Name = "Make"
            .Columns(4).Width = 150
            .Columns(5).Name = "Stock"
            .Columns(5).Width = 70
            .Columns(6).Name = "Unit"
            .Columns(6).Width = 50
            .Columns(7).Name = "Category"
            .Columns(7).Width = 100
            .Columns(8).Name = "Price"
            .Columns(8).Width = 87
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
        '    .Cols = 9

        '    '.Width = 395
        '    '.Height = 406
        '    .set_TextMatrix(0, 0, "S.No.")
        '    .set_ColWidth(0, 500)

        '    .set_TextMatrix(0, 1, "ItemCode")
        '    .set_ColWidth(1, 1100)
        '    ' .set_ColHidden(1, True)
        '    .set_TextMatrix(0, 2, "Code")
        '    .set_ColWidth(2, 1000)

        '    .set_TextMatrix(0, 3, "ItemName")
        '    .set_ColWidth(3, 3000)
        '    .set_TextMatrix(0, 4, "Make")
        '    .set_ColWidth(4, 1500)
        '    .set_TextMatrix(0, 5, "Stock")
        '    .set_ColWidth(5, 1200)
        '    .set_TextMatrix(0, 6, "Unit")
        '    .set_ColWidth(6, 800)
        '    .set_ColHidden(6, True)
        '    ''.set_TextMatrix(0, 7, "SubStock")
        '    ''.set_ColWidth(7, 1000)
        '    ''.set_TextMatrix(0, 8, "SubUnit")
        '    ''.set_ColWidth(8, 1000)
        '    ''.set_TextMatrix(0, 9, "ConvFact")
        '    ''.set_ColWidth(9, 1000)
        '    .set_TextMatrix(0, 7, "Category")
        '    .set_ColWidth(7, 1500)
        '    .set_ColHidden(7, True)
        '    .set_TextMatrix(0, 8, "Price")
        '    .set_ColWidth(8, 1000)
        'End With

        'Strquery = "Select * from ItemMaster order by Itemname"
        'da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        'da.Fill(ds, "FillGrid")
        'With fgSearch
        '    .Rows = 1
        '    If ds.Tables("FillGrid").Rows.Count > 0 Then
        '        For i = 0 To ds.Tables("FillGrid").Rows.Count - 1
        '            .Rows = .Rows + 1
        '            .set_TextMatrix(i + 1, 0, i + 1)
        '            .set_TextMatrix(i + 1, 1, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ItemCode")), "", ds.Tables("FillGrid").Rows(i).Item("ItemCode")))
        '            .set_TextMatrix(i + 1, 2, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Code")), "", ds.Tables("FillGrid").Rows(i).Item("Code")))
        '            .set_TextMatrix(i + 1, 3, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ItemName")), "", ds.Tables("FillGrid").Rows(i).Item("ItemName")))
        '            .set_TextMatrix(i + 1, 4, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Make")), "", ds.Tables("FillGrid").Rows(i).Item("Make")))
        '            .set_TextMatrix(i + 1, 5, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CurrentStock")), "", ds.Tables("FillGrid").Rows(i).Item("CurrentStock")))
        '            .set_TextMatrix(i + 1, 6, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Unit")), "", ds.Tables("FillGrid").Rows(i).Item("Unit")))
        '            '.set_TextMatrix(i + 1, 7, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("CurrentSubStock")), "", ds.Tables("FillGrid").Rows(i).Item("CurrentSubStock")))
        '            '.set_TextMatrix(i + 1, 8, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("StoreUnit")), "", ds.Tables("FillGrid").Rows(i).Item("StoreUnit")))
        '            '.set_TextMatrix(i + 1, 9, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ConvFAct")), "", ds.Tables("FillGrid").Rows(i).Item("ConvFAct")))
        '            .set_TextMatrix(i + 1, 7, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Category")), "", ds.Tables("FillGrid").Rows(i).Item("Category")))
        '            .set_TextMatrix(i + 1, 8, IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Price")), "", ds.Tables("FillGrid").Rows(i).Item("Price")))
        '        Next
        '    End If


        'End With



    End Sub

    Private Sub FillComboCat()
        Dim strquery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet

        strquery = "select Category from Itemmaster order by Category"
        da = New SqlClient.SqlDataAdapter(strquery, gl_Con)
        da.Fill(ds, "Category")

        If ds.Tables("Category").Rows.Count > 0 Then
            cboCategory.DataSource = "Category"
            cboCategory.DisplayMember = "Category"


        End If
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        Me.Close()
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

                            EnableControl(True)
                            Display()
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
                strMinMaxKey = "select max(ItemId) AS MaxId,MIN(ItemId) As MinId from ItemMaster"
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

                        strNextRecord = "select ItemCode  from ItemMaster where ItemId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                        txtItemCode.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("ItemCode")
                        Call Display(txtItemCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F4 'Previous Record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) - 1
                        End If

                        For intCounter = dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") To nextKey
                            strNextRecord = "select ItemCode from ItemMaster where ItemId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                            If dsMinMaxKey.Tables("PurchaseNavigation").Rows.Count = 0 And nextKey > dsMinMaxKey.Tables("Purchase").Rows(0).Item("minId") Then
                                nextKey = nextKey - 1
                            Else
                                Exit For
                            End If
                        Next

                        txtItemCode.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("ItemCode")
                        Call Display(txtItemCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F5 'Next record
                        If lblPrimaryKey.Text = dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId") Then
                            nextKey = CDbl(lblPrimaryKey.Text)
                        Else
                            nextKey = CLng(lblPrimaryKey.Text) + 1
                        End If

                        For intCounter = nextKey To dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId")
                            strNextRecord = "select ItemCode from ItemMaster where ItemId=" & nextKey & ""
                            daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                            daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                            If dsMinMaxKey.Tables("PurchaseNavigation").Rows.Count = 0 And nextKey < dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId") Then
                                nextKey = nextKey + 1
                            Else
                                Exit For
                            End If
                        Next

                        txtItemCode.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("ItemCode")
                        Call Display(txtItemCode.Text)
                        dsMinMaxKey.Clear()

                    Case Keys.F6 'Last Record

                        nextKey = dsMinMaxKey.Tables("Purchase").Rows(0).Item("maxId") 'go to First Record

                        strNextRecord = "select ItemCode from ItemMaster where ItemId=" & nextKey & ""
                        daMinMaxKey = New SqlClient.SqlDataAdapter(strNextRecord, gl_Con)
                        daMinMaxKey.Fill(dsMinMaxKey, "PurchaseNavigation")

                        txtItemCode.Text = dsMinMaxKey.Tables("PurchaseNavigation").Rows(0).Item("ItemCode")
                        Call Display(txtItemCode.Text)
                        dsMinMaxKey.Clear()

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtsearchName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub


    Private Sub txtSearchCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchMake.KeyPress
        If (e.KeyChar = Convert.ToChar(13)) Then
            dgSearch.Focus()
        End If
    End Sub

    Private Sub txtRemarks_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRemarks.LostFocus
        txtItemName.Focus()
    End Sub

    Private Sub cboCategory_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.GotFocus
        FillCategory()
    End Sub

    Private Sub cboStoreUnit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStoreUnit.GotFocus
        FillStoreUnit()
    End Sub

    Private Sub cboUnit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnit.GotFocus
        FillUnit()
    End Sub

    Private Sub cboMake_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMake.GotFocus

        FillMake()
    End Sub

    Private Sub txtConversion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConversion.TextChanged
        txtOpeningStock_TextChanged(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Me.Close()
    End Sub

    Private Sub gbMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles gbMain.Paint

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
                    txtItemCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                Else
                    txtItemCode.Text = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                End If
                intDGSearchKeayPress = 0
                Display(txtItemCode.Text)
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

    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable
        txtSearchMake.Text = ""
        Try
            dv = New DataView(ds.Tables(0), "ItemName Like '" & Trim(txtSearch.Text) & "*" & "'", "ItemCode", DataViewRowState.CurrentRows)
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemCode")), "", dTable.Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("Code")), "", dTable.Rows(i).Item("Code"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemName")), "", dTable.Rows(i).Item("ItemName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("Make")), "", dTable.Rows(i).Item("Make"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("CurrentStock")), "", dTable.Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("Unit")), "", dTable.Rows(i).Item("Unit"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dTable.Rows(i).Item("Category")), "", dTable.Rows(i).Item("Category"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dTable.Rows(i).Item("Price")), "", dTable.Rows(i).Item("Price"))



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

    Private Sub txtSearchMake_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchMake.TextChanged
        Dim i As Integer
        Dim dv As New DataView
        Dim dTable As New DataTable

        Try
            dv = New DataView(ds.Tables(0), "Make Like '" & Trim(txtSearchMake.Text) & "*" & "'", "ItemCode", DataViewRowState.CurrentRows)
            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = i + 1

                        .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemCode")), "", dTable.Rows(i).Item("ItemCode"))
                        .Rows(i).Cells(2).Value = IIf(IsDBNull(dTable.Rows(i).Item("Code")), "", dTable.Rows(i).Item("Code"))
                        .Rows(i).Cells(3).Value = IIf(IsDBNull(dTable.Rows(i).Item("ItemName")), "", dTable.Rows(i).Item("ItemName"))
                        .Rows(i).Cells(4).Value = IIf(IsDBNull(dTable.Rows(i).Item("Make")), "", dTable.Rows(i).Item("Make"))

                        .Rows(i).Cells(5).Value = IIf(IsDBNull(dTable.Rows(i).Item("CurrentStock")), "", dTable.Rows(i).Item("CurrentStock"))
                        .Rows(i).Cells(6).Value = IIf(IsDBNull(dTable.Rows(i).Item("Unit")), "", dTable.Rows(i).Item("Unit"))
                        .Rows(i).Cells(7).Value = IIf(IsDBNull(dTable.Rows(i).Item("Category")), "", dTable.Rows(i).Item("Category"))
                        .Rows(i).Cells(8).Value = IIf(IsDBNull(dTable.Rows(i).Item("Price")), "", dTable.Rows(i).Item("Price"))


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
End Class