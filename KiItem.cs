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
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player owner = null;
            if (projectile.owner != -1)
                owner = Main.player[projectile.owner];
            else if (projectile.owner == 255)
                owner = Main.LocalPlayer;
        }
    }

    public abstract class KiItem : ModItem
    {
        // make-safe
        public override void SetDefaults()
        {
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            knockback = knockback + MyPlayer.ModPlayer(player).KiKbAddition; 
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {
			damage = (int)(damage * MyPlayer.ModPlayer(player).KiDamage + 5E-06f);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
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
            if (line.mod == "Terraria" && line.Name == "Damage")
                {
                    line.overrideColor = Color.Cyan;
                }
            }
        }

	    }
    }
}
