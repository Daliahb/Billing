Public Class frmAddInquiry

    Public enumEditAdd As New Enumerators.EditAdd
    Public boolSaved, boolClientsBanks, isLoaded As Boolean

    Dim lClientId, lTPID, lOPID, lUsersCategory, lInquiryID As Long
    Dim dDate As Date
    Public strTask As String
    Dim dsOP, dsTP, dsUsers As DataSet
    Dim enumPriority As Enumerators.Priority
    Dim strToUsersIDs As String

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal lInquiryID As Long = 0)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumEditAdd = enumEditAdd
        Me.lInquiryID = lInquiryID

    End Sub

    Private Sub frmAddInquiry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbClientCode.AutoCompleteSource = AutoCompleteSource.ListItems
        FillDatasets()
        isLoaded = True
        If enumEditAdd = Enumerators.EditAdd.Edit Then
            SetControls()
        End If

  
        '        boolSaved = True
    End Sub

    Public Function CheckValidity() As Boolean
        Dim boolError = True

        If Me.cmbClientCode.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbClientCode, "Select client from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(cmbClientCode, "")
        End If

        If Me.txtTask.Text.Length = 0 Then
            ErrorProvider1.SetError(txtTask, "Pleaes insert data in Task box.")
            boolError = False
        Else
            ErrorProvider1.SetError(txtTask, "")
        End If
        'For i = 0 To Me.chkUsersList.Items.Count - 1
        '    If Me.chkUsersList.Items(i).selected Then

        '        Exit For
        '    End If
        'Next
        If Me.chkUsersList.CheckedItems.Count = 0 Then
            ErrorProvider1.SetError(chkUsersList, "Please select at least 1 User Name from the list.")
            boolError = False
        Else
            ErrorProvider1.SetError(chkUsersList, "")
        End If
        Return boolError
    End Function

    Public Sub FillDatasets()
        If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
            Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
            Me.cmbClientCode.DisplayMember = "CompanyCode"
            Me.cmbClientCode.ValueMember = "ID"
        Else
            gDsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                FillDatasets()
            End If
        End If

        Dim ds As DataSet
        ds = odbaccess.GetUserCategoriesDS()
        If Not ds Is Nothing Then
            Me.cmbUsersCategories.DataSource = ds.Tables(0)
            Me.cmbUsersCategories.DisplayMember = "Category"
            Me.cmbUsersCategories.ValueMember = "ID"
        End If
        Me.cmbUsersCategories.SelectedIndex = -1

        Me.cmbPriority.DataSource = Nothing
        Me.cmbPriority.Items.Add(New Obj("Low", Enumerators.Priority.Low))
        Me.cmbPriority.Items.Add(New Obj("Medium", Enumerators.Priority.Medium))
        Me.cmbPriority.Items.Add(New Obj("High", Enumerators.Priority.High))
        Me.cmbPriority.ValueMember = "Value"
        Me.cmbPriority.DisplayMember = "Name"
        Me.cmbPriority.SelectedIndex = 0
    End Sub

    Public Sub FillchkUsersList()
        dsUsers = Nothing
        Me.chkUsersList.Items.Clear()
        dsUsers = odbaccess.GetUsersbyCategoryID(CInt(Me.cmbUsersCategories.SelectedValue))
        If Not dsUsers Is Nothing AndAlso Not dsUsers.Tables().Count = 0 AndAlso Not dsUsers.Tables(0).Rows.Count = 0 Then
            For Each dr As DataRow In dsUsers.Tables(0).Rows
                Me.chkUsersList.Items.Add(dr.Item("UserName").ToString, False)
            Next
        End If
    End Sub

    Public Sub FillOPTPComboBox()
        dsOP = Nothing
        cmbOP.DataSource = Nothing
        dsOP = odbaccess.getClientOPsTPs(CLng(Me.cmbClientCode.SelectedValue), Enumerators.OPTP.OP)
        If Not dsOP Is Nothing AndAlso Not dsOP.Tables().Count = 0 AndAlso Not dsOP.Tables(0).Rows.Count = 0 Then
            Me.cmbOP.DataSource = dsOP.Tables(0)
            Me.cmbOP.ValueMember = "ID"
            Me.cmbOP.DisplayMember = "CompanyPoint"
        End If

        dsTP = Nothing
        cmbTP.DataSource = Nothing
        dsTP = odbaccess.getClientOPsTPs(CLng(Me.cmbClientCode.SelectedValue), Enumerators.OPTP.TP)
        If Not dsTP Is Nothing AndAlso Not dsTP.Tables().Count = 0 AndAlso Not dsTP.Tables(0).Rows.Count = 0 Then
            Me.cmbTP.DataSource = dsTP.Tables(0)
            Me.cmbTP.ValueMember = "ID"
            Me.cmbTP.DisplayMember = "CompanyPoint"
        End If
    End Sub

    Public Function getUsersIDs() As String
        Dim strIDs As New System.Text.StringBuilder("")
        Try
            For Each item In Me.chkUsersList.CheckedItems
                For Each dr As DataRow In dsUsers.Tables(0).Rows
                    If item.ToString = dr.Item("UserName").ToString Then
                        strIDs.Append(dr.Item("ID").ToString & ",")
                        Exit For
                    End If
                Next
            Next
            Return strIDs.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub SetControls()
        Dim ds As DataSet
        ds = odbaccess.GetInquiry(lInquiryID)
        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                For i As Integer = 0 To Me.cmbPriority.Items.Count - 1
                    If Me.cmbPriority.Items(i).name = CType(dr.Item("enumPriorityLevel"), Enumerators.Priority).ToString Then
                        Me.cmbPriority.SelectedIndex = i
                        Exit For
                    End If
                Next

                Me.cmbClientCode.SelectedValue = CLng(dr.Item("FK_Client"))

                Me.chkCompanyPoints.Checked = False
                If CInt(dr.Item("FK_OP")) > 0 Then
                    Me.chkCompanyPoints.Checked = True
                    Me.rbOP.Checked = True
                    Me.cmbOP.SelectedValue = CInt(dr.Item("FK_OP"))
                Else
                    Me.rbOP.Enabled = False
                    Me.cmbOP.Enabled = False
                End If
                If CInt(dr.Item("FK_TP")) > 0 Then
                    Me.chkCompanyPoints.Checked = True
                    Me.rbTP.Checked = True
                    Me.cmbTP.SelectedValue = CInt(dr.Item("FK_TP"))
                Else
                    Me.rbTP.Enabled = False
                    Me.cmbTP.Enabled = False
                End If

                Me.txtTask.Text = dr.Item("Task").ToString

                Me.DateTimePicker1.Value = CDate(dr.Item("DueDate"))

                Me.cmbUsersCategories.SelectedValue = CInt(dr.Item("FK_UsersCategory"))
                CheckUsersInUsersList(ds.Tables(1))
            End With
        End If


        '        chkboxlist1.Items.FindByValue(dtDataTable.Rows(i).Item("Name")).Selected = True
    End Sub

    Public Sub FillObject()
        enumPriority = CType(Me.cmbPriority.SelectedItem.value, Enumerators.Priority)
        lClientId = CLng(Me.cmbClientCode.SelectedValue)

        If Me.chkCompanyPoints.Checked Then
            If rbOP.Checked And Not cmbOP.SelectedValue Is Nothing Then
                lOPID = CLng(Me.cmbOP.SelectedValue)
            Else
                lOPID = 0
            End If
            If rbTP.Checked And Not cmbTP.SelectedValue Is Nothing Then
                lTPID = CLng(Me.cmbTP.SelectedValue)
            Else
                lTPID = 0
            End If
        Else
            lOPID = 0
            lTPID = 0
        End If
        strTask = Me.txtTask.Text
        dDate = Me.DateTimePicker1.Value
        lUsersCategory = CLng(cmbUsersCategories.SelectedValue)
        strToUsersIDs = getUsersIDs()
    End Sub

    Public Sub CheckUsersInUsersList(dt As DataTable)
        If Not dt Is Nothing And Not dt.Rows.Count = 0 Then
            For i = 0 To dt.Rows.Count - 1
                For j = 0 To Me.chkUsersList.Items.Count - 1
                    If Me.chkUsersList.Items(j).ToString = CStr(dt.Rows(i).Item("UserName")) Then
                        Me.chkUsersList.SetItemChecked(j, True)
                    End If
                Next
            Next
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Select Case MsgBox("Do you want to save data?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                btnSave_Click(Me, New System.EventArgs)
            Case MsgBoxResult.No
                Me.Close()
            Case MsgBoxResult.Cancel
                Return
        End Select

    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave, cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub

    Private Sub cmbClientCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbClientCode.SelectedIndexChanged
        If isLoaded Then
            FillOPTPComboBox()
        End If
    End Sub

    Private Sub rbOP_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbOP.CheckedChanged
        Me.cmbOP.Enabled = rbOP.Checked
    End Sub

    Private Sub rbTP_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbTP.CheckedChanged
        Me.cmbTP.Enabled = rbTP.Checked
    End Sub

    Private Sub cmbUsersCategories_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbUsersCategories.SelectedIndexChanged
        If isLoaded Then
            FillchkUsersList()
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            If Not CheckValidity() Then
                Return
            End If

            FillObject()
            'lClientId long,enumPriority int,lOPID long,lTPID long,strTask nvarchar(2000),lUsersCategory long,lUserID long,dDate date,strToUsersIDs
            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.InsertInquiry(lClientId, enumPriority, lOPID, lTPID, strTask, dDate, lUsersCategory, strToUsersIDs)
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditInquiry(lInquiryID, lClientId, enumPriority, lOPID, lTPID, strTask, dDate, lUsersCategory, strToUsersIDs)
            End If
            If boolError Then
                MsgBox("Operation done successfully.")
                'boolSaved = True
                'gDsMembers = Nothing
                'gDsClientsBanks = Nothing
                'gDsMembers = odbaccess.GetClientsDS
                'gDsClientsBanks = odbaccess.GetClientsBanksDS
                Me.Close()
            Else
                MsgBox("Error occured!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCompanyPoints.CheckedChanged
        Me.rbTP.Enabled = chkCompanyPoints.Checked
        Me.rbOP.Enabled = chkCompanyPoints.Checked
        If chkCompanyPoints.Checked = False Then
            Me.cmbOP.Enabled = False
            Me.cmbTP.Enabled = False
        Else
            If rbOP.Checked Then
                Me.cmbOP.Enabled = True
            End If
            If rbTP.Checked Then
                Me.cmbTP.Enabled = True
            End If
        End If
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        For i As Integer = 0 To chkUsersList.Items.Count - 1
            chkUsersList.SetItemChecked(i, True)
        Next
        Me.chkSelectAll.Checked = False
    End Sub

    Private Sub chkClearAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkClearAll.CheckedChanged
        For i As Integer = 0 To chkUsersList.Items.Count - 1
            chkUsersList.SetItemChecked(i, False)
        Next
        Me.chkClearAll.Checked = False
    End Sub
End Class