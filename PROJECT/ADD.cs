using System;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;


namespace PROJECT
{
    public partial class ADD : Form
    {
        MySqlCommand command;
        long FileSize;
        byte[] Data;
        public string tester_platform, FileName, database, DATALOG, Dataloglink, UpdateData, FileNameNumber, WordCheck, hostname, dlog1 = "", dlog2 = "", dlog3 = "", dlog4 = "";
        public int Endorsement_Number,FileNameLength;
        public string UserName { get; set; }
        public int Load_number { get; set; }
        public DateTime WriteTime = new DateTime();
        public ADD(int Load,string User)
        {
            InitializeComponent();
            Load_number = Load;
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
            else if (DatalogNumber == 3)
            {
                DATALOG = "SECOND_DATALOG";
                UpdateData = "SECOND_DATA";
                FileNameNumber = "FILENAME_2";
                Dataloglink = dlog2;
            }
            else if (DatalogNumber == 4)
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
            }
        }
        private void Save_btn_Click(object sender, EventArgs e)
        {
            DialogResult yes_no = MessageBox.Show(("PLEASE DOUBLE CHECK YOUR DATA,THIS WILL BE SAVE PERMANENTLY. SAVE IT?"), "ATTENTION", MessageBoxButtons.YesNo);
            switch (yes_no)
            {
                case DialogResult.Yes:
                    SendData(6);
                    Commands(1);
                    command.Connection = Connection.connect;
                    if (Connection.OpenConnection())
                    {
                        MySqlDataReader read_status = command.ExecuteReader();
                        read_status.Read();

                        Endorsement_Number = Convert.ToInt32(read_status["ENDORSEMENT_NUMBER"].ToString());
                    }
                    Connection.CloseConnection();
                    if (dlog1.Contains("\\"))
                    {
                        DatalogNumber(1); SendData(5);
                    }
                    if (dlog2.Contains("\\"))
                    {
                        DatalogNumber(3); SendData(5);
                    }
                    if (dlog3.Contains("\\"))
                    {
                        DatalogNumber(4); SendData(5);
                    }
                    if (dlog4.Contains("\\"))
                    {
                        DatalogNumber(5); SendData(5);
                    }
                    MessageBox.Show("FILE SAVED SUCCESSFULLY");
                    Clear_all();
                    Save_btn.Visible = false;
                    PART_NAME.Visible = true;
                    PART_NAME.Clear();
                    LOT_ID.Clear();
                    PART_NAME.Focus();
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
                case 2:
                    command = new MySqlCommand(string.Format("SELECT `TESTER`,`TESTER_PLATFORM` FROM `hit`.`hostnames` where `HOSTNAME` = '{0}'",hostname));
                    break;
                case 3:  //NOT USED
                    break;
                case 4:  //NOT USED
                    break;
                case 5: // INSERT DATALOG
                    command = new MySqlCommand(string.Format("UPDATE `hit`.`details` SET `{0}` = @{1},`{2}` = '{3}'" +
                        "WHERE (`ENDORSEMENT_NUMBER` = '" + Endorsement_Number + "')", DATALOG, UpdateData, FileNameNumber, Filename(Dataloglink)));
                    command.Parameters.Add(string.Format("@{0}", UpdateData), MySqlDbType.LongBlob).Value = SaveFile(Dataloglink);
                    break;
                case 6: // INSERT NEW TRANSACTION
                    command = new MySqlCommand("INSERT INTO `hit`.`details` " +
                        "(`PART_NAME`,`LOT_ID`,`VSPEC`,`TEST_STEP`,`TEST_SYSTEM`,`TESTER_ID`,`HANDLER_ID`,`FAILURE_MODE`,`FAILURE_MODE_OTHERS`,`BOARD_ID`," +
                        "`BIN_NUMBER`,`TEST_NUMBER`,`TEST_NAME`,`PRODUCT_OWNER`,`DATE_ENCOUNTERED`,`USER`,`PROBLEM`,`ACTION`) " +
                        "VALUES ('" + PART_NAME.Text + "', '" + LOT_ID.Text + "','" + VSPEC.Text + "','" + TEST_STEP.Text + "','" + Test_system.Text + "'," +
                        "'" + TESTER_ID.Text + "','" + HANDLER_ID.Text + "','" + Failure_mode.Text + "','" + Failure_mode_others.Text + "','" + BOARD_ID.Text + "','" + BIN_NUMBER.Text + "'," +
                        "'" + TEST_NUMBER.Text + "','" + TEST_NAME.Text + "','" + PRODUCT_OWNER.Text + "','" + WriteTime.ToString("yyyy-MM-dd") + "','" + UserName + "','" + Problem.Text + "','" + Action.Text + "')");
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
                    if (textBox == Failure_mode_others || textBox == Problem)
                        continue;
                    else
                    {
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            Error();
                            return false;
                        }
                        else if (textBox.Text.Length > 20)
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
                    if (comboBox.SelectedIndex == -1)
                    {
                        Error();
                        return false;
                    }
                    else if (comboBox == Failure_mode)
                    {
                        if (Failure_mode.SelectedIndex == 8)
                        {
                            if (string.IsNullOrWhiteSpace(Failure_mode_others.Text))
                            {
                                Error();
                                return false;
                            }
                            else if (Failure_mode_others.Text.Length > 40)
                            {
                                MessageBox.Show("TOO LONG INPUT!");
                                return false;
                            }
                            else continue;
                        }
                    }
                }
                else continue;
            }
            if (first_verif_link.Text == string.Empty)
            {
                Error();
                return false;
            }
            return false;
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
                first_verif_link.Text = Filename(openFileDialog1.FileName).Remove(20, Filename(openFileDialog1.FileName).Length - 20) + ".....";
                dlog1 = openFileDialog1.FileName;
                WriteTime = System.IO.File.GetLastWriteTime(openFileDialog1.FileName);
                Date.Text = WriteTime.ToString("yyyy-MM-dd");
            }
        }
        private void Add_first_verif_Click(object sender, EventArgs e)
        {
            try
            {
                InsertDatalog(first_verif_link, FirstDate);
                
                WordCheck = Filename(dlog1).Replace("_", " ");

                string[] words = Regex.Split(WordCheck, @"\s+");

                LOT_ID.Text = words[0];
                PART_NAME.Text = words[1];
                TEST_STEP.Text = string.Join(" ", words[2], words[3], words[4], words[5], words[6]);
                VSPEC.Text = words[7];
                hostname = words[8];

                Commands(2);
                command.Connection = Connection.connect;
                Connection.OpenConnection();
                MySqlDataReader read_data = command.ExecuteReader();
                read_data.Read();
                TESTER_ID.Text = read_data.GetString("TESTER");
                Test_system.Text = read_data.GetString("TESTER_PLATFORM");
                Connection.CloseConnection();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool CheckTextBox(string textBox)                         // CHECK TEXTBOX INPUTS
        {
            char[] text = textBox.ToCharArray();
            if (textBox.Length > 40)
            {
                MessageBox.Show("MAXIMUM OF 40 CHARACTERS ONLY");
                return false;
            }
            for (int Txt = 0; Txt < textBox.Length; Txt++)
            {
                if (char.IsLetterOrDigit(text[Txt])) continue;
                else if (text[Txt] == '-') continue;
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

        private void Clear_all()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox == PART_NAME || textBox == LOT_ID)
                    {
                        continue;
                    }
                    else
                    {
                        textBox.Visible = false;
                        textBox.Clear();
                    }
                }
                else if (c is LinkLabel)
                {
                    LinkLabel DlogLink = c as LinkLabel;
                    DlogLink.Text = null;
                }
                else if (c is ComboBox)
                {
                    ComboBox comboBox = c as ComboBox;
                    comboBox.Visible = false;
                    comboBox.SelectedIndex = -1;
                }
                else if (c is GroupBox)
                {
                    GroupBox groupBox = c as GroupBox;
                    foreach (Control b in groupBox.Controls)
                    {
                        if (b is LinkLabel)
                        {
                            LinkLabel link = b as LinkLabel;
                            link.Text = null;
                        }
                        else if (b is ComboBox)
                        {
                            ComboBox comboBox = b as ComboBox;
                            comboBox.SelectedIndex = -1;
                        }
                        else if (b is DateTimePicker)
                        {
                            DateTimePicker dateTime = b as DateTimePicker;
                            dateTime.ResetText();
                        }
                        else if (b is TextBox)
                        {
                            TextBox textBox = b as TextBox;
                            textBox.Clear();
                        }
                        else if (b is Label)
                        {
                            Label label = b as Label;
                            if (label == FirstDate)
                            {
                                label.Text = " ";
                            }
                        }
                        else continue;
                    }
                    groupBox.Visible = false;
                }
                else if (c is Label)
                {
                    Label label = c as Label;
                    if (label == label_serial || label == label_PartNumber)
                        label.Enabled = true;
                    else label.Visible = false;
                }
            }
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
                Link.Text = Filename(openFileDialog1.FileName).Remove(20, Filename(openFileDialog1.FileName).Length - 20) + ".....";
            }
        }

        private void ADD_SECOND_DLOG(object sender, EventArgs e)
        {
            OtherDatalog(SECOND_DLOG);
            dlog2 = openFileDialog1.FileName;
        }
        private void ADD_THIRD_DLOG(object sender, EventArgs e)
        {
            OtherDatalog(THIRD_DLOG);
            dlog3 = openFileDialog1.FileName;
        }
        private void ADD_FOURTH_DLOG(object sender, EventArgs e)
        {
            OtherDatalog(FOURTH_DLOG);
            dlog4 = openFileDialog1.FileName;
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
            USERNAME.Text = UserName;
        }
    }
}
