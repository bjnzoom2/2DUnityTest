using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PolygonCollider2D collider;

    public float bulletSpeed = 8.0f;
    public float bulletDirection = -1.0f;

    private void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(bulletDirection, 0.0f, 0.0f) * bulletSpeed * Time.deltaTime;
        transform.Rotate(0.0f, 0.0f, 45.0f * Time.deltaTime);

        if (transform.position.x > 25.0f || transform.position.x < -25.0f)
        {
            Destroy(gameObject);
        }
    }
}
