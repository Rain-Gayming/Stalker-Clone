using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Entities
{
    public class NavigationArea : MonoBehaviour
    {
        [BoxGroup("References")]
        public List<Transform> navigationPoints;

        public void Start()
        {
            NavigationPoint[] points = GetComponentsInChildren<NavigationPoint>();

            for (int i = 0; i < points.Length; i++)
            {
                navigationPoints.Add(points[i].transform);
            }
        }

        public Transform GetPoint()
        {
            //gets a random number 
            int randomPoint = Random.Range(0, navigationPoints.Count);
            Transform point = navigationPoints[randomPoint];
            return point;
        }
    }
}