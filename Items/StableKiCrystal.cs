using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Slimymod.Items
{
    public class StableCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stable Ki Crystal");
            Tooltip.SetDefault("-Tier 1 Material-");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 9999;
            item.value = 100;
            item.rare = 3;
        }
    }
}