using Microsoft.Xna.Framework;
using MonoEngine.Engine.Core;
using MonoEngine.Engine.UI;

namespace MonoEngine.Engine.UI
{
    public abstract class UIObject : GameObject
    {
        protected Rectangle bounds;

        public UIObject(string name, string spritePath, Scene scene, bool addToScene) : base(name, spritePath, scene, addToScene)
        {
            scene.AddUIObject(this);
            renderer = new UIRenderer(this);
        }
    }
}
