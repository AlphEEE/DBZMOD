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
        private KiBar kibar;
        public DBZMOD()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
        public override void Unload()
        {
            GFX.UnloadGFX();
        }
        public override void Load()
        {
            GFX.LoadGFX(this);
            MyPlayer.KaiokenKey = RegisterHotKey("Kaioken Toggle", "J");
            MyPlayer.EnergyCharge = RegisterHotKey("Energy Charge", "C");
            KiBar.visible = true;
            if(!Main.dedServ)
            {
                kibar = new KiBar();
                kibar.Activate();
                KiBarInterface = new UserInterface();
                KiBarInterface.SetState(kibar);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Contains("Resource Bars"));
            if (index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer(
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
 

