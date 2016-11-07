Public Class Apriori
    Private data As Array
    Public Sub New(d As Array)
        data = d

    End Sub
    ''' <summary>
    ''' Create a list of candidate item sets of size one.
    ''' </summary>
    ''' <returns>list of candidate item sets of size one.</returns>
    Public Function createCand() As ArrayList

        Dim cand As New ArrayList
        For k As Integer = 0 To data.GetUpperBound(0)
            For r As Integer = 0 To data.GetUpperBound(1)
                If data(k, r) <> 0 And Not cand.Contains(data(k, r)) Then
                    cand.Add(data(k, r))
                End If
            Next
        Next
        Return cand
    End Function
    ''' <summary>
    ''' Returns all candidates that meets a minimum support level
    ''' </summary>
    ''' <param name="minSup">Minimum support level</param>
    ''' <returns>all candidates that meets a minimum support level</returns>
    Public Function scanD(minSup As Double) As ArrayList
        Dim candMatching As New ArrayList
        Dim candNotMatchingYET As New Dictionary(Of String, Double)
        For Each key In createCand()
            Dim counter = 0
            For Each va In data
                If key.Equals(va) Then
                    counter += 1
                End If
            Next
            candNotMatchingYET.Add(key, counter)
        Next
        Dim n = data.GetUpperBound(0) + 1
        For Each candidate In createCand()

            If candNotMatchingYET.Item(candidate) / n >= minSup Then
                candMatching.Add(candidate)
            End If
        Next
        Return candMatching
    End Function
    ''' <summary>
    ''' Generate the joint transactions from candidate sets
    ''' </summary>
    ''' <returns></returns>
    Public Function joinTwo() As ArrayList
        Dim candMatching = scanD(0.5)
        Dim gen As New ArrayList
        candMatching.Sort()
        For i As Integer = 0 To candMatching.Count - 1
            For j As Integer = i + 1 To candMatching.Count - 1
                'If candMatching(i) <> candMatching(j) Then
                gen.Add(New ArrayList({candMatching(i), candMatching(j)}))
                'End If
            Next
        Next
        Return gen
    End Function
    Public Function joinX(x As Integer) As ArrayList
        Dim toRet As New ArrayList
        My.Application.Log.WriteEntry("K = " + x.ToString)



        Return toRet
    End Function
End Class