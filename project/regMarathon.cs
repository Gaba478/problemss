using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project
{
    public partial class regMarathon : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        int cash = 0;
        int cashDef = 0;
        int cashFee = 0;
        public regMarathon()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            timerDay.Start();
            dT = Convert.ToDateTime("24.11.2020 06:00:00");
            try
            {
                sql.GetDBConnection();
                fillBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            variables.conn.Close();
        }

        void fillBox()
        {
            try
            {
                // Заполнение комбобокса фондов
                variables.cmd = new MySqlCommand("SELECT * FROM `charity`", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    charityBox.Items.Add(variables.reader.GetString("CharityName"));
                }
                variables.reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void regMarathon_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose) Application.Exit();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            menuRunner mR = new menuRunner("regMarathon");
            mR.Show();
            checkClose = false;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (charityBox.SelectedItem != null)
            {
                informationCharity();
            }
        }

        void informationCharity()
        {
            try
            {
                sql.GetDBConnection();

                variables.cmd = new MySqlCommand("SELECT * FROM `charity` where `CharityName` = '" + charityBox.SelectedItem + "'", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    variables.gCharityDescription = variables.reader.GetString("CharityDescription");
                    variables.gCharityImage = variables.reader.GetString("CharityLogo");
                }
                variables.reader.Close();

                infoCharity infoCharity = new infoCharity();
                if (infoCharity.ShowDialog() == DialogResult.OK) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            variables.conn.Close();
        }

        private void cashBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            cash -= cashDef;
            if (metroCheckBox1.Checked) cashDef += 145;
            else
            {
                if (cashDef <= 145)
                    cashDef = 0;
                else
                    cashDef -= 145;
            }
            cash += cashDef;
            cashL.Text = cash.ToString() + "$";
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            cash -= cashDef;
            if (metroCheckBox2.Checked) cashDef += 75;
            else
            {
                if (cashDef <= 75)
                    cashDef = 0;
                else
                    cashDef -= 75;
            }
            cash += cashDef;
            cashL.Text = cash.ToString() + "$";
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            cash -= cashDef;
            if (metroCheckBox3.Checked) cashDef += 20;
            else
            {
                if (cashDef <= 20)
                    cashDef = 0;
                else
                    cashDef -= 20;
            }
            cash += cashDef;
            cashL.Text = cash.ToString() + "$";

        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cash -= cashDef;
            if (metroRadioButton2.Checked) cashDef += 20;
            else
            {
                if (cashDef <= 20)
                    cashDef = 0;
                else
                    cashDef -= 20;
            }
            cash += cashDef;
            cashL.Text = cash.ToString() + "$";
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cash -= cashDef;
            if (metroRadioButton3.Checked) cashDef += 45;
            else
            {
                if (cashDef <= 45)
                    cashDef = 0;
                else
                    cashDef -= 45;
            }
            cash += cashDef;
            cashL.Text = cash.ToString() + "$";
        }

        private void cashBox_Leave(object sender, EventArgs e)
        {
            try
            {
                cash -= cashFee;
                cashFee = Convert.ToInt32(cashBox.Text);
                cash += cashFee;
                cashL.Text = cash.ToString() + "$";
            }
            catch (Exception ex) { cashBox.Text = "0"; }
        }
    }
}
