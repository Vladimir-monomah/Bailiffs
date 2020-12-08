namespace Приставы.Объекты
{
    partial class Новая_Организация
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Новая_Организация));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.организацияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.адресОрганизацииDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.организацияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.приставыDataSet = new Приставы.ПриставыDataSet();
            this.button34 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button38 = new System.Windows.Forms.Button();
            this.организацияTableAdapter = new Приставы.ПриставыDataSetTableAdapters.ОрганизацияTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.организацияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.приставыDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.организацияDataGridViewTextBoxColumn,
            this.адресОрганизацииDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.организацияBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(11, 112);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1462, 648);
            this.dataGridView.TabIndex = 62;
            // 
            // организацияDataGridViewTextBoxColumn
            // 
            this.организацияDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.организацияDataGridViewTextBoxColumn.DataPropertyName = "Организация";
            this.организацияDataGridViewTextBoxColumn.HeaderText = "Организация";
            this.организацияDataGridViewTextBoxColumn.Name = "организацияDataGridViewTextBoxColumn";
            this.организацияDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // адресОрганизацииDataGridViewTextBoxColumn
            // 
            this.адресОрганизацииDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.адресОрганизацииDataGridViewTextBoxColumn.DataPropertyName = "Адрес организации";
            this.адресОрганизацииDataGridViewTextBoxColumn.HeaderText = "Адрес организации";
            this.адресОрганизацииDataGridViewTextBoxColumn.Name = "адресОрганизацииDataGridViewTextBoxColumn";
            this.адресОрганизацииDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // организацияBindingSource
            // 
            this.организацияBindingSource.DataMember = "Организация";
            this.организацияBindingSource.DataSource = this.приставыDataSet;
            // 
            // приставыDataSet
            // 
            this.приставыDataSet.DataSetName = "ПриставыDataSet";
            this.приставыDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(11, 40);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(102, 30);
            this.button34.TabIndex = 61;
            this.button34.Text = "Сохранить";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(119, 40);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(107, 30);
            this.button35.TabIndex = 59;
            this.button35.Text = "Удалить";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(232, 40);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(109, 30);
            this.button37.TabIndex = 60;
            this.button37.Text = "Добавить";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Visible = false;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(77, 76);
            this.textBox7.MaxLength = 30;
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(1350, 30);
            this.textBox7.TabIndex = 58;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(7, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 21);
            this.label16.TabIndex = 56;
            this.label16.Text = "Поиск";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(732, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 21);
            this.label17.TabIndex = 57;
            this.label17.Text = "Организация";
            // 
            // button38
            // 
            this.button38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button38.Image = global::Приставы.Properties.Resources.кнопка_3;
            this.button38.Location = new System.Drawing.Point(1441, 76);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(32, 30);
            this.button38.TabIndex = 55;
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // организацияTableAdapter
            // 
            this.организацияTableAdapter.ClearBeforeFill = true;
            // 
            // Новая_Организация
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 771);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button35);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button38);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Новая_Организация";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новая организация";
            this.Load += new System.EventHandler(this.Новая_организация_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.организацияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.приставыDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button38;
        private ПриставыDataSet приставыDataSet;
        private System.Windows.Forms.BindingSource организацияBindingSource;
        private ПриставыDataSetTableAdapters.ОрганизацияTableAdapter организацияTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn организацияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn адресОрганизацииDataGridViewTextBoxColumn;
    }
}