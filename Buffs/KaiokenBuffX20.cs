using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using DBZMOD;

namespace DBZMOD.Buffs
{
	public class KaiokenBuffX20 : ModBuff
	{
        private int kaioDamageTimer;
        public override void SetDefaults()
		{
			DisplayName.SetDefault("Kaioken x20");
			Description.SetDefault("20x Damage, 20x Speed, Rapidly Drains Life.");
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
            player.lifeRegen -= 120;
            if (MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 20f;
                player.maxRunSpeed *= 20f;
                player.runAcceleration *= 20f;
            }
            else if (!MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 2f;
                player.maxRunSpeed *= 2f;
                player.runAcceleration *= 2f;
            }
            player.meleeDamage *= 20f;
            player.rangedDamage *= 20f;
            player.magicDamage *= 20f;
            MyPlayer.ModPlayer(player).hasKaioken = true;
            player.minionDamage *= 20f;
            player.thrownDamage *= 20f;
            MyPlayer.ModPlayer(player).KiDamage *= 20f;
            Lighting.AddLight(player.Center, 12f, 0f, 0f);
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
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage *= 20f;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost *= 20f;
        }
        public void TremorEffects(Player player)
        {
            player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= 20f;
        }
    }
}

