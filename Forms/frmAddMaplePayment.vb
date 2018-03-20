Public Class frmAddMaplePayment

    Public enumEditAdd As New Enumerators.EditAdd
    Public boolSaved, boolClientsBanks As Boolean
    Dim dgRow As DataGridViewRow
    Public lClientId, lPaymentId, lNewBankID As Long
    Public dblAmount, dblRecievedAmount As Double
    Public dDate As Date
    Public strNote, strBank As String


    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, lClientID As Long, Optional ByVal dgRow As DataGridViewRow = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumEditAdd = enumEditAdd
        Me.dgRow = dgRow
        Me.lClientId = lClientID
    End Sub

    Private Sub frmAddBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '      'Me.BackColor = gBackColor
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        FillDataset()

        cmbClientCode.SelectedValue = -1

        'If Not gDsClientsBanks Is Nothing AndAlso Not gDsClientsBanks.Tables.Count = 0 AndAlso Not gDsClientsBanks.Tables(0).Rows().Count = 0 Then
        '    boolClientsBanks = True
        'Else
        '    boolClientsBanks = False
        'End If
        'FindClientBank()

        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Client Payment - " & gCountry.ToString

            SetControls()
        Else
            Me.Text = Me.Text & " - " & gCountry.ToString
        End If

        'check permission
        If gUser.oColRoles.find(Enumerators.Roles.Manage_RecievedAmount) Then
            Me.Button1.Enabled = True
        End If
        If Not Me.lClientId = 0 Then
            Me.cmbClientCode.SelectedValue = lClientId
        End If
        boolSaved = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try

            If Not CheckValidity() Then
                Return
            End If

            FillObject()

            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.InsertMaplePayment(lClientId, dblAmount, dblRecievedAmount, dDate, strNote, lNewBankID)
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditMaplePayment(lPaymentId, lClientId, dblAmount, dblRecievedAmount, dDate, strNote, lNewBankID)
            End If

            If boolError Then
                MsgBox("Operation done successfully.")
                '  If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                Me.Close()
                'Else
                '    Me.ResetForm()
                'End If
            Else
            MsgBox("Error occured!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtAmount.Text = "0.0"
        Me.txtRecievedAmount.Text = "0.0"
        Me.txtNote.Text = ""
        Me.cmbClientCode.SelectedIndex = 0
        Me.cmbBanks.SelectedIndex = 0
        Me.DateTimePicker1.Value = Now().Date
    End Sub

    Public Sub FillObject()
        lClientId = CLng(Me.cmbClientCode.SelectedValue)
        dblAmount = CDbl(Me.txtAmount.Text)
        dblRecievedAmount = CDbl(Me.txtRecievedAmount.Text)
        strNote = Me.txtNote.Text
        dDate = Me.DateTimePicker1.Value
        'If Me.chkBank.Checked Then
        lNewBankID = CLng(Me.cmbBanks.SelectedValue)
        strBank = Me.cmbBanks.Text
        'Else
        'strBank = Me.txtBankAccount.Text
        'End If
    End Sub

    Public Sub SetControls()
        lPaymentId = CLng(dgRow.Cells(0).Value)
        Me.cmbClientCode.Text = dgRow.Cells(2).Value.ToString
        Me.txtAmount.Text = dgRow.Cells(3).Value.ToString
        Me.txtRecievedAmount.Text = dgRow.Cells(4).Value.ToString
        '  Me.txtBankAccount.Text = dgRow.Cells(6).Value.ToString
        For i As Integer = 0 To Me.cmbBanks.Items.Count - 1
            If Me.cmbBanks.Items(i).Row.ItemArray(1) = dgRow.Cells(6).Value.ToString Then
                Me.cmbBanks.SelectedIndex = i
                Exit For
            End If
        Next
                Me.txtNote.Text = dgRow.Cells(7).Value.ToString
                Me.DateTimePicker1.Value = CDate(dgRow.Cells(8).Value)
                Me.txtBankFees.Text = dgRow.Cells(5).Value.ToString

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

    Public Function CheckValidity() As Boolean
        Dim boolError = True

        'If Me.txtAmount.Text.Length = 0 OrElse Not IsNumeric(Me.txtAmount.Text) OrElse CInt(Me.txtAmount.Text) = 0 Then
        '    ErrorProvider1.SetError(txtAmount, "Insert a valid value.")
        '    boolError = False
        'Else
        '    ErrorProvider1.SetError(txtAmount, "")
        'End If
        If Me.txtRecievedAmount.Text.Length = 0 OrElse Not IsNumeric(Me.txtAmount.Text) Then
            ErrorProvider1.SetError(txtRecievedAmount, "Insert a valid value.")
            boolError = False
        Else
            ErrorProvider1.SetError(txtRecievedAmount, "")
        End If
        If Me.cmbClientCode.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbClientCode, "Select client from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbClientCode, "")
        End If
        If Me.cmbBanks.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbBanks, "Select bank account from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbBanks, "")
        End If
        Return boolError
    End Function

    Public Sub FillDataset()

        If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
            Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
            Me.cmbClientCode.DisplayMember = "CompanyCode"
            Me.cmbClientCode.ValueMember = "ID"
        Else
            gDsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                FillDataset()
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
    End Sub

    Private Sub cmbClientCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClientCode.SelectedIndexChanged
        '        FindClientBank()
    End Sub

    Private Sub txtRecievedAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecievedAmount.TextChanged
        If IsNumeric(Me.txtAmount.Text) AndAlso IsNumeric(Me.txtRecievedAmount.Text) AndAlso Not CDbl(Me.txtRecievedAmount.Text) = 0 Then
            Me.txtBankFees.Text = (CDbl(Me.txtAmount.Text) - CDbl(Me.txtRecievedAmount.Text)).ToString
        Else
            Me.txtBankFees.Text = "0.0"
        End If
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        If IsNumeric(Me.txtAmount.Text) AndAlso IsNumeric(Me.txtRecievedAmount.Text) AndAlso Not CDbl(Me.txtRecievedAmount.Text) = 0 Then
            Me.txtBankFees.Text = (CDbl(Me.txtAmount.Text) - CDbl(Me.txtRecievedAmount.Text)).ToString
        Else
            Me.txtBankFees.Text = "0.0"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim boolRight As Boolean

        Dim frm As New frmPassword(boolRight)
        frm.ShowDialog()
        If frm.boolRight = True Then
            Me.txtRecievedAmount.Enabled = True
            Me.txtRecievedAmount.Focus()
        End If

    End Sub
    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
End Class