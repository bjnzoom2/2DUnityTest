using UnityEngine;

public class RadiationWave : MonoBehaviour, IDamager
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TrailRenderer trailPrefab;
    private TrailRenderer trailInstance;
    public float particleSpeed = 15.0f;
    public float waveMagnitude = 10.0f;
    public float Damage
    {
        get; private set;
    }

    void Start()
    {
        Damage = 7.5f;
        trailInstance = Instantiate(trailPrefab, transform.position, Quaternion.identity);
        trailInstance.emitting = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(waveMagnitude * Mathf.Sin(transform.position.y) * Time.deltaTime, -(particleSpeed * Time.deltaTime), 0.0f);
        trailInstance.transform.position = transform.position;
        if (transform.position.y > 25.0f || transform.position.y < -25.0f)
        {
            Destroy(gameObject);
            return;
        }
    }
}
