using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using static System.Windows.Forms.LinkLabel;

namespace PROJECT
{
    public partial class BOARD_DETAILS : System.Windows.Forms.Form
    {
        MySqlCommand command;
        long FileSize;
        byte[] Data;
        public string DATALOG,PROOF_FILE_LINK;
        public int Endorsement_number { get; set; }
        public static string DLOG1 ,DLOG2 ,DLOG3 ,DLOG4, OPEN_COUNT,CLOSED_COUNT,STATUS_OPTION,DATE_ENCOUNTER,DATE_DIFFERENCE,Add_File_Proof,New_File_Link,approver,rootcause_comment,dispo,body,subject;
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
            Add_File_Proof = new FileInfo(filename).Name;
            return Add_File_Proof;
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
                TEST_STAGE.Text = read_data["TEST_STAGE"].ToString();
                TESTER_ID.Text = read_data["TESTER_ID"].ToString();
                HANDLER_ID.Text = read_data["HANDLER_ID"].ToString();
                BOARD_ID.Text = read_data["BOARD_ID"].ToString();
                PROBLEM.Text = read_data["PROBLEM"].ToString();
                ACTION.Text = read_data["ACTION"].ToString();
                BIN_NUMBER.Text = read_data["BIN_NUMBER"].ToString();
                TEST_NUMBER.Text = read_data["TEST_NUMBER"].ToString();
                TEST_NAME.Text = read_data["TEST_NAME"].ToString();
                FAILURE_MODE.Text = read_data["FAILURE_MODE"].ToString();
                FAILURE_PERFORMANCE.Text = read_data["FAILURE_PERFORMANCE"].ToString();
                Date = Convert.ToDateTime(read_data["DATE_ENCOUNTERED"].ToString());
                USER_LOG.Text = read_data["USER"].ToString();
                STATUS.Text = read_data["STATUS"].ToString();
                ROOTCAUSE.Text = read_data["POTENTIAL_ROOTCAUSE"].ToString();
                PRODUCT_OWNER.Text = read_data["PRODUCT_OWNER"].ToString();
                DLOG1 = read_data["FILENAME_1"].ToString();
                DLOG2 = read_data["FILENAME_2"].ToString();
                DLOG3 = read_data["FILENAME_3"].ToString();
                DLOG4 = read_data["FILENAME_4"].ToString();
                
                FACTORY.Text = read_data["FACTORY"].ToString();
                SUB_FACTORY.Text = read_data["SUB_FACTORY"].ToString();
                BU_STRAT.Text = read_data["BU_STRAT"].ToString();
                
                if (STATUS.Text == "VALID")
                {
                    PO_COMMENT.Text = read_data["PO_COMMENT"].ToString();
                    Dispo_Date = Convert.ToDateTime(read_data["DISPO_DATE"].ToString());
                    DISPO_USER.Text = read_data["DISPO_USER"].ToString();
                    APPROVER.Text = read_data["APPROVER"].ToString();
                    Date_Approved = Convert.ToDateTime(read_data["DATE_APPROVED"].ToString());
                    FIXED_PROOF_FILE.Text = read_data["DLOG_PROOF_NAME"].ToString();
                    DISPO_DATE.Text = Dispo_Date.ToString("yyyy-MM-dd");
                    DATE_APPROVED.Text = Date_Approved.ToString("yyyy-MM-dd");
                    CLOSE.Visible = DATE_TEXT.Visible = APPROVE_TEXT.Visible = DATE2_TEXT.Visible = DISPO_USER.Visible = DISPO_DATE.Visible = APPROVER.Visible = DATE_APPROVED.Visible = true;
                    PO_ROOTCAUSE.Visible = Rootcause_label.Visible = false;
                    PO_COMMENT.ReadOnly = true;
                    UPDATE.Visible = false;

                    if (FIXED_PROOF_FILE.Text.Length > 21)
                    {
                        FIXED_PROOF_FILE.Text = FIXED_PROOF_FILE.Text.Remove(15, FIXED_PROOF_FILE.Text.Length - 20) + ".....";
                    }

                }
                else if (STATUS.Text == "FOR APPROVAL")
                {
                    PO_COMMENT.Text = read_data["PO_COMMENT"].ToString();
                    Dispo_Date = Convert.ToDateTime(read_data["DISPO_DATE"].ToString());
                    DISPO_USER.Text = read_data["DISPO_USER"].ToString();
                    FIXED_PROOF_FILE.Text = read_data["DLOG_PROOF_NAME"].ToString();
                    DISPO_DATE.Text = Dispo_Date.ToString("yyyy-MM-dd");
                    CLOSE.Visible = DATE_TEXT.Visible = DISPO_USER.Visible = DISPO_DATE.Visible = true;
                    UPDATE.Text = "APPROVE";
                    Rootcause_label.Visible = PO_ROOTCAUSE.Visible = false;
                    APPROVER.Text = UserName;
                    DATE_APPROVED.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    PO_COMMENT.ReadOnly = true;

                    if (FIXED_PROOF_FILE.Text.Length > 21)
                    {
                        FIXED_PROOF_FILE.Text = FIXED_PROOF_FILE.Text.Remove(15, FIXED_PROOF_FILE.Text.Length - 20) + ".....";
                    }

                    if (Approver == "0")
                        UPDATE.Visible = false;

                }
                else
                {
                    ROOTCAUSE.Text += " (POTENTIAL)";
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

        private void Update_Email_send()
        {

            if (string.IsNullOrEmpty(PO_ROOTCAUSE.Text)) rootcause_comment = ROOTCAUSE.Text;
            else rootcause_comment = PO_ROOTCAUSE.Text;

            if (PO_COMMENT.Text == "PLEASE REFER TO DISPOSITION")
                dispo = ACTION.Text;
            else
                dispo = PO_COMMENT.Text;

            if (UPDATE.Text == "APPROVE")
            {
                approver = "<b>----------------------------------------APPROVAL UPDATE----------------------------------------------------</b><br><br>" +
                    "<b>FAILURE ASSESSMENT:</b> VALID<br><br>" +
                    "<b>REVIEWED AND APPROVED BY:</b> " + APPROVER.Text + "<br><br>" +
                    "<b>DATE:</b> " + DATE_APPROVED.Text + "<br><br>";

                subject = string.Join(" | ", "FAILURE ASSESSMENT APPROVED", LOT_ID.Text, TEST_STAGE.Text, FAILURE_MODE.Text, "BIN " + BIN_NUMBER.Text + " TP#" + TEST_NUMBER.Text + " " + TEST_NAME.Text);

            }
            else
            {
                approver = "";
                subject = string.Join(" | ", "FOR APPROVAL", LOT_ID.Text, TEST_STAGE.Text, FAILURE_MODE.Text, "BIN " + BIN_NUMBER.Text + " TP#" + TEST_NUMBER.Text + " " + TEST_NAME.Text);

            }

            body = String.Format(@"(THIS IS A SYSTEM GENERATED EMAIL. DO NOT REPLY TO THIS EMAIL. PLEASE CONTACT JOHN MICHAEL SO FOR ANY CONCERN).<br><br>

<b>----------------------------------------PROBLEM ENCOUNTERED----------------------------------------------------</b><br><br>

<b>PARTNAME:</b> {0}<br><br>

<b>TESTER:</b> {1}    <b>HANDLER:</b> {2}<br><br>

<b>BOARD ID:</b> {3}<br><br>

<b>FAILURE MODE:</b> {4}<br><br>

<b>FAILURE PERFORMANCE:</b> {5}<br><br>

<b>PROBLEM DESCRIPTION:</b> 
{6}<br><br>

<b>LOGGED BY:</b> {7}<br><br>

<b>DATE:</b> {8}<br><br>

<b>----------------------------------------VERIFICATION UPDATE----------------------------------------------------</b><br><br>

<b>DISPOSITION:</b> 
{9}<br><br>

<b>POTENTIAL ROOTCAUSE:</b> {10}<br><br>

<b>FAILURE ASSESSMENT:</b> VALID (FOR APPROVAL)<br><br>

<b>UPDATED/VERIFIED BY:</b> {11}<br><br>

<b>DATE:</b> {12}<br><br>

{13}

(THIS IS A SYSTEM GENERATED EMAIL. DO NOT REPLY TO THIS EMAIL. PLEASE CONTACT JOHN MICHAEL SO FOR ANY CONCERN).",
PART_NAME.Text, TESTER_ID.Text, HANDLER_ID.Text, BOARD_ID.Text, FAILURE_MODE.Text, FAILURE_PERFORMANCE.Text,
PROBLEM.Text, UserName, DATE_VERIFIED.Text, dispo, rootcause_comment, DISPO_USER.Text, DISPO_DATE.Text, approver);

            if (UPDATE.Text == "APPROVE")
            {

                SavingWindow save = new SavingWindow(2,SUB_FACTORY.Text,BU_STRAT.Text);
                save.ShowDialog();
            }
            else
            {

                SavingWindow save = new SavingWindow(3, SUB_FACTORY.Text,BU_STRAT.Text);
                save.ShowDialog();
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

                if (STATUS.Text != "VALID")
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
                    OTHER_TRANSACTION.Items.Add(new ListViewItem(new[] { DATE_ENCOUNTER = Date.ToString("yyyy-MM-dd"), ReadData["USER"].ToString(), ReadData["ENDORSEMENT_NUMBER"].ToString() }));
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
            if (UPDATE.Text == "APPROVE")
            {
                DialogResult yes_no = MessageBox.Show("APPROVE DISPOSITION?","ATTENTION!", MessageBoxButtons.YesNo);
                switch(yes_no)
                {
                    case DialogResult.Yes:
                        try
                        {
                            Commands(5);
                            command.Connection = Connection.connect;
                            if (Connection.OpenConnection())
                            {
                                command.ExecuteNonQuery();
                            }
                            Connection.CloseConnection();
                            Update_Email_send();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.ToString());
                            Connection.CloseConnection();
                            this.Close();
                        }
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else if (string.IsNullOrWhiteSpace(PO_COMMENT.Text) || string.IsNullOrWhiteSpace(PO_ROOTCAUSE.Text) || string.IsNullOrWhiteSpace(FIXED_PROOF_FILE.Text))
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
                                    Update_Email_send();
                                }
                                catch (Exception Error)
                                {
                                    MessageBox.Show(Error.ToString());
                                    Connection.CloseConnection();
                                    this.Close();
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
                                    Connection.CloseConnection();
                                    Update_Email_send();
                                }
                                catch (Exception Error)
                                {
                                    MessageBox.Show(Error.ToString());
                                    Connection.CloseConnection();
                                    this.Close();
                                }
                                break;
                        }
                        break;
                    case DialogResult.No:
                        return;
                }
            }
        }

        private void FIXED_PROOF_FILE_Click(object sender, EventArgs e)
        {
            DatalogOpen("DLOG_PROOF_NAME", "DLOG_PROOF");
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
                New_File_Link = openFileDialog1.FileName;
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
                    command = new MySqlCommand(string.Format("UPDATE `hit`.`details` SET `PO_COMMENT` = '{0}',`POTENTIAL_ROOTCAUSE` = '{1}',`DISPO_DATE` = '{2}',`DISPO_USER` = '{3}',`DLOG_PROOF` = @{4},`DLOG_PROOF_NAME` = '{5}'," +
                            "`STATUS` = 'FOR APPROVAL' WHERE (`ENDORSEMENT_NUMBER` = '{6}')",
                            PO_COMMENT.Text,PO_ROOTCAUSE.Text,DISPO_DATE.Text,DISPO_USER.Text,PROOF_FILE_LINK = "FILE",Filename(New_File_Link),Endorsement_number));
                    command.Parameters.Add(string.Format("@{0}", PROOF_FILE_LINK), MySqlDbType.LongBlob).Value = SaveFile(New_File_Link);
                    break;
                case 5:  // APPROVE ROOTCAUSE ISSUE
                    command = new MySqlCommand("UPDATE `hit`.`details` SET `STATUS` = 'VALID',`APPROVER` = '" + APPROVER.Text + "',`DATE_APPROVED` = '" + DATE_APPROVED.Text + "' where `ENDORSEMENT_NUMBER` = '" + Endorsement_number + "'");
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
                    OTHER_TRANSACTION.Items.Add(new ListViewItem(new[] { DATE_ENCOUNTER = Date.ToString("yyyy-MM-dd"), ReadData["USER"].ToString(), ReadData["ENDORSEMENT_NUMBER"].ToString() }));
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
