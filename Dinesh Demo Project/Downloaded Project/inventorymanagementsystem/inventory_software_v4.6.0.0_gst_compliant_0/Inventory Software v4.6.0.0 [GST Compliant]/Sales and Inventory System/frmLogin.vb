Imports System.Data.SqlClient
Public Class frmLogin
    Dim frm As New frmMainMenu
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If Len(Trim(UserID.Text)) = 0 Then
            MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UserID.Focus()
            Exit Sub
        End If
        If Len(Trim(Password.Text)) = 0 Then
            MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Password.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(Password) FROM Registration where UserID = @d1 and Password=@d2 and Active='Yes'"
            cmd.Parameters.AddWithValue("@d1", UserID.Text)
            cmd.Parameters.AddWithValue("@d2", Encrypt(Password.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT usertype FROM Registration where UserID=@d3 and Password=@d4"
                cmd.Parameters.AddWithValue("@d3", UserID.Text)
                cmd.Parameters.AddWithValue("@d4", Encrypt(Password.Text))
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    UserType.Text = rdr.GetValue(0).ToString.Trim
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                    frm.lblUser.Text = UserID.Text
                    frm.lblUserType.Text = UserType.Text
                    Dim st As String = "Successfully logged in"
                    LogFunc(UserID.Text, st)
                    Me.Hide()
                    frm.Show()
            Else
                MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied")
                UserID.Text = ""
                Password.Text = ""
                UserID.Focus()
            End If
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        End
    End Sub


    Private Sub LoginForm1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
        Panel1.Anchor = AnchorStyles.None
    End Sub

    Private Sub frmLogin_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub btnChangePassword_Click(sender As System.Object, e As System.EventArgs) Handles btnChangePassword.Click
        Me.Hide()
        frmChangePassword.Show()
        frmChangePassword.UserID.Text = ""
        frmChangePassword.OldPassword.Text = ""
        frmChangePassword.NewPassword.Text = ""
        frmChangePassword.ConfirmPassword.Text = ""
        frmChangePassword.UserID.Focus()
    End Sub

    Private Sub btnChangePassword_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnChangePassword.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(btnChangePassword, "Change Password")
    End Sub

    Private Sub btnRecoveryPassword_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnRecoveryPassword.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(btnRecoveryPassword, "Password Recovery")
    End Sub

    Private Sub btnKeyboard_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(btnKeyboard, "OnScreen Keyboard")
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start("osk.exe")
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start("osk.exe")
        End If
    End Sub

    Private Sub btnRecoveryPassword_Click(sender As System.Object, e As System.EventArgs) Handles btnRecoveryPassword.Click
        Me.Hide()
        frmRecoveryPassword.Show()
        frmRecoveryPassword.txtEmailID.Text = ""
        frmRecoveryPassword.txtEmailID.Focus()
    End Sub
End Class
