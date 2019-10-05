using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	public float PerlinRate;
	public float PerlinAccelerationFactor;
	private Rigidbody2D _rigidbody;
	private Collider2D _collider;
	private Vector2 _perlinDirection;
	private Animator _animator;

	public int VirionsDrop = 5;
	public GameObject VirionPrefab;
    public GameObject HealObjectPrefab;
	private VirionManager _virionManager;

	public bool IsPopped=false;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_perlinDirection = Random.insideUnitCircle.normalized;
		_animator = GetComponent<Animator>();
		_virionManager = GameManager.instance.GetComponent<VirionManager>();
		_collider = GetComponent<Collider2D>();
	}

	void Update()
    {
		Vector2 perlinPosition = _perlinDirection * PerlinRate * Time.time;
		Vector2 acceleration = PerlinAccelerationFactor  * new Vector2(Mathf.PerlinNoise(perlinPosition.x, perlinPosition.y) - 0.5f, Mathf.PerlinNoise(perlinPosition.x + 10,perlinPosition.y) -0.5f );
		_rigidbody.velocity += acceleration * Time.deltaTime;
		

	}

	public void StartInfecting()
	{
		_animator.SetBool("panicked", true);
	}

	public void StopInfecting()
	{
		_animator.SetBool("panicked", false);
	}

	public void Pop(bool infected)
	{
		IsPopped = true;
		_animator.SetTrigger("pop");
		_collider.enabled = false;
		Destroy(gameObject,1.0f);
		if (infected)
		{
			EnemiesManager.numberOfCellsDestroyed++;
			for (int i = 0; i < VirionsDrop; i++)
			{
                if (_virionManager.virions.Count < _virionManager.maxVirions)
                {
                    var v = Instantiate(VirionPrefab, transform.position + Random.onUnitSphere, Quaternion.identity, GameManager.instance.Game.transform);
                    _virionManager.virions.Add(v.GetComponent<Virion>());
                }
			}
            int chance = Random.Range(0, 3);
            if (chance == 0)
            {
                Instantiate(HealObjectPrefab, transform.position + Random.onUnitSphere * 3, Quaternion.identity, GameManager.instance.Game.transform);
            }
		}
		EnemiesManager.numberOfCells--;
	}
}
