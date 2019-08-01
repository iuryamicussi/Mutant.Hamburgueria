node {
	stage ('Checkout'){
		git 'https://github.com/iuryamicussi/Mutant.Hamburgueria.git'
	}
	stage ('Restore'){
    bat "dotnet restore"
    bat "dotnet clean"
	}
  stage ('Build'){
    bat "dotnet build --configuration Release"
  }
}
