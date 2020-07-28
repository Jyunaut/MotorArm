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
            this.lblMouseCoords = new System.Windows.Forms.Label();
            this.lblEndEffectorCoords = new System.Windows.Forms.Label();
            this.lblLinkAngles = new System.Windows.Forms.Label();
            this.Area.SuspendLayout();
            this.SuspendLayout();
            // 
            // port
            // 
            this.port.PortName = "COM12";
            // 
            // Area
            // 
            this.Area.Controls.Add(this.lblLinkAngles);
            this.Area.Controls.Add(this.lblEndEffectorCoords);
            this.Area.Controls.Add(this.lblMouseCoords);
            this.Area.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Area.Location = new System.Drawing.Point(0, 0);
            this.Area.Name = "Area";
            this.Area.Size = new System.Drawing.Size(624, 601);
            this.Area.TabIndex = 0;
            this.Area.Paint += new System.Windows.Forms.PaintEventHandler(this.Area_Paint);
            this.Area.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Area_MouseMove);
            // 
            // lblMouseCoords
            // 
            this.lblMouseCoords.AutoSize = true;
            this.lblMouseCoords.Location = new System.Drawing.Point(12, 9);
            this.lblMouseCoords.Name = "lblMouseCoords";
            this.lblMouseCoords.Size = new System.Drawing.Size(98, 39);
            this.lblMouseCoords.TabIndex = 1;
            this.lblMouseCoords.Text = "Mouse Coordinates\r\nX: 0\r\nY: 0";
            // 
            // lblEndEffectorCoords
            // 
            this.lblEndEffectorCoords.AutoSize = true;
            this.lblEndEffectorCoords.Location = new System.Drawing.Point(116, 9);
            this.lblEndEffectorCoords.Name = "lblEndEffectorCoords";
            this.lblEndEffectorCoords.Size = new System.Drawing.Size(125, 39);
            this.lblEndEffectorCoords.TabIndex = 3;
            this.lblEndEffectorCoords.Text = "End Effector Coordinates\r\nX: 0\r\nY: 0";
            // 
            // lblLinkAngles
            // 
            this.lblLinkAngles.AutoSize = true;
            this.lblLinkAngles.Location = new System.Drawing.Point(247, 9);
            this.lblLinkAngles.Name = "lblLinkAngles";
            this.lblLinkAngles.Size = new System.Drawing.Size(62, 39);
            this.lblLinkAngles.TabIndex = 4;
            this.lblLinkAngles.Text = "Link Angles\r\nTheta 1: 0\r\nTheta 2: 0";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 601);
            this.Controls.Add(this.Area);
            this.MaximizeBox = false;
            this.Name = "Window";
            this.Text = "Motor Arm Control";
            this.Load += new System.EventHandler(this.Window_Load);
            this.MouseLeave += new System.EventHandler(this.Window_MouseLeave);
            this.Area.ResumeLayout(false);
            this.Area.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Panel Area;
        private System.Windows.Forms.Label lblMouseCoords;
        private System.Windows.Forms.Label lblEndEffectorCoords;
        private System.Windows.Forms.Label lblLinkAngles;
    }
}