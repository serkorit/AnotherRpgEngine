using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public static class Ply
    {
        public static Player Player = new Player(10, 15, 20, 0, 0);
        internal delegate void Print(string message, bool line = false);
        internal static Print Msg = Player.RaiseMessage;

        public static int HP
        {
            get { return Player.HP; }
            set { if (value > Player.MaxHP) { Player.HP = Player.MaxHP; } else { Player.HP = value; }; if (Player.HP <= 0) { IsDead(); } }
        }
        public static int MaxHP
        {
            get { return Player.MaxHP; }
            set { Player.MaxHP = value; }
        }
        public static int Mana
        {
            get { return Player.Mana; }
            set { if (value > Player.MaxMana) { Player.Mana = Player.MaxMana; } else { Player.Mana = value; }; }
        }
        public static int MaxMana
        {
            get { return Player.MaxMana; }
            set { Player.MaxMana = value; }
        }
        public static int Stamina
        {
            get { return Player.Stamina; }
            set { if (value > Player.MaxStamina) { Player.Stamina = Player.MaxStamina; } else { Player.Stamina = value; }; }
        }
        public static int MaxStamina
        {
            get { return Player.MaxStamina; }
            set { Player.MaxStamina = value; }
        }
        public static int Gold
        {
            get { return Player.Gold; }
            set { Player.Gold = value; }
        }
        public static int Exp
        {
            get { return Player.Exp; }
            set { Player.Exp = value; }
        }
        public static int Level { get { return Player.Level; } }
        public static int NextLevel { get { return Player.NextLevel; } }

        public static bool InBattle { get; set; }

        public static List<InventoryCollection> Inventory
        {
            get { return Player.Inventory; }
            set { Player.Inventory = value; }
        }
        public static List<QuestCollection> Quests
        {
            get { return Player.Quests; }
            set { Player.Quests = value; }
        }
        public static List<EffectsCollection> Effects
        {
            get { return Player.Effects; }
            set { Player.Effects = value; }
        }

        public static List<Spell> Spells
        {
            get { return Player.Spells; }
            set { Player.Spells = value; }
        }
        public static List<Weapon> Weapons
        {
            get { return Ply.Inventory.Where(x => x.Item is Weapon).Select(x => x.Item as Weapon).ToList(); }
        }
        public static List<Potion> Potions
        {
            get { return Ply.Inventory.Where(x => x.Item is Potion).Select(x => x.Item as Potion).ToList(); }
        }
        public static List<Location> NearestLocations
        {
            get { return Player.CurrentLocation.NearestLocations.ToList(); }
        }

        public static Weapon CurWeapon
        {
            get { return Player.CurWeapon; }
            set { Player.CurWeapon = value; }
        }
        public static Potion CurPotion
        {
            get { return Player.CurPotion; }
            set { Player.CurPotion = value; }
        }
        public static Spell CurSpell
        {
            get { return Player.CurSpell; }
            set { Player.CurSpell = value; }
        }
        public static Location CurrentLocation
        {
            get { return Player.CurrentLocation; }
            set { Player.CurrentLocation = value; Controller.NotifyNewLocation(); }
        }
        public static Enemy CurEnemy { get; set; }

        public static void MoveTo(Location newLocation)
        {
            if (!HasKeyForLocation(newLocation))
            {
                Msg("Тебе необходим ключ, чтобы пройти сюда.");
                return;
            }

            if (newLocation.IsSafe)
            {
                RestorePlayer();
            }

            CurrentLocation = newLocation;
            if (newLocation.JustQuest != null)
            {

                bool playerAlreadyHasQuest = HasThisQuest(newLocation.JustQuest);
                bool playerAlreadyCompleteQuest = ThisQuestCompleted(newLocation.JustQuest);

                if (playerAlreadyHasQuest)
                {
                    if (!playerAlreadyCompleteQuest)
                    {
                        bool playerHasItems = HasQuestItems(newLocation.JustQuest);

                        if (playerHasItems)
                        {
                            RemoveQuestItem(newLocation.JustQuest);
                            Exp = newLocation.JustQuest.RewardExp;
                            Gold = newLocation.JustQuest.RewardGold;

                            AddReward(newLocation.JustQuest.RewardItems[0]);
                            MarkQuestAsComplete(newLocation.JustQuest);
                        }
                    }
                }
                else
                {
                    Msg("Ты получил новое задание:");
                    Msg("'" + newLocation.JustQuest.Name + "'");
                    Msg(newLocation.JustQuest.Desc);
                    Quests.Add(new QuestCollection(newLocation.JustQuest));
                }
            }
            if (newLocation.EnemiesHere.Count > 0)
            {

                CurEnemy = new Enemy(newLocation.EnemiesHere[0]);
                Msg("Ты видишь " + CurEnemy.Name);
            }
            else
            {
                CurEnemy = null;
            }
        }


        public static bool HasKeyForLocation(Location location)
        {
            if (location.Key == null)
                return true;
            return Inventory.Exists(i => i.Item.ID == location.Key.ID);
        }
        public static bool HasThisQuest(Quest quest)
        {
            return Quests.Exists(q => q.Quest.ID == quest.ID);
        }
        public static bool ThisQuestCompleted(Quest quest)
        {
            foreach (QuestCollection qc in Quests)
            {
                if (qc.Quest.ID == quest.ID) return qc.IsComplete;
            }
            return false;
        }
        public static bool HasQuestItems(Quest quest)
        {
            foreach (QuestConditionsCollection qcc in quest.ItemsNeeded)
            {
                if (!Inventory.Exists(i => i.Item.ID == qcc.Items.ID && i.Quanity >= qcc.Quanity)) return false;
            }

            return true;
        }
        public static void MarkQuestAsComplete(Quest quest)
        {
            QuestCollection qc = Quests.SingleOrDefault(qcp => qcp.Quest.ID == quest.ID);

            if (qc != null)
            {
                Msg("Ты получил " + qc.Quest.RewardExp + " золота и " + qc.Quest.RewardExp + " очков опыта.");
                Msg("Ты завершил задание: " + qc.Quest.Name, true);
                Msg("");
                qc.IsComplete = true;
            }
        }

        public static void RemoveQuestItem(Quest quest)
        {
            foreach (QuestConditionsCollection qcc in quest.ItemsNeeded)
            {
                InventoryCollection item = Inventory.SingleOrDefault(i => i.Item.ID == qcc.Items.ID);

                if (item != null) item.Quanity--;
                if (item.Quanity <= 0) Inventory.Remove(item);
            }
        }
        public static void AddReward(Item addedItem)
        {
            if (addedItem is Misc || addedItem is Potion)
            {
                foreach (InventoryCollection i in Inventory)
                {
                    if (i.Item.ID == addedItem.ID)
                    {
                        Msg("Ты получаешь награду: " + i.Item.Name);
                        i.Quanity++;
                        return;
                    }
                }
            }
            Msg("Ты получаешь награду: " + addedItem.Name);
            if (addedItem is Weapon) Inventory.Add(new InventoryCollection(new Weapon(addedItem as Weapon), 1));
            else Inventory.Add(new InventoryCollection(addedItem, 1));
        }
        public static void AddReward(Item addedItem, int quanity)
        {
            if (addedItem is Misc || addedItem is Potion)
            {
                foreach (InventoryCollection i in Inventory)
                {
                    if (i.Item.ID == addedItem.ID)
                    {
                        Msg("Ты получаешь награду: " + i.Item.Name + " в количестве " + quanity);
                        i.Quanity += quanity;
                        return;
                    }
                }
            }
            Msg("Ты получаешь награду: " + addedItem.Name + " в количестве " + quanity);
            if (addedItem is Weapon) Inventory.Add(new InventoryCollection(new Weapon(addedItem as Weapon), 1));
            else Inventory.Add(new InventoryCollection(addedItem, quanity));
        }
        public static void AddSpell(Spell addedSpell)
        {
            foreach (Spell i in Spells)
            {
                if (i.ID == addedSpell.ID)
                {
                    return;
                }
            }
            Msg("Ты получаешь заклинание: " + addedSpell.Name);
            Spells.Add(addedSpell);
        }
        public static void RemoveItem(Item item)
        {
            foreach (InventoryCollection i in Inventory)
            {
                if (i.Item.UniqueID == item.UniqueID)
                {
                    if(i.Quanity > 1)
                    {
                        i.Quanity--;
                        Msg("Ты теряешь " + i.Item.Name + " в количестве 1.");
                        return;
                    }
                    Msg("Ты теряешь " + i.Item.Name);
                    Inventory.Remove(i);
                    return;
                }
            }
        }
        public static void RemoveQuanity(Item item)
        {
            foreach(InventoryCollection i in Inventory)
            {
                if(i.Item.UniqueID == item.UniqueID)
                {
                    if (item is Potion)
                    {
                        if ((item as Potion).AvaibleStacks <= 1)
                        {
                            i.Quanity--;
                            if (i.Quanity <= 0) Inventory.Remove(i);
                            else (item as Potion).RestoreStacks();
                            return;
                        }
                        else
                        {
                            (item as Potion).AvaibleStacks--;
                            return;
                        }
                    }
                }
            }
        }
        public static void AddEffect(EffectsCollection effect)
        {
            if (Effects.Count == 0)
            {
                Effects.Add(effect);
                return;
            }
            foreach (EffectsCollection ef in Effects)
            {
                if(ef.Effect.ID == effect.Effect.ID)
                {
                    ef.AddStack();
                    return;
                }
            }
            Effects.Add(effect);
        }
        public static void RemoveEffect(EffectsCollection effect)
        {
            Effects.Remove(effect);
        }

        public static void PlayerAction(Weapon curWep)
        {
            int playerDamage = RandomNumberGenerator.Generate(curWep.MinDamage, curWep.MaxDamage);
            if (CurEnemy != null)
            {
                if(Stamina < curWep.StaminaCost)
                {
                    Msg("Недостаточно стамины.");
                    return;
                }
                int mn = RandomNumberGenerator.Generate(1, 4);
                Mana += mn;
                Msg("Ты восстановил " + mn + " очков маны");

                Msg("Ты наносишь " + playerDamage + " единиц урона по " + CurEnemy.Name);
                Msg("");
                CurEnemy.HP -= playerDamage;
                Stamina -= curWep.StaminaCost;
                CurWeapon = curWep;
            }
            
        }
        public static void PlayerAction(Potion curPotion, Action action)
        {
            int hp = RandomNumberGenerator.Generate(0, 1);
            int st = RandomNumberGenerator.Generate(0, 2);
            int mn = RandomNumberGenerator.Generate(1, 3);
            HP += hp;
            Stamina += st;
            Mana += mn;
            Msg("Ты восстановил " + hp + " очков здоровья");
            Msg("Ты восстановил " + st + " очков стамины");
            Msg("Ты восстановил " + mn + " очков маны");
            Msg("");
            if (action == Action.thraw)
            {
                curPotion.Throw();
            }
            else if(action == Action.drink)
            {
                curPotion.Drink();
            }
            CurPotion = curPotion;
        }
        public static void PlayerAction(Spell curSpell, Action action)
        {
            if(Mana < curSpell.Manacost)
            {
                Msg("Недостаточно маны.");
                return;
            }
            CurSpell = curSpell;
            int hp = RandomNumberGenerator.Generate(0, 1);
            int st = RandomNumberGenerator.Generate(0, 2);
            HP += hp;
            Stamina += st;
            Msg("Ты восстановил " + hp + " очков здоровья");
            Msg("Ты восстановил " + st + " очков стамины");
            Msg("");
            
            if (action == Action.onplayer)
            {
                curSpell.CastOnPlayer();
            }
            else if(action == Action.onenemy)
            {
                curSpell.CastOnEnemy();
            }
        }
        public static void PlayerAction()
        {
            Msg("Ты решил передохнуть:");
            int hp = RandomNumberGenerator.Generate(0, 1);
            int st = RandomNumberGenerator.Generate(1, 3);
            int mn = RandomNumberGenerator.Generate(2, 5);
            HP += hp;
            Stamina += st;
            Mana += mn;
            Msg("Ты восстановил " + hp + " очков здоровья");
            Msg("Ты восстановил " + st + " очков стамины");
            Msg("Ты восстановил " + mn + " очков маны");
            Msg("");
        }

        public  static void CheckForVictory()
        {
            Exp += CurEnemy.Exp;
            Gold += CurEnemy.Gold;
            Msg("Ты получил " + CurEnemy.Exp + " очков опыта.");
            Msg("Ты получил " + CurEnemy.Gold + " золота.");

            List<InventoryCollection> loot = new List<InventoryCollection>();

            foreach(LootCollection loots in CurEnemy.LootTable)
            {
                if (RandomNumberGenerator.Generate(1, 100) <= loots.DropChance) loot.Add(new InventoryCollection(loots.Item, 1));
            }

            foreach(InventoryCollection i in loot)
            {
                AddReward(i.Item);
            }
            MoveTo(CurrentLocation);
            InBattle = false;
        }
        private static void IsDead()
        {
            if (CurEnemy != null)
            {
                Msg(CurEnemy.Name + " убил тебя.");
                InBattle = false;
                MoveTo(Controller.LocationParse(Controller.location_home));
            }
            else
            {
                Msg("Ты умер.");
                InBattle = false;
                MoveTo(Controller.LocationParse(Controller.location_home));
            }
        }


        private static void RestorePlayer()
        {
            HP = MaxHP;
            Stamina = MaxStamina;
            Mana = MaxMana;
            Msg("Ты был полностью исцелен.");
        }
    } 
}
