using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace ConsoleApplication1
{
    class Program
    {
        static void Desplay()
        {
            foreach (InventoryCollection i in Ply.Inventory)
            {
                Console.WriteLine("{0} {1} {2}", i.Item.Name, i.Quanity, i.Item.GetType());
            }
            Console.WriteLine(Ply.HP);
            Console.WriteLine(Ply.Stamina);
            Console.WriteLine(Ply.Mana);

            if(Ply.CurrentLocation.EnemiesHere.Count > 0)
            {
                Console.WriteLine(Ply.CurrentLocation.EnemiesHere[0].Name);
                Console.WriteLine(Ply.CurrentLocation.EnemiesHere[0].HP);
            }
        }
        static void Main(string[] args)
        {
            Controller.PopulateWorld();
            Ply.AddReward(Controller.ItemParse(Controller.weapon_iron_sword));
            Ply.MoveTo(Controller.LocationParse(Controller.location_home));
            Ply.AddReward(Controller.ItemParse(Controller.potion_lesser_hp_pot));
            Ply.AddReward(Controller.ItemParse(Controller.potion_lesser_hp_pot));
            Ply.AddReward(Controller.ItemParse(Controller.potion_lesser_hp_pot));
            Ply.AddReward(Controller.ItemParse(Controller.potion_fire_pot));
            Ply.AddReward(Controller.ItemParse(Controller.potion_fire_pot));
            Ply.AddReward(Controller.ItemParse(Controller.potion_fire_pot));

            foreach(InventoryCollection i in Ply.Inventory)
            {
                Console.WriteLine("{0} {1} {2}",i.Item.Name, i.Quanity, i.Item.GetType());
            }

            Ply.MoveTo(Controller.LocationParse(Controller.location_forest));
            Console.WriteLine(Ply.CurrentLocation.EnemiesHere[0].Name);
            string ask;
            if (Ply.CurrentLocation.EnemiesHere.Count > 0)
            {
                while (true)
                {
                    ask = Console.ReadLine();
                    if(ask.ToLower() == "att")
                    {
                        Ply.PlayerAction(Ply.Inventory[0].Item as Weapon);
                    }
                    else if(ask.ToLower() == "fire")
                    {
                        Ply.PlayerAction(Ply.Inventory[2].Item as Potion, Engine.Action.drink);
                    }
                    else if (ask.ToLower() == "rest")
                    {
                        Ply.PlayerAction();
                    }
                    else if (ask.ToLower() == "hppot")
                    {
                        Ply.PlayerAction(Ply.Inventory[1].Item as Potion, Engine.Action.drink);
                    }
                    else if(ask.ToLower() == "heale")
                    {
                        Ply.PlayerAction(Ply.Spells[0], Engine.Action.onenemy);
                    }
                    if (Ply.CurrentLocation.EnemiesHere.Count == 0) break;

                    Desplay();
                }
            }
            

            Console.ReadLine();
        }
    }
}
