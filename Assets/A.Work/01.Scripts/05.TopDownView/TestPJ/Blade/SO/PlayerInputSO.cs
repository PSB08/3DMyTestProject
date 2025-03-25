using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "ScriptableObjects/PlayerInputSO")]
public class PlayerInputSO : ScriptableObject
{
    public Vector2 moveInput;
    public bool isMoving = false;
    public bool isClicking = false; 
    public bool isAttacking = false;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isClicking = true; 
        }
        else if (context.canceled)
        {
            isClicking = false; 
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && !isMoving)
        {
            Debug.Log("Q 키가 눌렸습니다.");
            isAttacking = !isAttacking;
            Debug.Log($"isAttacking 상태: {isAttacking}");
        }
    }

    private void OnEnable()
    {
        isClicking = false;
        isAttacking = false;
        isMoving = false;
    }

    private void OnDisable()
    {
        isClicking = false;
        isAttacking = false;
        isMoving = false;
    }
}