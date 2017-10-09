using AIRTS_Client_2d.GUI;
using AiRTServer;
using AiRTServer.Packets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRTS_Client_2d.Scene
{
    public class LoginScene : Scene
    {
        Button m_LoginButton;

        public LoginScene()
        {
            this.AddGuiScene(new Text(new Vector2(150, 150), "Addresse : "));
            this.AddGuiScene(new Text(new Vector2(150, 180), "Login : "));
            this.AddGuiScene(new Text(new Vector2(150, 210), "Mdp : "));
            m_LoginButton = new Button(new Vector2(250, 240), new Vector2(150, 25), "Connection");
            m_LoginButton.OnClicked = OnLoginClick;
            this.AddGuiScene(m_LoginButton);
        }

        public void OnLoginClick()
        {
            m_LoginButton.Text = "Connection";
            if (Network.NetManager.Instance().Connect("127.0.0.1", 5123))
            {
                Packet.SendAsync(new LoginPacket("test", "test"), Network.NetManager.Instance().Socket);
            }
        }
    }
}
