<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddUser))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmbAcountManagerAdd = New System.Windows.Forms.ComboBox()
        Me.AccountManagersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAccountManagers = New WindowsApplication1.dsAccountManagers()
        Me.rbAccountManagerAdd = New System.Windows.Forms.RadioButton()
        Me.rbAdminAdd = New System.Windows.Forms.RadioButton()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.txtAddUserName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAddPassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAddPasswrod2 = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbAccountManagersEdit = New System.Windows.Forms.ComboBox()
        Me.rbAccountManagerEdit = New System.Windows.Forms.RadioButton()
        Me.rbAdminEdit = New System.Windows.Forms.RadioButton()
        Me.btnDeleteUser = New System.Windows.Forms.Button()
        Me.btnEditUser = New System.Windows.Forms.Button()
        Me.cmbEditUserName = New System.Windows.Forms.ComboBox()
        Me.UsersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsUser = New WindowsApplication1.dsUser()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEditPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEditUserName = New System.Windows.Forms.TextBox()
        Me.txtEditPassword2 = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkImportRates = New System.Windows.Forms.CheckBox()
        Me.chkEditNonCLI = New System.Windows.Forms.CheckBox()
        Me.chkViewRatesReports = New System.Windows.Forms.CheckBox()
        Me.chkAddUsers = New System.Windows.Forms.CheckBox()
        Me.Accounting = New System.Windows.Forms.GroupBox()
        Me.chkPurchases = New System.Windows.Forms.CheckBox()
        Me.chkViewVouchers = New System.Windows.Forms.CheckBox()
        Me.chkViewPayments = New System.Windows.Forms.CheckBox()
        Me.chkTransactions = New System.Windows.Forms.CheckBox()
        Me.chkManagerRecievedAmount = New System.Windows.Forms.CheckBox()
        Me.chkBeginingBalances = New System.Windows.Forms.CheckBox()
        Me.chkMangePayments = New System.Windows.Forms.CheckBox()
        Me.chkManageVouchers = New System.Windows.Forms.CheckBox()
        Me.chkStatementofAccount = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkCashflowReport = New System.Windows.Forms.CheckBox()
        Me.chkClientPerformanceReport = New System.Windows.Forms.CheckBox()
        Me.chkGenerateInvoices = New System.Windows.Forms.CheckBox()
        Me.chkViewInvoices = New System.Windows.Forms.CheckBox()
        Me.chkSendEmails = New System.Windows.Forms.CheckBox()
        Me.chkCompanyPerformanceReport = New System.Windows.Forms.CheckBox()
        Me.chkImportInvoices = New System.Windows.Forms.CheckBox()
        Me.chkGenerateWeeklyReport = New System.Windows.Forms.CheckBox()
        Me.chkViewInsertedBilling = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkEditClients = New System.Windows.Forms.CheckBox()
        Me.chkEditEmailBody = New System.Windows.Forms.CheckBox()
        Me.chkEditMapleAccounts = New System.Windows.Forms.CheckBox()
        Me.chkManageCompanies = New System.Windows.Forms.CheckBox()
        Me.chkEditSoftwares = New System.Windows.Forms.CheckBox()
        Me.chkEditAccountManager = New System.Windows.Forms.CheckBox()
        Me.chkEditBankAccounts = New System.Windows.Forms.CheckBox()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.chkClearAll = New System.Windows.Forms.CheckBox()
        Me.UsersTableAdapter = New WindowsApplication1.dsUserTableAdapters.UsersTableAdapter()
        Me.AccountManagersTableAdapter = New WindowsApplication1.dsAccountManagersTableAdapters.AccountManagersTableAdapter()
        Me.chbEditProviderPrice = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.AccountManagersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAccountManagers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Accounting.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(680, 150)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.cmbAcountManagerAdd)
        Me.TabPage1.Controls.Add(Me.rbAccountManagerAdd)
        Me.TabPage1.Controls.Add(Me.rbAdminAdd)
        Me.TabPage1.Controls.Add(Me.btnAddUser)
        Me.TabPage1.Controls.Add(Me.txtAddUserName)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtAddPassword)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtAddPasswrod2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(672, 121)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Add User"
        '
        'cmbAcountManagerAdd
        '
        Me.cmbAcountManagerAdd.DataSource = Me.AccountManagersBindingSource
        Me.cmbAcountManagerAdd.DisplayMember = "Name"
        Me.cmbAcountManagerAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAcountManagerAdd.Enabled = False
        Me.cmbAcountManagerAdd.FormattingEnabled = True
        Me.cmbAcountManagerAdd.Location = New System.Drawing.Point(237, 87)
        Me.cmbAcountManagerAdd.Name = "cmbAcountManagerAdd"
        Me.cmbAcountManagerAdd.Size = New System.Drawing.Size(152, 24)
        Me.cmbAcountManagerAdd.TabIndex = 31
        Me.cmbAcountManagerAdd.ValueMember = "ID"
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
        'rbAccountManagerAdd
        '
        Me.rbAccountManagerAdd.AutoSize = True
        Me.rbAccountManagerAdd.Location = New System.Drawing.Point(90, 89)
        Me.rbAccountManagerAdd.Name = "rbAccountManagerAdd"
        Me.rbAccountManagerAdd.Size = New System.Drawing.Size(141, 20)
        Me.rbAccountManagerAdd.TabIndex = 27
        Me.rbAccountManagerAdd.TabStop = True
        Me.rbAccountManagerAdd.Text = "Account Manager"
        Me.rbAccountManagerAdd.UseVisualStyleBackColor = True
        '
        'rbAdminAdd
        '
        Me.rbAdminAdd.AutoSize = True
        Me.rbAdminAdd.Location = New System.Drawing.Point(7, 89)
        Me.rbAdminAdd.Name = "rbAdminAdd"
        Me.rbAdminAdd.Size = New System.Drawing.Size(66, 20)
        Me.rbAdminAdd.TabIndex = 26
        Me.rbAdminAdd.TabStop = True
        Me.rbAdminAdd.Text = "Admin"
        Me.rbAdminAdd.UseVisualStyleBackColor = True
        '
        'btnAddUser
        '
        Me.btnAddUser.Location = New System.Drawing.Point(563, 85)
        Me.btnAddUser.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(74, 28)
        Me.btnAddUser.TabIndex = 24
        Me.btnAddUser.Text = "Save"
        Me.btnAddUser.UseVisualStyleBackColor = True
        '
        'txtAddUserName
        '
        Me.txtAddUserName.Location = New System.Drawing.Point(78, 18)
        Me.txtAddUserName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddUserName.Name = "txtAddUserName"
        Me.txtAddUserName.Size = New System.Drawing.Size(151, 23)
        Me.txtAddUserName.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "User Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 50)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Password"
        '
        'txtAddPassword
        '
        Me.txtAddPassword.Location = New System.Drawing.Point(78, 47)
        Me.txtAddPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddPassword.Name = "txtAddPassword"
        Me.txtAddPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAddPassword.Size = New System.Drawing.Size(151, 23)
        Me.txtAddPassword.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(371, 43)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Re-Enter Password"
        '
        'txtAddPasswrod2
        '
        Me.txtAddPasswrod2.Location = New System.Drawing.Point(508, 40)
        Me.txtAddPasswrod2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddPasswrod2.Name = "txtAddPasswrod2"
        Me.txtAddPasswrod2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAddPasswrod2.Size = New System.Drawing.Size(129, 23)
        Me.txtAddPasswrod2.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Controls.Add(Me.cmbAccountManagersEdit)
        Me.TabPage2.Controls.Add(Me.rbAccountManagerEdit)
        Me.TabPage2.Controls.Add(Me.rbAdminEdit)
        Me.TabPage2.Controls.Add(Me.btnDeleteUser)
        Me.TabPage2.Controls.Add(Me.btnEditUser)
        Me.TabPage2.Controls.Add(Me.cmbEditUserName)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtEditPassword)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtEditUserName)
        Me.TabPage2.Controls.Add(Me.txtEditPassword2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(672, 121)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit User"
        '
        'cmbAccountManagersEdit
        '
        Me.cmbAccountManagersEdit.DataSource = Me.AccountManagersBindingSource
        Me.cmbAccountManagersEdit.DisplayMember = "Name"
        Me.cmbAccountManagersEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccountManagersEdit.Enabled = False
        Me.cmbAccountManagersEdit.FormattingEnabled = True
        Me.cmbAccountManagersEdit.Location = New System.Drawing.Point(237, 87)
        Me.cmbAccountManagersEdit.Name = "cmbAccountManagersEdit"
        Me.cmbAccountManagersEdit.Size = New System.Drawing.Size(152, 24)
        Me.cmbAccountManagersEdit.TabIndex = 30
        Me.cmbAccountManagersEdit.ValueMember = "ID"
        '
        'rbAccountManagerEdit
        '
        Me.rbAccountManagerEdit.AutoSize = True
        Me.rbAccountManagerEdit.Location = New System.Drawing.Point(90, 89)
        Me.rbAccountManagerEdit.Name = "rbAccountManagerEdit"
        Me.rbAccountManagerEdit.Size = New System.Drawing.Size(141, 20)
        Me.rbAccountManagerEdit.TabIndex = 29
        Me.rbAccountManagerEdit.TabStop = True
        Me.rbAccountManagerEdit.Text = "Account Manager"
        Me.rbAccountManagerEdit.UseVisualStyleBackColor = True
        '
        'rbAdminEdit
        '
        Me.rbAdminEdit.AutoSize = True
        Me.rbAdminEdit.Location = New System.Drawing.Point(7, 89)
        Me.rbAdminEdit.Name = "rbAdminEdit"
        Me.rbAdminEdit.Size = New System.Drawing.Size(66, 20)
        Me.rbAdminEdit.TabIndex = 28
        Me.rbAdminEdit.TabStop = True
        Me.rbAdminEdit.Text = "Admin"
        Me.rbAdminEdit.UseVisualStyleBackColor = True
        '
        'btnDeleteUser
        '
        Me.btnDeleteUser.Location = New System.Drawing.Point(537, 85)
        Me.btnDeleteUser.Name = "btnDeleteUser"
        Me.btnDeleteUser.Size = New System.Drawing.Size(102, 28)
        Me.btnDeleteUser.TabIndex = 18
        Me.btnDeleteUser.Text = "Delete User"
        Me.btnDeleteUser.UseVisualStyleBackColor = True
        '
        'btnEditUser
        '
        Me.btnEditUser.Location = New System.Drawing.Point(450, 85)
        Me.btnEditUser.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditUser.Name = "btnEditUser"
        Me.btnEditUser.Size = New System.Drawing.Size(82, 28)
        Me.btnEditUser.TabIndex = 16
        Me.btnEditUser.Text = "Save"
        Me.btnEditUser.UseVisualStyleBackColor = True
        '
        'cmbEditUserName
        '
        Me.cmbEditUserName.DataSource = Me.UsersBindingSource
        Me.cmbEditUserName.DisplayMember = "Username"
        Me.cmbEditUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEditUserName.FormattingEnabled = True
        Me.cmbEditUserName.Location = New System.Drawing.Point(76, 10)
        Me.cmbEditUserName.Name = "cmbEditUserName"
        Me.cmbEditUserName.Size = New System.Drawing.Size(152, 24)
        Me.cmbEditUserName.TabIndex = 0
        Me.cmbEditUserName.ValueMember = "ID"
        '
        'UsersBindingSource
        '
        Me.UsersBindingSource.DataMember = "Users"
        Me.UsersBindingSource.DataSource = Me.DsUser
        '
        'DsUser
        '
        Me.DsUser.DataSetName = "dsUser"
        Me.DsUser.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(426, 13)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "User Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 13)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "User Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Password"
        '
        'txtEditPassword
        '
        Me.txtEditPassword.Location = New System.Drawing.Point(76, 40)
        Me.txtEditPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEditPassword.Name = "txtEditPassword"
        Me.txtEditPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEditPassword.Size = New System.Drawing.Size(152, 23)
        Me.txtEditPassword.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(370, 43)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Re-Enter Password"
        '
        'txtEditUserName
        '
        Me.txtEditUserName.Location = New System.Drawing.Point(507, 10)
        Me.txtEditUserName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEditUserName.Name = "txtEditUserName"
        Me.txtEditUserName.Size = New System.Drawing.Size(130, 23)
        Me.txtEditUserName.TabIndex = 0
        '
        'txtEditPassword2
        '
        Me.txtEditPassword2.Location = New System.Drawing.Point(507, 40)
        Me.txtEditPassword2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEditPassword2.Name = "txtEditPassword2"
        Me.txtEditPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEditPassword2.Size = New System.Drawing.Size(130, 23)
        Me.txtEditPassword2.TabIndex = 2
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Permissions:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkImportRates)
        Me.GroupBox4.Controls.Add(Me.chbEditProviderPrice)
        Me.GroupBox4.Controls.Add(Me.chkEditNonCLI)
        Me.GroupBox4.Controls.Add(Me.chkViewRatesReports)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 393)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(211, 104)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Rating"
        '
        'chkImportRates
        '
        Me.chkImportRates.AutoSize = True
        Me.chkImportRates.Location = New System.Drawing.Point(6, 19)
        Me.chkImportRates.Name = "chkImportRates"
        Me.chkImportRates.Size = New System.Drawing.Size(113, 20)
        Me.chkImportRates.TabIndex = 17
        Me.chkImportRates.Text = "Import Rates"
        Me.chkImportRates.UseVisualStyleBackColor = True
        '
        'chkEditNonCLI
        '
        Me.chkEditNonCLI.AutoSize = True
        Me.chkEditNonCLI.Location = New System.Drawing.Point(6, 61)
        Me.chkEditNonCLI.Name = "chkEditNonCLI"
        Me.chkEditNonCLI.Size = New System.Drawing.Size(139, 20)
        Me.chkEditNonCLI.TabIndex = 14
        Me.chkEditNonCLI.Text = "Edit Non-CLI type"
        Me.chkEditNonCLI.UseVisualStyleBackColor = True
        '
        'chkViewRatesReports
        '
        Me.chkViewRatesReports.AutoSize = True
        Me.chkViewRatesReports.Location = New System.Drawing.Point(6, 40)
        Me.chkViewRatesReports.Name = "chkViewRatesReports"
        Me.chkViewRatesReports.Size = New System.Drawing.Size(156, 20)
        Me.chkViewRatesReports.TabIndex = 21
        Me.chkViewRatesReports.Text = "View Rates Reports"
        Me.chkViewRatesReports.UseVisualStyleBackColor = True
        '
        'chkAddUsers
        '
        Me.chkAddUsers.AutoSize = True
        Me.chkAddUsers.Location = New System.Drawing.Point(5, 169)
        Me.chkAddUsers.Name = "chkAddUsers"
        Me.chkAddUsers.Size = New System.Drawing.Size(53, 17)
        Me.chkAddUsers.TabIndex = 23
        Me.chkAddUsers.Text = "Users"
        Me.chkAddUsers.UseVisualStyleBackColor = True
        '
        'Accounting
        '
        Me.Accounting.Controls.Add(Me.chkPurchases)
        Me.Accounting.Controls.Add(Me.chkViewVouchers)
        Me.Accounting.Controls.Add(Me.chkViewPayments)
        Me.Accounting.Controls.Add(Me.chkTransactions)
        Me.Accounting.Controls.Add(Me.chkManagerRecievedAmount)
        Me.Accounting.Controls.Add(Me.chkBeginingBalances)
        Me.Accounting.Controls.Add(Me.chkMangePayments)
        Me.Accounting.Controls.Add(Me.chkManageVouchers)
        Me.Accounting.Controls.Add(Me.chkStatementofAccount)
        Me.Accounting.Location = New System.Drawing.Point(466, 187)
        Me.Accounting.Margin = New System.Windows.Forms.Padding(1)
        Me.Accounting.Name = "Accounting"
        Me.Accounting.Padding = New System.Windows.Forms.Padding(2)
        Me.Accounting.Size = New System.Drawing.Size(212, 310)
        Me.Accounting.TabIndex = 30
        Me.Accounting.TabStop = False
        Me.Accounting.Text = "Accounting"
        '
        'chkPurchases
        '
        Me.chkPurchases.AutoSize = True
        Me.chkPurchases.Location = New System.Drawing.Point(4, 195)
        Me.chkPurchases.Name = "chkPurchases"
        Me.chkPurchases.Size = New System.Drawing.Size(129, 20)
        Me.chkPurchases.TabIndex = 13
        Me.chkPurchases.Text = "View Purchases"
        Me.chkPurchases.UseVisualStyleBackColor = True
        '
        'chkViewVouchers
        '
        Me.chkViewVouchers.AutoSize = True
        Me.chkViewVouchers.Location = New System.Drawing.Point(4, 173)
        Me.chkViewVouchers.Name = "chkViewVouchers"
        Me.chkViewVouchers.Size = New System.Drawing.Size(123, 20)
        Me.chkViewVouchers.TabIndex = 13
        Me.chkViewVouchers.Text = "View Vouchers"
        Me.chkViewVouchers.UseVisualStyleBackColor = True
        '
        'chkViewPayments
        '
        Me.chkViewPayments.AutoSize = True
        Me.chkViewPayments.Location = New System.Drawing.Point(4, 151)
        Me.chkViewPayments.Name = "chkViewPayments"
        Me.chkViewPayments.Size = New System.Drawing.Size(126, 20)
        Me.chkViewPayments.TabIndex = 13
        Me.chkViewPayments.Text = "View Payments"
        Me.chkViewPayments.UseVisualStyleBackColor = True
        '
        'chkTransactions
        '
        Me.chkTransactions.AutoSize = True
        Me.chkTransactions.Location = New System.Drawing.Point(4, 128)
        Me.chkTransactions.Name = "chkTransactions"
        Me.chkTransactions.Size = New System.Drawing.Size(185, 20)
        Me.chkTransactions.TabIndex = 13
        Me.chkTransactions.Text = "View Client Transactions"
        Me.chkTransactions.UseVisualStyleBackColor = True
        '
        'chkManagerRecievedAmount
        '
        Me.chkManagerRecievedAmount.AutoSize = True
        Me.chkManagerRecievedAmount.Location = New System.Drawing.Point(4, 41)
        Me.chkManagerRecievedAmount.Name = "chkManagerRecievedAmount"
        Me.chkManagerRecievedAmount.Size = New System.Drawing.Size(203, 20)
        Me.chkManagerRecievedAmount.TabIndex = 14
        Me.chkManagerRecievedAmount.Text = "Add/Edit Recieved Amount"
        Me.chkManagerRecievedAmount.UseVisualStyleBackColor = True
        '
        'chkBeginingBalances
        '
        Me.chkBeginingBalances.AutoSize = True
        Me.chkBeginingBalances.Location = New System.Drawing.Point(4, 85)
        Me.chkBeginingBalances.Name = "chkBeginingBalances"
        Me.chkBeginingBalances.Size = New System.Drawing.Size(197, 20)
        Me.chkBeginingBalances.TabIndex = 13
        Me.chkBeginingBalances.Text = "Manage Begining Balances"
        Me.chkBeginingBalances.UseVisualStyleBackColor = True
        '
        'chkMangePayments
        '
        Me.chkMangePayments.AutoSize = True
        Me.chkMangePayments.Location = New System.Drawing.Point(4, 19)
        Me.chkMangePayments.Name = "chkMangePayments"
        Me.chkMangePayments.Size = New System.Drawing.Size(153, 20)
        Me.chkMangePayments.TabIndex = 13
        Me.chkMangePayments.Text = "Add/Edit Payments"
        Me.chkMangePayments.UseVisualStyleBackColor = True
        '
        'chkManageVouchers
        '
        Me.chkManageVouchers.AutoSize = True
        Me.chkManageVouchers.Location = New System.Drawing.Point(4, 63)
        Me.chkManageVouchers.Name = "chkManageVouchers"
        Me.chkManageVouchers.Size = New System.Drawing.Size(150, 20)
        Me.chkManageVouchers.TabIndex = 13
        Me.chkManageVouchers.Text = "Add/Edit Vouchers"
        Me.chkManageVouchers.UseVisualStyleBackColor = True
        '
        'chkStatementofAccount
        '
        Me.chkStatementofAccount.AutoSize = True
        Me.chkStatementofAccount.Location = New System.Drawing.Point(4, 107)
        Me.chkStatementofAccount.Name = "chkStatementofAccount"
        Me.chkStatementofAccount.Size = New System.Drawing.Size(171, 20)
        Me.chkStatementofAccount.TabIndex = 13
        Me.chkStatementofAccount.Text = "Statement of Account"
        Me.chkStatementofAccount.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCashflowReport)
        Me.GroupBox2.Controls.Add(Me.chkClientPerformanceReport)
        Me.GroupBox2.Controls.Add(Me.chkGenerateInvoices)
        Me.GroupBox2.Controls.Add(Me.chkViewInvoices)
        Me.GroupBox2.Controls.Add(Me.chkSendEmails)
        Me.GroupBox2.Controls.Add(Me.chkCompanyPerformanceReport)
        Me.GroupBox2.Controls.Add(Me.chkImportInvoices)
        Me.GroupBox2.Controls.Add(Me.chkGenerateWeeklyReport)
        Me.GroupBox2.Controls.Add(Me.chkViewInsertedBilling)
        Me.GroupBox2.Location = New System.Drawing.Point(228, 188)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(232, 309)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Invoicing"
        '
        'chkCashflowReport
        '
        Me.chkCashflowReport.AutoSize = True
        Me.chkCashflowReport.Location = New System.Drawing.Point(6, 187)
        Me.chkCashflowReport.Name = "chkCashflowReport"
        Me.chkCashflowReport.Size = New System.Drawing.Size(134, 20)
        Me.chkCashflowReport.TabIndex = 21
        Me.chkCashflowReport.Text = "Cashflow Report"
        Me.chkCashflowReport.UseVisualStyleBackColor = True
        '
        'chkClientPerformanceReport
        '
        Me.chkClientPerformanceReport.AutoSize = True
        Me.chkClientPerformanceReport.Location = New System.Drawing.Point(6, 145)
        Me.chkClientPerformanceReport.Name = "chkClientPerformanceReport"
        Me.chkClientPerformanceReport.Size = New System.Drawing.Size(199, 20)
        Me.chkClientPerformanceReport.TabIndex = 19
        Me.chkClientPerformanceReport.Text = "Client Performance Report"
        Me.chkClientPerformanceReport.UseVisualStyleBackColor = True
        '
        'chkGenerateInvoices
        '
        Me.chkGenerateInvoices.AutoSize = True
        Me.chkGenerateInvoices.Location = New System.Drawing.Point(6, 82)
        Me.chkGenerateInvoices.Name = "chkGenerateInvoices"
        Me.chkGenerateInvoices.Size = New System.Drawing.Size(145, 20)
        Me.chkGenerateInvoices.TabIndex = 18
        Me.chkGenerateInvoices.Text = "Generate Invoices"
        Me.chkGenerateInvoices.UseVisualStyleBackColor = True
        '
        'chkViewInvoices
        '
        Me.chkViewInvoices.AutoSize = True
        Me.chkViewInvoices.Location = New System.Drawing.Point(6, 124)
        Me.chkViewInvoices.Name = "chkViewInvoices"
        Me.chkViewInvoices.Size = New System.Drawing.Size(116, 20)
        Me.chkViewInvoices.TabIndex = 16
        Me.chkViewInvoices.Text = "View Invoices"
        Me.chkViewInvoices.UseVisualStyleBackColor = True
        '
        'chkSendEmails
        '
        Me.chkSendEmails.AutoSize = True
        Me.chkSendEmails.Location = New System.Drawing.Point(6, 103)
        Me.chkSendEmails.Name = "chkSendEmails"
        Me.chkSendEmails.Size = New System.Drawing.Size(102, 20)
        Me.chkSendEmails.TabIndex = 15
        Me.chkSendEmails.Text = "Send Emails"
        Me.chkSendEmails.UseVisualStyleBackColor = True
        '
        'chkCompanyPerformanceReport
        '
        Me.chkCompanyPerformanceReport.AutoSize = True
        Me.chkCompanyPerformanceReport.Location = New System.Drawing.Point(6, 166)
        Me.chkCompanyPerformanceReport.Name = "chkCompanyPerformanceReport"
        Me.chkCompanyPerformanceReport.Size = New System.Drawing.Size(222, 20)
        Me.chkCompanyPerformanceReport.TabIndex = 20
        Me.chkCompanyPerformanceReport.Text = "Company Performance Report"
        Me.chkCompanyPerformanceReport.UseVisualStyleBackColor = True
        '
        'chkImportInvoices
        '
        Me.chkImportInvoices.AutoSize = True
        Me.chkImportInvoices.Location = New System.Drawing.Point(6, 19)
        Me.chkImportInvoices.Name = "chkImportInvoices"
        Me.chkImportInvoices.Size = New System.Drawing.Size(129, 20)
        Me.chkImportInvoices.TabIndex = 9
        Me.chkImportInvoices.Text = "Import Invoices"
        Me.chkImportInvoices.UseVisualStyleBackColor = True
        '
        'chkGenerateWeeklyReport
        '
        Me.chkGenerateWeeklyReport.AutoSize = True
        Me.chkGenerateWeeklyReport.Location = New System.Drawing.Point(6, 61)
        Me.chkGenerateWeeklyReport.Name = "chkGenerateWeeklyReport"
        Me.chkGenerateWeeklyReport.Size = New System.Drawing.Size(187, 20)
        Me.chkGenerateWeeklyReport.TabIndex = 2
        Me.chkGenerateWeeklyReport.Text = "Generate Weekly Report"
        Me.chkGenerateWeeklyReport.UseVisualStyleBackColor = True
        '
        'chkViewInsertedBilling
        '
        Me.chkViewInsertedBilling.AutoSize = True
        Me.chkViewInsertedBilling.Location = New System.Drawing.Point(6, 40)
        Me.chkViewInsertedBilling.Name = "chkViewInsertedBilling"
        Me.chkViewInsertedBilling.Size = New System.Drawing.Size(158, 20)
        Me.chkViewInsertedBilling.TabIndex = 10
        Me.chkViewInsertedBilling.Text = "View Inserted Billing"
        Me.chkViewInsertedBilling.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkEditClients)
        Me.GroupBox1.Controls.Add(Me.chkEditEmailBody)
        Me.GroupBox1.Controls.Add(Me.chkEditMapleAccounts)
        Me.GroupBox1.Controls.Add(Me.chkManageCompanies)
        Me.GroupBox1.Controls.Add(Me.chkEditSoftwares)
        Me.GroupBox1.Controls.Add(Me.chkAddUsers)
        Me.GroupBox1.Controls.Add(Me.chkEditAccountManager)
        Me.GroupBox1.Controls.Add(Me.chkEditBankAccounts)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 187)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(213, 200)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manage"
        '
        'chkEditClients
        '
        Me.chkEditClients.AutoSize = True
        Me.chkEditClients.Location = New System.Drawing.Point(5, 19)
        Me.chkEditClients.Name = "chkEditClients"
        Me.chkEditClients.Size = New System.Drawing.Size(58, 17)
        Me.chkEditClients.TabIndex = 3
        Me.chkEditClients.Text = "Clients"
        Me.chkEditClients.UseVisualStyleBackColor = True
        '
        'chkEditEmailBody
        '
        Me.chkEditEmailBody.AutoSize = True
        Me.chkEditEmailBody.Location = New System.Drawing.Point(5, 147)
        Me.chkEditEmailBody.Name = "chkEditEmailBody"
        Me.chkEditEmailBody.Size = New System.Drawing.Size(77, 17)
        Me.chkEditEmailBody.TabIndex = 8
        Me.chkEditEmailBody.Text = "Email Body"
        Me.chkEditEmailBody.UseVisualStyleBackColor = True
        '
        'chkEditMapleAccounts
        '
        Me.chkEditMapleAccounts.AutoSize = True
        Me.chkEditMapleAccounts.Location = New System.Drawing.Point(5, 125)
        Me.chkEditMapleAccounts.Name = "chkEditMapleAccounts"
        Me.chkEditMapleAccounts.Size = New System.Drawing.Size(101, 17)
        Me.chkEditMapleAccounts.TabIndex = 8
        Me.chkEditMapleAccounts.Text = "Maple Accounts"
        Me.chkEditMapleAccounts.UseVisualStyleBackColor = True
        '
        'chkManageCompanies
        '
        Me.chkManageCompanies.AutoSize = True
        Me.chkManageCompanies.Location = New System.Drawing.Point(5, 82)
        Me.chkManageCompanies.Name = "chkManageCompanies"
        Me.chkManageCompanies.Size = New System.Drawing.Size(78, 17)
        Me.chkManageCompanies.TabIndex = 6
        Me.chkManageCompanies.Text = "Companies"
        Me.chkManageCompanies.UseVisualStyleBackColor = True
        '
        'chkEditSoftwares
        '
        Me.chkEditSoftwares.AutoSize = True
        Me.chkEditSoftwares.Location = New System.Drawing.Point(5, 103)
        Me.chkEditSoftwares.Name = "chkEditSoftwares"
        Me.chkEditSoftwares.Size = New System.Drawing.Size(75, 17)
        Me.chkEditSoftwares.TabIndex = 6
        Me.chkEditSoftwares.Text = "Softwares"
        Me.chkEditSoftwares.UseVisualStyleBackColor = True
        '
        'chkEditAccountManager
        '
        Me.chkEditAccountManager.AutoSize = True
        Me.chkEditAccountManager.Location = New System.Drawing.Point(5, 61)
        Me.chkEditAccountManager.Name = "chkEditAccountManager"
        Me.chkEditAccountManager.Size = New System.Drawing.Size(115, 17)
        Me.chkEditAccountManager.TabIndex = 5
        Me.chkEditAccountManager.Text = "Account Managers"
        Me.chkEditAccountManager.UseVisualStyleBackColor = True
        '
        'chkEditBankAccounts
        '
        Me.chkEditBankAccounts.AutoSize = True
        Me.chkEditBankAccounts.Location = New System.Drawing.Point(5, 40)
        Me.chkEditBankAccounts.Name = "chkEditBankAccounts"
        Me.chkEditBankAccounts.Size = New System.Drawing.Size(96, 17)
        Me.chkEditBankAccounts.TabIndex = 4
        Me.chkEditBankAccounts.Text = "Bank Accounts"
        Me.chkEditBankAccounts.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.BackColor = System.Drawing.Color.Transparent
        Me.chkSelectAll.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSelectAll.Location = New System.Drawing.Point(97, 170)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(78, 17)
        Me.chkSelectAll.TabIndex = 33
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = False
        '
        'chkClearAll
        '
        Me.chkClearAll.AutoSize = True
        Me.chkClearAll.BackColor = System.Drawing.Color.Transparent
        Me.chkClearAll.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearAll.Location = New System.Drawing.Point(196, 170)
        Me.chkClearAll.Name = "chkClearAll"
        Me.chkClearAll.Size = New System.Drawing.Size(72, 17)
        Me.chkClearAll.TabIndex = 34
        Me.chkClearAll.Text = "Clear All"
        Me.chkClearAll.UseVisualStyleBackColor = False
        '
        'UsersTableAdapter
        '
        Me.UsersTableAdapter.ClearBeforeFill = True
        '
        'AccountManagersTableAdapter
        '
        Me.AccountManagersTableAdapter.ClearBeforeFill = True
        '
        'chbEditProviderPrice
        '
        Me.chbEditProviderPrice.AutoSize = True
        Me.chbEditProviderPrice.Location = New System.Drawing.Point(6, 82)
        Me.chbEditProviderPrice.Name = "chbEditProviderPrice"
        Me.chbEditProviderPrice.Size = New System.Drawing.Size(146, 20)
        Me.chbEditProviderPrice.TabIndex = 14
        Me.chbEditProviderPrice.Text = "Edit Provider Price"
        Me.chbEditProviderPrice.UseVisualStyleBackColor = True
        '
        'frmAddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(684, 503)
        Me.Controls.Add(Me.chkClearAll)
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Accounting)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmAddUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add/Edit Users"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.AccountManagersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAccountManagers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Accounting.ResumeLayout(False)
        Me.Accounting.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtAddUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAddPasswrod2 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmbEditUserName As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEditPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEditUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtEditPassword2 As System.Windows.Forms.TextBox
    '  Friend WithEvents DsUsers As Tempo.dsUsers
    '  Friend WithEvents UsersTableAdapter As Tempo.dsUsersTableAdapters.UsersTableAdapter
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEditNonCLI As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewRatesReports As System.Windows.Forms.CheckBox
    Friend WithEvents chkImportRates As System.Windows.Forms.CheckBox
    Friend WithEvents Accounting As System.Windows.Forms.GroupBox
    Friend WithEvents chkViewPayments As System.Windows.Forms.CheckBox
    Friend WithEvents chkMangePayments As System.Windows.Forms.CheckBox
    Friend WithEvents chkManageVouchers As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatementofAccount As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransactions As System.Windows.Forms.CheckBox
    Friend WithEvents chkBeginingBalances As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkViewInvoices As System.Windows.Forms.CheckBox
    Friend WithEvents chkGenerateWeeklyReport As System.Windows.Forms.CheckBox
    Friend WithEvents chkImportInvoices As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewInsertedBilling As System.Windows.Forms.CheckBox
    Friend WithEvents chkSendEmails As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEditMapleAccounts As System.Windows.Forms.CheckBox
    Friend WithEvents chkEditSoftwares As System.Windows.Forms.CheckBox
    Friend WithEvents chkEditAccountManager As System.Windows.Forms.CheckBox
    Friend WithEvents chkEditBankAccounts As System.Windows.Forms.CheckBox
    Friend WithEvents chkEditClients As System.Windows.Forms.CheckBox
    Friend WithEvents chkClearAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddUsers As System.Windows.Forms.CheckBox
    Friend WithEvents btnAddUser As System.Windows.Forms.Button
    Friend WithEvents btnDeleteUser As System.Windows.Forms.Button
    Friend WithEvents btnEditUser As System.Windows.Forms.Button
    Friend WithEvents chkViewVouchers As System.Windows.Forms.CheckBox
    Friend WithEvents chkGenerateInvoices As System.Windows.Forms.CheckBox
    Friend WithEvents chkEditEmailBody As System.Windows.Forms.CheckBox
    Friend WithEvents DsUser As Global.WindowsApplication1.dsUser
    Friend WithEvents UsersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UsersTableAdapter As dsUserTableAdapters.UsersTableAdapter
    Friend WithEvents chkManageCompanies As System.Windows.Forms.CheckBox
    Friend WithEvents chkClientPerformanceReport As System.Windows.Forms.CheckBox
    Friend WithEvents chkManagerRecievedAmount As System.Windows.Forms.CheckBox
    Friend WithEvents cmbAcountManagerAdd As System.Windows.Forms.ComboBox
    Friend WithEvents rbAccountManagerAdd As System.Windows.Forms.RadioButton
    Friend WithEvents rbAdminAdd As System.Windows.Forms.RadioButton
    Friend WithEvents cmbAccountManagersEdit As System.Windows.Forms.ComboBox
    Friend WithEvents rbAccountManagerEdit As System.Windows.Forms.RadioButton
    Friend WithEvents rbAdminEdit As System.Windows.Forms.RadioButton
    Friend WithEvents DsAccountManagers As Global.WindowsApplication1.dsAccountManagers
    Friend WithEvents AccountManagersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountManagersTableAdapter As Global.WindowsApplication1.dsAccountManagersTableAdapters.AccountManagersTableAdapter
    Friend WithEvents chkPurchases As System.Windows.Forms.CheckBox
    Friend WithEvents chkCashflowReport As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompanyPerformanceReport As System.Windows.Forms.CheckBox
    Friend WithEvents chbEditProviderPrice As System.Windows.Forms.CheckBox

End Class
