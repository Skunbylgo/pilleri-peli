using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pilleripeli
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadSceneByName()
        {
            SceneManager.LoadScene("Assets/Scenes/Settings.unity");
        }
    }
}
