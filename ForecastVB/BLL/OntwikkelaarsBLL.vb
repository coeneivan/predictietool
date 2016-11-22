Public Class OntwikkelaarsBLL
    Dim dao As New OntwikkelaarsDAO
    Public Function getAll(filters As ArrayList) As List(Of Cursus)
        Return dao.getList(filters)
    End Function
End Class
