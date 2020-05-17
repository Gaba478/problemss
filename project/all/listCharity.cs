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
    public partial class listCharity : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        int count = 1;
        public listCharity()
        {
            InitializeComponent();
            timerDay.Start();
            dT = Convert.ToDateTime("24.11.2020 06:00:00");

            try
            {
                sql.GetDBConnection();
                fillCharity();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            variables.conn.Close();
        }

        void fillCharity()
        {            
            try
            {
                variables.cmd = new MySqlCommand("SELECT * FROM `charity`", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    variables.gCharityDescription = variables.reader.GetString("CharityDescription");
                    variables.gCharityImage = "resources\\charity\\" + variables.reader.GetString("CharityLogo");
                    loadPicture();
                    count++; 
                }
                variables.reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void loadPicture()
        {
            switch (count)
            {
                case 1:
                    richTextBox1.Text = variables.gCharityDescription;
                    pictureBox1.Load(variables.gCharityImage);
                    break;
                case 2:
                    richTextBox2.Text = variables.gCharityDescription;
                    pictureBox2.Load(variables.gCharityImage);
                    break;
                case 3:
                    richTextBox3.Text = variables.gCharityDescription;
                    pictureBox3.Load(variables.gCharityImage);
                    break;
                case 4:
                    richTextBox4.Text = variables.gCharityDescription;
                    pictureBox4.Load(variables.gCharityImage);
                    break;
                case 5:
                    richTextBox5.Text = variables.gCharityDescription;
                    pictureBox5.Load(variables.gCharityImage);
                    break;
                case 6:
                    richTextBox6.Text = variables.gCharityDescription;
                    pictureBox6.Load(variables.gCharityImage);
                    break;
                case 7:
                    richTextBox7.Text = variables.gCharityDescription;
                    pictureBox7.Load(variables.gCharityImage);
                    break;
                case 8:
                    richTextBox8.Text = variables.gCharityDescription;
                    pictureBox8.Load(variables.gCharityImage);
                    break;
                case 9:
                    richTextBox9.Text = variables.gCharityDescription;
                    pictureBox9.Load(variables.gCharityImage);
                    break;
                case 10:
                    richTextBox10.Text = variables.gCharityDescription;
                    pictureBox10.Load(variables.gCharityImage);
                    break;
                case 11:
                    richTextBox11.Text = variables.gCharityDescription;
                    pictureBox11.Load(variables.gCharityImage);
                    break;
                case 12:
                    richTextBox12.Text = variables.gCharityDescription;
                    pictureBox12.Load(variables.gCharityImage);
                    break;
                case 13:
                    richTextBox13.Text = variables.gCharityDescription;
                    pictureBox13.Load(variables.gCharityImage);
                    break;
                case 14:
                    richTextBox14.Text = variables.gCharityDescription;
                    pictureBox14.Load(variables.gCharityImage);
                    break;
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

        private void listCharity_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose) Application.Exit();
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            moreInfo moreInfo = new moreInfo();
            moreInfo.Show();
            checkClose = false;
            this.Close();
        }
    }
}
