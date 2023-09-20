
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
            this.AddOrDeleteList1 = new System.Windows.Forms.ListBox();
            this.ADD = new System.Windows.Forms.TextBox();
            this.ADD_TEXT = new System.Windows.Forms.Label();
            this.Tester_platforms = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Save_btn = new System.Windows.Forms.Button();
            this.CurrentList1_text = new System.Windows.Forms.Label();
            this.BACK = new System.Windows.Forms.Button();
            this.Mode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.REMOVE = new System.Windows.Forms.Button();
            this.AddOrRemoveText = new System.Windows.Forms.Label();
            this.ADD_BTN = new System.Windows.Forms.Button();
            this.CurrentList1 = new System.Windows.Forms.ListBox();
            this.PRODUCT_OWNER_FILTER = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddOrDeleteList2 = new System.Windows.Forms.ListBox();
            this.CurrentList2 = new System.Windows.Forms.ListBox();
            this.CurrentList2_text = new System.Windows.Forms.Label();
            this.NewList1 = new System.Windows.Forms.Label();
            this.NewList2 = new System.Windows.Forms.Label();
            this.ADD_BUTTON = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddOrDeleteList1
            // 
            this.AddOrDeleteList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddOrDeleteList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddOrDeleteList1.FormattingEnabled = true;
            this.AddOrDeleteList1.ItemHeight = 16;
            this.AddOrDeleteList1.Location = new System.Drawing.Point(12, 186);
            this.AddOrDeleteList1.Name = "AddOrDeleteList1";
            this.AddOrDeleteList1.Size = new System.Drawing.Size(156, 228);
            this.AddOrDeleteList1.TabIndex = 0;
            // 
            // ADD
            // 
            this.ADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ADD.Location = new System.Drawing.Point(174, 114);
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
            this.ADD_TEXT.Location = new System.Drawing.Point(12, 118);
            this.ADD_TEXT.Name = "ADD_TEXT";
            this.ADD_TEXT.Size = new System.Drawing.Size(0, 16);
            this.ADD_TEXT.TabIndex = 3;
            this.ADD_TEXT.Visible = false;
            // 
            // Tester_platforms
            // 
            this.Tester_platforms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tester_platforms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tester_platforms.FormattingEnabled = true;
            this.Tester_platforms.Location = new System.Drawing.Point(174, 37);
            this.Tester_platforms.Name = "Tester_platforms";
            this.Tester_platforms.Size = new System.Drawing.Size(167, 21);
            this.Tester_platforms.Sorted = true;
            this.Tester_platforms.TabIndex = 4;
            this.Tester_platforms.SelectionChangeCommitted += new System.EventHandler(this.Tester_platforms_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(9, 38);
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
            this.Save_btn.Location = new System.Drawing.Point(12, 427);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(117, 41);
            this.Save_btn.TabIndex = 6;
            this.Save_btn.Text = "SAVE";
            this.Save_btn.UseVisualStyleBackColor = false;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // CurrentList1_text
            // 
            this.CurrentList1_text.AutoSize = true;
            this.CurrentList1_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentList1_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.CurrentList1_text.Location = new System.Drawing.Point(501, 161);
            this.CurrentList1_text.Name = "CurrentList1_text";
            this.CurrentList1_text.Size = new System.Drawing.Size(40, 16);
            this.CurrentList1_text.TabIndex = 7;
            this.CurrentList1_text.Text = "LIST";
            // 
            // BACK
            // 
            this.BACK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BACK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BACK.Location = new System.Drawing.Point(657, 427);
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
            "DELETE",
            "UPDATE"});
            this.Mode.Location = new System.Drawing.Point(174, 8);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(167, 21);
            this.Mode.Sorted = true;
            this.Mode.TabIndex = 10;
            this.Mode.SelectedIndexChanged += new System.EventHandler(this.Option_selection);
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
            this.REMOVE.Location = new System.Drawing.Point(336, 309);
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
            this.AddOrRemoveText.Location = new System.Drawing.Point(499, 47);
            this.AddOrRemoveText.Name = "AddOrRemoveText";
            this.AddOrRemoveText.Size = new System.Drawing.Size(0, 25);
            this.AddOrRemoveText.TabIndex = 13;
            // 
            // ADD_BTN
            // 
            this.ADD_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ADD_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ADD_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADD_BTN.Location = new System.Drawing.Point(336, 273);
            this.ADD_BTN.Name = "ADD_BTN";
            this.ADD_BTN.Size = new System.Drawing.Size(112, 30);
            this.ADD_BTN.TabIndex = 16;
            this.ADD_BTN.Text = "--> ADD -->";
            this.ADD_BTN.UseVisualStyleBackColor = false;
            this.ADD_BTN.Visible = false;
            this.ADD_BTN.Click += new System.EventHandler(this.ADD_BTN_Click);
            // 
            // CurrentList1
            // 
            this.CurrentList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentList1.FormattingEnabled = true;
            this.CurrentList1.ItemHeight = 16;
            this.CurrentList1.Location = new System.Drawing.Point(454, 186);
            this.CurrentList1.Name = "CurrentList1";
            this.CurrentList1.Size = new System.Drawing.Size(156, 228);
            this.CurrentList1.Sorted = true;
            this.CurrentList1.TabIndex = 1;
            this.CurrentList1.SelectedIndexChanged += new System.EventHandler(this.CurrentList1_SelectedIndexChanged);
            // 
            // PRODUCT_OWNER_FILTER
            // 
            this.PRODUCT_OWNER_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PRODUCT_OWNER_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PRODUCT_OWNER_FILTER.FormattingEnabled = true;
            this.PRODUCT_OWNER_FILTER.Location = new System.Drawing.Point(174, 66);
            this.PRODUCT_OWNER_FILTER.Name = "PRODUCT_OWNER_FILTER";
            this.PRODUCT_OWNER_FILTER.Size = new System.Drawing.Size(167, 21);
            this.PRODUCT_OWNER_FILTER.Sorted = true;
            this.PRODUCT_OWNER_FILTER.TabIndex = 17;
            this.PRODUCT_OWNER_FILTER.SelectionChangeCommitted += new System.EventHandler(this.PRODUCT_OWNER_FILTER_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label5.Location = new System.Drawing.Point(9, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "PRODUCT OWNER";
            // 
            // AddOrDeleteList2
            // 
            this.AddOrDeleteList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddOrDeleteList2.FormattingEnabled = true;
            this.AddOrDeleteList2.ItemHeight = 16;
            this.AddOrDeleteList2.Location = new System.Drawing.Point(174, 187);
            this.AddOrDeleteList2.Name = "AddOrDeleteList2";
            this.AddOrDeleteList2.Size = new System.Drawing.Size(156, 228);
            this.AddOrDeleteList2.TabIndex = 22;
            // 
            // CurrentList2
            // 
            this.CurrentList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentList2.FormattingEnabled = true;
            this.CurrentList2.ItemHeight = 16;
            this.CurrentList2.Location = new System.Drawing.Point(616, 186);
            this.CurrentList2.Name = "CurrentList2";
            this.CurrentList2.Size = new System.Drawing.Size(156, 228);
            this.CurrentList2.Sorted = true;
            this.CurrentList2.TabIndex = 23;
            // 
            // CurrentList2_text
            // 
            this.CurrentList2_text.AutoSize = true;
            this.CurrentList2_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentList2_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.CurrentList2_text.Location = new System.Drawing.Point(654, 161);
            this.CurrentList2_text.Name = "CurrentList2_text";
            this.CurrentList2_text.Size = new System.Drawing.Size(40, 16);
            this.CurrentList2_text.TabIndex = 24;
            this.CurrentList2_text.Text = "LIST";
            // 
            // NewList1
            // 
            this.NewList1.AutoSize = true;
            this.NewList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewList1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.NewList1.Location = new System.Drawing.Point(47, 161);
            this.NewList1.Name = "NewList1";
            this.NewList1.Size = new System.Drawing.Size(40, 16);
            this.NewList1.TabIndex = 25;
            this.NewList1.Text = "LIST";
            // 
            // NewList2
            // 
            this.NewList2.AutoSize = true;
            this.NewList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewList2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.NewList2.Location = new System.Drawing.Point(211, 161);
            this.NewList2.Name = "NewList2";
            this.NewList2.Size = new System.Drawing.Size(40, 16);
            this.NewList2.TabIndex = 26;
            this.NewList2.Text = "LIST";
            // 
            // ADD_BUTTON
            // 
            this.ADD_BUTTON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ADD_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ADD_BUTTON.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADD_BUTTON.Location = new System.Drawing.Point(347, 109);
            this.ADD_BUTTON.Name = "ADD_BUTTON";
            this.ADD_BUTTON.Size = new System.Drawing.Size(58, 32);
            this.ADD_BUTTON.TabIndex = 27;
            this.ADD_BUTTON.Text = "ADD";
            this.ADD_BUTTON.UseVisualStyleBackColor = false;
            this.ADD_BUTTON.Visible = false;
            this.ADD_BUTTON.Click += new System.EventHandler(this.ADD_BUTTON_Click);
            // 
            // EDIT_TESTERS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(786, 475);
            this.Controls.Add(this.ADD_BUTTON);
            this.Controls.Add(this.NewList2);
            this.Controls.Add(this.NewList1);
            this.Controls.Add(this.CurrentList2_text);
            this.Controls.Add(this.CurrentList2);
            this.Controls.Add(this.AddOrDeleteList2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PRODUCT_OWNER_FILTER);
            this.Controls.Add(this.ADD_BTN);
            this.Controls.Add(this.CurrentList1);
            this.Controls.Add(this.AddOrDeleteList1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BACK);
            this.Controls.Add(this.CurrentList1_text);
            this.Controls.Add(this.ADD);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.AddOrRemoveText);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.ADD_TEXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.REMOVE);
            this.Controls.Add(this.Tester_platforms);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(802, 514);
            this.MinimumSize = new System.Drawing.Size(802, 514);
            this.Name = "EDIT_TESTERS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD/DELETE";
            this.Load += new System.EventHandler(this.EDIT_TESTERS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AddOrDeleteList1;
        private System.Windows.Forms.TextBox ADD;
        private System.Windows.Forms.Label ADD_TEXT;
        private System.Windows.Forms.ComboBox Tester_platforms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Label CurrentList1_text;
        private System.Windows.Forms.Button BACK;
        private System.Windows.Forms.ComboBox Mode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button REMOVE;
        private System.Windows.Forms.Label AddOrRemoveText;
        private System.Windows.Forms.Button ADD_BTN;
        private System.Windows.Forms.ListBox CurrentList1;
        private System.Windows.Forms.ComboBox PRODUCT_OWNER_FILTER;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox AddOrDeleteList2;
        private System.Windows.Forms.ListBox CurrentList2;
        private System.Windows.Forms.Label CurrentList2_text;
        private System.Windows.Forms.Label NewList1;
        private System.Windows.Forms.Label NewList2;
        private System.Windows.Forms.Button ADD_BUTTON;
    }
}