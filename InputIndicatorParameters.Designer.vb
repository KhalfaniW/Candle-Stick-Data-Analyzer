<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputIndicatorParameters
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
        Me.btnAddParamater = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblVal1 = New System.Windows.Forms.Label()
        Me.lblVal2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtFormula = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblOperator = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnAddToFormula = New System.Windows.Forms.Button()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnAddParamater
        '
        Me.btnAddParamater.Location = New System.Drawing.Point(397, 244)
        Me.btnAddParamater.Name = "btnAddParamater"
        Me.btnAddParamater.Size = New System.Drawing.Size(107, 34)
        Me.btnAddParamater.TabIndex = 0
        Me.btnAddParamater.Text = "Add Parameter"
        Me.btnAddParamater.UseVisualStyleBackColor = True
        Me.btnAddParamater.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 18.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(118, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(318, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Indicator Test Creation Zone"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"Bar Open", "Bar High", "Bar Low", "Bar Close", "Stochastic Oscillator", "Bollinger Band", "Simple Moving Average", "Exponential Moving Average", "Value Chart (val 5)"})
        Me.ListBox1.Location = New System.Drawing.Point(35, 90)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 2
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Items.AddRange(New Object() {">", "=", "<", "Crosses Above", "Crosses Bellow"})
        Me.ListBox2.Location = New System.Drawing.Point(201, 90)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(120, 95)
        Me.ListBox2.TabIndex = 3
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Items.AddRange(New Object() {"Constant", "Bar Open", "Bar High", "Bar Low", "Bar Close", "Stochastic Oscillator", "Bollinger Band", "Simple Moving Average", "Exponential Moving Average", "Value Chart (val 5)"})
        Me.ListBox3.Location = New System.Drawing.Point(374, 90)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(120, 95)
        Me.ListBox3.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Label2.Location = New System.Drawing.Point(228, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Operator"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Label3.Location = New System.Drawing.Point(393, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Value 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Label4.Location = New System.Drawing.Point(67, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Value 1"
        '
        'lblVal1
        '
        Me.lblVal1.AutoSize = True
        Me.lblVal1.Location = New System.Drawing.Point(44, 188)
        Me.lblVal1.Name = "lblVal1"
        Me.lblVal1.Size = New System.Drawing.Size(111, 13)
        Me.lblVal1.TabIndex = 8
        Me.lblVal1.Text = "Click A Value 1 to test"
        '
        'lblVal2
        '
        Me.lblVal2.AutoSize = True
        Me.lblVal2.Location = New System.Drawing.Point(371, 188)
        Me.lblVal2.Name = "lblVal2"
        Me.lblVal2.Size = New System.Drawing.Size(111, 13)
        Me.lblVal2.TabIndex = 9
        Me.lblVal2.Text = "Click A Value 2 to test"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(71, 201)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(59, 20)
        Me.TextBox1.TabIndex = 10
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(397, 204)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(61, 20)
        Me.TextBox2.TabIndex = 11
        '
        'txtFormula
        '
        Me.txtFormula.Location = New System.Drawing.Point(86, 252)
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.ReadOnly = True
        Me.txtFormula.Size = New System.Drawing.Size(300, 20)
        Me.txtFormula.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(49, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "IF"
        '
        'ListBox4
        '
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.Location = New System.Drawing.Point(144, 315)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(198, 69)
        Me.ListBox4.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(180, 292)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Startegy"
        '
        'lblOperator
        '
        Me.lblOperator.AutoSize = True
        Me.lblOperator.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.lblOperator.Location = New System.Drawing.Point(249, 198)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(16, 17)
        Me.lblOperator.TabIndex = 16
        Me.lblOperator.Text = "="
        Me.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Button2.Location = New System.Drawing.Point(201, 395)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 30)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnAddToFormula
        '
        Me.btnAddToFormula.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddToFormula.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!)
        Me.btnAddToFormula.Location = New System.Drawing.Point(214, 218)
        Me.btnAddToFormula.Name = "btnAddToFormula"
        Me.btnAddToFormula.Size = New System.Drawing.Size(89, 28)
        Me.btnAddToFormula.TabIndex = 18
        Me.btnAddToFormula.Text = "Add To Formula"
        Me.btnAddToFormula.UseVisualStyleBackColor = True
        '
        'txtname
        '
        Me.txtname.Location = New System.Drawing.Point(232, 289)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(100, 20)
        Me.txtname.TabIndex = 20
        '
        'InputIndicatorParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 453)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.btnAddToFormula)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblOperator)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ListBox4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFormula)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblVal2)
        Me.Controls.Add(Me.lblVal1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAddParamater)
        Me.Name = "InputIndicatorParameters"
        Me.Text = "InputIndicatorParameters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddParamater As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblVal1 As System.Windows.Forms.Label
    Friend WithEvents lblVal2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFormula As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ListBox4 As System.Windows.Forms.ListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblOperator As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnAddToFormula As System.Windows.Forms.Button
    Friend WithEvents txtname As System.Windows.Forms.TextBox
End Class
