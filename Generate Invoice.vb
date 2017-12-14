
'Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel
Imports System.IO


Public Class Generate_Invoice
    Public dInsertDate As Date
    Dim excel As Application = New Application
    Dim worksheet As Worksheet
    Dim oWorkBook As Workbook
    Dim RootDirectory As String

    '--- PDF Parameters---
    Dim PDFFile As String = "C:\Users\dalia\Desktop\invoices\Test.pdf"
    Dim pFormatType As XlFixedFormatType = XlFixedFormatType.xlTypePDF
    Dim pQuality As XlFixedFormatQuality = XlFixedFormatQuality.xlQualityMinimum
    Dim pIncludeDocProperties As Boolean = True
    Dim pIgnorePrintAreas As Boolean = True
    Dim pFrom As Object = Type.Missing
    Dim pTo As Object = Type.Missing
    Dim pOpenAfterPublish As Boolean = False

    Public Sub New()
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
        RootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
        If (Not System.IO.Directory.Exists(RootDirectory)) Then
            System.IO.Directory.CreateDirectory(RootDirectory)
        End If
    End Sub

    Public Sub New(ByVal dInsertDate As Date)

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
        RootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
        If (Not System.IO.Directory.Exists(RootDirectory)) Then
            System.IO.Directory.CreateDirectory(RootDirectory)
        End If

        Dim lClientID As Long
        Me.dInsertDate = dInsertDate
        Dim ds As DataSet
        ds = odbaccess.GetBillingClients(dInsertDate)
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

                lClientID = CLng(dr.Item("ID"))
                GenerateClientInvoice(lClientID)
                dValue += x
                PBar.lblPercent.Text = Math.Round(dValue, 0).ToString + "%"
            Next

            ' GenerateWeeklyReport(dInsertDate)
            PBar.Close()
            MsgBox("Operation done successfully.")
        Else
            MsgBox("No data found.")
        End If

    End Sub

    Public Sub GenerateClientInvoice(ByVal lClientID As Long)
        Dim ds As DataSet
        ds = odbaccess.GetInvoiceDetails(lClientID, dInsertDate)
        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 Then
            GenerateExcelFile(ds)
        End If
    End Sub

    Public Sub GenerateExcelFile(ByVal ds As DataSet)
        Try
            Dim strName As String
            excel.Visible = True
            Dim i As Integer
            Dim ExcelPath As String = System.Windows.Forms.Application.StartupPath & "\Invoice.xlsx"
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            RootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
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
                    Me.worksheet.Range("D" & i).Value = Math.Round(dr.Item("Total_Charges"), 3)
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
            If Not oWorkbook Is Nothing Then
                oWorkbook.ExportAsFixedFormat(pFormatType, PDFFile, pQuality, _
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

                RootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
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
                            Me.worksheet.Range("E" & i).Value = .Item("Amount")
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

    Public Sub GenerateStatementOfAccountReport()
        Try
            Dim frmStatementOfAccount As New frmStatementOfAccount
            Dim intRowIndex, intCounter As Integer
            Dim dLastDate As Date
            Dim dblAmount As Double
            Dim ds As DataSet
            ds = odbaccess.GetStatementOfAccount()
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

                If ds.Tables(0).Rows.Count > 5 Then
                    Dim x As Integer
                    x = ds.Tables(0).Rows.Count - 5
                    For i = 1 To x
                        worksheet.Rows(4).Insert()
                    Next

                End If

                Me.worksheet.Range("B" & 1).Value = "Statement Of Acount   " & Now.Date.ToString("dd-MM-yyyy")

                i = 3
                For Each dr As DataRow In ds.Tables(0).Rows
                    With dr
                        If Not .Item("Company_Code") Is DBNull.Value Then
                            Me.worksheet.Range("B" & i).Value = .Item("Company_Code")
                        End If
                        If Not .Item("BeginingBalance") Is DBNull.Value Then
                            Me.worksheet.Range("C" & i).Value = .Item("BeginingBalance")
                        End If
                        If Not .Item("Credit") Is DBNull.Value Then
                            Me.worksheet.Range("D" & i).Value = .Item("Credit")
                        End If
                        If Not .Item("Debit") Is DBNull.Value Then
                            Me.worksheet.Range("E" & i).Value = .Item("Debit")
                        End If
                        Dim dblBalance As Double
                        dblBalance = CDbl(.Item("BeginingBalance")) + CDbl(.Item("Credit")) - CDbl(.Item("Debit"))
                        Dim f As String
                        f = "=C" & i & "+D" & i & "-E" & i
                        Me.worksheet.Range("F" & i).Formula = f

                        getLastPaymentDate(ds.Tables(1), CInt(.Item("fk_client")), dLastDate, dblAmount)

                        Me.worksheet.Range("G" & i).Value = dLastDate
                        Me.worksheet.Range("H" & i).Value = dblAmount

                        If Not .Item("Credit_Limit") Is DBNull.Value Then
                            Me.worksheet.Range("I" & i).Value = .Item("Credit_Limit")
                        End If

                        Dim intDiff As Long
                        intDiff = DateDiff(DateInterval.Day, dLastDate, Now())
                        If intDiff > 21 And dblBalance < 0 Then
                            'Me.worksheet.Range("B" & i).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                            'Me.worksheet.Range("C" & i).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                            'Me.worksheet.Range("D" & i).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                            'Me.worksheet.Range("E" & i).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                            'Me.worksheet.Range("F" & i).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                            'Me.worksheet.Range("G" & i).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                            'Me.worksheet.Range("H" & i).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)

                            Me.worksheet.Range("J" & i).Value = intDiff
                        End If

                        If Not .Item("AccountManager") Is DBNull.Value Then
                            Me.worksheet.Range("K" & i).Value = .Item("AccountManager")
                        End If


                        ' Fill Form DataGrid
                        intRowIndex = frmStatementOfAccount.DataGridView1.Rows.Add
                        With frmStatementOfAccount.DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("fk_client")
                            .Cells(1).Value = intCounter + 1
                            .Cells(3).Value = dr.Item("Company_Code")
                            .Cells(4).Value = dr.Item("AccountManager")
                            .Cells(5).Value = dr.Item("BeginingBalance")
                            .Cells(6).Value = dr.Item("Credit")
                            .Cells(7).Value = dr.Item("Debit")
                            .Cells(8).Value = Math.Round(dblBalance, 3)
                            .Cells(9).Value = CDate(dLastDate).ToString("yyyy-MM-dd")
                            .Cells(10).Value = dblAmount
                            .Cells(11).Value = dr.Item("Credit_Limit")
                            If intDiff > 21 And dblBalance < 0 Then
                                .DefaultCellStyle.BackColor = Color.RosyBrown
                                .Cells(12).Value = intDiff
                            End If

                            ' .Cells(13).Value = dr.Item("isSentEmail")

                            intCounter += 1
                        End With
                        i += 1
                    End With
                Next
                frmStatementOfAccount.Show()

                strName = "Statement Of Account - " & Now.ToString("ddMMyyyy")
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
                ' excel.Workbooks.Close()
                '  excel.Quit()
            End If
        Catch ex As Exception

        End Try
    End Sub

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
                If gCountry = "Jordan" Then
                    strCompany = "Maple"
                ElseIf gCountry = "Yerevan" Then
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

    Public Sub getLastPaymentDate(ByVal dt As System.Data.DataTable, ByVal lClientID As Integer, ByRef dLastDate As String, ByRef dblAmount As Double)
        Try
            dLastDate = Nothing
            dblAmount = 0
            For Each dr As DataRow In dt.Rows
                If CInt(dr.Item("fk_client")) = lClientID Then
                    dLastDate = CDate(dr.Item("Insert_Date")).ToString("yyyy/MM/dd")
                    dblAmount = Math.Round(CDbl(dr.Item("Amount")), 3)
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
