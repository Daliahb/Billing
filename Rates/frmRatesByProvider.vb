Public Class frmRatesByProvider


#Region "Controls Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer

        Dim ds As DataSet
        Try
            If Me.cmbClientCode.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbClientCode, "Select provider from the list.")
                Exit Sub
            Else
                ErrorProvider1.SetError(cmbClientCode, "")
            End If
            If Me.cmbTypes.SelectedItem Is Nothing Then
                ErrorProvider1.SetError(cmbTypes, "Select type from the list.")
                Exit Sub
            Else
                ErrorProvider1.SetError(cmbTypes, "")
            End If
            If Not (CLng(Me.cmbTypes.SelectedItem.value) = 3) Then
                Me.DataGridView1.Columns(6).Visible = False
            Else
                Me.DataGridView1.Columns(6).Visible = True
            End If
            Me.DataGridView1.Rows.Clear()
            ds = odbaccess.GetRatesByProvider(CLng(Me.cmbClientCode.SelectedValue), CLng(Me.cmbTypes.SelectedItem.value))
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
                            '  .Cells(5).Value = CType(dr.Item("Type"), Enumerators.CodeType)
                            .Cells(6).Value = CType(dr.Item("NonCLIType"), Enumerators.NON_CLI_Type)
                            If CBool(dr.Item("isNew")) Then
                                Me.DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.LightCoral
                            End If


                            intCounter += 1
                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        Me.DataGridView1.Columns(6).Visible = False
        'check permission
        For Each oRole As Role In gUser.oColRoles
            Select Case CType(oRole.ID, Enumerators.Roles)
                Case Enumerators.Roles.Manage_NonCLI_Type
                    Me.SetAsRetailToolStripMenuItem.Enabled = True
                    Me.SetAsWholesaleToolStripMenuItem.Enabled = True
                Case Enumerators.Roles.Edit_provide_price
                    Me.EditPriceToolStripMenuItem.Enabled = True
            End Select
        Next

        fillComboBoxes()
   
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
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

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
#End Region


    Public Sub fillComboBoxes()
        Try
            'Dim DsMembers As New DataSet
            'DsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
                Me.cmbClientCode.DisplayMember = "CompanyCode"
                Me.cmbClientCode.ValueMember = "ID"
            End If


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

    Private Sub cmbTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypes.SelectedIndexChanged
        If CType(Me.cmbTypes.SelectedItem.value, Enumerators.CodeType) = Enumerators.CodeType.Non_CLI Then
            SetAsRetailToolStripMenuItem.Visible = True
            SetAsWholesaleToolStripMenuItem.Visible = True
        Else
            SetAsRetailToolStripMenuItem.Visible = False
            SetAsWholesaleToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub SetAsRetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAsRetailToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim lid As Long
            lid = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
            If odbaccess.EditNonClIType(lId, Enumerators.NON_CLI_Type.Retail) Then
                MsgBox("Operation done successfully.")
                Me.DataGridView1.SelectedRows(0).Cells(6).Value = "Retail"
            Else
                MsgBox("An error occured!")
            End If
        End If
    End Sub

    Private Sub SetAsWholesaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAsWholesaleToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim lid As Long
            lid = CLng(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
            If odbaccess.EditNonClIType(lid, Enumerators.NON_CLI_Type.Wholesale) Then
                MsgBox("Operation done successfully.")
                Me.DataGridView1.SelectedRows(0).Cells(6).Value = "Wholesale"
            Else
                MsgBox("An error occured!")
            End If
        End If
    End Sub

    Private Sub EditPriceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPriceToolStripMenuItem.Click
        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim lid As Integer
            lid = CInt(Me.DataGridView1.SelectedRows(0).Cells(0).Value)
            Dim strCode As String = Me.DataGridView1.SelectedRows(0).Cells(2).Value.ToString
            Dim dblRate As Double = CDbl(Me.DataGridView1.SelectedRows(0).Cells(4).Value)
            Dim frm As New frmEditProviderRate(lid, strCode, dblRate)
            frm.ShowDialog()
            If frm.boolDone Then
                Me.DataGridView1.SelectedRows(0).Cells(4).Value = frm.txtAmount.Text
            End If

        End If
    End Sub
End Class
