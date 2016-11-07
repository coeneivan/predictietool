Public Class PerOntwikkelaar
    Dim root As MainScreen
    Public Sub New(main As MainScreen)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        root = main
    End Sub
    Private Sub PerOntwikkelaar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim juist = 0
        Dim fout = 0
        Dim dic As New Dictionary(Of String, List(Of DataMiningPrediction2))
        Dim sql As New SQLUtil
        'PER MERK/SUBAFDELING --> %gescharpt + #cursussen
        Dim f As String
        f = createFilterString(root.getFilters())
        Dim data2015 = sql.getArrayList2("SELECT ont, merk, CodeSubafdeling, count(*) as totaal, sum(CASE WHEN CodeIngetrokken='Nee' THEN 1 ELSE 0 END) as doorgeggaan from cursussen where year(startdatum)=2015 and " + f + " and ont is not null group by ont, merk, CodeSubafdeling")
        Dim test As New TestBLL
        Dim listOfAllItems = test.GetAllCursForAllVarByOnt(f)
        dgvResult.Columns.Add("Ontwikkelaar", "Ontwikkelaar")
        dgvResult.Columns.Add("Merk", "Merk")
        dgvResult.Columns.Add("Sub afdeling", "Sub afdeling")
        dgvResult.Columns.Add("Totaal", "Totaal")
        dgvResult.Columns.Add("Doorgegaan", "Doorgegaan")
        dgvResult.Columns.Add("Voorspeld voor 2015", "Voorspeld voor 2015")
        dgvResult.Columns.Add("Werkelijk voor 2015", "Werkelijk voor 2015")
        For Each item In listOfAllItems
            Dim ToCheck = (item.getOnt + "|" + item.getMerk + "|" + item.getCodeSubAfdeling).ToUpper
            If Not dic.ContainsKey(ToCheck) Then
                Dim ar As New List(Of DataMiningPrediction2)
                ar.Add(item)
                dic.Add(ToCheck, ar)
            Else
                Dim ar As List(Of DataMiningPrediction2) = dic(ToCheck)
                ar.Add(item)
                dic(ToCheck) = ar
            End If
        Next
        For Each item In dic
            Dim dicToPass = New Dictionary(Of String, Parameter)
            Dim key = item.Key.Split(New Char(), "|")
            Dim doorgegaan = 0
            For Each i In item.Value
                doorgegaan += i.getDoorgegaan
                If Not dicToPass.ContainsKey(i.getJaar) Then
                    dicToPass.Add(i.getJaar, New Parameter(1, i.getDoorgegaan))
                Else
                    Dim v = dicToPass(i.getJaar)
                    dicToPass(i.getJaar) = New Parameter(v.getTotaal + 1, v.getNietGeschrapt + i.getDoorgegaan)
                End If
            Next
            Dim prospector As New Prospect
            Dim p = prospector.prospect(dicToPass, 2015)
            Dim bereik = prospector.certainty(dicToPass, p)
            'TODO get werkelijke waarde
            'System.Diagnostics.Debug.WriteLine("---------------------")
            Dim percentage2015 = 0
            For Each i In data2015
                'System.Diagnostics.Debug.WriteLine(i(0) + "-" + key(0) + " - " + i(1) + "-" + key(1) + " - " + i(2) + "-" + key(2))
                If i(0).ToString.ToUpper.Trim = key(0).ToString.ToUpper.Trim And i(1).ToString.ToUpper.Trim = key(1).ToString.ToUpper.Trim And i(2).ToString.ToUpper.Trim = key(2).ToString.ToUpper.Trim Then
                    percentage2015 = (i(4) / i(3)) * 100
                    GoTo uitdeloopstappen
                End If
            Next
uitdeloopstappen:
            dgvResult.Rows.Add(key(0), key(1), key(2), item.Value.Count.ToString, Math.Round((doorgegaan / item.Value.Count * 100), 2).ToString, bereik.ToString, percentage2015.ToString)
            If bereik.valtTussen(percentage2015) Then
                juist += 1
            Else
                fout += 1
            End If
        Next
        MessageBox.Show("Totaal : " + (juist + fout).ToString + " waarvan " + juist.ToString + " juist geschat", "Klaar")
    End Sub
    Private Function createFilterString(filters As ArrayList) As String
        Dim f As String = ""
        For Each s As FilterItem In filters
            If f.Equals("") Then
                f = s.kolom + " " + s.factor + " " + s.filter
            Else
                f += " and " + s.kolom + " " + s.factor + " " + s.filter
            End If
        Next
        Return f
    End Function

    Private Sub dgvResult_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dgvResult.SortCompare
        If e.Column.Index = 3 Then
            Try
                e.SortResult = If(CInt(e.CellValue1) < CInt(e.CellValue2), -1, 1)
                e.Handled = True
            Catch
                Throw New Exception()
                'TODO catch!
            End Try
        End If
    End Sub
End Class