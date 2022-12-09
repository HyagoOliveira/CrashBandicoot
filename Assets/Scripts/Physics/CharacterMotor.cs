using UnityEngine;

namespace CrashBandicoot.Physicss
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterController))]
    public sealed class CharacterMotor : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField, Min(0f)] private float speed = 4f;

        public Vector2 MoveInput { get; set; }
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

        public bool HasVelocity() => Mathf.Abs(Velocity.sqrMagnitude) > 0f;

        private void UpdateMovement()
        {
            UpdateMovingDirection();

            Velocity = speed * Time.deltaTime * movingDirection;
            controller.Move(Velocity);
        }

        private void UpdateRotation()
        {
            Direction = transform.position + Velocity;
            transform.LookAt(Direction);
        }

        private void UpdateMovingDirection()
        {
            var absoluteMagnitude = Mathf.Abs(MoveInput.sqrMagnitude);
            var isMoving = absoluteMagnitude > 0F;
            movingDirection = isMoving ?
                GetMoveInputDirectionRelativeToCamera() :
                Vector3.zero;
        }

        private Vector3 GetMoveInputDirectionRelativeToCamera()
        {
            var right = currentCamera.right;
            var forward = Vector3.Cross(right, Vector3.up);
            return right * MoveInput.x + forward * MoveInput.y;
        }
    }
}