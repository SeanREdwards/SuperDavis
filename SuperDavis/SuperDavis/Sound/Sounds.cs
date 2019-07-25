using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

/*Class to hold game sound effects, will be data driven in the refactor from file.*/
namespace SuperDavis.Sound
{
    sealed class Sounds
    {
        public static Sounds Instance { get; } = new Sounds();
        private Sounds() { }

        public SoundEffect Music;
        public SoundEffectInstance MusicInstance;
        public SoundEffect Jump;
        public SoundEffect Death;
        public SoundEffect ItemPickup;

        private bool readyJump = true;

        public void Load(ContentManager content)
        {
            Music = content.Load<SoundEffect>("SoundFX/MarioMusic");
            MusicInstance = Music.CreateInstance();
            MusicInstance.IsLooped = true;
            Jump = content.Load<SoundEffect>("SoundFX/Jump");
            Death = content.Load<SoundEffect>("SoundFX/Death");
            ItemPickup = content.Load<SoundEffect>("SoundFX/ItemPickup");
            readyJump = true;
        }

        public void PlayJump()
        {
            if (readyJump)
            {
                readyJump = false;
                Jump.Play();
            }
        }

        public void SetJump()
        {
            readyJump = true;
        }

        public void PlayItemPickUp()
        {
            ItemPickup.Play();
        }

    }
}
