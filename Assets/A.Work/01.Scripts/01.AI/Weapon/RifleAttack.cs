using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 30f;
    public float fireRate = 0.2f; //발사 간격 (초 단위)

    private float nextFireTime = 0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime) // 쿨타임 적용
        {
            nextFireTime = Time.time + fireRate; // 다음 발사 가능 시간 설정
            Shoot();
            animator.SetTrigger("Idle");
        }
    }

    private void Shoot()
    {
        animator.SetTrigger("Attack");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        bullet.transform.forward = firePoint.forward; // 총알이 총구 방향을 바라보도록 설정
        rb.useGravity = false;
        rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        Quaternion rot = Quaternion.Euler(-15, 0, 0);
        transform.localPosition = new Vector3(0.8f, 0, 1.2f);
        transform.localRotation = rot;
    }

}
