using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour
{
    public EntityState idleState;
    public EntityState moveState;
    public EntityState attackState;

    public EntityAnimator entityAnimator; 
    public CharacterController characterController;

    public float speed = 3f;
    public Vector3 targetPosition;
    public bool isMoving = false; 
    public PlayerInputSO playerInput;

    public GameObject attackEffectPrefab; 
    private GameObject currentAttackEffect; 
    public Image attackIndicator; 

    private EntityState currentState;

    public TextMeshProUGUI stateText;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        ChangeState(idleState);
    }

    private void Update()
    {
        currentState?.Handle(this); 
        HandleAttackState();
    }
    
    private void HandleAttackState()
    {
        if (playerInput.isAttacking && currentState == idleState)
        {
            if (playerInput.isClicking)
            {
                ChangeState(attackState);
            }
            else
            {
                attackIndicator.color = Color.yellow; 
            }
        }
        else
        {
            attackIndicator.color = Color.white;
        }
    }

    public void ChangeState(EntityState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
        
        if (stateText != null)
        {
            stateText.text = newState.GetType().Name.Replace("State", ""); 
        }
    }

    public void ExecuteAttack()
    {
        entityAnimator.SetParam("Attack"); 
        entityAnimator.SetParam("isAttacking", true); 
    }

    public void AnimationEnd()
    {
        playerInput.isAttacking = false;
        if (currentAttackEffect != null)
        {
            Destroy(currentAttackEffect);
        }
        
        if (attackEffectPrefab != null)
        {
            Vector3 attackPosition = targetPosition;
            attackPosition.y += 0.1f; 

            currentAttackEffect = Instantiate(attackEffectPrefab, attackPosition, Quaternion.identity);
        }

        entityAnimator.SetParam("isAttacking", false); 
        ChangeState(idleState);
    }
}