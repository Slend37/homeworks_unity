using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speedMove = 2f;
    [SerializeField] private float speedJump = 10f;
    private bool jump = true;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.linearVelocityX = Input.GetAxis("Horizontal") * speedMove;
        }

        if (jump && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, speedJump), ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!jump)
        {
            jump = true;
        }
    }
}
