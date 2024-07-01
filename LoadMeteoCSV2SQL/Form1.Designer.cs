namespace LoadMeteoCSV2SQL
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.datetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tempDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlagaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.windspeedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winddirectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insolationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pressuregPaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pressuremmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winddirectidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valuedateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceMeteo = new System.Windows.Forms.BindingSource(this.components);
            this.oNGUREN_DBDataSet = new LoadMeteoCSV2SQL.oNGUREN_DBDataSet();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bindingSourcePower = new System.Windows.Forms.BindingSource(this.components);
            this.onguren_dbDataSet_Power = new LoadMeteoCSV2SQL.onguren_dbDataSet_Power();
            this.bindingSourceWindTotal = new System.Windows.Forms.BindingSource(this.components);
            this.onguren_dbDataSet_WindTotal = new LoadMeteoCSV2SQL.onguren_dbDataSet_WindTotal();
            this.table_wind_totalTableAdapter = new LoadMeteoCSV2SQL.onguren_dbDataSet_WindTotalTableAdapters.table_wind_totalTableAdapter();
            this.table_meteoTableAdapter = new LoadMeteoCSV2SQL.oNGUREN_DBDataSetTableAdapters.table_meteoTableAdapter();
            this.table_powerTableAdapter = new LoadMeteoCSV2SQL.onguren_dbDataSet_PowerTableAdapters.table_powerTableAdapter();
            this.bindingSourceSNTotal = new System.Windows.Forms.BindingSource(this.components);
            this.onguren_dbDataSet_SNTotal = new LoadMeteoCSV2SQL.onguren_dbDataSet_SNTotal();
            this.table_sn_totalTableAdapter = new LoadMeteoCSV2SQL.onguren_dbDataSet_SNTotalTableAdapters.table_sn_totalTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMeteo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oNGUREN_DBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onguren_dbDataSet_Power)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWindTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onguren_dbDataSet_WindTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSNTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onguren_dbDataSet_SNTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datetimeDataGridViewTextBoxColumn,
            this.tempDataGridViewTextBoxColumn,
            this.vlagaDataGridViewTextBoxColumn,
            this.windspeedDataGridViewTextBoxColumn,
            this.winddirectDataGridViewTextBoxColumn,
            this.insolationDataGridViewTextBoxColumn,
            this.pressuregPaDataGridViewTextBoxColumn,
            this.pressuremmDataGridViewTextBoxColumn,
            this.winddirectidDataGridViewTextBoxColumn,
            this.valuedateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSourceMeteo;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1138, 180);
            this.dataGridView1.TabIndex = 2;
            // 
            // datetimeDataGridViewTextBoxColumn
            // 
            this.datetimeDataGridViewTextBoxColumn.DataPropertyName = "date_time";
            this.datetimeDataGridViewTextBoxColumn.HeaderText = "date_time";
            this.datetimeDataGridViewTextBoxColumn.Name = "datetimeDataGridViewTextBoxColumn";
            // 
            // tempDataGridViewTextBoxColumn
            // 
            this.tempDataGridViewTextBoxColumn.DataPropertyName = "temp";
            this.tempDataGridViewTextBoxColumn.HeaderText = "temp";
            this.tempDataGridViewTextBoxColumn.Name = "tempDataGridViewTextBoxColumn";
            // 
            // vlagaDataGridViewTextBoxColumn
            // 
            this.vlagaDataGridViewTextBoxColumn.DataPropertyName = "vlaga";
            this.vlagaDataGridViewTextBoxColumn.HeaderText = "vlaga";
            this.vlagaDataGridViewTextBoxColumn.Name = "vlagaDataGridViewTextBoxColumn";
            // 
            // windspeedDataGridViewTextBoxColumn
            // 
            this.windspeedDataGridViewTextBoxColumn.DataPropertyName = "wind_speed";
            this.windspeedDataGridViewTextBoxColumn.HeaderText = "wind_speed";
            this.windspeedDataGridViewTextBoxColumn.Name = "windspeedDataGridViewTextBoxColumn";
            // 
            // winddirectDataGridViewTextBoxColumn
            // 
            this.winddirectDataGridViewTextBoxColumn.DataPropertyName = "wind_direct";
            this.winddirectDataGridViewTextBoxColumn.HeaderText = "wind_direct";
            this.winddirectDataGridViewTextBoxColumn.Name = "winddirectDataGridViewTextBoxColumn";
            // 
            // insolationDataGridViewTextBoxColumn
            // 
            this.insolationDataGridViewTextBoxColumn.DataPropertyName = "insolation";
            this.insolationDataGridViewTextBoxColumn.HeaderText = "insolation";
            this.insolationDataGridViewTextBoxColumn.Name = "insolationDataGridViewTextBoxColumn";
            // 
            // pressuregPaDataGridViewTextBoxColumn
            // 
            this.pressuregPaDataGridViewTextBoxColumn.DataPropertyName = "pressure_gPa";
            this.pressuregPaDataGridViewTextBoxColumn.HeaderText = "pressure_gPa";
            this.pressuregPaDataGridViewTextBoxColumn.Name = "pressuregPaDataGridViewTextBoxColumn";
            // 
            // pressuremmDataGridViewTextBoxColumn
            // 
            this.pressuremmDataGridViewTextBoxColumn.DataPropertyName = "pressure_mm";
            this.pressuremmDataGridViewTextBoxColumn.HeaderText = "pressure_mm";
            this.pressuremmDataGridViewTextBoxColumn.Name = "pressuremmDataGridViewTextBoxColumn";
            // 
            // winddirectidDataGridViewTextBoxColumn
            // 
            this.winddirectidDataGridViewTextBoxColumn.DataPropertyName = "wind_direct_id";
            this.winddirectidDataGridViewTextBoxColumn.HeaderText = "wind_direct_id";
            this.winddirectidDataGridViewTextBoxColumn.Name = "winddirectidDataGridViewTextBoxColumn";
            // 
            // valuedateDataGridViewTextBoxColumn
            // 
            this.valuedateDataGridViewTextBoxColumn.DataPropertyName = "value_date";
            this.valuedateDataGridViewTextBoxColumn.HeaderText = "value_date";
            this.valuedateDataGridViewTextBoxColumn.Name = "valuedateDataGridViewTextBoxColumn";
            // 
            // bindingSourceMeteo
            // 
            this.bindingSourceMeteo.DataMember = "table_meteo";
            this.bindingSourceMeteo.DataSource = this.oNGUREN_DBDataSet;
            // 
            // oNGUREN_DBDataSet
            // 
            this.oNGUREN_DBDataSet.DataSetName = "oNGUREN_DBDataSet";
            this.oNGUREN_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "ConvertAiiskue";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 244);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(844, 20);
            this.textBox1.TabIndex = 4;
            // 
            // bindingSourcePower
            // 
            this.bindingSourcePower.DataMember = "table_power";
            this.bindingSourcePower.DataSource = this.onguren_dbDataSet_Power;
            // 
            // onguren_dbDataSet_Power
            // 
            this.onguren_dbDataSet_Power.DataSetName = "onguren_dbDataSet_Power";
            this.onguren_dbDataSet_Power.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSourceWindTotal
            // 
            this.bindingSourceWindTotal.DataMember = "table_wind_total";
            this.bindingSourceWindTotal.DataSource = this.onguren_dbDataSet_WindTotal;
            // 
            // onguren_dbDataSet_WindTotal
            // 
            this.onguren_dbDataSet_WindTotal.DataSetName = "onguren_dbDataSet_WindTotal";
            this.onguren_dbDataSet_WindTotal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table_wind_totalTableAdapter
            // 
            this.table_wind_totalTableAdapter.ClearBeforeFill = true;
            // 
            // table_meteoTableAdapter
            // 
            this.table_meteoTableAdapter.ClearBeforeFill = true;
            // 
            // table_powerTableAdapter
            // 
            this.table_powerTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSourceSNTotal
            // 
            this.bindingSourceSNTotal.DataMember = "table_sn_total";
            this.bindingSourceSNTotal.DataSource = this.onguren_dbDataSet_SNTotal;
            // 
            // onguren_dbDataSet_SNTotal
            // 
            this.onguren_dbDataSet_SNTotal.DataSetName = "onguren_dbDataSet_SNTotal";
            this.onguren_dbDataSet_SNTotal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table_sn_totalTableAdapter
            // 
            this.table_sn_totalTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 512);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMeteo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oNGUREN_DBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onguren_dbDataSet_Power)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWindTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onguren_dbDataSet_WindTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSNTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onguren_dbDataSet_SNTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource bindingSourceMeteo;
        private System.Windows.Forms.BindingSource bindingSourcePower;
        private System.Windows.Forms.BindingSource bindingSourceWindTotal;
        private onguren_dbDataSet_WindTotal onguren_dbDataSet_WindTotal;
        private onguren_dbDataSet_WindTotalTableAdapters.table_wind_totalTableAdapter table_wind_totalTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tempDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlagaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn windspeedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winddirectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insolationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pressuregPaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pressuremmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winddirectidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valuedateDataGridViewTextBoxColumn;
        private oNGUREN_DBDataSet oNGUREN_DBDataSet;
        private oNGUREN_DBDataSetTableAdapters.table_meteoTableAdapter table_meteoTableAdapter;
        private onguren_dbDataSet_Power onguren_dbDataSet_Power;
        private onguren_dbDataSet_PowerTableAdapters.table_powerTableAdapter table_powerTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourceSNTotal;
        private onguren_dbDataSet_SNTotal onguren_dbDataSet_SNTotal;
        private onguren_dbDataSet_SNTotalTableAdapters.table_sn_totalTableAdapter table_sn_totalTableAdapter;
    }
}

