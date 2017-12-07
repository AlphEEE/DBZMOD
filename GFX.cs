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

        public static Texture2D KiBar;
		
        public static void LoadGFX(Mod mod)
        {
            KiBar = mod.GetTexture(KIBAR);
        }

        public static void UnloadGFX()
        {
            KiBar = null;
        }
    }
}