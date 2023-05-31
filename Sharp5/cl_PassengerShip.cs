using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp6
{
    public interface IPasShip
    {
        int[] PassengerByDeck();
    }

    [Serializable]
    public class cl_PassengerShip : cl_Ship, IPasShip
    {
        public cl_PassengerShip() { }
        public cl_PassengerShip(int shipCrew, int[] numberOfPassengers, string nameShip, string captainName, TypeShip1 type1, int quantityMasts, int numberOfWeapons, string[] pirateCircle, string classShip, Image picture, string info)
                     : base(nameShip, captainName, type1, quantityMasts, numberOfWeapons, pirateCircle, classShip, picture, info)
        {
            this.shipCrew = shipCrew;
            this.numberOfPassengers = numberOfPassengers;
        }
        private int shipCrew;
        static private string portOfresidence = "порт Артур";
        private int[] numberOfPassengers;

        public int ShipCrew
        {
            get { return shipCrew; }
            set { shipCrew = value; }
        }

        public new int this[int ind] /*индексатор*/
        {
            get
            {
                if ((ind >= 0) && (ind < numberOfPassengers.Length))
                    return numberOfPassengers[ind];
                else
                    return numberOfPassengers[0];
            }
            set
            {
                if ((ind >= 0) && (ind < numberOfPassengers.Length))
                    numberOfPassengers[ind] = value;
            }
        }

        public virtual void ShowPassengerShip()
        {
            //Console.WriteLine("Пассажирский корабль:");
            //Show();
            Console.WriteLine($"Количество команды: {ShipCrew}");
            Console.WriteLine($"Место прописки корабля: {portOfresidence}");
            Console.WriteLine($"Количество пассажиров на верхней палубе: {numberOfPassengers[0]}");
            Console.WriteLine($"Количество пассажиров на нижней палубе: {numberOfPassengers[1]}");
            Console.WriteLine(); 
}

        public int[] PassengerByDeck()
        {          
            int[] numberOfPassengers = new int[2];
            Random rand = new Random();
            for (int i = 0; i < numberOfPassengers.Length; i++)
                numberOfPassengers[i] = rand.Next(20, 45); 
            return numberOfPassengers;
        }

        public override string ToString()
        {
            Show();
            return base.ToString();
        }

        public override void Show()
        {
            Console.WriteLine("Пассажирский корабль:");
            base.Show();
            ShowPassengerShip();         
        }
    }
}
