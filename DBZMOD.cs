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
        public bool enigmaLoaded;
        public bool battlerodsLoaded;
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
            SSJHairDraw.Hair = null;
            instance = null;
        }
        public override void Load()
        {
            instance = this;
            tremorLoaded = ModLoader.GetMod("Tremor") != null;
            thoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
            enigmaLoaded = ModLoader.GetMod("Laugicality") != null;
            battlerodsLoaded = ModLoader.GetMod("UnuBattleRods") != null;
            MyPlayer.KaiokenKey = RegisterHotKey("Kaioken", "J");
            MyPlayer.EnergyCharge = RegisterHotKey("Energy Charge", "C");
            MyPlayer.Transform = RegisterHotKey("Transform", "X");
            MyPlayer.PowerDown = RegisterHotKey("Power Down", "V");
            MyPlayer.SpeedToggle = RegisterHotKey("Speed Toggle", "Z");
            MyPlayer.QuickKi = RegisterHotKey("Quick Ki", "N");
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
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Ki Fragment", new int[]
            {
            ItemType("KiFragment1"),
            ItemType("KiFragment2"),
            ItemType("KiFragment3"),
            ItemType("KiFragment4"),
            ItemType("KiFragment5")
            });
            RecipeGroup.RegisterGroup("DBZMOD:KiFragment", group);
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
 

