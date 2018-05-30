using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using DBZMOD;
using Terraria;

namespace DBZMOD
{
    public abstract class TransBuff : ModBuff
    {
        public float DamageMulti;
        public float SpeedMulti;
        public float KaioLightValue;
        public float KiDrainBuffMulti;
        public bool IsKaioken;
        public static bool IsTransformation;
        public int HealthDrainRate;
        public int KiDrainRate;
        public override void Update(Player player, ref int buffIndex)
        {
            if(IsKaioken)
            {
                MyPlayer.ModPlayer(player).hasKaioken = true;
                Lighting.AddLight(player.Center, KaioLightValue, 0f, 0f);
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= HealthDrainRate;
            }
            if (MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= SpeedMulti;
                player.maxRunSpeed *= SpeedMulti;
                player.runAcceleration *= SpeedMulti;
            }
            else if (!MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 2f;
                player.maxRunSpeed *= 2f;
                player.runAcceleration *= 2f;
            }
            player.meleeDamage *= DamageMulti;
            player.rangedDamage *= DamageMulti;
            player.magicDamage *= DamageMulti;
            player.minionDamage *= DamageMulti;
            player.thrownDamage *= DamageMulti;
            MyPlayer.ModPlayer(player).KiDamage *= DamageMulti;
            if (DBZMOD.instance.thoriumLoaded)
            {
                ThoriumEffects(player);
            }
            if (DBZMOD.instance.tremorLoaded)
            {
                TremorEffects(player);
            }
            
            
        }
        public void ThoriumEffects(Player player)
        {
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage *= DamageMulti;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost *= DamageMulti;
        }
        public void TremorEffects(Player player)
        {
            player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= DamageMulti;
        }
        private void KiDrainAdd(Player player)
        {
            if(!MyPlayer.ModPlayer(player).RealismMode)
            {
                MyPlayer.ModPlayer(player).KiDrainMulti = KiDrainBuffMulti;
            }
        }
    }
}

