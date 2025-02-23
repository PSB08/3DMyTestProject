using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ResetGround"))
        {
            Debug.Log(1);
            Camera.main.transform.position = new Vector3(0, 3.7f, -7.4f);
            Debug.Log(2);
        }
    }

}
