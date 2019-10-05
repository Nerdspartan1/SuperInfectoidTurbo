using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	public float PerlinRate;
	public float PerlinAccelerationFactor;
	private Rigidbody2D _rigidbody;
	private Vector2 _perlinDirection;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_perlinDirection = Random.insideUnitCircle.normalized;
	}

	void Update()
    {

		Vector2 perlinPosition = _perlinDirection * PerlinRate * Time.time;
		Vector2 acceleration = PerlinAccelerationFactor  * new Vector2(Mathf.PerlinNoise(perlinPosition.x, perlinPosition.y) - 0.5f, Mathf.PerlinNoise(perlinPosition.x + 10,perlinPosition.y) -0.5f );
		_rigidbody.velocity += acceleration * Time.deltaTime;
		
	}

	public void Pop()
	{
		EnemiesManager.numberOfCells--;
	}
}
