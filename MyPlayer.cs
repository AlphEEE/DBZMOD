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
using Terraria.ModLoader.IO;

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
        public bool RealismMode = false;
        public bool SSJ1Achieved;
        public bool scouterT2;
        public bool scouterT3;
        public bool scouterT4;
        public bool scouterT5;
        public bool scouterT6;
        public bool IsTransforming;
        public bool Fragment1;
        public bool Fragment2;
        public bool Fragment3;
        public bool Fragment4;
        public bool Fragment5;
        public bool KaioFragment1;
        public bool KaioFragment2;
        public bool KaioFragment3;
        public bool KaioFragment4;
        public bool KaioAchieved;
        public bool spiritualEmblem;
        public bool hasKaioken;
        public bool hasSSJ1;
        public bool kiLantern;
        public bool speedToggled = true;
        public float KiDrainMulti;
        public int ChargeSoundTimer;
        public int TransformCooldown;
        public static ModHotKey KaiokenKey;
        public static ModHotKey EnergyCharge;
        public static ModHotKey Transform;
        public static ModHotKey PowerDown;
        public static ModHotKey SpeedToggle;
        public static ModHotKey QuickKi;


        public static MyPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<MyPlayer>();
        }
        public bool KaiokenCheck()
        {
            if(player.HasBuff(mod.BuffType("KaiokenBuff")) || player.HasBuff(mod.BuffType("KaiokenBuffX3")) || player.HasBuff(mod.BuffType("KaiokenBuffX10")) || player.HasBuff(mod.BuffType("KaiokenBuffX20")) || player.HasBuff(mod.BuffType("KaiokenBuffX100")))
            {
                return hasKaioken = true;
            }
            else
            {
                return hasKaioken = false;
            }
        }
        public override void PreUpdate()
        {
            if(kiLantern)
            {
                player.AddBuff(mod.BuffType("KiLanternBuff"), 18000);
            }
            if (!kiLantern && player.HasBuff(mod.BuffType("KiLanternBuff")))
            {
                player.ClearBuff(mod.BuffType("KiLanternBuff"));
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

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();

            tag.Add("Fragment1", Fragment1);
            tag.Add("Fragment2", Fragment2);
            tag.Add("Fragment3", Fragment3);
            tag.Add("Fragment4", Fragment4);
            tag.Add("Fragment5", Fragment5);
            tag.Add("KaioFragment1", KaioFragment1);
            tag.Add("KaioFragment2", KaioFragment2);
            tag.Add("KaioFragment3", KaioFragment3);
            tag.Add("KaioFragment4", KaioFragment4);
            tag.Add("KaioAchieved", KaioAchieved);
            tag.Add("RealismMode", RealismMode);
            tag.Add("SSJ1Achieved", SSJ1Achieved);
            tag.Add("KiCurrent", KiCurrent);

            return tag;
        }

        public override void Load(TagCompound tag)
        {
            Fragment1 = tag.Get<bool>("Fragment1");
            Fragment2 = tag.Get<bool>("Fragment2");
            Fragment3 = tag.Get<bool>("Fragment3");
            Fragment4 = tag.Get<bool>("Fragment4");
            Fragment5 = tag.Get<bool>("Fragment5");
            KaioFragment1 = tag.Get<bool>("KaioFragment1");
            KaioFragment2 = tag.Get<bool>("KaioFragment2");
            KaioFragment3 = tag.Get<bool>("KaioFragment3");
            KaioFragment4 = tag.Get<bool>("KaioFragment4");
            KaioAchieved = tag.Get<bool>("KaioAchieved");
            RealismMode = tag.Get<bool>("RealismMode");
            SSJ1Achieved = tag.Get<bool>("SSJ1Achieved");
            KiCurrent = tag.Get<int>("KiCurrent");
        }




        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Transform.JustPressed && player.HasBuff(mod.BuffType("KaiokenBuff")))
            {
                if (!player.HasBuff(mod.BuffType("SSJ1Buff")) && SSJ1Achieved && !IsTransforming)
                {
                    player.AddBuff(mod.BuffType("SSJ1Buff"), 18000);
                    Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("SSJ1AuraProjStartQuick"), 0, 0, player.whoAmI);
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/AuraStart").WithVolume(.7f));
                }
            }
            if (SpeedToggle.JustPressed)
            {
                speedToggled = !speedToggled;
            }
            if(QuickKi.JustPressed)
            {

            }
                
            if (KaiokenKey.JustPressed && (!player.HasBuff(mod.BuffType("KaiokenBuff")) && !player.HasBuff(mod.BuffType("KaiokenBuffX3")) && !player.HasBuff(mod.BuffType("KaiokenBuffX10")) && !player.HasBuff(mod.BuffType("KaiokenBuffX20")) && !player.HasBuff(mod.BuffType("KaiokenBuffX100"))) && !player.HasBuff(mod.BuffType("TiredDebuff")) && KaioAchieved && !player.channel)
            {
                player.AddBuff(mod.BuffType("KaiokenBuff"), 18000);
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("KaiokenAuraProj"), 0, 0, player.whoAmI);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/KaioAuraStart").WithVolume(.5f));
            }
            else if (KaiokenKey.JustPressed && (player.HasBuff(mod.BuffType("KaiokenBuff"))) && KaioFragment1)
            {
                player.ClearBuff(mod.BuffType("KaiokenBuff"));
                player.AddBuff(mod.BuffType("KaiokenBuffX3"), 18000);
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("KaiokenAuraProjx3"), 0, 0, player.whoAmI);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/KaioAuraAscend").WithVolume(.6f));
            }
            else if (KaiokenKey.JustPressed && (player.HasBuff(mod.BuffType("KaiokenBuffX3"))) && KaioFragment2)
            {
                player.ClearBuff(mod.BuffType("KaiokenBuffX3"));
                player.AddBuff(mod.BuffType("KaiokenBuffX10"), 18000);
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("KaiokenAuraProjx10"), 0, 0, player.whoAmI);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/KaioAuraAscend").WithVolume(.6f));
            }
            else if (KaiokenKey.JustPressed && (player.HasBuff(mod.BuffType("KaiokenBuffX10"))) && KaioFragment3)
            {
                player.ClearBuff(mod.BuffType("KaiokenBuffX10"));
                player.AddBuff(mod.BuffType("KaiokenBuffX20"), 18000);
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("KaiokenAuraProjx20"), 0, 0, player.whoAmI);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/KaioAuraAscend").WithVolume(.7f));
            }
            else if (KaiokenKey.JustPressed && (player.HasBuff(mod.BuffType("KaiokenBuffX20"))) && KaioFragment4)
            {
                player.ClearBuff(mod.BuffType("KaiokenBuffX20"));
                player.AddBuff(mod.BuffType("KaiokenBuffX100"), 18000);
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("KaiokenAuraProjx100"), 0, 0, player.whoAmI);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/KaioAuraAscend").WithVolume(.8f));
            }

            if (EnergyCharge.Current && (KiCurrent < KiMax) && !player.channel)
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
                if(hasKaioken || hasSSJ1)
                {
                    Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("BaseAuraProj"), 0, 0, player.whoAmI);
                }
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EnergyChargeStart").WithVolume(.7f));
            }
            if (PowerDown.JustPressed && (player.HasBuff(mod.BuffType("KaiokenBuff")) || player.HasBuff(mod.BuffType("KaiokenBuffX3")) || player.HasBuff(mod.BuffType("KaiokenBuffX10")) || player.HasBuff(mod.BuffType("KaiokenBuffX20")) || player.HasBuff(mod.BuffType("KaiokenBuffX100"))))
            {
                player.ClearBuff(mod.BuffType("KaiokenBuff"));
                player.ClearBuff(mod.BuffType("KaiokenBuffX3"));
                player.ClearBuff(mod.BuffType("KaiokenBuffX10"));
                player.ClearBuff(mod.BuffType("KaiokenBuffX20"));
                player.ClearBuff(mod.BuffType("KaiokenBuffX100"));
                player.ClearBuff(mod.BuffType("SSJ1Buff"));
                player.AddBuff(mod.BuffType("TiredDebuff"), 3600);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/PowerDown").WithVolume(.3f));
            }

        }        
        public MyPlayer() : base()
		{
		}
        public override void ResetEffects()
        {
            KiDamage = 1f;
            KiKbAddition = 0f;
            if(Fragment1)
            {
                KiMax = 2000;

                if (Fragment2)
                {
                    KiMax = 4000;

                    if (Fragment3)
                    {
                        KiMax = 6000;

                        if (Fragment4)
                        {
                            KiMax = 8000;

                            if (Fragment5)
                            {
                                KiMax = 10000;
                            }
                        }
                    }
                }
            }
           else if (!Fragment1 && !Fragment2 && !Fragment3 && !Fragment4 && !Fragment5)
            {
                KiMax = 1000;
            }
            
            
            
           
            
            KiRegen = 2f;
            scouterT2 = false;
            scouterT3 = false;
            scouterT4 = false;
            scouterT5 = false;
            scouterT6 = false;
            spiritualEmblem = false;
            KiDrainMulti = 1f;
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (damageSource.SourceNPCIndex > -1)
            {
                NPC culprit = Main.npc[damageSource.SourceNPCIndex];
                if (culprit.boss && !SSJ1Achieved && (Main.rand.Next(9) == 0))
                {
                    Main.NewText("The humiliation of failing drives you mad.");
                    player.statLife = 1;
                    player.HealEffect(1);
                    SSJ1Achieved = true;
                    IsTransforming = true;
                    SSJTransformation();
                    return false;
                }
            }

            return true;
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if(IsTransforming)
            {
                return false;
            }
            return true;
        }
        float speedX;
        float speedY;
        public void SSJTransformation()
        {
            Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("SSJ1AuraProjStart"), 0, 0, player.whoAmI);
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
            for (int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("SSJ1AuraProjBeamHead"), 0, 0, player.whoAmI);
            }
        }
        public override void SetupStartInventory(IList<Item> items)
        {
            Item item1 = new Item();
            item1.SetDefaults(mod.ItemType("KiFist1"));   
            item1.stack = 1;
            items.Add(item1);

            Item item9 = new Item();
            item9.SetDefaults(mod.ItemType("KiAggravationStone"));
            item9.stack = 1;
            items.Add(item9);
        }
        //public override void UpdateBiomes()

        //ZoneCustomBiome = (DBZMODWorld.customBiome > 0);  
    }
    public class SSJHairDraw : ModPlayer
    {
        public static Texture2D Hair;
        public static SSJHairDraw ModPlayer(Player player)
        {
            return player.GetModPlayer<SSJHairDraw>();
        }
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            int head = layers.FindIndex(l => l == PlayerLayer.Hair);
            if (head < 0)
                return;

            layers[head] = new PlayerLayer(mod.Name, "TransHair",
                delegate (PlayerDrawInfo draw)
               {
                   Player player = draw.drawPlayer;
                   if (TransBuff.IsTransformation)
                       return;

                   Color alpha = draw.drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)(draw.position.X + draw.drawPlayer.width * 0.5) / 16, (int)((draw.position.Y + draw.drawPlayer.height * 0.25) / 16.0), Color.White), draw.shadow);
                   DrawData data = new DrawData(Hair, new Vector2((float)((int)(draw.position.X - Main.screenPosition.X - (float)(player.bodyFrame.Width / 2) + (float)(player.width / 2))), (float)((int)(draw.position.Y - Main.screenPosition.Y + (float)player.height - (float)player.bodyFrame.Height + 4f))) + player.headPosition + draw.headOrigin, player.bodyFrame, alpha, player.headRotation, draw.headOrigin, 1f, draw.spriteEffects, 0);
                   data.shader = draw.hairShader;
                   Main.playerDrawData.Add(data);
               });
        }
        public void HairSelect(Player player)
        {
            if (player.HasBuff(mod.BuffType("SSJ1Buff")))
            {
                Hair = mod.GetTexture("Hairs/SSJ/SSJ1Hair");
            }
            if (player.HasBuff(mod.BuffType("SSJ2Buff")))
            {
                Hair = mod.GetTexture("Hairs/SSJ/SSJ2Hair");
            }
            else
            {
                Hair = null;
            }
        }
    }
}
