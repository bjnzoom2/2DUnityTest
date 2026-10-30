using System.Collections;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    private SpriteRenderer renderer;
    private bool isSwitched = false;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        PlayerHealth.OnHurt += () =>
        {
            StartCoroutine(Flash());
        };
    }

    private void OnDisable()
    {
        PlayerHealth.OnHurt -= () =>
        {
            StartCoroutine(Flash());
        };
    }

    private IEnumerator Flash()
    {
        float timer = 0.0f;
        Color color = renderer.color;

        while (timer < 0.5f)
        {
            color.a = (isSwitched) ? 1.0f : 0.0f;
            renderer.color = color;
            isSwitched = !isSwitched;

            timer += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }

        isSwitched = false;
        color.a = 1.0f;
        renderer.color = color;
    }
}
