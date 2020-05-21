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
using System.IO;
using System.Text.RegularExpressions;

namespace project
{
    public partial class updateForm : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        bool checkImage = false;
        string tempPhoto;
        public updateForm()
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
                fillAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            variables.conn.Close();
        }

        void fillAll()
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
                // Заполнение данных пользователя
                variables.cmd = new MySqlCommand("select user.FirstName, user.LastName, runner.Gender, runner.DateOfBirth, " +
                    "country.CountryName, runner.photo from user, runner, country where user.Email = '" + variables.gUserLogin + "' " +
                    "and country.CountryCode = runner.CountryCode and user.Email = runner.Email", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    mailL.Text = variables.gUserLogin;
                    nameBox.Text = variables.reader.GetString("FirstName");
                    famBox.Text = variables.reader.GetString("LastName");
                    genderBox.SelectedItem = variables.reader.GetString("Gender");
                    dateTimePicker1.Value = variables.reader.GetDateTime("DateOfBirth");
                    countryBox.SelectedItem = variables.reader.GetString("CountryName");
                    photoBox.Text = variables.reader.GetString("photo");
                    tempPhoto = "resources\\" + variables.gUserLogin + "\\" + photoBox.Text;
                    FileInfo f = new FileInfo(tempPhoto);
                    if (f.Exists) { pictureBox1.Load(f.FullName); photoBox.Text = f.Name; }
                    else { pictureBox1.Load("resources\\none.png"); photoBox.Text = "none"; }
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

        private void updateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose) Application.Exit();
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            menuRunner mR = new menuRunner("updateForm");
            mR.Show();
            checkClose = false;
            this.Close();
        }

        private void updateRunBut_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (passBox.Text != "")
            {
                if (passBox.Text.Length < 6) { MessageBox.Show("Длина пароля должны быть не меньше 6 символов."); return; }
                if (!passBox.Text.Any(c => char.IsUpper(c))) { MessageBox.Show("В пароле нет заглавной буквы."); return; }
                if (!passBox.Text.Any(c => char.IsDigit(c))) { MessageBox.Show("В пароле нет цифры."); return; }
                Regex r = new Regex(@"[!@#$%^]");
                Match m = r.Match(passBox.Text);
                while (m.Success) { count++; m = m.NextMatch(); }
                if (count == 0) { MessageBox.Show("В пароле нет ни одного из следующих символов: ! @ # $ % ^"); return; }
                if (passBox.Text != rPassBox.Text) { MessageBox.Show("Пароли не совпадают."); return; }
                variables.gUserPassword = passBox.Text;
            }            
            if (nameBox.Text == "") { MessageBox.Show("Вы не указали своё имя."); return; }
            if (famBox.Text == "") { MessageBox.Show("Вы не указали свою фамилию."); return; }
            if (genderBox.SelectedItem == null) { MessageBox.Show("Вы не указали свой пол."); return; }
            if (photoBox.Text == "") { MessageBox.Show("Вы не загрузили фотографию."); return; }
            if (countryBox.SelectedItem == null) { MessageBox.Show("Вы не указали свою страну."); return; }
            updateRunner();            
        }

        void updateRunner()
        {
            try
            {
                sql.GetDBConnection();
                variables.cmd = new MySqlCommand("update user, runner set " +
                    "user.Password = '" + variables.gUserPassword + "', " +
                    "user.FirstName = '" + nameBox.Text + "', " +
                    "user.LastName = '" + famBox.Text + "', " +
                    "runner.Gender = '" + genderBox.SelectedItem + "', " +
                    "runner.DateOfBirth = '" + dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + "', " +
                    "runner.CountryCode = (select CountryCode from country where CountryName = '" + countryBox.SelectedItem + "'), " +
                    "runner.photo = '" + photoBox.Text + "' " +
                    "where user.Email = '" + variables.gUserLogin + "';", variables.conn);
                variables.cmd.ExecuteNonQuery();

                DirectoryInfo directoryInfo = new DirectoryInfo("resources\\" + variables.gUserLogin);
                FileInfo fileInfo = new FileInfo(tempPhoto);
                string justFun = "resources\\" + variables.gUserLogin + "\\" + photoBox.Text;
                if (directoryInfo.Exists)
                {
                    if (checkImage)
                        fileInfo.CopyTo(justFun);
                }
                else
                {
                    directoryInfo.Create();
                    if (fileInfo.Exists) fileInfo.CopyTo(justFun);
                }    

                menuRunner mR = new menuRunner("updateForm");
                mR.Show();
                checkClose = false;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            variables.conn.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                photoBox.Text = openFileDialog1.SafeFileName;
                tempPhoto = openFileDialog1.FileName;
                checkImage = true;
            }
        }
    }
}
