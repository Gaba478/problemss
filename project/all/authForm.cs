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
    public partial class authForm : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        string typeWindow;
        public authForm(string type)
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            timerDay.Start();
            dT = Convert.ToDateTime("24.11.2020 06:00:00");
            typeWindow = type;
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

        private void authForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose)
                Application.Exit();
        }

        private void goBackBut_Click(object sender, EventArgs e)
        {
            if (typeWindow == "Main")
            {
                Main mainForm = new Main();
                if (mainForm.Visible == false) mainForm.Visible = true;                
            }
            else if (typeWindow == "beRunner")
            {
                beRunner bR = new beRunner();
                bR.Show();
            }
            checkClose = false;
            this.Close();
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            if (mainForm.Visible == false) mainForm.Visible = true;
            checkClose = false;
            this.Close();
        }

        private void logBut_Click(object sender, EventArgs e)
        {
            if (mailTextBox.Text != "" && passTextBox.Text != "")
            {
                try
                {
                    int count = 0;
                    sql.GetDBConnection();
                    variables.cmd = new MySqlCommand("select Password, id_role from user where Email = '" + mailTextBox.Text + "';", variables.conn);
                    MySqlDataReader accReader = variables.cmd.ExecuteReader();
                    while (accReader.Read())
                    {
                        count = 1;
                        variables.gUserPassword = accReader.GetString("Password");
                        variables.gUserRole = accReader.GetString("id_role");
                    }
                    accReader.Close();
                    if (count == 0) { MessageBox.Show("Аккаунт с такой почтой не найден!"); return; }
                    if (passTextBox.Text != variables.gUserPassword) MessageBox.Show("Пароль введен неверно!");
                    else
                    {
                        switch (variables.gUserRole)
                        {
                            case "R":
                                variables.gUserLogin = mailTextBox.Text;
                                variables.gUserRole = "R";
                                menuRunner mR = new menuRunner(typeWindow);
                                mR.Show();
                                break;
                            case "C":
                                variables.gUserLogin = mailTextBox.Text;
                                variables.gUserRole = "C";
                                menuCoordinator mC = new menuCoordinator(typeWindow);
                                mC.Show();
                                break;
                            case "A":
                                variables.gUserLogin = mailTextBox.Text;
                                variables.gUserRole = "A";
                                menuAdmin mA = new menuAdmin(typeWindow);
                                mA.Show();
                                break;
                            default:
                                MessageBox.Show("Ваша роль - " + variables.gUserRole + ". Для неё нет формы.");
                                break;
                        }
                        checkClose = false;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                variables.conn.Close();
            }
            else MessageBox.Show("Все поля должны быть заполнены!");            
        }
    }
}
