using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speedMove = 20f;
    [SerializeField] private float speedJump = 10f;
    [SerializeField] private float rayDistance = 3f;
    public LayerMask groundLayer;
    private SpriteRenderer pl;
    private Rigidbody2D rb;
    private PlayerState state;
    private bool lookRight;

    public PlayerState State { get => state; set => state = value; } 
    public Rigidbody2D Rb { get => rb; set => rb = value; }

    void Start()
    {
        // take component from object 
        rb = GetComponent<Rigidbody2D>();
        state = PlayerState.Idle;
        lookRight = true;
        pl = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // runing logic
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Run();
        }
        // idle logic
        else if (!Input.anyKey && state != PlayerState.Jumping)
        {
            Idle();
        }
        // jumpic logic
        if (state != PlayerState.Jumping && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (IsGrounded() && rb.linearVelocityY <= 0.1)
        {
            if (!Input.anyKey)
                state = PlayerState.Idle;
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                state = PlayerState.Running;
        }
    }


    private void Flip()
    {
        pl.flipX = !pl.flipX;
        lookRight = !lookRight;
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);
        return Physics2D.Raycast(transform.position, Vector3.down, rayDistance, groundLayer);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, speedJump), ForceMode2D.Impulse);
        state = PlayerState.Jumping;
    }

    private void Run()
    {
        rb.linearVelocityX = Input.GetAxis("Horizontal") * speedMove;
        if (state != PlayerState.Jumping)
            state = PlayerState.Running;
        if (
            (Input.GetAxis("Horizontal") > 0 && !lookRight) ||
            (Input.GetAxis("Horizontal") < 0 && lookRight)
           )
            Flip();
    }

    private void Idle()
    {
        rb.linearVelocityX = 0;
        state = PlayerState.Idle;
    }

}