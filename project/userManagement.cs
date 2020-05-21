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
        string roleS = "";
        string typeUpdate = "";
        string typeUpdateRole = "";
        string typeUpdateRows = "";
        List<string[]> data = new List<string[]>();
        public userManagement()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            timerDay.Start();
            dT = Convert.ToDateTime("24.11.2020 06:00:00");
            fill();
        }

        void fill()
        {
            try
            {
                sql.GetDBConnection();    
                variables.cmd = new MySqlCommand("SELECT distinct `id_role` FROM `user`", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    switch (variables.reader.GetString("id_role"))
                    {
                        case "R":
                            roleS = "Бегун";
                            break;
                        case "C":
                            roleS = "Координатор";
                            break;
                        case "A":
                            roleS = "Администратор";
                            break;
                    }
                    metroComboBox1.Items.Add(roleS);
                }
                variables.reader.Close();
                variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user`", variables.conn);
                variables.reader = variables.cmd.ExecuteReader();
                while (variables.reader.Read())
                {
                    switch (variables.reader.GetString("id_role"))
                    {
                        case "R":
                            roleS = "Бегун";
                            break;
                        case "C":
                            roleS = "Координатор";
                            break;
                        case "A":
                            roleS = "Администратор";
                            break;
                    }
                    data.Add(new string[4]);
                    data[data.Count - 1][0] = variables.reader.GetString("FirstName");
                    data[data.Count - 1][1] = variables.reader.GetString("LastName");
                    data[data.Count - 1][2] = variables.reader.GetString("Email");
                    data[data.Count - 1][3] = roleS;
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
            updateFilter();
        }

        void updateFilter()
        {
            try
            {
                sql.GetDBConnection();
                bool checkBox1 = false;
                bool checkBox2 = false;
                typeUpdateRole = "";
                typeUpdateRows = "";

                if (metroComboBox1.SelectedItem != null) checkBox1 = true;
                if (checkBox1)
                {
                    if (metroComboBox1.SelectedItem == "Бегун") typeUpdateRole = "run";
                    else if (metroComboBox1.SelectedItem == "Координатор") typeUpdateRole = "coor";
                    else if (metroComboBox1.SelectedItem == "Администратор") typeUpdateRole = "admin";
                }                

                if (metroComboBox2.SelectedItem != null) checkBox2 = true;
                if (checkBox2)
                {
                    if (metroComboBox2.SelectedItem == "Имени") typeUpdateRows = "name";
                    else if (metroComboBox2.SelectedItem == "Фамилии") typeUpdateRows = "fam";
                    else if (metroComboBox2.SelectedItem == "Почте") typeUpdateRows = "mail";
                    else if (metroComboBox2.SelectedItem == "Роле") typeUpdateRows = "role";
                }

                if (checkBox1 && !checkBox2) typeUpdate = typeUpdateRole;
                if (!checkBox1 && checkBox2) typeUpdate = typeUpdateRows;
                if (checkBox1 && checkBox2) typeUpdate = typeUpdateRole + " " + typeUpdateRows;
                if (!checkBox1 && !checkBox2) typeUpdate = "";
                fillGrid(typeUpdate);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            variables.conn.Close();
        }

        void fillGrid(string type)
        {
            userGrid.Rows.Clear();
            data.Clear();
            switch (type)
            {
                case "admin":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'A'", variables.conn);
                    break;
                case "run":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'R'", variables.conn);
                    break;
                case "coor":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'C'", variables.conn);
                    break;
                case "name":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` ORDER BY `FirstName`", variables.conn);
                    break;
                case "fam":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` ORDER BY 'LastName'", variables.conn);
                    break;
                case "mail":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` ORDER BY 'Email'", variables.conn);
                    break;
                case "role":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` ORDER BY 'id_role'", variables.conn);
                    break;
                case "admin name":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'A' order by `FirstName`", variables.conn);
                    break;
                case "admin fam":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'A' order by `LastName`", variables.conn);
                    break;
                case "admin mail":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'A' order by `Email`", variables.conn);
                    break;
                case "admin role":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'A' order by `id_role`", variables.conn);
                    break;
                case "run name":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'R' order by `FirstName`", variables.conn);
                    break;
                case "run fam":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'R' order by `LastName`", variables.conn);
                    break;
                case "run mail":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'R' order by `Email`", variables.conn);
                    break;
                case "run role":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'R' order by `id_role`", variables.conn);
                    break;
                case "coor name":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'C' order by `FirstName`", variables.conn);
                    break;
                case "coor fam":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'C' order by `LastName`", variables.conn);
                    break;
                case "coor mail":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'C' order by `Email`", variables.conn);
                    break;
                case "coor role":
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user` where `id_role` = 'C' order by `id_role`", variables.conn);
                    break;
                default:
                    variables.cmd = new MySqlCommand("SELECT `Email`, `FirstName`, `LastName`, `id_role` FROM `user`", variables.conn);
                    break;
            }
            variables.reader = variables.cmd.ExecuteReader();
            while (variables.reader.Read())
            {
                switch (variables.reader.GetString("id_role"))
                {
                    case "R":
                        roleS = "Бегун";
                        break;
                    case "C":
                        roleS = "Координатор";
                        break;
                    case "A":
                        roleS = "Администратор";
                        break;
                }
                data.Add(new string[4]);
                data[data.Count - 1][0] = variables.reader.GetString("FirstName");
                data[data.Count - 1][1] = variables.reader.GetString("LastName");
                data[data.Count - 1][2] = variables.reader.GetString("Email");
                data[data.Count - 1][3] = roleS;
            }
            variables.reader.Close();

            foreach (string[] s in data)
                userGrid.Rows.Add(s);
        }
    }
}
