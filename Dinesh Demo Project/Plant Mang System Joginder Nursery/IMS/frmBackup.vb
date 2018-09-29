Imports System.Data.SqlClient
Imports System.IO
Imports DAO
Public Class frmBackup
    Inherits System.Windows.Forms.Form
    Private Sub cmdYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYes.Click
        Dim SqlCmd As New SqlCommand
        Dim path As String = Nothing
        If FBD.ShowDialog() = DialogResult.OK Then
            path = FBD.SelectedPath & "\JoginderNursery " & DateTime.Now.ToString("dd MMM yyyy hh mm ss tt").ToString() & ".bak"
            SqlCmd.CommandText = "Backup Database JoginderNursery To DISK ='" + path & "'"
            SqlCmd.Connection = gl_Con
            Try
                SqlCmd.ExecuteNonQuery()
                MessageBox.Show("The backup operation has been completed successfully.", "JoginderNursery", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
 
    End Sub

    Private Sub cmdNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNo.Click
        BackupDatabase = Nothing
        Me.Close()
    End Sub

    Private Sub frmBackup_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        BackupDatabase = Nothing
    End Sub
End Class