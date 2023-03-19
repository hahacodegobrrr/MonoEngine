using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoEngine.Core
{
    public static class SceneManager
    {

        static Dictionary<string, Scene> scenes;
        static Scene activeScene;

        public static void Initialize()
        {
            scenes = new Dictionary<string, Scene>();
        }

        public static void AddScene(Scene s)
        {
            scenes.Add(s.name, s);
            if (activeScene == null)
                activeScene = s;
        }

        public static void SetActiveScene(string name)
        {
            activeScene = GetScene(name);
            activeScene.Activate();
        }

        public static Scene GetScene(string name)
        {
            Scene scene;
            scenes.TryGetValue(name, out scene);
            return scene;
        }

        public static void Update()
        {
            if (activeScene == null)
                return;
            activeScene.Update();
        }

        public static void Draw(SpriteBatch sb)
        {
            if (activeScene == null)
                return;
            activeScene.Draw(sb);
        }
    }
}
