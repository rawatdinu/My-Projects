
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Public Class frmCompanyMaster
    Dim bln_AddOn As Boolean
    Dim bln_EditOn As Boolean
    Dim f_strImagePath As String
    Dim f_blnCheckData As Boolean
    Dim f_strDataCheck As String

    Dim imgfile As FileInfo
    Dim fileLen As Long
    Private Sub frmCompanyMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        CompanyMaster = Nothing
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        pbPicture.Image = Image.FromFile(OpenFileDialog1.FileName)
        pbPicture.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Private Sub frmCompanyMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EnableControl(True)
        Display()
        cmdEdit.Focus()
    End Sub
    Private Sub EnableControl(ByVal status As Boolean)
        cmdAdd.Enabled = status
        cmdEdit.Enabled = status
        cmdCancel.Enabled = Not status
        cmdSave.Enabled = Not status
        cmdExit.Enabled = status

        txtCompanyNAme.ReadOnly = status
        txtAddress.ReadOnly = status
        txtCity.ReadOnly = status
        txtState.ReadOnly = status
        txtCountry.ReadOnly = status
        txtPIN.ReadOnly = status
        txtEmail.ReadOnly = status
        txtWebsite.ReadOnly = status
        txtFax.ReadOnly = status
        txtPhone.ReadOnly = status
        txtTINNo.ReadOnly = status
        txtPANNo.ReadOnly = status
        txtECCNo.ReadOnly = status
        txtCSTNo.ReadOnly = status
        txtExciseDivision.ReadOnly = status
        txtExciseRange.ReadOnly = status
        txtHGStNo.ReadOnly = status
        txtServiceTaxNo.ReadOnly = status


        'txtCompanyNAme.BackColor = Color.White
        'txtAddress.BackColor = Color.White
        'txtCity.BackColor = Color.White
        'txtState.BackColor = Color.White
        'txtCountry.BackColor = Color.White
        'txtPin.BackColor = Color.White
        'txtEmail.BackColor = Color.White
        'txtwebsite.BackColor = Color.White
        'txtFax.BackColor = Color.White
        'txtPhone.BackColor = Color.White
        'txtTinNo.BackColor = Color.White
        'txtPANNo.BackColor = Color.White
        'txtECCNo.BackColor = Color.White
        'txtCSTNo.BackColor = Color.White
        'txtExciseDivision.BackColor = Color.White
        'txtExciseRange.BackColor = Color.White
        'txtHGStNo.BackColor = Color.White
        'txtServiceTaxNo.BackColor = Color.White

    End Sub


    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        bln_EditOn = True
        EnableControl(False)
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancel()
    End Sub
    Private Sub Cancel()

        If bln_AddOn Or bln_EditOn Then

            If MsgQuestion("CANCEL") = 7 Then

                Exit Sub
            End If

        End If


        Call EnableControl(True)

        ''''''''''''flag check
        bln_AddOn = False
        bln_EditOn = False

        Display()
        cmdAdd.Focus()

    End Sub
    Private Sub ClearControl()
        txtCompanyNAme.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtState.Text = ""
        pbPicture.Image = Nothing
        txtCountry.Text = ""
        txtPIN.Text = ""
        txtEmail.Text = ""
        txtWebsite.Text = ""
        txtFax.Text = ""
        txtPhone.Text = ""
        txtTINNo.Text = ""
        txtPANNo.Text = ""
        txtECCNo.Text = ""
        txtCSTNo.Text = ""
        txtExciseDivision.Text = ""
        txtExciseRange.Text = ""
        txtHGStNo.Text = ""
        txtServiceTaxNo.Text = ""
    End Sub
    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Save()
    End Sub

    Private Function checkData() As Boolean

        f_blnCheckData = False
        f_strDataCheck = ""


        If Trim(txtCompanyNAme.Text) = "" Then
            f_strDataCheck = "CompanyName"
            txtCompanyNAme.Focus()
            f_blnCheckData = True
            checkData = True
            Exit Function
        End If

        checkData = f_blnCheckData
    End Function

    Private Sub Save()
        Dim ComSave As SqlClient.SqlCommand
        Dim StrQuery As String
        Dim trn As SqlClient.SqlTransaction

        Try



            If checkData() = True Then '''''''''''''Checking data
                MsgDisplay(f_strDataCheck) ''calling function in main module 

                Exit Sub
            Else
                If bln_AddOn = True Then
                    If MsgQuestion("SAVE") = 6 Then
                        ''''''''inserting data into the table JobCard
                        StrQuery = "insert into CompanyMaster1 (CompanyName,Address,City,State,Pin,Phone,Fax,Country,EmailId,Website,TINNo,PANNo,ECCNo,CSTNo,HGSTNo,ServiceTaxRegnNo,ExciseRange,ExciseDivision)values('" & txtCompanyNAme.Text & "','" & txtAddress.Text & "','" & txtCity.Text & "','" & txtState.Text & "','" & txtPIN.Text & "','" & txtPhone.Text & "','" & txtFax.Text & "','" & txtCountry.Text & "','" & txtEmail.Text & "','" & txtWebsite.Text & "','" & txtTINNo.Text & "','" & txtPANNo.Text & "','" & txtECCNo.Text & "','" & txtCSTNo.Text & "','" & txtHGStNo.Text & "','" & txtServiceTaxNo.Text & "','" & txtExciseRange.Text & "','" & txtExciseDivision.Text & "')"

                        trn = gl_Con.BeginTransaction 'Transaction Start

                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()

                        If f_strImagePath <> "" Then
                            imgfile = New FileInfo(f_strImagePath)
                            FileLen = imgfile.Length
                            Dim fs As New FileStream(f_strImagePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                            Dim m_barrImg(Convert.ToInt32(FileLen)) As Byte
                            Dim iBytesRead As Integer = fs.Read(m_barrImg, 0, Convert.ToInt32(FileLen))
                            fs.Close()


                            StrQuery = "Update CompanyMaster1 set Picture = @Picture where CompanyName = '" & txtCompanyNAme.Text & "'"

                            ComSave = New SqlCommand(StrQuery, gl_Con)
                            ComSave.Parameters.Add("@Picture", System.Data.SqlDbType.Image)
                            ComSave.Parameters("@Picture").Value = m_barrImg
                            ComSave.CommandType = CommandType.Text
                            ComSave.Transaction = trn
                            ComSave.ExecuteNonQuery()
                            f_strImagePath = ""

                        End If



                        trn.Commit() ''''''''End transaction

                        Call EnableControl(True)

                        bln_AddOn = False ''setting boolean variable for add completion
                        Call ClearControl()

                    Else

                        Exit Sub
                    End If

                ElseIf bln_EditOn = True Then

                    If MsgQuestion("UPDATE") = 6 Then


                        StrQuery = "Update CompanyMaster1 Set CompanyName='" & txtCompanyNAme.Text & "',Address='" & txtAddress.Text & "', City='" & txtCity.Text & "',State='" & txtState.Text & "',Pin='" & txtPIN.Text & "',Phone='" & txtPhone.Text & "',Fax='" & txtFax.Text & "',Country='" & txtCountry.Text & "',EmailId='" & txtEmail.Text & "',Website='" & txtWebsite.Text & "',PANNo='" & txtPANNo.Text & "',TINNo='" & txtTINNo.Text & "',ECCNo='" & txtECCNo.Text & "',CSTNo='" & txtCSTNo.Text & "',HGSTNo='" & txtHGStNo.Text & "',ServiceTaxRegnNo='" & txtServiceTaxNo.Text & "',ExciseRange='" & txtExciseRange.Text & "',ExciseDivision='" & txtExciseDivision.Text & "'  "
                        trn = gl_Con.BeginTransaction
                        ComSave = New SqlClient.SqlCommand(StrQuery, gl_Con)
                        ComSave.CommandType = CommandType.Text
                        ComSave.Transaction = trn
                        ComSave.ExecuteNonQuery()




                        If f_strImagePath <> "" Then
                            imgfile = New FileInfo(f_strImagePath)
                            fileLen = imgfile.Length
                            Dim fs As New FileStream(f_strImagePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                            Dim m_barrImg(Convert.ToInt32(fileLen)) As Byte
                            Dim iBytesRead As Integer = fs.Read(m_barrImg, 0, Convert.ToInt32(fileLen))
                            fs.Close()


                            StrQuery = "Update CompanyMaster1 set Picture = @Picture where CompanyName = '" & txtCompanyNAme.Text & "'"

                            ComSave = New SqlCommand(StrQuery, gl_Con)
                            ComSave.Parameters.Add("@Picture", System.Data.SqlDbType.Image)
                            ComSave.Parameters("@Picture").Value = m_barrImg
                            ComSave.CommandType = CommandType.Text
                            ComSave.Transaction = trn
                            ComSave.ExecuteNonQuery()
                            f_strImagePath = ""

                        End If

                        trn.Commit()

                        Call EnableControl(True)

                        bln_EditOn = False
                        Call ClearControl()
                    Else

                        Exit Sub
                    End If
                Else
                    Call EnableControl(True)

                    bln_EditOn = False
                    Call ClearControl()
                End If
            End If


            Call Display()

        Catch ex As Exception
            trn.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        bln_AddOn = True
        EnableControl(False)
        ClearControl()

        txtCompanyNAme.Focus()
    End Sub
    Private Sub Display()
        Dim Strquery As String
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet

        Strquery = "SELECT   Picture,  CompanyName,Address,City,State,Pin,Phone,Fax,Country,EmailId,Website,TINNo,PANNo,ExciseDivision,ExciseRange,ServiceTaxRegnNo,CSTNo,ECCNo,HGSTNo FROM CompanyMaster1"

        da = New SqlClient.SqlDataAdapter(Strquery, gl_Con)
        da.Fill(ds, "CompanyMaster1")
        If ds.Tables("CompanyMaster1").Rows.Count > 0 Then

            cmdAdd.Enabled = False
            cmdEdit.Enabled = True




            txtCompanyNAme.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("CompanyNAme")), "", ds.Tables("CompanyMaster1").Rows(0).Item("CompanyNAme"))
            txtAddress.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("Address")), "", ds.Tables("CompanyMaster1").Rows(0).Item("Address"))
            txtPANNo.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("PANNo")), "", ds.Tables("CompanyMaster1").Rows(0).Item("PANNo"))
            txtCity.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("City")), "", ds.Tables("CompanyMaster1").Rows(0).Item("City"))
            txtPIN.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("Pin")), "", ds.Tables("CompanyMaster1").Rows(0).Item("Pin"))
            txtPhone.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("Phone")), "", ds.Tables("CompanyMaster1").Rows(0).Item("Phone"))
            txtFax.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("Fax")), "", ds.Tables("CompanyMaster1").Rows(0).Item("Fax"))
            txtTINNo.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("TINNo")), "", ds.Tables("CompanyMaster1").Rows(0).Item("TINNo"))
            txtState.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("State")), "", ds.Tables("CompanyMaster1").Rows(0).Item("State"))
            txtCountry.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("Country")), "", ds.Tables("CompanyMaster1").Rows(0).Item("Country"))
            txtEmail.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("EmailId")), "", ds.Tables("CompanyMaster1").Rows(0).Item("EmailId"))
            txtWebsite.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("Website")), "", ds.Tables("CompanyMaster1").Rows(0).Item("Website"))
            txtECCNo.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("ECCNo")), "", ds.Tables("CompanyMaster1").Rows(0).Item("ECCNo"))
            txtCSTNo.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("CSTNo")), "", ds.Tables("CompanyMaster1").Rows(0).Item("CSTNo"))
            txtHGStNo.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("HGSTNo")), "", ds.Tables("CompanyMaster1").Rows(0).Item("HGSTNo"))
            txtServiceTaxNo.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("ServiceTaxRegnNo")), "", ds.Tables("CompanyMaster1").Rows(0).Item("ServiceTaxRegnNo"))
            txtExciseRange.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("ExciseRange")), "", ds.Tables("CompanyMaster1").Rows(0).Item("ExciseRange"))
            txtExciseDivision.Text = IIf(IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("ExciseDivision")), "", ds.Tables("CompanyMaster1").Rows(0).Item("ExciseDivision"))

            If IsDBNull(ds.Tables("CompanyMaster1").Rows(0).Item("Picture")) = False Then
                Dim bits As Byte() = CType(ds.Tables("CompanyMaster1").Rows(0).Item("Picture"), Byte())
                Dim memorybits As New MemoryStream(bits)
                Dim bitmap As New Bitmap(memorybits)
                pbPicture.Image = bitmap
            Else
                pbPicture.Image = Nothing
            End If


        End If
    End Sub


    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        cmdSave.Focus()
    End Sub

    Private Sub txtFax_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFax.LostFocus
        txtCompanyNAme.Focus()
    End Sub

    Private Sub txtExciseDivision_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExciseDivision.LostFocus
        txtTINNo.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogo.Click
        OpenFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp"
        If f_strImagePath <> "" Then
            OpenFileDialog1.InitialDirectory = f_strImagePath
        End If
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            f_strImagePath = OpenFileDialog1.FileName
            pbPicture.Image = Image.FromFile(OpenFileDialog1.FileName)
            pbPicture.BackgroundImageLayout = ImageLayout.Stretch
        End If

        ' Testing
       

        Exit Sub
ErrHnd:
        MsgBox("Please verify the Image", MsgBoxStyle.Information, "ERSys")
    End Sub
End Class
