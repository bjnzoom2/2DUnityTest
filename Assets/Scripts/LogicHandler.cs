using System.Collections;
using UnityEngine;

public class LogicHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    static public bool BulletsActive
    {
        get; private set;
    }

    static public bool BombsActive
    {
        get; private set;
    }

    static public bool BouncersActive
    {
        get; private set;
    }

    private void Start()
    {
        StartCoroutine(GameTimeline());
    }

    private IEnumerator GameTimeline()
    {
        Debug.Log("Phase 1");
        BulletsActive = true;
        BombsActive = true;
        BouncersActive = false;
        BulletSpawner.spawnInterval = 0.55f;
        BombSpawner.spawnInterval = 2.5f;
        yield return new WaitForSeconds(30.0f);

        Debug.Log("Cutscene 1");
        BulletsActive = false;
        BombsActive = false;
        BouncersActive = false;
        yield return new WaitForSeconds(7.0f);

        Debug.Log("Phase 2");
        BulletsActive = false;
        BombsActive = true;
        BouncersActive = true;
        BombSpawner.spawnInterval = 1.5f;
        BouncerSpawner.spawnInterval = 5.0f;
        yield return new WaitForSeconds(30.0f);

        Debug.Log("Cutscene 2");
        BulletsActive = false;
        BombsActive = false;
        BouncersActive = false;
        yield return new WaitForSeconds(7.0f);

        Debug.Log("Phase 3");
        BulletsActive = true;
        BombsActive = true;
        BouncersActive = true;
        yield return new WaitForSeconds(60.0f);

        Debug.Log("Ending");
        BulletsActive = false;
        BombsActive = false;
        BouncersActive = false;
    }
}
