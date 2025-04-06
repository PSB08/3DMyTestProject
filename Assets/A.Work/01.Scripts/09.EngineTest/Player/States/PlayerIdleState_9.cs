using Code.Entities;
using Code.FSM;
using UnityEngine;

namespace Code.Player.States
{
    public class PlayerIdleState_9 : PlayerState_9
    {
        public PlayerIdleState_9(Entity entity, int animationHash) : base(entity, animationHash)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            _movement.StopImmediately();
        }
        
    }
}
