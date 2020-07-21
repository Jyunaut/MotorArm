namespace Arm
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.Area = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // port
            // 
            this.port.PortName = "COM12";
            // 
            // Area
            // 
            this.Area.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Area.Location = new System.Drawing.Point(0, 0);
            this.Area.Name = "Area";
            this.Area.Size = new System.Drawing.Size(584, 561);
            this.Area.TabIndex = 0;
            this.Area.Paint += new System.Windows.Forms.PaintEventHandler(this.Area_Paint);
            this.Area.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Area_MouseMove);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.Area);
            this.MaximizeBox = false;
            this.Name = "Window";
            this.Text = "Motor Arm Control";
            this.Load += new System.EventHandler(this.Window_Load);
            this.MouseLeave += new System.EventHandler(this.Window_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Panel Area;
    }
}