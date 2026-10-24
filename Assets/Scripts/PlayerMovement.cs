using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rigidbody;

    public float speed = 10.0f;
    public float jumpScale = 8.0f;

    private void Start()
    {
        Debug.Log("Hello");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0.0f)
        {
            rigidbody.linearVelocityX = horizontalInput * speed;
        } else
        {
            rigidbody.linearVelocityX = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody.linearVelocity = Vector2.up * jumpScale;
        }
    }
}
