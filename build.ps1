#Have one parameter: build configuration from {"Debug", "Release"}

if($args -ne "") {
	args = "Release"
}

if(($args -ne "Debug") -and ($args -ne "Release")) {
	echo "Configuration parameter is incorrect"
	return 1
}

If(-Not (Test-Path $pwd\nuget.exe)) {
	echo "Downloading NuGet"
	Invoke-WebRequest "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $pwd\nuget.exe		#Download NuGet if hasn't downloaded
}

#.\nuget install Microsoft.Net.Compilers
#.\nuget install Microsoft.CodeAnalysis
#$CscPath = Join-Path $pwd "Microsoft.Net.Compilers.*\tools\csc"

#Restoring NuGet packages in solutions
.\nuget restore .\DatabaseFiller\
.\nuget restore .\OpenRelicsWebApp\

#Assing MSBuild compiler loction
$MSBuild = "C:\Windows\Microsoft.NET\Framework\v4*\MSBuild.exe"

#Build DatabaseFiller
iex "$MSBuild .\DatabaseFiller\DatabaseFiller\DatabaseFiller.csproj /p:Configuration=$args"										

if($args[0] -eq "Debug") {
	copy .\DatabaseFiller\DatabaseFiller\bin\debug\DatabaseFiller.exe .\Filler.exe		#TODO replace with link (.lnk)
}
else {
	copy .\DatabaseFiller\DatabaseFiller\bin\release\DatabaseFiller.exe .\Filler.exe	#TODO the same as above
}

echo "Compiled Filler.exe copied to current directory"
#TODO build and run in IIS Web App