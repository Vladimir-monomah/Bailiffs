using DGV2Printer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Приставы.Properties;
using Приставы.Объекты;
using Приставы.РегАвт;
using Приставы.Формы;
using static Приставы.ПриставыDataSet;

namespace Приставы
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            this.Form1_Load();
        }

        private void Form1_Load()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "приставыDataSet.Должники". При необходимости она может быть перемещена или удалена.
            this.должникиTableAdapter.Fill(this.приставыDataSet.Должники);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "приставыDataSet.ДолжникиЗапрос". При необходимости она может быть перемещена или удалена.
            this.должникиЗапросTableAdapter.Fill(this.приставыDataSet.ДолжникиЗапрос);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "приставыDataSet.Должники". При необходимости она может быть перемещена или удалена.
            this.должникиTableAdapter.Fill(this.приставыDataSet.Должники);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "приставыDataSet.ДолжникиЗапрос". При необходимости она может быть перемещена или удалена.
            this.должникиЗапросTableAdapter.Fill(this.приставыDataSet.ДолжникиЗапрос);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var input = new Карточка_должника();
            input.ShowDialog();

            this.должникиЗапросTableAdapter.Fill(this.приставыDataSet.ДолжникиЗапрос);
        }

        public ДолжникиRow GetCurrentEmployee()
        {
            return (ДолжникиRow)((DataRowView)this.dataGridView.CurrentRow.DataBoundItem).Row;
        }

        private string BuildWorkerCardFilter()
        {
            var filterExpressionList = new List<string>();
            var fieldFilter = this.textBox3.Text;
            if (!string.IsNullOrEmpty(fieldFilter))
            {
                filterExpressionList.Add(string.Format("(([ФИО должника] Like '%{0}%') OR ([ФИО взыскателя] Like '%{0}%'))", fieldFilter));
            }

            if (this.onlyWorkingFilterCheckBox.Checked)
            {
                filterExpressionList.Add("[Долг]");
            }

            return string.Join(" AND ", filterExpressionList);
        }

        /// <summary>
        /// Кнопка удалить строку должника из БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var idEmployee = ((ДолжникиЗапросRow)((DataRowView)this.dataGridView.CurrentRow?.DataBoundItem)?.Row)?.Id;
            if (!idEmployee.HasValue)
            {
                return;
            }

            var deleteEmployeeQuestionResult = MessageBox.Show("Вы действительно хотите удалить сотрудника?", "Информация",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteEmployeeQuestionResult != DialogResult.Yes)
            {
                return;
            }

            using (var connection = new OleDbConnection(Settings.Default.ПриставыConnectionString))
            {
                connection.Open();
                using (var sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = $"DELETE FROM Должники WHERE Id = {idEmployee.Value}";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            this.Form1_Load();
        }

        /// <summary>
        /// стереть весь текст
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = "";
        }

        /// <summary>
        /// Фильтрация должников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.должникиЗапросBindingSource.Filter = this.BuildWorkerCardFilter();
        }

        /// <summary>
        /// Фильтрация долгов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFilter_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var input = new Карточка_должника();
            input.LoadКарточка_должника(
                (ДолжникиЗапросRow)((DataRowView)this.dataGridView.CurrentRow.DataBoundItem).Row);
            input.ShowDialog();

            this.должникиTableAdapter.Fill(this.приставыDataSet.Должники);
        }

        private void buttonFilter_Click_1(object sender, EventArgs e)
        {
            var deltaCoordinates = this.onlyWorkingFilterCheckBox.Height;
            if (this.onlyWorkingFilterCheckBox.Visible)
            {
                this.buttonFilter.BackColor = Color.Transparent;
                deltaCoordinates = -deltaCoordinates;
            }
            else
            {
                this.buttonFilter.BackColor = Color.LightSlateGray;
            }

            this.onlyWorkingFilterCheckBox.Visible = !this.onlyWorkingFilterCheckBox.Visible;

            this.dataGridView.Top += deltaCoordinates;
            this.dataGridView.Height -= deltaCoordinates;
            this.label5.Top += deltaCoordinates;
            this.textBox3.Top += deltaCoordinates;
            this.button11.Top += deltaCoordinates;
        }

        private void onlyWorkingFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.должникиЗапросBindingSource.Filter = this.BuildWorkerCardFilter();
        }

        private void новыйПристависполнительToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Новый_пристав_исполнитель открыть = new Новый_пристав_исполнитель();
            открыть.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show("Вы действиетльно хотите выйти?",
                    "Закрытие программы", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else e.Cancel = true;
            }
            else Application.Exit();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var открыть = new Должность();
            открыть.ShowDialog();
        }

        private void отделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var открыть = new Отдел();
            открыть.ShowDialog();
        }

        /// <summary>
        /// Печать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDataGridView pr = new PrintDataGridView(this.dataGridView);
            pr.isRightToLeft = true;
            pr.ReportHeader = this.label6.Text;
            pr.Print();
        }

        /// <summary>
        /// Экспорт данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExp_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            for (int i = 0; i < this.dataGridView.Columns.Count; i++)
            {
                var cellCaption = this.dataGridView.Columns[i].HeaderText;
                var bracketIndex = cellCaption.IndexOf('(') - 1;
                if (bracketIndex > -1)
                {
                    cellCaption = cellCaption.Substring(0, bracketIndex);
                }

                cellCaption = cellCaption.Replace("ФИО должника", "ФИО должника");

                ExcelWorkSheet.Cells[1, i + 1] = cellCaption;
            }
            for (int i = 0; i < this.dataGridView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < this.dataGridView.Columns.Count; j++)
                {
                    ExcelWorkSheet.Cells[i + 2, j + 1] = this.dataGridView.Rows[i].Cells[j].Value.ToString();
                    if (!this.dataGridView.Columns[j].Visible)
                    {
                        ExcelWorkSheet.Cells[i + 2, j + 1].ColumnWidth = 0;
                    }
                }
            }

            for (int j = 0; j < this.dataGridView.Columns.Count; j++)
            {
                if (this.dataGridView.Columns[j].Visible)
                {
                    ExcelWorkSheet.Columns[j + 1].AutoFit();
                }
            }
            ExcelApp.Visible = true;
        }

        private void сохранитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dataBasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Приставы.mdb";
            var saveDialog = new SaveFileDialog
            {
                FileName = "Приставы - копия.mdb",
                Filter = "AccessDB files|*.mdb"
            };
            try
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(dataBasePath, saveDialog.FileName, true);
                    MessageBox.Show("Резервное копирование прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Не удаётся скопировать файл из-за исключения: " + exception.Message);
            }
        }

        private void восстановитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dataBasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Приставы.mdb";
            var openDialog = new OpenFileDialog
            {
                Filter = "AccessDB files|*.mdb"
            };
            try
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(openDialog.FileName, dataBasePath, true);
                    MessageBox.Show("Восстановление прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Form1_Load();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void алиментыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var открыть = new Калькулятор();
            открыть.ShowDialog();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\Справка.chm");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void сменаАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var открыть = new Авторизация();
            открыть.Show();
            this.Hide();
        }

        private void новаяОрганизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var открыть = new Новая_Организация();
            открыть.ShowDialog();
        }
    }
}
