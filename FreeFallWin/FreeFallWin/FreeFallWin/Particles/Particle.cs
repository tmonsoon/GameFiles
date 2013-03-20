using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeFallWin.Particles
{
    class Particle
    {
        #region CONSTRUCTOR
        public Particle(Vector2 start_pos, Vector2 start_vel, Vector2 start_accel,float start_trans, 
            float Life_Span, Color Color, Texture2D text, Rectangle Draw_Rec, Vector2 Head_Part_Pos)
        {
            life = 0.0f;
            pos = start_pos;
            vel = start_vel;
            accel = start_accel;

            curr_trans = start_trans;
            life_span = Life_Span;
            color = Color;
            texture = text;
            draw_rec = Draw_Rec;
            past_hpp = Head_Part_Pos;
        }
        #endregion
        #region UPDATE
        public bool update(Particle head_part, List<Particle> attr_list, float elapsed_time, bool moveWHead)
        {

            life += elapsed_time;
            curr_trans = 1.0f - life / life_span;
            curr_trans = 1.0f - (Vector2.Distance(pos, head_part.position) / 100);
            vel += accel * elapsed_time;
            pos += vel * elapsed_time;
            if (moveWHead)
            {
                pos += head_part.position - past_hpp;
                past_hpp = head_part.position;
            }
            draw_rec.X = ((int)(pos.X + 0.5) - draw_rec.Width / 2);
            draw_rec.Y = ((int)(pos.Y + 0.5) - draw_rec.Height / 2);

            if (life > life_span)
            {
                return true;
            }
            else
                return false;
        }
        #endregion

        #region RENDER
        public void render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, draw_rec, color * curr_trans);
        }

        #endregion

        #region PRIVATE

        private Vector2 pos;
        private Vector2 vel;
        private Vector2 accel;

        const float trans_max = 1.0f;
        private float curr_trans;
        private float trans_step; // percentage per second
        private Color color;

        // in seconds
        private float life; 
        private float life_span;
        private float mass;

        private Vector2 past_hpp;

        
        private Texture2D texture;
        private Rectangle draw_rec;


        #endregion

        public Vector2 position
        {
            get{return pos;}
            set{pos = value;}
        }
    }
}
