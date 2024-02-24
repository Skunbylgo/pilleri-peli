using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobiiliesimerkki
{

public class InputReader : MonoBehaviour
{

  public enum InputType
  {
    VirtualJoystick,
    Touch
  }

  [SerializeField] private InputType _inputType = InputType.VirtualJoystick;

    private Inputs _inputs = null;
    private Vector2 _movementInput = Vector2.zero;
    private bool _interactInput = false;
    private Vector3 _tapWorldPosition = Vector3.zero;

/// <summary>
/// C#:n propertyt korvaavat mm. Javan getterit ja setterrit.
/// Property näyttää käyttäjälle muuttujalta, mutta se käyttäytyy
/// kuin get ja set metodit.
/// </summary>
    public Vector2 Movement
    {
      get { return _movementInput; }
    }

    private void Awake()
    {
      // Alustetaan Inputs-olio Awakessa luomalla new:lla uusi Inputs olio
      _inputs = new Inputs();
    }

    // Update is called once per frame
    private void OnEnable()
    {
      // Aktivoidaan Input OnEnable:ssa, eli kun objekti aktivoituu
      _inputs.Game.Enable();
      if (_inputType == InputType.Touch)
      {
        _inputs.TapControl.Enable();
      }
    }

    private void OnDisable()
    {
      // Deaktivoidaan Input OnDisable:ssa, eli kun objekti deaktivoidaan
      _inputs.Game.Disable();
      if (_inputType == InputType.Touch)
      {
        _inputs.TapControl.Disable();
      }
    }

    private void Update()
    {
      switch (_inputType)
      {
        case InputType.VirtualJoystick:
          _movementInput = _inputs.Game.Move.ReadValue<Vector2>();
          break;
        case InputType.Touch:
          if (_inputs.TapControl.Move.WasPerformedThisFrame())
          {
            Vector2 tapPosition = _inputs.TapControl.Move.ReadValue<Vector2>();

          Camera.main.ScreenToWorldPoint(tapPosition);
          _tapWorldPosition.z = 0;
          }

          //laske suunta vektori tappauksen jja hahmon valilla
          Vector3 toTarget = _tapWorldPosition - transform.position;
          if (toTarget.sqrMagnitude < 0.1f)
          {
            _movementInput = Vector2.zero;
          }
          else
          {
            _movementInput = toTarget.normalized;
          }
          break;
      }
      // Luetaan Inputin arvoa jokaisella framella
      _movementInput = _inputs.Game.Move.ReadValue<Vector2>();

        //TODO 2.1: Luetaan Interact inputin arvo(event)
    }
  }
}
