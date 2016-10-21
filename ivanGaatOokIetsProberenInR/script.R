# load the library
#library(mlbench)
#library(caret)
#library(e1071)
#library(pROC)
library(RODBC)
#library(randomForest)


start = Sys.time()
dbhandle <- odbcDriverConnect('driver=SQL Server;server=USER-PC\\SQLExpress;database=SyntraTest')


inget <- sqlQuery(dbhandle, "SELECT CodeIngetrokken, OmschrijvingComm, dag, UitvCentrumOmsch, Aard, CaM, CuB, OpC, Ont, CoC, CodeAnalytischPlanSubafdeling, CodeSubafdeling FROM [SyntraTest].[dbo].[Cursussen] Where month(startdatum)=9 and merk='Syntra West' and Aard NOT IN (15,29,14,58,12,13) and OmschrijvingComm not like '%SELOR%' and OmschrijvingComm not like '%Bekwaamheidsattest%' and OmschrijvingComm not like '%stage%' and OmschrijvingComm not like '%proef%' and OmschrijvingComm not like '%attest%' and OmschrijvingComm not like '%aanvullende praktijk%' and OmschrijvingComm not like '%eindwerk%' and OmschrijvingComm not like '%AP%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'POC%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'C.I.%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'P.S.%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'LeReN%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'Lerend%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm not like 'Iedereen leert%' and OmschrijvingComm not like 'Bedrijvig Brugge%' and OmschrijvingComm not like '%testavond%' and OmschrijvingComm not like 'Talent%' and OmschrijvingComm not like '%Spoor 1%' and OmschrijvingComm not like '%Spoor 2%' and OmschrijvingComm not like '%Spoor 3%' and OmschrijvingComm not like '%Spoor 4%' and OmschrijvingComm not like '%Spoor 5%' and year(startdatum)<2015")
colnames(inget) <- c("CodeIngetrokken", "OmschrijvingComm", "dag", "UitvCentrumOmsch", "Aard", "CaM", "CuB", "OpC", "Ont", "CoC", "CodeAnalytischPlanSubafdeling", "CodeSubafdeling")
inget[, 1] = factor(inget[, 1], labels = c("Ja", "Nee"))
inget[, 5] = factor(inget[, 5], labels = c("AARD#"))
print(inget[1,])
############VOOR OVER DE MIDDAG

# prepare training scheme
#control <- trainControl(method = "repeatedcv", number = 10, repeats = 3)
# train the model
#model <- train(CodeIngetrokken ~ ., data = inget, method = "lvq", preProcess = "scale", trControl = control)
# estimate variable importance
#importance <- varImp(model, scale = FALSE)

# summarize importance
#print(importance)
# plot importance
#plot(importance)


# define the control using a random forest selection function
#control <- rfeControl(functions = rfFuncs, method = "repeatedcv", repeats = 5,verbose = FALSE)
# run the RFE algorithm
#results <- rfe(inget[, 2:8], inget[, 1], sizes = c(2:8), rfeControl = control)
# summarize the results
#print(results)
# list the chosen features
#predictors(results)
# plot the results
#plot(results, type = c("g", "o"))
library(arules)
rules <- apriori(inget,
    parameter = list(support = 0.25, confidence = 0.01),
    appearance = list(rhs = c("CodeIngetrokken=Nee"),lhs = paste0("UitvCentrumOmsch" = inget$UitvCentrumOmsch))
    #appearance = list(rhs = c("CodeIngetrokken=Nee"), default = "lhs")
)

rules.sorted <- sort(rules, by = "confidence")
top5.rules <- head(rules.sorted, 10)
return (as(top5.rules, "data.frame"))


#print("TOTAL: ")
#print(difftime(Sys.time(), start))