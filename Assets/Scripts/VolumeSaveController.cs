using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace pilleripeli
{
    public class VolumeSaveController : MonoBehaviour
    {
        [SerializeField] private Slider effectVolumeSlider = null;
        [SerializeField] private Text effectVolumeTextUI = null;

        [SerializeField] private Slider musicVolumeSlider = null;
        [SerializeField] private Text musicVolumeTextUI = null;

        [SerializeField] private Slider volumeSlider = null;
        [SerializeField] private Text volumeTextUI = null;

        private void Start()
        {
            LoadValues();
        }

        public void VolumeSlider(float volume)
        {
            volumeTextUI.text = (volume * 100.0f).ToString("000");
        }

        public void EffectVolumeSlider(float volume)
        {
            effectVolumeTextUI.text = (volume * 100.0f).ToString("000");
        }

        public void MusicVolumeSlider(float volume)
        {
            ChangeMusicVolume(volume);
            musicVolumeTextUI.text = (volume * 100.0f).ToString("000");
        }

        public void SaveVolumeButton()
        {
            float volumeValue = volumeSlider.value;
            float effectVolumeValue = effectVolumeSlider.value;
            float musicVolumeValue = musicVolumeSlider.value;
            PlayerPrefs.SetFloat("Volume", volumeValue);
            PlayerPrefs.SetFloat("EffectVolume", effectVolumeValue);
            PlayerPrefs.SetFloat("MusicVolume", musicVolumeValue);
            LoadValues();
            ChangeMusicVolume(musicVolumeValue);
        }

        void LoadValues()
        {
            float volumeValue = PlayerPrefs.GetFloat("Volume");
            float effectVolumeValue = PlayerPrefs.GetFloat("EffectVolume");
            float musicVolumeValue = PlayerPrefs.GetFloat("MusicVolume");
            volumeSlider.value = volumeValue;
            effectVolumeSlider.value = effectVolumeValue;
            musicVolumeSlider.value = musicVolumeValue;
            AudioListener.volume = volumeValue;
        }
        void ChangeMusicVolume(float value)
        {
            try
            {
                GameObject.Find("MusicManager").GetComponent<MusicManager>().ChangeVolume(value);
            }
            catch (System.Exception)
            {
                Debug.Log("Couldn't find MusicManager");
            }
        }
    }
}
