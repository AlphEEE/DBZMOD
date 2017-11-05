using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using DBZMOD;

namespace DBZMOD
{
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
            MyPlayer modPlayer = MyPlayer.GetModPlayer(player);
            knockback += modPlayer.KiKbAddition;
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            MyPlayer modPlayer = MyPlayer.GetModPlayer(player);
            // We want to multiply the damage we do by our alchemicalDamage modifier.
            // todo: ? do we want magic damage to also have effect here?
            damage = (int)(damage * modPlayer.KiDamage + 5E-06f);
        }
    }
}
