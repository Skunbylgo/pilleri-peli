using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pilleripeli
{
    public class MainMenu : MonoBehaviour
    {
        public void OnPlayTapped()
        {
            Debug.Log("Play button tapped");
            SceneManager.LoadScene("SampleScene");
        }
        public void OnQuitTapped()
        {
            Debug.Log("Quit button tapped");
            Application.Quit();
        }
        public void OnSettingsTapped()
        {
            Debug.Log("Settings button tapped");
        }
    }
}

