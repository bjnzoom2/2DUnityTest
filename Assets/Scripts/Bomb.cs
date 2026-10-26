using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public SpriteRenderer renderer;
    private Color baseColor;
    private GameObject playerTarget;
    private Vector3 targetPosition;
    public float speed = 4.5f;
    private float timer = 0.0f;
    public float duration = 3.0f;
    public float rotationStrength = 800.0f;
    public float rotationEndPercentage = 0.333333f;

    private float rotationValue;
    private float rotationDecay;
    public float implodeBefore = 0.5f;
    private float implodeTime;
    private bool isFlashed = false;
    private float sinceSwitched = 0.0f;
    public GameObject shrapnelPrefab;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        baseColor = renderer.color;
        playerTarget = GameObject.FindGameObjectWithTag("Player");

        if (playerTarget != null)
        {
            targetPosition = playerTarget.transform.position;
        } else
        {
            Destroy(gameObject);
            return;
        }

        rotationValue = rotationStrength - rotationStrength * rotationEndPercentage;
        rotationDecay = rotationStrength / duration;
        implodeTime = duration - implodeBefore;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

        float rotation = rotationValue - rotationDecay * timer;
        if (rotation < 0.0f) { rotation = 0.0f; }

        transform.Rotate(0.0f, 0.0f, rotation * Time.deltaTime);

        if (duration - timer <= 0.5f)
        {
            float implosionProgress = Mathf.InverseLerp(implodeTime, duration, timer);
            float implosionValue = 1.0f - (implosionProgress * implosionProgress * implosionProgress);
            transform.localScale = new Vector3(implosionValue, implosionValue, implosionValue);
        }

        if (transform.position.x > 25.0f || transform.position.x < -25.0f || transform.position.y > 25.0f || transform.position.y < -25.0f)
        {
            Destroy(gameObject);
            return;
        }

        if (timer >= duration)
        {
            float zRotation = transform.eulerAngles.z;

            for (int i = 0; i < 6; i++)
            {
                Instantiate(shrapnelPrefab, transform.position, Quaternion.Euler(0.0f, 0.0f, zRotation + (60.0f * i)));
            }

            Destroy(gameObject);
            return;
        }

        float flashInterval = Mathf.Clamp(Mathf.InverseLerp(0.0f, rotationStrength, rotationStrength - rotationDecay * timer), 0.05f, 0.5f);

        sinceSwitched += Time.deltaTime;

        if (sinceSwitched >= flashInterval)
        {
            if (!isFlashed)
            {
                renderer.color = Color.white;
                isFlashed = true;
            }
            else
            {
                renderer.color = baseColor;
                isFlashed = false;
            }

            sinceSwitched = 0.0f;
        }

        timer += Time.deltaTime;
    }
}