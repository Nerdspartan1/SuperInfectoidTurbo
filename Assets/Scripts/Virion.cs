using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virion : MonoBehaviour
{
    public enum State
    {
        Orbiting = 0,
        Firing = 1
    }

    public State state;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private float _speed = 2000;
    private Vector2 _randomUnit;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _randomUnit = 2*Random.onUnitSphere;
        state = State.Orbiting;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Orbiting)
        {
            Vector2 direction = new Vector2(GameManager.instance.player.transform.position.x + _randomUnit.x - transform.position.x, GameManager.instance.player.transform.position.y + _randomUnit.y - transform.position.y).normalized;
            _rigidbody.velocity += Vector3.Distance(GameManager.instance.player.transform.position, transform.position) * direction / 10;
        }
    }

    public void Fire(Vector2 direction)
    {
        state = State.Firing;
        gameObject.layer = 13;
        _direction = direction;
        _rigidbody.velocity = _speed * direction * Time.deltaTime;
        _rigidbody.drag = 0;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == State.Firing)
        {
            // layer 8 = enemy
            if (collision.collider.gameObject.layer == 8)
            {
                collision.collider.gameObject.GetComponent<Damageable>().TakeDamage(10);
            }
            Destroy(gameObject);
        }
    }
}
