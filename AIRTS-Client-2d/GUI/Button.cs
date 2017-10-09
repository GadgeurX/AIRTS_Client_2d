using AIRTS_Client_2d.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRTS_Client_2d.GUI
{
    public class Button : Scene.Scene
    {
        private bool m_Clicked = false;
        private bool m_ReadyToClick = false;
        private Texture2D m_ButtonTexture;
        private Texture2D m_ButtonTexturePushed;
        private Texture2D m_ButtonTextureCurrent;
        private Vector2 m_Size;
        private String m_Text;
        private SpriteFont m_Font;
        public delegate void Clicked();
        private Clicked m_ClickedMethod;

        public Vector2 Size { get => m_Size; set => m_Size = value; }
        public string Text { get => m_Text; set => m_Text = value; }
        public Clicked OnClicked { get => m_ClickedMethod; set => m_ClickedMethod = value; }

        public Button(Vector2 p_Position, Vector2 p_Size, String p_Text) : base(p_Position)
        {
            m_Size = p_Size;
            m_Text = p_Text;
            m_ButtonTexture = AssetsManager.Instance().GetSprite("Button");
            m_ButtonTexturePushed = AssetsManager.Instance().GetSprite("Button_Push");
            m_Font = AssetsManager.Instance().GetFont("Arial_12");
            m_ButtonTextureCurrent = m_ButtonTexture;
        }

        public override void Update(GameTime p_GameTime)
        {
            MouseState l_MouseState = Mouse.GetState();
            if (l_MouseState.LeftButton == ButtonState.Pressed)
            {
                if (l_MouseState.X > m_Position.X && l_MouseState.X < m_Position.X + m_Size.X &&
                    l_MouseState.Y > m_Position.Y && l_MouseState.Y < m_Position.Y + m_Size.Y)
                {
                    m_ButtonTextureCurrent = m_ButtonTexturePushed;
                    m_ReadyToClick = true;
                }
                else
                {
                    m_ButtonTextureCurrent = m_ButtonTexture;
                    m_ReadyToClick = false;
                }
            }
            else if (m_ReadyToClick)
            {
                m_ButtonTextureCurrent = m_ButtonTexture;
                m_ReadyToClick = false;
                OnClicked?.Invoke();
            } else
                m_ButtonTextureCurrent = m_ButtonTexture;
        }

        public override void Draw(GraphicsDevice p_GraphicDevice, SpriteBatch p_SpriteBatch, GameTime p_GameTime)
        {
            float scaleX = m_Size.X / m_ButtonTextureCurrent.Width;
            float scaleY = m_Size.Y / m_ButtonTextureCurrent.Height;
            p_SpriteBatch.Draw(m_ButtonTextureCurrent, m_Position, null, Color.White, 0.0f, Vector2.Zero,new Vector2(scaleX, scaleY), SpriteEffects.None, 1);
            Vector2 l_Offset = Vector2.Zero;
            l_Offset.X = m_Size.X / 2 - m_Font.MeasureString(m_Text).X / 2;
            l_Offset.Y = m_Size.Y / 2 - m_Font.MeasureString(m_Text).Y / 2;
            p_SpriteBatch.DrawString(m_Font, m_Text, m_Position + l_Offset, Color.Black);
        }
    }
}
