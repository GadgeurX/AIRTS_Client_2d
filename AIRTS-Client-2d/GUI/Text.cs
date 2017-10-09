using AIRTS_Client_2d.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRTS_Client_2d.GUI
{
    public class Text : Scene.Scene
    {

        private bool m_Clicked = false;
        private bool m_ReadyToClick = false;
        private String m_Text;
        private SpriteFont m_Font;

        public string TextValue { get => m_Text; set => m_Text = value; }

        public Text(Vector2 p_Position, String p_Text) : base(p_Position)
        {
            m_Text = p_Text;
            m_Font = AssetsManager.Instance().GetFont("Arial_20");
        }

        public override void Update(GameTime p_GameTime)
        {
        }

        public override void Draw(GraphicsDevice p_GraphicDevice, SpriteBatch p_SpriteBatch, GameTime p_GameTime)
        {
            p_SpriteBatch.DrawString(m_Font, m_Text, m_Position, Color.Black);
        }
    }
}