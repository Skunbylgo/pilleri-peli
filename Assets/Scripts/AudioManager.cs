using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] happyAudioclips;
        [SerializeField]
        private AudioClip[] tiredAudioclips;
        [SerializeField]
        private AudioClip[] hurryAudioclips;
        [SerializeField]
        private AudioClip[] surprisedAudioclips;
        [SerializeField]
        private AudioClip[] sadAudioclips;
        [SerializeField]
        private AudioClip[] coffeeAudioclips;
        [SerializeField]
        private AudioClip[] administerAudioclips;
        [SerializeField]
        private AudioClip[] pillbottleAudioclips;
        [SerializeField]
        private AudioClip drinkAudioclip;
        private AudioSource audioSource;
        private float volumeScale;

        // Start is called before the first frame update
        void Start()
        {
            volumeScale = PlayerPrefs.GetFloat("Volume");
            audioSource = this.GetComponent<AudioSource>();
        }
        public void PlayDrinkClip()
        {
            PlayClip(drinkAudioclip);
        }
        public void PlayHappyClip()
        {
            PlayClip(happyAudioclips[Random.Range(0, happyAudioclips.Length)]);
        }
        public void PlayTiredClip()
        {
            PlayClip(tiredAudioclips[Random.Range(0, tiredAudioclips.Length)]);
        }
        public void PlayHurryClip()
        {
            PlayClip(hurryAudioclips[Random.Range(0, hurryAudioclips.Length)]);
        }
        public void PlaySurprisedClip()
        {
            PlayClip(surprisedAudioclips[Random.Range(0, surprisedAudioclips.Length)]);
        }
        public void PlaySadClip()
        {
            PlayClip(sadAudioclips[Random.Range(0, sadAudioclips.Length)]);
        }
        public void PlayCoffeeClip()
        {
            PlayClip(coffeeAudioclips[Random.Range(0, coffeeAudioclips.Length)]);
        }
        public void PlayPillClip()
        {
            PlayClip(pillbottleAudioclips[Random.Range(0, pillbottleAudioclips.Length)]);
        }
        public void PlayAdministerClip()
        {
            PlayClip(administerAudioclips[Random.Range(0, administerAudioclips.Length)]);
        }
        private void PlayClip(AudioClip audioClip)
        {
            Debug.Log($"Playing AudioClip {audioClip.name}");
            audioSource.PlayOneShot(audioClip);
        }
    }
}
