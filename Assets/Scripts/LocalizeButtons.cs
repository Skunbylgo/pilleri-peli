using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace pilleripeli
{
    public class LocalizeButtons : MonoBehaviour
    {
        [SerializeField]
        private Sprite finButton;
        [SerializeField]
        private Sprite engButton;
        // Start is called before the first frame update
        void Start()
        {
            var img = this.GetComponent<Image>();
            string lang = PlayerPrefs.GetString("Lang");
            if(lang.Equals("Fin"))
            {
                img.sprite = finButton;
            }
            else if(lang.Equals("Eng"))
            {
                img.sprite = engButton;
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
