using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoEngine.Engine.Core;

namespace MonoEngine.Engine.UI
{
    public class UIRenderer : Renderer
    {
        public UIRenderer(UIObject parent) : base(parent) { }

        public override void Draw(SpriteBatch sb)
        {
            Draw(sb, Color.White);
        }

        public void Draw(SpriteBatch sb, Color colorMask)
        {
            parent.scene.camera.DrawUI(sb, animationManager.GetCurrentFrame(), new Rectangle((int)parent.position.X, (int)parent.position.Y, (int)parent.scale.X, (int)parent.scale.Y), colorMask);
        }
    }
}
