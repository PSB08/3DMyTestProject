using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpawn : MonoBehaviour
{
    public PlayerController playerController;
    public HpSystem hpSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ResetGround"))
        {
            playerController.transform.position = new Vector3(0, 3.7f, -7.4f);
            if (playerController != null)
            {
                playerController.isResetting = true;
                hpSystem.TakeDamage(50f);
            }
            StartCoroutine(ResetPlayer(playerController));
        }
    }

    private IEnumerator ResetPlayer(PlayerController playerController)
    {
        yield return new WaitForSeconds(0.1f);
        playerController.isResetting = false;
    }


}
