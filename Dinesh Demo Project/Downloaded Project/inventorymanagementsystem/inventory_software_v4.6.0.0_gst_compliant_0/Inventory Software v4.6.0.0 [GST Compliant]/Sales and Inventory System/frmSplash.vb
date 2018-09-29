Imports System.Data.SqlClient
Public Class frmSplash

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ProgressBar1.Value + 2
                    If (ProgressBar1.Value = 10) Then
                        lblSet.Text = "Reading modules.."
                    ElseIf (ProgressBar1.Value = 20) Then
                        lblSet.Text = "Turning on modules."
                    ElseIf (ProgressBar1.Value = 40) Then
                        lblSet.Text = "Starting modules.."
                    ElseIf (ProgressBar1.Value = 60) Then
                        lblSet.Text = "Loading modules.."
                    ElseIf (ProgressBar1.Value = 80) Then
                        lblSet.Text = "Done Loading modules.."
                    ElseIf (ProgressBar1.Value = 100) Then
                        frmLogin.Show()
                        Timer1.Enabled = False
                        Me.Hide()
                    End If
            Else
                ProgressBar1.Visible = True
                ProgressBar1.Value = ProgressBar1.Value + 2
                If (ProgressBar1.Value = 10) Then
                    lblSet.Text = "Reading modules.."
                ElseIf (ProgressBar1.Value = 20) Then
                    lblSet.Text = "Turning on modules."
                ElseIf (ProgressBar1.Value = 40) Then
                    lblSet.Text = "Starting modules.."
                ElseIf (ProgressBar1.Value = 60) Then
                    lblSet.Text = "Loading modules.."
                ElseIf (ProgressBar1.Value = 80) Then
                    lblSet.Text = "Done Loading modules.."
                ElseIf (ProgressBar1.Value = 100) Then
                    frmSqlServerSetting.Reset()
                    frmSqlServerSetting.Show()
                    Timer1.Enabled = False
                    Me.Hide()
            End If
            End if
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            End
        End Try

    End Sub
End Class