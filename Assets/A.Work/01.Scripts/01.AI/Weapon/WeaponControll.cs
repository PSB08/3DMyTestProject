using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControll : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons;
    private int currentWeaponIndex = 0;

    private void Start()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].active = (i == 0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            SwitchCamera(currentWeaponIndex);
        }
    }

    private void SwitchCamera(int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].active = (i == index);
        }
    }

}
