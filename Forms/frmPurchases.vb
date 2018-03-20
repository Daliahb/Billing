Public Class frmPurchases

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        'check permission

        fillComboBoxes()

        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        Me.cmbClientCode.SelectedIndex = 0
        Me.cmbPeriod.SelectedIndex = 0
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
        Dim enumStatus As Enumerators.ClientStatus
        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            generateSearchCrytiria(lClientID, boolPeriodDate, dtFrom, dtTo, boolInsertDate, dInsertDate, enumStatus, intPeriod)

            'If Me.cmbBillingDates.SelectedIndex = 0 And Me.chkInsertDate.Checked Then
            '    Me.DataGridView1.Columns(2).Visible = True
            'Else
            '    Me.DataGridView1.Columns(2).Visible = False
            'End If

            ds = odbaccess.GetPurchasesSearch(lClientID, boolPeriodDate, dtFrom, dtTo, boolInsertDate, dInsertDate, enumStatus, intPeriod)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    intRowIndex = Me.DataGridView1.Rows.Add
                    With Me.DataGridView1.Rows(intRowIndex)
                        .Cells(0).Value = dr.Item("ID")
                        .Cells(1).Value = intCounter + 1
                        .Cells(2).Value = dr.Item("Client_Code")
                        .Cells(3).Value = CDate(dr.Item("insert_date")).ToString("yyyy-MM-dd")
                        .Cells(4).Value = dr.Item("Amount")
                        .Cells(5).Value = dr.Item("Duration")
                        .Cells(6).Value = CDate(dr.Item("Billing_Period_From")).ToString("yyyy-MM-dd")
                        .Cells(7).Value = CDate(dr.Item("Billing_Period_To")).ToString("yyyy-MM-dd")
                        .Cells(8).Value = dr.Item("InvoicePeriod").ToString
                        .Cells(9).Value = dr.Item("AccountManager").ToString
                        .Cells(10).Value = dr.Item("Bank_Name")
                        If Not dr.Item("isConfirmed") Is DBNull.Value Then
                            .Cells(11).Value = CBool(dr.Item("isConfirmed"))
                        Else
                            .Cells(11).Value = False
                        End If
                        .Cells(12).Value = dr.Item("Note")
                        dTotalDuration += CDbl(dr.Item("Duration"))
                        dTotalCharges += CDbl(dr.Item("Amount"))
                        intCounter += 1
                    End With
                Next
                Me.lblTotalCharges.Text = Math.Round(dTotalCharges, 3).ToString
                Me.lblTotalDuration.Text = dTotalDuration.ToString
                '  Me.Text = "Invoices - Total Charges= " & Math.Round(dTotalCharges, 3).ToString & "      Total Duration= " & dTotalDuration.ToString
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

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
#End Region


    Public Sub generateSearchCrytiria(ByRef lClientID As Long, ByRef boolPeriodDate As Boolean, ByRef dtFrom As Date, ByRef dtTo As Date, ByRef boolInsertDate As Boolean, ByRef dtInsertDate As Date, ByRef enumStatus As Enumerators.ClientStatus, ByRef intPeriod As Integer)
        Try
            If Me.chkCode.Checked Then
                lClientID = CLng(Me.cmbClientCode.SelectedValue)
            Else
                lClientID = 0
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

            If Me.chkStatus.Checked AndAlso Not Me.cmbStatus.SelectedItem Is Nothing Then
                enumStatus = CType(Me.cmbStatus.SelectedItem.value, Enumerators.ClientStatus)
            Else
                enumStatus = 0
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

            Me.cmbStatus.Items.Add(New Obj("Active", Enumerators.ClientStatus.Active))
            Me.cmbStatus.Items.Add(New Obj("Disabled", Enumerators.ClientStatus.Disabled))
            '  Me.cmbStatus.Items.Add(New Obj("Potential", Enumerators.ClientStatus.Potential))
            Me.cmbStatus.ValueMember = "Value"
            Me.cmbStatus.DisplayMember = "Name"
        Catch ex As Exception

        End Try

    End Sub


    Dim intColumnIndex As Integer

    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Not Me.DataGridView1.SelectedRows.Count = 0 Then
                Me.DataGridView1.SelectedRows(0).Selected = False
            End If
            Dim ht As DataGridView.HitTestInfo
            ht = Me.DataGridView1.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                Me.DataGridView1.Rows(ht.RowIndex).Selected = True
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


    Private Sub chkInsertDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInsertDate.CheckedChanged
        Me.cmbBillingDates.Enabled = Me.chkInsertDate.Checked
    End Sub

    Private Sub EditTotalChargesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditTotalChargesToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim boolRight As Boolean

            Dim frm As New frmPassword(boolRight)
            frm.ShowDialog()
            If frm.boolRight = True Then
                Dim frm2 As New frmEditPurchace(CInt(Me.DataGridView1.SelectedRows(0).Cells(0).Value), Me.DataGridView1.SelectedRows(0).Cells(2).Value.ToString, Math.Round(CDbl(Me.DataGridView1.SelectedRows(0).Cells(4).Value), 3), Math.Round(CDbl(Me.DataGridView1.SelectedRows(0).Cells(5).Value), 3))
                frm2.ShowDialog()
                If frm2.boolDone Then
                    Me.DataGridView1.SelectedRows(0).Cells(4).Value = frm2.txtAmount.Text
                    Me.DataGridView1.SelectedRows(0).Cells(5).Value = frm2.txtDuration.Text
                End If
            End If
        End If

    End Sub

    Private Sub ConfirmTotalChargesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfirmTotalChargesToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            If MsgBox("Are you sure you want to change the status of the purchase to Confirmed?", MsgBoxStyle.YesNo) = vbYes Then
                If odbaccess.SetPurchaseAsConfirmed(CInt(Me.DataGridView1.SelectedRows(0).Cells(0).Value), True) Then
                    'MsgBox("Confirmed.")
                    Me.DataGridView1.SelectedRows(0).Cells(11).Value = True
                Else
                    MsgBox("An error occured.")
                End If
            End If
        End If
    End Sub

    Private Sub SetAsNotConfirmedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAsNotConfirmedToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            If MsgBox("Are you sure you want to change the status of the purchase to Unconfirmed?", MsgBoxStyle.YesNo) = vbYes Then
                If odbaccess.SetPurchaseAsConfirmed(CInt(Me.DataGridView1.SelectedRows(0).Cells(0).Value), False) Then
                    '  MsgBox("Confirmed.")
                    Me.DataGridView1.SelectedRows(0).Cells(11).Value = False
                Else
                    MsgBox("An error occured.")
                End If
            End If
        End If
    End Sub

    Private Sub EditNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditNoteToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim lid As Integer = CInt(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
            Dim strNote As String = Me.DataGridView1.SelectedRows(0).Cells(12).Value.ToString
            Dim frmEditNote As New frmPurchaseNote(strNote, lid)
            frmEditNote.ShowDialog()
            If frmEditNote.boolDone Then
                Me.DataGridView1.SelectedRows(0).Cells(12).Value = frmEditNote.txtMessage.Text
            End If
        End If
    End Sub

    Private Sub chkStatus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStatus.CheckedChanged
        Me.cmbStatus.Enabled = Me.chkStatus.Checked
    End Sub

    Private Sub chkPeriod_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPeriod.CheckedChanged
        Me.cmbPeriod.Enabled = Me.chkPeriod.Checked
    End Sub
End Class
