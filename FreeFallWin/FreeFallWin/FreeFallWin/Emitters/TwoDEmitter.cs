using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FreeFallWin.Particles;

namespace FreeFallWin.Emitters
{
    class TwoDEmitter
    {
        #region CONSTRUCTOR
        public TwoDEmitter(Vector2 sPos, Vector2 sVel, Vector2 sAccel, string hPTex, string pTex,
            bool hpg, bool eg, bool pg, float Mass,  int Max_Part, Library mainLibrary )
        {
            pos = sPos;
            vel = sVel;
            accel = sAccel;
            head_part_tex = mainLibrary.getTexture(hPTex);
            norm_part_tex = mainLibrary.getTexture(pTex);
            head_part_gravity = hpg;
            emitter_gravity = eg;
            pariticle_gravity = pg;
            mass = Mass;
            max_particles = Max_Part;
            rand = new Random(0);
            particles = new List<Particle>();
            particle_dump = new List<Particle>();
            particle_attractions = new List<Particle>();

            head_part = new Particle(pos, new Vector2(3,3), new Vector2(0,0), 1.0f, 2.0f, Color.Yellow,
                norm_part_tex, new Rectangle((int)pos.X, (int) pos.Y, 5, 5), new Vector2(0,0));
            move_with_head = true;

        }
        #endregion

        #region UPDATE
        public void update(float elapsed_time)
        {
            while (particles.Count() < max_particles)
            {
     
                float rx = rand.Next(-20, 20);
                float ry = rand.Next(-20, 20);
                float rpx = rand.Next(-50, 50);
                float rpy = rand.Next(-50, 50);
                float rl = (float)rand.Next(3, 10);
                particles.Add(new Particle(new Vector2(head_part.position.X + rpx, head_part.position.Y + rpy), new Vector2(rx, ry), new Vector2(0, 0), 1.0f, rl, Color.PeachPuff, 
                    norm_part_tex, new Rectangle((int)pos.X, (int)pos.Y, 1, 1), head_part.position));
            }
            head_part.update(head_part, particle_attractions, elapsed_time, false);

            for(int i = 0; i < particles.Count(); i++)
            {
                remove_part = particles[i].update(head_part, particle_attractions, elapsed_time, move_with_head);
                if (remove_part)
                    particles.Remove(particles[i]);
            }

        }
        #endregion

        #region RENDER
        public void render(SpriteBatch spriteBatch)
        {
            head_part.render(spriteBatch);
            for (int i = 0; i < particles.Count(); i++)
            {
                particles[i].render(spriteBatch);
            }

        }
        #endregion

        #region PRIVATE

        private Vector2 pos;
        private Vector2 vel;
        private Vector2 accel;

        private Texture2D head_part_tex;
        private Texture2D norm_part_tex;

        private Particle head_part;
        private List<Particle> particles;
        private List<Particle> particle_dump;

        private bool head_part_gravity;
        private bool emitter_gravity;
        private bool pariticle_gravity;
        private static List<Particle> particle_attractions;
        private bool particle_attracted_emitter;
        static bool remove_part;
        
        private float mass;
        private int max_particles;

        private bool move_with_head;

        Random rand;

        #endregion


    }
}
