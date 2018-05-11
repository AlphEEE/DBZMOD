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
        public bool scouterT2;
        public bool scouterT3;
        public bool scouterT4;
        public bool scouterT5;
        public bool scouterT6;
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
        public int ChargeSoundTimer;
        public int TransformCooldown;
        public static ModHotKey KaiokenKey;
        public static ModHotKey EnergyCharge;
        public static ModHotKey Transform;
        public static ModHotKey PowerDown;
        public static ModHotKey SpeedToggle;


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
            var fragment = new List<string>();
            if (Fragment1) fragment.Add("Fragment1");
            if (Fragment2) fragment.Add("Fragment2");
            if (KaioAchieved) fragment.Add("KaioAchieved");
            if (KaioFragment1) fragment.Add("KaioFragment1");
            if (KaioFragment2) fragment.Add("KaioFragment2");
            if (KaioFragment3) fragment.Add("KaioFragment3");
            if (KaioFragment4) fragment.Add("KaioFragment4");
            if (RealismMode) fragment.Add("RealismMode");

            return new TagCompound {
                {"fragment", fragment}
            };
            
            
        }

        public override void Load(TagCompound tag)
        {
            var fragment = tag.GetList<string>("fragment");
            Fragment1 = fragment.Contains("Fragment1");
            Fragment2 = fragment.Contains("Fragment2");
            KaioFragment1 = fragment.Contains("KaioFragment1");
            KaioFragment2 = fragment.Contains("KaioFragment2");
            KaioFragment3 = fragment.Contains("KaioFragment3");
            KaioFragment4 = fragment.Contains("KaioFragment4");
            KaioAchieved = fragment.Contains("KaioAchieved");
            RealismMode = fragment.Contains("RealismMode");
        }


        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Transform.JustPressed && player.HasBuff(mod.BuffType("KaiokenBuff")))
            {
                //if (!player.HasBuff(mod.BuffType("SSJ1Buff")))
                //{
                //player.AddBuff(mod.BuffType("SSJ1Buff"), 18000);
                //Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("SSJ1AuraProjStart"), 0, 0, player.whoAmI);
                //Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/AuraStart").WithVolume(.7f));
                //}
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType("SSJ1AuraProjStart"), 0, 0, player.whoAmI);
                player.ClearBuff(mod.BuffType("KaiokenBuff"));


            }
            if (SpeedToggle.JustPressed)
            {
                speedToggled = !speedToggled;
            }
                
            if (KaiokenKey.JustPressed && (!player.HasBuff(mod.BuffType("KaiokenBuff")) && !player.HasBuff(mod.BuffType("KaiokenBuffX3")) && !player.HasBuff(mod.BuffType("KaiokenBuffX10")) && !player.HasBuff(mod.BuffType("KaiokenBuffX20")) && !player.HasBuff(mod.BuffType("KaiokenBuffX100"))) && !player.HasBuff(mod.BuffType("TiredDebuff")) && KaioAchieved)
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
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (player.statLife < 0 && hasKaioken)
            {
                player.KillMe(PlayerDeathReason.ByCustomReason(" Destroyed Their Body"), damage, hitDirection);
                //damageSource = PlayerDeathReason.ByCustomReason(" Destroyed Their Body");
            }
            return true;
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
    /*public class SSJHairDraw : ModPlayer
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
        }
    }*/
}
