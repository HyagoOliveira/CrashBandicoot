using UnityEngine;

namespace CrashBandicoot.Physicss
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterController))]
    public sealed class CharacterMotor : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField, Min(0f)] private float horizontalSpeed = 4f;

        [field: SerializeField]
        public float Gravity { get; set; } = -9.8F;

        public bool IsGrounded { get; private set; }
        public bool HasVelocity { get; private set; }

        public Vector2 MoveInput { get; set; }
        public Vector3 Speed { get; private set; }
        public Vector3 Velocity { get; private set; }
        public Vector3 Direction { get; private set; }

        private Transform currentCamera;
        private Vector3 movingDirection;

        private void Reset() => controller = GetComponent<CharacterController>();
        private void Start() => currentCamera = Camera.main.transform;

        private void Update()
        {
            UpdateMovement();
            UpdateRotation();
        }

        public bool IsMoveInputting() => Mathf.Abs(MoveInput.sqrMagnitude) > 0F;

        private void UpdateMovement()
        {
            UpdateMovingDirection();
            UpdateVerticalSpeed();

            Speed = horizontalSpeed * movingDirection + Vector3.up * Gravity;
            Velocity = Speed * Time.deltaTime;

            controller.Move(Velocity);

            IsGrounded = controller.isGrounded;
            HasVelocity = Mathf.Abs(Velocity.sqrMagnitude) > 0f;
        }

        private void UpdateRotation()
        {
            Direction = transform.position + movingDirection;
            transform.LookAt(Direction);
        }

        private void UpdateMovingDirection()
        {
            movingDirection = IsMoveInputting() ?
                GetMoveInputDirectionRelativeToCamera() :
                Vector3.zero;
        }

        private void UpdateVerticalSpeed()
        {
        }

        private Vector3 GetMoveInputDirectionRelativeToCamera()
        {
            var right = currentCamera.right;
            right.y = 0f;
            var forward = Vector3.Cross(right, Vector3.up);
            return right * MoveInput.x + forward * MoveInput.y;
        }
    }
}