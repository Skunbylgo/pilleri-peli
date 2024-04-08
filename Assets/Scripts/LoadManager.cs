using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace pilleripeli
{
    public class LoadManager : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private GameObject fader;
        private string sceneToLoad;
        void Start()
        {
            if(PlayerPrefs.GetString("Lang") == "Eng")
            {
                Debug.Log("Loading English scene");
                sceneToLoad = "MainMenu";
            }
            else if(PlayerPrefs.GetString("Lang") == "Fin")
            {
                Debug.Log("Loading Finnish scene");
                sceneToLoad = "MainMenuFi";
            }
            else
            {
                Debug.Log("Lang setting missing from PlayerPrefs, setting to \"Eng\"");
                PlayerPrefs.SetString("Lang", "Eng");
                Debug.Log("Loading English scene");
                sceneToLoad = "MainMenu";
            }
            StartCoroutine(FadeIn());
        }
        IEnumerator FadeIn()
        {
            float timer = 1.0f;
            float normalizedTime = 1.0f;
            while(normalizedTime > 0.0f)
            {
                normalizedTime -= Time.deltaTime / timer;
                fader.GetComponent<Image>().color = new Color(0,0,0,normalizedTime);
                yield return null;
            }
            StartCoroutine(FadeOut());
        }
        IEnumerator FadeOut()
        {
            // 3 second timer
            float timer = 3.0f;
            float normalizedTime = 0.0f;
            while(normalizedTime < 1.0f)
            {
                normalizedTime += Time.deltaTime / timer;
                fader.GetComponent<Image>().color = new Color(0,0,0,normalizedTime);
                yield return null;
            }
            SceneManager.LoadScene(sceneToLoad);
            
        }
    }
}
