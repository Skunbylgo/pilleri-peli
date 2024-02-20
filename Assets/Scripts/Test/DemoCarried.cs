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
        private SpriteResolver spriteResolver;

        void Start()
        {
            spriteResolver = GetComponent<SpriteResolver>();
        }
        public string GetCarriedMedicine()
        {
            return carriedMedicine;
        }

        public void SetCarriedMedicine(string medicine)
        {
            carriedMedicine = medicine;
            spriteResolver.SetCategoryAndLabel("Medicine", medicine);

            Debug.Log($"Set carried medicine to {medicine}");
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

