using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace FreeFallWin
{
    class Library
    {
        public Library()
        {
            textures = new Dictionary<string,Texture2D>();
            fonts = new Dictionary<string,SpriteFont>();
            soundEffects = new Dictionary<string, SoundEffect>();
            gameStates = new Dictionary<string, GameState>();
        }
        #region TEXTURES

        private static Dictionary<String, Texture2D> textures;

        public void addTexture(string key, Texture2D texture)
        {
            textures.Add(key, texture);
        }

        public Texture2D getTexture(string key)
        {
            return textures[key];
        }
        #endregion

        #region FONTS

        private static Dictionary<String, SpriteFont> fonts;

        public void addFont(string key, SpriteFont font)
        {
            fonts.Add(key, font);
        }
        public SpriteFont getFont(string key)
        {
            return fonts[key];
        }
        #endregion

        #region SOUNDEFFECTS

        private static Dictionary<String, SoundEffect> soundEffects;

        public void addSoundEffect(string key, SoundEffect sound)
        {
            soundEffects.Add(key, sound);
        }
        public SoundEffect getSoundEffect(string key){
            return soundEffects[key];
        }
        #endregion

        #region GAMESTATES

        private static Dictionary<String, GameState> gameStates;

        public void addGameState(string key, GameState state)
        {
            gameStates.Add(key, state);
        }
        public GameState getGameState(string key)
        {
            return gameStates[key];
        }
        #endregion

        #region GAMETIME
        private GameTime gameTime;

        public void addGameTime(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }
        public GameTime getGameTime()
        {
            return gameTime;
        }
        public void updateGameTime(GameTime gameTime)
        {
            this.gameTime = gameTime;
        }
        #endregion

        private static SpriteBatch spriteBatch;
    }
}
