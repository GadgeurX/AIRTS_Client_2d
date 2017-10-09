using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRTS_Client_2d.Scene
{
    public class SplashScene : Scene
    {
        public override void Update(GameTime p_GameTime)
        {
            SceneManager.Instance().SetScene("Login");
            base.Update(p_GameTime);
        }
    }
}
