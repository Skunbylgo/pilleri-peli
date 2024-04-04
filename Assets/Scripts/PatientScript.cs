using System.Collections;
using System.Collections.Generic;
using Mobiiliesimerkki;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace pilleripeli
{
    public class PatientScript : MonoBehaviour
    {
        [SerializeField]
        private GameObject debug_text;
        private ParticleSystem sickened;
        public GameManager gameManagerScript;
        [SerializeField]
        private bool needsMedicine = false;
        
        [SerializeField]
        protected GameObject clipboardView;
        protected GameObject clone;
        public string requiredMedicine { get; private set; }
        [SerializeField]
        private string[] possibleMedicine;
        [SerializeField]
        protected int timeToDeath;
        private SpriteResolver patientStatusResolver;
        void Start()
        {
            sickened = this.GetComponent<ParticleSystem>();
            patientStatusResolver = this.gameObject.GetComponentInChildren<SpriteResolver>();
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
            {
                if(!needsMedicine)
                {
                    return;
                }
                else
                {
                    GenerateClipboard();
                }
            }
            else if(!needsMedicine)
            {
                RollMedicine();
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
            {
                Destroy(clone);
            }
        }
        void RollMedicine()
        {
            Debug.Log("Rolling for medicine");
            if(Random.Range(0.0f,2.0f) > 1.0f)
            {
                sickened.Play();
                StartCoroutine(DeathTimer());
                requiredMedicine = possibleMedicine[Random.Range(0,possibleMedicine.Length)];
                Debug.Log($"{this.gameObject.name} now requires {requiredMedicine}.");
                needsMedicine = true;
                patientStatusResolver.SetCategoryAndLabel("Patient","Sick");
            }
            else
            {
                //needsMedicine = false;
            }
        }

        void GenerateClipboard()
        {
            if (clone != null)
            {
                Destroy(clone);
            }
            GameObject.FindWithTag("Player").GetComponent<DemoCarried>().currentPatient = this.gameObject;
            clone = Instantiate(clipboardView);
            //clone.GetComponent<DemoIVDrip>().SetRequiredMedicine(requiredMedicine);
        }
        public void AdministerMedicine()
        {
            

            if(clone.GetComponentInChildren<DemoIVDrip>().requiredMedicine.Equals(GameObject.FindWithTag("Player").GetComponent<DemoCarried>().GetCarriedMedicine()))
            {
                needsMedicine = false;
                StopAllCoroutines();
                patientStatusResolver.SetCategoryAndLabel("Patient", "Healthy");
            }
            GameObject.FindWithTag("Player").GetComponent<DemoCarried>().SetCarriedMedicine("None");
            Destroy(clone);
            
        }

        IEnumerator DeathTimer()
        {
            float timer = 0.0f;
            while (timer < timeToDeath)
            {                    
                if(debug_text != null)
                    debug_text.GetComponent<TextMeshProUGUI>().text = timer.ToString();
                timer += Time.deltaTime;
                yield return null;
            }
            Debug.Log($"{this.gameObject.name} has died");
            if(!gameManagerScript.gameOver)
            {
                gameManagerScript.GameOver("PatientDead");
            }
        }
    }
}
