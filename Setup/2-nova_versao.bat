@echo off

PacoteTools.exe -tipo inno -config BalancaSolutionSetup.iss -xml BalancaSolutionSetup.xml -addversao 0.0.0.1
if errorlevel 1 goto fim

call compilar_setup.bat
if errorlevel 1 goto fim

:fim
if errorlevel 1 pause
