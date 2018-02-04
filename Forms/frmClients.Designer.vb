<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClients
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClients))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.chkAddedFromMC = New System.Windows.Forms.CheckBox()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.chkAgreement = New System.Windows.Forms.CheckBox()
        Me.cmbAgreement = New System.Windows.Forms.ComboBox()
        Me.cmbAccountManager = New System.Windows.Forms.ComboBox()
        Me.AccountManagersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAccountManagers = New WindowsApplication1.dsAccountManagers()
        Me.cmbContractMapleBank = New System.Windows.Forms.ComboBox()
        Me.cmbContractMapleName = New System.Windows.Forms.ComboBox()
        Me.chkContractWith = New System.Windows.Forms.CheckBox()
        Me.chkBankAccount = New System.Windows.Forms.CheckBox()
        Me.chkAccountManager = New System.Windows.Forms.CheckBox()
        Me.chkCompanyID = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnAddCustomer = New System.Windows.Forms.Button()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountManagersTableAdapter = New WindowsApplication1.dsAccountManagersTableAdapters.AccountManagersTableAdapter()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clMobile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.AccountManagersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAccountManagers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbClientCode)
        Me.Panel1.Controls.Add(Me.chkAddedFromMC)
        Me.Panel1.Controls.Add(Me.chkStatus)
        Me.Panel1.Controls.Add(Me.cmbStatus)
        Me.Panel1.Controls.Add(Me.chkAgreement)
        Me.Panel1.Controls.Add(Me.cmbAgreement)
        Me.Panel1.Controls.Add(Me.cmbAccountManager)
        Me.Panel1.Controls.Add(Me.cmbContractMapleBank)
        Me.Panel1.Controls.Add(Me.cmbContractMapleName)
        Me.Panel1.Controls.Add(Me.chkContractWith)
        Me.Panel1.Controls.Add(Me.chkBankAccount)
        Me.Panel1.Controls.Add(Me.chkAccountManager)
        Me.Panel1.Controls.Add(Me.chkCompanyID)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.btnAddCustomer)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1679, 696)
        Me.Panel1.TabIndex = 0
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
        Me.cmbClientCode.Location = New System.Drawing.Point(151, 2)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(228, 24)
        Me.cmbClientCode.TabIndex = 85
        Me.cmbClientCode.ValueMember = "ID"
        '
        'chkAddedFromMC
        '
        Me.chkAddedFromMC.AutoSize = True
        Me.chkAddedFromMC.Location = New System.Drawing.Point(470, 65)
        Me.chkAddedFromMC.Name = "chkAddedFromMC"
        Me.chkAddedFromMC.Size = New System.Drawing.Size(127, 20)
        Me.chkAddedFromMC.TabIndex = 84
        Me.chkAddedFromMC.Text = "Added From MC"
        Me.chkAddedFromMC.UseVisualStyleBackColor = True
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Location = New System.Drawing.Point(964, 5)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(70, 20)
        Me.chkStatus.TabIndex = 83
        Me.chkStatus.Text = "Status"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Enabled = False
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(1038, 3)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(228, 24)
        Me.cmbStatus.TabIndex = 82
        '
        'chkAgreement
        '
        Me.chkAgreement.AutoSize = True
        Me.chkAgreement.Location = New System.Drawing.Point(10, 63)
        Me.chkAgreement.Name = "chkAgreement"
        Me.chkAgreement.Size = New System.Drawing.Size(100, 20)
        Me.chkAgreement.TabIndex = 83
        Me.chkAgreement.Text = "Agreement"
        Me.chkAgreement.UseVisualStyleBackColor = True
        '
        'cmbAgreement
        '
        Me.cmbAgreement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgreement.Enabled = False
        Me.cmbAgreement.FormattingEnabled = True
        Me.cmbAgreement.Location = New System.Drawing.Point(151, 61)
        Me.cmbAgreement.Name = "cmbAgreement"
        Me.cmbAgreement.Size = New System.Drawing.Size(228, 24)
        Me.cmbAgreement.TabIndex = 82
        '
        'cmbAccountManager
        '
        Me.cmbAccountManager.DataSource = Me.AccountManagersBindingSource
        Me.cmbAccountManager.DisplayMember = "Name"
        Me.cmbAccountManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccountManager.Enabled = False
        Me.cmbAccountManager.FormattingEnabled = True
        Me.cmbAccountManager.Location = New System.Drawing.Point(151, 32)
        Me.cmbAccountManager.Name = "cmbAccountManager"
        Me.cmbAccountManager.Size = New System.Drawing.Size(228, 24)
        Me.cmbAccountManager.TabIndex = 78
        Me.cmbAccountManager.ValueMember = "id"
        '
        'AccountManagersBindingSource
        '
        Me.AccountManagersBindingSource.DataMember = "AccountManagers"
        Me.AccountManagersBindingSource.DataSource = Me.DsAccountManagers
        '
        'DsAccountManagers
        '
        Me.DsAccountManagers.DataSetName = "dsAccountManagers"
        Me.DsAccountManagers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbContractMapleBank
        '
        Me.cmbContractMapleBank.DisplayMember = "id"
        Me.cmbContractMapleBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbContractMapleBank.Enabled = False
        Me.cmbContractMapleBank.FormattingEnabled = True
        Me.cmbContractMapleBank.Location = New System.Drawing.Point(592, 32)
        Me.cmbContractMapleBank.Name = "cmbContractMapleBank"
        Me.cmbContractMapleBank.Size = New System.Drawing.Size(297, 24)
        Me.cmbContractMapleBank.TabIndex = 63
        Me.cmbContractMapleBank.ValueMember = "id"
        '
        'cmbContractMapleName
        '
        Me.cmbContractMapleName.DisplayMember = "id"
        Me.cmbContractMapleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbContractMapleName.Enabled = False
        Me.cmbContractMapleName.FormattingEnabled = True
        Me.cmbContractMapleName.Location = New System.Drawing.Point(592, 3)
        Me.cmbContractMapleName.Name = "cmbContractMapleName"
        Me.cmbContractMapleName.Size = New System.Drawing.Size(297, 24)
        Me.cmbContractMapleName.TabIndex = 62
        Me.cmbContractMapleName.ValueMember = "id"
        '
        'chkContractWith
        '
        Me.chkContractWith.AutoSize = True
        Me.chkContractWith.Location = New System.Drawing.Point(470, 5)
        Me.chkContractWith.Name = "chkContractWith"
        Me.chkContractWith.Size = New System.Drawing.Size(116, 20)
        Me.chkContractWith.TabIndex = 61
        Me.chkContractWith.Text = "Contract with"
        Me.chkContractWith.UseVisualStyleBackColor = True
        '
        'chkBankAccount
        '
        Me.chkBankAccount.AutoSize = True
        Me.chkBankAccount.Location = New System.Drawing.Point(470, 34)
        Me.chkBankAccount.Name = "chkBankAccount"
        Me.chkBankAccount.Size = New System.Drawing.Size(116, 20)
        Me.chkBankAccount.TabIndex = 60
        Me.chkBankAccount.Text = "Bank Account"
        Me.chkBankAccount.UseVisualStyleBackColor = True
        '
        'chkAccountManager
        '
        Me.chkAccountManager.AutoSize = True
        Me.chkAccountManager.Location = New System.Drawing.Point(10, 34)
        Me.chkAccountManager.Name = "chkAccountManager"
        Me.chkAccountManager.Size = New System.Drawing.Size(142, 20)
        Me.chkAccountManager.TabIndex = 59
        Me.chkAccountManager.Text = "Account Manager"
        Me.chkAccountManager.UseVisualStyleBackColor = True
        '
        'chkCompanyID
        '
        Me.chkCompanyID.AutoSize = True
        Me.chkCompanyID.Location = New System.Drawing.Point(10, 5)
        Me.chkCompanyID.Name = "chkCompanyID"
        Me.chkCompanyID.Size = New System.Drawing.Size(104, 20)
        Me.chkCompanyID.TabIndex = 58
        Me.chkCompanyID.Text = "Company ID"
        Me.chkCompanyID.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clID, Me.clNo, Me.clName, Me.clEmail, Me.Column12, Me.clMobile, Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column6, Me.Column11, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column13})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.Location = New System.Drawing.Point(3, 90)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1670, 600)
        Me.DataGridView1.TabIndex = 39
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteRowToolStripMenuItem, Me.ActivateToolStripMenuItem, Me.ToolStripSeparator1, Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(151, 98)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.EditToolStripMenuItem.Text = "Edit Record"
        '
        'DeleteRowToolStripMenuItem
        '
        Me.DeleteRowToolStripMenuItem.Name = "DeleteRowToolStripMenuItem"
        Me.DeleteRowToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.DeleteRowToolStripMenuItem.Text = "Delete Record"
        '
        'ActivateToolStripMenuItem
        '
        Me.ActivateToolStripMenuItem.Name = "ActivateToolStripMenuItem"
        Me.ActivateToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ActivateToolStripMenuItem.Text = "Activate"
        Me.ActivateToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(147, 6)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(1572, 5)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(101, 34)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnAddCustomer
        '
        Me.btnAddCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCustomer.Location = New System.Drawing.Point(1498, 4)
        Me.btnAddCustomer.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddCustomer.Name = "btnAddCustomer"
        Me.btnAddCustomer.Size = New System.Drawing.Size(64, 34)
        Me.btnAddCustomer.TabIndex = 35
        Me.btnAddCustomer.Text = "Add"
        Me.btnAddCustomer.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideColumnToolStripMenuItem, Me.ShowAllColumnsToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(172, 48)
        '
        'HideColumnToolStripMenuItem
        '
        Me.HideColumnToolStripMenuItem.Name = "HideColumnToolStripMenuItem"
        Me.HideColumnToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.HideColumnToolStripMenuItem.Text = "Hide Column"
        '
        'ShowAllColumnsToolStripMenuItem
        '
        Me.ShowAllColumnsToolStripMenuItem.Name = "ShowAllColumnsToolStripMenuItem"
        Me.ShowAllColumnsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ShowAllColumnsToolStripMenuItem.Text = "Show All Columns"
        '
        'AccountManagersTableAdapter
        '
        Me.AccountManagersTableAdapter.ClearBeforeFill = True
        '
        'clID
        '
        Me.clID.HeaderText = "ID"
        Me.clID.Name = "clID"
        Me.clID.ReadOnly = True
        Me.clID.Visible = False
        Me.clID.Width = 28
        '
        'clNo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.clNo.HeaderText = "No."
        Me.clNo.Name = "clNo"
        Me.clNo.ReadOnly = True
        Me.clNo.Width = 53
        '
        'clName
        '
        Me.clName.HeaderText = "Company Name"
        Me.clName.Name = "clName"
        Me.clName.ReadOnly = True
        Me.clName.Width = 120
        '
        'clEmail
        '
        Me.clEmail.HeaderText = "Company ID"
        Me.clEmail.Name = "clEmail"
        Me.clEmail.ReadOnly = True
        Me.clEmail.Width = 101
        '
        'Column12
        '
        Me.Column12.HeaderText = "Status"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 76
        '
        'clMobile
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clMobile.DefaultCellStyle = DataGridViewCellStyle3
        Me.clMobile.HeaderText = "Time Zone"
        Me.clMobile.Name = "clMobile"
        Me.clMobile.ReadOnly = True
        Me.clMobile.Width = 89
        '
        'Column5
        '
        Me.Column5.HeaderText = " "
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 37
        '
        'Column1
        '
        Me.Column1.HeaderText = "Credit Limit"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 97
        '
        'Column2
        '
        Me.Column2.HeaderText = "Contract With"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 114
        '
        'Column3
        '
        Me.Column3.HeaderText = "Bank Account"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 112
        '
        'Column4
        '
        Me.Column4.HeaderText = "Account Manager"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 135
        '
        'Column6
        '
        Me.Column6.HeaderText = "Agreement"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 106
        '
        'Column11
        '
        Me.Column11.HeaderText = "Bank Account Name"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 147
        '
        'Column7
        '
        Me.Column7.HeaderText = "Bank Account No."
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 115
        '
        'Column8
        '
        Me.Column8.HeaderText = "IBAN"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 64
        '
        'Column9
        '
        Me.Column9.HeaderText = "SWIFT"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 72
        '
        'Column10
        '
        Me.Column10.HeaderText = "ABA Routing No."
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 109
        '
        'Column13
        '
        Me.Column13.HeaderText = "Billing Email"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 96
        '
        'frmClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1684, 695)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmClients"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clients"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.AccountManagersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAccountManagers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteRowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddCustomer As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HideColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkBankAccount As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccountManager As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompanyID As System.Windows.Forms.CheckBox
    Friend WithEvents chkContractWith As System.Windows.Forms.CheckBox
    Friend WithEvents cmbContractMapleName As System.Windows.Forms.ComboBox
    Friend WithEvents cmbContractMapleBank As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAccountManager As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgreement As System.Windows.Forms.ComboBox
    Friend WithEvents chkAgreement As System.Windows.Forms.CheckBox
    Friend WithEvents DsAccountManagers As WindowsApplication1.dsAccountManagers
    Friend WithEvents AccountManagersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountManagersTableAdapter As WindowsApplication1.dsAccountManagersTableAdapters.AccountManagersTableAdapter
    Friend WithEvents chkAddedFromMC As System.Windows.Forms.CheckBox
    Friend WithEvents cmbClientCode As System.Windows.Forms.ComboBox
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents clID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clMobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
