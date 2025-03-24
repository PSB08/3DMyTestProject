using UnityEngine;

[CreateAssetMenu(fileName = "MoveState", menuName = "EntityStates/Move")]
public class MoveState : EntityState
{
    public GameObject summonPrefab; 
    private GameObject currentSummon;
    
    public override void Enter(PlayerStateMachine player)
    {
        player.entityAnimator.SetParam("isMoving", true);
        player.entityAnimator.SetParam("isIdle", false);
        
        if (currentSummon != null)
        {
            Destroy(currentSummon);
        }
        
        if (summonPrefab != null)
        {
            Vector3 summonPosition = player.targetPosition;
            summonPosition.y -= 0.4f; 

            currentSummon = Instantiate(summonPrefab, summonPosition, Quaternion.identity);
        }
        
    }

    public override void Handle(PlayerStateMachine player)
    {
        Vector3 direction = (player.targetPosition - player.transform.position).normalized;
        player.characterController.Move(direction * player.speed * Time.deltaTime);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10f);

        if (Vector3.Distance(player.transform.position, player.targetPosition) < 0.6f)
        {
            player.playerInput.isMoving = false;

            if (player.playerInput.isAttacking)
            {
                player.ChangeState(player.attackState);
            }
            else
            {
                player.ChangeState(player.idleState); 
            }
        }
    }

    public override void Exit(PlayerStateMachine player)
    {
        player.entityAnimator.SetParam("isMoving", false);
    }
}