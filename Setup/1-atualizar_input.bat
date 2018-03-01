@echo off

if not exist Input mkdir Input

copy /y ..\BalancaSolution\bin\Release\*.* Input
copy /y balanca.db Input
if errorlevel 1 goto fim

:fim
if errorlevel 1 pause