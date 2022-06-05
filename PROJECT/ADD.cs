using System;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;


namespace PROJECT
{
    public partial class ADD : Form
    {
        MySqlCommand command;
        public string tester_platform, get_status, inputBox,FileName,displayStatus,boardQuery,database,tester,input_status;
        public int sites, DoNotLoadBoard, UpdateCheck;
        public DateTime FIRST_DATE = new DateTime();
        public DateTime SECOND_DATE = new DateTime();
        public DateTime FIRST_TIME = new DateTime();
        public DateTime SECOND_TIME = new DateTime();
        public DateTime FirstVsSecond = new DateTime();

        byte[] data;
        public ADD()
        {
            InitializeComponent();
        }
        private void error()
        {
            MessageBox.Show("INCOMPLETE DETAILS!");
        }
        private byte[] SaveFile(string file)
        {
            using (Stream getDatalog = File.OpenRead(file))
            {
                data = new byte[getDatalog.Length];
                getDatalog.Read(data, 0, data.Length);
            }
            return data;
        }
        private string Filename(string filename)
        {
            FileName = new FileInfo(filename).Name;
            return FileName;
        }

        private void Save_data(int InputCommand)
        {
            DialogResult yes_no = MessageBox.Show(string.Format("PLEASE DOUBLE CHECK YOUR DATA,THIS WILL BE SAVE PERMANENTLY. SAVE IT? STATUS: {0}",STATUS.Text), "ATTENTION", MessageBoxButtons.YesNo);
                switch (yes_no)
                {
                    case DialogResult.Yes:
                        commands(InputCommand);
                        break;
                    case DialogResult.No:
                        return;
                }
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
                if (Connection.CloseConnection())
                {
                    UpdateCheck = 0;
                    MessageBox.Show("FILE SAVED SUCCESSFULLY");
                    clear_all();
                    Save_btn.Visible = false;
                    Update_Button.Visible = false;
                    Serial_number.Visible = true;
                    Serial_number.Clear();
                    Part_number.Clear();
                    LoadTesterPlatforms();
                }
                else return;
            }
            else
                return;
        }
        private bool ForFirstVerif()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox == Failure_mode_others || textBox == Failed_during_others || textBox == Remarks)
                        continue;
                    else
                    {
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            error();
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
                        error();
                        return false;
                    }
                    else if (comboBox == Failed_during)
                    {
                        if (Failed_during.SelectedIndex == 2)
                        {
                            if (string.IsNullOrWhiteSpace(Failed_during_others.Text))
                            {
                                error();
                                return false;
                            }
                            else if (Failed_during_others.Text.Length > 20)
                            {
                                MessageBox.Show("TOO LONG INPUT!");
                                return false;
                            }
                            else continue;
                        }
                    }
                    else if (comboBox == Failure_mode)
                    {
                        if (Failure_mode.SelectedIndex == 7)
                        {
                            if (string.IsNullOrWhiteSpace(Failure_mode_others.Text))
                            {
                                error();
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
            if (STATUS.Text == "BRG" || STATUS.Text == "INSTALL TO TESTER")
            {
                if (First_tester.SelectedIndex == -1 || string.IsNullOrWhiteSpace(First_board_slot.Text)
                  || first_endorser.SelectedIndex == -1)
                {
                    error();
                    return false;
                }
            }
            else
            {
                if (first_verif_link.Text == string.Empty || First_tester.SelectedIndex == -1 || string.IsNullOrWhiteSpace(First_board_slot.Text)
               || first_endorser.SelectedIndex == -1)
                {
                    error();
                    return false;
                }
            }
            if (First_board_slot.Text.Length > 5)
            {
                MessageBox.Show("TOO LONG INPUT ON BOARD SLOT!");
                return false;
            }
            if (First_Site.Items.Count != 0)
            {
                if (First_Site.SelectedIndex == -1)
                {
                    error();
                    return false;
                }
            }
            return true;
        }
        private bool ForSecondVerif()
        {
            if (STATUS.Text == "BRG")
            {
                if (Second_tester.SelectedIndex == -1 || string.IsNullOrWhiteSpace(Second_slot.Text) || second_endorser.SelectedIndex == -1 || string.IsNullOrWhiteSpace(Remarks.Text))
                {
                    error(); return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(second_verif_link.Text) || Second_tester.SelectedIndex == -1 || string.IsNullOrWhiteSpace(Second_slot.Text)
                    || second_endorser.SelectedIndex == -1 || string.IsNullOrWhiteSpace(Remarks.Text))
                {
                    error();
                    return false;
                }
            }
            if (Second_slot.Text.Length > 5)
            {
                MessageBox.Show("TOO LONG INPUT IN SLOT!");
                return false;
            }
            if (Second_Site.Items.Count != 0)
            {
                if (Second_Site.SelectedIndex == -1)
                {
                    error();
                    return false;
                }
            }
            return true;
        }
        private void Update_Button_Click(object sender, EventArgs e)
        {
           if (STATUS.Text == "INSTALL TO TESTER")
            {
                input_status = STATUS.Text;
                if (Second_Site.Items.Count == 0)
                {
                    if (second_endorser.SelectedIndex == -1 || Second_tester.SelectedIndex == -1 || string.IsNullOrWhiteSpace(Second_slot.Text))
                    {
                        error();
                        return;
                    }
                    Save_data(10);
                }
                else
                {
                    if (second_endorser.SelectedIndex == -1 || Second_tester.SelectedIndex == -1 || Second_Site.SelectedIndex == -1 || string.IsNullOrWhiteSpace(Second_slot.Text))
                    {
                        error();
                        return;
                    }
                    Save_data(10);
                }
            }
            else if (STATUS.Text == "SPARES")
            {
                input_status = STATUS.Text;
                if (ForSecondVerif())
                {
                    Save_data(3);
                }
            }
            else if (STATUS.Text == "BRG")
            {
                input_status = "BRG (INCOMING)";
                if (ForSecondVerif())
                    Save_data(3);
            }
            else
            {
                MessageBox.Show("CHOOSE STATUS");
            }
        }
        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (STATUS.Text == "FOR SECOND VERIF")
            {
                if (get_status == "FOR VERIFICATION")
                {
                    input_status = STATUS.Text;
                    if (ForFirstVerif())
                    {
                        Save_data(9);
                    }
                }
                else
                {
                    input_status = STATUS.Text;
                    if (ForFirstVerif())
                    {
                        Save_data(2);
                    }
                }
            }
            else if (STATUS.Text == "FOR VERIFICATION")
            {
                input_status = STATUS.Text;
                if (string.IsNullOrWhiteSpace(Revision.Text) || Test_system.SelectedIndex == -1 || Boards.SelectedIndex == -1 ||
                    Area.SelectedIndex == -1)
                {
                    error(); return;
                }
                Save_data(6);
            }
            else if (STATUS.Text == "SPARES")
            {
                input_status = STATUS.Text;
                if (ForFirstVerif())
                {
                    if (get_status == "FOR VERIFICATION")
                        Save_data(9);
                    else
                        Save_data(2);
                }
            }
            else if (STATUS.Text == "INSTALL TO TESTER")
            {
                input_status = STATUS.Text;
                if (ForFirstVerif())
                {
                    if (get_status == "FOR VERIFICATION")
                    {
                        Save_data(11);
                    }
                    else
                    {
                        Save_data(7);
                    }
                }
            }
            else if (STATUS.Text == "BRG")
            {
                input_status = "BRG (INCOMING)";
                if (ForFirstVerif())
                {
                    if (ForSecondVerif())
                    {
                        if (string.IsNullOrEmpty(first_verif_link.Text))
                        {
                            FirstDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            FirstTime.Text = DateTime.Now.ToString("hh:mm tt");
                            if (get_status == "FOR VERIFICATION")
                                Save_data(17);
                            else
                                Save_data(12);
                        }
                        else if (string.IsNullOrEmpty(second_verif_link.Text))
                        {
                            SecondDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            SecondTime.Text = DateTime.Now.ToString("hh:mm tt");
                            if (get_status == "FOR VERIFICATION")
                                Save_data(16);
                            else
                                Save_data(19);
                        }
                        else
                        {
                            if (get_status == "FOR VERIFICATION")
                                Save_data(18);
                            else
                                Save_data(4);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("CHOOSE STATUS");
            }
        }
        private void Add_first_verif_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "BROWSE A FILE";
            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                first_verif_link.Visible = true;
                first_verif_link.Text = openFileDialog1.FileName;
                FIRST_DATE = System.IO.File.GetLastWriteTime(openFileDialog1.FileName);
                FirstDate.Text = FIRST_DATE.ToString("yyyy-MM-dd");
                FirstTime.Text = FIRST_DATE.ToString("hh:mm tt");
            }
            Show_second_grpBox();
        }
        private void Add_second_verif_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = @"c:\";
            openFileDialog2.Title = "BROWSE A FILE";
            openFileDialog2.FileName = null;
            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                SECOND_DATE = System.IO.File.GetLastWriteTime(openFileDialog2.FileName);
                if (FIRST_DATE > SECOND_DATE)
                {
                    MessageBox.Show("DATE NOT VALID, MUST BE AHEAD TO THE FIRST VERIFICATION DATE");
                    return;
                }
                if (UpdateCheck == 1)
                {
                    FirstVsSecond = DateTime.ParseExact(FirstDate.Text, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture);
                    if (FirstVsSecond > SECOND_DATE)
                    { 
                        MessageBox.Show("DATE NOT VALID, MUST BE AHEAD TO THE FIRST VERIFICATION DATE");
                        return;
                    }
                }
                second_verif_link.Visible = true;
                second_verif_link.Text = openFileDialog2.FileName;
                SecondDate.Text = SECOND_DATE.ToString("yyyy-MM-dd");
                SecondTime.Text = SECOND_DATE.ToString("hh:mm tt");
            }
        }
        private void first_verif_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Save_btn.Visible == false)
            {
                string DatalogFile = string.Format("C:\\Users\\{0}\\Desktop\\{1}", Environment.UserName, FileName);
                File.WriteAllBytes(DatalogFile, data);
                System.Diagnostics.Process.Start(DatalogFile);
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(first_verif_link.Text);
                }
                catch (Exception me)
                {
                    MessageBox.Show("ERROR " + me.ToString());
                }
            }
        }
        private void second_verif_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(second_verif_link.Text);
            }
            catch (Exception mess)
            {
                MessageBox.Show("ERROR " + mess.ToString());
            }
        }

        private bool CheckTextBox(string textBox)
        {
            char[] text = textBox.ToCharArray();
            if (textBox.Length > 40)
            {
                MessageBox.Show("MAXIMUM OF TEN CHARACTERS ONLY");
                return false;
            }
            for (int Txt = 0; Txt < textBox.Length ; Txt++)
            {
                if (char.IsLetterOrDigit(text[Txt])) continue;
                else if (text[Txt] == '-') continue;
                else
                {
                    MessageBox.Show("PLEASE ENTER NUMBER OR LETTER ONLY.");
                    return false;
                }
            }
            return true;
        }
        private void Key_Enter(object sender, KeyEventArgs e)
        {
            UpdateCheck = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckTextBox(Serial_number.Text))
                {
                    if (string.IsNullOrWhiteSpace(Serial_number.Text) || string.IsNullOrWhiteSpace(Part_number.Text))
                    {
                        MessageBox.Show("NO INPUT");
                        return;
                    }
                    STATUS.Items.Remove("FOR VERIFICATION");
                    STATUS.Items.Add("FOR VERIFICATION");
                    LoadBoardDetails();
                }
            }
        }

        private void LoadBoardDetails()
        {
            commands(1);
            command.Connection = Connection.connect;

            if (Connection.OpenConnection())
            {
                MySqlDataReader read_status = command.ExecuteReader();
                read_status.Read();
                try
                {
                    get_status = read_status["STATUS"].ToString();
                    if (get_status == "BRG (INCOMING)")
                    {
                        MessageBox.Show("THIS BOARD IS CURRENTLY ENDORSED TO BRG");
                        Connection.CloseConnection();
                        clear_all();
                        Save_btn.Visible = false;
                        Update_Button.Visible = false;
                        return;
                    }
                    if (get_status == "SPARES" || get_status == "BRG (REPAIRED)" || get_status.Contains("INSTALL") || get_status == "FAILURE CHANGED" || get_status == "FOR VERIFICATION")
                    {
                        if (get_status == "FOR VERIFICATION")
                            STATUS.Items.Remove("FOR VERIFICATION");
                        DialogResult yes_no = MessageBox.Show("LAST TRANSACTION: " + get_status + ", ADD NEW?", "ATTENTION!",
                            MessageBoxButtons.YesNo);
                        switch (yes_no)
                        {
                            case DialogResult.Yes:
                                Connection.CloseConnection();
                                commands(14);
                                command.Connection = Connection.connect;
                                Connection.OpenConnection();
                                MySqlDataReader read_data = command.ExecuteReader();
                                read_data.Read();
                                clear_all();
                                enable_control();
                                all_controls();
                                Revision.Text = read_data["REVISION"].ToString();
                                Test_system.Items.Add(read_data["TESTER PLATFORM"].ToString());
                                Boards.Items.Add(read_data["BOARD"].ToString());
                                Connection.CloseConnection();
                                Boards.SelectedIndex = 0;
                                Update_Button.Visible = false;
                                DoNotLoadBoard = 1;
                                Test_system.SelectedIndex = 0;
                                if (Test_system.Text == "ASL1K" || Test_system.Text == "ASL4K")
                                {
                                    Test_system.Items.Clear();
                                    Test_system.Items.Add("TMT");
                                }
                                Test_system.SelectedIndex = 0;
                                Testers();
                                DIE_TYPE.Focus();
                                return;
                            case DialogResult.No:
                                Connection.CloseConnection();
                                clear_all();
                                Serial_number.Clear();
                                Part_number.Clear();
                                Save_btn.Visible = false;
                                Update_Button.Visible = false;
                                DoNotLoadBoard = 0;
                                return;
                        }
                    }
                    else
                    {
                        Connection.CloseConnection();
                        STATUS.Items.Remove("FOR VERIFICATION");
                        STATUS.Items.Remove("FOR SECOND VERIF");
                        commands(13);
                        command.Connection = Connection.connect;
                        Connection.OpenConnection();
                        MySqlDataReader read_secondVerif = command.ExecuteReader();
                        read_secondVerif.Read();
                        ClearItemsInTesterBox();
                        Test_system.Items.Clear();
                        Boards.Items.Clear();
                        all_controls();

                        Revision.Text = read_secondVerif["REVISION"].ToString();
                        Boards.Items.Add(read_secondVerif["BOARD"].ToString());
                        DIE_TYPE.Text = read_secondVerif["TEST PROGRAM"].ToString();
                        Test_system.Items.Add(read_secondVerif["TESTER PLATFORM"].ToString());
                        Failed_during.Text = read_secondVerif["FAILED DURING"].ToString();
                        Failed_during_others.Text = read_secondVerif["FAILED DURING OTHERS"].ToString();
                        Failure_mode.Text = read_secondVerif["FAILURE MODE"].ToString();
                        Failure_mode_others.Text = read_secondVerif["FAILURE MODE OTHERS"].ToString();
                        Test_option.Text = read_secondVerif["TEST OPTION"].ToString();
                        Remarks.Text = read_secondVerif["REMARKS"].ToString();
                        data = (byte[])read_secondVerif["FIRST DATALOG"];
                        First_tester.Items.Add(read_secondVerif["FIRST TESTER"]);
                        First_Site.Items.Add(read_secondVerif["FIRST SITE"].ToString());
                        First_board_slot.Text = read_secondVerif["FIRST SLOT"].ToString();
                        first_endorser.Text = read_secondVerif["FIRST ENDORSER"].ToString();
                        FileName = read_secondVerif["FILENAME 1"].ToString();
                        Area.Text = read_secondVerif["AREA"].ToString();
                        FirstDate.Text = read_secondVerif["FIRST DATE"].ToString();
                        FirstTime.Text = read_secondVerif["FIRST TIME"].ToString();
                        Connection.CloseConnection();
                        UpdateCheck = 1;
                        disable_control();
                        first_verif_link.Text = FileName;
                        Boards.SelectedIndex = 0;
                        Test_system.SelectedIndex = 0;
                        First_tester.SelectedIndex = 0;
                        First_Site.SelectedIndex = 0;
                        Remarks.Focus();
                        if (First_Site.Text.Equals(string.Empty))
                            First_Site.Visible = false;
                        else
                            First_Site.Visible = true;
                        Save_btn.Visible = false;
                        Update_Button.Visible = true;
                        Second_box.Visible = true;
                        if (Test_system.Text == "ASL4K" || Test_system.Text == "ASL1K")
                        {
                            Test_system.Items.Clear();
                            Test_system.Items.Add("TMT");
                            Test_system.SelectedIndex = 0;
                            command = new MySqlCommand("select * from `boards_for_verification`.`tmt`", Connection.connect);
                            Connection.OpenConnection();
                            MySqlDataReader tmt = command.ExecuteReader();
                            while (tmt.Read())
                            {
                                Second_tester.Items.Add(tmt["TMT"].ToString());
                            }
                            Connection.CloseConnection();
                        }
                        else
                        {
                            tester_platform = string.Format("SELECT * FROM `boards_for_verification`.`{0}`", Test_system.Text.ToLower());
                            command = new MySqlCommand(tester_platform, Connection.connect);

                            Connection.OpenConnection();
                            MySqlDataReader read = command.ExecuteReader();
                            while (read.Read())
                            {
                                Second_tester.Items.Add(read.GetString(Test_system.Text.ToUpper()));
                            }
                            sites = int.Parse(read["SITE"].ToString());
                            Connection.CloseConnection();
                            if (sites != 0)
                            {
                                for (int CountSite = 1; CountSite <= sites; CountSite++)
                                {
                                    Second_Site.Items.Add(CountSite.ToString());
                                }
                                Second_Site.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    DialogResult yes_no = MessageBox.Show("NO DATA, ADD NEW?", "ATTENTION!", MessageBoxButtons.YesNo);
                    switch (yes_no)
                    {
                        case DialogResult.Yes:
                            Connection.CloseConnection();
                            clear_all();
                            all_controls();
                            enable_control();
                            Update_Button.Visible = false;
                            DoNotLoadBoard = 0;
                            LoadTesterPlatforms();
                            Revision.Focus();
                            break;
                        case DialogResult.No:
                            Connection.CloseConnection();
                            Serial_number.Clear();
                            Part_number.Clear();
                            clear_all();
                            Save_btn.Visible = false;
                            Update_Button.Visible = false;
                            break;
                    }
                }
            }         
        }
        private void commands(int Pick)
        {
            switch (Pick)
            {
                case 1:  // FOR CHECKING THE STATUS
                    command = new MySqlCommand("SELECT `STATUS` FROM `boards_for_verification`.`board details` WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' and `PART NUMBER` = '" + Part_number.Text + "') " +
                        "ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    break;

                case 2:  // FOR ADDING A NEW TRANSACTION FOR NO SECOND VERIFICATION
                    command = new MySqlCommand("INSERT INTO `boards_for_verification`." +
            "`board details`(`SERIAL NUMBER`,`PART NUMBER`,REVISION,BOARD,`TEST PROGRAM`,`FAILED DURING`,`FAILED DURING OTHERS`,`FAILURE MODE`,`FAILURE MODE OTHERS`," +
            "`TEST OPTION`,STATUS,REMARKS,`FIRST DATALOG`,`FIRST TESTER`,`FIRST SITE`,`FIRST SLOT`,`FIRST ENDORSER`,`TESTER PLATFORM`,`FILENAME 1`,`AREA`,`FIRST DATE`,`FIRST TIME`) VALUES('" + Serial_number.Text + "'," +
            "'" + Part_number.Text + "','" + Revision.Text + "','" + Boards.Text + "','" + DIE_TYPE.Text + "','" + Failed_during.Text + "','" + Failed_during_others.Text + "'," +
            "'" + Failure_mode.Text + "','" + Failure_mode_others.Text + "','" + Test_option.Text + "','" + input_status + "','" + Remarks.Text + "',@FIRST_DATA," +
            "'" + First_tester.Text + "','" + First_Site.Text + "','" + First_board_slot.Text + "','" + first_endorser.Text + "','" + Test_system.Text + "'," +
            "'" + Filename(first_verif_link.Text) + "','" + Area.Text + "','" + FirstDate.Text + "','" + FirstTime.Text + "')");
                    command.Parameters.Add("@FIRST_DATA", MySqlDbType.VarBinary).Value = SaveFile(first_verif_link.Text);
                    break;
                case 3:  // FOR UPDATING THE LAST TRANSACTION
                    command = new MySqlCommand("UPDATE `boards_for_verification`.`board details` SET `STATUS` = '" + input_status + "',`SECOND DATALOG` = @SECOND_DATA," +
                        "`SECOND TESTER` = '" + Second_tester.Text + "',`SECOND SITE` = '" + Second_Site.Text + "'," +
                        "`SECOND SLOT` = '" + Second_slot.Text + "',`SECOND ENDORSER` = '" + second_endorser.Text + "',`REMARKS` = '" + Remarks.Text + "'," +
                        "`FILENAME 2` = '" + Filename(second_verif_link.Text) + "',`SECOND DATE` = '" + SecondDate.Text + "'," +
                        "`SECOND TIME` ='" + SecondTime.Text + "'" +
                        " WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' AND `PART NUMBER` = '" + Part_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    command.Parameters.Add("@SECOND_DATA", MySqlDbType.VarBinary).Value = SaveFile(second_verif_link.Text);
                    break;

                case 4: //FOR ADDING A NEW TRANSACTION WITH FIRST AND SECOND VERIFICATION
                    command = new MySqlCommand("INSERT INTO `boards_for_verification`." +
            "`board details`(`SERIAL NUMBER`,`PART NUMBER`,REVISION,BOARD,`TEST PROGRAM`,`FAILED DURING`,`FAILED DURING OTHERS`,`FAILURE MODE`,`FAILURE MODE OTHERS`," +
            "`TEST OPTION`,STATUS,REMARKS,`FIRST DATALOG`,`FIRST TESTER`,`FIRST SITE`,`FIRST SLOT`,`FIRST ENDORSER`,`SECOND DATALOG`," +
            "`SECOND TESTER`,`SECOND SITE`,`SECOND SLOT`,`SECOND ENDORSER`,`TESTER PLATFORM`,`FILENAME 1`,`FILENAME 2`,`AREA`,`FIRST DATE`,`SECOND DATE`,`FIRST TIME`,`SECOND TIME`) " +
            "VALUES('" + Serial_number.Text + "','" + Part_number.Text + "','" + Revision.Text + "','" + Boards.Text + "','" + DIE_TYPE.Text + "','" + Failed_during.Text + "','" + Failed_during_others.Text + "'," +
            "'" + Failure_mode.Text + "','" + Failure_mode_others.Text + "','" + Test_option.Text + "','" + input_status + "','" + Remarks.Text + "',@FIRST_DATA," +
            "'" + First_tester.Text + "','" + First_Site.Text + "','" + First_board_slot.Text + "','" + first_endorser.Text + "',@SECOND_DATA," +
            "'" + Second_tester.Text + "','" + Second_Site.Text + "','" + Second_slot.Text + "','" + second_endorser.Text + "','" + Test_system.Text + "'," +
            "'" + Filename(first_verif_link.Text )+ "','" + Filename(second_verif_link.Text )+ "','" + Area.Text + "','" + FirstDate.Text + "','" + SecondDate.Text + "',"+
            "'" + FirstTime.Text + "','" + SecondTime.Text + "')");
                    command.Parameters.Add("@FIRST_DATA", MySqlDbType.VarBinary).Value = SaveFile(first_verif_link.Text);
                    command.Parameters.Add("@SECOND_DATA", MySqlDbType.VarBinary).Value = SaveFile(second_verif_link.Text);
                    break;
                case 5:  //FOR THE TESTER PLATFORMS
                    command = new MySqlCommand("SELECT * FROM `boards_for_verification`.`tester platforms`", Connection.connect);
                    break;
                case 6:  //FOR VERIFICATION
                    command = new MySqlCommand("INSERT INTO `boards_for_verification`.`board details` " +
                        "(`SERIAL NUMBER`,`PART NUMBER`,`REVISION`,`TESTER PLATFORM`,`BOARD`,`TEST PROGRAM`,`AREA`,`STATUS`,`REMARKS`,`FIRST DATE`,`FIRST TIME`) " +
                        "VALUES ('" + Serial_number.Text + "', '" + Part_number.Text + "'," +
                        "'" + Revision.Text + "','" + Test_system.Text + "','" + Boards.Text + "','N/A','" + Area.Text + "','" + input_status + "'," +
                        "'" + Remarks.Text + "','" + FirstDate.Text + "','" + FirstTime.Text + "')");
                    break;
                case 7:  // INSTALLED TO TESTER (NEW TRANSACTION)
                    command = new MySqlCommand(String.Format("INSERT INTO `boards_for_verification`." +
                        "`board details`(`SERIAL NUMBER`,`PART NUMBER`,REVISION,BOARD,`TEST PROGRAM`,`FAILED DURING`,`FAILED DURING OTHERS`,`FAILURE MODE`,`FAILURE MODE OTHERS`," +
                        "`TEST OPTION`,STATUS,REMARKS,`FIRST TESTER`,`FIRST SITE`,`FIRST SLOT`,`FIRST ENDORSER`,`TESTER PLATFORM`,`AREA`,`STATUS`,`REMARKS`,`FIRST DATE`,`FIRST TIME`) VALUES('" + Serial_number.Text + "'," +
                         "'" + Part_number.Text + "','" + Revision.Text + "','" + Boards.Text + "','" + DIE_TYPE.Text + "','" + Failed_during.Text + "','" + Failed_during_others.Text + "'," +
                        "'" + Failure_mode.Text + "','" + Failure_mode_others.Text + "','" + Test_option.Text + "','" + input_status + "','" + Remarks.Text + "'," +
                        "'" + First_tester.Text + "','" + First_Site.Text + "','" + First_board_slot.Text + "','" + first_endorser.Text + "','" + Test_system.Text + "'," +
                        "'" + Area.Text + "','INSTALL TO {0}','" + Remarks.Text + "','" + FirstDate.Text + "','" + FirstTime.Text + "')",First_tester.Text));
                    break;
                case 8:  //LOAD TESTER PLATFORMS
                    tester_platform = string.Format("SELECT * FROM `boards_for_verification`.`{0}`", Test_system.Text.ToLower());
                    command = new MySqlCommand(tester_platform, Connection.connect);
                    break;
                case 9://UPDATE BOARD WHEN LOGGED FOR VERIFICATION (ENDOSED TO SPARES)
                    command = new MySqlCommand("UPDATE `boards_for_verification`.`board details` SET `TEST PROGRAM` = '" + DIE_TYPE.Text + "'," +
                        "`FAILED DURING` = '" + Failed_during.Text + "',`FAILED DURING OTHERS` = '" + Failed_during_others.Text + "',`FAILURE MODE` = '" + Failure_mode.Text + "'," +
                        "`FAILURE MODE OTHERS` = '" + Failure_mode_others.Text + "',`TEST OPTION` = '" + Test_option.Text + "',`AREA` = '" + Area.Text + "',`STATUS` = '" + input_status + "',REMARKS = '" + Remarks.Text + "'," +
                        "`FIRST DATALOG` = @FIRST_DATA,`FIRST TESTER` = '" + First_tester.Text + "',`FIRST SITE` = '" + First_Site.Text + "',`FIRST SLOT` = '" + First_board_slot.Text + "'," +
                        "`FIRST ENDORSER` = '" + first_endorser.Text + "',`FIRST TIME` = '" + FirstTime.Text + "',`FIRST DATE` = '" + FirstDate.Text + "',`FILENAME 1` = '" + Filename(first_verif_link.Text) + "'" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' AND `PART NUMBER` = '" + Part_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    command.Parameters.Add("@FIRST_DATA", MySqlDbType.VarBinary).Value = SaveFile(first_verif_link.Text);
                    break;
                case 10:  // INSTALL TO A TESTER IN SECOND VERIFICATION
                    command = new MySqlCommand(string.Format("UPDATE `boards_for_verification`.`board details` " +
                        "SET `SECOND TESTER` = '" + Second_tester.Text + "',`SECOND SITE` = '" + Second_Site.Text + "'," +
                        "`SECOND SLOT` = '" + Second_slot.Text + "'," +
                        "`SECOND ENDORSER` = '" + second_endorser.Text + "'," +
                        "`STATUS` = 'INSTALL TO {0}',`REMARKS` = '" + Remarks.Text + "',`SECOND DATE` = '" + SecondDate.Text + "'," +
                        "`SECOND TIME` = '" + SecondTime.Text + "'" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1", Second_tester.Text));
                    break;
                case 11: // INSTALLED TO TESTER IN FIRST VERIFICATION
                    command = new MySqlCommand(String.Format("UPDATE `boards_for_verification`.`board details` SET `TEST PROGRAM` = '" + DIE_TYPE.Text + "'," +
                        "`FAILED DURING` = '" + Failed_during.Text + "',`FAILED DURING OTHERS` = '" + Failed_during_others.Text + "',`FAILURE MODE` = '" + Failure_mode.Text + "'," +
                        "`FAILURE MODE OTHERS` = '" + Failure_mode_others.Text + "',`TEST OPTION` = '" + Test_option.Text + "',`AREA` = '" + Area.Text + "',`STATUS` = 'INSTALL TO {0}',REMARKS = '" + Remarks.Text + "'," +
                        "`FIRST TESTER` = '" + First_tester.Text + "',`FIRST SITE` = '" + First_Site.Text + "',`FIRST SLOT` = '" + First_board_slot.Text + "'," +
                        "`FIRST ENDORSER` = '" + first_endorser.Text + "',`FIRST TIME` = '" + FirstTime.Text + "'" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' AND `PART NUMBER` = '" + Part_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1",First_tester.Text));
                    break;
                case 12: //ENDORSED TO BRG WITH PHYSICAL DAMAGE IN FIRST VERIFICATION (NO DATALOG)
                    command = new MySqlCommand("INSERT INTO `boards_for_verification`." +
            "`board details`(`SERIAL NUMBER`,`PART NUMBER`,REVISION,BOARD,`TEST PROGRAM`,`FAILED DURING`,`FAILED DURING OTHERS`,`FAILURE MODE`,`FAILURE MODE OTHERS`," +
            "`TEST OPTION`,STATUS,REMARKS,`FIRST TESTER`,`FIRST SITE`,`FIRST SLOT`,`FIRST ENDORSER`," +
            "`TESTER PLATFORM`,`AREA`,`FIRST DATE`,`FIRST TIME`) " +
            "VALUES ('" + Serial_number.Text + "','" + Part_number.Text + "','" + Revision.Text + "','" + Boards.Text + "','" + DIE_TYPE.Text + "','" + Failed_during.Text + "','" + Failed_during_others.Text + "'," +
            "'" + Failure_mode.Text + "','" + Failure_mode_others.Text + "','" + Test_option.Text + "','" + input_status + "','" + Remarks.Text + "'" +
            "'" + First_tester.Text + "','" + First_Site.Text + "','" + First_board_slot.Text + "','" + first_endorser.Text + "','" + Test_system.Text + "'," +
            "'" + Area.Text + "','" + FirstDate.Text + "','" + FirstTime.Text + "')");
                    break;
                case 13:  // FOR CHECKING THE LAST TRANSACTION FOR 2ND VERIF
                    command = new MySqlCommand("SELECT * FROM `boards_for_verification`.`board details`" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' and `PART NUMBER` = '" + Part_number.Text + "') " +
                        "ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    break;
                case 14:  // FOR CHECKING THE LAST TRANSACTION FOR NEW BOARD FAILURE
                    command = new MySqlCommand("SELECT `REVISION`,`TESTER PLATFORM`,`BOARD`" +
                        " FROM `boards_for_verification`.`board details` " +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' and `PART NUMBER` = '" + Part_number.Text + "') " +
                        "ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    break;
                case 15:  //LOAD USERS 
                    command = new MySqlCommand("SELECT * FROM `boards_of_testers`.`user`",Connection.ConnectBoards);
                    break;
                case 16: // ENDORSED TO BRG WITH FIRST DATALOG AND PHYSICAL DAMAGE ON SECOND VERIF
                    command = new MySqlCommand("UPDATE `boards_for_verification`.`board details` SET `TEST PROGRAM` = '" + DIE_TYPE.Text + "'," +
                        "`FAILED DURING` = '" + Failed_during.Text + "',`FAILED DURING OTHERS` = '" + Failed_during_others.Text + "',`FAILURE MODE` = '" + Failure_mode.Text + "'," +
                        "`FAILURE MODE OTHERS` = '" + Failure_mode_others.Text + "',`TEST OPTION` = '" + Test_option.Text + "',`AREA` = '" + Area.Text + "',`STATUS` = '" + input_status + "',REMARKS = '" + Remarks.Text + "'," +
                        "`FIRST DATALOG` = @FIRST_DATA,`FIRST TESTER` = '" + First_tester.Text + "',`FIRST SITE` = '" + First_Site.Text + "',`FIRST SLOT` = '" + First_board_slot.Text + "'," +
                        "`FIRST ENDORSER` = '" + first_endorser.Text + "',`FIRST TIME` = '" + FirstTime.Text + "',`FIRST DATE` = '" + FirstDate.Text + "'," +
                        "`FILENAME 1` = '" + Filename(first_verif_link.Text) + "',`SECOND TESTER` = '" + Second_tester.Text + "',`SECOND SITE` = '" + Second_Site.Text + "'," +
                        "`SECOND SLOT` = '" + Second_slot.Text + "',`SECOND ENDORSER` = '" + second_endorser.Text + "',`REMARKS` = '" + Remarks.Text + "'," +
                        "`SECOND DATE` = '" + SecondDate.Text + "',`SECOND TIME` ='" + SecondTime.Text + "'" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' AND `PART NUMBER` = '" + Part_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    command.Parameters.Add("@FIRST_DATA", MySqlDbType.VarBinary).Value = SaveFile(first_verif_link.Text);
                    break;
                case 17: // ENDORSED TO BRG (NO DATALOG) FIRST TAGGED AS FOR VERIFICATION
                    command = new MySqlCommand("UPDATE `boards_for_verification`.`board details` SET `TEST PROGRAM` = '" + DIE_TYPE.Text + "'," +
                        "`FAILED DURING` = '" + Failed_during.Text + "',`FAILED DURING OTHERS` = '" + Failed_during_others.Text + "',`FAILURE MODE` = '" + Failure_mode.Text + "'," +
                        "`FAILURE MODE OTHERS` = '" + Failure_mode_others.Text + "',`TEST OPTION` = '" + Test_option.Text + "',`AREA` = '" + Area.Text + "',`STATUS` = '" + input_status + "',REMARKS = '" + Remarks.Text + "'," +
                        "`FIRST TESTER` = '" + First_tester.Text + "',`FIRST SITE` = '" + First_Site.Text + "',`FIRST SLOT` = '" + First_board_slot.Text + "'," +
                        "`FIRST ENDORSER` = '" + first_endorser.Text + "',`FIRST TIME` = '" + FirstTime.Text + "',`FIRST DATE` = '" + FirstDate.Text + "'" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' AND `PART NUMBER` = '" + Part_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    break;
                case 18: //ENDORSED TO BRG FROM FIRST VERIFICATION WITH 1ST AND 2ND DATALOG
                    command = new MySqlCommand("UPDATE `boards_for_verification`.`board details` SET `TEST PROGRAM` = '" + DIE_TYPE.Text + "'," +
                        "`FAILED DURING` = '" + Failed_during.Text + "',`FAILED DURING OTHERS` = '" + Failed_during_others.Text + "',`FAILURE MODE` = '" + Failure_mode.Text + "'," +
                        "`FAILURE MODE OTHERS` = '" + Failure_mode_others.Text + "',`TEST OPTION` = '" + Test_option.Text + "',`AREA` = '" + Area.Text + "',`STATUS` = '" + input_status + "',REMARKS = '" + Remarks.Text + "'," +
                        "`FIRST DATALOG` = @FIRST_DATA,`FIRST TESTER` = '" + First_tester.Text + "',`FIRST SITE` = '" + First_Site.Text + "',`FIRST SLOT` = '" + First_board_slot.Text + "'," +
                        "`FIRST ENDORSER` = '" + first_endorser.Text + "',`FIRST TIME` = '" + FirstTime.Text + "',`FIRST DATE` = '" + FirstDate.Text + "'," +
                        "`FILENAME 1` = '" + Filename(first_verif_link.Text) + "',`SECOND DATALOG` = @SECOND_DATA,`SECOND TESTER` = '" + Second_tester.Text + "'," +
                        "`SECOND SITE` = '" + Second_Site.Text + "',`FILENAME 2` = '" + Filename(second_verif_link.Text) + "'," +
                        "`SECOND SLOT` = '" + Second_slot.Text + "',`SECOND ENDORSER` = '" + second_endorser.Text + "',`REMARKS` = '" + Remarks.Text + "'," +
                        "`SECOND DATE` = '" + SecondDate.Text + "',`SECOND TIME` ='" + SecondTime.Text + "'" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' AND `PART NUMBER` = '" + Part_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    command.Parameters.Add("@FIRST_DATA", MySqlDbType.VarBinary).Value = SaveFile(first_verif_link.Text);
                    command.Parameters.Add("@SECOND_DATA", MySqlDbType.VarBinary).Value = SaveFile(second_verif_link.Text);
                    break;
                case 19: //ENDORSED TO BRG
                    command = new MySqlCommand("INSERT INTO `boards_for_verification`." +
            "`board details`(`SERIAL NUMBER`,`PART NUMBER`,REVISION,BOARD,`TEST PROGRAM`,`FAILED DURING`,`FAILED DURING OTHERS`,`FAILURE MODE`,`FAILURE MODE OTHERS`," +
            "`TEST OPTION`,STATUS,REMARKS,`FIRST DATALOG`,`FIRST TESTER`,`FIRST SITE`,`FIRST SLOT`,`FIRST ENDORSER`," +
            "`SECOND TESTER`,`SECOND SITE`,`SECOND SLOT`,`SECOND ENDORSER`,`TESTER PLATFORM`,`FILENAME 1`,`FILENAME 2`,`AREA`,`FIRST DATE`,`SECOND DATE`,`FIRST TIME`,`SECOND TIME`) " +
            "VALUES('" + Serial_number.Text + "','" + Part_number.Text + "','" + Revision.Text + "','" + Boards.Text + "','" + DIE_TYPE.Text + "','" + Failed_during.Text + "','" + Failed_during_others.Text + "'," +
            "'" + Failure_mode.Text + "','" + Failure_mode_others.Text + "','" + Test_option.Text + "','" + input_status + "','" + Remarks.Text + "',@FIRST_DATA," +
            "'" + First_tester.Text + "','" + First_Site.Text + "','" + First_board_slot.Text + "','" + first_endorser.Text + "'," +
            "'" + Second_tester.Text + "','" + Second_Site.Text + "','" + Second_slot.Text + "','" + second_endorser.Text + "','" + Test_system.Text + "'," +
            "'" + Filename(first_verif_link.Text) + "','" + Area.Text + "','" + FirstDate.Text + "','" + SecondDate.Text + "'," +
            "'" + FirstTime.Text + "','" + SecondTime.Text + "')");
                    command.Parameters.Add("@FIRST_DATA", MySqlDbType.VarBinary).Value = SaveFile(first_verif_link.Text);
                    break;
                case 20: // UPDATE 3RD VERIF DATALOG
                    command = new MySqlCommand("UPDATE `boards_for_verification`.`board details` SET `STATUS` = '" + input_status + "',REMARKS = '" + Remarks.Text + "'," +
                        "`THIRD DATALOG` = @THIRD_DATA,`FILENAME 3` = '" + Filename(THIRD_VERIF.Text) + "'" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' AND `PART NUMBER` = '" + Part_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    command.Parameters.Add("@THIRD_DATA", MySqlDbType.VarBinary).Value = SaveFile(THIRD_VERIF.Text);
                    break;
                case 21:  // UPDATE 4TH VERIF DATALOG
                    command = new MySqlCommand("UPDATE `boards_for_verification`.`board details` SET `STATUS` = '" + input_status + "',REMARKS = '" + Remarks.Text + "'," +
                        "`FOURTH DATALOG` = @THIRD_DATA,`FILENAME 4` = '" + Filename(FOURTH_VERIF.Text) + "'" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' AND `PART NUMBER` = '" + Part_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    command.Parameters.Add("@FOURTH_DATA", MySqlDbType.VarBinary).Value = SaveFile(FOURTH_VERIF.Text);
                    break;
                case 22:  // UPDATE 5TH VERIF DATALOG
                    command = new MySqlCommand("UPDATE `boards_for_verification`.`board details` SET `STATUS` = '" + input_status + "',REMARKS = '" + Remarks.Text + "'," +
                        "`FIFTH DATALOG` = @FIFTH_DATA,`FILENAME 5` = '" + Filename(FIFTH_VERIF.Text) + "'" +
                        "WHERE (`SERIAL NUMBER` = '" + Serial_number.Text + "' AND `PART NUMBER` = '" + Part_number.Text + "') ORDER BY `ENDORSEMENT NUMBER` DESC LIMIT 1");
                    command.Parameters.Add("@FIFTH_DATA", MySqlDbType.VarBinary).Value = SaveFile(FIFTH_VERIF.Text);
                    break;
            }
        }
        private void disable_control()
        {
            foreach (Control c in this.Controls)
            {
                if (c == Remarks || c == Save_btn || c == Update_Button || c == Exit_btn || c == Serial_number
                    || c == Second_box || c is RadioButton || c == Part_number || c == STATUS)
                {
                    continue;
                }
                else if (c == First_box)
                {
                    foreach (Control ctrl in First_box.Controls)
                    {
                        if (ctrl is LinkLabel)
                        {
                            continue;
                        }
                        else
                            ctrl.Enabled = false;
                    }
                }
                else if (c is Label)
                    continue;
                else
                {
                    c.Enabled = false;
                }    
            }
        }
        private void enable_control()
        {
            foreach (Control c in this.Controls)
            {
                if (c == First_box)
                {
                    foreach (Control ctrl in First_box.Controls)
                    {
                        ctrl.Enabled = true;
                    }
                }
                else
                    c.Enabled = true;
            }
        }
        private void all_controls()
        {
            foreach (Control c in this.Controls)
            {
                if (c == Update_Button || c == Second_box || c == Failed_during_others || c == Failure_mode_others)
                {
                    continue;
                }
                else
                {
                    c.Visible = true;
                }
            }
        }
        private void clear_all()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox == Serial_number || textBox == Part_number)
                    {
                        continue;
                    }
                    else
                    {
                        textBox.Visible = false;
                        textBox.Clear();
                    }
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
                            if (label == FirstDate || label == FirstTime || label == SecondDate || label == SecondTime)
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
                else if (c is RadioButton)
                {
                    c.Visible = false;
                }
            }
            Test_system.Items.Clear();
            Boards.Items.Clear();
            ClearItemsInTesterBox();
        }
        private void Show_second_grpBox()
        {
            if (first_verif_link.Text.Equals(string.Empty) || First_tester.SelectedIndex == -1
                || string.IsNullOrWhiteSpace(First_board_slot.Text)
                || first_endorser.SelectedIndex == -1)
            {
                foreach(Control c in Second_box.Controls)
                {
                    if (c is LinkLabel)
                    {
                        LinkLabel link = c as LinkLabel;
                        link.Text = null;
                    }
                    else if (c is ComboBox)
                    {
                        ComboBox comboBox = c as ComboBox;
                        comboBox.SelectedIndex = -1;
                    }
                    else if (c is DateTimePicker)
                    {
                        DateTimePicker dateTime = c as DateTimePicker;
                        dateTime.ResetText();
                    }
                    else if (c is TextBox)
                    {
                        TextBox textBox = c as TextBox;
                        textBox.Clear();
                    }
                    else
                    {
                        continue;
                    }
                }
                Second_box.Visible = false;
                return;
            }
            else
            {
                if (First_Site.Items.Count != 0)
                {
                    if (First_Site.SelectedIndex == -1)
                        return;
                    else
                    {
                        Second_box.Visible = true;
                    }
                }
                else
                {
                    Second_box.Visible = true;
                }
            }
        }
        private void slot_first(object sender, EventArgs e)
        {
            Show_second_grpBox();
        }
        private void first_verif_endorser(object sender, EventArgs e)
        {
            Show_second_grpBox();
        }
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Failed_during_indexchanged(object sender, EventArgs e)
        {
            if (Failed_during.SelectedIndex == 2)
                Failed_during_others.Visible = true;          
            else
            {
                Failed_during_others.Visible = false;
                Failed_during_others.Clear();
            }
        }
        private void Failure_mode_indexchanged(object sender, EventArgs e)
        {
            if (Failure_mode.SelectedIndex == 7)
                Failure_mode_others.Visible = true;
            else
            {
                Failure_mode_others.Visible = false;
                Failure_mode_others.Clear();
            }
        }

        private void Key_PartNumber(object sender, KeyEventArgs e)
        {
            UpdateCheck = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckTextBox(Part_number.Text))
                {
                    if (string.IsNullOrWhiteSpace(Serial_number.Text) || string.IsNullOrWhiteSpace(Part_number.Text))
                    {
                        MessageBox.Show("NO INPUT");
                        return;
                    }
                    STATUS.Items.Remove("FOR SECOND VERIF");
                    STATUS.Items.Remove("FOR VERIFICATION");
                    STATUS.Items.Add("FOR SECOND VERIF");
                    STATUS.Items.Add("FOR VERIFICATION");
                    LoadBoardDetails();
                }
            }
        }

        private void First_tester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Test_system.Text == "TMT")
            {
                if (First_tester.Text.Contains("ASL4K"))
                {
                    First_Site.Items.Clear();
                    for (int site = 1; site <= 4; site++)
                    {
                        First_Site.Items.Add(site.ToString());
                    }
                    First_Site.Visible = true;
                }
                else
                {
                    First_Site.Visible = false;
                    Show_second_grpBox();
                }
            }
        }

        private void ThirdVerifClick(object sender, EventArgs e)
        {
            openFileDialog3.InitialDirectory = @"c:\";
            openFileDialog3.Title = "BROWSE A FILE";
            openFileDialog3.FileName = null;
            openFileDialog3.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                THIRD_VERIF.Visible = true;
                THIRD_VERIF.Text = openFileDialog3.FileName;
                //FIRST_DATE = System.IO.File.GetLastWriteTime(openFileDialog1.FileName);
                //FirstDate.Text = FIRST_DATE.ToString("yyyy-MM-dd");
                //FirstTime.Text = FIRST_DATE.ToString("hh:mm tt");
            }
        }

        private void FourthVerif(object sender, EventArgs e)
        {
            openFileDialog4.InitialDirectory = @"c:\";
            openFileDialog4.Title = "BROWSE A FILE";
            openFileDialog4.FileName = null;
            openFileDialog4.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog4.ShowDialog() == DialogResult.OK)
            {
                FOURTH_VERIF.Visible = true;
                FOURTH_VERIF.Text = openFileDialog4.FileName;
                //FIRST_DATE = System.IO.File.GetLastWriteTime(openFileDialog1.FileName);
                //FirstDate.Text = FIRST_DATE.ToString("yyyy-MM-dd");
                //FirstTime.Text = FIRST_DATE.ToString("hh:mm tt");
            }
        }

        private void FifthVerif(object sender, EventArgs e)
        {
            openFileDialog5.InitialDirectory = @"c:\";
            openFileDialog5.Title = "BROWSE A FILE";
            openFileDialog5.FileName = null;
            openFileDialog5.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog5.ShowDialog() == DialogResult.OK)
            {
                FIFTH_VERIF.Visible = true;
                FIFTH_VERIF.Text = openFileDialog5.FileName;
                //FIRST_DATE = System.IO.File.GetLastWriteTime(openFileDialog1.FileName);
                //FirstDate.Text = FIRST_DATE.ToString("yyyy-MM-dd");
                //FirstTime.Text = FIRST_DATE.ToString("hh:mm tt");
            }
        }

        private void ThirdDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Save_btn.Visible == false)
            {
                string DatalogFile = string.Format("C:\\Users\\{0}\\Desktop\\{1}", Environment.UserName, FileName);
                File.WriteAllBytes(DatalogFile, data);
                System.Diagnostics.Process.Start(DatalogFile);
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(THIRD_VERIF.Text);
                }
                catch (Exception me)
                {
                    MessageBox.Show("ERROR " + me.ToString());
                }
            }
        }

        private void FourthDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Save_btn.Visible == false)
            {
                string DatalogFile = string.Format("C:\\Users\\{0}\\Desktop\\{1}", Environment.UserName, FileName);
                File.WriteAllBytes(DatalogFile, data);
                System.Diagnostics.Process.Start(DatalogFile);
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(FOURTH_VERIF.Text);
                }
                catch (Exception me)
                {
                    MessageBox.Show("ERROR " + me.ToString());
                }
            }
        }

        private void FifthDlog(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Save_btn.Visible == false)
            {
                string DatalogFile = string.Format("C:\\Users\\{0}\\Desktop\\{1}", Environment.UserName, FileName);
                File.WriteAllBytes(DatalogFile, data);
                System.Diagnostics.Process.Start(DatalogFile);
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(FIFTH_VERIF.Text);
                }
                catch (Exception me)
                {
                    MessageBox.Show("ERROR " + me.ToString());
                }
            }
        }

        private void status(object sender, EventArgs e)
        {
            if (STATUS.Text == "INSTALL TO TESTER")
            {
                SecondDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                SecondTime.Text = DateTime.Now.ToString("hh:mm tt");
                second_verif_link.Text = "";
            }
            else if (STATUS.Text == "FOR VERIFICATION")
            {
                FirstDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FirstTime.Text = DateTime.Now.ToString("hh:mm tt");
            }
        }

        private void Second_tester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Test_system.Text == "TMT")
            {
                if (Second_tester.Text.Contains("ASL4K"))
                {
                    Second_Site.Items.Clear();
                    for (int site = 1; site <= 4; site++)
                    {
                        Second_Site.Items.Add(site.ToString());
                    }
                    Second_Site.Visible = true;
                }
                else
                {
                    Second_Site.Items.Clear();
                    Second_Site.Visible = false;
                }
            }
        }
        private void ADD_Load(object sender, EventArgs e)
        {
            LoadTesterPlatforms();
            LoadUsers();
        }

        private void LoadUsers()
        {
            commands(15);
            if (Connection.OpenConnectionForBoards())
            {
                MySqlDataReader read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                   first_endorser.Items.Add(read_data.GetString("USERS"));
                   second_endorser.Items.Add(read_data.GetString("USERS"));
                }
                Connection.CloseConnectionForBoards();
            }
            else return;
        }
        private void LoadTesterPlatforms()
        {
            Boards.Items.Clear();
            Test_system.Items.Clear();
            commands(5);
            if (Connection.OpenConnection())
            {
                MySqlDataReader read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    Test_system.Items.Add(read_data.GetString("Tester platforms"));
                }
                Connection.CloseConnection();
            }
            else return;
        }
        private void Test_system_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearItemsInTesterBox();
            Testers();
            Show_second_grpBox();
            if (DoNotLoadBoard == 1)
            {
                return;
            }
            else
                LoadBoards();
        }
        private void ClearItemsInTesterBox()
        {
            First_Site.Items.Clear();
            Second_Site.Items.Clear();
            First_tester.Items.Clear();
            Second_tester.Items.Clear();
        }
        private void First_Site_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show_second_grpBox();
        }
        private void Testers()
        {
            commands(8);
            if (Connection.OpenConnection())
            {
                MySqlDataReader read_data = command.ExecuteReader();
                while (read_data.Read())
                {
                    First_tester.Items.Add(read_data.GetString(Test_system.Text.ToUpper()));
                    Second_tester.Items.Add(read_data.GetString(Test_system.Text.ToUpper()));
                    sites = int.Parse(read_data["SITE"].ToString());
                }
                Connection.CloseConnection();
            }
            else return;
            if (sites != 0)
            {
                for (int CountSite = 1; CountSite <= sites; CountSite++)
                {
                    First_Site.Items.Add(CountSite.ToString());
                    Second_Site.Items.Add(CountSite.ToString());
                }
                Second_Site.Visible = true;
                First_Site.Visible = true;
            }
            else
            {
                First_Site.Visible = false;
                First_Site.Items.Clear();
                Second_Site.Visible = false;
                Second_Site.Items.Clear();
            }
        }
        private void LoadBoards()
        {
            Boards.Items.Clear();
            database = "boards_of_testers";
            tester = Test_system.Text;
            boardQuery = string.Format("SELECT * FROM `{0}`.`{1}`", database, tester.ToLower());
            command = new MySqlCommand(boardQuery, Connection.ConnectBoards);

            if (Connection.OpenConnectionForBoards())
            {
                MySqlDataReader LoadBoards = command.ExecuteReader();
                while (LoadBoards.Read())
                {
                    Boards.Items.Add(LoadBoards.GetString(tester.ToUpper()));
                }
                Connection.CloseConnectionForBoards();
            }
            else return;
        }
    }
}
