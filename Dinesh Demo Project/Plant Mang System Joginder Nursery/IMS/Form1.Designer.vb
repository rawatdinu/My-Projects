<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompanyMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompanyMaster))
        Me.gbCompanyDetail = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdLogo = New System.Windows.Forms.Button
        Me.pbPicture = New System.Windows.Forms.PictureBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.txtWebsite = New System.Windows.Forms.TextBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtPIN = New System.Windows.Forms.TextBox
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.txtState = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtCompanyNAme = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbCompany = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.gbRegistration = New System.Windows.Forms.GroupBox
        Me.txtExciseDivision = New System.Windows.Forms.TextBox
        Me.txtExciseRange = New System.Windows.Forms.TextBox
        Me.txtServiceTaxNo = New System.Windows.Forms.TextBox
        Me.txtPANNo = New System.Windows.Forms.TextBox
        Me.txtTINNo = New System.Windows.Forms.TextBox
        Me.txtHGStNo = New System.Windows.Forms.TextBox
        Me.txtCSTNo = New System.Windows.Forms.TextBox
        Me.txtECCNo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.gbMain = New System.Windows.Forms.Panel
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.gbCompanyDetail.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCompany.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbRegistration.SuspendLayout()
        Me.gbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCompanyDetail
        '
        Me.gbCompanyDetail.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.gbCompanyDetail.Controls.Add(Me.Panel1)
        Me.gbCompanyDetail.Controls.Add(Me.cmdLogo)
        Me.gbCompanyDetail.Controls.Add(Me.pbPicture)
        Me.gbCompanyDetail.Controls.Add(Me.txtFax)
        Me.gbCompanyDetail.Controls.Add(Me.txtPhone)
        Me.gbCompanyDetail.Controls.Add(Me.txtWebsite)
        Me.gbCompanyDetail.Controls.Add(Me.txtEmail)
        Me.gbCompanyDetail.Controls.Add(Me.txtPIN)
        Me.gbCompanyDetail.Controls.Add(Me.txtCountry)
        Me.gbCompanyDetail.Controls.Add(Me.txtState)
        Me.gbCompanyDetail.Controls.Add(Me.txtCity)
        Me.gbCompanyDetail.Controls.Add(Me.txtAddress)
        Me.gbCompanyDetail.Controls.Add(Me.txtCompanyNAme)
        Me.gbCompanyDetail.Controls.Add(Me.Label13)
        Me.gbCompanyDetail.Controls.Add(Me.Label12)
        Me.gbCompanyDetail.Controls.Add(Me.Label11)
        Me.gbCompanyDetail.Controls.Add(Me.Label10)
        Me.gbCompanyDetail.Controls.Add(Me.Label8)
        Me.gbCompanyDetail.Controls.Add(Me.Label6)
        Me.gbCompanyDetail.Controls.Add(Me.Label5)
        Me.gbCompanyDetail.Controls.Add(Me.Label4)
        Me.gbCompanyDetail.Controls.Add(Me.Label3)
        Me.gbCompanyDetail.Controls.Add(Me.Label1)
        Me.gbCompanyDetail.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCompanyDetail.Location = New System.Drawing.Point(6, 3)
        Me.gbCompanyDetail.Name = "gbCompanyDetail"
        Me.gbCompanyDetail.Size = New System.Drawing.Size(551, 433)
        Me.gbCompanyDetail.TabIndex = 0
        Me.gbCompanyDetail.TabStop = False
        Me.gbCompanyDetail.Text = "Company Details"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdExit)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.cmdAdd)
        Me.Panel1.Controls.Add(Me.cmdEdit)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(47, 375)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 40)
        Me.Panel1.TabIndex = 60
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(263, 7)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(60, 24)
        Me.cmdExit.TabIndex = 38
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(198, 7)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(60, 24)
        Me.cmdCancel.TabIndex = 39
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(134, 7)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(60, 24)
        Me.cmdSave.TabIndex = 40
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(5, 8)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(60, 24)
        Me.cmdAdd.TabIndex = 36
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(69, 7)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(60, 24)
        Me.cmdEdit.TabIndex = 37
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdLogo
        '
        Me.cmdLogo.Location = New System.Drawing.Point(405, 164)
        Me.cmdLogo.Name = "cmdLogo"
        Me.cmdLogo.Size = New System.Drawing.Size(100, 31)
        Me.cmdLogo.TabIndex = 11
        Me.cmdLogo.Text = "&Browse Logo"
        Me.cmdLogo.UseVisualStyleBackColor = True
        '
        'pbPicture
        '
        Me.pbPicture.BackgroundImage = CType(resources.GetObject("pbPicture.BackgroundImage"), System.Drawing.Image)
        Me.pbPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbPicture.ErrorImage = Nothing
        Me.pbPicture.ImageLocation = "Center"
        Me.pbPicture.InitialImage = Nothing
        Me.pbPicture.Location = New System.Drawing.Point(395, 28)
        Me.pbPicture.Name = "pbPicture"
        Me.pbPicture.Size = New System.Drawing.Size(117, 123)
        Me.pbPicture.TabIndex = 23
        Me.pbPicture.TabStop = False
        '
        'txtFax
        '
        Me.txtFax.BackColor = System.Drawing.Color.White
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFax.Location = New System.Drawing.Point(145, 322)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(227, 23)
        Me.txtFax.TabIndex = 10
        '
        'txtPhone
        '
        Me.txtPhone.BackColor = System.Drawing.Color.White
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(145, 289)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(227, 23)
        Me.txtPhone.TabIndex = 9
        '
        'txtWebsite
        '
        Me.txtWebsite.BackColor = System.Drawing.Color.White
        Me.txtWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWebsite.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebsite.Location = New System.Drawing.Point(145, 256)
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(227, 23)
        Me.txtWebsite.TabIndex = 8
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.White
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(145, 223)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(227, 23)
        Me.txtEmail.TabIndex = 7
        '
        'txtPIN
        '
        Me.txtPIN.BackColor = System.Drawing.Color.White
        Me.txtPIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPIN.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPIN.Location = New System.Drawing.Point(145, 190)
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.Size = New System.Drawing.Size(227, 23)
        Me.txtPIN.TabIndex = 6
        '
        'txtCountry
        '
        Me.txtCountry.BackColor = System.Drawing.Color.White
        Me.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountry.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountry.Location = New System.Drawing.Point(145, 157)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(227, 23)
        Me.txtCountry.TabIndex = 5
        '
        'txtState
        '
        Me.txtState.BackColor = System.Drawing.Color.White
        Me.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtState.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtState.Location = New System.Drawing.Point(145, 128)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(227, 23)
        Me.txtState.TabIndex = 4
        '
        'txtCity
        '
        Me.txtCity.BackColor = System.Drawing.Color.White
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Location = New System.Drawing.Point(145, 94)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(227, 23)
        Me.txtCity.TabIndex = 3
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.White
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(145, 61)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(227, 23)
        Me.txtAddress.TabIndex = 2
        '
        'txtCompanyNAme
        '
        Me.txtCompanyNAme.BackColor = System.Drawing.Color.White
        Me.txtCompanyNAme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompanyNAme.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyNAme.Location = New System.Drawing.Point(145, 28)
        Me.txtCompanyNAme.Name = "txtCompanyNAme"
        Me.txtCompanyNAme.Size = New System.Drawing.Size(227, 23)
        Me.txtCompanyNAme.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 196)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "PIN"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 163)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 16)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Country"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 16)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Address"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "City"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Website"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 328)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fax No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 295)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Phone No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Email ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "State"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Name"
        '
        'tbCompany
        '
        Me.tbCompany.Controls.Add(Me.TabPage1)
        Me.tbCompany.Controls.Add(Me.TabPage2)
        Me.tbCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCompany.Location = New System.Drawing.Point(3, 3)
        Me.tbCompany.Name = "tbCompany"
        Me.tbCompany.SelectedIndex = 0
        Me.tbCompany.Size = New System.Drawing.Size(565, 601)
        Me.tbCompany.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TabPage1.Controls.Add(Me.gbCompanyDetail)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(557, 572)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Company Details"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TabPage2.Controls.Add(Me.gbRegistration)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(557, 572)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Registration Details"
        '
        'gbRegistration
        '
        Me.gbRegistration.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.gbRegistration.Controls.Add(Me.txtExciseDivision)
        Me.gbRegistration.Controls.Add(Me.txtExciseRange)
        Me.gbRegistration.Controls.Add(Me.txtServiceTaxNo)
        Me.gbRegistration.Controls.Add(Me.txtPANNo)
        Me.gbRegistration.Controls.Add(Me.txtTINNo)
        Me.gbRegistration.Controls.Add(Me.txtHGStNo)
        Me.gbRegistration.Controls.Add(Me.txtCSTNo)
        Me.gbRegistration.Controls.Add(Me.txtECCNo)
        Me.gbRegistration.Controls.Add(Me.Label9)
        Me.gbRegistration.Controls.Add(Me.Label14)
        Me.gbRegistration.Controls.Add(Me.Label15)
        Me.gbRegistration.Controls.Add(Me.Label16)
        Me.gbRegistration.Controls.Add(Me.Label17)
        Me.gbRegistration.Controls.Add(Me.Label20)
        Me.gbRegistration.Controls.Add(Me.Label21)
        Me.gbRegistration.Controls.Add(Me.Label22)
        Me.gbRegistration.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRegistration.Location = New System.Drawing.Point(3, 8)
        Me.gbRegistration.Name = "gbRegistration"
        Me.gbRegistration.Size = New System.Drawing.Size(382, 428)
        Me.gbRegistration.TabIndex = 1
        Me.gbRegistration.TabStop = False
        Me.gbRegistration.Text = "Registration Details"
        '
        'txtExciseDivision
        '
        Me.txtExciseDivision.BackColor = System.Drawing.Color.White
        Me.txtExciseDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExciseDivision.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExciseDivision.Location = New System.Drawing.Point(161, 263)
        Me.txtExciseDivision.Name = "txtExciseDivision"
        Me.txtExciseDivision.Size = New System.Drawing.Size(218, 23)
        Me.txtExciseDivision.TabIndex = 11
        '
        'txtExciseRange
        '
        Me.txtExciseRange.BackColor = System.Drawing.Color.White
        Me.txtExciseRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExciseRange.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExciseRange.Location = New System.Drawing.Point(161, 230)
        Me.txtExciseRange.Name = "txtExciseRange"
        Me.txtExciseRange.Size = New System.Drawing.Size(218, 23)
        Me.txtExciseRange.TabIndex = 10
        '
        'txtServiceTaxNo
        '
        Me.txtServiceTaxNo.BackColor = System.Drawing.Color.White
        Me.txtServiceTaxNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServiceTaxNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceTaxNo.Location = New System.Drawing.Point(161, 197)
        Me.txtServiceTaxNo.Name = "txtServiceTaxNo"
        Me.txtServiceTaxNo.Size = New System.Drawing.Size(218, 23)
        Me.txtServiceTaxNo.TabIndex = 9
        '
        'txtPANNo
        '
        Me.txtPANNo.BackColor = System.Drawing.Color.White
        Me.txtPANNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPANNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPANNo.Location = New System.Drawing.Point(161, 65)
        Me.txtPANNo.Name = "txtPANNo"
        Me.txtPANNo.Size = New System.Drawing.Size(218, 23)
        Me.txtPANNo.TabIndex = 5
        '
        'txtTINNo
        '
        Me.txtTINNo.BackColor = System.Drawing.Color.White
        Me.txtTINNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTINNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTINNo.Location = New System.Drawing.Point(161, 32)
        Me.txtTINNo.Name = "txtTINNo"
        Me.txtTINNo.Size = New System.Drawing.Size(218, 23)
        Me.txtTINNo.TabIndex = 4
        '
        'txtHGStNo
        '
        Me.txtHGStNo.BackColor = System.Drawing.Color.White
        Me.txtHGStNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHGStNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHGStNo.Location = New System.Drawing.Point(161, 164)
        Me.txtHGStNo.Name = "txtHGStNo"
        Me.txtHGStNo.Size = New System.Drawing.Size(218, 23)
        Me.txtHGStNo.TabIndex = 8
        '
        'txtCSTNo
        '
        Me.txtCSTNo.BackColor = System.Drawing.Color.White
        Me.txtCSTNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCSTNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCSTNo.Location = New System.Drawing.Point(161, 131)
        Me.txtCSTNo.Name = "txtCSTNo"
        Me.txtCSTNo.Size = New System.Drawing.Size(218, 23)
        Me.txtCSTNo.TabIndex = 7
        '
        'txtECCNo
        '
        Me.txtECCNo.BackColor = System.Drawing.Color.White
        Me.txtECCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtECCNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtECCNo.Location = New System.Drawing.Point(161, 98)
        Me.txtECCNo.Name = "txtECCNo"
        Me.txtECCNo.Size = New System.Drawing.Size(218, 23)
        Me.txtECCNo.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(145, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Service Tax Regn No"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 16)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "PAN NO"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 133)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 16)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "CST NO"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 166)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 16)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "HGST NO"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 265)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 16)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Excise Division"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 232)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(94, 16)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Excise Range"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 34)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 16)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "TIN NO"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 100)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(58, 16)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "ECC NO"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Green
        Me.TextBox1.Location = New System.Drawing.Point(-13, -1)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(607, 38)
        Me.TextBox1.TabIndex = 10000
        Me.TextBox1.Text = "Company Master"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbMain
        '
        Me.gbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbMain.Controls.Add(Me.tbCompany)
        Me.gbMain.Location = New System.Drawing.Point(12, 43)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(572, 469)
        Me.gbMain.TabIndex = 126
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmCompanyMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ClientSize = New System.Drawing.Size(590, 526)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmCompanyMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbCompanyDetail.ResumeLayout(False)
        Me.gbCompanyDetail.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCompany.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.gbRegistration.ResumeLayout(False)
        Me.gbRegistration.PerformLayout()
        Me.gbMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbCompanyDetail As System.Windows.Forms.GroupBox
    Friend WithEvents tbCompany As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdLogo As System.Windows.Forms.Button
    Friend WithEvents pbPicture As System.Windows.Forms.PictureBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtWebsite As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtPIN As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyNAme As System.Windows.Forms.TextBox
    Friend WithEvents gbRegistration As System.Windows.Forms.GroupBox
    Friend WithEvents txtExciseDivision As System.Windows.Forms.TextBox
    Friend WithEvents txtExciseRange As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceTaxNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPANNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTINNo As System.Windows.Forms.TextBox
    Friend WithEvents txtHGStNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCSTNo As System.Windows.Forms.TextBox
    Friend WithEvents txtECCNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents gbMain As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
