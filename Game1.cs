using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Screensaver
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<GameIcon> _gameIcons;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;           
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            List<GameIconInit> listGameIconInit = new List<GameIconInit>();
            listGameIconInit.Add(new GameIconInit("BG_Icon_128", new Vector2(300.0f, 300.0f), new Vector2(1.0f, 1.0f), 250.0D));
            listGameIconInit.Add(new GameIconInit("P_Icon_128", new Vector2(100.0f, 250.0f), new Vector2(-1.0f, 1.0f), 300.0D));
            listGameIconInit.Add(new GameIconInit("FB3D_Icon_128", new Vector2(150.0f, 150.0f), new Vector2(-1.0f, -1.0f), 200.0D));
            _gameIcons = InitalGameIcons(listGameIconInit);
        }

        private List<GameIcon> InitalGameIcons(List<GameIconInit> listGameIconInit)
        {
            List<GameIcon> listIcons = new List<GameIcon>();

            foreach (GameIconInit gameIconInit in listGameIconInit)
            {
                Texture2D iconTexture2D = Content.Load<Texture2D>(gameIconInit.GetIconPath());
                GameIcon gameIcon = new GameIcon(iconTexture2D, gameIconInit.GetStartPosition(), gameIconInit.GetSpeed(), gameIconInit.GetDirection(),
                    _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, 128, 128);
                listIcons.Add(gameIcon);
            }

            return listIcons;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (GameIcon gameIcon in _gameIcons)
            {
                gameIcon.UpdateIconPosition(gameTime.ElapsedGameTime.TotalSeconds);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach (GameIcon gameIcon in _gameIcons)
            {
                _spriteBatch.Draw(gameIcon.GetGameIconTexture2D(), gameIcon.GetIconPosition(), Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
