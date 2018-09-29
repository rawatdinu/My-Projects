Public Class LoginForm1

    Dim frmObject As Object
    Dim f_drLogin As Data.DataRow
    Dim f_cbLogin As SqlClient.SqlCommandBuilder
    Dim f_strQuery As String

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.Cursor = Cursors.WaitCursor

        Dim str As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim ComSave As SqlClient.SqlCommand
        Dim Machine As String
        Dim cmdCom1 As New SqlClient.SqlCommand

        Dim Trans1 As SqlClient.SqlTransaction



        Try
            gl_strMachine = SystemInformation.ComputerName
            str = "Select Machine from UserNameMaster"
            'str = "Select Machine from UserNameMaster where Username='" & txtuserName.Text & "' and Pwd='" & txtpassword.Text & "'"
            da = New SqlClient.SqlDataAdapter(str, gl_Con)
            da.Fill(ds, "Login")
            If ds.Tables("Login").Rows.Count > 0 Then
                Machine = IIf(IsDBNull(ds.Tables("Login").Rows(0).Item("Machine")), "", ds.Tables("Login").Rows(0).Item("Machine"))
                If Machine = "" Then
                    str = "Update  UserNameMaster set Machine='" & gl_strMachine & "' where Username='" & Trim(txtuserName.Text) & "'"
                    ComSave = New SqlClient.SqlCommand(str, gl_Con)
                    ComSave.CommandType = CommandType.Text
                    ComSave.ExecuteNonQuery()


                ElseIf (Machine <> gl_strMachine) Then
                    MsgBox("Login Fail")

                End If


            Else
                MsgBox("Login Fail")
                Exit Sub

            End If


            da.Dispose()
            ds.Clear()

            str = "SELECT max(LoginDetails.SlNo) as sino FROM LoginDetails "
            da = New SqlClient.SqlDataAdapter(str, gl_Con)
            da.Fill(ds, "Login")
            If ds.Tables("Login").Rows.Count > 0 Then
                gl_Sino = IIf(IsDBNull(ds.Tables("Login").Rows(0).Item("sino")), 0, ds.Tables("Login").Rows(0).Item("sino"))
            End If

            da.Dispose()
            ds.Clear()




            str = "Select * from UserNameMaster where Username='" & txtuserName.Text & "' and Pwd='" & Trim(txtpassword.Text) & "'And Machine='" & gl_strMachine & "'"

            da = New SqlClient.SqlDataAdapter(str, gl_Con)
            da.Fill(ds, "Login")
            If ds.Tables("Login").Rows.Count > 0 Then
                gl_EmpName = txtuserName.Text
                MainForm.Visible = True
                Me.Close()

                str = "Insert into logindetails(UserName, LoginDate) values('" & gl_EmpName & "','" & convertToServerDateFormat(dtpDate.Value) & "')"
                Trans1 = gl_Con.BeginTransaction
                cmdCom1.Transaction = Trans1
                cmdCom1.Connection = gl_Con
                cmdCom1.CommandText = str
                cmdCom1.ExecuteNonQuery()
                Trans1.Commit()

                DisplayForm("ActivityList")
            Else
                MsgBox("Login Fail")

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call cmdCancel_Click(sender, e)
        End If
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connect()
        dtpDate.Value = Now
        f_blnValidity = checkValidity()
        If f_blnValidity = False Then
            MsgBox("This is a demo version please contact www.maqsolution.com for full version", MsgBoxStyle.Critical)
            Me.Close()
        End If


        Dim f_strQuery As String
        f_strQuery = "select UserName from LoginDetails where SlNo = (select max(SlNo) from LoginDetails )"
        Dim daLastUser As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(f_strQuery, gl_Con)
        Dim dsLastUser As DataSet = New DataSet
        daLastUser.Fill(dsLastUser)
        If dsLastUser.Tables(0).Rows.Count > 0 Then
            txtuserName.Text = dsLastUser.Tables(0).Rows(0).Item("UserName")

        End If
        dsLastUser.Clear()
        daLastUser.Dispose()



        Dim drDate As SqlClient.SqlDataReader
        Dim comDate As SqlClient.SqlCommand

        f_strQuery = "SELECT getdate() AS ServerDate"
        comDate = New SqlClient.SqlCommand(f_strQuery, gl_Con)
        drDate = comDate.ExecuteReader()
        'Me.Height = 184
        If drDate.HasRows = True Then
            drDate.Read()
            gl_dtServerDate = drDate.Item("ServerDate")
        End If
        drDate.Close()
        FillFinancilaYear()
        'txtpassword.Focus()
        Me.Height = 237
        cmdChangePassword.Enabled = False
    End Sub


    Private Sub FillFinancilaYear()
        Dim strYearL As String
        Dim strYearC As String
        Dim strYearN As String
        Dim strFinancialYear As String
        Dim strFinancialYear1 As String

        Try
            cboFinancialYear.Items.Clear()
            ''DatePart(DateInterval.Year, DateAdd(DateInterval.Year, 0, Date.Now))
            If gl_dtServerDate.Month = 1 Or gl_dtServerDate.Month = 2 Or gl_dtServerDate.Month = 3 Then
                strYearL = gl_dtServerDate.Year - 2
                strYearC = gl_dtServerDate.Year - 1
                strYearN = gl_dtServerDate.Year
            Else
                strYearL = gl_dtServerDate.Year - 1
                strYearC = gl_dtServerDate.Year
                strYearN = gl_dtServerDate.Year + 1
            End If

            strFinancialYear = strYearL & "-" & strYearC
            strFinancialYear1 = strYearC & "-" & strYearN
            gl_strCurrFinancialYear = strFinancialYear1
            cboFinancialYear.Items.Add(strFinancialYear)
            cboFinancialYear.Items.Add(strFinancialYear1)
            cboFinancialYear.Text = strFinancialYear1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangePassword.Click
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdChangePassword.Enabled = False
        cmdSave.Enabled = True
        cmdClose.Enabled = True
        Me.Height = 419
        txtOldPassword.Focus()
    End Sub


    Private Sub txtpassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpassword.GotFocus
        cmdChangePassword.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Height = 237
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        On Error Resume Next
        Dim daChangePwd As SqlClient.SqlDataAdapter
        Dim trn As SqlClient.SqlTransaction
        f_strQuery = "select pwd from UserNameMaster where UserName='" & txtuserName.Text & "' and pwd='" & txtOldPassword.Text & "'"
        daChangePwd = New SqlClient.SqlDataAdapter(f_strQuery, gl_Con)
        f_cbLogin = New SqlClient.SqlCommandBuilder(daChangePwd)
        gl_dsLogin.Clear()
        daChangePwd.Fill(gl_dsLogin, "UserNameMaster")

        If gl_dsLogin.Tables("UserNameMaster").Rows.Count > 0 Then
            If Trim(txtNewPassword.Text) = "" Then
                MsgBox("Pasword could not be empty", MsgBoxStyle.Exclamation, "ERsys")
                txtNewPassword.Focus()
                Exit Sub
            End If
            If txtNewPassword.Text <> txtConfirmPassword.Text Then
                MsgBox("Please enter password again", MsgBoxStyle.Exclamation, "ERsys")
                txtNewPassword.Focus()
                Exit Sub
            Else

                Dim cmdCngPwd As New SqlClient.SqlCommand
                cmdCngPwd.CommandText = "update UserNameMaster set pwd='" & txtNewPassword.Text & "' where UserName='" & txtuserName.Text & "'"
                trn = gl_Con.BeginTransaction
                cmdCngPwd.CommandType = CommandType.Text
                cmdCngPwd.Connection = gl_Con
                cmdCngPwd.Transaction = trn
                cmdCngPwd.ExecuteNonQuery()

                trn.Commit()


                cmdOk.Enabled = True
                cmdCancel.Enabled = True
                cmdChangePassword.Enabled = True
                cmdSave.Enabled = False
                cmdClose.Enabled = False
                txtOldPassword.Text = ""
                txtNewPassword.Text = ""
                txtConfirmPassword.Text = ""
                Me.Height = 237
            End If
        Else
            MsgBox("Invalid Password", MsgBoxStyle.Exclamation, "ERsys")
            txtOldPassword.Focus()
            Exit Sub
        End If
        Exit Sub




        'Dim str As String
        'Dim da As SqlClient.SqlDataAdapter
        'Dim ds As New DataSet
        'Dim ComSave As SqlClient.SqlCommand


        'str = "select password from LoginMaster where UserName='" & txtuserName.Text & "' and password='" & txtOldPassword.Text & "'"
        'da = New SqlClient.SqlDataAdapter(str, gl_Con)
        'da.Fill(ds, "Login")
        'If ds.Tables("Login").Rows.Count > 0 Then
        '    If Trim(txtNewPassword.Text) = "" Then
        '        MsgBox("Pasword could not be empty", MsgBoxStyle.Exclamation, "IMS")
        '        txtNewPassword.Focus()
        '        Exit Sub
        '    End If
        '    If txtNewPassword.Text <> txtConfirmPassword.Text Then
        '        MsgBox("Please enter password again", MsgBoxStyle.Exclamation, "IMS")
        '        txtNewPassword.Focus()
        '        Exit Sub


        '    Else
        '        Dim cmdCngPwd As New SqlClient.SqlCommand
        '        cmdCngPwd.CommandText = "Update  LoginMaster set Password='" & txtNewPassword.Text & "' where Username='" & txtuserName.Text & "'"
        '        cmdCngPwd.CommandType = CommandType.Text
        '        cmdCngPwd.Connection = gl_Con
        '        cmdCngPwd.ExecuteNonQuery()



        '        ComSave = New SqlClient.SqlCommand(str, gl_Con)
        '        ComSave.CommandType = CommandType.Text
        '        ComSave.ExecuteNonQuery()

        '        cmdOk.Enabled = True
        '        cmdCancel.Enabled = True
        '        cmdChangePassword.Enabled = True
        '        cmdSave.Enabled = False
        '        cmdClose.Enabled = False
        '        txtOldPassword.Text = ""
        '        txtNewPassword.Text = ""
        '        txtConfirmPassword.Text = ""
        '        Me.Height = 237

        '    End If

        'Else
        '    MsgBox("Invalid Password", MsgBoxStyle.Exclamation, "IMS")
        '    txtOldPassword.Focus()
        '    Exit Sub
        'End If
        'Exit Sub

    End Sub

















    Private Sub txtConfirmPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConfirmPassword.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call cmdCancel_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            Call cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub txtNewPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNewPassword.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call cmdCancel_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            Call cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub cmdOk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdOk.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call cmdCancel_Click(sender, e)
        End If
    End Sub

    Private Sub txtOldPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOldPassword.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call cmdCancel_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            Call cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub txtpassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call cmdCancel_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            cmdOk.Focus()
            Call cmdOk_Click(sender, e)
        End If
    End Sub

    Private Sub txtuserName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtuserName.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call cmdCancel_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            cmdOk.Focus()
            Call cmdOk_Click(sender, e)
        End If
    End Sub

End Class
