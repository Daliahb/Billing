Public Class frmAddUser
    Dim oUser As New User
    Dim oColUsers As New ColUser
    Dim booloaded As Boolean

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmAddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsAccountManagers.AccountManagers' table. You can move, or remove it, as needed.
        Me.AccountManagersTableAdapter.Fill(Me.DsAccountManagers.AccountManagers)
        'TODO: This line of code loads data into the 'DsUser.Users' table. You can move, or remove it, as needed.
        Me.UsersTableAdapter.Fill(Me.DsUser.Users)

        Me.oColUsers.Clear()
        Me.oColUsers = odbaccess.GetUsers()

        booloaded = True
    End Sub

    Private Sub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click
        Dim boolError As Boolean
        Try
            If CheckValidation(Enumerators.EditAdd.Add) Then
                FillObject(Enumerators.EditAdd.Add)

                boolError = odbaccess.InsertUser(oUser)
                If boolError Then
                    MsgBox("Operation done successfully.")
                    Me.oColUsers.Add(oUser)
                    Me.UsersTableAdapter.Fill(Me.DsUser.Users)
                    ResetForm()
                Else
                    MsgBox("Error occured!")
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtAddPasswrod2.Text = ""
        Me.txtAddPassword.Text = ""
        Me.txtAddUserName.Text = ""

    End Sub

    Public Function CheckValidation(ByVal enumAddEdit As Enumerators.EditAdd) As Boolean
        Dim boolError As Boolean = True
        If enumAddEdit = Enumerators.EditAdd.Add Then
            If txtAddUserName.Text.Length = 0 Then
                ErrorProvider1.SetError(txtAddUserName, "Insert a valid UserName")
                boolError = False
            Else
                ErrorProvider1.SetError(txtAddUserName, "")
            End If

            If Me.txtAddPassword.Text.Length = 0 Then
                ErrorProvider1.SetError(txtAddPassword, "Insert a Password")
                boolError = False
            Else
                ErrorProvider1.SetError(txtAddPassword, "")
            End If

            If Me.txtAddPassword.Text <> Me.txtAddPasswrod2.Text Then
                ErrorProvider1.SetError(txtAddPasswrod2, "Passwords don't match.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtAddPasswrod2, "")
            End If

            If Me.rbAccountManagerAdd.Checked = False And Me.rbAdminAdd.Checked = False Then
                ErrorProvider1.SetError(rbAdminAdd, "Choose User type.")
                boolError = False
            Else
                ErrorProvider1.SetError(rbAdminAdd, "")
            End If

        ElseIf enumAddEdit = Enumerators.EditAdd.Edit Then
            If txtEditUserName.Text.Length = 0 Then
                ErrorProvider1.SetError(txtEditUserName, "Insert a valid UserName")
                boolError = False
            Else
                ErrorProvider1.SetError(txtEditUserName, "")
            End If

            If Me.txtEditPassword.Text.Length = 0 Then
                ErrorProvider1.SetError(txtEditPassword, "Insert a Password")
                boolError = False
            Else
                ErrorProvider1.SetError(txtEditPassword, "")
            End If

            If Me.txtEditPassword.Text <> Me.txtEditPassword2.Text Then
                ErrorProvider1.SetError(txtEditPassword2, "Passwords don't match.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtEditPassword2, "")
            End If

            If Me.cmbEditUserName.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbEditUserName, "Choose User from the list")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbEditUserName, "")
            End If
            If Me.rbAccountManagerEdit.Checked = False And Me.rbAdminEdit.Checked = False Then
                ErrorProvider1.SetError(rbAdminEdit, "Choose User type.")
                boolError = False
            Else
                ErrorProvider1.SetError(rbAdminEdit, "")
            End If
            If Me.rbAccountManagerEdit.Checked And Me.cmbAccountManagersEdit.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbAccountManagersEdit, "Please choose Account Manager from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbAccountManagersEdit, "")
            End If
        End If

        Return boolError
    End Function

    Public Sub FillObject(ByVal enumAddEdit As Enumerators.EditAdd)
        oUser = New User
        Dim oRole As Role
        Dim oColRole As New ColRole
        If enumAddEdit = Enumerators.EditAdd.Add Then
            With oUser
                .UserName = Me.txtAddUserName.Text
                .Password = Me.txtAddPassword.Text
            End With
            If rbAccountManagerAdd.Checked Then
                oUser.lAccountManager = CInt(Me.cmbAcountManagerAdd.SelectedValue)
                oUser.IsAccountManager = True
            Else
                oUser.lAccountManager = 0
                oUser.IsAccountManager = False
            End If
        Else
            With oUser
                .Id = CLng(cmbEditUserName.SelectedValue)
                .UserName = Me.txtEditUserName.Text
                .Password = Me.txtEditPassword.Text
                If rbAccountManagerEdit.Checked Then
                    .lAccountManager = CInt(Me.cmbAccountManagersEdit.SelectedValue)
                    .IsAccountManager = True
                Else
                    .lAccountManager = 0
                    .IsAccountManager = False
                End If
            End With
          
        End If

        If Me.chkImportInvoices.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Import_Invoices_files
            oColRole.Add(oRole)
        End If

        If Me.chkGenerateWeeklyReport.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Generate_weekly_Report
            oColRole.Add(oRole)
        End If

        If Me.chkGenerateInvoices.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Generate_Invoices
            oColRole.Add(oRole)
        End If

        If Me.chkImportRates.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Import_Rates
            oColRole.Add(oRole)
        End If

        If Me.chkEditSoftwares.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_Softwares
            oColRole.Add(oRole)
        End If

        If Me.chkEditBankAccounts.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_BankAccounts
            oColRole.Add(oRole)
        End If

        If Me.chkEditMapleAccounts.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_MapleAccounts
            oColRole.Add(oRole)
        End If


        If Me.chkManageCompanies.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_Companies
            oColRole.Add(oRole)
        End If

        If Me.chkEditAccountManager.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_AccountManager
            oColRole.Add(oRole)
        End If

        If Me.chkEditClients.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_Clients
            oColRole.Add(oRole)
        End If

        If Me.chkEditNonCLI.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_NonCLI_Type
            oColRole.Add(oRole)
        End If

        If Me.chkSendEmails.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Post_Invoices_Send_Emails
            oColRole.Add(oRole)
        End If

        If Me.chkViewInsertedBilling.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.view_Inserted_Billing
            oColRole.Add(oRole)
        End If

        If Me.chkMangePayments.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Add_Payment
            oColRole.Add(oRole)
        End If

        If Me.chkBeginingBalances.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_BeginingBalances
            oColRole.Add(oRole)
        End If

        If Me.chkManageVouchers.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Add_Voucher
            oColRole.Add(oRole)
        End If

        If Me.chkTransactions.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.View_ClientTransactions
            oColRole.Add(oRole)
        End If

        If Me.chkViewPayments.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.View_Payments
            oColRole.Add(oRole)
        End If

        If Me.chkStatementofAccount.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.View_StatementOfAccount
            oColRole.Add(oRole)
        End If

        If Me.chkViewInvoices.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.View_Invoices
            oColRole.Add(oRole)
        End If

        If Me.chkAddUsers.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_Users
            oColRole.Add(oRole)
        End If

        If Me.chkViewRatesReports.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.View_Rates_Reports
            oColRole.Add(oRole)
        End If

        If Me.chkViewVouchers.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.View_Vouchers
            oColRole.Add(oRole)
        End If
        If Me.chkEditEmailBody.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_EmailBody
            oColRole.Add(oRole)
        End If
        If Me.chkClientPerformanceReport.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Client_Performance_Report
            oColRole.Add(oRole)
        End If
        If Me.chkCompanyPerformanceReport.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Company_Performance_Report
            oColRole.Add(oRole)
        End If
        If Me.chkCashflowReport.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Cashflow_Report
            oColRole.Add(oRole)
        End If
        If Me.chkManagerRecievedAmount.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Manage_RecievedAmount
            oColRole.Add(oRole)
        End If
        If Me.chkPurchases.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.View_Purchases
            oColRole.Add(oRole)
        End If
        If Me.chbEditProviderPrice.Checked Then
            oRole = New Role
            oRole.ID = Enumerators.Roles.Edit_provide_price
            oColRole.Add(oRole)
        End If

        oUser.oColRoles = oColRole
    End Sub

    Private Sub btnEditUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditUser.Click
        Try
            If CheckValidation(Enumerators.EditAdd.Edit) Then
                FillObject(Enumerators.EditAdd.Edit)

                If odbaccess.EditUser(oUser) Then
                    MsgBox("Operation done successfully.")
                    Me.oColUsers.Clear()
                    Me.oColUsers = odbaccess.GetUsers()

                Else
                    MsgBox("Error occured!")
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Private Sub cmbEditUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEditUserName.SelectedIndexChanged
        If booloaded Then
            For Each oUser As User In Me.oColUsers
                If oUser.Id = CLng(Me.cmbEditUserName.SelectedValue) Then
                    Me.oUser = oUser
                    Exit For
                End If
            Next

            Me.txtEditUserName.Text = Me.cmbEditUserName.Text
            Me.txtEditPassword.Text = oUser.Password
            Me.txtEditPassword2.Text = oUser.Password
            If oUser.IsAccountManager Then
                Me.cmbAccountManagersEdit.Enabled = True
                Me.cmbAccountManagersEdit.SelectedValue = oUser.lAccountManager
                Me.rbAccountManagerEdit.Checked = True
            Else
                Me.rbAdminEdit.Checked = True
                Me.cmbAccountManagersEdit.Enabled = False
            End If
            Me.chkClearAll.Checked = True
            setRoles()

        End If


    End Sub

    Private Sub btnAddClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnEditClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If Me.chkSelectAll.Checked Then
            For Each cnt As Control In Me.GroupBox1.Controls
                If TypeOf cnt Is CheckBox Then
                    Dim chkBox As CheckBox = CType(cnt, CheckBox)
                    chkBox.Checked = True
                End If
            Next

            For Each cnt As Control In Me.GroupBox2.Controls
                If TypeOf cnt Is CheckBox Then
                    Dim chkBox As CheckBox = CType(cnt, CheckBox)
                    chkBox.Checked = True
                End If
            Next

            For Each cnt As Control In Me.Accounting.Controls
                If TypeOf cnt Is CheckBox Then
                    Dim chkBox As CheckBox = CType(cnt, CheckBox)
                    chkBox.Checked = True
                End If
            Next

            For Each cnt As Control In Me.GroupBox4.Controls
                If TypeOf cnt Is CheckBox Then
                    Dim chkBox As CheckBox = CType(cnt, CheckBox)
                    chkBox.Checked = True
                End If
            Next
            Me.chkSelectAll.Checked = False
        End If

    End Sub

    Private Sub chkClearAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAll.CheckedChanged
        If Me.chkClearAll.Checked Then
            For Each cnt As Control In Me.GroupBox1.Controls
                If TypeOf cnt Is CheckBox Then
                    Dim chkBox As CheckBox = CType(cnt, CheckBox)
                    chkBox.Checked = False
                End If
            Next

            For Each cnt As Control In Me.GroupBox2.Controls
                If TypeOf cnt Is CheckBox Then
                    Dim chkBox As CheckBox = CType(cnt, CheckBox)
                    chkBox.Checked = False
                End If
            Next

            For Each cnt As Control In Me.Accounting.Controls
                If TypeOf cnt Is CheckBox Then
                    Dim chkBox As CheckBox = CType(cnt, CheckBox)
                    chkBox.Checked = False
                End If
            Next

            For Each cnt As Control In Me.GroupBox4.Controls
                If TypeOf cnt Is CheckBox Then
                    Dim chkBox As CheckBox = CType(cnt, CheckBox)
                    chkBox.Checked = False
                End If
            Next
            Me.chkClearAll.Checked = False
        End If

    End Sub

    Public Sub setRoles()


        For Each oRol In oUser.oColRoles
            Select Case CType(oRol.id, Enumerators.Roles)
                Case Enumerators.Roles.Import_Invoices_files
                    Me.chkImportInvoices.Checked = True
                Case Enumerators.Roles.Generate_weekly_Report
                    Me.chkGenerateWeeklyReport.Checked = True
                Case Enumerators.Roles.Manage_Users
                    Me.chkAddUsers.Checked = True
                Case Enumerators.Roles.Import_Rates
                    Me.chkImportRates.Checked = True
                Case Enumerators.Roles.Manage_Softwares
                    Me.chkEditSoftwares.Checked = True
                Case Enumerators.Roles.View_Rates_Reports
                    Me.chkViewRatesReports.Checked = True
                Case Enumerators.Roles.Manage_BankAccounts
                    Me.chkEditBankAccounts.Checked = True
                Case Enumerators.Roles.Manage_MapleAccounts
                    Me.chkEditMapleAccounts.Checked = True
                Case Enumerators.Roles.Manage_Companies
                    Me.chkManageCompanies.Checked = True
                Case Enumerators.Roles.Manage_AccountManager
                    Me.chkEditAccountManager.Checked = True
                Case Enumerators.Roles.Manage_Clients
                    Me.chkEditClients.Checked = True
                Case Enumerators.Roles.Manage_NonCLI_Type
                    Me.chkEditNonCLI.Checked = True
                Case Enumerators.Roles.Post_Invoices_Send_Emails
                    Me.chkSendEmails.Checked = True
                Case Enumerators.Roles.view_Inserted_Billing
                    Me.chkViewInsertedBilling.Checked = True
                Case Enumerators.Roles.Add_Payment
                    Me.chkMangePayments.Checked = True
                Case Enumerators.Roles.Add_Voucher
                    Me.chkManageVouchers.Checked = True
                Case Enumerators.Roles.View_ClientTransactions
                    Me.chkTransactions.Checked = True
                Case Enumerators.Roles.Manage_BeginingBalances
                    Me.chkBeginingBalances.Checked = True
                Case Enumerators.Roles.View_Payments
                    Me.chkViewPayments.Checked = True
                Case Enumerators.Roles.View_StatementOfAccount
                    Me.chkStatementofAccount.Checked = True
                Case Enumerators.Roles.View_Invoices
                    Me.chkViewInvoices.Checked = True
                Case Enumerators.Roles.View_Vouchers
                    Me.chkViewVouchers.Checked = True
                Case Enumerators.Roles.Generate_Invoices
                    Me.chkGenerateInvoices.Checked = True
                Case Enumerators.Roles.Manage_EmailBody
                    Me.chkEditEmailBody.Checked = True
                Case Enumerators.Roles.Client_Performance_Report
                    Me.chkClientPerformanceReport.Checked = True
                Case Enumerators.Roles.Company_Performance_Report
                    Me.chkCompanyPerformanceReport.Checked = True
                Case Enumerators.Roles.Cashflow_Report
                    Me.chkCashflowReport.Checked = True
                Case Enumerators.Roles.Manage_RecievedAmount
                    Me.chkManagerRecievedAmount.Checked = True
                Case Enumerators.Roles.View_Purchases
                    Me.chkPurchases.Checked = True
                Case Enumerators.Roles.Edit_provide_price
                    Me.chbEditProviderPrice.Checked = True
            End Select
        Next

    End Sub

    Private Sub btnDeleteUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteUser.Click
        If MsgBox("Are you sure you want to delete the selected User?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If odbaccess.DeleteUser(CLng(Me.cmbEditUserName.SelectedValue)) Then
                MsgBox("deleted successfuly")
                Me.UsersTableAdapter.Fill(Me.DsUser.Users)
                'Me.oColUsers.Add(oUser)
                '         Me.Close()
            Else
                MsgBox("An Error Occured.")
            End If
        End If
    End Sub

    Private Sub rbAccountManagerAdd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAccountManagerAdd.CheckedChanged
        Me.cmbAcountManagerAdd.Enabled = Me.rbAccountManagerAdd.Checked
    End Sub

    Private Sub rbAccountManagerEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAccountManagerEdit.CheckedChanged
        Me.cmbAccountManagersEdit.Enabled = Me.rbAccountManagerEdit.Checked
    End Sub

    Private Sub cmbAccountManagersEdit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccountManagersEdit.SelectedIndexChanged
        Dim boolFound As Boolean
        For Each oUser As User In Me.oColUsers

            If oUser.lAccountManager = CInt(Me.cmbAccountManagersEdit.SelectedValue) AndAlso Not (oUser.Id = CLng(cmbEditUserName.SelectedValue)) Then
                boolFound = True
                Exit For
            End If
        Next
        If boolFound Then
            ErrorProvider1.SetError(cmbAccountManagersEdit, "The selected 'Account Manager' is already used for another User")
            boolFound = False
            Else
            ErrorProvider1.SetError(cmbAccountManagersEdit, "")
        End If

    End Sub

    Private Sub cmbAcountManagerAdd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAcountManagerAdd.SelectedIndexChanged
        Dim boolFound As Boolean
        For Each oUser As User In Me.oColUsers

            If oUser.lAccountManager = CLng(Me.cmbAcountManagerAdd.SelectedValue) Then
                boolFound = True
                Exit For
            End If
        Next
        If boolFound Then
            ErrorProvider1.SetError(cmbAcountManagerAdd, "The selected 'Account Manager' is already used for another User")
            boolFound = False
        Else
            ErrorProvider1.SetError(cmbAcountManagerAdd, "")
        End If

    End Sub

End Class
