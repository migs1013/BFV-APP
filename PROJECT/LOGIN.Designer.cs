
namespace PROJECT
{
    partial class LOGIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.User = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.REG_CONFIRM = new System.Windows.Forms.TextBox();
            this.REG_PASS = new System.Windows.Forms.TextBox();
            this.REG_USER = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.REGISTER = new System.Windows.Forms.Button();
            this.UPDATE_BTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "USERNAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "PASSWORD";
            // 
            // User
            // 
            this.User.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.User.Location = new System.Drawing.Point(111, 12);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(149, 20);
            this.User.TabIndex = 2;
            this.User.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User_Enter);
            // 
            // Pass
            // 
            this.Pass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Pass.Location = new System.Drawing.Point(111, 53);
            this.Pass.Name = "Pass";
            this.Pass.PasswordChar = '*';
            this.Pass.Size = new System.Drawing.Size(149, 20);
            this.Pass.TabIndex = 3;
            this.Pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pass_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(127, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Aqua;
            this.groupBox1.Controls.Add(this.REG_CONFIRM);
            this.groupBox1.Controls.Add(this.REG_PASS);
            this.groupBox1.Controls.Add(this.REG_USER);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.REGISTER);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(8, 166);
            this.groupBox1.MinimumSize = new System.Drawing.Size(337, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 238);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CREATE ACCOUNT";
            // 
            // REG_CONFIRM
            // 
            this.REG_CONFIRM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.REG_CONFIRM.Location = new System.Drawing.Point(238, 111);
            this.REG_CONFIRM.Name = "REG_CONFIRM";
            this.REG_CONFIRM.PasswordChar = '*';
            this.REG_CONFIRM.Size = new System.Drawing.Size(213, 22);
            this.REG_CONFIRM.TabIndex = 6;
            // 
            // REG_PASS
            // 
            this.REG_PASS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.REG_PASS.Location = new System.Drawing.Point(238, 71);
            this.REG_PASS.Name = "REG_PASS";
            this.REG_PASS.PasswordChar = '*';
            this.REG_PASS.Size = new System.Drawing.Size(213, 22);
            this.REG_PASS.TabIndex = 5;
            // 
            // REG_USER
            // 
            this.REG_USER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.REG_USER.Location = new System.Drawing.Point(238, 32);
            this.REG_USER.Name = "REG_USER";
            this.REG_USER.Size = new System.Drawing.Size(213, 22);
            this.REG_USER.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "CONFIRM PASSWORD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "PASSWORD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "USERNAME";
            // 
            // REGISTER
            // 
            this.REGISTER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.REGISTER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.REGISTER.Location = new System.Drawing.Point(278, 192);
            this.REGISTER.Name = "REGISTER";
            this.REGISTER.Size = new System.Drawing.Size(131, 23);
            this.REGISTER.TabIndex = 0;
            this.REGISTER.Text = "REGISTER";
            this.REGISTER.UseVisualStyleBackColor = false;
            this.REGISTER.Click += new System.EventHandler(this.REGISTER_Click);
            // 
            // UPDATE_BTN
            // 
            this.UPDATE_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(105)))));
            this.UPDATE_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UPDATE_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.UPDATE_BTN.Location = new System.Drawing.Point(376, 13);
            this.UPDATE_BTN.Name = "UPDATE_BTN";
            this.UPDATE_BTN.Size = new System.Drawing.Size(113, 33);
            this.UPDATE_BTN.TabIndex = 6;
            this.UPDATE_BTN.Text = "UPDATE APP";
            this.UPDATE_BTN.UseVisualStyleBackColor = false;
            this.UPDATE_BTN.Visible = false;
            this.UPDATE_BTN.Click += new System.EventHandler(this.UPDATE_BTN_Click);
            // 
            // LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(501, 416);
            this.Controls.Add(this.UPDATE_BTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.User);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(517, 455);
            this.MinimumSize = new System.Drawing.Size(517, 455);
            this.Name = "LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN (VERSION 1)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exit);
            this.Load += new System.EventHandler(this.LOGIN_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox User;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox REG_CONFIRM;
        private System.Windows.Forms.TextBox REG_PASS;
        private System.Windows.Forms.TextBox REG_USER;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button REGISTER;
        private System.Windows.Forms.Button UPDATE_BTN;
    }
}