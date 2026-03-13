using UnityEngine;

public class ZombieWander : MonoBehaviour
{
    public float speed = 1.5f;
    public float changeDirectionTime = 3f;
    public float rotationSpeed = 5f;

    public float arenaLimitX = 18f;
    public float arenaLimitZ = 18f;

    float timer;
    Vector3 direction;

    public float separationDistance = 2.5f;
    public float separationStrength = 2f;

    void Start()
    {
        PickNewDirection();
    }

    void Update()
    {
        MoveZombie();
        KeepInsideArena();

        timer += Time.deltaTime;

        if (timer > changeDirectionTime)
        {
            PickNewDirection();
        }
    }
    // void Update()
    // {
    //     transform.Translate(Vector3.back * speed * Time.deltaTime);
    // }

    void MoveZombie()
    {
        Vector3 separation = Vector3.zero;

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");

        foreach(GameObject z in zombies)
        {
            if(z == gameObject) continue;

            float dist = Vector3.Distance(transform.position, z.transform.position);

            if(dist < separationDistance)
            {
                separation += (transform.position - z.transform.position).normalized;
            }
        }

        Vector3 finalDirection = direction + separation * separationStrength;
        finalDirection.Normalize();

        transform.Translate(finalDirection * speed * Time.deltaTime, Space.World);

        if(finalDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(finalDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    void PickNewDirection()
    {
        timer = 0;

        direction = new Vector3(
            Random.Range(-1f,1f),
            0,
            Random.Range(-1f,1f)
        ).normalized;
    }

    void KeepInsideArena()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -arenaLimitX, arenaLimitX);
        pos.z = Mathf.Clamp(pos.z, -arenaLimitZ, arenaLimitZ);

        transform.position = pos;
    }
}