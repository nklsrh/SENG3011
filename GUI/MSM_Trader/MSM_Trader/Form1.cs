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

        public string version = "0.5";

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

            if (LoadSettingsFile())
            {
                openFile.InitialDirectory = inputFileName;
                if (importOnStart)
                {
                    OpenCSV(dataInput, inputFileName);
                    ReadLog();
                    ReadEvaluation();
                }
            }
            else
            {
                executableURL = "";
                executableArguments = "";
                threshold = "0.01";
                window = "3";
                WriteSettingsFile();
            }
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
                                    version = fileDataField[1];
                                    writeSettingsAfter = true;
                                }
                                else
                                {
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
            this.Text = inputFileName + " - Rubber Ducky Trader";

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
                }
                else
                {
                    MessageBox.Show("Couldn't find CSV at " + csvPath);
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
            Actuators
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
                    break;
                case GUI_Steps.Find:
                    btnFind.Enabled = true;
                    btnRun.Enabled = false;
                    btnEvaluate.Enabled = false;
                    txtVal_Threshold.Enabled = false;
                    txtVal_Window.Enabled = false;
                    lstStrategy.Enabled = true;
                    break;
                case GUI_Steps.Run:
                    btnFind.Enabled = true;
                    btnRun.Enabled = true;
                    btnEvaluate.Enabled = false;
                    txtVal_Threshold.Enabled = true;
                    txtVal_Window.Enabled = true;
                    lstStrategy.Enabled = true;
                    break;
                case GUI_Steps.Export:
                    btnFind.Enabled = true;
                    btnRun.Enabled = true;
                    btnEvaluate.Enabled = true;
                    txtVal_Threshold.Enabled = true;
                    txtVal_Window.Enabled = true;
                    lstStrategy.Enabled = true;
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
            }
        }

        void RunStrategy_RubberDucky()
        {
            if (UpdateArgumentsTXT() && Run_MSM() && Run_Evaluator())
            {
                WriteSettingsFile();
                EnableDisableUIElements(GUI_Steps.Export);
                ReadLog();
            }
        }
        void RunStrategy_Actuators()
        {
            if (UpdateArgumentsTXT_Actuators() && Run_MSM_Actuators() && Run_Evaluator())
            {
                WriteSettingsFile();
                EnableDisableUIElements(GUI_Steps.Export);
                ReadLog();
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


    }
}

