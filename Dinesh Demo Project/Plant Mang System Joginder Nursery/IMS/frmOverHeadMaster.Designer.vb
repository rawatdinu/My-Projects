<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOverHeadMaster
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
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.gbMain = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cmdDeleteRow = New System.Windows.Forms.Button
        Me.cmdAddParent = New System.Windows.Forms.Button
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.txtConfigurationCode = New System.Windows.Forms.TextBox
        Me.gbSearch = New System.Windows.Forms.Panel
        Me.dgSearch = New System.Windows.Forms.DataGridView
        Me.lblSearch = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.gbMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Green
        Me.TextBox1.Location = New System.Drawing.Point(-2, -3)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(524, 33)
        Me.TextBox1.TabIndex = 124
        Me.TextBox1.Text = "Over Head Master"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbMain
        '
        Me.gbMain.BackColor = System.Drawing.Color.Transparent
        Me.gbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbMain.Controls.Add(Me.Panel2)
        Me.gbMain.Controls.Add(Me.Panel1)
        Me.gbMain.Controls.Add(Me.cmdSearch)
        Me.gbMain.Controls.Add(Me.Label2)
        Me.gbMain.Controls.Add(Me.Label1)
        Me.gbMain.Controls.Add(Me.txtRemarks)
        Me.gbMain.Controls.Add(Me.txtConfigurationCode)
        Me.gbMain.Location = New System.Drawing.Point(5, 36)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(510, 401)
        Me.gbMain.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmdDeleteRow)
        Me.Panel2.Controls.Add(Me.cmdAddParent)
        Me.Panel2.Controls.Add(Me.dgDetail)
        Me.Panel2.Location = New System.Drawing.Point(5, 82)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(497, 252)
        Me.Panel2.TabIndex = 35
        '
        'cmdDeleteRow
        '
        Me.cmdDeleteRow.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteRow.Location = New System.Drawing.Point(116, 215)
        Me.cmdDeleteRow.Name = "cmdDeleteRow"
        Me.cmdDeleteRow.Size = New System.Drawing.Size(113, 28)
        Me.cmdDeleteRow.TabIndex = 36
        Me.cmdDeleteRow.Text = "&Delete Row"
        '
        'cmdAddParent
        '
        Me.cmdAddParent.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddParent.Location = New System.Drawing.Point(6, 215)
        Me.cmdAddParent.Name = "cmdAddParent"
        Me.cmdAddParent.Size = New System.Drawing.Size(99, 28)
        Me.cmdAddParent.TabIndex = 35
        Me.cmdAddParent.Text = "&Add Parent"
        '
        'dgDetail
        '
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Location = New System.Drawing.Point(5, 4)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.Size = New System.Drawing.Size(484, 205)
        Me.dgDetail.TabIndex = 34
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdPrint)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.cmdEdit)
        Me.Panel1.Controls.Add(Me.cmdAdd)
        Me.Panel1.Location = New System.Drawing.Point(231, 341)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(271, 49)
        Me.Panel1.TabIndex = 33
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(220, 13)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(46, 23)
        Me.cmdPrint.TabIndex = 4
        Me.cmdPrint.Text = "&Exit"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(159, 13)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(55, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(107, 13)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(46, 23)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(55, 13)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(46, 23)
        Me.cmdEdit.TabIndex = 1
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(3, 13)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(46, 23)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(242, 15)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(28, 23)
        Me.cmdSearch.TabIndex = 32
        Me.cmdSearch.Text = "..."
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Remark/Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Over HeadCode"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Location = New System.Drawing.Point(114, 54)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(388, 20)
        Me.txtRemarks.TabIndex = 1
        '
        'txtConfigurationCode
        '
        Me.txtConfigurationCode.BackColor = System.Drawing.Color.White
        Me.txtConfigurationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfigurationCode.Location = New System.Drawing.Point(114, 17)
        Me.txtConfigurationCode.Name = "txtConfigurationCode"
        Me.txtConfigurationCode.Size = New System.Drawing.Size(117, 20)
        Me.txtConfigurationCode.TabIndex = 0
        '
        'gbSearch
        '
        Me.gbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbSearch.Controls.Add(Me.dgSearch)
        Me.gbSearch.Controls.Add(Me.lblSearch)
        Me.gbSearch.Controls.Add(Me.txtSearch)
        Me.gbSearch.Location = New System.Drawing.Point(5, 36)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(226, 293)
        Me.gbSearch.TabIndex = 125
        '
        'dgSearch
        '
        Me.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearch.Location = New System.Drawing.Point(6, 33)
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.RowHeadersVisible = False
        Me.dgSearch.RowTemplate.Height = 17
        Me.dgSearch.Size = New System.Drawing.Size(208, 251)
        Me.dgSearch.TabIndex = 15
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.Location = New System.Drawing.Point(6, 8)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(49, 16)
        Me.lblSearch.TabIndex = 14
        Me.lblSearch.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(82, 7)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(132, 20)
        Me.txtSearch.TabIndex = 1
        '
        'frmOverHeadMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ClientSize = New System.Drawing.Size(521, 444)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.gbSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmOverHeadMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents gbMain As System.Windows.Forms.Panel
    Friend WithEvents txtConfigurationCode As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents gbSearch As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents dgSearch As System.Windows.Forms.DataGridView
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdDeleteRow As System.Windows.Forms.Button
    Friend WithEvents cmdAddParent As System.Windows.Forms.Button
End Class
