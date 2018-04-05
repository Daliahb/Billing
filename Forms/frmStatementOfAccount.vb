Public Class frmStatementOfAccount

    Friend boolSendEmail As Boolean = False
    Dim enumClientStatus As Enumerators.ClientStatus
    Dim dsStatmentNotes As DataSet

    Public Sub New(enumClientStatus As Enumerators.ClientStatus)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumClientStatus = enumClientStatus
    End Sub

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

        'Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        Me.cmbClientCode.SelectedIndex = 0

        FillDataGrid()

    End Sub

    Private Sub FillDataGrid()
        dsStatmentNotes = odbaccess.GetClientStatemntNotes(0)
        Dim ds As DataSet = odbaccess.GetStatementOfAccount(enumClientStatus)
        Dim dLastDate As Date
        Dim dblAmount As Double
        Dim intCounter, intRowIndex As Integer
        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 Then
            ' Fill Form DataGrid
            For Each drrrrr As DataRow In ds.Tables(0).Rows
                intRowIndex = Me.DataGridView1.Rows.Add
                With Me.DataGridView1.Rows(intRowIndex)
                    .Cells(0).Value = drrrrr.Item("fk_client")
                    .Cells(1).Value = intCounter + 1
                    .Cells(3).Value = drrrrr.Item("Company_Code")
                    .Cells(4).Value = CType(drrrrr.Item("enumClientStatus"), Enumerators.ClientStatus).ToString()
                    .Cells(5).Value = drrrrr.Item("AccountManager")
                    .Cells(6).Value = Math.Round(CDbl(drrrrr.Item("BeginingBalance")), 2)
                    '   .Cells(6).Value = dr.Item("Credit")
                    '   .Cells(7).Value = dr.Item("Debit")
                    Dim dblBalance As Double
                    dblBalance = (CDbl(drrrrr.Item("BeginingBalance")) + CDbl(drrrrr.Item("Purchase")) + CDbl(drrrrr.Item("ClientPayment")) + CDbl(drrrrr.Item("VouchersCredit")) - CDbl(drrrrr.Item("Invoice")) - CDbl(drrrrr.Item("MaplePayment")) - CDbl(drrrrr.Item("VouchersDebit")))
                    If Not drrrrr.Item("fk_client") Is DBNull.Value Then
                        getLastPaymentDate(ds.Tables(1), CInt(drrrrr.Item("fk_client")), dLastDate, dblAmount)
                    End If

                    .Cells(9).Value = Math.Round(dblBalance, 2)
                    .Cells(10).Value = CDate(dLastDate).ToString("yyyy-MM-dd")
                    .Cells(11).Value = dblAmount
                    .Cells(12).Value = drrrrr.Item("Credit_Limit")


                    Dim intDiff As Long
                    intDiff = DateDiff(DateInterval.Day, dLastDate, Now())

                    If intDiff > 21 And dblBalance < 0 Then
                        .DefaultCellStyle.BackColor = Color.RosyBrown
                        .Cells(13).Value = intDiff
                    End If

                    ' .Cells(14).Value = dr.Item("isSentEmail")
                    If Not drrrrr.Item("fk_client") Is DBNull.Value Then
                        .Cells(15).Value = CheckNotes(CLng(drrrrr.Item("fk_client")))
                    End If

                    intCounter += 1
                End With
            Next
        End If
    End Sub

    Public Sub getLastPaymentDate(ByVal dt As System.Data.DataTable, ByVal lClientID As Integer, ByRef dLastDate As String, ByRef dblAmount As Double)
        Try
            dLastDate = Nothing
            dblAmount = 0
            For Each dr As DataRow In dt.Rows
                If Not dr.Item("fk_client") Is DBNull.Value Then
                    If CInt(dr.Item("fk_client")) = lClientID Then
                        If Not dr.Item("Insert_Date") Is DBNull.Value Then
                            dLastDate = CDate(dr.Item("Insert_Date")).ToString("yyyy/MM/dd")
                        End If
                        If Not dr.Item("Amount") Is DBNull.Value Then
                            dblAmount = Math.Round(CDbl(dr.Item("Amount")), 2)
                        End If

                        If Not dr.Item("DataFrom") Is DBNull.Value Then
                            If dr.Item("DataFrom").ToString = "mp" Then
                                dblAmount = -dblAmount
                            End If
                        End If

                        Exit For
                    End If
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function CheckNotes(lClientID As Long) As String
        If Not dsStatmentNotes Is Nothing AndAlso Not dsStatmentNotes.Tables.Count = 0 AndAlso Not dsStatmentNotes.Tables(0).Rows.Count = 0 Then
            For Each row As DataRow In dsStatmentNotes.Tables(0).Rows
                If row.Item("FK_Client") = lClientID Then
                    Return row.Item("Note").ToString
                End If
            Next
        End If
        Return ""
    End Function

#Region "Controls Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub ckbDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCode.CheckedChanged
        Me.cmbClientCode.Enabled = Me.chkCode.Checked
    End Sub


    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
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

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
#End Region


    Public Sub generateSearchCrytiria(ByRef lClientID As Long, ByRef boolEmail As Boolean, ByRef boolSent As Boolean, ByRef boolPeriodDate As Boolean, ByRef dtFrom As Date, ByRef dtTo As Date, ByRef boolInsertDate As Boolean, ByRef dtInsertDate As Date)
        Try
            If Me.chkCode.Checked Then
                lClientID = CLng(Me.cmbClientCode.SelectedValue)
            Else
                lClientID = 0
            End If

            'If Me.chkEmail.Checked Then
            '    boolEmail = True
            '    If Me.rbSent.Checked Then
            '        boolSent = True
            '    Else
            '        boolSent = False
            '    End If
            'Else
            '    boolEmail = False
            'End If

            'If Me.chkPeriodDate.Checked Then
            '    boolPeriodDate = True
            '    dtFrom = Me.dtpFrom.Value.Date
            '    dtTo = Me.dtpTo.Value.Date
            'Else
            '    boolPeriodDate = False
            'End If
            'If Me.chkInsertDate.Checked Then
            '    boolInsertDate = True
            '    dtInsertDate = CDate(Me.cmbBillingDates.SelectedValue.Date)
            'Else
            '    boolInsertDate = False
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fillComboBoxes()
        'Try
        '    If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
        '        Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
        '        Me.cmbClientCode.DisplayMember = "CompanyCode"
        '        Me.cmbClientCode.ValueMember = "ID"
        '    Else
        '        gDsMembers = odbaccess.GetClientsDS
        '        If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
        '            fillComboBoxes()
        '        End If
        '    End If

        '    Dim DsDates As New DataSet
        '    DsDates = odbaccess.GetBillingDatessDS
        '    If Not DsDates Is Nothing AndAlso Not DsDates.Tables.Count = 0 AndAlso Not DsDates.Tables(0).Rows.Count = 0 Then
        '        Me.cmbBillingDates.DataSource = DsDates.Tables(0)
        '        Me.cmbBillingDates.DisplayMember = "Insert_Date"
        '        Me.cmbBillingDates.ValueMember = "Insert_Date"
        '    End If
        'Catch ex As Exception

        'End Try

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
        '   SendEmails(False, strConfirmationNote)
    End Sub

    Private Sub btnSendTestEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendTestEmails.Click
        Dim strConfirmationNote As String = "Are you sure you want to send Test Emails to " & My.Settings.TestEmail & "?"
        '  SendEmails(True, strConfirmationNote)

    End Sub

    Public Sub SendEmails(ByVal isTestEmails As Boolean, ByVal strConfirmationNote As String)
        Dim strInvoiceID As New System.Text.StringBuilder
        Dim strInsertDate As Date

        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            If CBool(dr.Cells(2).Value) = True Then
                strInvoiceID.Append(dr.Cells(0).Value.ToString + ",")
            End If
        Next

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

    Private Sub AddNoteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddNoteToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim lClientID As Long
            lClientID = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
            Dim frm As New frmClientTransactionNote(lClientID)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.DataGridView1.SelectedRows(0).Cells(15).Value = frm.strNote
            End If

        End If
    End Sub
End Class
