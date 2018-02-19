<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddClient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddClient))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbAccountManager = New System.Windows.Forms.ComboBox()
        Me.AccountManagersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAccountManagersTest = New WindowsApplication1.dsAccountManagers()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbContractMapleBank = New System.Windows.Forms.ComboBox()
        Me.cmbContractMapleName = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbPeriod = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.cmbAgreement = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dgOutboundNames = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStatement = New System.Windows.Forms.TextBox()
        Me.txtCreditLimit = New System.Windows.Forms.TextBox()
        Me.txtCCEmails = New System.Windows.Forms.TextBox()
        Me.txtABARouting = New System.Windows.Forms.TextBox()
        Me.txtSwift = New System.Windows.Forms.TextBox()
        Me.txtBeneficiaryBankAdd = New System.Windows.Forms.TextBox()
        Me.txtBeneficiaryBankName = New System.Windows.Forms.TextBox()
        Me.txtIBAN = New System.Windows.Forms.TextBox()
        Me.txtBankAccountNumber = New System.Windows.Forms.TextBox()
        Me.txtBankAccountName = New System.Windows.Forms.TextBox()
        Me.txtBillingEmail = New System.Windows.Forms.TextBox()
        Me.txtTimeZone = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.AccountManagersTableAdapter1 = New WindowsApplication1.dsAccountManagersTableAdapters.AccountManagersTableAdapter()
        Me.txtDisableReason = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AccountManagersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAccountManagersTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgOutboundNames, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 577)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmbAccountManager)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cmbContractMapleBank)
        Me.GroupBox2.Controls.Add(Me.cmbContractMapleName)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 438)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(785, 87)
        Me.GroupBox2.TabIndex = 80
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contract"
        '
        'cmbAccountManager
        '
        Me.cmbAccountManager.DataSource = Me.AccountManagersBindingSource
        Me.cmbAccountManager.DisplayMember = "Name"
        Me.cmbAccountManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccountManager.FormattingEnabled = True
        Me.cmbAccountManager.Location = New System.Drawing.Point(461, 48)
        Me.cmbAccountManager.Name = "cmbAccountManager"
        Me.cmbAccountManager.Size = New System.Drawing.Size(228, 24)
        Me.cmbAccountManager.TabIndex = 77
        Me.cmbAccountManager.ValueMember = "id"
        '
        'AccountManagersBindingSource
        '
        Me.AccountManagersBindingSource.DataMember = "AccountManagers"
        Me.AccountManagersBindingSource.DataSource = Me.DsAccountManagersTest
        '
        'DsAccountManagersTest
        '
        Me.DsAccountManagersTest.DataSetName = "dsAccountManagersTest"
        Me.DsAccountManagersTest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(458, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(123, 16)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Account Manager"
        '
        'cmbContractMapleBank
        '
        Me.cmbContractMapleBank.DisplayMember = "id"
        Me.cmbContractMapleBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbContractMapleBank.FormattingEnabled = True
        Me.cmbContractMapleBank.Location = New System.Drawing.Point(122, 55)
        Me.cmbContractMapleBank.Name = "cmbContractMapleBank"
        Me.cmbContractMapleBank.Size = New System.Drawing.Size(297, 24)
        Me.cmbContractMapleBank.TabIndex = 1
        Me.cmbContractMapleBank.ValueMember = "id"
        '
        'cmbContractMapleName
        '
        Me.cmbContractMapleName.DisplayMember = "id"
        Me.cmbContractMapleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbContractMapleName.FormattingEnabled = True
        Me.cmbContractMapleName.Location = New System.Drawing.Point(123, 24)
        Me.cmbContractMapleName.Name = "cmbContractMapleName"
        Me.cmbContractMapleName.Size = New System.Drawing.Size(297, 24)
        Me.cmbContractMapleName.TabIndex = 0
        Me.cmbContractMapleName.ValueMember = "id"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 16)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "Bank Account"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 16)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Contract With"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmbPeriod)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.cmbStatus)
        Me.GroupBox1.Controls.Add(Me.cmbAgreement)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.dgOutboundNames)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtCompanyName)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblCompanyName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAddress)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtStatement)
        Me.GroupBox1.Controls.Add(Me.txtCreditLimit)
        Me.GroupBox1.Controls.Add(Me.txtCCEmails)
        Me.GroupBox1.Controls.Add(Me.txtABARouting)
        Me.GroupBox1.Controls.Add(Me.txtSwift)
        Me.GroupBox1.Controls.Add(Me.txtBeneficiaryBankAdd)
        Me.GroupBox1.Controls.Add(Me.txtBeneficiaryBankName)
        Me.GroupBox1.Controls.Add(Me.txtIBAN)
        Me.GroupBox1.Controls.Add(Me.txtBankAccountNumber)
        Me.GroupBox1.Controls.Add(Me.txtBankAccountName)
        Me.GroupBox1.Controls.Add(Me.txtDisableReason)
        Me.GroupBox1.Controls.Add(Me.txtBillingEmail)
        Me.GroupBox1.Controls.Add(Me.txtTimeZone)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblGender)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(781, 429)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Client Info"
        '
        'cmbPeriod
        '
        Me.cmbPeriod.DisplayMember = "id"
        Me.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriod.FormattingEnabled = True
        Me.cmbPeriod.Items.AddRange(New Object() {"7", "15", "30"})
        Me.cmbPeriod.Location = New System.Drawing.Point(187, 97)
        Me.cmbPeriod.Name = "cmbPeriod"
        Me.cmbPeriod.Size = New System.Drawing.Size(97, 24)
        Me.cmbPeriod.TabIndex = 81
        Me.cmbPeriod.ValueMember = "id"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(512, 166)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 16)
        Me.Label20.TabIndex = 79
        Me.Label20.Text = "Status"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(618, 163)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(145, 24)
        Me.cmbStatus.TabIndex = 80
        '
        'cmbAgreement
        '
        Me.cmbAgreement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgreement.FormattingEnabled = True
        Me.cmbAgreement.Location = New System.Drawing.Point(618, 120)
        Me.cmbAgreement.Name = "cmbAgreement"
        Me.cmbAgreement.Size = New System.Drawing.Size(145, 24)
        Me.cmbAgreement.TabIndex = 80
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(512, 123)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 16)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "Agreement"
        '
        'dgOutboundNames
        '
        Me.dgOutboundNames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOutboundNames.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgOutboundNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOutboundNames.ColumnHeadersVisible = False
        Me.dgOutboundNames.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgOutboundNames.Location = New System.Drawing.Point(518, 281)
        Me.dgOutboundNames.Name = "dgOutboundNames"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOutboundNames.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgOutboundNames.RowHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgOutboundNames.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgOutboundNames.Size = New System.Drawing.Size(228, 134)
        Me.dgOutboundNames.TabIndex = 78
        Me.dgOutboundNames.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 150
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(513, 256)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 16)
        Me.Label17.TabIndex = 77
        Me.Label17.Text = "Outbound Names:"
        Me.Label17.Visible = False
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(187, 22)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(297, 23)
        Me.txtCompanyName.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(512, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Time Zone"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 284)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(154, 16)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "Beneficiary Bank Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 256)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 16)
        Me.Label12.TabIndex = 76
        Me.Label12.Text = "IBAN"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(150, 16)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "Bank Account Number"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 16)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Bank Account Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Address"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(618, 21)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(145, 23)
        Me.txtCode.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "CC Emails"
        '
        'lblCompanyName
        '
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Location = New System.Drawing.Point(15, 25)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(106, 16)
        Me.lblCompanyName.TabIndex = 8
        Me.lblCompanyName.Text = "Company Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Billing Email"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(187, 50)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(297, 42)
        Me.txtAddress.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(512, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Credit Limit"
        '
        'txtStatement
        '
        Me.txtStatement.Location = New System.Drawing.Point(416, 98)
        Me.txtStatement.Name = "txtStatement"
        Me.txtStatement.Size = New System.Drawing.Size(68, 23)
        Me.txtStatement.TabIndex = 5
        '
        'txtCreditLimit
        '
        Me.txtCreditLimit.Location = New System.Drawing.Point(618, 92)
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.Size = New System.Drawing.Size(145, 23)
        Me.txtCreditLimit.TabIndex = 6
        '
        'txtCCEmails
        '
        Me.txtCCEmails.Location = New System.Drawing.Point(187, 153)
        Me.txtCCEmails.Multiline = True
        Me.txtCCEmails.Name = "txtCCEmails"
        Me.txtCCEmails.Size = New System.Drawing.Size(297, 39)
        Me.txtCCEmails.TabIndex = 8
        '
        'txtABARouting
        '
        Me.txtABARouting.Location = New System.Drawing.Point(187, 366)
        Me.txtABARouting.Name = "txtABARouting"
        Me.txtABARouting.Size = New System.Drawing.Size(297, 23)
        Me.txtABARouting.TabIndex = 14
        '
        'txtSwift
        '
        Me.txtSwift.Location = New System.Drawing.Point(187, 337)
        Me.txtSwift.Name = "txtSwift"
        Me.txtSwift.Size = New System.Drawing.Size(297, 23)
        Me.txtSwift.TabIndex = 14
        '
        'txtBeneficiaryBankAdd
        '
        Me.txtBeneficiaryBankAdd.Location = New System.Drawing.Point(187, 309)
        Me.txtBeneficiaryBankAdd.Name = "txtBeneficiaryBankAdd"
        Me.txtBeneficiaryBankAdd.Size = New System.Drawing.Size(297, 23)
        Me.txtBeneficiaryBankAdd.TabIndex = 13
        '
        'txtBeneficiaryBankName
        '
        Me.txtBeneficiaryBankName.Location = New System.Drawing.Point(187, 281)
        Me.txtBeneficiaryBankName.Name = "txtBeneficiaryBankName"
        Me.txtBeneficiaryBankName.Size = New System.Drawing.Size(297, 23)
        Me.txtBeneficiaryBankName.TabIndex = 12
        '
        'txtIBAN
        '
        Me.txtIBAN.Location = New System.Drawing.Point(187, 253)
        Me.txtIBAN.Name = "txtIBAN"
        Me.txtIBAN.Size = New System.Drawing.Size(297, 23)
        Me.txtIBAN.TabIndex = 11
        '
        'txtBankAccountNumber
        '
        Me.txtBankAccountNumber.Location = New System.Drawing.Point(187, 225)
        Me.txtBankAccountNumber.Name = "txtBankAccountNumber"
        Me.txtBankAccountNumber.Size = New System.Drawing.Size(297, 23)
        Me.txtBankAccountNumber.TabIndex = 10
        '
        'txtBankAccountName
        '
        Me.txtBankAccountName.Location = New System.Drawing.Point(187, 197)
        Me.txtBankAccountName.Name = "txtBankAccountName"
        Me.txtBankAccountName.Size = New System.Drawing.Size(297, 23)
        Me.txtBankAccountName.TabIndex = 9
        '
        'txtBillingEmail
        '
        Me.txtBillingEmail.Location = New System.Drawing.Point(187, 125)
        Me.txtBillingEmail.Name = "txtBillingEmail"
        Me.txtBillingEmail.Size = New System.Drawing.Size(297, 23)
        Me.txtBillingEmail.TabIndex = 7
        '
        'txtTimeZone
        '
        Me.txtTimeZone.Location = New System.Drawing.Point(618, 50)
        Me.txtTimeZone.Name = "txtTimeZone"
        Me.txtTimeZone.Size = New System.Drawing.Size(145, 23)
        Me.txtTimeZone.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(15, 369)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(118, 16)
        Me.Label19.TabIndex = 76
        Me.Label19.Text = "ABA/Routing No."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(337, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Settelment"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 340)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 16)
        Me.Label15.TabIndex = 76
        Me.Label15.Text = "SWIFT Address"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(15, 101)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(100, 16)
        Me.lblGender.TabIndex = 76
        Me.lblGender.Text = "Invoice Period"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 312)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(173, 16)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Beneficiary Bank Address"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(512, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Company ID"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Location = New System.Drawing.Point(269, 537)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(254, 35)
        Me.Panel2.TabIndex = 78
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
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(44, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 31)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
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
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'AccountManagersTableAdapter1
        '
        Me.AccountManagersTableAdapter1.ClearBeforeFill = True
        '
        'txtDisableReason
        '
        Me.txtDisableReason.Location = New System.Drawing.Point(618, 194)
        Me.txtDisableReason.Multiline = True
        Me.txtDisableReason.Name = "txtDisableReason"
        Me.txtDisableReason.Size = New System.Drawing.Size(145, 55)
        Me.txtDisableReason.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(512, 193)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(106, 16)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Disable Reason"
        '
        'frmAddClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(798, 579)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmAddClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Client"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.AccountManagersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAccountManagersTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgOutboundNames, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtTimeZone As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbContractMapleBank As System.Windows.Forms.ComboBox
    Friend WithEvents cmbContractMapleName As System.Windows.Forms.ComboBox
    Friend WithEvents txtStatement As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditLimit As System.Windows.Forms.TextBox
    Friend WithEvents txtCCEmails As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
    Friend WithEvents txtBillingEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSwift As System.Windows.Forms.TextBox
    Friend WithEvents txtBeneficiaryBankAdd As System.Windows.Forms.TextBox
    Friend WithEvents txtBeneficiaryBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtIBAN As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbAccountManager As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DsAccountManagers As Global.WindowsApplication1.dsAccountManagers
    Friend WithEvents AccountManagersTableAdapter As Global.WindowsApplication1.dsAccountManagersTableAdapters.AccountManagersTableAdapter
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgOutboundNames As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbAgreement As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtABARouting As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents DsAccountManagersTest As WindowsApplication1.dsAccountManagers
    Friend WithEvents AccountManagersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountManagersTableAdapter1 As dsAccountManagersTableAdapters.AccountManagersTableAdapter
    Friend WithEvents cmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtDisableReason As System.Windows.Forms.TextBox
End Class
