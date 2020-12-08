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
    public partial class Новый_отдел : Form
    {
        public delegate void OnSave();

        public delegate void OnBeforeSave(ОтделыRow isRecordExists);

        public Новый_отдел()
        {
            this.OnSaveEvent += () => { };
            this.OnBeforeSaveEvent += isRecordExists => { };
            this.InitializeComponent();
        }

        public event OnSave OnSaveEvent;

        public event OnBeforeSave OnBeforeSaveEvent;

        public void ЗагрузитьОтдел(string названиеОтдел)
        {
            this.textBoxDep.Text = названиеОтдел;
        }

        private bool CheckTextBoxes()
        {
            if (this.textBoxDep.Text == "")
            {
                return false;
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckTextBoxes())
            {
                MessageBox.Show("Название элемента справочника пустое и не будет сохранено.", "Информация",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            var departamentName = this.textBoxDep.Text;
            var adapter = new ОтделыTableAdapter();
            adapter.Fill(EntityManager.DepDataTable);
            ОтделыRow existingDepartaments = null;
            foreach (var departaments in EntityManager.DepDataTable)
            {
                if (departaments.Наименование == departamentName)
                {
                    existingDepartaments = departaments;
                    break;
                }
            }

            if (existingDepartaments != null)
            {
                this.OnBeforeSaveEvent(existingDepartaments);
                MessageBox.Show("Отдел с таким именем уже существует!", "Информация", MessageBoxButtons.OK);
                return;
            }

            var newDepartaments = EntityManager.DepDataTable.NewОтделыRow();
            newDepartaments.Наименование = departamentName;
            EntityManager.DepDataTable.AddОтделыRow(newDepartaments);
            EntityManager.UpdateDep();
            this.OnSaveEvent();

            MessageBox.Show("Добавление прошло успешно!", "Информация", MessageBoxButtons.OK);
        }

        private void textBoxDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Новый_отдел_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "приставыDataSet.Отделы". При необходимости она может быть перемещена или удалена.
            this.отделыTableAdapter.Fill(this.приставыDataSet.Отделы);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var deleteDepartament = MessageBox.Show("Вы действительно хотите удалить данный отдел?", "Информация",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteDepartament != DialogResult.Yes)
            {
                return;
            }
            int ind = this.dataGridView.SelectedCells[0].RowIndex;
            this.dataGridView.Rows.RemoveAt(ind);
            this.отделыTableAdapter.Update(приставыDataSet.Отделы);
        }
    }
}
