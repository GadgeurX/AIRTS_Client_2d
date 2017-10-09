using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRTS_Client_2d.Scene
{
    public abstract class Scene
    {
        List<Scene> m_Scenes = new List<Scene>();
        List<Scene> m_Gui = new List<Scene>();
        protected Vector2 m_Position;

        public Vector2 Position { get => m_Position; set => m_Position = value; }

        public Scene()
        {
            m_Position = Vector2.Zero;
        }

        public Scene(Vector2 p_Position)
        {
            m_Position = p_Position;
        }

        public virtual void Update(GameTime p_GameTime)
        {
            foreach (Scene l_Scene in m_Scenes)
            {
                l_Scene.Update(p_GameTime);
            }
            foreach (Scene l_Scene in m_Gui)
            {
                l_Scene.Update(p_GameTime);
            }
        }

        public virtual void Draw(GraphicsDevice p_GraphicDevice, SpriteBatch p_SpriteBatch, GameTime p_GameTime)
        {
            p_GraphicDevice.Clear(Color.CornflowerBlue);
            p_SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Camera.Instance().TranslationMatrix);
            foreach (Scene l_Scene in m_Scenes)
            {
                l_Scene.Draw(p_GraphicDevice, p_SpriteBatch, p_GameTime);
            }
            p_SpriteBatch.End();
            p_SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            foreach (Scene l_Scene in m_Gui)
            {
                l_Scene.Draw(p_GraphicDevice, p_SpriteBatch, p_GameTime);
            }
            p_SpriteBatch.End();
        }

        public void AddGuiScene(Scene p_Scene)
        {
            m_Gui.Add(p_Scene);
        }

        public void AddScene(Scene p_Scene)
        {
            m_Scenes.Add(p_Scene);
        }
    }
}
