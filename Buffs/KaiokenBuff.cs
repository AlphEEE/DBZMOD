using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Buffs
{
	public class KaiokenBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Kaioken");
			Description.SetDefault("2x Damage, 2x Speed, Drains Life.");
			Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {                                             
            player.lifeRegen = -25;
			player.moveSpeed *= 2f;
            player.meleeDamage += 1f;
			player.rangedDamage += 1f;
			player.magicDamage += 1f;
			player.minionDamage += 1f;
			player.thrownDamage += 1f;
			MyPlayer.ModPlayer(player).KiDamage += 1f;
			Lighting.AddLight(player.Center, 5f, 0f, 0f);
        }	
	}
}
