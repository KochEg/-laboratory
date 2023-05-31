using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharp6
{
    [Serializable]
    public partial class Redact : Form
    {
        public Redact()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; /*запрещаем писать в комбобоксе*/
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сохранить изменения?", "Подтвердите действие", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) //если "да", то эта форма закрывается
            {
                DialogResult = DialogResult.OK; //а измененные данные будут записаны в лист кол-лекции
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Закрыть форму?", "Подтвердите действие", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) //если "да", то эта форма закрывается
            {
                DialogResult = DialogResult.OK; //данные не изменяются
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   pictureBox2.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Не возможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = false;
            numericUpDown2.Visible = false;
            numericUpDown4.Enabled = false;
            numericUpDown4.Visible = false;
            numericUpDown5.Enabled = false;
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
    }
}
