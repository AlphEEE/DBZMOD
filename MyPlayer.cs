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
    	public float KiDamage;
        public float KiKbAddition;
        public float KiControlStat;
        public float SpeedStat;
        public float FortitudeStat;
        public float KiMax;
        public float KiRegen; 
        public bool ZoneCustomBiome = false;
        public int drawX;
        public int drawY;

        public static MyPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<MyPlayer>();
        }

        public float Powerlevel()
        {
           return Powerlevel = (KiControlStat + SpeedStat + FortitudeStat * 50); 
        }

        public override void ResetEffects()
        {
            KiDamage = 1f;
            KiKbAddition = 0f;
            KiControlStat = 1;
            SpeedStat = 1;
            FortitudeStat = 1;
            KiMax = 50f;
            KiRegen 2f;
        }
	
        public override void SetupStartInventory(IList<Item> items)
        {
            Item item4 = new Item();
            item4.SetDefaults(mod.ItemType("EmptyScroll"));   
            item4.stack = 1;         
            items.Add(item4);
        }
        //public override void UpdateBiomes()

        //ZoneCustomBiome = (DBZMODWorld.customBiome > 0);  

        public static readonly PlayerLayer MiscEffectsBack = new PlayerLayer("DBZMOD", "MiscEffectsBack", PlayerLayer.MiscEffectsBack, delegate(PlayerDrawInfo drawInfo)
            {
                if (drawInfo.shadow != 0f)
            {
                return;
            }
                Player drawPlayer = drawInfo.drawPlayer;
                Mod mod = ModLoader.GetMod("DBZMOD");
                MyPlayer modPlayer = drawPlayer.GetModPlayer<MyPlayer>(mod);
                if (player.FindBuffIndex(mod.BuffType("KaiokenBuff")) != -1)
                    {
                        Texture2D texture = mod.GetTexture("Auras/KaiokenAura");
                        int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f);
                        int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f);
                        DrawData value6 = new DrawData(TextureManager.Load("Auras/KaiokenAura"), value4 + new Vector2(75f, 75f), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, 150, 150)), new Color(new Vector4(1f - (float)Math.Sqrt((double)num91))), drawPlayer.bodyRotation, new Vector2(75f, 75f), (1f + num91), SpriteEffects.None, 0);
                        Main.playerDrawData.Add(data);
                    }
            });
        
        public override void PostUpdateEquips()
        {
            player.statLifeMax2 += (FortitudeStat * 20);
            player.statDefense += (FortitudeStat * 2);
            player.moveSpeed *= 1f + Math.Min(1.5f, SpeedStat * 0.03f);
        }
        public override void Hurt()
        {
            FortitudeStat += 0.1f;
        }
        
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
            {
                MiscEffectsBack.visible = true;
                layers.Insert(0, MiscEffectsBack);
            }
    }
}
