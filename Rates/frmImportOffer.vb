Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO

Public Class frmImportOffer

    Public enumEditAdd As New Enumerators.EditAdd
    Public lClientID, lTypeID As Long

    Public boolError As Boolean
    Public filename As String = ""

    Dim excel As Excel.Application = New Excel.Application
    Dim worksheet As Excel.Worksheet
    Dim xlWorkBook As Excel.Workbook
    Dim sql As New System.Text.StringBuilder

    Private Sub frmAddBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillTypes()
        Me.cmbTypes.SelectedIndex = 0

    End Sub


    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim boolError = False
        Try
            If filename.Length = 0 OrElse (filename.Substring(filename.Length - 4, 4).ToLower <> "xlsx" And filename.Substring(filename.Length - 3, 3).ToLower <> "xls") Then
                ErrorProvider1.SetError(txtFileName, "Select a valid Excel file.")
                boolError = True
            Else
                ErrorProvider1.SetError(txtFileName, "")
            End If
            If Me.cmbClientCode.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbClientCode, "Please select provider from the list.")
                boolError = True
            Else
                ErrorProvider1.SetError(cmbClientCode, "")
            End If
            If Me.cmbTypes.SelectedIndex = -1 Then
                ErrorProvider1.SetError(cmbTypes, "Please select type from the list.")
                boolError = True
            Else
                ErrorProvider1.SetError(cmbTypes, "")
            End If

            If boolError = False Then
              
                '   GetdataFromExcel()
                Me.lClientID = CLng(Me.cmbClientCode.SelectedValue)
                Me.lTypeID = CLng(Me.cmbTypes.SelectedItem.value)
                ImportOffer()

               
            End If



        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub



    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFile.Click
        ErrorProvider1.SetError(txtFileName, "")
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            filename = Me.OpenFileDialog1.FileName
            Me.txtFileName.Text = filename
        End If
    End Sub

    Private Sub ImportOffer()
        Try
            Dim Code, Destination, Price As String
            Dim boolError As Boolean

            excel.Visible = True
            Dim ExcelPath As String = filename
            Dim htNumberAlpahbit As Hashtable = GetHashtable()
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            worksheet = excel.Worksheets(1)

            Dim x As Double
            x = 100 / Me.worksheet.UsedRange.Rows.Count
            Dim row As Integer = 1
            Dim CodeCol, DestinationCol, PriceCol As String
            For row = 1 To Me.worksheet.UsedRange.Rows.Count
                If Not CodeCol Is Nothing AndAlso Not DestinationCol Is Nothing AndAlso Not PriceCol Is Nothing Then
                    Exit For
                End If
                For col = 1 To Me.worksheet.UsedRange.Columns.Count
                    If Not Me.worksheet.Range(htNumberAlpahbit(col).ToString & row).Value() Is Nothing Then
                        If Me.worksheet.Range(htNumberAlpahbit(col).ToString & row).Value().ToString.Trim.ToLower.Contains("code") Then
                            CodeCol = htNumberAlpahbit(col).ToString
                        ElseIf Me.worksheet.Range(htNumberAlpahbit(col).ToString & row).Value().ToString.Trim.ToLower.Contains("country") Then
                            DestinationCol = htNumberAlpahbit(col).ToString
                        ElseIf Me.worksheet.Range(htNumberAlpahbit(col).ToString & row).Value().ToString.Trim.ToLower.Contains("destination") Then
                            DestinationCol = htNumberAlpahbit(col).ToString
                        ElseIf Me.worksheet.Range(htNumberAlpahbit(col).ToString & row).Value().ToString.Trim.ToLower.Contains("price") Then
                            PriceCol = htNumberAlpahbit(col).ToString
                        ElseIf Me.worksheet.Range(htNumberAlpahbit(col).ToString & row).Value().ToString.Trim.ToLower.Contains("rate") Then
                            PriceCol = htNumberAlpahbit(col).ToString
                        End If
                    End If
                    If Not CodeCol Is Nothing AndAlso Not DestinationCol Is Nothing AndAlso Not PriceCol Is Nothing Then
                        Exit For
                    End If
                Next
            Next
            If CodeCol Is Nothing Then
                MsgBox("There is no 'Code' column in the excel file.")
                Return
            End If
            If DestinationCol Is Nothing Then
                MsgBox("There is no 'Destination/Country' column in the excel file.")
                Return
            End If
            If PriceCol Is Nothing Then
                MsgBox("There is no 'Price/Rate' column in the excel file.")
                Return
            End If

            For rCnt = row To Me.worksheet.UsedRange.Rows.Count
                x += x
                If x < 100 Then
                    Me.ProgressBar1.Value = CInt(x)
                End If
                If Not Me.worksheet.Range(CodeCol & rCnt).Value() Is Nothing Then
                    Code = Me.worksheet.Range(CodeCol & rCnt).Value().ToString.Trim
                Else
                    '  Code = "''"
                    Exit For
                End If

                If Not Me.worksheet.Range(DestinationCol & rCnt).Value() Is Nothing Then
                    Destination = Me.worksheet.Range(DestinationCol & rCnt).Value().ToString
                Else
                    Destination = "''"
                End If

                If Not Me.worksheet.Range(PriceCol & rCnt).Value() Is Nothing Then
                    Price = Me.worksheet.Range(PriceCol & rCnt).Value().ToString
                Else
                    Price = "0.0"
                End If

                sql.Append(Code & "," & Destination & "," & Price & ",|")
            Next

            Me.ProgressBar1.Value = 100
            excel.Workbooks.Close()
            excel.Quit()
            '  boolError = odbaccess.importdata(sql.ToString.Substring(0, sql.ToString.Length - 1))


            If Me.rbReplace.Checked Then
                If Not odbaccess.DeleteOffer(Me.lClientID, lTypeID) Then
                    MsgBox("An error occured while deleting old data")
                    Exit Sub
                End If

                boolError = odbaccess.InsertOffer(sql.ToString, Me.lClientID, Me.lTypeID)
            Else
                boolError = odbaccess.UpdateOffer(sql.ToString, Me.lClientID, Me.lTypeID)
            End If

            If boolError Then
                MsgBox("Operation done successfully.")
                filename = ""
                Me.txtFileName.Text = ""
                Me.ProgressBar1.Value = 0
            Else
                MsgBox("An error occured!")
            End If
            Me.btnImport.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Public Sub FillTypes()
        Try
            Me.cmbTypes.DataSource = Nothing

            Dim oColObjects As New ColObjects
            oColObjects.GetCodeTypes()
            For Each Obj As Obj In oColObjects
                Me.cmbTypes.Items.Add(Obj)
            Next

            Me.cmbTypes.ValueMember = "Value"
            Me.cmbTypes.DisplayMember = "Name"

            'Dim DsMembers As New DataSet
            'DsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
                Me.cmbClientCode.DisplayMember = "CompanyCode"
                Me.cmbClientCode.ValueMember = "ID"
            Else
                gDsMembers = odbaccess.GetClientsDS
                If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                    Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
                    Me.cmbClientCode.DisplayMember = "CompanyCode"
                    Me.cmbClientCode.ValueMember = "ID"
                End If
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

End Class