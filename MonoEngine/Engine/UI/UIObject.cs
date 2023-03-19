using Microsoft.Xna.Framework;
using MonoEngine.Core;

namespace MonoEngine.UI
{
    public abstract class UIObject : GameObject
    {
        protected Rectangle bounds;

        public UIObject(string name, string spritePath, Scene scene, bool addToScene) : base(name, spritePath, scene, addToScene) {
            scene.AddUIObject(this);
            renderer = new UIRenderer(this);
        }
    }
}
