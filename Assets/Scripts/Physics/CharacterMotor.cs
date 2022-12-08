using UnityEngine;

namespace CrashBandicoot.Physicss
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterController))]
    public sealed class CharacterMotor : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField, Min(0f)] private float speed = 4f;

        public Vector3 Velocity { get; private set; }

        public Vector3 Direction { get; private set; }

        private Transform currentCamera;
        private Vector3 movingDirection;

        private void Reset()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Start()
        {
            currentCamera = Camera.main.transform;
        }

        private void Update()
        {
            UpdateMovement();
            UpdateRotation();
        }

        public void Move(Vector2 direction)
        {
            var absoluteMagnitude = Mathf.Abs(direction.sqrMagnitude);
            var isMoving = absoluteMagnitude > 0F;
            movingDirection = isMoving ?
                GetDirectionRelativeFromCamera(direction) :
                Vector3.zero;
        }

        public bool HasVelocity() => Mathf.Abs(Velocity.sqrMagnitude) > 0f;

        private void UpdateMovement()
        {
            Velocity = speed * Time.deltaTime * movingDirection;
            controller.Move(Velocity);
        }

        private void UpdateRotation()
        {
            Direction = transform.position + Velocity;
            transform.LookAt(Direction);
        }

        private Vector3 GetDirectionRelativeFromCamera(Vector2 input)
        {
            var cameraRight = currentCamera.right;
            var forward = Vector3.Cross(cameraRight, Vector3.up);
            return cameraRight * input.x + forward * input.y;
        }
    }
}