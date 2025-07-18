using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
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
        public string Approver { get; set; }

        MySqlCommand command;
        public SEARCH_BOARD(string User,string Approver_access)
        {
            InitializeComponent();
            UserAccount = User;
            Approver = Approver_access;
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

                Commands(13);
                Connection.OpenConnection();
                MySqlDataReader read_data = command.ExecuteReader();

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
            //MessageBox.Show(dataGridViewList.SelectedCells[9].Value.ToString());
            try
            {
                string endorsement_number = dataGridViewList.SelectedCells[9].Value.ToString();
                BOARD_DETAILS details = new BOARD_DETAILS(endorsement_number,UserAccount,Approver);
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
                case 3:  //FOR UPDATING PURPOSES
                    command = new MySqlCommand("SELECT `PART_NAME`,`TEST_NUMBER`,`TEST_NAME`,`TESTER_ID`,`TEST_STEP`,`DATE_ENCOUNTERED`,`PRODUCT_OWNER`," +
                        "`STATUS`,if(`STATUS` = 'OPEN' OR `STATUS` = 'FOR APPROVAL',datediff(curdate(),`DATE_ENCOUNTERED`),'CLOSED') as `CYCLE_TIME`,`ENDORSEMENT_NUMBER` FROM `hit`.`details` ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30", Connection.connect);
                    break;
                case 4: // SEARCHING TRANSACTION COUNTS WITH FILTER
                    command = new MySqlCommand(string.Format("SELECT COUNT(*) FROM `hit`.`details` {0}",FullTextCommand), Connection.connect);
                    break;
                case 6:  // FOR SEARCH IN COMBO BOXES
                    command = new MySqlCommand(string.Format("Select `PART_NAME`,`TEST_NUMBER`,`TEST_NAME`,`TESTER_ID`,`TEST_STEP`," +
                        "`DATE_ENCOUNTERED`,`PRODUCT_OWNER`,`STATUS`,if(`STATUS` = 'OPEN' OR `STATUS` = 'FOR APPROVAL',datediff(curdate(),`DATE_ENCOUNTERED`),'CLOSED') as `CYCLE_TIME`,`ENDORSEMENT_NUMBER`" +
                        "FROM `hit`.`details` {0} ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30",FullTextCommand), Connection.connect);
                    break;
                case 7: //NEXT BUTTON
                    command = new MySqlCommand(string.Format("Select `PRODUCT_OWNER`,`PART_NAME`,`TEST_NUMBER`,`TEST_NAME`,`TESTER_ID`,`TEST_STEP`," +
                        "`DATE_ENCOUNTERED`,`STATUS`,if(`STATUS` = 'OPEN',datediff(curdate(),`DATE_ENCOUNTERED`),'CLOSED') as `CYCLE_TIME`,`ENDORSEMENT_NUMBER` " +
                        "FROM `hit`.`details` {0} ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT {1},30", FullTextCommand, range), Connection.connect);
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

                    if (!string.IsNullOrEmpty(FISCAL_YEAR.Text) || !string.IsNullOrEmpty(QUARTER.Text) || !string.IsNullOrEmpty(WORKWEEK.Text))
                    {
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
                    }


                    command = new MySqlCommand(string.Format("SELECT `PRODUCT_OWNER`,`PART_NAME`,`TEST_NUMBER`,`TEST_NAME`,`TESTER_ID`,`TEST_STEP`," +
                        "`DATE_ENCOUNTERED`,`STATUS`,if(`STATUS` = 'OPEN' OR `STATUS` = 'FOR APPROVAL',datediff(curdate(),`DATE_ENCOUNTERED`),'CLOSED') as `CYCLE_TIME`,`ENDORSEMENT_NUMBER` FROM `DETAILS` " +
                        "WHERE `PART_NAME` = '{0}'{1} ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30 ", HITCOUNT.SelectedItems[0].Text,DateFilter), Connection.connect);
                    break;
                case 18:
                    command = new MySqlCommand(string.Format("SELECT COUNT(*) FROM `hit`.`DETAILS` " +
                        "WHERE `PART_NAME` = '{0}'{1} ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 30 ", HITCOUNT.SelectedItems[0].Text, DateFilter), Connection.connect);
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
                        //search_text.Clear();
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

            foreach (Control CheckText in this.groupBox1.Controls)
            {
                if (CheckText is TextBox)
                    CheckText.Text.Trim();
            }
            CommandComboBox();

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

        private void Add_btn_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ADD next = new ADD(1,UserAccount);
            next.ShowDialog();
        }
        private void REFRESH_Click(object sender, EventArgs e)
        {
            ClearFilter();
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

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ADD next = new ADD(2, UserAccount);
            next.ShowDialog();
        }

        private void Click_Pareto(object sender, EventArgs e)
        {
            range = 0;
            try
            {   
                Commands(18);
                Connection.OpenConnection();
                
                all = command.ExecuteScalar().ToString();
                Connection.CloseConnection();
                Counts();
                Results();
                dataGridViewList.DataSource = Table(17);

            }
            catch (Exception ErrorMessage)
            {
                MessageBox.Show(ErrorMessage.ToString());
                Connection.CloseConnection();
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
            FACTORY.SelectedIndex = -1;
            PRODUCT_OWNER_FILTER.Clear();
            PART_NAME_FILTER.Clear();
            TESTER_PLATFORM_FILTER.Clear();
            TESTER_ID_FILTER.Clear();
            TEST_NUMBER_SEARCH.Clear();
            TEST_NAME_SEARCH.Clear();
            TEST_STEP_FILTER.Items.Clear();
            VSPEC.Clear();
            STATUS_FILTER.SelectedIndex = -1;
            FROM_DATE.CustomFormat = " ";
            TO_DATE.CustomFormat = " "; 
        }

        private void CommandComboBox()
        {
            List<string> Conditions = new List<string>();
            FullTextCommand = "";

            if (!string.IsNullOrEmpty(FACTORY.Text))
            {
                Conditions.Add($"`FACTORY` LIKE '%{FACTORY.Text}%'");
            }
            if (!string.IsNullOrEmpty(PRODUCT_OWNER_FILTER.Text))
            {
                Conditions.Add($"`PRODUCT_OWNER` LIKE '%{PRODUCT_OWNER_FILTER.Text}%'");
            }
            if (!string.IsNullOrEmpty(PART_NAME_FILTER.Text))
            {
                Conditions.Add($"`PART_NAME` LIKE '%{PART_NAME_FILTER.Text}%'");
            }
            if (!string.IsNullOrEmpty(TESTER_PLATFORM_FILTER.Text))
            {
                Conditions.Add($"`TESTER_PLATFORM` LIKE '%{TESTER_PLATFORM_FILTER.Text}%'");
            }
            if (!string.IsNullOrEmpty(TESTER_ID_FILTER.Text))
            {
                Conditions.Add($"`TESTER_ID` LIKE '%{TESTER_ID_FILTER}%'");
            }
            if (!string.IsNullOrEmpty(TEST_NUMBER_SEARCH.Text))
            {
                Conditions.Add($"`TEST_NUMBER` LIKE '%{TEST_NUMBER_SEARCH.Text}%'");
            }
            if (!string.IsNullOrEmpty(TEST_NAME_SEARCH.Text))
            {
                Conditions.Add($"`TEST_NAME` LIKE '%{TEST_NAME_SEARCH.Text}%'");
            }
            if (!string.IsNullOrEmpty(TEST_STEP_FILTER.Text))
            {
                Conditions.Add($"`TEST_STEP` LIKE '%{TEST_STEP_FILTER.Text}%'");
            }
            if (!string.IsNullOrEmpty(VSPEC.Text))
            {
                Conditions.Add($"`VSPEC` LIKE '%{VSPEC.Text}%'");
            }
            if (!string.IsNullOrEmpty(STATUS_FILTER.Text))
            {
                Conditions.Add($"`STATUS` LIKE '%{STATUS_FILTER.Text}%'");
            }
            if (!string.IsNullOrWhiteSpace(FROM_DATE.Text))
            {
                if (!string.IsNullOrWhiteSpace(TO_DATE.Text))
                {
                    Conditions.Add(string.Format("(`DATE_ENCOUNTERED` between '{0}' and '{1}')", FROM_DATE.Text, TO_DATE.Text));
                }
                else
                {
                    Conditions.Add(string.Format("(`DATE_ENCOUNTERED` = '{0}')", FROM_DATE.Text));
                }
            }
            if (Conditions.Count == 1)
            {
                FullTextCommand = "where" + Conditions[0];
            }
            else if (Conditions.Count > 1)
            {
                FullTextCommand = "where" + string.Join(" and", Conditions);
            }
            else FullTextCommand = string.Empty;
        }
    }
}
 