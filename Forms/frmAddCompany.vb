Public Class frmAddCompany

    Public enumEditAdd As New Enumerators.EditAdd
    Public lID As Long
    Public oCompany As New Company
    Public boolSaved As Boolean

    Public Sub New(ByVal enumEditAdd As Enumerators.EditAdd, Optional ByVal Company As Company = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumEditAdd = enumEditAdd
        Me.oCompany = Company

    End Sub

    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '      'Me.BackColor = gBackColor

        If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
            Me.Text = "Edit Company"
            ' oCompany = odbaccess.GetCompany(lID)
            SetControls()

        End If
        boolSaved = True
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try

            'If Not CheckValidity() Then
            '    Return
            'End If

            FillObject()


            If Me.enumEditAdd = Enumerators.EditAdd.Add Then
                boolError = odbaccess.insertCompany(oCompany)
            ElseIf Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                boolError = odbaccess.EditCompany(oCompany)
            End If
            If boolError Then
                MsgBox("Operation done successfully.")
                If Me.enumEditAdd = Enumerators.EditAdd.Edit Then
                    Me.Close()
                Else
                    Me.ResetForm()
                End If
            Else
                MsgBox("Error occured!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ResetForm()
        Me.txtName.Text = ""
        Me.txtAddress.Text = ""
        Me.txtBillingEmail.Text = ""
        Me.txtCCEmail.Text = ""
        Me.txtSignature.Text = ""
      
        'Me.ContractCompanyName()
        Me.oCompany = New Company

    End Sub

    Public Sub FillObject()
        If oCompany Is Nothing Then
            oCompany = New Company
        End If

        With Me.oCompany
            .CompanyName = Me.txtName.Text
            .Address = Me.txtAddress.Text
            .BillingEmail = Me.txtBillingEmail.Text
            .CCEmails = Me.txtCCEmail.Text
            .Signature = Me.txtSignature.Text
        End With
    End Sub

    Public Sub SetControls()
        If Not oCompany.Id = 0 Then

            With Me.oCompany
                Me.txtName.Text = .CompanyName
                Me.txtAddress.Text = .Address
                Me.txtBillingEmail.Text = .BillingEmail
                Me.txtCCEmail.Text = .CCEmails
                Me.txtSignature.Text = .signature
            End With
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not boolSaved Then
            Select Case MsgBox("Do you want to save data?", MsgBoxStyle.YesNo)
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


End Class