using UnityEngine;
using HeresyRun.Core;

namespace HeresyRun.Player
{
    /// <summary>
    /// Movimiento básico 2D: lateral, salto, animaciones.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [Header("Movimiento")]
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 12f;
        [SerializeField] private LayerMask _groundMask;

        private Rigidbody2D _rb;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private bool _grounded = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Move();
            Jump();
            UpdateAnimations();
        }

        private void Move()
        {
            float move = InputHandler.Instance.GetHorizontal();
            _rb.linearVelocity = new Vector2(move * _moveSpeed, _rb.linearVelocity.y);

            // Flip sprite según dirección
            if (move != 0)
                _spriteRenderer.flipX = move < 0;
        }

        private void Jump()
        {
            if (InputHandler.Instance.GetJump() && IsGrounded())
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
                _animator.SetTrigger("Jump");
            }
        }

        private bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, _groundMask);
            _grounded = hit.collider != null;
            return _grounded;
        }

        private void UpdateAnimations()
        {
            float move = Mathf.Abs(InputHandler.Instance.GetHorizontal());
            _animator.SetBool("isRunning", move > 0);
            _animator.SetBool("isGrounded", _grounded);
        }
    }
}