SET BASEPATH=C:\git\BoringGames
SET VERSION=0.1
dotnet tool install -g dotnet-reportgenerator-globaltool > NUL

RMDIR %BASEPATH%\CoverageResults /S /Q

dotnet test %BASEPATH%\BoringGames.Core.Test\BoringGames.Core.Test.csproj /p:CollectCoverage=true  /p:CoverletOutput=..\CoverageResults\
rem pause
dotnet test %BASEPATH%\BoringGames.Shared.Test\BoringGames.Shared.Test.csproj /p:CollectCoverage=true  /p:CoverletOutput=..\CoverageResults\ /p:MergeWith="..\CoverageResults\coverage.json"
rem pause
dotnet test %BASEPATH%\BoringGames.Api.Test\BoringGames.Api.Test.csproj /p:CollectCoverage=true  /p:CoverletOutput=..\CoverageResults\ /p:MergeWith="..\CoverageResults\coverage.json"
rem pause
dotnet test %BASEPATH%\BoringGames.Txt.Test\BoringGames.Txt.Test.csproj /p:CollectCoverage=true  /p:CoverletOutput=..\CoverageResults\ /p:MergeWith="..\CoverageResults\coverage.json"
rem pause
dotnet test %BASEPATH%\TicTacToe.Test\TicTacToe.Test.csproj /p:CollectCoverage=true  /p:CoverletOutput=..\CoverageResults\ /p:MergeWith="..\CoverageResults\coverage.json" /p:CoverletOutputFormat="opencover"
rem pause

reportgenerator -reports:%BASEPATH%\CoverageResults\coverage.opencover.xml -targetdir:%BASEPATH%\CoverageResults\Reports\ -reportTypes:"Cobertura"
dotnet C:\utils\sonarqube\netcore\SonarScanner.MSBuild.dll begin /k:"boringames" /v:%VERSION% /d:sonar.cs.opencover.reportsPaths=%BASEPATH%\CoverageResults\coverage.opencover.xml /d:sonar.coverage.exclusions="**Test*.cs"
dotnet build %BASEPATH%\BoringGames.sln
dotnet C:\utils\sonarqube\netcore\SonarScanner.MSBuild.dll end