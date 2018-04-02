<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaplePayments
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaplePayments))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbBanks = New System.Windows.Forms.ComboBox()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aaa = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Inser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditPaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddAsDebitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditBankFeesFromVouchersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetAsConfirmedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetAsUnconfirmedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.chkBank = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkClient = New System.Windows.Forms.CheckBox()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStripHideColumn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gbConfirmed = New System.Windows.Forms.GroupBox()
        Me.rbNotConfirmed = New System.Windows.Forms.RadioButton()
        Me.rbConfirmed = New System.Windows.Forms.RadioButton()
        Me.chkPayment = New System.Windows.Forms.CheckBox()
        Me.gbHandled = New System.Windows.Forms.GroupBox()
        Me.rbNotHandled = New System.Windows.Forms.RadioButton()
        Me.rbHandled = New System.Windows.Forms.RadioButton()
        Me.chkBankFees = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStripHideColumn.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConfirmed.SuspendLayout()
        Me.gbHandled.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dtpToDate)
        Me.Panel1.Controls.Add(Me.gbConfirmed)
        Me.Panel1.Controls.Add(Me.chkPayment)
        Me.Panel1.Controls.Add(Me.gbHandled)
        Me.Panel1.Controls.Add(Me.chkBankFees)
        Me.Panel1.Controls.Add(Me.chkStatus)
        Me.Panel1.Controls.Add(Me.cmbStatus)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpFromDate)
        Me.Panel1.Controls.Add(Me.cmbBanks)
        Me.Panel1.Controls.Add(Me.cmbClientCode)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.chkBank)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.chkClient)
        Me.Panel1.Controls.Add(Me.chkDate)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1407, 597)
        Me.Panel1.TabIndex = 0
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Location = New System.Drawing.Point(8, 72)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(70, 20)
        Me.chkStatus.TabIndex = 92
        Me.chkStatus.Text = "Status"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Enabled = False
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(82, 70)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(202, 24)
        Me.cmbStatus.TabIndex = 91
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1170, 9)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 33)
        Me.Button1.TabIndex = 88
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(396, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 16)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "To"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpToDate.Enabled = False
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(421, 38)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(200, 23)
        Me.dtpToDate.TabIndex = 84
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpFromDate.Enabled = False
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(421, 9)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(200, 23)
        Me.dtpFromDate.TabIndex = 84
        '
        'cmbBanks
        '
        Me.cmbBanks.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbBanks.DisplayMember = "Country"
        Me.cmbBanks.DropDownHeight = 400
        Me.cmbBanks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanks.DropDownWidth = 200
        Me.cmbBanks.Enabled = False
        Me.cmbBanks.FormattingEnabled = True
        Me.cmbBanks.IntegralHeight = False
        Me.cmbBanks.Location = New System.Drawing.Point(83, 38)
        Me.cmbBanks.Name = "cmbBanks"
        Me.cmbBanks.Size = New System.Drawing.Size(202, 24)
        Me.cmbBanks.TabIndex = 83
        Me.cmbBanks.ValueMember = "ID"
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
        Me.cmbClientCode.Location = New System.Drawing.Point(83, 8)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(202, 24)
        Me.cmbClientCode.TabIndex = 83
        Me.cmbClientCode.ValueMember = "ID"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clNo, Me.clID, Me.Category, Me.Column2, Me.Column1, Me.Column6, Me.Column3, Me.Column4, Me.Column5, Me.aaa, Me.Column8, Me.Inser, Me.Column7})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.Location = New System.Drawing.Point(4, 101)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1399, 492)
        Me.DataGridView1.TabIndex = 37
        '
        'clNo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.clNo.HeaderText = "No."
        Me.clNo.Name = "clNo"
        Me.clNo.ReadOnly = True
        Me.clNo.Width = 40
        '
        'clID
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clID.DefaultCellStyle = DataGridViewCellStyle3
        Me.clID.HeaderText = "ID"
        Me.clID.Name = "clID"
        Me.clID.ReadOnly = True
        '
        'Category
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Category.DefaultCellStyle = DataGridViewCellStyle4
        Me.Category.HeaderText = "Client"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 150
        '
        'Column2
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column2.HeaderText = "Maple Payment"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column1
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column1.HeaderText = "Bank Amount"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 120
        '
        'Column6
        '
        Me.Column6.HeaderText = "Bank Fees"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Bank"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 200
        '
        'Column4
        '
        Me.Column4.HeaderText = "Note"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 200
        '
        'Column5
        '
        Me.Column5.HeaderText = "Date"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'aaa
        '
        Me.aaa.HeaderText = "Bank Fees  (Handled)"
        Me.aaa.Name = "aaa"
        Me.aaa.ReadOnly = True
        Me.aaa.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.aaa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column8
        '
        Me.Column8.HeaderText = "Confirmed"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Inser
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Inser.DefaultCellStyle = DataGridViewCellStyle7
        Me.Inser.HeaderText = "Inserted by"
        Me.Inser.Name = "Inser"
        Me.Inser.ReadOnly = True
        Me.Inser.Width = 90
        '
        'Column7
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column7.HeaderText = "Edited by"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 90
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditPaymentToolStripMenuItem, Me.ToolStripSeparator1, Me.AddAsDebitToolStripMenuItem, Me.EditBankFeesFromVouchersToolStripMenuItem, Me.ToolStripSeparator2, Me.SetAsConfirmedToolStripMenuItem, Me.SetAsUnconfirmedToolStripMenuItem, Me.ToolStripSeparator3, Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(205, 154)
        '
        'EditPaymentToolStripMenuItem
        '
        Me.EditPaymentToolStripMenuItem.Name = "EditPaymentToolStripMenuItem"
        Me.EditPaymentToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.EditPaymentToolStripMenuItem.Text = "Edit Payment"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(201, 6)
        '
        'AddAsDebitToolStripMenuItem
        '
        Me.AddAsDebitToolStripMenuItem.Name = "AddAsDebitToolStripMenuItem"
        Me.AddAsDebitToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.AddAsDebitToolStripMenuItem.Text = "Add Bank Fees as voucher"
        Me.AddAsDebitToolStripMenuItem.Visible = False
        '
        'EditBankFeesFromVouchersToolStripMenuItem
        '
        Me.EditBankFeesFromVouchersToolStripMenuItem.Name = "EditBankFeesFromVouchersToolStripMenuItem"
        Me.EditBankFeesFromVouchersToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.EditBankFeesFromVouchersToolStripMenuItem.Text = "Edit Bank Fees from Vouchers"
        Me.EditBankFeesFromVouchersToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(201, 6)
        Me.ToolStripSeparator2.Visible = False
        '
        'SetAsConfirmedToolStripMenuItem
        '
        Me.SetAsConfirmedToolStripMenuItem.Name = "SetAsConfirmedToolStripMenuItem"
        Me.SetAsConfirmedToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.SetAsConfirmedToolStripMenuItem.Text = "Set as Confirmed"
        '
        'SetAsUnconfirmedToolStripMenuItem
        '
        Me.SetAsUnconfirmedToolStripMenuItem.Name = "SetAsUnconfirmedToolStripMenuItem"
        Me.SetAsUnconfirmedToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.SetAsUnconfirmedToolStripMenuItem.Text = "Set as Unconfirmed"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(201, 6)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1267, 8)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 34)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'chkBank
        '
        Me.chkBank.AutoSize = True
        Me.chkBank.Location = New System.Drawing.Point(9, 41)
        Me.chkBank.Name = "chkBank"
        Me.chkBank.Size = New System.Drawing.Size(58, 20)
        Me.chkBank.TabIndex = 86
        Me.chkBank.Text = "Bank"
        Me.chkBank.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(380, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "From"
        '
        'chkClient
        '
        Me.chkClient.AutoSize = True
        Me.chkClient.Location = New System.Drawing.Point(9, 11)
        Me.chkClient.Name = "chkClient"
        Me.chkClient.Size = New System.Drawing.Size(63, 20)
        Me.chkClient.TabIndex = 86
        Me.chkClient.Text = "Client"
        Me.chkClient.UseVisualStyleBackColor = True
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(327, 10)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(58, 20)
        Me.chkDate.TabIndex = 87
        Me.chkDate.Text = "Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'ContextMenuStripHideColumn
        '
        Me.ContextMenuStripHideColumn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideColumnToolStripMenuItem, Me.ShowAllColumnsToolStripMenuItem})
        Me.ContextMenuStripHideColumn.Name = "ContextMenuStripHideColumn"
        Me.ContextMenuStripHideColumn.Size = New System.Drawing.Size(172, 48)
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
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'gbConfirmed
        '
        Me.gbConfirmed.Controls.Add(Me.rbNotConfirmed)
        Me.gbConfirmed.Controls.Add(Me.rbConfirmed)
        Me.gbConfirmed.Enabled = False
        Me.gbConfirmed.Location = New System.Drawing.Point(823, 59)
        Me.gbConfirmed.Name = "gbConfirmed"
        Me.gbConfirmed.Size = New System.Drawing.Size(225, 37)
        Me.gbConfirmed.TabIndex = 97
        Me.gbConfirmed.TabStop = False
        '
        'rbNotConfirmed
        '
        Me.rbNotConfirmed.AutoSize = True
        Me.rbNotConfirmed.Location = New System.Drawing.Point(107, 12)
        Me.rbNotConfirmed.Name = "rbNotConfirmed"
        Me.rbNotConfirmed.Size = New System.Drawing.Size(117, 20)
        Me.rbNotConfirmed.TabIndex = 1
        Me.rbNotConfirmed.Text = "Not Confirmed"
        Me.rbNotConfirmed.UseVisualStyleBackColor = True
        '
        'rbConfirmed
        '
        Me.rbConfirmed.AutoSize = True
        Me.rbConfirmed.Checked = True
        Me.rbConfirmed.Location = New System.Drawing.Point(6, 11)
        Me.rbConfirmed.Name = "rbConfirmed"
        Me.rbConfirmed.Size = New System.Drawing.Size(91, 20)
        Me.rbConfirmed.TabIndex = 0
        Me.rbConfirmed.TabStop = True
        Me.rbConfirmed.Text = "Confirmed"
        Me.rbConfirmed.UseVisualStyleBackColor = True
        '
        'chkPayment
        '
        Me.chkPayment.AutoSize = True
        Me.chkPayment.Location = New System.Drawing.Point(689, 70)
        Me.chkPayment.Name = "chkPayment"
        Me.chkPayment.Size = New System.Drawing.Size(131, 20)
        Me.chkPayment.TabIndex = 98
        Me.chkPayment.Text = "Payment Status"
        Me.chkPayment.UseVisualStyleBackColor = True
        '
        'gbHandled
        '
        Me.gbHandled.Controls.Add(Me.rbNotHandled)
        Me.gbHandled.Controls.Add(Me.rbHandled)
        Me.gbHandled.Enabled = False
        Me.gbHandled.Location = New System.Drawing.Point(422, 60)
        Me.gbHandled.Name = "gbHandled"
        Me.gbHandled.Size = New System.Drawing.Size(200, 37)
        Me.gbHandled.TabIndex = 95
        Me.gbHandled.TabStop = False
        '
        'rbNotHandled
        '
        Me.rbNotHandled.AutoSize = True
        Me.rbNotHandled.Location = New System.Drawing.Point(93, 12)
        Me.rbNotHandled.Name = "rbNotHandled"
        Me.rbNotHandled.Size = New System.Drawing.Size(104, 20)
        Me.rbNotHandled.TabIndex = 1
        Me.rbNotHandled.Text = "Not Handled"
        Me.rbNotHandled.UseVisualStyleBackColor = True
        '
        'rbHandled
        '
        Me.rbHandled.AutoSize = True
        Me.rbHandled.Checked = True
        Me.rbHandled.Location = New System.Drawing.Point(6, 11)
        Me.rbHandled.Name = "rbHandled"
        Me.rbHandled.Size = New System.Drawing.Size(78, 20)
        Me.rbHandled.TabIndex = 0
        Me.rbHandled.TabStop = True
        Me.rbHandled.Text = "Handled"
        Me.rbHandled.UseVisualStyleBackColor = True
        '
        'chkBankFees
        '
        Me.chkBankFees.AutoSize = True
        Me.chkBankFees.Location = New System.Drawing.Point(327, 72)
        Me.chkBankFees.Name = "chkBankFees"
        Me.chkBankFees.Size = New System.Drawing.Size(91, 20)
        Me.chkBankFees.TabIndex = 96
        Me.chkBankFees.Text = "Bank Fees"
        Me.chkBankFees.UseVisualStyleBackColor = True
        '
        'frmMaplePayments
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1411, 602)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmMaplePayments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maple Payments"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStripHideColumn.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConfirmed.ResumeLayout(False)
        Me.gbConfirmed.PerformLayout()
        Me.gbHandled.ResumeLayout(False)
        Me.gbHandled.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStripHideColumn As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HideColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbClientCode As System.Windows.Forms.ComboBox
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkClient As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents EditPaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AddAsDebitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbBanks As System.Windows.Forms.ComboBox
    Friend WithEvents chkBank As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents EditBankFeesFromVouchersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetAsConfirmedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetAsUnconfirmedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents clNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aaa As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Inser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbConfirmed As System.Windows.Forms.GroupBox
    Friend WithEvents rbNotConfirmed As System.Windows.Forms.RadioButton
    Friend WithEvents rbConfirmed As System.Windows.Forms.RadioButton
    Friend WithEvents chkPayment As System.Windows.Forms.CheckBox
    Friend WithEvents gbHandled As System.Windows.Forms.GroupBox
    Friend WithEvents rbNotHandled As System.Windows.Forms.RadioButton
    Friend WithEvents rbHandled As System.Windows.Forms.RadioButton
    Friend WithEvents chkBankFees As System.Windows.Forms.CheckBox

End Class
