using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    public class FDAButton : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        protected string finURL;
        [SerializeField]
        protected string engURL;
        public void OpenLink()
        {
            var lang = PlayerPrefs.GetString("Lang");
            if(lang == "Fin")
            {
                Application.OpenURL(finURL);
            }
            else if(lang == "Eng")
            {
                Application.OpenURL(engURL);
            }
        }
    }
}
