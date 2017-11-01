Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class frmCompanyPerformanceReport
    Public ds As DataSet
    Public lTotalColumn As Integer

    Private Sub frmSchedual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
        Dim isByCountry As Boolean

        If Me.RadioButton1.Checked Then
            isByCountry = False
        ElseIf Me.RadioButton2.Checked Then
            isByCountry = True
        End If
        ds = odbaccess.getCompanyPerformanctReport(CInt(Me.NumericUpDown1.Value), isByCountry)

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
            contcolumn.Width = 60

            contcolumn = New DataGridViewTextBoxColumn
            With contcolumn
                .HeaderText = "Area Name"
                .Name = "1"
            End With
            DataGridView1.Columns.Add(contcolumn)
            contcolumn.Width = 200

            contcolumn = New DataGridViewTextBoxColumn
            With contcolumn
                .HeaderText = "" 'Total/Duration
                .Name = "1"
            End With
            DataGridView1.Columns.Add(contcolumn)
            contcolumn.Width = 100

            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 2 AndAlso Not ds.Tables(1).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(1).Rows
                    contcolumn = New DataGridViewTextBoxColumn

                    With contcolumn
                        .HeaderText = CDate(dr.Item("date")).ToString("yyyy-MM-dd")
                        '.Name = dr.Item("ID").ToString
                    End With

                    '  contcolumn.SortMode = DataGridViewColumnSortMode.NotSortable
                    DataGridView1.Columns.Add(contcolumn) 'Insert(1, contcolumn)
                Next
            End If

            DataGridView1.RowHeadersVisible = False
            'add first row for All Totals
            intRowIndex = Me.DataGridView1.Rows.Add
            DataGridView1.Rows(intRowIndex).Cells(0).Value = ""
            DataGridView1.Rows(intRowIndex).Cells(1).Value = "All Area Names"
            DataGridView1.Rows(intRowIndex).Cells(2).Value = "Total Charges"
            DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.LemonChiffon

            intRowIndex = Me.DataGridView1.Rows.Add
            DataGridView1.Rows(intRowIndex).Cells(0).Value = ""
            DataGridView1.Rows(intRowIndex).Cells(1).Value = ""
            DataGridView1.Rows(intRowIndex).Cells(2).Value = "Total Duration"
            DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.WhiteSmoke

            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 2 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    intRowIndex = Me.DataGridView1.Rows.Add
                    DataGridView1.Rows(intRowIndex).Cells(0).Value = intCounter
                    DataGridView1.Rows(intRowIndex).Cells(1).Value = dr.Item("Area_name").ToString
                    DataGridView1.Rows(intRowIndex).Cells(2).Value = "Total Charges"
                    DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.LemonChiffon

                    intRowIndex = Me.DataGridView1.Rows.Add
                    DataGridView1.Rows(intRowIndex).Cells(2).Value = ("Total Duration")
                    DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.WhiteSmoke

                    intCounter += 1
                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillDataGridRows()
        Dim j As Integer
        'fill first row All Totals
        If Not ds Is Nothing AndAlso Not ds.Tables.Count < 4 AndAlso Not ds.Tables(3).Rows.Count = 0 Then
            For Each dr As DataRow In ds.Tables(3).Rows
                For j = 3 To Me.DataGridView1.Columns.Count - 1
                    If Me.DataGridView1.Columns(j).HeaderText = CDate(dr.Item("Date")).ToString("yyyy-MM-dd") Then
                        Me.DataGridView1.Rows(0).Cells(j).Value = dr.Item("TotalCharges").ToString
                        Me.DataGridView1.Rows(1).Cells(j).Value = dr.Item("TotalDurations").ToString
                        Exit For
                    End If
                Next
            Next
        End If
        'fill other rows.. each Area Name
        If Not ds.Tables(2).Rows.Count = 0 Then
            For r = 2 To Me.DataGridView1.Rows.Count - 1 Step 2
                For Each dr As DataRow In ds.Tables(2).Rows
                    If Me.DataGridView1.Rows(r).Cells(1).Value.ToString = dr.Item("Area_name").ToString Then
                        For j = 3 To Me.DataGridView1.Columns.Count - 1
                            If Me.DataGridView1.Columns(j).HeaderText = CDate(dr.Item("Date")).ToString("yyyy-MM-dd") Then
                                Me.DataGridView1.Rows(r).Cells(j).Value = dr.Item("TotalCharges").ToString
                                Me.DataGridView1.Rows(r + 1).Cells(j).Value = dr.Item("TotalDurations").ToString
                                Exit For
                            End If
                        Next
                    End If
                Next
            Next
        End If
    End Sub

    'Public Sub ClearDataGridCells()
    '    Dim i As Integer
    '    For i = 3 To Me.DataGridView1.Columns.Count - 1
    '        For j As Integer = 0 To Me.DataGridView1.Rows.Count - 1
    '            DataGridView1.Rows(j).Cells(i).Value = Nothing
    '        Next

    '    Next
    'End Sub

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
        If e.Column.Index > 2 Then
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