using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        //Creating robot class object to access methods and variables
        Robot rb = new Robot();
        int a, b;
        //Direction 
        public enum Direction
        {
            West = 231,
            East = 232,
            North = 233,
            South = 234
        }

        //direction variable of Direction type which shows the Directon 
        public Direction direction;

        //Intially sets to center point and North direction
        public Form1()
        {
            InitializeComponent();          
            lblArrow.Text = Convert.ToChar(Direction.North).ToString();           
        }

        //Exit from application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }       

        //Sets direction to North
        private void btnNorth_Click(object sender, EventArgs e)
        {
            lblArrow.Text = Convert.ToChar(Direction.North).ToString();
            direction = Direction.North;
        }

        //Sets direction to East
        private void btnEast_Click(object sender, EventArgs e)
        {

            lblArrow.Text = Convert.ToChar(Direction.East).ToString();
            direction = Direction.East;
        }

        //Sets direction to WEst
        private void btnWest_Click(object sender, EventArgs e)
        {
            lblArrow.Text = Convert.ToChar(Direction.West).ToString();
            direction = Direction.West;
        }

        //Sets direction to South
        private void btnSouth_Click(object sender, EventArgs e)
        {
            lblArrow.Text = Convert.ToChar(Direction.South).ToString();
            direction = Direction.South;
        }

        //One point movement and call move method
        private void Go_One_Click(object sender, EventArgs e)
        {
            int movePoint = 1;
            moveArrow(movePoint);
        }

        //10 point movement and call move method
        private void btnGo10_Click(object sender, EventArgs e)
        {
            int movePoint = 10;
            moveArrow(movePoint);
        }

        //Move method which sets location and check location if it's beyond boundry then show message
        public void moveArrow(int movePoint)
        {
            int x = lblArrow.Location.X;
            int y = lblArrow.Location.Y;
            a = x;
            b = y;
            switch (direction)
            {
                case Direction.North:
                    y = y - movePoint;
                    if (x < -100 || y < -100 || x > 100 || y > 100)
                    {
                        MessageBox.Show("Maximum Limit");
                        if(y<0)
                        {
                            x=a;
                            y = b;
                        }
                    }
                    else
                    {

                        lblArrow.Location = new Point(x, y );

                        rb.RobotDistance = movePoint;
                    }
                    break;
                case Direction.South:
                    y = y + movePoint;
                    if (x < -100 || y  < -100 || x > 100 ||y  > 100)
                    {
                        MessageBox.Show("Maximum Limit");
                        if (y > 100)
                        {
                            x = a;
                            y = b;
                        }
                    }
                    else
                    {
                        lblArrow.Location = new Point(x, y);
                        rb.RobotDistance = movePoint;
                    }
                    break;
                case Direction.West:
                    x = x - movePoint;
                    if (x < -100 || y < -100 || x > 100 || y > 100)
                    {
                        MessageBox.Show("Maximum Limit");
                        if (x < 0)
                        {
                            x = a;
                            y = b;
                        }
                    }
                    else
                    {
                        lblArrow.Location = new Point(x , y);
                        rb.RobotDistance = movePoint;
                    }
                    break;
                case Direction.East:
                    x = x + movePoint;
                    if (x < -100 ||y < -100 || x > 100 || y  > 100)
                    {
                        MessageBox.Show("Maximum Limit");
                        if (x >100)
                        {
                            x = a;
                            y = b;
                        }
                    }
                    else
                    {
                        lblArrow.Location = new Point(x , y);
                        rb.RobotDistance = movePoint;
                    }
                    break;
            }
            //Display the loction
            lblPosition.Text = rb.GetFormattedLocation(lblArrow.Location.X, lblArrow.Location.Y);
        }

        //KeyDown Event
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.N: { btnNorth.PerformClick();break; }
                case Keys.S: { btnSouth.PerformClick();break; }
                case Keys.W: { btnWest.PerformClick();break; }
                case Keys.E: { btnEast.PerformClick();break; }
                case Keys.NumPad1: { Go_One.PerformClick();break; }
                case Keys.NumPad0: { btnGo10.PerformClick();break; }
                case Keys.Escape: { btnExit.PerformClick();break; }
            }
        }
       
    }
}
