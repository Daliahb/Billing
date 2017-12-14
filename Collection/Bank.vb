Public Class Bank
    Public ID As Integer
    Public BankName As String
    Public BankAccountName, BankAccountNumber, IBAN, BeneficiaryBankName, BeneficiaryBankAddress, Swift, ABARouting As String
    Public active As Boolean
    Public Sub SetProperties(ByVal dr As DataRow)
        Try
            With dr
                Me.ID = CInt(dr.Item("id"))
                If Not dr.Item("Bank_Name") Is DBNull.Value Then
                    Me.BankName = dr.Item("Bank_Name").ToString
                End If
                If Not dr.Item("Account_Name") Is DBNull.Value Then
                    Me.BankAccountName = dr.Item("Account_Name").ToString
                End If
                If Not dr.Item("Account_Number") Is DBNull.Value Then
                    Me.BankAccountNumber = dr.Item("Account_Number").ToString
                End If
                If Not dr.Item("IBAN") Is DBNull.Value Then
                    Me.IBAN = dr.Item("IBAN").ToString
                End If
                If Not dr.Item("Beneficiary_Bank_Name") Is DBNull.Value Then
                    Me.BeneficiaryBankName = dr.Item("Beneficiary_Bank_Name").ToString
                End If
                If Not dr.Item("Beneficiary_Bank_Address") Is DBNull.Value Then
                    Me.BeneficiaryBankAddress = dr.Item("Beneficiary_Bank_Address").ToString
                End If
                If Not dr.Item("SWIFT") Is DBNull.Value Then
                    Me.Swift = dr.Item("SWIFT").ToString
                End If
                If Not dr.Item("ABARouting") Is DBNull.Value Then
                    Me.ABARouting = dr.Item("ABARouting").ToString
                End If
                If Not dr.Item("active") Is DBNull.Value Then
                    Me.active = CBool(dr.Item("active"))
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class


Public Class ColBank
    Inherits CollectionBase

    Public Sub Add(ByVal oBank As Bank)
        List.Add(oBank)
    End Sub

    Public Sub remove(ByVal oBank As Bank)
        List.Remove(oBank)
    End Sub

    Public Sub Insert(ByVal oBank As Bank, ByVal index As Integer)
        List.Insert(index, oBank)
    End Sub

    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oBank As Bank
        Try
            For Each dr In ds.Tables(0).Rows
                oBank = New Bank
                oBank.SetProperties(dr)
                Me.Add(oBank)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetBank(ByVal lID As Long) As Bank
        Dim boolFound As Boolean
        Dim oBank As New Bank
        For Each oBank In Me.List
            If oBank.ID = lID Then
                boolFound = True
                Exit For
            End If
        Next
        If boolFound Then
            Return oBank
        Else
            Return Nothing
        End If
    End Function

End Class