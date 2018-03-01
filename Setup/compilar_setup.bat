@echo off

"C:\App\Inno Setup 5\Compil32.exe" /cc "BalancaSolutionSetup.iss"
if errorlevel 1 goto fim

copy /y BalancaSolutionSetup.xml Output\BalancaSolutionSetup.xml
if errorlevel 1 goto fim

:fim
if errorlevel 1 pause
