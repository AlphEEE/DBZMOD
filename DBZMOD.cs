using DBZMOD.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace DBZMOD
{
    public class DBZMOD : Mod
    {
        private UserInterface KiBarInterface;
        internal KiBar kibar;
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
            MyPlayer.KaiokenKey = RegisterHotKey("Kaioken", "J");
            MyPlayer.EnergyCharge = RegisterHotKey("Energy Charge", "C");
            KiBar.visible = true;

            if (!Main.dedServ)
            {
                KiBar kiBar = new KiBar();
                kiBar.Activate();
                KiBarInterface = new UserInterface();
                KiBar.visible = true;
                KiBarInterface.SetState(kiBar);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers.Insert(i, new LegacyGameInterfaceLayer(
                    "DBZMOD: Ki Bar",
                    delegate
                    {
                        if (KiBar.visible)
                        {
                            KiBarInterface.Update(Main._drawInterfaceGameTime);
                            kibar.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}


