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
        if (Input.GetButtonDown("Fire1")) // 마우스 왼쪽 버튼 클릭 시
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        bullet.transform.forward = firePoint.forward; // 총알이 총구 방향을 바라보도록 설정
        rb.useGravity = false;
        rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
    }
}
