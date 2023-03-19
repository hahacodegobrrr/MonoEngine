using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Core;
using MonoEngine.Math;

namespace MonoEngine.UI
{
    public class Button : UIObject {

        UIButtonState state;
        bool clickInitiated;

        public Button(string name, string spritePath, Scene scene) : base(name, spritePath, scene, true) {
            state = UIButtonState.Off;
            renderer.animationManager.AddStaticImage(name + "_base");
            renderer.animationManager.StartAnimation(name + "_base");
            scale = new Vector2(1280, 720);
            //renderer.animationManager.AddAnimation(name + "_hover", Animation.DEFAULT_FPS, true);
            //renderer.animationManager.AddAnimation(name + "_clicked", Animation.DEFAULT_FPS, true);
        }

        public override void Update() {
            if (!active) return;
            bounds = new Rectangle((int)position.X, (int)position.Y, (int)scale.X, (int)scale.Y);
            
            //state logic
            if (clickInitiated)
                state = UIButtonState.Click;
            else if (Collisions.Overlapping(InputManager.mousePosition, bounds))
                state = UIButtonState.Hover;
            else
                state = UIButtonState.Off;
            
            //button logic
            if (Collisions.Overlapping(InputManager.mousePosition, bounds)) {
                if (InputManager.LeftMousePressedThisFrame())
                    clickInitiated = true;
                if (InputManager.LeftMouseReleasedThisFrame() && clickInitiated) {
                    clickInitiated = false;
                    OnClick();
                }
            } else {
                if (InputManager.LeftMouseReleasedThisFrame() || InputManager.LeftMousePressedThisFrame())
                    clickInitiated = false;
            }
        }

        public override void Draw(SpriteBatch sb) {
            Color mask;
            switch (state) {
                case UIButtonState.Hover:
                    mask = new Color(230, 230, 230);
                    break;
                case UIButtonState.Click:
                    mask = Color.White;
                    break;
                default:
                    mask = new Color(200, 200, 200);
                    break;
            }

            ((UIRenderer)renderer).Draw(sb, mask);
        }

        public void OnClick() {
            scene.ButtonClicked(this);
        }
    }

    public enum UIButtonState {
        Off,
        Hover,
        Click
    }
}
