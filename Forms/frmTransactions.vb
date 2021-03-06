﻿Public Class frmTransactions

    Dim dsClientStatus As DataSet
    Dim isLoaded As Boolean
    Dim lMCClientID As Long

    Private Sub Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = gBackColor
        Me.Text = Me.Text & " - " & gCountry.ToString
        Me.lblStatus.Text = "    "
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        FillTypes()
        isLoaded = True

        oTCPConnection = New TCPControl()

        AddHandler oTCPConnection.GetClientMCBalance, AddressOf SetClientMCBalance

    End Sub

    Public Sub FillTypes()
        Try
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
                Me.cmbClientCode.DisplayMember = "CompanyCode"
                Me.cmbClientCode.ValueMember = "ID"
            Else
                gDsMembers = odbaccess.GetClientsDS
                If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                    FillTypes()
                End If
            End If


            dsClientStatus = odbaccess.GetClientsStatus

        Catch ex As Exception

        End Try
    End Sub

    Public Sub SetClientMCBalance(lMCClientId, strMCBalance)
        If lMCClientId = Me.lMCClientID Then
            Me.lblMCBalance.Text = Math.Round(CDbl(strMCBalance), 2)
            Me.lblDifference.Text = Math.Round(CDbl(strMCBalance) - CDbl(Me.lblBalance.Text), 2)
        End If
    End Sub

#Region "Controls Events"

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim lClientID As Long = 0
        Dim ds As DataSet
        Dim decBalance As Decimal = 0
        Dim dblTotalCredit, dblTotalDebit, dblTotalClientPayment, dblTotalTransactionBankFees, dblTotalBankFees As Double

        Try
            Me.btnGetMCBalance.Enabled = False
            Me.DataGridView1.Rows.Clear()
            If Not Me.cmbClientCode.SelectedValue Is Nothing Then
                lClientID = CLng(Me.cmbClientCode.SelectedValue)
                ErrorProvider1.SetError(cmbClientCode, "")
            Else
                ErrorProvider1.SetError(cmbClientCode, "Select Client from the list.")
                Exit Sub
            End If

            Me.lblMCBalance.Text = 0

            ds = odbaccess.GetTransactions(lClientID)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = Me.DataGridView1.Rows.Add
                        With Me.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = 0
                            .Cells(1).Value = intCounter + 1
                            .Cells(2).Value = Math.Round(CDbl(dr.Item("Debit")), 2)
                            .Cells(3).Value = Math.Round(CDbl(dr.Item("Credit")), 2)
                            .Cells(4).Value = dr.Item("BankFees").ToString
                            .Cells(5).Value = dr.Item("Note").ToString
                            Try
                                .Cells(6).Value = CDate(dr.Item("Date")).ToString("yyyy-MM-dd")
                            Catch ex As Exception

                            End Try

                            intCounter += 1
                            decBalance = CDec(Math.Round(decBalance + CDbl(dr.Item("Credit")) - CDbl(dr.Item("Debit")), 3))
                            dblTotalCredit += Math.Round(CDbl(dr.Item("Credit")), 2)
                            dblTotalDebit += Math.Round(CDbl(dr.Item("Debit")), 2)
                            .Cells(7).Value = Math.Round(decBalance, 2)
                            .Cells(8).Value = dr.Item("Bank")
                        End With
                    Catch ex As Exception

                    End Try
                Next
                Me.lblTotalCredit.Text = Math.Round(dblTotalCredit, 2).ToString
                Me.lblTotalDebit.Text = Math.Round(dblTotalDebit, 2).ToString
                Me.lblBalance.Text = Math.Round(decBalance, 2).ToString

                If Not ds.Tables.Count = 1 Then
                    dblTotalClientPayment = Math.Round(CDbl(ds.Tables(1).Rows(0).Item("TotalClientPayments")), 2)
                    dblTotalTransactionBankFees = Math.Round(CDbl(ds.Tables(1).Rows(0).Item("TotalTransactionsBankFees")), 2)
                    dblTotalBankFees = Math.Round(CDbl(ds.Tables(1).Rows(0).Item("TotalBankFees")), 2)
                    If Not ds.Tables(1).Rows(0).Item("MCClientID") Is DBNull.Value Then
                        Me.lMCClientID = CLng(ds.Tables(1).Rows(0).Item("MCClientID"))
                    Else
                        Me.lMCClientID = 0
                    End If



                    Me.lblClientPayments.Text = dblTotalClientPayment.ToString
                    Me.lblTransactionBankFees.Text = dblTotalTransactionBankFees.ToString
                    Me.lblBankFees.Text = dblTotalBankFees.ToString
                    Me.lblNoClientOfPayments.Text = ds.Tables(1).Rows(0).Item("NoClientOfPayments").ToString

                    Try
                        If Not dblTotalClientPayment = 0 Then
                            Me.lblPercentage.Text = Math.Round(((dblTotalBankFees - dblTotalTransactionBankFees) / (dblTotalClientPayment)), 2).ToString
                        Else
                            Me.lblPercentage.Text = "0"
                        End If

                    Catch ex As Exception

                    End Try

                    'get MC Balance from the server
                    oTCPConnection.Send("GetClientBalance|" & Me.lMCClientID.ToString & "|")
                End If
            End If

            Me.btnGetMCBalance.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub

    Private Sub cmbClientCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbClientCode.SelectedIndexChanged
        If isLoaded Then
            If Not cmbClientCode.SelectedValue Is Nothing Then
                If Not dsClientStatus Is Nothing AndAlso Not dsClientStatus.Tables.Count = 0 AndAlso Not dsClientStatus.Tables(0).Rows.Count = 0 Then
                    For Each dr As DataRow In dsClientStatus.Tables(0).Rows
                        If CLng(dr.Item("id")) = CLng(cmbClientCode.SelectedValue) Then
                            Me.lblStatus.Text = CType(dr.Item("enumClientStatus"), Enumerators.ClientStatus).ToString
                        End If
                    Next
                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnGetMCBalance.Click
        If oTCPConnection.ConnectToServer Then
            oTCPConnection.Send("GetClientBalance|" & Me.lMCClientID.ToString & "|")
        End If

    End Sub

#End Region
End Class
