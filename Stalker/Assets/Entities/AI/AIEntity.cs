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
            //if the AI is at the new point stop
            if (transform.position.x == currentPoint.transform.position.x && transform.position.z == currentPoint.transform.position.y)
            {
                print("at new point");
            }
            else
            {
                //if moving do nothing
                if (isMoving)
                    return;

                //get a random point
                currentPoint = navigationArea.GetPoint();

                //else move to the point
                agent.Move(currentPoint.position);
                isMoving = false;
            }
        }
    }

}