using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Items.Accessories
{
    public class ScouterT3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A Piece of equipment used for scanning powerlevels."
               + "\nGives Increased Ki Damage, Spelunker and Hunter effects."
               + "\n--Tier 3--");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = 70000;
            item.rare = 4;
            item.accessory = true;
            item.defense = 0;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {

                player.GetModPlayer<MyPlayer>(mod).KiDamage *= 1.08f;
                player.GetModPlayer<MyPlayer>(mod).scouterT3 = true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HonorKiCrystal", 20);
            recipe.AddIngredient(null, "ScouterT2");
            recipe.AddTile(null, "KiManipulator");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}