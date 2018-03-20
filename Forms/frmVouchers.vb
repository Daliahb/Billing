Public Class frmVouchers

#Region "Controls Events"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FillTypes()
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        ' FillTypes()
    End Sub

    Public Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim lClientID As Integer = 0
        Dim lBankID, lType As Integer
        Dim enumStatus As Enumerators.ClientStatus
        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            If Me.chkClient.Checked AndAlso Not Me.cmbClientCode.SelectedValue Is Nothing Then
                lClientID = CInt(Me.cmbClientCode.SelectedValue)
            Else
                lClientID = 0
            End If

            If Me.chkBank.Checked AndAlso Not Me.cmbBanks.SelectedValue Is Nothing Then
                lBankID = CInt(Me.cmbBanks.SelectedValue)
            Else
                lBankID = 0
            End If

            If Me.chkType.Checked AndAlso Not Me.cmbType.SelectedItem Is Nothing Then
                lType = CInt(Me.cmbType.SelectedItem.value)
            Else
                lType = 0
            End If


            If Me.chkStatus.Checked AndAlso Not Me.cmbStatus.SelectedItem Is Nothing Then
                enumStatus = CType(Me.cmbStatus.SelectedItem.value, Enumerators.ClientStatus)
            Else
                enumStatus = 0
            End If

            ds = odbaccess.GetVouchers(Me.chkClient.Checked, lClientID, Me.chkDate.Checked, Me.dtpFromDate.Value, dtpToDate.Value, lBankID, lType, enumStatus)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = intCounter + 1
                            .Cells(2).Value = dr.Item("CompanyCode").ToString
                            .Cells(3).Value = dr.Item("Debit_Amount").ToString
                            .Cells(4).Value = dr.Item("Credit_Amount").ToString
                            .Cells(5).Value = dr.Item("Bank_Name").ToString
                            .Cells(6).Value = dr.Item("Note").ToString
                            .Cells(7).Value = CDate(dr.Item("insert_Date")).ToString("yyyy-MM-dd")
                            .Cells(8).Value = dr.Item("InsertBy").ToString
                            .Cells(9).Value = dr.Item("EditBy").ToString
                            .Cells(10).Value = dr.Item("strVoucherType").ToString
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

            Me.cmbType.DataSource = Nothing
            Me.cmbType.Items.Add(New Obj("Bank Fees", Enumerators.VoucherTypes.BankFees))
            Me.cmbType.Items.Add(New Obj("Dispute", Enumerators.VoucherTypes.Dispute))
            Me.cmbType.Items.Add(New Obj("Voucher", Enumerators.VoucherTypes.Voucher))
            Me.cmbType.ValueMember = "Value"
            Me.cmbType.DisplayMember = "Name"

            Me.cmbStatus.Items.Add(New Obj("Active", Enumerators.ClientStatus.Active))
            Me.cmbStatus.Items.Add(New Obj("Disabled", Enumerators.ClientStatus.Disabled))
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

    Private Sub chkClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClient.CheckedChanged
        Me.cmbClientCode.Enabled = Me.chkClient.Checked
    End Sub

    Private Sub chkType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkType.CheckedChanged
        Me.cmbType.Enabled = Me.chkType.Checked
    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        Me.dtpFromDate.Enabled = Me.chkDate.Checked
        Me.dtpToDate.Enabled = Me.chkDate.Checked
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmAddVoucher(Enumerators.EditAdd.Add)
        frm.Show()
    End Sub

    Private Sub EditVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditVoucherToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim frm As New frmAddVoucher(Enumerators.EditAdd.Edit, Me.DataGridView1.SelectedRows(0))
            frm.ShowDialog()
            If frm.boolSaved Then
                Me.DataGridView1.SelectedRows(0).Cells(2).Value = frm.cmbClientCode.Text
                Me.DataGridView1.SelectedRows(0).Cells(3).Value = frm.txtDebit.Text
                Me.DataGridView1.SelectedRows(0).Cells(4).Value = frm.txtCredit.Text
                Me.DataGridView1.SelectedRows(0).Cells(5).Value = frm.strBank
                Me.DataGridView1.SelectedRows(0).Cells(6).Value = frm.txtNote.Text
                Me.DataGridView1.SelectedRows(0).Cells(7).Value = frm.DateTimePicker1.Value.ToString("yyyy-MM-dd")
                Me.DataGridView1.SelectedRows(0).Cells(10).Value = frm.cmbType.SelectedItem.Name
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
End Class
