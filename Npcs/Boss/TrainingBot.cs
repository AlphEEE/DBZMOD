using Terraria;
using Terraria.Modloader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace DBZMOD.Npcs
{
    public class TrainingBot : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Capsule Corp Training Robot");
        }
        
        public override void SetDefaults()
        {
            npc.life = 70;
            npc.damage = 25;
            
