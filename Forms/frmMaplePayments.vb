﻿Public Class frmMaplePayments

#Region "Controls Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        Me.Text = Me.Text & " - " & gCountry.ToString
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        FillTypes()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim lClientID As Long = 0
        Dim lBankID As Long = 0
        Dim enumStatus As Enumerators.ClientStatus
        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            If Me.chkClient.Checked AndAlso Not Me.cmbClientCode.SelectedValue Is Nothing Then
                lClientID = CLng(Me.cmbClientCode.SelectedValue)
            Else
                lClientID = 0
            End If

            If Me.chkBank.Checked AndAlso Not Me.cmbBanks.SelectedValue Is Nothing Then
                lBankID = CLng(Me.cmbBanks.SelectedValue)
            Else
                lBankID = 0
            End If

            If Me.chkStatus.Checked AndAlso Not Me.cmbStatus.SelectedItem Is Nothing Then
                enumStatus = CType(Me.cmbStatus.SelectedItem.value, Enumerators.ClientStatus)
            Else
                enumStatus = 0
            End If

            ds = odbaccess.GetMaplePayments(Me.chkClient.Checked, lClientID, Me.chkDate.Checked, Me.dtpFromDate.Value, dtpToDate.Value, lBankID, enumStatus)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = intCounter + 1
                            .Cells(2).Value = dr.Item("CompanyCode")
                            .Cells(3).Value = dr.Item("ClientAmount")
                            .Cells(4).Value = dr.Item("RecievedAmount")
                            .Cells(5).Value = dr.Item("Bank_Fees").ToString
                            .Cells(6).Value = dr.Item("Bank_Name").ToString
                            .Cells(7).Value = dr.Item("Note").ToString
                            .Cells(8).Value = CDate(dr.Item("insert_Date")).ToString("yyyy-MM-dd")
                            .Cells(9).Value = CBool(dr.Item("isBankFeesSentToVoucher"))
                            .Cells(10).Value = dr.Item("InsertBy")
                            .Cells(11).Value = dr.Item("EditBy")
                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

#End Region

    Public Sub FillTypes()
        Try
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
                Me.cmbClientCode.DisplayMember = "CompanyCode"
                Me.cmbClientCode.ValueMember = "ID"
            Else
                gDsMembers = odbaccess.GetClientsDS
                If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                    FillTypes()
                End If
            End If

            Dim dsBanks As DataSet
            Try
                dsBanks = odbaccess.GetBanksDS
                Me.cmbBanks.DataSource = dsBanks.Tables(0)
                Me.cmbBanks.ValueMember = "ID"
                Me.cmbBanks.DisplayMember = "Bank_Name"
            Catch ex As Exception

            End Try

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
                If ht.ColumnIndex = 5 And CBool(DataGridView1.Rows(ht.RowIndex).Cells(9).Value) = False Then
                    ContextMenuStrip1.Items(2).Visible = True
                    ContextMenuStrip1.Items(3).Visible = False
                    ContextMenuStrip1.Items(4).Visible = True
                    ContextMenuStrip1.Items(5).Visible = True
                ElseIf ht.ColumnIndex = 5 And CBool(DataGridView1.Rows(ht.RowIndex).Cells(9).Value) = True Then
                    ContextMenuStrip1.Items(2).Visible = False
                    ContextMenuStrip1.Items(3).Visible = True
                    ContextMenuStrip1.Items(4).Visible = True
                    ContextMenuStrip1.Items(5).Visible = True
                Else
                    ContextMenuStrip1.Items(2).Visible = False
                    ContextMenuStrip1.Items(3).Visible = False
                    ContextMenuStrip1.Items(4).Visible = False
                    ContextMenuStrip1.Items(5).Visible = True
                End If
            ElseIf ht.Type = DataGridViewHitTestType.ColumnHeader Then
                Me.intColumnIndex = ht.ColumnIndex
                DataGridView1.ContextMenuStrip = ContextMenuStripHideColumn
            Else
                DataGridView1.ContextMenuStrip = ContextMenuStrip1
            End If
        End If
        'If e.Button = Windows.Forms.MouseButtons.Right Then
        '    Dim ht As DataGridView.HitTestInfo
        '    ht = Me.DataGridView1.HitTest(e.X, e.Y)
        '    If ht.Type = DataGridViewHitTestType.Cell Then
        '        DataGridView1.ContextMenuStrip = ContextMenuStrip1
        '        If ht.ColumnIndex = 5 And CBool(DataGridView1.Rows(ht.RowIndex).Cells(9).Value) = False Then
        '            ContextMenuStrip1.Items(1).Visible = True
        '            ContextMenuStrip1.Items(2).Visible = True
        '            ContextMenuStrip1.Items(4).Visible = True
        '        Else
        '            ContextMenuStrip1.Items(1).Visible = False
        '            ContextMenuStrip1.Items(2).Visible = False
        '            ' ContextMenuStrip1.Items(3).Visible = True
        '            ContextMenuStrip1.Items(4).Visible = True
        '        End If
        '    ElseIf ht.Type = DataGridViewHitTestType.ColumnHeader Then
        '        Me.intColumnIndex = ht.ColumnIndex
        '        DataGridView1.ContextMenuStrip = ContextMenuStripHideColumn
        '    Else
        '        DataGridView1.ContextMenuStrip = ContextMenuStrip1
        '    End If
        'End If
    End Sub

    Private Sub HideColumnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideColumnToolStripMenuItem.Click
        Me.DataGridView1.Columns(intColumnIndex).Visible = False
    End Sub

    Private Sub ShowAllColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllColumnsToolStripMenuItem.Click
        For i As Integer = 1 To Me.DataGridView1.Columns.Count - 1
            Me.DataGridView1.Columns(i).Visible = True
        Next
    End Sub

    Private Sub chkClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClient.CheckedChanged
        Me.cmbClientCode.Enabled = Me.chkClient.Checked
    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        Me.dtpFromDate.Enabled = Me.chkDate.Checked
        Me.dtpToDate.Enabled = Me.chkDate.Checked
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim lClientID As Long
        If Me.chkClient.Checked Then
            lClientID = CLng(cmbClientCode.SelectedValue)
        End If
        Dim frm As New frmAddMaplePayment(Enumerators.EditAdd.Add, lClientID)
        frm.Show()
    End Sub

    Private Sub EditPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPaymentToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim frm As New frmAddMaplePayment(Enumerators.EditAdd.Edit, 0, Me.DataGridView1.SelectedRows(0))
            frm.ShowDialog()
            Me.DataGridView1.SelectedRows(0).Cells(2).Value = frm.cmbClientCode.Text
            Me.DataGridView1.SelectedRows(0).Cells(3).Value = frm.txtAmount.Text
            Me.DataGridView1.SelectedRows(0).Cells(4).Value = frm.txtRecievedAmount.Text
            Me.DataGridView1.SelectedRows(0).Cells(5).Value = frm.txtBankFees.Text
            Me.DataGridView1.SelectedRows(0).Cells(6).Value = frm.cmbBanks.Text
            Me.DataGridView1.SelectedRows(0).Cells(7).Value = frm.txtNote.Text
            Me.DataGridView1.SelectedRows(0).Cells(8).Value = frm.DateTimePicker1.Value.ToString("yyyy-MM-dd")
        End If
    End Sub


    Private Sub AddAsDebitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAsDebitToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
         
            Dim lId As Integer
            Dim dblFees As Double
            lId = CInt(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
            dblFees = Math.Round(CDbl(Me.DataGridView1.SelectedRows(0).Cells(5).Value))
            Dim frm As New frmPaymentBankFees(lId, dblFees, False)
            frm.ShowDialog()
            If frm.boolDone Then
                Me.DataGridView1.SelectedRows(0).Cells(9).Value = True
            End If
        End If

    End Sub

    Private Sub chkBank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBank.CheckedChanged
        Me.cmbBanks.Enabled = Me.chkBank.Checked
    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub

    Private Sub chkStatus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStatus.CheckedChanged
        Me.cmbStatus.Enabled = Me.chkStatus.Checked
    End Sub

    Private Sub EditBankFeesFromVouchersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditBankFeesFromVouchersToolStripMenuItem.Click
        Dim frm As New frmVouchers
        frm.cmbClientCode.Text = Me.DataGridView1.SelectedRows(0).Cells(2).Value.ToString
        frm.chkDate.Checked = True
        frm.dtpFromDate.Value = CDate(Me.DataGridView1.SelectedRows(0).Cells(8).Value)
        frm.dtpToDate.Value = CDate(Me.DataGridView1.SelectedRows(0).Cells(8).Value)
        frm.Show()
        frm.chkType.Checked = True
        frm.cmbType.SelectedItem = frm.cmbType.Items(0)
        frm.btnSearch_Click(Me, New System.EventArgs)
    End Sub
End Class
