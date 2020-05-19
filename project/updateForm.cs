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

namespace project
{
    public partial class updateForm : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
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
                    FileInfo f = new FileInfo("resources\\" + variables.gUserLogin + "\\" + photoBox.Text);
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
            menuRunner mR = new menuRunner("updateForm");
            mR.Show();
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
    }
}
