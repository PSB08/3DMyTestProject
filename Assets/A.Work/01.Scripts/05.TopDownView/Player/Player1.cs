using TMPro;
using UnityEngine;


namespace TopDownView.Player
{
    public class Player1 : MonoBehaviour
    {
        [SerializeField] private CharacterMovement1 movement;
        [SerializeField] private PlayerInputSO playerInput;
        [SerializeField] private TextMeshProUGUI sprintTxt;
        private bool isSprinted = false;

        private void Start()
        {
            sprintTxt.text = "Walk";
        }

        private void Awake()
        {
            playerInput.OnMovementChange += HandleMovementChange;
            playerInput.OnJumpPressed += HandleJumpPressed;
            playerInput.OnRunPressed += HandleRunPressed;
            playerInput.OnAttackPressed += HandleAttackPressed;
        }

        private void OnDestroy()
        {
            playerInput.OnMovementChange -= HandleMovementChange;
            playerInput.OnJumpPressed -= HandleJumpPressed;
            playerInput.OnRunPressed -= HandleRunPressed;
            playerInput.OnAttackPressed -= HandleAttackPressed;
        }

        private void HandleMovementChange(Vector2 movementnput)
        {
            movement.SetMovementDirection(movementnput);
        }

        private void HandleJumpPressed()
        {
            movement.Jump();
        }

        public void HandleRunPressed()
        {
            isSprinted = !isSprinted;
            if (isSprinted)
            {
                movement.SetSprint(true);
                sprintTxt.text = "Running";
            }
            else
            {
                movement.SetSprint(false);
                sprintTxt.text = "Walk";
            }
        }

        private void HandleAttackPressed()
        {
            
        }


    }
}

