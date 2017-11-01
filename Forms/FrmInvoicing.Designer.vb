<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInvoicing
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInvoicing))
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnGenerateInvoice = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnInvoices = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnImport
        '
        Me.btnImport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImport.Enabled = False
        Me.btnImport.FlatAppearance.BorderSize = 2
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImport.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.Location = New System.Drawing.Point(31, 41)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(215, 50)
        Me.btnImport.TabIndex = 5
        Me.btnImport.Text = "Import Files"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnApprove
        '
        Me.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApprove.Enabled = False
        Me.btnApprove.FlatAppearance.BorderSize = 2
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnApprove.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApprove.Location = New System.Drawing.Point(31, 153)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(215, 50)
        Me.btnApprove.TabIndex = 5
        Me.btnApprove.Text = "Approve Invoices"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'btnGenerateInvoice
        '
        Me.btnGenerateInvoice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerateInvoice.Enabled = False
        Me.btnGenerateInvoice.FlatAppearance.BorderSize = 2
        Me.btnGenerateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGenerateInvoice.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateInvoice.Location = New System.Drawing.Point(31, 97)
        Me.btnGenerateInvoice.Name = "btnGenerateInvoice"
        Me.btnGenerateInvoice.Size = New System.Drawing.Size(215, 50)
        Me.btnGenerateInvoice.TabIndex = 5
        Me.btnGenerateInvoice.Text = "Check Imported Data"
        Me.btnGenerateInvoice.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Sending Invoices Proccess:"
        '
        'btnInvoices
        '
        Me.btnInvoices.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInvoices.Enabled = False
        Me.btnInvoices.FlatAppearance.BorderSize = 2
        Me.btnInvoices.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnInvoices.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvoices.Location = New System.Drawing.Point(31, 209)
        Me.btnInvoices.Name = "btnInvoices"
        Me.btnInvoices.Size = New System.Drawing.Size(215, 50)
        Me.btnInvoices.TabIndex = 8
        Me.btnInvoices.Text = "View Invoices + Send Emails"
        Me.btnInvoices.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "1-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "2-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "3-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 226)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "4-"
        '
        'FrmInvoicing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(272, 278)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnInvoices)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnGenerateInvoice)
        Me.Controls.Add(Me.btnImport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmInvoicing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Invoicing System"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents btnGenerateInvoice As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnInvoices As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
