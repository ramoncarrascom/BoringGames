pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        echo 'Building'
        sh 'dotnet build'
      }
    }
    stage('Test') {
      steps {
        echo 'Testing'
        sh 'dotnet test BoringGames.Core.Test/BoringGames.Core.Test.csproj'
        sh 'dotnet test BoringGames.Shared.Test/BoringGames.Shared.Test.csproj'
        sh 'dotnet test BoringGames.Api.Test/BoringGames.Api.Test.csproj'
        sh 'dotnet test BoringGames.Txt.Test/BoringGames.Txt.Test.csproj'
        sh 'dotnet test TicTacToe.Test/TicTacToe.Test.csproj'
      }
    }
    stage('Deploy') {
      steps {
        echo 'Deploying'
      }
    }
  }
}
