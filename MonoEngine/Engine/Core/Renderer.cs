using Microsoft.Xna.Framework.Graphics;

namespace MonoEngine.Engine.Core
{
    public abstract class Renderer
    {
        public AnimationManager animationManager { get; protected set; }
        protected GameObject parent;

        public Renderer(GameObject parent)
        {
            this.parent = parent;
            animationManager = new AnimationManager(parent.spritePath);
        }

        public abstract void Draw(SpriteBatch sb);
    }
}
