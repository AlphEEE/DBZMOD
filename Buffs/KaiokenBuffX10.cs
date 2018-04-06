using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Buffs
{
	public class KaiokenBuffX10 : ModBuff
	{
        private int kaioDamageTimer;
        public override void SetDefaults()
		{
			DisplayName.SetDefault("Kaioken x10");
			Description.SetDefault("10x Damage, 10x Speed, Drains Life Quickly.");
			Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegenCount = 0;
            player.moveSpeed *= 10f;
            player.maxRunSpeed *= 10f;
            player.meleeDamage *= 10f;
            player.rangedDamage *= 10f;
            player.magicDamage *= 10f;
            player.minionDamage *= 10f;
            player.thrownDamage *= 10f;
            MyPlayer.ModPlayer(player).KiDamage *= 10f;
            Lighting.AddLight(player.Center, 5f, 0f, 0f);
            kaioDamageTimer++;
            if (kaioDamageTimer > 2 && player.statLife >= 0)
            {
                player.statLife -= 1;
                kaioDamageTimer = 0;
            }
            if (DBZMOD.instance.thoriumLoaded)
            {
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage *= 10f;
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost *= 10f;
            }
            if (DBZMOD.instance.tremorLoaded)
            {
                player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= 10f;
            }
        }
	}
}
