using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using DBZMOD;

namespace DBZMOD
{
    public abstract class KiProjectile : ModProjectile
    {
        public int ChargeLevel;
        public int ChargeTimer;
        public int KiDrainTimer;
        public bool KiWeapon = true;

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player owner = null;
            if (projectile.owner != -1)
                owner = Main.player[projectile.owner];
            else if (projectile.owner == 255)
                owner = Main.LocalPlayer;
        }
        public override void OnHitNPC(NPC npc, int damage, float knockback, bool crit)
        {
            if(KiWeapon)
            {
                if(npc.life < 0)
                {
                    if(Main.rand.Next(3) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KiOrb"), 1);
                    }
                }
            }
        }
    }

    public abstract class KiItem : ModItem
    {
        private Player player;
        // make-safe
        public override void SetDefaults()
        {
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }
        public static float KiDrain;
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            knockback = knockback + MyPlayer.ModPlayer(player).KiKbAddition;
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {   
            damage = (int)(damage * MyPlayer.ModPlayer(player).KiDamage);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine Indicate = new TooltipLine(mod, "", "");
            string[] Text = Indicate.text.Split(' ');
            Indicate.text = " Consumes " + KiDrain + " Ki ";
            tooltips.Add(Indicate);
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                tt.text = damageValue + " ki " + damageWord;
            }
            if (item.damage > 0)
            {
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip")
                    {
                        line.overrideColor = Color.Cyan;
                    }
                }
            }
        }
        public override bool CanUseItem(Player player)
        {
            if (KiDrain <= MyPlayer.ModPlayer(player).KiCurrent)
            {
               MyPlayer.ModPlayer(player).KiCurrent -= (int)KiDrain;
                return true;
            }
            else
            {
                return false;
            }
        }


    }
    public abstract class KiPotion : ModItem
    {
        public int KiHeal;
        public bool IsKiPotion;
        public override bool CloneNewInstances
        {
            get { return true; }
        }
        public override bool UseItem(Player player)
        {
            MyPlayer.ModPlayer(player).KiCurrent = MyPlayer.ModPlayer(player).KiCurrent + KiHeal;
            player.AddBuff(mod.BuffType("KiPotionCooldown"), 300);
            CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), new Color(51, 204, 255), KiHeal, false, false);
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if(player.HasBuff(mod.BuffType("KiPotionCooldown")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
