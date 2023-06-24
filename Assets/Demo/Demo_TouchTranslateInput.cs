using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using CW.Common;

public class Demo_TouchTranslateInput : MonoBehaviour
{
    public LeanFingerFilter Use = new LeanFingerFilter(true);
    [SerializeField] private float sensitivity = 1.0f;
    [Range(0f, 10f)]
    [SerializeField] private float damping = 0f;

    /// <summary>The movement speed will be multiplied by this.
    /// -1 = Inverted Controls.</summary>
    public float Sensitivity { set { sensitivity = value; } get { return sensitivity; } }

    /// <summary>If you want this component to change smoothly over time, then this allows you to control how quick the changes reach their target value.
    /// 0 = Instantly change.
    /// 1 = Quickly change.
    /// 10 = Slowly change.
    /// </summary>
    public float Damping { set { damping = Mathf.Clamp(value, 0f, 10f); } get { return damping; } }


    public Vector2 ScreenDelta { get; private set; }
    public Vector2 ScaledDelta { get; private set; }
    public Vector2 ScreenDeltaWithDamping { get; private set; }
    public Vector2 ScaledDeltaWithDamping { get; private set; }

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

        // Values
        ScreenDelta = LeanGesture.GetScreenDelta(fingers);
        ScaledDelta = LeanGesture.GetScaledDelta(fingers);

        // Smooth Values
        if (damping <= 0f)
        {
            ScreenDeltaWithDamping = ScreenDelta;
            ScaledDeltaWithDamping = ScaledDelta;
        }
        else
        {
            float factor = CwHelper.DampenFactor(10f - damping, Time.deltaTime);
            ScreenDeltaWithDamping = Vector3.Lerp(ScreenDeltaWithDamping, ScreenDelta, factor);
            ScaledDeltaWithDamping = Vector3.Lerp(ScaledDeltaWithDamping, ScaledDelta, factor);
        }
    }
}
