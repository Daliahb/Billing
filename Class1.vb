Imports Excel = Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Core
Public Class Form1
    Public Sub New()
        'Dim xlApp As Excel.Application
        'Dim xlWorkBook As Excel.Workbook
        'Dim xlWorkSheet As Excel.Worksheet
        'Dim misValue As Object = System.Reflection.Missing.Value

        'xlApp = New Excel.ApplicationClass
        'xlWorkBook = xlApp.Workbooks.Add(misValue)
        'xlWorkSheet = xlWorkBook.Sheets("sheet1")

        ''add some text
        'xlWorkSheet.Cells(1, 1) = "http://vb.net-informations.com"
        'xlWorkSheet.Cells(2, 1) = "Adding picture in Excel File"

        ''replace you picture to xl_pic.JPG

        ''xlWorkSheet.Shapes.AddPicture("F:\BillingSystem\Billing\Billing\bin\Debug\small maple logo.JPG", _
        ''   Microsoft.Office.Core.MsoTriState.msoCTrue, _
        ''     Microsoft.Office.Core.MsoTriState.msoCTrue, 300, 0, 231 * 3 / 4, 74 * 3 / 4)



        'xlWorkSheet.SaveAs("D:\vbexcel.xlsx")

        'xlWorkBook.Close()
        'xlApp.Quit()

        'releaseObject(xlApp)
        'releaseObject(xlWorkBook)
        'releaseObject(xlWorkSheet)

        'MsgBox("Excel file created , you can find the file c:\")
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class