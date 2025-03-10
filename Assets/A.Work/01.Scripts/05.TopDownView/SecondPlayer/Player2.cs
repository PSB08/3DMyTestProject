using TMPro;
using TopDownView.Player;
using UnityEngine;

namespace TopDownView.SecondPlayer
{
    public class Player2 : MonoBehaviour
    {
        [SerializeField] private CharacterMovement2 movement;
        [SerializeField] private PlayerInputSO2 playerInput;
        [SerializeField] private TextMeshProUGUI sprintTxt;

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

        public void HandleRunPressed(bool isSprinting)
        {
            this.movement.SetSprint(isSprinting);
            if (isSprinting)
                sprintTxt.text = "Running";
            else
                sprintTxt.text = "Walk";
        }

        private void HandleAttackPressed()
        {
            Debug.Log("Blue Player Attack");
        }


    }
}
