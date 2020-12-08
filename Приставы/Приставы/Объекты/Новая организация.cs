using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Приставы.Объекты
{
    public partial class Новая_Организация : Form
    {
        public Новая_Организация()
        {
            InitializeComponent();
        }

        private void Новая_организация_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "приставыDataSet.Организация". При необходимости она может быть перемещена или удалена.
            this.организацияTableAdapter.Fill(this.приставыDataSet.Организация);

        }

        private void button34_Click(object sender, EventArgs e)
        {
            this.организацияTableAdapter.Update(this.приставыDataSet);
            this.организацияTableAdapter.Fill(this.приставыDataSet.Организация);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            var deleteORG = MessageBox.Show("Вы действительно хотите удалить данного руководителя?", "Информация",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteORG != DialogResult.Yes)
            {
                return;
            }
            int ind = this.dataGridView.SelectedCells[0].RowIndex;
            this.dataGridView.Rows.RemoveAt(ind);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.textBox7.Text = "";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            this.организацияBindingSource.Filter = "[Организация] Like'" + this.textBox7.Text + "%'";
        }
    }
}
