using UnityEngine;

public class BlackHoleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject blackHolePrefab;

    private void OnEnable()
    {
        LogicHandler.SpawnBlackHole += spawnBlackHole;
    }

    private void spawnBlackHole()
    {
        Instantiate(blackHolePrefab, new Vector3(19.0f, 0.0f, 0.0f), Quaternion.identity);
    }
}
