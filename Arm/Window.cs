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
            return new[] { (double) Point.X / 10, (double) Point.Y / 10 };
        }

        private int RadToDeg(double rad)
        {
            return (int)(180 * rad / Math.PI);
        }

        private double c1, c2, s1, s2;
        private Point Point;

        private void Area_MouseMove(object sender, MouseEventArgs e)
        {
            if (Stopwatch.ElapsedMilliseconds > 15)
            {
                Stopwatch = Stopwatch.StartNew();
                //port.Write(String.Format("1:{0}2:{1}", e.X, e.Y));
                Point = e.Location;
                Area_Paint(this, null);
                Console.WriteLine(String.Format("Theta 1:{0}\tTheta 2:{1}", CoordsToMotorDeg()[0], CoordsToMotorDeg()[1]));
            }
        }

        private void Area_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Area.CreateGraphics();
            g.Clear(Color.White);
            g.DrawLine(System.Drawing.Pens.Black, 0, 0, Point.X, Point.Y);
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
