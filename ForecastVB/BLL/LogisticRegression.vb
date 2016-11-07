Imports System.IO

Public Class LogisticRegression
    Public Function Learn(inputs As Double()(), outputs As Double(), theta As Double(), alpha As Double) As Double()

        Dim h As Double() = New Double(inputs.Length - 1) {}
        Dim k As Integer = 0
        Dim cost As Double = 0.0
        Dim newtheta As Double() = New Double(theta.Length - 1) {}
        While True
            For Each input As Double() In inputs
                h(k) = Normalise(VectorProduct(input, theta))
                If k + 1 < inputs.Length Then
                    k += 1
                End If
            Next
            Dim newcost As Double = CalculateCost(h, outputs)
            newtheta = CalculateTheta(inputs, h, outputs, theta, alpha)
            System.Diagnostics.Debug.WriteLine("cost: " + newcost.ToString)
            'Console.WriteLine("cost Difference : " + (Math.Abs(newcost) - Math.Abs(cost)));
            If Math.Abs(Math.Abs(newcost) - Math.Abs(cost)) < 0.001 Then
                Exit While
            Else
                cost = newcost
            End If
            theta = newtheta
        End While
        Return h
    End Function
    Private Shared Function CalculateCost(h As Double(), outputs As Double()) As Double
        Dim cost As Double = 0.0
        If h.Length = outputs.Length Then
            For i As Integer = 0 To h.Length - 1
                cost += (-outputs(i) * Math.Log(h(i))) - ((1 - outputs(i)) * Math.Log(1 - h(i)))
            Next
        End If
        Return cost / h.Length
    End Function
    Private Shared Function CalculateTheta(inputs As Double()(), h As Double(), outputs As Double(), theta As Double(), alpha As Double) As Double()
        Dim newtheta As Double() = New Double(theta.Length - 1) {}
        Dim delta As Double() = New Double(theta.Length - 1) {}
        For i As Integer = 0 To theta.Length - 1
            For j As Integer = 0 To inputs.Length - 1
                delta(i) += (h(j) - outputs(j)) * inputs(j)(i)
            Next
            delta(i) *= alpha
        Next
        For k As Integer = 0 To delta.Length - 1
            newtheta(k) = theta(k) - delta(k)
        Next

        Return newtheta
    End Function
#Region "helpers"

    Public Shared Function ReadInputFromFile(filePath As String) As Double()()
        Dim lines As String() = File.ReadAllLines(filePath)
        Dim data As Double()() = New Double(lines.Length - 1)() {}
        For i As Integer = 0 To lines.Length - 1
            Dim entry As String() = lines(i).Split(New Char() {","c})
            data(i) = New Double(entry.Length - 1) {}
            For j As Integer = 0 To entry.Length - 1
                data(i)(j) = Double.Parse(entry(j))
            Next
        Next
        Return data
    End Function

    Public Shared Function ReadDataFromFile(filePath As String) As Double()
        Dim lines As String() = File.ReadAllLines(filePath)
        Dim data As Double() = New Double(lines.Length - 1) {}
        For i As Integer = 0 To lines.Length - 1
            data(i) = Double.Parse(lines(i))
        Next
        Return data
    End Function

    Private Shared Function VectorProduct(mul1 As Double(), mul2 As Double()) As Double
        Dim product As Double = 0.0
        If mul1.Length = mul2.Length Then
            For i As Integer = 0 To mul1.Length - 1

                product += mul1(i) * mul2(i)
            Next
        End If
        Return product
    End Function

    Private Shared Function Normalise(val As Double) As Double
        Return (1 / (1 + Math.Pow(Math.E, (-val))))
    End Function


    Private Shared Sub Display(arr As Double())
        For Each elem As Double In arr
            Console.WriteLine(elem + " ")
        Next
    End Sub

    Public Shared Function PrependWithOnes(arr As Double()()) As Double()()
        Dim newarr As Double()() = New Double(arr.Length - 1)() {}
        For i As Integer = 0 To arr.Length - 1
            newarr(i) = New Double(arr(i).Length) {}
            newarr(i)(0) = 1
            For j As Integer = 0 To arr(i).Length - 1
                newarr(i)(j + 1) = arr(i)(j)
            Next
        Next
        Return newarr
    End Function
#End Region
End Class
