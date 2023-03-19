using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoEngine.Engine.Core
{
    public class AnimationManager
    {
        string animationPath;
        Dictionary<string, Animation> animations;
        Animation activeAnimation;
        double activeAnimationStartTime;
        Texture2D noTexture;

        public AnimationManager(string animationPath)
        {
            this.animationPath = animationPath;
            animations = new Dictionary<string, Animation>();
            noTexture = EngineInterface.LoadContent<Texture2D>("Assets/Graphics/no_texture");
        }

        public void AddStaticImage(string name)
        {
            animations.Add(name, new Animation(animationPath, name));
            if (activeAnimation == null)
                StartAnimation(name);
        }

        public void AddAnimation(string name, int fps, bool loopable)
        {
            animations.Add(name, new Animation(animationPath, name, fps, loopable));
        }

        public void StartAnimation(string name)
        {
            if (activeAnimation == null || !name.Equals(activeAnimation.name))
            {
                animations.TryGetValue(name, out activeAnimation);
                activeAnimationStartTime = Time.now;
            }
        }

        public Texture2D GetCurrentFrame()
        {
            if (activeAnimation != null)
                return activeAnimation.GetCurrentFrame(Time.now - activeAnimationStartTime);
            return noTexture;
        }
    }

    public class Animation
    {
        public const int DEFAULT_FPS = 12;
        public string name { get; private set; }
        int frameCount;
        Texture2D[] frames;
        int fps;
        bool loopable;

        public Animation(string animationPath, string animationName, int fps, bool loopable)
        {
            frames = LoadFrames(animationPath, animationName);
            name = animationName;
            this.fps = fps;
            frameCount = frames.Length;
            this.loopable = loopable;
        }

        //constructor for static images
        public Animation(string spritePath, string spriteName)
        {
            frames = LoadStaticImage(spritePath, spriteName);
            name = spriteName;
            fps = DEFAULT_FPS;
            frameCount = 1;
            loopable = true;
        }

        Texture2D[] LoadStaticImage(string imagePath, string imageName)
        {
            Texture2D[] image = new Texture2D[1];
            string path = string.Format("Assets/Graphics/{0}/{1}", imagePath, imageName);
            image[0] = EngineInterface.LoadContent<Texture2D>(path);
            return image;
        }

        Texture2D[] LoadFrames(string animationPath, string animationName)
        {
            List<Texture2D> frames = new List<Texture2D>();
            int frameNumber = 0;
            string path = string.Format("Assets/Graphics/{0}/{1}/{1}{2,4:D4}", animationPath, animationName, frameNumber++);
            Texture2D t = EngineInterface.LoadContent<Texture2D>(path);
            while (t != null)
            {
                frames.Add(t);
                try
                {
                    path = string.Format("Assets/Graphics/{0}/{1}/{1}{2,4:D4}", animationPath, animationName, frameNumber++);
                    t = EngineInterface.LoadContent<Texture2D>(path);
                }
                catch (Exception) { t = null; }
            }

            return frames.ToArray();
        }

        public Texture2D GetCurrentFrame(double timeSinceAnimationStart)
        {
            if (loopable)
                return frames[(int)(timeSinceAnimationStart * fps) % frameCount];
            if ((int)timeSinceAnimationStart * fps > frameCount) return frames[frames.Length - 1];
            return frames[(int)(timeSinceAnimationStart * fps)];
        }
    }
}