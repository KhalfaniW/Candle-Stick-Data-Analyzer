Imports Data_Analyzer.FrmMain
Public Class Indicators

    Shared Function MovingAverage(ByVal Array As Double(), ByVal Period As Double) As Double()
        Dim ReturnArray(UBound(Array)) As Double
        If Period > 0 Then
            For j = Period - 1 To UBound(Array)

                Dim Sum As Double = 0

                For k = 0 To Period - 1
                    Sum += Array(j - k)
                Next

                Sum = Sum / Period
                ReturnArray(j) = Sum

            Next
            Return ReturnArray
        Else
            Return {0.0}
        End If


    End Function
    Shared Function ExponentialMovingAverage(ByVal Array As Double(), ByVal Period As Double) As Double()
        Dim alpha = 2 / (Period + 1)
        Dim firsttermnum As Integer = (Period - 1) / 2
        Dim MAx = MovingAverage(Array, firsttermnum)

        Dim ReturnArray(UBound(Array)) As Double

        ReturnArray(firsttermnum - 1) = MAx(firsttermnum - 1) 'the first moving average value

        For i = firsttermnum To UBound(Array)

            ReturnArray(i) = Math.Round((alpha * Array(i - firsttermnum + 1)) + ((1 - alpha) * ReturnArray(i - 1)), 5)

        Next
        Return ReturnArray
    End Function

    Shared Function ValueChart(Optional ByVal Numbars As Integer = 5) As Double(,)
        Dim Vopen(UBound(BarOpen)), VBarhigh(UBound(BarOpen)), Vlow(UBound(BarOpen)), Vclose(UBound(BarOpen)) As Double
        Dim ReturnArray(3, UBound(BarOpen)) As Double
        For i = 1 To UBound(BarOpen)

            Vopen(i) = (BarOpen(i) - MVA(Numbars, i)) / ATR(Numbars, i)
            VBarhigh(i) = (BarHigh(i) - MVA(Numbars, i)) / ATR(Numbars, i)
            Vlow(i) = (BarLow(i) - MVA(Numbars, i)) / ATR(Numbars, i)
            Vclose(i) = (BarClose(i) - MVA(Numbars, i)) / ATR(Numbars, i)
            ReturnArray(0, i) = Vopen(i)
            ReturnArray(1, i) = VBarhigh(i)
            ReturnArray(2, i) = Vlow(i)
            ReturnArray(3, i) = Vclose(i)

        Next
        Return ReturnArray
    End Function
    ' Market Value Added function
    Shared Function MVA(ByVal NumBars1 As Integer, ByVal CBar As Integer) As Double

        Dim sum, floatingAxis As Double
        Dim k = CBar
        Do While k < (NumBars1 + CBar) And k < UBound(BarOpen)

            sum += ((BarHigh(k) + BarLow(k)) / 2.0)
            k += 1
        Loop
        floatingAxis = (sum / NumBars1)
        Return floatingAxis
    End Function
    'Average True Range Function
    Shared Function ATR(ByVal NumBars1 As Integer, ByVal CBar As Integer) As Double

        Dim sum, volitilityUnit As Double
        Dim k = CBar
        Do While k < (NumBars1 + CBar) And k < UBound(BarOpen)

            sum += (BarHigh(k) - BarLow(k))
            k += 1
        Loop
        volitilityUnit = (0.2 * (sum / NumBars1))
        If volitilityUnit = 0 Then volitilityUnit = 0.00000001

        Return volitilityUnit
    End Function
    Shared Function StochasticOscillator(Optional ByVal Period As Integer = 14, Optional ByVal D_percent As Integer = 3) As Double(,)
        '%K=(C–L)(H–L) ×100 
        If Period > 1 Then


            Dim MA() = MovingAverage(BarOpen, Period)
            Dim K_percentval(UBound(BarOpen)) As Double
            Dim D_percentval(UBound(BarOpen)) As Double
            Dim ReturnArray(1, (UBound(BarOpen))) As Double

            For k = Period - 1 To UBound(BarOpen)

                Dim Barhighs_to_check(Period - 1) As Double
                Dim lows_to_check(Period - 1) As Double
                Dim closes_to_check(Period - 1) As Double



                For j As Double = 0 To Period - 1
                    Barhighs_to_check(j) = BarHigh(k - j)
                    lows_to_check(j) = BarLow(k - j)
                    closes_to_check(j) = BarClose(k - j)
                Next
                Dim highs_minus_lows = (Barhighs_to_check.Max - lows_to_check.Max)
                If highs_minus_lows > 0 Then
                    K_percentval(k) = (closes_to_check.Max - lows_to_check.Max) / (Barhighs_to_check.Max - lows_to_check.Max) * 100
                Else
                    K_percentval(k) = 0
                End If
                ReturnArray(0, k) = K_percentval(k)


            Next
            D_percentval = MovingAverage(K_percentval, D_percent)
            For K = Period - 1 To UBound(BarOpen)
                ReturnArray(1, K) = D_percentval(K)
            Next

            Return ReturnArray
        Else
            Return {{0.0}, {0.0}}
        End If
    End Function
    Shared Function BollingerBand(ByVal Array As Double(), Optional ByVal Period As Integer = 20, Optional ByVal StandardDeviation_ As Double = 2) As Double(,)
        Try


            Dim MA() = MovingAverage(Array, Period)
            Dim UpperBollingerBand(UBound(Array)) As Double
            Dim LowerBollingerBand(UBound(Array)) As Double
            Dim ReturnArray(1, (UBound(Array))) As Double


            For k = Period - 1 To UBound(Array)

                Dim Previousbars(Period - 1) As Double

                For x As Double = 0 To Period - 1

                    Previousbars(x) = Array(k - x)
                Next

                UpperBollingerBand(k) = MA(k) + (StandardDeviation(Previousbars) * StandardDeviation_)
                LowerBollingerBand(k) = MA(k) - (StandardDeviation(Previousbars) * StandardDeviation_)

                ReturnArray(0, k) = UpperBollingerBand(k)
                ReturnArray(1, k) = LowerBollingerBand(k)
            Next

            Return ReturnArray
        Catch ex As Exception
            Return {{0.0}, {0.0}}
        End Try
    End Function
    Shared Function StandardDeviation(ByVal NumericArray As Object) As Double

        Dim dblSum As Double, dblSumSqdDevs As Double, dblMean As Double
        Dim lngCount As Long, dblAnswer As Double
        Dim vElement As Object
        Dim lngStartPoint As Long, lngEndPoint As Long, lngCtr As Long

        On Error GoTo errorhandler
        'if NumericArray is not an array, this statement will
        'raise an error in the errorhandler

        lngCount = UBound(NumericArray)

        On Error Resume Next
        lngCount = 0

        'the check below will allow
        'for 0 or 1 based arrays.

        vElement = NumericArray(0)

        lngStartPoint = IIf(Err.Number = 0, 0, 1)
        lngEndPoint = UBound(NumericArray)

        'get sum and sample size
        For lngCtr = lngStartPoint To lngEndPoint
            vElement = NumericArray(lngCtr)
            If IsNumeric(vElement) Then
                lngCount += 1
                dblSum = dblSum + CDbl(vElement)
            End If
        Next

        'get mean
        If lngCount > 1 Then
            dblMean = dblSum / lngCount

            'get sum of squared deviations
            For lngCtr = lngStartPoint To lngEndPoint
                vElement = NumericArray(lngCtr)

                If IsNumeric(vElement) Then
                    dblSumSqdDevs = dblSumSqdDevs + _
                    ((vElement - dblMean) ^ 2)
                End If
            Next

            'divide result by sample size - 1 and get square root. 
            'this function calculates standard deviation of a sample.  
            'If your  set of values represents the population, use sample
            'size not sample size - 1

            If lngCount > 1 Then
                lngCount = lngCount - 1 'eliminate for population values
                dblAnswer = Math.Sqrt(dblSumSqdDevs / lngCount) ' could be square
            End If

        End If

        StandardDeviation = dblAnswer

        Exit Function

errorhandler:
        Err.Raise(Err.Number)
        Exit Function
    End Function
End Class

Public Class TestParameter
    Enum ConditionOperator
        Greaterthan = 1
        Equalto = 0
        Lessthan = -1
        CrossesAbove = 2
        CrossesBelow = -2
    End Enum
    Property MyCondition As ConditionOperator
    Property Array1 As Double()
    Property Array2 As Double()
    Property Array2isAConstant As Boolean


    Function TrueForBar(ByVal arraynum As Integer)

        If Array2isAConstant Then
            Select Case MyCondition
                Case ConditionOperator.Greaterthan
                    Return Array1(arraynum) > Array2(0)
                Case ConditionOperator.Equalto
                    Return Array1(arraynum) = Array2(0)
                Case ConditionOperator.Lessthan
                    Return Array1(arraynum) < Array2(0)
                Case ConditionOperator.CrossesAbove
                    Return (Array1(arraynum - 1) < Array2(0) And Array1(arraynum) < Array2(0))
                Case ConditionOperator.CrossesBelow
                    Return (Array1(arraynum - 1) > Array2(0) And Array1(arraynum) > Array2(0))
                Case Else
                    Throw New Exception("No condition operator selected")
            End Select
        Else
            Select Case MyCondition
                Case ConditionOperator.Greaterthan
                    Return Array1(arraynum) > Array2(arraynum)
                Case ConditionOperator.Equalto
                    Return Array1(arraynum) = Array2(arraynum)
                Case ConditionOperator.Lessthan
                    Return Array1(arraynum) < Array2(arraynum)
                Case ConditionOperator.CrossesAbove
                    Return (Array1(arraynum - 1) < Array2(arraynum - 1) And Array1(arraynum) > Array2(arraynum))
                Case ConditionOperator.CrossesBelow
                    Return (Array1(arraynum - 1) > Array2(arraynum - 1) And Array1(arraynum) < Array2(arraynum))
                Case Else
                    Throw New Exception("No condition operator selected")
            End Select
        End If
    End Function
  
    Sub New(ByVal [array1] As Double(), ByVal condition As ConditionOperator, ByVal ArrayOrConstant2 As Double(), Optional ByVal [array2isaconstant] As Boolean = False)
        Me.Array1 = [array1]
        Me.MyCondition = condition

        If [array2isaconstant] Then
            Me.Array2() = {0}
            Me.Array2(0) = ArrayOrConstant2(0)
            Me.Array2isAConstant = True
        Else
            Me.Array2 = ArrayOrConstant2
        End If

    End Sub
   
End Class
