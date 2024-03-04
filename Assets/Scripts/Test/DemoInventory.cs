using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace pilleripeli
{
    public class DemoInventory : MonoBehaviour, IPointerClickHandler
    {
        List<string> medicine;
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Clicked!");
            GameObject.FindWithTag("Player").GetComponent<DemoCarried>().SetCarriedMedicine(name);
        }
        // Start is called before the first frame update
        void Start()
        {
            medicine = new List<string>
            {
                "Blue",
                "Red",
                "Green"
            };
        }
    }
}
