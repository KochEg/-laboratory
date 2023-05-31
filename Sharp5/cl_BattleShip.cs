using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp6
{
    public interface IBatShip
    {
        int[] CrewByDeck();
    }

    [Serializable]
    public class cl_BattleShip : cl_Ship, IBatShip
    {
        public cl_BattleShip() { }
        public cl_BattleShip(int shipCrew, int[] numberOfCrewOnDeck, string nameShip, string captainName, TypeShip type, int quantityMasts, int numberOfWeapons, string[] pirateCircle, string classShip, Image picture, string info)
                  : base(nameShip, captainName, type, quantityMasts, numberOfWeapons, pirateCircle, classShip, picture, info)
        {
            this.shipCrew = shipCrew;
            this.numberOfCrewOnDeck = numberOfCrewOnDeck;
        }

        private int shipCrew;
        static private string portOfresidence = "порт Ройаль";
        private int[] numberOfCrewOnDeck;

        public int ShipCrew
        {
            get { return shipCrew; }
            set { shipCrew = value; }
        }

        public int[] NumberOfCrewOnDeck
        {
            get { return numberOfCrewOnDeck; }
            set { numberOfCrewOnDeck = value; }
        }
        public new int this[int ind] /*индексатор*/
        {
            get
            {
                if ((ind >= 0) && (ind < numberOfCrewOnDeck.Length))
                    return numberOfCrewOnDeck[ind];
                else
                    return numberOfCrewOnDeck[0];
            }
            set
            {
                if ((ind >= 0) && (ind < numberOfCrewOnDeck.Length))
                    numberOfCrewOnDeck[ind] = value;
            }
        }

        public virtual void ShowBattleShip()
        {
           // Console.WriteLine("Боевой корабль:");
            //Show();
            Console.WriteLine($"Количество команды: {shipCrew}");
            Console.WriteLine($"Место прописки корабля: {portOfresidence}");
            Console.WriteLine($"Количество команды на верхней палубе: {numberOfCrewOnDeck[0]}");
            Console.WriteLine($"Количество команды на нижней палубе: {numberOfCrewOnDeck[1]}");
            Console.WriteLine();
        }

        public int[] CrewByDeck()
        {
            int[] numberOfCrewOnDeck = new int[2];
            Random rand = new Random();
            for (int i = 0; i < numberOfCrewOnDeck.Length; i++)
                numberOfCrewOnDeck[i] = rand.Next(15, 20);           
            return numberOfCrewOnDeck;
        }

        public override string ToString()
        {
            Show();
            return base.ToString();
        }

        public override void Show()
        {
            Console.WriteLine("Боевой корабль:");
            base.Show();
            ShowBattleShip();
        }
    }
}
    