if exist ..\.deploy\Release rmdir ..\.deploy\Release /S /Q

call kpm build .\Archient.Web --configuration Release --out ..\.deploy
xcopy ..\.deploy\Release\*.nupkg ..\.deploy\ /R /Y
rmdir ..\.deploy\Release /S /Q

call kpm build .\Archient.Web.Identity --configuration Release --out ..\.deploy
xcopy ..\.deploy\Release\*.nupkg ..\.deploy\ /R /Y
rmdir ..\.deploy\Release /S /Q