using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class Player : Entity
    {

        public Location CurrentLocation;
        public event EventHandler<MessageEventArgs> OnMessage;

        public List<InventoryCollection> Inventory;
        public List<QuestCollection> Quests;
        public List<SpellsCollection> Spells;
        public Weapon CurWeapon;
        public List<Weapon> Weapons;
        public List<Potion> Potions;

        public int Level { get { return Exp / 50 + 1; } }
        public int NextLevel { get { return Level * 50; } }


        public Player(int hp, int stamina, int mana, int gold, int exp)
            : base(hp, stamina, mana, gold, exp)
        {
            CurrentLocation = null;
            Inventory = new List<InventoryCollection>();
            Quests = new List<QuestCollection>();
            Spells = new List<SpellsCollection>();
        }

        internal void RaiseMessage(string message, bool addExtraNewline = false)
        {
            if(OnMessage != null)
            {
                OnMessage(this, new MessageEventArgs(message, addExtraNewline));
            }
        }


    }
}
