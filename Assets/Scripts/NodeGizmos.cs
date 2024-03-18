using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace pilleripeli
{
    public class NodeGizmos : MonoBehaviour
    {
        [SerializeField]
        private string id;

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(this.transform.position, 0.5f);
        Handles.Label(this.transform.position + new Vector3(-1,1,0), id);
    }
#endif
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
