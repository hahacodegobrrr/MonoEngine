using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Engine.Core;

namespace MonoEngine.Engine.Core
{
    public class GameObject
    {
        static ulong nextID = 0;
        public ulong ID { get; private set; }
        public string name { get; private set; }
        public string spritePath { get; private set; }
        public Vector3 position;
        public float angle; // in radians; warning: +angle --> rotate clockwise because y axis is flipped
        public Vector2 scale;
        public Scene scene;
        public bool flipSprite;
        public Vector2 origin; //normalized texture pixel coordinates of rotation axis (0 -> 1 in x and y directions)

        public bool active;

        public AudioPlayer audioPlayer;
        public Renderer renderer;


        public GameObject(string name, string spritePath, Scene scene, bool addToScene)
        {
            if (addToScene)
                scene.AddGameObject(this);
            this.name = name;
            this.scene = scene;
            this.spritePath = spritePath;
            ID = nextID++;
            position = new Vector3();
            angle = 0;
            scale = new Vector2();
            renderer = new SpriteRenderer(this);
            active = true;
            audioPlayer = new AudioPlayer();
        }

        public void Activate()
        {
            active = true;
        }

        public void Deactivate()
        {
            active = false;
        }

        public virtual void Update() { }

        public virtual void Draw(SpriteBatch sb)
        {
            renderer.Draw(sb);
        }
    }
}
