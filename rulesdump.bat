@ECHO ON
@ECHO Must have path to MSBuild.  If this fails run from VS2015 Dev Command Prompt
msbuild.exe .\RoslynProofs\RoslynProofs.sln /p:RunCodeAnalysis=True /t:rebuild