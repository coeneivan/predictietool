Public Class FilterVerzameling
    Private filters As ArrayList
    Public Sub New()
        filters = New ArrayList
    End Sub
    Public Sub New(f As ArrayList)
        filters = f
    End Sub
    Public Sub addFilterItem(f As FilterItem)
        filters.Add(f)
    End Sub
    Public Sub addFilterItems(f As ArrayList)
        filters.AddRange(f)
    End Sub
    Public Overrides Function toString() As String
        If filters Is Nothing Then
            Return ""
        Else
            Dim fil As String
            Dim first = True
            fil = ""

            For Each filIt As FilterItem In filters
                If first Then
                    fil += filIt.kolom + " " + filIt.factor + " " + filIt.filter
                    first = False
                Else
                    fil += " AND " + filIt.kolom + " " + filIt.factor + " " + filIt.filter
                End If
            Next
            Return fil
        End If
    End Function
End Class
