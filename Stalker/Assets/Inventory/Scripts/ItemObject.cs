using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using Sirenix.OdinInspector;

namespace RainGayming.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class ItemObject : ScriptableObject
    {
        [BoxGroup("Item Info")]
        public string itemName;
        [BoxGroup("Item Info")]
        [TextArea] public string baseDescription;
        [BoxGroup("Item Info")]
        [TextArea] public string generatedDescription;
        [BoxGroup("Item Info")]
        public bool canStack;
        [BoxGroup("Item Info")]
        public float weight;

        [BoxGroup("Debug")]
        public int itemID;
        [BoxGroup("Debug")]
        public string itemDBLocation = "ItemDatabase";
        [BoxGroup("Debug")]
        public ItemDatabase itemDb;
        [BoxGroup("Debug")]
        public bool customDescription;

        private void OnEnable()
        {
            itemDBLocation = "ItemDatabase";
            itemDb = Resources.Load(itemDBLocation) as ItemDatabase;
            SetItemID();

            if(!customDescription){
                SetDescription();   
            }
        }

        [Button("ItemID")]
        public void SetItemID()
        {
            if (itemDb.items.Contains(this))
            {
                return;
            }

            itemDb.items.Add(this);
            itemID = itemDb.items.Count - 1;
        }

        [Button]
        public virtual void SetDescription()
        {

        }
    }
}