using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Items.Accessories
{
    public class ScouterT5 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A Piece of equipment used for scanning powerlevels."
               + "\nGives Increased Ki Damage, Spelunker and Hunter effects."
               + "\n--Tier 5--");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = 180000;
            item.rare = 6;
            item.accessory = true;
            item.defense = 0;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {

                player.GetModPlayer<MyPlayer>(mod).KiDamage *= 1.15f;
                player.GetModPlayer<MyPlayer>(mod).scouterT5 = true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AngerfulKiCrystal", 20);
            recipe.AddIngredient(null, "ScouterT4");
            recipe.AddTile(null, "KiManipulator");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}