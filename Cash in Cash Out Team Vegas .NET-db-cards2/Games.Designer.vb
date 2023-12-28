<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Games
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
        Me.btnBlackJack = New System.Windows.Forms.Button()
        Me.btnRoulette = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBlackJack
        '
        Me.btnBlackJack.Location = New System.Drawing.Point(346, 318)
        Me.btnBlackJack.Name = "btnBlackJack"
        Me.btnBlackJack.Size = New System.Drawing.Size(75, 23)
        Me.btnBlackJack.TabIndex = 0
        Me.btnBlackJack.Text = "Blackjack"
        Me.btnBlackJack.UseVisualStyleBackColor = True
        '
        'btnRoulette
        '
        Me.btnRoulette.Location = New System.Drawing.Point(491, 318)
        Me.btnRoulette.Name = "btnRoulette"
        Me.btnRoulette.Size = New System.Drawing.Size(75, 23)
        Me.btnRoulette.TabIndex = 1
        Me.btnRoulette.Text = "Roulette"
        Me.btnRoulette.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(215, 318)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Games
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnRoulette)
        Me.Controls.Add(Me.btnBlackJack)
        Me.Name = "Games"
        Me.Text = "Games"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBlackJack As Button
    Friend WithEvents btnRoulette As Button
    Friend WithEvents btnExit As Button
End Class
