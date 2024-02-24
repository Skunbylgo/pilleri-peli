using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobiiliesimerkki
{
    /// <summary>
    /// Hallinnoi pelihahmoa. Riippuvuudet: Mover, InputReader
    /// </summary>
    [RequireComponent(typeof(InputReader))]
    public class PlayerControl : MonoBehaviour
    {
      // Vakiot, näiden arvoa ei voi muuttaa ajon aikana.
      private const string SpeedAnimationParameter = "Speed";
      private const string DirectionXAnimationParameter = "DirectionX";
      private const string DirectionYAnimationParameter = "DirectionY";
        private InputReader _inputReader = null;
        private IMover _mover = null;
        private Animator _animator = null;
        private Health _health = null;
        private SpriteRenderer _spriteRenderer = null;


  #region Unity Messages
      private void Awake()
      {
        // Alustetaan InputReader ja Mover Awake metodissa
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<IMover>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _health = GetComponent<Health>();
      }
        // Update is called once per frame
        private void Update()
        {
          // Luetaan käyttäjän syöte
          Vector2 movement = _inputReader.Movement;
          _mover.Move(movement);
          UpdateAnimator(movement);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
          // Tarkistetaan osuuko pelaaja johonkin toiseen peliobjektiin
          ItemVisual itemVisual = other.GetComponent<ItemVisual>();
          if (itemVisual != null)
          {
            Debug.Log($"Pelaaja osui {itemVisual.name}iin");
            Destroy(other.gameObject); // Tuhoaa peliobjektin
          }
        }
#endregion Unity Messages

#region Private implementation

      private void Die()
      {
        gameObject.SetActive(false);
      }

      private void UpdateAnimator(Vector2 movement)
      {
        _animator.SetFloat(DirectionXAnimationParameter, movement.x);
        _animator.SetFloat(DirectionYAnimationParameter, movement.y);
        _animator.SetFloat(SpeedAnimationParameter, movement.sqrMagnitude);

        //Käännetään hahmoa jos liikutaan oikealle.
        bool lookRight = movement.x > 0;
        // Oikealle liikkuessa lookRight on true, jolloin voimme flipata
        // hahomon spriten x-akselin suhteen.
        _spriteRenderer.flipX = lookRight;
      }
#endregion Private implementation

#region Public interface
      public void Heal(int amount)
      {
        _health.IncreaseHealth(amount);
      }

      public bool TakeDamage(int amount)
      {
        if (!_health.DecreaseHealth(amount))
        {
          Die();
          return false;
        }
        return true;
      }
#endregion Public interface
  }
}