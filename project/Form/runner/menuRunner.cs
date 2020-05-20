using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class menuRunner : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        string nameWindow;
        public menuRunner(string name)
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            timerDay.Start();
            dT = Convert.ToDateTime("24.11.2020 06:00:00");
            nameWindow = name;
        }

        private void timerDay_Tick(object sender, EventArgs e)
        {
            DateTime test = DateTime.Now;
            tS = dT - test;

            if (tS.Minutes > 0)
            {
                if (tS.Hours >= 0)
                {
                    if (tS.Days > 0)
                    {
                        lTime.Text = "Осталось: " + tS.Days + " д. " + tS.Hours + " ч. " + tS.Minutes + " м.";
                        return;
                    }
                    lTime.Text = "Осталось: " + tS.Hours + " ч. " + tS.Minutes + " м.";
                    return;
                }
                lTime.Text = "Осталось: " + tS.Minutes + " м.";
                return;
            }
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            if (nameWindow == "Main")
            {
                Main mF = new Main();
                if (mF.Visible == false) mF.Visible = true;
            }
            else if (nameWindow == "beRunner")
            {
                beRunner bR = new beRunner();
                bR.Show();
            }
            checkClose = false;
            this.Close();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            variables.gUserLogin = "";
            variables.gUserId = "";
            variables.gUserRole = "";
            variables.gUserPassword = "";
            Main mF = new Main();
            if (mF.Visible == false) mF.Visible = true;
            checkClose = false;
            this.Close();
        }

        private void menuRunner_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose) Application.Exit();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            contactForm cF = new contactForm();
            if (cF.ShowDialog() == DialogResult.OK) { }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            regMarathon rM = new regMarathon();
            rM.Show();
            checkClose = false;
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            updateForm uF = new updateForm();
            uF.Show();
            checkClose = false;
            this.Close();
        }
    }
}
