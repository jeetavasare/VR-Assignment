using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform player;
    public Terrain terrain; 
    public float spawnRadius = 10.0f;
    private int numberOfZombies = 1;

    private void Start()
    {
        StartCoroutine(SpawnZombiesCoroutine());
    }

    private IEnumerator SpawnZombiesCoroutine()
    {
        while (true)
        {
            SpawnZombies();
            yield return new WaitForSeconds(18);
        }
    }

    private void SpawnZombies()
    {
        if (numberOfZombies > 8)
        {
            numberOfZombies = 8;
        }

        for (int i = 0; i < numberOfZombies; i++)
        {
            Vector3 spawnPosition = player.position + Random.insideUnitSphere * spawnRadius;


            spawnPosition.y = 0; // Temporarily set y to 0 to avoid incorrect sampling
            spawnPosition.y = player.position.y;
            // Calculate the correct y-position using the terrain
            //if (terrain != null)
            //{
            //    // Use the terrain's SampleHeight function for the specific (x, z) position
            //    float terrainHeight = terrain.SampleHeight(new Vector3(spawnPosition.x, 0, spawnPosition.z));
            //    Debug.Log(terrainHeight + " this is the height");
            //    spawnPosition.y = terrainHeight;
            //}
            //else
            //{
            //    Debug.LogWarning("Terrain reference is not set. Using default y value.");
            //    spawnPosition.y = -4.8f; // Fallback in case terrain is not assigned
            //}

            Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
        }

        Debug.Log("SPAWNED " + numberOfZombies.ToString() + "       !!!!!!!!!!!!!!!!!!!!!!");

        numberOfZombies = Mathf.Min(numberOfZombies * 2, 16);
    }
}
