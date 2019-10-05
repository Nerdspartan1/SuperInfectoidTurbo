using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = -velocity.magnitude * 10 * collision.GetContact(0).normal;
    }
}
