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
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            player.lifeRegen -= 480;
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
            MyPlayer.ModPlayer(player).hasKaioken = true;
            player.thrownDamage *= 100f;
            MyPlayer.ModPlayer(player).KiDamage *= 100f;
            Lighting.AddLight(player.Center, 15f, 0f, 0f);
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
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage *= 100f;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost *= 100f;
        }
        public void TremorEffects(Player player)
        {
            player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= 100f;
        }
    }
}

