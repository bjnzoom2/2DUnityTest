using UnityEngine;

interface IHealer
{
    public float HealAmount
    {
        get;
    }
}

public class Candy : MonoBehaviour, IHealer
{
    public float HealAmount
    {
        get; private set;
    }

    private float candySpeed = 7.0f;

    private void Start()
    {
        HealAmount = 50.0f;
    }

    private void Update()
    {
        transform.position += Vector3.right * candySpeed * Time.deltaTime;
        transform.Rotate(0.0f, 0.0f, 50.0f * Time.deltaTime);

        if (transform.position.x > 50.0f || transform.position.x < -50.0f)
        {
            Destroy(gameObject);
            return;
        }
    }
}
