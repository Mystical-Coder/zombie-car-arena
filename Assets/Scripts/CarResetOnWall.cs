using UnityEngine;

public class CarResetOnWall : MonoBehaviour
{
    // public Vector3 resetPosition = Vector3.zero;
    public Vector3 resetPosition = new Vector3(0,1,0);
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            transform.position = resetPosition;
            transform.rotation = Quaternion.identity;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}