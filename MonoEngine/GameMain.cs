using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoEngine.Engine;
using MonoEngine.Engine.Core;
using System;

namespace MonoEngine
{
    public class GameMain : Game {

        public static int WINDOW_WIDTH = 1280;
        public static int WINDOW_HEIGHT = 720;
        public const int TARGET_FPS = 60;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public GameMain() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowAltF4 = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(1000f / TARGET_FPS);
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            graphics.IsFullScreen = true;

            graphics.ApplyChanges();
        }

        protected override void Initialize() {
            EngineInterface.InitializeEngine(this, WINDOW_WIDTH, WINDOW_HEIGHT, TARGET_FPS);
            InputManager.Initialize();
            SceneManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //add scenes as necessary
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Time.Update(gameTime.TotalGameTime.TotalSeconds);
            InputManager.Update();

            SceneManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            SceneManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}