using TMPro;
using UnityEngine;

namespace Scripts.Math
{
    public class HecarimEasingSpeed : MonoBehaviour
    {
       public enum EasingType
        {
            EaseInSine,
            EaseOutSine,
            EaseInOutSine,
            EaseInExpo,
            EaseOutExpo,
            EaseInOutExpo,
            EaseInOutExpoShifted25_75,
            EaseInOutExpoShifted75_25
        }

        public EasingType easingType = EasingType.EaseOutSine;
        [SerializeField] private float moveDuration = 2f;
        [SerializeField] private float moveDistance = 10f;
        //[SerializeField] private TextMeshProUGUI text;

        private float _moveTimer = 0f;
        private bool _isMoving = false;

        private Vector3 _startPos;
        private Vector3 _endPos;

        private void Update()
        {
            //text.text = transform.position.x.ToString("F2");

            if (Input.GetKeyDown(KeyCode.E) && !_isMoving)
            {
                Debug.Log("Hecarim Move Start");
                _isMoving = true;
                _moveTimer = 0f;

                _startPos = transform.position;
                _endPos = _startPos + Vector3.right * moveDistance;
            }

            if (_isMoving)
            {
                _moveTimer += Time.deltaTime;
                float t = Mathf.Clamp01(_moveTimer / moveDuration);

                float easingValue = ApplyEasing(t, easingType);
                transform.position = Vector3.Lerp(_startPos, _endPos, easingValue);

                if (t >= 1f)
                {
                    _isMoving = false;
                }
            }
        }

        private float ApplyEasing(float t, EasingType type)
        {
            switch (type)
            {
                case EasingType.EaseInSine:
                    return 1f - Mathf.Cos((t * Mathf.PI) / 2f);
                case EasingType.EaseOutSine:
                    return Mathf.Sin((t * Mathf.PI) / 2f);
                case EasingType.EaseInOutSine:
                    return -(Mathf.Cos(Mathf.PI * t) - 1f) / 2f;

                case EasingType.EaseInExpo:
                    return t == 0f ? 0f : Mathf.Pow(2f, 10f * (t - 1f));
                case EasingType.EaseOutExpo:
                    return t == 1f ? 1f : 1f - Mathf.Pow(2f, -10f * t);
                case EasingType.EaseInOutExpo:
                    if (t == 0f) return 0f;
                    if (t == 1f) return 1f;
                    return t < 0.5f
                        ? Mathf.Pow(2f, 20f * t - 10f) / 2f
                        : (2f - Mathf.Pow(2f, -20f * t + 10f)) / 2f;
                case EasingType.EaseInOutExpoShifted25_75:
                    return ShiftedEasing(t, EasingType.EaseInOutExpo, 0.25f, 0.75f);
                case EasingType.EaseInOutExpoShifted75_25:
                    return ShiftedEasing(t, EasingType.EaseInOutExpo, 0.75f, 0.25f);
                default:
                    return t;
            }
        }

        private float ShiftedEasing(float t, EasingType originalType, float midX, float midY)
        {
            float x = (t - midX) / 0.5f + 0.5f;
            x = Mathf.Clamp01(x);

            float y = ApplyEasing(x, originalType);

            float scale = midY < 0.5f ? 2f * midY : 2f * (1f - midY);
            return Mathf.Clamp01((y - 0.5f) * scale + 0.5f);
        }
        
        
    }    
}

