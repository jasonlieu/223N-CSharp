//Jason Lieu
//CPSC 223N
//Source files in this program: build.sh, WarningLightMain.cs, WarningLightFrame.cs
//To compile this file:
//mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:WArningLightFrame.dll WarningLightFrame.cs


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class WarningLight : Form
{
	private const int formwidth = 640;
	private const int formheight = 720;
	
	private Label name = new Label();
	private Label title = new Label();
	
	private RadioButton RadioHalf = new RadioButton();
	private RadioButton RadioOne = new RadioButton();
	private RadioButton RadioTwo = new RadioButton();
	private RadioButton RadioFour = new RadioButton();
	private GroupBox RadioButtons = new GroupBox();
	
	private Button Exit = new Button();

	private static System.Timers.Timer Clock = new System.Timers.Timer();
	private int counter = 0;
	private bool DrawCircle = false;
	private int interval = 1000;
	private int blinks = 0;

	private int MouseX = 0;
	private int MouseY = 0;
	private bool Click = false;

	public WarningLight()
	{
		Size = new Size(formwidth, formheight);
		Text = "Warning Light";
		System.Console.WriteLine("Form_width = {0}, Form_height = {1}." , formwidth, formheight);
		BackColor = Color.White;
		RadioHalf.Text = "0.5sec";
		RadioOne.Text = "1.0sec";
		RadioTwo.Text = "2.0sec";
		RadioFour.Text = "4.0sec";
		RadioHalf.Size = new System.Drawing.Size(60,15);
		RadioHalf.Location = new System.Drawing.Point(30,650);
		RadioHalf.BackColor = Color.Yellow;
		RadioOne.Size = new System.Drawing.Size(60,15);
		RadioTwo.Size = new System.Drawing.Size(60,15);
		RadioFour.Size = new System.Drawing.Size(60,15);
		RadioOne.Location = new System.Drawing.Point(100, 650);
		RadioTwo.Location = new System.Drawing.Point(170,650);
		RadioFour.Location = new System.Drawing.Point(240,650);
		RadioOne.BackColor = Color.Yellow;
		RadioTwo.BackColor = Color.Yellow;
		RadioFour.BackColor = Color.Yellow;
		title.Text = "Warning Light";
		title.Location = new System.Drawing.Point(270,25);
		title.BackColor = Color.LightGray;
		title.Size = new Size(100,15);
		name.Text = "Programmer: Jason Lieu";
		name.Location = new System.Drawing.Point(10,70);
		name.BackColor = Color.White;
		name.Size = new Size(145,15);
		Exit.Text = "Exit";
		Exit.Size = new System.Drawing.Size(40,25);
		Exit.Location = new System.Drawing.Point(550,650);
		Controls.Add(Exit);
		Controls.Add(title);
		Controls.Add(name);	
		Controls.Add(RadioHalf);
		Controls.Add(RadioOne);
		Controls.Add(RadioTwo);
		Controls.Add(RadioFour);

		RadioOne.Checked = true;
		Clock.Enabled = false;
		Clock.Elapsed += new ElapsedEventHandler(Time);
		Clock.Interval = 1;
		Clock.Enabled = true;	

		Exit.Click += new EventHandler(ExitButton);
	}
	protected override void OnPaint(PaintEventArgs ee)
	{
		Graphics graph = ee.Graphics;
		graph.FillRectangle(Brushes.Yellow,0,630,640,90); //control bar
		graph.FillRectangle(Brushes.LightGray,0,0,640,45);  //top bar
		if(DrawCircle)
		{
			graph.FillEllipse(Brushes.Blue, MouseX-50, MouseY-50, 100, 100);
		}
		
	}
	protected void ExitButton(System.Object sender, EventArgs evt)
	{
		System.Console.WriteLine("Exit");
		Close();	
	}
	protected override void OnMouseDown(MouseEventArgs me)
	{
		if(blinks == 0)
		{
			MouseX = me.X;	
			MouseY = me.Y;
			Click = true;
			if(RadioHalf.Checked == true){interval = 500;}
			if(RadioOne.Checked == true){interval = 1000;}
			if(RadioTwo.Checked == true){interval = 2000;}
			if(RadioFour.Checked == true){interval = 4000;}
		}
		Invalidate();
	}
	protected void Time(System.Object sender, ElapsedEventArgs evt)
	{
		if(Click == true)
		{	
			switch(counter%2)
			{
				case 0:
					Clock.Interval = (int)interval;
					DrawCircle = true;
					System.Console.WriteLine("DRAW");
					blinks = blinks + 1;
					break;
				case 1:
					Clock.Interval = (int)interval;
					DrawCircle = false;
					System.Console.WriteLine("NODRAW");
					break;
			}
			counter = (counter + 1)%2;
			if(blinks == 9)
			{
				counter = 0;
				Click = false;
				DrawCircle = false;
				blinks = 0;
			}
		}
		Invalidate();
	}
}
