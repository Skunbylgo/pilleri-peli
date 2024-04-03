using System.Collections;
using System.Collections.Generic;
using pilleripeli;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

namespace Mobiiliesimerkki
{
    public class GameOverBehaviour : MonoBehaviour
    {
        private string lang;
        private string gameOverType;
        // Start is called before the first frame update
        void OnEnable()
        {
            var gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            lang = gm.lang;
            gameOverType = gm.gameOverType;
            var spriteLibAsset = GetComponent<SpriteLibrary>().spriteLibraryAsset;
            GetComponent<Image>().sprite = spriteLibAsset.GetSprite(lang,gameOverType);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
