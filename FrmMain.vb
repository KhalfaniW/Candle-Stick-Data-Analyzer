﻿Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Public Class FrmMain
    Public Shared ReadOnly MainFolder As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Data Folder"
    Public Shared ReadOnly CandleDataFolder As String = MainFolder & "\Candle Data"
    Public Shared ReadOnly StrategyDataFolder As String = MainFolder & "\Strategy Data"
    Dim ArchiveFolder As String = MainFolder & "\Test Results"
    Public Property numbars As Integer
    Dim filename As String = ""

    Dim strategyname As String
    Dim AssetName As String

    Private Sub DataAnalyzer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateFolder(My.Computer.FileSystem.SpecialDirectories.Desktop & "\Data Folder")
        CreateFolder(CandleDataFolder)
        CreateFolder(StrategyDataFolder)
        CreateFolder(ArchiveFolder)
        Dim stratname = txtStrategyName.Text
        For Each file In Directory.GetFiles(CandleDataFolder)
            lbFiles.Items.Add(IO.Path.GetFileNameWithoutExtension(file))
        Next
        Using sr As New System.IO.StreamReader(MainFolder & "\Strategies.txt")
            Do Until sr.EndOfStream
                lbStrategies.Items.Add(sr.ReadLine)
            Loop
        End Using
        Control.CheckForIllegalCrossThreadCalls = False 'Note

    End Sub

    Private Sub btnGo_Click() Handles btnGo.Click
        Dim thread0 As New Thread(AddressOf DOeverything)
        thread0.Start()
        btnGo.FlatStyle = FlatStyle.Flat

    End Sub
    Dim archivefilename As String

    Sub DOeverything()
        For Each Currency As String In lbFiles.Items


            Dim fileloc As String = CandleDataFolder & "\" & Currency & ".csv"

            'Dim fileloc As String = CandleDataFolder & "\" & lbFiles.SelectedItem & ".csv"
            If Directory.GetDirectories(ArchiveFolder).Contains(ArchiveFolder & "\" & AssetName & "►" & lblSelectedStrat.Text) Then
                Dim strategies As New List(Of String)
                For Each item In lbStrategies.Items
                    strategies.Add(item)
                Next

                SetLBLText(lblSelectedStrat, CreateUniqueName(lblSelectedStrat.Text, strategies.ToArray))
            End If

            strategyname = lblSelectedStrat.Text
            If fileloc = "" Then MsgBox("Please select a file to run test on") : GoTo EndOfSub
            If lblSelectedStrat.Text = "" Then MsgBox("Please select a strategy to  test") : GoTo EndOfSub

            Dim numrows As Integer


            ChangeWhatsHappeninglabelto("* Aquiring Data *")
            Try
                Dim sr As StreamReader = New StreamReader(fileloc)

                Do While sr.EndOfStream = False
                    numrows += 1
                    sr.ReadLine()
                Loop
            Catch ex As Exception
                If ex.Message.Contains("being used by another process") Then
                    MsgBox("The file you selected is being used in another process")
                Else
                    MsgBox(ex.Message)
                End If
                GoTo EndOfSub
            End Try
            numbars = numrows
            'runs the class to find the lenght of the file to set the array value limit
            ReDim Time(numrows) : ReDim BarHigh(numrows) : ReDim BarLow(numrows) : ReDim BarOpen(numrows) : ReDim BarClose(numrows)
            ReDim BodySize(numrows) : ReDim TopWickSize(numrows) : ReDim BottomWickSize(numrows) : ReDim Gaplength(numrows)
            ReDim calenderdate(numrows)
            ReDim BarMonth(numrows)
            ReDim DateName(numrows)
            ReDim BarSession(numrows) : ReDim BarWeekday(numrows)

            ReDim SessionNum(numrows) : ReDim BarWeekdaynum(numrows) : ReDim WeekDayNum(numrows)
            ReDim hour(numrows)
            ReDim BarVolume(numrows)
            ReDim isCandle(numrows) : ReDim isDead(numrows) : ReDim isBullSpinningTop(numrows) : ReDim isBearSpinningTop(numrows)
            'Counts bars ahead wheter they close above or below the close of the entry candle 
            ReDim Continuation(numrows) : ReDim Reversal(numrows) : ReDim Bullish(numrows) : ReDim Bearish(numrows) : ReDim BodySize0(numrows)
            ReDim PassedSelection(numrows)

            GetVariables(fileloc)





            Dim teststart = 5
            Dim testlimit = 10
            Dim teststart2 = 2
            Dim testlimit2 = 5
            Dim teststart3 = 1
            Dim testlimit3 = 4
            'For testnum3 = testlimit3 To testlimit3 Step 1 'Standard deviation
            '  For testnum2 = teststart2 To testlimit2 Step 1 'Deviation
            Dim testnum2 = 0
            Dim testnum3 = 0
            For testnum = teststart To testlimit Step 1 'vc

                Dim stoch(,) = Indicators.StochasticOscillator(testnum3)
                Dim kpercent(UBound(stoch, 2)) As Double
                Dim dpercent(UBound(stoch, 2)) As Double

                Dim Bands(,) = Indicators.BollingerBand(BarClose, testnum2, testnum3)
                Dim upperbollingerband(UBound(Bands, 2)) As Double
                Dim Lowerbollingerband(UBound(Bands, 2)) As Double

                Dim ValueChart(,) = Indicators.ValueChart
                Dim vcLow(UBound(ValueChart, 2)) As Double
                For i = testnum To numbars

                    Try
                        vcLow(i) = ValueChart(2, i)
                        upperbollingerband(i) = Bands(0, i)
                        Lowerbollingerband(i) = Bands(1, i)
                        kpercent(i) = stoch(0, i)
                        dpercent(i) = stoch(1, i)
                    Catch ex As Exception

                    End Try

                Next

                Dim paramaters As New List(Of TestParameter)
                '    paramaters.Add(New TestParameter(kpercent, TestParameter.ConditionOperator.CrossesAbove, dpercent))
                ' paramaters.Add(New TestParameter(kpercent, TestParameter.ConditionOperator.Greaterthan, {80}, True))
                paramaters.Add(New TestParameter(vcLow, TestParameter.ConditionOperator.CrossesBelow, {-6}, True))
                'paramaters.Add(New TestParameter(BarHigh, TestParameter.ConditionOperator.CrossesAbove, upperbollingerband))
                Dim highestnum = Math.Max(Math.Max(testnum, testnum2), testnum3)
                TestStrat(paramaters.ToArray, highestnum) 'Set PassedSelection Array

                '  strategyname = "Low Crosses Below " & "BollingerBand Period is" & testnum2 & " & Deviation is " & testnum3 'stoch (k « 20, k crosses above D,  K is" & testnum & ",D is 3) " & " & 
                strategyname = "VC less thaan 8 p=" & testnum '"Boll Period is " & testnum & "Dev is " & testnum2 &"Stoch is "& testlimit 3
                archivefilename = ArchiveFolder & "\" & "VC "
                '      If IsAnyYearlyTimeFrameGreaterthan75Precent(highestnum, testnum) Then ''Document it ! ☺
                '  My.Computer.Audio.Play("C:\Program Files (x86)\MetaTrader 4\Sounds\alert2.wav", AudioPlayMode.WaitToComplete)

                ChangeWhatsHappeninglabelto("*Proccessing *")
                Dim month1, month2, month3, month4, month5, month7, month8, month9, month10, month11, month12 As New List(Of Integer)
                Dim months As System.Collections.Generic.List(Of Integer)() = {month1, month2, month3, month4, month5, month7, month8, month9, month10, month11, month12}
                Dim lastmonth = 0
                For k = 1 To numbars
                    If BarMonth(k) > 0 Then months(BarMonth(k) - 1).Add(k)

                    If BarMonth(k) > lastmonth Then lastmonth = BarMonth(k)
                Next

                CalculateFromTo(1, numbars, "2015") 'Calc whole year
                Try ' if any of these list does not have anything in ti it wil skip all the other months after

                    'I enumerate everything to try to make sure it was documented in order: it wasn't
                    CalculateFromTo(months(0).First, months(0).Last, MonthName(1)) 'Jan
                    CalculateFromTo(months(1).First, months(1).Last, MonthName(2)) 'Feb
                    CalculateFromTo(months(2).First, months(2).Last, MonthName(3)) 'Mar
                    CalculateFromTo(months(3).First, months(3).Last, MonthName(4)) 'Apr
                    CalculateFromTo(months(4).First, months(4).Last, MonthName(5)) 'May
                    CalculateFromTo(months(5).First, months(5).Last, MonthName(6)) 'Jun
                    CalculateFromTo(months(6).First, months(6).Last, MonthName(7)) 'Jul
                    CalculateFromTo(months(7).First, months(7).Last, MonthName(8)) 'Aug
                    CalculateFromTo(months(8).First, months(8).Last, MonthName(9)) 'Sep
                    CalculateFromTo(months(9).First, months(9).Last, MonthName(10)) 'Oct
                    CalculateFromTo(months(10).First, months(10).Last, MonthName(11)) 'Nov
                    CalculateFromTo(months(11).First, months(11).Last, MonthName(12)) 'Dec
                Catch

                End Try
                ' End If
            Next
        Next
        '  Next
        '  Next
        End
        My.Computer.Audio.Play("C:\Program Files (x86)\MetaTrader 4\Sounds\connect.wav", AudioPlayMode.WaitToComplete) 'say it's done
        ChangeWhatsHappeninglabelto("*Done*")
        SetProgresbar(ProgressBar1, 100)

EndOfSub:
        Thread.Sleep(0)
    End Sub
    Public Sub GetVariables(ByVal fileLoc As String)
        Dim k As Integer = 0
        Dim gottentofirstbar As Boolean = False
        Dim isReallyDead(numbars) As Boolean
        Dim sr As StreamReader = New StreamReader(fileLoc)
        Dim line As String
        If fileLoc.Contains("JPY") Then
            pips = 100
        Else
            pips = 10000

        End If

        Do While sr.EndOfStream = False
            numrows += 1
            sr.ReadLine()
        Loop

        sr.Close()
        sr = New StreamReader(fileLoc) 'close and reopen stream reader to reset 
        sr.ReadLine() 'skip the first line
        Do While sr.EndOfStream = False'read file

            'Skip the first line
            If k > 0 Then

                line = sr.ReadLine()
                Dim celldata As String() = line.Split(New Char() {","c})
                ' celldata(5) contains the bar's volume

                If celldata(5) = 0 And Not gottentofirstbar Then
                    isReallyDead(k) = True
                Else
                    gottentofirstbar = True
                End If

                If gottentofirstbar Then
                    'Define the times of day when based on the hour
                    BarMonth(k) = CInt(line.Substring(3, 2))
                    hour(k) = CInt(line.Substring(11, 2))
                    Select Case True
                        Case hour(k) > 22 Or hour(k) < 6
                            BarSession(k) = "Sydney Tokyo"
                            SessionNum(k) = 24
                        Case hour(k) = 6
                            BarSession(k) = "Tokyo"
                            SessionNum(k) = 25
                        Case hour(k) = 7
                            BarSession(k) = "London Tokyo"
                            SessionNum(k) = 26
                        Case hour(k) > 7 And hour(k) < 12
                            BarSession(k) = "London "
                            SessionNum(k) = 27
                        Case hour(k) > 11 And hour(k) < 16
                            BarSession(k) = "London New York"
                            SessionNum(k) = 28
                        Case hour(k) > 15 And hour(k) < 21
                            BarSession(k) = "New York"
                            SessionNum(k) = 29
                        Case hour(k) > 20 And hour(k) < 23
                            BarSession(k) = "Sydney"
                            SessionNum(k) = 30
                        Case Else
                            'NOte
                            MsgBox(hour(k))
                            BarSession(k) = "Null"
                            SessionNum(k) = -1 'This will create an error  in the try statement ending execution
                    End Select

                    WeekDayNum(k) = Weekday(line.Substring(3, 2) & "/" & line.Substring(0, 2) & "/" & line.Substring(6, 4))

                    Select Case WeekDayNum(k)
                        Case 2
                            BarWeekday(k) = "Monday"
                            BarWeekdaynum(k) = 0
                        Case 3
                            BarWeekday(k) = "Tuesday"
                            BarWeekdaynum(k) = 1
                        Case 4
                            BarWeekday(k) = "Wednesday"
                            BarWeekdaynum(k) = 2
                        Case 5
                            BarWeekday(k) = "Thursday"
                            BarWeekdaynum(k) = 3
                        Case 6
                            BarWeekday(k) = "Friday"
                            BarWeekdaynum(k) = 4
                        Case Else
                            BarWeekday(k) = "Weekend"
                            BarWeekdaynum(k) = -1
                    End Select
                    'Extradct information
                    BarOpen(k) = celldata(1)
                    BarHigh(k) = celldata(2)
                    BarLow(k) = celldata(3)
                    BarClose(k) = celldata(4)
                    BarVolume(k) = celldata(5)
                    BodySize(k) = (BarClose(k) - BarOpen(k)) * pips

                    Gaplength(k) = Math.Abs(BarClose(k) - BarOpen(k - 1))
                    If BodySize(k) > 0 Then
                        Bullish(k) = True
                    ElseIf BodySize(k) < 0 Then
                        Bearish(k) = True
                    Else
                        BodySize0(k) = True
                    End If
                    BodySize(k) = Format(Math.Abs(BodySize(k)), "00.00")
                    TopWickSize(k) = Format((BarHigh(k) - Math.Max(BarClose(k), BarOpen(k))) * pips, "00.00")
                    BottomWickSize(k) = Format((Math.Min(BarClose(k), BarOpen(k)) - BarLow(k)) * pips, "00.00")
                    If k > 5 Then
                        Dim bars2check(4) As Double
                        For i As Integer = 0 To UBound(bars2check) - 1
                            bars2check(i) = BarVolume(k - i)
                        Next
                        If bars2check.Sum = 0 Then
                            'if nobody trades for 3 bars then 
                            isDead(k) = True

                        End If
                    End If 'Calculations


                    SetProgresbar(ProgressBar1, ((k / (numrows - 1)) * 90))

                    SetLBLText(lblCandlesProcessed, Format(k))

                End If
            End If

            k += 1
        Loop

        '*Re Evealuate Dead market to componsate*

        For i As Integer = 3 To numbars - 1
            If isDead(i) Or BarWeekday(i) = "Weekend" Then
                For j As Int16 = 0 To 3
                    isReallyDead(i - j) = True
                Next
                isReallyDead(i + 1) = True
            End If

            If isReallyDead(i) Then
                DeadCount += 1
                SetLBLText(lblDeadCandles, Format(DeadCount))
            End If

        Next
        isDead = isReallyDead

    End Sub

    Function IsAnyYearlyTimeFrameGreaterthan75Precent(ByVal Start As Integer, ByVal testnum As String) As Boolean
        Dim GrandTotal As Integer = 0

        'Run Preliminary Test
        Dim GrandArray(3, 5, 5, 31) As Integer
        ChangeWhatsHappeninglabelto("Calculating")

        For Expiry_ As Integer = 0 To UBound(expiry) 'For each expiry
            For outcome As Integer = 1 To 3 '3 'At Above and Bellow
                For k As Integer = Start To numbars - expiry(Expiry_) 'test for whole year

                    If PassedSelection(k) Then
                        Dim possiblities() = {False, BarClose(k + expiry(Expiry_)) > BarClose(k),
                                              BarClose(k + expiry(Expiry_)) < BarClose(k), BarClose(k + expiry(Expiry_)) = BarClose(k)}
                        If possiblities(outcome) = True Then

                            'Total Total for posibility
                            GrandArray(outcome, Expiry_, 0, 0) += 1
                            'Hour 
                            GrandArray(outcome, Expiry_, BarWeekdaynum(k) + 1, hour(k) + 1) += 1
                            GrandArray(0, Expiry_, BarWeekdaynum(k) + 1, hour(k) + 1) += 1
                            'Session T
                            GrandArray(outcome, Expiry_, BarWeekdaynum(k) + 1, SessionNum(k) + 1) += 1
                            GrandArray(0, Expiry_, BarWeekdaynum(k) + 1, SessionNum(k) + 1) += 1

                            'total total for expiry
                            GrandArray(0, Expiry_, 0, 0) += 1
                            'WeekdayTotal
                            GrandArray(0, Expiry_, BarWeekdaynum(k) + 1, 0) += 1
                            GrandArray(outcome, Expiry_, BarWeekdaynum(k) + 1, 0) += 1
                            'Session Total 
                            GrandArray(0, Expiry_, 0, SessionNum(k) + 1) += 1
                            GrandArray(outcome, Expiry_, 0, SessionNum(k) + 1) += 1
                            'Hour Total
                            GrandArray(0, Expiry_, 0, hour(k) + 1) += 1
                            GrandArray(outcome, Expiry_, 0, hour(k) + 1) += 1
                            GrandTotal += 1
                        End If
                    End If
                Next
            Next
        Next

        Dim Totals As New List(Of Integer)
        Dim Aboves As New List(Of Integer)
        Dim Belows As New List(Of Integer)
        Dim Ats As New List(Of Integer)
        Dim x = 0
        For Each num In GrandArray
            If num > 0 Then x += 1
        Next
        'session totals
        For a = 0 To UBound(GrandArray, 1)
            For b = 0 To UBound(GrandArray, 2)
                For c = 0 To UBound(GrandArray, 3)
                    Select Case a
                        Case 0
                            Totals.Add(GrandArray(a, b, c, 0))
                        Case 1
                            Aboves.Add(GrandArray(a, b, c, 0))
                        Case 2
                            Belows.Add(GrandArray(a, b, c, 0))
                        Case 3
                            Ats.Add(GrandArray(a, b, c, 0))
                    End Select
                Next
            Next
        Next 'hour totals
        For a = 0 To UBound(GrandArray, 1)
            For b = 0 To UBound(GrandArray, 2)
                For d = 0 To UBound(GrandArray, 4)
                    Select Case a
                        Case 0
                            Totals.Add(GrandArray(a, b, 0, d))
                        Case 1
                            Aboves.Add(GrandArray(a, b, 0, d))
                        Case 2
                            Belows.Add(GrandArray(a, b, 0, d))
                        Case 3
                            Ats.Add(GrandArray(a, b, 0, d))
                    End Select
                Next
            Next
        Next

        Dim HighestPercent As Double = 0
        Dim placeholder = 0
        For i = 0 To UBound(Totals.ToArray)
            If (Aboves(i) / Totals(i)) > HighestPercent And (Aboves(i) / Totals(i)) < 1 Then
                HighestPercent = (Aboves(i) / Totals(i)) : placeholder = i
            End If

            If (Belows(i) / Totals(i)) > HighestPercent And (Belows(i) / Totals(i)) < 1 Then
                HighestPercent = (Belows(i) / Totals(i)) : placeholder = i
            End If


        Next


        Using sw As New StreamWriter(archivefilename, True)
            sw.WriteLine("[" & GrandTotal & "]" & "(" & Totals(placeholder) & "," & Aboves(placeholder) & "," & Belows(placeholder) & "," & Ats(placeholder) & ")=" & HighestPercent & ":" & strategyname)

        End Using
        Dim returnval As Boolean = (HighestPercent > 0.75)
        Return returnval

    End Function
    Sub TestStrat(ByVal parameters As TestParameter(), ByVal firstbar As Integer)
 
        For i As Integer = firstbar To numbars
            Dim allparamterstrue As Boolean = True
            For Each parameter In parameters
                If Not parameter.TrueForBar(i) Then
                    PassedSelection(i) = False
                    allparamterstrue = False
                End If
            Next
            If allparamterstrue Then
                PassedSelection(i) = True
                CandleCount += 1
                SetLBLText(lblPassedSelection, CandleCount)
            End If

        Next
       
    End Sub
    Sub CreateFolder(ByVal folder As String)
        If Not Directory.Exists(folder) Then Directory.CreateDirectory(folder)
    End Sub

    '0=Conditions
    'First is for above below or at,Second is for how many different expiries to checkfor,
    'Third is for Day, last is for hours and sessions: 0-23 is the hours 24-30 is the Session
    'condition for passing selection, possible outcome(above below or at),expiries, days,hours and sessions

    Dim expiry As Integer() = {1, 2, 5}

    Sub ChangeWhatsHappeninglabelto(ByVal action As String)
        SetLBLText(lblWhatsHappenin, action)
        Thread.Sleep(2)
        SetLBLText(lblWhatsHappenin, action)

    End Sub
    Sub CalculateFromTo(ByVal FirstBarNum As Integer, ByVal LastBar As Integer, ByVal Timename As String)
        Dim GrandArray(3, 5, 5, 31) As Integer
        ChangeWhatsHappeninglabelto("Calculating")
        Dim GrandTotal As Integer
        For Expiry_ As Integer = 0 To UBound(expiry) 'For each expiry
            For outcome As Integer = 1 To 3 '3 'At Above and Bellow
                For k As Integer = FirstBarNum To LastBar - expiry(Expiry_)
                    If PassedSelection(k) Then
                        Dim possiblities() = {False, BarClose(k + expiry(Expiry_)) > BarClose(k),
                                              BarClose(k + expiry(Expiry_)) < BarClose(k), BarClose(k + expiry(Expiry_)) = BarClose(k)}
                        If possiblities(outcome) = True Then

                            'Total Total for posibility
                            GrandArray(outcome, Expiry_, 0, 0) += 1
                            'Hour 
                            GrandArray(outcome, Expiry_, BarWeekdaynum(k) + 1, hour(k) + 1) += 1
                            GrandArray(0, Expiry_, BarWeekdaynum(k) + 1, hour(k) + 1) += 1
                            'Session T
                            GrandArray(outcome, Expiry_, BarWeekdaynum(k) + 1, SessionNum(k) + 1) += 1
                            GrandArray(0, Expiry_, BarWeekdaynum(k) + 1, SessionNum(k) + 1) += 1

                            'total total for expiry
                            GrandArray(0, Expiry_, 0, 0) += 1
                            'WeekdayTotal
                            GrandArray(0, Expiry_, BarWeekdaynum(k) + 1, 0) += 1
                            GrandArray(outcome, Expiry_, BarWeekdaynum(k) + 1, 0) += 1
                            'Session Total 
                            GrandArray(0, Expiry_, 0, SessionNum(k) + 1) += 1
                            GrandArray(outcome, Expiry_, 0, SessionNum(k) + 1) += 1
                            'Hour Total
                            GrandArray(0, Expiry_, 0, hour(k) + 1) += 1
                            GrandArray(outcome, Expiry_, 0, hour(k) + 1) += 1
                            GrandTotal += 1
                        End If
                    End If
                Next
            Next
        Next

        Dim subarchivefolder = ArchiveFolder & "\" & AssetName & "►" & strategyname
        CreateFolder(subarchivefolder)

        For e = 0 To UBound(expiry)
            Dim filename = subarchivefolder & "\" & AssetName & "►" & strategyname & "," & Timename & "." & expiry(e) & ".csv"
            ArchiveData(e, filename, GrandArray)
        Next



EndOfSub:
    End Sub
    Sub ArchiveData(ByVal expirynumber As String, ByVal filename As String, ByVal GrandArray As Integer(,,,))

        Dim fs As FileStream = File.Create(filename)
        fs.Dispose()
        Dim sw As StreamWriter = File.AppendText(filename)


        'Write the first and second lines 
        Using sw

            Dim firstline As New List(Of String)
            firstline.Add("Strategy :" & strategyname)
            '               This         ↓      joins an array like so : "element 1" , "element 2" ,etc.. so they can be read in .csv
            sw.WriteLine("""" & String.Join(""",""", firstline) & """")

            Dim secondline As New List(Of String)
            secondline.Add(expiry(expirynumber) & "min")
            Dim timeseries As String() = {"Total", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"}
            For Each time As String In timeseries
                secondline.Add(time & "Total")
                secondline.Add(time & "Above")
                secondline.Add(time & "Below")
                secondline.Add(time & "At")
            Next
            sw.WriteLine("""" & String.Join(""",""", secondline) & """")

            Dim filters As New List(Of String)
            filters.Add("Total")
            For i As Integer = 0 To 23
                filters.Add(i) 'hours
            Next

            Dim sessions() = {"Sydney Tokyo", "Tokyo", "London Tokyo", "London ", "London New York", "New York", "Sydney"}
            filters.AddRange(sessions)

            'Write the MEAT of the data

            Dim posibilites = {0, 1, 2, 3} 'Total,Above,Below,At

            For filternum As Integer = 0 To UBound(filters.ToArray)
                Dim line As New List(Of String)
                line.Add(filters(filternum))

                For weekday_ As Integer = 0 To UBound(timeseries)
                    For Each posiblity In posibilites
                        line.Add(GrandArray(posiblity, expirynumber, weekday_, filternum))
                    Next
                Next
                sw.WriteLine("""" & String.Join(""",""", line) & """")
            Next


        End Using

        sw.Dispose()
    End Sub


    Private Sub btnAddStrat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddStrat.Click
        lblSelectedStrat.Text = txtStrategyName.Text
        Using sw As New StreamWriter(MainFolder & "\Strategies.txt")
            sw.Write(txtStrategyName.Text)
        End Using
        lbStrategies.Items.Add(txtStrategyName.Text)
    End Sub

    Private Sub lbStrategies_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbStrategies.SelectedIndexChanged
        If lbStrategies.SelectedIndex > -1 Then
            lblSelectedStrat.Text = lbStrategies.Items(lbStrategies.SelectedIndex)
            txtStrategyName.Text = lbStrategies.Items(lbStrategies.SelectedIndex)
        End If

    End Sub
    Public Shared Time(), BarHigh(), BarLow(), BarOpen(), BarClose(), BarVolume(),
      BodySize(), TopWickSize(), BottomWickSize(), Gaplength() As Double

    Dim BullOrBear, Column, calenderdate() As String
    Dim BarMonth() As Integer
    Dim DateName() As String
    Dim hour() As Integer
    Dim BarSession() As String
    Dim BarWeekday() As String
    Dim SessionNum, BarWeekdaynum As Integer()
    'predicament: bull swing bear swing etc; type of candle
    Dim CandleCount As Integer
    Dim Count As Integer

    Dim isCandle(), isDead(), isBullSpinningTop(), isBearSpinningTop() As Boolean

    Dim Continuation(), Reversal(), Bullish(), Bearish(), BodySize0() As Boolean
    Dim DeadCount, ContinuationCount As Long
    Dim pips As Integer = 10000

    Dim WeekDayNum() As Integer
    Dim PassedSelection() As Boolean
    Dim numrows As Integer = 0

    Private Sub lbFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbFiles.SelectedIndexChanged
        If lbFiles.SelectedIndex > -1 Then
            filename = lbFiles.SelectedItem
            Dim filenamecomponents = filename.Split("_")
            AssetName = filenamecomponents(0)
            Dim FileToolTip As New ToolTip
            FileToolTip.SetToolTip(lbFiles, lbFiles.SelectedItem)
        End If
    End Sub
    Function CreateUniqueFileName(ByVal filepath As String, ByVal FolderName As String) As String
        Dim CurrentFile = Path.GetFileNameWithoutExtension(filepath)
        If CurrentFile <> Nothing AndAlso CurrentFile <> "" Then

            Dim Folder = Directory.GetFiles(FolderName)
            Dim count As Integer = 0
            Dim FilesList As New List(Of String)
            For Each File As String In Folder
                FilesList.Add(Path.GetFileName(File))
            Next
            Dim FilesListString As String = String.Join(" ", FilesList)

1:          count = count + 1
            If FilesListString.Contains(CurrentFile) Then
                CurrentFile = (CurrentFile.Replace(" (" & count - 1 & ")", ""))
                CurrentFile = (CurrentFile & " (" & count & ")")
                GoTo 1
            End If
        End If

        Return CurrentFile
    End Function
    Function CreateUniqueName(ByVal Name As String, ByVal Arrayofnames As String())

        If Name <> Nothing AndAlso Name <> "" Then

1:          Count = Count + 1
            If Arrayofnames.Contains(Name) Then
                Name = (Name.Replace(" (" & Count - 1 & ")", ""))
                Name = (Name & " (" & Count & ")")
                GoTo 1
            End If
        End If

        Return Name
    End Function
    Delegate Sub TextboxSub(ByRef textbox As System.Windows.Forms.TextBox, ByVal [text] As String)
    Delegate Sub LabelSub(ByRef label As System.Windows.Forms.Label, ByVal [text] As String)

    Private Sub SetTXTText(ByRef textbox As System.Windows.Forms.TextBox, ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the 
        ' calling thread to the thread ID of the creating thread. 
        ' If these threads are different, it returns true. 
        If textbox.InvokeRequired Then
            Dim d As New TextboxSub(AddressOf SetTXTText)
            Me.Invoke(d, New Object() {textbox, [text]})
        Else
            textbox.Text = [text]
        End If
    End Sub

    Private Sub SetLBLText(ByRef Label As System.Windows.Forms.Label, ByVal [text] As String)
        If Label.InvokeRequired Then
            Dim d As New LabelSub(AddressOf SetLBLText)
            Me.Invoke(d, New Object() {Label, text})
        Else
            Label.Text = [text]
        End If
    End Sub
    Delegate Sub Progressbardelegate(ByRef Progressbar As System.Windows.Forms.ProgressBar, ByVal num As Double)
    Sub SetProgresbar(ByRef Progressbar As System.Windows.Forms.ProgressBar, ByVal num As Double)
        If Progressbar.InvokeRequired Then
            Dim invocation As New Progressbardelegate(AddressOf SetProgresbar)
            Me.Invoke(invocation, New Object() {Progressbar, num})
        Else
            ProgressBar1.Value = num
        End If
    End Sub



    Private Sub createparamater(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

    End Sub

End Class
