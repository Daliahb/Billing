Public Class frmApproveInvoicesDate

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillComboBoxes()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If MsgBox("Are you sure you are approving the invoices for " + Me.cmbBillingDates.Text + "?", vbYesNo) = vbYes Then
            Dim ds As DataSet
            Me.Hide()
            ds = odbaccess.ApproveInvoices(CDate(Me.cmbBillingDates.SelectedValue.Date))
            'ds = odbaccess.GetEmailsInfo("2017-01-16")
            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                '  SendEmails(ds)
                MsgBox("Operation done successfuly." & vbCrLf & "Invoices are posted.")
            Else

                MsgBox("There is no new imported data.")
                Return

            End If
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub fillComboBoxes()
        Try

            Dim DsDates As New DataSet
            DsDates = odbaccess.GetBillingDatessDS
            If Not DsDates Is Nothing AndAlso Not DsDates.Tables.Count = 0 AndAlso Not DsDates.Tables(0).Rows.Count = 0 Then
                Me.cmbBillingDates.DataSource = DsDates.Tables(0)
                Me.cmbBillingDates.DisplayMember = "Insert_Date"
                Me.cmbBillingDates.ValueMember = "Insert_Date"
            End If
        Catch ex As Exception

        End Try

    End Sub

  
End Class

