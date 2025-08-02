using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace PROJECT
{
    public partial class BOARD_DETAILS : System.Windows.Forms.Form
    {
        MySqlCommand command;
        long FileSize;
        byte[] Data;
        public string DATALOG;
        public int Endorsement_number { get; set; }
        public string DLOG1 ,DLOG2 ,DLOG3 ,DLOG4, OPEN_COUNT,CLOSED_COUNT,STATUS_OPTION,DATE_ENCOUNTER,DATE_DIFFERENCE,FileName;
        public string UserName { get; set; }
        public string Approver { get; set; }
        private DateTime Date = new DateTime();
        private DateTime Dispo_Date = new DateTime();
        private DateTime Date_Approved = new DateTime();

        public BOARD_DETAILS(string number,String User,string Approver_access)
        {
            InitializeComponent();
            Endorsement_number = Convert.ToInt32(number);
            UserName = User;
            Approver = Approver_access;
        }

        private string Filename(string filename)
        {
            FileName = new FileInfo(filename).Name;
            return FileName;
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

        private void LoadData()
        {
            try
            {
                Commands(0);
                command.Connection = Connection.connect;
                Connection.OpenConnection();

                MySqlDataReader read_data = command.ExecuteReader();
                read_data.Read();

                PART_NAME.Text = read_data["PART_NAME"].ToString();
                LOT_ID.Text = read_data["LOT_ID"].ToString();
                VSPEC.Text = read_data["VSPEC"].ToString();
                TEST_STEP.Text = read_data["TEST_STEP"].ToString();
                TESTER_ID.Text = read_data["TESTER_ID"].ToString();
                HANDLER_ID.Text = read_data["HANDLER_ID"].ToString();
                BOARD_ID.Text = read_data["BOARD_ID"].ToString();
                PROBLEM.Text = read_data["PROBLEM"].ToString();
                ACTION.Text = read_data["ACTION"].ToString();
                BIN_NUMBER.Text = read_data["BIN_NUMBER"].ToString();
                TEST_NUMBER.Text = read_data["TEST_NUMBER"].ToString();
                TEST_NAME.Text = read_data["TEST_NAME"].ToString();
                FAILURE_MODE.Text = read_data["FAILURE_MODE"].ToString();
                Date = Convert.ToDateTime(read_data["DATE_ENCOUNTERED"].ToString());
                USER_LOG.Text = read_data["USER"].ToString();
                STATUS.Text = read_data["STATUS"].ToString();
                ROOTCAUSE.Text = read_data["ROOTCAUSE"].ToString();
                PRODUCT_OWNER.Text = read_data["PRODUCT_OWNER"].ToString();
                DLOG1 = read_data["FILENAME_1"].ToString();
                DLOG2 = read_data["FILENAME_2"].ToString();
                DLOG3 = read_data["FILENAME_3"].ToString();
                DLOG4 = read_data["FILENAME_4"].ToString();
                
                FACTORY.Text = read_data["FACTORY"].ToString();
                SUB_FACTORY.Text = read_data["SUB_FACTORY"].ToString();
                PO_COMMENT.Text = read_data["PO_COMMENT"].ToString();
                Dispo_Date = Convert.ToDateTime(read_data["DISPO_DATE"].ToString());
                DISPO_USER.Text = read_data["DISPO_USER"].ToString();
                DISPO_DATE.Text = Dispo_Date.ToString("yyyy-MM-dd");
                APPROVER.Text = read_data["APPROVER"].ToString();
                Dispo_Date = Convert.ToDateTime(read_data["DATE_APPROVED"].ToString());
                DATE_APPROVED.Text = Date_Approved.ToString("yyyy-MM-dd");
                if (STATUS.Text == "CLOSED")
                {
                    PO_ROOTCAUSE.Visible = Rootcause_label.Visible = false;
                    PO_COMMENT.ReadOnly = true;
                    UPDATE.Visible = false;
                }
                else if (STATUS.Text == "FOR APPROVAL" && Approver.ToString() == "1")
                {
                    UPDATE.Text = "APPROVE";
                }
                else
                {
                    DISPO_DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    DISPO_USER.Text = UserName;
                    ADD_PROOF_FILE.Visible = true;
                }
                Connection.CloseConnection();

                DATE_VERIFIED.Text = Date.ToString("yyyy-MM-dd");
                Dlog(First_verif_link, DLOG1);
                Dlog(Second_dlog, DLOG2);
                Dlog(Third_dlog, DLOG3);
                Dlog(Fourth_dlog, DLOG4);
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
            }
        }

        private void Load_Boards(object sender, EventArgs e)
        {
            LoadData();
            try
            {

                Commands(2);

                command.Connection = Connection.connect;
                Connection.OpenConnection();
                MySqlDataReader read_data = command.ExecuteReader();

                read_data.Read();

                OPEN_COUNT = read_data[STATUS.Text].ToString();
                DATE_DIFFERENCE = read_data["DATE"].ToString();

                Connection.CloseConnection();

                OPEN.Text = "TOTAL TRANSACTION " + string.Format("({0})", OPEN_COUNT);

                if (STATUS.Text == "OPEN")
                {
                    if (Convert.ToInt32(DATE_DIFFERENCE) < 15)
                        ATTENTION.Text = "THIS ISSUE WAS FIRST ENCOUNTERED " + DATE_DIFFERENCE + " DAY/S AGO";
                    else
                        ATTENTION.Text = "THIS ISSUE IS ALREADY " + DATE_DIFFERENCE + " DAY/S OLD. SEEK ASSISTANCE TO PO TO FIX THE ISSUE";
                }
                else
                    ATTENTION.Text = "ISSUE WAS ALREADY FIXED";

                Commands(3);
                command.Connection = Connection.connect;
                Connection.OpenConnection();
                MySqlDataReader ReadData = command.ExecuteReader();

                while (ReadData.Read())
                {
                    Date = Convert.ToDateTime(ReadData["DATE_ENCOUNTERED"].ToString());
                    OTHER_TRANSACTION.Items.Add(new ListViewItem(new[] { DATE_ENCOUNTER = Date.ToString("yyyy-MM-dd"), ReadData.GetString("USER"), ReadData.GetString("ENDORSEMENT_NUMBER") }));
                }
                Connection.CloseConnection();

            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
        }

        private void VIEW_Click(object sender, EventArgs e)
        {
            if (OTHER_TRANSACTION.SelectedItems.Count > 0)
            {
                Endorsement_number = Convert.ToInt32(OTHER_TRANSACTION.SelectedItems[0].SubItems[2].Text);
                LoadData();
            }
            else
                MessageBox.Show("SELECT ITEM FIRST");
        }

        private void Dlog(LinkLabel DlogLink,string DlogName)
        {
            if (string.IsNullOrEmpty(DlogName)) return;
            if (DlogName.Length < 20) DlogLink.Text = DlogName;
            else DlogLink.Text = DlogName.Remove(20, DlogName.Length - 20) + ".....";
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PO_COMMENT.Text) || string.IsNullOrWhiteSpace(PO_ROOTCAUSE.Text))
                MessageBox.Show("PLEASE PROVIDE DETAILS");
            else
            {
                DialogResult yes_no = MessageBox.Show(("DOUBLE CHECK YOUR DATA. SAVE IT?"), "ATTENTION", MessageBoxButtons.YesNo);
                switch(yes_no)
                {
                    case DialogResult.Yes:
                        DialogResult yes_or_no = MessageBox.Show(("DO YOU WANT TO UPDATE ALSO THE OTHER TRANSACTIONS MADE WITH THE SAME ISSUE?"), "ATTENTION", MessageBoxButtons.YesNo);
                        switch (yes_or_no)
                        {
                            case DialogResult.Yes:
                                try
                                {
                                    for (int count = 0; count < OTHER_TRANSACTION.Items.Count; count++)
                                    {
                                        Endorsement_number = Convert.ToInt32(OTHER_TRANSACTION.Items[count].SubItems[2].Text);

                                        Commands(4);
                                        command.Connection = Connection.connect;
                                        if (Connection.OpenConnection())
                                        {
                                            command.ExecuteNonQuery();
                                        }
                                        Connection.CloseConnection();
                                    }
                                    MessageBox.Show("UPDATED SUCCESSFULLY, PLEASE REFRESH DATA");
                                    this.Hide();
                                }
                                catch (Exception Error)
                                {
                                    MessageBox.Show(Error.ToString());
                                    Connection.CloseConnection();
                                }
                                break;
                            case DialogResult.No:
                                try
                                {
                                    Commands(4);
                                    command.Connection = Connection.connect;
                                    if (Connection.OpenConnection())
                                    {
                                        command.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("UPDATED SUCCESSFULLY");
                                    Connection.CloseConnection();
                                }
                                catch (Exception Error)
                                {
                                    MessageBox.Show(Error.ToString());
                                    Connection.CloseConnection();
                                }
                                break;
                        }
                        break;
                    case DialogResult.No:
                        return;
                }
            }
        }

        private void ADD_PROOF_FILE_Click(object sender, EventArgs e)
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
                FIXED_PROOF_FILE.Visible = true;
                if (Filename(openFileDialog1.FileName).Length < 21)
                {
                    FIXED_PROOF_FILE.Text = Filename(openFileDialog1.FileName);
                }
                else
                    FIXED_PROOF_FILE.Text = Filename(openFileDialog1.FileName).Remove(20, Filename(openFileDialog1.FileName).Length - 20) + ".....";
            }
        }

        private void Commands(int pick)
        {
            switch (pick)
            {
                case 0: // LOAD ALL TRANSACTION DETAILS
                    command = new MySqlCommand("SELECT * FROM `hit`.`details` WHERE (`ENDORSEMENT_NUMBER` = '" + Endorsement_number + "')");
                    break;
                case 1: // OPEN DATALOG
                    command = new MySqlCommand(String.Format("SELECT `{0}` FROM `hit`.`details` WHERE (`ENDORSEMENT_NUMBER` = '" + Endorsement_number + "')",DATALOG));
                    break;
                case 2: // LOAD TRANSACTION COUNTS WITH SAME ISSUE
                    command = new MySqlCommand(string.Format("use `hit`; select (select count(*) from `details` where `BIN_NUMBER` = '{0}' AND `TEST_NUMBER` = '{1}' AND `PRODUCT_OWNER` = '{2}' AND `STATUS` = '{3}') AS `{3}`," +
                            "(select datediff(curdate(),`DATE_ENCOUNTERED`) from `details` where `ENDORSEMENT_NUMBER` = (SELECT min(`ENDORSEMENT_NUMBER`) from `details` " +
                            "where `BIN_NUMBER` = '{0}' AND `TEST_NUMBER` = '{1}' AND `PRODUCT_OWNER` = '{2}' AND `STATUS` = '{3}')) as `DATE`", 
                            BIN_NUMBER.Text,TEST_NUMBER.Text,PRODUCT_OWNER.Text,STATUS.Text));
                    break;
                case 3: // LOAD OTHER TRANSACTIONS WITH THE SAME FAILURE
                    command = new MySqlCommand(string.Format("SELECT `DATE_ENCOUNTERED`,`USER`,`ENDORSEMENT_NUMBER` FROM `hit`.`details`" +
                            "where (`BIN_NUMBER` = '{0}' AND `TEST_NUMBER` = '{1}' AND `PRODUCT_OWNER` = '{2}' AND `STATUS` = '{3}')",
                            BIN_NUMBER.Text,TEST_NUMBER.Text,PRODUCT_OWNER.Text,STATUS.Text));
                    break;
                case 4:  // UPDATE ROOTCASE
                    command = new MySqlCommand(string.Format("UPDATE `hit`.`details` SET `PO_COMMENT` = '{0}',`ROOTCAUSE` = '{1}',`DISPO_DATE` = '{2}',`DISPO_USER` = '{3}',`DLOG_PROOF` = @{4},`DLOG_PROOF_NAME` = '{5}'," +
                            "`STATUS` = 'FOR APPROVAL' WHERE (`ENDORSEMENT_NUMBER` = '{6}')",
                            PO_COMMENT.Text,PO_ROOTCAUSE.Text,DISPO_DATE.Text,DISPO_USER.Text, DATALOG, Filename(openFileDialog1.FileName),Endorsement_number));
                            command.Parameters.Add("@DLOG_PROOF", MySqlDbType.LongBlob).Value = SaveFile(openFileDialog1.FileName);
                    break;
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void DatalogOpen(string link, string SQL_COLUMN_NAME)
        {
            DATALOG = SQL_COLUMN_NAME;
            Commands(1);
            command.Connection = Connection.connect;

            try
            {
                Connection.OpenConnection();

                MySqlDataReader read_data = command.ExecuteReader();
                read_data.Read();

                Data = (byte[])read_data[SQL_COLUMN_NAME];
                Connection.CloseConnection();

                string DatalogFile = string.Format("C:\\Users\\{0}\\Desktop\\{1}", Environment.UserName, link);
                File.WriteAllBytes(DatalogFile, Data);
                System.Diagnostics.Process.Start(DatalogFile);
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
        }

        private void OPEN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            STATUS_OPTION = "OPEN";

            Commands(3);

            command.Connection = Connection.connect;

            try
            {
                Connection.OpenConnection();
                MySqlDataReader ReadData = command.ExecuteReader();

                while (ReadData.Read())
                {
                    Date = Convert.ToDateTime(ReadData["DATE_ENCOUNTERED"].ToString());
                    OTHER_TRANSACTION.Items.Add(new ListViewItem(new[] { DATE_ENCOUNTER = Date.ToString("yyyy-MM-dd"), ReadData.GetString("USER"), ReadData.GetString("ENDORSEMENT_NUMBER") }));
                }
                Connection.CloseConnection();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
        }

        private void First_verif_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(DLOG1, "FIRST_DATALOG");
        }

        private void ThirdDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(DLOG2, "SECOND_DATALOG");
        }

        private void FourthDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(DLOG3, "THIRD_DATALOG");
        }

        private void FifthDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(DLOG4, "FOURTH_DATALOG");
        }
    }
}
