Public Class frmBanks
    Dim oColBanks As New ColBank

    Private Sub Template_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        CheckPermission()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        ' Dim boolStatus, boolActive As Boolean
     
        Try
            Me.DataGridView1.Rows.Clear()
            'generateSearchCrytiria(boolStatus, boolActive)


            oColBanks = odbaccess.GetBanks
            If Not oColBanks Is Nothing AndAlso Not oColBanks.Count = 0 Then
                For Each oBank As Bank In oColBanks
                    intRowIndex = Me.DataGridView1.Rows.Add
                    With Me.DataGridView1.Rows(intRowIndex)
                        .Cells(0).Value = oBank.ID
                        .Cells(1).Value = intCounter + 1
                        .Cells(2).Value = oBank.BankName
                        .Cells(3).Value = oBank.BankAccountName
                        .Cells(4).Value = oBank.BeneficiaryBankName
                        .Cells(5).Value = oBank.BeneficiaryBankAddress
                        .Cells(6).Value = oBank.active
                        intCounter += 1
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim lId As Long
        Dim obank As Bank
        Try
            If Not Me.DataGridView1.SelectedRows.Count = 0 Then
                lId = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
                obank = oColBanks.GetBank(lId)
                Dim frmAddBank As New frmAddBank(Enumerators.EditAdd.Edit, obank)
                frmAddBank.ShowDialog()
                With Me.DataGridView1.SelectedRows(0)
                    .Cells(2).Value = obank.BankName
                    .Cells(3).Value = obank.BankAccountName
                    .Cells(4).Value = obank.BeneficiaryBankName
                    .Cells(5).Value = obank.BeneficiaryBankAddress
                End With

                '   Me.btnSearch_Click(Me, New System.EventArgs)
            End If

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnAddCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCustomer.Click
        Dim oFrm As New frmAddBank(Enumerators.EditAdd.Add)
        oFrm.ShowDialog()
    End Sub

    Public Sub generateSearchCrytiria(ByRef boolStatus As Boolean, ByRef boolActive As Boolean)
        Try
            boolStatus = Me.chkStatus.Checked
            If boolStatus Then
                If rbActive.Checked Then
                    boolActive = True
                Else
                    boolActive = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        Me.rbActive.Enabled = chkStatus.Checked
        Me.rbInactive.Enabled = chkStatus.Checked
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        '    ExportToExcel(Me.DataGridView1)
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
                DataGridView1.ContextMenuStrip = ContextMenuStrip2
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

    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Try
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(1).Value = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteRowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteRowToolStripMenuItem.Click
        Dim lid As Long
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            lId = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)

            If MsgBox("Are you sure you want to inactive this Bank?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If odbaccess.DeleteBank(lid) Then
                    btnSearch_Click(Me, New System.EventArgs)
                Else
                    MsgBox("An error occured")
                End If

            End If
        End If

    End Sub

    Public Sub CheckPermission()
        'Dim boolEditBanks, boolExportToExcel As Boolean
        'For Each oRole As Role In oUser.oColRoles
        '    If CType(oRole.ID, Enumerators.Roles) = Enumerators.Roles.EditBanks Then
        '        boolEditBanks = True
        '    End If
        '    If CType(oRole.ID, Enumerators.Roles) = Enumerators.Roles.ExportToExcel Then
        '        boolExportToExcel = True
        '    End If
        'Next

        'If Not boolExportToExcel Then
        '    Me.ExportToExcelToolStripMenuItem.Enabled = False
        'End If
        'If Not boolEditBanks Then
        '    Me.EditToolStripMenuItem.Enabled = False
        '    Me.DeleteRowToolStripMenuItem.Enabled = False
        'End If
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim lId As Long
        'Try
        '    If Not Me.DataGridView1.SelectedRows.Count = 0 Then
        '        lId = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)

        '        If odbaccess.ActivateBank(lId) Then
        '            MsgBox("Operation done successfully.")
        '            '     Me.btnGet_Click(Me, New System.EventArgs)
        '        Else
        '            MsgBox("An error occured.")
        '        End If
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message & ex.StackTrace)
        'End Try
    End Sub
End Class