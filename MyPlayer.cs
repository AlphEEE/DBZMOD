using System;
using Microsoft.Xna.Framework;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD
{
    public class MyPlayer : ModPlayer
    {
		
		public bool ZoneCustomBiome = false;
        public override void SetupStartInventory(IList<Item> items)
        {
            Item item4 = new Item();
            item4.SetDefaults(mod.ItemType("EmptyScroll"));   
            item4.stack = 1;         
            items.Add(item4);
        }
		            //public override void UpdateBiomes()
           
		   //ZoneCustomBiome = (DBZMODWorld.customBiome > 0);  

       //public static readonly PlayerLayer MiscEffectsBack = new PlayerLayer("DBZMOD", "MiscEffectsBack", PlayerLayer.MiscEffectsBack, delegate(PlayerDrawInfo drawInfo)
			//{
				//if (drawInfo.shadow != 0f)
				//{
					//return;
				//}
				//Player drawPlayer = drawInfo.drawPlayer;
				//Mod mod = ModLoader.GetMod("DBZMOD");
				//MyPlayer modPlayer = drawPlayer.GetModPlayer<MyPlayer>(mod);
				//if (player.FindBuffIndex(mod.BuffType("KaiokenBuff")) != -1)
				//{
					//Texture2D texture = mod.GetTexture("Auras/KaiokenAura");
					//int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f);
					//int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f);
					//DrawData value6 = new DrawData(TextureManager.Load("Auras/KaiokenAura"), value4 + new Vector2(75f, 75f), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, 150, 150)), new Color(new Vector4(1f - (float)Math.Sqrt((double)num91))), drawPlayer.bodyRotation, new Vector2(75f, 75f), (1f + num91), SpriteEffects.None, 0);
					//Main.playerDrawData.Add(data);
				//}
			//});
		
		//public override void ModifyDrawLayers(List<PlayerLayer> layers)
		//{
			//MiscEffectsBack.visible = true;
			//layers.Insert(0, MiscEffectsBack);
		//}




		   
    }
}