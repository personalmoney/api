@echo off 

if [%1]==[] goto end
cd PersonalMoney.Api
dotnet ef migrations add %1
@echo Done.
goto :eof
:end
@echo Provide name for the migration
exit /B 1