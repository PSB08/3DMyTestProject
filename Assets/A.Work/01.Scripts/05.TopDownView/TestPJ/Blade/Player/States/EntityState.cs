using UnityEngine;

[CreateAssetMenu(fileName = "NewEntityState", menuName = "EntityState")]
public class EntityState : ScriptableObject
{
    public virtual void Enter(PlayerStateMachine player) {}
    public virtual void Exit(PlayerStateMachine player) {}
    public virtual void Handle(PlayerStateMachine player) {} 
}
