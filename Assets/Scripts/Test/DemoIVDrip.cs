using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D.Animation;


namespace pilleripeli
{
    public class DemoIVDrip : MonoBehaviour, IPointerClickHandler
    {
        private SpriteResolver spriteResolver;
        private SpriteLibraryAsset spriteLibraryAsset;
        private List<string> medicineLabels;
        private DemoCarried playerInventory;
        public string requiredMedicine;
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Clicked!");
            spriteResolver.SetCategoryAndLabel("Medicine", playerInventory.GetCarriedMedicine());
            GameObject.FindWithTag("Player").GetComponent<DemoCarried>().currentPatient.GetComponent<PatientScript>().AdministerMedicine();
            //spriteResolver
        }
        // Start is called before the first frame update
        void Start()
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerInventory = player.GetComponent<DemoCarried>();
            requiredMedicine = playerInventory.currentPatient.GetComponent<PatientScript>().requiredMedicine;

            
            spriteResolver = GetComponent<SpriteResolver>();
            /*
            var wee = spriteResolver.spriteLibrary;
            spriteLibraryAsset = wee.spriteLibraryAsset;
            
            //medicineLabels = spriteLibraryAsset.GetCategoryLabelNames("Medicine").ToList();
            //requiredMedicine = medicineLabels[Random.Range(0,medicineLabels.Count-1)];
            //Debug.Log($"Required medicine is now {requiredMedicine}");
            */
            // OBSOLETE
            // Slight delay so the sprite actually changes. 
            //Invoke(nameof(ChangeColor), 0.1f);
            
        }

        /*
        public void SetRequiredMedicine(string medicine)
        {
            requiredMedicine = medicine;
        }
        */
        void ChangeColor()
        {
            GameObject.Find("RequiredMedicine").GetComponent<SpriteResolver>().SetCategoryAndLabel("Medicine", requiredMedicine);
        }
    }
}

