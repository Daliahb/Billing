Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient.MySqlConnection
Imports MySql.Data.MySqlClient.MySqlException
Imports MySql.Data.MySqlClient.MySqlParameter


Public Class DBAccess
    Dim oSelectCommand As New MySqlCommand
    Dim oParam As New MySqlParameter
    Dim oDataAdapter As New MySqlDataAdapter
    Public oConnection As New MySqlConnection
    ' Public oTrans As SqlClient.SqlTransaction
    Public oTrans As MySqlTransaction


    Public ds As DataSet
    Public sql As String

    Public Sub New()
        'Real Online  DB
        ' oConnection.ConnectionString = "server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337;User Id=maple_db_user;Password=5skqi5ygv3ciiBF9LDf362uW;Persist Security Info=True;database=voip_billing_system"

        'Test  DB
        oConnection.ConnectionString = "server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337;User Id=maple_db_user_dev;Password=xee1lahnaeyoa0iethaeJoo7;Persist Security Info=True;database=voip_billing_system_dev"

        'Armenia DB
        'oConnection.ConnectionString = "server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337;User Id=maple_yerevan;Password=KeePa1thee5naXaeZunakuge;Persist Security Info=True;database=voip_billing_system_mapleexpress_yerevan"

        'Armenia Test
        'oConnection.ConnectionString = "server=localhost;User Id=root;Password=root;Persist Security Info=false;database=voip_billing_system_mapleexpress_yerevan"
    End Sub

#Region "Get"

    Public Function GetClient(ByVal lID As Long) As Client
        Dim oClient As New Client
        Dim ds As New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetClientByID"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "@ID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oClient.SetProperties(ds.Tables(0).Rows(0))
            End If

            Return oClient
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetClients(ByVal strCompany As String, ByVal lAccountManager As Integer, ByVal lAgreement As Integer, ByVal lBankAccount As Integer, ByVal lCompanyAccount As Integer, boolFromMC As Boolean, enumStatus As Integer) As ColClient
        ds = New DataSet
        Dim oColClient As New ColClient

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetClients"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strCompany"
                .Value = strCompany
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lAccountManager"
                .Value = lAccountManager
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lAgreement"
                .Value = lAgreement
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankAccount"
                .Value = lBankAccount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lCompanyAccount"
                .Value = lCompanyAccount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolFromMC"
                .Value = boolFromMC
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumStatus"
                .Value = enumStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oColClient.SetProperties(ds)
            End If

            Return oColClient
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetBanks() As ColBank
        ds = New DataSet
        Dim oColBank As New ColBank

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetBanks"

            'oParam = New MySqlParameter
            'With oParam
            '    .ParameterName = "@boolStatus"
            '    .Value = True
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New MySqlParameter
            'With oParam
            '    .ParameterName = "@boolActive"
            '    .Value = True
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oColBank.SetProperties(ds)
            End If

            Return oColBank
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetOutboundNames(ByVal lClientID As Long) As DataSet
        ds = New DataSet

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetOutboundNames"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetEmailInfoByInvoiceID(ByVal strInvoiceNo As String) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetEmailInfoByInvoiceID"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strInvoiceIds"
                .Value = strInvoiceNo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCompany(ByVal lID As Long) As Company
        Dim oCompany As New Company
        Dim ds As New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCompanyByID"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "@ID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oCompany.SetProperties(ds.Tables(0).Rows(0))
            End If

            Return oCompany
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCompanies() As ColCompany
        ds = New DataSet
        Dim oColCompany As New ColCompany

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCompanies"

            'oParam = New MySqlParameter
            'With oParam
            '    .ParameterName = "@boolStatus"
            '    .Value = True
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New MySqlParameter
            'With oParam
            '    .ParameterName = "@boolActive"
            '    .Value = True
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oColCompany.SetProperties(ds)
            End If

            Return oColCompany
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetCompaniesDS() As DataSet
        ds = New DataSet
        Dim oColCompany As New ColCompany

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCompaniesDS"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetBanksDS() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetBanksDS"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetUserCategoriesDS() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetUserCategoriesDS"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetSoftwareDS() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetSoftwareDS"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetClientsDS() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetClientsDS"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetClientsBanksDS() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetClientsBanksDS"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetBillingDatessDS() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.Text
            oSelectCommand.CommandText = "select distinct Insert_Date from billing order by Insert_Date desc"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetBillingClients(ByVal dInsertedDate As Date) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetBillingClients"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dInsertDate"
                .Value = dInsertedDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GenerateWeeklyReport(ByVal dInsertedDate As Date) As DataSet

        ds = New DataSet

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GenerateWeeklyReport"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dInsertDate"
                .Value = dInsertedDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetBillingSearch(ByRef lClientID As Long, ByRef lSoftware As Long, ByRef boolPeriodDate As Boolean, ByRef dtFrom As Date, ByRef dtTo As Date, ByRef boolInsertDate As Boolean, ByRef dtInsertDate As Date, ByVal boolInbound As Boolean) As DataSet
        ds = New DataSet

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetBillingSearch"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lSoftware"
                .Value = lSoftware
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolPeriodDate"
                .Value = boolPeriodDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dtFrom"
                .Value = dtFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dtTo"
                .Value = dtTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolInsertDate"
                .Value = boolInsertDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dtInsertDate"
                .Value = dtInsertDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolInbound"
                .Value = boolInbound
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetInvoicesSearch(ByRef lClientID As Long, ByRef boolEmail As Boolean, ByRef boolSent As Boolean, ByRef boolPeriodDate As Boolean, ByRef dtFrom As Date, ByRef dtTo As Date, ByRef boolInsertDate As Boolean, ByRef dtInsertDate As Date) As DataSet
        ds = New DataSet
        Dim oColCompany As New ColCompany

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetInvoicesSearch"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolEmail"
                .Value = boolEmail
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolSent"
                .Value = boolSent
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolPeriodDate"
                .Value = boolPeriodDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dtFrom"
                .Value = dtFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dtTo"
                .Value = dtTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolInsertDate"
                .Value = boolInsertDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dtInsertDate"
                .Value = dtInsertDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetPurchasesSearch(ByRef lClientID As Long, ByRef boolPeriodDate As Boolean, ByRef dtFrom As Date, ByRef dtTo As Date, ByRef boolInsertDate As Boolean, ByRef dtInsertDate As Date, ByRef enumStatus As Enumerators.ClientStatus) As DataSet
        ds = New DataSet

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetPurchasesSearch"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolPeriodDate"
                .Value = boolPeriodDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dtFrom"
                .Value = dtFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dtTo"
                .Value = dtTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolInsertDate"
                .Value = boolInsertDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dtInsertDate"
                .Value = dtInsertDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumStatus"
                .Value = enumStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetInvoiceDetails(ByVal lClientID As Long, ByVal dInsertedDate As Date) As DataSet
        ds = New DataSet

        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetInvoiceDetails"


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dInsertDate"
                .Value = dInsertedDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetRatesByCode(ByVal strCode As String, ByVal lTypeID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetRatesByCode"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strCode"
                .Value = strCode
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetRatesByProvider(ByVal lClientID As Long, ByVal lTypeID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetRatesByProvider"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetClientsStatus() As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetClientsStatus"

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetStatementOfAccount(enumClientStatus As Enumerators.ClientStatus) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetStatementOfAccount"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumStatus"
                .Value = enumClientStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetStatementOfAccountForClient(ByVal lClientID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetStatementOfAccountForClient"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetStatementOfAccountForClient_New(ByVal lClientID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetStatementOfAccountForClient-seperated"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetEmailsInfo(ByVal dInstDate As Date) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetEmailsInfo"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dInstDate"
                .Value = dInstDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetRatesByCountry(ByVal boolCode As Boolean, ByVal strCode As String, ByVal boolCountry As Boolean, ByVal strCountry As String, ByVal lClientID As Long, ByVal lTypeID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetRatesByCountry"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolCode"
                .Value = boolCode
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strCode"
                .Value = strCode
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolCountry"
                .Value = boolCountry
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strCountry"
                .Value = strCountry
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function getActiveCodes(ByVal lTypeID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "getActiveCodes"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetActiveProviders(ByVal lTypeID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetActiveProviders"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetAllRates(ByVal lTypeID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetAllRates"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function getEmailBody() As String
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "getEmailBody"


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds.Tables(0).Rows(0).Item(0).ToString
            End If
            Return ""
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetUsers() As ColUser
        Dim oColUser As New ColUser
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetUsers"


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oColUser.SetProperties(ds)
                Return oColUser
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function getPerformanctReport(ByVal lCount As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "getPerformanceReport"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lCount"
                .Value = lCount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function getCompanyPerformanctReport(ByVal lCount As Integer, ByVal isByCountry As Boolean) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure

            If isByCountry Then
                oSelectCommand.CommandText = "getCompanyPerformanceReportByCountry"
            Else
                oSelectCommand.CommandText = "getCompanyPerformanceReport"
            End If


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lCount"
                .Value = lCount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetVouchers(ByVal boolClient As Boolean, ByVal lClientID As Integer, ByVal boolDate As Boolean, ByVal dFromDate As Date, ByVal dToDate As Date, ByVal lBankID As Integer, ByVal lType As Integer, enumStatus As Enumerators.ClientStatus) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetVouchers"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolClient"
                .Value = boolClient
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = boolDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = dFromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = dToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankID"
                .Value = lBankID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lType"
                .Value = lType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumStatus"
                .Value = enumStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetClientsPayments(ByVal boolClient As Boolean, ByVal lClientID As Long, ByVal boolDate As Boolean, ByVal dFromDate As Date, ByVal dToDate As Date, ByVal lBankID As Integer, enumStatus As Enumerators.ClientStatus) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetClientsPayments"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolClient"
                .Value = boolClient
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = boolDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = dFromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = dToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankID"
                .Value = lBankID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumStatus"
                .Value = enumStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetMaplePayments(ByVal boolClient As Boolean, ByVal lClientID As Long, ByVal boolDate As Boolean, ByVal dFromDate As Date, ByVal dToDate As Date, ByVal lBankID As Integer, enumStatus As Enumerators.ClientStatus) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetMaplePayments"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolClient"
                .Value = boolClient
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = boolDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = dFromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = dToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankID"
                .Value = lBankID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumStatus"
                .Value = enumStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetTransactions(ByVal lClientID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetTransactions"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetInquiryComment(ByVal lIquiryID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetInquiryComment"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lInquiryID"
                .Value = lIquiryID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetInquiries(boolFromUser As Boolean, lFromUserID As Long, boolCheckDone As Boolean, boolDone As Boolean, boolDate As Boolean, dFromDate As Date, dToDate As Date) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetInquiries"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolFromUser"
                .Value = boolFromUser
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lFromUserID"
                .Value = lFromUserID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolCheckDone"
                .Value = boolCheckDone
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolDone"
                .Value = boolDone
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolDate"
                .Value = boolDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dFromDate"
                .Value = dFromDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dToDate"
                .Value = dToDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetInquiry(lInquiryID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetInquiry"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lInquiryID"
                .Value = lInquiryID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function getClientOPsTPs(lClientID As Long, enumOPTP As Enumerators.OPTP) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "getClientOPsTPs"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "OPTP"
                .Value = enumOPTP
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function GetUsersbyCategoryID(intCategoryID As Integer) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetUsersbyCategoryID"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "intCategoryID"
                .Value = intCategoryID
            End With
            oSelectCommand.Parameters.Add(oParam)


            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Return ds
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function


#End Region

#Region "Insert"
    Public Function insertClient(ByVal oClient As Client) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertClient"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CompanyName"
                .Value = oClient.CompanyName
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CompanyCode"
                .Value = oClient.CompanyCode
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Address"
                .Value = oClient.Address
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "TimeZone"
                .Value = oClient.timezone
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Period"
                .Value = oClient.Period
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Statement"
                .Value = oClient.Statement
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BillingEmail"
                .Value = oClient.BillingEmail
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CCEmail"
                .Value = oClient.CCEmail
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankAccountName"
                .Value = oClient.BankAccountName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankAccountNumber"
                .Value = oClient.BankAccountNumber
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "IBAN"
                .Value = oClient.IBAN
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BeneficiaryBankName"
                .Value = oClient.BeneficiaryBankName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BeneficiaryBankAddress"
                .Value = oClient.BeneficiaryBankAddress
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Swift"
                .Value = oClient.Swift
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "ABARouting"
                .Value = oClient.ABARouting
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CreditLimit"
                .Value = oClient.CreditLimit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "ContractMapleNameID"
                .Value = oClient.ContractMapleNameID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "ContractMapleBankID"
                .Value = oClient.ContractMapleBankID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "AccountManagerID"
                .Value = oClient.AccountManagerID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strOutboundNames"
                .Value = oClient.strOutboundNames
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lAgreement"
                .Value = oClient.Agreement
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumStatus"
                .Value = oClient.Status
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            '    oConnection.Close()
            Return False

        End Try
    End Function

    Public Function insertBank(ByVal oBank As Bank) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertBank"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankName"
                .Value = oBank.BankName
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankAccountName"
                .Value = oBank.BankAccountName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankAccountNumber"
                .Value = oBank.BankAccountNumber
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "IBAN"
                .Value = oBank.IBAN
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BeneficiaryBankName"
                .Value = oBank.BeneficiaryBankName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BeneficiaryBankAddress"
                .Value = oBank.BeneficiaryBankAddress
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Swift"
                .Value = oBank.Swift
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "ABARouting"
                .Value = oBank.ABARouting
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function AddPurchaseNote(ByVal strNote As String, ByVal lPurchaseId As Integer) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "AddPurchaseNote"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lPurchaseId"
                .Value = lPurchaseId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function insertCompany(ByVal oCompany As Company) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertCompany"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CompanyName"
                .Value = oCompany.CompanyName
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Address"
                .Value = oCompany.Address
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BillingEmail"
                .Value = oCompany.BillingEmail
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CCEmails"
                .Value = oCompany.CCEmails
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "EmailSignature"
                .Value = oCompany.Signature
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertMapleBankFees(ByVal lId As Long, ByVal dblCredit As Double, ByVal dblDebit As Double) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertMapleBankFees"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lId"
                .Value = lId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblCredit"
                .Value = dblCredit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblDebit"
                .Value = dblDebit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertHistory(ByVal strNote As String, ByVal lType As Integer) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertHistory"
            oSelectCommand.Connection = oConnection

            'lType int,lTypeID int,lUserID int,enumHistoryAction int,strNote
            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lType"
                .Value = lType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = 0
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumHistoryAction"
                .Value = lType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertOffer(ByVal str As String, ByVal lClientID As Long, ByVal lTypeID As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertOffer"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "str"
                .Value = str
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertClientPayment(ByVal lClientId As Long, ByVal dblClientAmount As Double, ByVal dblRecievedAmount As Double, ByVal dDate As Date, ByVal strNote As String, ByVal lBankId As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertClientPayment"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientId"
                .Value = lClientId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblClientAmount"
                .Value = dblClientAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblRecievedAmount"
                .Value = dblRecievedAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankId"
                .Value = lBankId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertMaplePayment(ByVal lClientId As Long, ByVal dblPaidAmount As Double, ByVal dblRecievedAmount As Double, ByVal dDate As Date, ByVal strNote As String, ByVal lBankId As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertMaplePayment"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientId"
                .Value = lClientId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblPaidAmount"
                .Value = dblPaidAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblRecievedAmount"
                .Value = dblRecievedAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankId"
                .Value = lBankId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertVoucher(ByVal lClientId As Long, ByVal dblCredit As Double, ByVal dblDebit As Double, ByVal dDate As Date, ByVal strNote As String, ByVal lBankId As Long, ByVal lType As Long, ByVal strType As String) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertVoucher"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientId"
                .Value = lClientId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblCredit"
                .Value = dblCredit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblDebit"
                .Value = dblDebit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankId"
                .Value = lBankId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lVoucherType"
                .Value = lType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strType"
                .Value = strType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertClientBankFees(ByVal lId As Long, ByVal dblCredit As Double, ByVal dblDebit As Double) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertClientBankFees"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lId"
                .Value = lId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblCredit"
                .Value = dblCredit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblDebit"
                .Value = dblDebit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function InsertUser(ByVal oUser As User) As Boolean
        Dim strRoleIDs As New System.Text.StringBuilder
        Try
            For Each oRole As Role In oUser.oColRoles
                strRoleIDs.Append(oRole.ID)
                strRoleIDs.Append(",")
            Next
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertUser"
            oSelectCommand.Connection = oConnection


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strUserName"
                .Value = oUser.UserName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strPassword"
                .Value = oUser.Password
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lAccountManager"
                .Value = oUser.lAccountManager
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "IsAccountManager"
                .Value = oUser.IsAccountManager
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strRoleIDs"
                .Value = strRoleIDs.ToString
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserCategory"
                .Value = oUser.UserCategory
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            '  MsgBox(ex.Message & ex.StackTrace)
            Return False
        End Try

    End Function

    Public Function InsertInquiry(ByVal lClientId As Long, ByVal enumPriority As Enumerators.Priority, ByVal lOPID As Long, lTPID As Long, strTask As String, dDate As Date, lUsersCategory As Long, strUsersIDs As String) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "InsertInquiry"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientId"
                .Value = lClientId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumPriority"
                .Value = enumPriority
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lOPID"
                .Value = lOPID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTPID"
                .Value = lTPID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strTask"
                .Value = strTask
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUsersCategory"
                .Value = lUsersCategory
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strToUsersIDs"
                .Value = strUsersIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

#End Region

#Region "Update/Edit"

    Public Function EditClient(ByVal oClient As Client) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditClient"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = oClient.ID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CompanyName"
                .Value = oClient.CompanyName
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CompanyCode"
                .Value = oClient.CompanyCode
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Address"
                .Value = oClient.Address
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "TimeZone"
                .Value = oClient.timezone
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Period"
                .Value = oClient.Period
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Statement"
                .Value = oClient.Statement
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BillingEmail"
                .Value = oClient.BillingEmail
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CCEmail"
                .Value = oClient.CCEmail
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankAccountName"
                .Value = oClient.BankAccountName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankAccountNumber"
                .Value = oClient.BankAccountNumber
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "IBAN"
                .Value = oClient.IBAN
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BeneficiaryBankName"
                .Value = oClient.BeneficiaryBankName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BeneficiaryBankAddress"
                .Value = oClient.BeneficiaryBankAddress
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Swift"
                .Value = oClient.Swift
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "ABARouting"
                .Value = oClient.ABARouting
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CreditLimit"
                .Value = oClient.CreditLimit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "ContractMapleNameID"
                .Value = oClient.ContractMapleNameID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "ContractMapleBankID"
                .Value = oClient.ContractMapleBankID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "AccountManagerID"
                .Value = oClient.AccountManagerID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strOutboundNames"
                .Value = oClient.strOutboundNames
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lAgreement"
                .Value = oClient.Agreement
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumStatus"
                .Value = oClient.Status
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            '    oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditEmailBody(ByVal txtBody As String, ByVal txtLatePaymentBody As String) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditEmailBody"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "txtBody"
                .Value = txtBody
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "txtLatePaymentBody"
                .Value = txtLatePaymentBody
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function UpdateInvoiceEmailStatus(ByVal strClients As String, ByVal dInsertedDate As Date) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "UpdateInvoiceEmailStatus"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strClientsIDs"
                .Value = strClients
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dInsertDate"
                .Value = dInsertedDate
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "txtBody"
                .Value = strClients
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditBank(ByVal oBank As Bank) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditBank"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = oBank.ID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankName"
                .Value = oBank.BankName
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankAccountName"
                .Value = oBank.BankAccountName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BankAccountNumber"
                .Value = oBank.BankAccountNumber
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "IBAN"
                .Value = oBank.IBAN
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BeneficiaryBankName"
                .Value = oBank.BeneficiaryBankName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BeneficiaryBankAddress"
                .Value = oBank.BeneficiaryBankAddress
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Swift"
                .Value = oBank.Swift
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "ABARouting"
                .Value = oBank.ABARouting
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditCompany(ByVal oCompany As Company) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditCompany"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = oCompany.ID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CompanyName"
                .Value = oCompany.CompanyName
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "Address"
                .Value = oCompany.Address
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "BillingEmail"
                .Value = oCompany.BillingEmail
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "CCEmails"
                .Value = oCompany.CCEmails
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "EmailSignature"
                .Value = oCompany.Signature
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function UpdateOffer(ByVal str As String, ByVal lClientID As Long, ByVal lTypeID As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "UpdateOffer"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "str"
                .Value = str
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditNonClIType(ByVal lId As Long, ByVal enumNonCLI As Enumerators.NON_CLI_Type) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditNonClIType"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lId"
                .Value = lId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumNonCLI"
                .Value = enumNonCLI
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditClientPayment(ByVal lPaymentID As Long, ByVal lClientId As Long, ByVal dblClientAmount As Double, ByVal dblRecievedAmount As Double, ByVal dDate As Date, ByVal strNote As String, ByVal lBankId As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditClientPayment"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lPaymentID"
                .Value = lPaymentID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientId"
                .Value = lClientId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblClientAmount"
                .Value = dblClientAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblRecievedAmount"
                .Value = dblRecievedAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankId"
                .Value = lBankId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)


            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditMaplePayment(ByVal lPaymentID As Long, ByVal lClientId As Long, ByVal dblPaidAmount As Double, ByVal dblRecievedAmount As Double, ByVal dDate As Date, ByVal strNote As String, ByVal lBankId As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditMaplePayment"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lPaymentID"
                .Value = lPaymentID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientId"
                .Value = lClientId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblPaidAmount"
                .Value = dblPaidAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblRecievedAmount"
                .Value = dblRecievedAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankId"
                .Value = lBankId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)


            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditVoucher(ByVal lVoucherID As Long, ByVal lClientId As Long, ByVal dblCredit As Double, ByVal dblDebit As Double, ByVal dDate As Date, ByVal strNote As String, ByVal lBankId As Long, ByVal lType As Long, ByVal strType As String) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditVoucher"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lVoucherID"
                .Value = lVoucherID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientId"
                .Value = lClientId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblCredit"
                .Value = dblCredit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblDebit"
                .Value = dblDebit
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lBankId"
                .Value = lBankId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lVoucherType"
                .Value = lType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strType"
                .Value = strType
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditPurchaseTotalCharges(ByVal lPurchaseID As Long, ByVal dblAmount As Double, ByVal dblDuration As Double) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditPurchaseTotalCharges"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lPurchaseID"
                .Value = lPurchaseID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblDuration"
                .Value = dblDuration
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblAmount"
                .Value = dblAmount
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditProviderRatePrice(ByVal lID As Integer, ByVal dblPrice As Double) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditProviderRatePrice"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dblPrice"
                .Value = dblPrice
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function EditUser(ByVal oUser As User) As Boolean
        ds = New DataSet
        Dim strRoleIDs As New System.Text.StringBuilder
        Try
            For Each oRole As Role In oUser.oColRoles
                strRoleIDs.Append(oRole.ID)
                strRoleIDs.Append(",")
            Next
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditUser"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lId"
                .Value = oUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strUserName"
                .Value = oUser.UserName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strPassword"
                .Value = oUser.Password
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lAccountManager"
                .Value = oUser.lAccountManager
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "IsAccountManager"
                .Value = oUser.IsAccountManager
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserCategory"
                .Value = oUser.UserCategory
            End With
            oSelectCommand.Parameters.Add(oParam)


            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strRoleIDs"
                .Value = strRoleIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            '  MsgBox(ex.Message & ex.StackTrace)
            'oConnection.Close()
            Return False
        End Try

    End Function

    Public Function EditInquiryComment(ByVal lInquiryID As Long, strNote As String) As Boolean
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditInquiryComment"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lInquiryID"
                .Value = lInquiryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strNote"
                .Value = strNote
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function EditInquiry(lInquiryID As Long, ByVal lClientId As Long, ByVal enumPriority As Enumerators.Priority, ByVal lOPID As Long, lTPID As Long, strTask As String, dDate As Date, lUsersCategory As Long, strUsersIDs As String) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "EditInquiry"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lInquiryID"
                .Value = lInquiryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientId"
                .Value = lClientId
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "enumPriority"
                .Value = enumPriority
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lOPID"
                .Value = lOPID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTPID"
                .Value = lTPID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strTask"
                .Value = strTask
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dDate"
                .Value = dDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUsersCategory"
                .Value = lUsersCategory
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strToUsersIDs"
                .Value = strUsersIDs
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

#End Region

#Region "Delete"

    Public Function DeleteClient(ByVal lID As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteClient"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteBank(ByVal lID As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteBank"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteCompany(ByVal lID As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteCompany"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteImportedData(ByVal lSoftware As Long, ByVal dPeriodFrom As Date, ByVal dPeriodTo As Date) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteImportedData"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lSoftware"
                .Value = lSoftware
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dPeriodFrom"
                .Value = dPeriodFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dPeriodTo"
                .Value = dPeriodTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteOffer(ByVal lClientID As Long, ByVal lTypeID As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteOffer"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lClientID"
                .Value = lClientID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lTypeID"
                .Value = lTypeID
            End With
            oSelectCommand.Parameters.Add(oParam)


            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function DeleteUser(ByVal lID As Long) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteUser"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

#End Region

#Region "Others"

    Public Function importdata(ByVal sql As String) As Boolean
        Try
            ' Dim uploadQry As String = "LOAD DATA INFILE " + path + " INSERT INTO TABLE billing FIELDS TERMINATED BY ',' LINES TERMINATED BY '\\n' IGNORE 1 LINES"

            '  Dim mycom As MySqlCommand = New MySqlCommand(uploadQry, Me.oConnection)
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.Text
            oSelectCommand.CommandText = sql
            oSelectCommand.Connection = oConnection

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False
        End Try

    End Function

    Public Function CheckDataExists(ByVal lSoftware As Long, ByVal dPeriodFrom As Date, ByVal dPeriodTo As Date, ByRef boolInvoice As Boolean) As Boolean
        ds = New DataSet
        Dim boolfoundData As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "CheckDataExists"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lSoftware"
                .Value = lSoftware
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dPeriodFrom"
                .Value = dPeriodFrom
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dPeriodTo"
                .Value = dPeriodTo
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 Then
                If ds.Tables(0).Rows(0).Item(0) Is DBNull.Value Then
                    boolfoundData = False
                Else
                    boolfoundData = True
                End If
                If ds.Tables(0).Rows(0).Item(1) Is DBNull.Value Then
                    boolInvoice = False
                Else
                    boolInvoice = True
                End If
                Return boolfoundData
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function ApproveInvoices(ByVal dInvoiceDate As Date) As DataSet
        Dim ds As New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "GenerateInvoices"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "dInvoiceDate"
                .Value = dInvoiceDate
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return Nothing

        End Try

    End Function

    Public Function CheckLogin(ByVal strUserName As String, ByVal strPassword As String) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "CheckLogin"

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strUserName"
                .Value = strUserName
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strPassword"
                .Value = strPassword
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function CheckClientsFromMC() As Boolean
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "CheckClientsFromMC"
            oSelectCommand.Connection = oConnection

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            Return CBool(oSelectCommand.ExecuteScalar)
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function SetPurchaseAsConfirmed(ByVal lPurchaseID As Long, ByVal boolStatus As Boolean) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "SetPurchaseAsConfirmed"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lPurchaseID"
                .Value = lPurchaseID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "boolStatus"
                .Value = boolStatus
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function ChangePassword(ByVal lUserID As Long, ByVal strPassword As String) As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "ChangePassword"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lID"
                .Value = lUserID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "strPassword"
                .Value = strPassword
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try

    End Function

    Public Function LogOut() As Boolean
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "LogOut"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oSelectCommand.ExecuteNonQuery()
            oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function CheckInquiryHandled(ByVal lInquiryID As Long) As DataSet
        ds = New DataSet
        Try
            oSelectCommand = New MySqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "CheckInquiryHandled"
            oSelectCommand.Connection = oConnection

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lInquiryID"
                .Value = lInquiryID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oParam = New MySqlParameter
            With oParam
                .ParameterName = "lUserID"
                .Value = gUser.Id
            End With
            oSelectCommand.Parameters.Add(oParam)

            If oConnection.State = ConnectionState.Closed Then
                oConnection.Open()
            End If

            oDataAdapter.SelectCommand = oSelectCommand
            oDataAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region

End Class
