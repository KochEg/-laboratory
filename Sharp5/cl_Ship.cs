using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp6
{
    public enum TypeShip { Галеон, Каравелла, Корвет, Фрегат, Шхуна, Линейный }
    public enum TypeShip1 { Круизный, Рейсовый }

        [Serializable]
    abstract public class cl_Ship
    {
        public cl_Ship() { }
        public cl_Ship(string nameShip, string captainName, TypeShip type, int quantityMasts, int numberOfWeapons, string[] pirateCircle,string classShip, Image picture, string info)
        {
            this.nameShip = nameShip;
            this.captainName = captainName;
            this.type = type;
            this.quantityMasts = quantityMasts;
            this.numberOfWeapons = numberOfWeapons;
            this.pirateCircle = pirateCircle;
            this.classShip = classShip;
        }

        public cl_Ship(string nameShip, string captainName, TypeShip1 type1, int quantityMasts, int numberOfWeapons, string[] pirateCircle, string classShip, Image picture, string info)
        {
            this.nameShip = nameShip;
            this.captainName = captainName;
            this.type1 = type1;
            this.quantityMasts = quantityMasts;
            this.numberOfWeapons = numberOfWeapons;
            this.pirateCircle = pirateCircle;
            this.classShip = classShip;
        }


        private string nameShip;
        private string captainName;
        private TypeShip type;
        private TypeShip1 type1;
        private int quantityMasts;
        private static string pirateBay = "Пиратская бухта Тортуга"; /*статическое поле для задания*/
        private int numberOfWeapons;
        private string[] pirateCircle; /*одно из полей массив*/
        private string classShip;
        private Image picture;
        private string info;

        public string NameShip
        {
            get { return nameShip; }
            set { nameShip = value; }
        }

        public string CaptainName
        {
            get { return captainName; }
            set { captainName = value; }
        }
        public TypeShip1 Type1
        {
            get { return type1; }
            set { type1 = value; }
        }

        public TypeShip Type
        {
            get { return type; }
            set { type = value; }
        }

        public int QuantityMasts
        {
            get { return quantityMasts; }
            set { quantityMasts = value; }
        }

        public int NumberOfWeapons
        {
            get { return numberOfWeapons; }
            set { numberOfWeapons = value; }
        }

        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        public Image Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public string ClassShip 
        { 
            get { return classShip; } 
            set { classShip = value; } 
        }
        public string[] PirateCircle
        {
            get { return pirateCircle; }
            set { pirateCircle = value; }
        }

        public string this[int ind] /*индексатор*/
        {
            get
            {
                if ((ind >= 0) && (ind < pirateCircle.Length))
                    return pirateCircle[ind];
                else
                    return pirateCircle[0];
            }
            set
            {
                if ((ind >= 0) && (ind < pirateCircle.Length))
                    pirateCircle[ind] = value;
            }
        }

        public static string[] AssignmentPiratCircle(int x) /*Присвоение массива дислокации объекту*/
        {
            int x1 = x;
            string[] piratCircle0 = { "Бермудские острова", "Нассау", "Ла-Корунья" };
            string[] piratCircle1 = { "Сингапур", "острова Мадейра", "мыс Доброй Надежды" };
            string[] piratCircle2 = { "Мозамбикский пролив", "Мадагаскар", "Коморские острова" };
            string[] piratCircle = null;
            if (x1 == 0) piratCircle = piratCircle0;
            else if (x1 == 1) piratCircle = piratCircle1;
            else if (x1 == 2) piratCircle = piratCircle2;
            return piratCircle;
        }
        public void ChangeMas() /*метод для изменения массива в объекте*/
        {
            for (int i = 0; i < pirateCircle.Length; i++)
                pirateCircle[i] = Console.ReadLine();
        }

        public virtual void Show() /*Виртуальный метод для задания(вывод все объектов на экран)*/
        {          
            Console.WriteLine($"Имя корабля: {nameShip}");
            Console.WriteLine($"Имя капитана: {captainName}");
            Console.WriteLine($"Тип корабля: {type}");
            Console.WriteLine($"Место стоянки: {pirateBay}");
            Console.WriteLine($"Количество мачт: {quantityMasts}");
            Console.WriteLine($"Количество пушек: {numberOfWeapons}");
            Console.Write("Места дислокации:");
            for (int j = 0; j < pirateCircle.Length; j++)
                Console.Write(pirateCircle[j] + ", ");           
            Console.WriteLine();         
        }

    }

}

