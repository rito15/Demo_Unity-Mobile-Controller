using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rito.Demo.MobileControl
{
    public class MobileCharacterController : MonoBehaviour
    {
        [Header("Instances")]
        public Transform _playerTr;
        public Transform _camRigTr;
        public Transform _camTr;
        public Lean.Gui.LeanJoystick _joystick;
        public TouchTranslateInput _touchTranslateInput;
        public TouchPinchInput _touchPinchInput;

        [Header("Options")]
        [Range(0f, 20f)] public float _moveSpeed = 10f;
        [Range(0f, 20f)] public float _rotSpeed = 15f;
        [Range(0f, 10f)] public float _zoomSpeed = 3f;

        [Range(-30f, 0f)] public float _minRotationX = -15f;
        [Range(0f, 30f)] public float _maxRotationX = 25f;

        [Range(-12f, -6f)] public float _minZoomZ = -9f;
        [Range(-6f, -1f)] public float _maxZoomZ = -3f;

        private void Update()
        {
            float d = Time.deltaTime;

            RotatePlayerHorizontal(d);
            RotateCamVertical(d);
            MovePlayer(d);
            ZoomCamera(d);
        }

        private void MovePlayer(float d)
        {
            Vector2 j = _joystick.ScaledValue;
            Vector3 move = new Vector3(j.x, 0f, j.y);

            _playerTr.Translate(_moveSpeed * d * move, Space.Self);
        }

        private void RotatePlayerHorizontal(float d)
        {
            float v = _touchTranslateInput.ScaledDeltaWithDamping.x;
            if (v == 0f) return;

            Vector3 rot = _rotSpeed * d * v * Vector3.up;
            _playerTr.Rotate(rot, Space.Self);
        }

        private void RotateCamVertical(float d)
        {
            float v = -_touchTranslateInput.ScaledDeltaWithDamping.y;
            if (v == 0f) return;

            Vector3 rot = _rotSpeed * d * v * Vector3.right;

            Quaternion nextRot = _camRigTr.localRotation * Quaternion.Euler(rot);
            Vector3 nextRotEuler = nextRot.eulerAngles;

            float nextX = nextRotEuler.x;
            if (nextX > 180f) nextX -= 360f;

            if (_minRotationX < nextX && nextX < _maxRotationX)
                _camRigTr.localRotation = nextRot;
        }

        private void ZoomCamera(float d)
        {
            const float UNIT_CORRECTION = 100f;
            float v = _touchPinchInput.PinchDeltaWithDamping;
            if (v == 0f) return;

            float zoom = _zoomSpeed * d * v * UNIT_CORRECTION;

            Vector3 lp = _camTr.localPosition;
            float nextZ = lp.z + zoom;

            if (_minZoomZ < nextZ && nextZ < _maxZoomZ)
            {
                _camTr.localPosition = new Vector3(lp.x, lp.y, nextZ);
            }
        }
    }
}


