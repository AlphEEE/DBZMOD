using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons.MemeWeapons
{
    public class Rock : KiItem
    {
        public override void SetDefaults()
        {
            item.shoot = mod.ProjectileType("RockProjectile");
            item.shootSpeed = 10f;
            item.damage = 69;
            item.knockBack = 100f;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 7;
            item.useTime = 7;
            item.width = 14;
            item.height = 16;
            item.autoReuse = false;
            item.value = Item.sellPrice(6, 9, 0, 0);
            item.expert = true;
        }
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("-Tier 999-");
            DisplayName.SetDefault("God Killer Rock");
        }
    }
}
