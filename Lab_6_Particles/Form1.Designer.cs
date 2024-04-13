namespace Lab_6_Particles
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.display = new System.Windows.Forms.PictureBox();
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGravitation = new System.Windows.Forms.TrackBar();
            this.tbGravitation2 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGravitation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGravitation2)).BeginInit();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(12, 12);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(1054, 345);
            this.display.TabIndex = 0;
            this.display.TabStop = false;
            this.display.MouseMove += new System.Windows.Forms.MouseEventHandler(this.display_MouseMove);
            // 
            // displayTimer
            // 
            this.displayTimer.Enabled = true;
            this.displayTimer.Interval = 40;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(12, 397);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(353, 69);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Направление";
            // 
            // tbGravitation
            // 
            this.tbGravitation.Location = new System.Drawing.Point(403, 397);
            this.tbGravitation.Maximum = 100;
            this.tbGravitation.Name = "tbGravitation";
            this.tbGravitation.Size = new System.Drawing.Size(198, 69);
            this.tbGravitation.TabIndex = 4;
            this.tbGravitation.Scroll += new System.EventHandler(this.tbGravitation_Scroll);
            // 
            // tbGravitation2
            // 
            this.tbGravitation2.Location = new System.Drawing.Point(619, 397);
            this.tbGravitation2.Maximum = 100;
            this.tbGravitation2.Name = "tbGravitation2";
            this.tbGravitation2.Size = new System.Drawing.Size(198, 69);
            this.tbGravitation2.TabIndex = 5;
            this.tbGravitation2.Scroll += new System.EventHandler(this.tbGravitation2_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 478);
            this.Controls.Add(this.tbGravitation2);
            this.Controls.Add(this.tbGravitation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.display);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGravitation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGravitation2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbGravitation;
        private System.Windows.Forms.TrackBar tbGravitation2;
    }
}

