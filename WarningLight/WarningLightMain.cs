//Jason Lieu
//CPSC 223N
//Source files in this program: build.sh, WarningLightMain.cs, WarningLightFrame.cs
//To compile this file:
//mcs -r:System -r:System.Windows.Forms -r:WarningLightFrame.dll -out:WarningLight.exe WarningLightMain.cs


using System;
using System.Windows.Forms;            //Needed for "Application.Run" near the end of Main function.
public class Warning
{  public static void Main()
   {  System.Console.WriteLine("WarningLight starts now");
      WarningLight Light= new WarningLight();
      Application.Run(Light);
      System.Console.WriteLine("End");
   }//End of Main function
}//End of RYG class
