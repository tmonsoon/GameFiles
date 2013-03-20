using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FreeFallWin
{
    class Cursor
    {
        #region CONSTRUCTOR
        public Cursor(Library mainLibrary)
        {
            position = new Vector2(400, 300);
            velocity = Vector2.Zero;
            width = 40;
            height = 40;
            texture = mainLibrary.getTexture("TITLE_SCREEN_CURSOR");
            cursor_rec = new Rectangle((int)(position.X - width/2), (int)(position.Y - height/2), width, height);
            draw_position = new Vector2((position.X - width / 2),(position.Y - height / 2));

        }
        #endregion

        #region UPDATE
        public void update(GamePadState pad_state )
        {
            velocity.X = (int)(pad_state.ThumbSticks.Left.X * max_velocity);
            velocity.Y = (int)(pad_state.ThumbSticks.Left.Y * max_velocity);
            
            position += velocity;
            draw_position.X = (position.X - width / 2);
            draw_position.Y = (position.Y - height / 2);
            cursor_rec.X = (int)draw_position.X;
            cursor_rec.Y = (int)draw_position.Y;
            
            MouseState ms = Mouse.GetState();
            position.X = ms.X;
            position.Y = ms.Y;
            draw_position.X = (position.X - width / 2);
            draw_position.Y = (position.Y - height / 2);
            cursor_rec.X = (int)draw_position.X;
            cursor_rec.Y = (int)draw_position.Y;
            
        }
        #endregion

        #region RENDER
        public void render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, cursor_rec, Color.DarkBlue);
        }
        #endregion

        #region PRIVATE
        private Vector2 position;
        private Vector2 draw_position;
        private Vector2 velocity;
        int max_velocity = 5;
        private int width;
        private int height;

        private Texture2D texture;
        private Rectangle cursor_rec;
        #endregion

        public Rectangle getRectangle()
        {
            return cursor_rec;
        }
    }
}
