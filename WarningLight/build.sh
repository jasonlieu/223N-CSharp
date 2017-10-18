#Jason Lieu
#CPSC 223N 
#Source files in this program: build.sh, WarningLightMain.cs, WarningLightFrame.cs


echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of files
ls -l

echo Compile csp1frame
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:WarningLightFrame.dll WarningLightFrame.cs 

echo Compile csp1main
mcs -r:System -r:System.Windows.Forms -r:WarningLightFrame.dll -out:WarningLight.exe WarningLightMain.cs

echo list of files
ls -l

echo Running file
./WarningLight.exe

echo End
