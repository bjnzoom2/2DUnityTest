using System;
using UnityEngine;

public class Bouncer : MonoBehaviour, IDamager
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    public float bouncerSpeed = 9.5f;
    private int bounceCount = 0;
    public int maxBounce = 3;
    private Vector3 movingVector;
    private Vector3 direction;
    private bool enteredBorders = false;
    public float Damage
    {
        get; private set;
    }

    private float xBounds = 13.25f;
    private float yBounds = 7.075f;

    private void Start()
    {
        this.Damage = 40.0f;
        direction = transform.right;
    }

    // Update is called once per frame
    private void Update()
    {
        movingVector = direction * bouncerSpeed * Time.deltaTime;

        if (bounceCount <= maxBounce && enteredBorders)
        {
            if ((transform.position + movingVector).x > xBounds || (transform.position + movingVector).x < -xBounds)
            {
                float overshoot = (movingVector.x > 0.0f) ? (transform.position + movingVector).x - xBounds : (transform.position + movingVector).x + xBounds;
                transform.position = (movingVector.x > 0.0f) ? new Vector3(xBounds - overshoot, transform.position.y, 0.0f) : new Vector3(-xBounds - overshoot, transform.position.y, 0.0f);
                direction = new Vector3(-direction.x, direction.y, 0.0f);
                bounceCount++;
                OnBounce?.Invoke();
                return;
            }

            if ((transform.position + movingVector).y > yBounds || (transform.position + movingVector).y < -yBounds)
            {
                float overshoot = (movingVector.y > 0.0f) ? (transform.position + movingVector).y - yBounds : (transform.position + movingVector).y + yBounds;
                transform.position = (movingVector.y > 0.0f) ? new Vector3(transform.position.x, yBounds - overshoot, 0.0f) : new Vector3(transform.position.x, -yBounds - overshoot, 0.0f);
                direction = new Vector3(direction.x, -direction.y, 0.0f);
                bounceCount++;
                OnBounce?.Invoke();
                return;
            }
        }

        if (transform.position.x <= xBounds && transform.position.x >= -xBounds && transform.position.y <= yBounds && transform.position.y >= -yBounds && !enteredBorders)
        {
            enteredBorders = true;
        }

        transform.position += movingVector;

        if (transform.position.x > 40.0f || transform.position.x < -40.0f || transform.position.y > 40.0f || transform.position.y < -40.0f)
        {
            Destroy(gameObject);
            return;
        }
    }

    static public event Action OnBounce;
}
