using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRTS_Client_2d.Assets
{
    public class AssetsManager
    {
        Dictionary<String, Texture2D> m_Sprites;
        Dictionary<String, SpriteFont> m_Fonts;
        private static AssetsManager m_Instance; 

        public AssetsManager()
        {
            m_Sprites = new Dictionary<string, Texture2D>();
            m_Fonts = new Dictionary<string, SpriteFont>();
            m_Instance = this;
        }

        public Texture2D GetSprite(String p_Name)
        {
            if (!m_Sprites.ContainsKey(p_Name))
                return m_Sprites["NotFound"];
            return m_Sprites[p_Name];
        }

        public SpriteFont GetFont(String p_Name)
        {
            if (!m_Fonts.ContainsKey(p_Name))
                return m_Fonts["NotFound"];
            return m_Fonts[p_Name];
        }

        public void LoadFont(GraphicsDevice p_GraphicsDevice, ContentManager p_Content)
        {
            m_Fonts.Add("NotFound", p_Content.Load<SpriteFont>("Fonts\\Arial_12"));
            m_Fonts.Add("Arial_12", p_Content.Load<SpriteFont>("Fonts\\Arial_12"));
            m_Fonts.Add("Arial_20", p_Content.Load<SpriteFont>("Fonts\\Arial_20"));
        }

        public void LoadSprite(GraphicsDevice p_GraphicsDevice, ContentManager p_Content)
        {
            m_Sprites.Add("NotFound", p_Content.Load<Texture2D>("Graphics\\NotFound"));
            m_Sprites.Add("Button", p_Content.Load<Texture2D>("Graphics\\GUI\\Button"));
            m_Sprites.Add("Button_Push", p_Content.Load<Texture2D>("Graphics\\GUI\\Button_Push"));
        }

        public static AssetsManager Instance()
        {
            return (m_Instance ?? new AssetsManager());
        }
    }
}