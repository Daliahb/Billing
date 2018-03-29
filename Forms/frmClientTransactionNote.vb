Public Class frmClientTransactionNote


    Public boolSaved As Boolean
    Public lClientID As Long
    Public strNote As String

    Public Sub New(ByVal lClientID As Long)
        ' This call is required by the designer.
        InitializeComponent()


        Me.lClientID = lClientID
    End Sub

    Private Sub frmClientTransactionNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As DataSet
        ds = odbaccess.GetClientStatemntNotes(lClientID)
        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
            strNote = ds.Tables(0).Rows(0).Item(1).ToString
        End If
        If lClientID > 0 Then
            Me.txtTask.Text = strNote
        End If


        Me.lblDate.Text = "Date: " & Now().ToString("yyyy-MM-dd")

        boolSaved = True
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError As Boolean

        Try
            If Not CheckValidation() Then
                Exit Sub
            End If
            strNote = vbCrLf & vbCrLf & gUser.UserName & " " & Now().ToString("yyyy-MM-dd") & " :" & vbCrLf & Me.txtNote.Text

            boolError = odbaccess.EditClientTransactionNote(lClientID, strNote)

            If boolError Then
                MsgBox("Note added successfully.")
                Me.Close()
            Else
                MsgBox("Error occured!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
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

    Public Function CheckValidation() As Boolean
        Dim boolError As Boolean = True
        If Not Me.txtNote.Text.Length = 0 Then
            ErrorProvider1.SetError(txtNote, "")
        Else
            ErrorProvider1.SetError(txtNote, "Please insert note.")
            boolError = False
        End If
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