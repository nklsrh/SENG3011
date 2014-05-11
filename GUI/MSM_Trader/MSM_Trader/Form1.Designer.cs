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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabInput = new System.Windows.Forms.TabPage();
            this.dataInput = new System.Windows.Forms.DataGridView();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.dataOutput = new System.Windows.Forms.DataGridView();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstStrategy = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAutoImport = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtVal_Threshold = new System.Windows.Forms.TextBox();
            this.txtVal_Window = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.openExecutable = new System.Windows.Forms.OpenFileDialog();
            this.tabEvaluator = new System.Windows.Forms.TabPage();
            this.txtEvaluation = new System.Windows.Forms.TextBox();
            this.dataEvaluation = new System.Windows.Forms.DataGridView();
            this.tabs.SuspendLayout();
            this.tabInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataInput)).BeginInit();
            this.tabOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOutput)).BeginInit();
            this.tabLog.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabEvaluator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEvaluation)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabs.Controls.Add(this.tabInput);
            this.tabs.Controls.Add(this.tabOutput);
            this.tabs.Controls.Add(this.tabLog);
            this.tabs.Controls.Add(this.tabEvaluator);
            this.tabs.Font = new System.Drawing.Font("Segoe WP", 10F);
            this.tabs.Location = new System.Drawing.Point(-1, 79);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(701, 446);
            this.tabs.TabIndex = 1;
            // 
            // tabInput
            // 
            this.tabInput.Controls.Add(this.dataInput);
            this.tabInput.Location = new System.Drawing.Point(4, 29);
            this.tabInput.Name = "tabInput";
            this.tabInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabInput.Size = new System.Drawing.Size(693, 413);
            this.tabInput.TabIndex = 0;
            this.tabInput.Text = "Input";
            this.tabInput.UseVisualStyleBackColor = true;
            // 
            // dataInput
            // 
            this.dataInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataInput.Location = new System.Drawing.Point(3, 3);
            this.dataInput.Name = "dataInput";
            this.dataInput.RowTemplate.Height = 24;
            this.dataInput.Size = new System.Drawing.Size(687, 407);
            this.dataInput.TabIndex = 0;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.dataOutput);
            this.tabOutput.Location = new System.Drawing.Point(4, 29);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(693, 413);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // dataOutput
            // 
            this.dataOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataOutput.Location = new System.Drawing.Point(3, 3);
            this.dataOutput.Name = "dataOutput";
            this.dataOutput.RowTemplate.Height = 24;
            this.dataOutput.Size = new System.Drawing.Size(687, 407);
            this.dataOutput.TabIndex = 1;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Location = new System.Drawing.Point(4, 29);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(693, 413);
            this.tabLog.TabIndex = 2;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(687, 407);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "Run a Strategy to collect logs.";
            // 
            // statusBar
            // 
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
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(163, 17);
            this.lblStatus.Text = "Ready, waiting for file import.";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImport.Location = new System.Drawing.Point(7, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 33);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEvaluate.Location = new System.Drawing.Point(606, 3);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(65, 56);
            this.btnEvaluate.TabIndex = 1;
            this.btnEvaluate.Text = "Evaluate";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Visible = false;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRun.Location = new System.Drawing.Point(478, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(74, 56);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run + Evaluate";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find Strategy";
            // 
            // lstStrategy
            // 
            this.lstStrategy.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStrategy.FormattingEnabled = true;
            this.lstStrategy.ItemHeight = 17;
            this.lstStrategy.Items.AddRange(new object[] {
            "Momentum"});
            this.lstStrategy.Location = new System.Drawing.Point(174, 31);
            this.lstStrategy.Name = "lstStrategy";
            this.lstStrategy.Size = new System.Drawing.Size(77, 21);
            this.lstStrategy.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.chkAutoImport);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.txtVal_Threshold);
            this.panel1.Controls.Add(this.txtVal_Window);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lstStrategy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnEvaluate);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 62);
            this.panel1.TabIndex = 0;
            // 
            // chkAutoImport
            // 
            this.chkAutoImport.AutoSize = true;
            this.chkAutoImport.Location = new System.Drawing.Point(8, 40);
            this.chkAutoImport.Name = "chkAutoImport";
            this.chkAutoImport.Size = new System.Drawing.Size(93, 17);
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
            this.btnFind.Location = new System.Drawing.Point(257, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(61, 56);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtVal_Threshold
            // 
            this.txtVal_Threshold.Location = new System.Drawing.Point(385, 35);
            this.txtVal_Threshold.Name = "txtVal_Threshold";
            this.txtVal_Threshold.Size = new System.Drawing.Size(87, 20);
            this.txtVal_Threshold.TabIndex = 8;
            this.txtVal_Threshold.Text = "0.001";
            // 
            // txtVal_Window
            // 
            this.txtVal_Window.Location = new System.Drawing.Point(385, 7);
            this.txtVal_Window.Name = "txtVal_Window";
            this.txtVal_Window.Size = new System.Drawing.Size(87, 20);
            this.txtVal_Window.TabIndex = 7;
            this.txtVal_Window.Text = "3";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Threshold";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Window";
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
            // tabEvaluator
            // 
            this.tabEvaluator.Controls.Add(this.dataEvaluation);
            this.tabEvaluator.Controls.Add(this.txtEvaluation);
            this.tabEvaluator.Location = new System.Drawing.Point(4, 29);
            this.tabEvaluator.Name = "tabEvaluator";
            this.tabEvaluator.Size = new System.Drawing.Size(693, 413);
            this.tabEvaluator.TabIndex = 3;
            this.tabEvaluator.Text = "Evaluation";
            this.tabEvaluator.UseVisualStyleBackColor = true;
            // 
            // txtEvaluation
            // 
            this.txtEvaluation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEvaluation.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.txtEvaluation.Location = new System.Drawing.Point(266, 0);
            this.txtEvaluation.Multiline = true;
            this.txtEvaluation.Name = "txtEvaluation";
            this.txtEvaluation.ReadOnly = true;
            this.txtEvaluation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEvaluation.Size = new System.Drawing.Size(427, 413);
            this.txtEvaluation.TabIndex = 1;
            this.txtEvaluation.Text = "Run + Evaluate to find evaluations...";
            // 
            // dataEvaluation
            // 
            this.dataEvaluation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataEvaluation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEvaluation.Location = new System.Drawing.Point(0, 0);
            this.dataEvaluation.Name = "dataEvaluation";
            this.dataEvaluation.RowTemplate.Height = 24;
            this.dataEvaluation.Size = new System.Drawing.Size(260, 413);
            this.dataEvaluation.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 548);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Rubber Ducky Trader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabs.ResumeLayout(false);
            this.tabInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataInput)).EndInit();
            this.tabOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataOutput)).EndInit();
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabEvaluator.ResumeLayout(false);
            this.tabEvaluator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEvaluation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ListBox lstStrategy;
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
    }
}

