namespace project
{
    partial class menuRunner
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.timerDay = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.lTime = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.goBack = new MetroFramework.Controls.MetroButton();
            this.logout = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // timerDay
            // 
            this.timerDay.Enabled = true;
            this.timerDay.Interval = 1000;
            this.timerDay.Tick += new System.EventHandler(this.timerDay_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(0, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(551, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Меню бегуна";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.metroPanel2.Location = new System.Drawing.Point(0, 287);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(551, 28);
            this.metroPanel2.TabIndex = 8;
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
            this.lTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lTime.Location = new System.Drawing.Point(0, 0);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(551, 28);
            this.lTime.TabIndex = 4;
            this.lTime.Text = "                                  ";
            this.lTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lTime.UseCompatibleTextRendering = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(23, 187);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(164, 53);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Редактирование профиля";
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(193, 187);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(164, 53);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton2.TabIndex = 10;
            this.metroButton2.Text = "Мой спонсор";
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Highlight = true;
            this.metroButton3.Location = new System.Drawing.Point(363, 187);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(164, 53);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton3.TabIndex = 11;
            this.metroButton3.Text = "Контакты";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Highlight = true;
            this.metroButton5.Location = new System.Drawing.Point(107, 120);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(164, 53);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton5.TabIndex = 13;
            this.metroButton5.Text = "Регистрация на марафон";
            // 
            // metroButton6
            // 
            this.metroButton6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton6.Highlight = true;
            this.metroButton6.Location = new System.Drawing.Point(280, 120);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(164, 53);
            this.metroButton6.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton6.TabIndex = 14;
            this.metroButton6.Text = "Мои результаты";
            // 
            // goBack
            // 
            this.goBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goBack.Highlight = true;
            this.goBack.Location = new System.Drawing.Point(23, 257);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(75, 23);
            this.goBack.Style = MetroFramework.MetroColorStyle.Black;
            this.goBack.TabIndex = 15;
            this.goBack.Text = "Назад";
            this.goBack.Click += new System.EventHandler(this.goBack_Click);
            // 
            // logout
            // 
            this.logout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logout.Highlight = true;
            this.logout.Location = new System.Drawing.Point(451, 257);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.Style = MetroFramework.MetroColorStyle.Black;
            this.logout.TabIndex = 16;
            this.logout.Text = "Выйти";
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // menuRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(549, 315);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.goBack);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.label1);
            this.Name = "menuRunner";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "MARATHON SKILLS 2020";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.menuRunner_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.Timer timerDay;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.Label lTime;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton goBack;
        private MetroFramework.Controls.MetroButton logout;
    }
}