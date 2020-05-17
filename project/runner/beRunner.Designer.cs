namespace project
{
    partial class beRunner
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.logBut = new MetroFramework.Controls.MetroButton();
            this.goBackBut = new MetroFramework.Controls.MetroButton();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.lTime = new System.Windows.Forms.Label();
            this.timerDay = new System.Windows.Forms.Timer(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(72, 78);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(309, 54);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Я участвовал ранее";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(72, 152);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(309, 54);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton2.TabIndex = 1;
            this.metroButton2.Text = "Я новый участник";
            // 
            // logBut
            // 
            this.logBut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBut.Highlight = true;
            this.logBut.Location = new System.Drawing.Point(356, 221);
            this.logBut.Name = "logBut";
            this.logBut.Size = new System.Drawing.Size(75, 23);
            this.logBut.Style = MetroFramework.MetroColorStyle.Black;
            this.logBut.TabIndex = 2;
            this.logBut.Text = "Войти";
            this.logBut.Click += new System.EventHandler(this.logBut_Click);
            // 
            // goBackBut
            // 
            this.goBackBut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goBackBut.Highlight = true;
            this.goBackBut.Location = new System.Drawing.Point(23, 221);
            this.goBackBut.Name = "goBackBut";
            this.goBackBut.Size = new System.Drawing.Size(75, 23);
            this.goBackBut.Style = MetroFramework.MetroColorStyle.Black;
            this.goBackBut.TabIndex = 3;
            this.goBackBut.Text = "Назад";
            this.goBackBut.Click += new System.EventHandler(this.goBackBut_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel2.BackColor = System.Drawing.Color.DarkGray;
            this.metroPanel2.Controls.Add(this.lTime);
            this.metroPanel2.CustomBackground = true;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 257);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(455, 28);
            this.metroPanel2.TabIndex = 6;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // lTime
            // 
            this.lTime.AccessibleDescription = "";
            this.lTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lTime.AutoEllipsis = true;
            this.lTime.BackColor = System.Drawing.Color.Transparent;
            this.lTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lTime.Location = new System.Drawing.Point(0, 0);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(455, 28);
            this.lTime.TabIndex = 4;
            this.lTime.Text = "                                  ";
            this.lTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lTime.UseCompatibleTextRendering = true;
            // 
            // timerDay
            // 
            this.timerDay.Enabled = true;
            this.timerDay.Interval = 1000;
            this.timerDay.Tick += new System.EventHandler(this.timerDay_Tick);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // beRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(454, 284);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.goBackBut);
            this.Controls.Add(this.logBut);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Name = "beRunner";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "MARATHON SKILLS 2020";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.beRunner_FormClosing);
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton logBut;
        private MetroFramework.Controls.MetroButton goBackBut;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Timer timerDay;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}