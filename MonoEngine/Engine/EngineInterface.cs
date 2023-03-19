using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoEngine.Engine
{

    //interface between the game's main class and the engine
    public static class EngineInterface
    {
        public static int WINDOW_WIDTH = 1280;
        public static int WINDOW_HEIGHT = 1080;
        public static int TARGET_FPS = 60;

        private static Game game;

        public static void InitializeEngine(Game gameClass, int windowWidth, int windowHeight, int targetFps)
        {
            game = gameClass;
            WINDOW_WIDTH = windowWidth;
            WINDOW_HEIGHT = windowHeight;
            TARGET_FPS = targetFps;
        }

        public static T LoadContent<T>(string path)
        {
            if (game == null)
                return default;
            return game.Content.Load<T>(path);
        }

        public static bool IsActive()
        {
            return game != null && game.IsActive;
        }
    }
}
