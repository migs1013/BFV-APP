
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
            this.AddOrDelete = new System.Windows.Forms.ListBox();
            this.Current_List = new System.Windows.Forms.ListBox();
            this.ADD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tester_platforms = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Save_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BACK = new System.Windows.Forms.Button();
            this.Mode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.REMOVE = new System.Windows.Forms.Button();
            this.AddOrRemoveText = new System.Windows.Forms.Label();
            this.Tester = new System.Windows.Forms.RadioButton();
            this.Board = new System.Windows.Forms.RadioButton();
            this.ADD_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddOrDelete
            // 
            this.AddOrDelete.FormattingEnabled = true;
            this.AddOrDelete.Location = new System.Drawing.Point(12, 168);
            this.AddOrDelete.Name = "AddOrDelete";
            this.AddOrDelete.Size = new System.Drawing.Size(205, 238);
            this.AddOrDelete.Sorted = true;
            this.AddOrDelete.TabIndex = 0;
            // 
            // Current_List
            // 
            this.Current_List.FormattingEnabled = true;
            this.Current_List.Location = new System.Drawing.Point(342, 168);
            this.Current_List.Name = "Current_List";
            this.Current_List.Size = new System.Drawing.Size(205, 238);
            this.Current_List.Sorted = true;
            this.Current_List.TabIndex = 1;
            // 
            // ADD
            // 
            this.ADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ADD.Location = new System.Drawing.Point(58, 129);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(159, 20);
            this.ADD.TabIndex = 2;
            this.ADD.Visible = false;
            this.ADD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Add_Tester);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "ADD";
            this.label3.Visible = false;
            // 
            // Tester_platforms
            // 
            this.Tester_platforms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tester_platforms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tester_platforms.FormattingEnabled = true;
            this.Tester_platforms.Location = new System.Drawing.Point(169, 30);
            this.Tester_platforms.Name = "Tester_platforms";
            this.Tester_platforms.Size = new System.Drawing.Size(130, 21);
            this.Tester_platforms.TabIndex = 4;
            this.Tester_platforms.SelectedIndexChanged += new System.EventHandler(this.Tester_platforms_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "TESTER PLATFORM";
            // 
            // Save_btn
            // 
            this.Save_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Save_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_btn.Location = new System.Drawing.Point(15, 420);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(117, 41);
            this.Save_btn.TabIndex = 6;
            this.Save_btn.Text = "SAVE";
            this.Save_btn.UseVisualStyleBackColor = false;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label2.Location = new System.Drawing.Point(365, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "CURRENT VALUES";
            // 
            // BACK
            // 
            this.BACK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BACK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BACK.Location = new System.Drawing.Point(432, 420);
            this.BACK.Name = "BACK";
            this.BACK.Size = new System.Drawing.Size(115, 41);
            this.BACK.TabIndex = 9;
            this.BACK.Text = "BACK";
            this.BACK.UseVisualStyleBackColor = false;
            this.BACK.Click += new System.EventHandler(this.button1_Click);
            // 
            // Mode
            // 
            this.Mode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mode.FormattingEnabled = true;
            this.Mode.Items.AddRange(new object[] {
            "ADD",
            "DELETE"});
            this.Mode.Location = new System.Drawing.Point(169, 7);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(130, 21);
            this.Mode.TabIndex = 10;
            this.Mode.SelectedIndexChanged += new System.EventHandler(this.Option_selection);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label4.Location = new System.Drawing.Point(9, 9);
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
            this.REMOVE.Location = new System.Drawing.Point(224, 286);
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
            this.AddOrRemoveText.Location = new System.Drawing.Point(196, 80);
            this.AddOrRemoveText.Name = "AddOrRemoveText";
            this.AddOrRemoveText.Size = new System.Drawing.Size(0, 25);
            this.AddOrRemoveText.TabIndex = 13;
            // 
            // Tester
            // 
            this.Tester.AutoSize = true;
            this.Tester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.Tester.Location = new System.Drawing.Point(15, 84);
            this.Tester.Name = "Tester";
            this.Tester.Size = new System.Drawing.Size(87, 20);
            this.Tester.TabIndex = 15;
            this.Tester.TabStop = true;
            this.Tester.Text = "TESTER";
            this.Tester.UseVisualStyleBackColor = true;
            this.Tester.Click += new System.EventHandler(this.Tester_mode);
            // 
            // Board
            // 
            this.Board.AutoSize = true;
            this.Board.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Board.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.Board.Location = new System.Drawing.Point(15, 57);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(89, 20);
            this.Board.TabIndex = 14;
            this.Board.TabStop = true;
            this.Board.Text = "BOARDS";
            this.Board.UseVisualStyleBackColor = true;
            this.Board.Click += new System.EventHandler(this.Boards_mode);
            // 
            // ADD_BTN
            // 
            this.ADD_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ADD_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ADD_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADD_BTN.Location = new System.Drawing.Point(224, 250);
            this.ADD_BTN.Name = "ADD_BTN";
            this.ADD_BTN.Size = new System.Drawing.Size(112, 30);
            this.ADD_BTN.TabIndex = 16;
            this.ADD_BTN.Text = "--> ADD -->";
            this.ADD_BTN.UseVisualStyleBackColor = false;
            this.ADD_BTN.Visible = false;
            this.ADD_BTN.Click += new System.EventHandler(this.ADD_BTN_Click);
            // 
            // EDIT_TESTERS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(559, 478);
            this.Controls.Add(this.ADD_BTN);
            this.Controls.Add(this.Tester);
            this.Controls.Add(this.Board);
            this.Controls.Add(this.Current_List);
            this.Controls.Add(this.AddOrDelete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BACK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ADD);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.AddOrRemoveText);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.REMOVE);
            this.Controls.Add(this.Tester_platforms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(575, 517);
            this.MinimumSize = new System.Drawing.Size(575, 517);
            this.Name = "EDIT_TESTERS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD/DELETE";
            this.Load += new System.EventHandler(this.EDIT_TESTERS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AddOrDelete;
        private System.Windows.Forms.ListBox Current_List;
        private System.Windows.Forms.TextBox ADD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Tester_platforms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BACK;
        private System.Windows.Forms.ComboBox Mode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button REMOVE;
        private System.Windows.Forms.Label AddOrRemoveText;
        private System.Windows.Forms.RadioButton Tester;
        private System.Windows.Forms.RadioButton Board;
        private System.Windows.Forms.Button ADD_BTN;
    }
}