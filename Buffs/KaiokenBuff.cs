using Terraria;
using Terraria.ModLoader;

namespace DBZMOD.Buffs
{
	public class KaiokenBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Kaioken");
			Description.SetDefault("1.2x Damage, 1.2x Speed, Loosing Life.");
			Main.buffNoTimeDisplay[Type] = true;
		}
        public override void Update(Player player, ref int buffIndex)
        {                                             
            player.lifeRegen = -15;
			player.moveSpeed *= 1.2f;
            player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.thrownDamage *= 1.2f;
        }	
	}
}
