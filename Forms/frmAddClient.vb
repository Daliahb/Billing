Public Class frmAddClient

    Public enumEditAdd As New Enumerators.EditAdd
    Public lID As Long
    Public oClient As New Client
    Public boolSaved As Boolean
    Dim dsOutboundNames As DataSet

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByRef oClient As Client = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.o
        Me.enumEditAdd = enumEditAdd
        Me.lID = lID
        Me.oClient = oClient

        FillData()
    End Sub

    Private Sub frmAddClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsAccountManagers.AccountManagers' table. You can move, or remove it, as needed.
        Me.AccountManagersTableAdapter.Fill(Me.DsAccountManagers.AccountManagers)
        '      'Me.BackColor = gBackColor

        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Client"
            dsOutboundNames = odbaccess.getOutboundNames(oClient.ID)
            SetControls()

        End If
        'boolSaved = True
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try

            If CheckValidity() Then
                Return
            End If

            FillObject()


            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.insertClient(oClient)
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditClient(oClient)
            End If
            If boolError Then
                MsgBox("Operation done successfully.")
                boolSaved = True
                gDsMembers = Nothing
                gDsClientsBanks = Nothing
                gDsMembers = odbaccess.GetClientsDS
                gDsClientsBanks = odbaccess.GetClientsBanksDS
                If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                    Me.Close()
                Else
                    Me.ResetForm()
                End If
            Else
                MsgBox("Error occured!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtCompanyName.Text = ""
        Me.txtCode.Text = ""
        Me.txtTimeZone.Text = ""
        Me.txtAddress.Text = ""
        Me.txtPeriod.Text = ""
        Me.txtStatement.Text = ""
        Me.txtBillingEmail.Text = ""
        Me.txtCCEmails.Text = ""
        Me.txtBankAccountName.Text = ""
        Me.txtBankAccountNumber.Text = ""
        Me.txtIBAN.text = ""
        Me.txtBeneficiaryBankName.text = ""
        Me.txtBeneficiaryBankAdd.text = ""
        Me.txtSwift.Text = ""
        Me.txtCreditLimit.Text = ""
        Me.dgOutboundNames.Rows.Clear()
        'Me.ContractCompanyName()
        Me.oClient = New Client
        Me.cmbAgreement.SelectedValue = -1

    End Sub

    Public Sub FillObject()
        If oClient Is Nothing Then
            oClient = New Client
        End If
        With Me.oClient

            .CompanyName = Me.txtCompanyName.Text
            .CompanyCode = Me.txtCode.Text
            .timezone = Me.txtTimeZone.Text
            .Address = Me.txtAddress.Text
            .Period = CInt(Me.txtPeriod.Text)
            .Statement = CInt(Me.txtStatement.Text)
            .BillingEmail = Me.txtBillingEmail.Text
            .CCEmail = Me.txtCCEmails.Text
            .BankAccountName = Me.txtBankAccountName.Text
            .BankAccountNumber = Me.txtBankAccountNumber.Text
            .IBAN = Me.txtIBAN.Text
            .BeneficiaryBankName = Me.txtBeneficiaryBankName.Text
            .BeneficiaryBankAddress = Me.txtBeneficiaryBankAdd.Text
            .Swift = Me.txtSwift.Text
            .CreditLimit = CInt(Me.txtCreditLimit.Text)
            .ContractMapleNameID = CLng(Me.cmbContractMapleName.SelectedValue)
            .ContractMapleBankID = CLng(Me.cmbContractMapleBank.SelectedValue)
            .AccountManagerID = CLng(Me.cmbAccountManager.SelectedValue)
            .ContractMapleBank = Me.cmbContractMapleBank.Text
            .ContractMapleName = Me.cmbContractMapleName.Text
            .AccountManagerName = Me.cmbAccountManager.Text
            .Agreement = CType(Me.cmbAgreement.SelectedItem.value, Enumerators.Agreement)

            Dim strOutboundNames As String = ""
            For Each dr As DataGridViewRow In Me.dgOutboundNames.Rows
                If Not dr.Cells(0).Value Is Nothing AndAlso Not dr.Cells(0).Value.ToString = "" Then
                    strOutboundNames += dr.Cells(0).Value.ToString
                    strOutboundNames += ","
                End If
            Next
            .strOutboundNames = strOutboundNames
        End With
    End Sub

    Public Sub SetControls()
        If Not oClient.Id = 0 Then

            With Me.oClient
                Me.txtCompanyName.Text = .CompanyName
                Me.txtCode.Text = .CompanyCode
                Me.txtTimeZone.Text = .timezone
                Me.txtAddress.Text = .Address
                Me.txtPeriod.Text = .Period.ToString
                Me.txtStatement.Text = .Statement.ToString
                Me.txtBillingEmail.Text = .BillingEmail
                Me.txtCCEmails.Text = .CCEmail
                Me.txtBankAccountName.Text = .BankAccountName
                Me.txtBankAccountNumber.Text = .BankAccountNumber
                Me.txtIBAN.Text = .IBAN
                Me.txtBeneficiaryBankName.Text = .BeneficiaryBankName
                Me.txtBeneficiaryBankAdd.Text = .BeneficiaryBankAddress
                Me.txtSwift.Text = .Swift
                Me.txtCreditLimit.Text = .CreditLimit.ToString
                Me.cmbContractMapleName.SelectedValue = .ContractMapleNameID
                Me.cmbContractMapleBank.SelectedValue = .ContractMapleBankID
                Me.cmbAccountManager.SelectedValue = .AccountManagerID
                For Each item In cmbAgreement.Items
                    If item.value = .Agreement Then
                        cmbAgreement.SelectedItem = item
                        Exit For
                    End If
                Next
                '  Me.cmbAgreement.SelectedItem.value = .Agreement
                If Not dsOutboundNames Is Nothing AndAlso Not dsOutboundNames.Tables.Count = 0 AndAlso Not dsOutboundNames.Tables(0).Rows.Count = 0 Then
                    Dim intRowIndex As Integer
                    For Each dr As DataRow In dsOutboundNames.Tables(0).Rows
                        intRowIndex = Me.dgOutboundNames.Rows.Add
                        Me.dgOutboundNames.Rows(intRowIndex).Cells(0).Value = dr.Item(0).ToString
                    Next
                End If
            End With
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not boolSaved Then
            Select Case MsgBox("Do you want to save data?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    btnSave_Click(Me, New System.EventArgs)
                Case MsgBoxResult.No
                    Me.Close()
                Case MsgBoxResult.Cancel
                    Return
            End Select
        Else
            Me.Close()
        End If
    End Sub

    Public Sub FillData()
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
    End Sub


    Public Function CheckValidity() As Boolean
        Dim boolError As Boolean = False
        Try
            If Not IsNumeric(Me.txtPeriod.Text) Then
                ErrorProvider1.SetError(txtPeriod, "Please insert a valid value.")
                boolError = True
            Else
                ErrorProvider1.SetError(txtPeriod, "")
            End If
            If Not IsNumeric(Me.txtStatement.Text) Then
                ErrorProvider1.SetError(txtStatement, "Please insert a valid value.")
                boolError = True
            Else
                ErrorProvider1.SetError(txtStatement, "")
            End If
            If Not IsNumeric(Me.txtCreditLimit.Text) Then
                ErrorProvider1.SetError(txtCreditLimit, "Please insert a valid value.")
                boolError = True
            Else
                ErrorProvider1.SetError(txtCreditLimit, "")
            End If
            If Me.txtCode.Text.Length = 0 Then
                ErrorProvider1.SetError(txtCode, "Please insert a valid value.")
                boolError = True
            Else
                ErrorProvider1.SetError(txtCode, "")
            End If

            If Me.txtCompanyName.Text.Length = 0 Then
                ErrorProvider1.SetError(txtCompanyName, "Please insert a valid value.")
                boolError = True
            Else
                ErrorProvider1.SetError(txtCompanyName, "")
            End If
            If Me.txtBillingEmail.Text.Length = 0 Then
                ErrorProvider1.SetError(Me.txtBillingEmail, "Please insert a valid value.")
                boolError = True
            Else
                ErrorProvider1.SetError(txtBillingEmail, "")
            End If
            If Me.cmbAgreement.SelectedItem Is Nothing OrElse Me.cmbAgreement.SelectedItem.value = -1 Then
                ErrorProvider1.SetError(Me.cmbAgreement, "Please select Agreement type.")
                boolError = True
            Else
                ErrorProvider1.SetError(cmbAgreement, "")
            End If
            If boolError = False And Me.enumEditAdd = Enumerators.EditAdd.Add Then
                If isClientExists(Me.txtCode.Text) Then
                    ErrorProvider1.SetError(txtCode, "This Company ID is already exists.")
                    boolError = True
                Else
                    ErrorProvider1.SetError(txtCode, "")
                End If
            End If
            Return boolError
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function isClientExists(ByVal code As String) As Boolean
        For Each dr As DataRow In gDsMembers.Tables(0).Rows
            If dr.Item("CompanyCode").ToString.ToLower = code.ToLower Then
                Return True
            End If
        Next
        Return False
    End Function


    Private Sub txtCreditLimit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCreditLimit.KeyPress, txtStatement.KeyPress, txtPeriod.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


End Class