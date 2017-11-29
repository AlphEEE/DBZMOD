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
        public static bool visible = false;

        private Vector2 KiBarPosition
        {
            get
            {
                return new Vector2((float)Main.screenWidth / 2f - 128f, Main.screenHeight / 0f);
            }
        }

        public virtual void PostDraw(SpriteBatch spriteBatch, Player player)
        {
            if (visible == true)
            {
                spriteBatch.Draw(GFX.KiBar, new Vector2(KiBarPosition.X, KiBarPosition.Y), Color.White);
            }
        }
        public override void OnInitialize()
        {
            UIPanel parent = new UIPanel();
            parent.Height.Set(100f, 0f);
            parent.Width.Set(300, 0f);
            parent.Left.Set(Main.screenWidth - parent.Width.Pixels, 0f);
            parent.Top.Set(0f, 0f);
            parent.BackgroundColor = new Color(255, 255, 255, 255);

            base.Append(parent);
        }

    }
}