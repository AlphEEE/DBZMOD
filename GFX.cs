using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace DBZMOD
{
    public static class GFX
    {

        private const string GUI_DIRECTORY = "GFX/";
        private const string KIBAR = GUI_DIRECTORY + "KiBar";
        private const string KICONTROL = GUI_DIRECTORY + "KiControl";
        private const string KIPOWER = GUI_DIRECTORY + "KiPower";
		private const string STATGUI = GUI_DIRECTORY + "StatGUI";

        public static Texture2D KiBar;
        public static Texture2D KiControl;
        public static Texture2D KiPower;
		public static Texture2D StatGUI;
		
        public static void LoadGFX(Mod mod)
        {
            KiBar = mod.GetTexture(KIBAR);
            KiPower = mod.GetTexture(KIPOWER);
            KiControl = mod.GetTexture(KICONTROL);
			StatGUI = mod.GetTexture(STATGUI);
        }

        public static void UnloadGFX()
        {
            KiBar = null;
            KiPower = null;
            KiControl = null;
            StatGUI = null;
        }
    }
}