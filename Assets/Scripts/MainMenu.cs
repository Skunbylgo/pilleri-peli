using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pilleripeli
{
    public class MainMenu : MonoBehaviour
    {
        void Start()
        {
            var musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
            musicManager.PlayMenuMusic();
        }
        public void OnPlayTapped()
        {
            Debug.Log("Play button tapped");
            SceneManager.LoadScene("SampleScene");
        }
        public void OnInstructionsTapped()
        {
            Debug.Log("Instructions button tapped");
            SceneManager.LoadScene("HowToPlay");
        }
        public void OnSettingsTapped()
        {
            Debug.Log("Settings button tapped");
        }
    }
}

