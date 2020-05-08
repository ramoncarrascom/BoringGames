pipeline {
  agent any
  stages {
    stage('Backend Build') {
      steps {
        sh 'dotnet build'
      }
    }
    stage('Backend Test') {
      steps {
        sh 'dotnet test BoringGames.Core.Test/BoringGames.Core.Test.csproj'
        sh 'dotnet test BoringGames.Shared.Test/BoringGames.Shared.Test.csproj'
        sh 'dotnet test BoringGames.Api.Test/BoringGames.Api.Test.csproj'
        sh 'dotnet test BoringGames.Txt.Test/BoringGames.Txt.Test.csproj'
        sh 'dotnet test TicTacToe.Test/TicTacToe.Test.csproj'
      }
    }
    stage('Backend Deploy') {
      steps {
        echo 'Deploying'
      }
    }
    stage('Frontend NPM Setup') {
      steps {
        sh 'cd BoringGames.Web/boring-games'
        sh 'npm install'
      }
    }
    stage('Frontend Build') {
      steps {
        sh 'cd BoringGames.Web/boring-games'
        sh 'npm run build --prod'
      }
    }
  }
}
