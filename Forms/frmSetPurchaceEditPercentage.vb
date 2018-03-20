Imports System.Net.Mail
Imports System.Net.Mime

Public Class frmSetPurchaceEditPercentage

    Dim mail As New MailMessage()
    Dim strEmails As String

    Private Sub SetTestEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        Me.txtMessage.Text = gPurchaseEditPercentage.ToString
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' My.Settings.TestEmail = Me.txtMessage.Text
        If odbaccess.SetPurchaceEditPurcentage(CDbl(Me.txtMessage.Text)) Then
            MsgBox("Operation done successfuly.")
            gPurchaseEditPercentage = CDbl(Me.txtMessage.Text)
            Me.Close()
        Else
            MsgBox("An error occured! Please try again.")
        End If


    End Sub


    Public Sub CenterButtons()
        Me.Panel1.Left = CInt((Me.ClientSize.Width / 2) - (Panel1.Width / 2))
    End Sub

    Private Sub frmSendEmail_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterButtons()
    End Sub

End Class
