using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Squirrel;
using System.Reflection;

namespace PROJECT
{
    public partial class SEARCH_BOARD : Form
    {
        public string check,all;
        public int count, ComboBoxCount, firstCount, secondCount, range = 0;
        public string TP, B, A, S, DATE_FILTER,FullTextCommand;
        public string UserAccount { get; set; }
        public int BRG { get; set; }
        string tester;
        MySqlCommand command;
        public SEARCH_BOARD(string User,int BRG_User)
        {
            InitializeComponent();
            UserAccount = User;
            BRG = BRG_User;
        }

        private void SEARCH_BOARD_Load(object sender, EventArgs e)
        {
            LoadData();
            NAME.Text = UserAccount;
        }

        private async void LoadData()
        {
            commands(6);
            if (Connection.OpenConnection())
            {
                MySqlDataReader read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    Tester_platform.Invoke((MethodInvoker)(() => Tester_platform.Items.Add(read_data.GetString("Tester platforms"))));
                }
                Connection.CloseConnection();
            }
            else
            {
                Connection.CloseConnection();
                CheckForUpdates();
                this.Close();
            }
            commands(2);
            if (Connection.OpenConnection())
            {
                check = command.ExecuteScalar().ToString();
                Connection.CloseConnection();
            }
            else
            {
                Connection.CloseConnection();
                CheckForUpdates();
                this.Close();
            }
            await Task.Run(() =>
            {
                FROM_DATE.Invoke((MethodInvoker)(()=> FROM_DATE.CustomFormat = " "));
                TO_DATE.Invoke((MethodInvoker)(() => TO_DATE.CustomFormat = " "));
                Stats.Invoke((MethodInvoker)(() => Stats.SelectedIndex = 0));
                AREA.Invoke((MethodInvoker)(() => AREA.SelectedIndex = 0));
                Tester_platform.Invoke((MethodInvoker)(() => Tester_platform.SelectedIndex = 0));
                Boards.Invoke((MethodInvoker)(()=> Boards.SelectedIndex = 0));
                dataGridViewList.Invoke((MethodInvoker)(() => dataGridViewList.DataSource = table(3)));
                commands(0);
                if (Connection.OpenConnection())
                {
                    all = command.ExecuteScalar().ToString();
                    Connection.CloseConnection();
                }
                else
                {
                    Connection.CloseConnection();
                    CheckForUpdates();
                    this.Close();
                }
            }
            );
            Counts();
            results();
            OVERDUE.Text = string.Format("OVERDUE({0})", check);
        }
        private void results()
        {
            Count_search.Text = string.Format("RESULT({0}-{1} of {2})", firstCount,secondCount, all);
        }
        private void Counts()
        {
            firstCount = 1;
            if (int.Parse(all) >= 30)
                secondCount = 30;
            else
                secondCount = int.Parse(all);
            if (int.Parse(all) < 1)
                firstCount = 0;
        }
        private void Click_data(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                try
                {
                    string endorsement_number = (dataGridViewList.SelectedCells[8].Value.ToString());
                    BOARD_DETAILS details = new BOARD_DETAILS(endorsement_number,UserAccount,BRG);
                    details.ShowDialog();
                }
                catch (Exception)
                {
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void commands(int cmd)
        {
            switch(cmd)
            {
               
                case 0: //TO CHECK IF THERE'S EXISTING DATA SEARCHED
                    command = new MySqlCommand("SELECT COUNT(*) FROM `boards_for_verification`.`board details`",Connection.connect);
                    break;
                case 1:  //TO DISPLAY THE DATA THAT IS SEARCHED BY THE USER
                    command = new MySqlCommand("SELECT `SERIAL NUMBER`,`PART NUMBER`,`BOARD`,`TESTER PLATFORM`,`TEST PROGRAM`,`FIRST DATE`,`STATUS`," +
                        "CASE WHEN (ISNULL(`SECOND DATE`) OR `SECOND DATE` = '') AND (STATUS = 'FOR SECOND VERIF' OR STATUS = 'FOR VERIFICATION')" +
                        " THEN DATEDIFF(NOW(),`FIRST DATE`) " +
                        "ELSE DATEDIFF(`SECOND DATE`,`FIRST DATE`) END AS `AGING DAYS`," +
                        "`ENDORSEMENT NUMBER`" +
                        " FROM `boards_for_verification`.`board details` WHERE '" + search_text.Text + "'" +
                        " IN (`SERIAL NUMBER`,`PART NUMBER`,`FIRST TESTER`,`TEST PROGRAM`)" +
                        " ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 30",Connection.connect);
                    break;
                case 2: //COUNT OVERDUE BOARDS
                    command = new MySqlCommand("SELECT count(`FIRST DATE`) FROM `board details` WHERE ((select abs(datediff(`FIRST DATE`,current_date()))) > 2) AND (`STATUS` = 'FOR SECOND VERIF')",
                        Connection.connect);
                    break;
                case 3:  //FOR UPDATING PURPOSES
                    command = new MySqlCommand("SELECT `SERIAL NUMBER`,`PART NUMBER`,`BOARD`,`TESTER PLATFORM`,`TEST PROGRAM`,`FIRST DATE`,`STATUS`," +
                        "CASE WHEN (ISNULL(`SECOND DATE`) OR `SECOND DATE` = '') AND (STATUS = 'FOR SECOND VERIF' OR STATUS = 'FOR VERIFICATION')" +
                        " THEN DATEDIFF(NOW(),`FIRST DATE`) " +
                        "ELSE DATEDIFF(`SECOND DATE`,`FIRST DATE`) END AS `AGING DAYS`," +
                        "`ENDORSEMENT NUMBER`" +
                        " FROM `boards_for_verification`.`board details` ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 30",Connection.connect);
                    break;
                case 4:
                    // NOT USE
                    break;
                case 5: // SEARCHING BOARDS WITH FILTER
                    command = new MySqlCommand(string.Format("SELECT COUNT(*) FROM `boards_for_verification`.`board details` {0}",FullTextCommand), Connection.connect);
                    break;
                case 6:  //TESTER PLATFORMS
                    command = new MySqlCommand("SELECT * FROM `boards_for_verification`.`tester platforms`", Connection.connect);
                    break;
                case 7:  //BOARDS OF TESTER PLATFORM
                    tester = string.Format("SELECT * FROM `boards_for_verification`.`{0}_boards`", Tester_platform.Text.ToLower());
                    command = new MySqlCommand(tester, Connection.connect);
                    break;
                case 8:   //FOR TMT BOARDS
                    command = new MySqlCommand("SELECT * FROM `board_for_verification`.`tmt_boards`", Connection.connect);
                    break;
                case 9:  // FOR SEARCH IN COMBO BOXES
                    command = new MySqlCommand(string.Format("Select `SERIAL NUMBER`,`PART NUMBER`,`BOARD`,`TESTER PLATFORM`,`TEST PROGRAM`,`FIRST DATE`,`STATUS`," +
                        "CASE WHEN (ISNULL(`SECOND DATE`) OR `SECOND DATE` = '') AND (STATUS = 'FOR SECOND VERIF' OR STATUS = 'FOR VERIFICATION')" +
                        " THEN DATEDIFF(NOW(),`FIRST DATE`) " +
                        "ELSE DATEDIFF(`SECOND DATE`,`FIRST DATE`) END AS `AGING DAYS`," +
                        "`ENDORSEMENT NUMBER`" +
                        " FROM `boards_for_verification`.`board details` {0} ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 30",FullTextCommand), Connection.connect);
                    break;
                case 10: // UNUSED
                    break;
                case 11: //NEXT BUTTON
                    command = new MySqlCommand(string.Format("select `SERIAL NUMBER`,`PART NUMBER`,`BOARD`,`TESTER PLATFORM`,`TEST PROGRAM`,`FIRST DATE` as `FIRST DATE VERIFIED`," +
                        "`STATUS`,CASE WHEN (ISNULL(`SECOND DATE`) OR `SECOND DATE` = '') AND (STATUS = 'FOR SECOND VERIF' OR STATUS = 'FOR VERIFICATION')" +
                        " THEN DATEDIFF(NOW(),`FIRST DATE`) " +
                        " ELSE DATEDIFF(`SECOND DATE`,`FIRST DATE`) END AS `AGING DAYS`," +
                        "`ENDORSEMENT NUMBER`" +
                        " FROM `boards_for_verification`.`board details` {0} ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT {1},30", FullTextCommand, range), Connection.connect);
                    break;
                case 12:
                    command = new MySqlCommand("SELECT COUNT(*) FROM `board details` WHERE '" + search_text.Text + "' IN (`SERIAL NUMBER`,`PART NUMBER`,`FIRST TESTER`,`TEST PROGRAM`)", Connection.connect);
                    break;
            }
        }
        private DataTable table(int COMMAND)
        {
            commands(COMMAND);
            DataTable new_data = new DataTable();
            if (Connection.OpenConnection())
            {
                MySqlDataAdapter read = new MySqlDataAdapter(command);
                read.Fill(new_data);
                Connection.CloseConnection();
                return new_data;
            }
            else 
                return new_data;
        }
        private void load_data(int commandss)
        {
            commands(count);
            if (Connection.OpenConnection())
            {
                check = command.ExecuteScalar().ToString();
                if (Connection.CloseConnection())
                {
                    if (check == "0")
                    {
                        MessageBox.Show("NO DATA");
                        search_text.Clear();
                        return;
                    }
                    else
                    {
                        dataGridViewList.DataSource = table(commandss);
                    }
                }
                else
                {
                    Connection.CloseConnection();
                }
            }
            else
            {
                Connection.CloseConnection();
            }
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            range = 0;
            if (string.IsNullOrWhiteSpace(search_text.Text))
            {
                CommandComboBox();
                commands(5);
                if (Connection.OpenConnection())
                {
                    all = command.ExecuteScalar().ToString();
                    Connection.CloseConnection();
                }
                else return;
                dataGridViewList.DataSource = table(9);
                Counts();
                results();
            }
            else
            {
                count = 0;
                commands(12);
                if (Connection.OpenConnection())
                {
                    all = command.ExecuteScalar().ToString();
                    Connection.CloseConnection();
                }
                else return;
                Counts();
                results();
                load_data(1);
                FROM_DATE.CustomFormat = " ";
                TO_DATE.CustomFormat = " ";
                AREA.SelectedIndex = 0;
                Stats.SelectedIndex = 0;
                Tester_platform.SelectedIndex = 0;
                clearBoards();
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ADD next = new ADD(1,UserAccount);
            next.ShowDialog();
        }
        private void REFRESH_Click(object sender, EventArgs e)
        {
            FROM_DATE.CustomFormat = " ";
            TO_DATE.CustomFormat = " ";
            AREA.SelectedIndex = 0;
            Stats.SelectedIndex = 0;
            Tester_platform.SelectedIndex = 0;
            clearBoards();
            search_text.Clear();
            dataGridViewList.DataSource = table(3);
            commands(2);
            if (Connection.OpenConnection())
            {
                check = command.ExecuteScalar().ToString();
                Connection.CloseConnection();
                OVERDUE.Text = string.Format("OVERDUE({0})", check);
            }
            else Connection.CloseConnection();
            commands(0);
            if (Connection.OpenConnection())
            {
                all = command.ExecuteScalar().ToString();
                Connection.CloseConnection();
            }
            else return;
            Counts();
            results();
        }

        private void EDIT_Click(object sender, EventArgs e)
        {
            EDIT_TESTERS edit = new EDIT_TESTERS();
            edit.ShowDialog();
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
            MessageBox.Show("THIS APP WILL CLOSED, WAIT FOR A FEW SECOND AND REOPEN IT AGAIN.");
            this.Close();
        }

        private async void CheckForUpdates()
        {
            using (var update = new UpdateManager(@"\\maxcavfs01\mpoc_asl_softwares\12_Projects and Activities\BFV APPLICATION"))
            {
                await update.UpdateApp();
            }
        }

        private void FirstDate(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                FROM_DATE.CustomFormat = " ";
                TO_DATE.CustomFormat = " ";
            }
            else
                e.SuppressKeyPress = true;
        }

        private void Select_FirstDate(object sender, EventArgs e)
        {
            FROM_DATE.CustomFormat = "yyyy-MM-dd";
            TO_DATE.CustomFormat = " ";
        }

        private void TO_DATE_select(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FROM_DATE.Text))
            {
                MessageBox.Show("FROM DATE IS EMPTY");
                TO_DATE.CustomFormat = " ";
                return;
            }
            else if (TO_DATE.Value < FROM_DATE.Value)
            {
                MessageBox.Show("INVALID DATE");
                TO_DATE.CustomFormat = " ";
                return;
            }
            else
            TO_DATE.CustomFormat = "yyyy-MM-dd";
        }

        private void Enter_search(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                range = 0;
                count = 0;
                commands(12);
                if (Connection.OpenConnection())
                {
                    all = command.ExecuteScalar().ToString();
                    Connection.CloseConnection();
                }
                else return;
                Counts();
                results();
                load_data(1);
                FROM_DATE.CustomFormat = " ";
                TO_DATE.CustomFormat = " ";
                AREA.SelectedIndex = 0;
                Stats.SelectedIndex = 0;
                Tester_platform.SelectedIndex = 0;
                clearBoards();
            }

        }


        private void FormClose(object sender, FormClosingEventArgs e)
        {
            LOGIN Back = new LOGIN();
            Back.Show();
        }

        private void TO_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                TO_DATE.CustomFormat = " ";
            else
                e.SuppressKeyPress = true;
        }

        private void ForwardClick(object sender, EventArgs e)
        {
            if (secondCount == int.Parse(all))
            {
                return;
            }
            secondCount = secondCount + 30;
            if (secondCount > int.Parse(all))
            {
                secondCount = int.Parse(all);
            }
            firstCount += 30;
            range += 30;
            results();
            CommandComboBox();
            load_data(11);
        }
        private void BackClick(object sender, EventArgs e)
        {
            if (firstCount == 1) return;
            if (secondCount == int.Parse(all))
            {
                secondCount = firstCount - 1;
                firstCount -= 30;
            }
            else
            {
                secondCount -= 30;
                firstCount -= 30;
            }
            range -= 30;
            CommandComboBox();
            load_data(11);
            results();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AreaIndexChanged(object sender, EventArgs e)
        {
            search_text.Clear();
        }

        private void statusIndexChanged(object sender, EventArgs e)
        {
            search_text.Clear();
        }

        private void Boardsindexchanged(object sender, EventArgs e)
        {
            search_text.Clear();
        }

        private void ShowBoards(object sender, EventArgs e)
        {
            search_text.Clear();
            if (Tester_platform.SelectedIndex == 0)
            {
                clearBoards();
            }
            else
            {
                clearBoards();
                if (Tester_platform.Text == "ASL1K" || Tester_platform.Text == "ASL4K")
                {
                    commands(8);
                    if (Connection.OpenConnection())
                    {
                        MySqlDataReader read_data = command.ExecuteReader();
                        while (read_data.Read())
                        {
                            Boards.Items.Add(read_data.GetString("TMT"));
                        }
                        Connection.CloseConnection();
                    }
                    else
                    {
                        Connection.CloseConnection();
                        return;
                    }
                }
                else
                {
                    commands(7);
                    if (Connection.OpenConnection())
                    {
                        MySqlDataReader read_data = command.ExecuteReader();
                        while (read_data.Read())
                        {
                            Boards.Items.Add(read_data.GetString(Tester_platform.Text.ToUpper()));
                        }
                        Connection.CloseConnection();
                    }
                    else return;
                }
            }
        }
        private void clearBoards()
        {
            Boards.Items.Clear();
            Boards.Items.Add(" ");
            Boards.SelectedIndex = 0;
        }

        private void CommandComboBox()
        {
            FullTextCommand = "";
            ComboBoxCount = 0;
            search_text.Clear();
            if (Tester_platform.SelectedIndex != 0)                                                        //TESTER PLATFORM
            {
                TP = string.Format("(`TESTER PLATFORM` = '{0}')", Tester_platform.Text);
                FullTextCommand = string.Format("where {0}", TP);
                ComboBoxCount++;
            } 
            if (Boards.SelectedIndex != 0)                                                                 //BOARDS
            {
                B = string.Format("(`BOARD` = '{0}')", Boards.Text);
                FullTextCommand = FullTextCommand + string.Format(" and {0}", B);
            }
            if (AREA.SelectedIndex != 0)                                                                   //AREA
            {
                A = string.Format("(`AREA` = '{0}')", AREA.Text);
                if (ComboBoxCount == 1)
                {
                    FullTextCommand = FullTextCommand + string.Format(" and {0}", A);
                    ComboBoxCount++;
                }
                else
                {
                    FullTextCommand = string.Format("where {0}", A);
                    ComboBoxCount++;
                }
            }
            if (Stats.SelectedIndex != 0)                                                                 //STATUS
            {
                if (Stats.Text == "OVERDUE")
                {
                    S = string.Format("((select abs(datediff(`FIRST DATE`,current_date()))) > 2) and (`STATUS` = 'FOR SECOND VERIF')");
                }
                else if (Stats.Text == "INSTALL TO A TESTER")
                {
                    S = string.Format("(`STATUS` REGEXP 'INSTALL')");
                }
                else
                {
                    S = string.Format("(`STATUS` = '{0}')", Stats.Text);
                }
                if (ComboBoxCount == 2)
                {
                    FullTextCommand = FullTextCommand + string.Format(" and {0}", S);
                    ComboBoxCount++;
                }
                else if (ComboBoxCount == 1)
                {
                    FullTextCommand = FullTextCommand + string.Format(" and {0}", S);
                    ComboBoxCount++;
                }
                else
                {
                    FullTextCommand = string.Format("where {0}", S);
                    ComboBoxCount++;
                }
            }
            if (!string.IsNullOrWhiteSpace(FROM_DATE.Text))                                                //DATE FILTERING
            {
                if (!string.IsNullOrWhiteSpace(TO_DATE.Text))
                {
                    DATE_FILTER = string.Format("(`FIRST DATE` between '{0}' and '{1}')", FROM_DATE.Text, TO_DATE.Text);
                }
                else
                {
                    DATE_FILTER = string.Format("(`FIRST DATE` = '{0}')", FROM_DATE.Text);
                }
                if (ComboBoxCount == 3)
                {
                    FullTextCommand = FullTextCommand + string.Format(" and {0}", DATE_FILTER);
                }
                else if (ComboBoxCount == 2)
                {
                    FullTextCommand = FullTextCommand + string.Format(" and {0}", DATE_FILTER);
                }
                else if (ComboBoxCount == 1)
                {
                    FullTextCommand = FullTextCommand + string.Format(" and {0}", DATE_FILTER);
                }
                else
                {
                    FullTextCommand = string.Format("where {0}", DATE_FILTER);
                }
            }
        }
    }
}
 