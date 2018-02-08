Public Class Task
    Public id As Long
    Public task As String
    Public Note As String
    Public FromUserID As Long
    Public ToUserID As Long
    Public Active As Boolean
    Public IsDone As Boolean
    Public TaskDate As Date
    Public UserName As String

    Public IsRecurrence As Boolean
    Public boolRecurrenceChanged As Boolean 'used in edit

    'Assignment
    Public Priority As New Enumerators.Priority
    Public DueDate As Date
    Public Completeness As Integer
    Public FromUserName As String
    Public ToUserName As String

    Public Sub SetProperties(ByVal dr As DataRow, Optional ByVal isAssignment As Boolean = 0)
        Try
            Me.id = CLng(dr.Item("id"))
            If Not dr.Item("inst_Date") Is DBNull.Value Then
                Me.TaskDate = CDate(dr.Item("inst_Date"))
            End If
            If Not dr.Item("Note") Is DBNull.Value Then
                Me.Note = dr.Item("Note").ToString
            End If
            If Not dr.Item("task") Is DBNull.Value Then
                Me.task = dr.Item("task").ToString
            End If
            If Not dr.Item("FK_FromUser") Is DBNull.Value Then
                Me.FromUserID = CLng(dr.Item("FK_FromUser"))
            End If
            If Not dr.Item("FK_ToUser") Is DBNull.Value Then
                Me.ToUserID = CLng(dr.Item("FK_ToUser"))
            End If
            If Not dr.Item("IsDone") Is DBNull.Value Then
                Me.IsDone = CBool(dr.Item("IsDone"))
            End If
            If Not dr.Item("active") Is DBNull.Value Then
                Me.Active = CBool(dr.Item("active"))
            End If
            If Not isAssignment Then
                If Not dr.Item("IsRecurrence") Is DBNull.Value Then
                    Me.IsRecurrence = CBool(dr.Item("IsRecurrence"))
                End If
                Try
                    If Not dr.Item("UserName") Is DBNull.Value Then
                        Me.UserName = dr.Item("UserName").ToString
                    End If
                Catch ex As Exception

                End Try

            End If

            If isAssignment = True Then
                If Not dr.Item("FromUserName") Is DBNull.Value Then
                    Me.FromUserName = dr.Item("FromUserName").ToString
                End If
                If Not dr.Item("ToUserName") Is DBNull.Value Then
                    Me.ToUserName = dr.Item("ToUserName").ToString
                End If
                If Not dr.Item("PriorityLevel") Is DBNull.Value Then
                    Me.Priority = CLng(dr.Item("PriorityLevel"))
                End If
                If Not dr.Item("Completeness") Is DBNull.Value Then
                    Me.Completeness = CLng(dr.Item("Completeness"))
                End If
                If Not dr.Item("DueDate") Is DBNull.Value Then
                    Me.DueDate = CDate(dr.Item("DueDate"))
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
End Class

Public Class ColTasks
    Inherits CollectionBase

    Public Sub Add(ByVal oTask As Task)
        List.Add(oTask)
    End Sub

    Public Sub SetProperties(ByVal ds As DataSet, Optional ByVal isAssignment As Boolean = 0)
        Dim dr As DataRow
        Dim oTask As Task
        Try
            For Each dr In ds.Tables(0).Rows
                oTask = New Task
                oTask.SetProperties(dr, isAssignment)
                Me.Add(oTask)
            Next
            'If ds.Tables.Count = 2 Then
            '    oTask.SetRecurrenceProperties(ds.Tables(1).Rows(1))
            'End If
        Catch ex As Exception

        End Try
    End Sub

End Class