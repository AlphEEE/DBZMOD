using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Items.Accessories
{
    public class ScouterT4 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A Piece of equipment used for scanning powerlevels."
               + "\nGives Increased Ki Damage, Spelunker and Hunter effects."
               + "\n--Tier 4--");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = 120000;
            item.rare = 5;
            item.accessory = true;
            item.defense = 0;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {

                player.GetModPlayer<MyPlayer>(mod).KiDamage *= 1.12f;
                player.GetModPlayer<MyPlayer>(mod).scouterT4 = true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PridefulKiCrystal", 20);
            recipe.AddIngredient(null, "ScouterT3");
            recipe.AddTile(null, "KiManipulator");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}