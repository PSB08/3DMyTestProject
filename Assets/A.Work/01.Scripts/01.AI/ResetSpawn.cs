using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpawn : MonoBehaviour
{
    public PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ResetGround"))
        {
            Debug.Log(1);
            Camera.main.transform.position = new Vector3(0, 3.7f, -7.4f);
            Debug.Log(2);
            if (playerController != null)
            {
                playerController.isResetting = true; // 회전 막기
            }
            StartCoroutine(ResetPlayer(playerController));
        }
    }
    private IEnumerator ResetPlayer(PlayerController playerController)
    {
        yield return new WaitForSeconds(0.1f);
        playerController.isResetting = false; // 다시 움직일 수 있도록 설정
    }


}
