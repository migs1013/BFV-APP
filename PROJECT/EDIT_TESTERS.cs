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
        string List_value, List_AddOrDelete,FullCommand,category;
        int command;
        public EDIT_TESTERS()
        {
            InitializeComponent();
        }

        private void LoadDataToCurrentList(string Column1,string Column2, int CommandNumber)
        {
            Commands(CommandNumber);
            try
            {
                Connection.OpenConnection();
                MySqlDataReader ReadData = Command.ExecuteReader();
                if (Column2 == "NULL")
                {
                    while (ReadData.Read())
                    {
                        CURRENT_LIST.Items.Add(new ListViewItem(new[] { ReadData.GetString(Column1)}));
                    }
                }
                else
                {
                    while (ReadData.Read())
                    {
                        CURRENT_LIST.Items.Add(new ListViewItem(new[] { ReadData.GetString(Column1), ReadData.GetString(Column2) }));
                    }
                }
                Connection.CloseConnection();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                Connection.CloseConnection();
            }
        }

        
        private bool CheckInputInListView(int Check,ListView List,TextBox Input)
        {
            foreach (ListViewItem Current in List.Items)
            {
                if (Current.SubItems[Check].Text == Input.Text)
                {
                    MessageBox.Show("DATA YOU ENTERED IS ALREADY THERE, DOUBLE CHECK INPUTS");
                    return false;
                }
                else continue;
            }
            return true;
        }
        private void AddInput()
        {
            if (LIST_OPTION.SelectedIndex == -1) return;
            if (CATEGORY.SelectedIndex == 0)
            {
                if (string.IsNullOrWhiteSpace(ADD.Text))
                {
                    MessageBox.Show("NO INPUT"); return;
                }
                if (CheckInputInListView(0, CURRENT_LIST, ADD) == true && CheckInputInListView(0, NEWLIST, ADD) == true)
                {
                    NEWLIST.Items.Add(new ListViewItem(new[] { ADD.Text }));
                }
            }
            else if (CATEGORY.SelectedIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(ADD.Text) || string.IsNullOrWhiteSpace(HOSTNAME_TEXTBOX.Text))
                {
                    MessageBox.Show("ENTER TESTER AND HOSTNAME"); return;
                }
                if (CheckInputInListView(0, CURRENT_LIST, ADD) == true && CheckInputInListView(0, NEWLIST, ADD) == true
                    && CheckInputInListView(1, CURRENT_LIST, HOSTNAME_TEXTBOX) == true && CheckInputInListView(1, CURRENT_LIST, HOSTNAME_TEXTBOX) == true)
                {
                    NEWLIST.Items.Add(new ListViewItem(new[] { ADD.Text, HOSTNAME_TEXTBOX.Text }));
                }
            }
            else return;
            ADD.Clear();
            HOSTNAME_TEXTBOX.Clear();
            ADD.Focus();
        }
        private void Add_Tester(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddInput();
            }
        }

        private void HOSTNAME_TEXTBOX_KeyDown(object sender, KeyEventArgs e)
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
                if (NEWLIST.Items.Count > 0)
                {
                    try
                    {
                        NEWLIST.Items.Remove(NEWLIST.SelectedItems[0]);
                    }
                    catch
                    {
                        MessageBox.Show("PLEASE SELECT AN ITEM ON THE NEW LIST");
                    }
                }
                else
                    MessageBox.Show("LIST TO BE DELETED IS EMPTY");
            }
            else if (Mode.SelectedIndex == 1)
            {
                try
                {
                    if (CATEGORY.SelectedIndex == 0)
                    {
                        NEWLIST.Items.Add(new ListViewItem(new[] { CURRENT_LIST.SelectedItems[0].Text }));
                    }
                    else
                    {
                        NEWLIST.Items.Add(new ListViewItem(new[] { CURRENT_LIST.SelectedItems[0].SubItems[0].Text, CURRENT_LIST.SelectedItems[0].SubItems[1].Text }));
                    }
                    CURRENT_LIST.Items.Remove(CURRENT_LIST.SelectedItems[0]);
                }
                catch
                {
                    MessageBox.Show("SELECT AN ITEM ON CURRENT LIST");
                }
            }
        }
        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (Mode.SelectedIndex == 0)   //FOR ADDING NEW DATA
            {
                if (CATEGORY.SelectedIndex == -1)
                    MessageBox.Show("PLEASE CHOOSE CATEGORY");
                else if (NEWLIST.Items.Count == 0)
                    MessageBox.Show("LIST IS EMPTY");
                else
                {
                    Save_data(2);
                }
            }
            else if (Mode.SelectedIndex == 1)    // FOR REMOVING DATA FROM DATABASE
            {
                if (CATEGORY.SelectedIndex == -1)
                    MessageBox.Show("PLEASE CHOOSE A CATEGORY");
                else if (NEWLIST.Items.Count == 0)
                    MessageBox.Show("LIST TO BE DELETED IS EMPTY");
                else
                {
                    Save_data(3);
                }
            }
            else
                MessageBox.Show("PLEASE CHOOSE MODE");
            
        }

        private void ClearAllList()
        {
            ADD.Clear();
            NEWLIST.Items.Clear();
            LIST_OPTION.Items.Clear();
            CURRENT_LIST.Items.Clear();
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
                    MessageBox.Show("SAVED SUCCESSFULLY TO DATABASE");
                    NEWLIST.Items.Clear();
                    CURRENT_LIST.Items.Clear();
                    if (CATEGORY.SelectedIndex == 0) LoadDataToCurrentList("DEVICE", "NULL", 0);
                    else LoadDataToCurrentList("TESTER", "HOSTNAME", 6);
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void LIST_OPTION_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CURRENT_LIST.Items.Clear();
            NEWLIST.Items.Clear();
            if (CATEGORY.Text == "TESTER/HOSTNAME")
            {
                LoadDataToCurrentList("TESTER", "HOSTNAME", 6);
            }
            else
            {
                LoadDataToCurrentList("DEVICE", "NULL", 0);
            }
            ADD.Focus();
        }

        private void Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            FullCommand = null;
            option_list.Text = "";
            ShowTextBox();
        }

        private void ShowTextBox()
        {
            if (Mode.SelectedIndex == 1)
            {
                AddOrRemoveText.Text = "DELETE MODE";
                UNDO_BUTTON.Visible = true;
                HOSTNAME_LABEL.Visible = HOSTNAME_TEXTBOX.Visible = ADD_TEXT.Visible = ADD_BUTTON.Visible = ADD.Visible = false;
            }
            if (CATEGORY.SelectedIndex == 0)
            {
                command = 5; category = "PRODUCT_OWNER"; COLUMN1_NEW.Text = TESTER.Text = "DEVICE"; COLUMN2_NEW.Text = HOSTNAME.Text = "";
                option_list.Text = "PRODUCT OWNERS"; ADD_TEXT.Text = "ENTER GENERIC PN";
                if (Mode.SelectedIndex == 0)
                {
                    ADD.Visible = ADD_BUTTON.Visible = ADD_TEXT.Visible = true;
                    HOSTNAME_LABEL.Visible = HOSTNAME_TEXTBOX.Visible = false;
                    AddOrRemoveText.Text = "ADD MODE";
                    UNDO_BUTTON.Visible = false;
                }
            }
            else if (CATEGORY.SelectedIndex == 1)
            {
                command = 1; category = "TESTER_PLATFORM"; COLUMN1_NEW.Text = TESTER.Text = "TESTER"; COLUMN2_NEW.Text = HOSTNAME.Text = "HOSTNAME";
                option_list.Text = "TESTER PLATFORMS"; ADD_TEXT.Text = "ENTER TESTER ID"; HOSTNAME_LABEL.Text = "ENTER HOSTNAME";
                if (Mode.SelectedIndex == 0)
                {
                    ADD.Visible = ADD_BUTTON.Visible = ADD_TEXT.Visible = HOSTNAME_LABEL.Visible = HOSTNAME_TEXTBOX.Visible = true;
                    AddOrRemoveText.Text = "ADD MODE";
                    UNDO_BUTTON.Visible = false;
                }
            }
        }

        private void CATEGORY_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowTextBox();
            ClearAllList();
            try
            {
                Commands(command);
                Connection.OpenConnection();
                MySqlDataReader read_data = Command.ExecuteReader();
                while (read_data.Read())
                {
                    LIST_OPTION.Items.Add(read_data.GetString(category));
                }
                Connection.CloseConnection();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                Connection.CloseConnection();
            }
        }

        private void UNDO_BTN_Click(object sender, EventArgs e)
        {
            if (NEWLIST.Items.Count > 0)
            {
                try
                {
                    if (CATEGORY.SelectedIndex == 0)
                    {
                        CURRENT_LIST.Items.Add(new ListViewItem(new[] { NEWLIST.SelectedItems[0].Text }));
                    }
                    else
                    {
                        CURRENT_LIST.Items.Add(new ListViewItem(new[] { NEWLIST.SelectedItems[0].SubItems[0].Text, NEWLIST.SelectedItems[0].SubItems[1].Text }));
                    }
                    NEWLIST.Items.Remove(NEWLIST.SelectedItems[0]);
                }
                catch
                {
                    MessageBox.Show("SELECT A VALUE FIRST IN LIST TO BE ADDED");
                }
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
                case 0:  //LOAD DEVICE
                    Command = new MySqlCommand(string.Format("SELECT `DEVICE` FROM `hit`.`device` where `PRODUCT_OWNER` = '{0}'",LIST_OPTION.Text), Connection.connect);
                    break;
                case 1:  //LOAD TESTER PLATFORM
                    Command = new MySqlCommand("SELECT `TESTER_PLATFORM` FROM `hit`.`hostnames` GROUP BY `TESTER_PLATFORM`", Connection.connect);
                    break;
                case 2:  //INSERT NEW TESTER AND HOSTNAME
                    if (CATEGORY.SelectedIndex == 1)
                    {
                        foreach (ListViewItem Current in NEWLIST.Items)
                        {
                            List_value = string.Format("('{0}','{1}','{2}'),", Current.SubItems[0].Text, Current.SubItems[1].Text, LIST_OPTION.Text);
                            List_AddOrDelete += List_value;
                        }
                        List_AddOrDelete = List_AddOrDelete.Remove(List_AddOrDelete.Length - 1, 1);
                        FullCommand = string.Format("INSERT INTO `hit`.`hostnames`(`TESTER`,`HOSTNAME`,`TESTER_PLATFORM`) VALUES {0}", List_AddOrDelete);
                    }
                    else
                    {
                        foreach (ListViewItem Current in NEWLIST.Items)
                        {
                            List_value = string.Format("('{0}','{1}'),", LIST_OPTION.Text, Current.SubItems[0].Text);
                            List_AddOrDelete += List_value;
                        }
                        List_AddOrDelete = List_AddOrDelete.Remove(List_AddOrDelete.Length - 1, 1);
                        FullCommand = string.Format("INSERT INTO `hit`.`device`(`PRODUCT_OWNER`,`DEVICE`) VALUES {0}", List_AddOrDelete);
                    }
                    Command = new MySqlCommand(FullCommand, Connection.connect);
                    break;
                case 3:  //DELETE DATA
                    if (CATEGORY.SelectedIndex == 0)
                    {
                        foreach (ListViewItem Current in NEWLIST.Items)
                        {
                            List_value = string.Format("DELETE FROM `hit`.`device` where `DEVICE` = '{0}';", Current.SubItems[0].Text);
                            List_AddOrDelete += List_value;
                        }
                    }
                    else if (CATEGORY.SelectedIndex == 1)
                    {
                        foreach (ListViewItem Current in NEWLIST.Items)
                        {
                            List_value = string.Format("DELETE FROM `hit`.`hostnames` where `TESTER` = '{0}';", Current.SubItems[0].Text);
                            List_AddOrDelete += List_value;
                        }
                    }
                    FullCommand = List_AddOrDelete;
                    Command = new MySqlCommand(FullCommand, Connection.connect);
                    break;
                case 4: // NOT USE
                    
                    break;
                case 5:  // LOAD PRODUCT OWNERS
                    Command = new MySqlCommand("SELECT `PRODUCT_OWNER` FROM `hit`.`device` group by `PRODUCT_OWNER`", Connection.connect);
                    break;
                case 6:   //LOAD TESTER AND HOSTNAME
                    Command = new MySqlCommand(string.Format("SELECT `TESTER`,`HOSTNAME` FROM `hit`.`hostnames` where `TESTER_PLATFORM` = '{0}'", LIST_OPTION.Text), Connection.connect);
                    break;
            }
        }
    }
}
