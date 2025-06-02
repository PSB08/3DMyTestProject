using System;
using TMPro;
using UnityEngine;

namespace Scripts.Math
{
    public class YoumuuEasingSpeed : MonoBehaviour
    {
        public enum EasingType
        {
            EaseInSine,
            EaseOutSine,
            EaseInOutSine,
            EaseInExpo,
            EaseOutExpo,
            EaseInOutExpo
        }
        
        public EasingType easingType = EasingType.EaseOutSine;
        [SerializeField] private float boostDuration = 2f;
        [SerializeField] private float maxSpeed = 10f;
        [SerializeField] private float baseSpeed = 3f;
        [SerializeField] private TextMeshProUGUI text;
        
        private float currentSpeed;
        private float boostTimer = 0f;
        private bool isBoosting = false;

        private void Update()
        {
            text.text = currentSpeed.ToString();
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Debug.Log("Youmuu");
                isBoosting = true;
                boostTimer = 0f;
            }

            if (isBoosting)
            {
                boostTimer += Time.deltaTime;
                float t = Mathf.Clamp01(boostTimer / boostDuration);

                float easingValue = ApplyEasing(t, easingType);
                currentSpeed = Mathf.Lerp(maxSpeed, baseSpeed, easingValue);

                if (boostTimer >= boostDuration)
                {
                    isBoosting = false;
                    currentSpeed = 0;
                }
            }

            transform.Translate(Vector3.right * (currentSpeed * Time.deltaTime));
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
                    if (t < 0.5f)
                        return Mathf.Pow(2f, 20f * t - 10f) / 2f;
                    else
                        return (2f - Mathf.Pow(2f, -20f * t + 10f)) / 2f;

                default:
                    return t;
            }
        }

    }    
}

