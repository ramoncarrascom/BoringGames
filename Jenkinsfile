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
        sh 'cd BoringGames.Web/boring-games && npm install'
      }
    }
    stage('Frontend Build') {
      steps {
        sh 'cd BoringGames.Web/boring-games && npm run build --prod'
      }
    }
    stage('Frontend Deploy') {
      steps {
        ftpPublisher alwaysPublishFromMaster: false, 
          masterNodeName: '',
          paramPublish: null,
          continueOnError: false, 
          failOnError: false, 
          publishers: [
            [configName: 'FTP_Boringames', 
             transfers: [
               [asciiMode: false, 
                cleanRemote: false, 
                excludes: '', 
                flatten: false, 
                makeEmptyDirs: false, 
                noDefaultExcludes: false, 
                patternSeparator: '[, ]+', 
                remoteDirectory: '', 
                remoteDirectorySDF: false, 
                removePrefix: '', 
                sourceFiles: 'BoringGames.Web/boring-games/www/**']
             ], 
             usePromotionTimestamp: false, 
             useWorkspaceInPromotion: false, 
             verbose: false]
          ]
      }
    }
  }
}
