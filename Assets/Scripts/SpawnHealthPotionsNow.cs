using System.Collections;
using UnityEngine;

public class SpawnHealthPotions : MonoBehaviour
{
    public GameObject healthPotionPrefab;
    public Transform player;
    public Terrain terrain;
    public float spawnRadius = 5.0f;
    private int numberOfPotions = 1;

    private void Start()
    {
        StartCoroutine(SpawnHealthPotionsCoroutine());
    }

    private IEnumerator SpawnHealthPotionsCoroutine()
    {
        while (true)
        {
            if (PlayerHealth.health > 0)
            {
                SpawnHealthPotionsNow();
                yield return new WaitForSeconds(15);
            }
        }
    }

    private void SpawnHealthPotionsNow()
    {
        if (numberOfPotions > 2)
        {
            numberOfPotions = 2;
        }

        for (int i = 0; i < numberOfPotions; i++)
        {
            Vector3 spawnPosition = player.position + Random.insideUnitSphere * spawnRadius;


            spawnPosition.y = player.position.y;

            Instantiate(healthPotionPrefab, spawnPosition, Quaternion.identity);
        }

        Debug.Log("SPAWNED " + numberOfPotions.ToString() + "       !!!!!!!!!!!!!!!!!!!!!!");

        numberOfPotions = Mathf.Min(numberOfPotions * 2, 2);
    }
}
