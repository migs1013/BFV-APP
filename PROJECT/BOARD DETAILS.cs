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
        public string other_failure_mode, other_failed_during;

        public BOARD_DETAILS(string number)
        {
            InitializeComponent();
            Endorsement_number = Convert.ToInt32(number);
        }

        private void Load_Boards(object sender, EventArgs e)
        {
            Commands(0);
            command.Connection = Connection.connect;

            if (Connection.OpenConnection())
            {
                MySqlDataReader read_data = command.ExecuteReader();
                read_data.Read();

                PART_NAME.Text = read_data["PART_NAME"].ToString();
                LOT_ID.Text = read_data["LOT_ID"].ToString();
                VSPEC.Text = read_data["VSPEC"].ToString();
                TEST_STEP.Text = read_data["TEST_STEP"].ToString();
                TESTER_ID.Text = read_data["TESTER_ID"].ToString();
                HANDLER_ID.Text = read_data["HANDLER_ID"].ToString();
                other_failure_mode = read_data["FAILURE_MODE_OTHERS"].ToString();
                BOARD_ID.Text = read_data["BOARD_ID"].ToString();
                PROBLEM.Text = read_data["PROBLEM"].ToString();
                ACTION.Text = read_data["ACTION"].ToString();
                BIN_NUMBER.Text = read_data["BIN_NUMBER"].ToString();
                TEST_NUMBER.Text = read_data["TEST_NUMBER"].ToString();
                DATE_ENCOUNTERED.Text = read_data["DATE_ENCOUNTERED"].ToString();
                USER.Text = read_data["USER"].ToString();
                First_verif_link.Text = read_data["FILENAME_1"].ToString();
                Third_dlog.Text = read_data["FILENAME_2"].ToString();
                Fourth_dlog.Text = read_data["FILENAME_3"].ToString();
                Fifth_dlog.Text = read_data["FILENAME_4"].ToString();
                Connection.CloseConnection();
                if (HANDLER_ID.Text == "OTHERS")
                {
                    HANDLER_ID.Text = other_failure_mode;
                }
            }
            else
                this.Close();

        }

        private void Commands(int pick)
        {
            switch (pick)
            {
                case 0:
                    command = new MySqlCommand("SELECT `ENDORSEMENT_NUMBER`,`PART_NAME`,`LOT_ID`,`VSPEC`,`TEST_STEP`,`TESTER_ID`,`HANDLER_ID`," +
                            "`FAILURE_MODE`,`FAILURE_MODE_OTHERS`,`BOARD_ID`,`BIN_NUMBER`,`TEST_NUMBER`,`TEST_NAME`,`PRODUCT_OWNER`,`FIRST_DATALOG`,`SECOND_DATALOG`,`THIRD_DATALOG`," +
                            "`FOURTH_DATALOG`,`DATE_ENCOUNTERED`,`USER`,`PROBLEM`,`ACTION`,`FILENAME_1`,`FILENAME_2`,`FILENAME_3`,`FILENAME_4`" +
                            " FROM `hit`.`details` WHERE (`ENDORSEMENT_NUMBER` = '" + Endorsement_number + "')");
                    break;
                case 1:
                    command = new MySqlCommand(String.Format("SELECT `{0}` FROM `hit`.`details` WHERE (`ENDORSEMENT_NUMBER` = '" + Endorsement_number + "')",DATALOG));
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

            if (Connection.OpenConnection())
            {
                MySqlDataReader read_data = command.ExecuteReader();
                read_data.Read();

                Data = (byte[])read_data[SQL_COLUMN_NAME];
                Connection.CloseConnection();
            }
            string DatalogFile = string.Format("C:\\Users\\{0}\\Desktop\\{1}", Environment.UserName, link);
            File.WriteAllBytes(DatalogFile, Data);
            System.Diagnostics.Process.Start(DatalogFile);
        }

        private void First_verif_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(First_verif_link.Text, "FIRST_DATALOG");
        }

        private void ThirdDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(Third_dlog.Text, "SECOND_DATALOG");
        }

        private void FourthDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(Fourth_dlog.Text, "THIRD_DATALOG");
        }

        private void FifthDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatalogOpen(Fifth_dlog.Text, "FOURTH_DATALOG");
        }
    }
}
