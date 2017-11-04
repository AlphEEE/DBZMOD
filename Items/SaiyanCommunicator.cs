using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
	public class SaiyanCommunicator : ModItem
	{
		public override void SetDefaults()
		{

			item.consumable = true;
			item.width = 20;
			item.height = 38;
			item.maxStack = 99;

			item.value = 100000;
			item.rare = 3;
			item.useAnimation = 30;
			item.useStyle = 4;
			item.useTime = 30;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Saiyan Communicator");
      Tooltip.SetDefault("Contacts The Remaining Saiyans For Help.");
    }

       public override bool CanUseItem(Player player)
        {
            return !Main.dayTime && !NPC.AnyNPCs(mod.NPCType("FriezaShip"));
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("FriezaShip"));   //boss spawn
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(175, 10);
			recipe.AddIngredient(null, "KiGem", 20);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
