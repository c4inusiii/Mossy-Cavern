using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] LayerMask platformLayer;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundCheckDistance = 0.2f;

    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.freezeRotation = true;
    }

    private void Update()
    {
        moveDirection = GameInput.Instance.GetMoveDirection();
        IsGrounded();
    }

    private void FixedUpdate()
    {
        Move(moveDirection);
        Jump();
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }


    private void IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, platformLayer);

        if (hit.collider != null)
            isGrounded = true;
        else
            isGrounded = false;
    }

    private void Move(Vector2 direction)
    {
        rb.position += (direction * moveSpeed) * Time.fixedDeltaTime;
    }

    private void Jump()
    {
        if (GameInput.Instance.GetJumpPressed() > 0 && isGrounded)
            rb.AddForce(Vector2.up * jumpForce);
    }
}
