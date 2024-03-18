using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace pilleripeli
{
    public class DemoCarried : MonoBehaviour
    {
        // Start is called before the first frame update
        private string carriedMedicine;
        public GameObject currentPatient { get; set; }
        private SpriteResolver spriteResolver;

        void Start()
        {
            spriteResolver = GameObject.FindWithTag("Inventory").GetComponent<SpriteResolver>();
        }
        public string GetCarriedMedicine()
        {
            return carriedMedicine;
        }

        public void SetCarriedMedicine(string medicine)
        {
            Debug.Log($"Trying to set carried medicine to {medicine}");
            carriedMedicine = medicine;
            Debug.Log(this.gameObject.name);
            spriteResolver.SetCategoryAndLabel("Medicine", medicine);

            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

