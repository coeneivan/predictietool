
# load the library
library(mlbench)
library(caret)
library(e1071)
library(pROC)
library(RODBC)
library(randomForest)

dbhandle <- odbcDriverConnect('driver=SQL Server;server=USER-PC\\SQLExpress;database=SyntraTest')

inget <- sqlQuery(dbhandle, "SELECT CodeIngetrokken, month(StartDatum) as StartDatum, dag, Merk, UitvCentrum, CodeSoortCursus, CodeAnalytischPlanSubafdeling, CodeSubafdeling, OpInternet FROM [SyntraTest].[dbo].[Cursussen]")
colnames(inget) <- c("CodeIngetrokken", "StartDatum", "dag", "Merk", "UitvCentrum", "CodeSoortCursus", "CodeAnalytischPlanSubafdeling", "CodeSubafdeling", "OpInternet")
#summary(inget)

############VOOR OVER DE MIDDAG

# prepare training scheme
control <- trainControl(method = "repeatedcv", number = 10, repeats = 3)
# train the model
model <- train(CodeIngetrokken ~ ., data = inget, method = "lvq", preProcess = "scale", trControl = control)
# estimate variable importance
importance <- varImp(model, scale = FALSE)

# summarize importance
print(importance)
# plot importance
plot(importance)

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