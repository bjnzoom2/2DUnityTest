using System.Collections;
using System;
using UnityEngine;

public class LogicHandler : MonoBehaviour
{
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

    static public bool RadiationActive
    {
        get; private set;
    }

    static public event Action SpawnCandy;

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
        RadiationActive = false;
        BulletSpawner.spawnInterval = 0.55f;
        BombSpawner.spawnInterval = 2.3f;
        yield return new WaitForSeconds(30.0f);

        Debug.Log("Cutscene 1");
        BulletsActive = false;
        BombsActive = false;
        BouncersActive = false;
        RadiationActive = false;
        yield return new WaitForSeconds(3.5f);
        SpawnCandy?.Invoke();
        yield return new WaitForSeconds(3.5f);

        Debug.Log("Phase 2");
        BulletsActive = false;
        BombsActive = true;
        BouncersActive = true;
        RadiationActive = true;
        BombSpawner.spawnInterval = 1.75f;
        BouncerSpawner.spawnInterval = 5.5f;
        RadiationWaveSpawner.spawnInterval = 0.65f;
        yield return new WaitForSeconds(30.0f);

        Debug.Log("Cutscene 2");
        BulletsActive = false;
        BombsActive = false;
        BouncersActive = false;
        RadiationActive = false;
        yield return new WaitForSeconds(3.5f);
        SpawnCandy?.Invoke();
        yield return new WaitForSeconds(3.5f);

        Debug.Log("Phase 3");
        Camera.main.orthographicSize = 14.0f;
        BulletsActive = true;
        BombsActive = true;
        BouncersActive = true;
        RadiationActive = true;
        yield return new WaitForSeconds(60.0f);

        Debug.Log("Ending");
        BulletsActive = false;
        BombsActive = false;
        BouncersActive = false;
        RadiationActive = false;
    }
}
