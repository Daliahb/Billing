Public Class frmAddVoucher

    Public enumEditAdd As New Enumerators.EditAdd
    Public boolSaved, boolClientsBanks, doneLoad As Boolean

    Dim lClientId, lPaymentId, lNewBankID, lType As Long
    Dim dblCredit, dblDebit As Double
    Dim dDate As Date
    Public strNote, strBank, strType As String
    Dim dgRow As DataGridViewRow

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal dgRow As DataGridViewRow = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumEditAdd = enumEditAdd
        Me.dgRow = dgRow

    End Sub

    Private Sub frmAddBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '      'Me.BackColor = gBackColor
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        FillDatasets()
        cmbClientCode.SelectedValue = -1

        doneLoad = True
        If Not gDsClientsBanks Is Nothing AndAlso Not gDsClientsBanks.Tables.Count = 0 AndAlso Not gDsClientsBanks.Tables(0).Rows().Count = 0 Then
            boolClientsBanks = True
        Else
            gDsClientsBanks = odbaccess.GetClientsBanksDS
            If Not gDsClientsBanks Is Nothing AndAlso Not gDsClientsBanks.Tables.Count = 0 AndAlso Not gDsClientsBanks.Tables(0).Rows().Count = 0 Then
                boolClientsBanks = False
            Else
                boolClientsBanks = True
            End If

        End If
        Me.FindClientBank()
        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Client Payment"

            SetControls()

        End If
        boolSaved = True
    End Sub

    Public Function CheckValidity() As Boolean
        Dim boolError = True

        If Not IsNumeric(Me.txtCredit.Text) Then
            ErrorProvider1.SetError(txtCredit, "Insert a valid value.")
            boolError = False
        Else
            ErrorProvider1.SetError(txtCredit, "")
        End If
        If Not IsNumeric(Me.txtDebit.Text) Then
            ErrorProvider1.SetError(txtDebit, "Insert a valid value.")
            boolError = False
        Else
            ErrorProvider1.SetError(txtDebit, "")
        End If

        If Me.cmbClientCode.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbClientCode, "Select client from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbClientCode, "")
        End If

        If Me.lNewBankID = 0 Then
            ErrorProvider1.SetError(txtBankAccount, "Bank Account is not assigned.")
            boolError = False
        Else
            ErrorProvider1.SetError(txtBankAccount, "")
        End If
        If boolError = False Then
            Return boolError
        End If
        If CDbl(Me.txtDebit.Text) = 0.0 And CDbl(Me.txtCredit.Text) = 0.0 Then
            ErrorProvider1.SetError(txtDebit, "Insert either Credit or Debit amount.")
            boolError = False
        Else
            ErrorProvider1.SetError(txtDebit, "")
        End If
        Return boolError
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try

            If Not CheckValidity() Then
                Return
            End If

            FillObject()

            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.InsertVoucher(lClientId, dblCredit, dblDebit, dDate, strNote, lNewBankID, lType, strType)
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditVoucher(lPaymentId, lClientId, dblCredit, dblDebit, dDate, strNote, lNewBankID, lType, strType)
            End If
            If boolError Then
                MsgBox("Operation done successfully.")
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
        Me.txtCredit.Text = "0.0"
        Me.txtDebit.Text = "0.0"
        Me.txtNote.Text = ""
        Me.cmbClientCode.SelectedIndex = 0
        Me.DateTimePicker1.Value = Now().Date
        Me.chkBank.Checked = False

    End Sub

    Public Sub FillDatasets()
        If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
            Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
            Me.cmbClientCode.DisplayMember = "CompanyCode"
            Me.cmbClientCode.ValueMember = "ID"
        Else
            gDsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                FillDatasets()
            End If
        End If

        Dim dsBanks As DataSet
        Try
            dsBanks = odbaccess.GetBanksDS
            Me.cmbBanks.DataSource = dsBanks.Tables(0)
            Me.cmbBanks.ValueMember = "ID"
            Me.cmbBanks.DisplayMember = "Bank_Name"
        Catch ex As Exception

        End Try

        Me.cmbType.DataSource = Nothing
        Me.cmbType.Items.Add(New Obj("Dispute", Enumerators.VoucherTypes.Dispute))
        Me.cmbType.Items.Add(New Obj("Voucher", Enumerators.VoucherTypes.Voucher))
        Me.cmbType.ValueMember = "Value"
        Me.cmbType.DisplayMember = "Name"
    End Sub

    Public Sub SetControls()
        lPaymentId = CLng(dgRow.Cells(0).Value)
        Me.cmbClientCode.Text = dgRow.Cells(2).Value.ToString
        Me.txtCredit.Text = dgRow.Cells(4).Value.ToString
        Me.txtDebit.Text = dgRow.Cells(3).Value.ToString
        Me.txtBankAccount.Text = dgRow.Cells(5).Value.ToString
        Me.txtNote.Text = dgRow.Cells(6).Value.ToString
        Me.DateTimePicker1.Value = CDate(dgRow.Cells(7).Value)
        For i As Integer = 0 To Me.cmbType.Items.Count - 1
            If Me.cmbType.Items(i).name = dgRow.Cells(10).Value.ToString Then
                Me.cmbType.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub

    Public Sub FillObject()
        lClientId = CLng(Me.cmbClientCode.SelectedValue)
        dblCredit = CDbl(Me.txtCredit.Text)
        dblDebit = CDbl(Me.txtDebit.Text)
        strNote = Me.txtNote.Text
        dDate = Me.DateTimePicker1.Value
        If Me.chkBank.Checked Then
            lNewBankID = CLng(Me.cmbBanks.SelectedValue)
            strBank = Me.cmbBanks.Text
        Else
            strBank = Me.txtBankAccount.Text
        End If
        lType = CLng(cmbType.SelectedItem.value)
        If CType(cmbType.SelectedItem.value, Enumerators.VoucherTypes) = Enumerators.VoucherTypes.Dispute Then
            strType = "Dispute"
        Else
            strType = "Voucher"
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBank.CheckedChanged
        Me.cmbBanks.Enabled = Me.chkBank.Checked
    End Sub

    Public Sub FindClientBank()
        Try
            If boolClientsBanks Then
                For Each dr As DataRow In gDsClientsBanks.Tables(0).Rows
                    If CDbl(dr.Item("ClientID")) = CDbl(Me.cmbClientCode.SelectedValue) Then
                        Me.txtBankAccount.Text = dr.Item("Bank_Name").ToString
                        lNewBankID = CLng(dr.Item("BankID").ToString)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbClientCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClientCode.SelectedIndexChanged
        If doneLoad Then
            FindClientBank()
        End If

    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
End Class