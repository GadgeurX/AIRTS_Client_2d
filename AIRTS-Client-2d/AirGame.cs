using AIRTS_Client_2d.Assets;
using AIRTS_Client_2d.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace AIRTS_Client_2d
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class AirGame : Game
    {
        GraphicsDeviceManager m_Graphics;
        SpriteBatch m_SpriteBatch;
        Thread m_NetworkThread;
        bool m_Running = true;

        public AirGame()
        {
            m_Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            m_Graphics.PreferredBackBufferHeight = 720;
            m_Graphics.PreferredBackBufferWidth = 1080;
            m_Graphics.ApplyChanges();
            Camera.Instance().ViewportWidth = m_Graphics.GraphicsDevice.Viewport.Width;
            Camera.Instance().ViewportHeight = m_Graphics.GraphicsDevice.Viewport.Height;
            m_NetworkThread = new Thread(UpdateNetwork);
            m_NetworkThread.Start();
            base.Initialize();
        }

        public void UpdateNetwork()
        {
            while (m_Running)
            {
                Network.NetManager.Instance().Update();
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            m_SpriteBatch = new SpriteBatch(GraphicsDevice);
            AssetsManager.Instance().LoadSprite(GraphicsDevice, Content);
            AssetsManager.Instance().LoadFont(GraphicsDevice, Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                m_Running = false;
                Exit();
            }
            SceneManager.Instance().Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            SceneManager.Instance().Draw(GraphicsDevice, m_SpriteBatch, gameTime);
            base.Draw(gameTime);
        }
    }
}
