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
using DBZMOD.Projectiles;

namespace DBZMOD
{
    public class MyPlayer : ModPlayer
    {
        public float KiDamage;
        public float KiKbAddition;
        public int KiMax;
        public int KiCurrent;
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
        public int TransformCooldown;
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
            if (KaiokenKey.JustPressed /*&& (MyPlayer.ModPlayer(player).Powerlevel > 10000)*/ && (!player.HasBuff(mod.BuffType("KaiokenBuff"))) && (!player.HasBuff(mod.BuffType("TiredDebuff"))))
            {
                player.AddBuff(mod.BuffType("KaiokenBuff"), 18000);
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("KaiokenAuraProj"), 0, 0, player.whoAmI);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/AuraStart").WithVolume(.5f));
                TransformCooldown++;
            }
            else if (KaiokenKey.JustPressed && (player.HasBuff(mod.BuffType("KaiokenBuff"))) && TransformCooldown <= 600)
            {
                player.ClearBuff(mod.BuffType("KaiokenBuff"));
                player.AddBuff(mod.BuffType("TiredDebuff"), 3600);
                TransformCooldown = 0;
            }
            if (EnergyCharge.Current && (KiCurrent < KiMax))
            {
                KiCurrent++;
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
            KiCurrent = 100;
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
    }
}
