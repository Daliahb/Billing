Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class frmPerformanceReport
    Public ds As DataSet
    Public lTotalColumn As Integer

    Private Sub frmSchedual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        ds = odbaccess.getPerformanctReport(CInt(Me.NumericUpDown1.Value))

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
                .Name = "1"
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


            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 2 AndAlso Not ds.Tables(1).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(1).Rows
                    contcolumn = New DataGridViewTextBoxColumn

                    With contcolumn
                        .HeaderText = CDate(dr.Item("date")).ToString("dd/MM/yyyy")
                        '.Name = dr.Item("ID").ToString
                    End With

                    '  contcolumn.SortMode = DataGridViewColumnSortMode.NotSortable
                    DataGridView1.Columns.Add(contcolumn) 'Insert(1, contcolumn)

                    contcolumn = New DataGridViewTextBoxColumn
                    With contcolumn
                        .HeaderText = "Account Manager"
                        .Name = "4"
                    End With
                    DataGridView1.Columns.Add(contcolumn)
                    contcolumn.Width = 120
                Next
            End If

            contcolumn = New DataGridViewTextBoxColumn
            With contcolumn
                .HeaderText = "Total"
                .Name = "2"
            End With
            DataGridView1.Columns.Add(contcolumn) 'GetType(Integer)
            lTotalColumn = contcolumn.Index

            DataGridView1.RowHeadersVisible = False
            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 2 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    intRowIndex = Me.DataGridView1.Rows.Add
                    DataGridView1.Rows(intRowIndex).Cells(0).Value = intCounter
                    DataGridView1.Rows(intRowIndex).Cells(1).Value = dr.Item("code").ToString
                    DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.LemonChiffon

                    intCounter += 1
                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillDataGridRows()
        ClearDataGridCells()
        Dim j As Integer

        For r = 0 To Me.DataGridView1.Rows.Count - 1
            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 4 AndAlso Not ds.Tables(2).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(2).Rows
                    If Me.DataGridView1.Rows(r).Cells(1).Value.ToString = dr.Item("code").ToString Then
                        For j = 2 To Me.DataGridView1.Columns.Count - 1
                            If Me.DataGridView1.Columns(j).HeaderText = CDate(dr.Item("Date")).ToString("dd/MM/yyyy") Then
                                Me.DataGridView1.Rows(r).Cells(j).Value = dr.Item("Amount").ToString
                                Me.DataGridView1.Rows(r).Cells(j + 1).Value = dr.Item("AccountManager").ToString
                                Exit For
                            End If
                        Next
                    End If
                Next
                'get total
                If Not ds.Tables(3).Rows.Count = 0 Then
                    For Each dr As DataRow In ds.Tables(3).Rows
                        If Me.DataGridView1.Rows(r).Cells(1).Value.ToString = dr.Item("code").ToString Then
                            Me.DataGridView1.Rows(r).Cells(lTotalColumn).Value = dr.Item("TotalAmount").ToString
                            Exit For
                        End If
                    Next
                End If
            End If
        Next

    End Sub

    Public Sub ClearDataGridCells()
        Dim i As Integer
        For i = 2 To Me.DataGridView1.Columns.Count - 1
            For j As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                DataGridView1.Rows(j).Cells(i).Value = Nothing
            Next

        Next
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub

    Private Sub DataGridView1_sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        Try
            Dim i As Integer
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(0).Value = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dataGridView1_SortCompare(ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs) Handles DataGridView1.SortCompare
        If e.Column.Index = 2 Or e.Column.Index = 4 Or e.Column.Index = 6 Or e.Column.Index = 8 Or e.Column.Index = lTotalColumn Then
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
End Class