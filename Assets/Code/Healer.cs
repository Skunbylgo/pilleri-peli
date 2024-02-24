using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobiiliesimerkki
{
    public class Healer : MonoBehaviour
    {
        [SerializeField]
        private int _amount = 10;

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if (player != null)
            {
                player.Heal(_amount);
                Destroy(gameObject); // Tuhoaa gameObjectin ku pelaaja kerää sen
            }
        }
    }
}
