using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] gameMusic;
        [SerializeField]
        private AudioClip[] sleepMusic;
        [SerializeField]
        private AudioClip[] menuMusic;
        [SerializeField]
        private AudioClip[] deathMusic;
        private AudioSource audioSource;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = this.GetComponent<AudioSource>();
        }

        public void PlayGameMusic()
        {
            PlayMusic(gameMusic[Random.Range(0,gameMusic.Length)]);
        }
        public void PlaySleepMusic()
        {
            PlayMusic(sleepMusic[Random.Range(0,sleepMusic.Length)]);
        }
        public void PlayMenuMusic()
        {
            PlayMusic(menuMusic[Random.Range(0,menuMusic.Length)]);
        }
        public void PlayDeathMusic()
        {
            /*
            in comments until music is imported
            PlayMusic(deathMusic[Random.Range(0,deathMusic.Length)]);
            */
            PlayMusic(null);
        }
        private void PlayMusic(AudioClip audioClip)
        {
            audioSource.Stop();
            if(audioClip.Equals(null))
                return;
            audioSource.clip = audioClip;
            audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
            audioSource.Play();
        }
        public void ChangeVolume(float value)
        {
            audioSource.volume = value;
        }
    }
}
