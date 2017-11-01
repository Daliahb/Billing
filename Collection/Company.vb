Public Class Company
    Public ID As Integer
    Public CompanyName As String
    Public Address, BillingEmail, CCEmails, Signature As String

    Public Sub SetProperties(ByVal dr As DataRow)
        Try
            With dr
                Me.ID = CInt(dr.Item("id"))
                If Not dr.Item("Name") Is DBNull.Value Then
                    Me.CompanyName = dr.Item("Name").ToString
                End If
                If Not dr.Item("Address") Is DBNull.Value Then
                    Me.Address = dr.Item("Address").ToString
                End If
                If Not dr.Item("Billing_Email") Is DBNull.Value Then
                    Me.BillingEmail = dr.Item("Billing_Email").ToString
                End If
                If Not dr.Item("CC_Emails") Is DBNull.Value Then
                    Me.CCEmails = dr.Item("CC_Emails").ToString
                End If
                If Not dr.Item("EmailSignature") Is DBNull.Value Then
                    Me.Signature = dr.Item("EmailSignature").ToString
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class


Public Class ColCompany
    Inherits CollectionBase

    Public Sub Add(ByVal oCompany As Company)
        List.Add(oCompany)
    End Sub

    Public Sub remove(ByVal oCompany As Company)
        List.Remove(oCompany)
    End Sub

    Public Function getByID(ByVal lID As Long) As Company
        For Each ocompany As Company In Me
            If ocompany.ID = lID Then
                Return ocompany
            End If
        Next
        Return Nothing
    End Function

    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oCompany As Company
        Try
            For Each dr In ds.Tables(0).Rows
                oCompany = New Company
                oCompany.SetProperties(dr)
                Me.Add(oCompany)
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class