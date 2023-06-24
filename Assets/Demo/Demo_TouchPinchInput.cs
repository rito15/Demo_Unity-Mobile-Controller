using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using CW.Common;

public class Demo_TouchPinchInput : MonoBehaviour
{
    public LeanFingerFilter Use = new LeanFingerFilter(true);
    [SerializeField] private float sensitivity = 1.0f;
    [Range(0f, 10f)]
    [SerializeField] private float damping = 0f;

    /// <summary>The sensitivity of the scaling.
    /// 1 = Default.
    /// 2 = Double.</summary>
    public float Sensitivity { set { sensitivity = value; } get { return sensitivity; } }

    /// <summary>If you want this component to change smoothly over time, then this allows you to control how quick the changes reach their target value.
    /// 0 = Instantly change.
    /// 1 = Quickly change.
    /// 10 = Slowly change.
    /// </summary>
    public float Damping { set { damping = Mathf.Clamp(value, 0f, 10f); } get { return damping; } }

    public float Pinch { get; private set; }
    public float PinchDelta { get; private set; }
    public float PinchDeltaWithDamping { get; private set; }

#if UNITY_EDITOR
    private void Reset()
    {
        Use.UpdateRequiredSelectable(gameObject);
    }
#endif

    private void Awake()
    {
        Use.UpdateRequiredSelectable(gameObject);
    }

    private void Update()
    {
        var fingers = Use.UpdateAndGetFingers();

        // Pinch Values
        var pinchScale = LeanGesture.GetPinchScale(fingers);
        Pinch = Mathf.Pow(pinchScale, sensitivity);
        PinchDelta = Pinch - 1f;

        // Smooth Pinch
        if (damping <= 0f)
        {
            PinchDeltaWithDamping = PinchDelta;
        }
        else
        {
            float factor = CwHelper.DampenFactor(10f - damping, Time.deltaTime);
            PinchDeltaWithDamping = Mathf.Lerp(PinchDeltaWithDamping, PinchDelta, factor);
        }
    }
}
