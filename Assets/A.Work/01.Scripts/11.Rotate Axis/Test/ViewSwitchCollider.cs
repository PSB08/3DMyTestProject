using UnityEngine;
using UnityEngine.Serialization;

public class ViewSwitchCollider : MonoBehaviour
{
    public bool is2D;
    private Collider col;

    private void Awake() => col = GetComponent<Collider>();

    public void SetView(bool is2D)
    {
        col.enabled = (this.is2D == is2D);
    }
}
