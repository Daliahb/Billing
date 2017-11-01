Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class frmAllRates
    Dim excel As Excel.Application = New Excel.Application
    Dim worksheet As Excel.Worksheet
    Dim xlWorkBook As Excel.Workbook
    Dim intCurrentRowIndex, intCurrentColumnIndex As Integer
    Dim lTimeID, lInstructorID As Long

    Private Sub frmSchedual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        FillTypes()
        Me.cmbTypes.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If cmbTypes.SelectedItem.value Is Nothing Then
            ErrorProvider1.SetError(cmbTypes, "Select type from the list.")
            Exit Sub
        Else
            ErrorProvider1.SetError(cmbTypes, "")
        End If

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        FillDataGridColumns()
        FillDataGridRows()
    End Sub

    Public Sub FillDataGridColumns()
        Dim dsCodes As DataSet
        Dim dsProviders As DataSet

        Dim contcolumn As New DataGridViewTextBoxColumn
        Dim intRowIndex As Integer

        Try
            dsCodes = odbaccess.getActiveCodes(CLng(Me.cmbTypes.SelectedItem.value))
            dsProviders = odbaccess.GetActiveProviders(CLng(Me.cmbTypes.SelectedItem.value))

            contcolumn = New DataGridViewTextBoxColumn

            With contcolumn
                .HeaderText = "Codes"
                .Name = "0"
            End With
            DataGridView1.Columns.Add(contcolumn)

            contcolumn = New DataGridViewTextBoxColumn

            With contcolumn
                .HeaderText = "Destination | Providers"
                .Name = "1"
            End With
            DataGridView1.Columns.Add(contcolumn)

            If Not dsProviders Is Nothing AndAlso Not dsProviders.Tables.Count = 0 AndAlso Not dsProviders.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In dsProviders.Tables(0).Rows
                    contcolumn = New DataGridViewTextBoxColumn

                    With contcolumn
                        .HeaderText = dr.Item("Provider").ToString
                        '.Name = dr.Item("ID").ToString
                    End With

                    contcolumn.SortMode = DataGridViewColumnSortMode.NotSortable
                    DataGridView1.Columns.Add(contcolumn) 'Insert(1, contcolumn)

                Next
            End If
            DataGridView1.RowHeadersVisible = False
            If Not dsCodes Is Nothing AndAlso Not dsCodes.Tables.Count = 0 AndAlso Not dsCodes.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In dsCodes.Tables(0).Rows
                    intRowIndex = Me.DataGridView1.Rows.Add
                    DataGridView1.Rows(intRowIndex).Cells(0).Value = dr.Item("Code").ToString
                    DataGridView1.Rows(intRowIndex).Cells(1).Value = dr.Item("Destination").ToString
                    DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.LemonChiffon
                    '  DataGridView1.Rows(intRowIndex).Height = 47

                    'DataGridView1.Rows(intRowIndex).HeaderCell.
                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillDataGridRows()
        ClearDataGridCells()
        Dim j As Integer
        Dim dsAllRates As New DataSet
        dsAllRates = odbaccess.GetAllRates(CLng(Me.cmbTypes.SelectedItem.value))
        If Not dsAllRates Is Nothing AndAlso Not dsAllRates.Tables.Count = 0 AndAlso Not dsAllRates.Tables(0).Rows.Count = 0 Then
            For Each dr As DataRow In dsAllRates.Tables(0).Rows
                For j = 2 To Me.DataGridView1.Columns.Count - 1
                    If Me.DataGridView1.Columns(j).HeaderText = dr.Item("Provider").ToString Then
                        For r = 0 To Me.DataGridView1.Rows.Count - 1
                            If Me.DataGridView1.Rows(r).Cells(0).Value.ToString = dr.Item("code").ToString Then
                                Me.DataGridView1.Rows(r).Cells(j).Value = dr.Item("Price").ToString
                                Exit For
                            End If
                        Next
                    End If
                Next
            Next

        End If
    End Sub

    Public Sub ClearDataGridCells()
        Dim i As Integer
        For i = 2 To Me.DataGridView1.Columns.Count - 1
            For j As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                DataGridView1.Rows(j).Cells(i).Value = Nothing
            Next

        Next
    End Sub

    Public Sub FillTypes()
        Try
            Me.cmbTypes.DataSource = Nothing

            Dim oColObjects As New ColObjects
            oColObjects.GetCodeTypes()
            For Each Obj As Obj In oColObjects
                Me.cmbTypes.Items.Add(Obj)
            Next

            Me.cmbTypes.ValueMember = "Value"
            Me.cmbTypes.DisplayMember = "Name"


        Catch ex As Exception

        End Try
    End Sub


    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub
End Class