using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    public class CabinetOuter : MonoBehaviour
    {
        [SerializeField]
        GameObject cabinetView;
        private GameObject clone;
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
            {
                GenerateCabinet();
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
            {
                Destroy(clone);
            }
        }
        void GenerateCabinet()
        {
            if(clone != null)
            {
                Destroy(clone);
            }
            clone = Instantiate(cabinetView);
        }
    }
}
