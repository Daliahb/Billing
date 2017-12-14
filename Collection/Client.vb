Public Class Client
    Public ID, ContractMapleNameID, ContractMapleBankID, AccountManagerID As Long
    Public CompanyName, ContractMapleName, ContractMapleBank, AccountManagerName As String
    Public CompanyCode, strOutboundNames As String
    Public timezone As String
    Public Address As String
    Public Period, Statement, CreditLimit As Integer
    Public BillingEmail, CCEmail As String
    Public BankAccountName, BankAccountNumber, IBAN, BeneficiaryBankName, BeneficiaryBankAddress, Swift, ABARouting As String
    Public Agreement As New Enumerators.Agreement

    Public Sub SetProperties(ByVal dr As DataRow)
        Try
            With dr
                Me.ID = CLng(dr.Item("id"))
                If Not dr.Item("CompanyName") Is DBNull.Value Then
                    Me.CompanyName = dr.Item("CompanyName").ToString
                End If
                If Not dr.Item("CompanyCode") Is DBNull.Value Then
                    Me.CompanyCode = dr.Item("CompanyCode").ToString
                End If
                If Not dr.Item("TimeZone") Is DBNull.Value Then
                    Me.timezone = dr.Item("TimeZone").ToString
                End If
                If Not dr.Item("Address") Is DBNull.Value Then
                    Me.Address = dr.Item("Address").ToString
                End If
                If Not dr.Item("Invoice_Period") Is DBNull.Value Then
                    Me.Period = CInt(dr.Item("Invoice_Period"))
                End If
                If Not dr.Item("Statement") Is DBNull.Value Then
                    Me.Statement = CInt(dr.Item("Statement"))
                End If
                If Not dr.Item("Billing_Email") Is DBNull.Value Then
                    Me.BillingEmail = dr.Item("Billing_Email").ToString
                End If
                If Not dr.Item("CCEmails") Is DBNull.Value Then
                    Me.CCEmail = dr.Item("CCEmails").ToString
                End If
                If Not dr.Item("BankAccountName") Is DBNull.Value Then
                    Me.BankAccountName = dr.Item("BankAccountName").ToString
                End If
                If Not dr.Item("BankAccountNumber") Is DBNull.Value Then
                    Me.BankAccountNumber = dr.Item("BankAccountNumber").ToString
                End If
                If Not dr.Item("IBAN") Is DBNull.Value Then
                    Me.IBAN = dr.Item("IBAN").ToString
                End If
                If Not dr.Item("BeneficiaryBankName") Is DBNull.Value Then
                    Me.BeneficiaryBankName = dr.Item("BeneficiaryBankName").ToString
                End If
                If Not dr.Item("BeneficiaryBankAddress") Is DBNull.Value Then
                    Me.BeneficiaryBankAddress = dr.Item("BeneficiaryBankAddress").ToString
                End If
                If Not dr.Item("Swift") Is DBNull.Value Then
                    Me.Swift = dr.Item("Swift").ToString
                End If
                If Not dr.Item("ABARouting") Is DBNull.Value Then
                    Me.ABARouting = dr.Item("ABARouting").ToString
                End If
                If Not dr.Item("Credit_Limit") Is DBNull.Value Then
                    Me.CreditLimit = CInt(dr.Item("Credit_Limit").ToString)
                End If
                If Not dr.Item("FK_Companies") Is DBNull.Value Then
                    Me.ContractMapleNameID = CLng(dr.Item("FK_Companies").ToString)
                End If
                If Not dr.Item("FK_BankAccounts") Is DBNull.Value Then
                    Me.ContractMapleBankID = CLng(dr.Item("FK_BankAccounts").ToString)
                End If
                If Not dr.Item("ContractMapleName") Is DBNull.Value Then
                    Me.ContractMapleName = dr.Item("ContractMapleName").ToString
                End If
                If Not dr.Item("ContractMapleBank") Is DBNull.Value Then
                    Me.ContractMapleBank = dr.Item("ContractMapleBank").ToString
                End If
                If Not dr.Item("FK_AccountManager") Is DBNull.Value Then
                    Me.AccountManagerID = CLng(dr.Item("FK_AccountManager").ToString)
                End If
                If Not dr.Item("AccountManagerName") Is DBNull.Value Then
                    Me.AccountManagerName = dr.Item("AccountManagerName").ToString
                End If
                If Not dr.Item("Agreement") Is DBNull.Value Then
                    Me.Agreement = CType(dr.Item("Agreement"), Enumerators.Agreement)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class


Public Class ColClient
    Inherits CollectionBase

    Public Sub Add(ByVal oClient As Client)
        List.Add(oClient)
    End Sub

    Public Sub remove(ByVal oClient As Client)
        List.Remove(oClient)
    End Sub

    Public Sub Insert(ByVal oClient As Client, ByVal index As Integer)
        List.Insert(index, oClient)
    End Sub

    Public Sub SetProperties(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim oClient As Client
        Try
            For Each dr In ds.Tables(0).Rows
                oClient = New Client
                oClient.SetProperties(dr)
                Me.Add(oClient)
            Next
            'If Not ds.Tables.Count < 2 Then
            '    oClient.OutboundNames = ds.Tables(1)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetClient(ByVal lID As Long) As Client
        Dim boolFound As Boolean
        Dim oClient As New Client
        For Each oClient In Me.List
            If oClient.ID = lID Then
                boolFound = True
                Exit For
            End If
        Next
        If boolFound Then
            Return oClient
        Else
            Return Nothing
        End If
    End Function

End Class