using Phrases;
using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Controler
{

    // AP: 75 damage
    // HE: 54 damage, 4 block explosion
    // MG: 4 damage per shoot, 10 round burst
    // Auto: 10 damage per shoot, 6 round burst
    // Rocket: 100, guided

    // base movement: 25

    internal class Player
    {
       
        public class MBT : Vehicle
        {

            public MBT (decimal Coordnates) // Main battle tank
            {
                Health = 200;
                Speed = 60;
                Location = Coordnates;
                Ammo = [-1, 10, 200, 0, 0];
            }

            public decimal Health { get; set; }
            public decimal Speed { get; set; }
            public decimal Location { get; set; }
            public int[] Ammo { get; set; }
        }

        public class IFV : Vehicle
        {

            public IFV(decimal Coordnates) //Infantry fighting vehicle P.S NOT APC
            {
                Health = 145;
                Speed = 100;
                Location = Coordnates;
                Ammo = [0, 0, 200, -1, 4];
            }

            public decimal Health { get; set; }
            public decimal Speed { get; set; }
            public decimal Location { get; set; }
            public int[] Ammo { get; set; }
        }

        public class Truck : Vehicle
        {

            public Truck(decimal Coordnates) // Hanz where's the mg3?/
            {
                Health = 50;
                Speed = 160;
                Location = Coordnates;
                Ammo = [0, 0, -1, 0, 8];
            }

            public decimal Health { get; set; }
            public decimal Speed { get; set; }
            public decimal Location { get; set; }
            public int[] Ammo { get; set; }
        }

        public class RoundCounter : Counter
        {
            public RoundCounter()
            {
                counter = 0;
            }

            public decimal counter { get; set; }
        }

        public class ActiceFunc : FuncOption 
        { 
            public ActiceFunc()
            {
                choosenFunc = 0;
            }

            public int choosenFunc { get; set; }
        }

        public class ClassList : CList
        {
            public override string[] selectableClasses => ["", "MBT", "IFV", "Truck"];
        }

        public class WeaponList : WeaponNames
        {
            public override string[] weaponNames => ["AP", "HE", "MG", "Auto", "Rocket"];
        }
    }
}


