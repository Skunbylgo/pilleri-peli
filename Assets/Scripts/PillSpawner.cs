using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    public class PillSpawner : MonoBehaviour
    {
        [SerializeField]
        protected GameObject pillPrefab;
        [SerializeField]
        private float pillDelay;
        public bool spawnPills = true;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnPills());
        }

        // Update is called once per frame
        IEnumerator SpawnPills()
        {
            while(spawnPills)
            {
                SpawnPill();
                yield return new WaitForSeconds(pillDelay);
            }
        }
        void SpawnPill()
        {
            var randomRotation = Quaternion.Euler(0.0f,0.0f,Random.Range(0.0f, 360.0f));
            var clone = Instantiate(pillPrefab,this.gameObject.transform.position, randomRotation);
            var rb = clone.GetComponent<Rigidbody2D>();
            rb.AddTorque(Random.Range(-10.0f, 10.0f));
            Destroy(clone,5.0f);
        }
    }
}
