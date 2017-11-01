Public Class frmClientStatementOfAccount



    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillComboBoxes()
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        Me.cmbClientCode.SelectedIndex = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not Me.cmbClientCode.SelectedValue Is Nothing Then
            Dim oGenerate_Invoice As New Generate_Invoice
            oGenerate_Invoice.GenerateStatementOfAccountReportForClient(CInt(Me.cmbClientCode.SelectedValue))
            Me.Close()
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
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
        Catch ex As Exception

        End Try

    End Sub


    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
End Class

