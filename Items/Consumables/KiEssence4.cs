﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Consumables
{
    public class KiEssence4 : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.consumable = true;
            item.maxStack = 1;
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.value = 0;
            item.rare = 3;
            item.potion = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radiant Ki Essence");
            Tooltip.SetDefault("Increases your ki charge rate.");
        }


        public override bool UseItem(Player player)
        {
            MyPlayer.ModPlayer(player).KiRegenRate += 2;
            MyPlayer.ModPlayer(player).KiEssence4 = true;
            return true;

        }
        public override bool CanUseItem(Player player)
        {
            if (MyPlayer.ModPlayer(player).KiEssence4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AngerKiCrystal", 30);
            recipe.AddIngredient(null, "PridefulKiCrystal", 30);
            recipe.AddIngredient(null, "HonorKiCrystal", 30);
            recipe.AddIngredient(null, "CalmKiCrystal", 30);
            recipe.AddIngredient(null, "StableKiCrystal", 30);
            recipe.AddIngredient(ItemID.LihzahrdPowerCell);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
