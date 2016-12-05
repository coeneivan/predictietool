Public Class OntwikkelaarsBLL
    Dim dao As New OntwikkelaarsDAO
    Public Function getAll(filters As ArrayList) As List(Of Cursus)
        Return dao.getList(filters)
    End Function
    Public Function getList(cursus As Cursus, filters As ArrayList) As List(Of CursusExtraInfo)
        Dim tijdelijkefilters As New ArrayList

        '"Ontwikkelaar", "Merk", "Maand", "Subafdeling", "Uitvoerend centrum",
        tijdelijkefilters.Add(New FilterItem("Merk", "=", "'" + cursus.getMerk + "'"))
        If cursus.getOntw.Equals("NIEMAND") Then
            tijdelijkefilters.Add(New FilterItem("Ont", "is", "null"))
        Else
            tijdelijkefilters.Add(New FilterItem("Ont", "=", "'" + cursus.getOntw + "'"))
        End If
        tijdelijkefilters.Add(New FilterItem("month(startdatum)", "=", "'" + cursus.getMaand.ToString + "'"))
        tijdelijkefilters.Add(New FilterItem("CodeSubafdeling", "=", "'" + cursus.getCodeSubafdeling + "'"))
        tijdelijkefilters.Add(New FilterItem("UitvCentrumOmsch", "=", "'" + cursus.getUitvoerCentrum + "'"))

        filters.AddRange(tijdelijkefilters)
        Dim list = dao.getListExtraInfo(filters)
        For Each fi In tijdelijkefilters
            filters.Remove(fi)
        Next
        Return list
    End Function
End Class
