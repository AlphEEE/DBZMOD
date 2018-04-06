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
        private UIFlatPanel UIFlatPanel;
        private DBZMOD mod;
        public bool thoriumLoaded;
        public bool tremorLoaded;
        public static DBZMOD instance;

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
            KiBar.visible = false;
<<<<<<< HEAD
            instance = null;
=======
>>>>>>> 090fab9dd248e77d3537c6a57f88521a3c9e4299
        }
        public override void Load()
        {
            instance = this;
            tremorLoaded = ModLoader.GetMod("Tremor") != null;
            thoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
            MyPlayer.KaiokenKey = RegisterHotKey("Kaioken Toggle", "J");
            MyPlayer.EnergyCharge = RegisterHotKey("Energy Charge", "C");
            MyPlayer.Transform = RegisterHotKey("Transform", "X");
            MyPlayer.PowerDown = RegisterHotKey("Power Down", "V");
            if(!Main.dedServ)
            {
                KiBar.visible = true;
                GFX.LoadGFX(this);
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
 

