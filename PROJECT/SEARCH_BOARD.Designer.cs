namespace PROJECT
{
    partial class SEARCH_BOARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SEARCH_BOARD));
            this.Search_button = new System.Windows.Forms.Button();
            this.search_text = new System.Windows.Forms.TextBox();
            this.Add_btn = new System.Windows.Forms.Button();
            this.dataGridViewList = new System.Windows.Forms.DataGridView();
            this.PART_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEST_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TESTER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEST_STEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE_ENCOUNTERED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_OWNER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDORSEMENT_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFRESH = new System.Windows.Forms.Button();
            this.EDIT = new System.Windows.Forms.Button();
            this.FROM_DATE = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PRODUCT_OWNER_FILTER = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TESTER_ID_FILTER = new System.Windows.Forms.ComboBox();
            this.TESTER_PLATFORM_FILTER = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Count_search = new System.Windows.Forms.Label();
            this.FORWARD = new System.Windows.Forms.Label();
            this.BACK = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TO_DATE = new System.Windows.Forms.DateTimePicker();
            this.NAME = new System.Windows.Forms.Label();
            this.TEST_STEP_FILTER = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PART_NAME_FILTER = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BIN_NUMBER_FILTER = new System.Windows.Forms.TextBox();
            this.VSPECS = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).BeginInit();
            this.SuspendLayout();
            // 
            // Search_button
            // 
            this.Search_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.Search_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Search_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Search_button.Location = new System.Drawing.Point(1095, 4);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(150, 21);
            this.Search_button.TabIndex = 0;
            this.Search_button.Text = "SEARCH";
            this.Search_button.UseVisualStyleBackColor = false;
            this.Search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // search_text
            // 
            this.search_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.search_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_text.Location = new System.Drawing.Point(1251, 4);
            this.search_text.Name = "search_text";
            this.search_text.Size = new System.Drawing.Size(147, 20);
            this.search_text.TabIndex = 1;
            this.search_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_search);
            // 
            // Add_btn
            // 
            this.Add_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.Add_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Add_btn.Location = new System.Drawing.Point(351, 513);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(130, 51);
            this.Add_btn.TabIndex = 2;
            this.Add_btn.Text = "TRANSACT";
            this.Add_btn.UseVisualStyleBackColor = false;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // dataGridViewList
            // 
            this.dataGridViewList.AllowUserToAddRows = false;
            this.dataGridViewList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewList.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PART_NAME,
            this.LOT_ID,
            this.TEST_NUMBER,
            this.TESTER_ID,
            this.TEST_STEP,
            this.DATE_ENCOUNTERED,
            this.PRODUCT_OWNER,
            this.ENDORSEMENT_NUMBER});
            this.dataGridViewList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewList.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewList.Location = new System.Drawing.Point(7, 98);
            this.dataGridViewList.Name = "dataGridViewList";
            this.dataGridViewList.ReadOnly = true;
            this.dataGridViewList.RowHeadersVisible = false;
            this.dataGridViewList.RowHeadersWidth = 62;
            this.dataGridViewList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewList.Size = new System.Drawing.Size(1390, 409);
            this.dataGridViewList.TabIndex = 4;
            this.dataGridViewList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_data);
            // 
            // PART_NAME
            // 
            this.PART_NAME.DataPropertyName = "PART_NAME";
            this.PART_NAME.HeaderText = "PART NAME";
            this.PART_NAME.MinimumWidth = 8;
            this.PART_NAME.Name = "PART_NAME";
            this.PART_NAME.ReadOnly = true;
            // 
            // LOT_ID
            // 
            this.LOT_ID.DataPropertyName = "LOT_ID";
            this.LOT_ID.HeaderText = "LOT ID";
            this.LOT_ID.MinimumWidth = 8;
            this.LOT_ID.Name = "LOT_ID";
            this.LOT_ID.ReadOnly = true;
            // 
            // TEST_NUMBER
            // 
            this.TEST_NUMBER.DataPropertyName = "TEST_NUMBER";
            this.TEST_NUMBER.HeaderText = "TEST NUMBER";
            this.TEST_NUMBER.MinimumWidth = 8;
            this.TEST_NUMBER.Name = "TEST_NUMBER";
            this.TEST_NUMBER.ReadOnly = true;
            // 
            // TESTER_ID
            // 
            this.TESTER_ID.DataPropertyName = "TESTER_ID";
            this.TESTER_ID.HeaderText = "TESTER ID";
            this.TESTER_ID.MinimumWidth = 8;
            this.TESTER_ID.Name = "TESTER_ID";
            this.TESTER_ID.ReadOnly = true;
            // 
            // TEST_STEP
            // 
            this.TEST_STEP.DataPropertyName = "TEST_STEP";
            this.TEST_STEP.HeaderText = "TEST STEP";
            this.TEST_STEP.MinimumWidth = 8;
            this.TEST_STEP.Name = "TEST_STEP";
            this.TEST_STEP.ReadOnly = true;
            // 
            // DATE_ENCOUNTERED
            // 
            this.DATE_ENCOUNTERED.DataPropertyName = "DATE_ENCOUNTERED";
            this.DATE_ENCOUNTERED.HeaderText = "DATE ENCOUNTERED";
            this.DATE_ENCOUNTERED.MinimumWidth = 8;
            this.DATE_ENCOUNTERED.Name = "DATE_ENCOUNTERED";
            this.DATE_ENCOUNTERED.ReadOnly = true;
            this.DATE_ENCOUNTERED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DATE_ENCOUNTERED.ToolTipText = "FIRST";
            // 
            // PRODUCT_OWNER
            // 
            this.PRODUCT_OWNER.DataPropertyName = "PRODUCT_OWNER";
            this.PRODUCT_OWNER.HeaderText = "PRODUCT OWNER";
            this.PRODUCT_OWNER.MinimumWidth = 8;
            this.PRODUCT_OWNER.Name = "PRODUCT_OWNER";
            this.PRODUCT_OWNER.ReadOnly = true;
            // 
            // ENDORSEMENT_NUMBER
            // 
            this.ENDORSEMENT_NUMBER.DataPropertyName = "ENDORSEMENT_NUMBER";
            this.ENDORSEMENT_NUMBER.HeaderText = "ENDORSEMENT NUMBER";
            this.ENDORSEMENT_NUMBER.MinimumWidth = 8;
            this.ENDORSEMENT_NUMBER.Name = "ENDORSEMENT_NUMBER";
            this.ENDORSEMENT_NUMBER.ReadOnly = true;
            this.ENDORSEMENT_NUMBER.Visible = false;
            // 
            // REFRESH
            // 
            this.REFRESH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.REFRESH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.REFRESH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REFRESH.ForeColor = System.Drawing.SystemColors.ControlText;
            this.REFRESH.Location = new System.Drawing.Point(7, 4);
            this.REFRESH.Name = "REFRESH";
            this.REFRESH.Size = new System.Drawing.Size(150, 22);
            this.REFRESH.TabIndex = 5;
            this.REFRESH.Text = "REFRESH ALL";
            this.REFRESH.UseVisualStyleBackColor = false;
            this.REFRESH.Click += new System.EventHandler(this.REFRESH_Click);
            // 
            // EDIT
            // 
            this.EDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EDIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.EDIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDIT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EDIT.Location = new System.Drawing.Point(915, 513);
            this.EDIT.Name = "EDIT";
            this.EDIT.Size = new System.Drawing.Size(130, 50);
            this.EDIT.TabIndex = 24;
            this.EDIT.Text = "TESTER / BOARDS";
            this.EDIT.UseVisualStyleBackColor = false;
            this.EDIT.Click += new System.EventHandler(this.EDIT_Click);
            // 
            // FROM_DATE
            // 
            this.FROM_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FROM_DATE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FROM_DATE.CustomFormat = "yyyy-MM-dd";
            this.FROM_DATE.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.FROM_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FROM_DATE.Location = new System.Drawing.Point(1151, 36);
            this.FROM_DATE.Name = "FROM_DATE";
            this.FROM_DATE.Size = new System.Drawing.Size(112, 20);
            this.FROM_DATE.TabIndex = 26;
            this.FROM_DATE.CloseUp += new System.EventHandler(this.Select_FirstDate);
            this.FROM_DATE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstDate);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(640, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "VERSION 1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(7, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 50);
            this.button1.TabIndex = 30;
            this.button1.Text = "LOGOUT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label2.Location = new System.Drawing.Point(263, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "PRODUCT OWNER:";
            // 
            // PRODUCT_OWNER_FILTER
            // 
            this.PRODUCT_OWNER_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PRODUCT_OWNER_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PRODUCT_OWNER_FILTER.FormattingEnabled = true;
            this.PRODUCT_OWNER_FILTER.Items.AddRange(new object[] {
            ""});
            this.PRODUCT_OWNER_FILTER.Location = new System.Drawing.Point(416, 38);
            this.PRODUCT_OWNER_FILTER.Name = "PRODUCT_OWNER_FILTER";
            this.PRODUCT_OWNER_FILTER.Size = new System.Drawing.Size(188, 21);
            this.PRODUCT_OWNER_FILTER.Sorted = true;
            this.PRODUCT_OWNER_FILTER.TabIndex = 32;
            this.PRODUCT_OWNER_FILTER.SelectionChangeCommitted += new System.EventHandler(this.PRODUCT_OWNER_FILTER_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label4.Location = new System.Drawing.Point(4, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "TESTER ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label5.Location = new System.Drawing.Point(4, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "TESTER PLATFORM:";
            // 
            // TESTER_ID_FILTER
            // 
            this.TESTER_ID_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TESTER_ID_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TESTER_ID_FILTER.FormattingEnabled = true;
            this.TESTER_ID_FILTER.Items.AddRange(new object[] {
            ""});
            this.TESTER_ID_FILTER.Location = new System.Drawing.Point(136, 66);
            this.TESTER_ID_FILTER.Name = "TESTER_ID_FILTER";
            this.TESTER_ID_FILTER.Size = new System.Drawing.Size(121, 21);
            this.TESTER_ID_FILTER.Sorted = true;
            this.TESTER_ID_FILTER.TabIndex = 37;
            // 
            // TESTER_PLATFORM_FILTER
            // 
            this.TESTER_PLATFORM_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TESTER_PLATFORM_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TESTER_PLATFORM_FILTER.FormattingEnabled = true;
            this.TESTER_PLATFORM_FILTER.Items.AddRange(new object[] {
            ""});
            this.TESTER_PLATFORM_FILTER.Location = new System.Drawing.Point(136, 39);
            this.TESTER_PLATFORM_FILTER.Name = "TESTER_PLATFORM_FILTER";
            this.TESTER_PLATFORM_FILTER.Size = new System.Drawing.Size(121, 21);
            this.TESTER_PLATFORM_FILTER.Sorted = true;
            this.TESTER_PLATFORM_FILTER.TabIndex = 38;
            this.TESTER_PLATFORM_FILTER.SelectionChangeCommitted += new System.EventHandler(this.TESTER_PLATFORM_FILTER_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label6.Location = new System.Drawing.Point(1092, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "FROM:";
            // 
            // Count_search
            // 
            this.Count_search.AutoSize = true;
            this.Count_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Count_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.Count_search.Location = new System.Drawing.Point(345, 8);
            this.Count_search.Name = "Count_search";
            this.Count_search.Size = new System.Drawing.Size(0, 16);
            this.Count_search.TabIndex = 41;
            // 
            // FORWARD
            // 
            this.FORWARD.AutoSize = true;
            this.FORWARD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FORWARD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FORWARD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.FORWARD.Location = new System.Drawing.Point(305, 4);
            this.FORWARD.Name = "FORWARD";
            this.FORWARD.Size = new System.Drawing.Size(34, 24);
            this.FORWARD.TabIndex = 42;
            this.FORWARD.Text = ">>";
            this.FORWARD.Click += new System.EventHandler(this.ForwardClick);
            // 
            // BACK
            // 
            this.BACK.AutoSize = true;
            this.BACK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BACK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.BACK.Location = new System.Drawing.Point(265, 4);
            this.BACK.Name = "BACK";
            this.BACK.Size = new System.Drawing.Size(34, 24);
            this.BACK.TabIndex = 43;
            this.BACK.Text = "<<";
            this.BACK.Click += new System.EventHandler(this.BackClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label7.Location = new System.Drawing.Point(1262, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "TO:";
            // 
            // TO_DATE
            // 
            this.TO_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TO_DATE.CustomFormat = "yyyy-MM-dd";
            this.TO_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TO_DATE.Location = new System.Drawing.Point(1291, 36);
            this.TO_DATE.Name = "TO_DATE";
            this.TO_DATE.Size = new System.Drawing.Size(106, 20);
            this.TO_DATE.TabIndex = 45;
            this.TO_DATE.CloseUp += new System.EventHandler(this.TO_DATE_select);
            this.TO_DATE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TO_DATE_KeyDown);
            // 
            // NAME
            // 
            this.NAME.AutoSize = true;
            this.NAME.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.NAME.Location = new System.Drawing.Point(816, 10);
            this.NAME.Name = "NAME";
            this.NAME.Size = new System.Drawing.Size(0, 13);
            this.NAME.TabIndex = 46;
            // 
            // TEST_STEP_FILTER
            // 
            this.TEST_STEP_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TEST_STEP_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TEST_STEP_FILTER.FormattingEnabled = true;
            this.TEST_STEP_FILTER.Location = new System.Drawing.Point(712, 38);
            this.TEST_STEP_FILTER.Name = "TEST_STEP_FILTER";
            this.TEST_STEP_FILTER.Size = new System.Drawing.Size(191, 21);
            this.TEST_STEP_FILTER.Sorted = true;
            this.TEST_STEP_FILTER.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label3.Location = new System.Drawing.Point(610, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "TEST STEP:";
            // 
            // PART_NAME_FILTER
            // 
            this.PART_NAME_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PART_NAME_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PART_NAME_FILTER.FormattingEnabled = true;
            this.PART_NAME_FILTER.Location = new System.Drawing.Point(416, 66);
            this.PART_NAME_FILTER.Name = "PART_NAME_FILTER";
            this.PART_NAME_FILTER.Size = new System.Drawing.Size(188, 21);
            this.PART_NAME_FILTER.Sorted = true;
            this.PART_NAME_FILTER.TabIndex = 50;
            this.PART_NAME_FILTER.SelectionChangeCommitted += new System.EventHandler(this.PART_NAME_FILTER_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label8.Location = new System.Drawing.Point(263, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 49;
            this.label8.Text = "PART NAME:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label9.Location = new System.Drawing.Point(756, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 51;
            this.label9.Text = "USER:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label10.Location = new System.Drawing.Point(912, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 16);
            this.label10.TabIndex = 52;
            this.label10.Text = "BIN NUMBER:";
            // 
            // BIN_NUMBER_FILTER
            // 
            this.BIN_NUMBER_FILTER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.BIN_NUMBER_FILTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIN_NUMBER_FILTER.Location = new System.Drawing.Point(1024, 65);
            this.BIN_NUMBER_FILTER.Name = "BIN_NUMBER_FILTER";
            this.BIN_NUMBER_FILTER.Size = new System.Drawing.Size(65, 20);
            this.BIN_NUMBER_FILTER.TabIndex = 53;
            // 
            // VSPECS
            // 
            this.VSPECS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VSPECS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VSPECS.FormattingEnabled = true;
            this.VSPECS.Location = new System.Drawing.Point(712, 66);
            this.VSPECS.Name = "VSPECS";
            this.VSPECS.Size = new System.Drawing.Size(191, 21);
            this.VSPECS.Sorted = true;
            this.VSPECS.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label11.Location = new System.Drawing.Point(625, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 54;
            this.label11.Text = "VSPECS:";
            // 
            // SEARCH_BOARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1404, 575);
            this.Controls.Add(this.VSPECS);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BIN_NUMBER_FILTER);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PART_NAME_FILTER);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TEST_STEP_FILTER);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NAME);
            this.Controls.Add(this.TO_DATE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BACK);
            this.Controls.Add(this.FORWARD);
            this.Controls.Add(this.Count_search);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TESTER_PLATFORM_FILTER);
            this.Controls.Add(this.TESTER_ID_FILTER);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PRODUCT_OWNER_FILTER);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FROM_DATE);
            this.Controls.Add(this.EDIT);
            this.Controls.Add(this.REFRESH);
            this.Controls.Add(this.dataGridViewList);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.search_text);
            this.Controls.Add(this.Search_button);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1278, 614);
            this.Name = "SEARCH_BOARD";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.SEARCH_BOARD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Search_button;
        private System.Windows.Forms.TextBox search_text;
        private System.Windows.Forms.Button Add_btn;
        private System.Windows.Forms.DataGridView dataGridViewList;
        private System.Windows.Forms.Button REFRESH;
        private System.Windows.Forms.Button EDIT;
        private System.Windows.Forms.DateTimePicker FROM_DATE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PRODUCT_OWNER_FILTER;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox TESTER_ID_FILTER;
        private System.Windows.Forms.ComboBox TESTER_PLATFORM_FILTER;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Count_search;
        private System.Windows.Forms.Label FORWARD;
        private System.Windows.Forms.Label BACK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker TO_DATE;
        private System.Windows.Forms.Label NAME;
        private System.Windows.Forms.ComboBox TEST_STEP_FILTER;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEST_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn TESTER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEST_STEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE_ENCOUNTERED;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_OWNER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDORSEMENT_NUMBER;
        private System.Windows.Forms.ComboBox PART_NAME_FILTER;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox BIN_NUMBER_FILTER;
        private System.Windows.Forms.ComboBox VSPECS;
        private System.Windows.Forms.Label label11;
    }
}