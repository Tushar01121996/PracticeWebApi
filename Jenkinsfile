pipeline {
    agent any

  
    
    triggers {
        pollSCM('* * * * *')  // every 1 min
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Tushar01121996/PracticeWebApi.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test --no-build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish --configuration Release -o published'
            }
        }

        stage('Deploy (Local IIS)') {
            steps {
                echo 'Deploying to local IIS...'
                // Example: Copy published files to IIS site folder
                bat 'xcopy /y /s published "C:\\inetpub\\wwwroot\\PracticeWebApiJenkins"'
            }
        }
    }

    post {
        success {
            echo '✅ Build & Deploy Successful!'
        }
        failure {
            echo '❌ Build Failed!'
        }
    }
}
