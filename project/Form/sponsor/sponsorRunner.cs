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
    public partial class sponsorRunner : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        int cashP = 0;
        public sponsorRunner()
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
                // Заполнение комбобокса бегунов
                variables.cmd = new MySqlCommand("SELECT * FROM `user` WHERE `id_role` = 'R'", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    runnerBox.Items.Add(variables.reader.GetString("FirstName") + " " + variables.reader.GetString("LastName"));
                }
                variables.reader.Close();
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

        private void sponsorRunner_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose) Application.Exit();
        }

        private void metroTextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkTextBox(e);
        }

        private void metroTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkTextBox(e);
        }

        private void metroTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkTextBox(e);
        }

        private void metroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkTextBox(e);
        }

        private void metroTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkTextBox(e);
        }

        private void metroTextBox7_TextChanged(object sender, EventArgs e)
        {
            cashP = Convert.ToInt32(cashBox.Text);
            cash.Text = cashP.ToString() + "$";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (cashP <= 10) cashP = 0;
            else cashP -= 10;
            cashBox.Text = cashP.ToString();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            cashP += 10;
            cashBox.Text = cashP.ToString();
        }

        void checkTextBox(KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            if (mainForm.Visible == false) mainForm.Visible = true;
            checkClose = false;
            this.Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (nameBox.Text != null && runnerBox.SelectedItem != null
                && nameCardBox.Text != null && numberCardBox.Text != null
                && monthCardBox.Text != null && yearCardBox.Text != null
                && cvcBox.Text != null && charityBox.SelectedItem != null)
            {
                int numberCardLenght = numberCardBox.Text.Length;
                int monthCard = Convert.ToInt32(monthCardBox.Text);
                int monthCardLenght = monthCardBox.Text.Length;
                int yearCard = Convert.ToInt32(yearCardBox.Text);
                int cvcLenght = cvcBox.Text.Length;
                if (numberCardLenght == 16)
                {
                    if ((monthCard <= 9 && monthCardLenght == 1) || monthCardLenght == 2)
                    {
                        if (monthCard <= 9 && monthCardLenght == 1) variables.gMonthCard = "0" + monthCard;
                        else variables.gMonthCard = monthCard.ToString();

                        if (monthCard < 13 && yearCard > 19)
                        {
                            variables.gYearCard = "20" + yearCard;
                            if (cvcLenght == 3)
                            {
                                donateCharity();
                            }
                            else MessageBox.Show("Некорректный CVC код!");
                        }
                        else MessageBox.Show("Некорректные данные срока действия карты!");
                    }                    
                }
                else MessageBox.Show("Некорректный номер карты! ");                
            }
            else MessageBox.Show("Все поля должны быть заполнены!");
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

        void donateCharity()
        {
            try
            {
                sql.GetDBConnection();

                variables.gNameRunner = runnerBox.SelectedItem.ToString();
                variables.gCharityName = charityBox.SelectedItem.ToString();
                variables.gCharityCash = Convert.ToInt32(cashBox.Text);

                thxForm thxForm = new thxForm();
                thxForm.Show();
                checkClose = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            variables.conn.Close();
        }

        private void charityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            variables.gCharityName = charityBox.SelectedItem.ToString();
        }
    }
}