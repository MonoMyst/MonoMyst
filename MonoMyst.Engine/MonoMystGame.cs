﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;
using System.IO;
using System;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine
{
    public class MonoMystGame : Game
    {
        public static Scene Scene { get; private set; }

        private SpriteBatch spriteBatch;

        public static Camera Camera { get; private set; }

        protected GraphicsDeviceManager GraphicsDeviceManager { get; private set; }

        private RasterizerState rasterizerState = new RasterizerState () { ScissorTestEnable = true };

        public static XNBContentManager EmbeddedContent { get; private set; }

        public static GraphicUtilities GraphicUtilities { get; private set; }

        public UIHost UI { get; private set; }

        public MonoMystGame ()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager (this);

            IsMouseVisible = true;

            Camera = new Camera (GraphicsDevice)
            {
                Position = Vector2.Zero
            };
        }

        protected override void Initialize ()
        {
            base.Initialize ();
        }

        protected override void LoadContent()
        {
            base.LoadContent ();

            spriteBatch = new SpriteBatch (GraphicsDevice);

            UI = new UIHost (this);            

            EmbeddedContent = new XNBContentManager (GraphicsDevice);
            GraphicUtilities = new GraphicUtilities ();
        }

        protected override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            Scene.Update (deltaTime);

            UI.Update (deltaTime);

            if (Keyboard.GetState ().IsKeyDown (Keys.Left))
                Camera.Position.X -= 50f * deltaTime;
            if (Keyboard.GetState ().IsKeyDown (Keys.Up))
                Camera.Position.Y -= 50f * deltaTime;
            if (Keyboard.GetState ().IsKeyDown (Keys.Right))
                Camera.Position.X += 50f * deltaTime;
            if (Keyboard.GetState ().IsKeyDown (Keys.Down))
                Camera.Position.Y += 50f * deltaTime;
        }

        protected override void Draw (GameTime gameTime)
        {
            GraphicsDevice.Clear (Scene.ClearColor);

            spriteBatch.Begin (transformMatrix: Camera.Transform);

            Scene.Draw (spriteBatch);

            spriteBatch.End ();

            spriteBatch.Begin (sortMode: SpriteSortMode.FrontToBack, rasterizerState: rasterizerState);

            UI.Draw (spriteBatch);

            spriteBatch.End ();

            base.Draw (gameTime);
        }

        /// <summary>
        /// Switches to the next scene.
        /// </summary>
        public void NextScene (Scene scene)
        {
            Scene = scene;
            Scene.Current = Scene;
            Scene.Initialize ();
        }
    }
}