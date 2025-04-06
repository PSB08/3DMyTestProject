using Code.Entities;
using UnityEngine;

namespace Code.Player.States
{
    public class PlayerAttackState_9 : PlayerState_9
    {
        public PlayerAttackState_9(Entity entity, int animationHash) : base(entity, animationHash)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            _movement.StopImmediately();
        }

        public override void Update()
        {
            base.Update();
            if (_isTriggerCall)
            {
                Player.ChangeState("IDLE");
            }
        }

        public override void Exit()
        {
            base.Exit();
            _animatorTrigger.OnAnimatonEndTrigger?.Invoke();
        }
        
        
        
    }    
}

