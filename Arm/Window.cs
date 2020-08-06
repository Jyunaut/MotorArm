using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Arm
{
    public partial class Window : Form
    {
        public Stopwatch Stopwatch { get; set; }

        private Point Point;
        private Point Link1Coords;
        private Point Link2Coords;

        // Motor Arm Properties (mm)
        private readonly double l1 = 160;
        private readonly double l2 = 160;
        private readonly int originOffset = 320;

        private double[] motorAngle;
 
        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            Stopwatch = Stopwatch.StartNew();

            port.PortName = "COM" + numPort.Value;
        }

        private void pnlSimulation_MouseMove(object sender, MouseEventArgs e)
        {
            if (Stopwatch.ElapsedMilliseconds > 25)
            {
                Stopwatch = Stopwatch.StartNew();

                // Get Point coordinates with respect to the origin
                Point = e.Location;
                Point.X -= originOffset;
                Point.Y = 640 - originOffset - Point.Y;

                // Do not output angles if mouse is out of bounds
                if (Math.Sqrt(Math.Pow(Point.X, 2) + Math.Pow(Point.Y, 2)) > l1 + l2 - 1
                    || Point.X < 0 || Point.Y < 0)
                    return;

                pnlSimulation_Paint(this, null);
                DisplayValues();
                WriteAnglesToPort();
            }
        }

        private void pnlSimulation_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = pnlSimulation.CreateGraphics();

            Link1Coords = GetJointCoords(1);
            Link2Coords = GetJointCoords(2);

            g.Clear(Color.White);

            // Draw Axis and Bounds
            g.DrawLine(System.Drawing.Pens.Gray, originOffset, 0, originOffset, 640);
            g.DrawLine(System.Drawing.Pens.Gray, 0, originOffset, 640, originOffset);
            g.DrawEllipse(System.Drawing.Pens.Gray, (int)(originOffset - l1 - l2), (int)(originOffset - l1 - l2),
                                                    (int)(2 * (l1 + l2))         , (int)(2 * (l1 + l2)));

            if (Math.Sqrt(Math.Pow(Point.X, 2) + Math.Pow(Point.Y, 2)) > l1 + l2 - 1
                || Point.X < 0 || Point.Y < 0)
                return;

            // Draw Link 1 and Link 2
            g.DrawLine(System.Drawing.Pens.Black, originOffset, originOffset,
                                                  originOffset + Link1Coords.X, originOffset + Link1Coords.Y);
            g.DrawLine(System.Drawing.Pens.Black, originOffset + Link1Coords.X, originOffset + Link1Coords.Y,
                                                  originOffset + Link2Coords.X, originOffset + Link2Coords.Y);
        }
        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            port.PortName = "COM" + numPort.Value;
            cboxPortStatus.Checked = false;
        }

        private void cboxPortStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxPortStatus.Checked)
            {
                try
                {
                    port.Open();
                    lblPortStatus.Text = "Port Status: Open";
                }
                catch (System.IO.IOException)
                {
                    lblPortStatus.Text = "Port Status: Not Available";
                }
            }
            else
            {
                try
                {
                    port.Close();
                }
                catch (System.IO.IOException)
                {
                    // Ignore Exception
                }
                lblPortStatus.Text = "Port Status: Closed";
            }
        }

        private void DisplayValues()
        {
            lblMouseCoords.Text = "Mouse Coordinates\n" + "X: " + Point.X + "\n" + "Y: " + Point.Y;
            lblEndEffectorCoords.Text = "End Effector Coordinates\n" + "X: " + Link2Coords.X + "\n" + "Y: " + -Link2Coords.Y;
            lblLinkAngles.Text = "Link Angles\n" + "Theta 1: " + -RadToDeg(t1) + "\nTheta 2: " + RadToDeg(Math.PI - t2);
        }

        private int RadToDeg(double rad)
        {
            return (int)(180 * rad / Math.PI);
        }

        private double t1, t2, t3 = 170;
        private Point GetJointCoords(int link)
        {
            motorAngle = CoordsToMotorAngles();
            Point Coords = new Point();
            
            switch (link)
            {
                case 1:
                    Coords.X = (int)(l1 * Math.Cos(motorAngle[0]));
                    Coords.Y = (int)(l1 * Math.Sin(motorAngle[0]));
                    break;
                case 2:
                    Coords.X = (int)(l1 * Math.Cos(motorAngle[0]) + l2 * Math.Cos(motorAngle[0] + motorAngle[1]));
                    Coords.Y = (int)(l1 * Math.Sin(motorAngle[0]) + l2 * Math.Sin(motorAngle[0] + motorAngle[1]));
                    break;
            }

            return Coords;
        }

        private double[] CoordsToMotorAngles()
        {
            if (Point.X == 0)
                Point.X = 1;

            t2 = Math.Acos((Math.Pow(Point.X, 2) + Math.Pow(Point.Y, 2) - Math.Pow(l1, 2) - Math.Pow(l2, 2)) / (2 * l1 * l2));
            t1 = Math.Atan((double) - Point.Y / (double)Point.X) - Math.Atan((l2 * Math.Sin(t2)) / (l1 + l2 * Math.Cos(t2)));

            return new[] { t1, t2 };
        }

        private void pnlSimulation_MouseUp(object sender, MouseEventArgs e)
        {
            t3 = 170;
            WriteAnglesToPort();
        }

        private void pnlSimulation_MouseDown(object sender, MouseEventArgs e)
        {
            t3 = 100;
            WriteAnglesToPort();
        }

        private void WriteAnglesToPort()
        {
            if (cboxPortStatus.Checked && port.IsOpen)
            {
                port.WriteLine(String.Format("A{0}B{1}", RadToDeg(-t1), RadToDeg(Math.PI - t2)) + "C" + t3);
            }
        }
    }
}
