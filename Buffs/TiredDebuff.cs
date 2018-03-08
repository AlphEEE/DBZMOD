using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;

namespace DBZMOD.Buffs
{
    public class TiredDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Exhausted");
            Description.SetDefault("You have used too much Ki.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage *= 0.8f;
            player.rangedDamage *= 0.8f;
            player.magicDamage *= 0.8f;
            player.minionDamage *= 0.8f;
            player.thrownDamage *= 0.8f;
            MyPlayer.ModPlayer(player).KiDamage *= 0.8f;
        }
        public void PreHurt(double damage, Player player, NPC npc)
        {
            if (player.HasBuff(mod.BuffType("TiredDebuff")))
            {
                npc.damage *= 2;
            }
        }
    }
}
