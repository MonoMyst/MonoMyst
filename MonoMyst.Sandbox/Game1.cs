﻿using MonoMyst.Engine;
using MonoMyst.Engine.ECS;

namespace MonoMyst.Sandbox
{
    public class Game1 : MonoMystGame
    {
        protected override void Initialize ()
        {
            base.Initialize ();

            Scene scene = new MainScene (this, GraphicsDeviceManager.GraphicsDevice);
            NextScene (scene);
        }
    }
}
