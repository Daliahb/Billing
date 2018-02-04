Public Class frmBilling

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor

        'check permission
        For Each oRole As Role In gUser.oColRoles
            Select Case CType(oRole.ID, Enumerators.Roles)
                Case Enumerators.Roles.Generate_weekly_Report
                    Me.btnWeeklyReport.Enabled = True
                Case Enumerators.Roles.Generate_Invoices
                    Me.btnGenerateInvoices.Enabled = True
            End Select
        Next

        fillComboBoxes()

        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        Try
            Me.cmbClientCode.SelectedIndex = 0
        Catch ex As Exception

        End Try



    End Sub

#Region "Controls Events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '  Dim oColEvents As New ColEvents
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer

        Dim lClientID, lSoftware As Long
        Dim boolPeriodDate, boolInsertDate, boolInbound As Boolean
        Dim dtFrom, dtTo, dInsertDate As Date
        Dim dTotalDuration As Double = 0
        Dim dTotalCharges As Double = 0
        Me.lblTotalCharges.Text = "0.0000000"
        Me.lblTotalDuration.Text = "0.0000000"
        Dim ds As DataSet
        Try
            Me.DataGridView1.Rows.Clear()
            generateSearchCrytiria(lClientID, lSoftware, boolPeriodDate, dtFrom, dtTo, boolInsertDate, dInsertDate, boolInbound)
            ds = odbaccess.GetBillingSearch(lClientID, lSoftware, boolPeriodDate, dtFrom, dtTo, boolInsertDate, dInsertDate, boolInbound)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    intRowIndex = Me.DataGridView1.Rows.Add
                    With Me.DataGridView1.Rows(intRowIndex)
                        .Cells(0).Value = dr.Item("ID")
                        .Cells(1).Value = intCounter + 1
                        If CBool(dr.Item("found")) = True Then
                            .Cells(2).Value = True
                        Else
                            .Cells(2).Value = False
                            Me.DataGridView1.Rows(intRowIndex).DefaultCellStyle.BackColor = Color.IndianRed
                        End If
                        .Cells(3).Value = dr.Item("Client_Code")
                        .Cells(4).Value = dr.Item("Area_Name")
                        .Cells(5).Value = dr.Item("Area_Code")
                        .Cells(6).Value = dr.Item("Total_Charges")
                        .Cells(7).Value = dr.Item("Total_Duration")
                        .Cells(8).Value = CDate(dr.Item("Billing_Period_From")).ToString("dd-MM-yyyy")
                        .Cells(9).Value = CDate(dr.Item("Billing_Period_To")).ToString("dd-MM-yyyy")
                        .Cells(10).Value = dr.Item("Software")
                        .Cells(11).Value = CDate(dr.Item("Insert_Date")).ToString("dd-MM-yyyy")
                        dTotalDuration += CDec(dr.Item("Total_Duration"))
                        dTotalCharges += CDec(dr.Item("Total_Charges"))
                        intCounter += 1
                    End With
                Next
                Me.lblTotalCharges.Text = Math.Round(dTotalCharges, 3).ToString
                Me.lblTotalDuration.Text = dTotalDuration.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoftware.CheckedChanged
        Me.cmbSoftware.Enabled = Me.chkSoftware.Checked
    End Sub

    Private Sub ckbDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCode.CheckedChanged
        Me.cmbClientCode.Enabled = Me.chkCode.Checked
    End Sub


    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel(Me.DataGridView1)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPeriodDate.CheckedChanged
        Me.dtpFrom.Enabled = Me.chkPeriodDate.Checked
        Me.dtpTo.Enabled = Me.chkPeriodDate.Checked
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

    Private Sub chkInsertDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInsertDate.CheckedChanged
        Me.cmbBillingDates.Enabled = Me.chkInsertDate.Checked
    End Sub

  
#End Region


    Public Sub generateSearchCrytiria(ByRef lClientID As Long, ByRef lSoftware As Long, ByRef boolPeriodDate As Boolean, ByRef dtFrom As Date, ByRef dtTo As Date, ByRef boolInsertDate As Boolean, ByRef dtInsertDate As Date, ByRef boolInbound As Boolean)
        Try
            If Me.chkCode.Checked Then
                lClientID = CLng(Me.cmbClientCode.SelectedValue)
            Else
                lClientID = 0
            End If
            If Me.chkSoftware.Checked Then
                lSoftware = CLng(Me.cmbSoftware.SelectedValue)
            Else
                lSoftware = 0
            End If
            If Me.rbInBound.Checked Then
                boolInbound = True
            Else
                boolInbound = False
            End If
            If Me.chkPeriodDate.Checked Then
                boolPeriodDate = True
                dtFrom = Me.dtpFrom.Value.Date
                dtTo = Me.dtpTo.Value.Date
            Else
                boolPeriodDate = False
            End If
            If Me.chkInsertDate.Checked Then
                boolInsertDate = True
                dtInsertDate = CDate(Me.cmbBillingDates.SelectedValue.Date)
            Else
                boolInsertDate = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fillComboBoxes()
        Try
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
                Me.cmbClientCode.DisplayMember = "CompanyCode"
                Me.cmbClientCode.ValueMember = "ID"
            Else
                gDsMembers = odbaccess.GetClientsDS
                If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                    fillComboBoxes()
                End If
            End If

            Dim dsSoftware As DataSet
            dsSoftware = odbaccess.GetSoftwareDS
            If Not dsSoftware Is Nothing Then
                Me.cmbSoftware.DataSource = dsSoftware.Tables(0)
                Me.cmbSoftware.ValueMember = "ID"
                Me.cmbSoftware.DisplayMember = "Name"
            End If


            'Dim DsMembers As New DataSet
            'DsMembers = odbaccess.GetClientsDS


            Dim DsDates As New DataSet
            DsDates = odbaccess.GetBillingDatessDS
            If Not DsDates Is Nothing AndAlso Not DsDates.Tables.Count = 0 AndAlso Not DsDates.Tables(0).Rows.Count = 0 Then
                Me.cmbBillingDates.DataSource = DsDates.Tables(0)
                Me.cmbBillingDates.DisplayMember = "Insert_Date"
                Me.cmbBillingDates.ValueMember = "Insert_Date"
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateInvoices.Click
        If Not Me.chkInsertDate.Checked Then
            ErrorProvider1.SetError(cmbBillingDates, "Please select a Date")
            Return
        Else
            ErrorProvider1.SetError(cmbBillingDates, "")
        End If
        If Me.chkCode.Checked Then
            If MsgBox("Are you sure you want generate excel file for " & cmbClientCode.Text & "?", vbYesNo) = vbYes Then
                Dim lClientID As Long
                lClientID = CLng(Me.cmbClientCode.SelectedValue)
                Dim oGenerate_Invoice As New Generate_Invoice(CDate(Me.cmbBillingDates.SelectedValue.Date), lClientID)
            End If
        Else
            If MsgBox("Are you sure you want generate excel files for all clients?", vbYesNo) = vbYes Then
                Dim oGenerate_Invoice As New Generate_Invoice(CDate(Me.cmbBillingDates.SelectedValue.Date), 0)
            End If
        End If



        '1- get all clients that have invoice this week
        '2- get company name, company address, company bank account, client name, cliet address, billing period, invoice no., Issue date,time zone, statemtn, period
        '3- get invoice details
        ' 4- fill excel
        ' 5- convert to pdf
        '6- send by email
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeeklyReport.Click
        Dim oGenerate_Invoice As New Generate_Invoice
        oGenerate_Invoice.GenerateWeeklyReport(CDate(Me.cmbBillingDates.SelectedValue.Date))
    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
End Class
