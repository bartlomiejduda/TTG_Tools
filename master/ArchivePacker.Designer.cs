namespace TTG_Tools
{
    partial class ArchivePacker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchivePacker));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ttarch2RB = new System.Windows.Forms.RadioButton();
            this.ttarchRB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buildButton = new System.Windows.Forms.Button();
            this.checkCompress = new System.Windows.Forms.CheckBox();
            this.versionSelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.EncryptIt = new System.Windows.Forms.CheckBox();
            this.comboGameList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkXmode = new System.Windows.Forms.CheckBox();
            this.DontEncLuaCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.newEngineLua = new System.Windows.Forms.CheckBox();
            this.CheckCustomKey = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ttarch2RB);
            this.groupBox1.Controls.Add(this.ttarchRB);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TTARCH/TTARCH2";
            // 
            // ttarch2RB
            // 
            this.ttarch2RB.AutoSize = true;
            this.ttarch2RB.Location = new System.Drawing.Point(5, 46);
            this.ttarch2RB.Name = "ttarch2RB";
            this.ttarch2RB.Size = new System.Drawing.Size(190, 20);
            this.ttarch2RB.TabIndex = 1;
            this.ttarch2RB.TabStop = true;
            this.ttarch2RB.Text = "TTARCH2 (newer games)";
            this.ttarch2RB.UseVisualStyleBackColor = true;
            this.ttarch2RB.CheckedChanged += new System.EventHandler(this.ttarch2RB_CheckedChanged);
            // 
            // ttarchRB
            // 
            this.ttarchRB.AutoSize = true;
            this.ttarchRB.Location = new System.Drawing.Point(5, 18);
            this.ttarchRB.Name = "ttarchRB";
            this.ttarchRB.Size = new System.Drawing.Size(163, 20);
            this.ttarchRB.TabIndex = 0;
            this.ttarchRB.TabStop = true;
            this.ttarchRB.Text = "TTARCH (old games)";
            this.ttarchRB.UseVisualStyleBackColor = true;
            this.ttarchRB.CheckedChanged += new System.EventHandler(this.ttarchRB_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output archive:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(225, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(122, 144);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(225, 22);
            this.textBox2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(352, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(268, 175);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(97, 23);
            this.buildButton.TabIndex = 7;
            this.buildButton.Text = "Build archive";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // checkCompress
            // 
            this.checkCompress.AutoSize = true;
            this.checkCompress.Location = new System.Drawing.Point(663, 65);
            this.checkCompress.Name = "checkCompress";
            this.checkCompress.Size = new System.Drawing.Size(144, 20);
            this.checkCompress.TabIndex = 8;
            this.checkCompress.Text = "Compress archive";
            this.checkCompress.UseVisualStyleBackColor = true;
            // 
            // versionSelection
            // 
            this.versionSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionSelection.FormattingEnabled = true;
            this.versionSelection.Location = new System.Drawing.Point(347, 62);
            this.versionSelection.Name = "versionSelection";
            this.versionSelection.Size = new System.Drawing.Size(43, 24);
            this.versionSelection.TabIndex = 9;
            this.versionSelection.SelectedIndexChanged += new System.EventHandler(this.versionSelection_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Version of archive:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(35, 175);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(212, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 12;
            // 
            // EncryptIt
            // 
            this.EncryptIt.AutoSize = true;
            this.EncryptIt.Location = new System.Drawing.Point(421, 125);
            this.EncryptIt.Name = "EncryptIt";
            this.EncryptIt.Size = new System.Drawing.Size(128, 20);
            this.EncryptIt.TabIndex = 13;
            this.EncryptIt.Text = "Encrypt archive";
            this.EncryptIt.UseVisualStyleBackColor = true;
            // 
            // comboGameList
            // 
            this.comboGameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGameList.FormattingEnabled = true;
            this.comboGameList.Location = new System.Drawing.Point(529, 177);
            this.comboGameList.MaxDropDownItems = 9;
            this.comboGameList.Name = "comboGameList";
            this.comboGameList.Size = new System.Drawing.Size(290, 24);
            this.comboGameList.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "List of encryption key:";
            // 
            // checkXmode
            // 
            this.checkXmode.AutoSize = true;
            this.checkXmode.Location = new System.Drawing.Point(430, 65);
            this.checkXmode.Name = "checkXmode";
            this.checkXmode.Size = new System.Drawing.Size(227, 20);
            this.checkXmode.TabIndex = 16;
            this.checkXmode.Text = "Xmode (For some old archives)";
            this.checkXmode.UseVisualStyleBackColor = true;
            // 
            // DontEncLuaCheck
            // 
            this.DontEncLuaCheck.AutoSize = true;
            this.DontEncLuaCheck.Location = new System.Drawing.Point(421, 151);
            this.DontEncLuaCheck.Name = "DontEncLuaCheck";
            this.DontEncLuaCheck.Size = new System.Drawing.Size(142, 20);
            this.DontEncLuaCheck.TabIndex = 17;
            this.DontEncLuaCheck.Text = "Don\'t encrypt Lua";
            this.DontEncLuaCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Encryption functions:";
            // 
            // newEngineLua
            // 
            this.newEngineLua.AutoSize = true;
            this.newEngineLua.Location = new System.Drawing.Point(584, 125);
            this.newEngineLua.Name = "newEngineLua";
            this.newEngineLua.Size = new System.Drawing.Size(202, 20);
            this.newEngineLua.TabIndex = 19;
            this.newEngineLua.Text = "Encrypt Lua for new games";
            this.newEngineLua.UseVisualStyleBackColor = true;
            // 
            // CheckCustomKey
            // 
            this.CheckCustomKey.AutoSize = true;
            this.CheckCustomKey.Location = new System.Drawing.Point(329, 214);
            this.CheckCustomKey.Name = "CheckCustomKey";
            this.CheckCustomKey.Size = new System.Drawing.Size(194, 20);
            this.CheckCustomKey.TabIndex = 20;
            this.CheckCustomKey.Text = "Custom key of encryption:";
            this.CheckCustomKey.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(529, 212);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(290, 22);
            this.textBox3.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Typical functions:";
            // 
            // ArchivePacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 246);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.CheckCustomKey);
            this.Controls.Add(this.newEngineLua);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DontEncLuaCheck);
            this.Controls.Add(this.checkXmode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboGameList);
            this.Controls.Add(this.EncryptIt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.versionSelection);
            this.Controls.Add(this.checkCompress);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArchivePacker";
            this.Text = "Archive packer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchivePacker_FormClosing);
            this.Load += new System.EventHandler(this.ArchivePacker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ttarch2RB;
        private System.Windows.Forms.RadioButton ttarchRB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.CheckBox checkCompress;
        private System.Windows.Forms.ComboBox versionSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox EncryptIt;
        private System.Windows.Forms.ComboBox comboGameList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkXmode;
        private System.Windows.Forms.CheckBox DontEncLuaCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox newEngineLua;
        private System.Windows.Forms.CheckBox CheckCustomKey;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
    }
}