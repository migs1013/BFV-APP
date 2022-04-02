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

namespace PROJECT
{
    public partial class EDIT_TESTERS : Form
    { 
        MySqlCommand Command;
        string testers = "boards_for_verification";
        string boards = "boards_of_testers";
        string List_value, List_AddOrDelete,database,Tester_platform,FullCommand,Values;
        public EDIT_TESTERS()
        {
            InitializeComponent();
        }
        private void LoadTesters()
        {
            AddOrDelete.Items.Clear();
            Current_List.Items.Clear();
            database = testers;
            Tester_platform = Tester_platforms.Text;
            Commands(1);
            if (Connection.OpenConnection())
            {
                MySqlDataReader read = Command.ExecuteReader();
                while (read.Read())
                {
                    Current_List.Items.Add(read.GetString(Tester_platform.ToUpper()));
                }
                Connection.CloseConnection();
            }
        }

        private void LoadBoards()
        {
            AddOrDelete.Items.Clear();
            Current_List.Items.Clear();
            database = boards;
            Tester_platform = Tester_platforms.Text;
            Commands(1);
            if (Connection.OpenConnectionForBoards())
            {
                MySqlDataReader readBoards = Command.ExecuteReader();
                while (readBoards.Read())
                {
                    Current_List.Items.Add(readBoards.GetString(Tester_platform.ToUpper()));
                }
                Connection.CloseConnectionForBoards();
            }
        }

        private void EDIT_TESTERS_Load(object sender, EventArgs e)
        {
            Commands(0);
            if (Connection.OpenConnection())
            {
                MySqlDataReader read_data = Command.ExecuteReader();
                while (read_data.Read())
                {
                    Tester_platforms.Items.Add(read_data.GetString("Tester platforms"));
                }
                Connection.CloseConnection();
            }
        }

        private void Option_selection(object sender, EventArgs e)
        {
            FullCommand = null;
            if(Mode.SelectedIndex == 0)
            {
                AddOrRemoveText.Text = "ADD MODE";
                AddOrDelete.Items.Clear();
                Current_List.Items.Clear();
                ADD_BTN.Visible = false;
                REMOVE.Text = "REMOVE";
                ADD.Clear();
                label3.Visible = true;
                ADD.Visible = true;
                Board.Checked = false;
                Tester.Checked = false;
            }
            else
            {
                AddOrRemoveText.Text = "DELETE MODE";
                AddOrDelete.Items.Clear();
                Current_List.Items.Clear();
                ADD_BTN.Visible = true;
                REMOVE.Text = "<-- REMOVE <--";
                label3.Visible = false;
                ADD.Visible = false;
                Board.Checked = false;
                Tester.Checked = false;
            }
        }
        private void CheckTextInListBox()
        {
            for (int CurrentList = 0; CurrentList < Current_List.Items.Count; CurrentList++)
            {
                Current_List.SelectedIndex = CurrentList;
                if (ADD.Text == Current_List.SelectedItem.ToString())
                {
                    Current_List.SelectedIndex = -1;
                    AddOrDelete.SelectedIndex = -1;
                    MessageBox.Show(ADD.Text + " ALREADY EXIST TO THE CURRENT LIST, THIS WILL NOT BE ADDED.");
                    return;
                }
            }
            for (int AddToList = 0; AddToList < AddOrDelete.Items.Count; AddToList++)
            {
                AddOrDelete.SelectedIndex = AddToList;
                if (ADD.Text == AddOrDelete.SelectedItem.ToString())
                {
                    AddOrDelete.SelectedIndex = -1;
                    Current_List.SelectedIndex = -1;
                    MessageBox.Show(ADD.Text + " ALREADY EXIST IN THE LIST, THIS WILL NOT BE ADDED.");
                    return;
                }
            }
            Current_List.SelectedIndex = -1;
            AddOrDelete.SelectedIndex = -1;
            AddOrDelete.Items.Add(ADD.Text);
            ADD.Clear();
        }
        private void Add_Tester(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(ADD.Text))
                {
                    MessageBox.Show("NO INPUT");
                    return;
                }
                else
                {
                    if (Tester.Checked)
                    {
                        if (ADD.Text.Contains(Tester_platforms.Text))
                        {
                            CheckTextInListBox();
                        }
                        else if(Tester_platforms.Text == "TMT")
                        {
                            if (ADD.Text.Contains("ASL1K") || ADD.Text.Contains("ASL4K"))
                            {
                                CheckTextInListBox();
                            }
                            else
                            {
                                MessageBox.Show("INVALID TESTER NAME");
                                ADD.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("INVALID TESTER NAME");
                            ADD.Clear();
                        }
                    }
                    else
                    {
                        CheckTextInListBox();
                    }
                }
            }
        }

        private void REMOVE_Click(object sender, EventArgs e)
        {
            if (Mode.SelectedIndex == 0)
            {
                if (AddOrDelete.Items.Count != 0)
                {
                    if (AddOrDelete.SelectedIndex == -1)
                    {
                        MessageBox.Show("PLEASE SELECT AN ITEM TO BE DELETED!");
                        return;
                    }
                    else
                       AddOrDelete.Items.RemoveAt(AddOrDelete.SelectedIndex);
                }
                else
                    MessageBox.Show("LIST TO BE DELETED IS EMPTY");
            }
            else if (Mode.SelectedIndex == 1)
            {
                if (Current_List.SelectedIndex < 0)
                    MessageBox.Show("PLEASE SELECT A VALUE FIRST");
                else
                {
                    AddOrDelete.Items.Add(Current_List.SelectedItem);
                    Current_List.Items.RemoveAt(Current_List.SelectedIndex);
                }
            }
            else
                MessageBox.Show("PLEASE CHOOSE MODE FIRST");
        }
        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (Mode.SelectedIndex == 0)   //FOR ADDING NEW DATA
            {
                if (Board.Checked == false && Tester.Checked == false)
                    MessageBox.Show("PLEASE CHOOSE IF BOARD OR TESTER");
                else if (Tester_platforms.SelectedIndex == -1)
                    MessageBox.Show("PLEASE CHOOSE A TESTER PLATFORM");
                else if (AddOrDelete.Items.Count == 0)
                    MessageBox.Show("LIST IS EMPTY");
                else
                {
                    if (Tester.Checked)
                        database = testers;
                    else
                        database = boards;
                    Save_data(2);
                }
            }
            else if (Mode.SelectedIndex == 1)    // FOR REMOVING DATA FROM DATABASE
            {
                if (Board.Checked == false && Tester.Checked == false)
                    MessageBox.Show("PLEASE CHOOSE IF BOARD OR TESTER");
                else if (Tester_platforms.SelectedIndex == -1)
                    MessageBox.Show("PLEASE CHOOSE A TESTER PLATFORM");
                else if (AddOrDelete.Items.Count == 0)
                    MessageBox.Show("LIST TO BE DELETED IS EMPTY");
                else
                {
                    if (Tester.Checked)
                        database = testers;
                    else
                        database = boards;
                    Save_data(3);
                }
            }
            else
                MessageBox.Show("PLEASE CHOOSE MODE");
        }
        private void Save_data(int save)  //FOR SAVING THE DATA
        {
            DialogResult yes_no = MessageBox.Show("ARE YOU SURE YOU WANT TO SAVE IT?", "CONFIRMATION", MessageBoxButtons.YesNo);
            switch (yes_no)
            {
                case DialogResult.Yes:
                    if (Tester.Checked)
                        Tester_platform = Tester_platforms.Text;
                    else
                    {
                        if (Tester_platforms.Text == "ASL1K" || Tester_platforms.Text == "ASL4K")
                            Tester_platform = "tmt";
                        else
                            Tester_platform = Tester_platforms.Text;
                    }
                    FullCommand = null;
                    List_AddOrDelete = null;
                    List_value = null;
                    Commands(save);
                    if (Tester.Checked)
                    {
                        if (Connection.OpenConnection())
                        {
                            try
                            {
                                Command.ExecuteNonQuery();
                                Connection.CloseConnection();
                            }
                            catch (Exception message)
                            {
                                MessageBox.Show(message.ToString());
                                Connection.CloseConnection();
                                return;
                            }
                        }
                        else return;
                    }
                    else
                    {
                        if (Connection.OpenConnectionForBoards())
                        {
                            try
                            {
                                Command.ExecuteNonQuery();
                                Connection.CloseConnectionForBoards();
                            }
                            catch (Exception message) 
                            { 
                                MessageBox.Show(message.ToString());
                                Connection.CloseConnectionForBoards();
                                return;
                            }
                        }
                        else return;
                    }

                    AddOrDelete.SelectedIndex = -1;
                    MessageBox.Show("SAVED SUCCESSFULLY TO DATABASE");
                    if (Tester.Checked)
                        LoadTesters();
                    else
                        LoadBoards();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void ADD_BTN_Click(object sender, EventArgs e)
        {
            if (AddOrDelete.Items.Count == 0)
            {
                return;
            }
            else if (AddOrDelete.SelectedIndex == -1)
            {
                MessageBox.Show("PLEASE SELECT AN ITEM TO BE MOVE BACK TO THE CURRENT VALUES");
                return;
            }
            else
            {
                Current_List.Items.Add(AddOrDelete.SelectedItem);
                AddOrDelete.Items.RemoveAt(AddOrDelete.SelectedIndex);
            }
        }

        private void Tester_platforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tester.Checked)
                LoadTesters();
            else if (Board.Checked)
                LoadBoards();
            else
                return;
        }

        private void Tester_mode(object sender, EventArgs e)
        {
            if (Tester_platforms.SelectedIndex == -1)
                return;
            LoadTesters();
        }

        private void Boards_mode(object sender, EventArgs e)
        {
            if (Tester_platforms.SelectedIndex == -1)
                return;
            LoadBoards();
        }
        private void Commands(int commads)
        {
            switch (commads)
            {
                case 0:  //LOAD TESTER PLATFORMS
                    Command = new MySqlCommand("SELECT * FROM `boards_for_verification`.`tester platforms`", Connection.connect);
                    break;

                case 1:  //LOAD TESTERS OR BOARDS IN THE TESTER PLATFORM
                    if (Tester.Checked)
                        Command = new MySqlCommand(string.Format("SELECT * FROM `{0}`.`{1}`",
                        database, Tester_platform.ToLower()), Connection.connect);               //LOAD TESTER
                    else
                        Command = new MySqlCommand(string.Format("SELECT * FROM `{0}`.`{1}`",    //LOAD BOARD
                        database, Tester_platform.ToLower()), Connection.ConnectBoards);
                    break;

                case 2:  //INSERT NEW TESTERS OR BOARDS IN THE CHOSEN TESTER PLATFORM
                    for (int ListCount = 0; ListCount < AddOrDelete.Items.Count; ListCount++)
                    {
                        AddOrDelete.SelectedIndex = ListCount;
                        Values = AddOrDelete.SelectedItem.ToString();
                        List_value = string.Format("('{0}'),",Values);
                        List_AddOrDelete = List_AddOrDelete + List_value;
                    }
                    List_AddOrDelete = List_AddOrDelete.Remove(List_AddOrDelete.Length - 1, 1);
                    FullCommand = string.Format("INSERT INTO `{0}`.`{1}`(`{2}`) VALUES {3}"
                        , database, Tester_platform.ToLower(), Tester_platform.ToUpper(), List_AddOrDelete);
                    if (Tester.Checked)
                        Command = new MySqlCommand(FullCommand, Connection.connect);   //INSERT NEW TESTER
                    else
                        Command = new MySqlCommand(FullCommand, Connection.ConnectBoards);   //INSERT NEW BOARDS
                    break;

                case 3:  ///DELETE TESTERS OR BOARDS IN THE CHOSEN TESTER PLATFORM
                    for (int ListCount = 0; ListCount < AddOrDelete.Items.Count; ListCount++)
                    {
                        AddOrDelete.SelectedIndex = ListCount;
                        List_value = AddOrDelete.SelectedItem.ToString();
                        List_AddOrDelete = string.Format("DELETE FROM `{0}`.`{1}` WHERE (`{2}` = '{3}');",
                        database, Tester_platform.ToLower(), Tester_platform.ToUpper(), List_value);
                        FullCommand = FullCommand + List_AddOrDelete;
                    }
                    if (Tester.Checked)
                        Command = new MySqlCommand(FullCommand, Connection.connect);    //DELETE TESTER
                    else
                        Command = new MySqlCommand(FullCommand, Connection.ConnectBoards);   //DELETE BOARD
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
