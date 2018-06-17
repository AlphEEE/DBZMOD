using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;

namespace DBZMOD
{
    public class DBZWorld : ModWorld
    {
        public static bool RealismMode = false;

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();
            tag.Add("RealismMode", RealismMode);

            return tag;
        }

        public override void Load(TagCompound tag)
        {
            RealismMode = tag.Get<bool>("RealismMode");
        }



    }
    /*public class ModWord : ModWorld
    {
        private const int saveVersion = 0;
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Custom Mod Ores", delegate (GenerationProgress progress)
            {
                progress.Message = "Custom Mod Ores";
                
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)                                                                                                                                      //      |
                {                                                                                                                                                                                                                      //       |
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), mod.TileType("KiCrystalOre"), false, 0f, 0f, false, true);
                }
            }));
        }

    }
*/}
