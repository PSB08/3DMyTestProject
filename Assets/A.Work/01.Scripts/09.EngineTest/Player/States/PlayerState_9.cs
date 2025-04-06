using Code.Entities;
using Code.FSM;

namespace Code.Player.States
{
    public class PlayerState_9 : EntityState_9
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

