using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace CPT
{
    public partial class CPM : Form
    {
        string xmlMask = "export_adplano_";
        string xmlPath = @"\\netshare\data\Verstka\Reclama\Reclama_Plans";
        string xmlName = String.Empty;
        string pdfPath = @"\\10.1.1.61\sls\Archive";
        ReadXML xmlData = new ReadXML();

        int Status = -1;
        List<TextBox> textBoxPageCounts = new List<TextBox>();

        string[] issuePDFs;

        public CPM()
        {
            InitializeComponent();
            string currPath = Directory.GetCurrentDirectory();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CPT_Load(object sender, EventArgs e)
//загрузка формы
        {
            if (!LoadSettings())
            {
                MessageBox.Show("Error loading settings!");
                Application.Exit();
            }

            if (!Directory.Exists(pdfPath))
            {
                MessageBox.Show("Not found PDF-container disk!");
                pdfPath = String.Empty;
            }
            if (!Directory.Exists(xmlPath))
            {
                MessageBox.Show("Not found XML-container folder!");
                xmlPath = String.Empty;
            }
            FindNum();
            dtPicker_ValueChanged(this, EventArgs.Empty);
            this.Text = "CPM v." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private bool LoadSettings()
//чтение настроек
        {
            try
            {
                xmlMask = Properties.Settings.Default.xmlMask;
                xmlPath = Properties.Settings.Default.xmlPath;
                pdfPath = Properties.Settings.Default.pdfPath;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void dtPicker_ValueChanged(object sender, EventArgs e)
//если сменяется дата
        {
            xmlName = xmlMask + dtPicker.Value.Year.ToString() + "_" + dtPicker.Value.Month.ToString("D2") + "_" + dtPicker.Value.Day.ToString("D2") + ".xml";

            for (int i = this.Controls.Count-1; i > 0; i--)
            {
                if (this.Controls[i].Tag != null && this.Controls[i].Tag.ToString().Contains("xmlData"))
                    this.Controls.Remove(this.Controls[i]);
            }
            FindDate(dtPicker.Value);

            GetXMLData();
        }

        private void GetXMLData()
//получение даты и создание чек-боксов по выпускам из XML
        {
            int top = 104;

            textBoxPageCounts.Clear();

            if (!File.Exists(Path.Combine(xmlPath, xmlName)))
            {
                Label l = new Label();

                l.Location = new Point(12, 115);
                l.Size = new Size(this.Width - 100, 24);
                l.Text = "На эту дату не найден XML";
                l.Tag = "xmlData";
                this.Controls.Add(l);
                return;
            }

            xmlData.Load(Path.Combine(xmlPath, xmlName));
            int i = 0;
            foreach (ReadXML.Issue s in xmlData.IssuesList)
            {
                CheckBox c = new CheckBox();

                c.Location = new Point(62, top + i * 36);
                c.Size = new System.Drawing.Size(60, 17);
                c.Text = s.code;
                c.ThreeState = false;
                c.Tag = "xmlData";
                this.Controls.Add(c);

                TextBox t = new TextBox();

                t.Location = new Point(132, top + i * 36);
                t.Text = s.pages.ToString();
                t.Tag = "xmlData" + s.code;
                //t.Tag = s.code;
                t.Size = new Size(30, 12);
                this.Controls.Add(t);
                textBoxPageCounts.Add(t);

                i++;
            }
            this.Size = new System.Drawing.Size(this.Size.Width, top + i * 36 + 160);
        }

        private void btnRun_Click(object sender, EventArgs e)
//запускаем основной процесс
        {
            string path = String.Empty;
            PDFwork combinedPDF = new PDFwork(this);
            bool flag = true;
            bool combineResult = true;

            if (pdfPath == String.Empty || xmlPath == String.Empty)
                return;

            Cursor mtCur = this.Cursor;

            string newPath = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            saveDialog.InitialDirectory = Properties.Settings.Default.InitialFolder;

            foreach (Control chkB in this.Controls)
            {
                if (chkB.GetType().Name.ToString() == "CheckBox")
                {
                    CheckBox j = (CheckBox)(chkB);
                    if (j.Checked == true && !j.Text.Contains("Сохранять"))
                    {
                        IEnumerable<int> pages = from issues in textBoxPageCounts//in xmlData.IssuesList
                                                 where issues.Tag.ToString() == "xmlData" + j.Text
                                                 select Convert.ToInt32(issues.Text);

                        string h = (j.Text == "KIE" ? "SEK_" : "SE_");

                        saveDialog.FileName = h + ((int)smallNum.Value).ToString("D3") + "_" + dtPicker.Value.Day.ToString("D2") + "_" + dtPicker.Value.Month.ToString("D2") + "_" + dtPicker.Value.Year.ToString().Substring(2, 2);

                        if (flag)
                        {
                            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                            {
                                combineResult = false;
                                break;
                            }
                            flag = (saveOldPath.Checked == true ? false : true);
                            newPath = Path.GetDirectoryName(saveDialog.FileName);
                        }
                        string resultPDF = (saveDialog.FileName.Contains("\\") ? saveDialog.FileName : Path.Combine(newPath, saveDialog.FileName + ".pdf"));

                        Properties.Settings.Default.InitialFolder = newPath;

                        combineResult = CollectPages(j.Text, pages.FirstOrDefault());
                        if (!combineResult)
                        {
                            j.Checked = false;
                            break;
                        }

                        combineResult = combinedPDF.CreatePDF(resultPDF, issuePDFs);
                        if (!combineResult)
                            MessageBox.Show("Ошибка создания файла " + resultPDF);
                        j.Checked = false;
                        Status = 1;
                    }
                }
            }
            this.Cursor = mtCur;
            if (Status == 1)
            {
                SaveIssueNum();
                MessageBox.Show("Готово!");
                SystemSounds.Beep.Play();
            }
            FindDate(dtPicker.Value);
        }

        private bool CollectPages(string code, int pages)
//набираем список полос с параллельной
//проверкой на существование и на дубли
        {
            string data = dtPicker.Value.Year.ToString().Substring(2, 2) + dtPicker.Value.Month.ToString("D2") + dtPicker.Value.Day.ToString("D2");
            string fName = data + "_SEG_" + code.ToUpper() + "_";
            bool result = true;

            issuePDFs = new string[pages];

            for (int i = 0; i < pages; i++ )
            {
                string controlName = fName + (i + 1).ToString("D2");// +".PDF";

                /*foreach (Control c in this.Controls)
                {
                    if (c.GetType().Name.ToString() == "CheckBox")
                    {
                        if (c.Text == "SUP" && code == "KIE" && (i < 2 || i > pages - 3))
                            controlName = data + "_SEG_SUP_" + (i + 1).ToString("D2");
                    }
                }*/

                if (File.Exists(Path.Combine(pdfPath, controlName + ".PDF")))
                {
                    controlName = controlName + ".PDF";
                }
                else
                {
                    controlName = controlName + "K.PDF";
                }
                while (File.Exists(Path.Combine(pdfPath, controlName)))
                {
                    controlName = "!" + controlName;
                }
                string pdfName = Path.Combine(pdfPath, controlName.Substring(1, controlName.Length-1));
                if (!File.Exists(pdfName))
                {
                    if (MessageBox.Show("Не найден файл " + pdfName + ". Продолжить?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        result = false;
                        return result;
                    }
                }
                else
                {
                    issuePDFs[i] = pdfName;
                }
            }
            return result;
        }

        private void CPT_FormClosing(object sender, FormClosingEventArgs e)
//закрытие формы
        {
            if (Status != -1)
            {
                Properties.Settings.Default.Save();
            }        
        }

        private void btnSettings_Click(object sender, EventArgs e)
//доступ к настройкам
        {
            Settings mySet = new Settings();

            if (mySet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadSettings();
            }

        }

        private void smallNum_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;

            if (bsMain.Position < 0 || num.Focused)
            {
                int f = Convert.ToInt32(num.Text) - Convert.ToInt32(num.Value);
                bigNum.Text = (Convert.ToInt32(bigNum.Text) - f).ToString();
            }
        }
    }
}
