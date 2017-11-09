using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Ply
    {
        private static Player Player = new Player(10, 15, 20, 0, 0);

        public static int HP
        {
            get { return Player.HP; }
            set { Player.HP = value; }
        }
        public static int MaxHP
        {
            get { return Player.MaxHP; }
            set { Player.MaxHP = value; }
        }
        public static int Mana
        {
            get { return Player.Mana; }
            set { Player.Mana = value; }
        }
        public static int MaxMana
        {
            get { return Player.MaxMana; }
            set { Player.MaxMana = value; }
        }
        public static int Stamina
        {
            get { return Player.Stamina; }
            set { Player.Stamina = value; }
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
        public static List<SpellsCollection> Spells
        {
            get { return Player.Spells; }
            set { Player.Spells = value; }
        }
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
                return;
            }

            if (newLocation.IsSafe)
            {
                RestorePlayer();
            }

            CurrentLocation = newLocation;
            if (newLocation != null)
            {
                bool playerAlreadyHasQuest = HasThisQuest(newLocation.QuestsHere[0]);
                bool playerAlreadyCompleteQuest = ThisQuestCompleted(newLocation.QuestsHere[0]);

                if (playerAlreadyHasQuest)
                {
                    if (!playerAlreadyCompleteQuest)
                    {
                        bool playerHasItems = HasQuestItems(newLocation.QuestsHere[0]);

                        if (playerHasItems)
                        {
                            RemoveQuestItem(newLocation.QuestsHere[0]);
                            Exp = newLocation.QuestsHere[0].RewardExp;
                            Gold = newLocation.QuestsHere[0].RewardGold;

                            AddReward(newLocation.QuestsHere[0].RewardItems[0]);
                            MarkQuestAsComplete(newLocation.QuestsHere[0]);
                        }
                    }
                }
                else
                {
                    Quests.Add(new QuestCollection(newLocation.QuestsHere[0]));
                }

                if (newLocation.EnemiesHere[0] != null)
                {
                    CurEnemy = new Enemy(newLocation.EnemiesHere[0]);
                    foreach(LootCollection loot in CurEnemy.LootTable)
                    {
                        CurEnemy.LootTable.Add(loot);
                    }
                }
                else
                {
                    CurEnemy = null;
                }
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
                        i.Quanity++;
                        return;
                    }
                }
            }
            if (addedItem is Weapon) Inventory.Add(new InventoryCollection(new Weapon(addedItem as Weapon), 1));
            else Inventory.Add(new InventoryCollection(addedItem, 1));

        }
        public static void MarkQuestAsComplete(Quest quest)
        {
            QuestCollection qc = Quests.SingleOrDefault(qcp => qcp.Quest.ID == quest.ID);

            if(qc != null)
            {
                qc.IsComplete = true;
            }
        }
        public static void RemoveItem(Item item)
        {
            foreach (InventoryCollection i in Inventory)
            {
                if (i.Item.UniqueID == item.UniqueID)
                {
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
            

            if(CurEnemy != null)
            {
                CurEnemy.HP -= playerDamage;
                Stamina -= curWep.StaminaCost;
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
            if(action == Action.thraw)
            {
                curPotion.Throw();
            }
            else if(action == Action.drink)
            {
                curPotion.Drink();
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
        public static void PlayerAction(Spell curSpell, Action action)
        {
            if(action == Action.onplayer)
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
            HP += RandomNumberGenerator.Generate(0, 1);
            Stamina += RandomNumberGenerator.Generate(1, 3);
            Mana += RandomNumberGenerator.Generate(2, 5);

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
        }
        private static void CheckForVictory()
        {
            Exp += CurEnemy.Exp;
            Gold += CurEnemy.Gold;

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
        }
        private static void IsDead()
        {
            if (HP <= 0)
            {
                MoveTo(Controller.LocationParse(Controller.location_home));
            }
        }


        private static void RestorePlayer()
        {
            HP = MaxHP;
            Stamina = MaxStamina;
            Mana = MaxMana;
        }
    } 
}
