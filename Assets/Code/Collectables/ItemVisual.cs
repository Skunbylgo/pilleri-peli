using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobiiliesimerkki
{
    public class ItemVisual : MonoBehaviour
    {
    [SerializeField] private Item _item = null;

    public Item Item => _item;
    }
}
