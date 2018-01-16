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
            UIFlatPanel parent = new UIFlatPanel();
            parent.SetPadding(0);
            parent.Left.Set(300f, 0f);
            parent.Top.Set(70f, 0f);
            parent.Width.Set(130f, 0f);
            parent.Height.Set(50f, 0f);
            parent.backgroundColor = new Color(0, 94, 171);

            UIFlatPanel ki = new UIFlatPanel();
            ki.Height.Set(40f, 0f);
            ki.Width.Set(110f, 0f);
            ki.Left.Set(290f, 0f);
            ki.Top.Set(65f, 0f);
            ki.backgroundColor = Color.Red;
            parent.Append(ki);

            base.Append(parent);
        }
    }
}