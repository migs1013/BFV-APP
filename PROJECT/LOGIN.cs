using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace PROJECT
{
    public partial class LOGIN : Form
    {
        MySqlCommand command;
        public int count,brg,brg_user;
        public string UserName;
        public LOGIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(User.Text) || string.IsNullOrWhiteSpace(Pass.Text))
            {
                MessageBox.Show("NO INPUT");
                return;
            }
            else
                LOGINUSER();
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
                else if (text[Txt] == ' ') continue;
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
                MessageBox.Show("FILL UP ALL FORMS");
                return;
            }
            if (REG_PASS.Text == REG_CONFIRM.Text)
            {
                if (CheckTextBox(REG_USER.Text) && CheckTextBox(REG_PASS.Text))
                {
                    commands(1);
                    command.Connection = Connection.connect;
                    if (Connection.OpenConnection())
                    {
                        MySqlDataReader read_status = command.ExecuteReader();
                        read_status.Read();

                        count = Convert.ToInt32(read_status["count"].ToString());
                    }
                    Connection.CloseConnection(); ;
                    if (count == 0)
                    {
                        if (BRG.Checked == true)
                            brg = 1;
                        else
                            brg = 0;
                        commands(2);
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
                            MessageBox.Show("ACCOUNT SUCCESSFULLY REGISTERED");
                            REG_USER.Clear();
                            REG_PASS.Clear();
                            REG_CONFIRM.Clear();
                            BRG.Checked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ACCOUNT ALREADY EXIST");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("PASSWORD NOT MATCH");
                return;
            }
        }

        private void commands(int cmd)
        {
            switch (cmd)
            {
                case 1:
                    command = new MySqlCommand("SELECT *,COUNT(*) as count FROM `boards_for_verification`.`useraccount` " +
                        "WHERE (`USERNAME` = '" + REG_USER.Text + "' and `PASSWORD` = '" + REG_PASS.Text + "')");
                    break;
                case 2:
                    command = new MySqlCommand(String.Format("INSERT INTO `boards_for_verification`.`useraccount` SET `USERNAME` = '" + REG_USER.Text + "'," +
                        "`PASSWORD` = '" + REG_PASS.Text + "',`BRG` = {0}",brg));
                    break;
                case 3:
                    command = new MySqlCommand("SELECT *,COUNT(*) as count FROM `boards_for_verification`.`useraccount` " +
                     "WHERE (`USERNAME` = '" + User.Text + "' and `PASSWORD` = '" + Pass.Text + "')");
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
            commands(3);
            command.Connection = Connection.connect;
            if (Connection.OpenConnection())
            {
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
                    brg_user = Convert.ToInt32(read_status["BRG"].ToString());
                    Connection.CloseConnection();
                    User.Clear();
                    Pass.Clear();
                    SEARCH_BOARD next = new SEARCH_BOARD(UserName, brg_user);
                    this.Hide();
                    next.ShowDialog();
                }
            }
            else Connection.CloseConnection();
        }
    }
}
