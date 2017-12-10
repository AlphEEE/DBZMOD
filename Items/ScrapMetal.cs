using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
    public class ScrapMetal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scrap Metal");
            Tooltip.SetDefault("Ripped from a strange robot.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.maxStack = 9999;
            item.value = 600;
            item.rare = 2;
        }
    }
}