using Code.Entities;
using Code.FSM;

namespace Code.Player
{
    public class PlayerState_9 : EntityState
    {
        protected Player_9 Player;
        protected PlayerMovement_9 _movement;

        public PlayerState_9(Entity entity, int animationHash) : base(entity, animationHash)
        {
            Player = entity as Player_9;
            _movement = entity.GetCompo<PlayerMovement_9>();    
        }
    
    }    
}

