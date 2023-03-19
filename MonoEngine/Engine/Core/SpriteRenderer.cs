using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoEngine.Engine.Core
{
    public class SpriteRenderer : Renderer
    {

        public SpriteRenderer(GameObject parent) : base(parent) { }

        public override void Draw(SpriteBatch sb)
        {
            Draw(sb, Color.White);
        }

        public void Draw(SpriteBatch sb, Color colorMask)
        {
            Texture2D t = animationManager.GetCurrentFrame();
            Vector2 pixelOrigin = new Vector2(t.Width * parent.origin.X, t.Height * parent.origin.Y);
            parent.scene.camera.DrawWorld(sb, t, parent.position, parent.scale, parent.angle, pixelOrigin, colorMask, parent.flipSprite);
        }
    }
}
