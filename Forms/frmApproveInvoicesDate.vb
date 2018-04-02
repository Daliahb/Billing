Public Class frmApproveInvoicesDate

    Dim DsDates As New DataSet

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
            ds = odbaccess.ApproveInvoices(CDate(Me.cmbBillingDates.SelectedValue.Date), CInt(cmbPeriod.Text))

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then

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
            DsDates = odbaccess.GetBillingDatessDS
            If Not DsDates Is Nothing AndAlso Not DsDates.Tables.Count = 0 AndAlso Not DsDates.Tables(0).Rows.Count = 0 Then
                Me.cmbBillingDates.DataSource = DsDates.Tables(0)
                Me.cmbBillingDates.DisplayMember = "Insert_Date"
                Me.cmbBillingDates.ValueMember = "Insert_Date"
            End If

            Me.cmbPeriod.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPeriod_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPeriod.SelectedIndexChanged
        If Not DsDates Is Nothing AndAlso Not DsDates.Tables.Count = 0 Then
            Dim dv As New DataView(DsDates.Tables(0))
            dv.RowFilter = "InvoicePeriod = " & CInt(Me.cmbPeriod.Text).ToString
            Me.cmbBillingDates.DataSource = dv
            Me.cmbBillingDates.ValueMember = "Insert_Date"
            Me.cmbBillingDates.DisplayMember = "Insert_Date"
        End If
    End Sub
End Class

