using Code.Entities;
using UnityEngine;

namespace Code.Player.States
{
    public class PlayerJumpState_9 : PlayerState_9
    {
        private PlayerJumpCompo_9 _jumpCompo;

        public PlayerJumpState_9(Entity entity, int animationHash) : base(entity, animationHash)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Player._agent.autoTraverseOffMeshLink = false;

            // PlayerJumpCompo_9 초기화
            _jumpCompo = Player.GetComponentInChildren<PlayerJumpCompo_9>();
            _jumpCompo.Initialize(Player.transform, Player._agent);

            if (Player._agent.isOnOffMeshLink)
            {
                var linkData = Player._agent.currentOffMeshLinkData;
                _jumpCompo.StartJump(linkData.startPos, linkData.endPos);
            }
        }

        public override void Update()
        {
            base.Update();

            // 점프 상태 업데이트
            if (_jumpCompo != null && _jumpCompo.IsJumping)
            {
                _jumpCompo.UpdateJump();

                // 점프 완료 후 상태 변경
                if (!_jumpCompo.IsJumping)
                {
                    if (Player._agent.velocity.sqrMagnitude > 0.1f)
                        Player.ChangeState("MOVE");
                    else
                        Player.ChangeState("IDLE");
                }
            }
        }
        
        
    }    
}

