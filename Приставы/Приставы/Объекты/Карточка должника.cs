using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Приставы.Объекты;
using Приставы.ПриставыDataSetTableAdapters;
using static Приставы.ПриставыDataSet;
using Word = Microsoft.Office.Interop.Word;

namespace Приставы.Формы
{
    public partial class Карточка_должника : Form
    {
        private Dictionary<string, string[]> sexToHeightMap = new Dictionary<string, string[]>
        {
            {
                "Алименты",
                new string[]
                {
                }
            }
        };

        private ДолжникиRow должники;

        public Карточка_должника()
        {
            this.InitializeComponent();
        }

        public void LoadКарточка_должника(ДолжникиЗапросRow должники)
        {
            this.должники = EntityManager.FilterDOL($"Id={должники.Id}").FirstOrDefault();
            this.textBoxNomer.Text = должники.IsНомер_делаNull() ? "0" : должники.Номер_дела.ToString();
            this.textBoxFIODOL.Text = должники.ФИО_должника;
            this.tbSeriaDOL.Text = Convert.ToInt32(должники.Серия_паспорта_должника).ToString();
            this.tbNumberDOL.Text = Convert.ToInt32(должники.Номер_паспорта_должника).ToString();
            this.tbStreetDol.Text = должники.Адрес_должника;
            this.dateTimePickerDOL.Value = должники.Дата_рождения_должника;
            this.tbInnDOL.Text = должники.ИНН_должника;
            this.textBoxFIOVZ.Text = должники.ФИО_взыскателя;
            this.tbSeriaVZ.Text = Convert.ToInt32(должники.Серия_паспорта_взыскателя).ToString();
            this.tbNumberVZ.Text = Convert.ToInt32(должники.Номер_паспорта_взыскателя).ToString();
            this.dateTimePickerVZ.Value = должники.Дата_рождения_взыскателя;
            this.tbStreetVZ.Text = должники.Адрес_взыскателя;
            this.tbInnVZ.Text = должники.ИНН_взыскателя;
            this.textBoxPR.Text = должники._Пристав_исполнитель;
            this.ReceiptDateTimePicker.Enabled = false;
            this.ReceiptDateTimePicker.Value = должники.Дата_заведения_дела;
            this.DateJobChancheTimePicker.Enabled = false;
            this.DateJobChancheTimePicker.Value = должники.Дата_окончания_дела;
            this.DateJobChancheTimePicker.Enabled = true;
            this.tbFIOChildren.Text = должники.ФИО_ребёнка;
            this.tbNumberChildren.Text = должники.___свидетельсва_о_рождении;
            this.dateTimePickerChildren.Value = должники.Дата_рождения_ребёнка;
            this.tbNum.Text = должники.Счёт_получателя;
            this.tbBank.Text = должники.Банк_получателя;
            this.tbInnBank.Text = должники.ИНН_банка_получателя;
            this.tbBIKBank.Text = должники.БИК_банка_получателя;
            this.label22.Text = должники.ФИО_должника;
            this.tbRazmVZ.Text = должники.Размер_взыскания.ToString();
            this.tbORG.Text = должники.Организация;
            this.tbStreetOrg.Text = должники.Адрес_организации;
            this.firedCheckBox.Checked = !должники.Долг;

            if (!должники.IsТип_взысканияNull())
            {
                this.comboBoxTypeVZ.SelectedIndex = this.comboBoxTypeVZ.Items.IndexOf(должники.Тип_взыскания);
            }

            if (!должники.IsПол_должникаNull())
            {
                this.cbPolDol.SelectedIndex = this.cbPolDol.Items.IndexOf(должники.Пол_должника);
            }

            if (!должники.IsПол_взыскателяNull())
            {
                this.cbPolVZ.SelectedIndex = this.cbPolVZ.Items.IndexOf(должники.Пол_взыскателя);
            }

            if (!должники.IsПол_ребёнкаNull())
            {
                this.cbChildren.SelectedIndex = this.cbChildren.Items.IndexOf(должники.Пол_ребёнка);
            }
        }

        private bool CheckTextBoxes()
        {
            if (this.textBoxNomer.Text == "" || this.textBoxFIODOL.Text == ""
                || this.textBoxFIOVZ.Text == "" || this.textBoxPR.Text == ""
                || this.ReceiptDateTimePicker.Value.ToString() == "")
            {
                return false;
            }

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckTextBoxes())
            {
                MessageBox.Show("Заполните необходимые поля!",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var idEmloyee = this.должники?.Id;
            var adapter = new ДолжникиTableAdapter();
            adapter.Fill(EntityManager.DOLDataTable);
            var savingEmployee = EntityManager.DOLDataTable.FindById(idEmloyee ?? -1)
                ?? EntityManager.DOLDataTable.NewДолжникиRow();

            savingEmployee.ФИО_должника = this.textBoxFIODOL.Text;
            savingEmployee.Организация = this.tbORG.Text;
            savingEmployee.Адрес_организации = this.tbStreetOrg.Text;
            savingEmployee.Серия_паспорта_должника = Convert.ToInt32(this.tbSeriaDOL.Text);
            savingEmployee.Номер_паспорта_должника = Convert.ToInt32(this.tbNumberDOL.Text);
            savingEmployee.Дата_рождения_должника = this.dateTimePickerDOL.Value
                .AddHours(-this.dateTimePickerDOL.Value.Hour)
                .AddMinutes(-this.dateTimePickerDOL.Value.Minute)
                .AddSeconds(-this.dateTimePickerDOL.Value.Second)
                .AddMilliseconds(-this.dateTimePickerDOL.Value.Millisecond);
            savingEmployee.ИНН_должника = this.tbInnDOL.Text;
            savingEmployee.Адрес_должника = this.tbStreetDol.Text;
            savingEmployee.Пол_должника = (string)this.cbPolDol.SelectedItem;
            savingEmployee.ФИО_взыскателя = this.textBoxFIOVZ.Text;
            savingEmployee.Серия_паспорта_взыскателя = Convert.ToInt32(this.tbSeriaVZ.Text);
            savingEmployee.Номер_паспорта_взыскателя = Convert.ToInt32(this.tbNumberVZ.Text);
            savingEmployee.Дата_рождения_взыскателя = this.dateTimePickerVZ.Value
                .AddHours(-this.dateTimePickerVZ.Value.Hour)
                .AddMinutes(-this.dateTimePickerVZ.Value.Minute)
                .AddSeconds(-this.dateTimePickerVZ.Value.Second)
                .AddMilliseconds(-this.dateTimePickerVZ.Value.Millisecond);
            savingEmployee.ИНН_взыскателя = this.tbInnVZ.Text;
            savingEmployee.Адрес_взыскателя = this.tbStreetVZ.Text;
            savingEmployee.Пол_взыскателя = (string)this.cbPolVZ.SelectedItem;
            savingEmployee._Пристав_исполнитель = this.textBoxPR.Text;
            savingEmployee.Дата_заведения_дела = this.ReceiptDateTimePicker.Value
                .AddHours(-this.ReceiptDateTimePicker.Value.Hour)
                .AddMinutes(-this.ReceiptDateTimePicker.Value.Minute)
                .AddSeconds(-this.ReceiptDateTimePicker.Value.Second)
                .AddMilliseconds(-this.ReceiptDateTimePicker.Value.Millisecond);
            savingEmployee.Дата_окончания_дела = this.DateJobChancheTimePicker.Value
                .AddHours(-this.DateJobChancheTimePicker.Value.Hour)
                .AddMinutes(-this.DateJobChancheTimePicker.Value.Minute)
                .AddSeconds(-this.DateJobChancheTimePicker.Value.Second)
                .AddMilliseconds(-this.DateJobChancheTimePicker.Value.Millisecond);
            savingEmployee.Тип_взыскания = (string)this.comboBoxTypeVZ.SelectedItem;
            savingEmployee.ФИО_ребёнка = this.tbFIOChildren.Text;
            savingEmployee.___свидетельсва_о_рождении = this.tbNum.Text;
            savingEmployee.Дата_рождения_ребёнка = this.dateTimePickerChildren.Value
                .AddHours(-this.dateTimePickerChildren.Value.Hour)
                .AddMinutes(-this.dateTimePickerChildren.Value.Minute)
                .AddSeconds(-this.dateTimePickerChildren.Value.Second)
                .AddMilliseconds(-this.dateTimePickerChildren.Value.Millisecond);
            savingEmployee.Пол_ребёнка = (string)this.cbChildren.SelectedItem;
            savingEmployee.Счёт_получателя = this.tbNum.Text;
            savingEmployee.Банк_получателя = this.tbBank.Text;
            savingEmployee.ИНН_банка_получателя = this.tbInnBank.Text;
            savingEmployee.БИК_банка_получателя = this.tbBIKBank.Text;
            savingEmployee.Размер_взыскания = Convert.ToInt32(this.tbRazmVZ.Text);

            savingEmployee.Долг = !this.firedCheckBox.Checked;

            try
            {
                if (this.должники == null)
                {
                    EntityManager.DOLDataTable.AddДолжникиRow(savingEmployee);
                    if (savingEmployee.IsНомер_делаNull())
                    {
                        var должникиTableAdapter = new ДолжникиTableAdapter();
                        должникиTableAdapter.Connection.Open();
                        var nextNumberComand = должникиTableAdapter.Connection.CreateCommand();
                        nextNumberComand.CommandText = "SELECT MAX([Номер дела]) FROM Должники";
                        var nextNumber = (int)nextNumberComand.ExecuteScalar();
                        savingEmployee.Номер_дела = nextNumber + 1;
                    }
                    EntityManager.UpdateDOL();
                }
                else
                {
                    var должникиTableAdapter = new ДолжникиTableAdapter();
                    должникиTableAdapter.Adapter.Update(savingEmployee.Table);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Ошибка при добавлении/изменении! \r\n" + exception.ToString(),
                    "Ошибка",
                    MessageBoxButtons.OK);
                return;
            }
            var message = this.должники == null
                ? "Добавление прошло успешно!"
                : "Изменение завершено успешно!";

            MessageBox.Show(message, "Информация", MessageBoxButtons.OK);
            this.Close();
        }

        private bool IsEmployeeNumbersExists(ДолжникиRow savingEmployee, int cardNumber)
        {
            foreach (var employee in EntityManager.DOLDataTable)
            {
                if ((employee.Номер_дела == cardNumber)
                    && (savingEmployee.IsNull(0) || employee.Id != savingEmployee.Id))
                {
                    return true;
                }
            }

            return false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите закрыть данную вкладку?",
               "Закрытие вкладки", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBoxNomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.KeyChar = (char)0;
                e.Handled = true;
            }
        }

        private void DateJobChancheTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var dateTimePicker = (DateTimePicker)sender;
            if (dateTimePicker.Enabled
                && (dateTimePicker.Value < DateTime.Now.Date))
            {
                MessageBox.Show("Нельзя выбрать предыдующую дату", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker.Value = DateTime.Now.Date;
                return;
            }
        }

        private void textBoxFIODOL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void ReceiptDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var dateTimePicker = (DateTimePicker)sender;
            if (dateTimePicker.Enabled
                && (dateTimePicker.Value < DateTime.Now.Date
                    || dateTimePicker.Value > DateTime.Now.Date.AddDays(1).AddMilliseconds(-1)))
            {
                MessageBox.Show("Нельзя выбрать предыдующую или последующую даты", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker.Value = DateTime.Now.Date;
                return;
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            var открыть = new ИсполнительКарточка();
            if (открыть.ShowDialog() == DialogResult.OK)
            {
                this.textBoxPR.Text = открыть.ПолучитьИсполнителя();
            }
        }

        private void tbSeriaDOL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.KeyChar = (char)0;
                e.Handled = true;
            }
        }

        private void dateTimePickerChildren_ValueChanged(object sender, EventArgs e)
        {
            this.DateJobChancheTimePicker.Value = this.dateTimePickerChildren.Value.AddYears(18);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var templateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Исполнительное производство.dotx");
            if (!File.Exists(templateFile))
            {
                throw new Exception("Не найден файл " + templateFile);
            }

            var oWord = new Word.Application();
            _Document oDoc = null;
            var newTemplateFile = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    $"Исполнительное_производство_{DateTime.Now:dd.MM.yyyy_HH.mm.ss}.docx");
            try
            {
                oDoc = oWord.Documents.Add(templateFile);
                this.SetTemplate(oDoc);
                
                oDoc.SaveAs2(FileName: newTemplateFile);
            }
            finally
            {
                oDoc?.Close();
                oWord.Quit();
            }
            MessageBox.Show("Сохранение прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(newTemplateFile);
        }

        private void SetTemplate(_Document oDoc)
        {
            var tableInfo = oDoc.Tables[1];
            tableInfo.Cell(1, 2).Range.Text = this.tbFIOChildren.Text+" "+this.dateTimePickerChildren.Value.ToString("dd.MM.yyyy");
            tableInfo.Cell(2, 2).Range.Text = this.textBoxFIODOL.Text;
            tableInfo.Cell(2, 4).Range.Text = this.tbORG.Text;
            tableInfo.Cell(3, 2).Range.Text = this.tbStreetOrg.Text;
            tableInfo.Cell(5, 2).Range.Text = this.tbRazmVZ.Text;
            tableInfo.Cell(6, 2).Range.Text = this.textBoxNomer.Text;
            tableInfo.Cell(6, 4).Range.Text = this.ReceiptDateTimePicker.Value.ToString("dd.MM.yyyy");
            tableInfo.Cell(7, 2).Range.Text = this.textBoxNomer.Text;
            tableInfo.Cell(8, 2).Range.Text = this.tbNum.Text;
            tableInfo.Cell(9, 2).Range.Text = this.tbBank.Text;
            tableInfo.Cell(10, 2).Range.Text = this.tbInnBank.Text;
            tableInfo.Cell(11, 2).Range.Text = this.tbBIKBank.Text;
            tableInfo.Cell(15, 2).Range.Text = DateTime.Now.ToString("dd.MM.yyyy");
            tableInfo.Cell(16, 2).Range.Text = this.textBoxPR.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var открыть = new Калькулятор();
            открыть.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var открыть = new Организация();
            if (открыть.ShowDialog() == DialogResult.OK)
            {
                this.tbORG.Text = открыть.ПолучитьОрганизация();
                this.tbStreetOrg.Text = открыть.ПолучитьАдрес();
            }
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            var открыть = new Реквизиты_Банка();
            if (открыть.ShowDialog() == DialogResult.OK)
            {
                this.tbBank.Text = открыть.ПолучитьНазваниеБанка();
                this.tbInnBank.Text = открыть.ПолучитьБИКБанка();
                this.tbBIKBank.Text = открыть.ПолучитьИННБанка();
            }
        }
    }
}
