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
        public Stopwatch stopwatch { get; set; }

        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            stopwatch = Stopwatch.StartNew();
            port.Open();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds > 15)
            {
                stopwatch = Stopwatch.StartNew();
                port.Write(String.Format("{0}", e.X));
                Console.WriteLine(e.X);
            }
        }
    }
}
