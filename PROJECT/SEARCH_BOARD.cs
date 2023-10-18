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
        public string DATE_FILTER, FullTextCommand;
        public string UserAccount { get; set; }

        MySqlCommand command;
        public SEARCH_BOARD(string User)
        {
            InitializeComponent();
            UserAccount = User;
        }

        private void SEARCH_BOARD_Load(object sender, EventArgs e)
        {
            LoadData();
            NAME.Text = UserAccount;
        }
        private async void LoadData()
        {
            try
            {
                Commands(5);
                Connection.OpenConnection();

                MySqlDataReader read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    TESTER_PLATFORM_FILTER.Items.Add(read_data.GetString("TESTER_PLATFORM"));
                }
                Connection.CloseConnection();

                Commands(2);
                Connection.OpenConnection();

                read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    PRODUCT_OWNER_FILTER.Items.Add(read_data.GetString("PRODUCT_OWNER"));
                }
                Connection.CloseConnection();

                await Task.Run(() =>
                {
                    FROM_DATE.Invoke((MethodInvoker)(() => FROM_DATE.CustomFormat = " "));
                    TO_DATE.Invoke((MethodInvoker)(() => TO_DATE.CustomFormat = " "));
                    dataGridViewList.Invoke((MethodInvoker)(() => dataGridViewList.DataSource = Table(3)));
                    Commands(0);
                    if (Connection.OpenConnection())
                    {
                        all = command.ExecuteScalar().ToString();
                        Connection.CloseConnection();
                    }
                    else
                    {
                        Connection.CloseConnection();
                        this.Close();
                    }
                }
                );
                Counts();
                Results();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                Connection.CloseConnection();
            }
        }
        private void Results()
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
            //MessageBox.Show(dataGridViewList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            try
            {
                string endorsement_number = dataGridViewList.SelectedCells[8].Value.ToString();
                BOARD_DETAILS details = new BOARD_DETAILS(endorsement_number);
                details.ShowDialog();
            }
            catch (Exception ErrorMessage)
            {
                MessageBox.Show(ErrorMessage.ToString());
            }
        }
        private void Commands(int cmd)
        {
            switch(cmd)
            {
               
                case 0: //TO CHECK IF THERE'S EXISTING DATA SEARCHED
                    command = new MySqlCommand("SELECT COUNT(*) FROM `hit`.`details`",Connection.connect);
                    break;
                case 1:  //TO DISPLAY THE DATA THAT IS SEARCHED BY THE USER
                    command = new MySqlCommand(string.Format("SELECT `PART_NAME`,`LOT_ID`,`TEST_NUMBER`,`TESTER_ID`,`TEST_STEP`,`DATE_ENCOUNTERED`," +
                        "`PRODUCT_OWNER`,`STATUS`,`ENDORSEMENT_NUMBER` " +
                        "FROM `hit`.`details` WHERE (`PART_NAME` LIKE '%{0}%') OR (`LOT_ID` LIKE '%{0}%') OR (`TEST_NUMBER` LIKE '%{0}%') OR (`VSPEC` LIKE '%{0}%') OR" +
                        "(`BOARD_ID` LIKE '%{0}%') OR (`HANDLER_ID` LIKE '%{0}%') OR (`BIN_NUMBER` LIKE '%{0}%')" +
                        "ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30",search_text.Text),Connection.connect);
                    break;
                case 2: // PRODUCT OWNER
                    command = new MySqlCommand("SELECT `PRODUCT_OWNER` FROM `hit`.`device` GROUP BY `PRODUCT_OWNER` ", Connection.connect);
                    break;
                case 3:  //FOR UPDATING PURPOSES
                    command = new MySqlCommand("SELECT `PART_NAME`,`LOT_ID`,`TEST_NUMBER`,`TESTER_ID`,`TEST_STEP`,`DATE_ENCOUNTERED`,`PRODUCT_OWNER`," +
                        "`STATUS`,`ENDORSEMENT_NUMBER` FROM `hit`.`details` ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30", Connection.connect);
                    break;
                case 4: // SEARCHING TRANSACTION COUNTS WITH FILTER
                    command = new MySqlCommand(string.Format("SELECT COUNT(*) FROM `hit`.`details` {0}",FullTextCommand), Connection.connect);
                    break;
                case 5:  //TESTER PLATFORMS
                    command = new MySqlCommand("SELECT `TESTER_PLATFORM` FROM `hit`.`hostnames` GROUP BY `TESTER_PLATFORM`", Connection.connect);
                    break;
                case 6:  // FOR SEARCH IN COMBO BOXES
                    command = new MySqlCommand(string.Format("Select `PART_NAME`,`LOT_ID`,`TEST_NUMBER`,`TESTER_ID`,`TEST_STEP`," +
                        "`DATE_ENCOUNTERED`,`PRODUCT_OWNER`,`STATUS`,`ENDORSEMENT_NUMBER`" +
                        "FROM `hit`.`details` {0} ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30",FullTextCommand), Connection.connect);
                    break;
                case 7: //NEXT BUTTON
                    command = new MySqlCommand(string.Format("Select `PART_NAME`,`LOT_ID`,`TEST_NUMBER`,`TESTER_ID`,`TEST_STEP`," +
                        "`DATE_ENCOUNTERED`,`PRODUCT_OWNER`,`STATUS`,`ENDORSEMENT_NUMBER` " +
                        "FROM `hit`.`details` {0} ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT {1},30", FullTextCommand, range), Connection.connect);
                    break;
                case 8: // SEARCH DATA COUNT WITH TEXTBOX
                    command = new MySqlCommand(string.Format("SELECT count(*) FROM `hit`.`details` " +
                        "WHERE (`PART_NAME` LIKE '%{0}%') OR (`LOT_ID` LIKE '%{0}%') OR (`TEST_NUMBER` LIKE '%{0}%') OR (`VSPEC` LIKE '%{0}%') OR" +
                        "(`BOARD_ID` LIKE '%{0}%') OR (`HANDLER_ID` LIKE '%{0}%') OR (`BIN_NUMBER` LIKE '%{0}%')" +
                        "ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30", search_text.Text), Connection.connect);
                    break;
                case 9: // LOAD TESTER
                    command = new MySqlCommand(string.Format("SELECT `TESTER` from `hit`.`hostnames` where `TESTER_PLATFORM` = '{0}'",
                        TESTER_PLATFORM_FILTER.Text.ToLower()), Connection.connect);
                    break;
                case 10: // LOAD PRODUCT OWNER DEVICES
                    command = new MySqlCommand(string.Format("select `DEVICE` from `hit`.`device` where `PRODUCT_OWNER` = '{0}'", PRODUCT_OWNER_FILTER.Text), Connection.connect);
                    break;
                case 11: // LOAD VSPEC
                    command = new MySqlCommand(string.Format("SELECT `VSPEC` from `details` WHERE locate('{0}',`PART_NAME`) = 1 GROUP BY `VSPEC`"
                        ,PART_NAME_FILTER.Text),Connection.connect);
                    break;
                case 12: // LOAD TEST STEP
                    command = new MySqlCommand(string.Format("SELECT `TEST_STEP` from `details` WHERE locate('{0}',`PART_NAME`) = 1 GROUP BY `TEST_STEP`"
                        , PART_NAME_FILTER.Text), Connection.connect);
                    break;
            }
        }
        private DataTable Table(int COMMAND)
        {
            try
            {
                Commands(COMMAND);
                DataTable new_data = new DataTable();
                Connection.OpenConnection();
                MySqlDataAdapter read = new MySqlDataAdapter(command);
                read.Fill(new_data);
                Connection.CloseConnection();
                return new_data;
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
                return null;
            }
        }
        private void Load_data(int commandss)
        {
            Commands(count);
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
                        dataGridViewList.DataSource = Table(commandss);
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
                if (!string.IsNullOrWhiteSpace(BIN_NUMBER_FILTER.Text))
                {
                    char[] Word = BIN_NUMBER_FILTER.Text.ToCharArray();
                    if (Word.Length > 4)
                    {
                        MessageBox.Show("MAXIMUM BIN NUMBER IS 4 DIGITS ONLY");
                        return;
                    }
                    for (int Txt = 0; Txt < Word.Length; Txt++)
                    {
                        if (char.IsDigit(Word[Txt])) continue;
                        else if (Word[Txt] == ' ')
                        {
                            MessageBox.Show("SPACE IN BIN NUMBER IS NOT ALLOWED");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("PLEASE ENTER NUMBER ONLY FOR BIN NUMBER");
                            return;
                        }
                    }
                }
                CommandComboBox();
                Connection.CloseConnection();
                Commands(4);
                if (Connection.OpenConnection())
                {
                    all = command.ExecuteScalar().ToString();
                    Connection.CloseConnection();
                }
                else return;
                dataGridViewList.DataSource = Table(6);
                Counts();
                Results();
                Connection.CloseConnection();
            }
            else
            {
                count = 0;
                Commands(8);
                if (Connection.OpenConnection())
                {
                    all = command.ExecuteScalar().ToString();
                    Connection.CloseConnection();
                }
                else
                {
                    Connection.CloseConnection();
                    return;
                }
                Counts();
                Results();
                Load_data(1);
                ClearFilter();
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
            ClearFilter();
            search_text.Clear();
            dataGridViewList.DataSource = Table(3);
            Commands(0);
            if (Connection.OpenConnection())
            {
                all = command.ExecuteScalar().ToString();
                Connection.CloseConnection();
            }
            else return;
            Counts();
            Results();
        }

        private void EDIT_Click(object sender, EventArgs e)
        {
            EDIT_TESTERS edit = new EDIT_TESTERS();
            edit.ShowDialog();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            LOGIN back = new LOGIN();
            this.Hide();
            back.ShowDialog();
        }

        private void Enter_search(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                range = 0;
                count = 0;
                Commands(8);
                if (Connection.OpenConnection())
                {
                    all = command.ExecuteScalar().ToString();
                    Connection.CloseConnection();
                }
                else return;
                Counts();
                Results();
                Load_data(1);
                FROM_DATE.CustomFormat = " ";
                TO_DATE.CustomFormat = " ";
                ClearFilter();
            }

        }
        private void TESTER_PLATFORM_FILTER_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (TESTER_PLATFORM_FILTER.SelectedIndex == 0)
            { 
                TESTER_PLATFORM_FILTER.DroppedDown = false;
                TESTER_ID_FILTER.SelectedIndex = 0;
                TESTER_ID_FILTER.Items.Clear();
                return; 
            }
            TESTER_ID_FILTER.Items.Clear();
            TESTER_ID_FILTER.Items.Add("");
            Connection.CloseConnection();
            Commands(9);
            if (Connection.OpenConnection())
            {
                MySqlDataReader read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    TESTER_ID_FILTER.Items.Add(read_data.GetString("TESTER"));
                }
                Connection.CloseConnection();
            }
            else
            {
                Connection.CloseConnection();
                this.Close();
            }
        }

        private void ClearVspecTestStep()
        {
            VSPECS.Items.Clear();
            TEST_STEP_FILTER.Items.Clear();
            VSPECS.SelectedIndex = -1;
            TEST_STEP_FILTER.SelectedIndex = -1;
            VSPECS.Items.Add(" ");
            TEST_STEP_FILTER.Items.Add(" ");
        }

        private void PRODUCT_OWNER_FILTER_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (PRODUCT_OWNER_FILTER.SelectedIndex == 0)
            {
                PRODUCT_OWNER_FILTER.DroppedDown = false;
                PART_NAME_FILTER.SelectedIndex = 0;
                PART_NAME_FILTER.Items.Clear();
                return;
            }
            PART_NAME_FILTER.Items.Clear();
            PART_NAME_FILTER.Items.Add("");
            ClearVspecTestStep();
            Connection.CloseConnection();
            try
            {
                Commands(10);
                Connection.OpenConnection();

                MySqlDataReader read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    PART_NAME_FILTER.Items.Add(read_data.GetString("DEVICE"));
                }
                Connection.CloseConnection();
            }
            catch (Exception ERROR)
            {
                MessageBox.Show(ERROR.ToString());
                Connection.CloseConnection();
            }
        }

        private void PART_NAME_FILTER_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearVspecTestStep();
            try
            {
                Commands(11);
                Connection.OpenConnection();

                MySqlDataReader read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    VSPECS.Items.Add(read_data.GetString("VSPEC"));
                }
                Connection.CloseConnection();

                Commands(12);
                Connection.OpenConnection();

                read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    TEST_STEP_FILTER.Items.Add(read_data.GetString("TEST_STEP"));
                }
                Connection.CloseConnection();
            }
            catch (Exception ERROR)
            {
                MessageBox.Show(ERROR.ToString());
                Connection.CloseConnection();
            }
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
            secondCount += 30;
            if (secondCount > int.Parse(all))
            {
                secondCount = int.Parse(all);
            }
            firstCount += 30;
            range += 30;
            Results();
            CommandComboBox();
            Load_data(7);
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
            Load_data(7);
            Results();
        }

        private void ClearFilter()
        {
            FROM_DATE.CustomFormat = " ";
            TO_DATE.CustomFormat = " ";
            BIN_NUMBER_FILTER.Clear();
            TESTER_ID_FILTER.Items.Clear();
            VSPECS.Items.Clear();
            TEST_STEP_FILTER.Items.Clear();
            TESTER_ID_FILTER.Items.Add(" ");
            TESTER_ID_FILTER.SelectedIndex = 0;
            TESTER_PLATFORM_FILTER.SelectedIndex = 0;
            PRODUCT_OWNER_FILTER.SelectedIndex = 0;
            TEST_STEP_FILTER.SelectedIndex = -1;
            PART_NAME_FILTER.SelectedIndex = -1;
            VSPECS.SelectedIndex = -1;
        }

        private void CommandComboBox()
        {
            FullTextCommand = "";
            ComboBoxCount = 0;
            search_text.Clear();

            if (TESTER_PLATFORM_FILTER.Text != "")                                                        //TESTER PLATFORM
            {
                FullTextCommand = string.Format("where `TEST_SYSTEM`= '{0}'", TESTER_PLATFORM_FILTER.Text);
                ComboBoxCount++;
            } 
            if (!string.IsNullOrWhiteSpace(TESTER_ID_FILTER.Text))                                                                 // TESTER ID
            {
                FullTextCommand += string.Format(" and `TESTER_ID` = '{0}'", TESTER_ID_FILTER.Text);
            }
            if (PRODUCT_OWNER_FILTER.Text != "")                                                                 // PRODUCT OWNER
            {
                if (ComboBoxCount != 0)
                {
                    FullTextCommand += string.Format(" and `PRODUCT_OWNER` = '{0}'", PRODUCT_OWNER_FILTER.Text);
                    ComboBoxCount++;
                }
                else
                {
                    FullTextCommand = string.Format("where `PRODUCT_OWNER` = '{0}'", PRODUCT_OWNER_FILTER.Text);
                    ComboBoxCount++;
                }
            }
            if (PART_NAME_FILTER.Text != "")                                                                 // PART NAME
            {
                FullTextCommand += String.Format(" and `PART_NAME` LIKE '%{0}%'", PART_NAME_FILTER.Text);
            }
            if (!String.IsNullOrWhiteSpace(TEST_STEP_FILTER.Text))                                                                 // TEST STEP
            {
                FullTextCommand += string.Format(" and `TEST_STEP` = '{0}'", TEST_STEP_FILTER.Text);
            }
            if (!String.IsNullOrWhiteSpace(VSPECS.Text))
            {
                FullTextCommand += string.Format(" and `VSPEC` = '{0}'", VSPECS.Text);
            }
            if (STATUS_FILTER.Text != "")                                                                 // STATUS
            {
                if (ComboBoxCount != 0)
                {
                    FullTextCommand += string.Format(" and `STATUS` = '{0}'", STATUS_FILTER.Text);
                    ComboBoxCount++;
                }
                else
                {
                    FullTextCommand = string.Format("where `STATUS` = '{0}'", STATUS_FILTER.Text);
                    ComboBoxCount++;
                }
            }
            if (!String.IsNullOrWhiteSpace(BIN_NUMBER_FILTER.Text))                                     // BIN NUMBER
            {
                if (ComboBoxCount != 0)
                {
                    FullTextCommand += string.Format(" and `BIN_NUMBER` = '{0}'", BIN_NUMBER_FILTER.Text);
                    ComboBoxCount++;
                }
                else
                {
                    FullTextCommand = string.Format("where `BIN_NUMBER` = '{0}'", BIN_NUMBER_FILTER.Text);
                    ComboBoxCount++;
                }
            }
            if (!string.IsNullOrWhiteSpace(FROM_DATE.Text))                                                // DATE FILTERING
            {
                if (!string.IsNullOrWhiteSpace(TO_DATE.Text))
                {
                    DATE_FILTER = string.Format("(`DATE_ENCOUNTERED` between '{0}' and '{1}')", FROM_DATE.Text, TO_DATE.Text);
                }
                else
                {
                    DATE_FILTER = string.Format("(`DATE_ENCOUNTERED` = '{0}')", FROM_DATE.Text);
                }
                if (ComboBoxCount != 0)
                {
                    FullTextCommand += string.Format(" and {0}", DATE_FILTER);
                }
                else
                {
                    FullTextCommand = string.Format("where {0}", DATE_FILTER);
                }
            }
        }
    }
}
 