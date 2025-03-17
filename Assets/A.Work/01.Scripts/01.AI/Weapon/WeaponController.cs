using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons;
    private int currentWeaponIndex = 0;

    private void Start()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == 0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            SwitchWeapon(currentWeaponIndex);
        }
    }

    private void SwitchWeapon(int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == index);
        }
    }

}
