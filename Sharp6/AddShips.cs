using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sharp6
{
    [Serializable]
    public partial class AddShips : Form
    {
        public AddShips()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; /*запрещаем писать в комбобоксе*/
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        /*Выбор корабля Боевой*/
        private void radioButton1_Click(object sender, EventArgs e) 
        {           
            radioButton1.Checked = true; //кнопка имеет статус «выбрана»
            radioButton2.Checked = false; //кнопка имеет статус «не выбрана»
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {            
            numericUpDown2.Enabled = true;
            numericUpDown4.Enabled = true;
            numericUpDown5.Enabled = true;
            numericUpDown2.Visible = true;
            numericUpDown4.Visible = true;
            numericUpDown5.Visible = true;
            label5.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label7.Text = "Кол-во команды";
            comboBox2.Enabled = false;
            comboBox2.Visible = false;
            comboBox1.Enabled = true;
            comboBox1.Visible = true;         
        }
        /*Выбор корабля Пассажирский*/
        private void radioButton2_Click(object sender, EventArgs e) 
        {
            radioButton1.Checked = false; //кнопка имеет статус «не выбрана»
            radioButton2.Checked = true;//кнопка имеет статус «выбрана»
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            numericUpDown2.Visible = false;
            numericUpDown4.Visible = false;
            numericUpDown5.Visible = false;
            label5.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label7.Text = "Кол-во пассажиров";
            comboBox1.Enabled = false;
            comboBox1.Visible = false;
            comboBox2.Enabled = true;
            comboBox2.Visible = true;
        }


        /*Кнопка ОТМЕНА*/
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Отменить ввод?", "Подтвердите действие", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) //если "да", то форма закрывается, данные не записываются
            {
                this.Close();
            }
        }
        /*Кнопка ДОБАВИТЬ*/
        private void button1_Click(object sender, EventArgs e)
        {          
            DialogResult dialogResult = MessageBox.Show("Добавить корабль в список?", "Подтвердите действие", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) //если выбрано да - то происходит запись дан-ных в лист коллекции
            {
                DialogResult = DialogResult.OK;
            }
            else if (dialogResult == DialogResult.No) //если нет - то форма закрывается, записи не будет
            {
                this.Close();
            }
        }

    }
}
