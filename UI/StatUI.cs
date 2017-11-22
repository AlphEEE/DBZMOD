using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Graphics;

namespace DBZMOD.Ui
{
    public class StatUi : BaseGUI 
    {
        private MyPlayer character;
        private Mod mod;
        private DBZMOD dbzmod; 
        private Item item;
        public Vector2 position;
        public bool GuiOpen = false;

            private Vector2 GuiPosition
            {
                get
                {
                    return new Vector2((float)Main.screenWidth / 2f - 128f, Main.screenHeight / 2f);
                }
         
            }
            private Vector2 KiPowerPos
            {
                get
                {
                    return new Vector2(GuiPosition.X - 36f, GuiPosition.Y - 100f);
                }
            }
            private Vector2 KiControlPos
            {
                get
                {
                    return new Vector2(GuiPosition.X - 36f, GuiPosition.Y - 120f);
                }
            }
            private Vector2 SpeedPos
            {
                get
                {
                    return new Vector2(GuiPosition.X - 36f, GuiPosition.Y - 140f);
                }
            }
            private Vector2 FortitudePos
            {
                get
                {
                    return new Vector2(GuiPosition.X - 36f, GuiPosition.Y - 160f);
                }
            }
            public override void PostDraw(SpriteBatch spriteBatch, Player player)
            {
            if (GuiOpen == true)
                {
                    spriteBatch.Draw(GFX.StatGUI, new Vector2(GuiPosition.X , GuiPosition.Y ), Color.White);
                    spriteBatch.Draw(GFX.KiPower, KiPowerPos + new Vector2(9f, 10f), Color.White);
                    spriteBatch.DrawString(Main.fontMouseText, "Speed. " + (character.SpeedStat == 1 ? "1." : character.SpeedStat + " ."), KiPowerPos , Color.White);
                    spriteBatch.Draw(GFX.KiControl, KiControlPos + new Vector2(9f, 10f), Color.White);
                    spriteBatch.DrawString(Main.fontMouseText, character.KiControlStat == 1 ? "1." : character.KiControlStat + " .", KiControlPos, Color.White);
                }
            }
    }
}