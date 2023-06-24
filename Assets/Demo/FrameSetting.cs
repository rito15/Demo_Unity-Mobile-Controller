using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSetting : MonoBehaviour
{
    void Start()
    {
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
        Application.targetFrameRate = 60;
#else
        Application.targetFrameRate = 240;
#endif
    }
}
