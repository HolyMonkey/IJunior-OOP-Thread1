using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTrader
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class TraderNPC
    {
        public BehaviourSettings Settings;
        public NPCProfile Profile;
        public Bag Bag;

        public TraderNPC(BehaviourSettings settings, NPCProfile profile, Bag bag)
        {
            Settings = settings;
            Profile = profile;
            Bag = bag;
        }
    }

    class BehaviourSettings
    {
        public int AgressionLevel;
        public int LeavLevel;
    }

    class NPCProfile
    {
        public int Health;
        public int Money;
        public int Experience;
    }

    class Bag
    {
        public Item[] Items;
    }
    
    class Item
    {

    }
}
