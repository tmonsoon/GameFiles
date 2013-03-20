using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeFallWin.GameStates
{
    class Playing : GameState
    {
        public Playing()
        {

        }
        public override GameState update()
        {
            return this;
        }
        public override void render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
           	
        }
    }
}
