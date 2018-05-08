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
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            player.lifeRegen -= 60;
            if (MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 10f;
                player.maxRunSpeed *= 10f;
                player.runAcceleration *= 10f;
            }
            else if (!MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 2f;
                player.maxRunSpeed *= 2f;
                player.runAcceleration *= 2f;
            }
            player.meleeDamage *= 10f;
            player.rangedDamage *= 10f;
            player.magicDamage *= 10f;
            player.minionDamage *= 10f;
            MyPlayer.ModPlayer(player).hasKaioken = true;
            player.thrownDamage *= 10f;
            MyPlayer.ModPlayer(player).KiDamage *= 10f;
            Lighting.AddLight(player.Center, 10f, 0f, 0f);
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
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage *= 10f;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost *= 10f;
        }
        public void TremorEffects(Player player)
        {
            player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= 10f;
        }
    }
}

