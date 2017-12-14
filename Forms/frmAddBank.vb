Public Class frmAddBank

    Public enumEditAdd As New Enumerators.EditAdd
    Public lID As Long
    Public oBank As New Bank
    Public boolSaved As Boolean

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByRef oBank As Bank = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumEditAdd = enumEditAdd
        Me.oBank = oBank
    End Sub

    Private Sub frmAddBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '      'Me.BackColor = gBackColor

        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Bank"

            SetControls()

        End If
        boolSaved = True
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try

            'If Not CheckValidity() Then
            '    Return
            'End If

            FillObject()


            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.insertBank(oBank)
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditBank(oBank)
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
        Me.txtBankName.Text = ""
        Me.txtBankAccountName.Text = ""
        Me.txtBankAccountNo.Text = ""
        Me.txtIBAN.text = ""
        Me.txtBeneficiaryBankName.text = ""
        Me.txtBeneficiaryBankAdd.text = ""
        Me.txtSwift.Text = ""
        Me.oBank = New Bank
        Me.txtABARouting.Text = ""
    End Sub

    Public Sub FillObject()
        If oBank Is Nothing Then
            oBank = New Bank
        End If
        With Me.oBank
            .BankName = Me.txtBankName.Text
            .BankAccountName = Me.txtBankAccountName.Text
            .BankAccountNumber = Me.txtBankAccountNo.Text
            .IBAN = Me.txtIBAN.Text
            .BeneficiaryBankName = Me.txtBeneficiaryBankName.Text
            .BeneficiaryBankAddress = Me.txtBeneficiaryBankAdd.Text
            .Swift = Me.txtSwift.Text
            .ABARouting = Me.txtABARouting.Text
        End With
    End Sub

    Public Sub SetControls()
        If Not oBank.Id = 0 Then

            With Me.oBank
                Me.txtBankName.Text = .BankName
                Me.txtBankAccountName.Text = .BankAccountName
                Me.txtBankAccountNo.Text = .BankAccountNumber
                Me.txtIBAN.Text = .IBAN
                Me.txtBeneficiaryBankName.Text = .BeneficiaryBankName
                Me.txtBeneficiaryBankAdd.Text = .BeneficiaryBankAddress
                Me.txtSwift.Text = .Swift
                Me.txtABARouting.Text = .ABARouting
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

End Class