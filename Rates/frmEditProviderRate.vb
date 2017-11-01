Public Class frmEditProviderRate

    Dim lID As Long
    Public boolDone As Boolean
    Dim dblRate As Double

    Public Sub New(ByVal lID As Integer, ByVal strCode As String, ByVal dblRate As Double)
        ' This call is required by the designer.
        InitializeComponent()
        Me.dblRate = dblRate
        Me.lID = lID
        Me.lblCode.Text = strCode
        Me.txtAmount.Text = dblRate.ToString
        Me.lblRate.Text = dblRate.ToString
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If MsgBox("Are you sure you want to change the price?", MsgBoxStyle.YesNo) = vbYes Then
            If odbaccess.EditProviderRatePrice(Me.lID, CDbl(Me.txtAmount.Text)) Then
                boolDone = True
                MsgBox("Operation done successfully")
                Me.Close()
            Else
                MsgBox("An error occured, please try again later")
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
    End Sub

    Private Sub txtCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

End Class

