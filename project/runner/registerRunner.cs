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
using System.Text.RegularExpressions;


namespace project
{
    public partial class registerRunner : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        public registerRunner()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            timerDay.Start();
            dT = Convert.ToDateTime("24.11.2020 06:00:00");

            DateTime t1 = DateTime.Parse(DateTime.Today.ToString());
            DateTime t2 = t1.AddYears(-10);
            dateTimePicker1.MaxDate = t2;

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

        private void registerRunner_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose) Application.Exit();
        }

        void fillBox()
        {
            try
            {
                // Заполнение комбобокса полов
                variables.cmd = new MySqlCommand("SELECT * FROM `gender`", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    genderBox.Items.Add(variables.reader.GetString("Gender"));
                }
                variables.reader.Close();
                // Заполнение комбобокса стран
                variables.cmd = new MySqlCommand("SELECT * FROM `country`", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    countryBox.Items.Add(variables.reader.GetString("CountryName"));
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            beRunner bR = new beRunner();
            bR.Show();
            checkClose = false;
            this.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            checkClose = false;
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.Load(openFileDialog1.FileName);
                photoBox.Text = openFileDialog1.SafeFileName;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (validateEmail(mailBox.Text) == false) { MessageBox.Show("Некорректная почта."); return; }
            if (passBox.Text.Length < 6) { MessageBox.Show("Длина пароля должны быть не меньше 6 символов."); return; }
            if (!passBox.Text.Any(c => char.IsUpper(c))) { MessageBox.Show("В пароле нет заглавной буквы."); return; }
            if (!passBox.Text.Any(c => char.IsDigit(c))) { MessageBox.Show("В пароле нет цифры."); return; }            
            Regex r = new Regex(@"[!@#$%^]"); 
            Match m = r.Match(passBox.Text);
            while (m.Success) { count++; m = m.NextMatch(); }
            if (count == 0) { MessageBox.Show("В пароле нет ни одного из следующих символов: ! @ # $ % ^"); return; }            
            if (passBox.Text != rPassBox.Text) { MessageBox.Show("Пароли не совпадают."); return; }
            if (nameBox.Text == "") { MessageBox.Show("Вы не указали своё имя."); return; }
            if (famBox.Text == "") { MessageBox.Show("Вы не указали свою фамилию."); return; }
            if (genderBox.SelectedItem == null) { MessageBox.Show("Вы не указали своё пол."); return; }
            if (photoBox.Text == "") { MessageBox.Show("Вы не загрузили фотографию."); return; }
            if (countryBox.SelectedItem == null) { MessageBox.Show("Вы не указали свою страну."); return; }
            insertAccount();
        }

        void insertAccount()
        {
            int countMail = 0;
            try
            {
                sql.GetDBConnection();
                variables.cmd = new MySqlCommand("select * from user where Email = '" + mailBox.Text + "';", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    countMail++;
                }
                variables.reader.Close();
                if (countMail != 0) { MessageBox.Show("Аккаунт с такой почтой уже существует!"); return; }
                try
                {
                    variables.cmd = new MySqlCommand(
                        "insert into user (`Email`, `Password`, `FirstName`, `LastName`, `id_role`) values (" +
                        "'" + mailBox.Text + "', " +
                        "'" + passBox.Text + "', " +
                        "'" + nameBox.Text + "', " +
                        "'" + famBox.Text + "', " +
                        "'R');"
                        , variables.conn);
                    variables.cmd.ExecuteNonQuery();
                    try
                    {
                        variables.cmd = new MySqlCommand(
                        "insert into runner (`Email`, `Gender`, `DateOfBirth`, `CountryCode`, `photo`) values (" +
                        "'" + mailBox.Text + "', " +
                        "'" + genderBox.SelectedItem + "', " +
                        "'" + dateTimePicker1.Value + "', " +
                        "(SELECT `CountryCode` FROM `country` WHERE `CountryName` = '" + countryBox.SelectedItem + "'), " +
                        "'" + photoBox.Text + "');"
                        , variables.conn);
                        variables.cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            variables.conn.Close();
        }

        bool validateEmail(string email)
        {
            string[] words = email.Split('@');
            if (words.Length != 2)
                return false;
            string[] dotdomen = words[1].Split('.');
            if (dotdomen.Length != 2)
                return false;
            return true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MonthCalendar calendar = new MonthCalendar();
            calendar.Show();
        }
    }
}
