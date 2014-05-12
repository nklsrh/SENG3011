namespace MSM_Trader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabInput = new System.Windows.Forms.TabPage();
            this.dataInput = new System.Windows.Forms.DataGridView();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.dataOutput = new System.Windows.Forms.DataGridView();
            this.tabEvaluator = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataEvaluation = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOverallReturn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPairCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEvaluation = new System.Windows.Forms.TextBox();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstStrategy = new System.Windows.Forms.ComboBox();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.chkAutoImport = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtVal_Threshold = new System.Windows.Forms.TextBox();
            this.txtVal_Window = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.openExecutable = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs.SuspendLayout();
            this.tabInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataInput)).BeginInit();
            this.tabOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOutput)).BeginInit();
            this.tabEvaluator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEvaluation)).BeginInit();
            this.tabLog.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabInput);
            this.tabs.Controls.Add(this.tabOutput);
            this.tabs.Controls.Add(this.tabEvaluator);
            this.tabs.Controls.Add(this.tabLog);
            this.tabs.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.tabs.Location = new System.Drawing.Point(-1, 95);
            this.tabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(701, 430);
            this.tabs.TabIndex = 1;
            // 
            // tabInput
            // 
            this.tabInput.Controls.Add(this.dataInput);
            this.tabInput.Location = new System.Drawing.Point(4, 26);
            this.tabInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabInput.Name = "tabInput";
            this.tabInput.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabInput.Size = new System.Drawing.Size(693, 400);
            this.tabInput.TabIndex = 0;
            this.tabInput.Text = "Input";
            this.tabInput.UseVisualStyleBackColor = true;
            // 
            // dataInput
            // 
            this.dataInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataInput.Location = new System.Drawing.Point(3, 2);
            this.dataInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataInput.Name = "dataInput";
            this.dataInput.ReadOnly = true;
            this.dataInput.RowTemplate.Height = 24;
            this.dataInput.Size = new System.Drawing.Size(687, 396);
            this.dataInput.TabIndex = 0;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.dataOutput);
            this.tabOutput.Location = new System.Drawing.Point(4, 26);
            this.tabOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabOutput.Size = new System.Drawing.Size(693, 400);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // dataOutput
            // 
            this.dataOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataOutput.Location = new System.Drawing.Point(3, 2);
            this.dataOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataOutput.Name = "dataOutput";
            this.dataOutput.ReadOnly = true;
            this.dataOutput.RowTemplate.Height = 24;
            this.dataOutput.Size = new System.Drawing.Size(687, 396);
            this.dataOutput.TabIndex = 1;
            // 
            // tabEvaluator
            // 
            this.tabEvaluator.Controls.Add(this.splitContainer1);
            this.tabEvaluator.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.tabEvaluator.Location = new System.Drawing.Point(4, 26);
            this.tabEvaluator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabEvaluator.Name = "tabEvaluator";
            this.tabEvaluator.Size = new System.Drawing.Size(693, 400);
            this.tabEvaluator.TabIndex = 3;
            this.tabEvaluator.Text = "Evaluation";
            this.tabEvaluator.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataEvaluation);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lblOverallReturn);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lblPairCount);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.txtEvaluation);
            this.splitContainer1.Size = new System.Drawing.Size(693, 400);
            this.splitContainer1.SplitterDistance = 451;
            this.splitContainer1.TabIndex = 5;
            // 
            // dataEvaluation
            // 
            this.dataEvaluation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEvaluation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataEvaluation.Location = new System.Drawing.Point(0, 0);
            this.dataEvaluation.Margin = new System.Windows.Forms.Padding(0);
            this.dataEvaluation.Name = "dataEvaluation";
            this.dataEvaluation.ReadOnly = true;
            this.dataEvaluation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataEvaluation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataEvaluation.RowTemplate.Height = 24;
            this.dataEvaluation.ShowEditingIcon = false;
            this.dataEvaluation.Size = new System.Drawing.Size(451, 400);
            this.dataEvaluation.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe WP", 11F);
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(11, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "on";
            // 
            // lblOverallReturn
            // 
            this.lblOverallReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverallReturn.AutoSize = true;
            this.lblOverallReturn.Font = new System.Drawing.Font("Segoe WP", 39F);
            this.lblOverallReturn.ForeColor = System.Drawing.Color.DarkGray;
            this.lblOverallReturn.Location = new System.Drawing.Point(4, 134);
            this.lblOverallReturn.Name = "lblOverallReturn";
            this.lblOverallReturn.Size = new System.Drawing.Size(123, 70);
            this.lblOverallReturn.TabIndex = 4;
            this.lblOverallReturn.Text = "N/A";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe WP", 11F);
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(11, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Overall returns";
            // 
            // lblPairCount
            // 
            this.lblPairCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPairCount.AutoSize = true;
            this.lblPairCount.Font = new System.Drawing.Font("Segoe WP", 24F);
            this.lblPairCount.ForeColor = System.Drawing.Color.DarkGray;
            this.lblPairCount.Location = new System.Drawing.Point(9, 237);
            this.lblPairCount.Name = "lblPairCount";
            this.lblPairCount.Size = new System.Drawing.Size(77, 45);
            this.lblPairCount.TabIndex = 8;
            this.lblPairCount.Text = "N/A";
            this.lblPairCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(11, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Buy/Sell pairs";
            // 
            // txtEvaluation
            // 
            this.txtEvaluation.BackColor = System.Drawing.Color.White;
            this.txtEvaluation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEvaluation.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.txtEvaluation.Location = new System.Drawing.Point(0, 0);
            this.txtEvaluation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEvaluation.Multiline = true;
            this.txtEvaluation.Name = "txtEvaluation";
            this.txtEvaluation.ReadOnly = true;
            this.txtEvaluation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEvaluation.Size = new System.Drawing.Size(238, 400);
            this.txtEvaluation.TabIndex = 1;
            this.txtEvaluation.Text = "Run + Evaluate to find evaluations...";
            this.txtEvaluation.Visible = false;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Location = new System.Drawing.Point(4, 26);
            this.tabLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLog.Size = new System.Drawing.Size(693, 400);
            this.tabLog.TabIndex = 2;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(3, 2);
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(687, 396);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "Run a Strategy to collect logs.";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lstStrategy);
            this.panel1.Controls.Add(this.btnEvaluate);
            this.panel1.Controls.Add(this.chkAutoImport);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.txtVal_Threshold);
            this.panel1.Controls.Add(this.txtVal_Window);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.ForeColor = System.Drawing.Color.Indigo;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 63);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox2.Location = new System.Drawing.Point(137, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(3, 53);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(623, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // lstStrategy
            // 
            this.lstStrategy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lstStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstStrategy.FormattingEnabled = true;
            this.lstStrategy.Items.AddRange(new object[] {
            "RubberDucky - Group 4",
            "Actuators - Group 1",
            "YOPO - Group 9"});
            this.lstStrategy.Location = new System.Drawing.Point(165, 29);
            this.lstStrategy.Name = "lstStrategy";
            this.lstStrategy.Size = new System.Drawing.Size(225, 21);
            this.lstStrategy.TabIndex = 15;
            this.lstStrategy.SelectedIndexChanged += new System.EventHandler(this.lstStrategy_SelectedIndexChanged);
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEvaluate.Location = new System.Drawing.Point(656, 2);
            this.btnEvaluate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(40, 56);
            this.btnEvaluate.TabIndex = 1;
            this.btnEvaluate.Text = "Evaluate";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Visible = false;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // chkAutoImport
            // 
            this.chkAutoImport.AutoSize = true;
            this.chkAutoImport.Location = new System.Drawing.Point(7, 41);
            this.chkAutoImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAutoImport.Name = "chkAutoImport";
            this.chkAutoImport.Size = new System.Drawing.Size(103, 17);
            this.chkAutoImport.TabIndex = 10;
            this.chkAutoImport.Text = "Import on start";
            this.chkAutoImport.UseVisualStyleBackColor = true;
            this.chkAutoImport.CheckedChanged += new System.EventHandler(this.chkAutoImport_CheckedChanged);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFind.Location = new System.Drawing.Point(623, 3);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(77, 55);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Find executable";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtVal_Threshold
            // 
            this.txtVal_Threshold.Location = new System.Drawing.Point(471, 35);
            this.txtVal_Threshold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVal_Threshold.Name = "txtVal_Threshold";
            this.txtVal_Threshold.Size = new System.Drawing.Size(42, 22);
            this.txtVal_Threshold.TabIndex = 8;
            this.txtVal_Threshold.Text = "0.0001";
            // 
            // txtVal_Window
            // 
            this.txtVal_Window.Location = new System.Drawing.Point(471, 7);
            this.txtVal_Window.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVal_Window.Name = "txtVal_Window";
            this.txtVal_Window.Size = new System.Drawing.Size(42, 22);
            this.txtVal_Window.TabIndex = 7;
            this.txtVal_Window.Text = "7";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Threshold";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Window";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Use Strategy";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRun.BackgroundImage")));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRun.Location = new System.Drawing.Point(532, 2);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(85, 59);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Immediate Execution";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImport.Location = new System.Drawing.Point(6, 4);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(104, 33);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import Sirca CSV";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(31)))), ((int)(((byte)(71)))));
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 526);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(699, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(163, 17);
            this.lblStatus.Text = "Ready, waiting for file import.";
            // 
            // openFile
            // 
            this.openFile.DefaultExt = "csv";
            this.openFile.FileName = "inputFile";
            this.openFile.Filter = "Sirca CSV|*.csv";
            this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
            // 
            // openExecutable
            // 
            this.openExecutable.DefaultExt = "csv";
            this.openExecutable.FileName = "MSM";
            this.openExecutable.Filter = "Java JAR|*.jar";
            this.openExecutable.FileOk += new System.ComponentModel.CancelEventHandler(this.openExecutable_FileOk);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.25F);
            this.label7.ForeColor = System.Drawing.Color.Sienna;
            this.label7.Location = new System.Drawing.Point(477, 525);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Rubber Ducky Trader";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lblVersion.ForeColor = System.Drawing.Color.Silver;
            this.lblVersion.Location = new System.Drawing.Point(654, 528);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(31, 17);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "v1.0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem.Text = "Import...";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(116, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(31)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(699, 548);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(715, 587);
            this.Name = "Form1";
            this.Text = "Rubber Ducky Trader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabs.ResumeLayout(false);
            this.tabInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataInput)).EndInit();
            this.tabOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataOutput)).EndInit();
            this.tabEvaluator.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataEvaluation)).EndInit();
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabInput;
        private System.Windows.Forms.DataGridView dataInput;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.DataGridView dataOutput;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtVal_Threshold;
        private System.Windows.Forms.TextBox txtVal_Window;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.CheckBox chkAutoImport;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.OpenFileDialog openExecutable;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TabPage tabEvaluator;
        private System.Windows.Forms.TextBox txtEvaluation;
        private System.Windows.Forms.DataGridView dataEvaluation;
        private System.Windows.Forms.ComboBox lstStrategy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOverallReturn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPairCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

