using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace MSM_Trader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string inputFileName;
        public string inputFileURL;
        
        public string executableURL;
        public string executableArguments;

        public string evaluatorURL;

        public string version = RubberDuckyTrader.Properties.Settings.Default.version;

        public Strategy strategy = Strategy.RubberDucky;

        public string threshold;
        public string window;
        
        public string settingsFile = System.IO.Directory.GetCurrentDirectory() + "\\TraderSettings.cfg";

        public bool importOnStart = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            openFile.InitialDirectory = System.IO.Directory.GetCurrentDirectory();

            EnableDisableUIElements(GUI_Steps.Import);
            lstStrategy.SelectedIndex = 0;

            version = RubberDuckyTrader.Properties.Settings.Default.version;

            if (LoadSettingsFile())
            {
                openFile.InitialDirectory = inputFileName;
                if (importOnStart && inputFileName.Length > 0)
                {
                    OpenCSV(dataInput, inputFileName);
                    ReadLog();
                    ReadEvaluation();
                    UpdateEvaluatedData();
                }
            }
            else
            {
                executableURL = System.IO.Directory.GetCurrentDirectory() + "\\MSM_v4.jar";
                executableArguments = System.IO.Directory.GetCurrentDirectory() + "\\arguments.txt";
                evaluatorURL = System.IO.Directory.GetCurrentDirectory() + "\\Evaluator.jar";
                threshold = "0.0001";
                window = "7";
                WriteSettingsFile();
            }

            cbVals.SelectedIndex = 0;

            lblVersion.Text = "v" + version;
        }

        public bool LoadSettingsFile()
        {
            if (System.IO.File.Exists(settingsFile))
            {
                try
                {
                    System.IO.StreamReader fileReader = new System.IO.StreamReader(settingsFile, false);

                    bool writeSettingsAfter = true;

                    lblStatus.Text = "Reading settings file.";
                    int lineNumber = 0;
                    //Reading Data
                    while (fileReader.Peek() != -1)
                    {
                        string fileRow = fileReader.ReadLine();
                        string[] fileDataField = fileRow.Split('=');

                        if (fileDataField.Length > 0)
                        {
                            if (fileDataField[0] == "tradingStrategyExecutable")
                            {
                                if (fileDataField[1].Substring(fileDataField[1].Length - 3, 3) == "jar")
                                {
                                    executableURL = fileDataField[1];
                                }
                            }
                            else if (fileDataField[0] == "argumentsFile")
                            {
                                if (fileDataField[1].Substring(fileDataField[1].Length - 3, 3) == "txt")
                                {
                                    executableArguments = fileDataField[1];
                                }
                            }
                            else if (fileDataField[0] == "evaluatorExecutable")
                            {
                                if (fileDataField[1].Substring(fileDataField[1].Length - 3, 3) == "jar")
                                {
                                    evaluatorURL = fileDataField[1];
                                }
                            }
                            else if (fileDataField[0] == "inputCSVFile")
                            {
                                inputFileURL = fileDataField[1];
                                inputFileName = inputFileURL.Split('/')[inputFileURL.Split('/').Length - 1];
                            }
                            else if (fileDataField[0] == "threshold")
                            {
                                threshold = fileDataField[1];
                                txtVal_Threshold.Text = threshold;
                            }
                            else if (fileDataField[0] == "window")
                            {
                                window = fileDataField[1];
                                txtVal_Window.Text = window;
                            }
                            else if (fileDataField[0] == "importOnStart")
                            {
                                importOnStart = fileDataField[1] == "True";
                                chkAutoImport.Checked = importOnStart;
                            }
                            else if (fileDataField[0] == "version")
                            {
                                if (Convert.ToDouble(version) > Convert.ToDouble(fileDataField[1]))
                                {
                                    writeSettingsAfter = true;
                                }
                                else
                                {
                                    version = fileDataField[1];
                                    writeSettingsAfter = false;
                                }
                            }
                        }
                        lineNumber++;
                    }
                    fileReader.Dispose();
                    fileReader.Close();

                    evaluatorURL = System.IO.Directory.GetCurrentDirectory() + "\\Evaluator.jar";

                    if (writeSettingsAfter)
                    {
                        WriteSettingsFile();
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool WriteSettingsFile ()
        {
            try
            {
                System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(settingsFile, false);
                fileWriter.WriteLine("tradingStrategyExecutable=" + executableURL);
                fileWriter.WriteLine("argumentsFile=" + executableArguments);
                fileWriter.WriteLine("evaluatorExecutable=" + evaluatorURL);
                fileWriter.WriteLine("inputCSVFile=" + inputFileURL);
                fileWriter.WriteLine("threshold=" + threshold);
                fileWriter.WriteLine("window=" + window);
                fileWriter.WriteLine("importOnStart=" + importOnStart);
                fileWriter.WriteLine("version=" + version);
                fileWriter.Dispose();
                fileWriter.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            tabs.SelectedIndex = 0;
            tabsInput.SelectedIndex = 1;
        }

        private void openFile_FileOk(object sender, CancelEventArgs e)
        {
            inputFileName = openFile.SafeFileName;
            inputFileURL = openFile.FileName;

            lblStatus.Text = "Input file found. Loading...";

            WriteSettingsFile();
            SetInputFile();
        }


        public void SetInputFile()
        {
            OpenCSV(dataInput, inputFileURL);
        }

        public void OpenCSV(DataGridView dataInput, string csvPath)
        {
            dataInput.Rows.Clear();
            try
            {
                if (System.IO.File.Exists(csvPath))
                {
                    ReadUpdateCSV(dataInput, csvPath, true);

                    if (executableURL != "")
                    {
                        EnableDisableUIElements(GUI_Steps.Run);
                    }
                    else
                    {
                        EnableDisableUIElements(GUI_Steps.Find);
                    }
                    this.Text = System.IO.Path.GetFileName(inputFileURL) + " - Rubber Ducky Trader";
                }
                else
                {
                    MessageBox.Show("Couldn't find CSV. Delete TraderSettings.cfg and Import a new CSV.");
                    lblStatus.Text = "No CSV file imported.";
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
            finally 
            {
                lblStatus.Text = "Ready.";
            }
        }

        void ReadUpdateCSV(DataGridView dataInput, string csvPath, bool firstRowIsHeader)
        {
            try
            {
                dataInput.Rows.Clear();
                dataInput.Columns.Clear();
                System.IO.StreamReader fileReader = new System.IO.StreamReader(csvPath, false);

                //Reading Data
                while (fileReader.Peek() != -1)
                {
                    string fileRow = fileReader.ReadLine();
                    string[] fileDataField = fileRow.Split(',');

                    int i = 0;
                    while (dataInput.Columns.Count < fileDataField.Length)
                    {
                        dataInput.Columns.Add(fileDataField[i], fileDataField[i]);
                        dataInput.Columns[i].Name = fileDataField[i];
                        if (firstRowIsHeader)
                        {
                            i++;
                        }
                    }
                    if (i == 0) // skipping first line which is header
                    {
                        dataInput.Rows.Add(fileDataField);
                    }
                }
                fileReader.Dispose();
                fileReader.Close();
                lblStatus.Text = "Loaded CSV = " + System.IO.Path.GetFileName(csvPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't read CSV: " + ex.Message);
            }
        }

        private void chkAutoImport_CheckedChanged(object sender, EventArgs e)
        {
            importOnStart = chkAutoImport.Checked;
            WriteSettingsFile();
        }

        public enum Strategy
        {
            RubberDucky,
            Actuators,
            YOPO
        }

        private void lstStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstStrategy.SelectedIndex)
            {
                case 0:
                    SwitchStrategy(Strategy.RubberDucky);
                    break;
                case 1:
                    SwitchStrategy(Strategy.Actuators);
                    break;
                case 2:
                    SwitchStrategy(Strategy.YOPO);
                    break;
            }
        }

        public void SwitchStrategy (Strategy newStrategy)
        {
            strategy = newStrategy;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            openExecutable.ShowDialog();
        }

        private void openExecutable_FileOk(object sender, CancelEventArgs e)
        {
            executableURL = openExecutable.FileName;
            executableArguments = System.IO.Path.GetDirectoryName(executableURL) + "\\arguments.txt";

            WriteSettingsFile();

            EnableDisableUIElements(GUI_Steps.Run);
        }
        
        public enum GUI_Steps
        {
            Import,
            Find,
            Run,
            Export
        }

        public void EnableDisableUIElements(GUI_Steps step)
        {
            switch (step)
            {
                case GUI_Steps.Import:
                    btnFind.Enabled = false;
                    btnRun.Enabled = false;
                    btnEvaluate.Enabled = false;
                    txtVal_Threshold.Enabled = false;
                    txtVal_Window.Enabled = false;
                    lstStrategy.Enabled = false;
                    chkAutoImport.Enabled = false;
                    tabInput.Enabled = false;
                    chart2.Enabled = false;
                    break;
                case GUI_Steps.Find:
                    btnFind.Enabled = true;
                    btnRun.Enabled = true;
                    btnEvaluate.Enabled = false;
                    txtVal_Threshold.Enabled = true;
                    txtVal_Window.Enabled = true;
                    lstStrategy.Enabled = true;
                    chkAutoImport.Enabled = true;
                    tabInput.Enabled = true;
                    chart2.Enabled = false;
                    break;
                case GUI_Steps.Run:
                    btnFind.Enabled = true;
                    btnRun.Enabled = true;
                    btnEvaluate.Enabled = false;
                    txtVal_Threshold.Enabled = true;
                    txtVal_Window.Enabled = true;
                    lstStrategy.Enabled = true;
                    chkAutoImport.Enabled = true;
                    tabInput.Enabled = true;
                    chart2.Enabled = true;
                    break;
                case GUI_Steps.Export:
                    btnFind.Enabled = true;
                    btnRun.Enabled = true;
                    btnEvaluate.Enabled = true;
                    txtVal_Threshold.Enabled = true;
                    txtVal_Window.Enabled = true;
                    lstStrategy.Enabled = true;
                    chkAutoImport.Enabled = true;
                    tabInput.Enabled = true;
                    chart2.Enabled = true;
                    break;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            switch (strategy)
            { 
                case Strategy.RubberDucky:
                    RunStrategy_RubberDucky();
                    break;
                case Strategy.Actuators:
                    RunStrategy_Actuators();
                    break;
                case Strategy.YOPO:
                    RunStrategy_YOPO();
                    break;
            }

            UpdateEvalChart();
        }

        void RunStrategy_RubberDucky()
        {
            if (UpdateArgumentsTXT() && Run_MSM() && Run_Evaluator())
            {
                WriteSettingsFile();
                EnableDisableUIElements(GUI_Steps.Export);
                ReadLog();
                UpdateEvaluatedData();
            }
        }
        void RunStrategy_Actuators()
        {
            if (UpdateArgumentsTXT_Actuators() && Run_MSM_Actuators() && Run_Evaluator())
            {
                WriteSettingsFile();
                EnableDisableUIElements(GUI_Steps.Export);
                ReadLog();
                UpdateEvaluatedData();
            }
        }
        void RunStrategy_YOPO()
        {
            if (UpdateArgumentsTXT_YOPO() && Run_MSM_YOPO() && Run_Evaluator())
            {
                WriteSettingsFile();
                EnableDisableUIElements(GUI_Steps.Export);
                ReadLog();
                UpdateEvaluatedData();
            }
        }

        public void ReadLog()
        {             
            if (System.IO.File.Exists(settingsFile))
            {
                try
                {
                    System.IO.StreamReader fileReader = new System.IO.StreamReader(System.IO.Path.GetDirectoryName(executableURL) + "\\MomentumStrategyModule.log", true);

                    lblStatus.Text = "Reading log file.";
                    txtLog.Text = "----------------------------------- -------- ----------------------------\r\n\r\n\r\n" + txtLog.Text;
                    txtLog.Text = "----------------------------------- NEW LOGS ----------------------------\r\n" + txtLog.Text;
                    txtLog.Text = "\r\n----------------------------------- -------- ----------------------------\r\n" + txtLog.Text;
                   
                    while (fileReader.Peek() != -1)
                    {
                        txtLog.Text = fileReader.ReadLine() + "\r\n" + txtLog.Text;
                    }
                    fileReader.Dispose();
                    fileReader.Close();

                    txtLog.SelectionStart = txtLog.Text.Length - 1;
                }
                finally
                {
                    lblStatus.Text = "Completed. Read logs in the Log tab.";
                }
            }
        }

        public bool UpdateArgumentsTXT()
        {
            window = txtVal_Window.Text;
            threshold = txtVal_Threshold.Text;
            try
            {
                System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(executableArguments, false);
                fileWriter.WriteLine("window= " + window);
                fileWriter.WriteLine("threshold= " + threshold);
                fileWriter.Dispose();
                fileWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool UpdateArgumentsTXT_Actuators()
        {
            window = txtVal_Window.Text;
            threshold = txtVal_Threshold.Text;
            try
            {
                System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(executableArguments, false);
                fileWriter.WriteLine("" + threshold);
                fileWriter.WriteLine("" + window);
                fileWriter.Dispose();
                fileWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool UpdateArgumentsTXT_YOPO()
        {
            window = txtVal_Window.Text;
            threshold = txtVal_Threshold.Text;
            try
            {
                System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(executableArguments, false);
                fileWriter.WriteLine("" + window);
                fileWriter.WriteLine("" + threshold);
                fileWriter.Dispose();
                fileWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool Run_MSM()
        {
            lblStatus.Text = "Running Rubber Ducky Strategy";
            string errorSpecific = "Couldn't find Java, or arguments.txt, or MSM.jar";

            ClearLogFile();

            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("java", "-jar " + executableURL + " " + inputFileURL + " " + executableArguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process proc;

                if ((proc = Process.Start(processInfo)) == null)
                {
                    throw new InvalidOperationException("??");
                }
                proc.WaitForExit();
                int exitCode = proc.ExitCode;
                proc.Close();
                
                errorSpecific = "Error with OrderList.csv";

                ReadUpdateCSV(dataOutput, System.IO.Directory.GetCurrentDirectory() + "\\OrderList.csv", true);
                tabs.SelectedIndex = 1;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorSpecific + "\r\n" + ex.Message);
                return false;
            }
        }

        public bool Run_MSM_Actuators()
        {
            lblStatus.Text = "Running Actuators Strategy";
            string errorSpecific = "Couldn't find Java, or arguments.txt, or MSM.jar";

            ClearLogFile();

            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("java", "-jar " + System.IO.Directory.GetCurrentDirectory() + "\\MSM_Actuators.jar" + " " + inputFileURL + " " + executableArguments + " MomentumStrategyModule.log OrderList.csv")
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process proc;

                if ((proc = Process.Start(processInfo)) == null)
                {
                    throw new InvalidOperationException("??");
                }
                proc.WaitForExit();
                int exitCode = proc.ExitCode;
                proc.Close();

                errorSpecific = "Error with OrderList.csv";

                ReadUpdateCSV(dataOutput, System.IO.Directory.GetCurrentDirectory() + "\\OrderList.csv", true);
                tabs.SelectedIndex = 1;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorSpecific + "\r\n" + ex.Message);
                return false;
            }
        }

        public bool Run_MSM_YOPO()
        {
            lblStatus.Text = "Running YOPO Strategy";
            string errorSpecific = "Couldn't find Java, or arguments.txt, or MSM.jar";

            ClearLogFile();

            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("java", "-jar " + System.IO.Directory.GetCurrentDirectory() + "\\MSM_YOPO.jar" + " " + inputFileURL + " " + executableArguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process proc;

                if ((proc = Process.Start(processInfo)) == null)
                {
                    throw new InvalidOperationException("??");
                }
                proc.WaitForExit();
                int exitCode = proc.ExitCode;
                proc.Close();

                errorSpecific = "Error with OrderList.csv";

                tabs.SelectedIndex = 1;

                // For YOPO, we have to move the logs from their annoyingly-named file to our own  
                System.IO.StreamReader reader = new System.IO.StreamReader(System.IO.Directory.GetParent(inputFileURL) + "\\" + System.IO.Path.GetFileNameWithoutExtension(inputFileURL) + "_Log.txt");
                System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\MomentumStrategyModule.log", false);           
                //System.IO.StreamReader reader = new System.IO.StreamReader(System.IO.Path.GetFileNameWithoutExtension(inputFileURL) + "_Log.txt");
                //System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\MomentumStrategyModule.log", false);

                while (reader.Peek() != -1)
                {
                    fileWriter.WriteLine(reader.ReadLine());
                }
                fileWriter.Dispose();
                fileWriter.Close();
                reader.Close();

                // rename sirca_Order.csv to OrderList.csv
                System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\OrderList.csv");
                System.IO.File.Move(System.IO.Directory.GetParent(inputFileURL) + "\\" + System.IO.Path.GetFileNameWithoutExtension(inputFileURL) + "_Order.csv", System.IO.Directory.GetCurrentDirectory() + "\\OrderList.csv");
                
                // finally, read OrderList.csv
                ReadUpdateCSV(dataOutput, System.IO.Directory.GetCurrentDirectory() + "\\OrderList.csv", true);
              
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorSpecific + "\r\n" + ex.Message);
                return false;
            }
        }

        public bool Run_Evaluator()
        {
            lblStatus.Text = "Evaluating using " + System.IO.Path.GetFileName(evaluatorURL);
            string errorSpecific = "Couldn't find Evaluator, or Java isn't installed.";
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("java", "-jar " + evaluatorURL + " OrderList.csv")
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process proc;

                if ((proc = Process.Start(processInfo)) == null)
                {
                    throw new InvalidOperationException("??");
                }
                proc.WaitForExit();
                int exitCode = proc.ExitCode;
                proc.Close();

                ReadEvaluation();
                tabs.SelectedIndex = 2;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorSpecific + "\r\n" + ex.Message);
                return false;
            }
        }

        public void ReadEvaluation()
        {
            string evaluationFile = System.IO.Directory.GetCurrentDirectory() + "\\eval.txt";
            if (System.IO.File.Exists(evaluationFile))
            {
                try
                {
                    System.IO.StreamReader fileReader = new System.IO.StreamReader(evaluationFile, true);

                    lblStatus.Text = "Reading Evaluation file.";
                    txtEvaluation.Text = "";
                    while (fileReader.Peek() != -1)
                    {
                        txtEvaluation.Text = fileReader.ReadLine() + "\r\n" + txtEvaluation.Text;
                    }
                    fileReader.Dispose();
                    fileReader.Close();

                    txtEvaluation.SelectionStart = txtEvaluation.Text.Length - 1;
                }
                finally
                {
                    lblStatus.Text = "Completed. Read evaluations in the Evaluation tab.";
                }
            }
            else
            {
                MessageBox.Show("Couldn't find evaluation file.");
            }
        }


        public void ClearLogFile()
        {
            if (System.IO.File.Exists(settingsFile))
            {
                try
                {
                    System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(System.IO.Path.GetDirectoryName(executableURL) + "\\MomentumStrategyModule.log", false);
                    fileWriter.WriteLine("");
                    fileWriter.Dispose();
                    fileWriter.Close();
                }
                finally {}
            }
        }


        void UpdateEvaluatedData()
        {
            try
            {
                lblOverallReturn.Text = txtEvaluation.Lines[0].Split(':')[1].Substring(1);

                lblOverallReturn.ForeColor = Color.DarkGray;
                if (Convert.ToDouble(lblOverallReturn.Text.Substring(0, lblOverallReturn.Text.Length - 1)) < -0.001)
                {
                    lblOverallReturn.ForeColor = Color.Red;
                }
                else if (Convert.ToDouble(lblOverallReturn.Text.Substring(0, lblOverallReturn.Text.Length - 1)) > 0.001)
                {
                    lblOverallReturn.ForeColor = Color.YellowGreen;
                }
                lblPairCount.Text = "" + (txtEvaluation.Lines.Length - 2);

                DataTable dt = new DataTable();
                dt.Columns.Add("S No.", typeof(Int32));
                dt.Columns.Add("Buy", typeof(Double));
                dt.Columns.Add("Sell", typeof(Double));
                dt.Columns.Add("Return %", typeof(Double));

                //Reading Data
                for (int i = 1; i < txtEvaluation.Lines.Length - 1; i++)
                {
                    string fileRow = txtEvaluation.Lines[i];
                    string[] fileDataField = fileRow.Split(' ');

                    dt.Rows.Add(fileDataField[0], fileDataField[2], fileDataField[4], fileDataField[6].Substring(0, fileDataField[6].Length - 1));
                }

                dataEvaluation.DataSource = dt;
                dataEvaluation.Sort(dataEvaluation.Columns[0], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        // some bullshit function thats supposed to find java path 
        // but it doesnt work
        private String GetJavaInstallationPath()
        {
            String javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment";
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey))
            {
                if (baseKey != null)
                {
                    String currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                    using (var homeKey = baseKey.OpenSubKey(currentVersion))
                        return homeKey.GetValue("JavaHome").ToString();
                }
                else
                {
                    lblStatus.Text = "Couldn't find Java Path!";
                    return null;
                }
            }
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void cbVals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVals.Text != "" && cbVals.Text != "Select data for graph")
            {
                //chart1.Series.Clear();
                //chart1.ChartAreas.Clear();
                chart1.ChartAreas[0] = new System.Windows.Forms.DataVisualization.Charting.ChartArea(cbVals.Text);
                //chart1.Series.Add(cbVals.Text);
                chart1.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series();
                chart1.Series[0].LegendText = cbVals.Text;
                chart1.ChartAreas[0].AxisX.Title = "Time";
                chart1.ChartAreas[0].AxisY.Title = cbVals.Text;

                if (dataInput.Rows.Count > 0 && dataInput.Columns.Count > 0)
                {
                    for (int i = 0; i < dataInput.Rows.Count; i++)
                    {
                        if (dataInput.Rows[i].Cells[FindIndexWithName(dataInput, cbVals.Text)].Value != null && dataInput.Rows[i].Cells[FindIndexWithName(dataInput, "Time")].Value != null)
                        {
                            chart1.Series[0].Points.AddXY(dataInput.Rows[i].Cells[FindIndexWithName(dataInput, "Time")].Value, dataInput.Rows[i].Cells[FindIndexWithName(dataInput, cbVals.Text)].Value);
                        }
                    }
                }
            }
        }
        private void UpdateEvalChart()
        {
            chart2.ChartAreas[0] = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chart2.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[0].LegendText = "Prices after MSM (AUD)";
            chart2.ChartAreas[0].AxisX.Title = "Time";
            chart2.ChartAreas[0].AxisY.Title = "Price (AUD)";
            //chart2.Series[1] = new System.Windows.Forms.DataVisualization.Charting.Series();
            //chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //chart2.Series[1].LegendText = "After MSM";

            //if (dataInput.Rows.Count > 0 && dataInput.Columns.Count > 0)
            //{
            //    for (int i = 0; i < dataInput.Rows.Count; i++)
            //    {
            //        if (dataInput.Rows[i].Cells[FindIndexWithName(dataInput, "Price")].Value != null && dataInput.Rows[i].Cells[FindIndexWithName(dataInput, "Time")].Value != null)
            //        {
            //            chart2.Series[0].Points.AddXY(dataInput.Rows[i].Cells[FindIndexWithName(dataInput, "Time")].Value, dataInput.Rows[i].Cells[FindIndexWithName(dataInput, "Price")].Value);
            //        }
            //    }
            //}
            if (dataOutput.Rows.Count > 0 && dataOutput.Columns.Count > 0)
            {
                for (int i = 0; i < dataOutput.Rows.Count - 1; i++)
                {
                    if (dataOutput.Rows[i].Cells[FindIndexWithName(dataOutput, "Price")].Value != null && dataOutput.Rows[i].Cells[FindIndexWithName(dataOutput, "Time")].Value != null)
                    {
                        chart2.Series[0].Points.AddXY(dataOutput.Rows[i].Cells[FindIndexWithName(dataOutput, "Time")].Value, dataOutput.Rows[i].Cells[FindIndexWithName(dataOutput, "Price")].Value);
                    }
                }
            }

            chart3.ChartAreas[0] = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chart3.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart3.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series[0].LegendText = "BID/ASK net outcomes (AUD)";
            chart3.ChartAreas[0].AxisX.Title = "BID/ASK Pair No.";
            chart3.ChartAreas[0].AxisY.Title = "Net outcome (AUD)";

            if (dataEvaluation.Rows.Count > 0 && dataEvaluation.Columns.Count > 0)
            {
                for (int i = 0; i < dataEvaluation.Rows.Count; i++)
                {
                    if (dataEvaluation.Rows[i].Cells[FindIndexWithName(dataEvaluation, "S No.")].Value != null && dataEvaluation.Rows[i].Cells[FindIndexWithName(dataEvaluation, "Buy")].Value != null)
                    {
                        chart3.Series[0].Points.AddXY(dataEvaluation.Rows[i].Cells[FindIndexWithName(dataEvaluation, "S No.")].Value, (double)dataEvaluation.Rows[i].Cells[FindIndexWithName(dataEvaluation, "Sell")].Value - (double)dataEvaluation.Rows[i].Cells[FindIndexWithName(dataEvaluation, "Buy")].Value);
                    }
                }
            }
        }


        int FindIndexWithName(DataGridView dataInput, string name)
        {
            for (int i = 0; i < dataInput.Columns.Count; i++)
            {
                if (dataInput.Columns[i].HeaderText == name)
                {
                    return i;
                }
            }
            return 0;
        }

    }
}


