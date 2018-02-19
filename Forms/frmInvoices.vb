Public Class frmInvoices

    Friend boolSendEmail As Boolean = False

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        'check permission
        For Each oRole As Role In gUser.oColRoles
            Select Case CType(oRole.ID, Enumerators.Roles)
                Case Enumerators.Roles.Post_Invoices_Send_Emails
                    boolSendEmail = True
            End Select
        Next

        fillComboBoxes()

        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        Me.cmbClientCode.SelectedIndex = -1
        Me.cmbPeriod.SelectedIndex = 0
        Try
            Me.cmbBillingDates.SelectedIndex = 0
            Me.chkInsertDate.Checked = True
        Catch ex As Exception

        End Try

    End Sub

#Region "Controls Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '  Dim oColEvents As New ColEvents
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer

        Dim lClientID As Long
        Dim boolPeriodDate, boolInsertDate, boolEmail, boolSent As Boolean
        Dim dtFrom, dtTo, dInsertDate As Date
        Dim dTotalDuration As Double = 0
        Dim dTotalCharges As Double = 0
        Dim intPeriod As Integer
        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            chkClearAll_CheckedChanged(Me, New System.EventArgs)
            generateSearchCrytiria(lClientID, boolEmail, boolSent, boolPeriodDate, dtFrom, dtTo, boolInsertDate, dInsertDate, intPeriod)

            If Me.chkInsertDate.Checked Then
                Me.DataGridView1.Columns(2).Visible = True
            Else
                Me.DataGridView1.Columns(2).Visible = False
            End If

            ds = odbaccess.GetInvoicesSearch(lClientID, boolEmail, boolSent, boolPeriodDate, dtFrom, dtTo, boolInsertDate, dInsertDate, intPeriod)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    intRowIndex = Me.DataGridView1.Rows.Add
                    With Me.DataGridView1.Rows(intRowIndex)
                        .Cells(0).Value = dr.Item("ID")
                        .Cells(1).Value = intCounter + 1
                        .Cells(3).Value = dr.Item("Client_Code")
                        .Cells(4).Value = CDate(dr.Item("date")).ToString("yyyy-MM-dd")
                        .Cells(5).Value = dr.Item("Amount")
                        .Cells(6).Value = dr.Item("Duration")
                        .Cells(7).Value = CDate(dr.Item("Billing_Period_From")).ToString("yyyy-MM-dd")
                        .Cells(8).Value = CDate(dr.Item("Billing_Period_To")).ToString("yyyy-MM-dd")
                        .Cells(9).Value = dr.Item("InvoicePeriod").ToString
                        .Cells(10).Value = dr.Item("AccountManager").ToString
                        .Cells(11).Value = dr.Item("Bank_Name")
                        .Cells(12).Value = dr.Item("isSentEmail")

                        dTotalDuration += CDbl(dr.Item("Duration"))
                        dTotalCharges += CDbl(dr.Item("Amount"))
                        intCounter += 1
                    End With
                Next
                'Me.lblTotalCharges.Text = Math.Round(dTotalCharges, 3).ToString
                'Me.lblTotalDuration.Text = dTotalDuration.ToString
                Me.Text = "Invoices - Total Charges= " & Math.Round(dTotalCharges, 3).ToString & "      Total Duration= " & dTotalDuration.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ckbDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCode.CheckedChanged
        Me.cmbClientCode.Enabled = Me.chkCode.Checked
    End Sub


    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPeriodDate.CheckedChanged
        Me.dtpFrom.Enabled = Me.chkPeriodDate.Checked
        Me.dtpTo.Enabled = Me.chkPeriodDate.Checked
    End Sub


    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Try
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(1).Value = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkInsertDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInsertDate.CheckedChanged
        Me.cmbBillingDates.Enabled = Me.chkInsertDate.Checked
        If Me.chkInsertDate.Checked And boolSendEmail Then
            Me.Panel2.Enabled = True
        Else
            Me.Panel2.Enabled = False
        End If
        'If Me.cmbBillingDates.SelectedIndex = 0 And Me.chkInsertDate.Checked Then
        '    If boolSendEmail Then
        '        Me.Panel2.Enabled = True
        '    End If
        'Else
        '    Me.Panel2.Enabled = False
        'End If
    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
#End Region


    Public Sub generateSearchCrytiria(ByRef lClientID As Long, ByRef boolEmail As Boolean, ByRef boolSent As Boolean, ByRef boolPeriodDate As Boolean, ByRef dtFrom As Date, ByRef dtTo As Date, ByRef boolInsertDate As Boolean, ByRef dtInsertDate As Date, ByRef intPeriod As Integer)
        Try
            If Me.chkCode.Checked Then
                lClientID = CLng(Me.cmbClientCode.SelectedValue)
            Else
                lClientID = 0
            End If

            If Me.chkEmail.Checked Then
                boolEmail = True
                If Me.rbSent.Checked Then
                    boolSent = True
                Else
                    boolSent = False
                End If
            Else
                boolEmail = False
            End If

            If Me.chkPeriodDate.Checked Then
                boolPeriodDate = True
                dtFrom = Me.dtpFrom.Value.Date
                dtTo = Me.dtpTo.Value.Date
            Else
                boolPeriodDate = False
            End If
            If Me.chkInsertDate.Checked Then
                boolInsertDate = True
                dtInsertDate = CDate(Me.cmbBillingDates.SelectedValue.Date)
            Else
                boolInsertDate = False
            End If

            If Me.chkPeriod.Checked Then
                intPeriod = CInt(Me.cmbPeriod.Text)
            Else
                intPeriod = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fillComboBoxes()
        Try
            'Dim DsMembers As New DataSet
            'DsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
                Me.cmbClientCode.DisplayMember = "CompanyCode"
                Me.cmbClientCode.ValueMember = "ID"
            Else
                gDsMembers = odbaccess.GetClientsDS
                If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                    fillComboBoxes()
                End If
            End If

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


    Dim intColumnIndex As Integer

    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo
            ht = Me.DataGridView1.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                DataGridView1.ContextMenuStrip = ContextMenuStrip1
            ElseIf ht.Type = DataGridViewHitTestType.ColumnHeader Then
                Me.intColumnIndex = ht.ColumnIndex
                DataGridView1.ContextMenuStrip = ContextMenuStripHideColumn
            Else
                DataGridView1.ContextMenuStrip = ContextMenuStrip1
            End If
        End If
    End Sub

    Private Sub HideColumnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideColumnToolStripMenuItem.Click
        Me.DataGridView1.Columns(intColumnIndex).Visible = False
    End Sub


    Private Sub ShowAllColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllColumnsToolStripMenuItem.Click
        For i As Integer = 1 To Me.DataGridView1.Columns.Count - 1
            Me.DataGridView1.Columns(i).Visible = True
        Next
    End Sub

    Private Sub chkEmail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmail.CheckedChanged
        Me.rbSent.Enabled = chkEmail.Checked
        Me.rbNotSent.Enabled = chkEmail.Checked
    End Sub

    Private Sub cmbBillingDates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillingDates.SelectedIndexChanged
        '  If Me.cmbBillingDates.SelectedIndex = 0 And Me.chkInsertDate.Checked Then
        If Me.chkInsertDate.Checked And boolSendEmail Then
            Me.Panel2.Enabled = True
        Else
            Me.Panel2.Enabled = False
        End If
        'Else
        'Me.Panel2.Enabled = False
        'End If
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        Me.chkSelectAll.Checked = False
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            dr.Cells(2).Value = True
        Next
    End Sub

    Private Sub chkClearAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAll.CheckedChanged
        Me.chkClearAll.Checked = False
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            dr.Cells(2).Value = False
        Next
    End Sub

    Private Sub btnSendEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmails.Click
        Dim strConfirmationNote As String = "Are you sure you want to send emails to the clients?"
        SendEmails(False, strConfirmationNote)
    End Sub

    Private Sub btnSendTestEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendTestEmails.Click
        Dim strConfirmationNote As String = "Are you sure you want to send Test Emails to " & My.Settings.TestEmail & "?"
        SendEmails(True, strConfirmationNote)

    End Sub

    Public Sub SendEmails(ByVal isTestEmails As Boolean, ByVal strConfirmationNote As String)
        Dim strInvoiceID As New System.Text.StringBuilder
        Dim strInsertDate As Date

        'Check if to send an email to clients with duration 0
        If Me.chkDurationZero.Checked Then
            For Each dr As DataGridViewRow In Me.DataGridView1.Rows
                If CBool(dr.Cells(2).Value) = True And (CInt(dr.Cells(6).Value) <> 0) Then
                    strInvoiceID.Append(dr.Cells(0).Value.ToString + ",")
                End If
            Next
        Else
            For Each dr As DataGridViewRow In Me.DataGridView1.Rows
                If CBool(dr.Cells(2).Value) = True Then
                    strInvoiceID.Append(dr.Cells(0).Value.ToString + ",")
                End If
            Next
        End If


        If Not strInvoiceID.ToString.Length = 0 Then
            If MsgBox(strConfirmationNote, vbYesNo) = vbYes Then

                strInsertDate = CDate(Me.DataGridView1.SelectedRows(0).Cells(4).Value)

                Dim frm As New SendEmails
                frm.SendEmailByInvoiceID(strInvoiceID.ToString, strInsertDate, isTestEmails)

            End If
        Else
            MsgBox("Please select the invoices you want to send by email.")
        End If
    End Sub

    Private Sub chkPeriod_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPeriod.CheckedChanged
        Me.cmbPeriod.Enabled = Me.chkPeriod.Checked
    End Sub
End Class
