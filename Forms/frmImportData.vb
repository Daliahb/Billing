Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO

Public Class frmImportData

    Public enumEditAdd As New Enumerators.EditAdd
    Public lID As Long
    Public oBank As New Bank
    Public boolError As Boolean
    Public filename As String = ""

    Dim excel As Excel.Application = New Excel.Application
    Dim worksheet As Excel.Worksheet
    Dim xlWorkBook As Excel.Workbook

    Private Sub frmAddBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '      'Me.BackColor = gBackColor
        ' fillData()
        Me.dtpFromDate.Value = Now.Date.AddDays(-7)
        Me.dtpToDate.Value = Now.Date.AddDays(-1)
        Me.cmbPeriod.SelectedIndex = 0
        FillSoftwares()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim boolError = False
        Try
            If filename.Length = 0 OrElse (filename.Substring(filename.Length - 4, 4).ToLower <> "xlsx" And filename.Substring(filename.Length - 3, 3).ToLower <> "xls") Then
                ErrorProvider1.SetError(txtFileName, "Select a valid Excel file.")
                boolError = True
            Else
                ErrorProvider1.SetError(txtFileName, "")
            End If
            If Me.cmbSoftwareID.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbSoftwareID, "Please select an item from the list.")
                boolError = True
            Else
                ErrorProvider1.SetError(cmbSoftwareID, "")
            End If
            If Me.cmbPeriod.SelectedIndex = -1 Then
                ErrorProvider1.SetError(cmbPeriod, "Please select an item from the list.")
                boolError = True
            Else
                ErrorProvider1.SetError(cmbPeriod, "")
            End If
            If Me.dtpFromDate.Value > Now.Date OrElse Me.dtpFromDate.Value > Me.dtpToDate.Value Then
                ErrorProvider1.SetError(dtpFromDate, "Please select a valid date.")
                boolError = True
            Else
                ErrorProvider1.SetError(dtpFromDate, "")
            End If
            If Me.dtpToDate.Value > Now.Date OrElse Me.dtpFromDate.Value > Me.dtpToDate.Value Then
                ErrorProvider1.SetError(dtpToDate, "Please select a valid date.")
                boolError = True
            Else
                ErrorProvider1.SetError(dtpToDate, "")
            End If
            If boolError = False Then
                Dim boolInvoice As Boolean
                'check if data is already existed
                If odbaccess.CheckDataExists(CLng(Me.cmbSoftwareID.SelectedValue), Me.dtpFromDate.Value.Date, Me.dtpToDate.Value.Date, CInt(Me.cmbPeriod.Text), boolInvoice) Then
                    If boolInvoice = False Then 'no invoices yet
                        If MsgBox("The data is already imported from " + Me.cmbSoftwareID.Text + " for period from " + Me.dtpFromDate.Value.ToString("yyyy-MM-dd") + " to " + Me.dtpToDate.Value.ToString("yyyy-MM-dd") + ". Do you want to replace data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            If odbaccess.DeleteImportedData(CLng(Me.cmbSoftwareID.SelectedValue), Me.dtpFromDate.Value.Date, Me.dtpToDate.Value.Date, CInt(Me.cmbPeriod.Text)) Then
                                Me.btnSave.Enabled = False
                                If Me.cmbSoftwareID.Text.ToLower.Contains("vos") Then
                                    ImportDataFromVos()
                                Else
                                    ImportDataFromMediaCoreInvoices()
                                    ImportDataFromMediaCorePayments()
                                End If
                            Else
                                MsgBox("An error occured!")
                            End If
                        Else
                            Return
                        End If
                    Else 'if boolinvoice = true
                        MsgBox("The data is already imported and the invoices posted.")
                    End If
                    ' Else 'already sent invoice
                    'MsgBox("Invoices have been already sent for " + Me.cmbSoftwareID.SelectedText + " for period from " + Me.dtpFromDate.Value.ToString("yyyy-MM-dd") + " to " + Me.dtpToDate.Value.ToString("yyyy-MM-dd") + ".")
                    '   Return
                    ' End If
                    '  Else ' no data existed or inserted before
                    '  If Me.cmbSoftwareID.SelectedIndex = 0 Then
                Else
                    Me.btnSave.Enabled = False
                    If Me.cmbSoftwareID.Text.ToLower.Contains("vos") Then
                        ImportDataFromVos()
                    Else
                        ImportDataFromMediaCoreInvoices()
                        ImportDataFromMediaCorePayments()
                    End If
                    'Else
                    '    Me.btnSave.Enabled = True

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ErrorProvider1.SetError(txtFileName, "")
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            filename = Me.OpenFileDialog1.FileName
            Me.txtFileName.Text = filename
        End If
    End Sub

    Private Sub ImportDataFromMediaCorePayments()
        Try

            Me.lblInsertOutbound.Enabled = True
            Me.lblInsertOutbound.ForeColor = Color.Red
            Me.lblInsertInvoices.Font = New Font(Label1.Font, FontStyle.Bold)
            Me.lblInsertInvoices.ForeColor = Color.Black

            Dim dFromDate, dToDate, dInvoiceDate As String
            Dim lSoftware As Long
            Dim ClientCode, AreaName, AreaCode, CountryCol, DurationCol, CostOutCol, MarginCol, ProfitCol As String
            Dim TotalCharge, TotalDuration, Profit, Margin As Double
            Dim boolError, boolRead As Boolean
            Dim sql As New System.Text.StringBuilder
            excel.Visible = True
            Dim intPeriod As Integer
            Dim ExcelPath As String = filename
            Dim htNumberAlpahbit As Hashtable = GetHashtable()
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            worksheet = excel.Worksheets(1)

            sql.Append("INSERT INTO billing (FK_Client,client_Code, Area_Name, Area_Code, Total_Charges, Total_Duration, Insert_Date, Billing_Period_From, Billing_Period_To,FK_Software,inst_by,InOutBound,InvoicePeriod,Margin,Profit) VALUES")
            dFromDate = "'" + Me.dtpFromDate.Value.ToString("yyyy-MM-dd") + "'"
            dToDate = "'" + Me.dtpToDate.Value.ToString("yyyy-MM-dd") + "'"
            dInvoiceDate = "'" + Me.dtpInvoiceDate.Value.ToString("yyyy-MM-dd") + "'"
            lSoftware = CLng(Me.cmbSoftwareID.SelectedValue)
            intPeriod = CInt(cmbPeriod.Text)

            Dim x As Double
            x = 100 / Me.worksheet.UsedRange.Rows.Count

            '----------------- Get Duration and Cost In columns --------------------
            For intRow = 1 To 10
                If Not Me.worksheet.Range("B" & intRow).Value() Is Nothing Then
                    If Me.worksheet.Range("B" & intRow).Value().ToString.ToLower = "point name" Then
                        For col = 2 To Me.worksheet.UsedRange.Columns.Count
                            Try
                                Select Case Me.worksheet.Range(htNumberAlpahbit(col).ToString & intRow).Value().ToString.Trim.ToLower
                                    Case "Country".ToLower
                                        CountryCol = htNumberAlpahbit(col).ToString
                                    Case "Duration".ToLower
                                        DurationCol = htNumberAlpahbit(col).ToString
                                    Case "Cost OUT".ToLower
                                        CostOutCol = htNumberAlpahbit(col).ToString
                                    Case "Margin".ToLower
                                        MarginCol = htNumberAlpahbit(col).ToString
                                    Case "Profit".ToLower
                                        ProfitCol = htNumberAlpahbit(col).ToString
                                End Select
                            Catch ex As Exception

                            End Try
                        Next
                        Exit For
                    End If
                End If
            Next


            If CountryCol Is Nothing Then
                MsgBox("There is no 'Country' column in the excel file.")
                Return
            End If
            If DurationCol Is Nothing Then
                MsgBox("There is no 'Duration' column in the excel file.")
                Return
            End If
            If CostOutCol Is Nothing Then
                MsgBox("There is no 'Cost Out' column in the excel file.")
                Return
            End If
            If MarginCol Is Nothing Then
                MsgBox("There is no 'Margin' column in the excel file.")
                Return
            End If
            If ProfitCol Is Nothing Then
                MsgBox("There is no 'Profit' column in the excel file.")
                Return
            End If
            ' -------------------------- end ----------------------------------

            For row = 2 To Me.worksheet.UsedRange.Rows.Count
                x += x
                If x < 100 Then
                    Me.ProgressBar1.Value = CInt(x)
                End If
                If boolRead = False Then
                    If Not Me.worksheet.Range("B" & row).Value() Is Nothing Then

                        If Me.worksheet.Range("B" & row).Value().ToString.ToUpper = "OUTBOUND" Then
                            'get company name from the first column
                            If Not Me.worksheet.Range("A" & row).Value() Is Nothing Then
                                Dim strCompanyName As String = Me.worksheet.Range("A" & row).Value().ToString
                                Dim words As String() = strCompanyName.Split(New String() {"Account Manager"},
                                            StringSplitOptions.None)
                                ClientCode = "'" + words(0).Trim + "'"
                            Else
                                For i As Integer = row To 0 Step -1
                                    If Not Me.worksheet.Range("A" & i).Value() Is Nothing Then
                                        Dim strCompanyName As String = Me.worksheet.Range("A" & i).Value().ToString
                                        Dim words As String() = strCompanyName.Split(New String() {"Account Manager"},
                                                    StringSplitOptions.None)
                                        ClientCode = "'" + words(0).Trim + "'"
                                        Exit For
                                    End If
                                Next
                            End If
                            ''''''''''''''''''


                            boolRead = True
                            Continue For
                        End If
                    Else
                        Exit For
                    End If

                ElseIf boolRead Then
                    If Not Me.worksheet.Range("B" & row).Value().ToString.ToUpper = "TOTAL" AndAlso Not Me.worksheet.Range("B" & row).Value().ToString.ToUpper = "INBOUND" Then
                        Try
                            If Not Me.worksheet.Range("B" & row).Value().ToString.ToUpper = "OUTBOUND" Then
                                If Me.worksheet.Range("B" & row).Value().ToString = "Point Name" Then
                                    Continue For
                                End If

                                '  ClientCode = "'" + Me.worksheet.Range("B" & row).Value().ToString + "'"
                                AreaName = "'" + Me.worksheet.Range(CountryCol & row).Value().ToString + "'"
                                AreaCode = "'" + "" + "'"
                                If Not Me.worksheet.Range(CostOutCol & row).Value() Is Nothing AndAlso IsNumeric(Me.worksheet.Range(CostOutCol & row).Value()) Then
                                    TotalCharge = Math.Round(CDec(Me.worksheet.Range(CostOutCol & row).Value()), 3)
                                Else
                                    TotalCharge = 0
                                End If

                                TotalDuration = getDurationInSeconds(Me.worksheet.Range(DurationCol & row).Value())

                                Profit = Math.Round(CDec(Me.worksheet.Range(ProfitCol & row).Value().ToString.TrimEnd(CChar("%"))), 3)
                                Margin = Math.Round(CDec(Me.worksheet.Range(MarginCol & row).Value()), 3)


                                sql.Append("(0," & ClientCode & "," & AreaName & "," & AreaCode & "," & TotalCharge & "," & TotalDuration & "," & dInvoiceDate & "," & dFromDate & "," & dToDate & "," & lSoftware & "," & gUser.Id & ",2," & intPeriod & "," & Margin & "," & Profit & "),")
                            Else
                                boolRead = False
                                row -= 1
                            End If
                        Catch ex As Exception
                            '  MsgBox(ex.Message & "  " & ex.StackTrace)
                        End Try

                    Else
                        boolRead = False
                    End If
                End If


            Next

            Me.ProgressBar1.Value = 100
            excel.Workbooks.Close()
            excel.Quit()
            boolError = odbaccess.ExecuteSQL(sql.ToString.Substring(0, sql.ToString.Length - 1))

            If boolError Then
                Me.lblInsertAim.Enabled = True
                Me.lblInsertAim.ForeColor = Color.Red
                '  Me.lblInsertOutbound.Font = New Font(Label1.Font, FontStyle.Bold)
                Me.lblInsertOutbound.ForeColor = Color.Black

                If intPeriod = 7 Then
                    odbaccess.FillAimTable(dtpInvoiceDate.Value)
                End If

                Me.lblClean.Enabled = True
                Me.lblClean.ForeColor = Color.FromArgb(255, 255, 0, 0)
                '    Me.lblInsertAim.Font = New Font(Label1.Font, FontStyle.Bold)
                Me.lblInsertAim.ForeColor = Color.Black

                odbaccess.CheckRightInvoicePeriodInBilling(intPeriod, dtpInvoiceDate.Value, lSoftware)

                '   Me.lblClean.Font = New Font(Label1.Font, FontStyle.Bold)
                Me.lblClean.ForeColor = Color.Black

                MsgBox("Inbound and Outbound data imported successfully.")
                Me.lblClean.Enabled = False
                Me.lblInsertAim.Enabled = False
                Me.lblInsertInvoices.Enabled = False
                Me.lblInsertOutbound.Enabled = False

                odbaccess.InsertHistory("Imported Outbound Media Core Data", 11)
                filename = ""
                Me.txtFileName.Text = ""
                Me.ProgressBar1.Value = 0
            Else
                MsgBox("An error occured!")
            End If
            Me.btnSave.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Private Sub ImportDataFromMediaCoreInvoices()
        Try
            Me.lblInsertInvoices.enabled = True
            Me.lblInsertInvoices.ForeColor = Color.Red

            Dim dFromDate, dToDate, dToday As String
            Dim lSoftware As Long
            Dim ClientCode, AreaName, AreaCode, CountryCol, DurationCol, CostINCol, MarginCol, ProfitCol As String
            Dim TotalCharge, TotalDuration, Profit, Margin As Double
            Dim boolError, boolRead As Boolean
            Dim sql As New System.Text.StringBuilder
            excel.Visible = True
            Dim ExcelPath As String = filename
            Dim intPeriod As Integer
            Dim htNumberAlpahbit As Hashtable = GetHashtable()
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            worksheet = excel.Worksheets(1)

            sql.Append("INSERT INTO billing (FK_Client,client_Code, Area_Name, Area_Code, Total_Charges, Total_Duration, Insert_Date, Billing_Period_From, Billing_Period_To,FK_Software,inst_by,InOutBound,InvoicePeriod,Margin,Profit) VALUES")
            dFromDate = "'" + Me.dtpFromDate.Value.ToString("yyyy-MM-dd") + "'"
            dToDate = "'" + Me.dtpToDate.Value.ToString("yyyy-MM-dd") + "'"
            dToday = "'" + Me.dtpInvoiceDate.Value.ToString("yyyy-MM-dd") + "'"
            lSoftware = CLng(Me.cmbSoftwareID.SelectedValue)
            intPeriod = CInt(cmbPeriod.Text)

            Dim x As Double
            x = 100 / Me.worksheet.UsedRange.Rows.Count

            '----------------- Get Duration and Cost In columns --------------------
            For intRow = 1 To 10
                If Not Me.worksheet.Range("B" & intRow).Value() Is Nothing Then
                    If Me.worksheet.Range("B" & intRow).Value().ToString.ToLower = "point name" Then
                        For col = 2 To Me.worksheet.UsedRange.Columns.Count
                            Try
                                Select Case Me.worksheet.Range(htNumberAlpahbit(col).ToString & intRow).Value().ToString.Trim.ToLower
                                    Case "Country".ToLower
                                        CountryCol = htNumberAlpahbit(col).ToString
                                    Case "Duration".ToLower
                                        DurationCol = htNumberAlpahbit(col).ToString
                                    Case "Cost IN".ToLower
                                        CostINCol = htNumberAlpahbit(col).ToString
                                    Case "Margin".ToLower
                                        MarginCol = htNumberAlpahbit(col).ToString
                                    Case "Profit".ToLower
                                        ProfitCol = htNumberAlpahbit(col).ToString
                                End Select
                            Catch ex As Exception

                            End Try
                        Next
                        Exit For
                    End If
                End If
            Next


            If CountryCol Is Nothing Then
                MsgBox("There is no 'Country' column in the excel file.")
                Return
            End If
            If DurationCol Is Nothing Then
                MsgBox("There is no 'Duration' column in the excel file.")
                Return
            End If
            If CostINCol Is Nothing Then
                MsgBox("There is no 'Cost In' column in the excel file.")
                Return
            End If
            If MarginCol Is Nothing Then
                MsgBox("There is no 'Margin' column in the excel file.")
                Return
            End If
            If ProfitCol Is Nothing Then
                MsgBox("There is no 'Profit' column in the excel file.")
                Return
            End If
            ' -------------------------- end ----------------------------------

            For row = 2 To Me.worksheet.UsedRange.Rows.Count
                x += x
                If x < 100 Then
                    Me.ProgressBar1.Value = CInt(x)
                End If
                If boolRead = False Then
                    If Not Me.worksheet.Range("B" & row).Value() Is Nothing Then

                        If Me.worksheet.Range("B" & row).Value().ToString.ToUpper = "INBOUND" Then
                            'get company name from the first column
                            If Not Me.worksheet.Range("A" & row).Value() Is Nothing Then
                                Dim strCompanyName As String = Me.worksheet.Range("A" & row).Value().ToString
                                Dim words As String() = strCompanyName.Split(New String() {"Account Manager"},
                                            StringSplitOptions.None)
                                ClientCode = "'" + words(0).Trim + "'"
                            Else
                                For i As Integer = row To 0 Step -1
                                    If Not Me.worksheet.Range("A" & i).Value() Is Nothing Then
                                        Dim strCompanyName As String = Me.worksheet.Range("A" & i).Value().ToString
                                        Dim words As String() = strCompanyName.Split(New String() {"Account Manager"},
                                                    StringSplitOptions.None)
                                        ClientCode = "'" + words(0).Trim + "'"
                                        Exit For
                                    End If
                                Next
                            End If
                            ''''''''''''''''''
                            boolRead = True
                            Continue For
                        End If
                    Else
                        Exit For
                    End If

                ElseIf boolRead Then
                    If Not Me.worksheet.Range("B" & row).Value().ToString.ToUpper = "TOTAL" AndAlso Not Me.worksheet.Range("B" & row).Value().ToString.ToUpper = "OUTBOUND" Then
                        Try
                            If Not Me.worksheet.Range("B" & row).Value().ToString.ToUpper = "INBOUND" Then
                                If Me.worksheet.Range("B" & row).Value().ToString = "Point Name" Then
                                    Continue For
                                End If

                                '  ClientCode = "'" + Me.worksheet.Range("B" & row).Value().ToString + "'"
                                AreaName = "'" + Me.worksheet.Range(CountryCol & row).Value().ToString.Replace("'", "") + "'"
                                AreaCode = "'" + "" + "'"
                                If Not Me.worksheet.Range(CostINCol & row).Value() Is Nothing AndAlso IsNumeric(Me.worksheet.Range(CostINCol & row).Value()) Then
                                    TotalCharge = Math.Round(CDec(Me.worksheet.Range(CostINCol & row).Value()), 3)
                                Else
                                    TotalCharge = 0
                                End If

                                TotalDuration = getDurationInSeconds(Me.worksheet.Range(DurationCol & row).Value())

                                Profit = Math.Round(CDec(Me.worksheet.Range(ProfitCol & row).Value().ToString.TrimEnd(CChar("%"))), 3)
                                Margin = Math.Round(CDec(Me.worksheet.Range(MarginCol & row).Value()), 3)

                                sql.Append("(0," & ClientCode & "," & AreaName & "," & AreaCode & "," & TotalCharge & "," & TotalDuration & "," & dToday & "," & dFromDate & "," & dToDate & "," & lSoftware & "," & gUser.Id & ",1," & intPeriod & "," & Margin & "," & Profit & "),")
                            Else
                                boolRead = False
                                row -= 1
                            End If

                        Catch ex As Exception
                            '  MsgBox(ex.Message & "  " & ex.StackTrace)
                        End Try
                    Else
                        boolRead = False
                    End If
                End If


            Next

            Me.ProgressBar1.Value = 100
            excel.Workbooks.Close()
            excel.Quit()
            boolError = odbaccess.ExecuteSQL(sql.ToString.Substring(0, sql.ToString.Length - 1))

            If boolError Then
                '  MsgBox("Inbound data imported successfully.")
                odbaccess.InsertHistory("Imported Inbound Media Core Data", 11)
                '  filename = ""
                '   Me.txtFileName.Text = ""
                Me.ProgressBar1.Value = 0
            Else
                MsgBox("An error occured!")
            End If
            Me.btnSave.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Private Sub ImportDataFromVos()
        Try
            Dim dFromDate, dToDate, dInvoiceDate As String
            Dim lSoftware As Long
            Dim ClientCode, AreaName, AreaCode As String
            Dim TotalCharge, TotalDuration As Double
            Dim boolError As Boolean
            Dim sql As New System.Text.StringBuilder
            excel.Visible = True
            Dim ExcelPath As String = filename
            Dim intPeriod As Integer
            Dim htNumberAlpahbit As Hashtable = GetHashtable()
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            worksheet = excel.Worksheets(1)

            sql.Append("INSERT INTO billing (FK_Client,client_Code, Area_Name, Area_Code, Total_Charges, Total_Duration, Insert_Date, Billing_Period_From, Billing_Period_To,FK_Software,inst_by,InvoicePeriod,Margin,Profit) VALUES")
            dFromDate = "'" + Me.dtpFromDate.Value.ToString("yyyy-MM-dd") + "'"
            dToDate = "'" + Me.dtpToDate.Value.ToString("yyyy-MM-dd") + "'"
            dInvoiceDate = "'" + Me.dtpInvoiceDate.Value.ToString("yyyy-MM-dd") + "'"
            lSoftware = CLng(Me.cmbSoftwareID.SelectedValue)
            intPeriod = CInt(cmbPeriod.Text)
            Dim x As Double
            x = 100 / Me.worksheet.UsedRange.Rows.Count

            Dim clientCodeCol, AreaNameCol, AreaCodeCol, TotalChargeCol, TotalDurationCol As String

            For col = 1 To Me.worksheet.UsedRange.Columns.Count
                Try
                    Select Case Me.worksheet.Range(htNumberAlpahbit(col).ToString & 1).Value().ToString.Trim.ToLower
                        Case "Account id".ToLower
                            clientCodeCol = htNumberAlpahbit(col).ToString
                        Case "Area name".ToLower
                            AreaNameCol = htNumberAlpahbit(col).ToString
                        Case "Area prefix".ToLower
                            AreaCodeCol = htNumberAlpahbit(col).ToString
                        Case "Call Charges".ToLower
                            TotalChargeCol = htNumberAlpahbit(col).ToString
                        Case "Total duration".ToLower
                            TotalDurationCol = htNumberAlpahbit(col).ToString
                    End Select
                Catch ex As Exception

                End Try
            Next

            If clientCodeCol Is Nothing Then
                MsgBox("There is no 'Account id' column in the excel file.")
                Return
            End If
            If AreaNameCol Is Nothing Then
                MsgBox("There is no 'Area name' column in the excel file.")
                Return
            End If
            If AreaCodeCol Is Nothing Then
                MsgBox("There is no 'Area prefix' column in the excel file.")
                Return
            End If
            If TotalChargeCol Is Nothing Then
                MsgBox("There is no 'Call charges' column in the excel file.")
                Return
            End If
            If TotalDurationCol Is Nothing Then
                MsgBox("There is no 'Total duration' column in the excel file.")
                Return
            End If
            For rCnt = 2 To Me.worksheet.UsedRange.Rows.Count
                x += x
                If x < 100 Then
                    Me.ProgressBar1.Value = CInt(x)
                End If
                If Not Me.worksheet.Range(AreaNameCol & rCnt).Value() Is Nothing Then
                    ClientCode = "'" + Me.worksheet.Range(clientCodeCol & rCnt).Value().ToString.Trim + "'"
                Else
                    '  ClientCode = "''"
                    Continue For
                End If

                If Not Me.worksheet.Range(AreaNameCol & rCnt).Value() Is Nothing Then
                    AreaName = "'" + Me.worksheet.Range(AreaNameCol & rCnt).Value().ToString + "'"
                Else
                    AreaName = "''"
                End If
                If Not Me.worksheet.Range(AreaCodeCol & rCnt).Value() Is Nothing Then
                    AreaCode = "'" + Me.worksheet.Range(AreaCodeCol & rCnt).Value().ToString + "'"
                Else
                    AreaCode = "''"
                End If

                If Not Me.worksheet.Range(TotalChargeCol & rCnt).Value() Is Nothing AndAlso IsNumeric(Me.worksheet.Range(TotalChargeCol & rCnt).Value()) Then
                    TotalCharge = Math.Round(CDec(Me.worksheet.Range(TotalChargeCol & rCnt).Value()), 3)
                Else
                    TotalCharge = 0
                End If


                If Not Me.worksheet.Range(TotalDurationCol & rCnt).Value() Is Nothing AndAlso IsNumeric(Me.worksheet.Range(TotalDurationCol & rCnt).Value()) Then
                    TotalDuration = CDbl(Me.worksheet.Range(TotalDurationCol & rCnt).Value())
                Else
                    TotalDuration = 0
                End If

                sql.Append("(0," & ClientCode & "," & AreaName & "," & AreaCode & "," & TotalCharge & "," & TotalDuration & "," & dInvoiceDate & "," & dFromDate & "," & dToDate & "," & lSoftware & "," & gUser.Id & "," & intPeriod & "),")
            Next
            '  MsgBox(sql.ToString)
            Me.ProgressBar1.Value = 100
            excel.Workbooks.Close()
            excel.Quit()
            boolError = odbaccess.ExecuteSQL(sql.ToString.Substring(0, sql.ToString.Length - 1))

            If boolError Then
                odbaccess.CheckRightInvoicePeriodInBilling(intPeriod, dInvoiceDate, lSoftware)
                MsgBox("Operation done successfully.")
                odbaccess.InsertHistory("Imported VOS Data", 11)
                filename = ""
                Me.txtFileName.Text = ""
                Me.ProgressBar1.Value = 0
            Else
                MsgBox("An error occured!")
            End If
            Me.btnSave.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub FillSoftwares()
        Dim dsSoftware As DataSet
        Try
            dsSoftware = odbaccess.GetSoftwareDS
            If Not dsSoftware Is Nothing Then
                Me.cmbSoftwareID.DataSource = dsSoftware.Tables(0)
                Me.cmbSoftwareID.ValueMember = "ID"
                Me.cmbSoftwareID.DisplayMember = "Name"
            End If

        Catch ex As Exception

        End Try

    End Sub

    Function GetHashtable() As Hashtable
        Dim tblAlphabitNumber As Hashtable = New Hashtable
        tblAlphabitNumber.Add(1, "A")
        tblAlphabitNumber.Add(2, "B")
        tblAlphabitNumber.Add(3, "C")
        tblAlphabitNumber.Add(4, "D")
        tblAlphabitNumber.Add(5, "E")
        tblAlphabitNumber.Add(6, "F")
        tblAlphabitNumber.Add(7, "G")
        tblAlphabitNumber.Add(8, "H")
        tblAlphabitNumber.Add(9, "I")
        tblAlphabitNumber.Add(10, "J")
        tblAlphabitNumber.Add(11, "K")
        tblAlphabitNumber.Add(12, "L")
        tblAlphabitNumber.Add(13, "M")
        tblAlphabitNumber.Add(14, "N")
        tblAlphabitNumber.Add(15, "O")
        tblAlphabitNumber.Add(16, "P")
        tblAlphabitNumber.Add(17, "Q")
        tblAlphabitNumber.Add(18, "R")
        tblAlphabitNumber.Add(19, "S")
        tblAlphabitNumber.Add(20, "T")
        tblAlphabitNumber.Add(21, "U")
        tblAlphabitNumber.Add(22, "V")
        tblAlphabitNumber.Add(23, "W")
        tblAlphabitNumber.Add(24, "X")
        tblAlphabitNumber.Add(25, "Y")
        tblAlphabitNumber.Add(26, "Z")
        Return tblAlphabitNumber
    End Function

    Function getDurationInSeconds(ByVal obj As Object) As Long
        If obj Is Nothing OrElse obj.ToString = "0:00" Then
            Return 0
        Else
            If obj.ToString.Contains(":") Then
                Dim Min, Sec As Long
                Dim strArr() As String
                strArr = obj.ToString.Split(CChar(":"))
                Min = CLng(strArr(0)) * 60
                Sec = CLng(strArr(1))
                Return Min + Sec
            Else
                Return 0
            End If
        End If
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.dtpInvoiceDate.Enabled = True
    End Sub

    Private Sub cmbPeriod_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPeriod.SelectedIndexChanged
        If cmbPeriod.Text = "7" Then
            Me.dtpFromDate.Value = Now.Date.AddDays(-7)
            Me.dtpToDate.Value = Now.Date.AddDays(-1)
        ElseIf cmbPeriod.Text = "15" Then
            If Now.Day >= 16 Then
                Me.dtpFromDate.Value = CDate(Now.Date.Year & "-" & Now.Date.Month & "-01") ' from first day of the month
                Me.dtpToDate.Value = CDate(Now.Date.Year & "-" & Now.Date.Month & "-15") ' 15th of the month
            ElseIf Now.Day < 16 Then
                Dim dDate As Date
                dDate = Now()
                dDate = dDate.AddMonths(-1)
                dDate = CDate(dDate.Year & "-" & dDate.Month & "-16") '.ToString("")
                Me.dtpFromDate.Value = dDate
                dDate = Now()
                dDate = dDate.AddMonths(-1)
                dDate = CDate(dDate.Year & "-" & dDate.Month & "-" & Now.DaysInMonth(Now.Year, Now.AddMonths(-1).Month))

                Me.dtpToDate.Value = dDate
            End If
        ElseIf cmbPeriod.Text = 30 Then ' period=30
            Dim dDate As Date
            dDate = Now()
            dDate = dDate.AddMonths(-1)
            dDate = CDate(dDate.Year & "-" & dDate.Month & "-" & "1") '.ToString("")
            Me.dtpFromDate.Value = dDate
            dDate = Now()
            dDate = dDate.AddMonths(-1)
            dDate = CDate(dDate.Year & "-" & dDate.Month & "-" & Now.DaysInMonth(Now.Year, Now.AddMonths(-1).Month))

            Me.dtpToDate.Value = dDate
        Else

        End If
    End Sub
End Class