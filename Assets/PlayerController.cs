using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float maxAcceleration;
	public float maxVelocity;

    private Collider2D _collider;
	private Rigidbody2D _rigidbody;

    private float _lerpTime = 1.0f;
    private float _timer = 0.0f;

	public void Start()
	{
		_collider = GetComponent<Collider2D>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
		Vector2 acceleration = new Vector2(maxAcceleration * Input.GetAxisRaw("Horizontal"), maxAcceleration * Input.GetAxisRaw("Vertical"));

		_rigidbody.velocity += acceleration/10;
		if (_rigidbody.velocity.sqrMagnitude > maxVelocity * maxVelocity)
			_rigidbody.velocity = _rigidbody.velocity.normalized * maxVelocity;
        
        //GameManager.instance.camera.orthographicSize = GameManager.instance.defaultOrthographicSize + _rigidbody.velocity.magnitude/5;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            GameManager.instance.camera.orthographicSize = GameManager.instance.defaultOrthographicSize + _rigidbody.velocity.magnitude / 5;
            _timer = 0.0f;
        }
        else
        {
            _timer += Time.deltaTime;
            GameManager.instance.camera.orthographicSize = GameManager.instance.defaultOrthographicSize + Mathf.Lerp(_rigidbody.velocity.magnitude / 5, 0, _timer / _lerpTime);
        }

        GameManager.instance.camera.transform.position = new Vector3(transform.position.x, transform.position.y, GameManager.instance.camera.transform.position.z);
    }
}
