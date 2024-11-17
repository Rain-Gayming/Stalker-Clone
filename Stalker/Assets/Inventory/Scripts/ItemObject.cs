using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace RainGayming.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class ItemObject : ScriptableObject
    {
        [Header("Item Info")]
        public string itemName;
        [TextArea] public string baseDescription;
        public bool canStack;

        [Header("Debug")]
        public int itemID;
        public string itemDBLocation = "ItemDatabase";
        public ItemDatabase itemDb;

        private void OnEnable()
        {
            itemDBLocation = "ItemDatabase";
            itemDb = Resources.Load(itemDBLocation) as ItemDatabase;
            SetItemID();
        }

        [ContextMenu("ItemID")]
        public void SetItemID()
        {
            if (itemDb.items.Contains(this))
            {
                return;
            }

            itemDb.items.Add(this);
            itemID = itemDb.items.Count - 1;
        }
    }
}