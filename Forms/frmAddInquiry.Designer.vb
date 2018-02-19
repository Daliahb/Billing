<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddInquiry
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddInquiry))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkClearAll = New System.Windows.Forms.CheckBox()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.chkClient = New System.Windows.Forms.CheckBox()
        Me.chkCompanyPoints = New System.Windows.Forms.CheckBox()
        Me.chkUsersList = New System.Windows.Forms.CheckedListBox()
        Me.rbTP = New System.Windows.Forms.RadioButton()
        Me.rbOP = New System.Windows.Forms.RadioButton()
        Me.cmbTP = New System.Windows.Forms.ComboBox()
        Me.cmbOP = New System.Windows.Forms.ComboBox()
        Me.cmbPriority = New System.Windows.Forms.ComboBox()
        Me.cmbUsersCategories = New System.Windows.Forms.ComboBox()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTask = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(136, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 31)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkClearAll)
        Me.Panel1.Controls.Add(Me.chkSelectAll)
        Me.Panel1.Controls.Add(Me.chkClient)
        Me.Panel1.Controls.Add(Me.chkCompanyPoints)
        Me.Panel1.Controls.Add(Me.chkUsersList)
        Me.Panel1.Controls.Add(Me.rbTP)
        Me.Panel1.Controls.Add(Me.rbOP)
        Me.Panel1.Controls.Add(Me.cmbTP)
        Me.Panel1.Controls.Add(Me.cmbOP)
        Me.Panel1.Controls.Add(Me.cmbPriority)
        Me.Panel1.Controls.Add(Me.cmbUsersCategories)
        Me.Panel1.Controls.Add(Me.cmbClientCode)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtTask)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(1, 6)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(538, 471)
        Me.Panel1.TabIndex = 1
        '
        'chkClearAll
        '
        Me.chkClearAll.AutoSize = True
        Me.chkClearAll.Location = New System.Drawing.Point(57, 325)
        Me.chkClearAll.Name = "chkClearAll"
        Me.chkClearAll.Size = New System.Drawing.Size(80, 20)
        Me.chkClearAll.TabIndex = 85
        Me.chkClearAll.Text = "Clear All"
        Me.chkClearAll.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Location = New System.Drawing.Point(57, 299)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(87, 20)
        Me.chkSelectAll.TabIndex = 85
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'chkClient
        '
        Me.chkClient.AutoSize = True
        Me.chkClient.Location = New System.Drawing.Point(10, 44)
        Me.chkClient.Name = "chkClient"
        Me.chkClient.Size = New System.Drawing.Size(63, 20)
        Me.chkClient.TabIndex = 84
        Me.chkClient.Text = "Client"
        Me.chkClient.UseVisualStyleBackColor = True
        '
        'chkCompanyPoints
        '
        Me.chkCompanyPoints.AutoSize = True
        Me.chkCompanyPoints.Location = New System.Drawing.Point(10, 77)
        Me.chkCompanyPoints.Name = "chkCompanyPoints"
        Me.chkCompanyPoints.Size = New System.Drawing.Size(67, 20)
        Me.chkCompanyPoints.TabIndex = 84
        Me.chkCompanyPoints.Text = "Points"
        Me.chkCompanyPoints.UseVisualStyleBackColor = True
        '
        'chkUsersList
        '
        Me.chkUsersList.FormattingEnabled = True
        Me.chkUsersList.Location = New System.Drawing.Point(145, 297)
        Me.chkUsersList.Name = "chkUsersList"
        Me.chkUsersList.Size = New System.Drawing.Size(373, 112)
        Me.chkUsersList.TabIndex = 83
        '
        'rbTP
        '
        Me.rbTP.AutoSize = True
        Me.rbTP.Enabled = False
        Me.rbTP.Location = New System.Drawing.Point(97, 105)
        Me.rbTP.Name = "rbTP"
        Me.rbTP.Size = New System.Drawing.Size(41, 20)
        Me.rbTP.TabIndex = 82
        Me.rbTP.TabStop = True
        Me.rbTP.Text = "TP"
        Me.rbTP.UseVisualStyleBackColor = True
        '
        'rbOP
        '
        Me.rbOP.AutoSize = True
        Me.rbOP.Enabled = False
        Me.rbOP.Location = New System.Drawing.Point(97, 74)
        Me.rbOP.Name = "rbOP"
        Me.rbOP.Size = New System.Drawing.Size(43, 20)
        Me.rbOP.TabIndex = 82
        Me.rbOP.TabStop = True
        Me.rbOP.Text = "OP"
        Me.rbOP.UseVisualStyleBackColor = True
        '
        'cmbTP
        '
        Me.cmbTP.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbTP.DisplayMember = "Country"
        Me.cmbTP.DropDownHeight = 400
        Me.cmbTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTP.DropDownWidth = 200
        Me.cmbTP.Enabled = False
        Me.cmbTP.FormattingEnabled = True
        Me.cmbTP.IntegralHeight = False
        Me.cmbTP.Location = New System.Drawing.Point(145, 101)
        Me.cmbTP.Name = "cmbTP"
        Me.cmbTP.Size = New System.Drawing.Size(373, 24)
        Me.cmbTP.TabIndex = 0
        Me.cmbTP.ValueMember = "ID"
        '
        'cmbOP
        '
        Me.cmbOP.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbOP.DisplayMember = "Country"
        Me.cmbOP.DropDownHeight = 400
        Me.cmbOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOP.DropDownWidth = 200
        Me.cmbOP.Enabled = False
        Me.cmbOP.FormattingEnabled = True
        Me.cmbOP.IntegralHeight = False
        Me.cmbOP.Location = New System.Drawing.Point(145, 70)
        Me.cmbOP.Name = "cmbOP"
        Me.cmbOP.Size = New System.Drawing.Size(373, 24)
        Me.cmbOP.TabIndex = 0
        Me.cmbOP.ValueMember = "ID"
        '
        'cmbPriority
        '
        Me.cmbPriority.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbPriority.DisplayMember = "Country"
        Me.cmbPriority.DropDownHeight = 400
        Me.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPriority.DropDownWidth = 200
        Me.cmbPriority.FormattingEnabled = True
        Me.cmbPriority.IntegralHeight = False
        Me.cmbPriority.Location = New System.Drawing.Point(145, 10)
        Me.cmbPriority.Name = "cmbPriority"
        Me.cmbPriority.Size = New System.Drawing.Size(373, 24)
        Me.cmbPriority.TabIndex = 0
        Me.cmbPriority.ValueMember = "ID"
        '
        'cmbUsersCategories
        '
        Me.cmbUsersCategories.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbUsersCategories.DisplayMember = "Country"
        Me.cmbUsersCategories.DropDownHeight = 400
        Me.cmbUsersCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsersCategories.DropDownWidth = 200
        Me.cmbUsersCategories.FormattingEnabled = True
        Me.cmbUsersCategories.IntegralHeight = False
        Me.cmbUsersCategories.Location = New System.Drawing.Point(145, 265)
        Me.cmbUsersCategories.Name = "cmbUsersCategories"
        Me.cmbUsersCategories.Size = New System.Drawing.Size(373, 24)
        Me.cmbUsersCategories.TabIndex = 0
        Me.cmbUsersCategories.ValueMember = "ID"
        '
        'cmbClientCode
        '
        Me.cmbClientCode.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbClientCode.DisplayMember = "Country"
        Me.cmbClientCode.DropDownHeight = 400
        Me.cmbClientCode.DropDownWidth = 200
        Me.cmbClientCode.Enabled = False
        Me.cmbClientCode.FormattingEnabled = True
        Me.cmbClientCode.IntegralHeight = False
        Me.cmbClientCode.Location = New System.Drawing.Point(146, 40)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(373, 24)
        Me.cmbClientCode.TabIndex = 0
        Me.cmbClientCode.ValueMember = "ID"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dddd  dd/MM/yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(146, 221)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(372, 23)
        Me.DateTimePicker1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Prioriy Level"
        '
        'txtTask
        '
        Me.txtTask.Location = New System.Drawing.Point(145, 133)
        Me.txtTask.Multiline = True
        Me.txtTask.Name = "txtTask"
        Me.txtTask.Size = New System.Drawing.Size(373, 80)
        Me.txtTask.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 136)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 16)
        Me.Label12.TabIndex = 76
        Me.Label12.Text = "Task"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Location = New System.Drawing.Point(141, 429)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(254, 35)
        Me.Panel2.TabIndex = 78
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(44, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 31)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(44, 2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 31)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 269)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 16)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Send to"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmAddInquiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(542, 478)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmAddInquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Inquiry"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbClientCode As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents txtTask As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkUsersList As System.Windows.Forms.CheckedListBox
    Friend WithEvents rbTP As System.Windows.Forms.RadioButton
    Friend WithEvents rbOP As System.Windows.Forms.RadioButton
    Friend WithEvents cmbTP As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOP As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPriority As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbUsersCategories As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkCompanyPoints As System.Windows.Forms.CheckBox
    Friend WithEvents chkClearAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkClient As System.Windows.Forms.CheckBox
End Class
