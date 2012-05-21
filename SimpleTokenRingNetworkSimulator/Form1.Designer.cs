namespace SimpleTokenRingNetworkSimulator
{
    partial class Form1
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
            this.gpBxNextHop = new System.Windows.Forms.GroupBox();
            this.numUpDwPortNextHop3 = new System.Windows.Forms.NumericUpDown();
            this.maskTbxIPNextHop3 = new System.Windows.Forms.MaskedTextBox();
            this.rbtnNextHop3 = new System.Windows.Forms.RadioButton();
            this.numUpDwPortNextHop2 = new System.Windows.Forms.NumericUpDown();
            this.maskTbxIPNextHop2 = new System.Windows.Forms.MaskedTextBox();
            this.rbtnNextHop2 = new System.Windows.Forms.RadioButton();
            this.numUpDwPortNextHop1 = new System.Windows.Forms.NumericUpDown();
            this.maskTbxIPNextHop1 = new System.Windows.Forms.MaskedTextBox();
            this.rbtnNextHop1 = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.gpBxSendFile = new System.Windows.Forms.GroupBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.rBtnChooseStationSendFile3 = new System.Windows.Forms.RadioButton();
            this.rBtnChooseStationSendFile2 = new System.Windows.Forms.RadioButton();
            this.rBtnChooseStationSendFile1 = new System.Windows.Forms.RadioButton();
            this.btnChooseFileSend = new System.Windows.Forms.Button();
            this.txtSendFile = new System.Windows.Forms.TextBox();
            this.ckBxIsTokenManager = new System.Windows.Forms.CheckBox();
            this.tbxLog = new System.Windows.Forms.RichTextBox();
            this.btnGenToken = new System.Windows.Forms.Button();
            this.btnHideNextToken = new System.Windows.Forms.Button();
            this.gpBxNextHop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPortNextHop3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPortNextHop2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPortNextHop1)).BeginInit();
            this.gpBxSendFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpBxNextHop
            // 
            this.gpBxNextHop.Controls.Add(this.numUpDwPortNextHop3);
            this.gpBxNextHop.Controls.Add(this.maskTbxIPNextHop3);
            this.gpBxNextHop.Controls.Add(this.rbtnNextHop3);
            this.gpBxNextHop.Controls.Add(this.numUpDwPortNextHop2);
            this.gpBxNextHop.Controls.Add(this.maskTbxIPNextHop2);
            this.gpBxNextHop.Controls.Add(this.rbtnNextHop2);
            this.gpBxNextHop.Controls.Add(this.numUpDwPortNextHop1);
            this.gpBxNextHop.Controls.Add(this.maskTbxIPNextHop1);
            this.gpBxNextHop.Controls.Add(this.rbtnNextHop1);
            this.gpBxNextHop.Location = new System.Drawing.Point(12, 40);
            this.gpBxNextHop.Name = "gpBxNextHop";
            this.gpBxNextHop.Size = new System.Drawing.Size(216, 105);
            this.gpBxNextHop.TabIndex = 0;
            this.gpBxNextHop.TabStop = false;
            this.gpBxNextHop.Text = "Next Hop";
            // 
            // numUpDwPortNextHop3
            // 
            this.numUpDwPortNextHop3.Location = new System.Drawing.Point(155, 73);
            this.numUpDwPortNextHop3.Maximum = new decimal(new int[] {
            11999,
            0,
            0,
            0});
            this.numUpDwPortNextHop3.Minimum = new decimal(new int[] {
            81,
            0,
            0,
            0});
            this.numUpDwPortNextHop3.Name = "numUpDwPortNextHop3";
            this.numUpDwPortNextHop3.Size = new System.Drawing.Size(55, 20);
            this.numUpDwPortNextHop3.TabIndex = 8;
            this.numUpDwPortNextHop3.Value = new decimal(new int[] {
            11002,
            0,
            0,
            0});
            // 
            // maskTbxIPNextHop3
            // 
            this.maskTbxIPNextHop3.Location = new System.Drawing.Point(54, 73);
            this.maskTbxIPNextHop3.Mask = "000\\.000\\.000\\.000";
            this.maskTbxIPNextHop3.Name = "maskTbxIPNextHop3";
            this.maskTbxIPNextHop3.Size = new System.Drawing.Size(95, 20);
            this.maskTbxIPNextHop3.TabIndex = 7;
            this.maskTbxIPNextHop3.Text = "127000000001";
            // 
            // rbtnNextHop3
            // 
            this.rbtnNextHop3.AutoSize = true;
            this.rbtnNextHop3.Location = new System.Drawing.Point(8, 75);
            this.rbtnNextHop3.Name = "rbtnNextHop3";
            this.rbtnNextHop3.Size = new System.Drawing.Size(31, 17);
            this.rbtnNextHop3.TabIndex = 6;
            this.rbtnNextHop3.Text = "3";
            this.rbtnNextHop3.UseVisualStyleBackColor = true;
            // 
            // numUpDwPortNextHop2
            // 
            this.numUpDwPortNextHop2.Location = new System.Drawing.Point(155, 47);
            this.numUpDwPortNextHop2.Maximum = new decimal(new int[] {
            11999,
            0,
            0,
            0});
            this.numUpDwPortNextHop2.Minimum = new decimal(new int[] {
            81,
            0,
            0,
            0});
            this.numUpDwPortNextHop2.Name = "numUpDwPortNextHop2";
            this.numUpDwPortNextHop2.Size = new System.Drawing.Size(55, 20);
            this.numUpDwPortNextHop2.TabIndex = 5;
            this.numUpDwPortNextHop2.Value = new decimal(new int[] {
            11001,
            0,
            0,
            0});
            // 
            // maskTbxIPNextHop2
            // 
            this.maskTbxIPNextHop2.Location = new System.Drawing.Point(54, 47);
            this.maskTbxIPNextHop2.Mask = "000\\.000\\.000\\.000";
            this.maskTbxIPNextHop2.Name = "maskTbxIPNextHop2";
            this.maskTbxIPNextHop2.Size = new System.Drawing.Size(95, 20);
            this.maskTbxIPNextHop2.TabIndex = 4;
            this.maskTbxIPNextHop2.Text = "127000000001";
            // 
            // rbtnNextHop2
            // 
            this.rbtnNextHop2.AutoSize = true;
            this.rbtnNextHop2.Checked = true;
            this.rbtnNextHop2.Location = new System.Drawing.Point(8, 49);
            this.rbtnNextHop2.Name = "rbtnNextHop2";
            this.rbtnNextHop2.Size = new System.Drawing.Size(31, 17);
            this.rbtnNextHop2.TabIndex = 3;
            this.rbtnNextHop2.TabStop = true;
            this.rbtnNextHop2.Text = "2";
            this.rbtnNextHop2.UseVisualStyleBackColor = true;
            // 
            // numUpDwPortNextHop1
            // 
            this.numUpDwPortNextHop1.Location = new System.Drawing.Point(155, 21);
            this.numUpDwPortNextHop1.Maximum = new decimal(new int[] {
            11999,
            0,
            0,
            0});
            this.numUpDwPortNextHop1.Minimum = new decimal(new int[] {
            81,
            0,
            0,
            0});
            this.numUpDwPortNextHop1.Name = "numUpDwPortNextHop1";
            this.numUpDwPortNextHop1.Size = new System.Drawing.Size(55, 20);
            this.numUpDwPortNextHop1.TabIndex = 2;
            this.numUpDwPortNextHop1.Value = new decimal(new int[] {
            11000,
            0,
            0,
            0});
            // 
            // maskTbxIPNextHop1
            // 
            this.maskTbxIPNextHop1.Location = new System.Drawing.Point(54, 21);
            this.maskTbxIPNextHop1.Mask = "000\\.000\\.000\\.000";
            this.maskTbxIPNextHop1.Name = "maskTbxIPNextHop1";
            this.maskTbxIPNextHop1.Size = new System.Drawing.Size(95, 20);
            this.maskTbxIPNextHop1.TabIndex = 1;
            this.maskTbxIPNextHop1.Text = "127000000001";
            // 
            // rbtnNextHop1
            // 
            this.rbtnNextHop1.AutoSize = true;
            this.rbtnNextHop1.Location = new System.Drawing.Point(8, 23);
            this.rbtnNextHop1.Name = "rbtnNextHop1";
            this.rbtnNextHop1.Size = new System.Drawing.Size(31, 17);
            this.rbtnNextHop1.TabIndex = 0;
            this.rbtnNextHop1.Text = "1";
            this.rbtnNextHop1.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 160);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(153, 160);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // gpBxSendFile
            // 
            this.gpBxSendFile.Controls.Add(this.btnSendFile);
            this.gpBxSendFile.Controls.Add(this.rBtnChooseStationSendFile3);
            this.gpBxSendFile.Controls.Add(this.rBtnChooseStationSendFile2);
            this.gpBxSendFile.Controls.Add(this.rBtnChooseStationSendFile1);
            this.gpBxSendFile.Controls.Add(this.btnChooseFileSend);
            this.gpBxSendFile.Controls.Add(this.txtSendFile);
            this.gpBxSendFile.Enabled = false;
            this.gpBxSendFile.Location = new System.Drawing.Point(12, 205);
            this.gpBxSendFile.Name = "gpBxSendFile";
            this.gpBxSendFile.Size = new System.Drawing.Size(216, 85);
            this.gpBxSendFile.TabIndex = 3;
            this.gpBxSendFile.TabStop = false;
            this.gpBxSendFile.Text = "Send File";
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(122, 46);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 5;
            this.btnSendFile.Text = "Send";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // rBtnChooseStationSendFile3
            // 
            this.rBtnChooseStationSendFile3.AutoSize = true;
            this.rBtnChooseStationSendFile3.Location = new System.Drawing.Point(84, 46);
            this.rBtnChooseStationSendFile3.Name = "rBtnChooseStationSendFile3";
            this.rBtnChooseStationSendFile3.Size = new System.Drawing.Size(31, 17);
            this.rBtnChooseStationSendFile3.TabIndex = 4;
            this.rBtnChooseStationSendFile3.TabStop = true;
            this.rBtnChooseStationSendFile3.Text = "3";
            this.rBtnChooseStationSendFile3.UseVisualStyleBackColor = true;
            // 
            // rBtnChooseStationSendFile2
            // 
            this.rBtnChooseStationSendFile2.AutoSize = true;
            this.rBtnChooseStationSendFile2.Location = new System.Drawing.Point(46, 46);
            this.rBtnChooseStationSendFile2.Name = "rBtnChooseStationSendFile2";
            this.rBtnChooseStationSendFile2.Size = new System.Drawing.Size(31, 17);
            this.rBtnChooseStationSendFile2.TabIndex = 3;
            this.rBtnChooseStationSendFile2.TabStop = true;
            this.rBtnChooseStationSendFile2.Text = "2";
            this.rBtnChooseStationSendFile2.UseVisualStyleBackColor = true;
            // 
            // rBtnChooseStationSendFile1
            // 
            this.rBtnChooseStationSendFile1.AutoSize = true;
            this.rBtnChooseStationSendFile1.Checked = true;
            this.rBtnChooseStationSendFile1.Location = new System.Drawing.Point(8, 46);
            this.rBtnChooseStationSendFile1.Name = "rBtnChooseStationSendFile1";
            this.rBtnChooseStationSendFile1.Size = new System.Drawing.Size(31, 17);
            this.rBtnChooseStationSendFile1.TabIndex = 2;
            this.rBtnChooseStationSendFile1.TabStop = true;
            this.rBtnChooseStationSendFile1.Text = "1";
            this.rBtnChooseStationSendFile1.UseVisualStyleBackColor = true;
            // 
            // btnChooseFileSend
            // 
            this.btnChooseFileSend.Location = new System.Drawing.Point(176, 16);
            this.btnChooseFileSend.Name = "btnChooseFileSend";
            this.btnChooseFileSend.Size = new System.Drawing.Size(34, 23);
            this.btnChooseFileSend.TabIndex = 1;
            this.btnChooseFileSend.Text = "...";
            this.btnChooseFileSend.UseVisualStyleBackColor = true;
            this.btnChooseFileSend.Click += new System.EventHandler(this.btnChooseFileSend_Click);
            // 
            // txtSendFile
            // 
            this.txtSendFile.Location = new System.Drawing.Point(8, 19);
            this.txtSendFile.Name = "txtSendFile";
            this.txtSendFile.ReadOnly = true;
            this.txtSendFile.Size = new System.Drawing.Size(147, 20);
            this.txtSendFile.TabIndex = 0;
            this.txtSendFile.Text = "c:\\temp\\testFile.txt";
            // 
            // ckBxIsTokenManager
            // 
            this.ckBxIsTokenManager.AutoSize = true;
            this.ckBxIsTokenManager.Checked = true;
            this.ckBxIsTokenManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBxIsTokenManager.Location = new System.Drawing.Point(12, 13);
            this.ckBxIsTokenManager.Name = "ckBxIsTokenManager";
            this.ckBxIsTokenManager.Size = new System.Drawing.Size(119, 17);
            this.ckBxIsTokenManager.TabIndex = 4;
            this.ckBxIsTokenManager.Text = "Is Token Manager?";
            this.ckBxIsTokenManager.UseVisualStyleBackColor = true;
            // 
            // tbxLog
            // 
            this.tbxLog.Location = new System.Drawing.Point(248, 13);
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ReadOnly = true;
            this.tbxLog.Size = new System.Drawing.Size(404, 306);
            this.tbxLog.TabIndex = 5;
            this.tbxLog.Text = "";
            this.tbxLog.TextChanged += new System.EventHandler(this.tbxLog_TextChanged);
            // 
            // btnGenToken
            // 
            this.btnGenToken.Enabled = false;
            this.btnGenToken.Location = new System.Drawing.Point(12, 296);
            this.btnGenToken.Name = "btnGenToken";
            this.btnGenToken.Size = new System.Drawing.Size(75, 23);
            this.btnGenToken.TabIndex = 6;
            this.btnGenToken.Text = "Gen Token";
            this.btnGenToken.UseVisualStyleBackColor = true;
            this.btnGenToken.Click += new System.EventHandler(this.btnGenToken_Click);
            // 
            // btnHideNextToken
            // 
            this.btnHideNextToken.Enabled = false;
            this.btnHideNextToken.Location = new System.Drawing.Point(117, 296);
            this.btnHideNextToken.Name = "btnHideNextToken";
            this.btnHideNextToken.Size = new System.Drawing.Size(105, 23);
            this.btnHideNextToken.TabIndex = 7;
            this.btnHideNextToken.Text = "Hide Next Token";
            this.btnHideNextToken.UseVisualStyleBackColor = true;
            this.btnHideNextToken.Click += new System.EventHandler(this.btnHideNextToken_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(673, 330);
            this.Controls.Add(this.btnHideNextToken);
            this.Controls.Add(this.btnGenToken);
            this.Controls.Add(this.tbxLog);
            this.Controls.Add(this.ckBxIsTokenManager);
            this.Controls.Add(this.gpBxSendFile);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gpBxNextHop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gpBxNextHop.ResumeLayout(false);
            this.gpBxNextHop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPortNextHop3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPortNextHop2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPortNextHop1)).EndInit();
            this.gpBxSendFile.ResumeLayout(false);
            this.gpBxSendFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpBxNextHop;
        private System.Windows.Forms.MaskedTextBox maskTbxIPNextHop1;
        private System.Windows.Forms.RadioButton rbtnNextHop1;
        private System.Windows.Forms.NumericUpDown numUpDwPortNextHop1;
        private System.Windows.Forms.NumericUpDown numUpDwPortNextHop3;
        private System.Windows.Forms.MaskedTextBox maskTbxIPNextHop3;
        private System.Windows.Forms.RadioButton rbtnNextHop3;
        private System.Windows.Forms.NumericUpDown numUpDwPortNextHop2;
        private System.Windows.Forms.MaskedTextBox maskTbxIPNextHop2;
        private System.Windows.Forms.RadioButton rbtnNextHop2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox gpBxSendFile;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.RadioButton rBtnChooseStationSendFile3;
        private System.Windows.Forms.RadioButton rBtnChooseStationSendFile2;
        private System.Windows.Forms.RadioButton rBtnChooseStationSendFile1;
        private System.Windows.Forms.Button btnChooseFileSend;
        private System.Windows.Forms.TextBox txtSendFile;
        private System.Windows.Forms.CheckBox ckBxIsTokenManager;
        private System.Windows.Forms.RichTextBox tbxLog;
        private System.Windows.Forms.Button btnGenToken;
        private System.Windows.Forms.Button btnHideNextToken;
    }
}

