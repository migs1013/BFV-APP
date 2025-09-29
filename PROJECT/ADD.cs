using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PROJECT
{
    public partial class ADD : System.Windows.Forms.Form
    {
        MySqlCommand command;
        long FileSize;
        byte[] Data;
        public static string FileName, database, DATALOG, Dataloglink, UpdateData, FileNameNumber, WordCheck,Temp,TestOption,subject,body, 
                      hostname, dlog1 = "", dlog2 = "", dlog3 = "", dlog4 = "",Stage_Temp,failure,BIN;

        public int Endorsement_Number,FileNameLength, WordCount = 0;
        public string UserName { get; set; }
        public int Device_option { get; set; }
        public static List<string> Files = new List<string>();
        public DateTime WriteTime = new DateTime();

        public ADD(int Option,string User)
        {
            InitializeComponent();
            Device_option = Option;
            UserName = User;
        }

        private void Error()
        {
            MessageBox.Show("INCOMPLETE DETAILS!");
        }
        private byte[] SaveFile(string file)
        {
            using (Stream getDatalog = File.OpenRead(file))
            {
                Data = new byte[getDatalog.Length];
                getDatalog.Read(Data, 0, Data.Length);
            }
            return Data;
        }
        private string Filename(string filename)
        {
            FileName = new FileInfo(filename).Name;
            return FileName;
        }

        private void DatalogNumber(int DatalogNumber)
        {
            if (DatalogNumber == 1)
            {
                DATALOG = "FIRST_DATALOG";
                UpdateData = "FIRST_DATA";
                FileNameNumber = "FILENAME_1";
                Dataloglink = dlog1;
            }
            else if (DatalogNumber == 2)
            {
                DATALOG = "SECOND_DATALOG";
                UpdateData = "SECOND_DATA";
                FileNameNumber = "FILENAME_2";
                Dataloglink = dlog2;
            }
            else if (DatalogNumber == 3)
            {
                DATALOG = "THIRD_DATALOG";
                UpdateData = "THIRD_DATA";
                FileNameNumber = "FILENAME_3";
                Dataloglink = dlog3;
            }
            else
            {
                DATALOG = "FOURTH_DATALOG";
                UpdateData = "FOURTH_DATA";
                FileNameNumber = "FILENAME_4";
                Dataloglink = dlog4;
            }
        }

        private void SendData(int InputCommand)
        {
            Commands(InputCommand);
            command.Connection = Connection.connect;

            Connection.OpenConnection();

            command.ExecuteNonQuery();


            Connection.CloseConnection();

        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (!CheckDetails()) return;
            Stage_Temp = string.Join(" ", TEST_STAGE.Text, TEMPERATURE.Text);
            DialogResult yes_no = MessageBox.Show(("PLEASE DOUBLE CHECK YOUR DATA,THIS WILL BE SAVE PERMANENTLY. SAVE IT?"), "ATTENTION", MessageBoxButtons.YesNo);
            switch (yes_no)
            {
                case DialogResult.Yes:
                    try
                    {
                        if (FACTORY.Text != "F1")
                            SUB_FACTORY.Text = "N/A";
                        if (FAILURE_ASSESSMENT.SelectedIndex == 1)
                        {
                            SendData(6);

                        }
                        else SendData(9);

                        Commands(1);
                        command.Connection = Connection.connect;
                        Connection.OpenConnection();

                        MySqlDataReader read_status = command.ExecuteReader();
                        read_status.Read();

                        Endorsement_Number = Convert.ToInt32(read_status["ENDORSEMENT_NUMBER"].ToString());

                        Connection.CloseConnection();

                        if (dlog1.Contains("\\"))
                        {
                            DatalogNumber(1); SendData(5);
                            Files.Add(dlog1);
                        }
                        if (dlog2.Contains("\\"))
                        {
                            DatalogNumber(2); SendData(5);
                            Files.Add(dlog2);
                        }
                        if (dlog3.Contains("\\"))
                        {
                            DatalogNumber(3); SendData(5);
                            Files.Add(dlog3);
                        }
                        if (dlog4.Contains("\\"))
                        {
                            DatalogNumber(4); SendData(5);
                            Files.Add(dlog4);
                        }

                        if (FAILURE_ASSESSMENT.SelectedIndex == 0) failure = FAILURE_ASSESSMENT.Text + " (FOR APPROVAL)";
                        else failure = FAILURE_ASSESSMENT.Text;

                        BIN = "BIN " + BIN_NUMBER.Text + " TP#" + TEST_NUMBER.Text + " " + TEST_NAME.Text;

                        subject = string.Join(" | ", LOT_ID.Text, TEST_STAGE.Text + " " + TEMPERATURE.Text, Failure_mode.Text, BIN);

                        body = String.Format(@"(THIS IS A SYSTEM GENERATED EMAIL. DO NOT REPLY TO THIS EMAIL.<br><br>

<b>PARTNAME:</b> {0}<br><br>

<b>TESTER:</b> {1} <b>HANDLER:</b> {2}<br><br>

<b>BOARD ID:</b> {3}<br><br>

<b>FAILURE MODE:</b> {4}<br><br>

<b>FAILURE PERFORMANCE:</b> {5}<br><br>

<b>PROBLEM DESCRIPTION:</b> 
{6}<br><br>

<b>DISPOSITION:</b> 
{7}<br><br>

<b>POTENTIAL ROOTCAUSE:</b> {8}<br><br>

<b>FAILURE ASSESSMENT:</b> {9}<br><br>

<b>LOGGED BY:</b> {10}<br><br>

(THIS IS A SYSTEM GENERATED EMAIL. DO NOT REPLY TO THIS EMAIL. PLEASE CONTACT JOHN MICHAEL SO FOR ANY CONCERN)."
, PART_NAME.Text, TESTER_ID.Text, HANDLER_ID.Text, BOARD_ID.Text, Failure_mode.Text, FAILURE_PERFORMANCE.Text, Problem.Text, Action.Text, POTENTIAL_ROOTCAUSE.Text, failure, UserName);

                        Connection.ClearAll(this);
                        Connection.CloseConnection();

                        SavingWindow save = new SavingWindow(1,SUB_FACTORY.Text);
                        SUB_FACTORY.SelectedIndex = -1;
                        save.ShowDialog();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        Connection.CloseConnection();
                    }
                    break;
                case DialogResult.No:
                    return;
            }
        }

        
        private void Commands(int Pick)
        {
            switch (Pick)
            {
                case 1:  // FOR CHECKING THE ENDORSEMENT NUMBER
                    command = new MySqlCommand("SELECT `ENDORSEMENT_NUMBER` FROM `hit`.`details`" +
                        " WHERE (`PART_NAME` = '" + PART_NAME.Text + "' and `LOT_ID` = '" + LOT_ID.Text + "') " +
                        "ORDER BY `ENDORSEMENT_NUMBER` DESC LIMIT 1");
                    break;
                case 2:  // LOAD TESTER PLATFORM AND TESTER ID
                    command = new MySqlCommand(string.Format("SELECT `TESTER`,`TESTER_PLATFORM` FROM `hit`.`hostnames` where `HOSTNAME` = '{0}'",hostname));
                    break;
                case 3:  // LOAD HANDLER ID
                    command = new MySqlCommand(string.Format("SELECT `HANDLER_ID` from `hit`.`details` WHERE `PART_NAME` = '{0}' GROUP BY `HANDLER_ID`",PART_NAME.Text));
                    break;
                case 4:  // LOAD BOARD ID
                    command = new MySqlCommand(string.Format("SELECT `BOARD_ID` from `hit`.`details` WHERE `PART_NAME` = '{0}' GROUP BY `BOARD_ID`", PART_NAME.Text));
                    break;
                case 5: // INSERT DATALOG
                    command = new MySqlCommand(string.Format("UPDATE `hit`.`details` SET `{0}` = @{1},`{2}` = '{3}'" +
                        "WHERE (`ENDORSEMENT_NUMBER` = '" + Endorsement_Number + "')", DATALOG, UpdateData, FileNameNumber, Filename(Dataloglink)));
                    command.Parameters.Add(string.Format("@{0}", UpdateData), MySqlDbType.LongBlob).Value = SaveFile(Dataloglink);
                    break;
                case 6: // INSERT NEW TRANSACTION WITH OPEN STATUS
                    command = new MySqlCommand("INSERT INTO `hit`.`details` " +
                        "(`PART_NAME`,`LOT_ID`,`VSPEC`,`TEST_STAGE`,`TESTER_PLATFORM`,`TESTER_ID`,`HANDLER_ID`,`FAILURE_MODE`,`FAILURE_PERFORMANCE`,`BOARD_ID`," +
                        "`BIN_NUMBER`,`TEST_NUMBER`,`TEST_NAME`,`STATUS`,`POTENTIAL_ROOTCAUSE`,`PRODUCT_OWNER`,`DATE_ENCOUNTERED`,`USER`,`PROBLEM`,`ACTION`,`FACTORY`,`SUB_FACTORY`,`BU_STRAT`) " +
                        "VALUES ('" + PART_NAME.Text + "', '" + LOT_ID.Text + "','" + VSPEC.Text + "','" + Stage_Temp + "','" + Tester_platform.Text + "'," +
                        "'" + TESTER_ID.Text + "','" + HANDLER_ID.Text + "','" + Failure_mode.Text + "','" + FAILURE_PERFORMANCE.Text + "','" + BOARD_ID.Text + "','" + BIN_NUMBER.Text + "'," +
                        "'" + TEST_NUMBER.Text + "','" + TEST_NAME.Text + "','" + FAILURE_ASSESSMENT.Text + "','" + POTENTIAL_ROOTCAUSE.Text + "','" + PRODUCT_OWNER.Text + "'," +
                        "'" + WriteTime.ToString("yyyy-MM-dd") + "','" + UserName + "','" + Problem.Text + "','" + Action.Text + "','" + FACTORY.Text + "','" + SUB_FACTORY.Text + "','" + BU_STRAT.Text + "')");
                    break;
                case 7: // LOAD PRODUCT OWNER
                    command = new MySqlCommand(string.Format("select `PRODUCT_OWNER` from `device` where locate(`DEVICE`,'{0}') = 1",PART_NAME.Text));
                    break;
                case 8: // LOAD BIN NUMBER
                    command = new MySqlCommand(string.Format("SELECT `BIN_NUMBER` from `hit`.`details` WHERE `PART_NAME` = '{0}' and `TEST_STEP` = '{1}' " +
                        "GROUP BY `BIN_NUMBER`", PART_NAME.Text, TEST_STAGE.Text));
                    break;
                case 9:  // INSERT NEW TRANSACTION WITH CLOSED STATUS
                    command = new MySqlCommand("INSERT INTO `hit`.`details` " +
                        "(`PART_NAME`,`LOT_ID`,`VSPEC`,`TEST_STAGE`,`TESTER_PLATFORM`,`TESTER_ID`,`HANDLER_ID`,`FAILURE_MODE`,`FAILURE_PERFORMANCE`,`BOARD_ID`," +
                        "`BIN_NUMBER`,`TEST_NUMBER`,`TEST_NAME`,`STATUS`,`POTENTIAL_ROOTCAUSE`,`PRODUCT_OWNER`,`DATE_ENCOUNTERED`,`USER`,`PROBLEM`,`ACTION`," +
                        "`PO_COMMENT`,`DISPO_DATE`,`DISPO_USER`,`FACTORY`,`SUB_FACTORY`,`BU_STRAT`) " +
                        "VALUES ('" + PART_NAME.Text + "', '" + LOT_ID.Text + "','" + VSPEC.Text + "','" + Stage_Temp + "','" + Tester_platform.Text + "'," +
                        "'" + TESTER_ID.Text + "','" + HANDLER_ID.Text + "','" + Failure_mode.Text + "','" + FAILURE_PERFORMANCE.Text + "','" + BOARD_ID.Text + "','" + BIN_NUMBER.Text + "'," +
                        "'" + TEST_NUMBER.Text + "','" + TEST_NAME.Text + "','FOR APPROVAL','" + POTENTIAL_ROOTCAUSE.Text + "','" + PRODUCT_OWNER.Text + "'," +
                        "'" + WriteTime.ToString("yyyy-MM-dd") + "','" + UserName + "','" + Problem.Text + "','" + Action.Text + "','PLEASE REFER TO DISPOSITION'," +
                        "'" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + UserName + "','" + FACTORY.Text + "','" + SUB_FACTORY.Text + "','" + BU_STRAT.Text + "')");
                    break;
                case 10: // LOAD TESTER PLATFORMS
                    command = new MySqlCommand("SELECT `TESTER_PLATFORM` FROM `DETAILS` GROUP BY `TESTER_PLATFORM`");
                    break;
                case 11: // LOAD PRODUCT OWNER BASED ON SELECTED SUB FACTORY
                    command = new MySqlCommand(string.Format("SELECT `PRODUCT_OWNER` FROM `details` WHERE `FACTORY` = '{0}' and `SUB_FACTORY` = '{1}' GROUP BY `PRODUCT_OWNER` order by `PRODUCT_OWNER`",FACTORY.Text,SUB_FACTORY.Text));
                    break;
                case 12: // CHECK PRODUCT OWNER COUNT BASED ON SELECTED SUB FACTORY
                    command = new MySqlCommand(string.Format("SELECT COUNT(*) AS `COUNT` FROM `DETAILS` WHERE `FACTORY` = '{0}' AND `SUB_FACTORY` = '{1}' AND `PRODUCT_OWNER` <> 'NOT APPLICABLE'", FACTORY.Text,SUB_FACTORY.Text));
                    break;
                case 13: // LOAD PRODUCT OWNER BASED ON SELECTED BU STRAT
                    command = new MySqlCommand(string.Format("SELECT `PRODUCT_OWNER` FROM `details` WHERE `FACTORY` = '{0}' and `SUB_FACTORY` = '{1}' GROUP BY `PRODUCT_OWNER` order by `PRODUCT_OWNER`", FACTORY.Text, SUB_FACTORY.Text));
                    break;
                case 14: // CHECK PRODUCT OWNER COUNT BASED ON SELECTED BU STRAT
                    command = new MySqlCommand(string.Format("SELECT COUNT(*) AS `COUNT` FROM `DETAILS` WHERE `FACTORY` = '{0}' AND `SUB_FACTORY` = '{1}' AND `PRODUCT_OWNER` <> 'NOT APPLICABLE'", FACTORY.Text, SUB_FACTORY.Text));
                    break;
            }
        }
        private bool CheckDetails()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;

                    textBox.Text.Trim();

                    if (textBox == Problem || textBox == Action || textBox == TEST_NAME)
                        continue;
                    else
                    {
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            Error();
                            return false;
                        }
                        else if (textBox.Text.Length > 60)
                        {
                            MessageBox.Show("TOO LONG INPUT!");
                            return false;
                        }
                        else continue;
                    }
                }
                else if (c is ComboBox)
                {
                    ComboBox comboBox = c as ComboBox;

                    comboBox.Text.Trim();

                    if (string.IsNullOrWhiteSpace(comboBox.Text))
                    {
                        Error();
                        return false;
                    }
                    else if (comboBox.Text.Length > 40)
                    {
                        MessageBox.Show("TOO LONG INPUT!");
                        return false;
                    }
                }
                else continue;
            }
            if (first_verif_link.Text == string.Empty || FACTORY.Text == string.Empty || SUB_FACTORY.Text == string.Empty)
            {
                Error();
                return false;
            }
            return true;
        }

        private void SUB_FACTORY_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectProductOwner(12, 11);
        }

        private void BU_STRAT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectProductOwner(14, 13);
        }

        private void SelectProductOwner(int counts,int PO)
        {
            int check_count;
            try
            {
                PRODUCT_OWNER.Items.Clear();
                PRODUCT_OWNER.Items.Add("NOT APPLICABLE");

                Commands(counts);
                command.Connection = Connection.connect;
                Connection.OpenConnection();
                MySqlDataReader read_data = command.ExecuteReader();
                read_data.Read();

                check_count = Convert.ToInt32(read_data["COUNT"].ToString());

                Connection.CloseConnection();

                if (check_count >= 1)
                {
                    Commands(PO);
                    command.Connection = Connection.connect;
                    Connection.OpenConnection();
                    read_data = command.ExecuteReader();

                    while (read_data.Read())
                    {
                        PRODUCT_OWNER.Items.Add(read_data.GetString("PRODUCT_OWNER"));
                    }
                    Connection.CloseConnection();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                Connection.CloseConnection();
            }
        }

        private void InsertDatalog(LinkLabel DlogName,Label Date)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "BROWSE A FILE";
            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileSize = new System.IO.FileInfo(openFileDialog1.FileName).Length;
                if (FileSize > 5150000)
                {
                    MessageBox.Show("FILE SIZE MUST NOT EXCEED 5MB");
                    return;
                }
                DlogName.Visible = true;
                if (Filename(openFileDialog1.FileName).Length < 20)
                {
                    first_verif_link.Text = Filename(openFileDialog1.FileName);
                }
                else
                    first_verif_link.Text = Filename(openFileDialog1.FileName).Remove(20, Filename(openFileDialog1.FileName).Length - 20) + ".....";
                dlog1 = openFileDialog1.FileName;
                WriteTime = System.IO.File.GetLastWriteTime(openFileDialog1.FileName);
                Date.Text = WriteTime.ToString("yyyy-MM-dd");
            }
        }

        private void BIN_NUMBER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChangeLetterToUpperCase(e);
        }

        private void TEST_NUMBER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChangeLetterToUpperCase(e);
        }

        private void Tester_platform_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChangeLetterToUpperCase(e);
        }

        private void PRODUCT_OWNER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChangeLetterToUpperCase(e);
        }

        private void Add_first_verif_Click(object sender, EventArgs e)
        {

            try
            {

                InsertDatalog(first_verif_link, FirstDate);

                if (string.IsNullOrEmpty(dlog1)) return;

                if (Device_option == 1)
                {
                    HANDLER_ID.Items.Clear();
                    BOARD_ID.Items.Clear();
                    BIN_NUMBER.Items.Clear();
                    TEST_NUMBER.Items.Clear();

                    HANDLER_ID.Text = BOARD_ID.Text = BIN_NUMBER.Text = TEST_NUMBER.Text = "";

                    WordCheck = Filename(dlog1).Replace("_", " ");

                    string[] words = Regex.Split(WordCheck, @"\s+");

                    foreach (string LotSummary in words)
                    {
                        if (WordCount == 0)
                        {
                            if (LotSummary.ToUpper().Contains("AY") || LotSummary.ToUpper().Contains("AX") || LotSummary.ToUpper().Contains("AZ") || LotSummary.Contains("."))
                            {
                                WordCount = 1;
                                LOT_ID.Text = LotSummary;
                            }
                        }

                        if (LotSummary.ToUpper().Contains("LT") || LotSummary.ToUpper().Contains("ADBMS"))
                            PART_NAME.Text = LotSummary;
                        else if (LotSummary.ToUpper().Contains("V") && LotSummary.ToUpper().Contains("P"))
                            VSPEC.Text = LotSummary;
                        else if ((LotSummary.ToUpper().Contains("ETS") || LotSummary.ToUpper().Contains("STS")) && LotSummary.Contains("-"))
                            hostname = LotSummary;
                        //else if (LotSummary.ToUpper().EndsWith("C") && LotSummary.Length <= 5 && char.IsDigit(Convert.ToChar(LotSummary.Substring(1, 1))))
                        //    Temp = LotSummary;
                        //else if (LotSummary.Length == 2)
                        //    TestOption = LotSummary;
                        else continue;
                    }
                    WordCount = 0;

                    Commands(2);
                    command.Connection = Connection.connect;
                    Connection.OpenConnection();
                    MySqlDataReader read_data = command.ExecuteReader();
                    read_data.Read();
                    TESTER_ID.Text = read_data.GetString("TESTER");
                    Tester_platform.Text = read_data.GetString("TESTER_PLATFORM");
                    Connection.CloseConnection();

                    Commands(3);
                    command.Connection = Connection.connect;
                    Connection.OpenConnection();
                    read_data = command.ExecuteReader();
                    while (read_data.Read())
                    {
                        HANDLER_ID.Items.Add(read_data.GetString("HANDLER_ID"));
                    }
                    Connection.CloseConnection();

                    Commands(4);
                    command.Connection = Connection.connect;
                    Connection.OpenConnection();
                    read_data = command.ExecuteReader();
                    while (read_data.Read())
                    {
                        BOARD_ID.Items.Add(read_data.GetString("BOARD_ID"));
                    }
                    Connection.CloseConnection();

                    Commands(8);
                    command.Connection = Connection.connect;
                    Connection.OpenConnection();
                    read_data = command.ExecuteReader();
                    while (read_data.Read())
                    {
                        BIN_NUMBER.Items.Add(read_data.GetString("BIN_NUMBER"));
                    }
                    Connection.CloseConnection();


                    Commands(7);
                    command.Connection = Connection.connect;
                    Connection.OpenConnection();
                    read_data = command.ExecuteReader();
                    read_data.Read();
                    PRODUCT_OWNER.Text = read_data.GetString("PRODUCT_OWNER");
                    Connection.CloseConnection();
                }

            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
        }

        private void FACTORY_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SUB_FACTORY.Items.Clear();
            if (FACTORY.Text == "F2")
            {
                BU_STRAT.SelectedIndex = 0;
                BU_STRAT.Enabled = false;
                foreach (string sub_factory in Connection.F2_Sub_Factories)
                    SUB_FACTORY.Items.Add(sub_factory);
            }
            else if (FACTORY.Text == "F1")
            {
                BU_STRAT.SelectedIndex = -1;
                BU_STRAT.Enabled = true;
                foreach (string sub_factory in Connection.F1_Sub_Factories)
                    SUB_FACTORY.Items.Add(sub_factory);
            }
        }

        private void ADD_SECOND_DLOG_CLICK(object sender, EventArgs e)
        {
            OtherDatalog(SECOND_DLOG);
            dlog2 = openFileDialog1.FileName;
        }

        private void ADD_THIRD_DLOG_CLICK(object sender, EventArgs e)
        {
            OtherDatalog(THIRD_DLOG);
            dlog3 = openFileDialog1.FileName;
        }

        private void ADD_FOURTH_DLOG_CLICK(object sender, EventArgs e)
        {
            OtherDatalog(FOURTH_DLOG);
            dlog4 = openFileDialog1.FileName;
        }

        private void ChangeLetterToUpperCase(KeyPressEventArgs Input)
        {
            if (Input.KeyChar >= 'a' && Input.KeyChar <= 'z')
                Input.KeyChar -= (char)32;
        }

        private void HANDLER_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChangeLetterToUpperCase(e);
        }

        private void Failure_mode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChangeLetterToUpperCase(e);
        }

        private void BOARD_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChangeLetterToUpperCase(e);
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OtherDatalog(LinkLabel Link)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "BROWSE A FILE";
            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileSize = new System.IO.FileInfo(openFileDialog1.FileName).Length;
                if (FileSize > 5150000)
                {
                    MessageBox.Show("FILE SIZE MUST NOT EXCEED 5MB");
                    return;
                }
                Link.Visible = true;
                if (Filename(openFileDialog1.FileName).Length < 21)
                {
                    Link.Text = Filename(openFileDialog1.FileName);
                }
                else
                    Link.Text = Filename(openFileDialog1.FileName).Remove(20, Filename(openFileDialog1.FileName).Length - 20) + ".....";
            }
        }

        public void DatalogOpen(string link)
        {
            try
            {
                System.Diagnostics.Process.Start(link);
            }
            catch (Exception mess)
            {
                MessageBox.Show("ERROR " + mess.ToString());
            }
        }

        private void First_verif_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(dlog1);
        }
        private void SecondDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(dlog2);
        }
        private void ThirdDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(dlog3);
        }
        private void FourthDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(dlog4);
        }


        private void ADD_Load(object sender, EventArgs e)
        {
            try
            {
                Commands(10);
                command.Connection = Connection.connect;
                Connection.OpenConnection();
                MySqlDataReader Read_data = command.ExecuteReader();

                while (Read_data.Read())
                {
                    Tester_platform.Items.Add(Read_data.GetString("TESTER_PLATFORM"));
                }
                Connection.CloseConnection();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
            if (Device_option == 2)
            {
                PRODUCT_OWNER.Text = "NOT APPLICABLE";
            }
            USERNAME.Text = UserName;
        }
    }
}
