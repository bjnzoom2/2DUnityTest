using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PolygonCollider2D collider;

    public float bulletSpeed = 8.0f;
    public float bulletDirection = -1.0f;

    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(bulletDirection, 0.0f, 0.0f) * Time.deltaTime;
    }
}
