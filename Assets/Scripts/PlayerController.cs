using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float moveSpeed = 10f;

    private Vector2 moveDirection;
    private Rigidbody2D rb;

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
        moveDirection.x = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.position += (moveDirection * moveSpeed) * Time.fixedDeltaTime;
    }

    public Vector2 GetMovementDirection()
    {
        return moveDirection;
    }
}
