using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace DBZMOD.UI
{
    internal class KiBar: UIState
    {
        public UIPanel Kibar;
        public static bool visible = false;

        public override void OnInitialize()
        {
            ResourceBar Bar = new ResourceBar(ResourceBarMode.KI, 6, 86);
            Bar.Left.Set(500f, 0f); //175
            Bar.Top.Set(40f, 0f);

            Texture2D BarTexture = GFX.KiBar;
            UIImage ki = new UIImage(BarTexture);
            ki.Left.Set(-20, 0f);
            ki.Top.Set(-8, 0f);
            ki.Width.Set(80, 0f);
            ki.Height.Set(18, 0f);
            Bar.Append(ki);

            base.Append(Bar);
        }
    }
}