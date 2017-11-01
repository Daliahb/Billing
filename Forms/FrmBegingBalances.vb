Public Class FrmBegingBalances

    Dim boolSaved As Boolean = False

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(i).Cells(5).Value = gUser.Id
            Next


            Me.Validate()
            Me.DataGridView1.EndEdit()
            Me.BeginingBalancesTableAdapter.Update(Me.DsBeginingBalance.BeginingBalances)
            odbaccess.InsertHistory("Managed Begining Balances", 11)
            MsgBox("Data saved successfully")
            boolSaved = True
            '  Me.Close()
        Catch ex As Exception
            MsgBox("Update failed")
        End Try
    End Sub

    Private Sub FrmCountries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsBeginingBalance.BeginingBalances' table. You can move, or remove it, as needed.
        Me.BeginingBalancesTableAdapter.Fill(Me.DsBeginingBalance.BeginingBalances)


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not boolSaved Then
            Select Case MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    btnSave_Click(Me, New System.EventArgs)
                Case MsgBoxResult.No
                    Me.Close()
                Case MsgBoxResult.Cancel
                    Return
            End Select
        Else
            Me.Close()
        End If
    End Sub

    Public Sub CenterButtons()
        Me.Panel2.Left = CInt((Me.ClientSize.Width / 2) - (Panel2.Width / 2))
    End Sub

    Private Sub FrmCountries_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterButtons()
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
        Or e.KeyChar = "." Or e.KeyChar = "-" Then
            e.Handled = False 'if numeric display 
        Else
            e.Handled = True  'if non numeric don't display
        End If

    End Sub


End Class
