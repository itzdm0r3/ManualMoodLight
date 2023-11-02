using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ManualMoodLight
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

            //The Game World - our color values
            byte redIntensity = 0;
            byte greenIntensity = 80;
            byte blueIntensity = 160;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //Allows the game to stop vibration and exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                GamePad.SetVibration(PlayerIndex.One, 0, 0);
                Exit();
            }
            
            //Get Gamepad state
            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
            
            //Get Keyboard state
            KeyboardState keys = Keyboard.GetState();

            if (pad1.Buttons.B == ButtonState.Pressed || keys.IsKeyDown(Keys.R)) redIntensity++;
            if (pad1.Buttons.X == ButtonState.Pressed || keys.IsKeyDown(Keys.B)) blueIntensity++;
            if (pad1.Buttons.A == ButtonState.Pressed || keys.IsKeyDown(Keys.G)) greenIntensity++;
            if (pad1.Buttons.Y == ButtonState.Pressed || keys.IsKeyDown(Keys.Y))
            {
                redIntensity++;
                greenIntensity++;
            }
            //Set controller vibration
            if (redIntensity > 220 ||
                greenIntensity > 220 ||
                blueIntensity > 220)
            {
                GamePad.SetVibration(PlayerIndex.One, 0, 1);
            }
            else
            {
                GamePad.SetVibration(PlayerIndex.One, 0, 0);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Color backgroundColor;
            backgroundColor =
                new Color(redIntensity, greenIntensity, blueIntensity);
            _graphics.GraphicsDevice.Clear(backgroundColor);
            base.Draw(gameTime);
        }
    }
}