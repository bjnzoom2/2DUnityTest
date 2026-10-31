using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    public float targetSpeed = 6.5f;
    public float jumpScale = 9.0f;
    private bool start = false;
    private float xVelocity = 0.0f;
    private float accelTime = 0.1f;
    private float horizontalInput;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Debug.Log("Hello");

        rigidbody.gravityScale = 0.0f;
    }

    private void Update()
    {
        if (start)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidbody.linearVelocityY = jumpScale;
            }
        }
    }

    private void FixedUpdate()
    {
        if (start)
        {
            float targetXVelocity = horizontalInput * targetSpeed;
            xVelocity = Mathf.MoveTowards(xVelocity, targetXVelocity, targetSpeed / accelTime * Time.fixedDeltaTime);
            rigidbody.linearVelocityX = xVelocity;
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
