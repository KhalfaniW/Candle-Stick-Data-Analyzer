<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lbStrategies = New System.Windows.Forms.ListBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblCandlesProcessed = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStrategyName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbFiles = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPassedSelection = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSelectedStrat = New System.Windows.Forms.Label()
        Me.btnAddStrat = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDeadCandles = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblWhatsHappenin = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(408, 177)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(85, 45)
        Me.btnGo.TabIndex = 12
        Me.btnGo.Text = "GO"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(28, 320)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(349, 31)
        Me.ProgressBar1.TabIndex = 28
        '
        'lbStrategies
        '
        Me.lbStrategies.FormattingEnabled = True
        Me.lbStrategies.Location = New System.Drawing.Point(307, 73)
        Me.lbStrategies.Name = "lbStrategies"
        Me.lbStrategies.Size = New System.Drawing.Size(80, 108)
        Me.lbStrategies.TabIndex = 32
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(121, 193)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Strategies"
        '
        'lblCandlesProcessed
        '
        Me.lblCandlesProcessed.AutoSize = True
        Me.lblCandlesProcessed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.lblCandlesProcessed.Location = New System.Drawing.Point(237, 276)
        Me.lblCandlesProcessed.Name = "lblCandlesProcessed"
        Me.lblCandlesProcessed.Size = New System.Drawing.Size(18, 20)
        Me.lblCandlesProcessed.TabIndex = 34
        Me.lblCandlesProcessed.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Label1.Location = New System.Drawing.Point(60, 276)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 20)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Candles processed"
        '
        'txtStrategyName
        '
        Me.txtStrategyName.Location = New System.Drawing.Point(201, 31)
        Me.txtStrategyName.Name = "txtStrategyName"
        Me.txtStrategyName.Size = New System.Drawing.Size(100, 20)
        Me.txtStrategyName.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(182, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 18)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Strategy Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(175, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Available Files"
        '
        'lbFiles
        '
        Me.lbFiles.FormattingEnabled = True
        Me.lbFiles.Location = New System.Drawing.Point(124, 73)
        Me.lbFiles.Name = "lbFiles"
        Me.lbFiles.Size = New System.Drawing.Size(177, 108)
        Me.lbFiles.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Label4.Location = New System.Drawing.Point(60, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 20)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Candles found matching"
        '
        'lblPassedSelection
        '
        Me.lblPassedSelection.AutoSize = True
        Me.lblPassedSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.lblPassedSelection.Location = New System.Drawing.Point(143, 256)
        Me.lblPassedSelection.Name = "lblPassedSelection"
        Me.lblPassedSelection.Size = New System.Drawing.Size(0, 20)
        Me.lblPassedSelection.TabIndex = 53
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label5.Location = New System.Drawing.Point(380, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Selected Strategy"
        '
        'lblSelectedStrat
        '
        Me.lblSelectedStrat.BackColor = System.Drawing.Color.White
        Me.lblSelectedStrat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSelectedStrat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.lblSelectedStrat.Location = New System.Drawing.Point(393, 30)
        Me.lblSelectedStrat.Name = "lblSelectedStrat"
        Me.lblSelectedStrat.Size = New System.Drawing.Size(100, 23)
        Me.lblSelectedStrat.TabIndex = 56
        '
        'btnAddStrat
        '
        Me.btnAddStrat.Location = New System.Drawing.Point(393, 73)
        Me.btnAddStrat.Name = "btnAddStrat"
        Me.btnAddStrat.Size = New System.Drawing.Size(110, 37)
        Me.btnAddStrat.TabIndex = 57
        Me.btnAddStrat.Text = "Add Strat"
        Me.btnAddStrat.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Label7.Location = New System.Drawing.Point(315, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(162, 20)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Candles not counted"
        '
        'lblDeadCandles
        '
        Me.lblDeadCandles.AutoSize = True
        Me.lblDeadCandles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.lblDeadCandles.Location = New System.Drawing.Point(388, 256)
        Me.lblDeadCandles.Name = "lblDeadCandles"
        Me.lblDeadCandles.Size = New System.Drawing.Size(0, 20)
        Me.lblDeadCandles.TabIndex = 58
        '
        'lblWhatsHappenin
        '
        Me.lblWhatsHappenin.AutoSize = True
        Me.lblWhatsHappenin.Location = New System.Drawing.Point(202, 304)
        Me.lblWhatsHappenin.Name = "lblWhatsHappenin"
        Me.lblWhatsHappenin.Size = New System.Drawing.Size(0, 13)
        Me.lblWhatsHappenin.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(405, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 18)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "File Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(304, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Strategy Names"
        '
        'FrmMain
        '
        Me.AcceptButton = Me.btnGo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(533, 371)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblWhatsHappenin)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblDeadCandles)
        Me.Controls.Add(Me.btnAddStrat)
        Me.Controls.Add(Me.lblSelectedStrat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblPassedSelection)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbFiles)
        Me.Controls.Add(Me.txtStrategyName)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCandlesProcessed)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lbStrategies)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnGo)
        Me.Name = "FrmMain"
        Me.ShowIcon = False
        Me.Text = "Data Analyzer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lbStrategies As System.Windows.Forms.ListBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblCandlesProcessed As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtStrategyName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbFiles As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPassedSelection As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSelectedStrat As System.Windows.Forms.Label
    Friend WithEvents btnAddStrat As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblDeadCandles As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblWhatsHappenin As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
