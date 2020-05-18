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
    public partial class beRunner : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        public beRunner()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            timerDay.Start();
            dT = Convert.ToDateTime("24.11.2020 06:00:00");
        }

        private void beRunner_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose)
                Application.Exit();
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

        private void goBackBut_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            if (mainForm.Visible == false) mainForm.Visible = true;
            checkClose = false;
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (variables.gUserLogin == "" || variables.gUserLogin == null)
            {
                authForm aF = new authForm("beRunner");
                aF.Show();
            }
            else
            {
                switch (variables.gUserRole)
                {
                    case "R":
                        menuRunner mRun = new menuRunner("beRunner");
                        mRun.Show();
                        break;
                    case "C":
                        menuCoordinator mCoor = new menuCoordinator("beRunner");
                        mCoor.Show();
                        break;
                    case "A":
                        menuAdmin mAdm = new menuAdmin("beRunner");
                        mAdm.Show();
                        break;
                    default:
                        break;
                }
            }
            checkClose = false;
            this.Close();
        }

        private void logBut_Click(object sender, EventArgs e)
        {
            if (variables.gUserLogin == "" || variables.gUserLogin == null)
            {
                authForm aF = new authForm("beRunner");
                aF.Show();                
            }
            else
            {
                switch (variables.gUserRole)
                {
                    case "R":
                        menuRunner mRun = new menuRunner("beRunner");
                        mRun.Show();                        
                        break;
                    case "C":
                        menuCoordinator mCoor = new menuCoordinator("beRunner");
                        mCoor.Show();
                        break;
                    case "A":
                        menuAdmin mAdm = new menuAdmin("beRunner");
                        mAdm.Show();
                        break;
                    default:
                        break;                        
                }
            }
            checkClose = false;
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (variables.gUserLogin == "" || variables.gUserLogin == null)
            {
                registerRunner rRun = new registerRunner();
                rRun.Show(); 
                checkClose = false;
                this.Close();
            }
            else
            {
                if (MessageBox.Show("Вы уже авторизованы в системе.\nДля продолжения выйдите с своего аккаунта.\nВыйти?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
                {
                    variables.gUserId = "";
                    variables.gUserLogin = "";
                    variables.gUserPassword = "";
                    variables.gUserRole = "";
                    registerRunner rRun = new registerRunner();
                    rRun.Show();
                    checkClose = false;
                    this.Close();
                }
            }            
        }
    }
}
