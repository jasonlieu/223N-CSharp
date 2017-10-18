echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of files
ls -l

echo Compile csp1frame
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:csp2frame.dll csp2frame.cs 

echo Compile csp1main
mcs -r:System -r:System.Windows.Forms -r:csp2frame.dll -out:csp2.exe csp2main.cs

echo list of files
ls -l

echo Running file
./csp2.exe

echo End
