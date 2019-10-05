using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    private Rigidbody2D _rigidbody;
	public float magnetFactor;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.velocity = speed * direction * Time.deltaTime;
    }

    void Update()
    {
		_rigidbody.velocity += magnetFactor * (Vector2)((GameManager.instance.player.transform.position - transform.position).normalized) * Time.deltaTime;
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
		Damageable damageable = collision.gameObject.GetComponent<Damageable>();
		if (damageable)
		{
			damageable.TakeDamage(1);
		}
        Destroy(gameObject);
    }
}
