using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD
{
    public class DBZMODItem : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (Main.rand.Next(4) == 0)
            {
                if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag)
                {
                    player.QuickSpawnItem(mod.ItemType("KaioFragmentFirst"));
                }
                if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
                {
                    player.QuickSpawnItem(mod.ItemType("KaioFragment1"));
                }
                if (context == "bossBag" && arg == ItemID.SkeletronPrimeBossBag)
                {
                    player.QuickSpawnItem(mod.ItemType("KaioFragment2"));
                }
                if (context == "bossBag" && arg == ItemID.GolemBossBag)
                {
                    player.QuickSpawnItem(mod.ItemType("KaioFragment3"));
                }
                if (context == "bossBag" && arg == ItemID.MoonLordBossBag)
                {
                    player.QuickSpawnItem(mod.ItemType("KaioFragment4"));
                }
            }
        }
    }
}