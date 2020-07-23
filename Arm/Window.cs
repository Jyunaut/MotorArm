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

        // Motor Arm Properties (mm)
        private readonly double l1 = 80;
        private readonly double l2 = 80;
 
        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            Stopwatch = Stopwatch.StartNew();
            //port.Open();
        }

        private void Window_MouseLeave(object sender, EventArgs e)
        {
            //port.Write(String.Format("1:{0}2:{1}", 0, 0));
            Console.WriteLine(String.Format("Theta 1:{0}\tTheta 2:{1}", 0, 0));
        }

        private double[] ScaledPoint(Point Point)
        {
            return new[] { (double) Point.X / 2, (double) Point.Y / 2 };
        }

        private int RadToDeg(double rad)
        {
            return (int)(180 * rad / Math.PI);
        }

        private double DegToRad(double deg)
        {
            return Math.PI * deg / 180.0;
        }

        private double c1, c2, s1, s2;
        private Point Point;

        private void Area_MouseMove(object sender, MouseEventArgs e)
        {
            if (Stopwatch.ElapsedMilliseconds > 15)
            {
                Stopwatch = Stopwatch.StartNew();
                //port.Write(String.Format("{0}", e.X));
                //Console.WriteLine(String.Format("{0}", e.X));
                Point = e.Location;
                Area_Paint(this, null);
                //Console.WriteLine(String.Format("Theta 1:{0}\tTheta 2:{1}", CoordsToMotorDeg()[0], CoordsToMotorDeg()[1]));
            }
        }

        private void Area_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Area.CreateGraphics();

            Point Link1Coords = GetJointCoords(1);
            Point Link2Coords = GetJointCoords(2);

            g.Clear(Color.White);
            g.DrawLine(System.Drawing.Pens.Black, 0, 0, Link1Coords.X, Link1Coords.Y);
            g.DrawLine(System.Drawing.Pens.Black, Link1Coords.X, Link1Coords.Y, Link1Coords.X + Link2Coords.X, Link1Coords.Y + Link2Coords.Y);
            Console.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}", Link1Coords.X + Link2Coords.X, Link1Coords.Y + Link2Coords.Y, Point.X, Point.Y));
        }

        private Point GetJointCoords(int link)
        {
            int[] motorDegs = CoordsToMotorDeg();

            Point Coords = new Point
            {
                X = (int)(l1 * Math.Cos(DegToRad(motorDegs[link - 1]))),
                Y = (int)(l1 * Math.Sin(DegToRad(motorDegs[link - 1])))
            };

            return Coords;
        }

        private int[] CoordsToMotorDeg()
        {
            c2 = (Math.Pow(ScaledPoint(Point)[0], 2) + Math.Pow(ScaledPoint(Point)[1], 2) - Math.Pow(l1, 2) - Math.Pow(l2, 2)) / (2 * l1 * l2);
            s2 = Math.Sqrt(1 - Math.Pow(c2, 2));
            c1 = ((l1 + l2 * c2) * ScaledPoint(Point)[0] + l2 * s2 * ScaledPoint(Point)[1]) / (Math.Pow(l1, 2) + Math.Pow(l2, 2) + 2 * l1 * l2 * c2);
            s1 = (-l2 * s2 * ScaledPoint(Point)[0] + (l1 + l2 * c2) * ScaledPoint(Point)[1]) / (Math.Pow(l1, 2) + Math.Pow(l2, 2) + 2 * l1 * l2 * c2);
            return new[] { RadToDeg(Math.Atan2(s1, c1)), RadToDeg(Math.Atan2(Math.Sqrt(1 - Math.Pow(c2, 2)), c2)) };
        }
    }
}
