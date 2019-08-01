node {
	stage ('Checkout'){
		git 'https://github.com/iuryamicussi/Mutant.Hamburgueria.git'
	}
	stage ('Restore'){
	    sh "dotnet restore"
	    sh "dotnet clean"
	}
  	stage ('Build'){
	    sh "dotnet build --configuration Release"
  	}
	stage ('Test'){
	    sh "dotnet test"
	}
}
