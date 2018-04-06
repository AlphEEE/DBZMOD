using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Buffs
{
	public class KaiokenBuff : ModBuff
	{
        private int kaioDamageTimer;
        public override void SetDefaults()
		{
			DisplayName.SetDefault("Kaioken");
			Description.SetDefault("2x Damage, 2x Speed, Slowly Drains Life.");
			Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegenCount = 0;
            player.moveSpeed *= 2f;
            player.maxRunSpeed *= 2f;
            player.meleeDamage *= 2f;
            player.rangedDamage *= 2f;
            player.magicDamage *= 2f;
            player.minionDamage *= 2f;
            player.thrownDamage *= 2f;
            MyPlayer.ModPlayer(player).KiDamage *= 2f;
            Lighting.AddLight(player.Center, 5f, 0f, 0f);
            kaioDamageTimer++;
            if (kaioDamageTimer > 5 && player.statLife >= 0)
            {
                player.statLife -= 1;
                kaioDamageTimer = 0;
            }
            if (DBZMOD.instance.thoriumLoaded)
            {
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage *= 2f;
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost *= 2f;
            }
            if (DBZMOD.instance.tremorLoaded)
            {
                player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= 2f;
                player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= 20f;
            }
        }
	}
}
