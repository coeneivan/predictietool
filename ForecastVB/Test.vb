Public Class Test
    Private root As MainScreen
    Public Sub New(main As MainScreen)
        ' This call is required by the designer.
        InitializeComponent()
        root = main
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim m As New MerkBLL
        cboMerk.Items.AddRange(m.getAll(2015, Nothing).ToArray)
        cboDag.Items.AddRange({"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"})
        startUp()
    End Sub
    Private Sub startUp()
        lvResult.Clear()
        lvResult.Columns.Add("SubAfdeling", 100)
        lvResult.Columns.Add("Voorspeld", 150)
        lvResult.Columns.Add("Echt", 100)
        lvResult.Columns.Add("Check", 50)
        lvResult.Columns.Add("aantal", 50)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            If cboMerk.SelectedItem Is Nothing Then
                Throw New ApplicationException("Gelieve een merk te kiezen")
            End If
            If cboDag.SelectedItem Is Nothing Then
                Throw New ApplicationException("Gelieve een dag te kiezen")
            End If

            startUp()

            If ComboBox1.SelectedItem.Equals("Linear regression") Then
                Dim sql As New SQLUtil
                Dim subAfds As New ArrayList
                Dim subBll As New subAfdBll
                Dim ja = 0
                Dim boven = 0
                Dim nee = 0
                Dim filters = root.getFilters
                Dim fil As String = ""

                If filters Is Nothing Then
                    subAfds.AddRange(sql.getArrayList("select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and year(StartDatum) = 2015 group by codesubafdeling having count(*) > 5").ToArray())
                    'TODO: catch empty arraylist
                Else
                    For Each filIt As FilterItem In filters
                        fil += " AND " + filIt.kolom + " " + filIt.factor + " " + filIt.filter
                    Next
                    subAfds.AddRange(sql.getArrayList("select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and year(StartDatum) = 2015 " + fil + "group by codesubafdeling having count(*) > 5").ToArray())

                End If
                pgb.Minimum = 0
                If subAfds.Count = 0 Then
                    pgb.Maximum = 1
                Else
                    pgb.Maximum = subAfds.Count - 1
                End If

                For i As Integer = 0 To subAfds.Count - 1
                    Dim merk As New MerkBLL
                    Dim dag As New DagBll
                    Dim lvi As New ListViewItem(subAfds(i).ToString)
                    Dim subA As Bereik = subBll.berekenVerwachtingsBereikVoorSubAfd(2015, subAfds(i), filters)
                    Dim dagA As Bereik = dag.berekenVerwachtingsBereikVoorDag(2015, cboDag.SelectedItem.ToString, filters)
                    Dim merkA As Bereik = merk.berekenVerwachtingsBereikVoorMerk(2015, cboMerk.SelectedItem.ToString, filters)
                    Dim min As Double = 100
                    Dim cursCount As Double = 0
                    Dim max As Double = 0
                    Dim bereiken As New ArrayList()
                    bereiken.AddRange({subA, dagA, merkA})
                    For j As Integer = 0 To bereiken.Count - 1
                        Dim ber As Bereik = bereiken(j)
                        If ber.getBovengrens > max Then
                            max = ber.getBovengrens
                        End If
                        If ber.getOndergrens < min Then
                            min = ber.getOndergrens
                        End If
                    Next
                    Dim bereik As New Bereik(min, 0, max)
                    lvi.SubItems.Add(bereik.ToString)
                    Dim dick As Dictionary(Of String, Parameter)
                    If filters Is Nothing Then
                        dick = sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND CodeSubafdeling = '" + subAfds(i) + "' AND year(cc.StartDatum) = year(c.StartDatum) AND Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "') as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE CodeSubafdeling = '" + subAfds(i) + "' AND year(c.StartDatum) =  2015 and Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' group by year(startdatum)")
                    Else
                        ' Voorkomen dat filterlijst opnieuw moet doorlopen worden, dit voorkomt de for each loop binnen deze for eacht loop
                        ' nu worden alle filters  keer doorlopen boven aan in de methode
                        dick = sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND CodeSubafdeling = '" + subAfds(i) + "' AND year(cc.StartDatum) = year(c.StartDatum) AND Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' " + fil + ") as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE CodeSubafdeling = '" + subAfds(i) + "' AND year(c.StartDatum) =  2015 and Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' " + fil + " group by year(startdatum)")
                    End If


                    If dick.ContainsKey(2015) Then
                        cursCount = dick.Item(2015).getTotaal()
                    End If

                    Dim y As Double
                    If dick IsNot Nothing Then
                        For Each kvp As KeyValuePair(Of String, Parameter) In dick
                            y = CDbl(kvp.Value.berekenPercentage)
                        Next

                        lvi.SubItems.Add(y.ToString)
                    End If
                    Dim tf = bereik.valtTussen(y)
                    If tf Then
                        lvi.BackColor = Color.FromArgb(255, 46, 204, 113)
                        ja += 1
                    ElseIf bereik.getBovengrens < y Then
                        lvi.BackColor = Color.FromArgb(255, 231, 76, 60)
                        boven += 1
                    Else
                        lvi.BackColor = Color.Orange
                        nee += 1
                    End If
                    lvi.SubItems.Add(tf)
                    lvi.SubItems.Add(cursCount)
                    lvResult.Items.AddRange(New ListViewItem() {lvi})

                    pgb.Value = i
                Next
                Label1.Text = "Valt tussen: " + ja.ToString() + " valt onder: " + nee.ToString() + " valt boven " + boven.ToString

            ElseIf ComboBox1.SelectedItem.Equals("Math.net regressie") Then
                nonLinearRegressionTest()

            ElseIf ComboBox1.SelectedItem.Equals("Decision tree") Then
                Dim cor = 0
                Dim sql As New SQLUtil
                Dim SQLCommandlbl = ("SELECT distinct top 1000 Opleidingsnr,month(StartDatum), TotalePrijs, CAST(CASE when dag = 'Maandag' then 1 when dag = 'Dinsdag' then 2 when dag = 'woensdag' then 3 when dag = 'Donderdag' then 4 when dag = 'Vrijdag' then 5 when dag = 'Zaterdag' then 6 when dag = 'Zondag' then 7 else '' end AS int) as dagnummer  , CAST(CASE when Merk = 'Syntra West' then 1 when Merk = 'SBM' then 2 when Merk = 'Escala' then 3 when Merk = 'EVW' then 4 else '' end AS int) as MerkNummer , CAST(CASE when CodeSubAfdeling = 'AB ' then 1 when CodeSubAfdeling = 'ACC' then 2 when CodeSubAfdeling = 'ACS' then 3 when CodeSubAfdeling = 'ADM' then 4 when CodeSubAfdeling = 'ADR' then 5 when CodeSubAfdeling = 'ADS' then 6 when CodeSubAfdeling = 'AFG' then 7 when CodeSubAfdeling = 'AFW' then 8 when CodeSubAfdeling = 'AGI' then 9 when CodeSubAfdeling = 'AGL' then 10 when CodeSubAfdeling = 'AGR' then 11 when CodeSubAfdeling = 'AKB' then 12 when CodeSubAfdeling = 'ALD' then 13 when CodeSubAfdeling = 'ALG' then 14 when CodeSubAfdeling = 'AN ' then 15 when CodeSubAfdeling = 'AR ' then 16 when CodeSubAfdeling = 'ART' then 17 when CodeSubAfdeling = 'AS4' then 18 when CodeSubAfdeling = 'AT ' then 19 when CodeSubAfdeling = 'AUD' then 20 when CodeSubAfdeling = 'AUT' then 21 when CodeSubAfdeling = 'BAK' then 22 when CodeSubAfdeling = 'BAL' then 23 when CodeSubAfdeling = 'BBH' then 24 when CodeSubAfdeling = 'BDM' then 25 when CodeSubAfdeling = 'BEL' then 26 when CodeSubAfdeling = 'BEW' then 27 when CodeSubAfdeling = 'BHI' then 28 when CodeSubAfdeling = 'BMV' then 29 when CodeSubAfdeling = 'BOL' then 30 when CodeSubAfdeling = 'BOW' then 31 when CodeSubAfdeling = 'BRA' then 32 when CodeSubAfdeling = 'BRL' then 33 when CodeSubAfdeling = 'BRO' then 34 when CodeSubAfdeling = 'BTK' then 35 when CodeSubAfdeling = 'BTT' then 36 when CodeSubAfdeling = 'BU ' then 37 when CodeSubAfdeling = 'CAD' then 38 when CodeSubAfdeling = 'CAL' then 39 when CodeSubAfdeling = 'CAR' then 40 when CodeSubAfdeling = 'CAT' then 41 when CodeSubAfdeling = 'CB ' then 42 when CodeSubAfdeling = 'CBL' then 43 when CodeSubAfdeling = 'CH ' then 44 when CodeSubAfdeling = 'CHL' then 45 when CodeSubAfdeling = 'CHO' then 46 when CodeSubAfdeling = 'CLT' then 47 when CodeSubAfdeling = 'CMV' then 48 when CodeSubAfdeling = 'COM' then 49 when CodeSubAfdeling = 'CST' then 50 when CodeSubAfdeling = 'CV ' then 51 when CodeSubAfdeling = 'DAK' then 52 when CodeSubAfdeling = 'DAL' then 53 when CodeSubAfdeling = 'DBA' then 54 when CodeSubAfdeling = 'DBG' then 55 when CodeSubAfdeling = 'DBO' then 56 when CodeSubAfdeling = 'DDG' then 57 when CodeSubAfdeling = 'DE ' then 58 when CodeSubAfdeling = 'DES' then 59 when CodeSubAfdeling = 'DIE' then 60 when CodeSubAfdeling = 'DIL' then 61 when CodeSubAfdeling = 'DKA' then 62 when CodeSubAfdeling = 'DRL' then 63 when CodeSubAfdeling = 'DRN' then 64 when CodeSubAfdeling = 'DSN' then 65 when CodeSubAfdeling = 'DSP' then 66 when CodeSubAfdeling = 'DTP' then 67 when CodeSubAfdeling = 'DU ' then 68 when CodeSubAfdeling = 'DVB' then 69 when CodeSubAfdeling = 'ELC' then 70 when CodeSubAfdeling = 'ELL' then 71 when CodeSubAfdeling = 'EN ' then 72 when CodeSubAfdeling = 'EPR' then 73 when CodeSubAfdeling = 'ESD' then 74 when CodeSubAfdeling = 'EVW' then 75 when CodeSubAfdeling = 'EXP' then 76 when CodeSubAfdeling = 'FBM' then 77 when CodeSubAfdeling = 'FI ' then 78 when CodeSubAfdeling = 'FIE' then 79 when CodeSubAfdeling = 'FIL' then 80 when CodeSubAfdeling = 'FIN' then 81 when CodeSubAfdeling = 'FIS' then 82 when CodeSubAfdeling = 'FR ' then 83 when CodeSubAfdeling = 'FRI' then 84 when CodeSubAfdeling = 'FTC' then 85 when CodeSubAfdeling = 'FTG' then 86 when CodeSubAfdeling = 'FTL' then 87 when CodeSubAfdeling = 'GAL' then 88 when CodeSubAfdeling = 'GAR' then 89 when CodeSubAfdeling = 'GIS' then 90 when CodeSubAfdeling = 'GLK' then 91 when CodeSubAfdeling = 'GLL' then 92 when CodeSubAfdeling = 'GMB' then 93 when CodeSubAfdeling = 'GMN' then 94 when CodeSubAfdeling = 'GR ' then 95 when CodeSubAfdeling = 'GRF' then 96 when CodeSubAfdeling = 'GSP' then 97 when CodeSubAfdeling = 'GVZ' then 98 when CodeSubAfdeling = 'HBB' then 99 when CodeSubAfdeling = 'HBR' then 100 when CodeSubAfdeling = 'HEN' then 101 when CodeSubAfdeling = 'HFT' then 102 when CodeSubAfdeling = 'HLT' then 103 when CodeSubAfdeling = 'HND' then 104 when CodeSubAfdeling = 'HO ' then 105 when CodeSubAfdeling = 'HOL' then 106 when CodeSubAfdeling = 'HOR' then 107 when CodeSubAfdeling = 'HOT' then 108 when CodeSubAfdeling = 'HOU' then 109 when CodeSubAfdeling = 'HRM' then 110 when CodeSubAfdeling = 'HSD' then 111 when CodeSubAfdeling = 'HSL' then 112 when CodeSubAfdeling = 'HTL' then 113 when CodeSubAfdeling = 'HUI' then 114 when CodeSubAfdeling = 'HUR' then 115 when CodeSubAfdeling = 'HW ' then 116 when CodeSubAfdeling = 'HWL' then 117 when CodeSubAfdeling = 'HYG' then 118 when CodeSubAfdeling = 'HZG' then 119 when CodeSubAfdeling = 'IDC' then 120 when CodeSubAfdeling = 'IEL' then 121 when CodeSubAfdeling = 'IIR' then 122 when CodeSubAfdeling = 'IJS' then 123 when CodeSubAfdeling = 'IME' then 124 when CodeSubAfdeling = 'IN ' then 125 when CodeSubAfdeling = 'INI' then 126 when CodeSubAfdeling = 'INL' then 127 when CodeSubAfdeling = 'INS' then 128 when CodeSubAfdeling = 'INT' then 129 when CodeSubAfdeling = 'IT ' then 130 when CodeSubAfdeling = 'ITB' then 131 when CodeSubAfdeling = 'ITI' then 132 when CodeSubAfdeling = 'JA ' then 133 when CodeSubAfdeling = 'JUL' then 134 when CodeSubAfdeling = 'JUR' then 135 when CodeSubAfdeling = 'JUW' then 136 when CodeSubAfdeling = 'KAL' then 137 when CodeSubAfdeling = 'KAP' then 138 when CodeSubAfdeling = 'KNS' then 139 when CodeSubAfdeling = 'KPB' then 140 when CodeSubAfdeling = 'KR ' then 141 when CodeSubAfdeling = 'KTA' then 142 when CodeSubAfdeling = 'KTL' then 143 when CodeSubAfdeling = 'KUN' then 144 when CodeSubAfdeling = 'KWA' then 145 when CodeSubAfdeling = 'LAN' then 146 when CodeSubAfdeling = 'LAS' then 147 when CodeSubAfdeling = 'LDS' then 148 when CodeSubAfdeling = 'LOG' then 149 when CodeSubAfdeling = 'MAN' then 150 when CodeSubAfdeling = 'MEC' then 151 when CodeSubAfdeling = 'MED' then 152 when CodeSubAfdeling = 'MEL' then 153 when CodeSubAfdeling = 'MET' then 154 when CodeSubAfdeling = 'MGV' then 155 when CodeSubAfdeling = 'MIL' then 156 when CodeSubAfdeling = 'MM ' then 157 when CodeSubAfdeling = 'MOC' then 158 when CodeSubAfdeling = 'MSF' then 159 when CodeSubAfdeling = 'MSR' then 160 when CodeSubAfdeling = 'MSW' then 161 when CodeSubAfdeling = 'NL ' then 162 when CodeSubAfdeling = 'NOV' then 163 when CodeSubAfdeling = 'NOX' then 164 when CodeSubAfdeling = 'NRS' then 165 when CodeSubAfdeling = 'ODH' then 166 when CodeSubAfdeling = 'OFF' then 167 when CodeSubAfdeling = 'OOI' then 168 when CodeSubAfdeling = 'OPS' then 169 when CodeSubAfdeling = 'ORG' then 170 when CodeSubAfdeling = 'OS ' then 171 when CodeSubAfdeling = 'P ' then 172 when CodeSubAfdeling = 'PED' then 173 when CodeSubAfdeling = 'PER' then 174 when CodeSubAfdeling = 'PO ' then 175 when CodeSubAfdeling = 'POP' then 176 when CodeSubAfdeling = 'PPS' then 177 when CodeSubAfdeling = 'PRD' then 178 when CodeSubAfdeling = 'PRG' then 179 when CodeSubAfdeling = 'PRM' then 180 when CodeSubAfdeling = 'PRS' then 181 when CodeSubAfdeling = 'PRV' then 182 when CodeSubAfdeling = 'PRX' then 183 when CodeSubAfdeling = 'PVZ' then 184 when CodeSubAfdeling = 'PWU' then 185 when CodeSubAfdeling = 'RED' then 186 when CodeSubAfdeling = 'REL' then 187 when CodeSubAfdeling = 'REN' then 188 when CodeSubAfdeling = 'RES' then 189 when CodeSubAfdeling = 'RET' then 190 when CodeSubAfdeling = 'RLT' then 191 when CodeSubAfdeling = 'RO ' then 192 when CodeSubAfdeling = 'RPA' then 193 when CodeSubAfdeling = 'RU ' then 194 when CodeSubAfdeling = 'RUW' then 195 when CodeSubAfdeling = 'SAC' then 196 when CodeSubAfdeling = 'SAF' then 197 when CodeSubAfdeling = 'SCE' then 198 when CodeSubAfdeling = 'SCH' then 199 when CodeSubAfdeling = 'SCL' then 200 when CodeSubAfdeling = 'SCO' then 201 when CodeSubAfdeling = 'SEC' then 202 when CodeSubAfdeling = 'SEM' then 203 when CodeSubAfdeling = 'SFI' then 204 when CodeSubAfdeling = 'SFV' then 205 when CodeSubAfdeling = 'SIE' then 206 when CodeSubAfdeling = 'SLA' then 207 when CodeSubAfdeling = 'SLL' then 208 when CodeSubAfdeling = 'SLV' then 209 when CodeSubAfdeling = 'SMA' then 210 when CodeSubAfdeling = 'SME' then 211 when CodeSubAfdeling = 'SOM' then 212 when CodeSubAfdeling = 'SOR' then 213 when CodeSubAfdeling = 'SP ' then 214 when CodeSubAfdeling = 'SPE' then 215 when CodeSubAfdeling = 'SRZ' then 216 when CodeSubAfdeling = 'STN' then 217 when CodeSubAfdeling = 'SVG' then 218 when CodeSubAfdeling = 'SWI' then 219 when CodeSubAfdeling = 'TAV' then 220 when CodeSubAfdeling = 'TDM' then 221 when CodeSubAfdeling = 'TEA' then 222 when CodeSubAfdeling = 'TEX' then 223 when CodeSubAfdeling = 'TLT' then 224 when CodeSubAfdeling = 'TRA' then 225 when CodeSubAfdeling = 'TRM' then 226 when CodeSubAfdeling = 'TS ' then 227 when CodeSubAfdeling = 'TTT' then 228 when CodeSubAfdeling = 'TU ' then 229 when CodeSubAfdeling = 'TVR' then 230 when CodeSubAfdeling = 'TXT' then 231 when CodeSubAfdeling = 'VAA' then 232 when CodeSubAfdeling = 'VAK' then 233 when CodeSubAfdeling = 'VAS' then 234 when CodeSubAfdeling = 'VDG' then 235 when CodeSubAfdeling = 'VDL' then 236 when CodeSubAfdeling = 'VEB' then 237 when CodeSubAfdeling = 'VEI' then 238 when CodeSubAfdeling = 'VEL' then 239 when CodeSubAfdeling = 'VID' then 240 when CodeSubAfdeling = 'VIS' then 241 when CodeSubAfdeling = 'VLI' then 242 when CodeSubAfdeling = 'VRA' then 243 when CodeSubAfdeling = 'VZK' then 244 when CodeSubAfdeling = 'VZS' then 245 when CodeSubAfdeling = 'WBH' then 246 when CodeSubAfdeling = 'WEB' then 247 when CodeSubAfdeling = 'WEM' then 248 when CodeSubAfdeling = 'WKN' then 249 when CodeSubAfdeling = 'WMC' then 250 when CodeSubAfdeling = 'WST' then 251 when CodeSubAfdeling = 'WW ' then 252 when CodeSubAfdeling = 'WWM' then 253 when CodeSubAfdeling = 'ZB ' then 254 when CodeSubAfdeling = 'ZW ' then 255 else '' end as int) as CodeSubafdelingNummer , CAST(CASE When CodeSoortCursus = 'AV' then 1 When CodeSoortCursus = 'DA' then 1 When CodeSoortCursus = 'DAG' then 1 When CodeSoortCursus = 'NA' then 1 When CodeSoortCursus = 'NB' then 1 When CodeSoortCursus = 'NM' then 1 When CodeSoortCursus = 'VDO' then 1 When CodeSoortCursus = 'VM' then 1 When CodeSoortCursus = 'ZAT' then 1 When CodeSoortCursus = 'ZATVM' then 1 else '' end as int) as CodeSoortCursusNummer , UitvCentrum , Aard  FROM dbo.Cursussen WHERE merk='" + cboMerk.SelectedItem + "' AND dag='" + cboDag.SelectedItem + "' AND (Aard NOT IN (15, 29, 14, 58, 12, 13)) AND (OmschrijvingComm NOT LIKE '%SELOR%') AND (OmschrijvingComm NOT LIKE '%Bekwaamheidsattest%') AND (OmschrijvingComm NOT LIKE '%stage%') AND (OmschrijvingComm NOT LIKE '%proef%') AND (OmschrijvingComm NOT LIKE '%attest%') AND (OmschrijvingComm NOT LIKE '%aanvullende praktijk%') AND (OmschrijvingComm NOT LIKE '%eindwerk%') AND (OmschrijvingComm NOT LIKE '%AP%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'POC%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'C.I.%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'P.S.%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'LeReN%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'Lerend%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'Iedereen leert%') AND (OmschrijvingComm NOT LIKE 'Bedrijvig Brugge%') AND (OmschrijvingComm NOT LIKE '%testavond%') AND (OmschrijvingComm NOT LIKE 'Talent%') AND (OmschrijvingComm NOT LIKE '%Spoor 1%') AND (OmschrijvingComm NOT LIKE '%Spoor 2%') AND (OmschrijvingComm NOT LIKE '%Spoor 3%') AND (OmschrijvingComm NOT LIKE '%Spoor 4%') AND (OmschrijvingComm NOT LIKE '%Spoor 5%') AND year(startdatum) < 2015")
                Dim subafds = sql.getAll(SQLCommandlbl)
                For i As Integer = 0 To subafds.Count - 1
                    Dim predictor As New newPredictor
                    Dim tempList = subafds(i)
                    Dim lvi = New ListViewItem(tempList(0))
                    Dim p = Not (predictor.predict(tempList(1), tempList(2), tempList(3), tempList(4), tempList(5), tempList(6), tempList(7), tempList(8)))
                    lvi.SubItems.Add(p.ToString)
                    Dim sql2 = sql.getArrayList("SELECT codeingetrokken from cursussen where Opleidingsnr = " + tempList(0))(0).ToString
                    lvi.SubItems.Add(sql2)
                    If (p = True And sql2.Equals("Ja")) Or (p = False And sql2.Equals("Nee")) Then
                        cor += 1
                    End If
                    lvi.SubItems.Add((p = True And sql2.Equals("Ja")) Or (p = False And sql2.Equals("Nee")))
                    lvResult.Items.AddRange(New ListViewItem() {lvi})
                Next
                Label1.Text = cor.ToString
            ElseIf ComboBox1.SelectedItem.Equals("Apriori (association Rule Learning)") Then
                Dim data = {{1, 3, 4, 0}, {2, 3, 5, 0}, {1, 2, 3, 5}, {2, 5, 0, 0}}
                Dim ap As New Apriori(data)
                For Each i In ap.joinTwo()
                    Dim lviTXT = ""
                    For Each a In i
                        ap.scanD(0.5)
                        lviTXT += a.ToString
                    Next
                    Dim lvi = New ListViewItem(lviTXT)
                    lvResult.Items.AddRange(New ListViewItem() {lvi})
                Next
            End If
        Catch ex As ApplicationException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub nonLinearRegressionTest()
        Dim subAfds As New ArrayList
        Dim Sql = New SQLUtil
        Dim filters = root.getFilters
        Dim fil As String = ""
        lvResult.Clear()

        ' Zijn er filters ingesteld?
        If filters Is Nothing Then
            'Haal alle subafdelingen op waar er, zonder filters, meer dan cursussen zijn (voor preciesere meting worden onder  cursussen niet in rekening gebracht)
            subAfds.AddRange(Sql.getArrayList("select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and year(StartDatum) = 2015 group by codesubafdeling having count(*) > 5").ToArray())
            'TODO: catch empty arraylist
        Else
            For Each filIt As FilterItem In filters
                fil += " AND " + filIt.kolom + " " + filIt.factor + " " + filIt.filter
            Next
            'Haal alle subafdelingen op waar er, met filters, meer dan cursussen zijn (voor preciesere meting worden onder  cursussen niet in rekening gebracht)
            subAfds.AddRange(Sql.getArrayList("select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and year(StartDatum) = 2015 " + fil + "group by codesubafdeling having count(*) > 5").ToArray())
        End If

        For i As Integer = 0 To subAfds.Count - 1
            Dim cursus As Dictionary(Of String, Parameter)

            If filters Is Nothing Then
                cursus = Sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND CodeSubafdeling = '" + subAfds(i) + "' AND year(cc.StartDatum) = year(c.StartDatum) AND Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "') as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE CodeSubafdeling = '" + subAfds(i) + "' AND year(c.StartDatum) =  2015 and Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' group by year(startdatum)")
            Else
                ' Voorkomen dat filterlijst opnieuw moet doorlopen worden, dit voorkomt de for each loop binnen deze for eacht loop
                ' nu worden alle filters  keer doorlopen boven aan in de methode
                cursus = Sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND CodeSubafdeling = '" + subAfds(i) + "' AND year(cc.StartDatum) = year(c.StartDatum) AND Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' " + fil + ") as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE CodeSubafdeling = '" + subAfds(i) + "' AND year(c.StartDatum) =  2015 and Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' " + fil + " group by year(startdatum)")
            End If
        Next

    End Sub
End Class