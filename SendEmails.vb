Imports System.Net.Mail
Imports System.Net.Mime

Public Class SendEmails

    Dim mail As New MailMessage()
    Dim strEmails, strRootDirectory As String
    Dim dInsertedDate As Date

    Public Sub New()

    End Sub

    Public Sub SendLatePaymentEmail(ByVal isTest As Boolean, ByVal lClientID As Integer)

    End Sub

    Public Function SendEmailTLatePayment(ByVal isTest As Boolean) As Boolean
        '  Try
            '    Dim mail As New MailMessage()
            '    Dim strTestEmail As String

            '    With dr
            '        'set the content 
            '        Dim strBody As String
            '        Dim ccEmail As String
            '        ccEmail = .Item("CCEmail").ToString
            '        If ccEmail.StartsWith(",") Then
            '            ccEmail = ccEmail.Remove(0, 1)
            '        End If
            '        If ccEmail.EndsWith(",") Then
            '            ccEmail = ccEmail.Remove(ccEmail.Length - 1, 1)
            '        End If

            '        strTestEmail = My.Settings.TestEmail
            '        If strTestEmail Is Nothing OrElse strTestEmail.Length = 0 Then
            '            strTestEmail = "Saher@mapletele.com"
            '        End If

            '        mail.From = New MailAddress(.Item("EmailFrom").ToString) '
            '        mail.[To].Add(strTestEmail)


            '        strBody = .Item("EmailBody").ToString & vbCrLf & vbCrLf & .Item("EmailSignature").ToString & vbCrLf & vbCrLf

            '        mail.Body = strBody


            '        mail.Subject = .Item("EmailSubject").ToString

            '        Dim filename As String

            '        filename = "Invoice-" + .Item("ClientCode").ToString + "-" + CDate(.Item("InsertDate")).ToString("ddMMyyyy")
            '        Dim attachment As New Net.Mail.Attachment(strRootDirectory & "\" & filename & ".pdf") '.xlsx") 'create the attachment

            '        mail.Attachments.Add(attachment) 'add the attachment

            '        Dim smtp As New SmtpClient("smtp.gmail.com")
            '        smtp.Credentials = New Net.NetworkCredential(.Item("smtpEamil").ToString, .Item("smtpPassword").ToString)
            '        smtp.Port = 587
            '        smtp.EnableSsl = True


            '        'send the message
            '        smtp.Send(mail)
            '    End With
            '    Return True
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            '    Return False
            'End Try
    End Function

    Public Sub SendEmailByInvoiceID(ByVal strInvoiceIds As String, ByVal strInsertDate As Date, ByVal isTest As Boolean)
        Dim ds As DataSet
        strRootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.SelectedPath = My.Settings.RootDirectory
        folderDlg.ShowNewFolderButton = True
        folderDlg.Description = "Select the location of Invoices.." & vbCrLf & "The current folder is: " & strRootDirectory
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            strRootDirectory = folderDlg.SelectedPath
        End If

        ds = odbaccess.GetEmailInfoByInvoiceID(strInvoiceIds)
       
        SendEmails(ds, isTest, strInsertDate)

    End Sub

    Public Sub SendEmails(ByVal ds As DataSet, ByVal isTest As Boolean, Optional ByVal dInsertedDate As Date = Nothing)
        Dim strSent As New System.Text.StringBuilder
        Dim strDidntSend As New System.Text.StringBuilder

        '   If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
        If Not ds.Tables.Count = 1 Then
            dInsertedDate = CDate(ds.Tables(1).Rows(0).Item(0))
        End If


        Dim PBar As New frmProgressBar
        PBar.Show()

        Dim x As Double = 0
        x = 100 / ds.Tables(0).Rows.Count
        Dim dValue As Double = 0

        PBar.ProgressBar1.Minimum = 0
        PBar.ProgressBar1.Maximum = ds.Tables(0).Rows.Count
        PBar.ProgressBar1.Value = 0
        PBar.ProgressBar1.Step = 1

        'check send this email to the client or test email
        If isTest Then
            For Each dr As DataRow In ds.Tables(0).Rows
                PBar.ProgressBar1.PerformStep()

                If SendEmailTest(dr) Then
                    strSent.Append(dr.Item("ClientID"))
                    strSent.Append(",")
                Else
                    strDidntSend.Append(dr.Item("ClientCode"))
                    strDidntSend.Append(",")
                End If
                dValue += x
                PBar.lblPercent.Text = Math.Round(dValue, 0).ToString + "%"
            Next
        Else 'send emails to client
            For Each dr As DataRow In ds.Tables(0).Rows
                PBar.ProgressBar1.PerformStep()
                If SendEmail(dr) Then
                    strSent.Append(dr.Item("ClientID"))
                    strSent.Append(",")
                Else
                    strDidntSend.Append(dr.Item("ClientCode"))
                    strDidntSend.Append(",")
                End If

                dValue += x
                PBar.lblPercent.Text = Math.Round(dValue, 0).ToString + "%"
            Next
        End If

        PBar.Close()
        'converto pdf
        If strDidntSend.ToString.Length = 0 Then
            MsgBox("Emails were sent successfuly.")
        Else
            MsgBox("Emails were sent to some clients successfully, but there were something wrong sending emails to clients below:" & vbCrLf & strDidntSend.ToString.Remove(strDidntSend.Length - 1))
        End If

        If Not strSent.ToString.Length = 0 Then
            odbaccess.UpdateInvoiceEmailStatus(strSent.ToString, dInsertedDate)
        End If
    End Sub

    Public Function SendEmail(ByVal dr As DataRow) As Boolean
        Try
            Dim mail As New MailMessage()
            With dr
                'set the content 
                Dim strBody As String
                Dim ccEmail As String
                ccEmail = .Item("CCEmail").ToString
                If ccEmail.StartsWith(",") Then
                    ccEmail = ccEmail.Remove(0, 1)
                End If
                If ccEmail.EndsWith(",") Then
                    ccEmail = ccEmail.Remove(ccEmail.Length - 1, 1)
                End If


                mail.From = New MailAddress(.Item("EmailFrom").ToString) '
                mail.[To].Add(.Item("EmailTo").ToString) '"dalia_BAdawi@hotmail.com"
                ' mail.[To].Add("dalia_BAdawi@hotmail.com")
                mail.[Bcc].Add(.Item("BCCEmail").ToString) ''"dalia_BAdawi@hotmail.com"
                mail.[CC].Add(ccEmail)
                strBody = .Item("EmailBody").ToString & vbCrLf & vbCrLf & .Item("EmailSignature").ToString & vbCrLf & vbCrLf

                mail.Body = strBody

                '' ''Dim imageLink = New LinkedResource("G:\BillingSystem\Billing\Billing\bin\Debug\" & .Item("LogoName").ToString)
                '' ''imageLink.ContentId = "myImage"
                '' ''Dim altView = AlternateView.CreateAlternateViewFromString("<html><body>" + strBody +
                '' ''  "<img src=cid:myImage/>" + "<br></body></html>", Nothing, MediaTypeNames.Text.Html)
                '' ''altView.LinkedResources.Add(imageLink)


                ' '' '' //now append it to the body of the mail
                '' ''mail.AlternateViews.Add(altView)
                '' ''mail.IsBodyHtml = True

                'Dim myImageData() As Byte = Nothing

                'Using myImage = Image.FromFile(System.Windows.Forms.Application.StartupPath.ToString & "\" & .Item("LogoName").ToString)
                '    Dim IC As New ImageConverter
                '    myImageData = DirectCast(IC.ConvertTo(myImage, GetType(Byte())), Byte())
                'End Using

                'Using myStream As New IO.MemoryStream(myImageData)
                '    'CREATE ALT VIEW
                '    Dim myAltView As AlternateView = AlternateView.CreateAlternateViewFromString(strBody, New System.Net.Mime.ContentType("text/html"))
                '    Dim myLinkedResouce = New LinkedResource(myStream, "image/jpeg")
                '    myLinkedResouce.ContentId = "ThePictureID" 'this must match in the HTML of the message body

                '    myAltView.LinkedResources.Add(myLinkedResouce)
                '    mail.AlternateViews.Add(myAltView)


                mail.Subject = .Item("EmailSubject").ToString

                Dim filename As String

                filename = "Invoice-" + .Item("ClientCode").ToString + "-" + CDate(.Item("InsertDate")).ToString("ddMMyyyy")
                Dim attachment As New Net.Mail.Attachment(strRootDirectory & "\" & filename & ".pdf") 'create the attachment

                mail.Attachments.Add(attachment) 'add the attachment

                Dim smtp As New SmtpClient("smtp.gmail.com")
                smtp.Credentials = New Net.NetworkCredential(.Item("smtpEamil").ToString, .Item("smtpPassword").ToString)
                smtp.Port = 587
                smtp.EnableSsl = True


                'send the message
                smtp.Send(mail)


            End With
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function SendEmailTest(ByVal dr As DataRow) As Boolean
        Try
            Dim mail As New MailMessage()
            Dim strTestEmail As String


            With dr
                'set the content 
                Dim strBody As String
                Dim ccEmail As String
                ccEmail = .Item("CCEmail").ToString
                If ccEmail.StartsWith(",") Then
                    ccEmail = ccEmail.Remove(0, 1)
                End If
                If ccEmail.EndsWith(",") Then
                    ccEmail = ccEmail.Remove(ccEmail.Length - 1, 1)
                End If

                strTestEmail = My.Settings.TestEmail
                If strTestEmail Is Nothing OrElse strTestEmail.Length = 0 Then
                    strTestEmail = "Saher@mapletele.com"
                End If

                mail.From = New MailAddress(.Item("EmailFrom").ToString) '
                mail.[To].Add(strTestEmail)


                strBody = .Item("EmailBody").ToString & vbCrLf & vbCrLf & .Item("EmailSignature").ToString & vbCrLf & vbCrLf

                mail.Body = strBody


                mail.Subject = .Item("EmailSubject").ToString

                Dim filename As String

                filename = "Invoice-" + .Item("ClientCode").ToString + "-" + CDate(.Item("InsertDate")).ToString("ddMMyyyy")
                Dim attachment As New Net.Mail.Attachment(strRootDirectory & "\" & filename & ".pdf") '.xlsx") 'create the attachment

                mail.Attachments.Add(attachment) 'add the attachment

                Dim smtp As New SmtpClient("smtp.gmail.com")
                smtp.Credentials = New Net.NetworkCredential(.Item("smtpEamil").ToString, .Item("smtpPassword").ToString)
                smtp.Port = 587
                smtp.EnableSsl = True


                'send the message
                smtp.Send(mail)


            End With
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
