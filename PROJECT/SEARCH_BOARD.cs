using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Squirrel;
using System.Reflection;

namespace PROJECT
{
    public partial class SEARCH_BOARD : System.Windows.Forms.Form
    {
        public string check,all,month1,month2,year,DateFilter;
        public int count, ComboBoxCount, firstCount, secondCount, range = 0, WW, ConvertYear;
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

                Commands(13);
                Connection.OpenConnection();

                read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    HITCOUNT.Items.Add(new ListViewItem(new[] { read_data.GetString("PART_NAME"), read_data.GetString("HITCOUNT") }));
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
                BOARD_DETAILS details = new BOARD_DETAILS(endorsement_number,UserAccount);
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
                case 13: // LOAD HIT COUNT
                    command = new MySqlCommand("SELECT `PART_NAME`,count(`PART_NAME`) as HITCOUNT from `DETAILS` GROUP BY `PART_NAME` ORDER BY `HITCOUNT` DESC", Connection.connect);
                    break;
                case 14: // LOAD Q2-Q4
                    command = new MySqlCommand(string.Format("select `part_name`,count(*) as HitCount from `details` " +
                        "where month(`DATE_ENCOUNTERED`) between '{0}' and '{1}' and year(`DATE_ENCOUNTERED`) = '{2}' " +
                        "group by `part_name` order by `HitCount` desc",month1,month2, FISCAL_YEAR.Text), Connection.connect);
                    break;
                case 15: // LOAD Q1
                    command = new MySqlCommand(string.Format("SELECT `PART_NAME`,count(*) as HitCount from `DETAILS`" +
                        "WHERE `DATE_ENCOUNTERED` BETWEEN '{0}-11-01' AND '{1}-01-31'" +
                        "GROUP BY `PART_NAME` ORDER BY `HitCount` DESC", year, FISCAL_YEAR.Text), Connection.connect);
                    break;
                case 16: // LOAD YEAR
                    command = new MySqlCommand(string.Format("SELECT `PART_NAME`,count(*) as HitCount from `DETAILS`" +
                        "WHERE YEAR(`DATE_ENCOUNTERED`) = '{0}'" +
                        "GROUP BY `PART_NAME` ORDER BY `HitCount` DESC", FISCAL_YEAR.Text), Connection.connect);
                    break;
                case 17: // LOAD DATA IN DATAGRIDVIEW THAT HAS BEEN CLICK IN THE PARETO LIST

                    ConvertYear = Convert.ToInt32(FISCAL_YEAR.Text);

                    year = Convert.ToString(ConvertYear - 1);

                    if (QUARTER.Text == "1")
                    {
                        DateFilter = string.Format("and (`DATE_ENCOUNTERED` BETWEEN '{0}-11-01' AND '{1}-01-31') ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30", year, FISCAL_YEAR.Text);
                    }
                    else if (QUARTER.Text == "2" || QUARTER.Text == "3" || QUARTER.Text == "4")
                    {
                        if (QUARTER.Text == "2") { month1 = "2"; month2 = "4"; }
                        else if (QUARTER.Text == "3") { month1 = "5"; month2 = "7"; }
                        else { month1 = "8"; month2 = "10"; }

                        DateFilter = string.Format("and (month(`DATE_ENCOUNTERED`) between '{0}' and '{1}' and year(`DATE_ENCOUNTERED`) = '{2}') " +
                        "ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30", month1, month2, FISCAL_YEAR.Text);
                    }
                    else
                        DateFilter = string.Format("and YEAR(`DATE_ENCOUNTERED`) = '{0}'", FISCAL_YEAR.Text);


                    command = new MySqlCommand(string.Format("SELECT `PART_NAME`,`LOT_ID`,`TEST_NUMBER`,`TESTER_ID`,`TEST_STEP`," +
                        "`DATE_ENCOUNTERED`,`PRODUCT_OWNER`,`STATUS`,`ENDORSEMENT_NUMBER` FROM `DETAILS` " +
                        "WHERE `PART_NAME` = '{0}'{1} ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30 ", HITCOUNT.SelectedItems[0].Text,DateFilter), Connection.connect);
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

                HITCOUNT.Items.Clear();
                Commands(13);
                Connection.OpenConnection();

                MySqlDataReader Read_data = command.ExecuteReader();
                while (Read_data.Read())
                {
                    HITCOUNT.Items.Add(new ListViewItem(new[] { Read_data.GetString("PART_NAME"), Read_data.GetString("HITCOUNT") }));
                }
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

        private void Click_Pareto(object sender, EventArgs e)
        {
            try
            {
                
                dataGridViewList.DataSource = Table(17);

            }
            catch (Exception ErrorMessage)
            {
                MessageBox.Show(ErrorMessage.ToString());
                Connection.CloseConnection();
            }
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

        private void SEARCH_PARETO_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(FISCAL_YEAR.Text))
            {
                HITCOUNT.Items.Clear();
                ConvertYear = Convert.ToInt32(FISCAL_YEAR.Text);

                year = Convert.ToString(ConvertYear - 1);

                if (QUARTER.Text == "2") { month1 = "2"; month2 = "4"; Commands(14); }
                else if (QUARTER.Text == "3") { month1 = "5"; month2 = "7"; Commands(14); }
                else if (QUARTER.Text == "4") { month1 = "8"; month2 = "10"; Commands(14); }
                else if (QUARTER.Text == "1") { Commands(15); }
                else Commands(16); 

                Connection.OpenConnection();

                MySqlDataReader Read_data = command.ExecuteReader();
                while (Read_data.Read())
                {
                    HITCOUNT.Items.Add(new ListViewItem(new[] { Read_data.GetString("PART_NAME"), Read_data.GetString("HITCOUNT") }));
                }
                Connection.CloseConnection();
            }
            else
            {
                MessageBox.Show("PLEASE CHOOSE FISCAL YEAR");
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
 