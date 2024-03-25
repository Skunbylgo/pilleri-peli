using System.Collections;
using System.Collections.Generic;
using pilleripeli;
using TMPro;
using UnityEngine;

namespace pilleripeli
{
    public class ScoreScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void OnEnable()
        {
            var gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            var score = gm.getScore();
            this.GetComponent<TextMeshProUGUI>().text = score;
        }
    }
}
