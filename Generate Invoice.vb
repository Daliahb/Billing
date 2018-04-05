
'Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel
Imports System.IO


Public Class Generate_Invoice
    Public dInsertDate As Date
    Dim excel As Application = New Application
    Dim worksheet As Worksheet
    Dim oWorkBook As Workbook
    Dim RootDirectory As String
    Dim dsStatmentNotes As DataSet

    '--- PDF Parameters---
    Dim PDFFile As String '= "C:\Users\dalia\Desktop\invoices\Test.pdf"
    Dim pFormatType As XlFixedFormatType = XlFixedFormatType.xlTypePDF
    Dim pQuality As XlFixedFormatQuality = XlFixedFormatQuality.xlQualityMinimum
    Dim pIncludeDocProperties As Boolean = True
    Dim pIgnorePrintAreas As Boolean = True
    Dim pFrom As Object = Type.Missing
    Dim pTo As Object = Type.Missing
    Dim pOpenAfterPublish As Boolean = False

    Public Sub New(dInsertDate As Date)
        If My.Settings.RootDirectory.Length = 0 Then
            If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                Dim folderDlg As New FolderBrowserDialog
                folderDlg.SelectedPath = My.Settings.RootDirectory
                folderDlg.ShowNewFolderButton = True
                folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                If (folderDlg.ShowDialog() = DialogResult.OK) Then

                    '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                    My.Settings.RootDirectory = folderDlg.SelectedPath
                End If
            Else
                Return
            End If

        End If
        'create a folder with today's date
        RootDirectory = My.Settings.RootDirectory + "/" + dInsertDate.ToString("dd-MM-yyyy")
        If (Not System.IO.Directory.Exists(RootDirectory)) Then
            System.IO.Directory.CreateDirectory(RootDirectory)
        End If

        Me.dInsertDate = dInsertDate
    End Sub

    Public Sub New(ByVal dInsertDate As Date, lClientId As Long, intPeriod As Integer)

        If My.Settings.RootDirectory.Length = 0 Then
            If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                Dim folderDlg As New FolderBrowserDialog
                folderDlg.SelectedPath = My.Settings.RootDirectory
                folderDlg.ShowNewFolderButton = True
                folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                If (folderDlg.ShowDialog() = DialogResult.OK) Then

                    '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                    My.Settings.RootDirectory = folderDlg.SelectedPath
                End If
            Else
                Return
            End If

        End If
        'create a folder with today's date
        RootDirectory = My.Settings.RootDirectory + "/" + dInsertDate.ToString("dd-MM-yyyy") + "/" + intPeriod.ToString
        If (Not System.IO.Directory.Exists(RootDirectory)) Then
            System.IO.Directory.CreateDirectory(RootDirectory)
        End If

        Me.dInsertDate = dInsertDate
        Dim ds As DataSet

        If lClientId = 0 Then
            ds = odbaccess.GetBillingClients(dInsertDate, intPeriod)
            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                Dim PBar As New frmProgressBar
                PBar.Show()

                Dim x As Double = 0
                x = 100 / ds.Tables(0).Rows.Count
                Dim dValue As Double = 0

                PBar.ProgressBar1.Minimum = 0
                PBar.ProgressBar1.Maximum = ds.Tables(0).Rows.Count
                PBar.ProgressBar1.Value = 0
                PBar.ProgressBar1.Step = 1
                For Each dr As DataRow In ds.Tables(0).Rows
                    PBar.ProgressBar1.PerformStep()

                    lClientId = CLng(dr.Item("ID"))
                    GenerateClientInvoice(lClientId, intPeriod)
                    dValue += x
                    PBar.lblPercent.Text = Math.Round(dValue, 0).ToString + "%"
                Next

                ' GenerateWeeklyReport(dInsertDate)
                PBar.Close()
                MsgBox("Operation done successfully.")
            Else
                MsgBox("No data found.")
            End If
        Else 'if lclientID <> 0, then generate invoice for one specific client only
            GenerateClientInvoice(lClientId, intPeriod)
        End If
    End Sub

    Public Sub GenerateClientInvoice(ByVal lClientID As Long, intPeriod As Integer)
        Dim ds As DataSet
        ds = odbaccess.GetInvoiceDetails(lClientID, dInsertDate)
        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 Then
            GenerateExcelFile(ds, intPeriod)
        End If
    End Sub

    Public Sub GenerateExcelFile(ByVal ds As DataSet, intPeriod As Integer)
        Try
            Dim strName As String
            excel.Visible = True
            Dim i As Integer
            Dim ExcelPath As String = System.Windows.Forms.Application.StartupPath & "\Invoice.xlsx"
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            RootDirectory = My.Settings.RootDirectory + "/" + dInsertDate.ToString("dd-MM-yyyy") + "/" + intPeriod.ToString
            Dim LogoPath As String


            worksheet = excel.Worksheets(1)

            With ds.Tables(0).Rows(0)
                'Client&Company info

                Me.worksheet.Range("b" & 2).Value = .Item("CompanyName")
                If Not .Item("CompanyAddress") Is DBNull.Value Then
                    Me.worksheet.Range("b" & 4).Value = .Item("CompanyAddress")
                End If

                Me.worksheet.Range("b" & 7).Value = "Invoice To: " + .Item("ClientName").ToString
                If Not .Item("ClientAddress") Is DBNull.Value Then
                    Me.worksheet.Range("b" & 8).Value = .Item("ClientAddress")
                End If
                If Not .Item("InvoiceNo") Is DBNull.Value Then
                    Me.worksheet.Range("d" & 7).Value = .Item("InvoiceNo")
                End If

                Me.worksheet.Range("d" & 8).Value = dInsertDate
                Me.worksheet.Range("d" & 9).Value = dInsertDate.AddDays(CLng(.Item("Statement")))
                Me.worksheet.Range("d" & 10).Value = .Item("TimeZone")
                Me.worksheet.Range("d" & 11).Value = .Item("PaymentTerms")
                Me.worksheet.Range("b" & 10).Value = "Billing Period: " + CDate(.Item("Billing_Period_From")).ToString("dd/MM/yyyy") + " - " + CDate(.Item("Billing_Period_to")).ToString("dd/MM/yyyy")
                Me.worksheet.Range("b" & 11).Value = "Time: " + CDate(.Item("Billing_Period_From")).ToString("dd/MM/yyyy") + " 00:00:00 TO " + CDate(.Item("Billing_Period_to")).ToString("dd/MM/yyyy") + "  23:59:59"

                'Bank account info
                If Not .Item("Account_Name") Is DBNull.Value Then
                    Me.worksheet.Range("c" & 41).Value = .Item("Account_Name")
                End If
                If Not .Item("Account_Number") Is DBNull.Value Then
                    Me.worksheet.Range("c" & 42).Value = .Item("Account_Number")
                End If
                If Not .Item("IBAN") Is DBNull.Value Then
                    Me.worksheet.Range("c" & 43).Value = .Item("IBAN")
                End If
                If Not .Item("Beneficiary_Bank_Name") Is DBNull.Value Then
                    Me.worksheet.Range("c" & 44).Value = .Item("Beneficiary_Bank_Name")
                End If
                If Not .Item("Beneficiary_Bank_Address") Is DBNull.Value Then
                    Me.worksheet.Range("c" & 45).Value = .Item("Beneficiary_Bank_Address")
                End If
                If Not .Item("SWIFT") Is DBNull.Value Then
                    Me.worksheet.Range("c" & 46).Value = .Item("SWIFT")
                End If

                If Not .Item("Account_Number") Is DBNull.Value Then
                    Me.worksheet.Range("c" & 47).Value = .Item("Account_Number").ToString
                End If

                If Not .Item("ABARouting") Is DBNull.Value Then
                    Me.worksheet.Range("c" & 48).Value = .Item("ABARouting").ToString
                End If

                If Not .Item("LogoName") Is DBNull.Value AndAlso Not .Item("LogoName").ToString.Length = 0 Then
                    LogoPath = System.Windows.Forms.Application.StartupPath & "\" & .Item("LogoName").ToString
                Else
                    LogoPath = ""
                End If


                If ds.Tables(1).Rows.Count > 21 Then
                    Dim x As Integer
                    x = ds.Tables(1).Rows.Count - 20
                    For i = 1 To x
                        worksheet.Rows(16).Insert()
                    Next

                End If
                'Details info
                i = 15
                For Each dr As DataRow In ds.Tables(1).Rows

                    Me.worksheet.Range("B" & i).Value = dr.Item("Area_Name")
                    '  Me.worksheet.Range("c" & i).Value = dr.Item("Area_Code")
                    Me.worksheet.Range("C" & i).Value = dr.Item("Total_Duration")
                    Me.worksheet.Range("D" & i).Value = Math.Round(CDbl(dr.Item("Total_Charges")), 2)
                    i += 1
                Next


                strName = "Invoice-" + .Item("CompanyCode").ToString + "-" + dInsertDate.ToString("ddMMyyyy")
                ' strName = strName + Now.ToString("mmff")
            End With
            'worksheet.Unprotect("111111")

            If Not LogoPath.Length = 0 Then
                ''Me.worksheet.Shapes.AddPicture(LogoPath, _
                ''Microsoft.Office.Core.MsoTriState.msoFalse, _
                ''Microsoft.Office.Core.MsoTriState.msoCTrue, 455, 0, 231 * 3 / 4, 74 * 3 / 4)

                'Me.worksheet.Shapes.AddPicture(LogoPath, _
                '0, 1, 455, 0, 231 * 3 / 4, 74 * 3 / 4)

                Me.worksheet.Shapes.AddPicture(LogoPath, 0, 1, 455, 0, 231 * 3 / 4, 74 * 3 / 4)

            End If

            worksheet.Protect("111111", False, True, False, True, True, True, True, True, True, True, True, True, True, True, True)
            '
            worksheet.SaveAs(Filename:=RootDirectory & "\" & strName)



            ' ---- Generate PDF File ------

            Dim PDFFile As String = RootDirectory & "\" & strName & ".pdf"
            Me.worksheet.PageSetup.FitToPagesWide = 1
            Me.worksheet.PageSetup.FitToPagesTall = 1
            Me.worksheet.PageSetup.Zoom = False
            oWorkBook = excel.Workbooks(1)
            If Not oWorkBook Is Nothing Then
                oWorkBook.ExportAsFixedFormat(pFormatType, PDFFile, pQuality, _
                                              pIncludeDocProperties, _
                                              pIgnorePrintAreas, _
                                              pFrom, pTo, pOpenAfterPublish)
            End If
            excel.Workbooks.Close()
            excel.Quit()

        Catch ex As Exception
            'excel.Workbooks.Close()
            'excel.Quit()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub GenerateWeeklyReport(ByVal dInsertDate As Date)
        Try

            Dim ds As DataSet
            ds = odbaccess.GenerateWeeklyReport(dInsertDate)
            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 Then
                '  GenerateExcelFile(ds)

                RootDirectory = My.Settings.RootDirectory + "/" + dInsertDate.ToString("dd-MM-yyyy")
                Dim strName As String
                excel.Visible = True
                Dim i As Integer
                Dim ExcelPath As String = System.Windows.Forms.Application.StartupPath & "\Weekly Report.xlsx"
                excel.Workbooks.Open(ExcelPath)
                excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized

                worksheet = excel.Worksheets(1)

                If ds.Tables(0).Rows.Count > 5 Then
                    Dim x As Integer
                    x = ds.Tables(0).Rows.Count - 5
                    For i = 1 To x
                        worksheet.Rows(7).Insert()
                    Next

                End If

                Me.worksheet.Range("B" & 4).Value = dInsertDate

                i = 6
                For Each dr As DataRow In ds.Tables(0).Rows
                    With dr
                        If Not .Item("Company_Code") Is DBNull.Value Then
                            Me.worksheet.Range("B" & i).Value = .Item("Company_Code")
                        End If
                        If Not .Item("Bank_Name") Is DBNull.Value Then
                            Me.worksheet.Range("C" & i).Value = .Item("Bank_Name")
                        End If
                        If Not .Item("InvoiceNo") Is DBNull.Value Then
                            Me.worksheet.Range("D" & i).Value = .Item("InvoiceNo")
                        End If
                        If Not .Item("Amount") Is DBNull.Value Then
                            Me.worksheet.Range("E" & i).Value = Math.Round(.Item("Amount"), 2)
                        End If
                        If Not .Item("Duration") Is DBNull.Value Then
                            Me.worksheet.Range("F" & i).Value = .Item("Duration")
                        End If
                        If Not .Item("Credit_Limit") Is DBNull.Value Then
                            Me.worksheet.Range("G" & i).Value = .Item("Credit_Limit")
                        End If
                        i += 1
                    End With
                Next



                strName = "Weekly Report - " & dInsertDate.ToString("ddMMyyyy")
                If My.Settings.RootDirectory.Length = 0 Then
                    If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                        Dim folderDlg As New FolderBrowserDialog
                        folderDlg.SelectedPath = My.Settings.RootDirectory
                        folderDlg.ShowNewFolderButton = True
                        folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                        If (folderDlg.ShowDialog() = DialogResult.OK) Then

                            '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                            My.Settings.RootDirectory = folderDlg.SelectedPath
                        End If
                    Else
                        Return
                    End If

                End If
                worksheet.SaveAs(Filename:=RootDirectory & "\" & strName)
                ' excel.Workbooks.Close()
                '  excel.Quit()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GenerateStatementOfAccountReport(enumClientStatus As Enumerators.ClientStatus, Optional dt As System.Data.DataTable = Nothing)
        Try
            Dim intRowIndex, intCounter As Integer
            Dim dLastDate As Date
            Dim dblAmount, dblCredit, dblDebit As Double
            Dim ds As DataSet
            Dim dblTotalClientPayment, dblTotalTransactionBankFees, dblTotalBankFees As Double

            ds = odbaccess.GetStatementOfAccount(enumClientStatus)

            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 Then
                '  GenerateExcelFile(ds)

                RootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
                Dim strName As String
                excel.Visible = True
                Dim i As Integer
                Dim ExcelPath As String = System.Windows.Forms.Application.StartupPath & "\Statement Of Account.xlsx"
                excel.Workbooks.Open(ExcelPath)
                excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized

                worksheet = excel.Worksheets(1)

                'If ds.Tables(0).Rows.Count > 5 Then
                '    Dim x As Integer
                '    x = ds.Tables(0).Rows.Count - 5
                '    For i = 1 To x
                '        worksheet.Rows(6).Insert()
                '    Next
                'End If

                Me.worksheet.Range("G" & 1).Value = "Statement Of Acount   " & Now.Date.ToString("dd-MM-yyyy")
                If Not ds.Tables.Count < 3 AndAlso Not ds.Tables(2) Is Nothing AndAlso Not ds.Tables(2).Rows.Count = 0 Then
                    Me.worksheet.Range("B" & 3).Value = "MC Data - " & CDate(ds.Tables(2).Rows(0).Item(0)).ToString("dd-MM-yyyy")
                End If
                i = 5
                For Each dr As DataRow In ds.Tables(0).Rows
                    With dr
                        If i > 8 Then
                            worksheet.Rows(i).Insert()
                        End If
                        If Not .Item("MCClientCode") Is DBNull.Value Then
                            Me.worksheet.Range("B" & i).Value = .Item("MCClientCode")
                        End If

                        If Not .Item("MCBalance") Is DBNull.Value Then
                            Me.worksheet.Range("C" & i).Value = .Item("MCBalance")
                        End If

                        If Not .Item("MCCreditLimit") Is DBNull.Value Then
                            Me.worksheet.Range("D" & i).Value = .Item("MCCreditLimit")
                        End If

                        If Not .Item("MCStatus") Is DBNull.Value Then
                            If CBool(.Item("MCStatus")) = True Then
                                Me.worksheet.Range("E" & i).Value = "Visible"
                            Else
                                Me.worksheet.Range("E" & i).Value = "Invisible"
                            End If

                        End If

                        If Not .Item("MSAccountManager") Is DBNull.Value Then
                            Me.worksheet.Range("F" & i).Value = .Item("MSAccountManager")
                        End If

                        If Not .Item("Company_Code") Is DBNull.Value Then
                            Me.worksheet.Range("G" & i).Value = .Item("Company_Code")
                        End If
                        If Not .Item("enumClientStatus") Is DBNull.Value Then
                            Me.worksheet.Range("H" & i).Value = CType(.Item("enumClientStatus"), Enumerators.ClientStatus).ToString()
                        End If
                        If Not .Item("BeginingBalance") Is DBNull.Value Then
                            Me.worksheet.Range("I" & i).Value = Math.Round(CDbl(.Item("BeginingBalance")), 2)
                        End If
                        'Credit
                        If Not .Item("Purchase") Is DBNull.Value Then
                            Me.worksheet.Range("J" & i).Value = .Item("Purchase")
                        End If
                        If Not .Item("ClientPayment") Is DBNull.Value Then
                            Me.worksheet.Range("K" & i).Value = Math.Round(CDbl(.Item("ClientPayment")), 2)
                        End If
                        If Not .Item("VouchersCredit") Is DBNull.Value Then
                            Me.worksheet.Range("L" & i).Value = .Item("VouchersCredit")
                        End If
                        'Debit
                        If Not .Item("Invoice") Is DBNull.Value Then
                            Me.worksheet.Range("M" & i).Value = Math.Round(CDbl(.Item("Invoice")), 2)
                        End If
                        If Not .Item("MaplePayment") Is DBNull.Value Then
                            Me.worksheet.Range("N" & i).Value = Math.Round(CDbl(.Item("MaplePayment")), 2)
                        End If
                        If Not .Item("VouchersDebit") Is DBNull.Value Then
                            Me.worksheet.Range("O" & i).Value = Math.Round(CDbl(.Item("VouchersDebit")), 2)
                        End If

                        'get Bank Fees percentage from total client payments
                        dblTotalClientPayment = Math.Round(CDbl(.Item("ClientPayment")), 2)
                        dblTotalTransactionBankFees = Math.Round(CDbl(.Item("TotalTransactionsBankFees")), 2)
                        dblTotalBankFees = Math.Round(CDbl(.Item("TotalBankFees")), 2)

                        Me.worksheet.Range("X" & i).Value = (dblTotalBankFees - dblTotalTransactionBankFees)

                        Try
                            If Not dblTotalClientPayment = 0 Then
                                Me.worksheet.Range("Y" & i).Value = Math.Round(((dblTotalBankFees - dblTotalTransactionBankFees) / (dblTotalClientPayment)), 2).ToString
                            Else
                                Me.worksheet.Range("Y" & i).Value = "0"
                            End If
                            Me.worksheet.Range("Z" & i).Value = .Item("NumberOfClientPayments")
                        Catch ex As Exception

                        End Try

                        Dim dblBalance As Double
                        dblBalance = (CDbl(.Item("BeginingBalance")) + CDbl(.Item("Purchase")) + CDbl(.Item("ClientPayment")) + CDbl(.Item("VouchersCredit")) - CDbl(.Item("Invoice")) - CDbl(.Item("MaplePayment")) - CDbl(.Item("VouchersDebit")))
                        Dim j As String
                        j = "=I" & i & "+J" & i & "+K" & i & "+L" & i & "-M" & i & "-" & "N" & i & "-O" & i
                        Me.worksheet.Range("P" & i).Formula = j

                        If Me.worksheet.Range("P" & i).Value < 0 Then
                            dblCredit += Me.worksheet.Range("P" & i).Value
                        Else
                            dblDebit += Me.worksheet.Range("P" & i).Value
                        End If

                        getLastPaymentDate(ds.Tables(1), CInt(.Item("fk_client")), dLastDate, dblAmount)

                        Me.worksheet.Range("S" & i).Value = dLastDate
                        Me.worksheet.Range("T" & i).Value = Math.Round(dblAmount, 2)

                        If Not .Item("Credit_Limit") Is DBNull.Value Then
                            Me.worksheet.Range("U" & i).Value = .Item("Credit_Limit")
                        End If

                        Dim intDiff As Long
                        intDiff = DateDiff(DateInterval.Day, dLastDate, Now())
                        If intDiff > 21 And dblBalance < 0 Then
                            'Me.worksheet.Range("B" & i).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                            Me.worksheet.Range("V" & i).Value = intDiff
                        End If

                        If Not .Item("AccountManager") Is DBNull.Value Then
                            Me.worksheet.Range("W" & i).Value = .Item("AccountManager")
                        End If

                        If Not dt Is Nothing AndAlso Not dt.Rows.Count = 0 Then
                            Try
                                Dim row As DataRow
                                row = dt.Rows.Find(.Item("Company_Code").ToString)

                                Me.worksheet.Range("Q" & i).Value = Math.Round(CDbl(row.Item("Balance")), 2)

                            Catch ex As Exception
                                'Me.worksheet.Range("L" & i).Value = 0
                            End Try
                            Me.worksheet.Range("R" & i).Value = Math.Round(Me.worksheet.Range("P" & i).Value - Me.worksheet.Range("Q" & i).Value, 2)
                        End If

                        i += 1
                    End With
                Next

                dt = Nothing


                Me.worksheet.Range("S2").Value = Math.Round(dblCredit, 2)
                Me.worksheet.Range("S3").Value = Math.Round(dblDebit, 2)


                Dim strStatus As String
                Select Case CType(enumClientStatus, Enumerators.ClientStatus)
                    Case Enumerators.ClientStatus.Active
                        strStatus = "Active - "
                    Case Enumerators.ClientStatus.Disabled
                        strStatus = "Disabled - "
                    Case Enumerators.ClientStatus.Maple_Accounts
                        strStatus = "Maple Accounts - "
                    Case Else
                        strStatus = ""
                End Select
                strName = "Statement Of Account - " & strStatus & Now.ToString("ddMMyyyy")
                If My.Settings.RootDirectory.Length = 0 Then
                    If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                        Dim folderDlg As New FolderBrowserDialog
                        folderDlg.SelectedPath = My.Settings.RootDirectory
                        folderDlg.ShowNewFolderButton = True
                        folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                        If (folderDlg.ShowDialog() = DialogResult.OK) Then

                            '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                            My.Settings.RootDirectory = folderDlg.SelectedPath
                        End If
                    Else
                        Return
                    End If

                End If
                '     worksheet.Protect("111111", False, True, False, True, True, True, True, True, True, True, True, True, True, True, True)
                worksheet.SaveAs(Filename:=RootDirectory & "\" & strName)

            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Function CheckNotes(lClientID As Long) As String
        If Not dsStatmentNotes Is Nothing AndAlso Not dsStatmentNotes.Tables.Count = 0 AndAlso Not dsStatmentNotes.Tables(0).Rows.Count = 0 Then
            For Each row As DataRow In dsStatmentNotes.Tables(0).Rows
                If row.Item("FK_Client") = lClientID Then
                    Return row.Item("Note").ToString
                End If
            Next
        End If
        Return ""
    End Function

    Public Sub GenerateStatementOfAccountReportForClient(ByVal lClientID As Integer)
        Try
            Dim ds As DataSet
            ds = odbaccess.GetStatementOfAccountForClient(lClientID)
            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                '  GenerateExcelFile(ds)

                Dim strName As String
                excel.Visible = True
                Dim i As Integer
                Dim ExcelPath As String = System.Windows.Forms.Application.StartupPath & "\SOA.xlsx"
                excel.Workbooks.Open(ExcelPath)
                excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized

                worksheet = excel.Worksheets(1)

                If ds.Tables(0).Rows.Count > 5 Then
                    Dim x As Integer
                    x = ds.Tables(0).Rows.Count - 5
                    For i = 1 To x
                        worksheet.Rows(7).Insert()
                    Next

                End If

                ' ------------------------------------------------------------
                Dim dblbeginingBalance As Double = CDbl(ds.Tables(0).Rows(0).Item("BeginingBalance")) '0.0
                Dim strClientCode As String = ds.Tables(0).Rows(0).Item("Company_Code").ToString
                Dim strCompany As String
                If gCountry = Enumerators.Country.Jordan Then
                    strCompany = "Maple"
                ElseIf gCountry = Enumerators.Country.Armenia Then
                    strCompany = "Maple Telecommunication FZE"
                End If

                Me.worksheet.Range("C" & 3).Value = strCompany
                Me.worksheet.Range("F" & 3).Value = strCompany
                Me.worksheet.Range("H" & 3).Value = strCompany
                Me.worksheet.Range("J" & 3).Value = strCompany



                '  Me.worksheet.Range("A" & 3).Value = ds.Tables(0).Rows(0).Item("DateFrom").ToString + "-" + ds.Tables(0).Rows(0).Item("DateTo").ToString
                Me.worksheet.Range("B" & 3).Value = dblbeginingBalance
                Me.worksheet.Range("D" & 3).Value = strClientCode
                Me.worksheet.Range("E" & 3).Value = strClientCode
                Me.worksheet.Range("G" & 3).Value = strClientCode
                Me.worksheet.Range("I" & 3).Value = strClientCode


                i = 4
                For Each dr As DataRow In ds.Tables(0).Rows
                    With dr
                        Me.worksheet.Range("A" & i).Value = CDate(.Item("DateFrom")).ToString("yyyy/MM/dd") + " - " + CDate(.Item("DateTo")).ToString("yyyy/MM/dd")
                        If i = 4 Then
                            Me.worksheet.Range("B" & i).Value = dblbeginingBalance
                        Else
                            Me.worksheet.Range("B" & i).Value = Me.worksheet.Range("K" & i - 1).Value
                        End If

                        Me.worksheet.Range("C" & i).Value = CDbl(.Item("Invoices"))
                        Me.worksheet.Range("D" & i).Value = CDbl(.Item("Purchases"))
                        Me.worksheet.Range("E" & i).Value = CDbl(.Item("disputeDebit"))
                        Me.worksheet.Range("F" & i).Value = CDbl(.Item("disputeCredit"))
                        Me.worksheet.Range("G" & i).Value = CDbl(.Item("BankFeesDebit"))
                        Me.worksheet.Range("H" & i).Value = CDbl(.Item("BankFeesCredit"))
                        Me.worksheet.Range("I" & i).Value = CDbl(.Item("ClientPayments"))
                        Me.worksheet.Range("J" & i).Value = CDbl(.Item("MaplePayments"))
                        Dim k As String
                        k = "=B" & i & "+C" & i & "+D" & i & "+E" & i & "+F" & i & "+G" & i & "+H" & i & "+I" & i & "+J" & i
                        Me.worksheet.Range("K" & i).Formula = k
                        i += 1
                    End With
                Next

                ' ------------------------------------------------------------

                strName = "SOA - " & strClientCode & " - " & Now.ToString("ddMMyyyy")
                If My.Settings.RootDirectory.Length = 0 Then
                    If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                        Dim folderDlg As New FolderBrowserDialog
                        folderDlg.SelectedPath = My.Settings.RootDirectory
                        folderDlg.ShowNewFolderButton = True
                        folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                        If (folderDlg.ShowDialog() = DialogResult.OK) Then

                            '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                            My.Settings.RootDirectory = folderDlg.SelectedPath
                        End If
                    Else
                        Return
                    End If

                End If
                ''  worksheet.Protect("111111", False, True, False, True, True, True, True, True, True, True, True, True, True, True, True)
                worksheet.SaveAs(Filename:=RootDirectory & "\" & strName)
                ' excel.Workbooks.Close()
                '  excel.Quit()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GenerateStatementOfAccountReportForClient_New(ByVal lClientID As Integer, strClientCode As String)
        Try
            Dim ds As DataSet
            ds = odbaccess.GetStatementOfAccountForClient_New(lClientID)
            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                '  GenerateExcelFile(ds)

                Dim strName As String
                excel.Visible = True
                Dim i As Integer
                Dim ExcelPath As String = System.Windows.Forms.Application.StartupPath & "\Statement Of Account - Client.xlsx"
                excel.Workbooks.Open(ExcelPath)
                excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized

                worksheet = excel.Worksheets(1)

                Me.worksheet.Range("A" & 1).Value = strClientCode & " SOA"

                i = 4
                For Each dr As DataRow In ds.Tables(0).Rows
                    With dr
                        If Not .Item("Source_Type") Is DBNull.Value Then
                            Select Case CType(.Item("Source_Type"), Enumerators.TransactionType)
                                Case Enumerators.TransactionType.ClientPayment
                                    Me.worksheet.Range("A" & i).Value = "CP " & .Item("Source_ID").ToString
                                Case Enumerators.TransactionType.Invoice
                                    Me.worksheet.Range("A" & i).Value = "I " & .Item("Source_ID").ToString
                                Case Enumerators.TransactionType.MaplePayment
                                    Me.worksheet.Range("A" & i).Value = "MP " & .Item("Source_ID").ToString
                                Case Enumerators.TransactionType.Purchase
                                    Me.worksheet.Range("A" & i).Value = "P " & .Item("Source_ID").ToString
                                Case Enumerators.TransactionType.Voucher
                                    Me.worksheet.Range("A" & i).Value = "V " & .Item("Source_ID").ToString
                            End Select
                        End If
                        If Not .Item("Date").ToString = "" Then
                            Me.worksheet.Range("B" & i).Value = CDate(.Item("Date")).ToString("yyyy/MM/dd")
                        End If

                        Me.worksheet.Range("C" & i).Value = .Item("Note").ToString

                        Me.worksheet.Range("D" & i).Value = .Item("InvoiceNo").ToString
                        If Not .Item("Period_From").ToString = "" Then
                            Me.worksheet.Range("E" & i).Value = CDate(.Item("Period_From")).ToString("yyyy/MM/dd")
                        End If
                        If Not .Item("Period_To").ToString = "" Then
                            Me.worksheet.Range("F" & i).Value = CDate(.Item("Period_To")).ToString("yyyy/MM/dd")
                        End If
                        If Not .Item("Duration").ToString = "" Then
                            Me.worksheet.Range("G" & i).Value = CDbl(.Item("Duration"))
                        End If

                        Me.worksheet.Range("H" & i).Value = Math.Round(CDbl(.Item("Credit")) - CDbl(.Item("Debit")), 2)

                        Dim k As String
                        If i = 4 Then
                            k = "=H" & i
                        Else
                            k = "=I" & i - 1 & "+H" & i '& "+D" & i & "+E" & i & "+F" & i & "+G" & i & "+H" & i & "+I" & i & "+J" & i
                        End If

                        Me.worksheet.Range("I" & i).Formula = k
                        i += 1
                    End With
                Next

                ' ------------------------------------------------------------

                strName = strClientCode & " - SOA - " & Now.ToString("ddMMyyyy")
                If My.Settings.RootDirectory.Length = 0 Then
                    If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                        Dim folderDlg As New FolderBrowserDialog
                        folderDlg.SelectedPath = My.Settings.RootDirectory
                        folderDlg.ShowNewFolderButton = True
                        folderDlg.Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                        If (folderDlg.ShowDialog() = DialogResult.OK) Then

                            '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                            My.Settings.RootDirectory = folderDlg.SelectedPath
                        End If
                    Else
                        Return
                    End If

                End If
                ''  worksheet.Protect("111111", False, True, False, True, True, True, True, True, True, True, True, True, True, True, True)
                worksheet.SaveAs(Filename:=RootDirectory & "\" & strName)
                ' excel.Workbooks.Close()
                '  excel.Quit()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub getLastPaymentDate(ByVal dt As System.Data.DataTable, ByVal lClientID As Integer, ByRef dLastDate As String, ByRef dblAmount As Double)
        Try
            dLastDate = Nothing
            dblAmount = 0
            For Each dr As DataRow In dt.Rows
                If CInt(dr.Item("fk_client")) = lClientID Then
                    dLastDate = CDate(dr.Item("Insert_Date")).ToString("yyyy/MM/dd")
                    dblAmount = Math.Round(CDbl(dr.Item("Amount")), 2)
                    If dr.Item("DataFrom").ToString = "mp" Then
                        dblAmount = -dblAmount
                    End If
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
