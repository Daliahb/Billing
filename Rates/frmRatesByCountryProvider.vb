Public Class frmRatesByCountryProvider

#Region "Controls Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim boolCode, boolCountry As Boolean
        Dim strCountry As String = ""
        Dim strCode As String = ""
        Dim lClientID As Long = 0
        Dim lTypeID As Long = 0
        Dim ds As DataSet
        Try
            If Validation() Then
                Me.DataGridView1.Rows.Clear()
                GenerateCrytiria(boolCode, strCode, boolCountry, strCountry, lClientID, lTypeID)
                ds = odbaccess.GetRatesByCountry(boolCode, strCode, boolCountry, strCountry, lClientID, lTypeID)
                If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                    For Each dr As DataRow In ds.Tables(0).Rows
                        Try
                            intRowIndex = Me.DataGridView1.Rows.Add
                            With Me.DataGridView1.Rows(intRowIndex)
                                .Cells(0).Value = dr.Item("ID")
                                .Cells(1).Value = intCounter + 1
                                .Cells(2).Value = dr.Item("Code")
                                .Cells(3).Value = dr.Item("Destination")
                                .Cells(4).Value = dr.Item("Price")
                                intCounter += 1
                            End With
                        Catch ex As Exception

                        End Try
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor

        FillTypes()
        If Not Me.cmbTypes.Items.Count = 0 Then
            Me.cmbTypes.SelectedIndex = 0
            Me.btnSearch.Enabled = True
        Else
            Me.btnSearch.Enabled = True
        End If

    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
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

#End Region


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



            'Dim DsMembers As New DataSet
            'DsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
                Me.cmbClientCode.DisplayMember = "CompanyCode"
                Me.cmbClientCode.ValueMember = "ID"
            End If
        Catch ex As Exception

        End Try
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
                DataGridView1.ContextMenuStrip = ContextMenuStripHideColumn
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

    Private Sub rbCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCode.CheckedChanged
        Me.txtCode.Enabled = Me.rbCode.Checked
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDestination.CheckedChanged
        Me.txtDestination.Enabled = Me.rbDestination.Checked
    End Sub

    Public Function Validation() As Boolean
        Dim boolError As Boolean = True
        If Me.rbCode.Checked Then
            ErrorProvider1.SetError(txtDestination, "")
            If txtCode.Text.Length = 0 Then
                ErrorProvider1.SetError(txtCode, "Insert a valid value.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtCode, "")
            End If
        End If
        If Me.rbDestination.Checked Then
            ErrorProvider1.SetError(txtCode, "")
            If txtDestination.Text.Length = 0 Then
                ErrorProvider1.SetError(txtDestination, "Insert a valid value.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtDestination, "")
            End If
        End If
        If Me.cmbClientCode.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbClientCode, "Select provider from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbClientCode, "")
        End If
        If Me.cmbTypes.SelectedItem Is Nothing Then
            ErrorProvider1.SetError(cmbTypes, "Select type from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbTypes, "")
        End If
        Return boolError
    End Function

    Public Sub GenerateCrytiria(ByRef boolCode As Boolean, ByRef strCode As String, ByRef boolCountry As Boolean, ByRef strCountry As String, ByRef lClientID As Long, ByRef lTypeID As Long)
        If Me.rbCode.Checked Then
            boolCode = True
            strCode = Me.txtCode.Text
        End If
        If Me.rbDestination.Checked Then
            boolCountry = True
            strCountry = Me.txtDestination.Text
        End If
        lClientID = CLng(Me.cmbClientCode.SelectedValue)
        lTypeID = CLng(Me.cmbTypes.SelectedItem.value)
    End Sub
End Class
