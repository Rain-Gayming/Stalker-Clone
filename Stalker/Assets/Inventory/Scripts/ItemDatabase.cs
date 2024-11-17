using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RainGayming.Inventory
{

    [CreateAssetMenu(menuName = "Inventory/ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        public List<ItemObject> items;

        public void OnEnable()
        {
            UpdateDatabase();
        }

        public void UpdateDatabase()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == null)
                {
                    items.RemoveAt(i);
                }
            }

            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetItemID();
            }
        }
    }
}