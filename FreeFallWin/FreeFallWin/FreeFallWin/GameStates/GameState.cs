using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFallWin
{
    abstract class GameState
    {
        public abstract GameState update();

        public abstract void render(SpriteBatch spriteBatch);

        protected static Library mainLibrary;

    }
}
