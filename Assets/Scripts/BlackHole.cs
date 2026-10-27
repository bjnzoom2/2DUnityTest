using System.Threading;
using UnityEngine;

public class BlackHole : MonoBehaviour, IDamager
{
    private GameObject player;
    private float suctionMagnitude = 75.0f;
    private float timer = 0.0f;

    public float Damage
    {
        get; private set;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Damage = 100.0f;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            float distance = Vector3.Distance(playerPosition, transform.position);
            Vector3 direction = new Vector3((playerPosition.x - transform.position.x) / distance, (playerPosition.y - transform.position.y) / distance, 0.0f).normalized;
            player.transform.position -= (suctionMagnitude / distance) * direction * Time.deltaTime;
        }

        if (timer >= LogicHandler.FinalPhaseTime)
        {
            Destroy(gameObject);
            return;
        }

        timer += Time.deltaTime;
    }
}
