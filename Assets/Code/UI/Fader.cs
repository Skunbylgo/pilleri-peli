using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mobiiliesimerkki
{
    public class Fader : MonoBehaviour
    {

        public enum State
        {
            None = 0,
            FadingIn,
            FadingOut
        }

        public static event System.Action FadeComplete;

        [SerializeField, Tooltip("Fade speed")]
        private float _speed = 1;

        [SerializeField, Tooltip("Image used for fading")]
        private Image _image = null;

        // Faderin tamanhetkinen tila
        private State _state = State.None;

        public bool IsFading => _state != State.None;

        private void Awake()
        {
            // Haetaan viittaus image komponenttiin, jos sitä ei ole asetettu Unitysta
            if (_image == null)
            {
                _image = GetComponent<Image>();
            }

            //Asetaan alpha-arvo nollaksi, jotta kuva on aluksi näkymätön
            SetAlpha(0);
        }

        // Update is called once per frame
        private void Update()
        {
            switch (_state)
            {
                case State.FadingIn:
                    FadeIn();

                    if (Mathf.Approximately(_image.color.a, 1))
                    {
                        FadingDone();
                    }
                    break;
                    
                case State.FadingOut:
                    FadeOut();

                    if (Mathf.Approximately(_image.color.a, 0))
                    {
                        FadingDone();
                    }
                    break;
            }
        }

        public bool StartFade(State state)
        {
            if (IsFading)
            {
                return false;
            }

            _state = state;
            return true;
        }

        private void FadingDone()
        {
            _state = State.None;
            if (FadeComplete != null)
            {
                FadeComplete();
            }
        }

        private void FadeIn()
        {
            float alpha = _image.color.a;
            alpha += Time.deltaTime * _speed;
            SetAlpha(alpha);
        }

        private void FadeOut()
        {
            float alpha = _image.color.a;
            alpha -= Time.deltaTime * _speed;
            SetAlpha(alpha);
        }

        private void SetAlpha(float alpha)
        {
            //Haetaan viittaus väriin, jotta voidaan muuttaa alpha-arvoa
            Color color = _image.color;
            // Varmistaa, että alpha-arvo on välillä 0-1
            color.a = Mathf.Clamp01(alpha);
            _image.color = color;
        }
    }
}
