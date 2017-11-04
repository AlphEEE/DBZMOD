using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Tiles
{
    public class KiCrystalOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
			minPick = 65;
			mineResist = 5f;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("UnrefinedKiGem");   //put your CustomBlock name
            AddMapEntry(new Color(0, 70, 200));
			Main.tileSpelunker[Type] = true;
        }
      
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0f;
            g = 0.3f;
            b = 0.7f;
        }
		 public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}