
library(RODBC)
dbhandle <- odbcDriverConnect('driver=SQL Server;server=laptop-BEN_ASUS;database=SyntraTest')
year <- sqlQuery(dbhandle, 'SELECT DISTINCT year(startdatum) FROM [SyntraTest].[dbo].[Cursussen]')

year