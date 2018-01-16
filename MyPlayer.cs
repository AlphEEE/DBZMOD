using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;
using DBZMOD.UI;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Graphics;
using Microsoft.Xna.Framework;

namespace DBZMOD
{
    public class MyPlayer : ModPlayer
    {
        public float KiDamage;
        public float KiKbAddition;
        public int KiMax;
        public float KiRegen;
        public bool ZoneCustomBiome = false;
        public int drawX;
        public int drawY;
        public bool scouterT2;
        public bool scouterT3;
        public bool scouterT4;
        public bool scouterT5;
        public bool scouterT6;
        public bool spiritualEmblem;
        public bool hasKaioken;
        public static ModHotKey KaiokenKey;
        public static ModHotKey EnergyCharge;

        public static MyPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<MyPlayer>();
        }
        public float Powerlevel
        {
            get
            {
                return player.statLifeMax2 + player.moveSpeed + player.statDefense + player.statManaMax2 + player.maxMinions * 50;
            }
        }
        public bool HasKaioken()
        {
            if(player.HasBuff(mod.BuffType("KaiokenBuff")))
            {
                return hasKaioken = true;
            }
            else
            {
                return hasKaioken = false;
            }
        }
        

         public override void ProcessTriggers(TriggersSet triggersSet)
        {
            //if (StatGUIOn == null)
            //ErrorLogger.Log("StatGUIOn is null");
            //if (ui == null)
            //  ErrorLogger.Log("ui is null");
            //if (ui.GuiOpen = true)
            //  Main.NewText("Gui is active");

            if (KaiokenKey.JustPressed /*&& (MyPlayer.ModPlayer(player).Powerlevel > 10000)*/ && (!player.HasBuff(mod.BuffType("KaiokenBuff"))))
            {
                player.AddBuff(mod.BuffType("KaiokenBuff"), 18000);
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("KaiokenAuraProj"), 0, 0, player.whoAmI);
            }
            else if (KaiokenKey.JustPressed && (player.HasBuff(mod.BuffType("KaiokenBuff"))))
            {
                player.ClearBuff(mod.BuffType("KaiokenBuff"));
            }
            if (EnergyCharge.Current && KiMax < 100)
            {
                KiMax++;
            }

        }
		public MyPlayer() : base()
		{

		}
        public override void ResetEffects()
        {
            KiDamage = 1f;
            KiKbAddition = 0f;
            KiMax = 100;
            KiRegen = 2f;
            scouterT2 = false;
            scouterT3 = false;
            scouterT4 = false;
            scouterT5 = false;
            scouterT6 = false;
            spiritualEmblem = false;
        }
	
        public override void SetupStartInventory(IList<Item> items)
        {
            Item item1 = new Item();
            item1.SetDefaults(mod.ItemType("KiFist1"));   
            item1.stack = 1;
            items.Add(item1);
        }
        //public override void UpdateBiomes()

        //ZoneCustomBiome = (DBZMODWorld.customBiome > 0);  

        public static readonly PlayerLayer MiscEffectsBack = new PlayerLayer("DBZMOD", "MiscEffectsBack", PlayerLayer.MiscEffectsBack, delegate (PlayerDrawInfo drawInfo)
             {
                 if (drawInfo.shadow != 0f)
                 {
                     return;
                 }
                 Player drawPlayer = drawInfo.drawPlayer;
                 Mod mod = ModLoader.GetMod("DBZMOD");
                 Player player = new Player();
                 MyPlayer modPlayer = drawPlayer.GetModPlayer<MyPlayer>(mod);
                    if (modPlayer.hasKaioken)
                    {
                        Texture2D texture = mod.GetTexture("Auras/KaiokenAura");
                        int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f);
                        int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 4f);
                        DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
                        Main.playerDrawData.Add(data);
                    }
                });
        
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
            {
                MiscEffectsBack.visible = true;
                layers.Insert(0, MiscEffectsBack);
            }
    }
}
