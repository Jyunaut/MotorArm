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
            this.pnlSimulation = new System.Windows.Forms.Panel();
            this.lblLinkAngles = new System.Windows.Forms.Label();
            this.lblEndEffectorCoords = new System.Windows.Forms.Label();
            this.lblMouseCoords = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboxPortStatus = new System.Windows.Forms.CheckBox();
            this.lblPortStatus = new System.Windows.Forms.Label();
            this.lblPortNum = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.pnlSimulation.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // port
            // 
            this.port.PortName = "COM12";
            // 
            // pnlSimulation
            // 
            this.pnlSimulation.Controls.Add(this.lblLinkAngles);
            this.pnlSimulation.Controls.Add(this.lblEndEffectorCoords);
            this.pnlSimulation.Controls.Add(this.lblMouseCoords);
            this.pnlSimulation.Controls.Add(this.panel1);
            this.pnlSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSimulation.Location = new System.Drawing.Point(0, 0);
            this.pnlSimulation.Name = "pnlSimulation";
            this.pnlSimulation.Size = new System.Drawing.Size(624, 601);
            this.pnlSimulation.TabIndex = 0;
            this.pnlSimulation.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSimulation_Paint);
            this.pnlSimulation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSimulation_MouseMove);
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
            // lblEndEffectorCoords
            // 
            this.lblEndEffectorCoords.AutoSize = true;
            this.lblEndEffectorCoords.Location = new System.Drawing.Point(116, 9);
            this.lblEndEffectorCoords.Name = "lblEndEffectorCoords";
            this.lblEndEffectorCoords.Size = new System.Drawing.Size(125, 39);
            this.lblEndEffectorCoords.TabIndex = 3;
            this.lblEndEffectorCoords.Text = "End Effector Coordinates\r\nX: 0\r\nY: 0";
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.cboxPortStatus);
            this.panel1.Controls.Add(this.lblPortStatus);
            this.panel1.Controls.Add(this.lblPortNum);
            this.panel1.Controls.Add(this.numPort);
            this.panel1.Location = new System.Drawing.Point(0, 321);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 280);
            this.panel1.TabIndex = 5;
            // 
            // cboxPortStatus
            // 
            this.cboxPortStatus.AutoSize = true;
            this.cboxPortStatus.Location = new System.Drawing.Point(12, 43);
            this.cboxPortStatus.Name = "cboxPortStatus";
            this.cboxPortStatus.Size = new System.Drawing.Size(74, 17);
            this.cboxPortStatus.TabIndex = 7;
            this.cboxPortStatus.Text = "Port Open";
            this.cboxPortStatus.UseVisualStyleBackColor = true;
            this.cboxPortStatus.CheckedChanged += new System.EventHandler(this.cboxPortStatus_CheckedChanged);
            // 
            // lblPortStatus
            // 
            this.lblPortStatus.AutoSize = true;
            this.lblPortStatus.Location = new System.Drawing.Point(12, 89);
            this.lblPortStatus.Name = "lblPortStatus";
            this.lblPortStatus.Size = new System.Drawing.Size(97, 13);
            this.lblPortStatus.TabIndex = 6;
            this.lblPortStatus.Text = "Port Status: Closed";
            // 
            // lblPortNum
            // 
            this.lblPortNum.AutoSize = true;
            this.lblPortNum.Location = new System.Drawing.Point(9, 19);
            this.lblPortNum.Name = "lblPortNum";
            this.lblPortNum.Size = new System.Drawing.Size(55, 13);
            this.lblPortNum.TabIndex = 3;
            this.lblPortNum.Text = "Serial Port";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(70, 17);
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(39, 20);
            this.numPort.TabIndex = 2;
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 601);
            this.Controls.Add(this.pnlSimulation);
            this.MaximizeBox = false;
            this.Name = "Window";
            this.Text = "Motor Arm Control";
            this.Load += new System.EventHandler(this.Window_Load);
            this.pnlSimulation.ResumeLayout(false);
            this.pnlSimulation.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Panel pnlSimulation;
        private System.Windows.Forms.Label lblMouseCoords;
        private System.Windows.Forms.Label lblEndEffectorCoords;
        private System.Windows.Forms.Label lblLinkAngles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lblPortNum;
        private System.Windows.Forms.Label lblPortStatus;
        private System.Windows.Forms.CheckBox cboxPortStatus;
    }
}