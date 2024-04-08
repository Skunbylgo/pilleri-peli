using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace pilleripeli
{
    public class ExitButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        GameObject self;
        // Start is called before the first frame update
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            Debug.Log("Click!");
            Destroy(self);
        }
    }
}
