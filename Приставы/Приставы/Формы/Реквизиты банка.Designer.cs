namespace Приставы.Формы
{
    partial class Реквизиты_банка
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Реквизиты_банка));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tbINNBank = new System.Windows.Forms.TextBox();
            this.tbBIKBank = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNameBank = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.названиеБанкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.бИКБанкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.иННБанкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.реквизитыБанкаBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.приставыDataSet = new Приставы.ПриставыDataSet();
            this.реквизиты_банкаTableAdapter = new Приставы.ПриставыDataSetTableAdapters.Реквизиты_банкаTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.реквизитыБанкаBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.приставыDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(261, 186);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 39);
            this.buttonCancel.TabIndex = 29;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(393, 186);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 39);
            this.buttonSave.TabIndex = 30;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tbINNBank
            // 
            this.tbINNBank.Location = new System.Drawing.Point(194, 131);
            this.tbINNBank.MaxLength = 4;
            this.tbINNBank.Multiline = true;
            this.tbINNBank.Name = "tbINNBank";
            this.tbINNBank.Size = new System.Drawing.Size(319, 30);
            this.tbINNBank.TabIndex = 26;
            this.tbINNBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBIKBank_KeyPress);
            // 
            // tbBIKBank
            // 
            this.tbBIKBank.Location = new System.Drawing.Point(194, 71);
            this.tbBIKBank.MaxLength = 11;
            this.tbBIKBank.Multiline = true;
            this.tbBIKBank.Name = "tbBIKBank";
            this.tbBIKBank.Size = new System.Drawing.Size(319, 30);
            this.tbBIKBank.TabIndex = 27;
            this.tbBIKBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBIKBank_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "ИНН банка";
            // 
            // textBoxNameBank
            // 
            this.textBoxNameBank.Location = new System.Drawing.Point(195, 17);
            this.textBoxNameBank.Multiline = true;
            this.textBoxNameBank.Name = "textBoxNameBank";
            this.textBoxNameBank.Size = new System.Drawing.Size(319, 30);
            this.textBoxNameBank.TabIndex = 28;
            this.textBoxNameBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNameBank_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "БИК банка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "Название банка";
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.названиеБанкаDataGridViewTextBoxColumn,
            this.бИКБанкаDataGridViewTextBoxColumn,
            this.иННБанкаDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.реквизитыБанкаBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(531, 11);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(567, 350);
            this.dataGridView.TabIndex = 31;
            // 
            // названиеБанкаDataGridViewTextBoxColumn
            // 
            this.названиеБанкаDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.названиеБанкаDataGridViewTextBoxColumn.DataPropertyName = "Название банка";
            this.названиеБанкаDataGridViewTextBoxColumn.HeaderText = "Название банка";
            this.названиеБанкаDataGridViewTextBoxColumn.Name = "названиеБанкаDataGridViewTextBoxColumn";
            this.названиеБанкаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // бИКБанкаDataGridViewTextBoxColumn
            // 
            this.бИКБанкаDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.бИКБанкаDataGridViewTextBoxColumn.DataPropertyName = "БИК банка";
            this.бИКБанкаDataGridViewTextBoxColumn.HeaderText = "БИК банка";
            this.бИКБанкаDataGridViewTextBoxColumn.Name = "бИКБанкаDataGridViewTextBoxColumn";
            this.бИКБанкаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // иННБанкаDataGridViewTextBoxColumn
            // 
            this.иННБанкаDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.иННБанкаDataGridViewTextBoxColumn.DataPropertyName = "ИНН банка";
            this.иННБанкаDataGridViewTextBoxColumn.HeaderText = "ИНН банка";
            this.иННБанкаDataGridViewTextBoxColumn.Name = "иННБанкаDataGridViewTextBoxColumn";
            this.иННБанкаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // реквизитыБанкаBindingSource
            // 
            this.реквизитыБанкаBindingSource.DataMember = "Реквизиты банка";
            this.реквизитыБанкаBindingSource.DataSource = this.приставыDataSet;
            // 
            // приставыDataSet
            // 
            this.приставыDataSet.DataSetName = "ПриставыDataSet";
            this.приставыDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // реквизиты_банкаTableAdapter
            // 
            this.реквизиты_банкаTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(135, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 39);
            this.button1.TabIndex = 32;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Реквизиты_банка
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 373);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.tbINNBank);
            this.Controls.Add(this.tbBIKBank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNameBank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Реквизиты_банка";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Реквизиты банка";
            this.Load += new System.EventHandler(this.Реквизиты_банка_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBIKBank_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.реквизитыБанкаBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.приставыDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox tbINNBank;
        private System.Windows.Forms.TextBox tbBIKBank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNameBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private ПриставыDataSet приставыDataSet;
        private System.Windows.Forms.BindingSource реквизитыБанкаBindingSource;
        private ПриставыDataSetTableAdapters.Реквизиты_банкаTableAdapter реквизиты_банкаTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиеБанкаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn бИКБанкаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn иННБанкаDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}