using UnityEngine;

public class PlayerInputManager3 : MonoBehaviour
{
    public PlayerInputSO playerInputSO;
    private Controls3 controls;

    private void Awake()
    {
        controls = new Controls3();
        
        controls.Player.Move.performed += ctx => playerInputSO.OnMove(ctx);
        
        controls.Player.Click.performed += ctx => playerInputSO.OnClick(ctx);
        controls.Player.Click.canceled += ctx => playerInputSO.OnClick(ctx);
        
        controls.Player.Attack.performed += ctx => playerInputSO.OnAttack(ctx);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    
}
