using System.Collections;
using System.Collections.Generic;
using pilleripeli;
using UnityEngine;

namespace pilleripeli
{
    public class CoffeeTableBehaviour : MonoBehaviour
    {
        [SerializeField]
        GameObject gameManagerObject;
        GameManager gameManager;

        void Start()
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        // Start is called before the first frame update
        public void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
            {
                gameManager.LoadCoffee();
            }
        }
        public void OnTriggerExit2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
            {
                gameManager.UnloadCoffee();
            }
        }
    }
}
