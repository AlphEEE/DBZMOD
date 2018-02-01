using Terraria;
using Terraria.Modloader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace DBZMOD.Npcs
{
    public class TrainingBot : ModNPC
    {
        public int ShootTimer;
        public int Damage;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Capsule Corp Training Robot");
        }
        
        public override void SetDefaults()
        {
            ShootTimer = 0;
            Damage = 15;
            npc.lifeMax = 70;
            npc.damage = 25;
            npc.defense = 5;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.width = 40;
            npc.height = 55;
            npc.value = 350;
            npc.lavaImmune = true;
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
         }
         
         if(Main.expertMode)
         {
            npc.lifeMax = 225;
            npc.damage = 60;
            Damage = 35;
         }
         
         public override void AI()
         {
            npc.position.Y = npc.position.Y - Main.player[npc.target].position.Y;
            npc.position.X = npc.position.X - Main.player[npc.target].position.X;
            
            if(Main.player[npc.target].statLife > 0)
            {
                ShootTimer++;
            }
            if(ShootTimer > 240)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, ProjectileID.83, damage / 3, 3, Main.myPlayer);
                ShootTimer = 0;
            }
         
         
         }
            
            
