namespace Network_Stresser
{
	partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.chkWaitReply = new System.Windows.Forms.CheckBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtSubsite = new System.Windows.Forms.TextBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.txtThreads = new System.Windows.Forms.TextBox();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.cmdAttack = new System.Windows.Forms.Button();
            this.TTip = new System.Windows.Forms.ToolTip(this.components);
            this.tShowStats = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAdvanced = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssRequested = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssFailed = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(96, 12);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(190, 20);
            this.txtTarget.TabIndex = 1;
            this.TTip.SetToolTip(this.txtTarget, "Target host to attack");
            // 
            // chkWaitReply
            // 
            this.chkWaitReply.AutoSize = true;
            this.chkWaitReply.Checked = true;
            this.chkWaitReply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaitReply.Location = new System.Drawing.Point(146, 150);
            this.chkWaitReply.Name = "chkWaitReply";
            this.chkWaitReply.Size = new System.Drawing.Size(88, 17);
            this.chkWaitReply.TabIndex = 7;
            this.chkWaitReply.Text = "Wait for reply";
            this.TTip.SetToolTip(this.chkWaitReply, "Don\'t disconnect before the server\'s started to answer");
            this.chkWaitReply.UseVisualStyleBackColor = true;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(65, 96);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(269, 20);
            this.txtData.TabIndex = 3;
            this.txtData.Text = "Lorem ipsum dolor sit amet.";
            this.TTip.SetToolTip(this.txtData, "The data to send in TCP/UDP mode");
            // 
            // txtSubsite
            // 
            this.txtSubsite.Location = new System.Drawing.Point(65, 70);
            this.txtSubsite.Name = "txtSubsite";
            this.txtSubsite.Size = new System.Drawing.Size(269, 20);
            this.txtSubsite.TabIndex = 2;
            this.txtSubsite.Text = "/";
            this.TTip.SetToolTip(this.txtSubsite, "What subsite to target (when using HTTP as type)");
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(65, 122);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(75, 20);
            this.txtTimeout.TabIndex = 1;
            this.txtTimeout.Text = "9001";
            this.TTip.SetToolTip(this.txtTimeout, "Max time to wait for a response");
            // 
            // txtThreads
            // 
            this.txtThreads.Location = new System.Drawing.Point(65, 148);
            this.txtThreads.Name = "txtThreads";
            this.txtThreads.Size = new System.Drawing.Size(75, 20);
            this.txtThreads.TabIndex = 6;
            this.txtThreads.Text = "10";
            this.TTip.SetToolTip(this.txtThreads, "How many users LOIC should emulate");
            // 
            // cbMethod
            // 
            this.cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "TCP",
            "UDP",
            "HTTP"});
            this.cbMethod.Location = new System.Drawing.Point(15, 12);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(75, 21);
            this.cbMethod.TabIndex = 5;
            this.TTip.SetToolTip(this.cbMethod, "Type of attack");
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(298, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(34, 20);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "80";
            this.TTip.SetToolTip(this.txtPort, "Port to attack");
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(65, 173);
            this.tbSpeed.Maximum = 20;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(269, 45);
            this.tbSpeed.TabIndex = 8;
            this.tbSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbSpeed.ValueChanged += new System.EventHandler(this.tbSpeed_ValueChanged);
            // 
            // cmdAttack
            // 
            this.cmdAttack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdAttack.Location = new System.Drawing.Point(220, 38);
            this.cmdAttack.Name = "cmdAttack";
            this.cmdAttack.Size = new System.Drawing.Size(112, 21);
            this.cmdAttack.TabIndex = 1;
            this.cmdAttack.Text = "Start";
            this.cmdAttack.UseVisualStyleBackColor = true;
            this.cmdAttack.Click += new System.EventHandler(this.cmdAttack_Click);
            // 
            // tShowStats
            // 
            this.tShowStats.Interval = 10;
            this.tShowStats.Tick += new System.EventHandler(this.tShowStats_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Timeout";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Threads";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = ":";
            // 
            // chkAdvanced
            // 
            this.chkAdvanced.AutoSize = true;
            this.chkAdvanced.Location = new System.Drawing.Point(15, 41);
            this.chkAdvanced.Name = "chkAdvanced";
            this.chkAdvanced.Size = new System.Drawing.Size(75, 17);
            this.chkAdvanced.TabIndex = 18;
            this.chkAdvanced.Text = "Advanced";
            this.chkAdvanced.UseVisualStyleBackColor = true;
            this.chkAdvanced.CheckedChanged += new System.EventHandler(this.chkAdvanced_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssRequested,
            this.tssFailed});
            this.statusStrip1.Location = new System.Drawing.Point(0, 68);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(344, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssRequested
            // 
            this.tssRequested.Name = "tssRequested";
            this.tssRequested.Size = new System.Drawing.Size(74, 17);
            this.tssRequested.Text = "Requested: 0";
            // 
            // tssFailed
            // 
            this.tssFailed.Name = "tssFailed";
            this.tssFailed.Size = new System.Drawing.Size(50, 17);
            this.tssFailed.Text = "Failed: 0";
            // 
            // frmMain
            // 
            this.AcceptButton = this.cmdAttack;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdAttack;
            this.ClientSize = new System.Drawing.Size(344, 90);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkAdvanced);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdAttack);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.cbMethod);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.chkWaitReply);
            this.Controls.Add(this.txtSubsite);
            this.Controls.Add(this.txtThreads);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.txtData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 270);
            this.MinimumSize = new System.Drawing.Size(360, 128);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox txtTarget;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.TextBox txtThreads;
		private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Button cmdAttack;
		private System.Windows.Forms.TextBox txtSubsite;
		private System.Windows.Forms.ToolTip TTip;
		private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Timer tShowStats;
		private System.Windows.Forms.CheckBox chkWaitReply;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAdvanced;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssRequested;
        private System.Windows.Forms.ToolStripStatusLabel tssFailed;

	}
}

