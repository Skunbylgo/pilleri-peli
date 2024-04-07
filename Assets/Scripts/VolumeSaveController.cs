using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mobiiliesimerkki
{
    public class VolumeSaveController : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider = null;
        [SerializeField] private Text volumeTextUI = null;

        private void Start()
        {
            LoadValues();
        }

        public void VolumeSlider(float volume)
        {
            volumeTextUI.text = volume.ToString("0.0");
        }

        public void SaveVolumeButton()
        {
            float volumeValue = volumeSlider.value;
            PlayerPrefs.SetFloat("Volume", volumeValue);
            LoadValues();
        }

        void LoadValues()
        {
            float volumeValue = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = volumeValue;
            AudioListener.volume = volumeValue;
        }
    }
}
