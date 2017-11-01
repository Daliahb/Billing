Imports System.Net.Mail
Imports System.Net.Mime

Public Class frmEmailBody

    Dim mail As New MailMessage()
    Dim strEmails As String

    Private Sub frmSendEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '    'Me.BackColor = gBackColor
        Me.txtMessage.Text = odbaccess.getEmailBody()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '  inline()
        If odbaccess.EditEmailBody(Me.txtMessage.Text, Me.TextBox1.Text) Then
            MsgBox("Operation done successfuly.")
            Me.Close()
        End If
        'Gmail()
    End Sub

    'Public Sub Gmail()
    '    Try
    '        'set the addresses[
    '        mail.From = New MailAddress(My.Settings.email) '("NadeenMuhaisen@gmail.com")
    '        mail.[To].Add(My.Settings.email) '"NadeenMuhaisen@gmail.com") 'Me.txtTo.Text) '("dalia_badawi@hotmail.com")
    '        mail.[Bcc].Add(Me.txtTo.Text)
    '        'set the content 
    '        mail.Subject = Me.txtSubject.Text '"This is an email"
    '        mail.Body = Me.txtMessage.Text '"this is a sample body"

    '        'set the server 
    '        Dim smtp As New SmtpClient("smtp.gmail.com")
    '        smtp.Credentials = New Net.NetworkCredential(My.Settings.email, My.Settings.EmailPassword) '"cyberjordan@")
    '        ' smtp.UseDefaultCredentials = False
    '        smtp.Port = 587
    '        smtp.EnableSsl = True
    '        'send the message
    '        smtp.Send(mail)
    '        MsgBox("Email sent successfuly.")
    '        resetForm()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Public Sub inline()
        Try
            Dim htmlbody As String
            htmlbody = "<html><body><h1>Picture</h1><br><img src='F:\BillingSystem\Billing\Billing\bin\Debug\it-absolute logo.jpg'></body></html>"
            Dim avHTML As AlternateView
            avHTML = AlternateView.CreateAlternateViewFromString(htmlbody, Nothing, MediaTypeNames.Text.Html)

            ' Create a LinkedResource object for each embedded image
            Dim pic1 As LinkedResource

            pic1 = New LinkedResource("it-absolute logo.jpg", MediaTypeNames.Image.Jpeg)
            pic1.ContentId = "Pic1"
            avHTML.LinkedResources.Add(pic1)


            '// Add the alternate views instead of using MailMessage.Body
            mail.Body = "test test test"

            mail.AlternateViews.Add(avHTML)
            '// Address and send the message
            mail.From = New MailAddress("daliabadawi79@gmail.com") '("NadeenMuhaisen@gmail.com")
            mail.[To].Add("dalia_badawi@hotmail.com") '"NadeenMuhaisen@gmail.com") 'Me.txtTo.Text) '("dalia_badawi@hotmail.com")
            ' mail.[Bcc].Add(Me.txtTo.Text)


            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Credentials = New Net.NetworkCredential("daliabadawi79@gmail.com", "dalloul123") '"cyberjordan@")
            ' smtp.UseDefaultCredentials = False
            smtp.Port = 587
            smtp.EnableSsl = True
            'send the message
            smtp.Send(mail)
            MsgBox("Email sent successfuly.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Public Sub xx()
    '    Dim oMail As New SmtpMail("TryIt")
    '    Dim oSmtp As New SmtpClient()

    '    ' Set sender email address, please change it to yours
    '    oMail.From = "test@emailarchitect.net"

    '    ' Set recipient email address, please change it to yours
    '    oMail.To = "support@emailarchitect.net"

    '    ' Set email subject
    '    oMail.Subject = "direct email sent from VB.NET project"

    '    ' Set email body
    '    oMail.TextBody = "this is a test email sent from VB.NET project directly"

    '    ' Set SMTP server address to ""
    '    Dim oServer As New SmtpServer("")

    '    ' Do not set user authentication
    '    ' Do not set SSL connection            

    '    Try

    '        Console.WriteLine("start to send email directly ...")
    '        oSmtp.SendMail(oServer, oMail)
    '        Console.WriteLine("email was sent successfully!")

    '    Catch ep As Exception

    '        Console.WriteLine("failed to send email with the following error:")
    '        Console.WriteLine(ep.Message)
    '    End Try

    'End Sub



    Public Sub CenterButtons()
        Me.Panel1.Left = CInt((Me.ClientSize.Width / 2) - (Panel1.Width / 2))
    End Sub

    Private Sub frmSendEmail_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterButtons()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class
