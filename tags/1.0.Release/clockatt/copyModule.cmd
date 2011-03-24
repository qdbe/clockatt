del /q /f /s ..\installPack
del /q /f /s ..\installPack\*.*
del /q /f /s ..\installPack\*
del /q /f /s ..\installPack\clockatt
mkdir ..\installPack
mkdir ..\installPack\clockatt
rem copy .\bin\release\*.dll ..\installPack\clockatt
copy .\bin\release\clockatt.exe ..\installPack\clockatt
xcopy /S/I/Y .\bin\release\Holiday ..\installPack\clockatt\Holiday
copy .\readme.txt ..\installPack\clockatt
copy .\license.txt ..\installPack\clockatt
rem copy .\ƒ‰ƒCƒZƒ“ƒX.rtf   ..\installPack\clockatt
copy .\Resources\catt.ico ..\installPack\clockatt
copy .\clockattHelp.htm ..\installPack\clockatt
xcopy /S/I/Y .\clockattHelp.files ..\installPack\clockatt\clockattHelp.files

pause

