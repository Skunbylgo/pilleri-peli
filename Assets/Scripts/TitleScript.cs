using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

namespace pilleripeli
{
    public class TitleScript : MonoBehaviour
    {
        void Start()
        {
            var lang = PlayerPrefs.GetString("Lang");
            SetTitle(lang);
        }
        public void SetTitle(string lang)
        {
            var title = GameObject.Find("Title");
            var spriteLib = title.GetComponent<SpriteLibrary>();
            title.GetComponent<Image>().sprite = spriteLib.GetSprite("Menu", lang);
        }
    }
}
