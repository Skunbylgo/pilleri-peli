using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobiiliEsimerkki
{
    /// <summary>
    /// tämä scripti vaihtaa spriten väriä sekunnin välein
    /// </summary>
public class ColorChanger : MonoBehaviour
{
    // Luokan jäsenmuuttujat
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Color[] _colours;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.color = _colours[0];

    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time %_colours.Length);
        _spriteRenderer.color = _colours[index];
    }
}
}
