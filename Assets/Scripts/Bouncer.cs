using UnityEngine;

public class Bouncer : MonoBehaviour, IDamager
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    public float bouncerSpeed = 5.0f;
    private int bounceCount = 0;
    public int maxBounce = 3;
    private Vector3 movingVector;
    private Vector3 direction;
    public float Damage
    {
        get; private set;
    }

    void Start()
    {
        this.Damage = 50.0f;
        direction = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        movingVector = direction * bouncerSpeed * Time.deltaTime;

        if (bounceCount <= maxBounce)
        {
            if ((transform.position + movingVector).x > 15.0f || (transform.position + movingVector).x < -15.0f)
            {
                float overshoot = (movingVector.x > 0.0f) ? (transform.position + movingVector).x - 15.0f : (transform.position + movingVector).x + 15.0f;
                transform.position = (movingVector.x > 0.0f) ? new Vector3(15.0f - overshoot, transform.position.y, 0.0f) : new Vector3(-15.0f - overshoot, transform.position.y, 0.0f);
                direction = new Vector3(-direction.x, direction.y, 0.0f);
                bounceCount++;
                return;
            }

            if ((transform.position + movingVector).y > 7.075f || (transform.position + movingVector).y < -7.075)
            {
                float overshoot = (movingVector.y > 0.0f) ? (transform.position + movingVector).y - 7.075f : (transform.position + movingVector).y + 7.075f;
                transform.position = (movingVector.y > 0.0f) ? new Vector3(transform.position.x, 7.075f - overshoot, 0.0f) : new Vector3(transform.position.x, -7.075f - overshoot, 0.0f);
                direction = new Vector3(direction.x, -direction.y, 0.0f);
                bounceCount++;
                return;
            }
        }

        movingVector = direction * bouncerSpeed * Time.deltaTime;

        transform.position += movingVector;

        if (transform.position.x > 25.0f || transform.position.x < -25.0f || transform.position.y > 25.0f || transform.position.y < -25.0f)
        {
            Destroy(gameObject);
            return;
        }
    }
}
