using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobiiliesimerkki
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int _maxHealth = 100;
        [SerializeField]
        private int _startingHealth = 100;
        [SerializeField] private float _invincibilityTime = 1;
        [SerializeField] private float _flashRate = 1 / 10f;
        private int _currentHealth = 0;
        private float _invincibilityTimer = 0;
        private SpriteRenderer _spriteRenderer = null;
        private float _flashTimer;

        public bool IsInvincible
        {
            get { return _invincibilityTimer > 0; }
        }

        public int CurrentHealth
        {
            get { return _currentHealth; }
            private set
            {
                // Clamp pitää huolen, että arvo ei voi koskaan tulla asetetuksi minimiä pienemmäksi
                // tai maksimia suuremmaksi
                _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
                Debug.Log($"Current health: {_currentHealth}");
            }
        }

        private void Awake()
        {
            Reset();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (IsInvincible)
            {
                _invincibilityTimer -= Time.deltaTime;
                _flashTimer += Time.deltaTime;
                if (_flashTimer > _flashRate)
                {
                    _spriteRenderer.enabled = !_spriteRenderer.enabled;
                    _flashTimer = 0;
                }

                if (!IsInvincible)
                {
                    _spriteRenderer.enabled = true;
                    _flashTimer = 0;
                }
            }
            else
            {
                _spriteRenderer.enabled = true;
            }
        }

        private void Reset()
        {
            CurrentHealth = _startingHealth;
        }

        public void IncreaseHealth(int amount)
        {
            if (amount <= 0)
            {
                // nameof-operaattori palauttaa parametrina annetun muuttujan nimen merkkijonona
                // Poikkeus (Exception) on tekniikka, jota käytetään virheiden käsittelyyn
                // ArgumentException on yleinen poikkeus, joka kertoo, että jokin parametri on virheellinen
                // Metodin suoritus päättyy poikkeuksen heittämiseen.
                // Poikkeys on käsiteltävä jossain ylemmällä tasolla, jotta sei ei pysäytä ohjelman suoritusta.
                // Unity käsittelee poikkeukset automaattisesti, joten ne eivät pysäytä peliä.
                // Virhe näkyy konsolissa.
                throw new ArgumentException("Amount must be positive", nameof(amount));
            }

            CurrentHealth += amount;
        }
/// <summary>
/// Vähentää hahmon terveyttä. Jos terveys menee nollaan tai alle, hahmo kuolee.
/// </summary>
/// <param name="amount">Vähennettävä määrä</param>
/// <returns>True, jos hahmo jää henkiin ja false kuollessa</returns>
/// <exception cref="ArgumentException"></exception>
        public bool DecreaseHealth(int amount)
        {
            if (IsInvincible)
            {
                return true;
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive", nameof(amount));
            }

            CurrentHealth -= amount;

            bool isAlive = CurrentHealth > 0;
            if (isAlive)
            {
                // Asetetaan hahmo kuolemattomaksi
                _invincibilityTimer = _invincibilityTime;
            }

            return isAlive;
        }
    }
}
