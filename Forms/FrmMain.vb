Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Deployment.Application
Imports System.Timers

Public Class FrmMain

    Dim oCheckInquiryThread As Threading.Thread

    Private Sub FrmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Settings.UserName = gUser.UserName
        odbaccess.LogOut()
        Application.Exit()
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        oCheckInquiryThread.Abort()
    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblCountry.Text = gCountry
        CheckPermission()
        Me.Text += gUser.UserName

        'Check if there are clients added from MC
        If odbaccess.CheckClientsFromMC() Then
            Dim frm As New frmWarningClientsFromMC
            frm.Show()
        End If



        Me.CheckForIllegalCrossThreadCalls = False
        oCheckInquiryThread = New Threading.Thread(AddressOf CheckNewInquiries)
        oCheckInquiryThread.Start()
    End Sub

    Public Sub CheckPermission()

        For Each oRole As Role In gUser.oColRoles
            Select Case CType(oRole.ID, Enumerators.Roles)
                Case Enumerators.Roles.Post_Invoices_Send_Emails
                    Me.SetTestEmailToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Manage_Clients
                    Me.ClientsToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Manage_BankAccounts
                    Me.BankAccountsToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Manage_Companies
                    Me.CompaniesToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Manage_Softwares
                    Me.SoftwaresToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Manage_AccountManager
                    Me.AccountManagersToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Manage_MapleAccounts
                    Me.MapleAccountsToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Manage_EmailBody
                    Me.EmailBodyToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Manage_Users
                    Me.MangeUsersToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Add_Payment
                    Me.AddClientPaymentToolStripMenuItem.Enabled = True
                    Me.AddMaplePaymentToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Add_Voucher
                    Me.AddVoucherToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.View_Payments
                    Me.PaymentsToolStripMenuItem.Enabled = True
                    Me.MaplePaymentsToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.View_Vouchers
                    Me.AllVouchersToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.View_StatementOfAccount
                    Me.StatementOfAccountToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.View_ClientTransactions
                    Me.TransactionsToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Manage_BeginingBalances
                    Me.BeginingBalancesToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Import_Rates
                    Me.ImportOfferToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.View_Purchases
                    Me.PurchasesToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Client_Performance_Report
                    Me.PerformanceReportToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Company_Performance_Report
                    Me.CompanyPerformanceReportToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Cashflow_Report
                    Me.CashflowReportToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.View_Rates_Reports
                    Me.GetAllRatesToolStripMenuItem.Enabled = True
                    Me.GetRatesByCodeToolStripMenuItem.Enabled = True
                    Me.GetRatesByCountryToolStripMenuItem.Enabled = True
                    Me.GetRatesByProviderToolStripMenuItem.Enabled = True
            End Select
        Next
    End Sub

    Public Sub CheckNewInquiries()
        Dim int, i As Integer

        i = 0
        Do
            int = odbaccess.CheckNewInquiries()
            If int > 0 Then
                Me.InquiriesToolStripMenuItem.BackColor = Color.LightCoral
            Else
                Me.InquiriesToolStripMenuItem.BackColor = Color.Transparent
            End If
            i += 1
            lbl1.Text = i
            Threading.Thread.Sleep(600000)

        Loop

    End Sub

    'Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
    '    CheckNewInquiries()
    '    System.Threading.Thread.Sleep(120000)
    'End Sub

#Region "Controls event handlers"


    Private Sub ClientsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmClients).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmClients") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmClients
            frm.Show()
        End If
    End Sub

    Private Sub BankAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankAccountsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmBanks).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmBanks") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmBanks
            frm.Show()
        End If
    End Sub

    Private Sub CompaniesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompaniesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCompanies).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCompanies") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmCompanies
            frm.Show()
        End If
    End Sub

    Private Sub SoftwaresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoftwaresToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of FrmSoftwares).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("FrmSoftwares") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New FrmSoftwares
            frm.Show()
        End If
    End Sub

    Private Sub AccountManagersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountManagersToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAccountManagers).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAccountManagers") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAccountManagers
            frm.Show()
        End If
    End Sub

    Private Sub MapleAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MapleAccountsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmMapleAccounts).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmMappleAccounts") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmMapleAccounts
            frm.Show()
        End If
    End Sub

    Private Sub SetInvoicesFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetInvoicesFolderToolStripMenuItem.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.SelectedPath = My.Settings.RootDirectory
        folderDlg.ShowNewFolderButton = True
        folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
        If (folderDlg.ShowDialog() = DialogResult.OK) Then

            '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
            My.Settings.RootDirectory = folderDlg.SelectedPath
        End If

    End Sub

    Private Sub EmailBodyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailBodyToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmEmailBody).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmEmailBody") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmEmailBody
            frm.Show()
        End If
    End Sub

    Private Sub GetRatesByCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetRatesByCodeToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmRatesByCode).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmRatesByCode") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmRatesByCode
            frm.Show()
        End If
    End Sub

    Private Sub GetRatesByProviderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetRatesByProviderToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmRatesByProvider).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmRatesByProvider") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmRatesByProvider
            frm.Show()
        End If
    End Sub

    Private Sub GetAllRatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetAllRatesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAllRates).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAllRates") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmAllRates
            frm.Show()
        End If
    End Sub

    Private Sub GetRatesByCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetRatesByCountryToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmRatesByCountryProvider).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmRatesByCountryProvider") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmRatesByCountryProvider
            frm.Show()
        End If
    End Sub

    Private Sub ImportOfferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportOfferToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmImportOffer).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmImportOffer") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmImportOffer
            frm.Show()
        End If
    End Sub

    Private Sub AddClientPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddClientPaymentToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAddClientPayment).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddClientPayment") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddClientPayment(Enumerators.EditAdd.Add, 0)
            frm.Show()
        End If
    End Sub

    Private Sub AddVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddVoucherToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAddVoucher).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddVoucher") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddVoucher(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub AllVouchersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllVouchersToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmVouchers).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmVouchers") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmVouchers
            frm.Show()
        End If
    End Sub

    Private Sub PaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmClientsPayments).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmClientsPayments") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmClientsPayments
            frm.Show()
        End If
    End Sub

    Private Sub StatementOfAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatementOfAccountToolStripMenuItem.Click
        'Dim oGenerate_Invoice As New Generate_Invoice
        '    oGenerate_Invoice.GenerateStatementOfAccountReport()
        If Application.OpenForms().OfType(Of frmClientStatementOfAccount).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmClientStatementOfAccount") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmClientStatementOfAccount
            frm.Show()
        End If
    End Sub

    Private Sub BeginingBalancesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginingBalancesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of FrmBegingBalances).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("FrmBegingBalances") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New FrmBegingBalances
            frm.Show()
        End If
    End Sub

    Private Sub TransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmTransactions).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmTransactions") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmTransactions
            frm.Show()
        End If

    End Sub

    Private Sub MangeUsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MangeUsersToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAddUser).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddUser") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddUser
            frm.Show()
        End If
      
    End Sub

    Private Sub ResetPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetPasswordToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmChangePassword).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmChangePassword") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmChangePassword
            frm.Show()
        End If

    End Sub

    Private Sub PerformanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PerformanceReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmClientPerformanceReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmPerformanceReport") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmClientPerformanceReport
            frm.Show()
        End If
       
    End Sub

    Private Sub SetTestEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetTestEmailToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of FrmSetTestEmail).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("FrmSetTestEmail") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New FrmSetTestEmail
            frm.Show()
        End If

    End Sub

    Private Sub InvoicingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoicingToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of FrmInvoicing).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("FrmInvoicing") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New FrmInvoicing
            frm.Show()
        End If
    End Sub

    Private Sub CompanyPerformanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyPerformanceReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCompanyPerformanceReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCompanyPerformanceReport") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmCompanyPerformanceReport
            frm.Show()
        End If

    End Sub

    Private Sub PurchasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmPurchases).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmPurchases") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmPurchases
            frm.Show()
        End If
    End Sub

    Private Sub CashflowReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashflowReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCashflowReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmCashflowReport") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmCashflowReport
            frm.Show()
        End If
    End Sub

    Private Sub MaplePaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaplePaymentsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmMaplePayments).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmMaplePayments") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmMaplePayments
            frm.Show()
        End If
    End Sub

    Private Sub StatementOfAccountoneClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AddMaplePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMaplePaymentToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAddMaplePayment).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddMaplePayment") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddMaplePayment(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub PotentialClientsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PotentialClientsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmPotentialClients2).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmPotentialClients2") Then
                    frm.WindowState = FormWindowState.Minimized
                End If
            Next
        Else
            Dim frm As New frmPotentialClients2()
            frm.Show()
        End If
    End Sub

    Private Sub InquiriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InquiriesToolStripMenuItem.Click
        Dim frm As New frmInquiries
        frm.Show()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click

      

    End Sub

    Private Sub AimPerformanceReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AimPerformanceReportToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmAimPerformanceReport).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAimPerformanceReport") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmAimPerformanceReport
            frm.Show()
        End If
    End Sub

#End Region

End Class