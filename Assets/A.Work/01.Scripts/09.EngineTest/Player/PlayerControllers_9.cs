using TopDownView.Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Code.Player
{
    public class PlayerControllers_9 : MonoBehaviour
    {
        [SerializeField] private PlayerInputSO_9 inputSO;
        [SerializeField] private PlayerMovement_9 playerMovement;
        private Player_9 _player;

        private void Awake()
        {
            _player = GetComponent<Player_9>();
        }

        private void OnEnable()
        {
            inputSO.OnMouseStatusChange += HandleClick;
        }

        private void OnDisable()
        {
            inputSO.OnMouseStatusChange -= HandleClick;
        }

        private void HandleClick(bool isPressed)
        {
            if (isPressed == false) return;
            if (_player.GetCurrentState() == "ATTACK")
                return;

            _player.ChangeState("MOVE");   
            
            if (inputSO.GetWorldPosition(out Vector3 clickPoint))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit rayHit, 100f))
                {
                    GameObject targetObject = rayHit.collider.gameObject;
                    
                    if (targetObject.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                    {
                        _player.Attack(targetObject);
                        return;
                    }
                }

                if (NavMesh.SamplePosition(clickPoint, out NavMeshHit hit, 1f, NavMesh.AllAreas))
                {
                    _player.MoveToPosition(hit.position);
                }
            }
        }

        
    }
}
