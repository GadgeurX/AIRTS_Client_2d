using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRTS_Client_2d.Scene
{
    public class SceneManager
    {
        private Dictionary<String, Scene> m_Scenes;
        private Scene m_CurrentScene;
        private static SceneManager m_Instance;

        public SceneManager()
        {
            m_Instance = this;
            m_Scenes = new Dictionary<string, Scene>
            {
                { "Splash", new SplashScene() },
                { "Login", new LoginScene() },
                { "Game", new GameScene() },
            };
            m_CurrentScene = m_Scenes["Splash"];
        }

        public void Update(GameTime p_GameTime)
        {
            if(m_CurrentScene != null)
                m_CurrentScene.Update(p_GameTime);
        }

        public void Draw(GraphicsDevice p_GraphicDevice, SpriteBatch p_SpriteBatch, GameTime p_GameTime)
        {
            if (m_CurrentScene != null)
                m_CurrentScene.Draw(p_GraphicDevice, p_SpriteBatch, p_GameTime);
        }

        public void SetScene(String p_Name)
        {
            Console.WriteLine("Set Scene : " + p_Name);
            if (m_Scenes.ContainsKey(p_Name))
                m_CurrentScene = m_Scenes[p_Name];
        }

        public static SceneManager Instance()
        {
            return m_Instance ?? new SceneManager();
        }
    }
}
