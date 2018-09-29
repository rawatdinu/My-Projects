
Imports System.Data
Imports System.Data.SqlClient
Public Class frmCurrencyMaster
    Dim bln_EditOn As Boolean
    Dim bln_AddOn As Boolean
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String
    Private Sub EnableControl(ByVal Status As Boolean)
        CmdEdit.Enabled = Not Status
        CmdSave.Enabled = Status
        cmdcancel.Enabled = Status
        cmdDeleteRow.Enabled = Status
        cmdAdd.Enabled = Status
      
    End Sub
    Private Sub DesignGrid()
        With dgCurrency
            .RowCount = 1
            .ColumnCount = 4
            .Columns(0).Name = "S.No"
            .Columns(0).Width = 40
            .Columns(1).Name = "CurrencyName"
            .Columns(1).Width = 90
            .Columns(2).Name = "Symbol"
            .Columns(2).Width = 80
            .Columns(3).Name = "ConvFact"
            .Columns(3).Width = 80
            .RowTemplate.Height = 17
            .RowHeadersVisible = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowCount = 0
        End With
    End Sub
    Private Sub Display()
        Dim drItem As SqlClient.SqlDataReader
        Dim comItem As SqlClient.SqlCommand
        Dim strQuery As String

        Try
            'With fgCurrency
            '    .AllowUserResizing = VSFlex7L.AllowUserResizeSettings.flexResizeBoth
            '    .ExplorerBar = VSFlex7L.ExplorerBarSettings.flexExSortShow
            '    .ScrollBars = VSFlex7L.ScrollBarsSettings.flexScrollBarBoth

            '    .Rows = 1
            '    .Cols = 4
            '    .FixedCols = 0
            '    .set_ColWidth(0, 500)
            '    .set_TextMatrix(0, 0, "S.No.")
            '    .set_ColWidth(1, 1500)
            '    .set_TextMatrix(0, 1, "Currency Name")
            '    .set_ColWidth(2, 1000)
            '    .set_TextMatrix(0, 2, "Symbol")
            '    .set_ColWidth(3, 1000)
            '    .set_TextMatrix(0, 3, "Conv Fact")

            'End With




            strQuery = "SELECT     CurrencyName,Symbol, ConvFact FROM   CurrencyMaster order by CurrencyName"

            comItem = New SqlClient.SqlCommand(strQuery, gl_Con)
            drItem = comItem.ExecuteReader

            dgCurrency.RowCount = 1
            If drItem.HasRows Then

                With dgCurrency
                    While drItem.Read

                        .RowCount = .RowCount + 1
                        .Rows(.RowCount - 2).Cells(0).Value = .RowCount - 1
                        .Rows(.RowCount - 2).Cells(1).Value = IIf(IsDBNull(drItem.Item("CurrencyName")), "", drItem.Item("CurrencyName"))
                        .Rows(.RowCount - 2).Cells(2).Value = IIf(IsDBNull(drItem.Item("Symbol")), "", drItem.Item("Symbol"))

                        .Rows(.RowCount - 2).Cells(3).Value = IIf(IsDBNull(drItem.Item("ConvFact")), "", drItem.Item("ConvFact"))

                    End While
                    .RowCount = .RowCount - 1
                End With
            Else
                dgCurrency.RowCount = 0
            End If
            drItem.Close()




            'comItem = New SqlClient.SqlCommand(strQuery, gl_Con)
            'drItem = comItem.ExecuteReader
            'If drItem.HasRows Then
            '    With fgCurrency
            '        While drItem.Read
            '            .Rows = .Rows + 1
            '            .set_TextMatrix(.Rows - 1, 0, .Rows - 1)
            '            .set_TextMatrix(.Rows - 1, 1, IIf(IsDBNull(drItem.Item("CurrencyName")), "", drItem.Item("CurrencyName")))
            '            .set_TextMatrix(.Rows - 1, 2, IIf(IsDBNull(drItem.Item("Symbol")), "", drItem.Item("Symbol")))
            '            .set_TextMatrix(.Rows - 1, 3, IIf(IsDBNull(drItem.Item("ConvFact")), "", drItem.Item("ConvFact")))
            '        End While
            '    End With
            'End If
            'drItem.Close()
        Catch ex As Exception
            If drItem.IsClosed = False Then
                drItem.Close()
            End If
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmCurrencyMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        CurrencyMaster = Nothing
    End Sub

    Private Sub frmCurrencyMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DesignGrid()
        Display()
        EnableControl(False)
    End Sub

    Private Sub optBankRate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Display()
    End Sub

    Private Sub optGocRate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Display()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        bln_AddOn = True
        Dim introw As Integer
        Dim i As Integer
        'If bln_AddOn = True Or bln_EditOn = True Then
        '    dgCurrency.EditMode = DataGridViewEditMode.EditOnEnter
        '    fgCurrency.Editable = VSFlex7L.EditableSettings.flexEDKbdMouse
        'Else
        '    dgCurrency.EditMode = DataGridViewEditMode.EditProgrammatically
        '    fgCurrency.Editable = VSFlex7L.EditableSettings.flexEDNone
        'End If

        'For introw = 1 To fgCurrency.Rows - 1
        '    If Len(fgCurrency.get_TextMatrix(introw, 1)) = 0 Then
        '        MsgBox("Row Can Not Empty", MsgBoxStyle.Information)
        '        fgCurrency.Rows = introw
        '        fgCurrency.Col = 1
        '        fgCurrency.Focus()
        '        Exit Sub
        '    End If
        'Next
        'fgCurrency.Rows = fgCurrency.Rows + 1
        'For introw = 1 To fgCurrency.Rows - 1
        '    fgCurrency.set_TextMatrix(introw, 0, introw)
        'Next





        For i = 0 To dgCurrency.RowCount - 1
            If Len(dgCurrency.Rows(i).Cells(1).Value) = 0 Then
                MsgBox("Row Cannot be Empty", MsgBoxStyle.Information)
                dgCurrency.Focus()
                Exit Sub
            End If
        Next
        dgCurrency.RowCount = dgCurrency.RowCount + 1
        For i = 0 To dgCurrency.RowCount - 1
            dgCurrency.Rows(i).Cells(0).Value = i + 1

        Next




    End Sub


    Private Sub cmdDeleteRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDeleteRow.Click
        Dim i As Integer
        If dgCurrency.RowCount >= 1 Then
            If MsgQuestion("DELETE") = 7 Then
                Exit Sub
            Else
                dgCurrency.Rows.Remove(dgCurrency.CurrentRow)

                For i = 0 To dgCurrency.RowCount - 1
                    dgCurrency.Rows(i).Cells(0).Value = i + 1
                Next
            End If
        Else
            MsgBox("No row to delete")
        End If


        'With fgCurrency
        '    If .RowSel >= 1 Then
        '        If (bln_EditOn = True And MsgQuestion("Delete")) = 6 Then
        '            .RemoveItem(.RowSel)
        '            For i = 0 To .Rows - 1
        '                .set_TextMatrix(i, 0, i)
        '            Next

        '        End If
        '    End If
        'End With
    End Sub



    Private Sub CmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        bln_EditOn = True
        EnableControl(True)
    End Sub

    Private Sub fgCurrency_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs)
        'If CmdSave.Enabled = True Then
        '    If fgCurrency.Col = 1 Or fgCurrency.Col = 2 Or fgCurrency.Col = 3 Then
        '        fgCurrency.Editable = VSFlex7L.EditableSettings.flexEDKbdMouse
        '    Else
        '        fgCurrency.Editable = VSFlex7L.EditableSettings.flexEDNone

        '    End If
        'Else
        '    fgCurrency.Editable = VSFlex7L.EditableSettings.flexEDNone
        'End If
    End Sub
    Private Function checkData() As Boolean

        f_blnCheckData = False
        f_strDataCheck = ""

        For i = 0 To dgCurrency.RowCount - 1
            If Trim(dgCurrency.Rows(i).Cells(1).Value) = "" Then
                f_strDataCheck = "Currency Name"
                dgCurrency.Focus()
                f_blnCheckData = True
                checkData = True
                Exit Function
            End If

            If Trim(dgCurrency.Rows(i).Cells(2).Value) = "" Then
                f_strDataCheck = "Symbol"
                dgCurrency.Focus()
                f_blnCheckData = True
                checkData = True
                Exit Function
            End If
            If Trim(dgCurrency.Rows(i).Cells(3).Value) = "" Then
                f_strDataCheck = "Conversion Factor"
                dgCurrency.Focus()
                f_blnCheckData = True
                checkData = True
                Exit Function
            End If

        Next



        checkData = f_blnCheckData
    End Function
    Private Sub Save()
        Dim ComSave As SqlCommand
        Dim StrQuery As String
        Dim trn As SqlClient.SqlTransaction
        Dim i As Integer

        Try
            If checkData() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            Else

                If bln_AddOn = True Or bln_EditOn = True Then
                    If MsgQuestion("SAVE") = 6 Then
                        trn = gl_Con.BeginTransaction 'Transaction Start
                        ''''''''inserting data into the table JobCard

                        StrQuery = "DELETE FROM CurrencyMaster"

                        ComSave = New SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        For i = 0 To dgCurrency.RowCount - 1

                            StrQuery = "Insert into CurrencyMaster (CurrencyName,Symbol, ConvFact) Values( '" & (dgCurrency.Rows(i).Cells(1).Value) & "','" & (dgCurrency.Rows(i).Cells(2).Value) & "', " & Val(dgCurrency.Rows(i).Cells(3).Value) & " )"
                            ComSave = New SqlCommand(StrQuery, gl_Con)
                            ComSave.CommandType = CommandType.Text
                            ComSave.Transaction = trn
                            ComSave.ExecuteNonQuery()
                        Next


                        'For i = 1 To fgCurrency.Rows - 1

                        '    StrQuery = "Insert into CurrencyMaster (CurrencyName,Symbol, ConvFact) Values( '" & (fgCurrency.get_TextMatrix(i, 1)) & "','" & (fgCurrency.get_TextMatrix(i, 2)) & "', " & Val(fgCurrency.get_TextMatrix(i, 3)) & " )"
                        '    ComSave = New SqlCommand(StrQuery, gl_Con)
                        '    ComSave.CommandType = CommandType.Text
                        '    ComSave.Transaction = trn
                        '    ComSave.ExecuteNonQuery()
                        'Next

                        trn.Commit() ''''''''End transaction

                        EnableControl(False)

                        bln_AddOn = False ''setting boolean variable for add completion
                        bln_EditOn = False

                        Display()
                    Else

                        Exit Sub
                    End If
                Else
                    Exit Sub


                End If

                Call Display()
            End If

        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub CmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Save()
    End Sub

    Private Sub dgCurrency_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCurrency.CellEnter
        If CmdSave.Enabled = True Then
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
                dgCurrency.EditMode = DataGridViewEditMode.EditOnEnter
            Else
                dgCurrency.EditMode = DataGridViewEditMode.EditProgrammatically

            End If
        End If
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        If bln_EditOn = True Then
            If MsgQuestion("CANCEL") = 7 Then

                Exit Sub
            End If

        End If
        Display()
        EnableControl(False)
        bln_EditOn = False
    End Sub
End Class