using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RainGayming.Entities
{
    public class AIManager : MonoBehaviour
    {
        public List<AIEntity> entitiesInScene;

        public void Start()
        {
            AIEntity[] entitiesFound = FindObjectsOfType<AIEntity>();

            for (int i = 0; i < entitiesFound.Length; i++)
            {
                entitiesInScene.Add(entitiesFound[i]);
            }
        }

        public void Update()
        {
            for (int i = 0; i < entitiesInScene.Count; i++)
            {
                entitiesInScene[i].UpdateAI();
            }
        }
    }

}
