﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBilling
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBilling))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbPeriod = New System.Windows.Forms.ComboBox()
        Me.chkPeriod = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbInBound = New System.Windows.Forms.RadioButton()
        Me.rbOutbound = New System.Windows.Forms.RadioButton()
        Me.btnWeeklyReport = New System.Windows.Forms.Button()
        Me.cmbBillingDates = New System.Windows.Forms.ComboBox()
        Me.lblTotalDurationNoMaple = New System.Windows.Forms.Label()
        Me.lblTotalDuration = New System.Windows.Forms.Label()
        Me.lblTotalChargesNoMaple = New System.Windows.Forms.Label()
        Me.lblTotalCharges = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.chkPeriodDate = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGenerateInvoices = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.cmbSoftware = New System.Windows.Forms.ComboBox()
        Me.chkCode = New System.Windows.Forms.CheckBox()
        Me.chkInsertDate = New System.Windows.Forms.CheckBox()
        Me.chkSoftware = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStripHideColumn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnWeeklyReport)
        Me.Panel1.Controls.Add(Me.cmbBillingDates)
        Me.Panel1.Controls.Add(Me.lblTotalDurationNoMaple)
        Me.Panel1.Controls.Add(Me.lblTotalDuration)
        Me.Panel1.Controls.Add(Me.lblTotalChargesNoMaple)
        Me.Panel1.Controls.Add(Me.lblTotalCharges)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.chkPeriodDate)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnGenerateInvoices)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.cmbClientCode)
        Me.Panel1.Controls.Add(Me.cmbSoftware)
        Me.Panel1.Controls.Add(Me.chkCode)
        Me.Panel1.Controls.Add(Me.chkInsertDate)
        Me.Panel1.Controls.Add(Me.chkSoftware)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1411, 711)
        Me.Panel1.TabIndex = 0
        '
        'cmbPeriod
        '
        Me.cmbPeriod.DisplayMember = "id"
        Me.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriod.FormattingEnabled = True
        Me.cmbPeriod.Items.AddRange(New Object() {"7", "15", "30"})
        Me.cmbPeriod.Location = New System.Drawing.Point(711, 42)
        Me.cmbPeriod.Name = "cmbPeriod"
        Me.cmbPeriod.Size = New System.Drawing.Size(61, 24)
        Me.cmbPeriod.TabIndex = 89
        Me.cmbPeriod.ValueMember = "id"
        '
        'chkPeriod
        '
        Me.chkPeriod.AutoSize = True
        Me.chkPeriod.Checked = True
        Me.chkPeriod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPeriod.Location = New System.Drawing.Point(594, 44)
        Me.chkPeriod.Name = "chkPeriod"
        Me.chkPeriod.Size = New System.Drawing.Size(119, 20)
        Me.chkPeriod.TabIndex = 88
        Me.chkPeriod.Text = "Invoice Period"
        Me.chkPeriod.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbInBound)
        Me.GroupBox1.Controls.Add(Me.rbOutbound)
        Me.GroupBox1.Location = New System.Drawing.Point(826, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 38)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        '
        'rbInBound
        '
        Me.rbInBound.AutoSize = True
        Me.rbInBound.Checked = True
        Me.rbInBound.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbInBound.Location = New System.Drawing.Point(10, 13)
        Me.rbInBound.Name = "rbInBound"
        Me.rbInBound.Size = New System.Drawing.Size(87, 22)
        Me.rbInBound.TabIndex = 0
        Me.rbInBound.TabStop = True
        Me.rbInBound.Text = "Inbound"
        Me.rbInBound.UseVisualStyleBackColor = True
        '
        'rbOutbound
        '
        Me.rbOutbound.AutoSize = True
        Me.rbOutbound.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOutbound.Location = New System.Drawing.Point(143, 13)
        Me.rbOutbound.Name = "rbOutbound"
        Me.rbOutbound.Size = New System.Drawing.Size(98, 22)
        Me.rbOutbound.TabIndex = 1
        Me.rbOutbound.Text = "Outbound"
        Me.rbOutbound.UseVisualStyleBackColor = True
        '
        'btnWeeklyReport
        '
        Me.btnWeeklyReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWeeklyReport.Enabled = False
        Me.btnWeeklyReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWeeklyReport.Location = New System.Drawing.Point(1267, 55)
        Me.btnWeeklyReport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnWeeklyReport.Name = "btnWeeklyReport"
        Me.btnWeeklyReport.Size = New System.Drawing.Size(132, 45)
        Me.btnWeeklyReport.TabIndex = 56
        Me.btnWeeklyReport.Tag = ""
        Me.btnWeeklyReport.Text = "Weekly Report"
        Me.btnWeeklyReport.UseVisualStyleBackColor = True
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
        Me.cmbBillingDates.Location = New System.Drawing.Point(450, 42)
        Me.cmbBillingDates.Name = "cmbBillingDates"
        Me.cmbBillingDates.Size = New System.Drawing.Size(113, 24)
        Me.cmbBillingDates.TabIndex = 55
        Me.cmbBillingDates.ValueMember = "ID"
        '
        'lblTotalDurationNoMaple
        '
        Me.lblTotalDurationNoMaple.AutoSize = True
        Me.lblTotalDurationNoMaple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDurationNoMaple.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalDurationNoMaple.Location = New System.Drawing.Point(255, 118)
        Me.lblTotalDurationNoMaple.Name = "lblTotalDurationNoMaple"
        Me.lblTotalDurationNoMaple.Size = New System.Drawing.Size(78, 18)
        Me.lblTotalDurationNoMaple.TabIndex = 52
        Me.lblTotalDurationNoMaple.Text = "0.0000000"
        '
        'lblTotalDuration
        '
        Me.lblTotalDuration.AutoSize = True
        Me.lblTotalDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDuration.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalDuration.Location = New System.Drawing.Point(113, 85)
        Me.lblTotalDuration.Name = "lblTotalDuration"
        Me.lblTotalDuration.Size = New System.Drawing.Size(78, 18)
        Me.lblTotalDuration.TabIndex = 52
        Me.lblTotalDuration.Text = "0.0000000"
        '
        'lblTotalChargesNoMaple
        '
        Me.lblTotalChargesNoMaple.AutoSize = True
        Me.lblTotalChargesNoMaple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalChargesNoMaple.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalChargesNoMaple.Location = New System.Drawing.Point(628, 119)
        Me.lblTotalChargesNoMaple.Name = "lblTotalChargesNoMaple"
        Me.lblTotalChargesNoMaple.Size = New System.Drawing.Size(38, 18)
        Me.lblTotalChargesNoMaple.TabIndex = 54
        Me.lblTotalChargesNoMaple.Text = "0.00"
        '
        'lblTotalCharges
        '
        Me.lblTotalCharges.AutoSize = True
        Me.lblTotalCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCharges.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalCharges.Location = New System.Drawing.Point(488, 86)
        Me.lblTotalCharges.Name = "lblTotalCharges"
        Me.lblTotalCharges.Size = New System.Drawing.Size(38, 18)
        Me.lblTotalCharges.TabIndex = 54
        Me.lblTotalCharges.Text = "0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(386, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(244, 16)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Total Charges without Maple clients:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(386, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 16)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Total Charges:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(247, 16)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Total Duration without Maple clients:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 16)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Total Duration:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(570, 15)
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
        Me.dtpTo.Location = New System.Drawing.Point(593, 12)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(113, 23)
        Me.dtpTo.TabIndex = 49
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(450, 12)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(113, 23)
        Me.dtpFrom.TabIndex = 48
        '
        'chkPeriodDate
        '
        Me.chkPeriodDate.AutoSize = True
        Me.chkPeriodDate.Location = New System.Drawing.Point(342, 13)
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clID, Me.clNo, Me.Column7, Me.Category, Me.clEmail, Me.clGender, Me.Column1, Me.Column2, Me.Column5, Me.Column3, Me.Column4, Me.Column6, Me.Column8})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridView1.Location = New System.Drawing.Point(-4, 152)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1403, 555)
        Me.DataGridView1.TabIndex = 37
        '
        'clID
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clID.DefaultCellStyle = DataGridViewCellStyle2
        Me.clID.HeaderText = "ID"
        Me.clID.Name = "clID"
        Me.clID.ReadOnly = True
        Me.clID.Visible = False
        '
        'clNo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.clNo.HeaderText = "No."
        Me.clNo.Name = "clNo"
        Me.clNo.ReadOnly = True
        Me.clNo.Width = 40
        '
        'Column7
        '
        Me.Column7.HeaderText = "Found in Database"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column7.Width = 80
        '
        'Category
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Category.DefaultCellStyle = DataGridViewCellStyle4
        Me.Category.HeaderText = "Client ID"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 130
        '
        'clEmail
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clEmail.DefaultCellStyle = DataGridViewCellStyle5
        Me.clEmail.HeaderText = "Area Name"
        Me.clEmail.Name = "clEmail"
        Me.clEmail.ReadOnly = True
        Me.clEmail.Width = 190
        '
        'clGender
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clGender.DefaultCellStyle = DataGridViewCellStyle6
        Me.clGender.HeaderText = "Area Code"
        Me.clGender.Name = "clGender"
        Me.clGender.ReadOnly = True
        Me.clGender.Width = 130
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
        'Column4
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column4.HeaderText = "Imported From"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 150
        '
        'Column6
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle12
        Me.Column6.HeaderText = "Imported Date"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 150
        '
        'Column8
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle13
        Me.Column8.HeaderText = "Invoice Period"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
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
        'btnGenerateInvoices
        '
        Me.btnGenerateInvoices.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateInvoices.Enabled = False
        Me.btnGenerateInvoices.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnGenerateInvoices.Location = New System.Drawing.Point(1119, 55)
        Me.btnGenerateInvoices.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerateInvoices.Name = "btnGenerateInvoices"
        Me.btnGenerateInvoices.Size = New System.Drawing.Size(141, 45)
        Me.btnGenerateInvoices.TabIndex = 36
        Me.btnGenerateInvoices.Text = "Generate Invoices (Excel files)"
        Me.btnGenerateInvoices.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1119, 8)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(280, 38)
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
        Me.cmbClientCode.Location = New System.Drawing.Point(92, 10)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(234, 24)
        Me.cmbClientCode.TabIndex = 40
        Me.cmbClientCode.ValueMember = "ID"
        '
        'cmbSoftware
        '
        Me.cmbSoftware.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbSoftware.DisplayMember = "ID"
        Me.cmbSoftware.DropDownHeight = 200
        Me.cmbSoftware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSoftware.DropDownWidth = 200
        Me.cmbSoftware.Enabled = False
        Me.cmbSoftware.FormattingEnabled = True
        Me.cmbSoftware.IntegralHeight = False
        Me.cmbSoftware.Location = New System.Drawing.Point(92, 42)
        Me.cmbSoftware.Name = "cmbSoftware"
        Me.cmbSoftware.Size = New System.Drawing.Size(234, 24)
        Me.cmbSoftware.TabIndex = 40
        Me.cmbSoftware.ValueMember = "ID"
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
        Me.chkInsertDate.Checked = True
        Me.chkInsertDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInsertDate.Location = New System.Drawing.Point(342, 44)
        Me.chkInsertDate.Name = "chkInsertDate"
        Me.chkInsertDate.Size = New System.Drawing.Size(106, 20)
        Me.chkInsertDate.TabIndex = 46
        Me.chkInsertDate.Text = "Import Date"
        Me.chkInsertDate.UseVisualStyleBackColor = True
        '
        'chkSoftware
        '
        Me.chkSoftware.AutoSize = True
        Me.chkSoftware.Location = New System.Drawing.Point(3, 44)
        Me.chkSoftware.Name = "chkSoftware"
        Me.chkSoftware.Size = New System.Drawing.Size(87, 20)
        Me.chkSoftware.TabIndex = 46
        Me.chkSoftware.Text = "Software"
        Me.chkSoftware.UseVisualStyleBackColor = True
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
        'frmBilling
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1415, 709)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmBilling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imported Data (Billing)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
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
    Friend WithEvents cmbSoftware As System.Windows.Forms.ComboBox
    Friend WithEvents chkSoftware As System.Windows.Forms.CheckBox
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
    Friend WithEvents btnGenerateInvoices As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbBillingDates As System.Windows.Forms.ComboBox
    Friend WithEvents btnWeeklyReport As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbInBound As System.Windows.Forms.RadioButton
    Friend WithEvents rbOutbound As System.Windows.Forms.RadioButton
    Friend WithEvents cmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents chkPeriod As System.Windows.Forms.CheckBox
    Friend WithEvents lblTotalDurationNoMaple As System.Windows.Forms.Label
    Friend WithEvents lblTotalChargesNoMaple As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents clID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
