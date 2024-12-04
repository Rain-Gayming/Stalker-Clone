using System.Collections;
using System.Collections.Generic;
using RainGayming.Inventory;
using UnityEngine;

namespace RainGayming.Combat
{
    public class BulletObject : MonoBehaviour
    {
        public Rigidbody rb;
        public GunItem gunInfo;
        public BulletItem bulletInfo;

        public void Start()
        {
            rb.AddForce(transform.forward * gunInfo.baseVelocity);
        }

        void OnTriggerStay(Collider other)
        {
            print("hit something");
            Destroy(gameObject);
        }
    }
}