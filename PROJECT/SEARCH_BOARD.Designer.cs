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
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.STATUS_FILTER = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.HITCOUNT = new System.Windows.Forms.ListView();
            this.DEVICE_NAME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HIT_COUNT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SEARCH_PARETO = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.WORKWEEK = new System.Windows.Forms.TextBox();
            this.FISCAL_YEAR = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.QUARTER = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search_button
            // 
            this.Search_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.Search_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Search_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Search_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Search_button.Location = new System.Drawing.Point(180, 169);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(150, 27);
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
            this.search_text.Location = new System.Drawing.Point(504, 17);
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
            this.Add_btn.Location = new System.Drawing.Point(351, 657);
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
            this.STATUS,
            this.ENDORSEMENT_NUMBER});
            this.dataGridViewList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewList.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewList.Location = new System.Drawing.Point(7, 227);
            this.dataGridViewList.Name = "dataGridViewList";
            this.dataGridViewList.ReadOnly = true;
            this.dataGridViewList.RowHeadersVisible = false;
            this.dataGridViewList.RowHeadersWidth = 62;
            this.dataGridViewList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewList.Size = new System.Drawing.Size(1437, 424);
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
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "STATUS";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
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
            this.REFRESH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.REFRESH.ForeColor = System.Drawing.SystemColors.ControlText;
            this.REFRESH.Location = new System.Drawing.Point(12, 12);
            this.REFRESH.Name = "REFRESH";
            this.REFRESH.Size = new System.Drawing.Size(150, 22);
            this.REFRESH.TabIndex = 5;
            this.REFRESH.Text = "REFRESH";
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
            this.EDIT.Location = new System.Drawing.Point(962, 658);
            this.EDIT.Name = "EDIT";
            this.EDIT.Size = new System.Drawing.Size(130, 50);
            this.EDIT.TabIndex = 24;
            this.EDIT.Text = "TESTER / DEVICE";
            this.EDIT.UseVisualStyleBackColor = false;
            this.EDIT.Click += new System.EventHandler(this.EDIT_Click);
            // 
            // FROM_DATE
            // 
            this.FROM_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FROM_DATE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FROM_DATE.CustomFormat = "yyyy-MM-dd";
            this.FROM_DATE.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.FROM_DATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FROM_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FROM_DATE.Location = new System.Drawing.Point(465, 158);
            this.FROM_DATE.Name = "FROM_DATE";
            this.FROM_DATE.Size = new System.Drawing.Size(115, 22);
            this.FROM_DATE.TabIndex = 26;
            this.FROM_DATE.CloseUp += new System.EventHandler(this.Select_FirstDate);
            this.FROM_DATE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstDate);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(647, 668);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "VERSION 1.0.4";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(7, 657);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 50);
            this.button1.TabIndex = 30;
            this.button1.Text = "LOGOUT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "PRODUCT OWNER:";
            // 
            // PRODUCT_OWNER_FILTER
            // 
            this.PRODUCT_OWNER_FILTER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PRODUCT_OWNER_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PRODUCT_OWNER_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PRODUCT_OWNER_FILTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRODUCT_OWNER_FILTER.FormattingEnabled = true;
            this.PRODUCT_OWNER_FILTER.Items.AddRange(new object[] {
            ""});
            this.PRODUCT_OWNER_FILTER.Location = new System.Drawing.Point(168, 51);
            this.PRODUCT_OWNER_FILTER.Name = "PRODUCT_OWNER_FILTER";
            this.PRODUCT_OWNER_FILTER.Size = new System.Drawing.Size(188, 24);
            this.PRODUCT_OWNER_FILTER.Sorted = true;
            this.PRODUCT_OWNER_FILTER.TabIndex = 32;
            this.PRODUCT_OWNER_FILTER.SelectionChangeCommitted += new System.EventHandler(this.PRODUCT_OWNER_FILTER_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "TESTER ID:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "TESTER PLATFORM:";
            // 
            // TESTER_ID_FILTER
            // 
            this.TESTER_ID_FILTER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TESTER_ID_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TESTER_ID_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TESTER_ID_FILTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TESTER_ID_FILTER.FormattingEnabled = true;
            this.TESTER_ID_FILTER.Items.AddRange(new object[] {
            ""});
            this.TESTER_ID_FILTER.Location = new System.Drawing.Point(168, 134);
            this.TESTER_ID_FILTER.Name = "TESTER_ID_FILTER";
            this.TESTER_ID_FILTER.Size = new System.Drawing.Size(188, 24);
            this.TESTER_ID_FILTER.Sorted = true;
            this.TESTER_ID_FILTER.TabIndex = 37;
            // 
            // TESTER_PLATFORM_FILTER
            // 
            this.TESTER_PLATFORM_FILTER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TESTER_PLATFORM_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TESTER_PLATFORM_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TESTER_PLATFORM_FILTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TESTER_PLATFORM_FILTER.FormattingEnabled = true;
            this.TESTER_PLATFORM_FILTER.Items.AddRange(new object[] {
            ""});
            this.TESTER_PLATFORM_FILTER.Location = new System.Drawing.Point(168, 106);
            this.TESTER_PLATFORM_FILTER.Name = "TESTER_PLATFORM_FILTER";
            this.TESTER_PLATFORM_FILTER.Size = new System.Drawing.Size(188, 24);
            this.TESTER_PLATFORM_FILTER.Sorted = true;
            this.TESTER_PLATFORM_FILTER.TabIndex = 38;
            this.TESTER_PLATFORM_FILTER.SelectionChangeCommitted += new System.EventHandler(this.TESTER_PLATFORM_FILTER_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(363, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "FROM:";
            // 
            // Count_search
            // 
            this.Count_search.AutoSize = true;
            this.Count_search.BackColor = System.Drawing.Color.Transparent;
            this.Count_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Count_search.ForeColor = System.Drawing.Color.Black;
            this.Count_search.Location = new System.Drawing.Point(424, 14);
            this.Count_search.Name = "Count_search";
            this.Count_search.Size = new System.Drawing.Size(0, 16);
            this.Count_search.TabIndex = 41;
            // 
            // FORWARD
            // 
            this.FORWARD.AutoSize = true;
            this.FORWARD.BackColor = System.Drawing.Color.Transparent;
            this.FORWARD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FORWARD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FORWARD.ForeColor = System.Drawing.Color.Black;
            this.FORWARD.Location = new System.Drawing.Point(384, 10);
            this.FORWARD.Name = "FORWARD";
            this.FORWARD.Size = new System.Drawing.Size(34, 24);
            this.FORWARD.TabIndex = 42;
            this.FORWARD.Text = ">>";
            this.FORWARD.Click += new System.EventHandler(this.ForwardClick);
            // 
            // BACK
            // 
            this.BACK.AutoSize = true;
            this.BACK.BackColor = System.Drawing.Color.Transparent;
            this.BACK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BACK.ForeColor = System.Drawing.Color.Black;
            this.BACK.Location = new System.Drawing.Point(347, 10);
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
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(363, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 18);
            this.label7.TabIndex = 44;
            this.label7.Text = "TO:";
            // 
            // TO_DATE
            // 
            this.TO_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TO_DATE.CustomFormat = "yyyy-MM-dd";
            this.TO_DATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TO_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TO_DATE.Location = new System.Drawing.Point(465, 186);
            this.TO_DATE.Name = "TO_DATE";
            this.TO_DATE.Size = new System.Drawing.Size(115, 22);
            this.TO_DATE.TabIndex = 45;
            this.TO_DATE.CloseUp += new System.EventHandler(this.TO_DATE_select);
            this.TO_DATE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TO_DATE_KeyDown);
            // 
            // NAME
            // 
            this.NAME.AutoSize = true;
            this.NAME.BackColor = System.Drawing.Color.Transparent;
            this.NAME.ForeColor = System.Drawing.Color.Black;
            this.NAME.Location = new System.Drawing.Point(228, 18);
            this.NAME.Name = "NAME";
            this.NAME.Size = new System.Drawing.Size(0, 13);
            this.NAME.TabIndex = 46;
            // 
            // TEST_STEP_FILTER
            // 
            this.TEST_STEP_FILTER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TEST_STEP_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TEST_STEP_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TEST_STEP_FILTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEST_STEP_FILTER.FormattingEnabled = true;
            this.TEST_STEP_FILTER.Location = new System.Drawing.Point(465, 50);
            this.TEST_STEP_FILTER.Name = "TEST_STEP_FILTER";
            this.TEST_STEP_FILTER.Size = new System.Drawing.Size(191, 24);
            this.TEST_STEP_FILTER.Sorted = true;
            this.TEST_STEP_FILTER.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(363, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "TEST STEP:";
            // 
            // PART_NAME_FILTER
            // 
            this.PART_NAME_FILTER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PART_NAME_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PART_NAME_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PART_NAME_FILTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PART_NAME_FILTER.FormattingEnabled = true;
            this.PART_NAME_FILTER.Location = new System.Drawing.Point(168, 79);
            this.PART_NAME_FILTER.Name = "PART_NAME_FILTER";
            this.PART_NAME_FILTER.Size = new System.Drawing.Size(188, 24);
            this.PART_NAME_FILTER.Sorted = true;
            this.PART_NAME_FILTER.TabIndex = 50;
            this.PART_NAME_FILTER.SelectionChangeCommitted += new System.EventHandler(this.PART_NAME_FILTER_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(15, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 49;
            this.label8.Text = "PART NAME:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(168, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 51;
            this.label9.Text = "USER:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(363, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 16);
            this.label10.TabIndex = 52;
            this.label10.Text = "BIN NUMBER:";
            // 
            // BIN_NUMBER_FILTER
            // 
            this.BIN_NUMBER_FILTER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BIN_NUMBER_FILTER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.BIN_NUMBER_FILTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIN_NUMBER_FILTER.Location = new System.Drawing.Point(465, 133);
            this.BIN_NUMBER_FILTER.Name = "BIN_NUMBER_FILTER";
            this.BIN_NUMBER_FILTER.Size = new System.Drawing.Size(65, 21);
            this.BIN_NUMBER_FILTER.TabIndex = 53;
            // 
            // VSPECS
            // 
            this.VSPECS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VSPECS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VSPECS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VSPECS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VSPECS.FormattingEnabled = true;
            this.VSPECS.Location = new System.Drawing.Point(465, 78);
            this.VSPECS.Name = "VSPECS";
            this.VSPECS.Size = new System.Drawing.Size(191, 24);
            this.VSPECS.Sorted = true;
            this.VSPECS.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(363, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 54;
            this.label11.Text = "VSPECS:";
            // 
            // STATUS_FILTER
            // 
            this.STATUS_FILTER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.STATUS_FILTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.STATUS_FILTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.STATUS_FILTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STATUS_FILTER.FormattingEnabled = true;
            this.STATUS_FILTER.Items.AddRange(new object[] {
            "",
            "OPEN",
            "CLOSED"});
            this.STATUS_FILTER.Location = new System.Drawing.Point(465, 106);
            this.STATUS_FILTER.Name = "STATUS_FILTER";
            this.STATUS_FILTER.Size = new System.Drawing.Size(191, 24);
            this.STATUS_FILTER.TabIndex = 57;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(363, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 16);
            this.label12.TabIndex = 56;
            this.label12.Text = "STATUS:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.STATUS_FILTER);
            this.groupBox1.Controls.Add(this.PRODUCT_OWNER_FILTER);
            this.groupBox1.Controls.Add(this.TO_DATE);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.VSPECS);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TESTER_ID_FILTER);
            this.groupBox1.Controls.Add(this.search_text);
            this.groupBox1.Controls.Add(this.BIN_NUMBER_FILTER);
            this.groupBox1.Controls.Add(this.Search_button);
            this.groupBox1.Controls.Add(this.FROM_DATE);
            this.groupBox1.Controls.Add(this.TESTER_PLATFORM_FILTER);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TEST_STEP_FILTER);
            this.groupBox1.Controls.Add(this.PART_NAME_FILTER);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(775, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 213);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SEARCH FILTER";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(429, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 16);
            this.label13.TabIndex = 58;
            this.label13.Text = "OTHERS:";
            // 
            // HITCOUNT
            // 
            this.HITCOUNT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DEVICE_NAME,
            this.HIT_COUNT});
            this.HITCOUNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HITCOUNT.HideSelection = false;
            this.HITCOUNT.Location = new System.Drawing.Point(7, 64);
            this.HITCOUNT.Name = "HITCOUNT";
            this.HITCOUNT.Size = new System.Drawing.Size(313, 157);
            this.HITCOUNT.TabIndex = 61;
            this.HITCOUNT.UseCompatibleStateImageBehavior = false;
            this.HITCOUNT.View = System.Windows.Forms.View.Details;
            this.HITCOUNT.Click += new System.EventHandler(this.Click_Pareto);
            // 
            // DEVICE_NAME
            // 
            this.DEVICE_NAME.Text = "DEVICE";
            this.DEVICE_NAME.Width = 203;
            // 
            // HIT_COUNT
            // 
            this.HIT_COUNT.Text = "HIT COUNT";
            this.HIT_COUNT.Width = 80;
            // 
            // SEARCH_PARETO
            // 
            this.SEARCH_PARETO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.SEARCH_PARETO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SEARCH_PARETO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCH_PARETO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SEARCH_PARETO.Location = new System.Drawing.Point(9, 122);
            this.SEARCH_PARETO.Name = "SEARCH_PARETO";
            this.SEARCH_PARETO.Size = new System.Drawing.Size(93, 34);
            this.SEARCH_PARETO.TabIndex = 62;
            this.SEARCH_PARETO.Text = "SEARCH";
            this.SEARCH_PARETO.UseVisualStyleBackColor = false;
            this.SEARCH_PARETO.Click += new System.EventHandler(this.SEARCH_PARETO_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(8, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 20);
            this.label14.TabIndex = 63;
            this.label14.Text = "PARETO FILTER";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(6, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 18);
            this.label15.TabIndex = 64;
            this.label15.Text = "QUARTER";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.WORKWEEK);
            this.groupBox2.Controls.Add(this.FISCAL_YEAR);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.QUARTER);
            this.groupBox2.Controls.Add(this.SEARCH_PARETO);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(326, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 162);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FILTER";
            // 
            // WORKWEEK
            // 
            this.WORKWEEK.Location = new System.Drawing.Point(6, 87);
            this.WORKWEEK.Name = "WORKWEEK";
            this.WORKWEEK.Size = new System.Drawing.Size(121, 20);
            this.WORKWEEK.TabIndex = 70;
            // 
            // FISCAL_YEAR
            // 
            this.FISCAL_YEAR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FISCAL_YEAR.FormattingEnabled = true;
            this.FISCAL_YEAR.Items.AddRange(new object[] {
            "",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027"});
            this.FISCAL_YEAR.Location = new System.Drawing.Point(141, 37);
            this.FISCAL_YEAR.Name = "FISCAL_YEAR";
            this.FISCAL_YEAR.Size = new System.Drawing.Size(121, 21);
            this.FISCAL_YEAR.TabIndex = 69;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(138, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 18);
            this.label17.TabIndex = 68;
            this.label17.Text = "FISCAL YEAR";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(6, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 18);
            this.label16.TabIndex = 66;
            this.label16.Text = "WORK WEEK";
            // 
            // QUARTER
            // 
            this.QUARTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QUARTER.FormattingEnabled = true;
            this.QUARTER.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4"});
            this.QUARTER.Location = new System.Drawing.Point(6, 37);
            this.QUARTER.Name = "QUARTER";
            this.QUARTER.Size = new System.Drawing.Size(121, 21);
            this.QUARTER.TabIndex = 65;
            // 
            // SEARCH_BOARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1451, 719);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HITCOUNT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BACK);
            this.Controls.Add(this.FORWARD);
            this.Controls.Add(this.NAME);
            this.Controls.Add(this.Count_search);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EDIT);
            this.Controls.Add(this.dataGridViewList);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.REFRESH);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1278, 678);
            this.Name = "SEARCH_BOARD";
            this.Text = " DASHBOARD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Close);
            this.Load += new System.EventHandler(this.SEARCH_BOARD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ComboBox PART_NAME_FILTER;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox BIN_NUMBER_FILTER;
        private System.Windows.Forms.ComboBox VSPECS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEST_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn TESTER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEST_STEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE_ENCOUNTERED;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_OWNER;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDORSEMENT_NUMBER;
        private System.Windows.Forms.ComboBox STATUS_FILTER;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView HITCOUNT;
        private System.Windows.Forms.ColumnHeader DEVICE_NAME;
        private System.Windows.Forms.ColumnHeader HIT_COUNT;
        private System.Windows.Forms.Button SEARCH_PARETO;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox FISCAL_YEAR;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox QUARTER;
        private System.Windows.Forms.TextBox WORKWEEK;
    }
}