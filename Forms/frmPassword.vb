Public Class frmPassword

    Public boolRight As Boolean
    Public Sub New(ByRef boolRight As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Label2.Visible = False
        If Me.txtOldPassword.Text = gUser.Password Then
            boolRight = True
            Me.Close()
        Else
            boolRight = False
            Me.Label2.Visible = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class

