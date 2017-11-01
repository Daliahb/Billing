Public Class frmEditPurchace

    Dim lPurchaseID As Long
    Public boolDone As Boolean
    Dim dblAmount, dblDuration As Double

    Public Sub New(ByVal lID As Integer, ByVal strClientCode As String, ByVal dblAmount As Double, ByVal dblDuration As Double)
        ' This call is required by the designer.
        InitializeComponent()
        Me.dblAmount = dblAmount
        Me.dblDuration = dblDuration
        Me.lPurchaseID = lID
        Me.lblCode.Text = strClientCode
        Me.txtAmount.Text = dblAmount.ToString
        Me.lblAmount.Text = dblAmount.ToString
        Me.txtDuration.text = dblDuration.ToString
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If CheckValidation() Then
            If MsgBox("Are you sure you want to change the Total Charges and/or Total Duration?", MsgBoxStyle.YesNo) = vbYes Then
                If odbaccess.EditPurchaseTotalCharges(Me.lPurchaseID, CDbl(Me.txtAmount.Text), CDbl(Me.txtDuration.Text)) Then
                    boolDone = True
                    MsgBox("Operation done successfully")
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
        Dim dblPercent As Double = (Me.dblAmount * gPurchaseEditPercentage)
        '1- if the difference less than 1$ then return true
        If (Math.Round(Math.Abs(dblAmount - CDbl(Me.txtAmount.Text)), 3)) <= 1 Then
            Return True
        End If

        '2- if the new value is less than the old value return true
        If CDbl(Me.txtAmount.Text) < Me.dblAmount Then
            Return True
        End If

        '3 if the new value is bigger than the old value, check the difference if its within percentage limit
        If (Math.Round(Math.Abs(dblAmount - CDbl(Me.txtAmount.Text)), 3) > dblPercent) Then
            ErrorProvider1.SetError(txtAmount, "The difference in the old and new amount should not exceed " + dblPercent.ToString)
            Return False
        Else
            ErrorProvider1.SetError(txtAmount, "")
            Return True
        End If
    End Function

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
    End Sub

    Private Sub txtCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress, txtDuration.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim boolRight As Boolean

        Dim frm As New frmPassword(boolRight)
        frm.ShowDialog()
        If frm.boolRight = True Then
            Me.txtAmount.Enabled = True
            Me.txtAmount.Focus()
        End If
    End Sub
End Class

