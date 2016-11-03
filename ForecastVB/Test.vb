

Imports System.Windows.Forms.DataVisualization.Charting

Public Class Test
    Private root As MainScreen
    Dim a As Double = 1
    Dim b As Double = 1
    Dim c As Double = 1
    Dim som As Double = 0
    Dim alleMerken, alleDagen, alleMaanden, alleCentra As ArrayList

    Public Sub New(main As MainScreen)
        ' This call is required by the designer.
        InitializeComponent()
        root = main
        ' Add any initialization after the InitializeComponent() call.


    End Sub



    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'bayesAndLinear() 'AUTO START Bayes' theorem & Linear
        ComboBox1.Text() = "Bayes' theorem with year"
        txtJaar.Text = 10
        txtJaarWeging.Text = -0.75

        Dim m As New MerkBLL
        alleMerken = m.getAll(2015, Nothing)
        cboMerk.Items.AddRange(alleMerken.ToArray)
        alleDagen = New ArrayList({"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"})
        cboDag.Items.AddRange(alleDagen.ToArray)
        Dim para As New ParameterParent("uitvCentrumOmsch")
        alleCentra = para.getAall(2015, root.getFilters)
        cboUitvoerendCentrum.Items.AddRange(alleCentra.ToArray)

    End Sub


#Region "Old Algorithms and methodes"
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try

            If ComboBox1.SelectedItem Is Nothing Then
                Throw New ApplicationException("Gelieve een algortime te kiezen")
            End If

            If (ComboBox1.SelectedItem.Equals("Data mining algorithms: Prediction")) Then
                dataMiningPrediction()
            ElseIf (ComboBox1.SelectedItem.Equals("Bayes' theorem")) Then
                dataMiningPrediction2()
            ElseIf (ComboBox1.SelectedItem.Equals("Bayes' theorem & Linear")) Then
                bayesAndLinear()
            ElseIf (ComboBox1.SelectedItem.Equals("Bayes' theorem with year")) Then
                BayersWithYear()
            Else


                If cboMerk.SelectedItem Is Nothing Then
                    Throw New ApplicationException("Gelieve een merk te kiezen")
                End If
                If cboDag.SelectedItem Is Nothing Then
                    Throw New ApplicationException("Gelieve een dag te kiezen")
                End If
                If (cbbMonth.SelectedItem).Value Is Nothing Then
                    Throw New ApplicationException("Gelieve een maand te kiezen")
                End If

                dgvResult.DataSource = Nothing 'CLEAR indien er andere data aanwezig was

                If ComboBox1.SelectedItem.Equals("Linear regression") Then
                    Dim sql As New SQLUtil
                    Dim subAfds As New ArrayList
                    Dim subBll As New subAfdBll
                    Dim ja = 0
                    Dim boven = 0
                    Dim nee = 0
                    Dim filters = root.getFilters
                    Dim fil As String = ""
                    dgvResult.Columns.Add("Subafdeling", "Subafdeling")
                    dgvResult.Columns.Add("Range", "Range")
                    dgvResult.Columns.Add("Echt", "Echt")
                    dgvResult.Columns.Add("Klopt het", "Klopt het")
                    dgvResult.Columns.Add("Aantal", "Aantal")

                    If filters Is Nothing Then
                        subAfds.AddRange(sql.getArrayList("select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and month(startdatum)=" + (cbbMonth.SelectedItem).Value + " and UitvCentrumOmsch='" + cboUitvoerendCentrum.SelectedItem + "' and year(StartDatum) = 2015 group by codesubafdeling having count(*) > 5").ToArray())
                    Else
                        For Each filIt As FilterItem In filters
                            fil += " AND " + filIt.kolom + " " + filIt.factor + " " + filIt.filter
                        Next
                        subAfds.AddRange(sql.getArrayList("select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and month(startdatum)=" + (cbbMonth.SelectedItem).Value + " and UitvCentrumOmsch='" + cboUitvoerendCentrum.SelectedItem + "' and year(StartDatum) = 2015 " + fil + " group by codesubafdeling  having count(*) > 5").ToArray())

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
                        Dim maand As New DatumBLL
                        Dim uitvCentrum As New ParameterParent("UitvCentrumOmsch")
                        Dim subA As Bereik = subBll.berekenVerwachtingsBereikVoorSubAfd(2015, subAfds(i), filters)
                        Dim dagA As Bereik = dag.berekenVerwachtingsBereikVoorDag(2015, cboDag.SelectedItem.ToString, filters)
                        Dim merkA As Bereik = merk.berekenVerwachtingsBereikVoorMerk(2015, cboMerk.SelectedItem.ToString, filters)
                        Dim maandA As Bereik = maand.berekenVerwachtingsBereikVoorDatum(2015, (cbbMonth.SelectedItem).Value, filters)
                        Dim uitvCenA As Bereik = uitvCentrum.berekenVerwachtingsBereik(2015, cboUitvoerendCentrum.SelectedItem.ToString, filters)
                        Dim cursCount As Double = 0
                        Dim averages As New ArrayList()
                        Dim sqlcommand = "SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee'  AND year(cc.StartDatum) = year(c.StartDatum)) as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE  year(c.StartDatum) < 2015 GROUP BY year(c.startDatum)"
                        Dim p As New Prospect
                        Dim pros = p.prospect(sql.getDictionary(sqlcommand), 2015)
                        averages.AddRange({subA.getAvg / 100, dagA.getAvg / 100, merkA.getAvg / 100, maandA.getAvg / 100, uitvCenA.getAvg / 100, pros / 100})
                        Dim pNee As Double = 1
                        Dim pJa As Double = 1
                        For Each a In averages
                            pNee *= a
                            pJa *= (1 - (a))
                        Next
                        Dim range = p.certainty(averages, pNee / (pNee + pJa))
                        Dim dick As Dictionary(Of String, Parameter)
                        If filters Is Nothing Then
                            dick = sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND CodeSubafdeling = '" + subAfds(i) + "' AND year(cc.StartDatum) = year(c.StartDatum) AND Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and month(startdatum)=" + (cbbMonth.SelectedItem).Value + " and UitvCentrumOmsch='" + cboUitvoerendCentrum.SelectedItem + "') as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE CodeSubafdeling = '" + subAfds(i) + "' AND year(c.StartDatum) =  2015 and Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and month(startdatum)=" + (cbbMonth.SelectedItem).Value + " and UitvCentrumOmsch='" + cboUitvoerendCentrum.SelectedItem + "' group by year(startdatum)")
                        Else
                            ' Voorkomen dat filterlijst opnieuw moet doorlopen worden, dit voorkomt de for each loop binnen deze for eacht loop
                            ' nu worden alle filters  keer doorlopen boven aan in de methode
                            dick = sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND CodeSubafdeling = '" + subAfds(i) + "' AND year(cc.StartDatum) = year(c.StartDatum) AND Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and month(startdatum)=" + (cbbMonth.SelectedItem).Value + " and UitvCentrumOmsch='" + cboUitvoerendCentrum.SelectedItem + "' " + fil + ") as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE CodeSubafdeling = '" + subAfds(i) + "' AND year(c.StartDatum) =  2015 and Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and month(startdatum)=" + (cbbMonth.SelectedItem).Value + " and UitvCentrumOmsch='" + cboUitvoerendCentrum.SelectedItem + "'" + fil + " group by year(startdatum)")
                        End If


                        If dick.ContainsKey(2015) Then
                            cursCount = dick.Item(2015).getTotaal()
                        End If

                        Dim y As Double
                        If dick IsNot Nothing Then
                            For Each kvp As KeyValuePair(Of String, Parameter) In dick
                                y = CDbl(kvp.Value.berekenPercentage)
                            Next


                        End If
                        Dim tf = range.valtTussen(y)
                        If tf Then
                            ja += 1
                        ElseIf range.getBovengrens < y Then
                            boven += 1
                        Else
                            nee += 1
                        End If
                        dgvResult.Rows.Add(subAfds(i).ToString, range.ToString, y.ToString, tf.ToString, cursCount.ToString)

                        pgb.Value = i
                    Next
                    Label1.Text = "Valt tussen: " + ja.ToString() + " valt onder: " + nee.ToString() + " valt boven " + boven.ToString

                ElseIf ComboBox1.SelectedItem.Equals("Lagrange Interpolating Polynomial") Then
                    nonLinearRegressionTest()

                ElseIf ComboBox1.SelectedItem.Equals("Decision tree") Then
                    Dim cor = 0
                    Dim sql As New SQLUtil
                    Dim SQLCommandlbl = ("SELECT distinct top 1000 Opleidingsnr,month(StartDatum), TotalePrijs, CAST(CASE when dag = 'Maandag' then 1 when dag = 'Dinsdag' then 2 when dag = 'woensdag' then 3 when dag = 'Donderdag' then 4 when dag = 'Vrijdag' then 5 when dag = 'Zaterdag' then 6 when dag = 'Zondag' then 7 else '' end AS int) as dagnummer  , CAST(CASE when Merk = 'Syntra West' then 1 when Merk = 'SBM' then 2 when Merk = 'Escala' then 3 when Merk = 'EVW' then 4 else '' end AS int) as MerkNummer , CAST(CASE when CodeSubAfdeling = 'AB ' then 1 when CodeSubAfdeling = 'ACC' then 2 when CodeSubAfdeling = 'ACS' then 3 when CodeSubAfdeling = 'ADM' then 4 when CodeSubAfdeling = 'ADR' then 5 when CodeSubAfdeling = 'ADS' then 6 when CodeSubAfdeling = 'AFG' then 7 when CodeSubAfdeling = 'AFW' then 8 when CodeSubAfdeling = 'AGI' then 9 when CodeSubAfdeling = 'AGL' then 10 when CodeSubAfdeling = 'AGR' then 11 when CodeSubAfdeling = 'AKB' then 12 when CodeSubAfdeling = 'ALD' then 13 when CodeSubAfdeling = 'ALG' then 14 when CodeSubAfdeling = 'AN ' then 15 when CodeSubAfdeling = 'AR ' then 16 when CodeSubAfdeling = 'ART' then 17 when CodeSubAfdeling = 'AS4' then 18 when CodeSubAfdeling = 'AT ' then 19 when CodeSubAfdeling = 'AUD' then 20 when CodeSubAfdeling = 'AUT' then 21 when CodeSubAfdeling = 'BAK' then 22 when CodeSubAfdeling = 'BAL' then 23 when CodeSubAfdeling = 'BBH' then 24 when CodeSubAfdeling = 'BDM' then 25 when CodeSubAfdeling = 'BEL' then 26 when CodeSubAfdeling = 'BEW' then 27 when CodeSubAfdeling = 'BHI' then 28 when CodeSubAfdeling = 'BMV' then 29 when CodeSubAfdeling = 'BOL' then 30 when CodeSubAfdeling = 'BOW' then 31 when CodeSubAfdeling = 'BRA' then 32 when CodeSubAfdeling = 'BRL' then 33 when CodeSubAfdeling = 'BRO' then 34 when CodeSubAfdeling = 'BTK' then 35 when CodeSubAfdeling = 'BTT' then 36 when CodeSubAfdeling = 'BU ' then 37 when CodeSubAfdeling = 'CAD' then 38 when CodeSubAfdeling = 'CAL' then 39 when CodeSubAfdeling = 'CAR' then 40 when CodeSubAfdeling = 'CAT' then 41 when CodeSubAfdeling = 'CB ' then 42 when CodeSubAfdeling = 'CBL' then 43 when CodeSubAfdeling = 'CH ' then 44 when CodeSubAfdeling = 'CHL' then 45 when CodeSubAfdeling = 'CHO' then 46 when CodeSubAfdeling = 'CLT' then 47 when CodeSubAfdeling = 'CMV' then 48 when CodeSubAfdeling = 'COM' then 49 when CodeSubAfdeling = 'CST' then 50 when CodeSubAfdeling = 'CV ' then 51 when CodeSubAfdeling = 'DAK' then 52 when CodeSubAfdeling = 'DAL' then 53 when CodeSubAfdeling = 'DBA' then 54 when CodeSubAfdeling = 'DBG' then 55 when CodeSubAfdeling = 'DBO' then 56 when CodeSubAfdeling = 'DDG' then 57 when CodeSubAfdeling = 'DE ' then 58 when CodeSubAfdeling = 'DES' then 59 when CodeSubAfdeling = 'DIE' then 60 when CodeSubAfdeling = 'DIL' then 61 when CodeSubAfdeling = 'DKA' then 62 when CodeSubAfdeling = 'DRL' then 63 when CodeSubAfdeling = 'DRN' then 64 when CodeSubAfdeling = 'DSN' then 65 when CodeSubAfdeling = 'DSP' then 66 when CodeSubAfdeling = 'DTP' then 67 when CodeSubAfdeling = 'DU ' then 68 when CodeSubAfdeling = 'DVB' then 69 when CodeSubAfdeling = 'ELC' then 70 when CodeSubAfdeling = 'ELL' then 71 when CodeSubAfdeling = 'EN ' then 72 when CodeSubAfdeling = 'EPR' then 73 when CodeSubAfdeling = 'ESD' then 74 when CodeSubAfdeling = 'EVW' then 75 when CodeSubAfdeling = 'EXP' then 76 when CodeSubAfdeling = 'FBM' then 77 when CodeSubAfdeling = 'FI ' then 78 when CodeSubAfdeling = 'FIE' then 79 when CodeSubAfdeling = 'FIL' then 80 when CodeSubAfdeling = 'FIN' then 81 when CodeSubAfdeling = 'FIS' then 82 when CodeSubAfdeling = 'FR ' then 83 when CodeSubAfdeling = 'FRI' then 84 when CodeSubAfdeling = 'FTC' then 85 when CodeSubAfdeling = 'FTG' then 86 when CodeSubAfdeling = 'FTL' then 87 when CodeSubAfdeling = 'GAL' then 88 when CodeSubAfdeling = 'GAR' then 89 when CodeSubAfdeling = 'GIS' then 90 when CodeSubAfdeling = 'GLK' then 91 when CodeSubAfdeling = 'GLL' then 92 when CodeSubAfdeling = 'GMB' then 93 when CodeSubAfdeling = 'GMN' then 94 when CodeSubAfdeling = 'GR ' then 95 when CodeSubAfdeling = 'GRF' then 96 when CodeSubAfdeling = 'GSP' then 97 when CodeSubAfdeling = 'GVZ' then 98 when CodeSubAfdeling = 'HBB' then 99 when CodeSubAfdeling = 'HBR' then 100 when CodeSubAfdeling = 'HEN' then 101 when CodeSubAfdeling = 'HFT' then 102 when CodeSubAfdeling = 'HLT' then 103 when CodeSubAfdeling = 'HND' then 104 when CodeSubAfdeling = 'HO ' then 105 when CodeSubAfdeling = 'HOL' then 106 when CodeSubAfdeling = 'HOR' then 107 when CodeSubAfdeling = 'HOT' then 108 when CodeSubAfdeling = 'HOU' then 109 when CodeSubAfdeling = 'HRM' then 110 when CodeSubAfdeling = 'HSD' then 111 when CodeSubAfdeling = 'HSL' then 112 when CodeSubAfdeling = 'HTL' then 113 when CodeSubAfdeling = 'HUI' then 114 when CodeSubAfdeling = 'HUR' then 115 when CodeSubAfdeling = 'HW ' then 116 when CodeSubAfdeling = 'HWL' then 117 when CodeSubAfdeling = 'HYG' then 118 when CodeSubAfdeling = 'HZG' then 119 when CodeSubAfdeling = 'IDC' then 120 when CodeSubAfdeling = 'IEL' then 121 when CodeSubAfdeling = 'IIR' then 122 when CodeSubAfdeling = 'IJS' then 123 when CodeSubAfdeling = 'IME' then 124 when CodeSubAfdeling = 'IN ' then 125 when CodeSubAfdeling = 'INI' then 126 when CodeSubAfdeling = 'INL' then 127 when CodeSubAfdeling = 'INS' then 128 when CodeSubAfdeling = 'INT' then 129 when CodeSubAfdeling = 'IT ' then 130 when CodeSubAfdeling = 'ITB' then 131 when CodeSubAfdeling = 'ITI' then 132 when CodeSubAfdeling = 'JA ' then 133 when CodeSubAfdeling = 'JUL' then 134 when CodeSubAfdeling = 'JUR' then 135 when CodeSubAfdeling = 'JUW' then 136 when CodeSubAfdeling = 'KAL' then 137 when CodeSubAfdeling = 'KAP' then 138 when CodeSubAfdeling = 'KNS' then 139 when CodeSubAfdeling = 'KPB' then 140 when CodeSubAfdeling = 'KR ' then 141 when CodeSubAfdeling = 'KTA' then 142 when CodeSubAfdeling = 'KTL' then 143 when CodeSubAfdeling = 'KUN' then 144 when CodeSubAfdeling = 'KWA' then 145 when CodeSubAfdeling = 'LAN' then 146 when CodeSubAfdeling = 'LAS' then 147 when CodeSubAfdeling = 'LDS' then 148 when CodeSubAfdeling = 'LOG' then 149 when CodeSubAfdeling = 'MAN' then 150 when CodeSubAfdeling = 'MEC' then 151 when CodeSubAfdeling = 'MED' then 152 when CodeSubAfdeling = 'MEL' then 153 when CodeSubAfdeling = 'MET' then 154 when CodeSubAfdeling = 'MGV' then 155 when CodeSubAfdeling = 'MIL' then 156 when CodeSubAfdeling = 'MM ' then 157 when CodeSubAfdeling = 'MOC' then 158 when CodeSubAfdeling = 'MSF' then 159 when CodeSubAfdeling = 'MSR' then 160 when CodeSubAfdeling = 'MSW' then 161 when CodeSubAfdeling = 'NL ' then 162 when CodeSubAfdeling = 'NOV' then 163 when CodeSubAfdeling = 'NOX' then 164 when CodeSubAfdeling = 'NRS' then 165 when CodeSubAfdeling = 'ODH' then 166 when CodeSubAfdeling = 'OFF' then 167 when CodeSubAfdeling = 'OOI' then 168 when CodeSubAfdeling = 'OPS' then 169 when CodeSubAfdeling = 'ORG' then 170 when CodeSubAfdeling = 'OS ' then 171 when CodeSubAfdeling = 'P ' then 172 when CodeSubAfdeling = 'PED' then 173 when CodeSubAfdeling = 'PER' then 174 when CodeSubAfdeling = 'PO ' then 175 when CodeSubAfdeling = 'POP' then 176 when CodeSubAfdeling = 'PPS' then 177 when CodeSubAfdeling = 'PRD' then 178 when CodeSubAfdeling = 'PRG' then 179 when CodeSubAfdeling = 'PRM' then 180 when CodeSubAfdeling = 'PRS' then 181 when CodeSubAfdeling = 'PRV' then 182 when CodeSubAfdeling = 'PRX' then 183 when CodeSubAfdeling = 'PVZ' then 184 when CodeSubAfdeling = 'PWU' then 185 when CodeSubAfdeling = 'RED' then 186 when CodeSubAfdeling = 'REL' then 187 when CodeSubAfdeling = 'REN' then 188 when CodeSubAfdeling = 'RES' then 189 when CodeSubAfdeling = 'RET' then 190 when CodeSubAfdeling = 'RLT' then 191 when CodeSubAfdeling = 'RO ' then 192 when CodeSubAfdeling = 'RPA' then 193 when CodeSubAfdeling = 'RU ' then 194 when CodeSubAfdeling = 'RUW' then 195 when CodeSubAfdeling = 'SAC' then 196 when CodeSubAfdeling = 'SAF' then 197 when CodeSubAfdeling = 'SCE' then 198 when CodeSubAfdeling = 'SCH' then 199 when CodeSubAfdeling = 'SCL' then 200 when CodeSubAfdeling = 'SCO' then 201 when CodeSubAfdeling = 'SEC' then 202 when CodeSubAfdeling = 'SEM' then 203 when CodeSubAfdeling = 'SFI' then 204 when CodeSubAfdeling = 'SFV' then 205 when CodeSubAfdeling = 'SIE' then 206 when CodeSubAfdeling = 'SLA' then 207 when CodeSubAfdeling = 'SLL' then 208 when CodeSubAfdeling = 'SLV' then 209 when CodeSubAfdeling = 'SMA' then 210 when CodeSubAfdeling = 'SME' then 211 when CodeSubAfdeling = 'SOM' then 212 when CodeSubAfdeling = 'SOR' then 213 when CodeSubAfdeling = 'SP ' then 214 when CodeSubAfdeling = 'SPE' then 215 when CodeSubAfdeling = 'SRZ' then 216 when CodeSubAfdeling = 'STN' then 217 when CodeSubAfdeling = 'SVG' then 218 when CodeSubAfdeling = 'SWI' then 219 when CodeSubAfdeling = 'TAV' then 220 when CodeSubAfdeling = 'TDM' then 221 when CodeSubAfdeling = 'TEA' then 222 when CodeSubAfdeling = 'TEX' then 223 when CodeSubAfdeling = 'TLT' then 224 when CodeSubAfdeling = 'TRA' then 225 when CodeSubAfdeling = 'TRM' then 226 when CodeSubAfdeling = 'TS ' then 227 when CodeSubAfdeling = 'TTT' then 228 when CodeSubAfdeling = 'TU ' then 229 when CodeSubAfdeling = 'TVR' then 230 when CodeSubAfdeling = 'TXT' then 231 when CodeSubAfdeling = 'VAA' then 232 when CodeSubAfdeling = 'VAK' then 233 when CodeSubAfdeling = 'VAS' then 234 when CodeSubAfdeling = 'VDG' then 235 when CodeSubAfdeling = 'VDL' then 236 when CodeSubAfdeling = 'VEB' then 237 when CodeSubAfdeling = 'VEI' then 238 when CodeSubAfdeling = 'VEL' then 239 when CodeSubAfdeling = 'VID' then 240 when CodeSubAfdeling = 'VIS' then 241 when CodeSubAfdeling = 'VLI' then 242 when CodeSubAfdeling = 'VRA' then 243 when CodeSubAfdeling = 'VZK' then 244 when CodeSubAfdeling = 'VZS' then 245 when CodeSubAfdeling = 'WBH' then 246 when CodeSubAfdeling = 'WEB' then 247 when CodeSubAfdeling = 'WEM' then 248 when CodeSubAfdeling = 'WKN' then 249 when CodeSubAfdeling = 'WMC' then 250 when CodeSubAfdeling = 'WST' then 251 when CodeSubAfdeling = 'WW ' then 252 when CodeSubAfdeling = 'WWM' then 253 when CodeSubAfdeling = 'ZB ' then 254 when CodeSubAfdeling = 'ZW ' then 255 else '' end as int) as CodeSubafdelingNummer , CAST(CASE When CodeSoortCursus = 'AV' then 1 When CodeSoortCursus = 'DA' then 1 When CodeSoortCursus = 'DAG' then 1 When CodeSoortCursus = 'NA' then 1 When CodeSoortCursus = 'NB' then 1 When CodeSoortCursus = 'NM' then 1 When CodeSoortCursus = 'VDO' then 1 When CodeSoortCursus = 'VM' then 1 When CodeSoortCursus = 'ZAT' then 1 When CodeSoortCursus = 'ZATVM' then 1 else '' end as int) as CodeSoortCursusNummer , UitvCentrum , Aard  FROM dbo.Cursussen WHERE merk='" + cboMerk.SelectedItem + "' AND dag='" + cboDag.SelectedItem + "' AND (Aard NOT IN (15, 29, 14, 58, 12, 13)) AND (OmschrijvingComm NOT LIKE '%SELOR%') AND (OmschrijvingComm NOT LIKE '%Bekwaamheidsattest%') AND (OmschrijvingComm NOT LIKE '%stage%') AND (OmschrijvingComm NOT LIKE '%proef%') AND (OmschrijvingComm NOT LIKE '%attest%') AND (OmschrijvingComm NOT LIKE '%aanvullende praktijk%') AND (OmschrijvingComm NOT LIKE '%eindwerk%') AND (OmschrijvingComm NOT LIKE '%AP%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'POC%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'C.I.%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'P.S.%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'LeReN%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'Lerend%' COLLATE SQL_Latin1_General_CP1_CS_AS) AND (OmschrijvingComm NOT LIKE 'Iedereen leert%') AND (OmschrijvingComm NOT LIKE 'Bedrijvig Brugge%') AND (OmschrijvingComm NOT LIKE '%testavond%') AND (OmschrijvingComm NOT LIKE 'Talent%') AND (OmschrijvingComm NOT LIKE '%Spoor 1%') AND (OmschrijvingComm NOT LIKE '%Spoor 2%') AND (OmschrijvingComm NOT LIKE '%Spoor 3%') AND (OmschrijvingComm NOT LIKE '%Spoor 4%') AND (OmschrijvingComm NOT LIKE '%Spoor 5%') AND year(startdatum) < 2015")
                    Dim subafds = sql.getAll(SQLCommandlbl)
                    For i As Integer = 0 To subafds.Count - 1
                        Dim predictor As New newPredictor
                        Dim tempList = subafds(i)
                        Dim p = Not (predictor.predict(tempList(1), tempList(2), tempList(3), tempList(4), tempList(5), tempList(6), tempList(7), tempList(8)))
                        Dim sql2 = sql.getArrayList("SELECT codeingetrokken from cursussen where Opleidingsnr = " + tempList(0))(0).ToString
                        If (p = True And sql2.Equals("Ja")) Or (p = False And sql2.Equals("Nee")) Then
                            cor += 1
                        End If
                        dgvResult.Rows.Add(tempList(0), p.ToString, sql2, (p = True And sql2.Equals("Ja")) Or (p = False And sql2.Equals("Nee")))

                    Next
                    Label1.Text = cor.ToString
                ElseIf ComboBox1.SelectedItem.Equals("Apriori (association Rule Learning)") Then
                    MessageBox.Show("Sorry, dit werkt niet")
                    'Dim data = {{1, 3, 4, 0}, {2, 3, 5, 0}, {1, 2, 3, 5}, {2, 5, 0, 0}}
                    'Dim ap As New Apriori(data)
                    'For Each i In ap.joinTwo()
                    '    Dim lviTXT = ""
                    '    For Each a In i
                    '        ap.scanD(0.5)
                    '        lviTXT += a.ToString
                    '    Next
                    '    Dim lvi = New ListViewItem(lviTXT)
                    'lvResult.Items.AddRange(New ListViewItem() {lvi})
                    'Next
                End If
            End If

        Catch ex As ApplicationException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub nonLinearRegressionTest()

        ' Toon grafiek voor i
        Dim showForI As Int16 = 4

        Dim subAfds As New ArrayList
        Dim Sql = New SQLUtil
        Dim filters = root.getFilters
        Dim fil As String = ""
        Dim startJaar As Int16 = 2006
        Dim berekenJaar As Int16 = 2015
        Dim minAantalCurs As Integer = 5

        dgvResult.DataSource = Nothing
        dgvResult.Columns.Add("Subafdeling", "Subafdeling")
        dgvResult.Columns.Add("Voorspeld", "Voorspeld")
        dgvResult.Columns.Add("Echt", "Echt")

        chartBerekend.Titles.Clear()
        'cursusChart.Titles.Clear()
        chartBerekend.Series.Clear()
        'cursusChart.Series.Clear()
        'cursusChart.Titles.Add("Werkelijk")
        chartBerekend.Titles.Add("Berekend")
        'Create a new series and add data points to it.


        ' Zijn er filters ingesteld?
        If filters Is Nothing Then
            'Haal alle subafdelingen op waar er, zonder filters, meer minAantalCurs dan cursussen zijn (voor preciesere meting worden onder  cursussen niet in rekening gebracht)
            subAfds.AddRange(Sql.getArrayList("select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and year(StartDatum) = 2015 group by codesubafdeling having count(*) > " + minAantalCurs.ToString).ToArray())
        Else
            For Each filIt As FilterItem In filters
                fil += " AND " + filIt.kolom + " " + filIt.factor + " " + filIt.filter
            Next
            'Haal alle subafdelingen op waar er, met filters, meer minAantalCurs dan cursussen zijn (voor preciesere meting worden onder  cursussen niet in rekening gebracht)
            Dim con As String = "select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and year(StartDatum) = 2015 " + fil + "group by codesubafdeling having count(*) > " + minAantalCurs.ToString
            subAfds.AddRange(Sql.getArrayList(con).ToArray())
        End If

        pgb.Minimum = 0
        If subAfds.Count = 0 Then
            pgb.Maximum = 1
        Else
            pgb.Maximum = subAfds.Count - 1
        End If

        ' Overloop alle afdelingen
        For i As Integer = 0 To subAfds.Count - 1
            Dim cursus As Dictionary(Of Integer, Parameter)


            Dim x_data As New List(Of Double) ' Jaar
            Dim y_data As New List(Of Double) ' waarde


            Dim r, a As New Series
            r.Name = "realiteit " + subAfds(i)
            a.Name = "Algoritme " + subAfds(i)
            If (i = showForI) Then
                'Change to a line graph.
                'a.ChartType = SeriesChartType.Line
                'r.ChartType = SeriesChartType.Line
            End If

            ' Haal aantal cursussen en aantal doorgegane cursussen op per jaar voor deze subafdeling
            cursus = TestBLL.GetAantalCursussenPerSubAfdelingPerJaarTotJaar(subAfds(i), fil, berekenJaar)

            Dim j As Integer = 0
            Dim lastYear As Double = 0
            For Each curs As KeyValuePair(Of Integer, Parameter) In cursus

                ' Zijn er voor dit jaar cursussen geweest? voeg ze toe aan list
                If ((curs.Key) = (startJaar + j)) Then
                    y_data.Add(curs.Value.getNietGeschrapt)
                    x_data.Add(j + 1)

                    If (i = showForI) Then
                        r.Points.AddXY(j, curs.Value.getNietGeschrapt)
                    End If

                End If

                lastYear = curs.Key
                j += 1
            Next



            If (i = showForI) Then
                For x As Double = 0.0 To x_data.Count - 1
                    a.Points.AddXY(x_data.Item(x), berekenJaarVoor(x_data.Item(x) - 1, y_data, x_data))
                Next
                chartBerekend.Series.Add(a)
                'Add the series to the Chart1 control.
                'cursusChart.Series.Add(r)
            End If



            Dim voorspelling As Double = berekenJaarVoor((berekenJaar - cursus.First.Key + 1), y_data, x_data)

            Dim cursusPara As Parameter = TestBLL.GetAantalCursussenPerSubAfdelingVoorJaar(subAfds(i), fil, berekenJaar)

            Dim toAdd = ""
            If (cursusPara IsNot Nothing) Then
                toAdd = cursusPara.getNietGeschrapt
            Else
                toAdd = "Geen data voor berekend jaar"
            End If
            dgvResult.Rows.Add(subAfds(i).ToString, voorspelling.ToString, toAdd)
            pgb.Value = i
        Next

    End Sub

    ''' <summary>
    ''' Berekend de waarde voor het te berekenen jaar wanneer lastYear het laatste jaar is met waarde
    ''' </summary>
    ''' <param name="findForX">het te brekenen jaar</param>
    ''' <param name="y_data">De Y waardes met het aantal cursussen dat is kunnen door gaan</param>
    ''' <param name="x_data">De X waardes voor het jaar waarin de cursussen zijn doorgegeaan</param>
    ''' <returns>Geeft de voorspelde waarde terug volgens een niet linaire functie verkregen door de gegeven data</returns>
    Private Function berekenJaarVoor(findForX As Short, y_data As List(Of Double), x_data As List(Of Double)) As Double

        ' TODO rekening houden met het jaar die als laatst werd gegeven en het jaar die berekend moet worden
        If (x_data.Count <> y_data.Count) Then
            Throw New IndexOutOfRangeException("de x_data en y_data hebben niet even veel waardes")
        End If


        ' Om problemen te voorkomen wanneer voor x=0 iets moet worden berekend zullen alle waardes 1 index opschuiven
        Dim xfix As New List(Of Double)
        xfix.Add(0)
        xfix.AddRange(x_data)

        Dim yfix As New List(Of Double)
        yfix.Add(0)
        yfix.AddRange(y_data)

        findForX += 1


        Dim x As Double = x_data.Count
        Dim y As Double = 0
        For i As Double = 1 To x - 1
            Dim deler As Double = 1
            Dim noemer As Double = 1

            For j As Double = 1 To x - 1
                If (i <> j) Then
                    noemer *= (findForX - xfix.Item(j))
                    deler *= (xfix.Item(i) - xfix.Item(j))
                    Dim stopHere As New Double
                End If
            Next


            y += noemer / deler * yfix.Item(i)

        Next
        '' 
        '' Formule: http://mathworld.wolfram.com/LagrangeInterpolatingPolynomial.html
        '' 
        ''          (x-x2)(x-x3)...(x-xn)           (x-x1)(x-x3)...(x-xn)                 (x-x1)(x-x2)...(x-x(n-1))
        '' P(x) = ------------------------ * y1 + ------------------------ * y2 + ... + ---------------------------- * yn
        ''        (x1-x2)(x1-x3)...(x1-xn)        (x2-x1)(x2-x3)...(x2-xn)              (xn-x1)(xn-x2)...(xn-x(n-1))
        '' 




        Return y
    End Function


    Public Sub testAlgoritme()
        Dim testX As New List(Of Double)
        Dim testY As New List(Of Double)

        testX.Add(18.3447008513705)
        testX.Add(79.8653766584296)
        testX.Add(85.0978750911023)
        testX.Add(10.5211032678597)
        testX.Add(44.4555865329731)
        testX.Add(69.5672625121865)
        testX.Add(8.95984867894632)
        testX.Add(86.1969639982446)
        testX.Add(66.8565569431935)
        testX.Add(16.8749080688385)
        testX.Add(52.2697069637002)
        testX.Add(93.916819815053)
        testX.Add(24.3466884170974)
        testX.Add(5.11781548243186)
        testX.Add(25.126222222172)
        testX.Add(34.0372283193021)
        testX.Add(61.4445490763988)
        testX.Add(42.7035769964426)
        testX.Add(39.5308929765408)
        testX.Add(29.9884494188329)

        testY.Add(5.07222770500145)
        testY.Add(7.15881537028438)
        testY.Add(7.26276462771072)
        testY.Add(4.25458132218093)
        testY.Add(6.28186665811137)
        testY.Add(6.91178733537563)
        testY.Add(4.04380974743643)
        testY.Add(7.25952869839834)
        testY.Add(6.89808922760562)
        testY.Add(4.87441797865311)
        testY.Add(6.51794377384427)
        testY.Add(7.34341950185679)
        testY.Add(5.43164863364436)
        testY.Add(3.38463431911083)
        testY.Add(5.46422771944839)
        testY.Add(5.90043172986688)
        testY.Add(6.80389562051497)
        testY.Add(6.19326313529158)
        testY.Add(6.07039770693631)
        testY.Add(5.73679247382638)


        Dim berekenX = InputBox("Geef een getal")
        Dim y = berekenJaarVoor(berekenX, testY, testX)
        MessageBox.Show("Waarde voor X = " + berekenX.ToString + " is " + y.ToString)

    End Sub

    Private Sub dataMiningPrediction()

        ' http://www.cs.ccsu.edu/~markov/ccsu_courses/DataMining-8.html

        ' Kolom naam aanmaken
        dgvResult.DataSource = Nothing
        dgvResult.Columns.Add("Merken", "Merken")
        dgvResult.Columns.Add("Uitvoerend centrum", "Uitvoerend centrum")
        dgvResult.Columns.Add("Sub afdeling", "Sub afdeling")
        dgvResult.Columns.Add("Maand", "Maand")
        dgvResult.Columns.Add("Dag", "Dag")
        dgvResult.Columns.Add("Voorspelling", "Voorspelling")
        dgvResult.Columns.Add("Echt", "Echt")
        dgvResult.Columns.Add("Klopt voorpelling", "Klopt voorpelling")


        pgb.Value = 0
        Dim merken As New MerkBLL
        Dim totalCounter = 0
        Dim filters = root.getFilters()
        Dim tijdelijkefilters As New ArrayList
        Dim merkFilter As New FilterItem()
        Dim sql As New SQLUtil
        Dim trues = 0
        Dim falses = 0
        Dim startTime = Now
        Dim everyMerk = merken.getAll(2015, filters)
        Dim gekozenMerk, gekozenDag, gekozenCentrum, gekozenMaand As FilterItem

        ' Is er een item in de dropdown list geselecteerd? voeg hem dan toe aan de filter
        If (cboMerk.SelectedItem <> Nothing) Then
            gekozenMerk = New FilterItem("Merk", "=", ("'" + cboMerk.SelectedItem.ToString) + "'")
            filters.Add(gekozenMerk)
        End If

        If (cboDag.SelectedItem <> Nothing) Then
            gekozenDag = New FilterItem("Dag", "=", ("'" + cboDag.SelectedItem.ToString) + "'")
            filters.Add(gekozenDag)
        End If

        If (cboUitvoerendCentrum.SelectedItem <> Nothing) Then
            gekozenCentrum = New FilterItem("UitvCentrumOmsch", "=", ("'" + cboUitvoerendCentrum.SelectedItem.ToString) + "'")
            filters.Add(gekozenCentrum)
        End If

        If ((cbbMonth.SelectedItem).Value <> Nothing) Then
            gekozenMaand = New FilterItem("month(startdatum)", "=", ("'" + (cbbMonth.SelectedItem).Value) + "'")
            filters.Add(gekozenMaand)
        End If

        ' TO/DO Niet telkens verbinding naar database leggen, eens proberen grote hoeveelheden data af te halen en daar mee te werken
        ' Misschien werkt dit rapper om resultaten te bereken
        ' Ja dus, zie dataMiningPrediction2()

        pgb.Minimum = 0
        pgb.Maximum = everyMerk.Count


        For Each merk In everyMerk
            My.Application.Log.WriteEntry(merk.ToString)
            Dim AllData As New AllDataBLL
            Dim merkJA = AllData.getPercentageJa(2015, "merk", merk.ToString, filters)
            Dim merkNEE = AllData.getPErcentageNee(2015, "merk", merk.ToString, filters)
            Dim uitvCentrum As New ParameterParent("UitvCentrumOmsch")
            Dim everyUitv = uitvCentrum.getAall(2015, filters)
            merkFilter = New FilterItem("merk", "=", "'" + merk.ToString + "'")
            filters.Add(merkFilter)
            pgb.Maximum += everyUitv.Count


            For Each centrum In everyUitv
                My.Application.Log.WriteEntry(merk.ToString + " " + centrum.ToString)
                Dim centrumJA = AllData.getPercentageJa(2015, "UitvCentrumOmsch", centrum.ToString, filters)
                Dim centrumNEE = AllData.getPErcentageNee(2015, "UitvCentrumOmsch", centrum.ToString, filters)
                Dim centrumFilter = New FilterItem("UitvCentrumOmsch", "=", "'" + centrum.ToString + "'")
                filters.Add(centrumFilter)
                Dim subafds As New subAfdBll
                Dim everySub = subafds.getAallSubAfds(2015, filters)
                pgb.Maximum += everySub.Count


                For Each subafd In everySub
                    My.Application.Log.WriteEntry(merk.ToString + " " + centrum.ToString + " " + subafd.ToString)
                    Dim subafdJA = AllData.getPercentageJa(2015, "CodeSubafdeling", subafd.ToString, filters)
                    Dim subafdNEE = AllData.getPErcentageNee(2015, "CodeSubafdeling", subafd.ToString, filters)
                    Dim subafdFilter As New FilterItem("CodeSubafdeling", "=", "'" + subafd.ToString + "'")
                    filters.Add(subafdFilter)
                    Dim startmaand As New ParameterParent("month(startdatum)")
                    Dim everyMonth = startmaand.getAall(2015, filters)
                    pgb.Maximum += everyMonth.Count


                    For Each maand In everyMonth
                        My.Application.Log.WriteEntry(merk.ToString + " " + centrum.ToString + " " + subafd.ToString + " " + maand.ToString)
                        Dim maandJA = AllData.getPercentageJa(2015, "month(startdatum)", maand.ToString, filters)
                        Dim maandNEE = AllData.getPErcentageNee(2015, "month(startdatum)", maand.ToString, filters)
                        Dim lesdag As New DagBll()
                        Dim maandFilters As New FilterItem("month(startdatum)", "=", ("'" + (cbbMonth.SelectedItem).Value + "'"))
                        filters.Add(maandFilters)
                        pgb.Maximum += lesdag.getAll(2015, filters).Count
                        Dim allDay = lesdag.getAll(2015, filters)
                        filters.Add(maandFilters)
                        pgb.Maximum += allDay.Count


                        For Each dag In lesdag.getAll(2015, filters)
                            Dim dagJA = AllData.getPercentageJa(2015, "dag", dag.ToString, filters)
                            Dim dagNEE = AllData.getPErcentageNee(2015, "dag", dag.ToString, filters)
                            My.Application.Log.WriteEntry(merk.ToString + " " + centrum.ToString + " " + subafd.ToString + " " + maand.ToString + " " + dag.ToString)

                            'BEREKEN VERWACHTE WAARDE

                            Dim berekendJa = addIfNotNaN(merkJA) * addIfNotNaN(centrumJA) * addIfNotNaN(subafdJA) * addIfNotNaN(maandJA) * addIfNotNaN(dagJA) * addIfNotNaN(AllData.getAllJa(2015, filters))
                            Dim berekendNee = addIfNotNaN(merkNEE) * addIfNotNaN(centrumNEE) * addIfNotNaN(subafdNEE) * addIfNotNaN(maandNEE) * addIfNotNaN(dagNEE) * addIfNotNaN(AllData.getAllNee(2015, filters))
                            Dim gaatdoor = berekendNee / (berekendJa + berekendNee)
                            Dim prospector As New Prospect
                            Dim alleNees As New ArrayList({merkNEE, centrumNEE, subafdNEE, maandNEE, dagNEE, AllData.getAllNee(2015, filters)})
                            Dim bereikNee = prospector.certainty(alleNees, gaatdoor)
                            'BEREKEN ECHTE WAARDE
                            Dim dick As Dictionary(Of String, Parameter)
                            If filters Is Nothing Then
                                dick = sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND year(cc.StartDatum) = year(c.StartDatum)) as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE year(c.StartDatum) =  2015 group by year(startdatum)")
                            Else
                                Dim fil = ""
                                For Each filIt As FilterItem In filters
                                    fil += " AND " + filIt.kolom + " " + filIt.factor + " " + filIt.filter
                                Next
                                dick = sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND year(cc.StartDatum) = year(c.StartDatum) " + fil + ") as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE year(c.StartDatum) =  2015  " + fil + " group by year(startdatum)")
                            End If
                            Dim y As Double
                            If dick IsNot Nothing Then
                                For Each kvp As KeyValuePair(Of String, Parameter) In dick
                                    y = CDbl(kvp.Value.berekenPercentage)
                                Next
                            End If
                            Dim kloptHet = bereikNee.valtTussen(y)
                            If kloptHet Then
                                trues += 1
                            Else
                                falses += 1
                            End If

                            dgvResult.Rows.Add(merk.ToString, centrum.ToString, subafd.ToString, maand.ToString, dag.ToString, bereikNee.ToString, y.ToString, kloptHet.ToString)
                            totalCounter += 1
                            pgb.Value += 1
                        Next

                        filters.Remove(maandFilters)
                        pgb.Value += 1
                    Next

                    filters.Remove(subafdFilter)
                    pgb.Value += 1
                Next

                filters.Remove(centrumFilter)
                pgb.Value += 1
            Next

            filters.Remove(merkFilter)
            pgb.Value += 1
        Next
        'gekozenMerk, gekozenDag, gekozenCentrum, gekozenMaand
        If gekozenMerk IsNot Nothing Then
            filters.Remove(gekozenMerk)
        End If
        If gekozenDag IsNot Nothing Then
            filters.Remove(gekozenDag)
        End If
        If gekozenCentrum IsNot Nothing Then
            filters.Remove(gekozenCentrum)
        End If
        If gekozenMaand IsNot Nothing Then
            filters.Remove(gekozenMaand)
        End If


        MessageBox.Show("Tijd verstreken = " + (Now - startTime).ToString)
        Label1.Text = "Totaal: " + totalCounter.ToString
    End Sub



    Private Sub dataMiningPrediction2()

        Dim trues = 0
        Dim falses = 0
        Dim f As String
        Dim listOfAllItems As New List(Of DataMiningPrediction2)
        Dim startTime = Now
        Dim versch As New Dictionary(Of Double, Integer)

        ' Lijst om te tellen hoeveel cursussen van elk item niet geschrapt werden
        Dim dicMerkW As New Dictionary(Of String, Int32)
        Dim dicUitvW As New Dictionary(Of String, Int32)
        Dim dicMaandW As New Dictionary(Of Int16, Int32)
        Dim dicDagW As New Dictionary(Of String, Int32)
        Dim dicSubW As New Dictionary(Of String, Int32)

        ' Lijst om te tellen hoeveel cursussen van elk item wel geschrapt werden
        Dim dicMerkN As New Dictionary(Of String, Int32)
        Dim dicUitvN As New Dictionary(Of String, Int32)
        Dim dicMaandN As New Dictionary(Of Int16, Int32)
        Dim dicDagN As New Dictionary(Of String, Int32)
        Dim dicSubN As New Dictionary(Of String, Int32)

        Dim atlDoorgg As Int32
        Dim atlNietDgg As Int32
        Dim standaardAfwijking As New List(Of Double)

        Dim cIn As Integer = 0
        Dim cOut As Integer = 0
        Dim ligtTussen As Integer = 10

        ' Kolom naam aanmaken
        initDataGridView()


        f = createFilterString(root.getFilters())

        listOfAllItems = TestBLL.GetAllCursForAllVar(f)


        pgb.Value = 0
        pgb.Minimum = 0
        pgb.Maximum = (listOfAllItems.Count) * 2

        ' Steek het aantal doorgegaan en aantal niet doorgegaan van ieder item in een dictionary
        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim merk = item.getMerk()
            Dim uitvCentr = item.getUitvoerCentrum
            Dim maand = item.getMaand
            Dim dag = item.getDag
            Dim codeSubAfd = item.getCodeSubAfdeling
            Dim nietDoor = item.getTotaal - item.getDoorgegaan
            Dim doorgegaan = item.getDoorgegaan
            ' Lijst per merk aanvullen
            If Not dicMerkW.ContainsKey(merk) Then
                dicMerkW.Add(merk, doorgegaan)

                ' Som van aantal doorgegane cursussen
                atlDoorgg += doorgegaan
            Else
                dicMerkW(merk) += doorgegaan

                ' Som van aantal doorgegane cursussen
                atlDoorgg += doorgegaan
            End If

            ' Lijst per merk aanvullen
            If Not dicMerkN.ContainsKey(merk) Then
                dicMerkN.Add(merk, nietDoor)

                ' Som van aantal Geschrapte cursussen
                atlNietDgg += nietDoor
            Else
                dicMerkN(merk) += nietDoor

                ' Som van aantal Geschrapte cursussen
                atlNietDgg += nietDoor
            End If

            ' Lijst per uitvoercentrum aanvullen
            If Not dicUitvW.ContainsKey(uitvCentr) Then
                dicUitvW.Add(uitvCentr, doorgegaan)
            Else
                dicUitvW(uitvCentr) += doorgegaan
            End If

            If Not dicUitvN.ContainsKey(uitvCentr) Then
                dicUitvN.Add(uitvCentr, nietDoor)
            Else
                dicUitvN(uitvCentr) += nietDoor
            End If


            ' Lijst per maand aanvullen
            If Not dicMaandW.ContainsKey(maand) Then
                dicMaandW.Add(maand, doorgegaan)
            Else
                dicMaandW(maand) += doorgegaan
            End If

            If Not dicMaandN.ContainsKey(maand) Then
                dicMaandN.Add(maand, nietDoor)
            Else
                dicMaandN(maand) += nietDoor
            End If


            ' Lijst per Dag aanvullen
            If Not dicDagW.ContainsKey(dag) Then
                dicDagW.Add(dag, doorgegaan)
            Else
                dicDagW(dag) += doorgegaan
            End If

            If Not dicDagN.ContainsKey(dag) Then
                dicDagN.Add(dag, nietDoor)
            Else
                dicDagN(dag) += nietDoor
            End If


            ' Lijst per subafdeling aanvullen
            If Not dicSubW.ContainsKey(codeSubAfd) Then
                dicSubW.Add(codeSubAfd, doorgegaan)
            Else
                dicSubW(codeSubAfd) += doorgegaan
            End If

            If Not dicSubN.ContainsKey(codeSubAfd) Then
                dicSubN.Add(codeSubAfd, nietDoor)
            Else
                dicSubN(codeSubAfd) += nietDoor
            End If

            pgb.Value += 1
        Next

        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim j1, j2, j3, j4, j5, j6 As Double
            Dim n1, n2, n3, n4, n5, n6 As Double

            j1 = (dicMerkW(item.getMerk) / atlDoorgg)
            j2 = (dicSubW(item.getCodeSubAfdeling) / atlDoorgg)
            j3 = (dicMaandW(item.getMaand) / atlDoorgg)
            j4 = (dicDagW(item.getDag) / atlDoorgg)
            j5 = (dicUitvW(item.getUitvoerCentrum) / atlDoorgg)
            j6 = (atlDoorgg / (atlDoorgg + atlNietDgg))

            n1 = (dicMerkN(item.getMerk) / atlNietDgg)
            n2 = (dicSubN(item.getCodeSubAfdeling) / atlNietDgg)
            n3 = (dicMaandN(item.getMaand) / atlNietDgg)
            n4 = (dicDagN(item.getDag) / atlNietDgg)
            n5 = (dicUitvN(item.getUitvoerCentrum) / atlNietDgg)
            n6 = (atlNietDgg / (atlDoorgg + atlNietDgg))

            Dim wel As Double = 0
            Dim niet As Double = 0
            If (item.getTotaal <= 12) Then
                wel = ((dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicDagW(item.getDag) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicDagN(item.getDag) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
            ElseIf item.getTotaal <= 15 Then
                wel = ((dicMerkW(item.getMerk) / atlDoorgg) * (dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((dicMerkN(item.getMerk) / atlNietDgg) * (dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
            Else
                wel = ((dicMerkW(item.getMerk) / atlDoorgg) * (dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicDagW(item.getDag) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((dicMerkN(item.getMerk) / atlNietDgg) * (dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicDagN(item.getDag) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))

            End If
            Dim totaal = wel + niet
            item.setKans(wel / (wel + niet))


            ' Verschil
            Dim verschil = Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2)

            standaardAfwijking.Add(Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2))

            verschil = (Math.Round(item.getDoorgegaan / item.getTotaal * 100) - Math.Round(item.getKans * 100))
            If Not versch.ContainsKey(verschil) Then
                versch.Add(verschil, 1)
            Else
                versch(verschil) += 1
            End If

            If verschil > ligtTussen Or verschil < -ligtTussen Then
                cOut += 1
            Else
                cIn += 1
            End If

            pgb.Value += 1
        Next


        ' Teken grafiek
        Dim ver As New Series
        For Each s As KeyValuePair(Of Double, Integer) In versch
            ver.Points.AddXY(s.Key, s.Value)
        Next
        drawBarGraph(ver)



        ' Standaard afwijking berekenen
        Dim deviatie = Math.Round(CalculateStandardDeviation(standaardAfwijking), 3)
        Dim remove As Double = 0
        Dim tVerd As New tVerdeling

        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim afw = tVerd.getTwaarde(0.99, item.getTotaal) * deviatie / Math.Sqrt(item.getTotaal)
            remove += afw

            Dim verschil = Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2)

            Dim echt = (Math.Round(((item.getDoorgegaan / item.getTotaal) * 10000)) / 100)

            ' Bereken de top waarde en onderste waarde van de afwijking, controlleer of deze boven 100 of onder 0 zit en pas deze aan indien nodig
            Dim bEdge = Math.Round(item.getKans * 100 - afw, 2)
            Dim tEdge = Math.Round(item.getKans * 100 + afw, 2)
            If bEdge < 0 Then bEdge = 0
            If tEdge > 100 Then tEdge = 100

            Dim result = "[" + bEdge.ToString + " - " + Math.Round(item.getKans * 100, 2).ToString + " - " + tEdge.ToString + "]"

            Dim kleur As Color
            If echt <= item.getKans * 100 + afw And echt >= item.getKans * 100 - afw Then
                trues += 1
                kleur = Color.LightGreen
                verschil = item.getKans * 100 - echt
            Else
                falses += 1
                kleur = Color.OrangeRed
                If echt < bEdge Then
                    verschil = bEdge - echt
                Else
                    verschil = tEdge - echt
                End If
            End If

            dgvResult.Rows.Add(item.getMerk, item.getUitvoerCentrum, item.getCodeSubAfdeling, item.getMaand.ToString, item.getDag, item.getTotaal.ToString, echt.ToString, result, Math.Round(verschil, 2).ToString)
            dgvResult.Rows(dgvResult.RowCount - 1).DefaultCellStyle.BackColor = kleur
        Next

        dgvResult.Refresh()

        Dim remove2 = remove / listOfAllItems.Count

        lblInfo2.Text = "Binnen -" + ligtTussen.ToString + " en " + ligtTussen.ToString + ": " + cIn.ToString + "    Buiten -" + ligtTussen.ToString + " en " + ligtTussen.ToString + ": " + cOut.ToString + "      Standaardafwijking: " + deviatie.ToString
        Label1.Text = "Totaal = " + listOfAllItems.Count.ToString + " waarvan " + trues.ToString + " correct voorspeld waren en " + falses.ToString + " niet"
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

    Private Sub initDataGridView()
        dgvResult.DataSource = Nothing
        dgvResult.Columns.Clear()
        dgvResult.Columns.Add("merk", "Merk")
        dgvResult.Columns.Add("Uitvoerend centrum", "Uitvoerend centrum")
        dgvResult.Columns.Add("Sub afdeling", "Sub afdeling")
        dgvResult.Columns.Add("Maand", "Maand")
        dgvResult.Columns.Add("Dag", "Dag")
        dgvResult.Columns.Add("Totaal", "Totaal")
        dgvResult.Columns.Add("% Doorgeg", "% Doorgeg")
        dgvResult.Columns.Add("% Berekend", "% Berekend")
        dgvResult.Columns.Add("verschil", "verschil")
        dgvResult.Columns.Add("Temp", "Temp")
        dgvResult.Columns.Add("Temp2", "Temp2")

        dgvResult.Columns(0).Width = 65
        dgvResult.Columns(1).Width = 100
        dgvResult.Columns(2).Width = 50
        dgvResult.Columns(3).Width = 50
        dgvResult.Columns(4).Width = 50
        dgvResult.Columns(5).Width = 40
        dgvResult.Columns(6).Width = 50
        dgvResult.Columns(7).Width = 115
        dgvResult.Columns(8).Width = 50
    End Sub

    Private Sub drawBarGraph(ver As Series)

        chartBerekend.Titles.Clear()
        chartBerekend.Series.Clear()

        chartBerekend.Series.Add(ver)
        Dim Title1 As New Title
        Dim Title2 As New Title
        Title1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left
        Title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Title1.Name = "Aantal"
        Title1.Text = "Aantal"
        Title2.Alignment = System.Drawing.ContentAlignment.BottomCenter
        Title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Title2.Name = "Verschil"
        Title2.Text = "Verschil"
        Me.chartBerekend.Titles.Add(Title1)
        Me.chartBerekend.Titles.Add(Title2)
        Me.Width = 1460
        chartBerekend.ChartAreas(0).AxisX.Interval = 20
        chartBerekend.ChartAreas(0).AxisY.Interval = 10
        chartBerekend.ChartAreas(0).AxisX.Minimum = -100
        chartBerekend.ChartAreas(0).AxisX.Maximum = 100
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Function addIfNotNaN(value As Double) As Double
        If Double.IsNaN(value) Then
            Return 1
        Else
            Return value
        End If
    End Function

    Private Function CalculateStandardDeviation(data As List(Of Double)) As Double
        Dim mean As Double = data.Average()
        Dim squares As New List(Of Double)
        Dim squareAvg As Double

        For Each value As Double In data
            squares.Add(Math.Pow(value - mean, 2))
        Next

        squareAvg = squares.Average()

        Return Math.Sqrt(squareAvg)
    End Function

    Private Sub bayesAndLinear()
        Dim trues = 0
        Dim falses = 0
        Dim f As String
        Dim listOfAllItems As New List(Of DataMiningPrediction2)
        Dim listOfAllItemsWithYear As New List(Of DataMiningPrediction2)
        Dim startTime = Now
        Dim versch As New Dictionary(Of Double, Integer)

        ' Lijst om te tellen hoeveel cursussen van elk item niet geschrapt werden
        Dim dicMerkW As New Dictionary(Of String, Int32)
        Dim dicUitvW As New Dictionary(Of String, Int32)
        Dim dicMaandW As New Dictionary(Of Int16, Int32)
        Dim dicDagW As New Dictionary(Of String, Int32)
        Dim dicSubW As New Dictionary(Of String, Int32)

        ' Lijst om te tellen hoeveel cursussen van elk item wel geschrapt werden
        Dim dicMerkN As New Dictionary(Of String, Int32)
        Dim dicUitvN As New Dictionary(Of String, Int32)
        Dim dicMaandN As New Dictionary(Of Int16, Int32)
        Dim dicDagN As New Dictionary(Of String, Int32)
        Dim dicSubN As New Dictionary(Of String, Int32)

        Dim atlDoorgg As Int32
        Dim atlNietDgg As Int32
        Dim standaardAfwijking As New List(Of Double)

        Dim cIn As Integer = 0
        Dim cOut As Integer = 0
        Dim ligtTussen As Integer = 10

        ' Kolom naam aanmaken
        initDataGridView()


        f = createFilterString(root.getFilters())

        listOfAllItems = TestBLL.GetAllCursForAllVar(f)
        listOfAllItemsWithYear = TestBLL.GetAllCursForAllVarWithYear(f)

        pgb.Value = 0
        pgb.Minimum = 0
        pgb.Maximum = (listOfAllItems.Count) * 2

        ' Steek het aantal doorgegaan en aantal niet doorgegaan van ieder item in een dictionary
        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim merk = item.getMerk()
            Dim uitvCentr = item.getUitvoerCentrum
            Dim maand = item.getMaand
            Dim dag = item.getDag
            Dim codeSubAfd = item.getCodeSubAfdeling
            Dim nietDoor = item.getTotaal - item.getDoorgegaan
            Dim doorgegaan = item.getDoorgegaan
            ' Lijst per merk aanvullen
            If Not dicMerkW.ContainsKey(merk) Then
                dicMerkW.Add(merk, doorgegaan)

                ' Som van aantal doorgegane cursussen
                atlDoorgg += doorgegaan
            Else
                dicMerkW(merk) += doorgegaan

                ' Som van aantal doorgegane cursussen
                atlDoorgg += doorgegaan
            End If

            ' Lijst per merk aanvullen
            If Not dicMerkN.ContainsKey(merk) Then
                dicMerkN.Add(merk, nietDoor)

                ' Som van aantal Geschrapte cursussen
                atlNietDgg += nietDoor
            Else
                dicMerkN(merk) += nietDoor

                ' Som van aantal Geschrapte cursussen
                atlNietDgg += nietDoor
            End If

            ' Lijst per uitvoercentrum aanvullen
            If Not dicUitvW.ContainsKey(uitvCentr) Then
                dicUitvW.Add(uitvCentr, doorgegaan)
            Else
                dicUitvW(uitvCentr) += doorgegaan
            End If

            If Not dicUitvN.ContainsKey(uitvCentr) Then
                dicUitvN.Add(uitvCentr, nietDoor)
            Else
                dicUitvN(uitvCentr) += nietDoor
            End If


            ' Lijst per maand aanvullen
            If Not dicMaandW.ContainsKey(maand) Then
                dicMaandW.Add(maand, doorgegaan)
            Else
                dicMaandW(maand) += doorgegaan
            End If

            If Not dicMaandN.ContainsKey(maand) Then
                dicMaandN.Add(maand, nietDoor)
            Else
                dicMaandN(maand) += nietDoor
            End If


            ' Lijst per Dag aanvullen
            If Not dicDagW.ContainsKey(dag) Then
                dicDagW.Add(dag, doorgegaan)
            Else
                dicDagW(dag) += doorgegaan
            End If

            If Not dicDagN.ContainsKey(dag) Then
                dicDagN.Add(dag, nietDoor)
            Else
                dicDagN(dag) += nietDoor
            End If


            ' Lijst per subafdeling aanvullen
            If Not dicSubW.ContainsKey(codeSubAfd) Then
                dicSubW.Add(codeSubAfd, doorgegaan)
            Else
                dicSubW(codeSubAfd) += doorgegaan
            End If

            If Not dicSubN.ContainsKey(codeSubAfd) Then
                dicSubN.Add(codeSubAfd, nietDoor)
            Else
                dicSubN(codeSubAfd) += nietDoor
            End If

            pgb.Value += 1
        Next

        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim j1, j2, j3, j4, j5, j6 As Double
            Dim n1, n2, n3, n4, n5, n6 As Double

            j1 = (dicMerkW(item.getMerk) / atlDoorgg)
            j2 = (dicSubW(item.getCodeSubAfdeling) / atlDoorgg)
            j3 = (dicMaandW(item.getMaand) / atlDoorgg)
            j4 = (dicDagW(item.getDag) / atlDoorgg)
            j5 = (dicUitvW(item.getUitvoerCentrum) / atlDoorgg)
            j6 = (atlDoorgg / (atlDoorgg + atlNietDgg))

            n1 = (dicMerkN(item.getMerk) / atlNietDgg)
            n2 = (dicSubN(item.getCodeSubAfdeling) / atlNietDgg)
            n3 = (dicMaandN(item.getMaand) / atlNietDgg)
            n4 = (dicDagN(item.getDag) / atlNietDgg)
            n5 = (dicUitvN(item.getUitvoerCentrum) / atlNietDgg)
            n6 = (atlNietDgg / (atlDoorgg + atlNietDgg))

            Dim wel As Double = 0
            Dim niet As Double = 0
            If (item.getTotaal <= 12) Then
                wel = ((dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicDagW(item.getDag) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicDagN(item.getDag) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
            ElseIf item.getTotaal <= 15 Then
                wel = ((dicMerkW(item.getMerk) / atlDoorgg) * (dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((dicMerkN(item.getMerk) / atlNietDgg) * (dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
            Else
                wel = ((dicMerkW(item.getMerk) / atlDoorgg) * (dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicDagW(item.getDag) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((dicMerkN(item.getMerk) / atlNietDgg) * (dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicDagN(item.getDag) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))

            End If
            Dim totaal = wel + niet
            Dim kansBayes = wel / totaal

            Dim xSum As Double = 0
            Dim ySum As Double = 0
            Dim xSquareSum As Double = 1
            Dim xySum As Double = 1
            Dim aantal As Integer = 0
            Dim a As Double
            Dim b As Double

            For Each itemWithYear As DataMiningPrediction2 In listOfAllItemsWithYear
                If (item.getCodeSubAfdeling = itemWithYear.getCodeSubAfdeling) Then
                    If (item.getMaand = itemWithYear.getMaand) Then
                        If (item.getUitvoerCentrum = itemWithYear.getUitvoerCentrum) Then
                            If (item.getDag = itemWithYear.getDag) Then
                                If item.getMerk = itemWithYear.getMerk Then
                                    Dim x = itemWithYear.getJaar
                                    Dim y = (itemWithYear.getDoorgegaan / itemWithYear.getTotaal)

                                    aantal += 1
                                    xySum += (x * y)
                                    xSum += x
                                    ySum += y
                                    xSquareSum += x ^ 2

                                End If
                            End If
                        End If
                    End If
                End If
            Next



            a = (((aantal * xySum) - (xSum * ySum)) / ((aantal * xSquareSum) - xSum ^ 2))
            b = (((xSquareSum * ySum) - (xSum * xySum)) / ((aantal * xSquareSum) - (xSum ^ 2)))

            item.setKans(((kansBayes * 1) + (a * Now.Year + b) * 1) / (1 + 1))
            If (item.getKans > 1) Then item.setKans(1)
            If (item.getKans < 0) Then item.setKans(0)
            'item.setKans(kansBayes)
            item.setJaar(a)
            item.temp = b

            ' Verschil
            Dim verschil = Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2)

            standaardAfwijking.Add(Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2))

            verschil = (Math.Round(item.getDoorgegaan / item.getTotaal * 100) - Math.Round(item.getKans * 100))
            If Not versch.ContainsKey(verschil) Then
                versch.Add(verschil, 1)
            Else
                versch(verschil) += 1
            End If

            If verschil > ligtTussen Or verschil < -ligtTussen Then
                cOut += 1
            Else
                cIn += 1
            End If

            pgb.Value += 1
        Next


        ' Teken grafiek
        Dim ver As New Series
        For Each s As KeyValuePair(Of Double, Integer) In versch
            ver.Points.AddXY(s.Key, s.Value)
        Next
        drawBarGraph(ver)



        ' Standaard afwijking berekenen
        Dim deviatie = Math.Round(CalculateStandardDeviation(standaardAfwijking), 3)
        Dim remove As Double = 0
        Dim tVerd As New tVerdeling

        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim afw = tVerd.getTwaarde(0.995, item.getTotaal) * deviatie / Math.Sqrt(item.getTotaal)
            remove += afw

            Dim verschil = Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2)

            Dim echt = (Math.Round(((item.getDoorgegaan / item.getTotaal) * 10000)) / 100)

            ' Bereken de top waarde en onderste waarde van de afwijking, controlleer of deze boven 100 of onder 0 zit en pas deze aan indien nodig
            Dim bEdge = Math.Round(item.getKans * 100 - afw, 2)
            Dim tEdge = Math.Round(item.getKans * 100 + afw, 2)
            If bEdge < 0 Then bEdge = 0
            If tEdge > 100 Then tEdge = 100

            Dim result = "[" + bEdge.ToString + " - " + Math.Round(item.getKans * 100, 2).ToString + " - " + tEdge.ToString + "]"

            Dim kleur As Color
            If echt <= item.getKans * 100 + afw And echt >= item.getKans * 100 - afw Then
                trues += 1
                kleur = Color.LightGreen
            Else
                falses += 1
                kleur = Color.OrangeRed
                If echt < bEdge Then
                    verschil = bEdge - echt
                Else
                    verschil = tEdge - echt
                End If
            End If

            dgvResult.Rows.Add(item.getMerk, item.getUitvoerCentrum, item.getCodeSubAfdeling, item.getMaand.ToString, item.getDag, item.getTotaal.ToString, echt.ToString, result, verschil.ToString, item.getJaar, item.temp)
            dgvResult.Rows(dgvResult.RowCount - 1).DefaultCellStyle.BackColor = kleur
        Next

        dgvResult.Refresh()

        Dim remove2 = remove / listOfAllItems.Count

        lblInfo2.Text = "Binnen -" + ligtTussen.ToString + " en " + ligtTussen.ToString + ": " + cIn.ToString + "    Buiten -" + ligtTussen.ToString + " en " + ligtTussen.ToString + ": " + cOut.ToString + "      Standaardafwijking: " + deviatie.ToString
        Label1.Text = "Totaal = " + listOfAllItems.Count.ToString + " waarvan " + trues.ToString + " correct voorspeld waren en " + falses.ToString + " niet"
    End Sub


    Private Sub BayersWithYear()

        Dim escalTot As Double = 0
        Dim EVWTot As Double = 0
        Dim SBMTot As Double = 0
        Dim SyntraTot As Double = 0
        Dim escalAant As Integer = 0
        Dim evwAant As Integer = 0
        Dim sbmAant As Integer = 0
        Dim SyntraAant As Integer = 0

        Dim trues = 0
        Dim falses = 0
        Dim f As String
        Dim listOfAllItems As New List(Of DataMiningPrediction2)
        Dim listOfAllItemsPerJaar As New List(Of DataMiningPrediction2)
        Dim startTime = Now
        Dim versch As New Dictionary(Of Double, Integer)

        ' Lijst om te tellen hoeveel cursussen van elk item niet geschrapt werden
        Dim dicMerkW As New Dictionary(Of String, Double)
        Dim dicUitvW As New Dictionary(Of String, Double)
        Dim dicMaandW As New Dictionary(Of Int16, Double)
        Dim dicDagW As New Dictionary(Of String, Double)
        Dim dicSubW As New Dictionary(Of String, Double)
        Dim dicJaarW As New Dictionary(Of Double, Double)

        ' Lijst om te tellen hoeveel cursussen van elk item wel geschrapt werden
        Dim dicMerkN As New Dictionary(Of String, Double)
        Dim dicUitvN As New Dictionary(Of String, Double)
        Dim dicMaandN As New Dictionary(Of Int16, Double)
        Dim dicDagN As New Dictionary(Of String, Double)
        Dim dicSubN As New Dictionary(Of String, Double)
        Dim dicJaarN As New Dictionary(Of Double, Double)

        Dim atlDoorgg As Int32
        Dim atlNietDgg As Int32
        Dim standaardAfwijking As New List(Of Double)

        Dim cIn As Integer = 0
        Dim cOut As Integer = 0
        Dim ligtTussen As Integer = 10

        ' Kolom naam aanmaken
        initDataGridView()

        ' Filter string maken
        f = createFilterString(root.getFilters())

        listOfAllItems = TestBLL.GetAllCursForAllVarWithYear(f)


        pgb.Value = 0
        pgb.Minimum = 0
        pgb.Maximum = (listOfAllItems.Count) * 2

        ' Steek het aantal doorgegaan en aantal niet doorgegaan van ieder item in een dictionary
        For Each item As DataMiningPrediction2 In listOfAllItems
            ' Hoe ver terug kijken?
            Dim y = Now.Year - Convert.ToDouble(Replace(txtJaar.Text, ".", ","))
            Dim wegingPerJaar = Convert.ToDouble(Replace(txtJaarWeging.Text, ".", ","))
            Dim merk = item.getMerk()
            Dim uitvCentr = item.getUitvoerCentrum
            Dim maand = item.getMaand
            Dim dag = item.getDag
            Dim codeSubAfd = item.getCodeSubAfdeling
            Dim nietDoor = item.getTotaal - item.getDoorgegaan
            Dim doorgegaan = item.getDoorgegaan
            Dim jaar = item.getJaar

            If (jaar >= y) Then
                Dim jaarDiff As Integer = jaar - y
                If jaarDiff = 0 Then jaarDiff = 1

                ' Lijst per merk aanvullen
                If Not dicMerkW.ContainsKey(merk) Then
                    dicMerkW.Add(merk, doorgegaan * jaarDiff ^ wegingPerJaar)

                    ' Som van aantal doorgegane cursussen
                    atlDoorgg += doorgegaan
                Else
                    dicMerkW(merk) += doorgegaan * jaarDiff ^ wegingPerJaar

                    ' Som van aantal doorgegane cursussen
                    atlDoorgg += doorgegaan
                End If

                ' Lijst per merk aanvullen
                If Not dicMerkN.ContainsKey(merk) Then
                    dicMerkN.Add(merk, nietDoor * jaarDiff ^ wegingPerJaar)

                    ' Som van aantal Geschrapte cursussen
                    atlNietDgg += nietDoor
                Else
                    dicMerkN(merk) += nietDoor * jaarDiff ^ wegingPerJaar

                    ' Som van aantal Geschrapte cursussen
                    atlNietDgg += nietDoor
                End If

                ' Lijst per uitvoercentrum aanvullen
                If Not dicUitvW.ContainsKey(uitvCentr) Then
                    dicUitvW.Add(uitvCentr, doorgegaan * jaarDiff ^ wegingPerJaar)
                Else
                    dicUitvW(uitvCentr) += doorgegaan * jaarDiff ^ wegingPerJaar
                End If

                If Not dicUitvN.ContainsKey(uitvCentr) Then
                    dicUitvN.Add(uitvCentr, nietDoor * jaarDiff ^ wegingPerJaar)
                Else
                    dicUitvN(uitvCentr) += nietDoor * jaarDiff ^ wegingPerJaar
                End If


                ' Lijst per maand aanvullen
                If Not dicMaandW.ContainsKey(maand) Then
                    dicMaandW.Add(maand, doorgegaan * jaarDiff ^ wegingPerJaar)
                Else
                    dicMaandW(maand) += doorgegaan * jaarDiff ^ wegingPerJaar
                End If

                If Not dicMaandN.ContainsKey(maand) Then
                    dicMaandN.Add(maand, nietDoor * jaarDiff ^ wegingPerJaar)
                Else
                    dicMaandN(maand) += nietDoor * jaarDiff ^ wegingPerJaar
                End If


                ' Lijst per Dag aanvullen
                If Not dicDagW.ContainsKey(dag) Then
                    dicDagW.Add(dag, doorgegaan * jaarDiff ^ wegingPerJaar)
                Else
                    dicDagW(dag) += doorgegaan * jaarDiff ^ wegingPerJaar
                End If

                If Not dicDagN.ContainsKey(dag) Then
                    dicDagN.Add(dag, nietDoor * jaarDiff ^ wegingPerJaar)
                Else
                    dicDagN(dag) += nietDoor * jaarDiff ^ wegingPerJaar
                End If


                ' Lijst per subafdeling aanvullen
                If Not dicSubW.ContainsKey(codeSubAfd) Then
                    dicSubW.Add(codeSubAfd, doorgegaan * jaarDiff ^ wegingPerJaar)
                Else
                    dicSubW(codeSubAfd) += doorgegaan * jaarDiff ^ wegingPerJaar
                End If

                If Not dicSubN.ContainsKey(codeSubAfd) Then
                    dicSubN.Add(codeSubAfd, nietDoor * jaarDiff ^ wegingPerJaar)
                Else
                    dicSubN(codeSubAfd) += nietDoor * jaarDiff ^ wegingPerJaar
                End If

                listOfAllItemsPerJaar.Add(item)
            End If

            pgb.Value += 1
        Next

        listOfAllItems = TestBLL.GetAllCursForAllVar(f)

        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim j1, j2, j3, j4, j5, j6 As Double
            Dim n1, n2, n3, n4, n5, n6 As Double

            j1 = 1
            j2 = 1
            j3 = 1
            j4 = 1
            j5 = 1
            j6 = 1

            n1 = 1
            n2 = 1
            n3 = 1
            n4 = 1
            n5 = 1
            n6 = 1


            If dicMerkW.ContainsKey(item.getMerk) Then j1 = (dicMerkW(item.getMerk) / atlDoorgg)
            If dicSubW.ContainsKey(item.getCodeSubAfdeling) Then j2 = (dicSubW(item.getCodeSubAfdeling) / atlDoorgg)
            If dicMaandW.ContainsKey(item.getMaand) Then j3 = (dicMaandW(item.getMaand) / atlDoorgg)
            If dicDagW.ContainsKey(item.getDag) Then j4 = (dicDagW(item.getDag) / atlDoorgg)
            If dicUitvW.ContainsKey(item.getUitvoerCentrum) Then j5 = (dicUitvW(item.getUitvoerCentrum) / atlDoorgg)
            j6 = (atlDoorgg / (atlDoorgg + atlNietDgg))

            If dicMerkN.ContainsKey(item.getMerk) Then n1 = (dicMerkN(item.getMerk) / atlDoorgg)
            If dicSubN.ContainsKey(item.getCodeSubAfdeling) Then n2 = (dicSubN(item.getCodeSubAfdeling) / atlDoorgg)
            If dicMaandN.ContainsKey(item.getMaand) Then n3 = (dicMaandN(item.getMaand) / atlDoorgg)
            If dicDagN.ContainsKey(item.getDag) Then n4 = (dicDagN(item.getDag) / atlDoorgg)
            If dicUitvN.ContainsKey(item.getUitvoerCentrum) Then n5 = (dicUitvN(item.getUitvoerCentrum) / atlDoorgg)
            n6 = (atlDoorgg / (atlDoorgg + atlNietDgg))

            Dim wel As Double = 0
            Dim niet As Double = 0
            If (item.getTotaal <= 12) Then
                wel = ((j2 / atlDoorgg) * (j3 / atlDoorgg) * (j4 / atlDoorgg) * (j5 / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((n2 / atlNietDgg) * (n3 / atlNietDgg) * (n4 / atlNietDgg) * (n5 / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
            ElseIf item.getTotaal <= 15 Then
                wel = ((j1 / atlDoorgg) * (j2 / atlDoorgg) * (j3 / atlDoorgg) * (j5 / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((n1 / atlNietDgg) * (n2 / atlNietDgg) * (n3 / atlNietDgg) * (n5 / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
            Else
                wel = ((j1 / atlDoorgg) * (j2 / atlDoorgg) * (j3 / atlDoorgg) * (j4 / atlDoorgg) * (j5 / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((n1 / atlNietDgg) * (n2 / atlNietDgg) * (n3 / atlNietDgg) * (n4 / atlNietDgg) * (n5 / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))

            End If
            Dim totaal = wel + niet
            item.setKans(wel / (wel + niet))


            ' Verschil
            Dim verschil = Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2)
            standaardAfwijking.Add(Math.Abs(((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100))
            verschil = (Math.Round(item.getDoorgegaan / item.getTotaal * 100) - Math.Round(item.getKans * 100))

            If verschil > ligtTussen Or verschil < -ligtTussen Then
                cOut += 1
            Else
                cIn += 1
            End If


            pgb.Value += 1
        Next


        Dim ver As New Series

        ' Standaard afwijking berekenen
        Dim deviatie = Math.Round(CalculateStandardDeviation(standaardAfwijking), 3)
        Dim remove As Double = 0
        Dim remove2 As Double = 0
        Dim remove3 As String = ""
        Dim tVerd As New tVerdeling

        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim afw = tVerd.getTwaarde(0.995, item.getTotaal) * deviatie / Math.Sqrt(item.getTotaal)
            remove += afw

            Dim verschil As Double

            Dim echt = (Math.Round(((item.getDoorgegaan / item.getTotaal) * 10000)) / 100)

            ' Bereken de top waarde en onderste waarde van de afwijking, controlleer of deze boven 100 of onder 0 zit en pas deze aan indien nodig
            Dim bEdge = Math.Round(item.getKans * 100 - afw, 2)
            Dim tEdge = Math.Round(item.getKans * 100 + afw, 2)
            If bEdge < 0 Then bEdge = 0
            If tEdge > 100 Then tEdge = 100

            Dim result = "[" + bEdge.ToString + " - " + Math.Round(item.getKans * 100, 2).ToString + " - " + tEdge.ToString + "]"

            Dim kleur As Color
            If echt <= item.getKans * 100 + afw And echt >= item.getKans * 100 - afw Then
                trues += 1
                kleur = Color.LightGreen

                verschil = item.getKans * 100 - echt

                remove += (afw * 2)
            Else
                falses += 1
                kleur = Color.OrangeRed
                remove2 += (afw * 2)

                If echt < bEdge Then
                    verschil = bEdge - echt
                Else
                    verschil = tEdge - echt
                End If


                ' Voeg punten toe aan grafiek
                If Not versch.ContainsKey(verschil) Then
                    versch.Add(verschil, 1)
                Else
                    versch(verschil) += 1
                End If


                remove3 += " or (Merk = '" + item.getMerk + "' and UitvCentrumOmsch = '" + item.getUitvoerCentrum + "' and CodeSubafdeling = '" + item.getCodeSubAfdeling + "' "
                remove3 += " and Month(StartDatum) = " + item.getMaand.ToString + " and dag = '" + item.getDag + "')"
            End If


            dgvResult.Rows.Add(item.getMerk, item.getUitvoerCentrum, item.getCodeSubAfdeling, item.getMaand.ToString, item.getDag, item.getTotaal.ToString, echt.ToString, result, verschil.ToString)
            dgvResult.Rows(dgvResult.RowCount - 1).DefaultCellStyle.BackColor = kleur
        Next

        dgvResult.Refresh()


        ' teken grafiek
        For Each s As KeyValuePair(Of Double, Integer) In versch
            ver.Points.AddXY(s.Key, s.Value)
        Next
        drawBarGraph(ver)

        remove = remove / trues
        remove2 = remove2 / falses
        'remove2 = remove / listOfAllItems.Count

        pgb.Value = pgb.Maximum

        lblInfo2.Text = "Binnen -" + ligtTussen.ToString + " en " + ligtTussen.ToString + ": " + cIn.ToString + "    Buiten -" + ligtTussen.ToString + " en " + ligtTussen.ToString + ": " + cOut.ToString + "      Standaardafwijking: " + deviatie.ToString
        Label1.Text = "Totaal = " + listOfAllItems.Count.ToString + " waarvan " + trues.ToString + " correct voorspeld waren en " + falses.ToString + " niet"
    End Sub

#End Region
End Class