using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Vector2 direction;
    public float speed = 2;

    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity += speed * direction * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
