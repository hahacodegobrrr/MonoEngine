using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace MonoEngine.Engine.Core
{
    public class AudioPlayer
    {
        Dictionary<string, Song> bgm;
        Dictionary<string, SoundEffect> sfx;
        AudioEmitter emitter;

        public AudioPlayer()
        {
            bgm = new Dictionary<string, Song>();
            sfx = new Dictionary<string, SoundEffect>();
            emitter = new AudioEmitter();
        }

        public void AddBGM(string name)
        {
            string path = string.Format("Assets/Audio/bgm/{0}", name);
            bgm.Add(name, EngineInterface.LoadContent<Song>(path));
        }

        public void AddSFX(string name)
        {
            string path = string.Format("Assets/Audio/sfx/{0}", name);
            sfx.Add(name, EngineInterface.LoadContent<SoundEffect>(path));
        }

        public bool BGMPlaying()
        {
            return MediaPlayer.State == MediaState.Playing;
        }

        public void PlayBGM(string name, bool looped)
        {
            Song song;
            bgm.TryGetValue(name, out song);
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = looped;
        }

        public void PlaySFX(string name)
        {
            SoundEffect s;
            sfx.TryGetValue(name, out s);
            SoundEffectInstance sfxi = s.CreateInstance();
            sfxi.Play();
        }
    }
}
