Public Class InputIndicatorParameters

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex <> -1 Then ChangeLabelAndTextboxBasedOnSelection(ListBox1.SelectedItem, lblVal1, TextBox1)
    End Sub
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex <> -1 Then lblOperator.Text = ListBox2.SelectedItem
    End Sub
    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        If ListBox3.SelectedIndex <> -1 Then ChangeLabelAndTextboxBasedOnSelection(ListBox3.SelectedItem, lblVal2, TextBox2)
    End Sub
    Sub ChangeLabelAndTextboxBasedOnSelection(ByVal item As String, ByRef lbl As Label, ByRef txt As TextBox)
        Select Case item
            Case "Constant"
                lbl.Text = "Enter Number Below"
                txt.Text = "0"
            Case "Bar Open"
                lbl.Text = ""
                txt.Text = "Bar Open"
            Case "Bar High"
                lbl.Text = ""
                txt.Text = "Bar High"
            Case "Bar Low"
                lbl.Text = ""
                txt.Text = "Bar Low"
            Case "Bar Close"
                lbl.Text = ""
                txt.Text = "Bar Close"
            Case "Stochastic Oscillator"
                lbl.Text = " Period, D percent "
                txt.Text = "(14,3)"
            Case "Bollinger Band"
                lbl.Text = " Bar Open, Bar High, Bar Low, or Bar Close "
                txt.Text = "(Bar Close)"
            Case "Simple Moving Average"
                lbl.Text = " Period "
                txt.Text = "(5)"
            Case "Exponential Moving Average"
                lbl.Text = " Period "
                txt.Text = "(5)"
            Case "Value Chart"
                lbl.Text = " Period "
                txt.Text = "(5)"
        End Select
        txt.Focus()
    End Sub

    Private Sub btnAddToFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToFormula.Click
        If ListBox1.SelectedIndex > 4 Then 'it is an indicator
            txtFormula.Text += ListBox1.SelectedItem & TextBox1.Text
        Else
            txtFormula.Text += TextBox1.Text
        End If
        txtFormula.Text += "| " & lblOperator.Text & "| "
        If ListBox2.SelectedIndex > 3 Then 'it is an indicator
            txtFormula.Text += ListBox2.SelectedItem & TextBox2.Text
        Else
            txtFormula.Text += TextBox2.Text
        End If
        TextBox1.Clear()
        TextBox2.Clear()
        btnAddParamater.Visible = True


    End Sub


    Private Sub btnAddParamater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddParamater.Click
        ListBox4.Items.Add(txtFormula.Text & ";")
        txtFormula.Clear()
    End Sub
End Class