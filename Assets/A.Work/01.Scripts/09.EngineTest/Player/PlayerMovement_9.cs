using Code.Entities;
using UnityEngine;

namespace Code.Player
{
    public class PlayerMovement_9 : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private UnityEngine.AI.NavMeshAgent agent;
        [SerializeField] private float stopThreshold = 0.6f;

        private Entity _entity;

        public bool IsArrived => !agent.pathPending && agent.remainingDistance <= stopThreshold;

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void SetDestination(Vector3 destination)
        {
            agent.isStopped = false;
            agent.SetDestination(destination);
        }

        public void StopImmediately()
        {
            if (agent != null)
            {
                agent.isStopped = true;
                agent.ResetPath();
            }
        }

        private void Update()
        {
            // 선택 사항: 회전 수동 보정 (필요 시만)
            if (agent.velocity.sqrMagnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(agent.velocity.normalized);
                _entity.transform.rotation = Quaternion.Lerp(_entity.transform.rotation, targetRotation, Time.deltaTime * agent.angularSpeed);
            }
        }

    
    }
    
}

