using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pilleripeli
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private SceneAsset tutorialScene;
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
            SceneManager.LoadScene(tutorialScene.name);
        }
        public void OnSettingsTapped()
        {
            Debug.Log("Settings button tapped");
        }
    }
}

