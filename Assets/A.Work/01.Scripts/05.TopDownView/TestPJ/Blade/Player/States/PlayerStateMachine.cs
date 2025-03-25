using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("Value")]
    public float speed = 3f;
    public Vector3 targetPosition;
    [Space(10)]
    [Header("Prefabs")]
    [SerializeField] private GameObject attackEffectPrefab; 
    private GameObject currentAttackEffect; 
    [Space(10)]
    [Header("Scriptable Objects")]
    public EntityState idleState;
    public EntityState moveState;
    public EntityState attackState;
    private EntityState currentState;
    public PlayerInputSO playerInput;
    [Space(10)]
    [Header("Components")]
    public EntityAnimator entityAnimator; 
    public CharacterController characterController;
    [Space(10)]
    [Header("UI")]
    public Image attackIndicator; 
    public TextMeshProUGUI stateText;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        ChangeState(idleState);
    }

    private void Update()
    {
        currentState?.Handle(this);
        if (!playerInput.isMoving)
        {
            HandleAttackState();
        }
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

    public void AnimationEnd()
    {
        if (currentAttackEffect != null)
        {
            Destroy(currentAttackEffect);
        }
        
        if (attackEffectPrefab != null)
        {
            Vector3 attackPosition = targetPosition;
            currentAttackEffect = Instantiate(attackEffectPrefab, attackPosition, Quaternion.identity);
        }
        playerInput.isAttacking = false;
        entityAnimator.SetParam("isAttacking", false); 
        ChangeState(idleState);
    }
}