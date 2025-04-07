using Code.Player;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField] private PlayerInputSO_9 _playerInput;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _cameraTransform;

    [Space(10)]
    [Header("이동 속도")]
    public float moveSpeed = 5f;
    public float scrollSpeed = 10f;

    [Space(10)]
    [Header("이동 제한 범위")]
    // 이동 제한 범위 설정
    public float minX = -10f, maxX = 10f;
    public float minY = -5f, maxY = 5f;

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (_playerInput == null) return;

        Vector2 movementInput = _playerInput.MovementKey;

        // 좌우 이동 (카메라 기준)
        Vector3 camRight = _cameraTransform.right;
        camRight.y = 0;
        camRight.Normalize();

        // 위/아래 이동 (월드 기준)
        Vector3 verticalMove = Vector3.up * movementInput.y;

        // 마우스 휠 Z축 이동
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Vector3 forwardMove = _cameraTransform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        Vector3 scrollMove = forwardMove * scrollInput * scrollSpeed;

        // 최종 이동 방향 (X, Y, Z 조합)
        Vector3 moveDirection = camRight * movementInput.x + verticalMove + scrollMove;

        if (moveDirection.sqrMagnitude > 0)
        {
            moveDirection.Normalize();
        }

        Vector3 newPosition = _rigidbody.position + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        // X, Y 제한 적용
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        // Z는 제한 없이 자유롭게

        _rigidbody.MovePosition(newPosition);
    }

}
