@echo off
cls
set NUGETPATH="%~dp0%build\tools\nuget"
set NUGET="%~dp0%build\tools\nuget\nuget.exe"
set FAKE="%~dp0%build\tools\FAKE\tools\Fake.exe"

if not exist %NUGETPATH% (
	mkdir %NUGETPATH%
)

if not exist %NUGET% (
	echo NuGet not found .. downloading
    PowerShell -NoProfile -ExecutionPolicy Bypass -Command "& { (New-Object Net.WebClient).DownloadFile('https://dist.nuget.org/win-x86-commandline/latest/nuget.exe', '%NUGET%') }"
    echo done
)

if not exist %FAKE% (
    echo FAKE not found .. installing
    %NUGET% "install" "FAKE" -Source "https://nuget.org/api/v2/" -OutputDirectory "build\tools" -ExcludeVersion -Version 4.61.3
)


set TARGET="Default"

if not [%1]==[] (set TARGET="%1")

shift

%FAKE% "build.fsx" "%TARGET%" %*
