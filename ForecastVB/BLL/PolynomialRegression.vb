Imports MathNet.Numerics.LinearAlgebra
Imports MathNet.Numerics.LinearAlgebra.Complex32

Public Class PolynomialRegression
    Dim x_data, y_data, coef As Vector(Of Double)
    Dim order As Integer

    Public Sub New(x_data As Vector(Of Double), y_data As Vector(Of Double), order As Integer)
        If (x_data.Count <> y_data.Count) Then
            Throw New IndexOutOfRangeException()
        End If

        Me.x_data = x_data
        Me.y_data = y_data
        Me.order = order

        Dim N = x_data.Count
        Dim A(N, order + 1) As CreateMatrix

        For i As Integer = 0 To N
            A.SetValue(VandermondeRow(x_data(i)), i)

            i = +1
        Next



    End Sub


    Public Function VandermondeRow(x As Double) As Vector
        Dim row(order + 1) As Double

        For i As Integer = 0 To order
            row(i) = Math.Pow(x, i)

            i = +1
        Next


        Return Nothing
    End Function
End Class
