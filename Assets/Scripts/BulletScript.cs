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
        float angle = Vector3.Angle(Vector3.up, new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, 0));
        if (_rigidbody.velocity.x < 0)
        {
            _rigidbody.SetRotation(angle);
        }
        else
        {
            _rigidbody.SetRotation(-angle);
        }
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
