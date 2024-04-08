using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pilleripeli
{
    public class MenuSceneLoader : MonoBehaviour
    {
        public void LoadSceneByName()
        {
            PlayerPrefs.SetString("Lang", "Eng");
            SceneManager.LoadScene("Assets/Scenes/MainMenu.unity");
        }
    }
}
