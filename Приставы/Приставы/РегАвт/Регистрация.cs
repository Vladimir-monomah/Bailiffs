using System;
using System.Windows.Forms;

namespace Приставы.РегАвт
{
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Проверка заполненности строк
        /// </summary>
        /// <returns></returns>
        private bool CheckTextBoxes()
        {
            if (this.tbSername.Text == "" || this.tbName.Text == "" ||
                this.tbPatronomic.Text == "" ||
                this.tbLogin.Text == "" || this.tbPassword.Text == "")
            {
                return false;
            }
            return true;
        }

        private void btRegistration_Click(object sender, EventArgs e)
        {
            if (!this.CheckTextBoxes())
            {
                MessageBox.Show("Заполните все поля", "Сообщение" +
                    MessageBoxButtons.OK);
                return;
            }

            var newUser = EntityManager.UserDataTable.NewПользователиRow();
            newUser.Фамилия = this.tbSername.Text;
            newUser.Имя = this.tbName.Text;
            newUser.Отчество = this.tbPatronomic.Text;
            newUser.Логин = this.tbLogin.Text;
            newUser.Пароль = this.tbPassword.Text;
            EntityManager.UserDataTable.AddПользователиRow(newUser);
            EntityManager.UpdateUsers();

            MessageBox.Show("Регистрация успешна", "Сообщение");
            this.Close();
        }
    }
}
