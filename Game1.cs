using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Screensaver
{
    public class Game1 : Game
    {
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

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
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            List<GameIconInit> listGameIconInit = new List<GameIconInit>();
            listGameIconInit.Add(new GameIconInit("BG_Icon_128", new Vector2(600.0f, 300.0f), 45.0d, 175.0d));
            listGameIconInit.Add(new GameIconInit("P_Icon_128", new Vector2(100.0f, 250.0f), 110.0d, 200.0d));
            listGameIconInit.Add(new GameIconInit("FB3D_Icon_128", new Vector2(550.0f, 150.0f), 225.0d, 225.0d));
            listGameIconInit.Add(new GameIconInit("CB_Icon_128", new Vector2(450.0f, 350.0f), 285.0d, 250.0d));
            _gameIcons = InitalGameIcons(listGameIconInit);
        }

        private List<GameIcon> InitalGameIcons(List<GameIconInit> listGameIconInit)
        {
            List<GameIcon> listIcons = new List<GameIcon>();

            foreach (GameIconInit gameIconInit in listGameIconInit)
            {
                Texture2D iconTexture2D = Content.Load<Texture2D>(gameIconInit.GetIconPath());
                GameIcon gameIcon = new GameIcon(iconTexture2D, gameIconInit.GetStartPosition(), gameIconInit.GetSpeed(), gameIconInit.GetDirection());
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
                gameIcon.DrawIcon(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
