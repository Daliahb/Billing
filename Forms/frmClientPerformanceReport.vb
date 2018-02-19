Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class frmClientPerformanceReport
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        FillObject()

        ds = odbaccess.getClientPerformanctReport(CInt(Me.NumericUpDown1.Value), intStatus, intAccountManager)

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

            ' add all dates as columns
            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 2 AndAlso Not ds.Tables(1).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(1).Rows
                    contcolumn = New DataGridViewTextBoxColumn
                    With contcolumn
                        .HeaderText = CDate(dr.Item("date")).ToString("dd/MM/yyyy")
                    End With

                    DataGridView1.Columns.Add(contcolumn)
                Next
            End If

            'Fill first few columns - Code, Status, In/Out, Account Manager
            DataGridView1.RowHeadersVisible = False
            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 2 AndAlso Not ds.Tables(0).Rows.Count = 0 Then

                For Each dr As DataRow In ds.Tables(0).Rows
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

            contcolumn = New DataGridViewTextBoxColumn
            With contcolumn
                .HeaderText = "Total"
                .Name = "Total"
                .DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192)
            End With
            DataGridView1.Columns.Add(contcolumn) 'GetType(Integer)
            lTotalColumn = contcolumn.Index
 
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
                        For j = 5 To Me.DataGridView1.Columns.Count - 1
                            If Me.DataGridView1.Columns(j).HeaderText = CDate(dr.Item("Date")).ToString("dd/MM/yyyy") Then
                                Me.DataGridView1.Rows(r).Cells(j).Value = dr.Item("Amount").ToString
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
                            dblTotalIn += CDbl(dr.Item("TotalAmount"))
                            Exit For
                        End If
                    Next
                End If
            End If
        Next

        'fill Amounts from Purchases (Table 4)
        For r = 1 To Me.DataGridView1.Rows.Count - 1 Step 2
            If Not ds Is Nothing AndAlso Not ds.Tables.Count < 5 AndAlso Not ds.Tables(4).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(4).Rows
                    If Me.DataGridView1.Rows(r).Cells(1).Value.ToString = dr.Item("code").ToString Then
                        For j = 5 To Me.DataGridView1.Columns.Count - 1
                            If Me.DataGridView1.Columns(j).HeaderText = CDate(dr.Item("insert_Date")).ToString("dd/MM/yyyy") Then
                                Me.DataGridView1.Rows(r).Cells(j).Value = dr.Item("Amount").ToString
                                '      Me.DataGridView1.Rows(r).Cells(j + 1).Value = dr.Item("AccountManager").ToString
                                Exit For
                            End If
                        Next
                    End If
                Next
                'get total
                If Not ds.Tables(5).Rows.Count = 0 Then
                    For Each dr As DataRow In ds.Tables(5).Rows
                        If Me.DataGridView1.Rows(r).Cells(1).Value.ToString = dr.Item("code").ToString Then
                            Me.DataGridView1.Rows(r).Cells(lTotalColumn).Value = dr.Item("TotalAmount").ToString
                            dblTotalOut += CDbl(dr.Item("TotalAmount"))
                            Exit For
                        End If
                    Next
                End If
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
        ' DataGridView1.Sort("Clients," & e.Column.name)

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

    Private Sub btnOutCharts_Click(sender As System.Object, e As System.EventArgs) Handles btnOutCharts.Click
        FillObject()
        Dim ds As New DataSet
        ds = odbaccess.GetChartsClientPerformance(lCount, intStatus, 2, intAccountManager)
        Dim frm As New frmChartsClientPerformance()
        frm.Text = "Charts - Client Performance - Out"
        frm.GetClientPerformanceData(ds)
        frm.Show()
    End Sub

    Private Sub btnInCharts_Click(sender As System.Object, e As System.EventArgs) Handles btnInCharts.Click
        FillObject()
        Dim ds As New DataSet
        ds = odbaccess.GetChartsClientPerformance(lCount, intStatus, 1, intAccountManager)
        Dim frm As New frmChartsClientPerformance()
        frm.Text = "Charts - Client Performance - In"
        frm.GetClientPerformanceData(ds)
        frm.Show()
    End Sub

    Private Sub chkAccountManager_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAccountManager.CheckedChanged
        Me.cmbAccountManager.Enabled = Me.chkAccountManager.Checked
    End Sub


End Class