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
        public SoundEffect BossMusic;
        public SoundEffectInstance MusicInstance;
        public SoundEffectInstance BossMusicInstance;

        public SoundEffect Jump;
        private bool readyJump;

        public SoundEffect Death;
        public SoundEffect ItemPickup;

        //Sounds for player character ranged attack
        public SoundEffect DavisShootSound;
        public SoundEffect WoodyShootSound;
        public SoundEffect BatShootSound;
        public SoundEffect JulianShootSound;

        public SoundEffect CharacterSelectSound;

        public SoundEffect DoorOpenSound;
        //public SoundEffect DoorCloseSound;

        public SoundEffect DrinkMilkSound;

        public SoundEffect Explode1Sound;
        //public SoundEffect Explode2Sound;
        //public SoundEffect Explode3Sound;
        //public SoundEffect Explode4Sound;

        public SoundEffect GameOverSound;

        public SoundEffect HealSound;

        public SoundEffect KeyPickupSound;

        public SoundEffect KiyahOneSound;
        public SoundEffect KiyahTwoSound;
        //public SoundEffect KiyahThreeSound;

        public SoundEffect PhysicalAttackCollisionSoundOne;

        public SoundEffect TeleportSound;

        public SoundEffect WinSound;

        public void Load(ContentManager content)
        {
            Music = content.Load<SoundEffect>("SoundFX/RegularGameMusic");
            MusicInstance = Music.CreateInstance();
            MusicInstance.IsLooped = true;

            BossMusic = content.Load<SoundEffect>("SoundFX/BossFightMusic");
            BossMusicInstance = BossMusic.CreateInstance();
            BossMusicInstance.IsLooped = true;

            Jump = content.Load<SoundEffect>("SoundFX/Jump");
            readyJump = true;

            Death = content.Load<SoundEffect>("SoundFX/Death");
            ItemPickup = content.Load<SoundEffect>("SoundFX/ItemPickup");

            /*Sounds from Little Fighter 2 (same game where we got the sprites)*/
            DavisShootSound = content.Load<SoundEffect>("SoundFX/DavisShootSound");
            WoodyShootSound = content.Load<SoundEffect>("SoundFX/WoodyShootSound");
            BatShootSound = content.Load<SoundEffect>("SoundFX/BatShootSound");
            JulianShootSound = content.Load<SoundEffect>("SoundFX/JulianShootSound");

            DrinkMilkSound = content.Load<SoundEffect>("SoundFX/DrinkMilkSound");

            CharacterSelectSound = content.Load<SoundEffect>("SoundFX/CharacterSelectSound");
            GameOverSound = content.Load<SoundEffect>("SoundFX/GameOverSound");

            HealSound = content.Load<SoundEffect>("SoundFX/HealSound");

            KeyPickupSound = content.Load<SoundEffect>("SoundFX/KeyPickupSound");

            KiyahOneSound = content.Load<SoundEffect>("SoundFX/KiyahOneSound");
            KiyahTwoSound = content.Load<SoundEffect>("SoundFX/KiyahTwoSound");
            //KiyahThreeSound = content.Load<SoundEffect>("SoundFX/KiyahThreeSound");

            PhysicalAttackCollisionSoundOne = content.Load<SoundEffect>("SoundFX/PhysicalAttackCollisionSoundOne");

            TeleportSound = content.Load<SoundEffect>("SoundFX/TeleportSound");

            WinSound = content.Load<SoundEffect>("SoundFX/WinSound");

            /*Sounds taken from Mojang's Minecraft*/
            DoorOpenSound = content.Load<SoundEffect>("SoundFX/DoorOpenSound");
            //DoorCloseSound = content.Load<SoundEffect>("SoundFX/DoorCloseSound");

            Explode1Sound = content.Load<SoundEffect>("SoundFX/Explode1Sound");
            //Explode2Sound = content.Load<SoundEffect>("SoundFX/Explode2Sound");
            //Explode3Sound = content.Load<SoundEffect>("SoundFX/Explode3Sound");
            //Explode4Sound = content.Load<SoundEffect>("SoundFX/Explode4Sound");

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

        public void PlayTeleportSound()
        {
            TeleportSound.Play();
        }

        public void PlayDavisYell()
        {
            KiyahTwoSound.Play();
        }

        public void PlayWoodyYell()
        {
            KiyahOneSound.Play();
        }

        public void PlayDoorOpen()
        {
            DoorOpenSound.Play();
        }

        public void PlayDavisShootBullet()
        {
            DavisShootSound.Play();
        }

        public void PlayWoodyShootBullet()
        {
            WoodyShootSound.Play();
        }

        public void PlayBatShootBullet()
        {
            BatShootSound.Play();
        }

        public void PlayJulianShootBullet()
        {
            JulianShootSound.Play();
        }

        public void PlayCharacterSelection()
        {
            CharacterSelectSound.Play();
        }

        public void PlayExplodeSound1()
        {
            Explode1Sound.Play();
        }

        public void PlayGameOverMusic()
        {
            GameOverSound.Play();
        }

        public void PlayWinMusic()
        {
            WinSound.Play();
        }

        public void PlayKeyPickUp()
        {
            KeyPickupSound.Play();
        }

        public void PlayDrinkMilk()
        {
            DrinkMilkSound.Play();
        }

        public void PlayHealSound()
        {
            HealSound.Play();
        }

        public void PlayPhysicsCollision()
        {
            PhysicalAttackCollisionSoundOne.Play();
        }
    }
}
