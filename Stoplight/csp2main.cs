using System;
using System.Windows.Forms;            //Needed for "Application.Run" near the end of Main function.
public class RYG
{  public static void Main()
   {  System.Console.WriteLine("Stoplight starts now");
      StopLight stop= new StopLight();
      Application.Run(stop);
      System.Console.WriteLine("End");
   }//End of Main function
}//End of RYG class
