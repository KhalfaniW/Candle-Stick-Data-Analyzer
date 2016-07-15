Imports System.IO
Imports Data_Analyzer.FrmMain
Public Class InputCandle
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtStrategyName.Text = "" Then Throw New Exception("This Strategy Must have a name")
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo EndofSub
        End Try
        Dim MaximumTopWickSize = Val(cbMaxTopWick.Text)
        Dim MinimumTopWickSize = Val(cbMinTopWick.Text)
        Dim MaximumBodySize = Val(cbMaxBody.Text)
        Dim MinimumBodySize = Val(cbMinBody.Text)
        Dim MaximumBottomWickSize = Val(cbMaxBottomWick.Text)
        Dim MinimumBottomWickSize = Val(cbMinBottomWick.Text)

        Dim stratname = txtStrategyName.Text
        Dim path As String = StrategyDataFolder & "\" & "Strategies" & ".txt"
        Dim c As String = " , "
        If Not File.Exists(path) Then
            ' Create a file to write to.  
            Using sw As StreamWriter = File.CreateText(path)
                sw.WriteLine("Name of patern, minbodysize,maxbody,mintopwick,maxtopwick,minbottomwick,maxbottomwick,optional(mingap,maxgap)")
            End Using
        Else

            Using sw As StreamWriter = File.AppendText(path)
                sw.Write(vbCrLf)
               
                sw.WriteLine(stratname & c &
                  MinimumTopWickSize & c & MaximumTopWickSize & c &
                  MinimumBodySize & c & MaximumBodySize & c &
                  MinimumBottomWickSize & c & MaximumBottomWickSize)
            End Using
        End If

        If Not FrmMain.lbStrategies.Items.Contains(stratname) Then
            FrmMain.lbStrategies.Items.Add(stratname)
        End If

        Me.Close()

EndofSub:
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cbMinTopWick.Text = cbMaxTopWick.Text
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cbMinBody.Text = cbMaxBody.Text
    End Sub
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cbMinBottomWick.Text = cbMaxBottomWick.Text
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub InputCandle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ComboBoxes As ComboBox() = {cbMaxTopWick, cbMinTopWick, cbMaxBody, cbMinBody, cbMaxBottomWick, cbMinBottomWick}
        For i = 0 To UBound(ComboBoxes) - 1
            For q = 0 To 10
                ComboBoxes(i).Items.Add(q)
            Next

        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            If cbMaxTopWick.Text <> "" Then cbMinTopWick.Text = cbMaxTopWick.Text
            If cbMinTopWick.Text <> "" Then cbMaxTopWick.Text = cbMinTopWick.Text
        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            If cbMaxBody.Text <> "" Then cbMinBody.Text = cbMaxBody.Text
            If cbMinBody.Text <> "" Then cbMaxBody.Text = cbMinBody.Text
        End If
    End Sub

  
    Private Sub CheckBox3_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            If cbMaxBottomWick.Text <> "" Then cbMinBottomWick.Text = cbMaxBottomWick.Text
            If cbMinBottomWick.Text <> "" Then cbMaxBottomWick.Text = cbMinBottomWick.Text
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Len(txtQuickEntry.Text) < 11 Then Throw New Exception("The text you entered cannot be read")
            Dim datapoint() = txtQuickEntry.Text.Split(",")
            If UBound(datapoint) < 5 Then Throw New Exception("There should be six data points seperated by commas")

            cbMaxTopWick.Text = datapoint(0)
            cbMinTopWick.Text = datapoint(1)
            cbMaxBody.Text = datapoint(2)
            cbMinBody.Text = datapoint(3)
            cbMaxBottomWick.Text = datapoint(4)
            cbMinBottomWick.Text = datapoint(5)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class