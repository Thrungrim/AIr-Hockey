using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }

        if (collision.gameObject.CompareTag("HammerPlayer") || collision.gameObject.CompareTag("HammerOpponent"))
        {
            rb.velocity = new Vector3(rb.velocity.x * 3, 0, rb.velocity.z * 3);
        }

        if (collision.gameObject.CompareTag("Border"))
        {
            rb.velocity = Vector3.Reflect(collision.relativeVelocity * 2, collision.contacts[0].normal);
            //rb.velocity = new Vector3(25, 0, 25);
        }
    }
}
