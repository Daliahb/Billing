Public Class frmClientStatementOfAccount

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillComboBoxes()
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        Me.cmbClientCode.SelectedIndex = 0

        oTCPConnection = New TCPControl()

        AddHandler oTCPConnection.GetAllClientsMCBalances, AddressOf SetClientsMCBalances
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

            Me.cmbStatus.Items.Add(New Obj("Active", Enumerators.ClientStatus.Active))
            Me.cmbStatus.Items.Add(New Obj("Disabled", Enumerators.ClientStatus.Disabled))
            Me.cmbStatus.Items.Add(New Obj("Maple Accounts", Enumerators.ClientStatus.Maple_Accounts))
            Me.cmbStatus.ValueMember = "Value"
            Me.cmbStatus.DisplayMember = "Name"
            Me.cmbStatus.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub

    Public Sub SetClientsMCBalances(strMCClientsBalances As String)

        Dim dt As New System.Data.DataTable()
        Try
            If Not strMCClientsBalances.Length = 0 Then
                Dim arClientBalance() As String
                Dim arBalance() As String
                ' Dim lvitem As ListViewItem
                arClientBalance = strMCClientsBalances.Split(CChar("&"))



                dt.Columns.Add("ClientCode")
                dt.Columns.Add("Balance")

                Dim primaryKey(0) As DataColumn
                primaryKey(0) = dt.Columns("ClientCode")
                dt.PrimaryKey = primaryKey

                For i = 0 To arClientBalance.Length - 2
                    ' lvitem = New ListViewItem
                    Try
                        arBalance = arClientBalance(i).ToString.Split(CChar(":"))
                        dt.Rows.Add(arBalance(0), arBalance(1))
                    Catch ex As Exception

                    End Try

                Next
            End If


            Dim enumClientStatus As Enumerators.ClientStatus
            If Me.chkStatus.Checked AndAlso Not Me.cmbStatus.SelectedItem Is Nothing Then
                enumClientStatus = CType(Me.cmbStatus.SelectedItem.value, Enumerators.ClientStatus)
            Else
                enumClientStatus = 0
            End If
            Dim oGenerate_Invoice As New Generate_Invoice
            oGenerate_Invoice.GenerateStatementOfAccountReport(enumClientStatus, dt)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim enumClientStatus As Enumerators.ClientStatus
        If Me.rbAllClients.Checked Then
            If Me.chkStatus.Checked AndAlso Not Me.cmbStatus.SelectedItem Is Nothing Then
                enumClientStatus = CType(Me.cmbStatus.SelectedItem.value, Enumerators.ClientStatus)
            Else
                enumClientStatus = 0
            End If
            Dim oGenerate_Invoice As New Generate_Invoice
            oGenerate_Invoice.GenerateStatementOfAccountReport(enumClientStatus)
        Else
            If Not Me.cmbClientCode.SelectedValue Is Nothing Then
                Dim oGenerate_Invoice As New Generate_Invoice
                '  oGenerate_Invoice.GenerateStatementOfAccountReportForClient(CInt(Me.cmbClientCode.SelectedValue))
                oGenerate_Invoice.GenerateStatementOfAccountReportForClient_New(CInt(Me.cmbClientCode.SelectedValue), Me.cmbClientCode.Text)
                Me.Close()
            End If
        End If


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnGetSOAMC.Click
        If oTCPConnection.ConnectToServer Then
            oTCPConnection.Send("GetAllClientsBalances|")
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub

    Private Sub rbAllClients_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbAllClients.CheckedChanged
        Me.chkStatus.Enabled = rbAllClients.Checked
        btnGetSOAMC.Enabled = rbAllClients.Checked
    End Sub

    Private Sub rbOneClient_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbOneClient.CheckedChanged
        Me.cmbClientCode.Enabled = rbOneClient.Checked
    End Sub

    Private Sub chkStatus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStatus.CheckedChanged
        Me.cmbStatus.Enabled = chkStatus.Checked
    End Sub


End Class

