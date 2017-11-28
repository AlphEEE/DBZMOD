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
            visible = true;
        }

    }
}