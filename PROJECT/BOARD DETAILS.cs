using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PROJECT
{
    public partial class BOARD_DETAILS : Form
    {
        MySqlCommand command;
        byte[] Data;
        public string DATALOG;
        public int Endorsement_number { get; set; }
        public string DLOG1 ,DLOG2 ,DLOG3 ,DLOG4, OPEN_COUNT,CLOSED_COUNT,STATUS_OPTION,DATE_ENCOUNTER,DATE_DIFFERENCE;
        public string UserName { get; set; }
        private DateTime Date = new DateTime();
        private DateTime Dispo_Date = new DateTime();

        public BOARD_DETAILS(string number,String User)
        {
            InitializeComponent();
            Endorsement_number = Convert.ToInt32(number);
            UserName = User;
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
                if (STATUS.Text == "CLOSED")
                {
                    PO_COMMENT.Text = read_data["PO_COMMENT"].ToString();
                    Dispo_Date = Convert.ToDateTime(read_data["DISPO_DATE"].ToString());
                    DISPO_USER.Text = read_data["DISPO_USER"].ToString();
                    DISPO_DATE.Text = Dispo_Date.ToString("yyyy-MM-dd");
                    PO_ROOTCAUSE.Visible = Rootcause_label.Visible = false;
                    PO_COMMENT.ReadOnly = true;
                }
                else
                {
                    DISPO_DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    DISPO_USER.Text = UserName;
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
                if (ROOTCAUSE.Text == "UNDER INVESTIGATION") ALL_TRANSACTION.Visible = UPDATE.Visible = true;

                if (OTHER_TRANSACTION.Items.Count == 1) ALL_TRANSACTION.Visible = false;
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
                        if (ALL_TRANSACTION.Checked == true)
                        {
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
                        }
                        else
                        {
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
                        }
                        break;
                    case DialogResult.No:
                        return;
                }
            }
        }

        private void Commands(int pick)
        {
            switch (pick)
            {
                case 0:
                    command = new MySqlCommand("SELECT `ENDORSEMENT_NUMBER`,`PART_NAME`,`LOT_ID`,`VSPEC`,`TEST_STEP`,`TESTER_ID`,`HANDLER_ID`," +
                            "`FAILURE_MODE`,`BOARD_ID`,`BIN_NUMBER`,`TEST_NUMBER`,`PRODUCT_OWNER`,`FIRST_DATALOG`,`SECOND_DATALOG`,`THIRD_DATALOG`," +
                            "`FOURTH_DATALOG`,`DATE_ENCOUNTERED`,`USER`,`PROBLEM`,`ACTION`,`FILENAME_1`,`FILENAME_2`,`FILENAME_3`,`FILENAME_4`,`STATUS`,`ROOTCAUSE`," +
                            "`PO_COMMENT`,`DISPO_DATE`,`DISPO_USER` FROM `hit`.`details` WHERE (`ENDORSEMENT_NUMBER` = '" + Endorsement_number + "')");
                    break;
                case 1:
                    command = new MySqlCommand(String.Format("SELECT `{0}` FROM `hit`.`details` WHERE (`ENDORSEMENT_NUMBER` = '" + Endorsement_number + "')",DATALOG));
                    break;
                case 2:
                    command = new MySqlCommand(string.Format("use `hit`; select (select count(*) from `details` where `BIN_NUMBER` = '{0}' AND `TEST_NUMBER` = '{1}' AND `PRODUCT_OWNER` = '{2}' AND `STATUS` = '{3}') AS `{3}`," +
                            "(select datediff(curdate(),`DATE_ENCOUNTERED`) from `details` where `ENDORSEMENT_NUMBER` = (SELECT max(`ENDORSEMENT_NUMBER`) from `details` " +
                            "where `BIN_NUMBER` = '{0}' AND `TEST_NUMBER` = '{1}' AND `PRODUCT_OWNER` = '{2}' AND `STATUS` = '{3}')) as `DATE`", 
                            BIN_NUMBER.Text,TEST_NUMBER.Text,PRODUCT_OWNER.Text,STATUS.Text));
                    break;
                case 3:
                    command = new MySqlCommand(string.Format("SELECT `DATE_ENCOUNTERED`,`USER`,`ENDORSEMENT_NUMBER` FROM `hit`.`details`" +
                            "where (`BIN_NUMBER` = '{0}' AND `TEST_NUMBER` = '{1}' AND `PRODUCT_OWNER` = '{2}' AND `STATUS` = '{3}')",
                            BIN_NUMBER.Text,TEST_NUMBER.Text,PRODUCT_OWNER.Text,STATUS.Text));
                    break;
                case 4:
                    command = new MySqlCommand(string.Format("UPDATE `hit`.`details` SET `PO_COMMENT` = '{0}',`ROOTCAUSE` = '{1}',`DISPO_DATE` = '{2}',`DISPO_USER` = '{3}'," +
                            "`STATUS` = 'CLOSED' WHERE (`ENDORSEMENT_NUMBER` = '{4}')",
                            PO_COMMENT.Text,PO_ROOTCAUSE.Text,DISPO_DATE.Text,DISPO_USER.Text,Endorsement_number));
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
