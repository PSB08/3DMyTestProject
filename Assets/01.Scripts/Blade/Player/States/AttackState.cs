using UnityEngine;

[CreateAssetMenu(fileName = "AttackState", menuName = "EntityStates/Attack")]
public class AttackState : EntityState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.ExecuteAttack(); 
    }

    public override void Handle(PlayerStateMachine player)
    {
        Animator animator = player.entityAnimator.GetComponent<Animator>();
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("NPC_01_ATTACK") && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            player.AnimationEnd(); 
        }
    }

    public override void Exit(PlayerStateMachine player)
    {
      
    }
}