
Public Class Form1

    Public Sub test()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String = "EXEC [spInsertEmp] @name,@age,@dob,@address,@city"
        Dim para() As String = {"@name", "@age", "@dob", "@address", "@city"}
        Dim value() As Object = {TextBox1.Text, TextBox2.Text, DateTimePicker1.Value, TextBox3.Text, TextBox4.Text}
        DBService.ExecuteNonQuerry(str, para, value)

    End Sub

   

    Private Sub TextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.Enter, TextBox3.Enter, TextBox2.Enter, TextBox1.Enter

        BeginInvoke(DirectCast(Sub() sender.SelectAll(), Action))
    End Sub
End Class
