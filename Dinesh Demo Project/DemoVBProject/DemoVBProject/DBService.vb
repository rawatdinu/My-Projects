Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class DBService
    Shared con As SqlConnection
    Shared cmd As SqlCommand

    Shared Sub OpenConncetion()
        Dim str As String = "Data Source=DINESH-PC;Initial Catalog=Test;User ID=sa;Password=12345"
        If (IsNothing(con)) Then
            con = New SqlConnection(str)
            con.Open()
        
        End If
        If (con.State = ConnectionState.Closed) Then
            con.Open()
        End If
        cmd = New SqlCommand()
        cmd.Connection = con
    End Sub
    Public Shared Sub CloseConnection()

        If (con.State = ConnectionState.Open) Then            
            con.Close()
        End If
       
    End Sub

    Public Overloads Shared Function ExecuteNonQuerry(ByVal querry As String, ByVal para() As String, ByVal value() As Object) As Object
        Dim obj As Object = Nothing
        Try
            OpenConncetion()
            cmd.CommandText = querry
            cmd.CommandType = CommandType.Text
            For i = 0 To para.Length - 1
                cmd.Parameters.AddWithValue(para(i), value(i))
            Next
            obj = cmd.ExecuteNonQuery()
            ExecuteNonQuerry = obj
        Catch ex As Exception
            ExecuteNonQuerry = Nothing
        End Try

    End Function

    Public Overloads Shared Function ExecuteNonQuerry(ByVal querry As String) As Object
        Dim obj As Object = Nothing
        Try
            OpenConncetion()
            cmd.CommandText = querry
            cmd.CommandType = CommandType.Text           
            obj = cmd.ExecuteNonQuery()
            ExecuteNonQuerry = obj
        Catch ex As Exception
            ExecuteNonQuerry = Nothing
        End Try

    End Function

    Public Shared Function GetDataTable(ByVal querry As String) As DataTable
        Dim da As New SqlDataAdapter()
        Dim dt As New DataTable()
        OpenConncetion()
        cmd.CommandText = querry
        cmd.CommandType = CommandType.Text
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        GetDataTable = dt
    End Function

End Class
