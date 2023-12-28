<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnewusername = New System.Windows.Forms.TextBox()
        Me.txtnewpass = New System.Windows.Forms.TextBox()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(187, 128)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 312)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 37)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'txtnewusername
        '
        Me.txtnewusername.Location = New System.Drawing.Point(390, 128)
        Me.txtnewusername.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.txtnewusername.Name = "txtnewusername"
        Me.txtnewusername.Size = New System.Drawing.Size(308, 44)
        Me.txtnewusername.TabIndex = 2
        '
        'txtnewpass
        '
        Me.txtnewpass.Location = New System.Drawing.Point(390, 309)
        Me.txtnewpass.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.txtnewpass.Name = "txtnewpass"
        Me.txtnewpass.Size = New System.Drawing.Size(308, 44)
        Me.txtnewpass.TabIndex = 3
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(209, 714)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(238, 65)
        Me.btnsave.TabIndex = 4
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Location = New System.Drawing.Point(589, 714)
        Me.btnexit.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(238, 65)
        Me.btnexit.TabIndex = 5
        Me.btnexit.Text = "E&xit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 877)
        Me.Controls.Add(Me.btnexit)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.txtnewpass)
        Me.Controls.Add(Me.txtnewusername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.Name = "Form2"
        Me.Text = "New User "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtnewusername As TextBox
    Friend WithEvents txtnewpass As TextBox
    Friend WithEvents btnsave As Button
    Friend WithEvents btnexit As Button
End Class
