namespace Lab_6_Particles
{
    partial class SolarSistemForm
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
            this.display = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.readyButton = new System.Windows.Forms.Button();
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.pullButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(12, 12);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(1347, 920);
            this.display.TabIndex = 0;
            this.display.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(1365, 12);
            this.trackBar1.Maximum = 13;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(201, 69);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(1365, 87);
            this.trackBar2.Maximum = 45;
            this.trackBar2.Minimum = -45;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(201, 69);
            this.trackBar2.TabIndex = 1;
            // 
            // readyButton
            // 
            this.readyButton.Location = new System.Drawing.Point(1393, 162);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(173, 61);
            this.readyButton.TabIndex = 3;
            this.readyButton.Text = "Подготовить астероид";
            this.readyButton.UseVisualStyleBackColor = true;
            // 
            // displayTimer
            // 
            this.displayTimer.Enabled = true;
            this.displayTimer.Interval = 40;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // pullButton
            // 
            this.pullButton.Location = new System.Drawing.Point(1393, 239);
            this.pullButton.Name = "pullButton";
            this.pullButton.Size = new System.Drawing.Size(173, 61);
            this.pullButton.TabIndex = 4;
            this.pullButton.Text = "Запустить астероид";
            this.pullButton.UseVisualStyleBackColor = true;
            // 
            // SolarSistemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 944);
            this.Controls.Add(this.pullButton);
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.display);
            this.Name = "SolarSistemForm";
            this.Text = "SolarSistemForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button readyButton;
        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.Button pullButton;
    }
}