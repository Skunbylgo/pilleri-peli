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
        public float timeMultiplier = 1.0f;
        private const string DirectionXAnimationParameter = "DirectionX";
        private const string DirectionYAnimationParameter = "DirectionY";
        private Vector2 currentTarget;
        private int currentIndex;
        private Animator _animator;
        private Transform transform;
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
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
            Vector3 movementVector = transform.position - (Vector3)currentTarget;
            Vector3 moveDirection = Vector3.MoveTowards(transform.position, currentTarget, baseMovementSpeed * timeMultiplier * Time.deltaTime);
            GetComponent<Transform>().position = moveDirection;
            _animator.SetFloat("DirectionX", -movementVector.x);
            _animator.SetFloat("DirectionY", -movementVector.y);
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
