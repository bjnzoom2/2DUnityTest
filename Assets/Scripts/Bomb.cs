using UnityEngine;

public class Bomb : MonoBehaviour
{
    private GameObject playerTarget;
    private Vector3 targetPosition;
    public float speed = 5.0f;
    private float timer = 0.0f;
    public float duration = 3.0f;
    public float rotationStrength = 800.0f;

    private void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        if (playerTarget != null)
        {
            targetPosition = playerTarget.transform.position;
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        transform.Rotate(new Vector3(0.0f, 0.0f, (rotationStrength - (rotationStrength / duration) * timer) * Time.deltaTime));

        if (transform.position.x > 25.0f || transform.position.x < -25.0f)
        {
            Destroy(gameObject);
        }

        if (timer >= duration)
        {
            Debug.Log("Boom");
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
    }
}
