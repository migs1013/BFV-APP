using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Squirrel;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace PROJECT
{
    public partial class LOGIN : System.Windows.Forms.Form
    {
        MySqlCommand command;
        public int count;
        public string UserName,Approver;
        public LOGIN()
        {
            InitializeComponent();
        }

        private bool CheckTextBox(string textBox)
        {
            char[] text = textBox.ToCharArray();
            if (textBox.Length > 30)
            {
                MessageBox.Show("MAXIMUM OF 30 CHARACTERS ONLY");
                return false;
            }
            for (int Txt = 0; Txt < textBox.Length; Txt++)
            {
                if (char.IsLetterOrDigit(text[Txt])) continue;
                else if (text[Txt] == '.') continue;
                else if (text[Txt] == ' ')
                {
                    MessageBox.Show("SPACE IS NOT ALLOWED");
                    return false;
                }
                else
                {
                    MessageBox.Show("PLEASE ENTER NUMBER OR LETTER ONLY");
                    return false;
                }
            }
            return true;
        }

        private void REGISTER_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(REG_USER.Text) || string.IsNullOrWhiteSpace(REG_PASS.Text) || string.IsNullOrWhiteSpace(REG_CONFIRM.Text))
            {
                ALERT.Text = "FILL UP ALL FORMS";
                return;
            }
            if (REG_PASS.Text == REG_CONFIRM.Text)
            {
                if (CheckTextBox(REG_USER.Text) && CheckTextBox(REG_PASS.Text))
                {
                    Commands(1);
                    command.Connection = Connection.connect;
                    if (Connection.OpenConnection())
                    {
                        MySqlDataReader read_status = command.ExecuteReader();
                        read_status.Read();

                        count = Convert.ToInt32(read_status["count"].ToString());
                        Connection.CloseConnection(); ;
                    }
                    else return;
                    if (count == 0)
                    {
                        Commands(2);
                        command.Connection = Connection.connect;
                        if (Connection.OpenConnection())
                        {
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (MySqlException m)
                            {
                                MessageBox.Show(m.ToString());
                                Connection.CloseConnection();
                                return;
                            }
                            Connection.CloseConnection();
                            ALERT.Text = "ACCOUNT SUCCESSFULLY REGISTERED";
                            REG_USER.Clear();
                            REG_PASS.Clear();
                            REG_CONFIRM.Clear();
                        }
                    }
                    else
                    {
                        ALERT.Text = "ACCOUNT ALREADY EXIST";
                        return;
                    }
                }
            }
            else
            {
                ALERT.Text = "PASSWORD NOT MATCH";
                return;
            }
        }

        private void Commands(int cmd)
        {
            switch (cmd)
            {
                case 1:
                    command = new MySqlCommand("SELECT COUNT(*) as count FROM `hit`.`useraccount` " +
                        "WHERE (`USERNAME` = '" + REG_USER.Text + "')");
                    break;
                case 2:
                    command = new MySqlCommand(String.Format("INSERT INTO `hit`.`useraccount` SET `USERNAME` = '" + REG_USER.Text + "'," +
                        "`PASSWORD` = '" + REG_PASS.Text + "'"));
                    break;
                case 3:
                    command = new MySqlCommand("SELECT IFNULL(u.`USERNAME`, NULL) AS `USERNAME`," +
                                                      "IFNULL(u.`PASSWORD`, NULL) AS `PASSWORD`," +
                                                      "IFNULL(u.`APPROVER`, NULL) AS `APPROVER`," +
                                                      "IFNULL(c.count, 0) AS count " +
                                                      "FROM (SELECT `USERNAME`, `PASSWORD`, `APPROVER` FROM `USERACCOUNT`" +
                                                      "WHERE `username` = '" + User.Text + "' AND `password` = '" + Pass.Text + "' LIMIT 1) u " +
                                                      "RIGHT JOIN (SELECT COUNT(*) AS count FROM `useraccount` WHERE `username` = '" + User.Text + "' AND password = '" + Pass.Text + "' ) c ON 1 = 1; ");
                    break;
            }
        }


        private void User_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(User.Text) || string.IsNullOrWhiteSpace(Pass.Text))
                {
                    MessageBox.Show("NO INPUT");
                    return;
                }
                else
                    LOGINUSER();
            }
        }

        private void Exit(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void UPDATE_BTN_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
            MessageBox.Show("THIS APP WILL CLOSED, WAIT FOR A FEW SECOND AND OPEN IT AGAIN.");
            this.Close();
        }

        private async void CheckForUpdates()
        {
            using (var update = new UpdateManager(@"\\maxcavfs01\mpoc_asl_softwares\12_Projects and Activities\BFV APPLICATION"))
            {
                await update.UpdateApp();
            }
        }

        private void Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(User.Text) || string.IsNullOrWhiteSpace(Pass.Text))
                {
                    MessageBox.Show("NO INPUT");
                    return;
                }
                else
                    LOGINUSER();
            }
        }

        private void LOGINUSER()
        {
            try
            {
                Commands(3);
                command.Connection = Connection.connect;
                Connection.OpenConnection();
                MySqlDataReader read_status = command.ExecuteReader();
                read_status.Read();

                count = Convert.ToInt32(read_status["count"].ToString());
                if (count == 0)
                {
                    Connection.CloseConnection();
                    MessageBox.Show("ACCOUNT DOES NOT EXIST");
                    return;
                }
                else
                {
                    UserName = read_status["USERNAME"].ToString();
                    Approver = read_status["APPROVER"].ToString();
                    Connection.CloseConnection();
                    User.Clear();
                    Pass.Clear();
                    this.Hide();
                    SEARCH_BOARD next = new SEARCH_BOARD(UserName, Approver);
                    next.ShowDialog();
                }
            }
            catch (Exception error)
            {
                Connection.CloseConnection();
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(User.Text) || string.IsNullOrWhiteSpace(Pass.Text))
            {
                MessageBox.Show("NO INPUT");
                return;
            }
            else
                LOGINUSER();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            User.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
