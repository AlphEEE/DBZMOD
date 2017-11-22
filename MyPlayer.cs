using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;
using DBZMOD.Ui;

namespace DBZMOD
{
    public class MyPlayer : ModPlayer
    {
        public float KiDamage;
        public float KiKbAddition;
        public int KiControlStat;
        public int SpeedStat;
        public int FortitudeStat;
        public float KiMax;
        public float KiRegen;
        public bool ZoneCustomBiome = false;
        public int drawX;
        public int drawY;
        public static ModHotKey KaiokenKey;
        public static ModHotKey StatGUIOn;
        StatUi ui = new StatUi();

        public static MyPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<MyPlayer>();
        }

        public float Powerlevel
        {
            get
            {
                return KiControlStat + SpeedStat + FortitudeStat * 50;
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

            if (StatGUIOn.JustPressed)
            {
                ui.GuiOpen = true;
            }
            if (StatGUIOn.JustPressed && (ui.GuiOpen = true))
            {
                ui.GuiOpen = false;
            }
            
            if (KaiokenKey.JustPressed && (MyPlayer.ModPlayer(player).Powerlevel > 10000) && player.FindBuffIndex(mod.BuffType("KaiokenBuff")) < 0)
            {
                player.AddBuff(mod.BuffType("KaiokenBuff"),15000);
            }
            if (KaiokenKey.JustPressed && player.FindBuffIndex(mod.BuffType("KaiokenBuff")) >= 0)
            {
                player.AddBuff(mod.BuffType("KaiokenBuff"),0);
            }

        }
		public MyPlayer() : base()
		{
			KiControlStat = 1;
			SpeedStat = 1;
			FortitudeStat = 1;
		}
        public override void ResetEffects()
        {
            KiDamage = 1f;
            KiKbAddition = 0f;
            KiControlStat = 1;
            SpeedStat = 1;
            FortitudeStat = 1;
            KiMax = 50f;
            KiRegen = 2f;
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

        //private static readonly PlayerLayer miscEffectsBack = new PlayerLayer("DBZMOD", "MiscEffectsBack", PlayerLayer.MiscEffectsBack, delegate (PlayerDrawInfo drawInfo)
            // {
               //  if (drawInfo.shadow != 0f)
                // {
                 //    return;
                // }
                 //Player drawPlayer = drawInfo.drawPlayer;
                // Mod mod = ModLoader.GetMod("DBZMOD");
               //  MyPlayer modPlayer = drawPlayer.GetModPlayer<MyPlayer>(mod);
               //  if (player.FindBuffIndex(mod.BuffType("KaiokenBuff")) != -1)
                // {
                //     Texture2D texture = mod.GetTexture("Auras/KaiokenAura");
                //     int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f);
                //     int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f);
                //     DrawData value6 = new DrawData(TextureManager.Load("Auras/KaiokenAura"), value4 + new Vector2(75f, 75f), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, 150, 150)), new Color(new Vector4(1f - (float)Math.Sqrt((double)num91))), drawPlayer.bodyRotation, new Vector2(75f, 75f), (1f + num91), SpriteEffects.None, 0);
                //     Main.playerDrawData.Add(DrawData);
               //  }
            // });
      //  private static double num91;
      //  private static Vector2 value4;
      //  private PlayerLayer MiscEffectsBack;

        public static void UpdateEquips(Player player)
        {
            player.statLifeMax2 = 100 + (MyPlayer.ModPlayer(player).FortitudeStat * 20);
            player.statDefense += (MyPlayer.ModPlayer(player).FortitudeStat * 2);
            player.moveSpeed *= 1f + Math.Min(1.5f, MyPlayer.ModPlayer(player).SpeedStat * 0.03f);
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            MyPlayer.ModPlayer(player).FortitudeStat += 1;
        }
        
      //  public override void ModifyDrawLayers(List<PlayerLayer> layers)
          //  {
          //      MiscEffectsBack.visible = true;
          //      layers.Insert(0, MiscEffectsBack);
          //  }
    }
}
