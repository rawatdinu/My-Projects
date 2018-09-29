Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class frmOverHeadMaster
    Dim bln_Add As Boolean
    Dim bln_Edit As Boolean
    Dim Statecode As String
    Dim f_StateCode As String
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String

    Dim intSEARCH As Integer
    Dim da As New SqlDataAdapter  'Searching 
    Dim ds As New DataSet         'searching
    Dim intDGSearchKeayPress As Integer


    'Dim f_blnOpen As Boolean
    'Dim f_blnAdd As Boolean
    'Dim f_blnEdit As Boolean
    'Dim f_blnPrint As Boolean
    ''''''''''''''''
    'Dim f_intRowFound As Integer ' FOR SEARCHING DATA
    'Dim f_strCategoryCode As String

    'Dim f_blnAddOn As Boolean = False
    'Dim f_blnEditOn As Boolean = False
    'Dim f_blnSaveAsOn As Boolean = False
    'Dim f_blnDoneModification As Boolean
    'Dim f_blnCalledFromClose As Boolean 'true when esc is pressed in the form 
    'Dim f_ctl As Control 'for setting focus after cancel=no
    Dim f_strConfgCode As String
    'Dim f_blnClick As Boolean
    'Dim f_intCnt As Integer
    'Dim f_strCriteria As String
    'Dim f_DAGrid As SqlClient.SqlDataAdapter
    'Dim f_DSGrid As New DataSet

    Private Sub frmOverHeadMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        OverHeadMaster = Nothing
    End Sub

    Private Sub frmOverHeadMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DesignGrid()
        ClearControl()
        EnableControl(True)
        Display()


    End Sub
    Private Sub DesignGrid()
        With dgDetail
            .RowCount = 1
            .ColumnCount = 10
            .Columns(0).Name = "Description"
            .Columns(0).Width = 130
            .Columns(1).Name = "%age"
            .Columns(1).Width = 50
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).Name = "+/-"
            .Columns(2).Width = 40
            .Columns(3).Name = "CalculatedOn"
            .Columns(3).Width = 150
            .Columns(4).Name = "S#"
            .Columns(4).Width = 50
            .Columns(5).Name = "Serial"
            .Columns(5).Width = 60
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(6).Name = "Lvl"
            .Columns(6).Width = 80
            .Columns(6).Visible = False
            .Columns(7).Name = "Calc On Code"
            .Columns(7).Width = 100
            .Columns(7).Visible = False
            .Columns(8).Name = "Ledger Name"
            .Columns(8).Width = 100
            .Columns(8).Visible = False
            .Columns(9).Name = "Code"
            .Columns(9).Width = 100
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
        txtRemarks.Text = ""
        dgDetail.RowCount = 0


    End Sub
    Private Sub EnableControl(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdSearch.Enabled = status
        cmdSave.Enabled = Not status
        cmdCancel.Enabled = Not status
        cmdPrint.Enabled = status

        cmdAddParent.Enabled = Not status
        cmdDeleteRow.Enabled = Not status

        txtConfigurationCode.ReadOnly = True
        txtRemarks.ReadOnly = status

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        EnableControl(False)
        bln_Edit = True
        bln_Add = False
        txtRemarks.Focus()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        EnableControl(False)
        ClearControl()
        bln_Add = True
        bln_Edit = False
        txtConfigurationCode.Text = showCode("Configuration")
        txtRemarks.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub
    Private Sub Cancel()

        If bln_Add Or bln_Edit Then

            If MsgQuestion("CANCEL") = 7 Then

                Exit Sub
            End If

        End If
        If bln_Add = True Then
            Display()
        Else
            Display(txtConfigurationCode.Text)
        End If


        Call EnableControl(True)

        ''''''''''''flag check
        bln_Add = False
        bln_Edit = False

        cmdAdd.Focus()

    End Sub
    Private Function checkData() As Boolean
        Dim i As Integer

        f_blnCheckData = False
        f_strDataCheck = ""

        For i = 0 To dgDetail.RowCount - 1
            If Trim(dgDetail.Rows(i).Cells(0).Value) = "" Then
                f_strDataCheck = "Description"
                dgDetail.Focus()
                f_blnCheckData = True
                checkData = True
                Exit Function
            End If

            If Trim(dgDetail.Rows(i).Cells(1).Value) = "" Then
                f_strDataCheck = "%age"
                dgDetail.Focus()
                f_blnCheckData = True
                checkData = True
                Exit Function
            End If
            If Trim(dgDetail.Rows(i).Cells(2).Value) = "" Then
                f_strDataCheck = "+/-"
                dgDetail.Focus()
                f_blnCheckData = True
                checkData = True
                Exit Function
            End If
            If Trim(dgDetail.Rows(i).Cells(2).Value) = "" Then
                f_strDataCheck = "Calculation ON"
                dgDetail.Focus()
                f_blnCheckData = True
                checkData = True
                Exit Function
            End If

        Next

        checkData = f_blnCheckData
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Save()
    End Sub
    Private Sub Save()
        Dim cmdCom1 As New SqlClient.SqlCommand
        Dim str1 As String
        Dim Trans1 As SqlClient.SqlTransaction
        Dim i As Integer


        Try
            f_strConfgCode = Trim(txtConfigurationCode.Text)
           
            If checkData() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            Else
                If bln_Add = True Then
                    If MsgQuestion("SAVE") = 6 Then

                        
                        str1 = "Insert into ConfigurationMaster(ConfigurationCode,Remarks) Values('" & f_strConfgCode & "','" & Trim(txtRemarks.Text) & "')"

                        Trans1 = gl_Con.BeginTransaction
                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()



                        With dgDetail
                            For i = 0 To .RowCount - 1
                              
                                str1 = "Insert into ConfigurationDetails(ConfigurationCode, Description, Percentage, PlusMinus, CalculatedOn, CalculatedOnSQ, SNo, Sequence, Lvl, Code) Values('" & f_strConfgCode & "','" & Trim(.Rows(i).Cells(0).Value.ToString) & "', '" & Val(.Rows(i).Cells(1).Value) & "','" & Trim(.Rows(i).Cells(2).Value.ToString) & "','" & Trim(.Rows(i).Cells(3).Value.ToString) & "','" & Trim(.Rows(i).Cells(7).Value.ToString) & "','" & Val(.Rows(i).Cells(4).Value.ToString) & "','" & Trim(.Rows(i).Cells(5).Value.ToString) & "','" & Trim(.Rows(i).Cells(6).Value.ToString) & "','" & Trim(.Rows(i).Cells(9).Value.ToString) & "' )"
                                cmdCom1.Transaction = Trans1
                                cmdCom1.Connection = gl_Con
                                cmdCom1.CommandText = str1
                                cmdCom1.ExecuteNonQuery()


                            Next
                        End With



                        str1 = "update sequencemaster set lastvalue=lastvalue+increment where head='Configuration'"

                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()


                        Trans1.Commit()
                        Call EnableControl(True)
                        bln_Add = False
                        cmdCom1.Dispose()

                    Else

                        Exit Sub
                    End If

                ElseIf bln_Edit = True Then

                    If MsgQuestion("UPDATE") = 6 Then


                        str1 = "update ConfigurationMaster set  Remarks='" & Replace(txtRemarks.Text, " '", "''") & "' where StateCode='" & f_strConfgCode & "'"

                        Trans1 = gl_Con.BeginTransaction
                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()



                        str1 = "Delete From ConfigurationDetails Where ConfigurationCode='" & f_strConfgCode & "'"
                        cmdCom1.Transaction = Trans1
                        cmdCom1.Connection = gl_Con
                        cmdCom1.CommandText = str1
                        cmdCom1.ExecuteNonQuery()

                        With dgDetail
                            For i = 0 To .RowCount - 1
                                str1 = "Insert into ConfigurationDetails(ConfigurationCode, Description, Percentage, PlusMinus, CalculatedOn, CalculatedOnSQ, SNo, Sequence, Lvl, Code) Values('" & f_strConfgCode & "','" & Trim(.Rows(i).Cells(0).Value.ToString) & "', '" & Val(.Rows(i).Cells(1).Value) & "','" & Trim(.Rows(i).Cells(2).Value.ToString) & "','" & Trim(.Rows(i).Cells(3).Value.ToString) & "','" & Trim(.Rows(i).Cells(7).Value.ToString) & "','" & Val(.Rows(i).Cells(4).Value.ToString) & "','" & Trim(.Rows(i).Cells(5).Value.ToString) & "','" & Trim(.Rows(i).Cells(6).Value.ToString) & "','" & Trim(.Rows(i).Cells(9).Value.ToString) & "' )"
                                cmdCom1.Transaction = Trans1
                                cmdCom1.Connection = gl_Con
                                cmdCom1.CommandText = str1
                                cmdCom1.ExecuteNonQuery()


                            Next
                        End With



                        Trans1.Commit()
                        cmdCom1.Dispose()
                        Call EnableControl(True)
                        bln_Edit = False
                    Else

                        Exit Sub
                    End If
                Else
                    Call EnableControl(True)
                    bln_Add = False
                    bln_Edit = False
                    Call ClearControl()
                End If
            End If


            Call Display(f_strConfgCode)

        Catch ex As Exception
            Trans1.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub Display(Optional ByVal strConfigCode As String = "-1")

        Dim cmdCom1 As New SqlCommand
        Dim daDA1 As SqlClient.SqlDataAdapter
        Dim dsDS1 As New DataSet
        Dim str1 As String

        Try

            Call ClearControl()
            If strConfigCode = "-1" Then

                str1 = "SELECT     ConfigurationMaster.ConfigurationID, ConfigurationMaster.ConfigurationCode, ConfigurationMaster.Remarks, ConfigurationDetails.Description,  ConfigurationDetails.Percentage, ConfigurationDetails.PlusMinus, ConfigurationDetails.CalculatedOn, ConfigurationDetails.CalculatedOnSQ,  ConfigurationDetails.SNo, ConfigurationDetails.Sequence, ConfigurationDetails.Lvl, ConfigurationDetails.Remarks AS Remarks2, ConfigurationDetails.Code FROM         ConfigurationDetails INNER JOIN ConfigurationMaster ON ConfigurationDetails.ConfigurationCode = ConfigurationMaster.ConfigurationCode WHERE     ( ConfigurationMaster.ConfigurationID = (SELECT     MAX(ConfigurationID)  FROM  ConfigurationMaster))"
            Else
                str1 = "SELECT     ConfigurationMaster.ConfigurationID, ConfigurationMaster.ConfigurationCode, ConfigurationMaster.Remarks, ConfigurationDetails.Description,  ConfigurationDetails.Percentage, ConfigurationDetails.PlusMinus, ConfigurationDetails.CalculatedOn, ConfigurationDetails.CalculatedOnSQ,  ConfigurationDetails.SNo, ConfigurationDetails.Sequence, ConfigurationDetails.Lvl, ConfigurationDetails.Remarks AS Remarks2, ConfigurationDetails.Code FROM         ConfigurationDetails INNER JOIN ConfigurationMaster ON ConfigurationDetails.ConfigurationCode = ConfigurationMaster.ConfigurationCode WHERE ConfigurationMaster.ConfigurationCode='" & strConfigCode & "'"

            End If

            daDA1 = New SqlDataAdapter(str1, gl_Con)
            daDA1.Fill(dsDS1, "Configuration")


            If dsDS1.Tables("Configuration").Rows.Count > 0 Then
                txtConfigurationCode.Tag = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(0).Item("ConfigurationID")), "", dsDS1.Tables("Configuration").Rows(0).Item("ConfigurationID"))
                txtConfigurationCode.Text = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(0).Item("ConfigurationCode")), "", dsDS1.Tables("Configuration").Rows(0).Item("ConfigurationCode"))
                txtRemarks.Text = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(0).Item("Remarks")), "", dsDS1.Tables("Configuration").Rows(0).Item("Remarks"))

                dgDetail.RowCount = 1
                If dsDS1.Tables("Configuration").Rows.Count > 0 Then
                    With dgDetail
                        For i = 0 To dsDS1.Tables("Configuration").Rows.Count - 1

                            .RowCount = .RowCount + 1
                            .Rows(i).Cells(0).Value = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(i).Item("Description")), "", dsDS1.Tables("Configuration").Rows(i).Item("Description"))
                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(i).Item("Percentage")), 0, dsDS1.Tables("Configuration").Rows(i).Item("Percentage"))

                            .Rows(i).Cells(2).Value = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(i).Item("PlusMinus")), "", dsDS1.Tables("Configuration").Rows(i).Item("PlusMinus"))
                            .Rows(i).Cells(3).Value = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(i).Item("CalculatedOn")), "", dsDS1.Tables("Configuration").Rows(i).Item("CalculatedOn"))

                            .Rows(i).Cells(4).Value = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(i).Item("SNo")), "", dsDS1.Tables("Configuration").Rows(i).Item("SNo"))
                            .Rows(i).Cells(5).Value = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(i).Item("Sequence")), "", dsDS1.Tables("Configuration").Rows(i).Item("Sequence"))

                            .Rows(i).Cells(6).Value = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(i).Item("Lvl")), "", dsDS1.Tables("Configuration").Rows(i).Item("Lvl"))
                            .Rows(i).Cells(7).Value = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(i).Item("CalculatedOnSQ")), "", dsDS1.Tables("Configuration").Rows(i).Item("CalculatedOnSQ"))

                            .Rows(i).Cells(9).Value = IIf(IsDBNull(dsDS1.Tables("Configuration").Rows(i).Item("Code")), "", dsDS1.Tables("Configuration").Rows(i).Item("Code"))

                        Next
                        .RowCount = .RowCount - 1
                    End With
                Else
                    dgSearch.RowCount = 0
                End If


            End If
            cmdAdd.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DesignGrid1()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 2
            .Columns(0).Name = "Code"
            .Columns(0).Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).Name = "Remarks"
            .Columns(1).Width = 100
            .Columns(1).Visible = True
            .RowTemplate.Height = 22
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
        intSEARCH = 0
        DesignGrid1()
        da.Dispose()
        ds.Clear()
        Try
            StrQuery = "SELECT     ConfigurationCode, Remarks FROM ConfigurationMaster ORDER BY ConfigurationCode"
            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "FillGrid")
            dgSearch.RowCount = 1
            If ds.Tables("FillGrid").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("FillGrid").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("ConfigurationCode")), "", ds.Tables("FillGrid").Rows(i).Item("ConfigurationCode"))
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("FillGrid").Rows(i).Item("Remarks")), "", ds.Tables("FillGrid").Rows(i).Item("Remarks"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            txtSearch.Text = ""
            txtSearch.Focus()
            gbSearch.BringToFront()
            gbMain.SendToBack()
            gbMain.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.DoubleClick
        With dgSearch
            If intSEARCH = 0 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbMain.Enabled = True
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then

                        txtConfigurationCode.Text = dgSearch(0, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        txtConfigurationCode.Text = dgSearch(0, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    Display(txtConfigurationCode.Text)
                    gbMain.BringToFront()
                    gbMain.Enabled = True
                    gbSearch.SendToBack()

                End If

            ElseIf intSEARCH = 1 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbMain.Enabled = True
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then

                        dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(0).Value = dgSearch(0, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(9).Value = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(0).Value = dgSearch(0, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(9).Value = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    gbMain.BringToFront()
                    gbMain.Enabled = True
                    gbSearch.SendToBack()

                End If
            ElseIf intSEARCH = 2 Then
                If dgSearch.RowCount = 0 Then
                    MessageBox.Show("No Record Found")
                    gbMain.BringToFront()
                    gbMain.Enabled = True
                    gbSearch.SendToBack()
                    Exit Sub
                Else
                    If .RowCount > 1 And intDGSearchKeayPress = 1 Then

                        dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(3).Value = dgSearch(0, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                        dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(7).Value = dgSearch(1, Convert.ToInt32(.CurrentRow.Index - 1)).Value.ToString
                    Else
                        dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(3).Value = dgSearch(0, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                        dgDetail.Rows(dgDetail.CurrentRow.Index).Cells(7).Value = dgSearch(1, Convert.ToInt32(.CurrentRow.Index)).Value.ToString
                    End If
                    intDGSearchKeayPress = 0
                    gbMain.BringToFront()
                    gbMain.Enabled = True
                    gbSearch.SendToBack()

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
            If intSEARCH = 0 Then

                dv = New DataView(ds.Tables("FillGrid"), "ConfigurationCode Like '" & Trim(txtSearch.Text) & "*" & "'", "ConfigurationCode", DataViewRowState.CurrentRows)
            ElseIf intSEARCH = 1 Then
                dv = New DataView(ds.Tables("DESCR"), "Description Like '" & Trim(txtSearch.Text) & "*" & "'", "", DataViewRowState.CurrentRows)
            End If

            dTable = dv.ToTable
            dgSearch.RowCount = 1
            If dTable.Rows.Count > 0 Then

                With dgSearch
                    For i = 0 To dTable.Rows.Count - 1

                        .RowCount = .RowCount + 1
                        If intSEARCH = 0 Then
                            .Rows(i).Cells(0).Value = IIf(IsDBNull(dTable.Rows(i).Item("ConfigurationCode")), "", dTable.Rows(i).Item("ConfigurationCode"))
                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("Remarks")), "", dTable.Rows(i).Item("Remarks"))
                        ElseIf intSEARCH = 1 Then
                            .Rows(i).Cells(0).Value = IIf(IsDBNull(dTable.Rows(i).Item("Description")), "", dTable.Rows(i).Item("Description"))
                            .Rows(i).Cells(1).Value = IIf(IsDBNull(dTable.Rows(i).Item("Code")), "", dTable.Rows(i).Item("Code"))

                        End If
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

    Private Sub cmdAddParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddParent.Click
        Dim i As Integer

        For i = 0 To dgDetail.RowCount - 1
            If Len(dgDetail.Rows(i).Cells(0).Value) = 0 Then
                MsgBox("Description", MsgBoxStyle.Information)
                dgDetail.CurrentCell = dgDetail.Item(0, i)
                Exit Sub
            End If
            If Len(dgDetail.Rows(i).Cells(1).Value) = 0 Then
                MsgBox("%age", MsgBoxStyle.Information)
                dgDetail.CurrentCell = dgDetail.Item(1, i)
                Exit Sub
            End If
            If Len(dgDetail.Rows(i).Cells(2).Value) = 0 Then
                MsgBox("+/-", MsgBoxStyle.Information)
                dgDetail.CurrentCell = dgDetail.Item(2, i)
                Exit Sub
            End If
            If Len(dgDetail.Rows(i).Cells(3).Value) = 0 Then
                MsgBox("Calculated On", MsgBoxStyle.Information)
                dgDetail.CurrentCell = dgDetail.Item(3, i)
                Exit Sub
            End If
        Next
        dgDetail.RowCount = dgDetail.RowCount + 1
        With dgDetail
            For i = 0 To .RowCount - 1
                .Rows(i).Cells(4).Value = i + 1
                .Rows(i).Cells(5).Value = (.Rows(i).Cells(4).Value.ToString).PadLeft(3, "0")
                .CurrentCell = .Item(0, i)
            Next
        End With

    End Sub

    Private Sub cmdDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRow.Click
        If dgDetail.RowCount >= 1 Then
            If MsgQuestion("DELETE") = 7 Then
                Exit Sub
            Else
                dgDetail.Rows.Remove(dgDetail.CurrentRow)
                With dgDetail
                    For i = 0 To .RowCount - 1
                        .Rows(i).Cells(4).Value = i + 1
                        .Rows(i).Cells(5).Value = (.Rows(i).Cells(4).Value.ToString).PadLeft(3, "0")
                    Next
                End With
            End If
        Else
            MsgBox("No row to delete")
        End If
    End Sub

    Private Sub dgDetail_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEnter
        If cmdSave.Enabled = True Then
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
                dgDetail.EditMode = DataGridViewEditMode.EditOnEnter
            Else
                dgDetail.EditMode = DataGridViewEditMode.EditProgrammatically

            End If
        End If
    End Sub
    Private Sub dgDetail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDetail.KeyPress
        With dgDetail
            If .CurrentCell.ColumnIndex = 0 Then
                intSEARCH = 1
                Call SearchDescriptioin()
            ElseIf .CurrentCell.ColumnIndex = 3 Then
                intSEARCH = 2
                Call SearchNetValue()

            End If

        End With

    End Sub
    Private Sub DesignGrid2()
        With dgSearch
            .RowCount = 1
            .ColumnCount = 2
            .Columns(0).Name = "Description"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(0).Width = 200
            .Columns(1).Name = "Code"
            .Columns(1).Width = 150
            .Columns(1).Visible = True

            .RowTemplate.Height = 20
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

    Private Sub SearchDescriptioin()
        Dim StrQuery As String
        Dim i As Integer
        DesignGrid2()
        da.Dispose()
        ds.Clear()

        Try

            StrQuery = "Select Code, Description From DescriptionMaster Order By Code"

            da = New SqlDataAdapter(StrQuery, gl_Con)
            da.Fill(ds, "DESCR")
            dgSearch.RowCount = 1
            If ds.Tables("DESCR").Rows.Count > 0 Then
                With dgSearch
                    For i = 0 To ds.Tables("DESCR").Rows.Count - 1

                        .RowCount = .RowCount + 1
                        .Rows(i).Cells(0).Value = IIf(IsDBNull(ds.Tables("DESCR").Rows(i).Item("Description")), "", ds.Tables("DESCR").Rows(i).Item("Description"))
                        .Rows(i).Cells(1).Value = IIf(IsDBNull(ds.Tables("DESCR").Rows(i).Item("Code")), "", ds.Tables("DESCR").Rows(i).Item("Code"))

                    Next
                    .RowCount = .RowCount - 1
                End With
            Else
                dgSearch.RowCount = 0
            End If
            lblSearch.Text = "Description"
            txtSearch.Text = ""
            txtSearch.Focus()
            gbSearch.BringToFront()
            gbMain.SendToBack()
            gbMain.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub SearchNetValue()
        Dim i As Integer
        Dim k As Integer
        With dgSearch
            .RowCount = 1
            .ColumnCount = 2
            .Columns(0).Name = "Description"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(0).Width = 208
            .Columns(1).Name = "SQ"
            .Columns(1).Width = 40
            .Columns(1).Visible = False

            .RowTemplate.Height = 20
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With


        dgSearch.RowCount = 1
        dgSearch.Rows(dgSearch.RowCount - 1).Cells(0).Value = "Net Order Value"
        dgSearch.Rows(dgSearch.RowCount - 1).Cells(1).Value = "0"
        k = dgDetail.RowCount - 1

        With dgSearch
            For i = 1 To k
                .RowCount = .RowCount + 1
                .Rows(i).Cells(0).Value = Trim(dgDetail.Rows(i - 1).Cells(0).Value.ToString)
                .Rows(i).Cells(1).Value = Trim(dgDetail.Rows(i - 1).Cells(9).Value.ToString)
            Next
        End With

        lblSearch.Text = "Description"
        txtSearch.Text = ""
        txtSearch.Focus()
        gbSearch.BringToFront()
        gbMain.SendToBack()
        gbMain.Enabled = False
    End Sub
End Class