
//	RED	YELLOW	GREEN
//FAST	1	0.25	0.75
//MED	2	0.5	1.5
//SLOW	4	1	3


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class StopLight : Form
{
	//size stuff
	private const int formwidth = 1280;
	private const int formheight = 720;

	//Radio button initialization stuff
	private RadioButton RadioSlow = new RadioButton();
	private RadioButton RadioMedium = new RadioButton();
	private RadioButton RadioFast = new RadioButton();
	private GroupBox RadioButtonSpeed = new GroupBox();
	
	//Button stuff
	private Button Pause = new Button();
	private Button Exit = new Button();
	private Button Start = new Button();

	//Time stuff
	private static System.Timers.Timer Clock = new System.Timers.Timer();
	private int counter = 0;
	
	//Other Stuff
	private string CurrentColor = "empty";
	private bool StartCheck = false;

	public StopLight()
	{
		Size = new Size(formwidth, formheight);
		Text = "Stoplight";
		System.Console.WriteLine("Form_width = {0}, Form_height = {1}.", formwidth, formheight);
		BackColor = Color.White;

		RadioSlow.Text = "Slow";
		RadioSlow.Size = new System.Drawing.Size(45,15);
		RadioSlow.BackColor = Color.LightBlue;
		RadioSlow.Location = new System.Drawing.Point(545,625);
		RadioMedium.Text = "Medium";
		RadioMedium.Size = new System.Drawing.Size(40,15);
		RadioMedium.BackColor = Color.LightBlue;
		RadioMedium.Location = new System.Drawing.Point(590,625);
		RadioFast.Text = "Fast";
		RadioFast.Size = new System.Drawing.Size(40,15);
		RadioFast.BackColor = Color.LightBlue;
		RadioFast.Location = new System.Drawing.Point(635,625);
		RadioButtonSpeed.Text = "Rate of Change";
		RadioButtonSpeed.Size = new System.Drawing.Size(145,35);
		RadioButtonSpeed.BackColor = Color.LightBlue;
		RadioButtonSpeed.Location = new System.Drawing.Point(543,612);
		Pause.Text = "Pause";
		Pause.Size = new System.Drawing.Size(40,25);
		Pause.Location = new System.Drawing.Point(690,620);
		Pause.BackColor = Color.LightBlue;
		Exit.Text = "Exit";
		Exit.Size = new System.Drawing.Size(40,25);
		Exit.Location = new System.Drawing.Point(735,620);
		Exit.BackColor = Color.LightBlue;
		Start.Text = "Start";
		Start.Size = new System.Drawing.Size(35,25);
		Start.Location = new System.Drawing.Point(505,620);
		Start.BackColor = Color.LightBlue;
		Controls.Add(RadioSlow);
		Controls.Add(RadioMedium);
		Controls.Add(RadioFast);
		Controls.Add(RadioButtonSpeed);
		Controls.Add(Pause);
		Controls.Add(Exit);
		Controls.Add(Start);
		
		RadioSlow.Checked = true;
		Clock.Enabled = false;
		Clock.Elapsed += new ElapsedEventHandler(StopLightControl);
		Clock.Interval = 1;
		Clock.Enabled = true;

		Start.Click += new EventHandler(StartButton);
		Exit.Click += new EventHandler(ExitButton);
		Pause.Click += new EventHandler(PauseButton);

		
	}
	
	protected override void OnPaint(PaintEventArgs ee){ 
		Graphics graph = ee.Graphics;
		//graph.FillRectangle(Brushes.COLOR, topX, topY, W, H)
      		graph.FillRectangle(Brushes.Gray,500,50,280,620);					//Mid
      		graph.FillRectangle(Brushes.LightBlue,500,50,280,70);					//Top
      		graph.FillRectangle(Brushes.LightBlue,500,600,280,70);					//Bottom
		graph.FillEllipse(Brushes.DarkGray, 640 - 75, 200 - 75, 150, 150);			//Lights off
		graph.FillEllipse(Brushes.DarkGray, 640 - 75, 360 - 75, 150, 150);
		graph.FillEllipse(Brushes.DarkGray, 640 - 75, 520 - 75, 150, 150);
		switch(CurrentColor)
		{
			case "red":
				graph.FillEllipse(Brushes.Red, 640 - 75, 200 - 75, 150, 150);		//RED
				break;
			case "yellow":
				graph.FillEllipse(Brushes.Yellow, 640 - 75, 360 - 75, 150, 150);	//YELLOW
				break;
			case "green":
				graph.FillEllipse(Brushes.Green, 640 - 75, 520 - 75, 150, 150);		//GREEN
     				break;
		}
		base.OnPaint(ee);
	}
	protected void StartButton(System.Object sender, EventArgs evt)
	{
		System.Console.WriteLine("Start");
		StartCheck = true;
	}
	protected void ExitButton(System.Object sender, EventArgs evt)
	{
		System.Console.WriteLine("Exit");
		Close();
	}
	protected void PauseButton(System.Object sender, EventArgs evt)
	{
		System.Console.WriteLine("Pause");
		StartCheck = false;
	}
	protected void StopLightControl(System.Object sender, ElapsedEventArgs evt)
	{
		if(StartCheck == true)
		{
			if(RadioSlow.Checked == true)					//Slow
			{
				switch(counter)
				{
					case 0:
						Clock.Interval = (int)3000;		//Slow Green, 3 sec
						CurrentColor = "green";
						break;
					case 1:
						Clock.Interval = (int)1000;		//Slow Yellow, 1 sec
						CurrentColor = "yellow";
						break;
					case 2: 
						Clock.Interval = (int)4000;		//Slow Red, 4 sec
						CurrentColor = "red";
						break;
				}
				counter = (counter + 1)%3;
				
			}
			if(RadioMedium.Checked == true)					//Medium
			{
				switch(counter)
				{
					case 0:
						Clock.Interval = (int)1500;		//Medium Green, 1.5 sec
						CurrentColor = "green";
						break;
					case 1:
						Clock.Interval = (int)500;		//Medium Yellow, 0.5 sec
						CurrentColor = "yellow";
						break;
					case 2:
						Clock.Interval = (int)2000;		//Medium Red, 2 sec
						CurrentColor = "red";
						break;
				}
				counter = (counter + 1)%3;
			}
			if(RadioFast.Checked == true)					//Fast
			{
				switch(counter)
				{
					case 0:
						Clock.Interval = (int)750;		//Fast Green, 0.75 sec
						CurrentColor = "green";
						break;
					case 1:
						Clock.Interval = (int)250;		//Fast Yellow, 0.25 sec
						CurrentColor = "yellow";
						break;
					case 2:
						Clock.Interval = (int)1000;		//Fast Red. 1 sec
						CurrentColor = "red";
						break;
				}
				counter = (counter + 1)%3;
			}
		}
		Invalidate();
	}
}
