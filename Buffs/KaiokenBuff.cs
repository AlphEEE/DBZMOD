using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Buffs
{
	public class KaiokenBuff : ModBuff
	{
        private Player player;
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
            if (MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 2f;
                player.maxRunSpeed *= 2f;
                player.runAcceleration *= 2f;
            }
            else if (!MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 2f;
                player.maxRunSpeed *= 2f;
                player.runAcceleration *= 2f;
            }
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            player.lifeRegen -= 24;
            player.meleeDamage *= 2f;
            player.rangedDamage *= 2f;
            player.magicDamage *= 2f;
            MyPlayer.ModPlayer(player).hasKaioken = true;
            player.minionDamage *= 2f;
            player.thrownDamage *= 2f;
            MyPlayer.ModPlayer(player).KiDamage *= 2f;
            Lighting.AddLight(player.Center, 5f, 0f, 0f);
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
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage *= 2f;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost *= 2f;
        }
        public void TremorEffects(Player player)
        {
            player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= 2f;
        }

    }
}

