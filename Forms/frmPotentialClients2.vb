Public Class frmPotentialClients2

    Private Sub FrmCountries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsAccountManagers.AccountManagers' table. You can move, or remove it, as needed.
        Me.AccountManagersTableAdapter.Fill(Me.DsAccountManagers.AccountManagers)
        FillDataGrid()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim strQuery As New System.Text.StringBuilder("")
            Dim row As DataGridViewRow
            '  strQuery.Append("delete from potential_clients; " & vbCrLf)
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 2
                row = Me.DataGridView1.Rows(i)
                If IsNumeric(row.Cells(0).Value) AndAlso CInt(row.Cells(0).Value) > 0 Then ' Then edit row
                    strQuery.Append(" update potential_clients set ")
                    If Not row.Cells(1).Value Is Nothing Then
                        strQuery.Append("`Name` ='" & row.Cells(1).Value & "',")
                    Else
                        strQuery.Append("`Name` =null,")
                    End If
                    If Not row.Cells(2).Value Is Nothing Then
                        strQuery.Append("`Title` ='" & row.Cells(2).Value & "',")
                    Else
                        strQuery.Append("`Title` =null,")
                    End If
                    If Not row.Cells(3).Value Is Nothing Then
                        strQuery.Append("`Company_Name` ='" & row.Cells(3).Value & "',")
                    Else
                        strQuery.Append("`Company_Name` =null,")
                    End If
                    If Not row.Cells(4).Value Is Nothing Then
                        strQuery.Append("`Phone` ='" & row.Cells(4).Value & "',")
                    Else
                        strQuery.Append("`Phone` =null,")
                    End If
                    If Not row.Cells(5).Value Is Nothing Then
                        strQuery.Append("`Phone2` ='" & row.Cells(5).Value & "',")
                    Else
                        strQuery.Append("`Phone2` =null,")
                    End If
                    If Not row.Cells(6).Value Is Nothing Then
                        strQuery.Append("`Mobile` ='" & row.Cells(6).Value & "',")
                    Else
                        strQuery.Append("`Mobile` =null,")
                    End If
                    If Not row.Cells(7).Value Is Nothing Then
                        strQuery.Append("`Email` ='" & row.Cells(7).Value & "',")
                    Else
                        strQuery.Append("`Email` =null,")
                    End If
                    If Not row.Cells(8).Value Is Nothing Then
                        strQuery.Append("`Skype` ='" & row.Cells(8).Value & "',")
                    Else
                        strQuery.Append("`Skype` =null,")
                    End If
                    If Not row.Cells(9).Value Is Nothing Then
                        strQuery.Append("`Website` ='" & row.Cells(9).Value & "',")
                    Else
                        strQuery.Append("`Website` =null,")
                    End If
                    If Not row.Cells(10).Value Is Nothing Then
                        strQuery.Append("`Address` ='" & row.Cells(10).Value & "',")
                    Else
                        strQuery.Append("`Address` =null,")
                    End If
                    If Not row.Cells(11).Value Is Nothing Then
                        strQuery.Append("`Exhibition_Name` ='" & row.Cells(11).Value & "',")
                    Else
                        strQuery.Append("`Exhibition_Name` =null,")
                    End If
                    If Not row.Cells(12).Value Is Nothing Then
                        strQuery.Append("`Limit` ='" & row.Cells(12).Value & "',")
                    Else
                        strQuery.Append("`Limit` =null,")
                    End If
                    If Not row.Cells(13).Value Is Nothing Then
                        strQuery.Append("`Credit_Check` =" & CBool(row.Cells(13).Value) & ",")
                    Else
                        strQuery.Append("`Credit_Check` =null,")
                    End If
                    If Not row.Cells(14).Value Is Nothing Then
                        strQuery.Append("`isContacted` =" & CBool(row.Cells(14).Value) & ",")
                    Else
                        strQuery.Append("`isContacted` =null,")
                    End If
                    If Not row.Cells(15).Value Is Nothing Then
                        strQuery.Append("`Action_Date` ='" & row.Cells(15).Value & "',")
                    Else
                        strQuery.Append("`Action_Date` =null,")
                    End If

                    If Not row.Cells(16).Value Is Nothing Then
                        strQuery.Append("`Note` ='" & row.Cells(16).Value & "',")
                    Else
                        strQuery.Append("`Note` =null,")
                    End If
                    If Not row.Cells(17).Value Is Nothing AndAlso Not row.Cells(17).Value = "" Then
                        strQuery.Append("`Account_Manager` =" & row.Cells(17).Value)
                    Else
                        strQuery.Append("`Account_Manager` =0")
                    End If
                    strQuery.Append(" WHERE `ID` ='" & row.Cells(0).Value & "'; " & vbCrLf)

                ElseIf row.Cells(0).Value Is DBNull.Value OrElse row.Cells(0).Value = "" Then 'add row
                    strQuery.Append(" insert into potential_clients (`Name`,`Title`,`Company_Name`,`Phone`,`Phone2`,`Mobile`,`Email`,`Skype`,`Website`,`Address`,`Exhibition_Name`,`Limit`,`Credit_Check`,`isContacted`,`Action_Date`,`Note`,`Account_Manager`) Values (")
                    If Not row.Cells(1).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(1).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(2).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(2).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(3).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(3).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(4).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(4).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(5).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(5).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(6).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(6).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(7).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(7).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(8).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(8).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(9).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(9).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(10).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(10).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(11).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(11).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(12).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(12).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(13).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(13).Value & "',")
                    Else
                        strQuery.Append("0,")
                    End If
                    If Not row.Cells(14).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(14).Value & "',")
                    Else
                        strQuery.Append("0,")
                    End If
                    If Not row.Cells(15).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(15).Value & "',")
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(16).Value Is Nothing Then
                        strQuery.Append("'" & row.Cells(16).Value & "',") 'Note
                    Else
                        strQuery.Append("null,")
                    End If
                    If Not row.Cells(17).Value Is Nothing OrElse row.Cells(17).Value = "" Then
                        strQuery.Append(row.Cells(17).Value) 'Account Manager
                    Else
                        strQuery.Append("0")
                    End If
                    strQuery.Append(");")
                End If

            Next
            If Not strQuery Is Nothing AndAlso Not strQuery.ToString.Count = 0 Then
                If odbaccess.ExecuteSQL(strQuery.ToString) Then
                    MsgBox("Data was saved Successfully.")
                Else
                    MsgBox("An error occured.")
                End If
            End If

            'Me.Close()
        Catch ex As Exception
            MsgBox("Update failed")
        End Try
    End Sub



    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Select Case MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                btnSave_Click(Me, New System.EventArgs)
            Case MsgBoxResult.No
                Me.Close()
            Case MsgBoxResult.Cancel
                Return
        End Select
    End Sub

    Public Sub CenterButtons()
        Me.Panel2.Left = CInt((Me.ClientSize.Width / 2) - (Panel2.Width / 2))
    End Sub

    Private Sub FrmCountries_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterButtons()
    End Sub

    Public Sub FillDataGrid()
        'Add Account Manger combobox column
        Dim ComboBox1 As New DataGridViewComboBoxColumn()
        Dim dt As New DataTable
        dt.Columns.Add("Account Manager")
        dt.Columns.Add("Value")

        dt.Rows.Add("", 0)
        For Each row As DataRow In Me.DsAccountManagers.AccountManagers.Rows
            dt.Rows.Add(row.Item("Name").ToString, CInt(row.Item("ID")))
        Next
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "Account Manager"
        ComboBox1.ValueMember = "Value"
        DataGridView1.Columns.Add(ComboBox1)
        DataGridView1.Columns(17).Width = 200
        DataGridView1.Columns(17).HeaderText = "Account Manager"
        If gUser.IsAccountManager Then
            DataGridView1.Columns(17).ReadOnly = True
        End If
        'Fill Datagrid
        Dim intRowIndex As Integer = 0
        Dim ds As DataSet
        ds = odbaccess.getPotentialClients()
        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
            For Each dr As DataRow In ds.Tables(0).Rows
                intRowIndex = Me.DataGridView1.Rows.Add
                With Me.DataGridView1.Rows(intRowIndex)
                    .Cells(0).Value = dr.Item(0).ToString
                    .Cells(1).Value = dr.Item(1).ToString
                    .Cells(2).Value = dr.Item(2).ToString
                    .Cells(3).Value = dr.Item(3).ToString
                    .Cells(4).Value = dr.Item(4).ToString
                    .Cells(5).Value = dr.Item(5).ToString
                    .Cells(6).Value = dr.Item(6).ToString
                    .Cells(7).Value = dr.Item(7).ToString
                    .Cells(8).Value = dr.Item(8).ToString
                    .Cells(9).Value = dr.Item(9).ToString
                    .Cells(10).Value = dr.Item(10).ToString
                    .Cells(11).Value = dr.Item(11).ToString
                    .Cells(12).Value = dr.Item(12).ToString
                    .Cells(13).Value = CBool(dr.Item(13).ToString)
                    .Cells(14).Value = CBool(dr.Item(14).ToString)
                    .Cells(15).Value = dr.Item(15).ToString
                    .Cells(16).Value = dr.Item("Note").ToString
                    .Cells(17).Value = dr.Item("Account_Manager").ToString
                    '.Cells(18).Value = dr.Item("Account_Manager").ToString
                End With
            Next
        End If


        ' End Sub
    End Sub

    Private Function DataGridViewCheckBoxColumn() As Type
        '     Throw New NotImplementedException
    End Function

End Class
