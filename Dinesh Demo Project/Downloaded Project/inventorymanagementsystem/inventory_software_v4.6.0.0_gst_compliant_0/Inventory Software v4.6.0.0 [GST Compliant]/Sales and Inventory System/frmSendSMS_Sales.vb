Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Data.SqlClient

Public Class frmSendSMS_Sales
    Dim st2 As String
    Sub GetCompany()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CompanyName) from Company"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCompany.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        Try
            If Len(Trim(txtMobileNo.Text)) = 0 Then
                MessageBox.Show("Please Enter Mobile No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMobileNo.Focus()
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
                    SMSFunc(txtMobileNo.Text, txtMessage.Text, st2)
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
        txtMobileNo.Text = ""
        txtMessage.Text = ""
        txtMobileNo.Focus()
        GetCompany()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub frmSendSMS_Sales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetCompany()
    End Sub

    Private Sub btnGetSales_Click(sender As System.Object, e As System.EventArgs) Handles btnGetSales.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn As String = "Select IsNull(Sum(GrandTotal),0) from InvoiceInfo where Cast(InvoiceDate as Date)=Cast(GetDate() as Date)"
            cmd = New SqlCommand(ctn)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtMessage.Text = "Hi,Today's total sales of " & txtCompany.Text & " is " & rdr.GetValue(0) & ""
                txtMobileNo.Focus()
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn As String = "Select IsNull(Sum(Invoice_Payment.TotalPaid),0) from InvoiceInfo,Invoice_Payment where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and Cast(PaymentDate as Date)=Cast(GetDate() as Date) and PaymentMode='By Cash'"
            cmd = New SqlCommand(ctn)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtMessage.Text = "Hi,Today's total cash sales of " & txtCompany.Text & " is " & rdr.GetValue(0) & ""
                txtMobileNo.Focus()
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class