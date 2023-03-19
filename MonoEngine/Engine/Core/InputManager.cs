using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoEngine.Engine.Core
{
    public static class InputManager
    {
        static KeyboardState keyStateLastUpdate;
        static Keys[] currentPressedKeys;
        static Keys[] pressedKeysLastUpdate;
        static MouseState mouseState;
        static MouseState mouseStateLastFrame;

        public static Point mousePosition { get; private set; }

        public static void Initialize()
        {
            currentPressedKeys = new Keys[0];
            pressedKeysLastUpdate = new Keys[0];
        }

        public static void Update()
        {
            keyStateLastUpdate = Keyboard.GetState();
            pressedKeysLastUpdate = currentPressedKeys;
            currentPressedKeys = keyStateLastUpdate.GetPressedKeys();
            mouseStateLastFrame = mouseState;
            mouseState = Mouse.GetState();
            mousePosition = mouseState.Position;
        }

        public static bool KeyPressed(Keys key)
        {
            return keyStateLastUpdate.IsKeyDown(key);
        }

        public static bool KeyPressedThisFrame(Keys key)
        {
            if (pressedKeysLastUpdate.Contains(key))
                return false;
            return currentPressedKeys.Contains(key);
        }

        public static bool LeftMousePressed()
        {
            return mouseState.LeftButton == ButtonState.Pressed && EngineInterface.IsActive();
        }

        public static bool LeftMousePressedThisFrame()
        {
            return mouseState.LeftButton == ButtonState.Pressed && mouseStateLastFrame.LeftButton == ButtonState.Released && EngineInterface.IsActive();
        }

        public static bool LeftMouseReleasedThisFrame()
        {
            return mouseState.LeftButton == ButtonState.Released && mouseStateLastFrame.LeftButton == ButtonState.Pressed && EngineInterface.IsActive();
        }
    }

}
