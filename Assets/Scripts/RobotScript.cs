using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    public class RobotScript : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] patrolNodes;
        [SerializeField]
        private float baseMovementSpeed;
        private float timeMultiplier = 1.0f;
        private const string DirectionXAnimationParameter = "DirectionX";
        private const string DirectionYAnimationParameter = "DirectionY";
        private Vector2 currentTarget;
        private int currentIndex;
        private Transform transform;
        // Start is called before the first frame update
        void Start()
        {
            transform = GetComponent<Transform>();
            currentIndex = 0;
            currentTarget = patrolNodes[currentIndex].GetComponent<Transform>().position;
        }

        // Update is called once per frame
        void Update()
        {
            if (GetComponent<Transform>().position == (Vector3)currentTarget)
            {
                ChangeTarget();
            }
        }
        void FixedUpdate()
        {
            GetComponent<Transform>().position = Vector3.MoveTowards(transform.position, currentTarget, baseMovementSpeed * timeMultiplier * Time.deltaTime);


        }
        /*
        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("Collision");
            if (col.CompareTag("MovementNode"))
            {
                ChangeTarget();
            }
        }
        */
        void ChangeTarget()
        {
            if (currentIndex == patrolNodes.Length - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
            currentTarget = patrolNodes[currentIndex].GetComponent<Transform>().position;
        }
    }
}
