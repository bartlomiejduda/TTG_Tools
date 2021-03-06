﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace TTG_Tools
{
    public partial class TextEditor : Form
    {
        public class AllText
        {
            public int number;
            public string orName;
            public string orText;
            public string trName;
            public string trText;
            public bool exported;
            public bool isChecked;
            public AllText() { }
            public AllText(int _number, string _orName, string _orText, string _trName, string _trText, bool _exported, bool _isChecked)
            {
                this.number = _number;
                this.orName = _orName;
                this.orText = _orText;
                this.trName = _trName;
                this.trText = _trText;
                this.isChecked = _isChecked;
                this.exported = _exported;
            }
        }

        public class Glossary
        {
            public string orText;
            public string trText;
            public bool exported;
            public bool isChecked;
            public Glossary() { }
            public Glossary(string _orText, string _trText, bool _exported, bool _isChecked)
            {
                this.trText = _trText;
                this.orText = _orText;
                this.isChecked = _isChecked;
                this.exported = _exported;
            }
        }

        public TextEditor()
        {
            InitializeComponent();
        }

        public static List<AllText> allText = new List<AllText>();
        public static List<AllText> allText2 = new List<AllText>();
        public static List<Glossary> glossary = new List<Glossary>();
        public static string file = "";

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdOrig = new OpenFileDialog();
            ofdOrig.Filter = "txt files (*.txt)|*.txt";
            ofdOrig.Title = "Set Original file!";
            allText = new List<AllText>();
            if (ofdOrig.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofdOrig.FileName.ToString();
                ImportTXTByOneFile(ofdOrig.FileName, ref allText, MainMenu.settings.ASCII_N, true);
                button2_Click(sender, e);
            }
        }



        public static List<AllText> ImportTXTByOneFile(string path, ref List<AllText> allText, int ASCII, bool isEnglish)
        {
            StreamReader sr = new StreamReader(path, System.Text.ASCIIEncoding.GetEncoding(ASCII));
            List<TextCollector.TXT_collection> tempText = new List<TextCollector.TXT_collection>();
            string error = string.Empty;
            AutoPacker.ImportTXT(path, ref tempText, false, MainMenu.settings.ASCII_N, "\r\n", ref error);
            for (int q = 0; q < tempText.Count; q++)
            {
                int isStringExist = IsNumberOfStringExist(tempText[q].number - 1, allText);
                if (isEnglish)
                {
                    if (isStringExist != -1)
                    {
                        allText[isStringExist].orName = tempText[q].name;
                        allText[isStringExist].orText = tempText[q].text;
                    }
                    else
                    {
                        allText.Add(new AllText(tempText[q].number - 1, tempText[q].name, tempText[q].text, "", "", false, false));
                    }
                }
                else
                {
                    if (isStringExist != -1)
                    {
                        allText[isStringExist].trName = tempText[q].name;
                        allText[isStringExist].trText = tempText[q].text;
                    }
                    else //если строки нет когда она потеряна или начат импорт с переведенного файла
                    {
                        allText.Add(new AllText(tempText[q].number - 1, "", "", tempText[q].name, tempText[q].text, false, false));
                    }
                }
                //text_temp[all_text[q].number - 1].text = all_text[q].text.Replace("\r\n", "\n");

            }
            return allText;
        }
        public static List<AllText> ImportTXTFromConvertedFile(string path, ref List<AllText> allText, int ASCII)
        {

            StreamReader sr = new StreamReader(path, System.Text.ASCIIEncoding.GetEncoding(ASCII));


            List<TextCollector.TXT_collection> tempText = new List<TextCollector.TXT_collection>();
            string error = string.Empty;
            AutoPacker.ImportTXT(path, ref tempText, false, MainMenu.settings.ASCII_N, "\r\n", ref error);
            for (int q = 0; q < tempText.Count; q++)
            {
                int isStringExist = IsNumberOfStringExist(tempText[q].number - 1, allText);

                if (isStringExist != -1)
                {
                    allText[isStringExist].trName = tempText[q].name;
                    allText[isStringExist].trText = tempText[q].text;
                }
                else
                {
                    allText.Add(new AllText(tempText[q].number - 1, tempText[q].name, tempText[q].text, "", "", false, false));
                }

            }
            return allText;
        }

        public static int IsNumberOfStringExist(int posStr, List<AllText> allText)
        {
            int b = -1;
            try
            {
                allText.Count();

                for (int i = 0; i < allText.Count(); i++)
                {
                    if (allText[i].number == posStr)
                    {
                        b = i;
                        break;
                    }
                }
                return b;
            }
            catch
            { return -1; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            allText.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt";
            ofd.Title = "Set file!";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = ofd.FileName.ToString();
                try
                {
                    ImportTXTFromConvertedFile(ofd.FileName, ref allText, MainMenu.settings.ASCII_N);
                    button7.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Error in file" + ofd.FileName);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdOrig = new OpenFileDialog();
            ofdOrig.Filter = "txt files (*.txt)|*.txt";
            ofdOrig.Title = "Set Original file!";
            if (ofdOrig.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofdOrig.FileName.ToString();
                ImportTXTByOneFile(ofdOrig.FileName, ref allText, MainMenu.settings.ASCII_N, false);
                file = ofdOrig.SafeFileName;
                button5_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < allText.Count(); i++)
            {
                if ((allText[i].trText == "" && allText[i].trName == "") || (allText[i].trText == "" || allText[i].trName == ""))
                {
                    allText[i].trName = allText[i].orName;
                    allText[i].trText = allText[i].orText;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var process = new ForThreads();
            process.Progress += ProcessorProgress;
            process.BackAllText += RefAllText;
            var thread = new Thread(new ParameterizedThreadStart(process.CreateExportingTXTfromAllText));
            progressBar1.Maximum = allText.Count - 1;
            thread.Start(allText);
        }

        void ProcessorProgress(int progress)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new ProgressHandler(ProcessorProgress), progress);
            }
            else
            {
                progressBar1.Value = progress;
            }
        }

        void RefAllText(List<AllText> allTextNew)
        {
            allText = new List<AllText>(allTextNew);
        }

        void RefAllText2(List<AllText> allTextNew2)
        {
            allText2 = new List<AllText>(allTextNew2);
        }

        public static void SaveFile(string path, List<AllText> allText)
        {
            FileStream ExportStream = new FileStream(path, FileMode.Create);
            for (int i = 0; i < allText.Count; i++)
            {
                TextCollector.SaveString(ExportStream, ((allText[i].number + 1) + ") " + allText[i].orName + "\r\n"), MainMenu.settings.ASCII_N);
                TextCollector.SaveString(ExportStream, (allText[i].orText + "\r\n"), MainMenu.settings.ASCII_N);
                TextCollector.SaveString(ExportStream, ((allText[i].number + 1) + ") " + allText[i].trName + "\r\n"), MainMenu.settings.ASCII_N);
                TextCollector.SaveString(ExportStream, (allText[i].trText + "\r\n"), MainMenu.settings.ASCII_N);
            }
            ExportStream.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<List<AllText>> text = new List<List<AllText>>();
            text.Add(allText);
            text.Add(allText2);
            var process = new ForThreads();
            process.Progress += ProcessorProgress;
            process.BackAllText2 += RefAllText2;
            var thread = new Thread(new ParameterizedThreadStart(process.CreateGlossaryFromFirstAndSecondAllText));
            progressBar1.Maximum = allText.Count - 1;
            thread.Start(text);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            allText2.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt";
            ofd.Title = "Set file!";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = ofd.FileName.ToString();
                ImportTXTFromConvertedFile(ofd.FileName, ref allText2, MainMenu.settings.ASCII_N);
            }
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt";
            sfd.FileName = file;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFile(sfd.FileName, allText);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt";
            sfd.FileName = file;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFile(sfd.FileName, allText2);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var process = new ForThreads();
            process.Progress += ProcessorProgress;
            process.BackAllText2 += RefAllText2;
            var thread = new Thread(new ParameterizedThreadStart(process.CreateExportingTXTfromAllText2));
            progressBar1.Maximum = allText2.Count - 1;
            thread.Start(allText2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdeng = new FolderBrowserDialog();
            fbdeng.SelectedPath = @"D:\translation\SnM\Season 3\texteng";
            if (fbdeng.ShowDialog() == DialogResult.OK)
            {
                FolderBrowserDialog fbdrus = new FolderBrowserDialog();
                fbdrus.SelectedPath = @"D:\translation\SnM\Season 3\textrus";
                if (fbdrus.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo direng = new DirectoryInfo(fbdeng.SelectedPath);
                    FileInfo[] inputFileseng = direng.GetFiles();
                    for (int i = 0; i < inputFileseng.Count(); i++)
                    {
                        string onlyNameImporting = inputFileseng[i].Name.Split('(')[0];
                        DirectoryInfo dirrus = new DirectoryInfo(fbdrus.SelectedPath);
                        FileInfo[] inputFiles = dirrus.GetFiles(onlyNameImporting + ".txt");
                        if (inputFiles.Count() == 1)
                        {
                            allText = new List<AllText>();

                            ImportTXTByOneFile(inputFileseng[i].FullName, ref allText, MainMenu.settings.ASCII_N, true);
                            int c = allText.Count();
                            ImportTXTByOneFile(inputFiles[0].FullName, ref allText, MainMenu.settings.ASCII_N, false);
                            if (c != allText.Count())
                            { MessageBox.Show(onlyNameImporting); }
                            //ForThreads.CreateExportingTXTfromAllTextN(ref allText);

                            SaveFile(@"D:\translation\SnM\Season 3\text2\" + inputFileseng[i].Name, allText);
                        }
                        else
                        {
                            //MessageBox.Show(onlyNameImporting);
                        }
                    }
                }
            }
        }
    }
}
