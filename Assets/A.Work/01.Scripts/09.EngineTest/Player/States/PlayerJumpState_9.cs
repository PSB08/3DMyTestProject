using Code.Entities;
using UnityEngine;

namespace Code.Player.States
{
    public class PlayerJumpState_9 : PlayerState_9
    {
        private bool _wasOnLink;
        
        public PlayerJumpState_9(Entity entity, int animationHash) : base(entity, animationHash)
        {
        }
        
        public override void Update()
        {
            base.Update();
            
            Vector3 euler = Player.transform.eulerAngles;
            euler.x = 0;
            Player.transform.eulerAngles = euler;
            
            bool isOnLink = Player._agent.isOnOffMeshLink;
            
            if (_wasOnLink && !isOnLink)
            {
                if (Player._agent.velocity.sqrMagnitude > 0.1f)
                    Player.ChangeState("MOVE");
                else
                    Player.ChangeState("IDLE");
            }

            _wasOnLink = isOnLink;
        }
        
    }    
}

