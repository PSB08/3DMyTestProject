using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 30f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // ���콺 ���� ��ư Ŭ�� ��
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        bullet.transform.forward = firePoint.forward; // �Ѿ��� �ѱ� ������ �ٶ󺸵��� ����
        rb.useGravity = false;
        rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
    }
}
