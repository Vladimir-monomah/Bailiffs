using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Приставы.ПриставыDataSetTableAdapters;
using static Приставы.ПриставыDataSet;

namespace Приставы.Формы
{
    public partial class Исполнитель : Form
    {
        public delegate void OnSave();

        public delegate void OnBeforeSave(ИсполнительRow isRecordExists);

        public Исполнитель()
        {
            this.OnSaveEvent += () => { };
            this.OnBeforeSaveEvent += existingDirector => { };
            this.InitializeComponent();
        }

        public event OnSave OnSaveEvent;

        public event OnBeforeSave OnBeforeSaveEvent;

        /// <summary>
        /// Проверка заполненности полей
        /// </summary>
        /// <returns></returns>
        private bool CheckTextBoxes()
        {
            if (this.textBoxISP.Text == "")
            {
                return false;
            }
            return true;
        }

        public string ПолучитьИсполнителя()
        {
            return this.textBoxISP.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckTextBoxes())
            {
                MessageBox.Show("Название элемента справочника пустое и не будет сохранено.", "Информация",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            var ispName = this.textBoxISP.Text;
            ИсполнительRow existingISP = null;
            var adapter = new ИсполнительTableAdapter();
            adapter.Fill(EntityManager.PR_ISPDataTable);
            foreach(var isp in EntityManager.PR_ISPDataTable)
            {
                if (ispName == isp.ФИО)
                {
                    existingISP = isp;
                    break;
                }
            }

            if (existingISP != null)
            {
                this.OnBeforeSaveEvent(existingISP);
                if (MessageBox.Show("Исполнитель уже существует! Изменить информацию о нём?", 
                    "Информация", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                var newISP = EntityManager.PR_ISPDataTable.NewИсполнительRow();
                newISP.ФИО = this.textBoxISP.Text;

                EntityManager.PR_ISPDataTable.AddИсполнительRow(newISP);
            }

            EntityManager.UpdatePR_ISP();
            this.OnSaveEvent();
            MessageBox.Show("Добавление прошло успешно!", "Информация", MessageBoxButtons.OK);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxISP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var deleteISP = MessageBox.Show("Вы действительно хотите удалить данного исполнителя?", "Информация",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteISP != DialogResult.Yes)
            {
                return;
            }
            int ind = this.dataGridView.SelectedCells[0].RowIndex;
            this.dataGridView.Rows.RemoveAt(ind);
            this.исполнительTableAdapter.Update(приставыDataSet.Исполнитель);
        }

        private void Исполнитель_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "приставыDataSet.Исполнитель". При необходимости она может быть перемещена или удалена.
            this.исполнительTableAdapter.Fill(this.приставыDataSet.Исполнитель);

        }
    }
}
