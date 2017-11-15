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
        public class Notify : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropetryChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }
        public static Notify Notifier;
        public static Player Player = new Player(10, 15, 20, 0, 0);
        internal delegate void Print(string message, bool line = false);
        internal static Print Msg = Player.RaiseMessage;

        public static int HP
        {
            get { return Player.HP; }
            set { if (value > Player.MaxHP) { Player.HP = Player.MaxHP; } else { Player.HP = value; }; }
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
        public static List<SpellsCollection> SpellList
        {
            get { return Player.Spells; }
            set { Player.Spells = value; }
        }
        public static List<Spell> Spells
        {
            get { return Ply.SpellList.Where(x => x.Spell is Spell).Select(x => x.Spell as Spell).ToList(); }
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
        public static Potion CurPotion { get; set; }
        public static Spell CurSpell { get; set; }
        public static Location CurrentLocation
        {
            get { return Player.CurrentLocation; }
            set { Player.CurrentLocation = value; }
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
            }
            else
            {
                if (newLocation.JustQuest != null)
                {
                    Msg("Ты получил новое задание:");
                    Msg("'" + newLocation.JustQuest.Name + "'");
                    Msg(newLocation.JustQuest.Desc);
                    Quests.Add(new QuestCollection(newLocation.JustQuest));
                }

            }
            if (newLocation.EnemiesHere.Count() > 0)
            {

                CurEnemy = new Enemy(newLocation.EnemiesHere[0]);
                Msg("Ты видишь " + CurEnemy.Name);
                /*
                foreach (LootCollection loot in CurEnemy.LootTable)
                {
                    CurEnemy.LootTable.Add(loot);
                }
                */
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
        public static void AddSpell(Spell addedSpell)
        {
            foreach (SpellsCollection i in SpellList)
            {
                if (i.Spell.ID == addedSpell.ID)
                {
                    return;
                }
            }
            Msg("Ты получаешь заклинание: " + addedSpell.Name);
            SpellList.Add(new SpellsCollection(new Spell(addedSpell)));
        }
        public static void MarkQuestAsComplete(Quest quest)
        {
            QuestCollection qc = Quests.SingleOrDefault(qcp => qcp.Quest.ID == quest.ID);

            if(qc != null)
            {
                Msg("Ты получил " + qc.Quest.RewardExp +" золота и " + qc.Quest.RewardExp + " очков опыта.");
                Msg("Ты завершил задание: " + qc.Quest.Name);
                qc.IsComplete = true;
            }
        }
        public static void RemoveItem(Item item)
        {
            foreach (InventoryCollection i in Inventory)
            {
                if (i.Item.UniqueID == item.UniqueID)
                {
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
                        if ((item as Potion).AvaibleStacks <= 0)
                        {
                            i.Quanity--;
                            if (i.Quanity <= 0) Inventory.Remove(i);
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
                CurEnemy.HP -= playerDamage;
                Stamina -= curWep.StaminaCost;
                CurWeapon = curWep;
                if (CurEnemy.HP <= 0)
                {
                    CheckForVictory();
                }
                else
                {
                    EnemyTurn();
                }
                IsDead();
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
            if (action == Action.thraw)
            {
                curPotion.Throw();
            }
            else if(action == Action.drink)
            {
                curPotion.Drink();
            }
            CurPotion = curPotion;
            if(CurEnemy != null)
            {
                if (CurEnemy.HP <= 0)
                {
                    CheckForVictory();
                }
                else
                {
                    EnemyTurn();
                }
            }
            IsDead(); 
        }
        public static void PlayerAction(Spell curSpell, Action action)
        {
            if(Mana < curSpell.Manacost)
            {
                Msg("Недостаточно маны.");
                return;
            }
            if (curSpell is Fireball) curSpell = curSpell as Fireball;
            if(curSpell is LesserHealing) curSpell = curSpell as LesserHealing;
            CurSpell = curSpell;
            int hp = RandomNumberGenerator.Generate(0, 1);
            int st = RandomNumberGenerator.Generate(0, 2);
            HP += hp;
            Stamina += st;
            Msg("Ты восстановил " + hp + " очков здоровья");
            Msg("Ты восстановил " + st + " очков стамины");

            if (action == Action.onplayer)
            {
                curSpell.CastOnPlayer();
            }
            else if(action == Action.onenemy)
            {
                curSpell.CastOnEnemy();
            }

            if(CurEnemy != null)
            {
                if (CurEnemy.HP <= 0)
                {
                    CheckForVictory();
                }
                else
                {
                    EnemyTurn();
                }
            }
            IsDead();
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

            if (CurEnemy != null)
            {
                if (CurEnemy.HP <= 0)
                {
                    CheckForVictory();
                }
                else
                {
                    EnemyTurn();
                }
            }
            IsDead();
        }


        private static void EnemyTurn()
        {
            int enemyDamage = RandomNumberGenerator.Generate(CurEnemy.MinDamage, CurEnemy.MaxDamage);
            HP -= enemyDamage;
            Msg(CurEnemy.Name + " наносит тебе " + enemyDamage +" единиц урона.");
        }
        private static void CheckForVictory()
        {
            Exp += CurEnemy.Exp;
            Gold += CurEnemy.Gold;
            Msg("Ты получил " + Exp);
            Msg("Ты получил " + Gold);

            List<InventoryCollection> loot = new List<InventoryCollection>();

            foreach(LootCollection loots in CurEnemy.LootTable)
            {
                if (RandomNumberGenerator.Generate(1, 100) <= loots.DropChance) loot.Add(new InventoryCollection(loots.Item, 1));
            }

            foreach(InventoryCollection i in loot)
            {
                Msg("Ты находишь " + i.Item.Name);
                AddReward(i.Item);
            }
            MoveTo(CurrentLocation);
        }
        private static void IsDead()
        {
            if (HP <= 0 && CurEnemy != null)
            {
                Msg(CurEnemy.Name + " убил тебя.");
                MoveTo(Controller.LocationParse(Controller.location_home));
            }
            else if (HP <= 0)
            {
                Msg("Ты умер.");
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
