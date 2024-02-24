using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobiiliesimerkki
{
    public class Damager : MonoBehaviour
    {
        [SerializeField]
        private int _amount = 5;

        private void OnTriggerStay2D(Collider2D other)
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if (player != null)
            {
                player.TakeDamage(_amount);
            }
        }
    }
}
