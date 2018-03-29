<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientStatementOfAccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientStatementOfAccount))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbOneClient = New System.Windows.Forms.RadioButton()
        Me.rbAllClients = New System.Windows.Forms.RadioButton()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.btnGetSOAMC = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.rbOneClient)
        Me.Panel1.Controls.Add(Me.rbAllClients)
        Me.Panel1.Controls.Add(Me.chkStatus)
        Me.Panel1.Controls.Add(Me.cmbStatus)
        Me.Panel1.Controls.Add(Me.cmbClientCode)
        Me.Panel1.Controls.Add(Me.btnGetSOAMC)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 204)
        Me.Panel1.TabIndex = 0
        '
        'rbOneClient
        '
        Me.rbOneClient.AutoSize = True
        Me.rbOneClient.Location = New System.Drawing.Point(11, 86)
        Me.rbOneClient.Name = "rbOneClient"
        Me.rbOneClient.Size = New System.Drawing.Size(91, 20)
        Me.rbOneClient.TabIndex = 97
        Me.rbOneClient.TabStop = True
        Me.rbOneClient.Text = "One Client"
        Me.rbOneClient.UseVisualStyleBackColor = True
        '
        'rbAllClients
        '
        Me.rbAllClients.AutoSize = True
        Me.rbAllClients.Location = New System.Drawing.Point(11, 19)
        Me.rbAllClients.Name = "rbAllClients"
        Me.rbAllClients.Size = New System.Drawing.Size(89, 20)
        Me.rbAllClients.TabIndex = 97
        Me.rbAllClients.TabStop = True
        Me.rbAllClients.Text = "All Clients"
        Me.rbAllClients.UseVisualStyleBackColor = True
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Enabled = False
        Me.chkStatus.Location = New System.Drawing.Point(29, 48)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(70, 20)
        Me.chkStatus.TabIndex = 96
        Me.chkStatus.Text = "Status"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Enabled = False
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(105, 46)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(213, 24)
        Me.cmbStatus.TabIndex = 95
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
        Me.cmbClientCode.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmbClientCode.Location = New System.Drawing.Point(105, 84)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(213, 24)
        Me.cmbClientCode.TabIndex = 41
        Me.cmbClientCode.ValueMember = "ID"
        '
        'btnGetSOAMC
        '
        Me.btnGetSOAMC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGetSOAMC.Enabled = False
        Me.btnGetSOAMC.Location = New System.Drawing.Point(14, 148)
        Me.btnGetSOAMC.Name = "btnGetSOAMC"
        Me.btnGetSOAMC.Size = New System.Drawing.Size(106, 47)
        Me.btnGetSOAMC.TabIndex = 6
        Me.btnGetSOAMC.Text = "Get SOA w MC Balance"
        Me.btnGetSOAMC.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(126, 148)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(106, 47)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Get SOA"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(238, 148)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 47)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmClientStatementOfAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(362, 209)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmClientStatementOfAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Statement Of Account"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbClientCode As System.Windows.Forms.ComboBox
    Friend WithEvents rbOneClient As System.Windows.Forms.RadioButton
    Friend WithEvents rbAllClients As System.Windows.Forms.RadioButton
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetSOAMC As System.Windows.Forms.Button

End Class
