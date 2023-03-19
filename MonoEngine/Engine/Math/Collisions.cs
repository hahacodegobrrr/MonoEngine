using Microsoft.Xna.Framework;

namespace MonoEngine.Math {
    public static class Collisions {
        public static bool Overlapping(Point p, Rectangle r) {
            return (p.X < r.Right && p.X > r.Left && p.Y > r.Top && p.Y < r.Bottom);
        }
    }
}
