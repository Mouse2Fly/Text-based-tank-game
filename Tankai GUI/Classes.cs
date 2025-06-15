using Controler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phrases;

namespace Classes
{
    interface Vehicle
    {
        decimal Health { get; set; } // 1-200
        decimal Location { get; set; } // 1-200
        decimal Speed { get; set; } // 1-100 percentage
        int[] Ammo { get; set; } // INDEX: 0(AP tank shell), 1(HE tank shell), 2(Machine gun), 3(Autocannon), 4(Rockets)
                                 // AMOUNT: -1: infinite!, 0: none, 1 or more
    }

    public abstract class CList
    {
        public abstract string[] selectableClasses { get; }
    }

    interface Counter
    {
        decimal counter { get; set; }
    }

    interface FuncOption
    {
        int choosenFunc { get; set; }
    }

    public abstract class Celebtarions
    {
        public abstract string Phrasse { get; }

        public virtual string Cheering()
        {
            return Phrasse;
        }
    }

    public abstract class WeaponNames
    {
        public abstract string[] weaponNames { get; }
    }
}
