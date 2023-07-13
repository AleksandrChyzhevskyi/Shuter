using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask _graundMask;

        private GraundCheck _graundCheck;
        private UserInput _userInput;
        private CharacterController _controller;
        private Vector3 _velocity;
        private float _gravity = -9.81f;
        private float _speedMove = 8f;
        private bool _isGrounded;
        private float _groundDistance = 0.5f;
        private float _jumpHeight = 5f;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _graundCheck = GetComponentInChildren<GraundCheck>();           
        }

        private void OnEnable()
        {
            _userInput = GetComponentInParent<PlayerStats>()._userInput;
            _userInput.MovePlayer += Movement;
            _userInput.JumpPlayer += Jumping;
        }

        private void OnDisable()
        {
            _userInput.MovePlayer -= Movement;
            _userInput.JumpPlayer -= Jumping;
        }

        private void Update()
        {
            Graunded();
            Gravity();
        }

        private void Movement(Vector3 move)
        {
            Vector3 playerMove = transform.right * move.x + transform.forward * move.z;
            _controller.Move(playerMove * _speedMove * Time.deltaTime);
        }

        private void Gravity()
        {
            _velocity.y += _gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }

        private void Graunded()
        {
            _isGrounded = Physics.CheckSphere(_graundCheck.gameObject.transform.position, _groundDistance, _graundMask);

            if(_isGrounded && _velocity.y < 0f)            
                _velocity.y = -2f;            
        }

        private void Jumping()
        {
            if(_isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
        }
    }
}
