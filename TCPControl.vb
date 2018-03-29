Imports System.Net, System.Net.Sockets

Public Class TCPControl

    Public Event ActualRatesMsg(sender As TCPControl, Data As String)
    Public Event GetCountryDestinations(Data As String)
    Public Event GetClientMCBalance(lMCClientId, dblMCBalance)
    Public Event GetAllClientsMCBalances(strClientsBalances As String)
    Public Event ConnectedToServer As EventHandler
    Dim intAllClientBalancesLength, intMsgLength As Integer
    Dim strMsg As String

    Dim clientSocket As Socket
    Dim byteData(1023) As Byte

    Public Sub New()
        Try
            ConnectToServer()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub OnConnect(ByVal ar As IAsyncResult)
        Try
            clientSocket.EndConnect(ar)
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                                      New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            MsgBox("API server is not connected!")
        End Try
    End Sub

    Private Sub OnRecieve(ByVal ar As IAsyncResult)
        Dim client As Socket = ar.AsyncState
        Try
            client.EndReceive(ar)
            Dim bytesRec As Byte() = byteData
            Dim message As String = System.Text.ASCIIEncoding.ASCII.GetString(bytesRec)
            Read(message)
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                                      New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            MsgBox("API server got disconnected.")
            ' MsgBox("API server is not connected!")
            RaiseEvent ConnectedToServer(Me, New EventArgs)

        End Try
    End Sub

    Delegate Sub _Read(ByVal msg As String)
    Private Sub Read(ByVal msg As String)
        'If InvokeRequired Then
        '    Invoke(New _Read(AddressOf Read), msg)
        '    Exit Sub
        'End If
        '  RichTextBox1.Text &= msg
        Dim arMSG As Array = msg.Split("|")
        If Not arMSG.Length = 0 Then
            Select Case arMSG(0)
                Case "GetClientBalance" 'Sync Companies
                    RaiseEvent GetClientMCBalance(CLng(arMSG(1)), arMSG(2))

                Case "GetAllClientsBalances"
                    intAllClientBalancesLength = arMSG(1)
                    If arMSG(2).ToString.Length = intAllClientBalancesLength Then
                        RaiseEvent GetAllClientsMCBalances(arMSG(2).ToString)
                        intAllClientBalancesLength = 0
                    Else
                        intMsgLength = arMSG(2).ToString.Length
                        strMsg = arMSG(2).ToString
                    End If
                Case Else
                    If Not intAllClientBalancesLength = 0 Then
                        intMsgLength += arMSG(0).ToString.Length
                        strMsg &= arMSG(0).ToString

                        If intAllClientBalancesLength = intMsgLength Then
                            intAllClientBalancesLength = 0
                            intMsgLength = 0

                            RaiseEvent GetAllClientsMCBalances(strMsg)
                            strMsg = ""
                        End If
                    End If

                    'MsgBox(arMSG(0))
            End Select
        End If
    End Sub

    Public Function SendTest(ByVal msg As String) As Boolean
        Try
            Dim sendBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(msg)
            clientSocket.BeginSend(sendBytes, 0, sendBytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnSend), clientSocket)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Send(ByVal msg As String) As Boolean
        Try
            Dim sendBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(msg)
            clientSocket.BeginSend(sendBytes, 0, sendBytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnSend), clientSocket)
            Return True
        Catch ex As Exception
            Return False
            MsgBox("API server is not connected!")
        End Try
    End Function

    Private Sub OnSend(ByVal ar As IAsyncResult)
        Dim client As Socket = ar.AsyncState
        client.EndSend(ar)
    End Sub

    Public Function ConnectToServer() As Boolean
        Dim strPort As String
        Try
            If Not IsPortAvailable() Then
                clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim ipAddress As IPAddress = IPAddress.Parse(My.Settings.APIServerIP)

                If gCountry = Enumerators.Country.Jordan Then
                    strPort = "8800"
                Else
                    strPort = "7700"
                End If

                Dim ipEndPoint As IPEndPoint = New IPEndPoint(ipAddress, strPort)

                clientSocket.BeginConnect(ipEndPoint, New AsyncCallback(AddressOf OnConnect), Nothing)
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function IsPortAvailable() As Boolean
        Try
            If clientSocket.Connected Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
