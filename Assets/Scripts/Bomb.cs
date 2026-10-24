using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public SpriteRenderer renderer;
    private Color baseColor;
    private GameObject playerTarget;
    private Vector3 targetPosition;
    public float speed = 4.75f;
    private float timer = 0.0f;
    public float duration = 3.0f;
    public float rotationStrength = 800.0f;
    public float rotationEndPercentage = 0.333333f;

    private float rotationValue;
    private float rotationDecay;
    private bool isFlashed = false;
    private float sinceSwitched = 0.0f;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        baseColor = renderer.color;
        playerTarget = GameObject.FindGameObjectWithTag("Player");

        if (playerTarget != null)
        {
            targetPosition = playerTarget.transform.position;
            StartCoroutine(Logic());
        } else
        {
            Destroy(gameObject);
        }

        rotationValue = rotationStrength - rotationStrength * rotationEndPercentage;
        rotationDecay = rotationStrength / duration;
    }

    private IEnumerator Logic()
    {
        while (timer < duration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

            float rotation = rotationValue - rotationDecay * timer;
            if (rotation < 0.0f) { rotation = 0.0f; }

            transform.Rotate(0.0f, 0.0f, rotation * Time.deltaTime);

            if (transform.position.x > 25.0f || transform.position.x < -25.0f)
            {
                Destroy(gameObject);
                yield break;
            }

            float flashInterval = Mathf.Clamp(Mathf.InverseLerp(0.0f, rotationStrength, rotationStrength - rotationDecay * timer), 0.05f, 1.0f);

            sinceSwitched += Time.deltaTime;

            if (sinceSwitched >= flashInterval)
            {
                if (!isFlashed)
                {
                    renderer.color = Color.white;
                    isFlashed = true;
                } else
                {
                    renderer.color = baseColor;
                    isFlashed = false;
                }

                sinceSwitched = 0.0f;
            }

            timer += Time.deltaTime;

            yield return null;
        }

        Debug.Log("Boom");
        Destroy(gameObject);
    }
}
