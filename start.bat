REM https://developer.microsoft.com/en-us/graph/quick-start?code=M.R3_BAY.c35add16-4f66-fdfd-ada4-9ab9b6818823&state=option-dotnet
REM https://portal.azure.com/#view/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/~/CallAnAPI/appId/787997e6-1a3d-4470-bc84-67bdc80b1aaa/isMSAApp~/false
REM https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/intro
REM https://github.com/OfficeDev/Microsoft-Teams-Samples
REM https://github.com/microsoftgraph/msgraph-sdk-dotnet
REM https://docs.microsoft.com/en-us/microsoftteams/platform/get-started/deploy-csharp-app-studio

dotnet add package Microsoft.Extensions.Configuration.Binder
dotnet add package Microsoft.Extensions.Configuration.Json 
dotnet add package Azure.Identity 
dotnet add package Microsoft.Graph

dotnet run