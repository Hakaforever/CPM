using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPT
{
    //static class GetDate
    public partial class CPM : Form
    {
        public myDB_DataSet mainDS = new myDB_DataSet();

        public myDB_DataSet.issue_numDataTable tblIssueNum;

        DateTime tmpDate; //для фиксации текущей даты

        myDB_DataSetTableAdapters.TableAdapterManager taMain = new myDB_DataSetTableAdapters.TableAdapterManager();
        myDB_DataSetTableAdapters.issue_numTableAdapter taIssueNum = new myDB_DataSetTableAdapters.issue_numTableAdapter();
        BindingSource bsMain = new BindingSource();

        public void FindNum()
        {
            tblIssueNum = mainDS.issue_num;
            taMain.issue_numTableAdapter = taIssueNum;
            try
            {
                taMain.issue_numTableAdapter.Fill(tblIssueNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            
            bsMain.DataSource = mainDS;
            bsMain.DataMember = "issue_num";
            bsMain.MoveLast();
            if (bsMain.Count != 0)
            {
                bigNum.DataBindings.Add("Text", bsMain, "big_num", true, DataSourceUpdateMode.OnPropertyChanged);
                smallNum.DataBindings.Add("Value", bsMain, "small_num", true, DataSourceUpdateMode.OnPropertyChanged);
                tmpDate = dtPicker.Value;
                dtPicker.DataBindings.Add("Value", bsMain, "data", true, DataSourceUpdateMode.OnPropertyChanged);
                dtPicker.Value = tmpDate;
            }
            else
            {
                MessageBox.Show("Нет данных в базе. Не забудьте внести правильные значения!");
            }
        }

        private void FindDate(DateTime dt)
        {
            bsMain.ResetBindings(true);
            int p = bsMain.Find("data", dtPicker.Value.Date);
            bsMain.CancelEdit();


            if (p != -1)
            {
                try
                {
                    bsMain.Position = p;
                }
                catch (Exception)
                {
                    bsMain.MoveLast();
                }
                smallNum.Enabled = false;
                bigNum.Visible = false;
            }
            else
            {
                bsMain.MoveLast();
                int s = (int)smallNum.Value;
                string b = bigNum.Text;
                bsMain.AddNew();
                if (dt.Year - dtPicker.Value.Year == 1)
                {
                    smallNum.Value = 1;
                }
                else
                {
                    smallNum.Value = s + 1;
                }
                bigNum.Text = (Convert.ToInt32(b) + 1).ToString();
                dtPicker.Value = dt.Date;
                smallNum.Enabled = true;
                bigNum.Visible = true;

            }
        }

        private void SaveIssueNum()
        {
            if (tblIssueNum.Count != bsMain.Count)
            {
                smallNum.DataBindings[0].WriteValue();
                bigNum.DataBindings[0].WriteValue();
                dtPicker.DataBindings[0].WriteValue();
                bsMain.EndEdit();
                taMain.UpdateAll(mainDS);
                stripLabel.Text = "NumSaved";
            }
        }
    }
}
