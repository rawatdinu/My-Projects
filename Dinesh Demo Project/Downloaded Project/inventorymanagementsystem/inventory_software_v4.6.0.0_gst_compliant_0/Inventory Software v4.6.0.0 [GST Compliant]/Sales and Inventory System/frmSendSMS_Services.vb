Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Data.SqlClient

Public Class frmSendSMS_Services
    Dim st2 As String
    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        Try
            If Len(Trim(txtContactNo.Text)) = 0 Then
                MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtContactNo.Focus()
                Exit Sub
            End If
            If Len(Trim(txtMessage.Text)) = 0 Then
                MessageBox.Show("Please Enter Message", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMessage.Focus()
                Exit Sub
            End If
            If CheckForInternetConnection() = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    st2 = rdr.GetValue(0)
                    SMSFunc(txtContactNo.Text, txtMessage.Text, st2)
                    SMS(txtMessage.Text)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                End If
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        txtContactNo.Text = ""
        txtCustomerID.Text = ""
        txtCustomerName.Text = ""
        txtMessage.Text = ""
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnListofServices_Click(sender As System.Object, e As System.EventArgs) Handles btnListofServices.Click
        frmServicesRecord1.Reset()
        frmServicesRecord1.lblSet.Text = "Send SMS"
        frmServicesRecord1.ShowDialog()
    End Sub
End Class