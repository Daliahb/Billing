﻿Public Class frmPaymentBankFees

    Dim lPaymentID As Long
    Dim dblFees As Double
    Public isClientPayment, boolDone As Boolean


    Public Sub New(ByVal lID As Integer, ByVal dblFees As Double, ByVal isClientPayment As Boolean)
        ' This call is required by the designer.
        InitializeComponent()

        Me.lPaymentID = lID
        Me.dblFees = dblFees
        Me.isClientPayment = isClientPayment

        Me.lblFees.Text = dblFees.ToString

        If isClientPayment Then
            Me.PanelClientPayment.Visible = True
        Else
            Me.PanelMaplePayment.Visible = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If CheckValidation() Then
            If isClientPayment Then 'came from ClientPayments form
                If odbaccess.InsertClientBankFees(Me.lPaymentID, CDbl(Me.txtCredit.Text), CDbl(Me.txtDebit.Text)) Then
                    boolDone = True
                    MsgBox("Transaction done successfully")
                    Me.Close()
                Else
                    MsgBox("An error occured, please try again later")
                End If
            Else 'came from MaplePayments form
                If odbaccess.InsertMapleBankFees(Me.lPaymentID, CDbl(Me.txtCredit.Text), CDbl(Me.txtDebit.Text)) Then
                    boolDone = True
                    MsgBox("Transaction done successfully")
                    Me.Close()
                Else
                    MsgBox("An error occured, please try again later")
                End If
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Function CheckValidation() As Boolean
       
        '  If Not (CDbl(Me.txtCredit.Text) + CDbl(Me.txtDebit.Text) = Me.dblFees) Then
        If (CDbl(Me.txtCredit.Text) > Me.dblFees) Then
            ErrorProvider1.SetError(txtCredit, "Credit should not be greater than Bank Fees.")
            Return False
        Else
            ErrorProvider1.SetError(txtCredit, "")
        End If

        If (CDbl(Me.txtDebit.Text) > Me.dblFees) Then
            ErrorProvider1.SetError(txtDebit, "Debit should not be greater than Bank Fees.")
            Return False
        Else
            ErrorProvider1.SetError(txtDebit, "")
        End If
        Return True
    End Function

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
       
    End Sub

    Private Sub txtCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCredit.KeyPress, txtDebit.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDebit.TextChanged
        If Me.txtDebit.Text = "" Then
            Me.txtDebit.Text = "0"
        End If
        'Me.txtCredit.Text = CStr(Math.Round(Me.dblFees - CDbl(txtDebit.Text), 3))
    End Sub

    Private Sub txtCredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCredit.TextChanged
        If Me.txtCredit.Text = "" Then
            Me.txtCredit.Text = "0"
        End If
        '   Me.txtDebit.Text = CStr(Math.Round(Me.dblFees - CDbl(txtCredit.Text), 3))
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If isClientPayment Then
            Me.txtCredit.Text = dblFees.ToString
        Else
            Me.txtDebit.Text = dblFees.ToString
        End If
    End Sub
End Class

