using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace MonoEngine.Engine.Core
{
    public class Camera
    {
        public Vector2 position;
        AudioListener audioListener;

        float ppu = 100;
        public float pixelsPerUnit
        {
            get { return ppu; }
            set
            {
                viewWindow.X = EngineInterface.WINDOW_WIDTH / value;
                viewWindow.Y = EngineInterface.WINDOW_HEIGHT / value;
                ppu = value;
            }
        }
        protected Vector2 viewWindow;
        protected Scene scene;

        public Camera(Scene s)
        {
            scene = s;
            audioListener = new AudioListener();
        }

        // bounds refers to the edges of the texture (in game units) in world space
        public void DrawWorld(SpriteBatch sb, Texture2D tex, Vector3 position, Vector2 scale, float angle, Vector2 origin, Color colorMask, bool flipped)
        {
            Vector2 posRelativeToCameraInGameUnits = new Vector2(position.X, position.Y) - this.position;
            Vector2 posRelativeToCameraInPixels = posRelativeToCameraInGameUnits * pixelsPerUnit;

            Vector2 topLeftCorner = posRelativeToCameraInPixels + new Vector2(EngineInterface.WINDOW_WIDTH / 2, EngineInterface.WINDOW_HEIGHT / 2);
            Vector2 convertedSize = new Vector2(scale.X, scale.Y) * pixelsPerUnit;

            sb.Draw(tex, new Rectangle(topLeftCorner.ToPoint(), convertedSize.ToPoint()), null, colorMask, angle, origin, flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }

        // bounds refers to edges of texture (in pixels) in screen space
        public void DrawUI(SpriteBatch sb, Texture2D tex, Rectangle bounds, Color colorMask)
        {
            sb.Draw(tex, bounds, colorMask);
        }

        public Vector2 ScreenCoordsToWorldSpace(Vector2 screenPos)
        {
            Vector2 screenCoordsInGameUnits = screenPos / pixelsPerUnit;
            return position + screenCoordsInGameUnits - new Vector2(EngineInterface.WINDOW_WIDTH, EngineInterface.WINDOW_HEIGHT) / (2 * pixelsPerUnit);
        }

        public virtual void Update()
        {

        }
    }
}
