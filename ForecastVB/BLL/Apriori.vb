Public Class Apriori
    Private data As ArrayList
    Public Sub New(d As ArrayList)
        data = d
    End Sub
    ''' <summary>
    ''' Create a list of candidate item sets of size one.
    ''' </summary>
    ''' <returns>list of candidate item sets of size one.</returns>
    Public Function createC1() As ArrayList
        Dim C1 As New ArrayList
        For Each row In data
            For Each cel In row
                If Not C1.Contains(cel) Then
                    C1.Add(cel)
                End If
            Next
        Next
        Return C1
    End Function
    ''' <summary>
    ''' Returns all candidates that meets a minimum support level
    ''' </summary>
    ''' <param name="minSup">Minimum support level</param>
    ''' <returns>all candidates that meets a minimum support level</returns>
    Public Function scanD(minSup As Double) As ArrayList

        '    sscnt = {}
        '    For tid in dataset
        '    For can in candidates
        '        If can.issubset(tid) Then
        '                sscnt.setdefault(can, 0)
        '                sscnt[can] += 1




        'num_items = float(Len(DataSet))
        '                retlist = []
        'support_data = {}
        '                For key in sscnt
        '    support = sscnt[key] / num_items
        '    If support >= min_support Then
        '                        retlist.insert(0, key)
        '                        support_data[key] = support
        'Return retlist, support_data
    End Function
End Class