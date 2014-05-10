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

        public string threshold;
        public string window;
        
        public string settingsFile = System.IO.Directory.GetCurrentDirectory() + "\\TraderSettings.cfg";

        public bool importOnStart = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            openFile.InitialDirectory = System.IO.Directory.GetCurrentDirectory();

            EnableDisableUIElements(GUI_Steps.Import);

            if (LoadSettingsFile())
            {
                openFile.InitialDirectory = inputFileName;
                if (importOnStart)
                {
                    OpenCSV(dataInput, inputFileName);
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
                            if (fileDataField[0] == "argumentsFile")
                            {
                                if (fileDataField[1].Substring(fileDataField[1].Length - 3, 3) == "txt")
                                {
                                    executableArguments = fileDataField[1];
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
                        }
                        lineNumber++;
                    }
                    fileReader.Dispose();
                    fileReader.Close();
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
                fileWriter.WriteLine("inputCSVFile=" + inputFileURL);
                fileWriter.WriteLine("threshold=" + threshold);
                fileWriter.WriteLine("window=" + window);
                fileWriter.WriteLine("importOnStart=" + importOnStart);
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
            this.Text = inputFileName;

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
                    btnExport.Enabled = false;
                    txtVal_Threshold.Enabled = false;
                    txtVal_Window.Enabled = false;
                    lstStrategy.Enabled = false;
                    break;
                case GUI_Steps.Find:
                    btnFind.Enabled = true;
                    btnRun.Enabled = false;
                    btnExport.Enabled = false;
                    txtVal_Threshold.Enabled = false;
                    txtVal_Window.Enabled = false;
                    lstStrategy.Enabled = true;
                    break;
                case GUI_Steps.Run:
                    btnFind.Enabled = true;
                    btnRun.Enabled = true;
                    btnExport.Enabled = false;
                    txtVal_Threshold.Enabled = true;
                    txtVal_Window.Enabled = true;
                    lstStrategy.Enabled = true;
                    break;
                case GUI_Steps.Export:
                    btnFind.Enabled = true;
                    btnRun.Enabled = true;
                    btnExport.Enabled = true;
                    txtVal_Threshold.Enabled = true;
                    txtVal_Window.Enabled = true;
                    lstStrategy.Enabled = true;
                    break;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (UpdateArgumentsTXT() && Run_MSM())
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


        public bool Run_MSM()
        {
            lblStatus.Text = "Running Strategy from " + System.IO.Path.GetFileName(executableURL);
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

                ReadUpdateCSV(dataOutput, System.IO.Directory.GetCurrentDirectory() + "\\OrderList.csv", false);
                tabs.SelectedIndex = 1;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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

    }
}

