using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace CPT
{
    public partial class Settings : Form
    {
        private class mySettings
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        List<mySettings> setList = new List<mySettings>();

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Key", "Параметр");
            dataGridView1.Columns.Add("Value", "Значение");

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 205;

            dataGridView1.Columns[0].ReadOnly = true;

            foreach (SettingsProperty p in Properties.Settings.Default.Properties)
            {
                dataGridView1.Rows.Add(p.Name, Properties.Settings.Default[p.Name]);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                //var f = r.Cells[0].Value;
                if ((Properties.Settings.Default[r.Cells[0].Value.ToString()].GetType().Name.ToString()) == "Int32")
                    Properties.Settings.Default[r.Cells[0].Value.ToString()] = Convert.ToInt32(r.Cells[1].Value);
                else
                    Properties.Settings.Default[r.Cells[0].Value.ToString()] = r.Cells[1].Value;
            }
            Properties.Settings.Default.Save();
            this.Close();
            this.Dispose();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
