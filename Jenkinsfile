pipeline {
    agent any

    tools {
        // Make sure dotnet is installed on Jenkins machine
        // If installed globally, you can skip this block
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/your-username/your-repo.git'
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
                bat 'xcopy /y /s published "C:\\inetpub\\wwwroot\\MyApi"'
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
