Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO

Public Class FrmInvoicing

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckPermission()
    End Sub

    Public Sub CheckPermission()

        For Each oRole As Role In gUser.oColRoles
            Select Case CType(oRole.ID, Enumerators.Roles)
                Case Enumerators.Roles.Import_Invoices_files
                    Me.btnImport.Enabled = True
                Case Enumerators.Roles.view_Inserted_Billing
                    Me.btnGenerateInvoice.Enabled = True
                Case Enumerators.Roles.Generate_Invoices
                    Me.btnApprove.Enabled = True
                Case Enumerators.Roles.View_Invoices
                    Me.btnInvoices.Enabled = True
            End Select
        Next
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim frm As New frmImportData
        frm.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateInvoice.Click
        If Application.OpenForms().OfType(Of frmBilling).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmBilling") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmBilling
            frm.Show()
        End If
    End Sub

    Private Sub btnGenerateInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

        Dim frm As New frmApproveInvoicesDate
        frm.ShowDialog()
    End Sub

    Private Sub btnInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoices.Click
        If Application.OpenForms().OfType(Of frmInvoices).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmInvoices") Then
                    frm.WindowState = FormWindowState.Maximized
                End If
            Next
        Else
            Dim frm As New frmInvoices
            frm.Show()
        End If
    End Sub

  
End Class