using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    bool isHit = false;

    ZombieRagdollController ragdoll;
    ZombieSpawner spawner;

    void Start()
    {
        ragdoll = GetComponent<ZombieRagdollController>();
        spawner = FindObjectOfType<ZombieSpawner>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isHit) return;

        if (collision.gameObject.name.Contains("Prometheus"))
        {
            isHit = true;

            Vector3 hitForce = collision.relativeVelocity;
            hitForce.y = Mathf.Abs(hitForce.y) + 2f;
            hitForce *= 2f;

            ZombieRagdollController ragdoll = GetComponentInParent<ZombieRagdollController>();

            if(ragdoll != null)
                ragdoll.EnableRagdoll(hitForce);

            if(ScoreManager.instance != null)
                ScoreManager.instance.AddScore();

            if(spawner != null)
                spawner.ZombieDied();

            Destroy(transform.root.gameObject, 1.5f);
        }
    }
}