library(RODBC)
library(ggvis)

source("dbconnection.R")

inget <- sqlQuery(dbhandle, "SELECTFROM [SyntraTest].[dbo].[Cursussen] where codeingetrokken = \'Nee\' GROUP BY year(startdatum)")



DrawNietGeschraptPerJaar <- function() {
    year <- sqlQuery(dbhandle, "SELECT DISTINCT year(startdatum) as jaar, count(codeingetrokken) as NietGeschrapteCursussen FROM [SyntraTest].[dbo].[Cursussen] where codeingetrokken = \'Nee\' GROUP BY year(startdatum)")
    plot(year$jaar, year$NietGeschrapteCursussen, "l")
}

# Filter op subafdeling, wanneer subafdeling == null, wordt alles terug gegeven.
DrawVerhoudingGeschraptPerDagPerSubafdeling <- function(Subafdeling) {
    q1 = 
    query = sprintf("SELECT DISTINCT dag, count(*) as totaal, COUNT(CASE WHEN CodeIngetrokken = 'Nee' THEN 1 ELSE NULL END) AS Doorgegaan, COUNT(CASE WHEN CodeIngetrokken = 'Ja' THEN 1 ELSE NULL END) AS Ingetrokken from Cursussen where CodeSubafdeling = \'%s\' Group by dag;", Subafdeling)
    # Run Query
    week <- sqlQuery(dbhandle, query)
    week2 <- data.frame(week$dag, week$Doorgegaan)
    barplot(as.matrix(week2))   
}

# Filter op subafdeling, wanneer subafdeling == null, wordt alles terug gegeven.
DrawVerhoudingGeschraptPerDag <- function() {
    quer = "SELECT DISTINCT dag, count(*) as totaal, COUNT(CASE WHEN CodeIngetrokken = 'Nee' THEN 1 ELSE NULL END) AS Doorgegaan, COUNT(CASE WHEN CodeIngetrokken = 'Ja' THEN 1 ELSE NULL END) AS Ingetrokken from Cursussen Group by dag;"
    
    # Run Query
    week <- sqlQuery(dbhandle, quer)
    barplot(week)
}

DrawVerhoudingGeschraptPerDagPerSubafdeling("WEB")