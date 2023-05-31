using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;



namespace Sharp6
{
    [Serializable]
    public partial class Ships : Form
    {
        List<cl_Ship> col = new List<cl_Ship>();
        public Ships()
        {
            InitializeComponent();
        }

        /*ЧекБокс скрывающий меню*/
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) //если флажок стоит
            {
                toolStrip1.Hide(); //панель скрыта
            }
            else
            {
                toolStrip1.Show(); //то панель инструментов доступна
            }
        }
        /*///////////////////////////////////////////////////////////*/


        /*Кнопки ДОБАВИТЬ*/
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddShips AddObj = new AddShips();
            if (AddObj.ShowDialog() == DialogResult.OK)
            {
                if (AddObj.radioButton1.Checked == true)
                {
                    string classShip = AddObj.radioButton1.Text = "Боевой";
                    string nameShip = AddObj.textBox1.Text;
                    string captainName = AddObj.textBox2.Text;
                    int typeShip = Convert.ToInt32(AddObj.comboBox1.SelectedIndex);
                    int quantityMasts = int.Parse(AddObj.numericUpDown1.Value.ToString());
                    int numberOfWeapons = int.Parse(AddObj.numericUpDown2.Value.ToString());
                    string[] pirateCircle = new string[1];
                    pirateCircle[0] = AddObj.richTextBox1.Text;
                    int shipCrew = int.Parse(AddObj.numericUpDown3.Value.ToString());
                    int[] numberOfCrewOnDeck = new int[2];
                    numberOfCrewOnDeck[0] = int.Parse(AddObj.numericUpDown4.Value.ToString());
                    numberOfCrewOnDeck[1] = int.Parse(AddObj.numericUpDown5.Value.ToString());
                    Image picture = null;
                    string info = "";

                    if (AddObj.textBox1.Text != "" && AddObj.textBox2.Text != "" &&
                       AddObj.comboBox1.Text != "" && AddObj.numericUpDown1.Value.ToString() != "" &&
                       AddObj.numericUpDown2.Value.ToString() != "" && AddObj.richTextBox1.Text != "" &&
                       AddObj.numericUpDown3.Value.ToString() != "" && AddObj.numericUpDown4.Value.ToString() != "" && 
                       AddObj.numericUpDown5.Value.ToString() != "")
                    {
                        cl_Ship ship = new cl_BattleShip(shipCrew, numberOfCrewOnDeck, nameShip, captainName,
                            (TypeShip)typeShip, quantityMasts, numberOfWeapons, pirateCircle, classShip, picture, info);
                        col.Add(ship);
                        int size = col.Count - 1;
                        string[] str = new string[] { col[size].NameShip, col[size].CaptainName,
                                Convert.ToString(col[size].QuantityMasts), Convert.ToString(col[size].NumberOfWeapons),};
                        ListViewItem list1 = new ListViewItem(classShip); //создается список для отображения информации
                        list1.SubItems.AddRange(str);//в созданный лист добавляется массив подэлементов
                        listView1.Items.Add(list1); //добавление в лист последней строкой
                    }
                    else if (AddObj.textBox1.Text == "" || AddObj.textBox2.Text == "" ||
                            AddObj.comboBox1.Text == "" || AddObj.richTextBox1.Text == "" )
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы заполнили не все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddObj.Close();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы заполнили не все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddObj.Close();
                    }
                }
                else if (AddObj.radioButton2.Checked == true)
                {
                    string classShip = AddObj.radioButton2.Text = "Пассажирский";
                    string nameShip = AddObj.textBox1.Text;
                    string captainName = AddObj.textBox2.Text;
                    int typeShip1 = Convert.ToInt32(AddObj.comboBox2.SelectedIndex);
                    int quantityMasts = int.Parse(AddObj.numericUpDown1.Value.ToString());
                    int numberOfWeapons = int.Parse(AddObj.numericUpDown2.Value.ToString());
                    string[] pirateCircle = new string[1];
                    pirateCircle[0] = AddObj.richTextBox1.Text;
                    int shipCrew = int.Parse(AddObj.numericUpDown3.Value.ToString());
                    int[] numberOfCrewOnDeck = new int[2];
                    numberOfCrewOnDeck[0] = int.Parse(AddObj.numericUpDown4.Value.ToString());
                    numberOfCrewOnDeck[1] = int.Parse(AddObj.numericUpDown5.Value.ToString());
                    Image picture = null;
                    string info = "";

                    if (AddObj.textBox1.Text != "" && AddObj.textBox2.Text != "" &&
                      AddObj.comboBox2.Text != "" && AddObj.numericUpDown1.Value.ToString() != "" &&
                      AddObj.numericUpDown2.Value.ToString() != "" && AddObj.richTextBox1.Text != "" && 
                      AddObj.numericUpDown3.Value.ToString() != "" && AddObj.numericUpDown4.Value.ToString() != "" && 
                      AddObj.numericUpDown5.Value.ToString() != "")
                    {
                        cl_Ship ship = new cl_PassengerShip(shipCrew, numberOfCrewOnDeck, nameShip, captainName,
                            (TypeShip1)typeShip1, quantityMasts, numberOfWeapons, pirateCircle, classShip, picture, info);
                        col.Add(ship);
                        int size = col.Count - 1;
                        string[] str = new string[] { col[size].NameShip, col[size].CaptainName,
                                Convert.ToString(col[size].QuantityMasts), Convert.ToString(col[size].NumberOfWeapons),};
                        ListViewItem list1 = new ListViewItem(classShip); //создается список для отображения информации
                        list1.SubItems.AddRange(str);//в созданный лист добавляется массив подэлементов
                        listView1.Items.Add(list1); //добавление в лист последней строкой
                    }
                    else if (AddObj.textBox1.Text == "" || AddObj.textBox2.Text == "" ||
                            AddObj.comboBox2.Text == "" || AddObj.richTextBox1.Text == "" )
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы заполнили не все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddObj.Close();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы заполнили не все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddObj.Close();
                    }
                }
            }
        }
        /*///////////////////////////////////////////////////////////*/



        /*Кнопки ЗАКРЫТЬ*/
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти из программы?", "Подтвердите действие", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) //если пользователь выбрал «да»
            {
                Application.Exit(); //происходит закрытие всех окон и выход из программы
            }
        }
        /*///////////////////////////////////////////////////////////*/


        /*Кнопки СПРАВКА*/
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"Программа записи кораблей:" +
            "\n\nКоманда \'Добавить\' - позволит добавлять корабль" +
            "\nКоманда \'Удалить\' - позволит удалить строку" +
            "\nКоманда \'Редактировать\' - позволит изменить имеющуюся строку" +
            "\nКоманда \'Просмотреть\' - выведет полные сведения корабле" +
            "\nКоманда \'Выход\' - позволит покинуть программу", "О программе");
        }
        /*///////////////////////////////////////////////////////////*/

        /*Кнопки УДАЛИТЬ*/
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Удалить корабль из списка?", "Подтвердите действие", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) //если пользователь выбрал "да", то
                {
                    List<cl_Ship> delList = new List<cl_Ship>(); //создание дополнительного листа кол-лекции
                    foreach (ListViewItem item in listView1.SelectedItems) //перебор всей коллекции первоначального листа listView1
                    {
                        listView1.Items.Remove(item); //удаляет строку (элемент) из первоначальной коллекции listView1
                        foreach (cl_Ship a in col) //перебор коллекции объектов 
                        {
                            if (a.ToString() == item.Text) //если номер объекта соответствует номеру в коллекции listView1
                                delList.Add(a); //элемент добавляется в новую коллекцию
                        }
                        foreach (cl_Ship a in delList) //затем элемент удаляется из новой коллекции
                            col.Remove(a);
                    }
                }
                else if (dialogResult == DialogResult.No) //если нет - то окно подтверждения закрывается, а основная форма - нет
                {
                    this.Show();
                }
            }
            else //если не выбрана строка для просмотра, выскочит окно предупреждения
            {
                MessageBox.Show("Не выбран объект для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }
        /*///////////////////////////////////////////////////////////*/

        /*Кнопки РЕДАКТИРОВАНИЯ*/
        private void button3_Click(object sender, EventArgs e)
        {
            Redact redact = new Redact();
            redact.radioButton1.Enabled = false; //кнопки не активны
            redact.radioButton2.Enabled = false;
            if (this.listView1.SelectedItems.Count > 0) //если выбран элемент коллекции листа
            {
                int index = listView1.FocusedItem.Index;
                if (col[index].GetType() == typeof(cl_BattleShip))
                {
                    cl_BattleShip BS = (cl_BattleShip)col[index];
                    redact.radioButton1.Checked = true;
                    redact.radioButton1.Text = BS.ClassShip = "Боевой";
                    redact.textBox1.Text = BS.NameShip;
                    redact.textBox2.Text = BS.CaptainName;   
                    redact.comboBox1.SelectedIndex = (int)BS.Type;
                    redact.numericUpDown1.Value = int.Parse(BS.QuantityMasts.ToString());
                    redact.numericUpDown2.Value = int.Parse(BS.NumberOfWeapons.ToString());
                    redact.richTextBox2.Text = BS.PirateCircle[0];
                    redact.numericUpDown3.Value = int.Parse(BS.ShipCrew.ToString());
                    redact.numericUpDown4.Value = int.Parse(BS[0].ToString());
                    redact.numericUpDown5.Value = int.Parse(BS[1].ToString());
                    redact.pictureBox2.Image = BS.Picture;
                    redact.richTextBox1.Text = BS.Info;
                }
                else
                {
                    cl_PassengerShip PS = (cl_PassengerShip)col[index];
                    redact.radioButton2.Checked = true;
                    redact.radioButton2.Text = PS.ClassShip = "Пассажирский";
                    redact.textBox1.Text = PS.NameShip;
                    redact.textBox2.Text = PS.CaptainName;
                    redact.comboBox2.SelectedIndex = (int)PS.Type1;
                    redact.numericUpDown1.Value = int.Parse(PS.QuantityMasts.ToString());
                    redact.numericUpDown2.Value = int.Parse(PS.NumberOfWeapons.ToString());
                    redact.richTextBox2.Text = PS.PirateCircle[0];
                    redact.numericUpDown3.Value = int.Parse(PS.ShipCrew.ToString());
                    redact.numericUpDown4.Value = int.Parse(PS[0].ToString());
                    redact.numericUpDown5.Value = int.Parse(PS[1].ToString());
                    redact.pictureBox2.Image = PS.Picture;
                    redact.richTextBox1.Text = PS.Info;
                }

                if (redact.ShowDialog() == DialogResult.OK)
                {
                    if (redact.radioButton1.Checked == true) //изменение боевого корабля
                    {
                        string classShip = redact.radioButton1.Text = "Боевой";
                        string nameShip = redact.textBox1.Text;
                        string captainName = redact.textBox2.Text;
                        int typeShip = Convert.ToInt32(redact.comboBox1.SelectedIndex);
                        int quantityMasts = int.Parse(redact.numericUpDown1.Value.ToString());
                        int numberOfWeapons = int.Parse(redact.numericUpDown2.Value.ToString());
                        string[] pirateCircle = new string[1];
                        pirateCircle[0] = redact.richTextBox2.Text;
                        int shipCrew = int.Parse(redact.numericUpDown3.Value.ToString());
                        int[] numberOfCrewOnDeck = new int[2];
                        numberOfCrewOnDeck[0] = int.Parse(redact.numericUpDown4.Value.ToString());
                        numberOfCrewOnDeck[1] = int.Parse(redact.numericUpDown5.Value.ToString());
                        Image picture = redact.pictureBox2.Image;
                        string info = redact.richTextBox1.Text;

                        if (redact.textBox1.Text != "" && redact.textBox2.Text != "" &&
                            redact.comboBox1.Text != "" && redact.numericUpDown1.Value.ToString() != "" &&
                            redact.numericUpDown2.Value.ToString() != "" && redact.richTextBox2.Text != "" &&
                            redact.numericUpDown3.Value.ToString() != "" && redact.numericUpDown4.Value.ToString() != "" && 
                            redact.numericUpDown5.Value.ToString() != "")
                        {
                            cl_BattleShip ship = (cl_BattleShip)col[index];
                            ship.ClassShip = classShip;
                            ship.NameShip = nameShip;
                            ship.CaptainName = captainName;
                            ship.PirateCircle = pirateCircle;
                            ship.Type = (TypeShip)typeShip;
                            ship.QuantityMasts = quantityMasts;
                            ship.NumberOfWeapons = numberOfWeapons;
                            ship.PirateCircle[0] = pirateCircle[0];
                            ship.ShipCrew = shipCrew;
                            ship[0] = numberOfCrewOnDeck[0];
                            ship[1] = numberOfCrewOnDeck[1];
                            ship.Picture = picture;
                            ship.Info = info;

                            listView1.Items.Clear(); //удаление всех элементов коллекции, чтобы отобразился корректный список                
                            foreach (var x in col) //перебор всей коллекции
                            {
                                ListViewItem newList = new ListViewItem(new string[]
                                {
                                    x.ClassShip, x.NameShip, x.CaptainName, x.QuantityMasts.ToString(),
                                    x.NumberOfWeapons.ToString()});
                                listView1.Items.Add(newList);
                            }
                        }
                        else //если не все поля заполнены – вывод окна об ошибке
                        {
                            MessageBox.Show("Данные введены некорректно. Повторите заполнение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (redact.radioButton2.Checked == true) //изменение пассажирского корабля
                    {
                        string classShip = redact.radioButton2.Text = "Пассажирский";
                        string nameShip = redact.textBox1.Text;
                        string captainName = redact.textBox2.Text;
                        int typeShip1 = Convert.ToInt32(redact.comboBox2.SelectedIndex);
                        int quantityMasts = int.Parse(redact.numericUpDown1.Value.ToString());
                        int numberOfWeapons = int.Parse(redact.numericUpDown2.Value.ToString());
                        string[] pirateCircle = new string[1];
                        pirateCircle[0] = redact.richTextBox2.Text;
                        int shipCrew = int.Parse(redact.numericUpDown3.Value.ToString());
                        int[] numberOfCrewOnDeck = new int[2];
                        numberOfCrewOnDeck[0] = int.Parse(redact.numericUpDown4.Value.ToString());
                        numberOfCrewOnDeck[1] = int.Parse(redact.numericUpDown5.Value.ToString());
                        Image picture = redact.pictureBox2.Image;
                        string info = redact.richTextBox1.Text;

                        if (redact.textBox1.Text != "" && redact.textBox2.Text != "" &&
                            redact.comboBox2.Text != "" && redact.numericUpDown1.Value.ToString() != "" &&
                            redact.numericUpDown2.Value.ToString() != "" && redact.richTextBox2.Text != "" &&
                            redact.numericUpDown3.Value.ToString() != "" && redact.numericUpDown4.Value.ToString() != "" && 
                            redact.numericUpDown5.Value.ToString() != "")
                        {
                            cl_PassengerShip ship = (cl_PassengerShip)col[index];
                            ship.ClassShip = classShip;
                            ship.NameShip = nameShip;
                            ship.CaptainName = captainName;
                            ship.PirateCircle = pirateCircle;
                            ship.Type1 = (TypeShip1)typeShip1;
                            ship.QuantityMasts = quantityMasts;
                            ship.NumberOfWeapons = numberOfWeapons;
                            ship.PirateCircle[0] = pirateCircle[0];
                            ship.ShipCrew = shipCrew;
                            ship[0] = numberOfCrewOnDeck[0];
                            ship[1] = numberOfCrewOnDeck[1];
                            ship.Picture = picture;
                            ship.Info = info;

                            listView1.Items.Clear(); //удаление всех элементов коллекции, чтобы отобразился корректный список                
                            foreach (var x in col) //перебор всей коллекции
                            {
                                    ListViewItem newList = new ListViewItem(new string[]
                                {
                                   x.ClassShip, x.NameShip, x.CaptainName, x.QuantityMasts.ToString(),
                                   x.NumberOfWeapons.ToString()});
                                listView1.Items.Add(newList);
                            }
                        }

                        else //если не все поля заполнены – вывод окна об ошибке
                        {
                            MessageBox.Show("Данные введены некорректно. Повторите заполнение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else //если не выбрана строка для изменения, выскочит окно сообщения
            {
                MessageBox.Show("Не выбрана строка для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        /*///////////////////////////////////////////////////////////*/

        /*Кнопки ПРОСМОТР*/
        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }
        
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            View watching = new View(); //создание объекта
            watching.radioButton1.Enabled = false; //кнопки не активны
            watching.radioButton2.Enabled = false;
            if (this.listView1.SelectedItems.Count > 0) //если выбран элемент коллекции листа
            {
                int index = listView1.FocusedItem.Index;
                if (col[index].GetType() == typeof(cl_BattleShip))
                {
                    cl_BattleShip BS = (cl_BattleShip)col[index];
                    watching.radioButton1.Text = BS.ClassShip = "Боевой";
                    watching.textBox1.Text = BS.NameShip;
                    watching.textBox2.Text = BS.CaptainName;
                    watching.comboBox1.SelectedIndex = (int)BS.Type;
                    watching.numericUpDown1.Value = int.Parse(BS.QuantityMasts.ToString());
                    watching.numericUpDown2.Value = int.Parse(BS.NumberOfWeapons.ToString());
                    watching.richTextBox2.Text = BS.PirateCircle[0];
                    watching.numericUpDown3.Value = int.Parse(BS.ShipCrew.ToString());
                    watching.numericUpDown4.Value = int.Parse(BS[0].ToString());
                    watching.numericUpDown5.Value = int.Parse(BS[1].ToString());
                    watching.pictureBox1.Image = BS.Picture;
                    watching.richTextBox1.Text = BS.Info;
                    watching.radioButton1.Checked = true;
                    watching.radioButton2.Checked = false;
                    watching.textBox1.ReadOnly = true;
                    watching.textBox2.ReadOnly = true;
                    watching.comboBox1.Enabled = false;
                    watching.numericUpDown1.Enabled = false;
                    watching.numericUpDown2.Enabled = false;
                    watching.richTextBox2.ReadOnly = true;
                    watching.numericUpDown3.Enabled = false;
                    watching.numericUpDown4.Enabled = false;
                    watching.numericUpDown5.Enabled = false;
                    watching.richTextBox1.ReadOnly = true;

                }
                else 
                {
                    cl_PassengerShip PS = (cl_PassengerShip)col[index];
                    watching.radioButton2.Text = PS.ClassShip = "Пассажирский";
                    watching.textBox1.Text = PS.NameShip;
                    watching.textBox2.Text = PS.CaptainName;
                    watching.comboBox2.SelectedIndex = (int)PS.Type1;
                    watching.numericUpDown1.Value = int.Parse(PS.QuantityMasts.ToString());
                    watching.numericUpDown2.Value = int.Parse(PS.NumberOfWeapons.ToString());
                    watching.richTextBox2.Text = PS.PirateCircle[0];
                    watching.numericUpDown3.Value = int.Parse(PS.ShipCrew.ToString());
                    watching.numericUpDown4.Value = int.Parse(PS[0].ToString());
                    watching.numericUpDown5.Value = int.Parse(PS[1].ToString());
                    watching.pictureBox1.Image = PS.Picture;
                    watching.richTextBox1.Text = PS.Info;
                    watching.radioButton2.Checked = true;
                    watching.radioButton1.Checked = false;
                    watching.textBox1.ReadOnly = true;
                    watching.textBox2.ReadOnly = true;
                    watching.comboBox2.Enabled = false;                  
                    watching.numericUpDown1.Enabled = false;
                    watching.numericUpDown2.Enabled = false;
                    watching.richTextBox2.ReadOnly = true;
                    watching.numericUpDown3.Enabled = false;
                    watching.numericUpDown4.Enabled = false;
                    watching.numericUpDown5.Enabled = false;
                    watching.richTextBox1.ReadOnly = true;
                }
                watching.Show();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для просмотра", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*///////////////////////////////////////////////////////////*/



        /*Кнопки ЗАГРУЗКИ и СОХРАНЕНИЯ*/
        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = "Files(*.bin)|*.bin|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {              
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, col);
                }
            }
        }
                   
        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Files(*.bin)|*.bin|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    listView1.Items.Clear();
                    BinaryFormatter bf = new BinaryFormatter();
                    col = (List<cl_Ship>)bf.Deserialize(fs);
                    foreach (cl_Ship size in col)
                    {
                        string[] str = new string[] { size.NameShip, size.CaptainName,
                            Convert.ToString(size.Type), Convert.ToString(size.NumberOfWeapons),};
                        ListViewItem list1 = new ListViewItem(size.ClassShip);
                        list1.SubItems.AddRange(str);   
                        listView1.Items.Add(list1);
                    }
                fs.Close();
                }
            }
        }

        private void быстроеСохранениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(@"shp.bin", FileMode.Create);
            bf.Serialize(fs, col);
            fs.Close();
        }

        private void быстраяЗагрузкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            listView1.Items.Clear();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(@"shp.bin", FileMode.Open);
            col = (List<cl_Ship>)bf.Deserialize(fs);
            foreach (cl_Ship size in col)
            {
                string[] str = new string[] { size.NameShip, size.CaptainName,
                        Convert.ToString(size.Type), Convert.ToString(size.NumberOfWeapons),};
                ListViewItem list1 = new ListViewItem(size.ClassShip);
                list1.SubItems.AddRange(str);
                listView1.Items.Add(list1);
            }
            fs.Close();
            }
            catch
            {
                MessageBox.Show("Нет файла для загрузки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            button7_Click(sender, e);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        /*///////////////////////////////////////////////////////////*/
    }
}
