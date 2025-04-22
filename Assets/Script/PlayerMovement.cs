using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;         // public variable uses Pascal casing
    public float JumpForce;     // jump force
    public bool IsJumping;      // check if player is in air

    float move;                 // private variable
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal"); // x-axis input

        // move left and right
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);

        // jump only if not jumping
        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));
            Debug.Log("Jump"); // for debugging purpose
        }
    }

    // when hitting ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }

    // when leaving ground
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
}
