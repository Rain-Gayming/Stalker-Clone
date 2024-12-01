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

        public void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void Update()
        {

        }

        public void UpdateAI()
        {
            if (isMoving)
            {

            }
            else
            {
                currentPoint = navigationArea.GetPoint();

                print(currentPoint.position);
                agent.Move(currentPoint.position);
                isMoving = true;
            }
        }

    }
}