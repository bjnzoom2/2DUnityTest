using UnityEngine;

public class RadiationWave : MonoBehaviour, IDamager
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TrailRenderer trailPrefab;
    private TrailRenderer trailInstance;
    public float particleSpeed = 15.0f;
    public float waveMagnitude = 10.0f;
    private float xRandom, yRandom;
    public float Damage
    {
        get; private set;
    }

    void Start()
    {
        Damage = 7.5f;
        trailInstance = Instantiate(trailPrefab, transform.position, Quaternion.identity);
        trailInstance.emitting = true;

        xRandom = UnityEngine.Random.Range(0.5f, 1.5f);
        yRandom = UnityEngine.Random.Range(0.75f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(waveMagnitude * xRandom * Mathf.Sin(transform.position.y) * Time.deltaTime, -(particleSpeed * yRandom * Time.deltaTime), 0.0f);
        trailInstance.transform.position = transform.position;
        if (transform.position.y > 25.0f || transform.position.y < -25.0f)
        {
            Destroy(trailInstance.gameObject);
            Destroy(gameObject);
            return;
        }
    }
}
