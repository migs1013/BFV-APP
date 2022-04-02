using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PROJECT
{
    public partial class BOARD_DETAILS : Form
    {
        MySqlCommand command;
        byte[] Data1,Data2;
        string DayCount,Second;
        public string FileName1, Filename2;
        int DAY;
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

                Serial_number.Text = read_data["SERIAL NUMBER"].ToString();
                Part_number.Text = read_data["PART NUMBER"].ToString();
                Board.Text = read_data["BOARD"].ToString();
                Revision.Text = read_data["REVISION"].ToString();
                Board.Text = read_data["BOARD"].ToString();
                Test_program.Text = read_data["TEST PROGRAM"].ToString();
                Failed_during.Text = read_data["FAILED DURING"].ToString();
                other_failed_during = read_data["FAILED DURING OTHERS"].ToString();
                Failure_mode.Text = read_data["FAILURE MODE"].ToString();
                other_failure_mode = read_data["FAILURE MODE OTHERS"].ToString();
                Test_option.Text = read_data["TEST OPTION"].ToString();
                Remarks.Text = read_data["REMARKS"].ToString();
                Status.Text = read_data["STATUS"].ToString();
                Data1 = (byte[])read_data["FIRST DATALOG"];
                First_date.Text = read_data["FIRST DATE"].ToString();
                First_tester.Text = read_data["FIRST TESTER"].ToString();
                First_site.Text = read_data["FIRST SITE"].ToString();
                First_slot.Text = read_data["FIRST SLOT"].ToString();
                First_endorser.Text = read_data["FIRST ENDORSER"].ToString();
                Second_verif_link.Text = read_data["SECOND DATALOG"].ToString();
                if (Second_verif_link.Text != String.Empty)
                    Data2 = (byte[])read_data["SECOND DATALOG"];
                Second_tester.Text = read_data["SECOND TESTER"].ToString();
                Second_site.Text = read_data["SECOND SITE"].ToString();
                Second_slot.Text = read_data["SECOND SLOT"].ToString();
                Second_endorser.Text = read_data["SECOND ENDORSER"].ToString();
                FileName1 = read_data["FILENAME 1"].ToString();
                Filename2 = read_data["FILENAME 2"].ToString();
                AREA.Text = read_data["AREA"].ToString();
                Second_date.Text = read_data["SECOND DATE"].ToString();
                FirstTime.Text = read_data["FIRST TIME"].ToString();
                SecondTime.Text = read_data["SECOND TIME"].ToString();
                Connection.CloseConnection();
                First_verif_link.Text = FileName1;
                Second_verif_link.Text = Filename2;
                if (Failed_during.Text.ToUpper() == "OTHERS")
                {
                    Failed_during.Text = other_failed_during;
                }
                if (Failure_mode.Text == "OTHERS")
                {
                    Failure_mode.Text = other_failure_mode;
                }
                if (Status.Text == "FOR SECOND VERIF")
                {
                    Second = "current_date()";
                    Count();
                }
                else if (string.IsNullOrEmpty(Second_date.Text))
                {
                    return;
                }
                else
                {
                    Second = "`SECOND DATE`";
                    Count();
                }
            }
            else
                this.Close();

        }
        private void Count()
        {
            Commands(1);
            if (Connection.OpenConnection())
            {
                MySqlDataReader readDay = command.ExecuteReader();
                readDay.Read();

                DAY = int.Parse(readDay["DAYS INTERVAL"].ToString());
                Connection.CloseConnection();
                Days(DAY);
            }
            else return;
        }
        private void Days(int day)
        {
            AGING.Text = string.Format("{0} DAY/S", day);
            if (day <= 2)
                AGING.ForeColor = System.Drawing.Color.Yellow;
            else if (day == 3)
                AGING.ForeColor = System.Drawing.Color.Orange;
            else
                AGING.ForeColor = System.Drawing.Color.Red;
        }
        private void Commands(int pick)
        {
            switch (pick)
            {
                case 0:
                    command = new MySqlCommand("SELECT `SERIAL NUMBER`,`PART NUMBER`,REVISION,BOARD,`TEST PROGRAM`,`FAILED DURING`,`FAILED DURING OTHERS`,`FAILURE MODE`,`FAILURE MODE OTHERS`," +
            "`TEST OPTION`,STATUS,REMARKS,`FIRST DATALOG`,`FIRST TESTER`,`FIRST SITE`,`FIRST SLOT`,`FIRST ENDORSER`,`SECOND DATALOG`," +
            "`SECOND TESTER`,`SECOND SITE`,`SECOND SLOT`,`SECOND ENDORSER`,`FILENAME 1`,`FILENAME 2`,`AREA`,`FIRST DATE`,`SECOND DATE`,`FIRST TIME`,`SECOND TIME`" +
            " FROM `boards_for_verification`.`board details` " +
            "WHERE (`ENDORSEMENT NUMBER` = '" + Endorsement_number + "')");
                    break;
                case 1:
                    DayCount = string.Format("select abs(datediff(`FIRST DATE`,{0})) as `DAYS INTERVAL` from `board details` where `endorsement number` = '" + Endorsement_number + "'",Second);
                    command = new MySqlCommand(DayCount,Connection.connect);
                    break;
            }
          
        }
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void First_verif_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string file1 = string.Format(@"C:\Users\{0}\Desktop\{1}", Environment.UserName, FileName1);
            File.WriteAllBytes(file1, Data1);
            System.Diagnostics.Process.Start(file1);
        }

        private void Second_verif_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string file2 = string.Format(@"C:\Users\{0}\Desktop\{1}", Environment.UserName, Filename2);
            File.WriteAllBytes(file2, Data2);
            System.Diagnostics.Process.Start(file2);
        }
    }
}
