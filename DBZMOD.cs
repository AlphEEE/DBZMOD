using DBZMOD.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace DBZMOD
{
    public class DBZMOD : Mod
    {
        public DBZMOD()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load()
        {
            MyPlayer.StatGUIOn = RegisterHotKey("Stat Gui", "N");
            MyPlayer.KaiokenKey = RegisterHotKey("Kaioken", "J");
            MyPlayer.EnergyCharge = RegisterHotKey("Energy Charge", "C");
            KiBar.visible = true;
        }
    }
}


