using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Screensaver
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D gameIcon;
        private Vector2 iconPosition;
        private double speed = 250.0D;
        private float dirX = 1.0f, dirY = 1.0f;
        private float currChangeValue;
        float destinationX, destinationY;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;           
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            gameIcon = Content.Load<Texture2D>("MinIcon_128");

            iconPosition = new Vector2((_graphics.PreferredBackBufferWidth / 2) - (gameIcon.Width / 2), (_graphics.PreferredBackBufferHeight / 2) - (gameIcon.Height / 2));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currChangeValue = (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            destinationX = iconPosition.X + (dirX * currChangeValue);
            if (dirX > 0)
            {                
                if (destinationX < _graphics.PreferredBackBufferWidth - gameIcon.Width)
                {
                    iconPosition.X = destinationX;
                }
                else
                {
                    iconPosition.X = 2 * (_graphics.PreferredBackBufferWidth - gameIcon.Width) - destinationX;
                    dirX = -1.0f;
                }
            }
            else
            {
                if (destinationX > 0)
                {
                    iconPosition.X = destinationX;
                }
                else
                {
                    iconPosition.X = - destinationX;
                    dirX = +1.0f;
                }
            }
            destinationY = iconPosition.Y + (dirY * currChangeValue);
            if (dirY > 0)
            {
                if (destinationY < _graphics.PreferredBackBufferHeight - gameIcon.Height)
                {
                    iconPosition.Y = destinationY;
                }
                else
                {
                    iconPosition.Y = 2 * (_graphics.PreferredBackBufferHeight - gameIcon.Height) - destinationY;
                    dirY = -1.0f;
                }
            }
            else
            {
                if (destinationY > 0)
                {
                    iconPosition.Y = destinationY;
                }
                else
                {
                    iconPosition.Y = -destinationY;
                    dirY = +1.0f;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(gameIcon, iconPosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
