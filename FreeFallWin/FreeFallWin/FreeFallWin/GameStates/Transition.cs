﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeFallWin.GameStates
{
    class Transition : GameState
    {
        Transition()
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
