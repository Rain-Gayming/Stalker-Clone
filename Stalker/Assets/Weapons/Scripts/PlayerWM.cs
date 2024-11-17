using System.Collections;
using System.Collections.Generic;
using RainGayming.Combat;
using RainGayming.Inputs;
using UnityEngine;

public class PlayerWM : MonoBehaviour
{
    [Header("Reference")]
    public InputManager inputs;

    [Header("Weapons")]
    public WeaponManager currentWeapon;
    public WeaponManager primaryWeapon;
    public WeaponManager secondaryWeapon;
    public WeaponManager sideWeapon;

    private void Start()
    {
        inputs = InputManager.instance;
    }

    public void Update()
    {
        if (inputs.attackInput)
        {
            currentWeapon.Attack();
        }
    }

}
