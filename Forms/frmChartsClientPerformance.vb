Public Class frmChartsClientPerformance

    ' Public ds As DataSet

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Me.ds = ds 'odbaccess.GetChartsClientPerformance(lCount, enumStatus, intInOut, intAccountManager)
    End Sub


    Private Sub testChart_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '  GetData()
    End Sub

    Public Sub GetClientPerformanceData(ds As DataSet)
        Try
            For i = 0 To ds.Tables.Count - 1
                If Not ds.Tables(i).Rows.Count = 0 Then
                    Dim pnlChart = New UserControl1
                    pnlChart.Chart1.Visible = False
                    pnlChart.lblClientCode.Text = ds.Tables(i).Rows(0).Item("code").ToString
                    pnlChart.lblAccountManager.Text = ds.Tables(i).Rows(0).Item("AccountManager").ToString
                    pnlChart.Chart2.DataSource = ds.Tables(i)
                    pnlChart.Chart2.Series("Amount").XValueMember = "Date"
                    pnlChart.Chart2.Series("Amount").YValueMembers = "Amount"
                    Me.FlowLayoutPanel1.Controls.Add(pnlChart)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub GetAimPerformanceData(ds As DataSet)
        Try
            For i = 0 To ds.Tables.Count - 1
                If Not ds.Tables(i).Rows.Count = 0 Then
                    Dim pnlChart = New UserControl1
                    pnlChart.Chart2.Visible = False
                    pnlChart.lblClientCode.Text = ds.Tables(i).Rows(0).Item("code").ToString
                    pnlChart.lblAccountManager.Text = ds.Tables(i).Rows(0).Item("AccountManager").ToString
                    pnlChart.Chart1.DataSource = ds.Tables(i)
                    pnlChart.Chart1.Series("Margin").XValueMember = "Insert_Date"
                    pnlChart.Chart1.Series("Margin").YValueMembers = "Margin"

                    pnlChart.Chart1.Series("Profit").XValueMember = "Insert_Date"
                    pnlChart.Chart1.Series("Profit").YValueMembers = "Profit"
                    '  pnlChart.Chart1.Series("Series1"). = "Margin"
                    Me.FlowLayoutPanel1.Controls.Add(pnlChart)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class