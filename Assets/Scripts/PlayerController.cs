﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
	public float maxAcceleration;
	public float maxVelocity;
	public float cellInfectionRadius;

	private Collider2D _collider;
	private Rigidbody2D _rigidbody;
	private Animator _animator;
	private bool _isInfectingCell = false;

	public void Start()
	{
		_collider = GetComponent<Collider2D>();
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

    void Update()
    {
		if (!_isInfectingCell)
		{
			Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

			int animDir;
			if (input.sqrMagnitude > 0.1f)
				animDir = (int)(Mathf.Atan2(input.y, input.x) * 4 / Mathf.PI);
			else
				animDir = -4;

			Debug.Log(animDir);
			_animator.SetInteger("direction", animDir);


			Vector2 acceleration = maxAcceleration * input;

			_rigidbody.velocity += acceleration;
			if (_rigidbody.velocity.sqrMagnitude > maxVelocity * maxVelocity)
				_rigidbody.velocity = _rigidbody.velocity.normalized * maxVelocity;

			if (Input.GetButtonDown("Jump"))
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, cellInfectionRadius);
				foreach(var col in colliders)
				{
					Cell cell = col.GetComponent<Cell>();
					if (cell)
					{
						StartCoroutine(AttackCellCoroutine(cell));
					}
				}
			}
		}

        GameManager.instance.camera.transform.position = new Vector3(transform.position.x, transform.position.y, GameManager.instance.camera.transform.position.z);
    }

	public IEnumerator AttackCellCoroutine(Cell cell)
	{
		_isInfectingCell = true;
		_rigidbody.isKinematic = true;
		_collider.enabled = false;

		Vector3 startPos = transform.position;
		float infectionRate = 1 / 3.0f;

		float infectionPercentage = 0;
		while (infectionPercentage < 1.0)
		{
			infectionPercentage += Time.deltaTime * infectionRate;
			transform.position = Vector3.Lerp(startPos, cell.transform.position , Mathf.Sqrt(infectionPercentage));

			if (Input.GetButtonUp("Jump"))
			{
				_isInfectingCell = false;
				_rigidbody.isKinematic = false;

				transform.position = startPos;
				_rigidbody.velocity = 30*infectionRate*(startPos - cell.transform.position);

				_collider.enabled = true;

				yield break;
			}
			

			yield return null;
		}

		Destroy(cell.gameObject);
		_isInfectingCell = false;
		_rigidbody.isKinematic = false;
		_collider.enabled = true;
	}
}