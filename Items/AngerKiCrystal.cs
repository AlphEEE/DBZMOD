using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
    public class AngerKiCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angerful Ki Crystal");
            Tooltip.SetDefault("-Tier 4 Material-");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 9999;
            item.value = 800;
            item.rare = 4;
        }
    }
}