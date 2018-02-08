Public Class frmReadInquiry


    Public boolSaved As Boolean
    Public lID As Long
    Public oTask As New Task


    Public Sub New(ByVal lID As Long)
        ' This call is required by the designer.
        InitializeComponent()


        Me.lID = lID
    End Sub

    Private Sub frmReadAssignment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Assignment"
        Dim ds As DataSet = odbaccess.GetInquiryComment(lID)
        SetControls(ds)

        boolSaved = True
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean
        Try
            If Not CheckValidation() Then
                Exit Sub
            End If
            FillObject()

            boolError = odbaccess.EditInquiryComment(lID, oTask.Note)

            If boolError Then
                MsgBox("Operation done successfully.")
                Me.Close()
            Else
                MsgBox("Error occured!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub SetControls(ds As DataSet)
        If Not ds Is Nothing Then
            Me.txtTask.Text = ds.Tables(0).Rows(0).Item("Task").ToString & vbCrLf & ds.Tables(0).Rows(0).Item("Comments").ToString
            ' Me.cmbUsers.SelectedValue = oTask.ToUserID
            Me.lblDate.Text = "Date: " & CDate(ds.Tables(0).Rows(0).Item("DueDate")).ToString("yyyy/MM/dd")
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

    Public Sub FillObject()
        With oTask
            If Not Me.txtNote.Text.Length = 0 Then
                .Note = Me.txtTask.Text & vbCrLf & gUser.UserName & " " & Now().ToString("yyyy-MM-dd") & " :" & vbCrLf & Me.txtNote.Text

                ' .Note = Me.txtNote.Text

            Else
                .Note = Me.txtTask.Text
            End If
            ' .TaskDate = Me.DateTimePicker1.Value.Date

        End With
    End Sub

    Public Function CheckValidation() As Boolean
        Dim boolError As Boolean = True
      
        Return boolError
    End Function

    Public Sub ResetForm()
        Me.txtNote.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New frmTaskRecurrence(Enumerators.EditAdd.Add)
        'frm.Show()
    End Sub



End Class