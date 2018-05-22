using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Consumables.Potions
{
    public class KiPotion1 : KiPotion
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.consumable = true;
            item.maxStack = 30;
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 12;
            item.useTime = 12;
            item.value = 200;
            item.rare = 3;
            item.potion = false;
            IsKiPotion = true;
            KiHeal = 100;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Ki Potion");
            Tooltip.SetDefault("Restores 100 Ki.");
        }
    }
}
