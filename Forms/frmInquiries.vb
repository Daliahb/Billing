Public Class frmInquiries

    Dim intColumnIndex As Integer
    Dim dFromDate, dToDate As Date
    Dim boolDate, boolCheckDone, boolDone, boolFromUser As Boolean
    Dim lFromUserID As Long

    Private Sub frmAbsentList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsUser.Users' table. You can move, or remove it, as needed.
        Me.UsersTableAdapter.Fill(Me.DsUser.Users)

        Me.BackColor = gBackColor
        CheckPermission()
        Me.chkStatus.Checked = True
    End Sub

    Public Sub CheckPermission()
        For Each oRole As Role In gUser.oColRoles
            'If CType(oRole.ID, Enumerators.Roles) = Enumerators.Roles.EditInquiry Then
            '    '  Me.btnAddCustomer.Enabled = True
            '    Me.EditInquiryToolStripMenuItem.Enabled = True
            '    Me.DeleteInquiryToolStripMenuItem.Enabled = True
            'End If
            'If CType(oRole.ID, Enumerators.Roles) = Enumerators.Roles.ExportToExcel Then
            '    Me.ExportToExcelToolStripMenuItem.Enabled = True
            'End If
        Next
    End Sub

    Public Sub GenerateSearchCrytiria()
        If Me.chkDate.Checked Then
            dFromDate = Me.dtpDateFrom.Value
            dToDate = Me.dtpDateTo.Value
            boolDate = True
        Else
            boolDate = False
        End If

        If Me.chkStatus.Checked Then
            boolCheckDone = True
            If rbDone.Checked Then
                boolDone = True
            Else
                boolDone = False
            End If
        Else
            boolCheckDone = False
        End If

        If Me.chkName.Checked And Not Me.cmbUsers.SelectedValue Is Nothing Then
            boolFromUser = True
            lFromUserID = CLng(Me.cmbUsers.SelectedValue)
        Else
            boolFromUser = False
            lFromUserID = 0
        End If
    End Sub

    Public Function getToUsers(tb As DataTable, lInqID As Long) As String
        Dim strUsers As String = ""
        If Not tb.Rows.Count = 0 Then
            For Each dr As DataRow In tb.Rows
                If CLng(dr.Item("FK_Inquiry")) = lInqID Then
                    strUsers = strUsers & dr.Item("UserName").ToString & ", "
                End If
            Next
            If Not strUsers.Length = 0 Then
                strUsers = strUsers.Remove(strUsers.Length - 2, 2)
            End If
            Return strUsers
        End If
    End Function

    Private Sub btnFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnFilter.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim ds As New DataSet
        Dim dblTotal As Double = 0

        Try
            Me.DataGridView1.Rows.Clear()
            GenerateSearchCrytiria()
            ds = odbaccess.GetInquiries(boolFromUser, lFromUserID, boolCheckDone, boolDone, boolDate, dFromDate, dToDate)
            If Not ds Is Nothing Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    intRowIndex = Me.DataGridView1.Rows.Add
                    With Me.DataGridView1.Rows(intRowIndex)
                        .Cells("clmUserID").Value = dr.Item("FK_FromUser").ToString
                        .Cells(0).Value = dr.Item("id").ToString
                        .Cells(1).Value = intCounter + 1
                        .Cells(2).Value = CType(dr.Item("enumPriorityLevel"), Enumerators.Priority).ToString
                        .Cells(3).Value = dr.Item("FromUser").ToString
                        .Cells(4).Value = dr.Item("Task").ToString
                        .Cells(5).Value = dr.Item("CompanyCode").ToString

                        If CInt(dr.Item("FK_OP")) > 0 Then
                            .Cells(6).Value = dr.Item("OP").ToString
                        ElseIf CInt(dr.Item("FK_TP")) > 0 Then
                            .Cells(6).Value = dr.Item("TP").ToString
                        End If
                        ' .Cells(7).Value = dr.Item("Category").ToString
                        .Cells(8).Value = CDate(dr.Item("DueDate")).ToString("yyyy/MM/dd hh:mm")


                        If Not dr.Item("Comments") Is DBNull.Value Then
                            .Cells(10).Value = dr.Item("Comments").ToString
                        End If
                        If CBool(dr.Item("isDone")) Then
                            .Cells(11).Value = "Done"
                            .DefaultCellStyle.BackColor = Color.LightSkyBlue
                        Else
                            .Cells(11).Value = "Not Done"
                        End If

                        If Not dr.Item("HandledBy") Is DBNull.Value Then
                            .Cells(9).Value = dr.Item("HandledBy").ToString
                            .Cells(9).Style.BackColor = Color.FromArgb(255, 192, 192)
                        Else
                            .Cells(9).Value = ""
                        End If

                        .Cells(12).Value = getToUsers(ds.Tables(1), CLng(dr.Item("id")))
                        If Not dr.Item("HandledBy") Is DBNull.Value Then
                            .Cells(13).Value = "Actions"
                        Else
                            .Cells(13).Value = "Get"
                        End If

                        Me.DataGridView1.Rows(intRowIndex).Height = 50

                        intRowIndex += 1
                        intCounter += 1
                    End With
                Next

                Me.DataGridView1.SelectedRows(0).Selected = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dataGridView1_CellClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = 13 And e.RowIndex >= 0 Then
            Dim lInquiryID As Long
            lInquiryID = CLng(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value)
            If Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString = "" Then
                Dim ds As DataSet

                ds = odbaccess.CheckInquiryHandled(lInquiryID)
                If Not ds Is Nothing Then
                    Dim lHandledID As Long = CLng(ds.Tables(0).Rows(0).Item("lUserID"))
                    Dim strHandledBy As String = ds.Tables(0).Rows(0).Item("UserName").ToString
                    Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value = strHandledBy
                    If Not lHandledID = 0 AndAlso Not lHandledID = gUser.Id Then
                        MsgBox("This inquiry is handled by " & strHandledBy)
                    End If
                End If
            End If

            Dim frm As New frmReadInquiry(lInquiryID)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ExportToExcel(Me.DataGridView1)
    End Sub

    Private Sub HideColumnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideColumnToolStripMenuItem.Click
        Me.DataGridView1.Columns(intColumnIndex).Visible = False
    End Sub

    Private Sub ShowAllColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllColumnsToolStripMenuItem.Click
        For i As Integer = 0 To Me.DataGridView1.Columns.Count - 1
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

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        Me.dtpDateFrom.Enabled = Me.chkDate.Checked
        Me.dtpDateTo.Enabled = Me.chkDate.Checked
    End Sub

    Private Sub EditInquiryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditInquiryToolStripMenuItem.Click
        Dim lId As Long
        Try
            If Not Me.DataGridView1.SelectedRows.Count = 0 Then
                lFromUserID = CLng(Me.DataGridView1.SelectedRows(0).Cells("clmUserID").Value)
                If lFromUserID = gUser.Id Then
                    lId = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
                    Dim frm As New frmAddInquiry(Enumerators.EditAdd.Edit, lId)
                    frm.ShowDialog()
                Else
                    MsgBox("You cannot edit Inquiry inserted by another User.", MsgBoxStyle.Exclamation)
                End If

                'Dim oInquiry = New Inquiry
                'oInquiry = odbaccess.GetInquiry(lId)

                'Me.DataGridView1.SelectedRows(0).Cells(10).Value = frm.dtpNextMonitor.Value.ToString("yyyy/MM/dd")
                'Me.DataGridView1.SelectedRows(0).Cells(11).Value = frm.cmbInquiryForm.Text

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteInquiryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteInquiryToolStripMenuItem.Click
        Dim lId As Long
            Try
                If Not Me.DataGridView1.SelectedRows.Count = 0 Then
                    lFromUserID = CLng(Me.DataGridView1.SelectedRows(0).Cells("clmUserID").Value)
                    If lFromUserID = gUser.Id Then
                        lId = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
                        If MsgBox("Are you sure you want to delete this Inquiry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If odbaccess.DeleteInquiry(lId) Then
                            Me.DataGridView1.Rows.Remove(Me.DataGridView1.SelectedRows(0))
                        Else
                            MsgBox("An error occured, please try again later.")
                        End If

                    End If
                Else
                    MsgBox("You cannot delete Inquiry inserted by another User.", MsgBoxStyle.Exclamation)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub chkName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkName.CheckedChanged
        Me.cmbUsers.Enabled = Me.chkName.Checked
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim frm As New frmAddInquiry(Enumerators.EditAdd.Add)
        frm.Show()
    End Sub

    Private Sub chkStatus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStatus.CheckedChanged
        Me.GroupBox1.Enabled = chkStatus.Checked
    End Sub

    Private Sub SetAsDoneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SetAsDoneToolStripMenuItem.Click

        If MsgBox("Are you sure you want to set this Inquiry as Done?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim lId As Long = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
            If odbaccess.SetInquiryAsDone(lId) Then
                Me.DataGridView1.SelectedRows(0).Cells(11).Value = "Done"
            Else
                MsgBox("An error occured, please try again later.")
            End If

        End If
    End Sub

    Private fromIndex As Integer
    Private dragIndex As Integer
    Private dragRect As Rectangle

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
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

            fromIndex = DataGridView1.HitTest(e.X, e.Y).RowIndex
            If fromIndex > -1 Then
                Dim dragSize As Size = SystemInformation.DragSize
                dragRect = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
            Else
                dragRect = Rectangle.Empty
            End If
        End If

    End Sub
    Private Sub DataGridView1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles DataGridView1.DragDrop
        Dim p As Point = DataGridView1.PointToClient(New Point(e.X, e.Y))
        dragIndex = DataGridView1.HitTest(p.X, p.Y).RowIndex
        If (e.Effect = DragDropEffects.Move) Then
            Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
            DataGridView1.Rows.RemoveAt(fromIndex)
            DataGridView1.Rows.Insert(dragIndex, dragRow)
        End If
    End Sub

    Private Sub DataGridView1_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles DataGridView1.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

  

    Private Sub DataGridView1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DataGridView1.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect <> Rectangle.Empty _
            AndAlso Not dragRect.Contains(e.X, e.Y)) Then
                DataGridView1.DoDragDrop(DataGridView1.Rows(fromIndex), DragDropEffects.Move)
            End If
        End If
    End Sub
End Class