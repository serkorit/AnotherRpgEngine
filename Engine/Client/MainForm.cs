﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Controller.PopulateWorld();

            Exit_Button.BackColor = Color.NavajoWhite;
            Minimize_Button.BackColor = Color.NavajoWhite;
            tabControl1.MouseEnter += (s, e) => tabControl1.Focus();

            lbHP.ForeColor = Color.Red;
            lbGold.ForeColor = Color.DarkGoldenrod;
            lbExp.ForeColor = Color.Green;
            lbLvl.ForeColor = Color.ForestGreen;
            lbStamina.ForeColor = Color.GreenYellow;
            lbMana.ForeColor = Color.Blue;

            lbHP.BackColor = Color.Transparent;
            lbGold.BackColor = Color.Transparent;
            lbExp.BackColor = Color.Transparent;
            lbLvl.BackColor = Color.Transparent;
            lbStamina.BackColor = Color.Transparent;
            lbMana.BackColor = Color.Transparent;

            label1.ForeColor = Color.Red; label1.BackColor = Color.Transparent;
            label2.ForeColor = Color.DarkGoldenrod; label2.BackColor = Color.Transparent;
            label3.ForeColor = Color.Green; label3.BackColor = Color.Transparent;
            label4.ForeColor = Color.ForestGreen; label4.BackColor = Color.Transparent;
            label7.ForeColor = Color.GreenYellow; label7.BackColor = Color.Transparent;
            label9.ForeColor = Color.Blue; label9.BackColor = Color.Transparent;

            Color custom = Color.FromArgb(155, 200, 200, 200);
            panel2.BackColor = custom;
            panel3.BackColor = custom;

            Ply.Player.OnMessage += DisplayMessage;
            Ply.AddReward(Controller.ItemParse(Controller.weapon_iron_sword));
            Ply.MoveTo(Controller.LocationParse(Controller.location_home));
            Ply.AddReward(Controller.ItemParse(Controller.potion_lesser_hp_pot), 3);
            Ply.AddReward(Controller.ItemParse(Controller.potion_medium_hp_pot), 1);
            Ply.AddReward(Controller.ItemParse(Controller.potion_fire_pot),3);
            Ply.AddReward(Controller.ItemParse(Controller.potion_lesser_mp_pot), 5);
            Ply.AddReward(Controller.ItemParse(Controller.potion_lesser_st_pot), 5);
            Ply.AddSpell(Controller.SpellParse(Controller.spell_fireball));
            Ply.AddSpell(Controller.SpellParse(Controller.spell_lesser_healing));
            Ply.AddSpell(Controller.SpellParse(Controller.spell_mana_to_stamina));
            Ply.AddSpell(Controller.SpellParse(Controller.spell_poison));
            Ply.AddSpell(Controller.SpellParse(Controller.spell_strength));

            UpdatePanel();
        }

        

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Exit_Button_MouseEnter(object sender, EventArgs e)
        {
            Exit_Button.BackColor = Color.AliceBlue;
        }
        private void Exit_Button_MouseLeave(object sender, EventArgs e)
        {
            Exit_Button.BackColor = Color.NavajoWhite;
        }

        private void UpdatePanel()
        {
            lbHP.Text = Ply.HP + "/" + Ply.MaxHP;
            lbMana.Text = Ply.Mana + "/" + Ply.MaxMana;
            lbStamina.Text = Ply.Stamina + "/" + Ply.MaxStamina;
            lbGold.Text = Ply.Gold.ToString();
            lbExp.Text = Ply.Exp + "/" + Ply.NextLevel;
            lbLvl.Text = Ply.Level.ToString();

            UpdateWeaponListUI();
            UpdateInventory();
            UpdatePotionListUI();
            UpdateQuestList();
            UpdateSpellList();
            UpdateSpellListUI();
            UpdateNewLocationsUI();
            UpdateEffectsList();
            UpdateShopUI();

            if (Ply.InBattle || Ply.CurEnemy == null) btnAttack.Enabled = false;
            else btnAttack.Enabled = true;

            rtLocation.Clear();
            rtLocation.Text += Ply.CurrentLocation.Name;
            rtLocation.Text += Environment.NewLine + Ply.CurrentLocation.Desc + Environment.NewLine;
            rtLocation.Text += "Соседнии локации: ";
            foreach (Location l in Ply.NearestLocations)
            {
                rtLocation.Text += l.Name + " , ";
            }

            
        }
        private void UpdateShopUI()
        {
            if (!Ply.CurrentLocation.IsShop) { tabControl1.TabPages[4].Enabled = false; }
            else tabControl1.TabPages[4].Enabled = true;

            listSell.DataSource = Ply.Items;
            listSell.DisplayMember = "SellText";
            listSell.ValueMember = "ID";


            listBuy.DataSource = Ply.CurrentLocation.ShopList;
            listBuy.DisplayMember = "BuyText";
            listBuy.ValueMember = "ID";

                
        }
        private void UpdateNewLocationsUI()
        {
            cbNewLoc.DataSource = Ply.NearestLocations;
            cbNewLoc.DisplayMember = "Name";
            cbNewLoc.ValueMember = "ID";
            cbNewLoc.SelectedItem = Ply.NearestLocations;
        
        }
        private void UpdateInventory()
        {
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.ColumnHeadersVisible = true;
            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Название";
            dgvInventory.Columns[0].Width = 350;
            dgvInventory.Columns[1].Name = "Количество";
            dgvInventory.Rows.Clear();
            foreach(InventoryCollection i in Ply.Inventory)
            {
                if (i.Quanity > 0)
                    if (i.Item is Weapon)
                        dgvInventory.Rows.Add(new[] { i.Item.Name , i.Quanity.ToString() });
                    else if (i.Item is Potion) dgvInventory.Rows.Add(new[] { i.Item.Name + "(Доступно: " + (i.Item as Potion).AvaibleStacks + ")", i.Quanity.ToString() });
                    else dgvInventory.Rows.Add(new[] { i.Item.Name, i.Quanity.ToString() });
            }
        }
        private void UpdateQuestList()
        { 
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.ColumnHeadersVisible = true;

            dgvQuests.ColumnCount = 3;
            dgvQuests.Columns[0].Name = "Название";
            dgvQuests.Columns[0].Width = 120;
            dgvQuests.Columns[1].Name = "Завершен?";
            dgvQuests.Columns[2].Name = "Необходимо";
            dgvQuests.Columns[2].Width = 300;

            dgvQuests.Rows.Clear();

            foreach (QuestCollection playerQuest in Ply.Quests)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Quest.Name, playerQuest.IsComplete.ToString(), playerQuest.Quest.ItemsNeeded[0].Items.Name + " " + playerQuest.Quest.ItemsNeeded[0].Quanity });
            }
            
        }
        private void UpdateSpellList()
        {
            dgvSpells.RowHeadersVisible = false;
            dgvSpells.ColumnHeadersVisible = true;

            dgvSpells.ColumnCount = 3;
            dgvSpells.Columns[0].Name = "Название";
            dgvSpells.Columns[0].Width = 140;
            dgvSpells.Columns[1].Width = 300;
            dgvSpells.Columns[1].Name = "Описание";
            dgvSpells.Columns[2].Name = "Манакост";

            dgvSpells.Rows.Clear();

            foreach (Spell spell in Ply.Spells)
            {
                dgvSpells.Rows.Add(new[] { spell.Name, spell.Desc," " + spell.Manacost });
            }
        }
        private void UpdateEffectsList()
        {
            dgvEffects.RowHeadersVisible = false;
            dgvEffects.ColumnHeadersVisible = true;

            dgvEffects.ColumnCount = 3;
            dgvEffects.Columns[0].Name = "Название";
            dgvEffects.Columns[0].Width = 140;
            dgvEffects.Columns[1].Width = 250;
            dgvEffects.Columns[1].Name = "Описание";
            dgvEffects.Columns[2].Name = "Длительность";
            dgvEffects.Columns[2].Width = 90;

            dgvEffects.Rows.Clear();

            foreach (EffectsCollection effect in Ply.Effects)
            {
                dgvEffects.Rows.Add(new[] { effect.Effect.Name, effect.Effect.Desc, effect.Duration.ToString() });
            }
        }
        private void UpdateWeaponListUI()
        {
            if (!Ply.InBattle) btnUseWeapon.Enabled = false;
            else btnUseWeapon.Enabled = true;
            cbWeapons.DataSource = Ply.Weapons;
            cbWeapons.DisplayMember = "Name";
            cbWeapons.ValueMember = "ID";
            if (Ply.CurWeapon == null) cbWeapons.SelectedIndex = 0;
            else cbWeapons.SelectedItem = Ply.CurWeapon;
        }
        private void UpdatePotionListUI()
        {
            if(Ply.Potions.Count() == 0)
            {
                btnDrink.Enabled = false;
                btnThrow.Enabled = false;
                cbPotions.Enabled = false;
            }
            else
            {
                btnDrink.Enabled = true;
                btnThrow.Enabled = true;
                cbPotions.Enabled = true;
                cbPotions.DisplayMember = "Name";
                cbPotions.ValueMember = "ID";
                cbPotions.DataSource = Ply.Potions;
                if (Ply.CurPotion == null) cbPotions.SelectedIndex = 0;
                else cbPotions.SelectedItem = Ply.CurPotion;
            }
            
        }
        private void UpdateSpellListUI()
        {
            List<Spell> PlySpells = Ply.Spells;
            if (!Ply.InBattle)
            {
                btnCastEnemy.Enabled = false;
            }
            else
            {
                btnCastEnemy.Enabled = true;
            }

            cbSpells.DisplayMember = "Name";
            cbSpells.ValueMember = "ID";
            cbSpells.DataSource = PlySpells;
            if (Ply.CurSpell == null) cbSpells.SelectedIndex = 0;
            else cbSpells.SelectedItem = Ply.CurSpell;
       
        }

        private void btnHideInv_Click(object sender, EventArgs e)
        {
            if (dgvInventory.Visible)
            {
                dgvInventory.Visible = false;
                btnHideInv.Text = "Show Inventory";
            }
            else
            {
                dgvInventory.Visible = true;
                btnHideInv.Text = "Hide Inventory";
            }

        }
        private void btnHideQuest_Click(object sender, EventArgs e)
        {
            if (dgvQuests.Visible)
            {
                dgvQuests.Visible = false;
                btnHideQuest.Text = "Show Quests";
            }
            else
            {
                dgvQuests.Visible = true;
                btnHideQuest.Text = "Hide Quests";
            }

        }
        private void btnReloadMsg_Click(object sender, EventArgs e)
        {
            rtMsg.Text = "";
        }
        private void btnDisplayMap_Click(object sender, EventArgs e)
        {
            if (panelMainMap.Visible)
            {
                panelMainMap.Visible = false;
                btnDisplayMap.Text = "Show map";
            }
            else
            {
                panelMainMap.Visible = true;
                btnDisplayMap.Text = "Hide map";
            }
        }


        private void DisplayMessage(object sender, MessageEventArgs message)
        {
            rtMsg.Text += message.Message + Environment.NewLine;

            if (message.AddExtraNewLine) rtMsg.Text += Environment.NewLine;
            rtMsg.SelectionStart = rtMsg.Text.Length;
            rtMsg.ScrollToCaret();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            Controller.DoBattle(cbWeapons.SelectedItem as Weapon,null,null,0);
            UpdatePanel();
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            Controller.DoBattle(null,cbPotions.SelectedItem as Potion,null, Engine.Action.drink);
            UpdatePanel();
        }

        private void btnThrow_Click(object sender, EventArgs e)
        {
            Controller.DoBattle(null,cbPotions.SelectedItem as Potion,null, Engine.Action.thraw);
            UpdatePanel();
        }

        private void btnCastSelf_Click(object sender, EventArgs e)
        {
            Controller.DoBattle(null,null,cbSpells.SelectedItem as Spell, Engine.Action.onplayer);
            UpdatePanel();
        }

        private void btnCastEnemy_Click(object sender, EventArgs e)
        {

            Controller.DoBattle(null,null,cbSpells.SelectedItem as Spell, Engine.Action.onenemy);
            UpdatePanel();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            Controller.DoBattle(null,null,null,0);
            UpdatePanel();
        }

        private void cbNewLoc_DoubleClick(object sender, EventArgs e)
        {   
            if(!Ply.InBattle)
                Ply.MoveTo(cbNewLoc.SelectedItem as Location);
            UpdatePanel();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {  
            if (!Ply.InBattle) Controller.StartBattle();
            UpdatePanel();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if(listSell.SelectedItem as Item != null)
            Ply.SellItem(listSell.SelectedItem as Item);
            UpdatePanel();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {

            if(listBuy.SelectedItem as Item != null)
            Ply.BuyItem(listBuy.SelectedItem as Item);
            UpdatePanel();
        }
    }
}