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
            oTask.Note = ds.Tables(0).Rows(0).Item("Comments").ToString
            oTask.task = ds.Tables(0).Rows(0).Item("Task").ToString
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
                .Note = Me.oTask.Note & vbCrLf & vbCrLf & gUser.UserName & " " & Now().ToString("yyyy-MM-dd") & " :" & vbCrLf & Me.txtNote.Text
                '.Note = gUser.UserName & " " & Now().ToString("yyyy-MM-dd") & " :" & vbCrLf & Me.txtNote.Text
                ' .Note = Me.txtNote.Text

            Else
                .Note = Me.oTask.Note
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

    Public Sub CenterButtons()
        Me.Panel2.Left = CInt((Me.ClientSize.Width / 2) - (Panel2.Width / 2))
    End Sub

    Private Sub FrmCountries_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterButtons()
    End Sub

End Class