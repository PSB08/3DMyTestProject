using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime); // 일정 시간 후 총알 제거
    }

    
}
