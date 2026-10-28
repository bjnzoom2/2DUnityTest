using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rigidbody;

    public float speed = 10.0f;
    public float jumpScale = 9.0f;
    private bool start = false;

    private void Start()
    {
        Debug.Log("Hello");
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.gravityScale = 0.0f;
    }

    private void Update()
    {
        if (start)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput != 0.0f)
            {
                rigidbody.linearVelocityX = horizontalInput * speed;
            }
            else
            {
                rigidbody.linearVelocityX = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidbody.linearVelocity = Vector2.up * jumpScale;
            }
        }
    }

    private void OnEnable()
    {
        LogicHandler.StartGame += () =>
        {
            start = true;
            rigidbody.gravityScale = 2.5f;
        };
    }
}
