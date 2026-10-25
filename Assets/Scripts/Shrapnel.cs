using UnityEngine;

public class Shrapnel : MonoBehaviour, IDamager
{
    public float shrapnelSpeed = 15.0f;
    public float Damage
    {
        get; private set;
    }
    private void Start()
    {
        this.Damage = 15.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.right * shrapnelSpeed * Time.deltaTime;

        if (transform.position.x > 25.0f || transform.position.x < -25.0f || transform.position.y > 25.0f || transform.position.y < -25.0f)
        {
            Destroy(gameObject);
            return;
        }
    }
}
