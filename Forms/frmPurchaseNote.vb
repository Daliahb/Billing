Imports System.Net.Mail
Imports System.Net.Mime

Public Class frmPurchaseNote

    Dim strNote As String
    Dim lId As Integer
    Public boolDone As Boolean

    Public Sub New(ByVal strNote As String, ByVal lId As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.strNote = strNote
        Me.lId = lId
        Me.txtMessage.Text = strNote
    End Sub

    Private Sub frmSendEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '    'Me.BackColor = gBackColor

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If odbaccess.AddPurchaseNote(Me.txtMessage.Text, lId) Then
            Me.boolDone = True
            MsgBox("Operation done successfuly.")
            Me.Close()
        End If
    End Sub

    Public Sub CenterButtons()
        Me.Panel1.Left = CInt((Me.ClientSize.Width / 2) - (Panel1.Width / 2))
    End Sub

    Private Sub frm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterButtons()
    End Sub

End Class
