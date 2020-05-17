using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace project
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        public Main()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            timerDay.Start();
            dT = Convert.ToDateTime("24.11.2020 06:00:00");
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            Application.Exit();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            beRunner bR = new beRunner();
            bR.Show();
            timerDay.Stop();
            this.Visible = false;            
        }

        private void logBut_Click(object sender, EventArgs e)
        {
            if (variables.gUserLogin == "" || variables.gUserLogin == null)
            {
                authForm aF = new authForm("Main");
                aF.Show();                
            }
            else
            {
                switch (variables.gUserRole)
                {
                    case "R":
                        menuRunner mRun = new menuRunner("Main");
                        mRun.Show();
                        break;
                    case "C":
                        menuCoordinator mCoor = new menuCoordinator("Main");
                        mCoor.Show();
                        break;
                    case "A":
                        menuAdmin mAdm = new menuAdmin("Main");
                        mAdm.Show();
                        break;
                    default:
                        break;
                }
            }
            timerDay.Stop();
            this.Visible = false;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            sponsorRunner sR = new sponsorRunner();
            sR.Show();
            timerDay.Stop();
            this.Visible = false;
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        { 

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            moreInfo moreInfo = new moreInfo();
            moreInfo.Show();
            timerDay.Stop();
            this.Visible = false;
        }

        private void exitBut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
