using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using DBZMOD;

namespace DBZMOD.Buffs
{
	public class KaiokenBuffX100 : ModBuff
	{
        private int kaioDamageTimer;
        public override void SetDefaults()
		{
			DisplayName.SetDefault("Kaioken x100");
			Description.SetDefault("100x Damage, 100x Speed, Drains Life Insanely Quick.");
			Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegenCount = 0;
            if (MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 100f;
                player.maxRunSpeed *= 100f;
                player.runAcceleration *= 100f;
            }
            else if (!MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 2f;
                player.maxRunSpeed *= 2f;
                player.runAcceleration *= 2f;
            }
            player.meleeDamage *= 100f;
            player.rangedDamage *= 100f;
            player.magicDamage *= 100f;
            player.minionDamage *= 100f;
            player.thrownDamage *= 100f;
            MyPlayer.ModPlayer(player).KiDamage *= 100f;
            Lighting.AddLight(player.Center, 15f, 0f, 0f);
            kaioDamageTimer++;
            if (kaioDamageTimer > 1 && player.statLife >= 0)
            {
                player.statLife -= 4;
                kaioDamageTimer = 0;
            }
            if (DBZMOD.instance.thoriumLoaded)
            {
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage *= 100f;
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost *= 100f;
            }
            if (DBZMOD.instance.tremorLoaded)
            {
                player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= 100f;
            }
        }
	}
}
