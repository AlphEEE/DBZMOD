using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DBZMOD
{
    public class BaseGUI
    {
        public static List<BaseGUI> gui_elements = new List<BaseGUI>();

        public bool guiActive = false;

        public BaseGUI()
        {
            gui_elements.Add(this);
            return;
        }

        public virtual bool PreDraw()
        {
            return guiActive;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Player player)
        {
            PostDraw(spriteBatch, player);
        }
		public virtual void PostDraw(SpriteBatch spriteBatch, Player player) { }
		
		
        public virtual bool RemoveOnClose
        {
            get
            {
                return false;
            }
        }

        public void CloseGUI()
        {
            OnClose();
            guiActive = false;
            if (RemoveOnClose) gui_elements.Remove(this);
        }

        public virtual void OnClose() { }

        //public virtual void PostDraw(SpriteBatch spriteBatch, Player player) {}
    }
}