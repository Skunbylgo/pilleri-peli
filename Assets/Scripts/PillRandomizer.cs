using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace pilleripeli
{
    public class PillRandomizer : MonoBehaviour
    {
        void Start()
        {
            var pill = this.GetComponent<SpriteRenderer>();
            var spriteLib = this.GetComponent<SpriteLibrary>().spriteLibraryAsset;
            var spriteRes = this.GetComponent<SpriteResolver>();
            var category = spriteRes.GetCategory();
            var sprites = spriteLib.GetCategoryLabelNames(category).ToArray();
            var label = sprites[Random.Range(0,sprites.Length)];
            pill.sprite = spriteLib.GetSprite(category,label);
        }
    }
}
