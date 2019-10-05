using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float range;
    public float speed;

    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManager.instance.player.transform.position - transform.position).magnitude < range)
        {
            _rigidbody.velocity = speed * (GameManager.instance.player.transform.position - transform.position).normalized;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.gameObject.GetComponent<PlayerController>().Heal(5);
        Destroy(gameObject);
    }
}
