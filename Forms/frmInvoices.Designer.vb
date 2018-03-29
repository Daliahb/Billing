<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoices
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoices))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbPeriod = New System.Windows.Forms.ComboBox()
        Me.chkPeriod = New System.Windows.Forms.CheckBox()
        Me.chkDurationZero = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbSent = New System.Windows.Forms.RadioButton()
        Me.rbNotSent = New System.Windows.Forms.RadioButton()
        Me.chkEmail = New System.Windows.Forms.CheckBox()
        Me.cmbBillingDates = New System.Windows.Forms.ComboBox()
        Me.lblTotalDuration = New System.Windows.Forms.Label()
        Me.lblTotalCharges = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.chkPeriodDate = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.chkCode = New System.Windows.Forms.CheckBox()
        Me.chkInsertDate = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkClearAll = New System.Windows.Forms.CheckBox()
        Me.btnSendTestEmails = New System.Windows.Forms.Button()
        Me.btnSendEmails = New System.Windows.Forms.Button()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStripHideColumn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.clNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStripHideColumn.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cmbPeriod)
        Me.Panel1.Controls.Add(Me.chkPeriod)
        Me.Panel1.Controls.Add(Me.chkDurationZero)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.chkEmail)
        Me.Panel1.Controls.Add(Me.cmbBillingDates)
        Me.Panel1.Controls.Add(Me.lblTotalDuration)
        Me.Panel1.Controls.Add(Me.lblTotalCharges)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.chkPeriodDate)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.cmbClientCode)
        Me.Panel1.Controls.Add(Me.chkCode)
        Me.Panel1.Controls.Add(Me.chkInsertDate)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1524, 472)
        Me.Panel1.TabIndex = 0
        '
        'cmbPeriod
        '
        Me.cmbPeriod.DisplayMember = "id"
        Me.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriod.FormattingEnabled = True
        Me.cmbPeriod.Items.AddRange(New Object() {"7", "15", "30"})
        Me.cmbPeriod.Location = New System.Drawing.Point(737, 45)
        Me.cmbPeriod.Name = "cmbPeriod"
        Me.cmbPeriod.Size = New System.Drawing.Size(61, 24)
        Me.cmbPeriod.TabIndex = 91
        Me.cmbPeriod.ValueMember = "id"
        '
        'chkPeriod
        '
        Me.chkPeriod.AutoSize = True
        Me.chkPeriod.Checked = True
        Me.chkPeriod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPeriod.Location = New System.Drawing.Point(620, 47)
        Me.chkPeriod.Name = "chkPeriod"
        Me.chkPeriod.Size = New System.Drawing.Size(119, 20)
        Me.chkPeriod.TabIndex = 90
        Me.chkPeriod.Text = "Invoice Period"
        Me.chkPeriod.UseVisualStyleBackColor = True
        '
        'chkDurationZero
        '
        Me.chkDurationZero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDurationZero.AutoSize = True
        Me.chkDurationZero.Checked = True
        Me.chkDurationZero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDurationZero.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDurationZero.Location = New System.Drawing.Point(1114, 27)
        Me.chkDurationZero.Name = "chkDurationZero"
        Me.chkDurationZero.Size = New System.Drawing.Size(213, 16)
        Me.chkDurationZero.TabIndex = 63
        Me.chkDurationZero.Text = "Don't send email if Total Duration = 0"
        Me.chkDurationZero.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSent)
        Me.GroupBox1.Controls.Add(Me.rbNotSent)
        Me.GroupBox1.Location = New System.Drawing.Point(92, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 38)
        Me.GroupBox1.TabIndex = 56
        Me.GroupBox1.TabStop = False
        '
        'rbSent
        '
        Me.rbSent.AutoSize = True
        Me.rbSent.Checked = True
        Me.rbSent.Enabled = False
        Me.rbSent.Location = New System.Drawing.Point(10, 13)
        Me.rbSent.Name = "rbSent"
        Me.rbSent.Size = New System.Drawing.Size(56, 20)
        Me.rbSent.TabIndex = 0
        Me.rbSent.TabStop = True
        Me.rbSent.Text = "Sent"
        Me.rbSent.UseVisualStyleBackColor = True
        '
        'rbNotSent
        '
        Me.rbNotSent.AutoSize = True
        Me.rbNotSent.Enabled = False
        Me.rbNotSent.Location = New System.Drawing.Point(136, 13)
        Me.rbNotSent.Name = "rbNotSent"
        Me.rbNotSent.Size = New System.Drawing.Size(81, 20)
        Me.rbNotSent.TabIndex = 1
        Me.rbNotSent.Text = "Not sent"
        Me.rbNotSent.UseVisualStyleBackColor = True
        '
        'chkEmail
        '
        Me.chkEmail.AutoSize = True
        Me.chkEmail.Location = New System.Drawing.Point(4, 47)
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Size = New System.Drawing.Size(66, 20)
        Me.chkEmail.TabIndex = 57
        Me.chkEmail.Text = "Emails"
        Me.chkEmail.UseVisualStyleBackColor = True
        '
        'cmbBillingDates
        '
        Me.cmbBillingDates.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbBillingDates.DisplayMember = "ID"
        Me.cmbBillingDates.DropDownHeight = 200
        Me.cmbBillingDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBillingDates.DropDownWidth = 200
        Me.cmbBillingDates.Enabled = False
        Me.cmbBillingDates.FormattingEnabled = True
        Me.cmbBillingDates.IntegralHeight = False
        Me.cmbBillingDates.Location = New System.Drawing.Point(476, 45)
        Me.cmbBillingDates.Name = "cmbBillingDates"
        Me.cmbBillingDates.Size = New System.Drawing.Size(113, 24)
        Me.cmbBillingDates.TabIndex = 55
        Me.cmbBillingDates.ValueMember = "ID"
        '
        'lblTotalDuration
        '
        Me.lblTotalDuration.AutoSize = True
        Me.lblTotalDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDuration.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalDuration.Location = New System.Drawing.Point(130, 78)
        Me.lblTotalDuration.Name = "lblTotalDuration"
        Me.lblTotalDuration.Size = New System.Drawing.Size(18, 18)
        Me.lblTotalDuration.TabIndex = 52
        Me.lblTotalDuration.Text = "0"
        Me.lblTotalDuration.Visible = False
        '
        'lblTotalCharges
        '
        Me.lblTotalCharges.AutoSize = True
        Me.lblTotalCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCharges.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalCharges.Location = New System.Drawing.Point(310, 78)
        Me.lblTotalCharges.Name = "lblTotalCharges"
        Me.lblTotalCharges.Size = New System.Drawing.Size(38, 18)
        Me.lblTotalCharges.TabIndex = 54
        Me.lblTotalCharges.Text = "0.00"
        Me.lblTotalCharges.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(208, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 16)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Total Charges:"
        Me.Label4.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 16)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Total Duration:"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(596, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 16)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "To"
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd/MMM/yyyy"
        Me.dtpTo.Enabled = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(619, 12)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(113, 23)
        Me.dtpTo.TabIndex = 49
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(476, 12)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(113, 23)
        Me.dtpFrom.TabIndex = 48
        '
        'chkPeriodDate
        '
        Me.chkPeriodDate.AutoSize = True
        Me.chkPeriodDate.Location = New System.Drawing.Point(368, 13)
        Me.chkPeriodDate.Name = "chkPeriodDate"
        Me.chkPeriodDate.Size = New System.Drawing.Size(102, 20)
        Me.chkPeriodDate.TabIndex = 47
        Me.chkPeriodDate.Text = "Period from"
        Me.chkPeriodDate.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clNo, Me.clID, Me.Column8, Me.Category, Me.Column6, Me.Column1, Me.Column2, Me.Column5, Me.Column3, Me.Column9, Me.ss, Me.Column7, Me.Column4})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridView1.Location = New System.Drawing.Point(4, 99)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1516, 369)
        Me.DataGridView1.TabIndex = 37
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(126, 26)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1371, 8)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(144, 34)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
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
        Me.cmbClientCode.Location = New System.Drawing.Point(92, 10)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(234, 24)
        Me.cmbClientCode.TabIndex = 40
        Me.cmbClientCode.ValueMember = "ID"
        '
        'chkCode
        '
        Me.chkCode.AutoSize = True
        Me.chkCode.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkCode.Location = New System.Drawing.Point(4, 12)
        Me.chkCode.Name = "chkCode"
        Me.chkCode.Size = New System.Drawing.Size(87, 21)
        Me.chkCode.TabIndex = 45
        Me.chkCode.Text = "Client ID"
        Me.chkCode.UseVisualStyleBackColor = True
        '
        'chkInsertDate
        '
        Me.chkInsertDate.AutoSize = True
        Me.chkInsertDate.Location = New System.Drawing.Point(368, 47)
        Me.chkInsertDate.Name = "chkInsertDate"
        Me.chkInsertDate.Size = New System.Drawing.Size(97, 20)
        Me.chkInsertDate.TabIndex = 46
        Me.chkInsertDate.Text = "Issue Date"
        Me.chkInsertDate.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.chkClearAll)
        Me.Panel2.Controls.Add(Me.btnSendTestEmails)
        Me.Panel2.Controls.Add(Me.btnSendEmails)
        Me.Panel2.Controls.Add(Me.chkSelectAll)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(1105, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(412, 49)
        Me.Panel2.TabIndex = 62
        '
        'chkClearAll
        '
        Me.chkClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkClearAll.AutoSize = True
        Me.chkClearAll.BackColor = System.Drawing.Color.Transparent
        Me.chkClearAll.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearAll.Location = New System.Drawing.Point(8, 27)
        Me.chkClearAll.Name = "chkClearAll"
        Me.chkClearAll.Size = New System.Drawing.Size(72, 17)
        Me.chkClearAll.TabIndex = 59
        Me.chkClearAll.Text = "Clear All"
        Me.chkClearAll.UseVisualStyleBackColor = False
        '
        'btnSendTestEmails
        '
        Me.btnSendTestEmails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendTestEmails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendTestEmails.Location = New System.Drawing.Point(263, 6)
        Me.btnSendTestEmails.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSendTestEmails.Name = "btnSendTestEmails"
        Me.btnSendTestEmails.Size = New System.Drawing.Size(144, 37)
        Me.btnSendTestEmails.TabIndex = 61
        Me.btnSendTestEmails.Tag = ""
        Me.btnSendTestEmails.Text = "Send Test Emails"
        Me.btnSendTestEmails.UseVisualStyleBackColor = True
        '
        'btnSendEmails
        '
        Me.btnSendEmails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendEmails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendEmails.Location = New System.Drawing.Point(110, 6)
        Me.btnSendEmails.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSendEmails.Name = "btnSendEmails"
        Me.btnSendEmails.Size = New System.Drawing.Size(144, 37)
        Me.btnSendEmails.TabIndex = 60
        Me.btnSendEmails.Tag = ""
        Me.btnSendEmails.Text = "Send emails to clients"
        Me.btnSendEmails.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.BackColor = System.Drawing.Color.Transparent
        Me.chkSelectAll.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSelectAll.Location = New System.Drawing.Point(8, 5)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(78, 17)
        Me.chkSelectAll.TabIndex = 58
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = False
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
        '
        'Column8
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleGoldenrod
        DataGridViewCellStyle4.NullValue = False
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column8.HeaderText = "Send Email to"
        Me.Column8.Name = "Column8"
        Me.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column8.Width = 90
        '
        'Category
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Category.DefaultCellStyle = DataGridViewCellStyle5
        Me.Category.HeaderText = "Client ID"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 130
        '
        'Column6
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column6.HeaderText = "Issue Date"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column1
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column1.HeaderText = "Total Charges"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 90
        '
        'Column2
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column2.HeaderText = "Total Duration"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'Column5
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column5.HeaderText = "Period from"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column3.HeaderText = "Period To"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column9
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column9.HeaderText = "Invoice Period"
        Me.Column9.Name = "Column9"
        '
        'ss
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ss.DefaultCellStyle = DataGridViewCellStyle12
        Me.ss.HeaderText = "Account Manager"
        Me.ss.Name = "ss"
        Me.ss.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Bank"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 200
        '
        'Column4
        '
        Me.Column4.HeaderText = "Sent Email"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmInvoices
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1528, 477)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmInvoices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Invoices"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ContextMenuStripHideColumn.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkCode As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cmbClientCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkPeriodDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkInsertDate As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStripHideColumn As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HideColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTotalCharges As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalDuration As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbBillingDates As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNotSent As System.Windows.Forms.RadioButton
    Friend WithEvents rbSent As System.Windows.Forms.RadioButton
    Friend WithEvents chkEmail As System.Windows.Forms.CheckBox
    Friend WithEvents chkClearAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSendTestEmails As System.Windows.Forms.Button
    Friend WithEvents btnSendEmails As System.Windows.Forms.Button
    Friend WithEvents chkDurationZero As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents chkPeriod As System.Windows.Forms.CheckBox
    Friend WithEvents clNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ss As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
