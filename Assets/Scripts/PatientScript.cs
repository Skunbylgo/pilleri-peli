using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    public class PatientScript : MonoBehaviour
    {
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
                StartCoroutine(DeathTimer());
                requiredMedicine = possibleMedicine[Random.Range(0,possibleMedicine.Length)];
                Debug.Log($"{this.gameObject.name} now requires {requiredMedicine}.");
                needsMedicine = true;
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
            }
            GameObject.FindWithTag("Player").GetComponent<DemoCarried>().SetCarriedMedicine("None");
            Destroy(clone);
            
        }

        IEnumerator DeathTimer()
        {
            float timer = 0.0f;
            while (timer < timeToDeath)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            Debug.Log($"{this.gameObject.name} has died");
        }
    }
}
