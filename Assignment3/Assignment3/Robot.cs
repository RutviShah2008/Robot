using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment3
{
    class Robot
    {
        public static int distanceCovered;
       
        public int RobotDistance
        {
            get
            {
                return distanceCovered;
            }
            set => distanceCovered = distanceCovered + value;
        }        

        //Method to print curent locations
        public string GetFormattedLocation(int x,int y)
        {
            string locationString = "{X=" + Convert.ToString(x) + ",Y=" + Convert.ToString(y) + "}";
            return locationString;
        }
    }
}
