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
    public partial class thxForm : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        public thxForm()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            timerDay.Start();
            nameCharityL.Text = "Фонд - " + variables.gCharityName;
            nameRunnerL.Text = "Бегун - " + variables.gNameRunner;
            cashCharityL.Text = variables.gCharityCash.ToString() + "$";
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

        private void thxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose) Application.Exit();
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            if (mainForm.Visible == false) mainForm.Visible = true;
            checkClose = false;
            this.Close();
        }
    }
}
