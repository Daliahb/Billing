Public Class Form2
    Private Sub Combine_two_columns_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        Me.DataGridView1.Columns.Add("JanWin", "Win")
        Me.DataGridView1.Columns.Add("JanLoss", "Loss")
        Me.DataGridView1.Columns.Add("FebWin", "Win")
        Me.DataGridView1.Columns.Add("FebLoss", "Loss")
        Me.DataGridView1.Columns.Add("MarWin", "Win")
        Me.DataGridView1.Columns.Add("MarLoss", "Loss")
        Me.DataGridView1.Columns.Add("AprWin", "Win")
        Me.DataGridView1.Columns.Add("AprLoss", "Loss")
        Me.DataGridView1.Columns.Add("AprWin", "Win")

        Me.DataGridView1.Rows.Add("1", "2", "3", "2", "2", "2", "4", "2", "2")
        For j As Integer = 0 To Me.DataGridView1.ColumnCount - 1
            Me.DataGridView1.Columns(j).Width = 45
        Next
        Me.DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.DataGridView1.ColumnHeadersHeight = Me.DataGridView1.ColumnHeadersHeight * 2
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        Me.DataGridView2.Columns.Add("JanWin", "Win")
        Me.DataGridView2.Columns.Add("JanLoss", "Loss")
        Me.DataGridView2.Columns.Add("FebWin", "Win")
        Me.DataGridView2.Columns.Add("FebLoss", "Loss")
        Me.DataGridView2.Columns.Add("MarWin", "Win")
        Me.DataGridView2.Columns.Add("MarLoss", "Loss")
        Me.DataGridView2.Columns.Add("AprWin", "Win")
        Me.DataGridView2.Columns.Add("AprLoss", "Loss")
        Me.DataGridView2.Columns.Add("AprLoss", "Loss")
        Me.DataGridView2.Rows.Add("1", "2", "3", "2", "2", "2", "4", "2", "2")
        For j As Integer = 0 To Me.DataGridView2.ColumnCount - 1
            Me.DataGridView2.Columns(j).Width = 45
        Next
        Me.DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.DataGridView2.ColumnHeadersHeight = Me.DataGridView2.ColumnHeadersHeight * 2
        Me.DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
    End Sub
    Private Sub DataGridView1_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex > -1 Then
            Dim r2 As Rectangle = e.CellBounds
            r2.Y += e.CellBounds.Height / 2
            r2.Height = e.CellBounds.Height / 2
            e.PaintBackground(r2, True)
            e.PaintContent(r2)
            e.Handled = True
        End If
    End Sub
    Private Sub DataGridView1_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridView1.ColumnWidthChanged
        Dim rtHeader As Rectangle = Me.DataGridView1.DisplayRectangle
        rtHeader.Height = Me.DataGridView1.ColumnHeadersHeight / 2
        Me.DataGridView1.Invalidate(rtHeader)
    End Sub
    Private Sub DataGridView1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
        Dim monthes As String() = {"January", "February", "March", "April"}
        Dim j As Integer = 0
        While j < 8
            Dim r1 As Rectangle = Me.DataGridView1.GetCellDisplayRectangle(j, -1, True)
            Dim w2 As Integer = Me.DataGridView1.GetCellDisplayRectangle(j + 1, -1, True).Width
            r1.X += 1
            r1.Y += 1
            r1.Width = r1.Width + w2 - 2
            r1.Height = r1.Height / 2 - 2
            e.Graphics.FillRectangle(New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1)
            Dim format As New StringFormat()
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(monthes(j \ 2), Me.DataGridView1.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)
            j += 2
        End While
    End Sub
    Private Sub DataGridView1_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView1.Scroll
        Dim rtHeader As Rectangle = Me.DataGridView1.DisplayRectangle
        rtHeader.Height = Me.DataGridView1.ColumnHeadersHeight / 2
        Me.DataGridView1.Invalidate(rtHeader)
    End Sub


    Private Sub DataGridView2_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView2.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex > -1 Then
            Dim r2 As Rectangle = e.CellBounds
            r2.Y += e.CellBounds.Height / 2
            r2.Height = e.CellBounds.Height / 2
            e.PaintBackground(r2, True)
            e.PaintContent(r2)
            e.Handled = True
        End If
    End Sub
    Private Sub DataGridView2_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridView2.ColumnWidthChanged
        Dim rtHeader As Rectangle = Me.DataGridView2.DisplayRectangle
        rtHeader.Height = Me.DataGridView2.ColumnHeadersHeight / 2
        Me.DataGridView2.Invalidate(rtHeader)
    End Sub
    Private Sub DataGridView2_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles DataGridView2.Paint
        Dim monthes As String() = {"January", "February", "March"}
        Dim j As Integer = 0
        While j < monthes.Count * 3
            Dim r1 As Rectangle = Me.DataGridView2.GetCellDisplayRectangle(j, -1, True)
            Dim w2 As Integer = 0 '= Me.DataGridView2.GetCellDisplayRectangle(j + 1, -1, True).Width * 4
            For i = 0 To 2
                w2 += Me.DataGridView2.GetCellDisplayRectangle(j + i, -1, True).Width
            Next
            r1.X += 1
            r1.Y += 1
            r1.Width = w2 - 2
            r1.Height = r1.Height / 2 - 2
            e.Graphics.FillRectangle(New SolidBrush(Me.DataGridView2.ColumnHeadersDefaultCellStyle.BackColor), r1)
            Dim format As New StringFormat()
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(monthes(j / 3), Me.DataGridView2.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)
            j += 3
        End While
    End Sub
    Private Sub DataGridView2_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView2.Scroll
        Dim rtHeader As Rectangle = Me.DataGridView2.DisplayRectangle
        rtHeader.Height = Me.DataGridView2.ColumnHeadersHeight / 2
        Me.DataGridView2.Invalidate(rtHeader)
    End Sub
End Class