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
    public partial class View : Form
    {
        
        public View()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Закрыть окно?", "Подтвердите действие", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) //если "да", то форма закрывается, данные не записываются
            {
                this.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "Кол-во команды";
            comboBox2.Enabled = false;
            comboBox2.Visible = false;
            comboBox1.Enabled = true;
            comboBox1.Visible = true;
            numericUpDown2.Enabled = true;
            numericUpDown4.Enabled = true;
            numericUpDown5.Enabled = true;
            numericUpDown2.Visible = true;
            numericUpDown4.Visible = true;
            numericUpDown5.Visible = true;
            label5.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "Кол-во пассажиров";
            comboBox1.Enabled = false;
            comboBox1.Visible = false;
            comboBox2.Enabled = true;
            comboBox2.Visible = true;
            numericUpDown4.Enabled = false;
            numericUpDown4.Visible = false;
            numericUpDown5.Enabled = false;
            numericUpDown5.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }
    }
}
