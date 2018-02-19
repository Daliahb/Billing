Public Class frmClients

    Dim oColClients As New ColClient

    Private Sub Template_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsAccountManagers.AccountManagers' table. You can move, or remove it, as needed.
        Me.AccountManagersTableAdapter.Fill(Me.DsAccountManagers.AccountManagers)
        'Me.BackColor = gBackColor
        CheckPermission()

        FillData()
        If gUser.IsAccountManager = True Then
            Me.chkAccountManager.Enabled = False
            Me.cmbAccountManager.SelectedValue = gUser.lAccountManager
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim boolFromMC As Boolean
        Dim strCompany As String = ""
        Dim lAccountManager, lAgreement, lBankAccount, lCompanyAccount, lStatus, lPeriod As Integer
        'Dim dtFrom, dtTo As Date
        'Dim ds As New DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            generateSearchCrytiria(strCompany, lAccountManager, lAgreement, lBankAccount, lCompanyAccount, boolFromMC, lStatus, lPeriod)

            oColClients.Clear()

            oColClients = odbaccess.GetClients(strCompany, lAccountManager, lAgreement, lBankAccount, lCompanyAccount, boolFromMC, lStatus, lPeriod)
            If Not oColClients Is Nothing AndAlso Not oColClients.Count = 0 Then
                For Each oClient As Client In oColClients
                    intRowIndex = Me.DataGridView1.Rows.Add
                    With Me.DataGridView1.Rows(intRowIndex)
                        .Cells(0).Value = oClient.ID
                        .Cells(1).Value = intCounter + 1
                        .Cells(2).Value = oClient.CompanyName
                        .Cells(3).Value = oClient.CompanyCode
                        .Cells(4).Value = oClient.Status.ToString
                        .Cells(5).Value = oClient.timezone
                        .Cells(6).Value = oClient.Period.ToString + " Net " + oClient.Statement.ToString
                        .Cells(7).Value = oClient.CreditLimit
                        .Cells(8).Value = oClient.ContractMapleName
                        .Cells(9).Value = oClient.ContractMapleBank
                        .Cells(10).Value = oClient.AccountManagerName
                        .Cells(11).Value = oClient.Agreement
                        .Cells(12).Value = oClient.BankAccountName
                        .Cells(13).Value = oClient.BankAccountNumber
                        .Cells(14).Value = oClient.IBAN
                        .Cells(15).Value = oClient.Swift
                        .Cells(16).Value = oClient.ABARouting
                        .Cells(17).Value = oClient.BillingEmail
                        intCounter += 1
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim lId As Long
        Dim oclient As Client
        Try
            If Not Me.DataGridView1.SelectedRows.Count = 0 Then
                lId = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
                oclient = Me.oColClients.GetClient(lId)

                Dim frmAddClient As New frmAddClient(Enumerators.EditAdd.Edit, oclient)
                frmAddClient.ShowDialog()
                With Me.DataGridView1.SelectedRows(0)
                    ' .Cells(0).Value = oclient.ID
                    '.Cells(1).Value = intCounter + 1
                    .Cells(2).Value = oclient.CompanyName
                    .Cells(3).Value = oclient.CompanyCode
                    .Cells(4).Value = oclient.Status.ToString
                    .Cells(5).Value = oclient.timezone
                    .Cells(6).Value = oclient.Period.ToString + " Net " + oclient.Statement.ToString
                    .Cells(7).Value = oclient.CreditLimit
                    .Cells(8).Value = oclient.ContractMapleName
                    .Cells(9).Value = oclient.ContractMapleBank
                    .Cells(10).Value = oclient.AccountManagerName
                    .Cells(11).Value = oclient.Agreement
                    .Cells(12).Value = oclient.BankAccountName
                    .Cells(13).Value = oclient.BankAccountNumber
                    .Cells(14).Value = oclient.IBAN
                    .Cells(15).Value = oclient.Swift
                    .Cells(16).Value = oclient.ABARouting
                    .Cells(17).Value = oclient.BillingEmail
                    '    intCounter += 1
                End With
                '  Me.btnSearch_Click(Me, New System.EventArgs)
            End If

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnAddCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCustomer.Click
        Dim oFrm As New frmAddClient(Enumerators.EditAdd.Add)
        oFrm.ShowDialog()
    End Sub

    Public Sub generateSearchCrytiria(ByRef strCompany As String, ByRef lAccountManager As Integer, ByRef lAgreement As Integer, ByRef lBankAccount As Integer, ByRef lCompanyAccount As Integer, ByRef boolFromMC As Boolean, ByRef lStatus As Integer, ByRef lPeriod As Integer)
        Try
            If Me.chkAccountManager.Checked Then
                lAccountManager = CInt(Me.cmbAccountManager.SelectedValue)
            Else
                lAccountManager = 0
            End If
            If Me.chkAgreement.Checked Then
                lAgreement = CInt(Me.cmbAgreement.SelectedItem.value)
            Else
                lAgreement = 0
            End If
            If Me.chkBankAccount.Checked Then
                lBankAccount = CInt(Me.cmbContractMapleBank.SelectedValue)
            Else
                lBankAccount = 0
            End If
            If Me.chkContractWith.Checked Then
                lCompanyAccount = CInt(Me.cmbContractMapleName.SelectedValue)
            Else
                lCompanyAccount = 0
            End If
            If Me.chkCompanyID.Checked Then
                strCompany = Me.cmbClientCode.Text
            Else
                strCompany = ""
            End If
            If Me.chkAddedFromMC.Checked Then
                boolFromMC = True
            Else
                boolFromMC = False
            End If
            If Me.chkStatus.Checked Then
                lStatus = CInt(Me.cmbStatus.SelectedItem.value)
            Else
                lStatus = 0
            End If
            If Me.chkPeriod.Checked Then
                lPeriod = CInt(Me.cmbPeriod.Text)
            Else
                lPeriod = 0
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub

    Dim intColumnIndex As Integer

    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo
            ht = Me.DataGridView1.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                DataGridView1.ContextMenuStrip = ContextMenuStrip1
            ElseIf ht.Type = DataGridViewHitTestType.ColumnHeader Then
                Me.intColumnIndex = ht.ColumnIndex
                DataGridView1.ContextMenuStrip = ContextMenuStrip2
            Else
                DataGridView1.ContextMenuStrip = ContextMenuStrip1
            End If
        End If
    End Sub

    Private Sub HideColumnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideColumnToolStripMenuItem.Click
        Me.DataGridView1.Columns(intColumnIndex).Visible = False
    End Sub

    Private Sub ShowAllColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllColumnsToolStripMenuItem.Click
        For i As Integer = 1 To Me.DataGridView1.Columns.Count - 1
            Me.DataGridView1.Columns(i).Visible = True
        Next
    End Sub

    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Try
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(1).Value = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteRowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteRowToolStripMenuItem.Click
        Dim lid As Long
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            lId = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)

            If MsgBox("Are you sure you want to inactive this Client?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If odbaccess.DeleteClient(lid) Then
                    btnSearch_Click(Me, New System.EventArgs)
                Else
                    MsgBox("An error occured")
                End If

            End If
        End If

    End Sub

    Public Sub FillData()
        If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
            Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
            Me.cmbClientCode.DisplayMember = "CompanyCode"
            Me.cmbClientCode.ValueMember = "ID"
        Else
            gDsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                FillData()
            End If
        End If

        Dim dsCompanies As DataSet
        Try
            dsCompanies = odbaccess.GetCompaniesDS
            Me.cmbContractMapleName.DataSource = dsCompanies.Tables(0)
            Me.cmbContractMapleName.ValueMember = "ID"
            Me.cmbContractMapleName.DisplayMember = "Name"
        Catch ex As Exception

        End Try
        Dim dsBanks As DataSet
        Try
            dsBanks = odbaccess.GetBanksDS
            Me.cmbContractMapleBank.DataSource = dsBanks.Tables(0)
            Me.cmbContractMapleBank.ValueMember = "ID"
            Me.cmbContractMapleBank.DisplayMember = "Bank_Name"
        Catch ex As Exception

        End Try

        Me.cmbAgreement.DataSource = Nothing
        Me.cmbAgreement.Items.Add(New Obj("Unilateral", Enumerators.Agreement.Unilateral))
        Me.cmbAgreement.Items.Add(New Obj("Bilateral", Enumerators.Agreement.Bilateral))
        Me.cmbAgreement.ValueMember = "Value"
        Me.cmbAgreement.DisplayMember = "Name"

        Me.cmbStatus.Items.Add(New Obj("Active", Enumerators.ClientStatus.Active))
        Me.cmbStatus.Items.Add(New Obj("Disabled", Enumerators.ClientStatus.Disabled))
        '  Me.cmbStatus.Items.Add(New Obj("Potential", Enumerators.ClientStatus.Potential))
        Me.cmbStatus.ValueMember = "Value"
        Me.cmbStatus.DisplayMember = "Name"
    End Sub

    Public Sub CheckPermission()
        'Dim boolEditClients, boolExportToExcel As Boolean
        'For Each oRole As Role In oUser.oColRoles
        '    If CType(oRole.ID, Enumerators.Roles) = Enumerators.Roles.EditClients Then
        '        boolEditClients = True
        '    End If
        '    If CType(oRole.ID, Enumerators.Roles) = Enumerators.Roles.ExportToExcel Then
        '        boolExportToExcel = True
        '    End If
        'Next

        'If Not boolExportToExcel Then
        '    Me.ExportToExcelToolStripMenuItem.Enabled = False
        'End If
        'If Not boolEditClients Then
        '    Me.EditToolStripMenuItem.Enabled = False
        '    Me.DeleteRowToolStripMenuItem.Enabled = False
        'End If
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivateToolStripMenuItem.Click
        'Dim lId As Long
        'Try
        '    If Not Me.DataGridView1.SelectedRows.Count = 0 Then
        '        lId = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)

        '        If odbaccess.ActivateClient(lId) Then
        '            MsgBox("Operation done successfully.")
        '            '     Me.btnGet_Click(Me, New System.EventArgs)
        '        Else
        '            MsgBox("An error occured.")
        '        End If
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message & ex.StackTrace)
        'End Try
    End Sub

    Private Sub chkCompanyID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCompanyID.CheckedChanged
        Me.cmbClientCode.Enabled = Me.chkCompanyID.Checked
    End Sub

    Private Sub chkAccountManager_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAccountManager.CheckedChanged
        Me.cmbAccountManager.Enabled = Me.chkAccountManager.Checked
    End Sub

    Private Sub chkAgreement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAgreement.CheckedChanged
        Me.cmbAgreement.Enabled = Me.chkAgreement.Checked
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged, chkPeriod.CheckedChanged
        Me.cmbStatus.Enabled = Me.chkStatus.Checked
    End Sub

    Private Sub chkContractWith_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContractWith.CheckedChanged
        Me.cmbContractMapleName.Enabled = Me.chkContractWith.Checked
    End Sub

    Private Sub chkBankAccount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBankAccount.CheckedChanged
        Me.cmbContractMapleBank.Enabled = Me.chkBankAccount.Checked
    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
End Class