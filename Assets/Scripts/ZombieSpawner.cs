using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    public int maxZombies = 10;

    public float arenaLimitX = 80f;
    public float arenaLimitZ = 80f;

    int currentZombieCount = 0;

    public Transform player;
    
    public float spawnRadius = 30f;

    public float minSpawnDistance = 4f;

    public float spawnDistance = 40f;
    public float roadWidth = 12f;
    
    
    void Start()
    {
        for(int i = 0; i < maxZombies; i++)
        {
            SpawnZombie();
        }
    }


    public void SpawnZombie()
    {
        if (currentZombieCount >= maxZombies)
            return;

        Vector3 spawnPos = Vector3.zero;
        int attempts = 0;
        bool valid = false;

        while(!valid && attempts < 30)
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;

            spawnPos = new Vector3(
                player.position.x + randomCircle.x,
                0,
                player.position.z + randomCircle.y
            );


            valid = true;

            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");

            foreach(GameObject z in zombies)
            {
                if(Vector3.Distance(spawnPos, z.transform.position) < minSpawnDistance)
                {
                    valid = false;
                    break;
                }
            }

            attempts++;
        }

        Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
        currentZombieCount++;
    }
        

    public void ZombieDied()
    {
        currentZombieCount--;
        SpawnZombie();
    }
}