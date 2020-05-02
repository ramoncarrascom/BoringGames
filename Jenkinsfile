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
      }
    }
    stage('Deploy') {
      steps {
        echo 'Deploying'
      }
    }
  }
}
