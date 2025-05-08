using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private PlayerController _playerController;

    private const string IS_RUNNING = "IsRunning";
    private const string IS_JUMPING = "IsJumping";

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerController = PlayerController.Instance;
    }

    private void Update()
    {
        FlipPlayerSprite();
        HandleMovementAnimation();
        HandleJumpAnimation();
    }

    private void FlipPlayerSprite()
    {
        if (_playerController.GetMoveDirection().x < 0)
            spriteRenderer.flipX = true;
        else if (_playerController.GetMoveDirection().x > 0)
            spriteRenderer.flipX = false;
    }

    private void HandleMovementAnimation()
    {
        if (Mathf.Abs(_playerController.GetMoveDirection().x) > 0)
            animator.SetBool(IS_RUNNING, true);
        else
            animator.SetBool(IS_RUNNING, false);
    }

    private void HandleJumpAnimation()
    {
        animator.SetBool(IS_JUMPING, !_playerController.GetIsGrounded());
    }
}
