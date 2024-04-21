using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pilleripeli
{
    public class FiMenuSceneLoader : MonoBehaviour
    {
        public void LoadSceneByName()
        {
            SceneManager.LoadScene("Assets/Scenes/MainMenu.unity");
        }
    }
}
