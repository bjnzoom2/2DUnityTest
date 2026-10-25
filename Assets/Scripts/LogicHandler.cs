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

    private void Start()
    {
        StartCoroutine(GameTimeline());
    }

    private IEnumerator GameTimeline()
    {
        Debug.Log("Phase 1");
        BulletsActive = true;
        BombsActive = true;
        yield return new WaitForSeconds(30.0f);

        Debug.Log("Cutscene 1");
        BulletsActive = false;
        BombsActive = false;
        yield return new WaitForSeconds(5.0f);

        Debug.Log("Phase 2");
        BulletsActive = true;
        BombsActive = true;
        yield return new WaitForSeconds(30.0f);

        Debug.Log("Cutscene 2");
        BulletsActive = false;
        BombsActive = false;
        yield return new WaitForSeconds(5.0f);

        Debug.Log("Phase 3");
        BulletsActive = true;
        BombsActive = true;
        yield return new WaitForSeconds(60.0f);

        Debug.Log("Ending");
        BulletsActive = false;
        BombsActive = false;
    }
}
