# load the library
library(caret)
library(RODBC)


start = Sys.time()
dbhandle <- odbcDriverConnect('driver=SQL Server;server=USER-PC\\SQLExpress;database=SyntraTest')


inget <- sqlQuery(dbhandle, "SELECT top 500 CodeIngetrokken, Merk, month(startdatum), dag, UitvCentrumOmsch, CodeSubafdeling FROM [SyntraTest].[dbo].[Cursussen] Where Aard NOT IN (15,29,14,58,12,13) and OmschrijvingComm not like '%SELOR%' and OmschrijvingComm not like '%Bekwaamheidsattest%' and OmschrijvingComm not like '%stage%' and OmschrijvingComm not like '%proef%' and OmschrijvingComm not like '%attest%' and OmschrijvingComm not like '%aanvullende praktijk%' and OmschrijvingComm not like '%eindwerk%' and OmschrijvingComm not like '%AP%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'POC%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'C.I.%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'P.S.%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'LeReN%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'Lerend%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'Iedereen leert%' and OmschrijvingComm not like 'Bedrijvig Brugge%' and OmschrijvingComm not like '%testavond%' and OmschrijvingComm not like 'Talent%' and OmschrijvingComm not like '%Spoor 1%' and OmschrijvingComm not like '%Spoor 2%' and OmschrijvingComm not like '%Spoor 3%' and OmschrijvingComm not like '%Spoor 4%' and OmschrijvingComm not like '%Spoor 5%' and year(startdatum)<2015 order by newID()")
colnames(inget) <- c("CodeIngetrokken", "merk", "startdatum", "dag", "UitvCentrumOmsch", "CodeSubafdeling")
inget[, 1] = factor(inget[, 1], labels = c("Ja", "Nee"))
print(inget[1,])
############VOOR OVER DE MIDDAG

# prepare training scheme
control <- trainControl(method = "repeatedcv", number = 5, repeats = 1)
# train the model
model <- train(CodeIngetrokken ~ ., data = inget, method = "lvq", preProcess = "scale", trControl = control)
# estimate variable importance
importance <- varImp(model, scale = FALSE)

# summarize importance
print(importance)
# plot importance
plot(importance)

print("TOTAL: ")
print(difftime(Sys.time(), start))