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
        private const string AURA_DIRECTORY = "Auras/";
        private const string UI_DIRECTORY = "UI/";
        private const string KIBAR = UI_DIRECTORY + "KiBar";
        private const string KAIOAURA = AURA_DIRECTORY + "KaiokenAura";

        public static Texture2D KiBar;
        public static Texture2D KaiokenAura;
		
        public static void LoadGFX(Mod mod)
        {
            KiBar = mod.GetTexture(KIBAR);
            KaiokenAura = mod.GetTexture(KAIOAURA);
        }

        public static void UnloadGFX()
        {
            KiBar = null;
            KaiokenAura = null;
        }
    }
}