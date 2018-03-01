@echo off

rem set destino1=c:\temp\tmp\BackupOlvebra\
set destino2=\\sntolvebra\discos\Programas\Olvebra\Instaladores\BalancaSolution\

dir \\sntolvebra\discos > nul
if errorlevel 1 net use \\sntolvebra\discos

rem if not exist %destino1% mkdir %destino1%
if not exist %destino2% mkdir %destino2%

rem copy /y Output\*.* %destino1%
rem if errorlevel 1 goto fim

copy /y Output\*.* %destino2%
if errorlevel 1 goto fim

:fim
if errorlevel 1 pause