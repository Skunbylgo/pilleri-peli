using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    public class LanguageSetter : MonoBehaviour
    {
        public void SetLanguage(string lang)
        {
            PlayerPrefs.SetString("Lang", lang);
        }
    }
}
