Imports System.Data.OleDb
Imports Microsoft.SqlServer.Server
Imports System.Data.SqlClient

Public Class DBAccessSQL
    Public oSelectCommand As New SqlClient.SqlCommand
    Public oDataAdapter As New SqlClient.SqlDataAdapter
    Public oConnection As New SqlClient.SqlConnection
    Dim oParam As New SqlClient.SqlParameter

    Public ds As DataSet
    Public sql As String

    Public oTrans As SqlClient.SqlTransaction

    Public Sub New()
        '   oConnection.ConnectionString = My.Settings.TempoDbConnectionString 'strCon
    End Sub

#Region "Insert"
    Public Function insertClient(ByVal oClient As Client) As Boolean
        Try
            '    oSelectCommand = New SqlClient.SqlCommand
            '    oSelectCommand.CommandType = CommandType.StoredProcedure
            '    oSelectCommand.CommandText = "InsertClient"
            '    oSelectCommand.Connection = oConnection

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Name"
            '        .Value = oClient.Name
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)


            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@phone"
            '        .Value = oClient.Phone
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Address"
            '        .Value = oClient.Address
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Email"
            '        .Value = oClient.Email
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Mobile"
            '        .Value = oClient.Mobile
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@reg_Date"
            '        .Value = oClient.Reg_Date
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Birthdate"
            '        .Value = oClient.BirthDate
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Occupation"
            '        .Value = oClient.Occupation
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@JoinedThrough"
            '        .Value = oClient.JoinedThrough
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@JoinedThroughOthers"
            '        .Value = oClient.JoinedThroughOther
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@FavouritPlace"
            '        .Value = oClient.FavoritePlace
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@HealthProblems"
            '        .Value = oClient.HealthProblem
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@isThereHealthProblems"
            '        .Value = oClient.boolHealthProblem
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@InterestedInShows"
            '        .Value = oClient.InterestedIn
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Gender"
            '        .Value = oClient.Gender
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@RecieveEmails"
            '        .Value = oClient.RecieveEmails
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@NameOnFB"
            '        .Value = oClient.NameOnFB
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    If oConnection.State = ConnectionState.Closed Then
            '        oConnection.Open()
            '    End If

            '    oSelectCommand.ExecuteNonQuery()
            '    oConnection.Close()

            Return True
        Catch ex As Exception
            '    MsgBox(ex.Message & ex.StackTrace)
            '    oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetClient(ByVal lID As Long) As Client
        Dim oClient As New Client
        Dim ds As New DataSet
        Try
            oSelectCommand = New SqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetClientByID"

            oParam = New SqlParameter
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

    Public Function EditClient(ByVal oClient As Client) As Boolean
        Try
            'oSelectCommand = New SqlClient.SqlCommand
            'oSelectCommand.CommandType = CommandType.StoredProcedure
            'oSelectCommand.CommandText = "EditClient"
            'oSelectCommand.Connection = Me.oConnection

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@ID"
            '    .Value = oClient.Id
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Name"
            '    .Value = oClient.Name
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@phone"
            '    .Value = oClient.Phone
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Address"
            '    .Value = oClient.Address
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Email"
            '    .Value = oClient.Email
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Mobile"
            '    .Value = oClient.Mobile
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@reg_Date"
            '    .Value = oClient.Reg_Date
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Birthdate"
            '    .Value = oClient.BirthDate
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Occupation"
            '    .Value = oClient.Occupation
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@JoinedThrough"
            '    .Value = oClient.JoinedThrough
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@JoinedThroughOthers"
            '    .Value = oClient.JoinedThroughOther
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@FavouritPlace"
            '    .Value = oClient.FavoritePlace
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@HealthProblems"
            '    .Value = oClient.HealthProblem
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@isThereHealthProblems"
            '    .Value = oClient.boolHealthProblem
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@InterestedInShows"
            '    .Value = oClient.InterestedIn
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Gender"
            '    .Value = oClient.Gender
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@RecieveEmails"
            '    .Value = oClient.RecieveEmails
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@NameOnFB"
            '    .Value = oClient.NameOnFB
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'If oConnection.State = ConnectionState.Closed Then
            '    oConnection.Open()
            'End If

            'oSelectCommand.ExecuteNonQuery()
            'oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetClients() As ColClient
        ds = New DataSet
        Dim oColClient As New ColClient

        Try
            oSelectCommand = New SqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetClients"

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@boolStatus"
            '    .Value = True
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@boolActive"
            '    .Value = True
            'End With
            'oSelectCommand.Parameters.Add(oParam)

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

    Public Function DeleteClient(ByVal lID As Long) As Boolean
        Try
            oSelectCommand = New SqlClient.SqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteClient"
            oSelectCommand.Connection = oConnection

            oParam = New SqlParameter
            With oParam
                .ParameterName = "@ID"
                .Value = lID
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

    Public Function insertBank(ByVal oBank As Bank) As Boolean
        Try
            '    oSelectCommand = New SqlBank.SqlCommand
            '    oSelectCommand.CommandType = CommandType.StoredProcedure
            '    oSelectCommand.CommandText = "InsertBank"
            '    oSelectCommand.Connection = oConnection

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Name"
            '        .Value = oBank.Name
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)


            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@phone"
            '        .Value = oBank.Phone
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Address"
            '        .Value = oBank.Address
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Email"
            '        .Value = oBank.Email
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Mobile"
            '        .Value = oBank.Mobile
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@reg_Date"
            '        .Value = oBank.Reg_Date
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Birthdate"
            '        .Value = oBank.BirthDate
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Occupation"
            '        .Value = oBank.Occupation
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@JoinedThrough"
            '        .Value = oBank.JoinedThrough
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@JoinedThroughOthers"
            '        .Value = oBank.JoinedThroughOther
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@FavouritPlace"
            '        .Value = oBank.FavoritePlace
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@HealthProblems"
            '        .Value = oBank.HealthProblem
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@isThereHealthProblems"
            '        .Value = oBank.boolHealthProblem
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@InterestedInShows"
            '        .Value = oBank.InterestedIn
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Gender"
            '        .Value = oBank.Gender
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@RecieveEmails"
            '        .Value = oBank.RecieveEmails
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@NameOnFB"
            '        .Value = oBank.NameOnFB
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    If oConnection.State = ConnectionState.Closed Then
            '        oConnection.Open()
            '    End If

            '    oSelectCommand.ExecuteNonQuery()
            '    oConnection.Close()

            Return True
        Catch ex As Exception
            '    MsgBox(ex.Message & ex.StackTrace)
            '    oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetBank(ByVal lID As Long) As Bank
        Dim oBank As New Bank
        Dim ds As New DataSet
        Try
            oSelectCommand = New SqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetBankByID"

            oParam = New SqlParameter
            With oParam
                .ParameterName = "@ID"
                .Value = lID
            End With
            oSelectCommand.Parameters.Add(oParam)

            oDataAdapter.SelectCommand = oSelectCommand
            oSelectCommand.Connection = Me.oConnection
            oDataAdapter.Fill(ds)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                oBank.SetProperties(ds.Tables(0).Rows(0))
            End If

            Return oBank
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function EditBank(ByVal oBank As Bank) As Boolean
        Try
            'oSelectCommand = New SqlBank.SqlCommand
            'oSelectCommand.CommandType = CommandType.StoredProcedure
            'oSelectCommand.CommandText = "EditBank"
            'oSelectCommand.Connection = Me.oConnection

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@ID"
            '    .Value = oBank.Id
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Name"
            '    .Value = oBank.Name
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@phone"
            '    .Value = oBank.Phone
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Address"
            '    .Value = oBank.Address
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Email"
            '    .Value = oBank.Email
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Mobile"
            '    .Value = oBank.Mobile
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@reg_Date"
            '    .Value = oBank.Reg_Date
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Birthdate"
            '    .Value = oBank.BirthDate
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Occupation"
            '    .Value = oBank.Occupation
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@JoinedThrough"
            '    .Value = oBank.JoinedThrough
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@JoinedThroughOthers"
            '    .Value = oBank.JoinedThroughOther
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@FavouritPlace"
            '    .Value = oBank.FavoritePlace
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@HealthProblems"
            '    .Value = oBank.HealthProblem
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@isThereHealthProblems"
            '    .Value = oBank.boolHealthProblem
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@InterestedInShows"
            '    .Value = oBank.InterestedIn
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Gender"
            '    .Value = oBank.Gender
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@RecieveEmails"
            '    .Value = oBank.RecieveEmails
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@NameOnFB"
            '    .Value = oBank.NameOnFB
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'If oConnection.State = ConnectionState.Closed Then
            '    oConnection.Open()
            'End If

            'oSelectCommand.ExecuteNonQuery()
            'oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetBanks() As ColBank
        ds = New DataSet
        Dim oColBank As New ColBank

        Try
            oSelectCommand = New SqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetBanks"

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@boolStatus"
            '    .Value = True
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
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

    Public Function DeleteBank(ByVal lID As Long) As Boolean
        Try
            oSelectCommand = New SqlClient.SqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteBank"
            oSelectCommand.Connection = oConnection

            oParam = New SqlParameter
            With oParam
                .ParameterName = "@ID"
                .Value = lID
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
            '    oSelectCommand = New SqlCompany.SqlCommand
            '    oSelectCommand.CommandType = CommandType.StoredProcedure
            '    oSelectCommand.CommandText = "InsertCompany"
            '    oSelectCommand.Connection = oConnection

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Name"
            '        .Value = oCompany.Name
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)


            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@phone"
            '        .Value = oCompany.Phone
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Address"
            '        .Value = oCompany.Address
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Email"
            '        .Value = oCompany.Email
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Mobile"
            '        .Value = oCompany.Mobile
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@reg_Date"
            '        .Value = oCompany.Reg_Date
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Birthdate"
            '        .Value = oCompany.BirthDate
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Occupation"
            '        .Value = oCompany.Occupation
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@JoinedThrough"
            '        .Value = oCompany.JoinedThrough
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@JoinedThroughOthers"
            '        .Value = oCompany.JoinedThroughOther
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@FavouritPlace"
            '        .Value = oCompany.FavoritePlace
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@HealthProblems"
            '        .Value = oCompany.HealthProblem
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@isThereHealthProblems"
            '        .Value = oCompany.boolHealthProblem
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@InterestedInShows"
            '        .Value = oCompany.InterestedIn
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@Gender"
            '        .Value = oCompany.Gender
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@RecieveEmails"
            '        .Value = oCompany.RecieveEmails
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    oParam = New SqlParameter
            '    With oParam
            '        .ParameterName = "@NameOnFB"
            '        .Value = oCompany.NameOnFB
            '    End With
            '    oSelectCommand.Parameters.Add(oParam)

            '    If oConnection.State = ConnectionState.Closed Then
            '        oConnection.Open()
            '    End If

            '    oSelectCommand.ExecuteNonQuery()
            '    oConnection.Close()

            Return True
        Catch ex As Exception
            '    MsgBox(ex.Message & ex.StackTrace)
            '    oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetCompany(ByVal lID As Long) As Company
        Dim oCompany As New Company
        Dim ds As New DataSet
        Try
            oSelectCommand = New SqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCompanyByID"

            oParam = New SqlParameter
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

    Public Function EditCompany(ByVal oCompany As Company) As Boolean
        Try
            'oSelectCommand = New SqlCompany.SqlCommand
            'oSelectCommand.CommandType = CommandType.StoredProcedure
            'oSelectCommand.CommandText = "EditCompany"
            'oSelectCommand.Connection = Me.oConnection

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@ID"
            '    .Value = oCompany.Id
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Name"
            '    .Value = oCompany.Name
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@phone"
            '    .Value = oCompany.Phone
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Address"
            '    .Value = oCompany.Address
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Email"
            '    .Value = oCompany.Email
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Mobile"
            '    .Value = oCompany.Mobile
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@reg_Date"
            '    .Value = oCompany.Reg_Date
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Birthdate"
            '    .Value = oCompany.BirthDate
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Occupation"
            '    .Value = oCompany.Occupation
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@JoinedThrough"
            '    .Value = oCompany.JoinedThrough
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@JoinedThroughOthers"
            '    .Value = oCompany.JoinedThroughOther
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@FavouritPlace"
            '    .Value = oCompany.FavoritePlace
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@HealthProblems"
            '    .Value = oCompany.HealthProblem
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@isThereHealthProblems"
            '    .Value = oCompany.boolHealthProblem
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@InterestedInShows"
            '    .Value = oCompany.InterestedIn
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@Gender"
            '    .Value = oCompany.Gender
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@RecieveEmails"
            '    .Value = oCompany.RecieveEmails
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@NameOnFB"
            '    .Value = oCompany.NameOnFB
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'If oConnection.State = ConnectionState.Closed Then
            '    oConnection.Open()
            'End If

            'oSelectCommand.ExecuteNonQuery()
            'oConnection.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
            oConnection.Close()
            Return False

        End Try
    End Function

    Public Function GetCompanys() As ColCompany
        ds = New DataSet
        Dim oColCompany As New ColCompany

        Try
            oSelectCommand = New SqlCommand
            oSelectCommand.CommandType = System.Data.CommandType.StoredProcedure
            oSelectCommand.CommandText = "GetCompanys"

            'oParam = New SqlParameter
            'With oParam
            '    .ParameterName = "@boolStatus"
            '    .Value = True
            'End With
            'oSelectCommand.Parameters.Add(oParam)

            'oParam = New SqlParameter
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

    Public Function DeleteCompany(ByVal lID As Long) As Boolean
        Try
            oSelectCommand = New SqlClient.SqlCommand
            oSelectCommand.CommandType = CommandType.StoredProcedure
            oSelectCommand.CommandText = "DeleteCompany"
            oSelectCommand.Connection = oConnection

            oParam = New SqlParameter
            With oParam
                .ParameterName = "@ID"
                .Value = lID
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

    Public Function ImportData(ByVal path As String) As Boolean
        Try
            Dim uploadQry As String = "LOAD DATA INFILE " + path + " INSERT INTO TABLE billing FIELDS TERMINATED BY ',' LINES TERMINATED BY '\\n' IGNORE 1 LINES"

            Dim mycom As SqlCommand = New SqlCommand(uploadQry, Me.oConnection)


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

End Class
