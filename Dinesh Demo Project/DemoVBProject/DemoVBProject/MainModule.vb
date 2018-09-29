Module MainModule

    Public Sub Main()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())

    End Sub

    Public Function Main2() As String
        MsgBox("Hello this is me ")
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
        Main2 = "Hello"

    End Function

End Module
