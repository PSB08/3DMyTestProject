using Code.Player;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField] private PlayerInputSO_9 _playerInput;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _cameraTransform; 
    public float moveSpeed = 5f;
        
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (_playerInput == null) return;

        Vector2 movementInput = _playerInput.MovementKey;

        // 카메라 기준 X축 (좌우) 방향 계산
        Vector3 camRight = _cameraTransform.right;
        camRight.y = 0;
        camRight.Normalize();

        // worldMoveDirection: X축은 카메라 기준으로, Y축은 movementInput.y 그대로
        Vector3 worldMoveDirection = camRight * movementInput.x + Vector3.up * movementInput.y;

        if (worldMoveDirection.sqrMagnitude > 0)
        {
            worldMoveDirection.Normalize();
        }

        _rigidbody.MovePosition(_rigidbody.position + worldMoveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

}
