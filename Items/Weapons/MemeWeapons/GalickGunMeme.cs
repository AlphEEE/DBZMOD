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
    public class GalickGunMeme : KiItem
    {
        public override void SetDefaults()
        {
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 10f;
            item.damage = 69;
            item.knockBack = 2f;
            item.useStyle = 5;
            item.UseSound = SoundID.Item12;
            item.useAnimation = 15;
            item.useTime = 15;
            item.width = 50;
            item.height = 40;
            item.autoReuse = false;
            item.value = Item.sellPrice(6, 9, 0, 0);
            item.expert = true;
        }
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("-Tier 999-");
            DisplayName.SetDefault("Garlic Gun");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        } 
    }
}
