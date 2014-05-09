using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                WriteSettingsFile(executableURL, inputFileName, threshold, window);
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
                                executableURL = fileDataField[1];
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

        public bool WriteSettingsFile (string exe="", string input="", string threshold="0.01", string window="3")
        {
            try
            {
                System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(settingsFile, false);
                fileWriter.WriteLine("tradingStrategyExecutable=" + exe);
                fileWriter.WriteLine("inputCSVFile=" + input);
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

            WriteSettingsFile(executableURL, inputFileURL, threshold, window);
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
                    System.IO.StreamReader fileReader = new System.IO.StreamReader(csvPath, false);

                    //Reading Data
                    while (fileReader.Peek() != -1)
                    {
                        string fileRow = fileReader.ReadLine();
                        string[] fileDataField = fileRow.Split(',');
                        //Console.WriteLine(fileDataField[0]);
                        int i = 0;
                        while (dataInput.Columns.Count < fileDataField.Length)
                        {
                            dataInput.Columns.Add(fileDataField[i], fileDataField[i]);
                            i++;
                        }
                        if (i == 0) // skipping first line which is header
                        {
                            dataInput.Rows.Add(fileDataField);
                        }
                    }
                    fileReader.Dispose();
                    fileReader.Close();
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

        private void chkAutoImport_CheckedChanged(object sender, EventArgs e)
        {
            importOnStart = chkAutoImport.Checked;
            WriteSettingsFile(executableURL, inputFileURL, threshold, window);
        }

    }
}
