using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
