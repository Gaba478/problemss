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
    public partial class userManagement : MetroFramework.Forms.MetroForm
    {
        TimeSpan tS = new TimeSpan();
        DateTime dT = new DateTime();
        bool checkClose = true;
        int countUser = 0;
        public userManagement()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            timerDay.Start();
            dT = Convert.ToDateTime("24.11.2020 06:00:00");
            fillGrid();
        }

        void fillGrid()
        {
            try
            {
                sql.GetDBConnection();
                string role = "";
                List<string[]> data = new List<string[]>();
                variables.sql = "SELECT distinct `id_role` FROM `user`";
                variables.cmd = new MySqlCommand(variables.sql, variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    switch (variables.reader.GetString("id_role"))
                    {
                        case "R":
                            role = "Бегун";
                            break;
                        case "C":
                            role = "Координатор";
                            break;
                        case "A":
                            role = "Администратор";
                            break;
                    }
                    metroComboBox1.Items.Add(role);
                }
                variables.reader.Close();
                variables.sql = "SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user`";
                variables.cmd = new MySqlCommand(variables.sql, variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    switch (variables.reader.GetString("id_role"))
                    {
                        case "R":
                            role = "Бегун";
                            break;
                        case "C":
                            role = "Координатор";
                            break;
                        case "A":
                            role = "Администратор";
                            break;
                    }   
                    data.Add(new string[4]);
                    data[data.Count - 1][0] = variables.reader.GetString("FirstName");
                    data[data.Count - 1][1] = variables.reader.GetString("LastName");
                    data[data.Count - 1][2] = variables.reader.GetString("Email");                    
                    data[data.Count - 1][3] = role;
                    countUser++;
                }
                variables.reader.Close();

                foreach (string[] s in data)
                    userGrid.Rows.Add(s);

                countUserL.Text = countUser.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            variables.conn.Close();            
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

        private void userManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDay.Stop();
            if (checkClose) Application.Exit();
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            menuAdmin mA = new menuAdmin("userManagement");
            mA.Show();
            checkClose = false;
            this.Close();
        }

        private void userGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {

            }
        }

        private void updateBut_Click(object sender, EventArgs e)
        {

        }
    }
}
