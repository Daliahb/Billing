<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPotentialClients2
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPotentialClients2))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DsAccountManagers = New WindowsApplication1.dsAccountManagers()
        Me.AccountManagersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AccountManagersTableAdapter = New WindowsApplication1.dsAccountManagersTableAdapters.AccountManagersTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.dsAccountManagersTableAdapters.TableAdapterManager()
        Me.dgID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPhone2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMobile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSkype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgWebsite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgExhibitionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCreditCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgIsContacted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgActionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgNote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAccountManagers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountManagersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Location = New System.Drawing.Point(691, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(170, 35)
        Me.Panel2.TabIndex = 17
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 28)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(92, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 28)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgID, Me.dgName, Me.dgPhone, Me.dgEmail, Me.dgAddress, Me.dgTitle, Me.dgCompanyName, Me.dgPhone2, Me.dgMobile, Me.dgSkype, Me.dgWebsite, Me.dgExhibitionName, Me.dgLimit, Me.dgCreditCheck, Me.dgIsContacted, Me.dgActionDate, Me.dgNote})
        Me.DataGridView1.Location = New System.Drawing.Point(5, 44)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1545, 597)
        Me.DataGridView1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.DataGridView2)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1553, 644)
        Me.Panel1.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(4, 44)
        Me.DataGridView2.Name = "DataGridView2"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.RowHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView2.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(1545, 577)
        Me.DataGridView2.TabIndex = 18
        '
        'DsAccountManagers
        '
        Me.DsAccountManagers.DataSetName = "dsAccountManagers"
        Me.DsAccountManagers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AccountManagersBindingSource
        '
        Me.AccountManagersBindingSource.DataMember = "AccountManagers"
        Me.AccountManagersBindingSource.DataSource = Me.DsAccountManagers
        '
        'AccountManagersTableAdapter
        '
        Me.AccountManagersTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AccountManagersTableAdapter = Me.AccountManagersTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.dsAccountManagersTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'dgID
        '
        Me.dgID.HeaderText = "ID"
        Me.dgID.Name = "dgID"
        Me.dgID.Visible = False
        '
        'dgName
        '
        Me.dgName.HeaderText = "Name"
        Me.dgName.Name = "dgName"
        Me.dgName.Width = 120
        '
        'dgPhone
        '
        Me.dgPhone.HeaderText = "Phone"
        Me.dgPhone.Name = "dgPhone"
        Me.dgPhone.Width = 120
        '
        'dgEmail
        '
        Me.dgEmail.HeaderText = "Email"
        Me.dgEmail.Name = "dgEmail"
        Me.dgEmail.Width = 120
        '
        'dgAddress
        '
        Me.dgAddress.HeaderText = "Address"
        Me.dgAddress.Name = "dgAddress"
        Me.dgAddress.Width = 120
        '
        'dgTitle
        '
        Me.dgTitle.HeaderText = "Title"
        Me.dgTitle.Name = "dgTitle"
        '
        'dgCompanyName
        '
        Me.dgCompanyName.HeaderText = "Company Name"
        Me.dgCompanyName.Name = "dgCompanyName"
        Me.dgCompanyName.Width = 120
        '
        'dgPhone2
        '
        Me.dgPhone2.HeaderText = "Phone2"
        Me.dgPhone2.Name = "dgPhone2"
        '
        'dgMobile
        '
        Me.dgMobile.HeaderText = "Mobile"
        Me.dgMobile.Name = "dgMobile"
        '
        'dgSkype
        '
        Me.dgSkype.HeaderText = "Skype"
        Me.dgSkype.Name = "dgSkype"
        '
        'dgWebsite
        '
        Me.dgWebsite.HeaderText = "Website"
        Me.dgWebsite.Name = "dgWebsite"
        Me.dgWebsite.Width = 120
        '
        'dgExhibitionName
        '
        Me.dgExhibitionName.HeaderText = "Exhibition Name"
        Me.dgExhibitionName.Name = "dgExhibitionName"
        Me.dgExhibitionName.Width = 120
        '
        'dgLimit
        '
        Me.dgLimit.HeaderText = "Limit"
        Me.dgLimit.Name = "dgLimit"
        '
        'dgCreditCheck
        '
        Me.dgCreditCheck.HeaderText = "Credit Check"
        Me.dgCreditCheck.Name = "dgCreditCheck"
        Me.dgCreditCheck.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCreditCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgIsContacted
        '
        Me.dgIsContacted.HeaderText = "Contacted?"
        Me.dgIsContacted.Name = "dgIsContacted"
        Me.dgIsContacted.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgIsContacted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgActionDate
        '
        Me.dgActionDate.HeaderText = "Action Date"
        Me.dgActionDate.Name = "dgActionDate"
        '
        'dgNote
        '
        Me.dgNote.HeaderText = "Note"
        Me.dgNote.Name = "dgNote"
        '
        'frmPotentialClients2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1557, 649)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmPotentialClients2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Potential Clients"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAccountManagers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountManagersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CountryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn


    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOfPrivateClassesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOfGroupClassesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsPerClassDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

    Friend WithEvents ActionDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DsAccountManagers As WindowsApplication1.dsAccountManagers
    Friend WithEvents AccountManagersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountManagersTableAdapter As WindowsApplication1.dsAccountManagersTableAdapters.AccountManagersTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.dsAccountManagersTableAdapters.TableAdapterManager
    Friend WithEvents dgID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCompanyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPhone2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgSkype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgWebsite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgExhibitionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgCreditCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgIsContacted As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgActionDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgNote As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
