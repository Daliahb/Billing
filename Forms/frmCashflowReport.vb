Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class frmCashflowReport
    Dim isLoad As Boolean
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Validate()
            Me.DataGridView1.EndEdit()
            Me.CashflowdataTableAdapter.Update(Me.DsCashFlow1.cashflowdata)
            odbaccess.InsertHistory("Cashflow Report updated", 11)
            MsgBox("Data saved successfully")
            '  Me.Close()
        Catch ex As Exception
            MsgBox("Update failed")
        End Try
    End Sub

    Private Sub FrmCountries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsCashFlow1.cashflowdata' table. You can move, or remove it, as needed.
        Me.CashflowdataTableAdapter.Fill(Me.DsCashFlow1.cashflowdata)

        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            row.Cells(1).ReadOnly = True
            row.Cells(2).ReadOnly = True
            If CDbl(row.Cells(3).Value) = 0.0 Then
                row.Cells(3).ReadOnly = False
                row.Cells(3).Style.BackColor = Color.LightBlue
            Else
                row.Cells(3).ReadOnly = True


            End If
            If CDbl(row.Cells(4).Value) = 0.0 Then
                row.Cells(4).ReadOnly = False
                row.Cells(4).Style.BackColor = Color.LightBlue
            Else
                row.Cells(4).ReadOnly = True
            End If
            row.Cells(5).ReadOnly = True
            row.Cells(5).Style.ForeColor = Color.Firebrick
            row.Cells(5).Value = CDec(row.Cells(2).Value) - CDec(row.Cells(3).Value) - CDec(row.Cells(4).Value)
            If Not CInt(row.Cells(2).Value) = 0 Then
                row.Cells(6).Value = Math.Round((CDec(row.Cells(5).Value) / CDec(row.Cells(2).Value)), 3)
                row.Cells(6).ReadOnly = True
            End If
        Next
        isLoad = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Select Case MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                btnSave_Click(Me, New System.EventArgs)
            Case MsgBoxResult.No
                Me.Close()
            Case MsgBoxResult.Cancel
                Return
        End Select
    End Sub

    Public Sub CenterButtons()
        Me.Panel2.Left = CInt((Me.ClientSize.Width / 2) - (Panel2.Width / 2))
    End Sub

    Private Sub FrmCountries_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterButtons()
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If isLoad Then
            If Not e.ColumnIndex = 5 Then
                Try
                    Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value = CDec(Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value) - CDec(Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value) - CDec(Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value)
                    Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value = Math.Round(CDec(Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value) / CDec(Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value), 3)
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, _
       ByVal e As DataGridViewEditingControlShowingEventArgs) _
       Handles DataGridView1.EditingControlShowing

        Dim txtEdit As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
        AddHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress

    End Sub

    Private Sub txtEdit_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Console.WriteLine("KeyPress " & e.KeyChar.ToString())
        'Test for numeric value or backspace in first column
        If IsNumeric(e.KeyChar.ToString()) _
            Or e.KeyChar = ChrW(Keys.Back) _
            Or e.KeyChar = "." Then
            e.Handled = False 'if numeric display 
        Else
            e.Handled = True  'if non numeric don't display
        End If
    End Sub

End Class