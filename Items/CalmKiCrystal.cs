using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
    public class CalmKiCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calm Ki Crystal");
            Tooltip.SetDefault("-Tier 2 Material-");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 9999;
            item.value = 300;
            item.rare = 3;
        }
    }
}