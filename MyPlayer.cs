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
        public bool hasSSJ1;
        public int ChargeSoundTimer;
        public int TransformCooldown;
        public static ModHotKey KaiokenKey;
        public static ModHotKey EnergyCharge;
        public static ModHotKey Transform;
        public static ModHotKey PowerDown;


        public static MyPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<MyPlayer>();
        }
        public bool KaiokenCheck()
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

        public bool SSJ1Check()
        {
            if (player.HasBuff(mod.BuffType("SSJ1Buff")))
            {
                return hasSSJ1 = true;
            }
            else
            {
                return hasSSJ1 = false;
            }
        }
        
         public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Transform.JustPressed)
            {
                if (!player.HasBuff(mod.BuffType("SSJ1Buff")))
                {
                    player.AddBuff(mod.BuffType("SSJ1Buff"), 18000);
                    Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("SSJ1AuraProjStart"), 0, 0, player.whoAmI);
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/AuraStart").WithVolume(.7f));
                }
            }
            else if (Transform.JustPressed && (player.HasBuff(mod.BuffType("SSJ1Buff"))))
            {
                player.ClearBuff(mod.BuffType("SSJ1Buff"));
            }

            if (KaiokenKey.JustPressed && (!player.HasBuff(mod.BuffType("KaiokenBuff"))) && (!player.HasBuff(mod.BuffType("TiredDebuff"))))
            {
                player.AddBuff(mod.BuffType("KaiokenBuff"), 18000);
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("KaiokenAuraProj"), 0, 0, player.whoAmI);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/KaioAuraStart").WithVolume(.5f));
                TransformCooldown++;
            }
            else if (KaiokenKey.JustPressed && (player.HasBuff(mod.BuffType("KaiokenBuff"))) && TransformCooldown < 600)
            {
                player.ClearBuff(mod.BuffType("KaiokenBuff"));
                player.AddBuff(mod.BuffType("TiredDebuff"), 3600);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/PowerDown").WithVolume(.3f));
                TransformCooldown = 0;
            }

            if (EnergyCharge.Current && (KiCurrent < KiMax))
            {
                KiCurrent++;
                player.velocity = new Vector2(0,player.velocity.Y);
                ChargeSoundTimer++;
                if (ChargeSoundTimer > 22)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EnergyCharge").WithVolume(.5f));
                    ChargeSoundTimer = 0;
                }
            }
            if (KiCurrent > KiMax)
            {
                KiCurrent = KiMax;
            }

            if (EnergyCharge.JustPressed)
            {
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("BaseAuraProj"), 0, 0, player.whoAmI);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EnergyChargeStart").WithVolume(.7f));
            }

        }
		public MyPlayer() : base()
		{

		}
        public override void ResetEffects()
        {
            KiDamage = 1f;
            KiKbAddition = 0f;
            KiMax = 1000;
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
    }
}
