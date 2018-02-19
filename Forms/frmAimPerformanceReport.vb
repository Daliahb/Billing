Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class frmAimPerformanceReport
    Public ds As DataSet
    Public lTotalColumn As Integer
    Public dblTotalIn, dblTotalOut As Double
    Dim intStatus, intAccountManager, lCount As Integer

    Private Sub frmSchedual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsAccountManagers.AccountManagers' table. You can move, or remove it, as needed.
        Me.AccountManagersTableAdapter.Fill(Me.DsAccountManagers.AccountManagers)

        Me.cmbStatus.Items.Add(New Obj("Active", Enumerators.ClientStatus.Active))
        Me.cmbStatus.Items.Add(New Obj("Disabled", Enumerators.ClientStatus.Disabled))
        Me.cmbStatus.ValueMember = "Value"
        Me.cmbStatus.DisplayMember = "Name"
        Me.cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()


        FillObject()

        ds = odbaccess.getAimPerformanctReport(lCount, intStatus, intAccountManager)

        FillDataGridColumns()
        FillDataGridRows()
    End Sub

    Public Sub FillDataGridColumns()
        Dim contcolumn As New DataGridViewTextBoxColumn
        Dim intRowIndex As Integer
        Dim intCounter As Integer = 1
        Try
            contcolumn = New DataGridViewTextBoxColumn
            With contcolumn
                .HeaderText = "No."
                .Name = "no"
            End With
            DataGridView1.Columns.Add(contcolumn)
            contcolumn.Width = 70

            contcolumn = New DataGridViewTextBoxColumn
            With contcolumn
                .HeaderText = "Clients"
                .Name = "1"
            End With
            DataGridView1.Columns.Add(contcolumn)
            contcolumn.Width = 120

            contcolumn = New DataGridViewTextBoxColumn
            With contcolumn
                .HeaderText = "In/Out"
                .Name = "InOut"
            End With
            DataGridView1.Columns.Add(contcolumn)
            contcolumn.Width = 120

            contcolumn = New DataGridViewTextBoxColumn
            With contcolumn
                .HeaderText = "Status"
                .Name = "Status"
            End With
            DataGridView1.Columns.Add(contcolumn)
            contcolumn.Width = 120

            contcolumn = New DataGridViewTextBoxColumn
            With contcolumn
                .HeaderText = "Account Manager"
                .Name = "AccountManager"
            End With
            DataGridView1.Columns.Add(contcolumn)
            contcolumn.Width = 150

            ' add all dates as columns (Table(1))
            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 2 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    contcolumn = New DataGridViewTextBoxColumn
                    With contcolumn
                        .HeaderText = "Amount"
                        .Name = CDate(dr.Item("date")).ToString("dd/MM/yyyy")
                    End With
                    DataGridView1.Columns.Add(contcolumn)

                    contcolumn = New DataGridViewTextBoxColumn
                    With contcolumn
                        .HeaderText = "Margin"
                    End With
                    DataGridView1.Columns.Add(contcolumn)

                    contcolumn = New DataGridViewTextBoxColumn
                    With contcolumn
                        .HeaderText = "Profit %"
                    End With
                    DataGridView1.Columns.Add(contcolumn)
                Next
            End If

            Me.DataGridView1.ColumnHeadersHeight = 23 * 2
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

            'Fill first few columns - Code, Status, In/Out, Account Manager
            DataGridView1.RowHeadersVisible = False
            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 2 AndAlso Not ds.Tables(1).Rows.Count = 0 Then

                For Each dr As DataRow In ds.Tables(1).Rows
                    ' add row for each client as In
                    intRowIndex = Me.DataGridView1.Rows.Add
                    DataGridView1.Rows(intRowIndex).Cells(0).Value = intCounter
                    DataGridView1.Rows(intRowIndex).Cells(1).Value = dr.Item("code").ToString
                    DataGridView1.Rows(intRowIndex).Cells(2).Value = "In"
                    DataGridView1.Rows(intRowIndex).Cells(3).Value = CType(dr.Item("enumClientstatus"), Enumerators.ClientStatus).ToString
                    DataGridView1.Rows(intRowIndex).Cells(4).Value = dr.Item("AccountManager").ToString
                    DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.LemonChiffon


                    ' add row for each client as Out
                    intRowIndex = Me.DataGridView1.Rows.Add
                    DataGridView1.Rows(intRowIndex).Cells(0).Value = intCounter
                    DataGridView1.Rows(intRowIndex).Cells(1).Value = dr.Item("code").ToString
                    DataGridView1.Rows(intRowIndex).Cells(2).Value = "Out"
                    DataGridView1.Rows(intRowIndex).Cells(3).Value = CType(dr.Item("enumClientstatus"), Enumerators.ClientStatus).ToString
                    DataGridView1.Rows(intRowIndex).Cells(4).Value = dr.Item("AccountManager").ToString
                    DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.PeachPuff

                    intCounter += 1
                Next
            End If

            'contcolumn = New DataGridViewTextBoxColumn
            'With contcolumn
            '    .HeaderText = "Total"
            '    .Name = "Total"
            '    .DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192)
            'End With
            'DataGridView1.Columns.Add(contcolumn) 'GetType(Integer)
            'lTotalColumn = contcolumn.Index

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillDataGridRows()
        ClearDataGridCells()
        Dim j As Integer
        'fill Amounts from Invoices (Table 2)
        For r = 0 To Me.DataGridView1.Rows.Count - 1 Step 2
            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 4 AndAlso Not ds.Tables(2).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(2).Rows
                    If Me.DataGridView1.Rows(r).Cells(1).Value.ToString = dr.Item("code").ToString Then
                        For j = 5 To Me.DataGridView1.Columns.Count - 1 Step 3
                            If Me.DataGridView1.Columns(j).Name = CDate(dr.Item("Insert_Date")).ToString("dd/MM/yyyy") Then
                                Me.DataGridView1.Rows(r).Cells(j).Value = dr.Item("Total_Charges").ToString
                                Me.DataGridView1.Rows(r).Cells(j + 1).Value = dr.Item("Margin").ToString
                                Me.DataGridView1.Rows(r).Cells(j + 2).Value = dr.Item("Profit").ToString
                                Exit For
                            End If
                        Next
                    End If
                Next
                'get total
                'If Not ds.Tables(3).Rows.Count = 0 Then
                '    For Each dr As DataRow In ds.Tables(3).Rows
                '        If Me.DataGridView1.Rows(r).Cells(1).Value.ToString = dr.Item("code").ToString Then
                '            Me.DataGridView1.Rows(r).Cells(lTotalColumn).Value = dr.Item("TotalAmount").ToString
                '            dblTotalIn += CDbl(dr.Item("TotalAmount"))
                '            Exit For
                '        End If
                '    Next
                'End If
            End If
        Next

        'fill Amounts from Purchases (Table 4)
        For r = 1 To Me.DataGridView1.Rows.Count - 1 Step 2
            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 4 AndAlso Not ds.Tables(3).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(3).Rows
                    If Me.DataGridView1.Rows(r).Cells(1).Value.ToString = dr.Item("code").ToString Then
                        For j = 5 To Me.DataGridView1.Columns.Count - 1 Step 3
                            If Me.DataGridView1.Columns(j).Name = CDate(dr.Item("Insert_Date")).ToString("dd/MM/yyyy") Then
                                Me.DataGridView1.Rows(r).Cells(j).Value = dr.Item("Total_Charges").ToString
                                Me.DataGridView1.Rows(r).Cells(j + 1).Value = dr.Item("Margin").ToString
                                Me.DataGridView1.Rows(r).Cells(j + 2).Value = dr.Item("Profit").ToString
                                Exit For
                            End If
                        Next
                    End If
                Next
                'get total
                'If Not ds.Tables(5).Rows.Count = 0 Then
                '    For Each dr As DataRow In ds.Tables(5).Rows
                '        If Me.DataGridView1.Rows(r).Cells(1).Value.ToString = dr.Item("code").ToString Then
                '            Me.DataGridView1.Rows(r).Cells(lTotalColumn).Value = dr.Item("TotalAmount").ToString
                '            dblTotalOut += CDbl(dr.Item("TotalAmount"))
                '            Exit For
                '        End If
                '    Next
                'End If
            End If
        Next
        Me.lblTotalIn.Text = dblTotalIn.ToString
        Me.lblTotalOut.Text = dblTotalOut.ToString
    End Sub

    Public Sub ClearDataGridCells()
        Dim i As Integer
        For i = 5 To Me.DataGridView1.Columns.Count - 1
            For j As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                DataGridView1.Rows(j).Cells(i).Value = Nothing
            Next

        Next
    End Sub

    Public Sub FillObject()
        If Me.chkStatus.Checked Then
            intStatus = CInt(Me.cmbStatus.SelectedItem.value)
        Else
            intStatus = 0
        End If

        If Me.chkAccountManager.Checked Then
            intAccountManager = CInt(Me.cmbAccountManager.SelectedValue)
        Else
            intAccountManager = 0
        End If

        lCount = CInt(Me.NumericUpDown1.Value)
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub

    Private Sub DataGridView1_sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        'Try
        '    Dim i As Integer
        '    For i = 0 To Me.DataGridView1.Rows.Count - 1
        '        Me.DataGridView1.Rows(i).Cells(0).Value = i + 1
        '    Next
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub dataGridView1_SortCompare(ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs) Handles DataGridView1.SortCompare
        If e.Column.Index > 4 Then
            Try
                If Not e.CellValue1 Is Nothing AndAlso Not e.CellValue2 Is Nothing Then
                    e.SortResult = If(CInt(e.CellValue1) < CInt(e.CellValue2), -1, 1)
                    e.Handled = True
                End If

            Catch
            End Try

        Else
            Return
        End If

    End Sub

    Private Sub chkStatus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStatus.CheckedChanged
        Me.cmbStatus.Enabled = chkStatus.Checked
    End Sub

    Private Sub chkAccountManager_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAccountManager.CheckedChanged
        Me.cmbAccountManager.Enabled = Me.chkAccountManager.Checked
    End Sub

#Region "Datagrid Header"
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
        'Dim monthes As String() = {"January", "February", "March"}
        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then


            Dim j As Integer = 0
            While j < ds.Tables(0).Rows.Count * 3
                Dim r1 As Rectangle = Me.DataGridView1.GetCellDisplayRectangle(j, -1, True)
                r1.X = Me.DataGridView1.GetCellDisplayRectangle(5 + j, -1, True).X
                Dim w2 As Integer = 0 '=  Me.DataGridView1.GetCellDisplayRectangle(j + 1, -1, True).Width * 4
                For i = 0 To 2
                    w2 += Me.DataGridView1.GetCellDisplayRectangle((5 + (j)) + i, -1, True).Width
                Next
                r1.X += 1
                r1.Y += 1
                r1.Width = w2 - 2
                r1.Height = r1.Height / 2 - 2
                e.Graphics.FillRectangle(New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1)
                Dim format As New StringFormat()
                format.Alignment = StringAlignment.Center
                format.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(CDate(ds.Tables(0).Rows(j / 3).Item(0)).ToString("yyyy-MM-dd"), Me.DataGridView1.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)
                j += 3
            End While
        End If
    End Sub
    Private Sub DataGridView1_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView1.Scroll
        Dim rtHeader As Rectangle = Me.DataGridView1.DisplayRectangle
        rtHeader.Height = Me.DataGridView1.ColumnHeadersHeight / 2
        Me.DataGridView1.Invalidate(rtHeader)
    End Sub
#End Region

    Private Sub btnOutCharts_Click(sender As System.Object, e As System.EventArgs) Handles btnOutCharts.Click
        FillObject()
        Dim ds As New DataSet
        ds = odbaccess.GetChartsAimPerformance(lCount, intStatus, 2, intAccountManager)
        Dim frm As New frmChartsClientPerformance()
        frm.Text = "Charts - Aim Performance - Out"
        frm.GetAimPerformanceData(ds)
        frm.Show()
    End Sub

    Private Sub btnInCharts_Click(sender As System.Object, e As System.EventArgs) Handles btnInCharts.Click
        FillObject()
        Dim ds As New DataSet
        ds = odbaccess.GetChartsAimPerformance(lCount, intStatus, 1, intAccountManager)
        Dim frm As New frmChartsClientPerformance()
        frm.Text = "Charts - Aim Performance - In"
        frm.GetAimPerformanceData(ds)
        frm.Show()
    End Sub

End Class