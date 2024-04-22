using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace pilleripeli
{
    public class LocalizeText : MonoBehaviour
    {
        [SerializeField]
        private GameObject textEng;
        [SerializeField]
        private GameObject textFin;
        void OnEnable()
        {
            var lang = PlayerPrefs.GetString("Lang");
            if(lang.Equals("Fin"))
            {
                textFin.SetActive(true);
                textEng.SetActive(false);
            }
            else 
            {
                textFin.SetActive(false);
                textEng.SetActive(true);
            }
        }
    }
}
