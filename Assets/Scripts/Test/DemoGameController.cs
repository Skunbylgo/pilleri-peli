using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    
    public class DemoGameController : MonoBehaviour
    {
        private GameObject clone;
        [SerializeField]
        private GameObject medicineAdministration;
        // Start is called before the first frame update
        public void Start()
        {
            GeneratePatient();
        }
        public void GeneratePatient()
        {
            if (clone != null)
            {
                Destroy(clone);
            }
            clone = Instantiate(medicineAdministration);
        }
    }
}