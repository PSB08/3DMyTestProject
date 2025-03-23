using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "IdleState", menuName = "EntityStates/Idle")]
public class IdleState : EntityState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.entityAnimator.SetParam("isMoving", false);
        player.entityAnimator.SetParam("isAttacking", false);
        player.entityAnimator.SetParam("isIdle", true); 
    }

    public override void Handle(PlayerStateMachine player)
    {
        if (player.playerInput.isClicking)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                player.targetPosition = hit.point;
                player.isMoving = true;
                player.ChangeState(player.moveState); 
            }
        }
    }

    public override void Exit(PlayerStateMachine player)
    {
        player.entityAnimator.SetParam("isIdle", false);
    }
}