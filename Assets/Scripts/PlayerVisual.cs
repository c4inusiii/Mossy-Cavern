using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Vector2 playerMoveDirection;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private const string IS_RUNNING = "IsRunning";
    private const string IS_JUMPING = "IsJumping";

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        playerMoveDirection = Player.Instance.GetMovementDirection();

        FlipPlayerSprite();
        HandleMovementAnimation();
    }

    private void FlipPlayerSprite()
    {
        if (playerMoveDirection.x < 0)
            spriteRenderer.flipX = true;
        else if (playerMoveDirection.x > 0)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = spriteRenderer.flipX;
    }

    private void HandleMovementAnimation()
    {
        if (Mathf.Abs(playerMoveDirection.x) > 0)
            animator.SetBool(IS_RUNNING, true);
        else
            animator.SetBool(IS_RUNNING, false);
    }
}
