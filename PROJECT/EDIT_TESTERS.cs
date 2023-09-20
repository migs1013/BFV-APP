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
using System.Text.RegularExpressions;

namespace PROJECT
{
    public partial class EDIT_TESTERS : Form
    { 
        MySqlCommand Command;
        string List_value, List_AddOrDelete,Tester_platform,FullCommand,PO;
        int Count = 0;
        public EDIT_TESTERS()
        {
            InitializeComponent();
        }

        private void LoadDataToCurrentList(string List1, int CommandNumber)
        {
            Commands(CommandNumber);
            try
            {
                Connection.OpenConnection();
                MySqlDataReader ReadData = Command.ExecuteReader();
                while (ReadData.Read())
                {
                    CurrentList1.Items.Add(ReadData.GetString(List1));
                }
                Connection.CloseConnection();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
        }
        private void PRODUCT_OWNER_FILTER_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AddOrDeleteList1.Items.Clear();
            AddOrDeleteList2.Items.Clear();
            CurrentList1.Items.Clear();
            CurrentList2.Items.Clear();
            if (PRODUCT_OWNER_FILTER.SelectedIndex == 0) return;
            PO = PRODUCT_OWNER_FILTER.Text.Replace(" ", "_");
            Tester_platforms.SelectedIndex = 0;
            LoadDataToCurrentList(PO, 5);
        }

        private void Tester_platforms_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AddOrDeleteList1.Items.Clear();
            AddOrDeleteList2.Items.Clear();
            CurrentList1.Items.Clear();
            CurrentList2.Items.Clear();
            if (Tester_platforms.SelectedIndex == 0) return;
            CurrentList1_text.Text = NewList1.Text = "TESTER"; CurrentList2_text.Text = NewList2.Text = "HOSTNAME";
            PRODUCT_OWNER_FILTER.SelectedIndex = 0;
            Tester_platform = Tester_platforms.Text;
            LoadDataToCurrentList("TESTER", 1);
        }
        private void EDIT_TESTERS_Load(object sender, EventArgs e)
        {
            Tester_platforms.Items.Add("");
            PRODUCT_OWNER_FILTER.Items.Add("");
            Commands(0);
            try
            {
                Connection.OpenConnection();
                MySqlDataReader ReadData = Command.ExecuteReader();
                while (ReadData.Read())
                {
                    Tester_platforms.Items.Add(ReadData.GetString("tester_platforms"));
                }
                Connection.CloseConnection();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
            Commands(4);
            try
            {
                Connection.OpenConnection();
                MySqlDataReader ReadData = Command.ExecuteReader();
                while (ReadData.Read())
                {
                    PRODUCT_OWNER_FILTER.Items.Add(ReadData.GetString("PRODUCT_OWNER"));
                }
                Connection.CloseConnection();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
        }

        private void Option_selection(object sender, EventArgs e)
        {
            FullCommand = null;
            if(Mode.SelectedIndex == 0)
            {
                AddOrRemoveText.Text = "ADD MODE";
                AddOrDeleteList1.Items.Clear();
                CurrentList1.Items.Clear();
                ADD_BTN.Visible = false;
                REMOVE.Text = "REMOVE";
                ADD.Clear();
                ADD_TEXT.Visible = ADD_BUTTON.Visible = ADD.Visible = true;
                ADD_TEXT.Text = "ENTER TESTER ID";
            }
            else if (Mode.SelectedIndex == 1)
            {
                AddOrRemoveText.Text = "DELETE MODE";
                AddOrDeleteList1.Items.Clear();
                CurrentList1.Items.Clear();
                ADD_BTN.Visible = true;
                REMOVE.Text = "<-- REMOVE <--";
                ADD_TEXT.Visible = ADD_BUTTON.Visible = ADD.Visible = false;
            }
        }
        private bool CheckTesterInListBox(ListBox List1, ListBox List2)
        {
            Count = 3;
            for (int CurrentList = 0; CurrentList < List2.Items.Count; CurrentList++)
            {
                List2.SelectedIndex = CurrentList;
                if (ADD.Text == List2.SelectedItem.ToString())
                {
                    List2.SelectedIndex = -1;
                    List1.SelectedIndex = -1;
                    MessageBox.Show(ADD.Text + " ALREADY EXIST TO THE CURRENT LIST, THIS WILL NOT BE ADDED.");
                    ADD.Clear();
                    if (ADD_TEXT.Text == "ENTER TESTER ID") Count = 0; else Count = 1;
                    return false;
                }
            }
            for (int AddToList = 0; AddToList < List1.Items.Count; AddToList++)
            {
                List1.SelectedIndex = AddToList;
                if (ADD.Text == List1.SelectedItem.ToString())
                {
                    List1.SelectedIndex = -1;
                    List2.SelectedIndex = -1;
                    MessageBox.Show(ADD.Text + " ALREADY EXIST IN THE NEW LIST, THIS WILL NOT BE ADDED.");
                    if (ADD_TEXT.Text == "ENTER TESTER ID") Count = 0; else Count = 1;
                    ADD.Clear();
                    return false;
                }
            }
            List2.SelectedIndex = -1;
            List1.SelectedIndex = -1;
            List1.Items.Add(ADD.Text);
            ADD.Clear();
            return true;
        }

        private void AddInput()
        {
            if (string.IsNullOrWhiteSpace(ADD.Text))
            {
                MessageBox.Show("NO INPUT");
                return;
            }
            else
            {
                if (Count == 0 && CheckTesterInListBox(AddOrDeleteList1, CurrentList1))
                {
                    ADD_TEXT.Text = "ENTER HOSTNAME";
                    Count = 1;
                }
                else if (Count == 1 && CheckTesterInListBox(AddOrDeleteList2, CurrentList2))
                {
                    ADD_TEXT.Text = "ENTER TESTER ID";
                    Count = 0;
                }
            }
        }
        private void Add_Tester(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddInput();
            }
        }

        private void ADD_BUTTON_Click(object sender, EventArgs e)
        {
            AddInput();
        }

        private void REMOVE_Click(object sender, EventArgs e)
        {
            if (Mode.SelectedIndex == 0)
            {
                if (AddOrDeleteList1.Items.Count != 0)
                {
                    if (AddOrDeleteList1.SelectedIndex == -1)
                    {
                        MessageBox.Show("PLEASE SELECT AN ITEM TO BE DELETED!");
                        return;
                    }
                    else
                       AddOrDeleteList1.Items.RemoveAt(AddOrDeleteList1.SelectedIndex);
                }
                else
                    MessageBox.Show("LIST TO BE DELETED IS EMPTY");
            }
            else if (Mode.SelectedIndex == 1)
            {
                if (CurrentList1.SelectedIndex < 0)
                    MessageBox.Show("PLEASE SELECT A VALUE FIRST");
                else
                {
                    AddOrDeleteList1.Items.Add(CurrentList1.SelectedItem);
                    CurrentList1.Items.RemoveAt(CurrentList1.SelectedIndex);
                }
            }
            else
                MessageBox.Show("PLEASE CHOOSE MODE FIRST");
        }

        private void CurrentList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            while (Count == 3) return;
            CurrentList2.Items.Clear();
            if (PRODUCT_OWNER_FILTER.SelectedIndex != 0) return;
            Commands(6);
            try
            {
                Connection.OpenConnection();
                MySqlDataReader read_data = Command.ExecuteReader();
                read_data.Read();
                CurrentList2.Items.Add(read_data.GetString("HOSTNAME"));
                Connection.CloseConnection();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (Mode.SelectedIndex == 0)   //FOR ADDING NEW DATA
            {
                if (Tester_platforms.SelectedIndex == -1)
                    MessageBox.Show("PLEASE CHOOSE A TESTER PLATFORM");
                else if (AddOrDeleteList1.Items.Count == 0)
                    MessageBox.Show("LIST IS EMPTY");
                else
                {
                    if (AddOrDeleteList1.Items.Count != AddOrDeleteList2.Items.Count)
                    {
                        MessageBox.Show("PLEASE ENTER THE HOSTNAME OF THE LAST TESTER ON THE LIST");
                        return;
                    }
                    Save_data(2);
                    AddOrDeleteList1.Items.Clear();
                    AddOrDeleteList2.Items.Clear();
                    LoadDataToCurrentList("TESTER", 1);
                }
            }
            else if (Mode.SelectedIndex == 1)    // FOR REMOVING DATA FROM DATABASE
            {
                if (Tester_platforms.SelectedIndex == -1)
                    MessageBox.Show("PLEASE CHOOSE A TESTER PLATFORM");
                else if (AddOrDeleteList1.Items.Count == 0)
                    MessageBox.Show("LIST TO BE DELETED IS EMPTY");
                else
                {
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
                    FullCommand = null;
                    List_AddOrDelete = null;
                    List_value = null;
                    Commands(save);
                    try
                    {
                        Connection.OpenConnection();
                        Command.ExecuteNonQuery();
                        Connection.CloseConnection();
                    }
                    catch (Exception message)
                    {
                        MessageBox.Show(message.ToString());
                        Connection.CloseConnection();
                        return;
                    }
                    AddOrDeleteList1.SelectedIndex = -1;
                    MessageBox.Show("SAVED SUCCESSFULLY TO DATABASE");
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void ADD_BTN_Click(object sender, EventArgs e)
        {
            if (AddOrDeleteList1.Items.Count == 0)
            {
                return;
            }
            else if (AddOrDeleteList1.SelectedIndex == -1)
            {
                MessageBox.Show("PLEASE SELECT AN ITEM TO BE MOVE BACK TO THE CURRENT VALUES");
                return;
            }
            else
            {
                CurrentList1.Items.Add(AddOrDeleteList1.SelectedItem);
                AddOrDeleteList1.Items.RemoveAt(AddOrDeleteList1.SelectedIndex);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Commands(int commads)
        {
            switch (commads)
            {
                case 0:  //LOAD TESTER PLATFORMS
                    Command = new MySqlCommand("SELECT * FROM `hit`.`tester_platforms`", Connection.connect);
                    break;
                case 1:  //LOAD TESTERS
                    Command = new MySqlCommand(string.Format("SELECT `TESTER` FROM `hit`.`hostnames` where `TESTER_PLATFORM` = '{0}'",
                    Tester_platform.ToLower()), Connection.connect);
                    break;
                case 2:  //INSERT NEW TESTER AND HOSTNAME
                    for (int ListCount = 0; ListCount < AddOrDeleteList1.Items.Count; ListCount++)
                    {
                        AddOrDeleteList1.SelectedIndex = ListCount;
                        AddOrDeleteList2.SelectedIndex = ListCount;
                        List_value = string.Format("('{0}','{1}','{2}'),",AddOrDeleteList1.SelectedItem.ToString(),AddOrDeleteList2.SelectedItem.ToString(),Tester_platforms.Text.ToUpper());
                        List_AddOrDelete += List_value;
                    }
                    List_AddOrDelete = List_AddOrDelete.Remove(List_AddOrDelete.Length - 1, 1);
                    if (Tester_platforms.SelectedIndex != 0)
                    {
                        FullCommand = string.Format("INSERT INTO `hit`.`hostnames`(`TESTER`,`HOSTNAME`,`TESTER_PLATFORM`) VALUES {0}",List_AddOrDelete);
                        Command = new MySqlCommand(FullCommand, Connection.connect);                                     
                    }
                    break;
                case 3:  //DELETE USERS, TESTERS, OR BOARDS
                    for (int ListCount = 0; ListCount < AddOrDeleteList1.Items.Count; ListCount++)
                    {
                        AddOrDeleteList1.SelectedIndex = ListCount;
                        List_value = AddOrDeleteList1.SelectedItem.ToString();
                        List_AddOrDelete = string.Format("DELETE FROM `hit`.`{0}` WHERE (`{1}` = '{2}');",
                        Tester_platform.ToLower(), Tester_platform.ToUpper(), List_value);

                        FullCommand += List_AddOrDelete;
                    }
                    break;
                case 4: // LOAD PRODUCT OWNER
                    Command = new MySqlCommand("SELECT * FROM `hit`.`product_owner`", Connection.connect);
                    break;
                case 5:  // LOAD DEVICE
                    Command = new MySqlCommand(string.Format("SELECT * FROM `hit`.`{0}`", PO.ToLower()), Connection.connect);
                    break;
                case 6:   //LOAD HOSTNAME
                    Command = new MySqlCommand(string.Format("SELECT `HOSTNAME` FROM `hit`.`hostnames` where `TESTER` = '{0}'", CurrentList1.Text), Connection.connect);
                    break;
            }
        }
    }
}
