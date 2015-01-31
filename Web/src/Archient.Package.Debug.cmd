if exist ..\.deploy\Debug rmdir ..\.deploy\Debug /S /Q

call kpm build .\Archient.Web --configuration Debug --out ..\.deploy
xcopy ..\.deploy\Debug\*.nupkg ..\.deploy\ /R /Y
rmdir ..\.deploy\Debug /S /Q

call kpm build .\Archient.Web.Identity --configuration Debug --out ..\.deploy
xcopy ..\.deploy\Debug\*.nupkg ..\.deploy\ /R /Y
rmdir ..\.deploy\Debug /S /Q

call kpm build .\Archient.Razor.TagHelpers --configuration Debug --out ..\.deploy
xcopy ..\.deploy\Debug\*.nupkg ..\.deploy\ /R /Y
rmdir ..\.deploy\Debug /S /Q