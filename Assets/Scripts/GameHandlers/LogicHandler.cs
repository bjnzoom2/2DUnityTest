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
    static public event Action SpawnBlackHole;
    static public event Action StartGame;
    static public event Action EndGame;

    static public float FinalPhaseTime
    {
        get; private set;
    }

    private void Start()
    {
        FinalPhaseTime = 45.0f;
        StartCoroutine(GameTimeline());
    }

    private IEnumerator GameTimeline()
    {
        bool start = false;
        while (!start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
                break;
            }

            yield return null;
        }

        Debug.Log("Phase 1");
        StartGame?.Invoke();
        BulletsActive = true;
        BombsActive = true;
        BouncersActive = false;
        RadiationActive = false;
        BulletSpawner.spawnInterval = 0.55f;
        BombSpawner.spawnInterval = 2.25f;
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
        BombSpawner.spawnInterval = 2.0f;
        BouncerSpawner.spawnInterval = 6.0f;
        RadiationWaveSpawner.spawnInterval = 0.65f;
        yield return new WaitForSeconds(30.0f);

        Debug.Log("Cutscene 2");
        BulletsActive = false;
        BombsActive = false;
        BouncersActive = false;
        RadiationActive = false;
        yield return new WaitForSeconds(3.5f);
        SpawnCandy?.Invoke();

        float time = 0.0f;
        while (time < 3.0f)
        {
            Camera.main.orthographicSize = Mathf.Lerp(8.07f, 14.0f, time / 3.0f);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        Debug.Log("Phase 3");
        BulletsActive = false;
        BombsActive = false;
        BouncersActive = false;
        RadiationActive = false;
        SpawnBlackHole?.Invoke();
        yield return new WaitForSeconds(FinalPhaseTime);

        Debug.Log("Ending");
        BulletsActive = false;
        BombsActive = false;
        BouncersActive = false;
        RadiationActive = false;
        EndGame?.Invoke();
    }
}
