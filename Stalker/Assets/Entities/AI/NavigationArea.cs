using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Entities
{
    public class NavigationArea : MonoBehaviour
    {
        [BoxGroup("References")]
        public NavigationPoint[] navigationPoints;

        public void Awake()
        {
            navigationPoints = GetComponentsInChildren<NavigationPoint>();
        }

        public Transform GetPoint()
        {
            Transform newPoint = navigationPoints[Random.Range(0, navigationPoints.Length)].transform;

            if (newPoint == null)
            {
                print("cant return a point");
                return null;
            }

            print(newPoint);

            return newPoint;
        }
    }
}