using UnityEngine;

public class ZombieRagdollController : MonoBehaviour
{
    Rigidbody[] bodies;
    Animator animator;
    ZombieWander wander;

    void Start()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        wander = GetComponent<ZombieWander>();
        Debug.Log("Ragdoll bodies: " + bodies.Length);

        DisableRagdoll();
    }

    void DisableRagdoll()
    {
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = true;
        }
    }

    public void EnableRagdoll(Vector3 force)
    {
        animator.enabled = false;

        if (wander != null)
            wander.enabled = false;

        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = false;
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}