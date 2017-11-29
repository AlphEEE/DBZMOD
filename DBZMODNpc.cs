using Terraria;
using Terraria.ModLoader;

namespace DBZMOD
{
    class DBZMODNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public override void PostAI(NPC npc)
        {
            // npc.lifeMax = ((int)Math.Round(npc.lifeMax * player.Powerlevel * 0.15));
            //npc.life = ((int)Math.Round(npc.life * player.Powerlevel * 0.15));
            //npc.defense = ((int)Math.Round(npc.life * player.Powerlevel * 0.10));
            //if (npc.damage > 0 && !npc.boss)
            {
                //npc.damage = ((int)Math.Round(npc.life * player.Powerlevel * 0.20));
            }
        }
        public override void NPCLoot(NPC npc)
        {

            //if (npc.type == NPCID.SkeletronHead) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))
            //
            //if (!SlimymodWorld.spawnOreGelm)
            // {                                                          //Red  Green Blue
            //Main.NewText("You feel a slimy chill down your neck.", 0, 20, 220);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
            //for (int k = 0; k < (int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 40E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
            //{
            //int X = WorldGen.genRand.Next(0, Main.maxTilesX);
            //int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 200); //this is the coordinates where the veins ore will spawn, so in Cavern layer
            //WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9), (ushort)mod.TileType("GelmalineOreTile"));   //WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9) is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, mod.TileType("CustomOreTile") is the custom tile that will spawn
            //}
            //}
            //SlimymodWorld.spawnOreGelm = true;   //so the message and the ore spawn does not proc(show) when you kill EoC/npc again
            //}
            //if (npc.type == NPCID.MoonLordCore) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))
            //{
            //if (!SlimymodWorld.spawnOreGelphyx)
            //{                                                          //Red  Green Blue
            //Main.NewText("The world glistens with a slimy shine.", 5, 5, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
            // for (int k = 0; k < (int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 40E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
            //  {
            // int X = WorldGen.genRand.Next(0, Main.maxTilesX);
            // int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 200); //this is the coordinates where the veins ore will spawn, so in Cavern layer
            //WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9), (ushort)mod.TileType("GelphyxOre"));   //WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9) is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, mod.TileType("CustomOreTile") is the custom tile that will spawn
            // }
            //  }
            //SlimymodWorld.spawnOreGelphyx = true;   //so the message and the ore spawn does not proc(show) when you kill EoC/npc again
            //}

            //THIS IS AN EXAMPLE OF HOW TO MAKE ITEMS DROP FROM ALL NPCs IN A SPECIFIC BIOME
            if (!Main.hardMode)     //this make the item drop only in hardmode
            {
                if (!Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneBeach && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCorrupt && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCrimson && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDesert && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneGlowshroom && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneHoly && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneJungle && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneMeteor && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneOldOneArmy && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSandstorm && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSnow && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneTowerNebula && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneTowerSolar && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneTowerStardust && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneTowerVortex && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUndergroundDesert && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)        //this is where you choose what biome you whant the item to drop. ZoneCorrupt is in Corruption
                {
                    if (Main.rand.Next(4) == 0)      //this is the item rarity, so 9 = 1 in 10 chance that the npc will drop the item.
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StableKiCrystal"), Main.rand.Next(1, 3));//this is where you set what item to drop ,ItemID.VileMushroom is an example of how to add vanila items , Main.rand.Next(5, 10) it's the quantity,so it will chose a number from 5 to 10 

                    }
                }
            }
            if (!Main.hardMode)
            {
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneJungle)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CalmKiCrystal"), Main.rand.Next(1, 3));
                    }
                }
            }
            if (!Main.hardMode)
            {
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HonorKiCrystal"), Main.rand.Next(1, 3));
                    }
                }
            }
            if (Main.hardMode)
            {
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneHoly)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PridefulKiCrystal"), Main.rand.Next(1, 3));
                    }
                }
            }
            if (Main.hardMode)
            {
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCrimson)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AngerfulKiCrystal"), Main.rand.Next(1, 3));
                    }
                }
            }
            if (Main.hardMode)
            {
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCorrupt)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AngerfulKiCrystal"), Main.rand.Next(1, 3));
                    }
                }
            }
            //THIS IS AN EXAMPLE HOW TO ADD A SECOND DORP
            //if (Main.rand.Next(2) == 0) //this is the item rarity, so 2 is 1 in 3 chance that the npc will drop the item.
            //{
            //{
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GunName"), 1); //this is where you set what item to drop, mod.ItemType("GunName") is an example of how to add your custom item. and 1 is the amount
            //}
            //}
            //}
            //}
            //else    //else if it's not hardmode this will happen
            // {
            //if (Main.player[Main.myPlayer].ZoneCorrupt)  //so again if the player is in corruption
            //{
            //if (Main.rand.Next(2) == 0)    //   the item has a 1 in 3 chance to drop
            //{
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VileMushroom, Main.rand.Next(5, 8));
            //}
            //}

            //}
            //THIS IS AN EXAMPLE OF HOW TO MAKE ITEMS DROP FROM VANILA NPCs

            //if (npc.type == NPCID.EyeofCthulhu)   //this is where you choose the npc you want
            //{
            //if (Main.rand.Next(1) == 0) //this is the item rarity, so 4 is 1 in 5 chance that the npc will drop the item.
            //{
            //{
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Rhongomyniad"), 1); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
            //}
            //}
            //}


            //THIS IS AN EXAMPLE OF HOW TO MAKE ITEMS DROP FROM NPCs IN CUSTOM BIOME
            //if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneCustomBiome) //change MyPlayer with your myplayer.cs name and ZoneCustomBiome with your zone name
            //{
            //if (Main.rand.Next(2) == 0) //this is the item rarity, so 2 is 1 in 3 chance that the npc will drop the item.
            //{
            //{
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofMight, 1); //this is where you set what item to drop
            //  }
            // }
            //}

            //THIS IS AN EXAMPLE OF HOW TO MAKE ITEMS DROP FROM CUSTOM NPCs

            //if (npc.type == mod.NPCType("GelmalineSlime"))//this is how you add your custom npc
            //{
            //if (Main.rand.Next(3) == 0) //this is the item rarity, so 2 is 1 in 3 chance that the npc will drop the item.
            //{
            //{
            // Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GelmalineOre"), Main.rand.Next(3, 12)); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
            //}
            // }
            //}
            //if (npc.type == mod.NPCType("OrangeSlime"))//this is how you add your custom npc
            //{
            //if (Main.rand.Next(20) == 0) //this is the item rarity, so 2 is 1 in 3 chance that the npc will drop the item.
            //{
            //{
            //  Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlazingCore"), 1); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
            //}
            // }
            // }
            //if (npc.type == mod.NPCType("CyanSlime"))//this is how you add your custom npc
            //{
            // if (Main.rand.Next(20) == 0)  //this is the item rarity, so 2 is 1 in 3 chance that the npc will drop the item.
            //{
            //{
            //     Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IcyAmalgam"), 1); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
            //}
            //}
            //}
            //if (npc.type == mod.NPCType("TealSlime"))//this is how you add your custom npc
            //{
            // if (Main.rand.Next(20) == 0) //this is the item rarity, so 2 is 1 in 3 chance that the npc will drop the item.
            //{
            //  {
            //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PoisonPearl"), 1); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
            //}
            // }
            // }
            //if (npc.type == mod.NPCType("WhiteSlime"))//this is how you add your custom npc
            //{
            // if (Main.rand.Next(20) == 0) //this is the item rarity, so 2 is 1 in 3 chance that the npc will drop the item.
            //{
            // {
            //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ArmorShard"), 1); //this is where you set what item to drop, mod.ItemType("CustomSword") is an example of how to add your custom item. and 1 is the amount
            //}
            //}
        }
    }
}
