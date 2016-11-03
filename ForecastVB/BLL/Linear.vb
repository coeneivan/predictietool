''' <summary>
''' Lineare voorspelling van realisatie graad voor cursussen
''' </summary>
Public Class Linear
    Private totaalDoorgegeaan As Integer
    Private totaalNietDoorgegaan As Integer
    'Private totaalDoorgegeaanEchte As Integer
    Private echteWaardes As List(Of Cursus)
    Public Function groupIt(theList As List(Of Cursus)) As Dictionary(Of String, Dictionary(Of String, Parameter))
        totaalDoorgegeaan = 0
        totaalNietDoorgegaan = 0
        echteWaardes = New List(Of Cursus)
        Dim grouped As New Dictionary(Of String, List(Of Cursus))
        Dim toRet As New Dictionary(Of String, Dictionary(Of String, Parameter))
        For Each cursus In theList
            If Year(cursus.datum) < 2016 Then
                Dim arr As New List(Of Cursus)
                Dim theKey As String = cursus.merkVanCursus + "|" + cursus.uitvoerendCentrum + "|" + cursus.codeSubafdeling + "|" + Month(cursus.datum).ToString + "|" + cursus.lesdag
                If Not grouped.ContainsKey(theKey) Then
                    arr.Add(cursus)
                    grouped.Add(theKey, arr)
                Else
                    arr = grouped(theKey)
                    arr.Add(cursus)
                    grouped(theKey) = arr
                End If
                If Not cursus.codeIngetrokken Then
                    totaalDoorgegeaan += 1
                Else
                    totaalNietDoorgegaan += 1
                End If
            End If
        Next
        For Each groep In grouped
            toRet.Add(groep.Key, groupByYear(groep.Value))
        Next
        Return toRet
    End Function
    Public Function groupbyMerk(theList As List(Of Cursus)) As Dictionary(Of String, List(Of Cursus))
        Dim grouped As New Dictionary(Of String, List(Of Cursus))
        For Each cursus In theList
            Dim arr As New List(Of Cursus)
            Dim theKey As String = cursus.merkVanCursus
            If Not grouped.ContainsKey(theKey) Then
                arr.Add(cursus)
                grouped.Add(theKey, arr)
            Else
                arr = grouped(theKey)
                arr.Add(cursus)
                grouped(theKey) = arr
            End If
        Next
        Return grouped
    End Function
    Public Function groupbySubAfdeling(theList As List(Of Cursus)) As Dictionary(Of String, List(Of Cursus))
        Dim grouped As New Dictionary(Of String, List(Of Cursus))
        For Each cursus In theList
            Dim arr As New List(Of Cursus)
            Dim theKey As String = cursus.codeSubafdeling
            If Not grouped.ContainsKey(theKey) Then
                arr.Add(cursus)
                grouped.Add(theKey, arr)
            Else
                arr = grouped(theKey)
                arr.Add(cursus)
                grouped(theKey) = arr
            End If
        Next
        Return grouped
    End Function
    Public Function groupbyCentrum(theList As List(Of Cursus)) As Dictionary(Of String, List(Of Cursus))
        Dim grouped As New Dictionary(Of String, List(Of Cursus))
        For Each cursus In theList
            Dim arr As New List(Of Cursus)
            Dim theKey As String = cursus.uitvoerendCentrum
            If Not grouped.ContainsKey(theKey) Then
                arr.Add(cursus)
                grouped.Add(theKey, arr)
            Else
                arr = grouped(theKey)
                arr.Add(cursus)
                grouped(theKey) = arr
            End If
        Next
        Return grouped
    End Function
    Public Function groupbyMaand(theList As List(Of Cursus)) As Dictionary(Of String, List(Of Cursus))
        Dim grouped As New Dictionary(Of String, List(Of Cursus))
        For Each cursus In theList
            Dim arr As New List(Of Cursus)
            Dim theKey As String = Month(cursus.datum).ToString
            If Not grouped.ContainsKey(theKey) Then
                arr.Add(cursus)
                grouped.Add(theKey, arr)
            Else
                arr = grouped(theKey)
                arr.Add(cursus)
                grouped(theKey) = arr
            End If
        Next
        Return grouped
    End Function
    Public Function groupbyDag(theList As List(Of Cursus)) As Dictionary(Of String, List(Of Cursus))
        Dim grouped As New Dictionary(Of String, List(Of Cursus))
        For Each cursus In theList
            Dim arr As New List(Of Cursus)
            Dim theKey As String = cursus.lesdag
            If Not grouped.ContainsKey(theKey) Then
                arr.Add(cursus)
                grouped.Add(theKey, arr)
            Else
                arr = grouped(theKey)
                arr.Add(cursus)
                grouped(theKey) = arr
            End If
        Next
        Return grouped
    End Function
    Public Function groupByYear(theList As List(Of Cursus)) As Dictionary(Of String, Parameter)
        Dim grouped As New Dictionary(Of String, List(Of Cursus))

        Dim toRet As New Dictionary(Of String, Parameter)
        For Each cursus In theList
            Dim arr As New List(Of Cursus)
            If Year(cursus.datum).ToString = "2015" Then
                echteWaardes.add(cursus)
            Else

                If Not grouped.ContainsKey(Year(cursus.datum).ToString) Then
                    arr.Add(cursus)
                    grouped.Add(Year(cursus.datum).ToString, arr)
                Else
                    arr = grouped(Year(cursus.datum).ToString)
                    arr.Add(cursus)
                    grouped(Year(cursus.datum).ToString) = arr
                End If
            End If

        Next
        For Each groep In grouped
            Dim doorgegaan = 0
            Dim nietDoorgegaan = 0
            For Each cursus In groep.Value
                If Not cursus.codeIngetrokken Then
                    doorgegaan += 1
                Else
                    nietDoorgegaan += 1
                End If
            Next
            toRet.Add(groep.Key, New Parameter(totaalNietDoorgegaan, totaalDoorgegeaan, nietDoorgegaan, doorgegaan))
        Next
        Return toRet
    End Function
    Public Function berekenVoor(jaar As String, dic As Dictionary(Of String, Parameter), ja As Boolean) As Double
        Dim n = dic.Count
        'System.Diagnostics.Debug.WriteLine("-_-_-_-_-")
        'Calculate averages and others
        Dim avgY, avgX, avgXY, avgXX As Double
        For Each kvp As KeyValuePair(Of String, Parameter) In dic
            'System.Diagnostics.Debug.WriteLine(kvp.Key + " " + kvp.Value.berekenPercentage.ToString)
            Dim x = CDbl(kvp.Key)
            Dim y
            If ja Then
                y = Math.Log(kvp.Value.percentageDoorgegaan)
            Else
                y = Math.Log(kvp.Value.percentageGeschrapt)
            End If
            If Not Double.IsNegativeInfinity(y) Then

                avgY += y
                avgX += x
                avgXY += x * y
                avgXX += x * x
            Else
                n -= 1
            End If

        Next
        avgY = avgY / n
        avgX = avgX / n
        avgXY = avgXY / n
        avgXX = avgXX / n

        'Linear regression coefficients
        Dim beta As Double = (avgXY - avgX * avgY) / (avgXX - avgX * avgX)
        Dim alpha = avgY - beta * avgX
        If Not Double.IsNaN(Math.Exp(alpha + beta * CDbl(jaar))) Then
            Return Math.Exp(alpha + beta * CDbl(jaar))
        Else
            Return -1
        End If
    End Function
    Public Function berekenVoor(jaar As String, dic As SortedDictionary(Of Double, Parameter)) As Double
        Dim n = dic.Count
        'System.Diagnostics.Debug.WriteLine("-_-_-_-_-")
        'Calculate averages and others
        Dim avgY, avgX, avgXY, avgXX As Double
        For Each kvp As KeyValuePair(Of Double, Parameter) In dic
            'System.Diagnostics.Debug.WriteLine(kvp.Key + " " + kvp.Value.berekenPercentage.ToString)
            Dim x = CDbl(kvp.Key)
            Dim y = Math.Log(kvp.Value.berekenPercentage)

            If Not Double.IsNegativeInfinity(y) Then

                avgY += y
                avgX += x
                avgXY += x * y
                avgXX += x * x
            Else
                n -= 1
            End If

        Next
        avgY = avgY / n
        avgX = avgX / n
        avgXY = avgXY / n
        avgXX = avgXX / n

        'Linear regression coefficients
        Dim beta As Double = (avgXY - avgX * avgY) / (avgXX - avgX * avgX)
        Dim alpha = avgY - beta * avgX
        If Not Double.IsNaN(Math.Exp(alpha + beta * CDbl(jaar))) Then
            Return Math.Exp(alpha + beta * CDbl(jaar))
        Else
            Return -1
        End If
    End Function
    Public Function getEchteWaardes() As Dictionary(Of String, List(Of Cursus))
        Dim grouped As New Dictionary(Of String, List(Of Cursus))
        For Each cursus In echteWaardes
            Dim arr As New List(Of Cursus)
            Dim theKey As String = cursus.merkVanCursus + "|" + cursus.uitvoerendCentrum + "|" + cursus.codeSubafdeling + "|" + Month(cursus.datum).ToString + "|" + cursus.lesdag
            If Not grouped.ContainsKey(theKey) Then
                arr.Add(cursus)
                grouped.Add(theKey, arr)
            Else
                arr = grouped(theKey)
                arr.Add(cursus)
                grouped(theKey) = arr
            End If
        Next
        Return grouped
    End Function
    Public Function getDoorgegaan() As Double
        Return totaalDoorgegeaan
    End Function
    Public Function certainty(d As Dictionary(Of String, Parameter)) As Bereik

        Dim values As New ArrayList
        Dim sum = 0
        For Each v In d
            Dim toAdd = v.Value.berekenPercentage
            values.Add(toAdd)
            sum += toAdd
        Next

        Dim sumOfSquaresOfDifferences As Double
        Dim n = values.Count
        Dim average = sum / n

        For Each value In values
            If Not Double.IsNaN(value) Then
                sumOfSquaresOfDifferences += (value - average) ^ 2
            Else
                n -= 1
            End If
        Next
        Dim sd As Double = Math.Sqrt(sumOfSquaresOfDifferences / n)
        Dim t As New tVerdeling
        Dim difference As Double = t.getTwaarde(0.995, If(n > 0, n, 1)) * (sd / Math.Sqrt(n))
        Return New Bereik((average - difference) * 100, (average) * 100, (average + difference) * 100)
    End Function
End Class
