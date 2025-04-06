using UnityEngine;
using Code.Entities;

namespace Code.FSM
{
    public abstract class EntityState_9
    {
        protected Entity _entity;
        protected int _animationHash;
        protected EntityAnimator_9 _entityAnimator;
        protected EntityAnimatorTrigger_9 _animatorTrigger;
        protected bool _isTriggerCall;

        protected EntityState_9(Entity entity, int animationHash)
        {
            _entity = entity;
            _animationHash = animationHash;
            _entityAnimator = entity.GetCompo<EntityAnimator_9>();
            _animatorTrigger = entity.GetCompo<EntityAnimatorTrigger_9>();
        }

        public virtual void Enter()
        {
            _entityAnimator.SetParam(_animationHash, true);
            _isTriggerCall = false;
            _animatorTrigger.OnAnimatonEndTrigger += AnimationEndTrigger;
        }

        public virtual void Update(){ }

        public virtual void Exit()
        {
            _animatorTrigger.OnAnimatonEndTrigger -= AnimationEndTrigger;
            _entityAnimator.SetParam(_animationHash, false);
        }

        protected virtual void AnimationEndTrigger() => _isTriggerCall = true;
    
    }
}

