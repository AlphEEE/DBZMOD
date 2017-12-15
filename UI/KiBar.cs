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
            Kibar = new UIPanel();
            Kibar.SetPadding(0);
            Kibar.Left.Set(300f, 0f);
            Kibar.Top.Set(70f, 0f);
            Kibar.Width.Set(130f, 0f);
            Kibar.Height.Set(50f, 0f);
            Kibar.BackgroundColor = new Color(0, 94, 171);

            base.Append(Kibar);
        }
        private Vector2 KiBarPosition
        {
            get
            {
                return new Vector2((float)Main.screenWidth / 2f - 128f, Main.screenHeight);
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Draw(GFX.KiBar, new Vector2(KiBarPosition.X, KiBarPosition.Y), Color.White);
            }
        }

    }
}