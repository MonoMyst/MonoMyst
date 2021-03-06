﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class Canvas : Widget
    {
        internal protected override void Initialize ()
        {
            base.Initialize ();

            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            Color = Color.Transparent;
        }

        internal protected override void Draw (SpriteBatch spriteBatch)
        {
            Size = spriteBatch.GraphicsDevice.Viewport.Bounds.Size.ToVector2 ();
            Position = Vector2.Zero;

            foreach (Widget w in Children)
                w.Draw (spriteBatch);
        }
    }
}
