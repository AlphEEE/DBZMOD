﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Consumables
{
    public class KaioFragment2 : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.consumable = true;
            item.maxStack = 1;
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.value = 0;
            item.rare = 5;
            item.potion = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Kaio Fragment");
            Tooltip.SetDefault("Unlocks the next level of kaioken.");
        }


        public override bool UseItem(Player player)
        {
            MyPlayer.ModPlayer(player).KaioFragment2 = true;
            return true;

        }
        public override bool CanUseItem(Player player)
        {
            if (MyPlayer.ModPlayer(player).KaioFragment2)
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
