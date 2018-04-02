Public Class frmClientsPayments



#Region "Controls Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        Me.Text = Me.Text & " - " & gCountry.ToString

        FillTypes()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim lClientID As Long = 0
        Dim lBankID As Integer = 0
        Dim enumStatus As Enumerators.ClientStatus
        Dim ds As DataSet
        Dim boolBankFeesStatus, boolHandled, boolPaymentStatus, boolConfirmed As Boolean
        Try
            Me.DataGridView1.Rows.Clear()
            If Me.chkClient.Checked AndAlso Not Me.cmbClientCode.SelectedValue Is Nothing Then
                lClientID = CLng(Me.cmbClientCode.SelectedValue)
            Else
                lClientID = 0
            End If

            If Me.chkBank.Checked AndAlso Not Me.cmbBanks.SelectedValue Is Nothing Then
                lBankID = CInt(Me.cmbBanks.SelectedValue)
            Else
                lBankID = 0
            End If

            If Me.chkStatus.Checked AndAlso Not Me.cmbStatus.SelectedItem Is Nothing Then
                enumStatus = CType(Me.cmbStatus.SelectedItem.value, Enumerators.ClientStatus)
            Else
                enumStatus = 0
            End If

            If Me.chkBankFees.Checked Then
                boolBankFeesStatus = True
                If rbHandled.Checked Then
                    boolHandled = True
                ElseIf rbNotHandled.Checked Then
                    boolHandled = False
                End If
            Else
                boolBankFeesStatus = False
            End If

            If Me.chkPayment.Checked Then
                boolPaymentStatus = True
                If rbConfirmed.Checked Then
                    boolConfirmed = True
                ElseIf rbNotConfirmed.Checked Then
                    boolConfirmed = False
                End If
            Else
                boolPaymentStatus = False
            End If

            ds = odbaccess.GetClientsPayments(Me.chkClient.Checked, lClientID, Me.chkDate.Checked, Me.dtpFromDate.Value, dtpToDate.Value, lBankID, enumStatus, boolBankFeesStatus, boolHandled, boolPaymentStatus, boolConfirmed)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = intCounter + 1
                            .Cells(1).Value = dr.Item("ID")
                            .Cells(2).Value = dr.Item("CompanyCode")
                            .Cells(3).Value = dr.Item("ClientAmount")
                            .Cells(4).Value = dr.Item("RecievedAmount")
                            .Cells(5).Value = dr.Item("Bank_Fees")
                            .Cells(6).Value = dr.Item("Bank_Name")
                            .Cells(7).Value = dr.Item("Note")
                            .Cells(8).Value = CDate(dr.Item("insert_Date")).ToString("yyyy-MM-dd")
                            .Cells(9).Value = CBool(dr.Item("isBankFeesSentToVoucher"))
                            .Cells(10).Value = CBool(dr.Item("isConfirmed"))
                            .Cells(11).Value = dr.Item("InsertBy")
                            .Cells(12).Value = dr.Item("EditBy")

                            If Not CBool(dr.Item("isConfirmed")) Then
                                Me.DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.LightCoral
                            End If
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
                Me.DataGridView1.Rows(i).Cells(0).Value = i + 1
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
        Dim frm As New frmAddClientPayment(Enumerators.EditAdd.Add, lClientID)
        frm.Show()
    End Sub

    Private Sub EditPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPaymentToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim frm As New frmAddClientPayment(Enumerators.EditAdd.Edit, 0, Me.DataGridView1.SelectedRows(0))
            frm.ShowDialog()
            Me.DataGridView1.SelectedRows(0).Cells(2).Value = frm.cmbClientCode.Text
            Me.DataGridView1.SelectedRows(0).Cells(3).Value = frm.txtAmount.Text
            Me.DataGridView1.SelectedRows(0).Cells(4).Value = frm.txtRecievedAmount.Text
            Me.DataGridView1.SelectedRows(0).Cells(5).Value = frm.txtBankFees.Text
            Me.DataGridView1.SelectedRows(0).Cells(6).Value = frm.strBank
            Me.DataGridView1.SelectedRows(0).Cells(7).Value = frm.txtNote.Text
            Me.DataGridView1.SelectedRows(0).Cells(8).Value = frm.DateTimePicker1.Value.ToString("yyyy-MM-dd")
        End If
    End Sub

    Private Sub AddAsDebitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAsDebitToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim lId As Integer
            Dim dblFees As Double
            lId = CInt(Me.DataGridView1.SelectedRows(0).Cells(1).Value)
            dblFees = Math.Round(CDbl(Me.DataGridView1.SelectedRows(0).Cells(5).Value), 3)
            Dim frm As New frmPaymentBankFees(lId, dblFees, True)
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


    Private Sub EditBankFeesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditBankFeesToolStripMenuItem.Click
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

    Private Sub SetAsUnconfirmedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SetAsUnconfirmedToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            If MsgBox("Are you sure you want to change the status of the payment to Unconfirmed?", MsgBoxStyle.YesNo) = vbYes Then
                If odbaccess.SetOperationAsConfirmed(Enumerators.TransactionType.ClientPayment, CInt(Me.DataGridView1.SelectedRows(0).Cells(1).Value), False) Then
                    '  MsgBox("Confirmed.")
                    Me.DataGridView1.SelectedRows(0).Cells(10).Value = False
                    Me.DataGridView1.SelectedRows(0).DefaultCellStyle.BackColor = Color.LightCoral
                Else
                    MsgBox("An error occured.")
                End If
            End If
        End If
    End Sub

    Private Sub SetAsConfirmedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SetAsConfirmedToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            If MsgBox("Are you sure you want to change the status of the payment to Confirmed?", MsgBoxStyle.YesNo) = vbYes Then
                If odbaccess.SetOperationAsConfirmed(Enumerators.TransactionType.ClientPayment, CInt(Me.DataGridView1.SelectedRows(0).Cells(1).Value), True) Then
                    '  MsgBox("Confirmed.")
                    Me.DataGridView1.SelectedRows(0).Cells(10).Value = True
                    Me.DataGridView1.SelectedRows(0).DefaultCellStyle.BackColor = Color.LemonChiffon
                Else
                    MsgBox("An error occured.")
                End If
            End If
        End If
    End Sub

    Private Sub chkPayment_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPayment.CheckedChanged
        Me.gbConfirmed.Enabled = chkPayment.Checked
    End Sub

    Private Sub chkBankFees_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBankFees.CheckedChanged
        Me.gbHandled.Enabled = chkBankFees.Checked
    End Sub
End Class
