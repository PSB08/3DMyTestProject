using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControll : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons;
    private int currentCameraIndex = 0;

    private void Start()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].active = (i == 0);
        }
    }

    private void Update()
    {
        // F 키를 누를 때마다 다음 카메라로 변경
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentCameraIndex = (currentCameraIndex + 1) % weapons.Count;
            SwitchCamera(currentCameraIndex);
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
