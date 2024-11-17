using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RainGayming.Misc
{
    public class CursorManager : MonoBehaviour
    {
        public bool isInGame;

        public void Start()
        {
            if (isInGame)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

}