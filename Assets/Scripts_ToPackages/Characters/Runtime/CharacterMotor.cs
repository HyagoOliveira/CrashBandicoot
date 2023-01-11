using System;
using UnityEngine;

namespace ActionCode.Characters
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterAnimator))]
    [RequireComponent(typeof(CharacterController))]
    public sealed class CharacterMotor : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private CharacterAnimator animator;
        [SerializeField] private LayerMask collision;

        [field: SerializeField, Min(0f)]
        public float MoveSpeed { get; set; } = 4f;

        [field: SerializeField]
        public float Gravity { get; set; } = -9.8F;

        public event Action OnLand;
        public event Action OnFallen;

        public float VerticalSpeed { get; set; }

        public bool IsGrounded { get; private set; }
        public bool IsAirborne => !IsGrounded;
        public bool IsRaising => IsAirborne && VerticalSpeed > 0F;
        public bool IsFalling => IsAirborne && VerticalSpeed < 0F;
        public bool IsMoveInputting { get; private set; }
        public bool CanMove { get; set; }

        public Vector2 MoveInput { get; private set; }
        public Vector3 Speed { get; private set; }
        public Vector3 Velocity { get; private set; }

        public RaycastHit GroundHit => groundHit;

        private Transform currentCamera;
        private Vector3 moveDirection;
        private RaycastHit groundHit;
        private bool isGroundCollision;
        private bool wasGroundCollision;

        private void Reset ()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<CharacterAnimator>();
        }

        private void Start()
        {
            currentCamera = Camera.main.transform;
            isGroundCollision = RaycastGround();
        }

        private void Update()
        {
            UpdateMovement();
            UpdateRotation();
            UpdateGroundCollision();
            UpdateAnimations();
        }

        public void SetMoveInput(Vector2 input)
        {
            MoveInput = CanMove ? input : Vector2.zero;
            IsMoveInputting = Mathf.Abs(MoveInput.sqrMagnitude) > 0F;
        }

        public void StopMoveInput ()
        {
            MoveInput = Vector2.zero;
            IsMoveInputting = false;
        }

        public void StopVerticalSpeed () => VerticalSpeed = 0f;

        public bool IsOverSlope()
        {
            if (GroundHit.collider == null) return false;
            var floorAngle = Vector3.Angle(GroundHit.normal, Vector3.up);
            return floorAngle > 0F;
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
            var direction = transform.position + moveDirection;
            transform.LookAt(direction);
        }

        private void UpdateGroundCollision()
        {
            wasGroundCollision = isGroundCollision;
            isGroundCollision = RaycastGround();

            var hasLanded = !wasGroundCollision && isGroundCollision;
            if (hasLanded)
            {
                VerticalSpeed = Gravity;
                OnLand?.Invoke();
                return;
            }

            var hasFallenFromGround = wasGroundCollision && !isGroundCollision && VerticalSpeed < 0F;
            if (hasFallenFromGround)
            {
                VerticalSpeed = 0F;
                OnFallen?.Invoke();
            }
        }

        private void UpdateMovingDirection()
        {
            moveDirection = IsMoveInputting ?
                GetMoveInputDirectionRelativeToCamera() :
                Vector3.zero;
        }

        private void UpdateAnimations ()
        {
            animator.SetIsGrounded(IsGrounded);
            animator.SetIsAirborne(IsAirborne);
            animator.SetIsFalling(IsFalling);
            animator.SetIsMoveInputting(IsMoveInputting);
        }

        private void AddGravityIntoVerticalSpeed()
        {
            const float maxVerticalSpeed = -25F;
            VerticalSpeed += Gravity * Time.deltaTime;
            if (VerticalSpeed < maxVerticalSpeed) VerticalSpeed = maxVerticalSpeed;
        }

        private bool RaycastGround()
        {
            // This value works for CharacterController.SlopeLimit = 45F
            const float distance = 0.2F;
            const float maxDistance = distance * 2F;

            var origin = transform.position + Vector3.up * distance;

            return Physics.Raycast(
                origin,
                direction: Vector3.down,
                out groundHit,
                maxDistance,
                collision,
                queryTriggerInteraction: QueryTriggerInteraction.Ignore
            );
        }

        private Vector3 GetMoveInputDirectionRelativeToCamera()
        {
            var right = currentCamera.right;
            right.y = 0f;
            var forward = Vector3.Cross(right, Vector3.up);
            // do not normalize if player should walk according with move input.
            return (right * MoveInput.x + forward * MoveInput.y).normalized;
        }
    }
}