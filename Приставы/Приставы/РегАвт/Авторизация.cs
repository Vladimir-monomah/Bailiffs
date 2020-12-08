using System;
using System.Linq;
using System.Windows.Forms;
using Приставы.Админка;

namespace Приставы.РегАвт
{
    public partial class Авторизация : Form
    {
        int counter = 0;

        public Авторизация()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Открытие формы регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReg_Click(object sender, EventArgs e)
        {
            var открыть = new Регистрация();
            открыть.Show();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно " +
               "хотите закрыть программу?",
               "Закрытие программы", MessageBoxButtons.
               YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btVH_Click(object sender, EventArgs e)
        {
            if (this.tbLogin.Text == "" && this.tbPassword.Text == "")
            {
                MessageBox.Show("Вы не " +
                    "ввели логин или пароль! " +
                    "Пожалуйста, заполните поля!",
                    "Сообщение", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            this.counter++;
            if (string.IsNullOrEmpty(this.tbLogin.Text))
            {
                this.tbLogin.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.tbPassword.Text))
            {
                this.tbPassword.Focus();
                return;
            }

            else if (this.counter >= 3)
            {
                this.tbLogin.Enabled = false;
                this.tbPassword.Enabled = false;
                MessageBox.Show("По всем вопросам " +
                    "восстановления пароля свяжитесь с " +
                    "Вашим администратором по номеру  " +
                    "+7 (986) 717-80-39!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            var loginCondition = $"логин = '{this.tbLogin.Text}' AND пароль = '{this.tbPassword.Text}' ";
            var user = EntityManager.FilterUsers(loginCondition).FirstOrDefault();
            if (user != null)
            {
                if (user.Является_администратором)
                {
                    var открыть = new Администратор();
                    this.Hide();
                    открыть.Show();
                }
                else
                {
                    var открыть = new Form1();
                    this.Hide();
                    открыть.Show();
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void Авторизация_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
