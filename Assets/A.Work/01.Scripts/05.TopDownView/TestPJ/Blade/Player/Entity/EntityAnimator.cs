using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Animator animator;
    public void SetParam(string paramName, float value) => animator.SetFloat(paramName, value);
    public void SetParam(string paramName, int value) => animator.SetInteger(paramName, value);
    public void SetParam(string paramName, bool value) => animator.SetBool(paramName, value);
    public void SetParam(string paramName) => animator.SetTrigger(paramName);
}