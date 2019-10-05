using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float maxAcceleration;
	public float maxVelocity;
	private Collider2D _collider;
	private Rigidbody2D _rigidbody;

	public void Start()
	{
		_collider = GetComponent<Collider2D>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
		Vector2 acceleration = new Vector2(maxAcceleration * Input.GetAxisRaw("Horizontal"), maxAcceleration * Input.GetAxisRaw("Vertical"));

		_rigidbody.velocity += acceleration;
		if (_rigidbody.velocity.sqrMagnitude > maxVelocity * maxVelocity)
			_rigidbody.velocity = _rigidbody.velocity.normalized * maxVelocity;

        GameManager.instance.camera.transform.position = new Vector3(transform.position.x, transform.position.y, GameManager.instance.camera.transform.position.z);
    }
}
