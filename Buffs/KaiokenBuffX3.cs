using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Buffs
{
	public class KaiokenBuffX3 : ModBuff
	{
        private int kaioDamageTimer;
        public override void SetDefaults()
		{
			DisplayName.SetDefault("Kaioken X3");
			Description.SetDefault("3x Damage, 3x Speed, Drains Life.");
			Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer dbzplayer = new MyPlayer();
            if (MyPlayer.ModPlayer(player).speedToggled)
            {
                player.moveSpeed *= 3f;
                player.maxRunSpeed *= 3f;
                player.runAcceleration *= 3f;
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
            player.lifeRegen -= 30;
            player.meleeDamage *= 3f;
            player.rangedDamage *= 3f;
            player.magicDamage *= 3f;
            player.minionDamage *= 3f;
            player.thrownDamage *= 3f;
            MyPlayer.ModPlayer(player).hasKaioken = true;
            MyPlayer.ModPlayer(player).KiDamage *= 3f;
            Lighting.AddLight(player.Center, 7f, 0f, 0f);
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
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage *= 3f;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost *= 3f;
        }
        public void TremorEffects(Player player)
        {
            player.GetModPlayer<Tremor.MPlayer>(ModLoader.GetMod("Tremor")).alchemicalDamage *= 3f;
        }
    }
}

