SonarScanner.MSBuild.exe begin /k:"MyFirstProject" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="a56f3f75501a10acbc9c6b06b6a66e86d8d9d9c9"
MsBuild.exe /t:Rebuild
SonarScanner.MSBuild.exe end /d:sonar.login="a56f3f75501a10acbc9c6b06b6a66e86d8d9d9c9"
Pause