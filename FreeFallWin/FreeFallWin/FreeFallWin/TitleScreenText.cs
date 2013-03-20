using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFallWin
{
    class TitleScreenText
    {
        public TitleScreenText(SpriteFont Font, string Text, Color isSel, Color notSel, Vector2 Pos, 
             int recL, int recW, Color select_rect_col)
        {
            font = Font;
            text = Text;
            pos = Pos;
            isSelCol = isSel;
            notSelCol = notSel;
            select_rectangle = new Rectangle((int)Pos.X - rect_stretch, (int)Pos.Y - rect_stretch, recL, recW);
            select_rect_color = select_rect_col;
            isSelected = false;
            count_up = true;
            current_trans = 0.0f;

        }
        public void update()
        {
            if (isSelected)
            {
                if (count_up)
                    current_trans += trans_step;
                else
                    current_trans -= trans_step;
                if (current_trans > max_trans)
                    count_up = false;
                else if (current_trans < 0.0f)
                    count_up = true;
            }
            else
            {
                current_trans = 0;
                count_up = true;
            }
        }
        public bool selected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        public Rectangle getRec()
        {
            return select_rectangle;
        }
        public void render(SpriteBatch spriteBatch, Texture2D select_texture)
        {
            if (isSelected)
            {
                spriteBatch.Draw(select_texture, select_rectangle, select_rect_color * current_trans);
                spriteBatch.DrawString(font, text, pos, isSelCol);
            }
            else
            {
                spriteBatch.DrawString(font, text, pos, notSelCol);
            }
        }
        private string text;
        private SpriteFont font;
        private Vector2 pos;
        private Color isSelCol;
        private Color notSelCol;
        const int rect_stretch = 3;

        private Rectangle select_rectangle;
        private Color select_rect_color;
        const float max_trans = 0.45f;
        const float trans_step = 0.01f;
        float current_trans;
        private bool count_up;
        private bool isSelected;


    }
}
