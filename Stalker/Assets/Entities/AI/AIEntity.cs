using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace RainGayming.Entities
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIEntity : Entity
    {
        [BoxGroup("References")]
        public NavMeshAgent agent;


        [BoxGroup("Navigating")]
        public NavigationArea navigationArea;
        [BoxGroup("Navigating")]
        public Transform currentPoint;
        [BoxGroup("Navigating")]
        public bool isMoving;
        [BoxGroup("Navigating/Waiting")]
        public bool isWaiting;
        [BoxGroup("Navigating/Waiting")]
        public float waitTimer;
        [BoxGroup("Navigating/Waiting")]
        public float maxWaitTime = 65f;
        [BoxGroup("Navigating/Waiting")]
        public float minWaitTime = 5f;

        public void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void Update()
        {

        }

        public void UpdateAI()
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                isWaiting = false;
            }

            if (!isWaiting && !isMoving)
            {
                currentPoint = navigationArea.GetPoint();
                agent.SetDestination(currentPoint.position);
                print(agent.destination);
                isMoving = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Navpoint") && other.transform == currentPoint)
            {
                print("reached my point");
                waitTimer = Random.Range(minWaitTime, maxWaitTime);
                isWaiting = true;
                isMoving = false;
            }
        }

    }
}