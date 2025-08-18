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

         stages {
        stage('Restore') {
            steps {
                dir("${WORKSPACE}") {
                    bat 'dotnet restore PracticeWebApi.sln'
                }
            }
        }
        stage('Build') {
            steps {
                dir("${WORKSPACE}") {
                    bat 'dotnet build PracticeWebApi.sln --configuration Release'
                }
            }
        }
        stage('Test') {
            steps {
                dir("${WORKSPACE}") {
                    bat 'dotnet test PracticeWebApi.sln --no-build --configuration Release'
                }
            }
        }
        stage('Publish') {
            steps {
                dir("${WORKSPACE}") {
                    bat 'dotnet publish PracticeWebApi/PracticeWebApi.csproj -c Release -o "C:\\inetpub\\wwwroot\\PracticeWebApi"'
                }
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
