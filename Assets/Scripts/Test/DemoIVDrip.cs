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
        private string requiredMedicine;
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Clicked!");
            spriteResolver.SetCategoryAndLabel("Medicine", playerInventory.GetCarriedMedicine());
            if (playerInventory.GetCarriedMedicine() == requiredMedicine)
            {
                GameObject.FindWithTag("GameController").GetComponent<DemoGameController>().GeneratePatient();
            }
            //spriteResolver
        }
        // Start is called before the first frame update
        void Start()
        {
            playerInventory = GameObject.FindWithTag("Player").GetComponent<DemoCarried>();

            spriteResolver = GetComponent<SpriteResolver>();
            var wee = spriteResolver.spriteLibrary;
            spriteLibraryAsset = wee.spriteLibraryAsset;
            
            medicineLabels = spriteLibraryAsset.GetCategoryLabelNames("Medicine").ToList();
            requiredMedicine = medicineLabels[Random.Range(0,medicineLabels.Count)];
            Debug.Log($"Required medicine is now {requiredMedicine}");
            // Slight delay so the sprite actually changes.
            Invoke(nameof(ChangeColor), 0.1f);
            
        }

        void ChangeColor()
        {
            GameObject.Find("RequiredMedicine").GetComponent<SpriteResolver>().SetCategoryAndLabel("Medicine", requiredMedicine);
        }
    }
}

