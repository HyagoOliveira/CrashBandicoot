using UnityEngine;

namespace CrashBandicoot.Physicss
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterController))]
    public sealed class CharacterMotor : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;

        [field: SerializeField, Min(0f)]
        public float MoveSpeed { get; set; } = 4f;

        [field: SerializeField]
        public float Gravity { get; set; } = -9.8F;

        public float VerticalSpeed { get; set; }

        public bool IsGrounded { get; private set; }
        public bool IsAirborne => !IsGrounded;
        public bool IsMoveInputting { get; private set; }

        public Vector2 MoveInput { get; private set; }
        public Vector3 Speed { get; private set; }
        public Vector3 Velocity { get; private set; }
        public Vector3 Direction { get; private set; }

        private Transform currentCamera;
        private Vector3 moveDirection;

        private void Reset() => controller = GetComponent<CharacterController>();
        private void Start() => currentCamera = Camera.main.transform;

        private void Update()
        {
            UpdateMovement();
            UpdateRotation();
        }

        public void SetMoveInput(Vector2 input)
        {
            MoveInput = input;
            IsMoveInputting = Mathf.Abs(MoveInput.sqrMagnitude) > 0F;
        }

        private void UpdateMovement()
        {
            UpdateMovingDirection();
            AddGravityIntoVerticalSpeed();

            Speed = MoveSpeed * moveDirection + Vector3.up * VerticalSpeed;
            Velocity = Speed * Time.deltaTime;

            controller.Move(Velocity);

            IsGrounded = controller.isGrounded;
        }

        private void UpdateRotation()
        {
            Direction = transform.position + moveDirection;
            transform.LookAt(Direction);
        }

        private void UpdateMovingDirection()
        {
            moveDirection = IsMoveInputting ?
                GetMoveInputDirectionRelativeToCamera() :
                Vector3.zero;
        }

        private void AddGravityIntoVerticalSpeed()
        {
            const float maxVerticalSpeed = -25F;

            if (IsGrounded && VerticalSpeed < 0F)
            {
                VerticalSpeed = Gravity;
                return;
            }

            VerticalSpeed += Gravity * Time.deltaTime;
            if (VerticalSpeed < maxVerticalSpeed) VerticalSpeed = maxVerticalSpeed;
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