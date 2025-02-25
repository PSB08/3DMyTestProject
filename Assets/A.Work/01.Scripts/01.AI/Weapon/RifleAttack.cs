using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 30f;
    public float fireRate = 0.2f; //�߻� ���� (�� ����)
    public float rightFireRate = 5f;
    public int bulletCount = 5; // �߻��� �Ѿ� ����
    public float spreadAngle = 15f; // ��ź�� �߻� ����

    private float nextFireTime = 0f;
    private float nextRightFireTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) // ��Ŭ��
        {
            nextFireTime = Time.time + fireRate; // ���� �߻� ���� �ð� ����
            Shoot();
            animator.SetTrigger("Idle");
        }
        if (Input.GetMouseButtonDown(1) && Time.time >= nextRightFireTime) // ���콺 ��Ŭ��
        {
            nextRightFireTime = Time.time + rightFireRate;
            ShootShotgun();
            animator.SetTrigger("Idle");
        }
    }

    private void Shoot()
    {
        FireBullet(firePoint.forward);
        animator.SetTrigger("Attack");
    }

    private void ShootShotgun()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion bulletRotation = Quaternion.Euler(0, angle, 0);
            Vector3 shootDirection = bulletRotation * firePoint.forward;
            FireBullet(shootDirection);
        }
        animator.SetTrigger("Attack");
    }

    private void FireBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        bullet.transform.forward = direction;
        rb.useGravity = false;
        rb.AddForce(direction * fireForce, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        Quaternion rot = Quaternion.Euler(-15, 0, 0);
        transform.localPosition = new Vector3(0.8f, 0, 1.2f);
        transform.localRotation = rot;
    }

}
