using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using FreeFallWin.GameStates;
using FreeFallWin.Emitters;


namespace FreeFallWin
{

    class TitleScreen : GameState
    {
        #region CONSTRUCTOR
        public TitleScreen(Library MainLibrary)
        {
            mainLibrary = MainLibrary;
            title_display_origin = Vector2.Zero;
            title_display_rectangle = new Rectangle(0,0, 800, 600);
            selection = TitleSelect.startNew;
            TITLE_TEXT = new TitleScreenText(mainLibrary.getFont("ARIAL_86"), "Freefall", Color.Bisque, Color.Bisque, new Vector2(40, 30),
                 0, 0, Color.Yellow);
            START_TEXT = new TitleScreenText(mainLibrary.getFont("ARIAL_14"), "Start New Game", Color.Bisque, Color.Bisque, new Vector2(60, 250),
                 145, 28, Color.Yellow);
            LOAD_TEXT = new TitleScreenText(mainLibrary.getFont("ARIAL_14"), "Load Game", Color.Bisque, Color.Bisque, new Vector2(60, 350),
                 110, 28, Color.Yellow);
            QUIT_TEXT = new TitleScreenText(mainLibrary.getFont("ARIAL_14"), "Quit", Color.Bisque, Color.Bisque, new Vector2(60, 450),
                40, 28, Color.Yellow);
            

            cursor = new Cursor(mainLibrary);

            emitter = new TwoDEmitter(new Vector2(400, 300), new Vector2(0, 0), new Vector2(0, 0), "BLANK", "BLANK",
                false, false, false, 100, 100, mainLibrary);

        }
        #endregion

        #region UPDATE
        public override GameState update()
        {

            float elapsed_time = (float)mainLibrary.getGameTime().ElapsedGameTime.TotalSeconds;
            current_delay -= elapsed_time;
            current_delay = MathHelper.Max(0,current_delay);
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            cursor.update(gamePadState);

            emitter.update(elapsed_time);

            START_TEXT.update();
            LOAD_TEXT.update();
            QUIT_TEXT.update();

            if (cursor.getRectangle().Intersects(START_TEXT.getRec()))
            {
                selection = TitleSelect.startNew;
                START_TEXT.selected = true;
            }
            else if (cursor.getRectangle().Intersects(LOAD_TEXT.getRec()))
            {
                selection = TitleSelect.Load;
                LOAD_TEXT.selected = true;
            }
            else if (cursor.getRectangle().Intersects(QUIT_TEXT.getRec()))
            {
                selection = TitleSelect.Quit;
                QUIT_TEXT.selected = true;                
            }
            else
            {
               selection = TitleSelect.Nothing;
               START_TEXT.selected = false;
               LOAD_TEXT.selected = false;
               QUIT_TEXT.selected = false;
            }
            if (gamePadState.Buttons.A == ButtonState.Pressed || gamePadState.Buttons.Start == ButtonState.Pressed)
            {
                if (selection == TitleSelect.startNew)
                {
                    return new StartNewGame();
                }
                else if (selection == TitleSelect.Load)
                {
                    return new LoadGame();
                }
                else if (selection == TitleSelect.Quit)
                {
                    return new Quitting();
                }
            }
        
            return this;
        }
        #endregion

        #region RENDER
        public override void render(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(mainLibrary.getTexture("BLANK"), title_display_rectangle, Color.Black);
            emitter.render(spriteBatch);
            TITLE_TEXT.render(spriteBatch, mainLibrary.getTexture("BLANK"));
            START_TEXT.render(spriteBatch, mainLibrary.getTexture("BLANK"));
            LOAD_TEXT.render(spriteBatch, mainLibrary.getTexture("BLANK"));
            QUIT_TEXT.render(spriteBatch, mainLibrary.getTexture("BLANK"));
            cursor.render(spriteBatch);
        }
        #endregion

        #region PRIVATE

        private Vector2 title_display_origin;
        private Rectangle title_display_rectangle;

        private const float min_input_delay = 0.25f;
        private float current_delay;

        private enum TitleSelect {startNew, Load, Quit, Nothing};

        TitleScreenText TITLE_TEXT;
        TitleScreenText START_TEXT;
        TitleScreenText LOAD_TEXT;
        TitleScreenText QUIT_TEXT;

        TitleSelect selection;

        TwoDEmitter emitter;

        private Cursor cursor;

        #endregion


    }

}
