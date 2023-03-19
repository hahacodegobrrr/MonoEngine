using Microsoft.Xna.Framework.Graphics;
using MonoEngine.UI;
using System.Collections.Generic;

namespace MonoEngine.Core
{
    public abstract class Scene
    {
        public Camera camera { get; set; }
        public string name { get; private set; }
        List<GameObject> gameObjects;
        List<UIObject> uiObjects;

        protected AudioPlayer audioPlayer;

        public Scene(string name)
        {
            this.name = name;
            audioPlayer = new AudioPlayer();
            gameObjects = new List<GameObject>();
            uiObjects = new List<UIObject>();
            camera = new Camera(this);
        }

        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }

        public GameObject FindGameObject(string name)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].name.Equals(name))
                {
                    return gameObjects[i];
                }
            }

            return null;
        }

        public void AddUIObject(UIObject uiObject)
        {
            uiObjects.Add(uiObject);
        }

        public void RemoveUIObject(UIObject uiObject)
        {
            uiObjects.Remove(uiObject);
        }

        public UIObject FindUIObject(string name)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (uiObjects[i].name.Equals(name))
                {
                    return uiObjects[i];
                }
            }

            return null;
        }

        public virtual void Activate() { }

        public virtual void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
                gameObjects[i].Update();
            for (int i = 0; i < uiObjects.Count; i++)
                uiObjects[i].Update();
            camera.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            gameObjects.Sort((g1, g2) => g1.position.Z.CompareTo(g2.position.Z)); //sort gameobjects before drawing
            for (int i = 0; i < gameObjects.Count; i++)
                gameObjects[i].Draw(sb);

            uiObjects.Sort((g1, g2) => g1.position.Z.CompareTo(g2.position.Z)); //sort uiobjects before drawing
            for (int i = 0; i < uiObjects.Count; i++)
                uiObjects[i].Draw(sb);
        }

        public abstract void ButtonClicked(Button b);
    }
}
