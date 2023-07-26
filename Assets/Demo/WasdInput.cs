using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rito.Demo.MobileControl
{
    [DisallowMultipleComponent]
    public class WasdInput : MonoBehaviour
    {
        public Vector2 ScaledValue { get; private set; }

        private void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            ScaledValue = new Vector2(x, y).normalized;
        }
    }
}