namespace CPT
{
    partial class CPM
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPM));
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.smallNum = new System.Windows.Forms.NumericUpDown();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.saveOldPath = new System.Windows.Forms.CheckBox();
            this.bigNum = new System.Windows.Forms.Label();
            this.myDB_DataSet = new CPT.myDB_DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.smallNum)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDB_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPicker
            // 
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker.Location = new System.Drawing.Point(105, 20);
            this.dtPicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(109, 20);
            this.dtPicker.TabIndex = 1;
            this.dtPicker.CloseUp += new System.EventHandler(this.dtPicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата выпуска:";
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "Выбор папки для сохранения файла";
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // smallNum
            // 
            this.smallNum.Location = new System.Drawing.Point(105, 46);
            this.smallNum.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.smallNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.smallNum.Name = "smallNum";
            this.smallNum.Size = new System.Drawing.Size(49, 20);
            this.smallNum.TabIndex = 4;
            this.smallNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.smallNum.ValueChanged += new System.EventHandler(this.smallNum_ValueChanged);
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "PDF";
            this.saveDialog.InitialDirectory = "c:\\";
            this.saveDialog.Tag = "";
            this.saveDialog.Title = "Укажите путь для сохранения файла";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Номер выпуска";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripLabel,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(239, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stripLabel
            // 
            this.stripLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stripLabel.Name = "stripLabel";
            this.stripLabel.Size = new System.Drawing.Size(76, 17);
            this.stripLabel.Text = "© Senya Soft";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(140, 16);
            this.progressBar.Visible = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.Image = global::CPT.Properties.Resources.Control_Panel_2;
            this.btnSettings.Location = new System.Drawing.Point(84, 453);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(70, 61);
            this.btnSettings.TabIndex = 7;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRun.Image = global::CPT.Properties.Resources.Forward___Next;
            this.btnRun.Location = new System.Drawing.Point(12, 453);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(66, 61);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Создать";
            this.btnRun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::CPT.Properties.Resources.Log_Off;
            this.btnExit.Location = new System.Drawing.Point(161, 453);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 61);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выход";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // saveOldPath
            // 
            this.saveOldPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveOldPath.AutoSize = true;
            this.saveOldPath.Checked = true;
            this.saveOldPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveOldPath.Location = new System.Drawing.Point(15, 426);
            this.saveOldPath.Name = "saveOldPath";
            this.saveOldPath.Size = new System.Drawing.Size(204, 17);
            this.saveOldPath.TabIndex = 8;
            this.saveOldPath.Text = "Сохранять все файлы в одну папку";
            this.saveOldPath.UseVisualStyleBackColor = true;
            // 
            // bigNum
            // 
            this.bigNum.AutoSize = true;
            this.bigNum.Location = new System.Drawing.Point(160, 48);
            this.bigNum.Name = "bigNum";
            this.bigNum.Size = new System.Drawing.Size(13, 13);
            this.bigNum.TabIndex = 9;
            this.bigNum.Text = "()";
            // 
            // myDB_DataSet
            // 
            this.myDB_DataSet.DataSetName = "myDB_DataSet";
            this.myDB_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(239, 548);
            this.Controls.Add(this.bigNum);
            this.Controls.Add(this.saveOldPath);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.smallNum);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CPM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPM v 1.20";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CPT_FormClosing);
            this.Load += new System.EventHandler(this.CPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.smallNum)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDB_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.NumericUpDown smallNum;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.CheckBox saveOldPath;
        private System.Windows.Forms.Label bigNum;
        private myDB_DataSet myDB_DataSet;
        public System.Windows.Forms.ToolStripStatusLabel stripLabel;
    }
}

