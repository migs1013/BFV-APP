
namespace PROJECT
{
    partial class EDIT_TESTERS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EDIT_TESTERS));
            this.ADD = new System.Windows.Forms.TextBox();
            this.ADD_TEXT = new System.Windows.Forms.Label();
            this.Save_btn = new System.Windows.Forms.Button();
            this.BACK = new System.Windows.Forms.Button();
            this.Mode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.REMOVE = new System.Windows.Forms.Button();
            this.AddOrRemoveText = new System.Windows.Forms.Label();
            this.UNDO_BUTTON = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.NewList2 = new System.Windows.Forms.Label();
            this.ADD_BUTTON = new System.Windows.Forms.Button();
            this.CURRENT_LIST = new System.Windows.Forms.ListView();
            this.TESTER = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HOSTNAME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CATEGORY = new System.Windows.Forms.ComboBox();
            this.LIST_OPTION = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.option_list = new System.Windows.Forms.Label();
            this.NEWLIST = new System.Windows.Forms.ListView();
            this.COLUMN1_NEW = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COLUMN2_NEW = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HOSTNAME_TEXTBOX = new System.Windows.Forms.TextBox();
            this.HOSTNAME_LABEL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ADD
            // 
            this.ADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ADD.Location = new System.Drawing.Point(167, 94);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(167, 20);
            this.ADD.TabIndex = 2;
            this.ADD.Visible = false;
            this.ADD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Add_Tester);
            // 
            // ADD_TEXT
            // 
            this.ADD_TEXT.AutoSize = true;
            this.ADD_TEXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADD_TEXT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.ADD_TEXT.Location = new System.Drawing.Point(10, 95);
            this.ADD_TEXT.Name = "ADD_TEXT";
            this.ADD_TEXT.Size = new System.Drawing.Size(0, 16);
            this.ADD_TEXT.TabIndex = 3;
            this.ADD_TEXT.Visible = false;
            // 
            // Save_btn
            // 
            this.Save_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Save_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Save_btn.Location = new System.Drawing.Point(11, 444);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(117, 41);
            this.Save_btn.TabIndex = 6;
            this.Save_btn.Text = "SAVE";
            this.Save_btn.UseVisualStyleBackColor = false;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // BACK
            // 
            this.BACK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BACK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BACK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BACK.Location = new System.Drawing.Point(535, 444);
            this.BACK.Name = "BACK";
            this.BACK.Size = new System.Drawing.Size(115, 41);
            this.BACK.TabIndex = 9;
            this.BACK.Text = "BACK";
            this.BACK.UseVisualStyleBackColor = false;
            this.BACK.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Mode
            // 
            this.Mode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mode.FormattingEnabled = true;
            this.Mode.Items.AddRange(new object[] {
            "ADD",
            "DELETE"});
            this.Mode.Location = new System.Drawing.Point(186, 8);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(167, 21);
            this.Mode.Sorted = true;
            this.Mode.TabIndex = 10;
            this.Mode.SelectedIndexChanged += new System.EventHandler(this.Mode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "CHOOSE MODE";
            // 
            // REMOVE
            // 
            this.REMOVE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.REMOVE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.REMOVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REMOVE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.REMOVE.Location = new System.Drawing.Point(274, 329);
            this.REMOVE.Name = "REMOVE";
            this.REMOVE.Size = new System.Drawing.Size(112, 30);
            this.REMOVE.TabIndex = 12;
            this.REMOVE.Text = "REMOVE";
            this.REMOVE.UseVisualStyleBackColor = false;
            this.REMOVE.Click += new System.EventHandler(this.REMOVE_Click);
            // 
            // AddOrRemoveText
            // 
            this.AddOrRemoveText.AutoSize = true;
            this.AddOrRemoveText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddOrRemoveText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.AddOrRemoveText.Location = new System.Drawing.Point(436, 73);
            this.AddOrRemoveText.Name = "AddOrRemoveText";
            this.AddOrRemoveText.Size = new System.Drawing.Size(0, 25);
            this.AddOrRemoveText.TabIndex = 13;
            // 
            // UNDO_BUTTON
            // 
            this.UNDO_BUTTON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.UNDO_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UNDO_BUTTON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UNDO_BUTTON.ForeColor = System.Drawing.Color.Black;
            this.UNDO_BUTTON.Location = new System.Drawing.Point(274, 293);
            this.UNDO_BUTTON.Name = "UNDO_BUTTON";
            this.UNDO_BUTTON.Size = new System.Drawing.Size(112, 30);
            this.UNDO_BUTTON.TabIndex = 16;
            this.UNDO_BUTTON.Text = "UNDO";
            this.UNDO_BUTTON.UseVisualStyleBackColor = false;
            this.UNDO_BUTTON.Visible = false;
            this.UNDO_BUTTON.Click += new System.EventHandler(this.UNDO_BTN_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label.Location = new System.Drawing.Point(66, 184);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(146, 16);
            this.label.TabIndex = 25;
            this.label.Text = "LIST TO BE ADDED";
            // 
            // NewList2
            // 
            this.NewList2.AutoSize = true;
            this.NewList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewList2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.NewList2.Location = new System.Drawing.Point(458, 184);
            this.NewList2.Name = "NewList2";
            this.NewList2.Size = new System.Drawing.Size(118, 16);
            this.NewList2.TabIndex = 26;
            this.NewList2.Text = "CURRENT LIST";
            // 
            // ADD_BUTTON
            // 
            this.ADD_BUTTON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ADD_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ADD_BUTTON.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADD_BUTTON.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ADD_BUTTON.Location = new System.Drawing.Point(218, 146);
            this.ADD_BUTTON.Name = "ADD_BUTTON";
            this.ADD_BUTTON.Size = new System.Drawing.Size(65, 28);
            this.ADD_BUTTON.TabIndex = 4;
            this.ADD_BUTTON.Text = "ADD";
            this.ADD_BUTTON.UseVisualStyleBackColor = false;
            this.ADD_BUTTON.Visible = false;
            this.ADD_BUTTON.Click += new System.EventHandler(this.ADD_BUTTON_Click);
            // 
            // CURRENT_LIST
            // 
            this.CURRENT_LIST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CURRENT_LIST.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TESTER,
            this.HOSTNAME});
            this.CURRENT_LIST.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CURRENT_LIST.FullRowSelect = true;
            this.CURRENT_LIST.GridLines = true;
            this.CURRENT_LIST.HideSelection = false;
            this.CURRENT_LIST.Location = new System.Drawing.Point(392, 209);
            this.CURRENT_LIST.Name = "CURRENT_LIST";
            this.CURRENT_LIST.Size = new System.Drawing.Size(258, 229);
            this.CURRENT_LIST.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.CURRENT_LIST.TabIndex = 30;
            this.CURRENT_LIST.UseCompatibleStateImageBehavior = false;
            this.CURRENT_LIST.View = System.Windows.Forms.View.Details;
            // 
            // TESTER
            // 
            this.TESTER.Text = "";
            this.TESTER.Width = 130;
            // 
            // HOSTNAME
            // 
            this.HOSTNAME.Text = "";
            this.HOSTNAME.Width = 120;
            // 
            // CATEGORY
            // 
            this.CATEGORY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CATEGORY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CATEGORY.FormattingEnabled = true;
            this.CATEGORY.Items.AddRange(new object[] {
            "PRODUCT OWNER",
            "TESTER/HOSTNAME"});
            this.CATEGORY.Location = new System.Drawing.Point(186, 35);
            this.CATEGORY.Name = "CATEGORY";
            this.CATEGORY.Size = new System.Drawing.Size(167, 21);
            this.CATEGORY.Sorted = true;
            this.CATEGORY.TabIndex = 31;
            this.CATEGORY.SelectionChangeCommitted += new System.EventHandler(this.CATEGORY_SelectionChangeCommitted);
            // 
            // LIST_OPTION
            // 
            this.LIST_OPTION.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LIST_OPTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LIST_OPTION.FormattingEnabled = true;
            this.LIST_OPTION.Location = new System.Drawing.Point(186, 62);
            this.LIST_OPTION.Name = "LIST_OPTION";
            this.LIST_OPTION.Size = new System.Drawing.Size(167, 21);
            this.LIST_OPTION.Sorted = true;
            this.LIST_OPTION.TabIndex = 32;
            this.LIST_OPTION.SelectionChangeCommitted += new System.EventHandler(this.LIST_OPTION_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "CHOOSE CATEGORY";
            // 
            // option_list
            // 
            this.option_list.AutoSize = true;
            this.option_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.option_list.Location = new System.Drawing.Point(10, 63);
            this.option_list.Name = "option_list";
            this.option_list.Size = new System.Drawing.Size(0, 16);
            this.option_list.TabIndex = 34;
            // 
            // NEWLIST
            // 
            this.NEWLIST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NEWLIST.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.COLUMN1_NEW,
            this.COLUMN2_NEW});
            this.NEWLIST.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NEWLIST.FullRowSelect = true;
            this.NEWLIST.GridLines = true;
            this.NEWLIST.HideSelection = false;
            this.NEWLIST.Location = new System.Drawing.Point(10, 203);
            this.NEWLIST.Name = "NEWLIST";
            this.NEWLIST.Size = new System.Drawing.Size(258, 229);
            this.NEWLIST.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.NEWLIST.TabIndex = 35;
            this.NEWLIST.UseCompatibleStateImageBehavior = false;
            this.NEWLIST.View = System.Windows.Forms.View.Details;
            // 
            // COLUMN1_NEW
            // 
            this.COLUMN1_NEW.Text = "";
            this.COLUMN1_NEW.Width = 130;
            // 
            // COLUMN2_NEW
            // 
            this.COLUMN2_NEW.Text = "";
            this.COLUMN2_NEW.Width = 120;
            // 
            // HOSTNAME_TEXTBOX
            // 
            this.HOSTNAME_TEXTBOX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.HOSTNAME_TEXTBOX.Location = new System.Drawing.Point(167, 120);
            this.HOSTNAME_TEXTBOX.Name = "HOSTNAME_TEXTBOX";
            this.HOSTNAME_TEXTBOX.Size = new System.Drawing.Size(167, 20);
            this.HOSTNAME_TEXTBOX.TabIndex = 3;
            this.HOSTNAME_TEXTBOX.Visible = false;
            this.HOSTNAME_TEXTBOX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HOSTNAME_TEXTBOX_KeyDown);
            // 
            // HOSTNAME_LABEL
            // 
            this.HOSTNAME_LABEL.AutoSize = true;
            this.HOSTNAME_LABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HOSTNAME_LABEL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.HOSTNAME_LABEL.Location = new System.Drawing.Point(10, 121);
            this.HOSTNAME_LABEL.Name = "HOSTNAME_LABEL";
            this.HOSTNAME_LABEL.Size = new System.Drawing.Size(0, 16);
            this.HOSTNAME_LABEL.TabIndex = 37;
            this.HOSTNAME_LABEL.Visible = false;
            // 
            // EDIT_TESTERS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(662, 491);
            this.Controls.Add(this.HOSTNAME_TEXTBOX);
            this.Controls.Add(this.HOSTNAME_LABEL);
            this.Controls.Add(this.NEWLIST);
            this.Controls.Add(this.option_list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LIST_OPTION);
            this.Controls.Add(this.CATEGORY);
            this.Controls.Add(this.CURRENT_LIST);
            this.Controls.Add(this.ADD_BUTTON);
            this.Controls.Add(this.NewList2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.UNDO_BUTTON);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BACK);
            this.Controls.Add(this.ADD);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.AddOrRemoveText);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.ADD_TEXT);
            this.Controls.Add(this.REMOVE);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EDIT_TESTERS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD/DELETE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ADD;
        private System.Windows.Forms.Label ADD_TEXT;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Button BACK;
        private System.Windows.Forms.ComboBox Mode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button REMOVE;
        private System.Windows.Forms.Label AddOrRemoveText;
        private System.Windows.Forms.Button UNDO_BUTTON;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label NewList2;
        private System.Windows.Forms.Button ADD_BUTTON;
        private System.Windows.Forms.ListView CURRENT_LIST;
        private System.Windows.Forms.ComboBox CATEGORY;
        private System.Windows.Forms.ComboBox LIST_OPTION;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label option_list;
        private System.Windows.Forms.ColumnHeader TESTER;
        private System.Windows.Forms.ColumnHeader HOSTNAME;
        private System.Windows.Forms.ListView NEWLIST;
        private System.Windows.Forms.ColumnHeader COLUMN1_NEW;
        private System.Windows.Forms.ColumnHeader COLUMN2_NEW;
        private System.Windows.Forms.TextBox HOSTNAME_TEXTBOX;
        private System.Windows.Forms.Label HOSTNAME_LABEL;
    }
}